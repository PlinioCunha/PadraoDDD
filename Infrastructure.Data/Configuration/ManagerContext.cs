using Domain.Interface.Infrastructure;
using Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Infrastructure.Data.Configuration
{
    public class ManagerContext : IDisposable, IManagerContext
    {
        public const string ContextoHttp = "ContextoHttp";
        public ContextoBanco Contexto
        {
            get
            {
                if (HttpContext.Current.Items[ContextoHttp] == null)
                    HttpContext.Current.Items[ContextoHttp] = new ContextoBanco();

                return HttpContext.Current.Items[ContextoHttp] as ContextoBanco;
            }
        }

        public void Dispose()
        {
            if (HttpContext.Current.Items[ContextoHttp] != null)
                (HttpContext.Current.Items[ContextoHttp] as ContextoBanco).Dispose();
        }
    }
}
