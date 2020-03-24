using NUnit.Framework;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Qowaiv.CodeGenerator.UnitTests
{
    public class QowaivGeneratedTest
    {
        [TestCase("Date", typeof(DateTime), "date", "Qowaiv", SvoFeatures.Continuous ^ SvoFeatures.Field)]
        [TestCase("DateSpan", typeof(ulong), "date span", "Qowaiv", SvoFeatures.Continuous ^ SvoFeatures.EqualsSvo ^ SvoFeatures.IConvertible)]
        [TestCase("EmailAddress", typeof(string), "email address", "Qowaiv", SvoFeatures.Default)]
        [TestCase("Gender", typeof(byte), "gender", "Qowaiv", SvoFeatures.Default | SvoFeatures.ComparisonOperators)]
        [TestCase("HouseNumber", typeof(int), "house number", "Qowaiv", SvoFeatures.Default | SvoFeatures.ComparisonOperators)]
        [TestCase("LocalDateTime", typeof(DateTime), "local date time", "Qowaiv", SvoFeatures.Continuous ^ SvoFeatures.Field)]
        [TestCase("Month", typeof(byte), "month", "Qowaiv", SvoFeatures.Default | SvoFeatures.ComparisonOperators)]
        [TestCase("Percentage", typeof(decimal), "percentage", "Qowaiv", SvoFeatures.Continuous ^ SvoFeatures.IFormattable)]
        [TestCase("PostalCode", typeof(string), "postal code", "Qowaiv", SvoFeatures.Default)]
        [TestCase("Uuid", typeof(Guid), "UUID", "Qowaiv", SvoFeatures.AllExcludingCulture ^ SvoFeatures.IsUnknown)]
        [TestCase("WeekDate", typeof(Date), "week date", "Qowaiv", SvoFeatures.Continuous ^ SvoFeatures.Field ^ SvoFeatures.ISerializable)]
        [TestCase("Year", typeof(short), "year", "Qowaiv", SvoFeatures.Default | SvoFeatures.ComparisonOperators)]
        [TestCase("YesNo", typeof(byte), "yes-no", "Qowaiv", SvoFeatures.Default)]

        [TestCase("Amount", typeof(decimal), "amount", "Qowaiv.Financial", SvoFeatures.Continuous, "QowaivMessages.FormatExceptionFinancialAmount")]
        [TestCase("BusinessIdentifierCode", typeof(string), "BIC", "Qowaiv.Financial", SvoFeatures.Default)]
        [TestCase("Currency", typeof(string), "currency", "Qowaiv.Financial", SvoFeatures.Default)]
        [TestCase("InternationalBankAccountNumber", typeof(string), "IBAN", "Qowaiv.Financial", SvoFeatures.Default)]
        [TestCase("Money", typeof(decimal), "money", "Qowaiv.Financial", SvoFeatures.Continuous 
            ^ SvoFeatures.ISerializable
            ^ SvoFeatures.EqualsSvo
            ^ SvoFeatures.Field)]

        [TestCase("Country", typeof(string), "country", "Qowaiv.Globalization", SvoFeatures.Default)]

        [TestCase("StreamSize", typeof(long), "stream size", "Qowaiv.IO", SvoFeatures.Continuous ^ SvoFeatures.Field ^ SvoFeatures.IFormattable)]

        [TestCase("CryptographicSeed", typeof(byte[]), "cryptographic seed", "Qowaiv.Security.Cryptography", SvoFeatures.AllExcludingCulture ^ SvoFeatures.IsUnknown ^ SvoFeatures.EqualsSvo)]

        [TestCase("Elo", typeof(double), "elo", "Qowaiv.Statistics", SvoFeatures.Continuous)]

        [TestCase("Fraction", typeof(long), "fraction", "Qowaiv.Mathematics", SvoFeatures.Continuous
            ^ SvoFeatures.ISerializable
            ^ SvoFeatures.EqualsSvo
            ^ SvoFeatures.Field)]

        [TestCase("InternetMediaType", typeof(string), "Internet media type", "Qowaiv.Web", SvoFeatures.AllExcludingCulture)]
        public async Task GenerateAsync_Qowaiv(string name, Type underlying, string fulleName, string ns, SvoFeatures features, string formatExceptionMessage = null)
        {
            var sub = ns.Replace("Qowaiv", "").Replace(".", @"\");
            var path = $@"C:\Code\qowaiv\src\Qowaiv\Generated\{sub}\{name}.generated.cs".Replace(@"\\", @"\");
            await GenerateAsync(name, underlying, fulleName, ns, features, path, formatExceptionMessage);
        }

        [TestCase("Timestamp", typeof(ulong), "timestamp", "Qowaiv.Sql", SvoFeatures.Continuous)]
        public async Task GenerateAsync_QowaivDataClient(string name, Type underlying, string fulleName, string ns, SvoFeatures features, string formatExceptionMessage = null)
        {
            var path = $@"C:\Code\qowaiv\src\Qowaiv.Data.SqlClient\Generated\{name}.generated.cs";
            await GenerateAsync(name, underlying, fulleName, ns, features, path, formatExceptionMessage);
        }

        private static async Task GenerateAsync(string name, Type underlying, string fulleName, string ns, SvoFeatures features, string path, string formatExceptionMessage)
        {
            var arguments = new SvoArguments
            {
                Name = name,
                Underlying = underlying,
                FullName = fulleName,
                Namespace = ns,
                Features = features,
                FormatExceptionMessage = formatExceptionMessage ?? $"QowaivMessages.FormatException{name}"
            };

            var generator = new SvoCodeGenerator(arguments);
            var generated = await generator.GenerateAsync();
            var location = new FileInfo(path);

            if (!location.Directory.Exists)
            {
                location.Directory.Create();
            }
            using var writer = new StreamWriter(location.FullName, false, Encoding.UTF8);
            
            generated.WriteTo(writer);
        }
    }
}
