using LeasingTestAssignment.Application.Common;
using LeasingTestAssignment.Application.DTOs;

namespace LeasingTestAssignment.Application.Services.Interfaces;

public interface IOfferService
{
    Task<ResultOfT<OfferDto>> CreateAsync(OfferDto offerDto, CancellationToken token = default);

    Task<ResultOfT<OfferDto?>> ReadByIdAsync(int id, CancellationToken token = default);

    Task<IReadOnlyList<OfferDto>> ReadAllAsync(CancellationToken token = default);

    Task<IReadOnlyList<OfferDto>> ReadAllBySearchTextAsync(string searchText, CancellationToken token = default);
}
