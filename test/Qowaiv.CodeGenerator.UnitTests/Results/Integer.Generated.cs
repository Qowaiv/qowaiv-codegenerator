﻿#define NotIsEmpty
#define NotIsUnknown
#define NotIsEmptyOrUnknown
#define NotGetHashCodeClass
namespace Qowaiv
{
    public partial struct Integer
    {
#if !NotField
        private Integer(int value) => m_Value = value;

        /// <summary>The inner value of the Int32 wrapper.</summary>
        private int m_Value;
#endif

#if !NotIsEmpty
        /// <summary>Returns true if the  Int32 wrapper is empty, otherwise false.</summary>
        public bool IsEmpty() => m_Value == default;
#endif
#if !NotIsUnknown
        /// <summary>Returns true if the  Int32 wrapper is unknown, otherwise false.</summary>
        public bool IsUnknown() => m_Value == Unknown.m_Value;
#endif
#if !NotIsEmptyOrUnknown
        /// <summary>Returns true if the  Int32 wrapper is empty or unknown, otherwise false.</summary>
        public bool IsEmptyOrUnknown() => IsEmpty() || IsUnknown();
#endif
    }
}
namespace Qowaiv
{
    using System;

    public partial struct Integer : IEquatable<Integer>
    {
#if !NotEqualsSvo
        /// <summary>Returns true if this instance and the other Int32 wrapper are equal, otherwise false.</summary>
        /// <param name="other">The <see cref="Integer" /> to compare with.</param>
        public bool Equals(Integer other) => m_Value == other.m_Value;
#endif
        /// <inheritdoc />
        public override bool Equals(object obj) => obj is Integer other && Equals(other);

#if !NotGetHashCodeStruct
        /// <inheritdoc />
        public override int GetHashCode() => m_Value.GetHashCode();
#endif
#if !NotGetHashCodeClass
        /// <inheritdoc />
        public override int GetHashCode() => m_Value is null ? 0 : m_Value.GetHashCode();
#endif
        /// <summary>Returns true if the left and right operand are equal, otherwise false.</summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand</param>
        public static bool operator !=(Integer left, Integer right) => !(left == right);

        /// <summary>Returns true if the left and right operand are not equal, otherwise false.</summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand</param>
        public static bool operator ==(Integer left, Integer right) => left.Equals(right);
    }
}
namespace Qowaiv
{
    using System;
    using System.Collections.Generic;

    public partial struct Integer : IComparable, IComparable<Integer>
    {
        /// <inheritdoc />
        public int CompareTo(object obj)
        {
            if (obj is Integer other)
            {
                return CompareTo(other);
            }
            throw new ArgumentException($"Argument must be {GetType().Name}.", nameof(obj));
        }

        /// <inheritdoc />
        public int CompareTo(Integer other) => Comparer<int>.Default.Compare(m_Value, other.m_Value);

#if !NoComparisonOperators
        /// <summary>Returns true if the left operator is less then the right operator, otherwise false.</summary>
        public static bool operator <(Integer l, Integer r) => l.CompareTo(r) < 0;

        /// <summary>Returns true if the left operator is greater then the right operator, otherwise false.</summary>
        public static bool operator >(Integer l, Integer r) => l.CompareTo(r) > 0;

        /// <summary>Returns true if the left operator is less then or equal the right operator, otherwise false.</summary>
        public static bool operator <=(Integer l, Integer r) => l.CompareTo(r) <= 0;

        /// <summary>Returns true if the left operator is greater then or equal the right operator, otherwise false.</summary>
        public static bool operator >=(Integer l, Integer r) => l.CompareTo(r) >= 0;
#endif
    }
}
namespace Qowaiv
{
    using System.Runtime.Serialization;

    public partial struct Integer : ISerializable
    {
        /// <summary>Initializes a new instance of the Int32 wrapper based on the serialization info.</summary>
        /// <param name="info">The serialization info.</param>
        /// <param name="context">The streaming context.</param>
        private Integer(SerializationInfo info, StreamingContext context)
        {
            Guard.NotNull(info, nameof(info));
            m_Value = (int)info.GetValue("Value", typeof(int));
        }

