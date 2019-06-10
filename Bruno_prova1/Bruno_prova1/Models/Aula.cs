using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bruno_prova1.Models
{
    public class Aula
    {
        public int AulaId { get; set; }
        public string Data { get; set; }
        public virtual Treino Treino { get; set; }
        public int TreinoId { get; set; }
    }
}