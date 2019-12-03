using CodeGeneration.Roslyn;
using System;
using System.IO;

namespace Qowaiv.CodeGenerator
{
    internal sealed class SvoSnippet : CSharpCodeSnippet<SvoArguments>
    {
        private SvoSnippet(string text, string fileName) : base(text, fileName, null) { }

        protected override string TransformText(SvoArguments arguments)
        {
            return Text
                .Replace("@TSvo", arguments.Name)
                .Replace("@FullName", arguments.FullName)
                .Replace("@Namespace", arguments.Namespace)
                .Replace("@type", arguments.Type)
                .Replace("@FormatExceptionMessage", arguments.FormatExceptionMessage)
            ;
        }

        public static SvoSnippet Embedded(string name)
        {
            var path = $"Qowaiv.CodeGenerator.Snippets.{name}.cs";

            using (var stream = typeof(SvoSnippet).Assembly.GetManifestResourceStream(path))
            {
                if (stream is null)
                {
                    throw new ArgumentException($"The path '{path}' is not a stream.", nameof(name));
                }
                using (var reader = new StreamReader(stream))
                {
                    return new SvoSnippet(reader.ReadToEnd(), $"{name}.cs");
                }
            }
        }
    }
}
