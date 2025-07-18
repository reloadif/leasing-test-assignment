using LeasingTestAssignment.Application.DTOs;

namespace LeasingTestAssignment.Application.Services.Interfaces;

public interface ISupplierService
{
    Task<IReadOnlyCollection<SupplierOfferCountDto>> ReadByMaxOfferCountAsync(int limit, CancellationToken token = default);
}
