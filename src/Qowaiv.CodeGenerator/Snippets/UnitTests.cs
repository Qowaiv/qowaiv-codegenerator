using NUnit.Framework;
using Qowaiv.Globalization;
using Qowaiv.TestTools;
using Qowaiv.TestTools.Formatting;
using Qowaiv.UnitTests.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading;
using System.Xml.Serialization;
using @Model.Namespace;

namespace @Namespace.UnitTests
{
    /// <summary>Tests the @FullName SVO.</summary>
    public class @TSvoTest
    {
        /// <summary>The test instance for most tests.</summary>
        public static readonly @TSvo TestStruct = @TSvo.Parse("");
        public static readonly @TSvo Smaller = @TSvo.Parse("");
        public static readonly @TSvo Bigger = @TSvo.Parse("");

        /// <summary><see cref="@TSvo.Empty"/> should be equal to the default of @FullName.</summary>
        [Test]
        public void Empty_EqualsDefault()
        {
            Assert.AreEqual(default(@TSvo), @TSvo.Empty);
        }

        /// <summary>@TSvo.IsEmpty() should be true for the default of @FullName.</summary>
        [Test]
        public void IsEmpty_Default_IsTrue()
        {
            Assert.IsTrue(default(@TSvo).IsEmpty());
        }
        /// <summary>@TSvo.IsEmpty() should be false for @TSvo.Unknown.</summary>
        [Test]
        public void IsEmpty_Unknown_IsFalse()
        {
            Assert.IsFalse(@TSvo.Unknown.IsEmpty());
        }
        /// <summary>@TSvo.IsEmpty() should be false for the TestStruct.</summary>
        [Test]
        public void IsEmpty_TestStruct_IsFalse()
        {
            Assert.IsFalse(TestStruct.IsEmpty());
        }

        /// <summary>@TSvo.IsUnknown() should be false for the default of @FullName.</summary>
        [Test]
        public void IsUnknown_Default_IsFalse()
        {
            Assert.IsFalse(default(@TSvo).IsUnknown());
        }
        /// <summary>@TSvo.IsUnknown() should be true for @TSvo.Unknown.</summary>
        [Test]
        public void IsUnknown_Unknown_IsTrue()
        {
            Assert.IsTrue(@TSvo.Unknown.IsUnknown());
        }
        /// <summary>@TSvo.IsUnknown() should be false for the TestStruct.</summary>
        [Test]
        public void IsUnknown_TestStruct_IsFalse()
        {
            Assert.IsFalse(TestStruct.IsUnknown());
        }

        /// <summary>@TSvo.IsEmptyOrUnknown() should be true for the default of @FullName.</summary>
        [Test]
        public void IsEmptyOrUnknown_Default_IsFalse()
        {
            Assert.IsTrue(default(@TSvo).IsEmptyOrUnknown());
        }
        /// <summary>@TSvo.IsEmptyOrUnknown() should be true for @TSvo.Unknown.</summary>
        [Test]
        public void IsEmptyOrUnknown_Unknown_IsTrue()
        {
            Assert.IsTrue(@TSvo.Unknown.IsEmptyOrUnknown());
        }
        /// <summary>@TSvo.IsEmptyOrUnknown() should be false for the TestStruct.</summary>
        [Test]
        public void IsEmptyOrUnknown_TestStruct_IsFalse()
        {
            Assert.IsFalse(TestStruct.IsEmptyOrUnknown());
        }

        /// <summary>TryParse null should be valid.</summary>
        [Test]
        public void TryParse_Null_IsValid()
        {
            Assert.IsTrue(@TSvo.TryParse(null, out var val));
            Assert.AreEqual(default(@TSvo), val);
        }

        /// <summary>TryParse string.Empty should be valid.</summary>
        [Test]
        public void TryParse_StringEmpty_IsValid()
        {
            Assert.IsTrue(@TSvo.TryParse(string.Empty, out var val));
            Assert.AreEqual(default(@TSvo), val);
        }

