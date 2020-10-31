using agenda_medica_aplicacao.Dto;
using agenda_medica_aplicacao.Interfaces.Mappers;
using agenda_medica_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace agenda_medica_aplicacao.Mappers
{
    public class MapperAgenda : IMapperAgenda
    {
        IEnumerable<AgendaDto> agendasDto = new List<AgendaDto>();
        public Agenda MapperDtoToEntity(AgendaDto agendaDto)
        {
            var agenda = new Agenda()
            {
                Id = agendaDto.Id,
                DataFimConsulta = agendaDto.DataFimConsulta,
                DataInicialConsulta = agendaDto.DataInicialConsulta,
                DataNascimentoPaciente = agendaDto.DataNascimentoPaciente,
                NomePaciente = agendaDto.NomePaciente,
                Observacoes = agendaDto.Observacoes
            };
            return agenda;
        }

        public AgendaDto MapperEntityToDto(Agenda agenda)
        {
            var agendaDto = new AgendaDto()
            {
                Id = agenda.Id,
                DataFimConsulta = agenda.DataFimConsulta,
                DataInicialConsulta = agenda.DataInicialConsulta,
                DataNascimentoPaciente = agenda.DataNascimentoPaciente,
                NomePaciente = agenda.NomePaciente,
                Observacoes = agenda.Observacoes
            };
            return agendaDto;
        }

        public IEnumerable<AgendaDto> MapperListAgendaDto(IEnumerable<Agenda> agendas)
        {
            var agendasDto = agendas.Select(a => new AgendaDto() { Id = a.Id, DataFimConsulta = a.DataFimConsulta, DataInicialConsulta = a.DataInicialConsulta, DataNascimentoPaciente = a.DataNascimentoPaciente, NomePaciente = a.NomePaciente, Observacoes = a.Observacoes });
            return agendasDto;
        }
    }
}
