using System.Collections.Immutable;
using System.Composition;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MathKernel.Analyzers
{
    [ExportCodeFixProvider(LanguageNames.CSharp,
        Name = nameof(ConsistentDuplicationCodeFixProvider))]
    [Shared]
    public class ConsistentDuplicationCodeFixProvider : CodeFixProvider
    {
        private const string title = "Make duplicate code consistent.";

        public sealed override ImmutableArray<string> FixableDiagnosticIds
        {
            get { return ImmutableArray.Create(ConsistentDuplicationAnalyzer.DiagnosticId); }
        }

        public sealed override FixAllProvider GetFixAllProvider()
        {
            return WellKnownFixAllProviders.BatchFixer;
        }

        public sealed override async Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            if (context.Diagnostics.Length == 0)
            {
                return;
            }

            var document = context.Document;
            foreach (var diagnostic in context.Diagnostics)
            {
                var root = await document.GetSyntaxRootAsync(context.CancellationToken);
                var classDeclaration = root.FindNode(diagnostic.Location.SourceSpan)
                    as ClassDeclarationSyntax;
                if (classDeclaration == null)
                {
                    continue;
                }
                string rewrite;
                if (!diagnostic.Properties.TryGetValue(nameof(rewrite), out rewrite))
                {
                    continue;
                }
                context.RegisterCodeFix(
                    CodeAction.Create(
                        title,
                        token => MakeConsistent(document, root, classDeclaration, rewrite),
                        equivalenceKey: title),
                    diagnostic);
            }
        }

        private Task<Document> MakeConsistent(
            Document document,
            SyntaxNode root,
            ClassDeclarationSyntax declaration,
            string rewrite)
        {
            var syntaxTree = root.SyntaxTree;
            var text = syntaxTree.GetText().Replace(declaration.Span, rewrite);
            syntaxTree = syntaxTree.WithChangedText(text);
            return Task.FromResult(document.WithSyntaxRoot(syntaxTree.GetRoot()));
        }
    }
}