        /// <summary>TryParse "?" should be valid and the result should be @TSvo.Unknown.</summary>
        [Test]
        public void TryParse_Questionmark_IsUnkown()
        {
            string str = "?";
            Assert.IsTrue(@TSvo.TryParse(str, out var val));
            Assert.IsTrue(val.IsUnknown(), "Should be unknown");
        }

        /// <summary>TryParse with specified string value should be valid.</summary>
        [Test]
        public void TryParse_StringValue_IsValid()
        {
            string str = "string";
            Assert.IsTrue(@TSvo.TryParse(str, out var val));
            Assert.AreEqual(str, val.ToString());
        }

        /// <summary>TryParse with specified string value should be invalid.</summary>
        [Test]
        public void TryParse_StringValue_IsNotValid()
        {
            string str = "invalid";
            Assert.IsFalse(@TSvo.TryParse(str, out var val));
            Assert.AreEqual(default(@TSvo), val);
        }

        [Test]
        public void Parse_Unknown_AreEqual()
        {
            using (new CultureInfoScope("en-GB"))
            {
                var act = @TSvo.Parse("?");
                var exp = @TSvo.Unknown;
                Assert.AreEqual(exp, act);
            }
        }

        [Test]
        public void Parse_InvalidInput_ThrowsFormatException()
        {
            using (new CultureInfoScope("en-GB"))
            {
                Assert.Catch<FormatException>
                (() =>
                {
                    @TSvo.Parse("InvalidInput");
                },
                "Not a valid @FullName");
            }
        }

        [Test]
        public void TryParse_TestStructInput_AreEqual()
        {
            using (new CultureInfoScope("en-GB"))
            {
                var exp = TestStruct;
                var act = @TSvo.TryParse(exp.ToString());

                Assert.AreEqual(exp, act);
            }
        }

        [Test]
        public void TryParse_InvalidInput_DefaultValue()
        {
            using (new CultureInfoScope("en-GB"))
            {
                var exp = default(@TSvo);
                var act = @TSvo.TryParse("InvalidInput");

                Assert.AreEqual(exp, act);
            }
        }

        [Test]
        public void Constructor_SerializationInfoIsNull_Throws()
        {
            Assert.Catch<ArgumentNullException>(() =>
               SerializationTest.DeserializeUsingConstructor<@TSvo>(null, default));
        }

        [Test]
        public void Constructor_InvalidSerializationInfo_Throws()
        {
            var info = new SerializationInfo(typeof(@TSvo), new FormatterConverter());

            Assert.Catch<SerializationException>(() =>
                SerializationTest.DeserializeUsingConstructor<@TSvo>(info, default));
        }

        [Test]
        public void GetObjectData_NulSerializationInfo_Throws()
        {
            ISerializable obj = TestStruct;
            Assert.Catch<ArgumentNullException>(() => obj.GetObjectData(null, default));
        }

        [Test]
        public void GetObjectData_SerializationInfo_AreEqual()
        {
            ISerializable obj = TestStruct;
            var info = new SerializationInfo(typeof(@TSvo), new FormatterConverter());
            obj.GetObjectData(info, default);

            Assert.AreEqual((@type)2, info.GetValue("Value", typeof(@type)));
        }

        [Test]
        public void SerializeDeserialize_TestStruct_AreEqual()
        {
            var input = TestStruct;
            var exp = TestStruct;
            var act = SerializationTest.SerializeDeserialize(input);
            Assert.AreEqual(exp, act);
        }
        [Test]
        public void DataContractSerializeDeserialize_TestStruct_AreEqual()
        {
            var input = TestStruct;
            var exp = TestStruct;
            var act = SerializationTest.DataContractSerializeDeserialize(input);
            Assert.AreEqual(exp, act);
        }

        [Test]
        public void XmlSerialize_TestStruct_AreEqual()
        {
            var act = SerializationTest.XmlSerialize(TestStruct);
            var exp = "xmlstring";
            Assert.AreEqual(exp, act);
        }

        [Test]
        public void XmlDeserialize_XmlString_AreEqual()
        {
            var act = SerializationTest.XmlDeserialize<@TSvo>("xmlstring");
            Assert.AreEqual(TestStruct, act);
        }

