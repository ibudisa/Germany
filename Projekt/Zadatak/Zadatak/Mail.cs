using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;
 
namespace Zadatak
{
    public class Mail
    {
        public Mail()
        {
        }

        public void sendMail(RootObject r)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("mijo.1955budisa@gmail.com");
                mail.To.Add(r.email);
                mail.Subject = "Test Mail";
                mail.Body = "Name= " + r.name + ", Username= " + r.username + ", Email= " + r.email + ", Address city= " + r.address.city + ", Address street= " + r.address.street + ", Phone= " + r.phone + ", Website= " +  r.website + ", company= " + r.company.name;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("mijo.1955budisa","opelastra2000");
                SmtpServer.EnableSsl = true;
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpServer.Send(mail);
             }
                catch (Exception ex)
                {
                    
                }
            
        }
    }
}