using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace CommonUtills
{
    public class GmailSmtp
    {
		static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		// static regex
		static readonly string emailRegex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

		// static is valid email
		static public Boolean isValidEmail(string email) {
			return Regex.IsMatch(email, emailRegex, RegexOptions.IgnoreCase);
		}

		// static Gmail sender - gets user name and password
		static public Boolean GmailEmailSender(string reciverEmail, string subject, string body) {
			try
			{
				if (isValidEmail(reciverEmail))
				{
					using (SmtpClient client = new SmtpClient())
					{
						client.Port = int.Parse(ConfigurationManager.AppSettings["SmtpClient_Port"]);
						client.Host = ConfigurationManager.AppSettings["SmtpClient_Host"];
						client.EnableSsl = Boolean.Parse(ConfigurationManager.AppSettings["SmtpClient_EnableSsl"]);
						client.Timeout = int.Parse(ConfigurationManager.AppSettings["SmtpClient_Timeout"]);
						client.DeliveryMethod = SmtpDeliveryMethod.Network;
						client.UseDefaultCredentials = Boolean.Parse(ConfigurationManager.AppSettings["SmtpClient_UseDefaultCredentials"]);
						client.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["Gmail_UserName"], ConfigurationManager.AppSettings["Gmail_Password"]);
						MailMessage mm = new MailMessage("DoNotReply@domain.com", reciverEmail, subject, body)
						{
							BodyEncoding = UTF8Encoding.UTF8,
							DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
						};
						client.Send(mm);
						return true;
					}
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return false;
		}
    }
}
