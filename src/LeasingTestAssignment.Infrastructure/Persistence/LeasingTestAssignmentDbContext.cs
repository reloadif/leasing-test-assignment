using LeasingTestAssignment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LeasingTestAssignment.Infrastructure.Persistence;

public class LeasingTestAssignmentDbContext : DbContext
{
    public LeasingTestAssignmentDbContext(DbContextOptions<LeasingTestAssignmentDbContext> options) : base(options)
    {
    }

    public DbSet<Supplier> Suppliers { get; set; } = null!;

    public DbSet<Offer> Offers { get; set; } = null!;
}
