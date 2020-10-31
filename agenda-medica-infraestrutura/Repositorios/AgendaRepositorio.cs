using agenda_medica_dominio.Entidades;
using agenda_medica_dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agenda_medica_infraestrutura.Repositorios
{
    public class AgendaRepositorio : BaseRepositorio<Agenda>, IAgendaRepositorio
    {
        private readonly ContextoDb _contexto;
        public AgendaRepositorio(ContextoDb contexto)
            :base(contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<Agenda> ObterAgendaPorDataConsulta(DateTime dataInicioConsulta)
        {
            return _contexto.Agendas.Where(x => x.DataInicialConsulta.Date == dataInicioConsulta.Date);
        }
    }
}
