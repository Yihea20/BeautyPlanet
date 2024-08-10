using BeautyPlanet.DTOs;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace BeautyPlanet.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public bool SendEmail(EmailDTO request)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("yiheayihea95@gmail.com"));
                email.To.Add(MailboxAddress.Parse(request.To));
                email.Subject = request.Subject;
                email.Body = new TextPart(TextFormat.Html) { Text = request.Body };
                using var smtp = new SmtpClient();
                smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
                var user = _config.GetSection("EmailUserName").Value;
                var pass = _config.GetSection("EmailPassWord").Value;
                smtp.Authenticate(user, pass);
                smtp.Send(email);
                smtp.Disconnect(true);
                return true;
            }
            catch (Exception ex) {
                return false;
            }
        }
    }
}
