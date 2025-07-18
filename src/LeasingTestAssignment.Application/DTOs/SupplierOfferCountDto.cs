using System.Text.Json.Serialization;

namespace LeasingTestAssignment.Application.DTOs;

public class SupplierOfferCountDto
{
    [JsonPropertyName("supplierName")]
    public string SupplierName { get; set; } = string.Empty;

    [JsonPropertyName("offerCount")]
    public int OfferCount { get; set; }
}
