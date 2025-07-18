using LeasingTestAssignment.Domain.Entities;

namespace LeasingTestAssignment.Domain.Interfaces;

public interface ISupplierRepository
{
    Task<Supplier?> ReadByIdAsync(int id, CancellationToken token = default);

    Task<IReadOnlyCollection<Supplier>> ReadByMaxOfferCountAsync(int limit, CancellationToken token = default);
}
