﻿    using NUnit.Framework;
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

            #region @FullName const tests

            /// <summary>@TSvo.Empty should be equal to the default of @FullName.</summary>
            [Test]
            public void Empty_None_EqualsDefault()
            {
                Assert.AreEqual(default(@TSvo), @TSvo.Empty);
            }

            #endregion

            #region @FullName IsEmpty tests

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

            #endregion

            #region TryParse tests

            /// <summary>TryParse null should be valid.</summary>
            [Test]
            public void TyrParse_Null_IsValid()
            {
                Assert.IsTrue(@TSvo.TryParse((string)null, out var val));
                Assert.AreEqual(default(@TSvo), val);
            }

            /// <summary>TryParse string.Empty should be valid.</summary>
            [Test]
            public void TyrParse_StringEmpty_IsValid()
            {
                Assert.IsTrue(@TSvo.TryParse(string.Empty, out var val));
                Assert.AreEqual(default(@TSvo), val);
            }

            /// <summary>TryParse "?" should be valid and the result should be @TSvo.Unknown.</summary>
            [Test]
            public void TyrParse_Questionmark_IsUnkown()
            {
                string str = "?";
                Assert.IsTrue(@TSvo.TryParse(str, out var val));
                Assert.IsTrue(val.IsUnknown(), "Should be unknown");
            }

            /// <summary>TryParse with specified string value should be valid.</summary>
            [Test]
            public void TyrParse_StringValue_IsValid()
            {
                string str = "string";
                Assert.IsTrue(@TSvo.TryParse(str, out var val));
                Assert.AreEqual(str, val.ToString());
            }

            /// <summary>TryParse with specified string value should be invalid.</summary>
            [Test]
            public void TyrParse_StringValue_IsNotValid()
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
                    "Not a valid @(Model.ClassLongName)");
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

            #endregion


            #region (XML) (De)serialization tests

            [Test]
            public void Constructor_SerializationInfoIsNull_ThrowsArgumentNullException()
            {
                ExceptionAssert.CatchArgumentNullException
                (() =>
                {
                    SerializationTest.DeserializeUsingConstructor<@TSvo>(null, default(StreamingContext));
                },
                "info");
            }

            [Test]
            public void Constructor_InvalidSerializationInfo_ThrowsSerializationException()
            {
                Assert.Catch<SerializationException>
                (() =>
                {
                    var info = new SerializationInfo(typeof(@TSvo), new System.Runtime.Serialization.FormatterConverter());
                    SerializationTest.DeserializeUsingConstructor<@TSvo>(info, default(StreamingContext));
                });
            }

            [Test]
            public void GetObjectData_Null_ThrowsArgumentNullException()
            {
                ExceptionAssert.CatchArgumentNullException
                (() =>
                {
                    ISerializable obj = TestStruct;
                    obj.GetObjectData(null, default(StreamingContext));
                },
                "info");
            }

            [Test]
            public void GetObjectData_SerializationInfo_AreEqual()
            {
                ISerializable obj = TestStruct;
                var info = new SerializationInfo(typeof(@TSvo), new System.Runtime.Serialization.FormatterConverter());
                obj.GetObjectData(info, default(StreamingContext));

                Assert.AreEqual((@Type)2, info.GetValue("Value", typeof(@Type)));
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
                var act = SerializationTest.XmlDeserialize<Model.ClassNameSerializeObject>("xmlstring");
                Assert.AreEqual(TestStruct, act);
            }

            [Test]
            public void SerializeDeserialize_@TSvoSerializeObject_AreEqual()
            {
                var input = new @TSvoSerializeObject()
                {
                    Id = 17,
                    Obj = TestStruct,
                    Date = new DateTime(1970, 02, 14),
                };
                var exp = new @TSvoSerializeObject()
                {
                    Id = 17,
                    Obj = TestStruct,
                    Date = new DateTime(1970, 02, 14),
                };
                var act = SerializationTest.SerializeDeserialize(input);
                Assert.AreEqual(exp.Id, act.Id, "Id");
                Assert.AreEqual(exp.Obj, act.Obj, "Obj");
                Assert.AreEqual(exp.Date, act.Date, "Date"); ;
            }
            [Test]
            public void XmlSerializeDeserialize_@TSvoSerializeObject_AreEqual()
            {
                var input = new @TSvoSerializeObject()
                {
                    Id = 17,
                    Obj = TestStruct,
                    Date = new DateTime(1970, 02, 14),
                };
                var exp = new @TSvoSerializeObject()
                {
                    Id = 17,
                    Obj = TestStruct,
                    Date = new DateTime(1970, 02, 14),
                };
                var act = SerializationTest.XmlSerializeDeserialize(input);
                Assert.AreEqual(exp.Id, act.Id, "Id");
                Assert.AreEqual(exp.Obj, act.Obj, "Obj");
                Assert.AreEqual(exp.Date, act.Date, "Date"); ;
            }
            [Test]
            public void DataContractSerializeDeserialize_@TSvoSerializeObject_AreEqual()
            {
                var input = new @TSvoSerializeObject()
                {
                    Id = 17,
                    Obj = TestStruct,
                    Date = new DateTime(1970, 02, 14),
                };
                var exp = new @TSvoSerializeObject()
                {
                    Id = 17,
                    Obj = TestStruct,
                    Date = new DateTime(1970, 02, 14),
                };
                var act = SerializationTest.DataContractSerializeDeserialize(input);
                Assert.AreEqual(exp.Id, act.Id, "Id");
                Assert.AreEqual(exp.Obj, act.Obj, "Obj");
                Assert.AreEqual(exp.Date, act.Date, "Date"); ;
            }

            [Test]
            public void SerializeDeserialize_Default_AreEqual()
            {
                var input = new @TSvoSerializeObject()
                {
                    Id = 17,
                    Obj = default,
                    Date = new DateTime(1970, 02, 14),
                };
                var exp = new @TSvoSerializeObject()
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
                var input = new @TSvoSerializeObject()
                {
                    Id = 17,
                    Obj = default,
                    Date = new DateTime(1970, 02, 14),
                };
                var exp = new @TSvoSerializeObject()
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

            #endregion

            #region JSON (De)serialization tests

            [Test]
            public void FromJson_None_EmptyValue()
            {
                var act = JsonTester.Read<@TSvo>
                 ();
                var exp = @TSvo.Empty;

                Assert.AreEqual(exp, act);
            }
            [Test]
            public void FromJson_Null_AssertNotSupportedException()
            {
                Assert.Catch<NotSupportedException>
                (() =>
                {
                    JsonTester.Read<@TSvo>
                     ();
                },
                "JSON deserialization from null is not supported.");
            }

            [Test]
            public void FromJson_InvalidStringValue_AssertFormatException()
            {
                Assert.Catch<FormatException>
                (() =>
                {
                    JsonTester.Read<@TSvo>
                     ("InvalidStringValue");
                },
                "Not a valid @FullName");
            }
            [Test]
            public void FromJson_StringValue_AreEqual()
            {
                var act = JsonTester.Read<@TSvo>("JsonRepresentationString");
                Assert.AreEqual(TestStruct, act);
            }

            [Test]
            public void FromJson_Int64Value_AreEqual()
            {
                var act = JsonTester.Read<@TSvo>(123456789L);
                Assert.AreEqual(TestStruct, act);
            }
            [Test]
            public void FromJson_Int64Value_AssertNotSupportedException()
            {
                Assert.Catch<NotSupportedException>
                (() =>
                {
                    JsonTester.Read<@TSvo>
                     (123456L);
                },
                "JSON deserialization from an integer is not supported.");
            }

            [Test]
            public void FromJson_DoubleValue_AreEqual()
            {
                var act = JsonTester.Read<@TSvo>
                 ((Double)TestStruct);
                var exp = TestStruct;

                Assert.AreEqual(exp, act);
            }
            [Test]
            public void FromJson_DoubleValue_AssertNotSupportedException()
            {
                Assert.Catch<NotSupportedException>
                (() =>
                {
                    JsonTester.Read<@TSvo>
                     (1234.56);
                },
                "JSON deserialization from a number is not supported.");
            }

            [Test]
            public void FromJson_DateTimeValue_AreEqual()
            {
                var act = JsonTester.Read<@TSvo>
                 ((DateTime)TestStruct);
                var exp = TestStruct;

                Assert.AreEqual(exp, act);
            }
            [Test]
            public void FromJson_DateTimeValue_AssertNotSupportedException()
            {
                Assert.Catch<NotSupportedException>
                (() =>
                {
                    JsonTester.Read<@TSvo>
                     (new DateTime(1972, 02, 14));
                },
                "JSON deserialization from a date is not supported.");
            }

            [Test]
            public void ToJson_DefaultValue_IsNull()
            {
                object act = JsonTester.Write(default(@TSvo));
                Assert.IsNull(act);
            }
            [Test]
            public void ToJson_TestStruct_AreEqual()
            {
                var act = JsonTester.Write(TestStruct);
                var exp = "Some JSON string";
                Assert.AreEqual(exp, act);
            }

            #endregion

            #region IFormattable / Tostring tests

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

            #endregion

            #region IEquatable tests

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

            #endregion

            #region IComparable tests

            /// <summary>Orders a list of @(Model.ClassLongName)s ascending.</summary>
            [Test]
            public void OrderBy_@TSvo_AreEqual()
            {
                var item0 = @TSvo.Parse("ComplexRegexPatternA");
                var item1 = @TSvo.Parse("ComplexRegexPatternB");
                var item2 = @TSvo.Parse("ComplexRegexPatternC");
                var item3 = @TSvo.Parse("ComplexRegexPatternD");

                var inp = new List<@TSvo>
                () { @TSvo.Empty, item3, item2, item0, item1, @TSvo.Empty };
                var exp = new List<@TSvo>
                () { @TSvo.Empty, @TSvo.Empty, item0, item1, item2, item3 };
                var act = inp.OrderBy(item => item).ToList();

                CollectionAssert.AreEqual(exp, act);
            }

            /// <summary>Orders a list of @(Model.ClassLongName)s descending.</summary>
            [Test]
            public void OrderByDescending_@TSvo_AreEqual()
            {
                var item0 = @TSvo.Parse("ComplexRegexPatternA");
                var item1 = @TSvo.Parse("ComplexRegexPatternB");
                var item2 = @TSvo.Parse("ComplexRegexPatternC");
                var item3 = @TSvo.Parse("ComplexRegexPatternD");

                var inp = new List<@TSvo>
                () { @TSvo.Empty, item3, item2, item0, item1, @TSvo.Empty };
                var exp = new List<@TSvo>
                () { item3, item2, item1, item0, @TSvo.Empty, @TSvo.Empty };
                var act = inp.OrderByDescending(item => item).ToList();

                CollectionAssert.AreEqual(exp, act);
            }

            /// <summary>Compare with a to object casted instance should be fine.</summary>
            [Test]
            public void CompareTo_ObjectTestStruct_0()
            {
                object other = TestStruct;

                var exp = 0;
                var act = TestStruct.CompareTo(other);

                Assert.AreEqual(exp, act);
            }

            /// <summary>Compare with null should throw an exception.</summary>
            [Test]
            public void CompareTo_null_ThrowsArgumentException()
            {
                ExceptionAssert.CatchArgumentException
                (() =>
                {
                    TestStruct.CompareTo(null);
                },
                "obj",
                "Argument must be @(Model.a) @(Model.ClassLongName)"
                );
            }
            /// <summary>Compare with a random object should throw an exception.</summary>
            [Test]
            public void CompareTo_newObject_ThrowsArgumentException()
            {
                ExceptionAssert.CatchArgumentException
                (() =>
                {
                    TestStruct.CompareTo(new object());
                },
                "obj",
                "Argument must be @(Model.a) @(Model.ClassLongName)"
                );
            }

            [Test]
            public void LessThan_17LT19_IsTrue()
            {
                @TSvol = 17;
                @TSvor = 19;

                Assert.IsTrue(l < r);
            }
            [Test]
            public void GreaterThan_21LT19_IsTrue()
            {
                @TSvol = 21;
                @TSvor = 19;

                Assert.IsTrue(l > r);
            }

            [Test]
            public void LessThanOrEqual_17LT19_IsTrue()
            {
                @TSvol = 17;
                @TSvor = 19;

                Assert.IsTrue(l <= r);
            }
            [Test]
            public void GreaterThanOrEqual_21LT19_IsTrue()
            {
                @TSvol = 21;
                @TSvor = 19;

                Assert.IsTrue(l >= r);
            }

            [Test]
            public void LessThanOrEqual_17LT17_IsTrue()
            {
                @TSvol = 17;
                @TSvor = 17;

                Assert.IsTrue(l <= r);
            }
            [Test]
            public void GreaterThanOrEqual_21LT21_IsTrue()
            {
                @TSvol = 21;
                @TSvor = 21;

                Assert.IsTrue(l >= r);
            }
            #endregion

            #region Casting tests

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
                var act = (Int32)TestStruct;

                Assert.AreEqual(exp, act);
            }
            #endregion

            #region Properties

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
            #endregion

            #region Type converter tests

            [Test]
            public void ConverterExists_@TSvo_IsTrue()
            {
                TypeConverterAssert.ConverterExists(typeof(@TSvo));
            }

            [Test]
            public void CanNotConvertFromInt32_@TSvo_IsTrue()
            {
                TypeConverterAssert.CanNotConvertFrom(typeof(@TSvo), typeof(Int32));
            }
            [Test]
            public void CanNotConvertToInt32_@TSvo_IsTrue()
            {
                TypeConverterAssert.CanNotConvertTo(typeof(@TSvo), typeof(Int32));
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
            public void ConvertFrom_StringNull_@TSvo Empty()
            {
                using (new CultureInfoScope("en-GB"))
                {
                    TypeConverterAssert.ConvertFromEquals(@TSvo.Empty, (string)null);
                }
            }

            [Test]
            public void ConvertFrom_StringEmpty_@TSvo Empty()
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

            #endregion
            #region IsValid tests

            [TestCase(null)]
            [TestCase("")]
            [TestCase("Complex")]
            public void IsInvalid_String(string pattern)
            {
                Assert.IsFalse(@TSvo.IsValid(pattern));
            }


            [Test]
            public void IsInvalid_@Type()
            {
                @Type? value = default;
                Assert.IsFalse(@TSvo.IsValid(value));
            }
            [Test]
            public void IsValid_Data_IsTrue()
            {
                Assert.IsTrue(@TSvo.IsValid("ComplexPattern"));
            }
            #endregion
        }

        [Serializable]
        public class @TSvoSerializeObject
        {
            public int Id { get; set; }
            public @TSvo Obj { get; set; }
            public DateTime Date { get; set; }
        }
    }
