using agenda_medica_aplicacao.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace agenda_medica_aplicacao.Interfaces
{
    public interface IAgendaAplicacao
    {
        AgendaDto Incluir(AgendaDto agendaDto);
        AgendaDto Deletar(AgendaDto agendaDto);
        AgendaDto Alterar(AgendaDto agendaDto);
        IEnumerable<AgendaDto> ListarTodos();
        AgendaDto ObterPorId(long id);
    }
}
