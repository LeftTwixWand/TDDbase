namespace Client.Infrastructure.Routes;

public class DongleRoutes
{
    public static string GetAllDongles = "https://jsonplaceholder.typicode.com/users/";

    public static string GetDongleBySerial(string serial)
    {
        return $"https://jsonplaceholder.typicode.com/users/{serial}";
    }
}