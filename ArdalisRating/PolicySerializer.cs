using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ArdalisRating
{
    public class PolicySerializer : IPolicySerializer
    {
        public Policy GetPolicyFromJsonString(string json) 
        {
            return JsonConvert.DeserializeObject<Policy>(json, new StringEnumConverter());
        }
    }
}
