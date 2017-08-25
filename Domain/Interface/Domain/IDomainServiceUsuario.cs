using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interface.Domain
{
    public interface IDomainServiceUsuario 
    {
        Usuario RetornarPorEmail(string email);
        Usuario LogarUsuario(string email, string senha);
        void CriarUsuario(Entities.Usuario model);
        IList<Usuario> Listar();
    }
}
