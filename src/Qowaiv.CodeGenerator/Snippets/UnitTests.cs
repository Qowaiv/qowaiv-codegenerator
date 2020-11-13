namespace @TSvo_specs
{
    using NUnit.Framework;
    using Qowaiv.Globalization;
    using Qowaiv.TestTools;
    using Qowaiv.TestTools.Formatting;
    using Qowaiv.UnitTests.Json;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Reflection;
    using System.Runtime.Serialization;
    using System.Threading;
    using System.Xml.Serialization;
    using @Model.Namespace;

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

    public class Has_constant
    {
        [Test]
        public void Empty_represent_default_value()
        {
            Assert.AreEqual(default(@Svo), @Svo.Empty);
        }
    }

    public class Is_equal_by_value
    {
        [Test]
        public void not_equal_to_null()
        {
            Assert.IsFalse(Svo.@Svo.Equals(null));
        }

        [Test]
        public void not_equal_to_other_type()
        {
            Assert.IsFalse(Svo.@Svo.Equals(new object()));
        }

        [Test]
        public void not_equal_to_different_value()
        {
            Assert.IsFalse(Svo.@Svo.Equals(@Svo.Parse("different")));
        }

        [Test]
        public void equal_to_same_value()
        {
            Assert.IsTrue(Svo.@Svo.Equals(@Svo.Parse("same")));
        }

        [Test]
        public void equal_operator_returns_true_for_same_values()
        {
            Assert.IsTrue(Svo.@Svo == @Svo.Parse("same"));
        }

        [Test]
        public void equal_operator_returns_false_for_different_values()
        {
            Assert.IsFalse(Svo.@Svo == @Svo.Parse("different"));
        }

        [Test]
        public void not_equal_operator_returns_false_for_same_values()
        {
            Assert.IsFalse(Svo.@Svo != @Svo.Parse("same"));
        }

        [Test]
        public void not_equal_operator_returns_true_for_different_values()
        {
            Assert.IsTrue(Svo.@Svo != @Svo.Parse("different"));
        }

        [TestCase("", 0)]
        [TestCase("svoValue", 2)]
        public void hash_code_is_value_based(@Svo svo, int hashcode)
        {
            Assert.AreEqual(hashcode, svo.GetHashCode());
        }

    }

    public class Can_be_parsed
    {
        [Test]
        public void from_null_string_represents_Empty()
        {
            Assert.AreEqual(@Svo.Empty, @Svo.Parse(null));
        }

        [Test]
        public void from_empty_string_represents_Empty()
        {
            Assert.AreEqual(@Svo.Empty, @Svo.Parse(string.Empty));
        }

        [Test]
        public void from_question_mark_represents_Unknown()
        {
            Assert.AreEqual(@Svo.Unknown, @Svo.Parse("?"));
        }

        [TestCase("en", "validInput")]
        public void from_string_with_different_formatting_and_cultures(CultureInfo culture, string input)
        {
            using (culture.Scoped())
            {
                var parsed = @Svo.Parse(input);
                Assert.AreEqual(Svo.@Svo, parsed);
            }
        }

        [Test]
        public void from_valid_input_only_otherwise_throws_on_Parse()
        {
            using (TestCultures.En_GB.Scoped())
            {
                var exception = Assert.Throws<FormatException>(() => @Svo.Parse("invalid input"));
                Assert.AreEqual("Not a valid SVO value", exception.Message);
            }
        }

        [Test]
        public void from_valid_input_only_otherwise_return_false_on_TryParse()
        {
            Assert.IsFalse(@Svo.TryParse("invalid input", out _));
        }
    }

    public class Has_custom_formatting
    {
        [Test]
        public void default_value_is_represented_as_string_empty()
        {
            Assert.AreEqual(string.Empty, default(@Svo).ToString());
        }

        [Test]
        public void unknown_value_is_represented_as_unknown()
        {
            Assert.AreEqual("unknown", @Svo.Unknown.ToString());
        }

        [Test]
        public void custom_format_provider_is_applied()
        {
            var formatted = Svo.@Svo.ToString("SomeFormat", new UnitTestFormatProvider());
            Assert.AreEqual("Unit Test Formatter, value: 'SvoValue', format: 'SomeFormat'", formatted);
        }

        [TestCase("en-GB", null, "Yes", "yes")]
        [TestCase("nl-BE", "f", "Yes", "ja")]
        [TestCase("es-EQ", "F", "Yes", "Si")]
        [TestCase("en-GB", null, "No", "no")]
        [TestCase("nl-BE", "f", "No", "nee")]
        [TestCase("es-EQ", "F", "No", "No")]
        [TestCase("en-GB", "C", "Yes", "Y")]
        [TestCase("nl-BE", "C", "Yes", "J")]
        [TestCase("es-EQ", "C", "Yes", "S")]
        [TestCase("en-GB", "C", "No", "N")]
        [TestCase("nl-BE", "c", "No", "n")]
        [TestCase("es-EQ", "c", "No", "n")]
        [TestCase("en-US", "B", "Yes", "True")]
        [TestCase("en-US", "b", "No", "false")]
        [TestCase("en-US", "i", "Yes", "1")]
        [TestCase("en-US", "i", "No", "0")]
        [TestCase("en-US", "i", "?", "?")]
        public void culture_dependend(CultureInfo culture, string format, YesNo svo, string expected)
        {
            using (culture.Scoped())
            {
                Assert.AreEqual(expected, svo.ToString(format));
            }
        }
    }

    public class Is_comparable
    {
        [Test]
        public void to_null()
        {
            Assert.AreEqual(1, Svo.@Svo.CompareTo(null));
        }

        [Test]
        public void to_@Svo_only()
        {
            Assert.Throws<ArgumentException>(() => Svo.@Svo.CompareTo(new object()));
        }

        [Test]
        public void can_be_sorted()
        {
            var sorted = new[]
            {
                default(@Svo),
                default(@Svo),
                @Svo.Parse("SvoValue0"),
                @Svo.Parse("SvoValue1"),
                @Svo.Parse("SvoValue2"),
            };

            var list = new List<@Svo> { sorted[3], sorted[4], sorted[2], sorted[0], sorted[1] };
            list.Sort();

            Assert.AreEqual(sorted, list);
        }
    }

    public class Casts
    {
        [Test]
        public void explicitly_from_string()
        {
            var casted = (@Svo)"SvoValue";
            Assert.AreEqual(Svo.@Svo, casted);
        }

        [Test]
        public void explicitly_to_string()
        {
            var casted = (string)Svo.@Svo;
            Assert.AreEqual("SvoValue", casted);
        }

        [Test]
        public void explicitly_from_@type()
        {
            var casted = (@Svo)null;
            Assert.AreEqual(Svo.@Svo, casted);
        }

        [Test]
        public void explicitly_to_@type()
        {
            var casted = (@type)Svo.@Svo;
            Assert.AreEqual(null, casted);
        }
    }

    public class Supports_type_conversion
    {
        [Test]
        public void via_TypeConverter_registered_with_attribute()
        {
            TypeConverterAssert.ConverterExists(typeof(@Svo));
        }

        [Test]
        public void from_null_string()
        {
            using (TestCultures.En_GB.Scoped())
            {
                TypeConverterAssert.ConvertFromEquals(default(@Svo), null);
            }
        }

        [Test]
        public void from_empty_string()
        {
            using (TestCultures.En_GB.Scoped())
            {
                TypeConverterAssert.ConvertFromEquals(default(@Svo), string.Empty);
            }
        }

        [Test]
        public void from_string()
        {
            using (TestCultures.En_GB.Scoped())
            {
                TypeConverterAssert.ConvertFromEquals(Svo.@Svo, Svo.@Svo.ToString());
            }
        }

        [Test]
        public void to_string()
        {
            using (TestCultures.En_GB.Scoped())
            {
                TypeConverterAssert.ConvertToStringEquals(Svo.@Svo.ToString(), Svo.@Svo);
            }
        }

        [Test]
        public void from_int()
        {
            TypeConverterAssert.ConvertFromEquals(17, Svo.@Svo);
        }

        [Test]
        public void to_int()
        {
            TypeConverterAssert.ConvertToEquals(17, Svo.@Svo);
        }
    }

    public class Supports_JSON_serialization
    {
        [TestCase("?", "unknown")]
        public void convension_based_deserialization(@Svo expected, object json)
        {
            var actual = JsonTester.Read<@Svo>(json);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(null, "")]
        public void convension_based_serialization(object expected, @Svo svo)
        {
            var serialized = JsonTester.Write(svo);
            Assert.AreEqual(expected, serialized);
        }

        [TestCase("Invalid input", typeof(FormatException))]
        [TestCase("2017-06-11", typeof(FormatException))]
        [TestCase(5L, typeof(ArgumentOutOfRangeException))]
        public void throws_for_invalid_json(object json, Type exceptionType)
        {
            var exception = Assert.Catch(() => JsonTester.Read<@Svo>(json));
            Assert.IsInstanceOf(exceptionType, exception);
        }
    }

    public class Supports_XML_serialization
    {
        [Test]
        public void using_XmlSerializer_to_serialize()
        {
            var xml = SerializationTest.XmlSerialize(Svo.@Svo);
            Assert.AreEqual("yes", xml);
        }

        [Test]
        public void using_XmlSerializer_to_deserialize()
        {
            var svo = SerializationTest.XmlDeserialize<YesNo>("yes");
            Assert.AreEqual(Svo.@Svo, svo);
        }

        [Test]
        public void using_DataContractSerializer()
        {
            var round_tripped = SerializationTest.DataContractSerializeDeserialize(Svo.@Svo);
            Assert.AreEqual(Svo.@Svo, round_tripped);
        }

        [Test]
        public void as_part_of_a_structure()
        {
            var structure = XmlStructure.New(Svo.@Svo);
            var round_tripped = SerializationTest.XmlSerializeDeserialize(structure);

            Assert.AreEqual(structure, round_tripped);
        }

        [Test]
        public void has_no_custom_XML_schema()
        {
            IXmlSerializable obj = Svo.@Svo;
            Assert.IsNull(obj.GetSchema());
        }
    }

    public class Supports_binary_serialization
    {
        [Test]
        public void using_BinaryFormatter()
        {
            var round_tripped = SerializationTest.BinaryFormatterSerializeDeserialize(Svo.@Svo);
            Assert.AreEqual(Svo.@Svo, round_tripped);
        }

        [Test]
        public void storing_byte_in_SerializationInfo()
        {
            var info = SerializationTest.GetSerializationInfo(Svo.@Svo);
            Assert.AreEqual("SerializedValue", info.GetString("Value"));
        }
    }
}
