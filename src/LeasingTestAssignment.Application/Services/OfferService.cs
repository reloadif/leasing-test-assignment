using LeasingTestAssignment.Application.Common;
using LeasingTestAssignment.Application.DTOs;
using LeasingTestAssignment.Application.Mappers;
using LeasingTestAssignment.Application.Services.Interfaces;
using LeasingTestAssignment.Application.Validators;
using LeasingTestAssignment.Domain.Interfaces;

namespace LeasingTestAssignment.Application.Services;

public class OfferService(IOfferRepository offerRepository, ISupplierRepository supplierRepository) : IOfferService
{
    private readonly ISupplierRepository _supplierRepository = supplierRepository;
    private readonly IOfferRepository _offerRepository = offerRepository;

    public async Task<ResultOfT<OfferDto>> CreateAsync(OfferDto offerDto, CancellationToken token = default)
    {
        var validateResult = await OfferValidator.ValidateDtoOnCreate(offerDto, _supplierRepository);
        if (!validateResult.IsSuccess)
        {
            return ResultOfT<OfferDto>.Fail(validateResult.ErrorMessage);
        }

        var offer = OfferMapper.ToEntity(offerDto);
        await _offerRepository.CreateAsync(offer, token);

        offer = await _offerRepository.ReadByIdAsync(offer.Id, token);
        if (offer == null)
        {
            return ResultOfT<OfferDto>.Fail($"Предложение с ID {offerDto.Id} не найдено после создания.");
        }

        return ResultOfT<OfferDto>.Success(OfferMapper.ToDto(offer));
    }

    public Task<ResultOfT<OfferDto?>> ReadByIdAsync(int id, CancellationToken token = default)
    {
        return _offerRepository.ReadByIdAsync(id, token)
            .ContinueWith(task =>
            {
                if (task.Result == null)
                {
                    return ResultOfT<OfferDto?>.Fail($"Предложение с ID {id} не найдено.");
                }
                return ResultOfT<OfferDto?>.Success(OfferMapper.ToDto(task.Result));
            }, token);
    }

    public async Task<IReadOnlyList<OfferDto>> ReadAllAsync(CancellationToken token = default)
    {
        return await _offerRepository.ReadAllAsync(token)
            .ContinueWith(task => task.Result.Select(OfferMapper.ToDto).ToList(), token);
    }

    public async Task<IReadOnlyList<OfferDto>> ReadAllBySearchTextAsync(string searchText, CancellationToken token = default)
    {
        return await _offerRepository.ReadAllBySearchTextAsync(searchText, token)
            .ContinueWith(task => task.Result.Select(OfferMapper.ToDto).ToList(), token);
    }
}
