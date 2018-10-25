using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace softwareprofs
{
    /// <summary>
    /// Summary description for EmailService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [ScriptService]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class EmailService : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public bool SendEmail(string toAddress, string subject, string message)
        {
            try
            {
                MailMessage objeto_mail = new MailMessage();
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com"; 
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("dewelloper@gmail.com", "Dimple3995*");
                client.EnableSsl = true;
                objeto_mail.From = new MailAddress("dewelloper@gmail.com");
                objeto_mail.To.Add(new MailAddress(toAddress));
                objeto_mail.Subject = subject;
                objeto_mail.Body = message;
                client.Send(objeto_mail);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
