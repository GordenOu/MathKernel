using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using MathKernel.Analyzers.Resources;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace MathKernel.Analyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class ConsistentDuplicationAnalyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = nameof(ConsistentDuplicationAnalyzer);

        private static readonly string Title = Strings.Title;
        private static readonly string MessageFormat = Strings.MessageFormat;
        private static readonly string Description = Strings.Description;
        private const string Category = "Duplication";

        private static DiagnosticDescriptor rule = new DiagnosticDescriptor(
            DiagnosticId,
            Title,
            MessageFormat,
            Category,
            DiagnosticSeverity.Warning,
            isEnabledByDefault: true,
            description: Description);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics =>
            ImmutableArray.Create(rule);

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSymbolAction(AnalyzeSymbol, SymbolKind.NamedType);
        }

        private static ImmutableArray<ImmutableArray<string>> dataTypeNames =
            ImmutableArray.Create(
                ImmutableArray.Create("float", "double", "complexf", "complex"),
                ImmutableArray.Create("float", "double"),
                ImmutableArray.Create("complexf", "complex"));

        private static DataType GetDataType(string typeName)
        {
            if (typeName == "float")
            {
                return DataType.Float;
            }
            else if (typeName == "double")
            {
                return DataType.Double;
            }
            else if (typeName == "complexf")
            {
                return DataType.Complexf;
            }
            else if (typeName == "complex")
            {
                return DataType.Complex;
            }
            else
            {
                throw new ArgumentException(nameof(typeName));
            }
        }

        private static void AnalyzeSymbol(SymbolAnalysisContext context)
        {
            AnalyzeSymbol(context, "Duplicate", dataTypeNames[0]);
            AnalyzeSymbol(context, "RealTypeDuplicate", dataTypeNames[1]);
            AnalyzeSymbol(context, "ComplexTypeDuplicate", dataTypeNames[2]);
        }

        private static void AnalyzeSymbol(
            SymbolAnalysisContext context,
            string attributeName,
            ImmutableArray<string> typeNames)
        {
            var namedTypeSymbol = (INamedTypeSymbol)context.Symbol;

            // Check attribute.
            var attributes =
                (from attribute in namedTypeSymbol.GetAttributes()
                 where attribute.AttributeClass.Name == attributeName + "Attribute"
                 select attribute).ToArray();
            if (attributes.Length == 0)
            {
                return;
            }

            // Retrieve partial class declarations.
            var partialClassDeclarations = namedTypeSymbol.DeclaringSyntaxReferences
                .Select(reference => reference.GetSyntax() as ClassDeclarationSyntax)
                .ToArray();
            if (partialClassDeclarations.Length <= 1)
            {
                return;
            }

            // Associate partial class declarations for each data type.
            var partialClasses = new Dictionary<DataType, ClassDeclarationSyntax>();
            foreach (var declaration in partialClassDeclarations)
            {
                var duplicateAttribute = declaration.AttributeLists
                    .SelectMany(list => list.Attributes)
                    .SingleOrDefault(attribute => attribute.Name.ToString() == attributeName);
                if (duplicateAttribute == null)
                {
                    continue;
                }
                var argument = duplicateAttribute.ArgumentList.Arguments.FirstOrDefault();
                if (argument == null)
                {
                    continue;
                }
                var typeOfExpressionSyntax = argument
                    .ChildNodes()
                    .FirstOrDefault()
                    as TypeOfExpressionSyntax;
                if (typeOfExpressionSyntax == null)
                {
                    continue;
                }
                string dataTypeName = typeOfExpressionSyntax.Type.ToString();
                if (!typeNames.Contains(dataTypeName))
                {
                    continue;
                }
                var dataType = GetDataType(dataTypeName);
                if (partialClasses.Keys.Contains(dataType))
                {
                    return;
                }
                partialClasses[dataType] = declaration;
            }

            // Separate main declaration from others.
            DataType mainDataType;
            ClassDeclarationSyntax mainDeclaration;
            if (partialClasses.TryGetValue(DataType.Float, out mainDeclaration))
            {
                mainDataType = DataType.Float;
            }
            else if (partialClasses.TryGetValue(DataType.Complexf, out mainDeclaration))
            {
                mainDataType = DataType.Complexf;
            }
            else
            {
                return;
            }
            foreach (var keyValue in partialClasses.Where(x => x.Key != mainDataType))
            {
                var rewriter = new ChangeDataTypeRewriter(mainDataType, keyValue.Key);
                var newDeclaration = rewriter.Visit(mainDeclaration);
                if (keyValue.Value.ToFullString() != newDeclaration.ToFullString())
                {
                    var builder = ImmutableDictionary.CreateBuilder<string, string>();
                    builder.Add("rewrite", newDeclaration.ToFullString());
                    var diagnostic = Diagnostic.Create(
                        rule,
                        keyValue.Value.GetLocation(),
                        properties: builder.ToImmutable());
                    context.ReportDiagnostic(diagnostic);
                }
            }
        }
    }
}
