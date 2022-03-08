using System.ComponentModel.DataAnnotations;

namespace CloudCustomers.Domain.Entity;

public class Dongle
{
    [Required] public string SerialNumber { get; set; }
    public int DealerId { get; set; }
    public int UserId { get; set; }
    [Required] public DateTime ExpirationDate { get; set; }
}