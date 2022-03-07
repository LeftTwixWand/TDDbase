namespace CloudCustomers.Application.Requests.Dongles;

public class GetDongleBySerialRequest : PagedRequest
{
    public string SearchString { get; set; }
    public string SerialNumber { get; set; }
}