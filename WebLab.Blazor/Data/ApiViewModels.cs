using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebLab.Blazor.Data
{
    public class LegalServiceListViewModel
    {
        [JsonPropertyName("legalServiceId")]
        public int LegalSeviceId { get; set; }

        [JsonPropertyName("name")]
        public string LegalServiceName { get; set; }
    }

    public class LegalServiceDetailsViewModel
    {
        [JsonPropertyName("name")]
        public string LegalServiceName { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }
    }
}
