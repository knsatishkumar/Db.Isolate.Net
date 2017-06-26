using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db.Isolate
{
    
    internal sealed class TextConverter<T> : JsonConverter where T : struct
    {
        public override bool CanRead => false;
        public override bool CanWrite => true;
        public override bool CanConvert(Type type) => type == typeof(T);

        public override void WriteJson(
            JsonWriter writer, object value, JsonSerializer serializer)
        {
            var literal = value.ToString();
            writer.WriteValue(literal.ToString(CultureInfo.InvariantCulture));
        }

        public override object ReadJson(
            JsonReader reader, Type type, object existingValue, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }
    }
}
