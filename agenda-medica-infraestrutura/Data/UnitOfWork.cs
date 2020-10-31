using agenda_medica_dominio.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace agenda_medica_infraestrutura.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContextoDb _contexto;

        public UnitOfWork(ContextoDb contexto)
        {
            _contexto = contexto;
        }

        public void Commit()
        {
            _contexto.SaveChanges();
        }

        public void RollBack()
        {
            _contexto.Dispose();
        }
    }
}
