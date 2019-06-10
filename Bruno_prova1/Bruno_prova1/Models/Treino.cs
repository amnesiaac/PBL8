using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bruno_prova1.Models
{
    public class Treino
    {
        public int TreinoId { get; set; }
        public string Nome { get; set; }
        public int NumeroVezesTreino { get; set; }
        public int TempoMaximo { get; set; }
        public virtual Exercicio Exercicio { get; set; }
        public int ExercicioId { get; set; }
    }
}