using Domain.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using System.Linq.Expressions;

namespace Infrastructure.Data.Repositories
{
    public class RepositoryUsuario : GenericRepository<Usuario>, IRepositoryUsuario
    {

        public Usuario LogarUsuario(string email, string senha)
        {
            return First(a => a.Email == email && a.Senha == senha);
        }

        public Usuario RetornarPorEmail(string email)
        {
            return First(a => a.Email == email);
        }
    }
}
