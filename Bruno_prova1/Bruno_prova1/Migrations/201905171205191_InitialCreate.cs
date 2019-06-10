namespace Bruno_prova1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aparelhoes",
                c => new
                    {
                        AparelhoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Link = c.String(),
                        MusculoTrabalhado = c.String(),
                    })
                .PrimaryKey(t => t.AparelhoId);
            
            CreateTable(
                "dbo.Aulas",
                c => new
                    {
                        AulaId = c.Int(nullable: false, identity: true),
                        Data = c.String(),
                        TreinoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AulaId)
                .ForeignKey("dbo.Treinoes", t => t.TreinoId, cascadeDelete: true)
                .Index(t => t.TreinoId);
            
            CreateTable(
                "dbo.Treinoes",
                c => new
                    {
                        TreinoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        NumeroVezesTreino = c.Int(nullable: false),
                        TempoMaximo = c.Int(nullable: false),
                        ExercicioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TreinoId)
                .ForeignKey("dbo.Exercicios", t => t.ExercicioId, cascadeDelete: true)
                .Index(t => t.ExercicioId);
            
            CreateTable(
                "dbo.Exercicios",
                c => new
                    {
                        ExercicioId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        QuantidadeRepeticao = c.Int(nullable: false),
                        Tempo = c.Int(nullable: false),
                        PertenceTreino = c.Boolean(nullable: false),
                        AparelhoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExercicioId)
                .ForeignKey("dbo.Aparelhoes", t => t.AparelhoId, cascadeDelete: true)
                .Index(t => t.AparelhoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Aulas", "TreinoId", "dbo.Treinoes");
            DropForeignKey("dbo.Treinoes", "ExercicioId", "dbo.Exercicios");
            DropForeignKey("dbo.Exercicios", "AparelhoId", "dbo.Aparelhoes");
            DropIndex("dbo.Exercicios", new[] { "AparelhoId" });
            DropIndex("dbo.Treinoes", new[] { "ExercicioId" });
            DropIndex("dbo.Aulas", new[] { "TreinoId" });
            DropTable("dbo.Exercicios");
            DropTable("dbo.Treinoes");
            DropTable("dbo.Aulas");
            DropTable("dbo.Aparelhoes");
        }
    }
}
