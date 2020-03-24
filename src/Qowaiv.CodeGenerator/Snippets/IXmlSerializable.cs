namespace @Namespace
{
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    public partial struct @TSvo : IXmlSerializable
    {
        /// <summary>Gets the <see href="XmlSchema" /> to XML (de)serialize the @FullName.</summary>
        /// <remarks>
        /// Returns null as no schema is required.
        /// </remarks>
        XmlSchema IXmlSerializable.GetSchema() => null;

        /// <summary>Reads the @FullName from an <see href="XmlReader" />.</summary>
        /// <param name="reader">An XML reader.</param>
        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            Guard.NotNull(reader, nameof(reader));
            var xml = reader.ReadElementString();
#if !NotCultureDependent
            var val = Parse(xml, CultureInfo.InvariantCulture);
#else
            var val = Parse(xml);
#endif
#if !NotField
            m_Value = val.m_Value;
#endif
            OnReadXml(val);
        }
        partial void OnReadXml(@TSvo other);

        /// <summary>Writes the @FullName to an <see href="XmlWriter" />.</summary>
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