        /// <summary>Adds the underlying property of the Int32 wrapper to the serialization info.</summary>
        /// <param name="info">The serialization info.</param>
        /// <param name="context">The streaming context.</param>
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Guard.NotNull(info, nameof(info));
            info.AddValue("Value", m_Value);
        }
    }
}
namespace Qowaiv
{
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    public partial struct Integer : IXmlSerializable
    {
        /// <summary>Gets the <see href="XmlSchema" /> to XML (de)serialize the Int32 wrapper.</summary>
        /// <remarks>
        /// Returns null as no schema is required.
        /// </remarks>
        XmlSchema IXmlSerializable.GetSchema() => null;

        /// <summary>Reads the Int32 wrapper from an <see href="XmlReader" />.</summary>
        /// <remarks>
        /// Uses <see cref="FromXml(string)"/>.
        /// </remarks>
        /// <param name="reader">An XML reader.</param>
        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            Guard.NotNull(reader, nameof(reader));
            var s = reader.ReadElementString();
            var val = FromXml(s);
            m_Value = val.m_Value;
        }

        /// <summary>Writes the Int32 wrapper to an <see href="XmlWriter" />.</summary>
        /// <remarks>
        /// Uses <see cref="ToXmlString()"/>.
        /// </remarks>
        /// <param name="writer">An XML writer.</param>
        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            Guard.NotNull(writer, nameof(writer));
            writer.WriteString(ToXmlString());
        }
    }
}
namespace Qowaiv
{
    using System;
    using System.Globalization;

    public partial struct Integer : IFormattable
    {
        /// <summary>Returns a <see cref="string" /> that represents the Int32 wrapper.</summary>
        public override string ToString() => ToString(CultureInfo.CurrentCulture);

        /// <summary>Returns a formatted <see cref="string" /> that represents the Int32 wrapper.</summary>
        /// <param name="format">
        /// The format that this describes the formatting.
        /// </param>
        public string ToString(string format) => ToString(format, CultureInfo.CurrentCulture);

        /// <summary>Returns a formatted <see cref="string" /> that represents the Int32 wrapper.</summary>
        /// <param name="formatProvider">
        /// The format provider.
        /// </param>
        public string ToString(IFormatProvider formatProvider) => ToString(string.Empty, formatProvider);
    }
}
namespace Qowaiv
{
    using System;
    using System.Globalization;

    public partial struct Integer
    {
        /// <summary>Converts the <see cref="string"/> to <see cref="Integer"/>.</summary>
        /// <param name="s">
        /// A string containing the Int32 wrapper to convert.
        /// </param>
        /// <returns>
        /// The parsed Int32 wrapper.
        /// </returns>
        /// <exception cref="FormatException">
        /// <paramref name="s"/> is not in the correct format.
        /// </exception>
        public static Integer Parse(string s) => Parse(s, CultureInfo.CurrentCulture);

        /// <summary>Converts the <see cref="string"/> to <see cref="Integer"/>.</summary>
        /// <param name="s">
        /// A string containing the Int32 wrapper to convert.
        /// </param>
        /// <param name="formatProvider">
        /// The specified format provider.
        /// </param>
        /// <returns>
        /// The parsed Int32 wrapper.
        /// </returns>
        /// <exception cref="FormatException">
        /// <paramref name="s"/> is not in the correct format.
        /// </exception>
        public static Integer Parse(string s, IFormatProvider formatProvider)
        {
            return TryParse(s, formatProvider, out Integer val)
                ? val
                : throw new FormatException(FormatExceptionMessage);
        }

        /// <summary>Converts the <see cref="string"/> to <see cref="Integer"/>.</summary>
        /// <param name="s">
        /// A string containing the Int32 wrapper to convert.
        /// </param>
        /// <returns>
        /// The Int32 wrapper if the string was converted successfully, otherwise default.
        /// </returns>
        public static Integer TryParse(string s)
        {
            return TryParse(s, out Integer val) ? val : default;
        }

        /// <summary>Converts the <see cref="string"/> to <see cref="Integer"/>.
        /// A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="s">
        /// A string containing the Int32 wrapper to convert.
        /// </param>
        /// <param name="result">
        /// The result of the parsing.
        /// </param>
        /// <returns>
        /// True if the string was converted successfully, otherwise false.
        /// </returns>
        public static bool TryParse(string s, out Integer result) => TryParse(s, CultureInfo.CurrentCulture, out result);
    }
}
