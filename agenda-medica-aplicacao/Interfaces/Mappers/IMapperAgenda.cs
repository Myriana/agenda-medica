using agenda_medica_aplicacao.Dto;
using agenda_medica_dominio.Entidades;
using System.Collections.Generic;

namespace agenda_medica_aplicacao.Interfaces.Mappers
{
    public interface IMapperAgenda
    {
        Agenda MapperDtoToEntity(AgendaDto agendaDto);
        IEnumerable<AgendaDto> MapperListAgendaDto(IEnumerable<Agenda> agendas);
        AgendaDto MapperEntityToDto(Agenda agenda);
    }
}
