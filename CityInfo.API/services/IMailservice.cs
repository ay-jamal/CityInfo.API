namespace CityInfo.API.services
{
    public interface IMailservice
    {
        void Send(string subject, string message);
    }
}