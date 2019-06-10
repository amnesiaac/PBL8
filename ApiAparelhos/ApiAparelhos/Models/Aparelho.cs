using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiAparelhos.Models
{
    public class Aparelho
    {
        public int AparelhoId { get; set; }
        public string Nome { get; set; }
        public string Link { get; set; }
        public string MusculoTrabalhado { get; set; }
    }
}