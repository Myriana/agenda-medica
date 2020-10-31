using agenda_medica_dominio.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace agenda_medica_infraestrutura.Repositorios
{
    public class BaseRepositorio<TEntity> : IBaseRepositorio<TEntity> where TEntity : class
    {
        private readonly DbContext _contexto;
        public BaseRepositorio(DbContext contexto)
        {
            _contexto = contexto;
        }
        public void Alterar(TEntity entity)
        {
            _contexto.Set<TEntity>().Update(entity);
        }

        public void Deletar(TEntity entity)
        {
            _contexto.Set<TEntity>().Remove(entity);
        }

        public void Incluir(TEntity entity)
        {
            _contexto.Set<TEntity>().Add(entity);
        }

        public IEnumerable<TEntity> ListarTodos()
        {
            return _contexto.Set<TEntity>().ToList();
        }

        public TEntity ObterPorId(long id)
        {
            return _contexto.Set<TEntity>().Find(id);
        }
    }
}
