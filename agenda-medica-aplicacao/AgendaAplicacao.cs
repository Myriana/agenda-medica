using agenda_medica_aplicacao.Dto;
using agenda_medica_aplicacao.Interfaces;
using agenda_medica_aplicacao.Interfaces.Mappers;
using agenda_medica_dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace agenda_medica_aplicacao
{
    public class AgendaAplicacao : IAgendaAplicacao
    {
        private readonly IAgendaServico _agendaServico;
        private readonly IMapperAgenda _mapperAgenda;

        public AgendaAplicacao(IAgendaServico agendaServico, IMapperAgenda mapperAgenda)
        {
            _agendaServico = agendaServico;
            _mapperAgenda = mapperAgenda;
        }

        public AgendaDto Alterar(AgendaDto agendaDto)
        {
            var agendasDoDia = _agendaServico.ObterAgendasPorDataConsulta(agendaDto.DataInicialConsulta);
            var agendaCadastrada = _agendaServico.ObterPorId(agendaDto.Id);
            if(agendaCadastrada == null) throw new Exception("Agenda não encontrada");
            if (agendaDto.DataFimConsulta < agendaDto.DataInicialConsulta) throw new Exception("A data final da consulta não pode ser menor que a data inicial");
            if (agendasDoDia != null && agendasDoDia.Any())
            {
                if(agendasDoDia.FirstOrDefault(x => x.Id != agendaDto.Id && x.DataInicialConsulta.TimeOfDay >= agendaDto.DataInicialConsulta.TimeOfDay && x.DataFimConsulta.TimeOfDay <= agendaDto.DataFimConsulta.TimeOfDay) != null)
                {
                    throw new Exception("O horário da consulta informado já possui agenda marcada");
                }
            }
            agendaCadastrada.NomePaciente = agendaDto.NomePaciente;
            agendaCadastrada.DataNascimentoPaciente = agendaDto.DataNascimentoPaciente;
            agendaCadastrada.DataInicialConsulta = agendaDto.DataInicialConsulta;
            agendaCadastrada.DataFimConsulta = agendaDto.DataFimConsulta;
            agendaCadastrada.Observacoes = agendaDto.Observacoes;
            _agendaServico.Alterar(agendaCadastrada);

            return agendaDto;
        }

        public AgendaDto Deletar(AgendaDto agendaDto)
        {
            var agendaCadastrada = _agendaServico.ObterPorId(agendaDto.Id);
            if (agendaCadastrada == null) throw new Exception("Agenda não encontrada");
            _agendaServico.Deletar(agendaCadastrada);
            return agendaDto;
        }

        public AgendaDto Incluir(AgendaDto agendaDto)
        {
            var agenda = _mapperAgenda.MapperDtoToEntity(agendaDto);
            var agendasDoDia = _agendaServico.ObterAgendasPorDataConsulta(agenda.DataInicialConsulta);
            if (agenda.DataFimConsulta < agenda.DataInicialConsulta)
            {
                throw new Exception("A data final da consulta não pode ser menor que a data inicial");
            }
            if (agendasDoDia != null && agendasDoDia.Any())
            {
                if (agendasDoDia.FirstOrDefault(x => x.DataInicialConsulta.TimeOfDay >= agenda.DataInicialConsulta.TimeOfDay && x.DataFimConsulta.TimeOfDay <= agenda.DataFimConsulta.TimeOfDay) != null)
                {
                    throw new Exception("O horário da consulta informado já possui agenda marcada");
                }
            }
            _agendaServico.Incluir(agenda);
            return agendaDto;
        }

        public IEnumerable<AgendaDto> ListarTodos()
        {
            var agendas = _agendaServico.ListarTodos();
            return _mapperAgenda.MapperListAgendaDto(agendas);
        }

        public AgendaDto ObterPorId(long id)
        {
            var agenda = _agendaServico.ObterPorId(id);
            if (agenda == null) throw new Exception("Agenda não encontrada");
            return _mapperAgenda.MapperEntityToDto(agenda);
        }
    }
}
