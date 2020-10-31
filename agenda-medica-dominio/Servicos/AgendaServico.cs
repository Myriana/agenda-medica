using agenda_medica_dominio.Entidades;
using agenda_medica_dominio.Interfaces.Repositorios;
using agenda_medica_dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace agenda_medica_dominio.Servicos
{
    public class AgendaServico : BaseServico<Agenda>, IAgendaServico
    {
        public readonly IAgendaRepositorio _agendaRepositorio;
        public AgendaServico(IAgendaRepositorio agendaRepositorio)
            :base(agendaRepositorio)
        {
            _agendaRepositorio = agendaRepositorio;
        }

        public IEnumerable<Agenda> ObterAgendasPorDataConsulta(DateTime dataInicioConsulta)
        {
            return _agendaRepositorio.ObterAgendaPorDataConsulta(dataInicioConsulta);
        }
    }
}
