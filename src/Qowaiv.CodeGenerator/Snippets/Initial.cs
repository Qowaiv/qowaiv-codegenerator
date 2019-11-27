#pragma warning disable S2328
// "GetHashCode" should not reference mutable fields
// See README.md => Hashing

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Serialization;
using Qowaiv;
using Qowaiv.CodeGenerator;
using Qowaiv.Formatting;
using Qowaiv.Json;

namespace @Namespace
{
    /// <summary>Represents a @FullName.</summary>
    [DebuggerDisplay("{DebuggerDisplay}")]
    [Serializable]
    [OpenApiDataType(type: "string", format: "@TSvo")]
    [TypeConverter(typeof(Conversion.@TSvoTypeConverter))]
    [SingleValueObject(typeof(@type), SvoFeatures.Default)]
    public partial struct @TSvo : IJsonSerializable
    {
        /// <summary>Represents an empty/not set @FullName.</summary>
        public static readonly @TSvo Empty;

        /// <summary>Represents an unknown (but set) @FullName.</summary>
        public static readonly @TSvo Unknown = new @TSvo(default);

        /// <summary>Gets a culture dependent message when a <see cref="FormatException"/> occurs.</summary>
        private static readonly string FormatExceptionMessage = QowaivMessages.FormatException@TSvo;

        /// <summary>Gets the number of characters of @FullName.</summary>
        public int Length => m_Value == null ? 0 : m_Value.Length;

        /// <summary>Returns a <see cref="string" /> that represents the @FullName for DEBUG purposes.</summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay => ToString("F", CultureInfo.InvariantCulture);

        /// <summary>Returns a formatted <see cref="string" /> that represents the @FullName.</summary>
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

        /// <summary>Gets an XML string representation of the @FullName.</summary>
        private string ToXmlString() => ToString(CultureInfo.InvariantCulture);

        #region (JSON) (De)serialization

        /// <summary>Generates the @FullName from a JSON null object representation.</summary>
        void IJsonSerializable.FromJson() => m_Value = default;

        /// <summary>Generates the @FullName from a JSON string representation.</summary>
        /// <param name="jsonString">
        /// The JSON string that represents the @FullName.
        /// </param>
        void IJsonSerializable.FromJson(string jsonString) => m_Value = Parse(jsonString, CultureInfo.InvariantCulture).m_Value;

        /// <summary>Generates the @FullName from a JSON integer representation.</summary>
        /// <param name="jsonInteger">
        /// The JSON integer that represents the @FullName.
        /// </param>
        void IJsonSerializable.FromJson(long jsonInteger) => throw new NotSupportedException(QowaivMessages.JsonSerialization_Int64NotSupported);
        // m_Value = Create(jsonInteger).m_Value;

        /// <summary>Generates the @FullName from a JSON number representation.</summary>
        /// <param name="jsonNumber">
        /// The JSON number that represents the @FullName.
        /// </param>
        void IJsonSerializable.FromJson(double jsonNumber) => throw new NotSupportedException(QowaivMessages.JsonSerialization_DoubleNotSupported);
        // m_Value = Create(jsonNumber).m_Value;

        /// <summary>Generates the @FullName from a JSON date representation.</summary>
        /// <param name="jsonDate">
        /// The JSON Date that represents the @FullName.
        /// </param>
        void IJsonSerializable.FromJson(DateTime jsonDate) => throw new NotSupportedException(QowaivMessages.JsonSerialization_DateTimeNotSupported);
        // m_Value = Create(jsonDate).m_Value;

        /// <summary>Converts the @FullName into its JSON object representation.</summary>
        object IJsonSerializable.ToJson() => m_Value == default ? null : ToString(CultureInfo.InvariantCulture);

        #endregion

        #region (Explicit) casting

        /// <summary>Casts the @FullName to a <see cref="string" />.</summary>
        public static explicit operator string(@TSvo val) => val.ToString(CultureInfo.CurrentCulture);
        /// <summary>Casts a <see cref="string" /> to a @FullName.</summary>
        public static explicit operator @TSvo(string str) => Parse(str, CultureInfo.CurrentCulture);

        /// <summary>Casts the @FullName to a <see cref="@type" />.</summary>
        public static explicit operator @type(@TSvo val) => val.m_Value;
        /// <summary>Casts a <see cref="@type" /> to a @FullName.</summary>
        public static explicit operator @TSvo(@type val) => Create(val);

        #endregion

        /// <summary>Converts the <see cref="string"/> to <see cref="@TSvo"/>.
        /// A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="s">
        /// A string containing the @FullName to convert.
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
        public static bool TryParse(string s, IFormatProvider formatProvider, out @TSvo result)
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

        /// <summary>Returns true if the value represents a valid @FullName.</summary>
        public static bool IsValid(string val) => IsValid(val, CultureInfo.CurrentCulture);

        /// <summary>Returns true if the value represents a valid @FullName.</summary>
        public static bool IsValid(string val, IFormatProvider formatProvider)
        {
            return !string.IsNullOrWhiteSpace(val)
                && !Qowaiv.Unknown.IsUnknown(val, formatProvider as CultureInfo)
                && TryParse(val, formatProvider, out _);
        }

        #endregion

        /// <summary>Creates the @FullName based on an XML string.</summary>
        /// <param name="xmlString">
        /// The XML string representing the @FullName.
        /// </param>
        private static @TSvo FromXml(string xmlString) => Parse(xmlString, CultureInfo.InvariantCulture);
    }
}
