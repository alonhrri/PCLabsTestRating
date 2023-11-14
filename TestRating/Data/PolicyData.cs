using Newtonsoft.Json;


namespace TestRating
{
    //TODO:Use Generics and some interface
    public class PolicyData : IJsonReader, IDeserializer<List<Policy>>
    {
        private const string filePath = "policy.json";
        

        public string ReadJson()
        {
            return File.ReadAllText(filePath);
        }

        public List<Policy> Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<List<Policy>>(json, new JsonSerializerSettings() { Converters = { new PolicyConverter() } });
        }

        public List<Policy> Fetch()
        {
            string json = ReadJson();
            return Deserialize(json);
        }

    }
}
