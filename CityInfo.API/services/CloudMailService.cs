namespace CityInfo.API.services
{
    public class CloudMailService
    {
        private string _mailTo = "admin@company.com";
        private string _mailFrom = "noreply2mycompany.com";

        public void Send(string subject, string message)
        {
            Console.WriteLine($"Mail from {_mailFrom} to {_mailTo}" +
                $"with {nameof(CloudMailService)}"
                );

            Console.WriteLine($"Subject : {subject}");
            Console.WriteLine($"Message : {message}");

        }
    }
}
