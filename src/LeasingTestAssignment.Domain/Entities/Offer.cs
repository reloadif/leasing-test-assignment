namespace LeasingTestAssignment.Domain.Entities;

public class Offer
{
    public int Id { get; private set; }

    public string Mark { get; private set; } = string.Empty;

    public string Model { get; private set; } = string.Empty;

    public int SupplierId { get; private set; }

    public Supplier Supplier { get; private set; } = null!;

    public DateTime RegistrationDate { get; private set; }

    protected Offer() { }

    public Offer(string mark, string model, int supplierId, DateTime registrationDate)
    {
        Mark = mark;
        Model = model;
        SupplierId = supplierId;
        RegistrationDate = registrationDate;
    }
}
