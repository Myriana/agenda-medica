using agenda_medica_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace agenda_medica_dominio.Interfaces.Repositorios
{
    public interface IAgendaRepositorio : IBaseRepositorio<Agenda>
    {
        IEnumerable<Agenda> ObterAgendaPorDataConsulta(DateTime dataInicioConsulta);
    }
}
