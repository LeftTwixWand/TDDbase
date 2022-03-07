using System;
using System.ComponentModel.DataAnnotations;
using CloudCustomers.Application.Enums;
using CloudCustomers.Domain.Entity;

namespace CloudCustomers.Application.Responses.Dongles;

public class DongleInformationResponse
{
    [Required] public string SerialNumber { get; set; }
    public int ProductId { get; set; }
    public ProductsEnum ProductName { get; set; }
    public string DealerСompany { get; set; }
    public DateTime Expiration { get; set; }
}