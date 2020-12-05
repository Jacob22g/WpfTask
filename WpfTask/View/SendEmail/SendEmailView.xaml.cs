using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace WpfTask
{
	/// <summary>
	/// Interaction logic for SendEmailView.xaml
	/// </summary>
	public partial class SendEmailView : UserControl
	{
		public SendEmailView()
		{
			InitializeComponent();
		}

		private void sendButton_click(object sender, RoutedEventArgs e)
		{
			bool isValidEmail = Regex.IsMatch(email_TB.Text , @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);

			if (isValidEmail)
			{
				MessageBox.Show($"Email to { email_TB.Text } sent");


				SmtpClient client = new SmtpClient();
				client.Port = 587;
				client.Host = "smtp.gmail.com";
				client.EnableSsl = true;
				client.Timeout = 10000;
				client.DeliveryMethod = SmtpDeliveryMethod.Network;
				client.UseDefaultCredentials = false;
				client.Credentials = new System.Net.NetworkCredential("user.123.jacob@gmail.com", "User123123");

				MailMessage mm = new MailMessage("DoNotReply@domain.com", email_TB.Text, body_TB.Text, subject_TB.Text);
				mm.BodyEncoding = UTF8Encoding.UTF8;
				mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

				client.Send(mm);


			}
			else
			{
				MessageBox.Show($"Invalid Email");
			}
		}
	}
}
