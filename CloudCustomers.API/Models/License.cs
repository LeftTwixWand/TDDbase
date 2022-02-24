namespace CloudCustomers.API.Models;

public class License
{
    public int DongleId { get; set; }
    public int UserId { get; set; }
    public int DealerId { get; set; }
    public string Description { get; set; }
}