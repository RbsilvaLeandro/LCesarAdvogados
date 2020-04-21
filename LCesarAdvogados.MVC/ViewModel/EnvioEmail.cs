using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Web;


namespace LCesarAdvogados.MVC.ViewModel
{
   public class EnvioEmail
    {
        public Boolean EnvioEmailCliente(string corpo, string destinatario, string assunto, string mail)
        {
            try
            {
                //Define o endereço do remetente com cópia oculta
                MailMessage Email = new MailMessage();
                Email.From = new MailAddress(mail);

                Email.To.Add(new MailAddress(destinatario));

                Email.Subject = assunto;
                Email.IsBodyHtml = true;

                //Atenção, o suporte a CSS é limitado em vários Webmails, 
                //utilize o CSS INLINE que é compatível com a maioria dos WEBMAILS, OUTLOOK e outros.
                StringBuilder body = new StringBuilder();
                body.Append("<html>");
                body.Append("<body style=\"font-family:Arial, Helvetica, sans-serif; font-size: 14px\">");
                body.Append("<img src=\"cid:logo\" title=\"logo\" />");
                body.Append("<table>");
                body.Append(corpo);

                LinkedResource lr = new LinkedResource("C:\\WebSites\\LCesarAdvogados\\LCesarAdvogados\\LCesarAdvogados.MVC\\img\\FundoEmail.jpg", "images/jpg");
                lr.ContentId = "logo";

                AlternateView av = AlternateView.CreateAlternateViewFromString(body.ToString(), new ContentType("text/html"));
                av.LinkedResources.Add(lr);

                Email.AlternateViews.Add(av);

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("leandrosilva.ssweb@gmail.com", "nigt@c#524897");

                smtp.Send(Email);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}