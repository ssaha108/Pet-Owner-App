using Newtonsoft.Json;
using System.Collections.Generic;

namespace API.DTOs
{
    public class GenderCatsDTO
    {
        [JsonProperty("gender")]
        public string Gender { get; set; }
        [JsonProperty("cats")]
        public List<CatDTO> Cats {get;set;}
    }
}