using FluentEmail.Core;
using FluentEmail.Smtp;
using System;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EmailDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var sender = new SmtpSender(() => new SmtpClient(host: "localhost")
            {
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
                PickupDirectoryLocation = @"C:\Demos"
            });

            Email.DefaultSender = sender;

            var email = await Email
                .From(emailAddress: "victormarri@exchange.com")
                .To(emailAddress: "jorge@gmail.com")
                .Subject(subject: "Coleee")
                .Body(body: "Valeu pela ajuda")
                .SendAsync();
        }
    }
}
