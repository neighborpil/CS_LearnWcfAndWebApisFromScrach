using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MEPInWCFLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class MEP : IMEP
    {
        public void SendEmail(string ToAddress)
        {

            try
            {
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress("md.manzoorahmed@gmail.com");
                mail.To.Add(ToAddress);
                mail.Subject = "Welcome To New Course";
                mail.Body = "Hi, We Heartly welcome you to new learnings";

                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("md.manzoorahmed@gmail.com", "XXXXXXXXXXXXXXXXXXXXX");

                client.Send(mail);

                IMEPCallBack cb = OperationContext.Current.GetCallbackChannel<IMEPCallBack>();
                cb.SendEmailCallBack(ToAddress);
            }
            catch (Exception Ex)
            {

                throw new FaultException(Ex.Message);
            }
        }
    }
}
