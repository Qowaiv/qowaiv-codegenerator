namespace @Namespace
{
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
