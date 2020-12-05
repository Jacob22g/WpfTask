using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Net.Mail;
using System.Configuration;
using CommonUtills;

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
			if (GmailSmtp.GmailEmailSender(email_TB.Text, subject_TB.Text, body_TB.Text)) {
				MessageBox.Show($"Email sent to { email_TB.Text } successfully");
			}
			else {
				MessageBox.Show($"Invalid Email");
				// Applying Error handling mechanism, for example: retry design pattern
			}
		}
	}
}
