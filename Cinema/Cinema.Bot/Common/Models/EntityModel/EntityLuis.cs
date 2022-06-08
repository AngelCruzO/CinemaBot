using Newtonsoft.Json;
using System.Collections.Generic;

namespace Cinema.Bot.Common.Models.EntityModel
{
    public class EntityLuis
    {
        [JsonProperty("$instance")]
        public Instance _instance { get; set; }
        public List<List<string>> ListMovies { get; set; }
    }

    public class Instance
    {
        public List<ListMovies> ListMovies { get; set; }
    }

    public class ListMovies
    {
        //variable solicitadas en doc de LUIS
        public string type { get; set; }
        public string text { get; set; }
        public string modelType { get; set; }
    }
}
