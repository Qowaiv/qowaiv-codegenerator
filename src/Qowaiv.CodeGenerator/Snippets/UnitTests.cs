namespace @TSvo_specs
{
    using NUnit.Framework;
    using Qowaiv.Globalization;
    using Qowaiv.TestTools;
    using Qowaiv.TestTools.Globalization;
    using Qowaiv.UnitTests.Json;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Reflection;
    using System.Runtime.Serialization;
    using System.Threading;
    using System.Xml.Serialization;
    using @Namespace;

    /// <summary>Tests the @FullName SVO.</summary>
    public class OldStyle
    {
        /// <summary>The test instance for most tests.</summary>
        public static readonly @TSvo TestStruct = @TSvo.Parse("");
        public static readonly @TSvo Smaller = @TSvo.Parse("");
        public static readonly @TSvo Bigger = @TSvo.Parse("");

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
    }

    public class With_domain_logic
    {
        [TestCase(false, "SvoValue")]
        [TestCase(false, "?")]
        [TestCase(true, "")]
        public void IsEmpty_returns(bool result, @TSvo svo)
        {
            Assert.AreEqual(result, svo.IsEmpty());
        }

        [TestCase(false, "SvoValue")]
        [TestCase(true, "?")]
        [TestCase(true, "")]
        public void IsEmptyOrUnknown_returns(bool result, @TSvo svo)
        {
            Assert.AreEqual(result, svo.IsEmptyOrUnknown());
        }

        [TestCase(false, "SvoValue")]
        [TestCase(true, "?")]
        [TestCase(false, "")]
        public void IsUnknown_returns(bool result, @TSvo svo)
        {
            Assert.AreEqual(result, svo.IsUnknown());
        }
    }

    public class Is_valid_for
    {
        [TestCase("?")]
        [TestCase("unknown")]
        public void strings_representing_unknown(string input)
        {
            Assert.IsTrue(@TSvo.IsValid(input));
        }

        [TestCase("SvoValue", "nl")]
        [TestCase("SvoValue", "nl")]
        public void strings_representing_SVO(string input, CultureInfo culture)
        {
            Assert.IsTrue(@TSvo.IsValid(input, culture));
        }
    }

    public class Is_not_valid_for
    {
        [Test]
        public void string_empty()
        {
            Assert.IsFalse(@TSvo.IsValid(string.Empty));
        }

        [Test]
        public void string_null()
        {
            Assert.IsFalse(@TSvo.IsValid(null));
        }

        [Test]
        public void whitespace()
        {
            Assert.IsFalse(@TSvo.IsValid(" "));
        }

        [Test]
        public void garbage()
        {
            Assert.IsFalse(@TSvo.IsValid("garbage"));
        }
    }


    public class Has_constant
    {
        [Test]
        public void Empty_represent_default_value()
        {
            Assert.AreEqual(default(@TSvo), @TSvo.Empty);
        }
    }

    public class Is_equal_by_value
    {
        [Test]
        public void not_equal_to_null()
        {
            Assert.IsFalse(Svo.@TSvo.Equals(null));
        }

        [Test]
        public void not_equal_to_other_type()
        {
            Assert.IsFalse(Svo.@TSvo.Equals(new object()));
        }

        [Test]
        public void not_equal_to_different_value()
        {
            Assert.IsFalse(Svo.@TSvo.Equals(@TSvo.Parse("different")));
        }

        [Test]
        public void equal_to_same_value()
        {
            Assert.IsTrue(Svo.@TSvo.Equals(@TSvo.Parse("same")));
        }

        [Test]
        public void equal_operator_returns_true_for_same_values()
        {
            Assert.IsTrue(Svo.@TSvo == @TSvo.Parse("same"));
        }

        [Test]
        public void equal_operator_returns_false_for_different_values()
        {
            Assert.IsFalse(Svo.@TSvo == @TSvo.Parse("different"));
        }

        [Test]
        public void not_equal_operator_returns_false_for_same_values()
        {
            Assert.IsFalse(Svo.@TSvo != @TSvo.Parse("same"));
        }

        [Test]
        public void not_equal_operator_returns_true_for_different_values()
        {
            Assert.IsTrue(Svo.@TSvo != @TSvo.Parse("different"));
        }

        [TestCase("", 0)]
        [TestCase("svoValue", 2)]
        public void hash_code_is_value_based(@TSvo svo, int hashcode)
        {
            Assert.AreEqual(hashcode, svo.GetHashCode());
        }
    }

    public class Can_be_parsed
    {
        [Test]
        public void from_null_string_represents_Empty()
        {
            Assert.AreEqual(@TSvo.Empty, @TSvo.Parse(null));
        }

        [Test]
        public void from_empty_string_represents_Empty()
        {
            Assert.AreEqual(@TSvo.Empty, @TSvo.Parse(string.Empty));
        }

        [Test]
        public void from_question_mark_represents_Unknown()
        {
            Assert.AreEqual(@TSvo.Unknown, @TSvo.Parse("?"));
        }

        [TestCase("en", "validInput")]
        public void from_string_with_different_formatting_and_cultures(CultureInfo culture, string input)
        {
            using (culture.Scoped())
            {
                var parsed = @TSvo.Parse(input);
                Assert.AreEqual(Svo.@TSvo, parsed);
            }
        }

        [Test]
        public void from_valid_input_only_otherwise_throws_on_Parse()
        {
            using (TestCultures.En_GB.Scoped())
            {
                var exception = Assert.Throws<FormatException>(() => @TSvo.Parse("invalid input"));
                Assert.AreEqual("Not a valid SVO value", exception.Message);
            }
        }

        [Test]
        public void from_valid_input_only_otherwise_return_false_on_TryParse()
        {
            Assert.IsFalse(@TSvo.TryParse("invalid input", out _));
        }


        [Test]
        public void from_invalid_as_empty_with_TryParse()
        {
            Assert.AreEqual(default(@TSvo), @TSvo.TryParse("invalid input"));
        }


        [Test]
        public void with_TryParse_returns_SVO()
        {
            Assert.AreEqual(Svo.@TSvo, @TSvo.TryParse("svoValue"));
        }
    }

    public class Has_custom_formatting
    {
        [Test]
        public void default_value_is_represented_as_string_empty()
        {
            Assert.AreEqual(string.Empty, default(@TSvo).ToString());
        }

        [Test]
        public void unknown_value_is_represented_as_unknown()
        {
            Assert.AreEqual("unknown", @TSvo.Unknown.ToString());
        }

        [Test]
        public void custom_format_provider_is_applied()
        {
            var formatted = Svo.@TSvo.ToString("SomeFormat", new UnitTestFormatProvider());
            Assert.AreEqual("Unit Test Formatter, value: 'SvoValue', format: 'SomeFormat'", formatted);
        }

        [TestCase("en-GB", null, "svoValue", "SvoFormat")]
        [TestCase("nl-BE", "f", "svoValue", "SvoFormat")]
        public void culture_dependend(CultureInfo culture, string format, @TSvo svo, string expected)
        {
            using (culture.Scoped())
            {
                Assert.AreEqual(expected, svo.ToString(format));
            }
        }

        [Test]
        public void with_current_thread_culture_as_default()
        {
            using (new CultureInfoScope(
                culture: TestCultures.Nl_NL,
                cultureUI: TestCultures.En_GB))
            {
                Assert.AreEqual("svoValue", Svo.@TSvo.ToString(provider: null));
            }
        }
    }

    public class Is_comparable
    {
        [Test]
        public void to_null()
        {
            Assert.AreEqual(1, Svo.@TSvo.CompareTo(null));
        }

        [Test]
        public void to_@TSvo_as_object()
        {
            object obj = Svo.@TSvo;
            Assert.AreEqual(0, Svo.@TSvo.CompareTo(obj));
        }

        [Test]
        public void to_@TSvo_only()
        {
            Assert.Throws<ArgumentException>(() => Svo.@TSvo.CompareTo(new object()));
        }

        [Test]
        public void can_be_sorted()
        {
            var sorted = new[]
            {
                default(@TSvo),
                default(@TSvo),
                @TSvo.Parse("SvoValue0"),
                @TSvo.Parse("SvoValue1"),
                @TSvo.Parse("SvoValue2"),
            };

            var list = new List<@TSvo> { sorted[3], sorted[4], sorted[2], sorted[0], sorted[1] };
            list.Sort();

            Assert.AreEqual(sorted, list);
        }
    }

    public class Casts
    {
        [Test]
        public void explicitly_from_string()
        {
            var casted = (@TSvo)"SvoValue";
            Assert.AreEqual(Svo.@TSvo, casted);
        }

        [Test]
        public void explicitly_to_string()
        {
            var casted = (string)Svo.@TSvo;
            Assert.AreEqual("SvoValue", casted);
        }

        [Test]
        public void explicitly_from_@type()
        {
            var casted = (@TSvo)null;
            Assert.AreEqual(Svo.@TSvo, casted);
        }

        [Test]
        public void explicitly_to_@type()
        {
            var casted = (@type)Svo.@TSvo;
            Assert.AreEqual(null, casted);
        }
    }

    public class Supports_type_conversion
    {
        [Test]
        public void via_TypeConverter_registered_with_attribute()
        {
            TypeConverterAssert.ConverterExists(typeof(@TSvo));
        }

        [Test]
        public void from_null_string()
        {
            using (TestCultures.En_GB.Scoped())
            {
                TypeConverterAssert.ConvertFromEquals(default(@TSvo), null);
            }
        }

        [Test]
        public void from_empty_string()
        {
            using (TestCultures.En_GB.Scoped())
            {
                TypeConverterAssert.ConvertFromEquals(default(@TSvo), string.Empty);
            }
        }

        [Test]
        public void from_string()
        {
            using (TestCultures.En_GB.Scoped())
            {
                TypeConverterAssert.ConvertFromEquals(Svo.@TSvo, Svo.@TSvo.ToString());
            }
        }

        [Test]
        public void to_string()
        {
            using (TestCultures.En_GB.Scoped())
            {
                TypeConverterAssert.ConvertToStringEquals(Svo.@TSvo.ToString(), Svo.@TSvo);
            }
        }

        [Test]
        public void from_int()
        {
            TypeConverterAssert.ConvertFromEquals(17, Svo.@TSvo);
        }

        [Test]
        public void to_int()
        {
            TypeConverterAssert.ConvertToEquals(17, Svo.@TSvo);
        }
    }

    public class Supports_JSON_serialization
    {
        [TestCase("?", "unknown")]
        public void convension_based_deserialization(@TSvo expected, object json)
        {
            var actual = JsonTester.Read<@TSvo>(json);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(null, "")]
        public void convension_based_serialization(object expected, @TSvo svo)
        {
            var serialized = JsonTester.Write(svo);
            Assert.AreEqual(expected, serialized);
        }

        [TestCase("Invalid input", typeof(FormatException))]
        [TestCase("2017-06-11", typeof(FormatException))]
        [TestCase(5L, typeof(ArgumentOutOfRangeException))]
        public void throws_for_invalid_json(object json, Type exceptionType)
        {
            var exception = Assert.Catch(() => JsonTester.Read<@TSvo>(json));
            Assert.IsInstanceOf(exceptionType, exception);
        }
    }

    public class Supports_XML_serialization
    {
        [Test]
        public void using_XmlSerializer_to_serialize()
        {
            var xml = SerializationTest.XmlSerialize(Svo.@TSvo);
            Assert.AreEqual("xmlValue", xml);
        }

        [Test]
        public void using_XmlSerializer_to_deserialize()
        {
            var svo = SerializationTest.XmlDeserialize<@TSvo>("xmlValue");
            Assert.AreEqual(Svo.@TSvo, svo);
        }

        [Test]
        public void using_DataContractSerializer()
        {
            var round_tripped = SerializationTest.DataContractSerializeDeserialize(Svo.@TSvo);
            Assert.AreEqual(Svo.@TSvo, round_tripped);
        }

        [Test]
        public void as_part_of_a_structure()
        {
            var structure = XmlStructure.New(Svo.@TSvo);
            var round_tripped = SerializationTest.XmlSerializeDeserialize(structure);

            Assert.AreEqual(structure, round_tripped);
        }

        [Test]
        public void has_no_custom_XML_schema()
        {
            IXmlSerializable obj = Svo.@TSvo;
            Assert.IsNull(obj.GetSchema());
        }
    }

    public class Supports_binary_serialization
    {
        [Test]
        public void using_BinaryFormatter()
        {
            var round_tripped = SerializationTest.BinaryFormatterSerializeDeserialize(Svo.@TSvo);
            Assert.AreEqual(Svo.@TSvo, round_tripped);
        }

        [Test]
        public void storing_byte_in_SerializationInfo()
        {
            var info = SerializationTest.GetSerializationInfo(Svo.@TSvo);
            Assert.AreEqual("SerializedValue", info.GetString("Value"));
        }
    }

    public class Debug_experience
    {
        [TestCase("{empty}", "")]
        [TestCase("{unknown}", "?")]
        [TestCase("DebuggerDisplay", "SvoValue")]
        public void with_custom_display(object display, @TSvo svo)
        {
            DebuggerDisplayAssert.HasResult(display, svo);
        }
    }
}
