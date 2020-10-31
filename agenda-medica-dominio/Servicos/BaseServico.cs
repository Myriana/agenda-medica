using agenda_medica_dominio.Interfaces.Repositorios;
using agenda_medica_dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace agenda_medica_dominio.Servicos
{
    public class BaseServico<TEntity> : IBaseServico<TEntity> where TEntity : class
    {
        private readonly IBaseRepositorio<TEntity> _repositorio;

        public BaseServico(IBaseRepositorio<TEntity> repositorio)
        {
            _repositorio = repositorio;
        }

        public void Alterar(TEntity entity)
        {
            _repositorio.Alterar(entity);
        }

        public void Deletar(TEntity entity)
        {
            _repositorio.Deletar(entity);
        }

        public void Incluir(TEntity entity)
        {
            _repositorio.Incluir(entity);
        }

        public IEnumerable<TEntity> ListarTodos()
        {
            return _repositorio.ListarTodos();
        }

        public TEntity ObterPorId(long id)
        {
            return _repositorio.ObterPorId(id);
        }
    }
}
