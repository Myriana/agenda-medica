using agenda_medica_dominio.Entidades;
using agenda_medica_dominio.Interfaces.Data;
using agenda_medica_dominio.Interfaces.Repositorios;
using agenda_medica_dominio.Servicos;
using agenda_medica_infraestrutura;
using agenda_medica_infraestrutura.Data;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace agenda_medica_testes.Servicos
{
    public class AgendaServicoTeste
    {
        [Fact]
        public void Incluir_Agenda()
        {
            var mockRepository = new Mock<IAgendaRepositorio>();
            var agendaServico = new AgendaServico(mockRepository.Object);
            agendaServico.Incluir(new Agenda() { Id = 1, NomePaciente = "Myriana Almeida", DataNascimentoPaciente = DateTime.Parse("04/09/1987"), DataInicialConsulta = new DateTime(2020, 11, 01, 08, 00, 00), DataFimConsulta = new DateTime(2020, 11, 01, 08, 30, 00), Observacoes = "" });
            mockRepository.Verify(m => m.Incluir(It.IsAny<Agenda>()), Times.Once());
        }

        [Fact]
        public void Alterar_Agenda()
        {
            var mockRepository = new Mock<IAgendaRepositorio>();
            var agendaServico = new AgendaServico(mockRepository.Object);
            agendaServico.Alterar(new Agenda() { Id = 1, NomePaciente = "Myriana Almeida", DataNascimentoPaciente = DateTime.Parse("04/09/1987"), DataInicialConsulta = new DateTime(2020, 11, 01, 08, 00, 00), DataFimConsulta = new DateTime(2020, 11, 01, 08, 30, 00), Observacoes = "" });
            mockRepository.Verify(m => m.Alterar(It.IsAny<Agenda>()), Times.Once());
        }

        [Fact]
        public void Deletar_Agenda()
        {
            var mockRepository = new Mock<IAgendaRepositorio>();
            var agendaServico = new AgendaServico(mockRepository.Object);
            agendaServico.Deletar(new Agenda() { Id = 1, NomePaciente = "Myriana Almeida", DataNascimentoPaciente = DateTime.Parse("04/09/1987"), DataInicialConsulta = new DateTime(2020, 11, 01, 08, 00, 00), DataFimConsulta = new DateTime(2020, 11, 01, 08, 30, 00), Observacoes = "" });
            mockRepository.Verify(m => m.Deletar(It.IsAny<Agenda>()), Times.Once());
        }

        [Fact]
        public void Obter_Por_Id_Agenda()
        {
            var mockRepository = new Mock<IAgendaRepositorio>();
            var agendaServico = new AgendaServico(mockRepository.Object);
            var obter = agendaServico.ObterPorId(1);
            mockRepository.Verify(m => m.ObterPorId(It.IsAny<long>()), Times.Once());
        }

        [Fact]
        public void Listar_Todos_Agenda()
        {
            var mockRepository = new Mock<IAgendaRepositorio>();
            var agendaServico = new AgendaServico(mockRepository.Object);
            var obter = agendaServico.ListarTodos();
            mockRepository.Verify(m => m.ListarTodos(), Times.Once());
        }
    }
}
