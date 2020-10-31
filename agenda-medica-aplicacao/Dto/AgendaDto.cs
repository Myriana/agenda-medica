using System;
using System.Collections.Generic;
using System.Text;

namespace agenda_medica_aplicacao.Dto
{
    public class AgendaDto
    {
        public long Id { get; set; }

        public string NomePaciente { get; set; }

        public DateTime DataNascimentoPaciente { get; set; }

        public DateTime DataInicialConsulta { get; set; }

        public DateTime DataFimConsulta { get; set; }

        public string Observacoes { get; set; }
    }
}
