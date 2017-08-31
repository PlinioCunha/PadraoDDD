using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interface.Domain
{
    public interface IDomainServiceUsuario: IDomainServiceBase<Usuario>
    {
        Usuario RetornarPorEmail(string email);
        Usuario LogarUsuario(string email, string senha);
        

        /// <summary>
        /// Esse metódo cria um usuário no bd, disparar e-mail do usuário e grava logsystem.        
        /// </summary>
        /// <param name="model"></param>
        void CriarUsuario(Usuario model);        
        void RecuperarSenha(string email);
        void AlterarSenha(string email, string senhaAntigo, string senhaNova);
        ICollection<Usuario> ListarUsuarios();

        IDomainServiceUsuario GetInstance();
    }
}
