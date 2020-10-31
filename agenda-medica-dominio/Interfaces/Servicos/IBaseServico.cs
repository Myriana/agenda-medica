using System;
using System.Collections.Generic;
using System.Text;

namespace agenda_medica_dominio.Interfaces.Servicos
{
    public interface IBaseServico<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> ListarTodos();
        TEntity ObterPorId(long id);
        void Incluir(TEntity entity);
        void Alterar(TEntity entity);
        void Deletar(TEntity entity);
    }
}
