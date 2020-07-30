using System;
using System.Net;
using System.Net.Mail;
using System.ServiceModel;

namespace MessageExchangePatternInWcfLibrary
{
    public class MessageExchangePattern : IMessageExchangePattern
    {
        public void SendEmail(string toAddress)
        {
			try
            {
                var mail = new MailMessage();
                mail.From = new MailAddress("test@gmail.com");
                mail.To.Add(toAddress);
                mail.Subject = "Please register to receive INHERITANCE";
                mail.Body = "Your far far relative have died. If you want to receive it, please send $1000 to register";

                var client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("test@gmail.com", "XXXXXXXX");

                client.Send(mail);
            }
			catch (System.Exception ex)
			{
                Console.WriteLine(ex.Message);

                throw new FaultException(ex.Message);
			}

        }
    }
}