using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;
using MimeKit.Text;

namespace NorthBook.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var emailToSend = new MimeMessage();
            emailToSend.From.Add(MailboxAddress.Parse("NorthBook"));
            emailToSend.To.Add(MailboxAddress.Parse(email));
            emailToSend.Subject = subject;
            emailToSend.Body = new TextPart(TextFormat.Html) { Text = htmlMessage };


            //send mail
            using (var emailClient = new SmtpClient())
            {
                emailClient.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                emailClient.Authenticate("bbogosny@gmail.com", "ovtvykmlhzwbrvqm");
                emailClient.Send(emailToSend);
                emailClient.Disconnect(true);
            }

            return Task.CompletedTask;
        }
    }
}
