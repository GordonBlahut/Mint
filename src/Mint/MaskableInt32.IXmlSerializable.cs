using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Mint
{
    public partial struct MaskableInt32 : IXmlSerializable
    {
        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException(nameof(reader));
            }

            string text = reader.ReadElementString();
            Val = GetUnmaskedValue(text);
        }

        public void WriteXml(XmlWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            writer.WriteString(GetMaskedValue());
        }
    }
}