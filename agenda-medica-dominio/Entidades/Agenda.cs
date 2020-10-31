using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace agenda_medica_dominio.Entidades
{
    public class Agenda
    {
        [Key]
        public long Id { get; set; }

        public string NomePaciente { get; set; }

        public DateTime DataNascimentoPaciente { get; set; }

        public DateTime DataInicialConsulta { get; set; }

        public DateTime DataFimConsulta { get; set; }

        public string Observacoes { get; set; }
    }
}
