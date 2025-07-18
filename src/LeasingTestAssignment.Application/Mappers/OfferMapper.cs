using LeasingTestAssignment.Application.DTOs;
using LeasingTestAssignment.Domain.Entities;

namespace LeasingTestAssignment.Application.Mappers;

public static class OfferMapper
{
    public static OfferDto ToDto(Offer offer)
    {
        ArgumentNullException.ThrowIfNull(offer);

        return new OfferDto
        {
            Id = offer.Id,
            Mark = offer.Mark,
            Model = offer.Model,
            RegistrationDate = offer.RegistrationDate,
            Supplier = SupplierMapper.ToDto(offer.Supplier)
        };
    }

    public static Offer ToEntity(OfferDto offerDto)
    {
        ArgumentNullException.ThrowIfNull(offerDto);

        return new Offer(
            offerDto.Mark,
            offerDto.Model,
            offerDto.Supplier.Id,
            DateTime.Now);
    }
}
