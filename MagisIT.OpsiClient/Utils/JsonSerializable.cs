using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace MagisIT.OpsiClient.Utils
{
    public abstract class JsonSerializable
    {
        public JObject ToJsonObject() =>
            JObject.FromObject(this,
                               new JsonSerializer() {
                                   ContractResolver = new CamelCasePropertyNamesContractResolver()
                               });
    }
}
