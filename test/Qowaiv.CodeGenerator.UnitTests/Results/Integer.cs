#pragma warning disable S2328
// "GetHashCode" should not reference mutable fields
// See README.md => Hashing

using Qowaiv.CodeGenerator;
using Qowaiv.Formatting;
using Qowaiv.Json;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;

namespace Qowaiv
{
    /// <summary>Represents a Int32 wrapper.</summary>
    [DebuggerDisplay("{DebuggerDisplay}")]
    [Serializable]
    [OpenApiDataType(description: "", type: "string", format: "Integer")]
    [TypeConverter(typeof(Conversion.IntegerTypeConverter))]
    [CodeGenerator.SingleValueObject(typeof(int), "Int32 wrapper",  SvoFeatures.All)]
    public partial struct Integer : IJsonSerializable
    {
        /// <summary>Represents an empty/not set Int32 wrapper.</summary>
        public static readonly Integer Empty;

        /// <summary>Represents an unknown (but set) Int32 wrapper.</summary>
        public static readonly Integer Unknown = new Integer(default);

        /// <summary>Gets a culture dependent message when a <see cref="FormatException"/> occurs.</summary>
        private static readonly string FormatExceptionMessage = "";

        ///// <summary>Gets the number of characters of Int32 wrapper.</summary>
        //public int Length => m_Value == null ? 0 : m_Value.Length;

        /// <summary>Returns a <see cref="string" /> that represents the Int32 wrapper for DEBUG purposes.</summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay => ToString("F", CultureInfo.InvariantCulture);

        /// <summary>Returns a formatted <see cref="string" /> that represents the Int32 wrapper.</summary>
        /// <param name="format">
        /// The format that this describes the formatting.
        /// </param>
        /// <param name="formatProvider">
        /// The format provider.
        /// </param>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (StringFormatter.TryApplyCustomFormatter(format, this, formatProvider, out string formatted))
            {
                return formatted;
            }
            throw new NotImplementedException();
        }

        /// <summary>Gets an XML string representation of the Int32 wrapper.</summary>
        private string ToXmlString() => ToString(CultureInfo.InvariantCulture);

        #region (JSON) (De)serialization

        /// <summary>Generates the Int32 wrapper from a JSON null object representation.</summary>
        void IJsonSerializable.FromJson() => m_Value = default;

        /// <summary>Generates the Int32 wrapper from a JSON string representation.</summary>
        /// <param name="jsonString">
        /// The JSON string that represents the Int32 wrapper.
        /// </param>
        void IJsonSerializable.FromJson(string jsonString) => m_Value = Parse(jsonString, CultureInfo.InvariantCulture).m_Value;

        /// <summary>Generates the Int32 wrapper from a JSON integer representation.</summary>
        /// <param name="jsonInteger">
        /// The JSON integer that represents the Int32 wrapper.
        /// </param>
        void IJsonSerializable.FromJson(long jsonInteger) => throw new NotSupportedException(QowaivMessages.JsonSerialization_Int64NotSupported);
        // m_Value = Create(jsonInteger).m_Value;

        /// <summary>Generates the Int32 wrapper from a JSON number representation.</summary>
        /// <param name="jsonNumber">
        /// The JSON number that represents the Int32 wrapper.
        /// </param>
        void IJsonSerializable.FromJson(double jsonNumber) => throw new NotSupportedException(QowaivMessages.JsonSerialization_DoubleNotSupported);
        // m_Value = Create(jsonNumber).m_Value;

        /// <summary>Generates the Int32 wrapper from a JSON date representation.</summary>
        /// <param name="jsonDate">
        /// The JSON Date that represents the Int32 wrapper.
        /// </param>
        void IJsonSerializable.FromJson(DateTime jsonDate) => throw new NotSupportedException(QowaivMessages.JsonSerialization_DateTimeNotSupported);
        // m_Value = Create(jsonDate).m_Value;

        /// <summary>Converts the Int32 wrapper into its JSON object representation.</summary>
        object IJsonSerializable.ToJson() => m_Value == default ? null : ToString(CultureInfo.InvariantCulture);

        #endregion

        #region (Explicit) casting

        /// <summary>Casts the Int32 wrapper to a <see cref="string" />.</summary>
        public static explicit operator string(Integer val) => val.ToString(CultureInfo.CurrentCulture);
        /// <summary>Casts a <see cref="string" /> to a Int32 wrapper.</summary>
        public static explicit operator Integer(string str) => Parse(str, CultureInfo.CurrentCulture);

        /// <summary>Casts the Int32 wrapper to a <see cref="int" />.</summary>
        public static explicit operator int(Integer val) => val.m_Value;
        /// <summary>Casts a <see cref="int" /> to a Int32 wrapper.</summary>
        public static explicit operator Integer(int val) => new Integer(val);

        #endregion

        /// <summary>Converts the <see cref="string"/> to <see cref="Integer"/>.
        /// A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="s">
        /// A string containing the Int32 wrapper to convert.
        /// </param>
        /// <param name="formatProvider">
        /// The specified format provider.
        /// </param>
        /// <param name="result">
        /// The result of the parsing.
        /// </param>
        /// <returns>
        /// True if the string was converted successfully, otherwise false.
        /// </returns>
        public static bool TryParse(string s, IFormatProvider formatProvider, out Integer result)
        {
            result = default;
            if (string.IsNullOrEmpty(s))
            {
                return true;
            }
            if (Qowaiv.Unknown.IsUnknown(s, formatProvider as CultureInfo))
            {
                result = Unknown;
                return true;
            }
            throw new NotImplementedException();
        }

        #region Validation

        /// <summary>Returns true if the value represents a valid Int32 wrapper.</summary>
        public static bool IsValid(string val) => IsValid(val, CultureInfo.CurrentCulture);

        /// <summary>Returns true if the value represents a valid Int32 wrapper.</summary>
        public static bool IsValid(string val, IFormatProvider formatProvider)
        {
            return !string.IsNullOrWhiteSpace(val)
                && !Qowaiv.Unknown.IsUnknown(val, formatProvider as CultureInfo)
                && TryParse(val, formatProvider, out _);
        }

        #endregion

        /// <summary>Creates the Int32 wrapper based on an XML string.</summary>
        /// <param name="xmlString">
        /// The XML string representing the Int32 wrapper.
        /// </param>
        private static Integer FromXml(string xmlString) => Parse(xmlString, CultureInfo.InvariantCulture);
    }
}

