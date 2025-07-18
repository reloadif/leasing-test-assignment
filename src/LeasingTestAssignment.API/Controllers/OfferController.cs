using LeasingTestAssignment.API.Contracts.Responses;
using LeasingTestAssignment.Application.DTOs;
using LeasingTestAssignment.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LeasingTestAssignment.API.Controllers;

[ApiController]
[Route("/api/offers")]
public class OfferController(IOfferService offerService, ILogger<OfferController> logger) : ControllerBase
{
    private readonly IOfferService _offerService = offerService;
    private readonly ILogger<OfferController> _logger = logger;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] OfferDto offer, CancellationToken token)
    {
        _logger.LogInformation("Получен запрос на создание оффера: {@Offer}", offer);

        if (offer == null)
        {
            _logger.LogWarning("Попытка создать оффер с пустым телом запроса.");
            return BadRequest(new ErrorResponse("Оффер не может быть null."));
        }

        var createResult = await _offerService.CreateAsync(offer, token);
        if (!createResult.IsSuccess)
        {
            _logger.LogError("Ошибка при создании оффера: {ErrorMessage}", createResult.ErrorMessage);
            return BadRequest(new ErrorResponse(createResult.ErrorMessage));
        }

        _logger.LogInformation("Оффер успешно создан с Id: {Id}", offer.Id);
        return CreatedAtAction(nameof(Read), new { id = offer.Id }, createResult.Result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Read([FromRoute] int id, CancellationToken token)
    {
        _logger.LogInformation("Получен запрос на получение оффера по Id: {Id}", id);

        var readResult = await _offerService.ReadByIdAsync(id, token);
        if (!readResult.IsSuccess)
        {
            _logger.LogWarning("Оффер с Id {Id} не найден.", id);
            return BadRequest(new ErrorResponse(readResult.ErrorMessage));
        }

        _logger.LogInformation("Оффер с Id {Id} успешно найден.", id);
        return Ok(readResult.Result);
    }

    [HttpGet]
    public async Task<IActionResult> ReadAll(CancellationToken token)
    {
        _logger.LogInformation("Получен запрос на получение всех офферов.");
        var offers = await _offerService.ReadAllAsync(token);
        _logger.LogInformation("Найдено офферов: {Count}", offers.Count);
        return Ok(offers);
    }

    [HttpGet("/search")]
    public async Task<IActionResult> ReadBySearchText([FromQuery] string searchText, CancellationToken token)
    {
        _logger.LogInformation("Получен запрос на поиск по тексту в офферах: {@SearchText}", searchText);

        if (string.IsNullOrWhiteSpace(searchText))
        {
            _logger.LogWarning("Попытка выполнить поиск с пустым поисковым запросом.");
            return BadRequest(new ErrorResponse("Поисковый запрос не может быть null или пустым."));
        }

        var offers = await _offerService.ReadAllBySearchTextAsync(searchText, token);
        _logger.LogInformation("Найдено офферов: {Count}", offers.Count);
        return Ok(new OfferSearchResponse
        {
            Data = offers,
            Total = offers.Count
        });
    }
}