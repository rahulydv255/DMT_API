using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMT.Domain.Core
{
    public class Serializer
    {
        public static string SerializeToJson<T>(T ObjectToSerialize)
        {
            var json = JsonConvert.SerializeObject(ObjectToSerialize);
            return json;
        }
        public static T DeserializeFromJson<T>(string input) where T : class
        {
            return JsonConvert.DeserializeObject<T>(input);
        }

    }
}
