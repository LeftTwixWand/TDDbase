namespace CloudCustomers.Domain.Entity;

public class Dongle
{
    public string Serial { get; set; }
    public int UserId { get; set; }
    public int DealerId { get; set; }
    public string Description { get; set; }
}