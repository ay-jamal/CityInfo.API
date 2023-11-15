namespace CityInfo.API.services
{
    public class LocalMailservice : IMailservice
    {


        private string _mailTo = "admin@company.com";
        private string _mailFrom = "noreply2mycompany.com";

        public LocalMailservice(
            IConfiguration configration
            
            )
        {
         // _mailTo = configration["mailSettings:mailToAdress"];
        }

        public void Send(string subject, string message)
        {
            Console.WriteLine($"Mail from {_mailFrom} to {_mailTo}" +
                $"with {nameof(LocalMailservice)}"
                );

            Console.WriteLine($"Subject : {subject}");
            Console.WriteLine($"Message : {message}");
        }
    }
}
