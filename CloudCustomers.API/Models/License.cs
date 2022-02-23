namespace CloudCustomers.API.Models;

public class License
{
    public int Id { get; set; }
    public int DongleId { get; set; }
    public int UserId { get; set; }
    public bool DealerId { get; set; }
    public string Description { get; set; }
}