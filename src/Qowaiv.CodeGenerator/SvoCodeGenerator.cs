using CodeGeneration.Roslyn;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Qowaiv.CodeGenerator
{
    public class SvoCodeGenerator: ICodeGenerator
    {
        public SvoCodeGenerator(AttributeData attributeData)
        {
        }

        public Task<SyntaxList<MemberDeclarationSyntax>> GenerateAsync(TransformationContext context, IProgress<Diagnostic> progress, CancellationToken cancellationToken)
        {
            if (!(context.ProcessingNode is TypeDeclarationSyntax typeDeclaration))
            {
                return Task.FromResult(SyntaxFactory.List<MemberDeclarationSyntax>());
            }

            if (typeDeclaration is StructDeclarationSyntax structDeclaration)
            {
                var partial = StructPartial(structDeclaration);
                var results = SyntaxFactory.SingletonList(partial);
                return Task.FromResult(results);
            }

            return Task.FromResult(SyntaxFactory.List(Array.Empty<MemberDeclarationSyntax>()));
        }

        private static MemberDeclarationSyntax StructPartial(StructDeclarationSyntax declaration)
        {
            return SyntaxFactory.StructDeclaration(declaration.Identifier)
                .WithTypeParameterList(declaration.TypeParameterList)
                .WithModifiers(SyntaxTokenList.Create(SyntaxFactory.Token(SyntaxKind.PartialKeyword)));
        }
    }
}