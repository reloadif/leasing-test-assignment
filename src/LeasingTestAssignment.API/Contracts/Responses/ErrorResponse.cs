using System.Text.Json.Serialization;

namespace LeasingTestAssignment.API.Contracts.Responses;

public class ErrorResponse(string? message)
{
    [JsonPropertyName("message")]
    public string Message { get; set; } = message ?? "Произошла неожиданная ошибка. Пожалуйста, свяжитесь с администратором системы.";
}
