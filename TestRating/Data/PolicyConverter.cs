using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TestRating;

namespace TestRating
{
    internal class PolicyConverter : JsonConverter
    {

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Policy);
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {

            JObject jo = JObject.Load(reader);
            PolicyType policyType = Enum.Parse<PolicyType>(jo["type"].Value<string>(), ignoreCase: true);
            switch (policyType)
            {
                case PolicyType.Health:
                    return jo.ToObject<HealthPolicy>(serializer);
                case PolicyType.Life:
                    return jo.ToObject<LifePolicy>(serializer);
                case PolicyType.Travel:
                    return jo.ToObject<TravelPolicy>(serializer);
                default:
                    return null;
            }

        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

    }
}
