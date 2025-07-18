using LeasingTestAssignment.Domain.Entities;
using System.Text.Json.Serialization;

namespace LeasingTestAssignment.Application.DTOs;

public class OfferDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("mark")]
    public string Mark { get; set; } = string.Empty;

    [JsonPropertyName("model")]
    public string Model { get; set; } = string.Empty;

    [JsonPropertyName("supplier")]
    public SupplierDto Supplier { get; set; } = null!;

    [JsonPropertyName("registrationDate")]
    public DateTime RegistrationDate { get; set; }
}

