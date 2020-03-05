﻿#pragma warning disable S2328
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
    [OpenApiDataType(description: "@FullName", type: "@TSvo", format: "@TSvo")]
    [TypeConverter(typeof(Conversion.@TSvoTypeConverter))]
    public partial struct @TSvo
    {
        /// <summary>Represents an empty/not set @FullName.</summary>
        public static readonly @TSvo Empty;

        /// <summary>Represents an unknown (but set) @FullName.</summary>
        public static readonly @TSvo Unknown = new @TSvo(default);

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

        /// <summary>Deserializes the @FullName from a JSON number.</summary>
        /// <param name="json">
        /// The JSON number to deserialize.
        /// </param>
        /// <returns>
        /// The deserialized @FullName.
        /// </returns>
        public static @TSvo FromJson(double json) => Create(json);

        /// <summary>Deserializes the @FullName from a JSON number.</summary>
        /// <param name="json">
        /// The JSON number to deserialize.
        /// </param>
        /// <returns>
        /// The deserialized @FullName.
        /// </returns>
        public static @TSvo FromJson(long json) => Create(json);

        /// <summary>Deserializes the @FullName from a JSON boolean.</summary>
        /// <param name="json">
        /// The number boolean to deserialize.
        /// </param>
        /// <returns>
        /// The deserialized @FullName.
        /// </returns>
        public static @TSvo FromJson(bool json) => Create(json);

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

#if !NotIConvertible

        /// <summary>Represents the underlying value as <see cref="IConvertible"/>.</summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IConvertible convertable => m_Value;

        /// <inheritdoc/>
        TypeCode IConvertible.GetTypeCode() => TypeCode.@TSvo;
#endif

#if !NotCultureDependent

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
#else
        /// <summary>Converts the <see cref="string"/> to <see cref="@TSvo"/>.
        /// A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="s">
        /// A string containing the @FullName to convert.
        /// </param>
        /// <param name="result">
        /// The result of the parsing.
        /// </param>
        /// <returns>
        /// True if the string was converted successfully, otherwise false.
        /// </returns>
        public static bool TryParse(string s, out @TSvo result)
        {
            result = default;
            if (string.IsNullOrEmpty(s))
            {
                return true;
            }
            if (Qowaiv.Unknown.IsUnknown(s))
            {
                result = Unknown;
                return true;
            }
            throw new NotImplementedException();
        }
#endif
    }
}
