using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Qowaiv.CodeGenerator
{
    public static class Program
    {
        public static async Task Main(params string[] args)
        {
            try
            {
                if (args == null || args.Length < 3) 
                {
                    Console.WriteLine("Usage: outputDir underlyingType structName [fullName] [namespace]");
                    return;
                }

                var output = new DirectoryInfo(args[0]);

                var arguments = new SvoArguments 
                {
                     Underlying = SimpleType.Parse(args[1]),
                     Name = args[2],
                };

                if (args.Length > 3) { arguments.FullName = args[3]; }
                if (args.Length > 4) { arguments.Namespace = args[4]; }

                var generator = new SvoCodeGenerator(arguments);
                var initial = await generator.GenerateInitialAsync();
                var generated = await generator.GenerateAsync();
                var unitTests = await generator.GenerateUnitTestsAsync();


                var structFile = new FileInfo(Path.Combine(output.FullName, $"{arguments.Name}.cs"));
                var geneFile = new FileInfo(Path.Combine(output.FullName, $"{arguments.Name}.generated.cs"));
                var testFile = new FileInfo(Path.Combine(output.FullName, $"{arguments.Name}Test.cs"));

                using (var writer = new StreamWriter(structFile.FullName, false, Encoding.UTF8))
                {
                    initial.WriteTo(writer);
                }
                using (var writer = new StreamWriter(geneFile.FullName, false, Encoding.UTF8))
                {
                    generated.WriteTo(writer);
                }
                using (var writer = new StreamWriter(testFile.FullName, false, Encoding.UTF8))
                {
                    unitTests.WriteTo(writer);
                }
            }
            catch (Exception x)
            {
                Console.Error.WriteLine(x);
            }
        }
    }
}
