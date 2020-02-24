using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Qowaiv.CodeGenerator.UnitTests
{
    public class SvoCodeGeneratorTest
    {
        [Test]
        public async Task Generate_Int32Based_()
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
        public async Task GenerateInitial_Int32Based_()
        {
            var args = new SvoArguments
            {
                Name = "Fraction",
                Namespace = "Qowaiv.Mathematics",
                FullName = "fraction",
                Underlying = typeof(long),
                Features = SvoFeatures.Continuous ^ SvoFeatures.ISerializable
                ^ SvoFeatures.EqualsSvo
                ^ SvoFeatures.Field,
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
