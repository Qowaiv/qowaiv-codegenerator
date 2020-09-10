﻿using CodeGeneration.Roslyn;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Qowaiv.CodeGenerator
{
    public class SvoCodeGenerator : ICodeGenerator
    {
        /// <summary>
        /// A "generated by tool" comment string with environment/os-normalized newlines.
        /// </summary>
        public static readonly string GeneratedByAToolPreamble = @"// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
".Replace("\r\n", "\n").Replace("\n", Environment.NewLine); // normalize regardless of git checkout policy

        public SvoCodeGenerator(AttributeData attributeData)
        {
        }

        public SvoCodeGenerator(SvoArguments arguments)
        {
            Arguments = arguments;
        }


        public SvoArguments Arguments { get; }


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
                .WithModifiers(SyntaxTokenList.Create(SyntaxFactory.Token(SyntaxKind.PartialKeyword)))
    ;
        }

        public async Task<CompilationUnitSyntax> GenerateAsync()
        {
            var defines = new SvoDefine(Arguments);
            var generated = SyntaxTriviaList.Create(SyntaxFactory.Comment(GeneratedByAToolPreamble));
            var defined = defines.AsTrivia();
            var trivia = generated.AddRange(defined);

            var members = new List<MemberDeclarationSyntax>();
            await Structure(members);
            await IEquatable(members);
            await IComparable(members);
            await ISerializable(members);
            await IXmlSerializable(members);
            await IJsonSerializable(members);
            await IFormattable(members);
            await Parsing(members);
            await Validation(members);

            var externs = new SyntaxList<ExternAliasDirectiveSyntax>(Array.Empty<ExternAliasDirectiveSyntax>());
            var usings = new SyntaxList<UsingDirectiveSyntax>(Array.Empty<UsingDirectiveSyntax>());
            var attributes = new SyntaxList<AttributeListSyntax>(Array.Empty<AttributeListSyntax>());

            var compilation = SyntaxFactory.CompilationUnit(externs, usings, attributes, new SyntaxList<MemberDeclarationSyntax>(members));
            return compilation
                .WithLeadingTrivia(trivia)
                .WithTrailingTrivia(SyntaxFactory.CarriageReturnLineFeed)
                .NormalizeWhitespace();

        }

        public async Task<CompilationUnitSyntax> GenerateInitialAsync()
        {
            var root = await SvoSnippet.Embedded("Initial").ParseAsync<NamespaceDeclarationSyntax>(Arguments);

            var externs = new SyntaxList<ExternAliasDirectiveSyntax>(Array.Empty<ExternAliasDirectiveSyntax>());
            var usings = new SyntaxList<UsingDirectiveSyntax>(Array.Empty<UsingDirectiveSyntax>());
            var attributes = new SyntaxList<AttributeListSyntax>(Array.Empty<AttributeListSyntax>());

            var members = SyntaxFactory.SingletonList<MemberDeclarationSyntax>(root);

            return SyntaxFactory.CompilationUnit(externs, usings, attributes, members)
                .WithTrailingTrivia(SyntaxFactory.CarriageReturnLineFeed)
                .NormalizeWhitespace();
        }

        public async Task<CompilationUnitSyntax> GenerateUnitTestsAsync()
        {
            var root = await SvoSnippet.Embedded("UnitTests").ParseAsync<NamespaceDeclarationSyntax>(Arguments);

            var externs = new SyntaxList<ExternAliasDirectiveSyntax>(Array.Empty<ExternAliasDirectiveSyntax>());
            var usings = new SyntaxList<UsingDirectiveSyntax>(Array.Empty<UsingDirectiveSyntax>());
            var attributes = new SyntaxList<AttributeListSyntax>(Array.Empty<AttributeListSyntax>());

            var members = SyntaxFactory.SingletonList<MemberDeclarationSyntax>(root);

            return SyntaxFactory.CompilationUnit(externs, usings, attributes, members)
                .WithTrailingTrivia(SyntaxFactory.CarriageReturnLineFeed)
                .NormalizeWhitespace();

        }


        private async Task Structure(List<MemberDeclarationSyntax> results)
        {
            
            var root = await SvoSnippet.Embedded(nameof(Structure)).ParseAsync<NamespaceDeclarationSyntax>(Arguments);
            results.Add(root);
        }

        private async Task IEquatable(List<MemberDeclarationSyntax> results)
        {
            if (Arguments.LacksFeature(SvoFeatures.IEquatable)) { return; }
            results.Add(await SvoSnippet.Embedded(nameof(IEquatable)).ParseAsync<NamespaceDeclarationSyntax>(Arguments));
        }
        
        private async Task IComparable(List<MemberDeclarationSyntax> results)
        {
            if (Arguments.LacksFeature(SvoFeatures.IComparable)) { return; }
            results.Add(await SvoSnippet.Embedded(nameof(IComparable)).ParseAsync<MemberDeclarationSyntax>(Arguments));
        }

        private async Task IFormattable(List<MemberDeclarationSyntax> results)
        {
            if (Arguments.LacksFeature(SvoFeatures.IFormattable)) { return; }
            results.Add(await SvoSnippet.Embedded(nameof(IFormattable)).ParseAsync<MemberDeclarationSyntax>(Arguments));
        }

        private async Task ISerializable(List<MemberDeclarationSyntax> results)
        {
            if (Arguments.LacksFeature(SvoFeatures.ISerializable)) { return; }
            results.Add(await SvoSnippet.Embedded(nameof(ISerializable)).ParseAsync<MemberDeclarationSyntax>(Arguments));
        }

        private async Task IXmlSerializable(List<MemberDeclarationSyntax> results)
        {
            if (Arguments.LacksFeature(SvoFeatures.IXmlSerializable)) { return; }
            results.Add(await SvoSnippet.Embedded(nameof(IXmlSerializable)).ParseAsync<MemberDeclarationSyntax>(Arguments));
        }

        private async Task IJsonSerializable(List<MemberDeclarationSyntax> results)
        {
            if (Arguments.LacksFeature(SvoFeatures.IJsonSerializable)) { return; }
            results.Add(await SvoSnippet.Embedded(nameof(IJsonSerializable)).ParseAsync<MemberDeclarationSyntax>(Arguments));
        }

        private async Task Parsing(List<MemberDeclarationSyntax> results)
        {
            if (Arguments.LacksFeature(SvoFeatures.Parsing)) { return; }
            results.Add(await SvoSnippet.Embedded(nameof(Parsing)).ParseAsync<MemberDeclarationSyntax>(Arguments));
        }

        private async Task Validation(List<MemberDeclarationSyntax> results)
        {
            if (Arguments.LacksFeature(SvoFeatures.Validation)) { return; }
            results.Add(await SvoSnippet.Embedded(nameof(Validation)).ParseAsync<MemberDeclarationSyntax>(Arguments));
        }
    }
}
