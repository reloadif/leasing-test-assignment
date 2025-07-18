using LeasingTestAssignment.Application.DTOs;
using LeasingTestAssignment.Domain.Entities;

namespace LeasingTestAssignment.Application.Mappers;

public static class SupplierMapper
{
    public static SupplierDto ToDto(Supplier supplier)
    {
        ArgumentNullException.ThrowIfNull(supplier);

        return new SupplierDto
        {
            Id = supplier.Id,
            Name = supplier.Name,
            CreationDate = supplier.CreationDate
        };
    }
}
