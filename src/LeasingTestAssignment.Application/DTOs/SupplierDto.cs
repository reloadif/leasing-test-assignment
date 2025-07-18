using System.Text.Json.Serialization;

namespace LeasingTestAssignment.Application.DTOs;

public class SupplierDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("creationDate")]
    public DateTime CreationDate { get; set; }
}
