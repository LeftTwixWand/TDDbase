using Newtonsoft.Json;

namespace CloudCustomers.Domain.Entity.Dongle;

public class DongleInformation
{
    public int DongleVersion { get; set; }
    public int ProductID { get; set; }
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string ProductName { get; set; }
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Code { get; set; }
    public DateTime ExpirationDate { get; set; }
}