        [Test]
        public void SerializeDeserialize_@TSvoSerializeObject_AreEqual()
        {
            var input = new @TSvoSerializeObject
            {
                Id = 17,
                Obj = TestStruct,
                Date = new DateTime(1970, 02, 14),
            };
            var exp = new @TSvoSerializeObject
            {
                Id = 17,
                Obj = TestStruct,
                Date = new DateTime(1970, 02, 14),
            };
            var act = SerializationTest.SerializeDeserialize(input);
            Assert.AreEqual(exp.Id, act.Id, "Id");
            Assert.AreEqual(exp.Obj, act.Obj, "Obj");
            Assert.AreEqual(exp.Date, act.Date, "Date");
        }

        [Test]
        public void XmlSerializeDeserialize_@TSvoSerializeObject_AreEqual()
        {
            var input = new @TSvoSerializeObject
            {
                Id = 17,
                Obj = TestStruct,
                Date = new DateTime(1970, 02, 14),
            };
            var exp = new @TSvoSerializeObject
            {
                Id = 17,
                Obj = TestStruct,
                Date = new DateTime(1970, 02, 14),
            };
            var act = SerializationTest.XmlSerializeDeserialize(input);
            Assert.AreEqual(exp.Id, act.Id, "Id");
            Assert.AreEqual(exp.Obj, act.Obj, "Obj");
            Assert.AreEqual(exp.Date, act.Date, "Date");
        }

        [Test]
        public void DataContractSerializeDeserialize_@TSvoSerializeObject_AreEqual()
        {
            var input = new @TSvoSerializeObject
            {
                Id = 17,
                Obj = TestStruct,
                Date = new DateTime(1970, 02, 14),
            };
            var exp = new @TSvoSerializeObject
            {
                Id = 17,
                Obj = TestStruct,
                Date = new DateTime(1970, 02, 14),
            };
            var act = SerializationTest.DataContractSerializeDeserialize(input);
            Assert.AreEqual(exp.Id, act.Id, "Id");
            Assert.AreEqual(exp.Obj, act.Obj, "Obj");
            Assert.AreEqual(exp.Date, act.Date, "Date");
        }

        [Test]
        public void SerializeDeserialize_Default_AreEqual()
        {
            var input = new @TSvoSerializeObject
            {
                Id = 17,
                Obj = default,
                Date = new DateTime(1970, 02, 14),
            };
            var exp = new @TSvoSerializeObject
            {
                Id = 17,
                Obj = default,
                Date = new DateTime(1970, 02, 14),
            };
            var act = SerializationTest.SerializeDeserialize(input);
            Assert.AreEqual(exp.Id, act.Id, "Id");
            Assert.AreEqual(exp.Obj, act.Obj, "Obj");
            Assert.AreEqual(exp.Date, act.Date, "Date");
        }

        [Test]
        public void XmlSerializeDeserialize_Default_AreEqual()
        {
            var input = new @TSvoSerializeObject
            {
                Id = 17,
                Obj = default,
                Date = new DateTime(1970, 02, 14),
            };
            var exp = new @TSvoSerializeObject
            {
                Id = 17,
                Obj = default,
                Date = new DateTime(1970, 02, 14),
            };
            var act = SerializationTest.XmlSerializeDeserialize(input);
            Assert.AreEqual(exp.Id, act.Id, "Id");
            Assert.AreEqual(exp.Obj, act.Obj, "Obj");
            Assert.AreEqual(exp.Date, act.Date, "Date");
        }

        [Test]
        public void GetSchema_None_IsNull()
        {
            IXmlSerializable obj = TestStruct;
            Assert.IsNull(obj.GetSchema());
        }

        [TestCase("Invalid input")]
        [TestCase("2017-06-11")]
        [TestCase(long.MinValue)]
        [TestCase(double.MinValue)]
        public void FromJson_Invalid_Throws(object json)
        {
            Assert.Catch<FormatException>(() => JsonTester.Read<@TSvo>(json));
        }

