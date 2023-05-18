using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelaxingKompas.Utils
{
    internal static class JsonUtils
    {
        /// <summary>
        /// Десериализация json. Обернуть в try catch
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string path)
        {
            if (!File.Exists(path))
            {
                return default;
            };
            T model = JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
            return model;
        }
        public static void Serialize<T>(string path, T obj)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            using (StreamWriter sw = new StreamWriter(path, false))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                serializer.Serialize(jw, obj);
            }
        }
    }
}
