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
                EnableSsl = false, //Como estamos fazendo local, nao precisamos configurar segurança, por isso eu deixo ele em false
                DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory, //Aqui estou dizendo que vou salvar em um diretorio os dados que chegarem desse envio
                PickupDirectoryLocation = @"C:\Demos" //Aqui estou especificando onde vai ficar registrado/guardado, para fins de teste
            });

            Email.DefaultSender = sender; //Aqui to setando quem vai estar mandando o email, e como eu setei em 'sender' partirá do meu localhost

            var email = await Email
                .From(emailAddress: "victormarri@exchange.com") //Quem ta enviando o email
                .To(emailAddress: "jorge@gmail.com") //Para quem ta enviando o email
                .Subject(subject: "Coleee") //O título do email
                .Body(body: "Valeu pela ajuda") //O conteúdo do email
                .SendAsync(); //Enviar o email
        }
    }
}
