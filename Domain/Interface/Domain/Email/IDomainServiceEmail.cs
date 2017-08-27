using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Services.Email.DomainEmailServices;

namespace Domain.Interface.Domain.Email
{
    public interface IDomainServiceEmail
    {
        void EnviarEmail(string[] para, string assunto, string mensagem, string[] listaAnexos = null, string[] paraCopia = null, string[] paraCopiaOcula = null);
        void EnviarEmailErro(string assunto, string mensagem);
        void EnviarEmailTemaplate(string[] para, string assunto, string texto, eTemplateEmail eTemplate = 0);
    }
}
