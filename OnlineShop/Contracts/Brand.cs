using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace OnlineStore.Contracts
{
    public record BrandRequest
    {
        [JsonPropertyName("brand")]
        [FromQuery(Name = "brand")]
        public string brands { get; set; }

        [FromQuery(Name = "sort")]
        public string SortOption { get; set; }
    }

    public record BrandResponse (
        string Name,
        string Image
    );
}
