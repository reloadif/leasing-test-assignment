namespace LeasingTestAssignment.Domain.Entities;

public class Supplier
{
    public int Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public DateTime CreationDate { get; set; }

    public ICollection<Offer> Offers { get; set; } = [];

    protected Supplier() { }
}
