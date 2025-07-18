using LeasingTestAssignment.Application.Common;
using LeasingTestAssignment.Application.DTOs;
using LeasingTestAssignment.Domain.Interfaces;

namespace LeasingTestAssignment.Application.Validators;

public static class OfferValidator
{
    public static async Task<Result> ValidateDtoOnCreate(OfferDto offerDto, ISupplierRepository supplierRepository)
    {
        if (string.IsNullOrWhiteSpace(offerDto.Mark))
        {
            return Result.Fail("Свойство Mark не может быть пустым.");
        }

        if (string.IsNullOrWhiteSpace(offerDto.Model))
        {
            return Result.Fail("Свойство Model не может быть пустым.");
        }

        if (offerDto.Supplier.Id <= 0)
        {
            return Result.Fail("Свойство SupplierId должно быть больше нуля.");
        }

        var supplier = await supplierRepository.ReadByIdAsync(offerDto.Supplier.Id);
        if (supplier == null)
        {
            return Result.Fail($"Поставщик с ID {offerDto.Supplier.Id} не найден.");
        }

        return Result.Success();
    }
}
