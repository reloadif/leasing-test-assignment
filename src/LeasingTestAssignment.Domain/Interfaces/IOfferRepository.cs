using LeasingTestAssignment.Domain.Entities;

namespace LeasingTestAssignment.Domain.Interfaces;

public interface IOfferRepository
{
    Task CreateAsync(Offer offer, CancellationToken token = default);

    Task<Offer?> ReadByIdAsync(int id, CancellationToken token = default);

    Task<IReadOnlyList<Offer>> ReadAllAsync(CancellationToken token = default);

    Task<IReadOnlyList<Offer>> ReadAllBySearchTextAsync(string searchText, CancellationToken token = default);
}
