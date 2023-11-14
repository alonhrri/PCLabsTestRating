using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TestRating
{
    public class FileHandler<T> : IFileReader, IDeserializer<T>
    {
        private readonly string _filePath;
        public FileHandler(string filePath)
        {
            _filePath = filePath;
        }
        public T Fetch()
        {
            string json = ReadFile(_filePath);
            return Deserialize(json);
        }
        public string ReadFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        public T Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, converters: new StringEnumConverter());
        }

    }
}
