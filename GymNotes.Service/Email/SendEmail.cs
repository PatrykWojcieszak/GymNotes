using System;
using System.Collections.Generic;
using System.Text;
using MailKit.Net.Smtp;
using MimeKit;

namespace GymNotes.Service.Email
{
  public static class SendEmail
  {
    private const string EMAIL = "gymnotes.customer.service@gmail.com";
    private const string SMTP_SERVER = "smtp.gmail.com";

    public static void Send(string email, string subject, string content)
    {
      MimeMessage message = new MimeMessage();

      MailboxAddress from = new MailboxAddress("Admin", EMAIL);
      message.From.Add(from);

      MailboxAddress to = new MailboxAddress("User", email);
      message.To.Add(to);

      message.Subject = subject;

      BodyBuilder bodyBuilder = new BodyBuilder();
      bodyBuilder.HtmlBody = content;
      bodyBuilder.TextBody = content;

      message.Body = bodyBuilder.ToMessageBody();

      SmtpClient client = new SmtpClient();
      client.Connect(SMTP_SERVER, 465, true);
      client.Authenticate(EMAIL, "gymnotes123");

      client.Send(message);
      client.Disconnect(true);
      client.Dispose();
    }
  }
}