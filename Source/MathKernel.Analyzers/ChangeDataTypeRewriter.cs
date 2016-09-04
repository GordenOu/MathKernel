using System;
using System.Diagnostics;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MathKernel.Analyzers
{
    internal class ChangeDataTypeRewriter : CSharpSyntaxRewriter
    {
        public DataType MainDataType { get; }

        public DataType TargetDataType { get; }

        private string mainDataTypeName;

        private string targetDataTypeName;

        public ChangeDataTypeRewriter(DataType mainDataType, DataType targetDataType)
        {
            Debug.Assert(mainDataType != targetDataType);

            MainDataType = mainDataType;
            TargetDataType = targetDataType;
            mainDataTypeName = GetTypeName(mainDataType);
            targetDataTypeName = GetTypeName(targetDataType);
        }

        private static string GetTypeName(DataType dataType)
        {
            switch (dataType)
            {
                case DataType.Float:
                    return "float";
                case DataType.Double:
                    return "double";
                case DataType.Complexf:
                    return "complexf";
                case DataType.Complex:
                    return "complex";
                default:
                    throw new ArgumentOutOfRangeException(nameof(dataType));
            }
        }

        public override SyntaxNode VisitPredefinedType(PredefinedTypeSyntax node)
        {
            if (MainDataType != DataType.Float)
            {
                return base.VisitPredefinedType(node);
            }
            if (node.ToString() != mainDataTypeName)
            {
                return base.VisitPredefinedType(node);
            }

            if (TargetDataType == DataType.Double)
            {
                var newNode = node.WithKeyword(SyntaxFactory.ParseToken("double"));
                return newNode.WithTriviaFrom(node);
            }
            else
            {
                var newNode = SyntaxFactory.IdentifierName(targetDataTypeName);
                return newNode.WithTriviaFrom(node);
            }
        }

        public override SyntaxNode VisitIdentifierName(IdentifierNameSyntax node)
        {
            if (MainDataType == DataType.Float)
            {
                return base.VisitIdentifierName(node);
            }
            if (node.ToString() != mainDataTypeName)
            {
                return base.VisitIdentifierName(node);
            }

            if (TargetDataType == DataType.Double)
            {
                var newNode = SyntaxFactory.PredefinedType(SyntaxFactory.ParseToken("double"));
                return newNode.WithTriviaFrom(node);
            }
            else
            {
                var newNode = node.WithIdentifier(SyntaxFactory.Identifier(targetDataTypeName));
                return newNode.WithTriviaFrom(node);
            }
        }
    }
}
