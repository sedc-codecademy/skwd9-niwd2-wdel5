using System;
using Newtonsoft.Json;

namespace RealEstate.Api.Models
{
    public class Estate
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("estateName")]
        public string EstateName { get; set; }

        [JsonProperty("contactPersonName")]
        public string ContactPersonName { get; set; }

        [JsonProperty("contactPersonPhone")]
        public string ContactPersonPhone { get; set; }

        [JsonProperty("contactPersonEmail")]
        public string ContactPersonEmail { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("photoUrl")]
        public string PhotoUrl { get; set; }

        [JsonProperty("available")]
        public bool Available { get; set; }
    }
}
