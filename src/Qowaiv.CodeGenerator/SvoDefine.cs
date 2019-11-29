using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Qowaiv.CodeGenerator
{
    public class SvoDefine
    {
        public SvoDefine(SvoArguments args) => Args = args;

        private SvoArguments Args { get; }

        public bool NotCultureDependent => Args.LacksFeature(SvoFeatures.CultureDependent);

        public bool NotField => Args.LacksFeature(SvoFeatures.Field);
        public bool NotIsEmpty => Args.LacksFeature(SvoFeatures.IsEmpty);
        public bool NotIsUnknown => Args.LacksFeature(SvoFeatures.IsUnknown);
        public bool NotIsEmptyOrUnknown => NotIsEmpty || NotIsUnknown;

        public bool NoComparisonOperators => Args.LacksFeature(SvoFeatures.ComparisonOperators);
        public bool NotEqualsSvo => Args.LacksFeature(SvoFeatures.EqualsSvo);
        public bool NotGetHashCodeStruct => Args.LacksFeature(SvoFeatures.GetHashCode) || Args.Underlying.IsClass;
        public bool NotGetHashCodeClass => Args.LacksFeature(SvoFeatures.GetHashCode) || Args.Underlying.IsValueType;

        public IEnumerable<string> Active
        {
            get
            {
                var props = GetType().GetProperties();

                foreach (var prop in props)
                {
                    var value = prop.GetValue(this, Array.Empty<object>());

                    if (value is bool b && b)
                    {
                        yield return prop.Name;
                    }
                }
            }
        }
    
        private IEnumerable<DefineDirectiveTriviaSyntax> ActiveDefines
        {
            get => Active.Select(name => SyntaxFactory.DefineDirectiveTrivia(name, isActive: true).NormalizeWhitespace());
        }

        public SyntaxTriviaList AsTrivia()
        {
            var defines = ActiveDefines.Select(d => SyntaxFactory.Trivia(d));
            var trivia = SyntaxFactory.TriviaList(defines);
            return trivia;

        }
    }
}
