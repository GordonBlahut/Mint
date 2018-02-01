using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mint
{
    public class MaskableInt32JsonConverter : JsonConverter
    {
        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(MaskableInt32) || objectType == typeof(MaskableInt32?);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            if (value != null)
            {
                var maskableInt = (MaskableInt32) value;
                string maskedValue = maskableInt.GetMaskedValue();
                writer.WriteValue(maskedValue);
            }
            else
            {
                writer.WriteValue((object) null);
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader == null)
            {
                throw new ArgumentNullException(nameof(reader));
            }

            JToken token = JToken.Load(reader);
            string maskedValue = token.ToObject<string>();
            if (maskedValue != null)
            {
                try
                {
                    return MaskableInt32.GetUnmaskedValue(maskedValue);
                }
                catch (ArgumentException exception)
                {
                    throw new JsonSerializationException(exception.Message);
                }
            }

            return null;
        }
    }
}