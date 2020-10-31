using System;
using System.Collections.Generic;
using System.Text;

namespace agenda_medica_dominio.Interfaces.Data
{
    public interface IUnitOfWork
    {
        void Commit();
        void RollBack();
    }
}
