using LeasingTestAssignment.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LeasingTestAssignment.API.Controllers;

[ApiController]
[Route("/api/suppliers")]
public class SupplierController(ISupplierService supplierService, ILogger<SupplierController> logger) : ControllerBase
{
    private const int limit = 3;

    private readonly ISupplierService _supplierService = supplierService;
    private readonly ILogger<SupplierController> _logger = logger;

    [HttpGet("by-maximum-offers")]
    public async Task<IActionResult> ReadByMaximumOffers(CancellationToken token)
    {
        _logger.LogInformation("Получен запрос на получение поставщиков с максимальным количеством офферов. Лимит: {Limit}", limit);

        var suppliers = await _supplierService.ReadByMaxOfferCountAsync(limit, token);

        _logger.LogInformation("Найдено поставщиков: {Count}", suppliers.Count);

        return Ok(suppliers);
    }
}
