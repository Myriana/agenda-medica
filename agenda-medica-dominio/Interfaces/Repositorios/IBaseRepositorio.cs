using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace agenda_medica_dominio.Interfaces.Repositorios
{
    public interface IBaseRepositorio <TEntity> where TEntity : class
    {
        IEnumerable<TEntity> ListarTodos();

        TEntity ObterPorId(long id);
        void Incluir(TEntity entity);
        void Deletar(TEntity entity);
        void Alterar(TEntity entity);
    }
}
