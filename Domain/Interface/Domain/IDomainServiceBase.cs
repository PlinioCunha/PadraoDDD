using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Domain
{
    public interface IDomainServiceBase<T> where T: class
    {
        T Detalhe(int Id);
        T Detalhe(Expression<Func<T, bool>> predicate);
        void Inserir(T model);
        void Salvar(T model);
        void Remover(int Id);
        void Remover(T model);

        ICollection<T> entityGetAll(Expression<Func<T, bool>> predicate = null);
        ICollection<T> dapperGetAll(string sql, object[] parameter, bool procecure = false);
    }
}
