using System.ComponentModel.DataAnnotations;
using CloudCustomers.Domain.Contracts;

namespace CloudCustomers.Domain.Entity.Dongle;

public class Dongle : AuditableEntity<int>
{
    [Required] public string SerialNumber { get; set; }
    public int DealerId { get; set; }
    public int UserId { get; set; }
    [Required] public DateTime ExpirationDate { get; set; }
}