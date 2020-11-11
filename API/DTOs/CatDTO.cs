using Newtonsoft.Json;

namespace API.DTOs
{
    public class CatDTO
    {
        [JsonProperty("catname")]
        public string CatName { get; set; }
    }
}