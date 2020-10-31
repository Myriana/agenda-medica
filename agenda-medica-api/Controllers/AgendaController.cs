using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using agenda_medica_aplicacao.Dto;
using agenda_medica_aplicacao.Interfaces;
using agenda_medica_dominio.Interfaces.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace agenda_medica_api.Controllers
{
    [Route("agenda/")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IAgendaAplicacao _agendaAplicacao;

        public AgendaController(IAgendaAplicacao agendaAplicacao, IUnitOfWork uow)
        {
            _agendaAplicacao = agendaAplicacao;
            _uow = uow;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<IEnumerable<string>> ObterTodas()
        {
            try
            {
                return Ok(_agendaAplicacao.ListarTodos());
            }
            catch(Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<string> ObterPorId(long id)
        {
            try
            {
                return Ok(_agendaAplicacao.ObterPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("")]
        public ActionResult Incluir(AgendaDto agendaDto)
        {
            try
            {
                var agenda = _agendaAplicacao.Incluir(agendaDto);
                _uow.Commit();
                return Ok(agenda);
            }
            catch (Exception ex)
            {
                _uow.RollBack();
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("")]
        public ActionResult Alterar(AgendaDto agendaDto)
        {
            try
            {
                var agenda = _agendaAplicacao.Alterar(agendaDto);
                _uow.Commit();
                return Ok(agenda);
            }
            catch (Exception ex)
            {
                _uow.RollBack();
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Deletar(int id)
        {
            try
            {
                var agendaDto = new AgendaDto() { Id = id };
                var agenda = _agendaAplicacao.Deletar(agendaDto);
                _uow.Commit();
                return Ok(agenda);
            }
            catch (Exception ex)
            {
                _uow.RollBack();
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}
