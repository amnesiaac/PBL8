using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bruno_prova1.Models
{
    public class Exercicio
    {
        public int ExercicioId { get; set; }
        public string Nome { get; set; }
        public int QuantidadeRepeticao { get; set; }
        public int Tempo { get; set; }
        public bool PertenceTreino { get; set; }
        public virtual Aparelho Aparelho { get; set; }
        public int AparelhoId { get; set; }

        public Exercicio()
        {
            PertenceTreino = false;

        }
    }
}