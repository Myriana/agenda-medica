using agenda_medica_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace agenda_medica_dominio.Interfaces.Servicos
{
    public interface IAgendaServico : IBaseServico<Agenda>
    {
        IEnumerable<Agenda> ObterAgendasPorDataConsulta(DateTime dataInicioConsulta);
    }
}
