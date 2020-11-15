using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Qowaiv.CodeGenerator.UnitTests
{
    public class Code_generation
    {
        [Test]
        public async Task generate_Int32_based_SVO()
        {
            var args = new SvoArguments 
            { 
                Name = "Integer",
                FullName = "Int32 wrapper",
                Underlying = typeof(int),
                Features = SvoFeatures.Default ^ SvoFeatures.IsEmpty ^ SvoFeatures.IsUnknown,
            };
            var generator = new SvoCodeGenerator(args);

            var result = await generator.GenerateAsync();

            Console.WriteLine(result.ToFullString());
        }

        [Test]
        public async Task generate_initial_SVO()
        {
            var args = new SvoArguments
            {
                Name = "Year",
                Namespace = "Qowaiv",
                FullName = "year",
                Underlying = typeof(short),
                Features = SvoFeatures.All,
            };
            var generator = new SvoCodeGenerator(args);

            var result = await generator.GenerateInitialAsync();

            Console.WriteLine(result.ToFullString());

            Console.WriteLine(new string('-', 80));

            result = await generator.GenerateUnitTestsAsync();

            Console.WriteLine(result.ToFullString());
        }
    }
}
