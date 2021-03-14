using System.Net;
using System.Net.Mail;

namespace UniversityManager.Helpers
{
    public static class SendEmail
    {
        public static void SendMail(string message, string to, string from)
        {
            string server = "smtp.gmail.com";
            MailMessage send_message = new MailMessage(from, to, "Spam", message);

            SmtpClient client = new SmtpClient(server);
            client.Port = 587; //sets the server port
            client.EnableSsl = true;

            client.Credentials = new NetworkCredential("",                                                                                                                                                  "password");

            client.SendAsync(send_message, "blabla");
        }
    }
}