using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Repositories
{
    public interface IRepositoryUsuario : IGenericRepository<Usuario>
    {
        Usuario RetornarPorEmail(string email);        
        Usuario LogarUsuario(string email, string senha);        
    }
}
