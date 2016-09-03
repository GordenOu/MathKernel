using System;
using System.Collections.Generic;
using System.IO;
using Core.Clang;
using Microsoft.CodeAnalysis.CSharp;

namespace MathKernel.CodeGeneration
{
    internal static class BLASNativeMethodGenerator
    {
        /// <summary>
        /// Generates the source code in MathKernel/BLASNativeMethods.cs.
        /// </summary>
        /// <param name="fileName">Path to mkl.h.</param>
        /// <returns>The generated contents in MathKernel/BLASNativeMethods.cs.</returns>
        public static string Generate(string fileName)
        {
            var builder = new IndentedStringBuilder()
                .AppendLine("using System.Runtime.InteropServices;")
                .AppendLine()
                .AppendLine("namespace MathKernel")
                .AppendLine("{");
            var methodBuilder = builder
                .IncreaseIndent()
                .AppendLine("internal static unsafe class BLASNativeMethods")
                .AppendLine("{")
                .IncreaseIndent()
                .AppendLine("private const string dllName = \"mkl_rt\";");

            var visitor = new BLASCursorVisitor(methodBuilder);
            using (var index = new Index(true, true))
            using (var translationUnit = index.ParseTranslationUnit(
                fileName,
                new[]
                {
                    "-v",
                    "-I" + new FileInfo(fileName).Directory.FullName
                }))
            {
                visitor.VisitChildren(translationUnit.GetCursor());
            }

            builder.IncreaseIndent().AppendLine("}");
            builder.AppendLine("}");
            return builder.ToString();
        }

        private class BLASCursorVisitor : CursorVisitor
        {
            private IndentedStringBuilder builder;

            public BLASCursorVisitor(IndentedStringBuilder builder)
            {
                this.builder = builder;
            }

            protected override ChildVisitResult Visit(Cursor cursor, Cursor parent)
            {
                if (cursor.GetLocation().IsInSystemHeader())
                {
                    return ChildVisitResult.Continue;
                }

                string fileName = Path.GetFileName(cursor.GetLocation().SourceFile.GetName());
                if (fileName != "mkl_cblas.h")
                {
                    return ChildVisitResult.Continue;
                }

                if (cursor.Kind == CursorKind.FunctionDecl)
                {
                    VisitFunctionDeclaration(cursor);
                }

                return ChildVisitResult.Continue;
            }

            private string GetTypeName(TypeInfo info)
            {
                switch (info.Kind)
                {
                    case TypeKind.Void:
                        return "void";
                    case TypeKind.Bool:
                        return "bool";
                    case TypeKind.Char_U:
                    case TypeKind.UChar:
                        return "byte";
                    case TypeKind.Char16:
                        return "char";
                    case TypeKind.UShort:
                        return "ushort";
                    case TypeKind.UInt:
                        return "uint";
                    case TypeKind.ULongLong:
                        return "ulong";
                    case TypeKind.Char_S:
                    case TypeKind.SChar:
                        return "sbyte";
                    case TypeKind.Short:
                        return "short";
                    case TypeKind.Int:
                        return "int";
                    case TypeKind.LongLong:
                        return "long";
                    case TypeKind.Float:
                        return "float";
                    case TypeKind.Double:
                        return "double";
                    case TypeKind.Pointer:
                        var pointeeType = info.GetPointeeType();
                        if (pointeeType.GetResultType().Kind != TypeKind.Invalid)
                        {
                            // Function pointer.
                            return nameof(IntPtr);
                        }
                        else
                        {
                            return GetTypeName(pointeeType) + '*';
                        }
                    case TypeKind.Auto:
                        return GetTypeName(info.GetCanonicalType());
                    case TypeKind.Typedef:
                        return GetTypeName(info.GetCanonicalType());
                    default:
                        string spelling = info.GetTypeDeclaration().GetSpelling();
                        if (string.IsNullOrEmpty(spelling)) // e.g., typedef struct { } A;
                        {
                            // Clear const qualifiers.
                            spelling = info.GetTypeDeclaration().GetTypeInfo().GetSpelling();
                        }
                        return spelling;
                }
            }

            private void VisitFunctionDeclaration(Cursor cursor)
            {
                string functionName = cursor.GetSpelling();
                if (!functionName.StartsWith("cblas_"))
                {
                    return;
                }

                builder.AppendLine();

                string resultTypeName = GetTypeName(cursor.GetResultType());

                var parameters = new List<string>();
                foreach (var child in cursor.GetChildren())
                {
                    if (child.Kind == CursorKind.ParmDecl)
                    {
                        var parameterType = child.GetTypeInfo();
                        if (parameterType.Kind == TypeKind.Void) // e.g., void foo(void);
                        {
                            break;
                        }
                        string typeName = GetTypeName(parameterType);

                        string parameterName = child.GetSpelling();
                        if (string.IsNullOrEmpty(parameterName))
                        {
                            parameterName = $"arg{parameters.Count + 1}";
                        }
                        // Escape keywords
                        if (SyntaxFacts.GetKeywordKind(parameterName) != SyntaxKind.None)
                        {
                            parameterName = '@' + parameterName;
                        }

                        parameters.Add($"{typeName} {parameterName}");
                    }
                }

                builder.AppendLine($"[DllImport(dllName)]");

                if (parameters.Count == 0)
                {
                    builder.AppendLine($"public static extern {resultTypeName} {functionName}();");
                }
                else
                {
                    builder.AppendLine($"public static extern {resultTypeName} {functionName}(");
                    for (int i = 0; i < parameters.Count; i++)
                    {
                        string end = i == parameters.Count - 1 ? ");" : ",";
                        builder.IncreaseIndent().AppendLine(parameters[i] + end);
                    }
                }
            }
        }
    }
}
