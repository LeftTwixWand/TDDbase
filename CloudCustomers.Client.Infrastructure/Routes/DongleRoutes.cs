namespace CloudCustomers.Client.Infrastructure.Routes;

public class DongleRoutes
{
    public static string GetAllDongles = "https://jsonplaceholder.typicode.com/users/";

    public static string GetDongleBySerial(string serial)
    {
        return $"http://192.168.62.28:44356/RegisterProxyService/GetAvailableProductsByDongle?dongle={serial}";
    }
}