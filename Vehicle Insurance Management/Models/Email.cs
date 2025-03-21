//using System.Net;
//using System.Net.Mail;
//using Microsoft.Extensions.Configuration;

//public class EmailService
//{
//    private readonly IConfiguration _configuration;

//    public EmailService(IConfiguration configuration)
//    {
//        _configuration = configuration;
//    }

//    public void SendEmail(string toEmail, string subject, string body)
//    {
//        var smtpServer = _configuration["EmailSettings:SmtpServer"];
//        var smtpPort = int.Parse(_configuration["EmailSettings:SmtpPort"]);
//        var senderEmail = _configuration["EmailSettings:SenderEmail"];
//        var senderPassword = _configuration["EmailSettings:SenderPassword"];

//        var client = new SmtpClient(smtpServer)
//        {
//            Port = smtpPort,
//            Credentials = new NetworkCredential(senderEmail, senderPassword),
//            EnableSsl = true
//        };

//        var mailMessage = new MailMessage
//        {
//            From = new MailAddress(senderEmail),
//            Subject = subject,
//            Body = body,
//            IsBodyHtml = true
//        };

//        mailMessage.To.Add(toEmail);
//        client.Send(mailMessage);
//    }
//}



///
/// a////b////c////d//ee//f
///zz///ab///a.//aa/.a/b/