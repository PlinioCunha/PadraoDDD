using Autofac;
using Autofac.Extras.CommonServiceLocator;
using Domain.Interface.Domain;
using Domain.Services;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;


namespace Api.Config.Owin
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private IDomainServiceUsuario _serviceUsuario;      
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            // AUTENTICAÇÃO
            // Service locator = Gerencia uma instancia do DomainServiceUsuario
            _serviceUsuario = (DomainServiceUsuario)ServiceLocator.Current.GetInstance<IDomainServiceUsuario>();                        
            var user = _serviceUsuario.LogarUsuario(context.UserName, context.Password);
            if (user == null)
            {
                context.SetError("invalid_grant", "Usuário ou senha não estão corretos.");
                return;
            }
           

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "user"));

            context.Validated(identity);
        }
    }
}