using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Bruno_prova1.Models
{
    public class Bruno_prova1Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Bruno_prova1Context() : base("name=Bruno_prova1Context")
        {
        }

        public System.Data.Entity.DbSet<Bruno_prova1.Models.Aparelho> Aparelhoes { get; set; }

        public System.Data.Entity.DbSet<Bruno_prova1.Models.Exercicio> Exercicios { get; set; }

        public System.Data.Entity.DbSet<Bruno_prova1.Models.Treino> Treinoes { get; set; }

        public System.Data.Entity.DbSet<Bruno_prova1.Models.Aula> Aulas { get; set; }
    }
}