        [TestCase("yes", "yes")]
        [TestCase("yes", true)]
        [TestCase("yes", 1)]
        [TestCase("no", 0.0)]
        [TestCase("?", "unknown")]
        public void FromJson(@TSvo expected, object json)
        {
            var actual = JsonTester.Read<@TSvo>(json);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToJson_TestStruct_JsonString()
        {
            var act = JsonTester.Write(TestStruct);
            var exp = "JSON STRING";
            Assert.AreEqual(exp, act);
        }

        [Test]
        public void ToString_Empty_StringEmpty()
        {
            var act = @TSvo.Empty.ToString();
            var exp = "";
            Assert.AreEqual(exp, act);
        }

        [Test]
        public void ToString_Unknown_QuestionMark()
        {
            var act = @TSvo.Unknown.ToString();
            var exp = "?";
            Assert.AreEqual(exp, act);
        }

        [Test]
        public void ToString_CustomFormatter_SupportsCustomFormatting()
        {
            var act = TestStruct.ToString("Unit Test Format", new UnitTestFormatProvider());
            var exp = "Unit Test Formatter, value: 'Some Formatted Value', format: 'Unit Test Format'";

            Assert.AreEqual(exp, act);
        }
        [TestCase("en-US", "", "ComplexPattern", "ComplexPattern")]
        [TestCase("nl-BE", null, "1600,1", "1600,1")]
        [TestCase("en-GB", null, "1600.1", "1600.1")]
        [TestCase("nl-BE", "0000", "800", "0800")]
        [TestCase("en-GB", "0000", "800", "0800")]
        public void ToString_UsingCultureWithPattern(string culture, string format, string str, string expected)
        {
            using (new CultureInfoScope(culture))
            {
                var actual = @TSvo.Parse(str).ToString(format);
                Assert.AreEqual(expected, actual);
            }
        }

        [Test]
        public void ToString_FormatValueSpanishEcuador_AreEqual()
        {
            var act = @TSvo.Parse("1700").ToString("00000.0", new CultureInfo("es-EC"));
            var exp = "01700,0";
            Assert.AreEqual(exp, act);
        }

        [Test]
        public void DebuggerDisplay_DebugToString_HasAttribute()
        {
            DebuggerDisplayAssert.HasAttribute(typeof(@TSvo));
        }

        [Test]
        public void DebuggerDisplay_DefaultValue_String()
        {
            DebuggerDisplayAssert.HasResult("ComplexPattern", default(@TSvo));
        }
        [Test]
        public void DebuggerDisplay_Unknown_String()
        {
            DebuggerDisplayAssert.HasResult("ComplexPattern", @TSvo.Unknown);
        }

        [Test]
        public void DebuggerDisplay_TestStruct_String()
        {
            DebuggerDisplayAssert.HasResult("ComplexPattern", TestStruct);
        }

        /// <summary>GetHash should not fail for @TSvo.Empty.</summary>
        [Test]
        public void GetHash_Empty_Hash()
        {
            Assert.AreEqual(-1, @TSvo.Empty.GetHashCode());
        }

        /// <summary>GetHash should not fail for the test struct.</summary>
        [Test]
        public void GetHash_TestStruct_Hash()
        {
            Assert.AreEqual(-1, TestStruct.GetHashCode());
        }

        [Test]
        public void Equals_EmptyEmpty_IsTrue()
        {
            Assert.IsTrue(@TSvo.Empty.Equals(@TSvo.Empty));
        }

        [Test]
        public void Equals_FormattedAndUnformatted_IsTrue()
        {
            var l = @TSvo.Parse("formatted", CultureInfo.InvariantCulture);
            var r = @TSvo.Parse("unformatted", CultureInfo.InvariantCulture);

            Assert.IsTrue(l.Equals(r));
        }

        [Test]
        public void Equals_TestStructTestStruct_IsTrue()
        {
            Assert.IsTrue(TestStruct.Equals(TestStruct));
        }

        [Test]
        public void Equals_TestStructEmpty_IsFalse()
        {
            Assert.IsFalse(TestStruct.Equals(@TSvo.Empty));
        }

        [Test]
        public void Equals_EmptyTestStruct_IsFalse()
        {
            Assert.IsFalse(@TSvo.Empty.Equals(TestStruct));
        }

        [Test]
        public void Equals_TestStructObjectTestStruct_IsTrue()
        {
            Assert.IsTrue(TestStruct.Equals((object)TestStruct));
        }

        [Test]
        public void Equals_TestStructNull_IsFalse()
        {
            Assert.IsFalse(TestStruct.Equals(null));
        }

        [Test]
        public void Equals_TestStructObject_IsFalse()
        {
            Assert.IsFalse(TestStruct.Equals(new object()));
        }

        [Test]
        public void OperatorIs_TestStructTestStruct_IsTrue()
        {
            var l = TestStruct;
            var r = TestStruct;
            Assert.IsTrue(l == r);
        }

        [Test]
        public void OperatorIsNot_TestStructTestStruct_IsFalse()
        {
            var l = TestStruct;
            var r = TestStruct;
            Assert.IsFalse(l != r);
        }

        /// <summary>Orders a list of @FullNames ascending.</summary>
        [Test]
        public void OrderBy_@TSvo_AreEqual()
        {
            var item0 = @TSvo.Parse("ComplexRegexPatternA");
            var item1 = @TSvo.Parse("ComplexRegexPatternB");
            var item2 = @TSvo.Parse("ComplexRegexPatternC");
            var item3 = @TSvo.Parse("ComplexRegexPatternD");

            var inp = new List<@TSvo> { @TSvo.Empty, item3, item2, item0, item1, @TSvo.Empty };
            var exp = new List<@TSvo> { @TSvo.Empty, @TSvo.Empty, item0, item1, item2, item3 };
            var act = inp.OrderBy(item => item).ToList();

            CollectionAssert.AreEqual(exp, act);
        }

        /// <summary>Orders a list of @FullNames descending.</summary>
        [Test]
        public void OrderByDescending_@TSvo_AreEqual()
        {
            var item0 = @TSvo.Parse("ComplexRegexPatternA");
            var item1 = @TSvo.Parse("ComplexRegexPatternB");
            var item2 = @TSvo.Parse("ComplexRegexPatternC");
            var item3 = @TSvo.Parse("ComplexRegexPatternD");

            var inp = new List<@TSvo> { @TSvo.Empty, item3, item2, item0, item1, @TSvo.Empty };
            var exp = new List<@TSvo> { item3, item2, item1, item0, @TSvo.Empty, @TSvo.Empty };
            var act = inp.OrderByDescending(item => item).ToList();

            CollectionAssert.AreEqual(exp, act);
        }

        /// <summary>Compare with a to object casted instance should be fine.</summary>
        [Test]
        public void CompareTo_ObjectTestStruct_0()
        {
            Assert.AreEqual(0, TestStruct.CompareTo((object)TestStruct));
        }

        /// <summary>Compare with null should return 1.</summary>
        [Test]
        public void CompareTo_null_1()
        {
            object @null = null;
            Assert.AreEqual(1, TestStruct.CompareTo(@null));
        }

        /// <summary>Compare with a random object should throw an exception.</summary>
        [Test]
        public void CompareTo_newObject_Throw()
        {
            var x = Assert.Catch<ArgumentException>(() => TestStruct.CompareTo(new object()));
            Assert.AreEqual("Argument must be @TSvo. (Parameter 'obj')", x.Message);
        }

        [Test]
        public void Smaller_LessThan_Bigger_IsTrue()
        {
            Assert.IsTrue(Smaller < Bigger);
        }
        [Test]
        public void Bigger_GreaterThan_Smaller_IsTrue()
        {
            Assert.IsTrue(Bigger > Smaller);
        }

        [Test]
        public void Smaller_LessThanOrEqual_Bigger_IsTrue()
        {
            Assert.IsTrue(Smaller <= Bigger);
        }
        [Test]
        public void Bigger_GreaterThanOrEqual_Smaller_IsTrue()
        {
            Assert.IsTrue(Bigger >= Smaller);
        }

        [Test]
        public void Smaller_LessThanOrEqual_Smaller_IsTrue()
        {
            var left = Smaller;
            var right = Smaller;
            Assert.IsTrue(left <= right);
        }

        [Test]
        public void Smaller_GreaterThanOrEqual_Smaller_IsTrue()
        {
            var left = Smaller;
            var right = Smaller;
            Assert.IsTrue(left >= right);
        }

        [Test]
        public void Explicit_StringTo@TSvo_AreEqual()
        {
            var exp = TestStruct;
            var act = (@TSvo)TestStruct.ToString();

            Assert.AreEqual(exp, act);
        }

        [Test]
        public void Explicit_@TSvoToString_AreEqual()
        {
            var exp = TestStruct.ToString();
            var act = (string)TestStruct;

            Assert.AreEqual(exp, act);
        }

        [Test]
        public void Explicit_Int32To@TSvo_AreEqual()
        {
            var exp = TestStruct;
            var act = (@TSvo)123456789;

            Assert.AreEqual(exp, act);
        }
        [Test]
        public void Explicit_@TSvoToInt32_AreEqual()
        {
            var exp = 123456789;
            var act = (int)TestStruct;

            Assert.AreEqual(exp, act);
        }

        [Test]
        public void Length_DefaultValue_0()
        {
            var exp = 0;
            var act = @TSvo.Empty.Length;
            Assert.AreEqual(exp, act);
        }
        [Test]
        public void Length_TestStruct_IntValue()
        {
            var exp = -10;
            var act = TestStruct.Length;
            Assert.AreEqual(exp, act);
        }

        [Test]
        public void ConverterExists_@TSvo_IsTrue()
        {
            TypeConverterAssert.ConverterExists(typeof(@TSvo));
        }

        [Test]
        public void CanNotConvertFromInt32_@TSvo_IsTrue()
        {
            TypeConverterAssert.CanNotConvertFrom(typeof(@TSvo), typeof(int));
        }

        [Test]
        public void CanNotConvertToInt32_@TSvo_IsTrue()
        {
            TypeConverterAssert.CanNotConvertTo(typeof(@TSvo), typeof(int));
        }

        [Test]
        public void CanConvertFromString_@TSvo_IsTrue()
        {
            TypeConverterAssert.CanConvertFromString(typeof(@TSvo));
        }

        [Test]
        public void CanConvertToString_@TSvo_IsTrue()
        {
            TypeConverterAssert.CanConvertToString(typeof(@TSvo));
        }

        [Test]
        public void ConvertFrom_StringNull_@TSvoEmpty()
        {
            using (new CultureInfoScope("en-GB"))
            {
                TypeConverterAssert.ConvertFromEquals(@TSvo.Empty, (string)null);
            }
        }

        [Test]
        public void ConvertFrom_StringEmpty_@TSvoEmpty()
        {
            using (new CultureInfoScope("en-GB"))
            {
                TypeConverterAssert.ConvertFromEquals(@TSvo.Empty, string.Empty);
            }
        }

        [Test]
        public void ConvertFromString_StringValue_TestStruct()
        {
            using (new CultureInfoScope("en-GB"))
            {
                TypeConverterAssert.ConvertFromEquals(TestStruct, TestStruct.ToString());
            }
        }

        [Test]
        public void ConvertToString_TestStruct_StringValue()
        {
            using (new CultureInfoScope("en-GB"))
            {
                TypeConverterAssert.ConvertToStringEquals(TestStruct.ToString(), TestStruct);
            }
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("Complex")]
        public void IsInvalid_String(string str)
        {
            Assert.IsFalse(@TSvo.IsValid(str));
        }

        [TestCase("ComplexPattern")]
        public void IsValid_String(string str)
        {
            Assert.IsTrue(@TSvo.IsValid(str));
        }

        [Test]
        public void IsValid_DefaultValue_IsFalse()
        {
            @type? value = default;
            Assert.IsFalse(@TSvo.IsValid(value));
        }
    }

    [Serializable]
    public class @TSvoSerializeObject
    {
        public int Id { get; set; }
        public @TSvo Obj { get; set; }
        public DateTime Date { get; set; }
    }
}
