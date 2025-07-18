using LeasingTestAssignment.Application.DTOs;
using LeasingTestAssignment.Application.Services.Interfaces;
using LeasingTestAssignment.Domain.Interfaces;

namespace LeasingTestAssignment.Application.Services;

public class SupplierService(ISupplierRepository supplierRepository) : ISupplierService
{
    private readonly ISupplierRepository _supplierRepository = supplierRepository;

    public async Task<IReadOnlyCollection<SupplierOfferCountDto>> ReadByMaxOfferCountAsync(int limit, CancellationToken token = default)
    {
        var suppliers = await _supplierRepository.ReadByMaxOfferCountAsync(limit, token);
        return suppliers.Select(s => new SupplierOfferCountDto
        {
            SupplierName = s.Name,
            OfferCount = s.Offers.Count
        }).ToList();
    }
}
