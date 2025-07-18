using LeasingTestAssignment.Domain.Entities;
using LeasingTestAssignment.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LeasingTestAssignment.Infrastructure.Persistence.Repositories;

public class SupplierRepository(LeasingTestAssignmentDbContext dbContext) : ISupplierRepository
{
    private readonly LeasingTestAssignmentDbContext _dbContext = dbContext;

    public Task<Supplier?> ReadByIdAsync(int id, CancellationToken token = default)
    {
        return _dbContext.Suppliers
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id, token);
    }

    public async Task<IReadOnlyCollection<Supplier>> ReadByMaxOfferCountAsync(int limit, CancellationToken token = default)
    {
        return await _dbContext.Suppliers
            .AsNoTracking()
            .Include(s => s.Offers)
            .OrderByDescending(s => s.Offers.Count)
            .Take(limit)
            .ToListAsync(token);
    }
}
