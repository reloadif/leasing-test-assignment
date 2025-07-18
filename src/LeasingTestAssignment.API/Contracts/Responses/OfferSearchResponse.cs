using LeasingTestAssignment.Application.DTOs;
using System.Text.Json.Serialization;

namespace LeasingTestAssignment.API.Contracts.Responses;

public class OfferSearchResponse
{
    [JsonPropertyName("data")]
    public IReadOnlyList<OfferDto> Data { get; set; } = [];

    [JsonPropertyName("total")]
    public int Total { get; set; }
}
