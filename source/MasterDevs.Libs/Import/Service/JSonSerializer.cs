using Newtonsoft.Json;
using System.IO;

namespace MasterDevs.Lib.Common.Service
{
    public class JSonSerializer : ISerializer
    {
		public static readonly JsonSerializerSettings DefaultSettings;

		static JSonSerializer() {
			DefaultSettings  = new JsonSerializerSettings();
            DefaultSettings.NullValueHandling = NullValueHandling.Ignore;
            DefaultSettings.DefaultValueHandling = DefaultValueHandling.Ignore;
            DefaultSettings.Formatting = Formatting.None;
		}

        public T Deserialize<T>(string json)
        {
			return DeserializeStatic<T>(json);
        }

        public T Deserialize<T>(Stream stream)
        {
			return DeserializeStatic<T> (stream);
        }

        public string Serialize<T>(T value)
        {
			return SerializeStatic<T> (value);
        }

        public static T DeserializeStatic<T>(string json)
        {
			return JsonConvert.DeserializeObject<T> (json, DefaultSettings);
        }

        public static T DeserializeStatic<T>(Stream stream)
        {
			var reader = new StreamReader(stream);
			var json = reader.ReadToEnd();
			return DeserializeStatic<T>(json);
        }

        public static string SerializeStatic<T>(T value)
        {
			return JsonConvert.SerializeObject(value, Formatting.None, DefaultSettings);
        }
    }
}