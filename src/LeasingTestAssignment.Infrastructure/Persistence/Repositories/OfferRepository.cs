using LeasingTestAssignment.Domain.Entities;
using LeasingTestAssignment.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LeasingTestAssignment.Infrastructure.Persistence.Repositories;

public class OfferRepository(LeasingTestAssignmentDbContext dbContext) : IOfferRepository
{
    private readonly LeasingTestAssignmentDbContext _dbContext = dbContext;

    public async Task CreateAsync(Offer offer, CancellationToken token = default)
    {
        await _dbContext.Offers.AddAsync(offer, token);
        await _dbContext.SaveChangesAsync(token);
    }

    public Task<Offer?> ReadByIdAsync(int id, CancellationToken token = default)
    {
        return _dbContext.Offers
            .AsNoTracking()
            .Include(o => o.Supplier)
            .FirstOrDefaultAsync(o => o.Id == id, token);
    }

    public async Task<IReadOnlyList<Offer>> ReadAllAsync(CancellationToken token = default)
    {
        return await _dbContext.Offers
            .AsNoTracking()
            .Include(o => o.Supplier)
            .ToListAsync(token);
    }

    public async Task<IReadOnlyList<Offer>> ReadAllBySearchTextAsync(string searchText, CancellationToken token = default)
    {
        return await _dbContext.Offers
            .AsNoTracking()
            .Include(o => o.Supplier)
            .Where(o => o.Mark.Contains(searchText) || o.Model.Contains(searchText) || o.Supplier.Name.Contains(searchText))
            .ToListAsync(token);
    }
}
