using Domain.Interface.Domain.Email;
using Domain.Interface.Domain.Log;
using Domain.Services.Log;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Services.Email
{
    public class DomainEmailServices : IDomainServiceEmail
    {

        public enum eTemplateEmail
        {
            [Description("http://localhost:51838/views/template_PrimeiroCadastro.html")]
            PrimeiroCadastro = 1,

            [Description("http://localhost:51838/views/template_RecuperarSenha.html")]
            RecuperarSenha = 2,

            [Description("http://localhost:51838/views/template_AlterarSenha.html")]
            AlterarSenha = 3,

            [Description("http://localhost:51838/views/template_Notificacao.html")]
            Notificacao = 4,

            [Description("http://localhost:51838/views/template_LogError.html")]
            LogError = 5,

            [Description("http://localhost:51838/views/template_NoReply.html")]
            NoReply = 6
        }

        private string ToDescriptionString(eTemplateEmail val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }


        private readonly ILog _logger;
        public DomainEmailServices()
        {
            log4net.Config.XmlConfigurator.Configure();
            _logger = LogManager.GetLogger("LogInFile");
        }


        public void EnviarEmailErro(string assunto, string mensagem)
        {
            EnviarEmail(new string[] { Convert.ToString(ConfigurationManager.AppSettings["email_erro"]) }, assunto, mensagem);
        }


        private string GetTemplateEmail(string path, string texto)
        {
            WebClient webClient = new WebClient();
            var email = webClient.DownloadString(path);
            webClient.Dispose();

            return email.Replace("{#texto}", texto);

            //HttpClient client = new HttpClient();
            //HttpResponseMessage response = await client.GetAsync(path);
            //if (response.IsSuccessStatusCode)
            //{
            //    var email = response.Content.ReadAsStringAsync().Result;
            //    email = email.Replace("{#texto}", texto);
            //    return email;

            //}
            //return string.Empty;
        }

        public void EnviarEmailTemaplate(string[] para, string assunto, string texto, eTemplateEmail eTemplate = 0)
        {            
            string templateUri = string.Empty;
            switch (eTemplate)
            {
                case eTemplateEmail.PrimeiroCadastro:
                    templateUri = ToDescriptionString(eTemplate);
                    break;

                case eTemplateEmail.RecuperarSenha:
                    break;

                case eTemplateEmail.NoReply:
                    break;
                default:
                    break;
            }

            var emailTemplate = GetTemplateEmail(templateUri, texto);
            EnviarEmail(para, assunto, emailTemplate);
        }




        public void EnviarEmail(string[] para, string assunto, string mensagem, string[] listaAnexos = null, string[] paraCopia = null, string[] paraCopiaOcula = null)
        {
            string smtp = Convert.ToString(ConfigurationManager.AppSettings["smtp"]);
            int port = Convert.ToInt32(ConfigurationManager.AppSettings["smtp_port"]);
            bool ssl = Convert.ToBoolean(ConfigurationManager.AppSettings["smtp_ssl"]);

            string userName = Convert.ToString(ConfigurationManager.AppSettings["smtp_username"]);
            string password = Convert.ToString(ConfigurationManager.AppSettings["smtp_password"]);
            string smtpNameDisplay = Convert.ToString(ConfigurationManager.AppSettings["smtp_name_display"]);

            // email
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(userName, smtpNameDisplay);

            // para
            foreach (var item in para)
                mail.To.Add(item);

            // copia
            if (paraCopia != null)
                foreach (var item in paraCopia)
                    mail.CC.Add(item);

            // copia oculta
            if (paraCopiaOcula != null)
                foreach (var item in paraCopiaOcula)
                    mail.Bcc.Add(item);

            mail.Subject = assunto;
            mail.Body = string.Format("<html><head></head><body>{0}</body></html>", mensagem);
            mail.IsBodyHtml = true;
            mail.BodyEncoding = mail.SubjectEncoding = System.Text.Encoding.UTF8;

            // anexo
            if (listaAnexos != null)
            {
                foreach (var item in listaAnexos)
                {
                    if (File.Exists(item) && !string.IsNullOrEmpty(item))
                    {
                        Attachment attachment = new Attachment(item, MediaTypeNames.Application.Octet);
                        ContentDisposition disposition = attachment.ContentDisposition;
                        disposition.CreationDate = File.GetCreationTime(item);
                        disposition.ModificationDate = File.GetLastWriteTime(item);
                        disposition.ReadDate = File.GetLastAccessTime(item);
                        disposition.FileName = Path.GetFileName(item);
                        disposition.Size = new FileInfo(item).Length;
                        disposition.DispositionType = DispositionTypeNames.Attachment;
                        mail.Attachments.Add(attachment);
                    }
                }
            }

            // 
            SmtpClient client = new SmtpClient();
            client.Host = smtp;
            client.Port = port;
            client.EnableSsl = ssl;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(userName, password);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            // Send
            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                _logger.Error(JsonConvert.SerializeObject(ex));
            }

        }




    }
}
