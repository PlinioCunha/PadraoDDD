namespace Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pix : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HistoricoTarefa",
                c => new
                    {
                        IdHistoricoTarefa = c.Int(nullable: false, identity: true),
                        DataCadastro = c.DateTime(nullable: false),
                        IdTarefa = c.Int(nullable: false),
                        IdUsuario = c.Int(nullable: false),
                        TextoHistorico = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.IdHistoricoTarefa)
                .ForeignKey("dbo.Tarefa", t => t.IdTarefa)
                .ForeignKey("dbo.Usuario", t => t.IdUsuario)
                .Index(t => t.IdTarefa)
                .Index(t => t.IdUsuario);
            
            CreateTable(
                "dbo.Tarefa",
                c => new
                    {
                        IdTarefa = c.Int(nullable: false, identity: true),
                        TituloTarefa = c.String(nullable: false, maxLength: 100, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                        IdCategoriaTarefa = c.Int(nullable: false),
                        Descricao = c.String(maxLength: 100, unicode: false),
                        IdUserCreate = c.Int(nullable: false),
                        IdHistoricoTarefa = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdTarefa)
                .ForeignKey("dbo.Usuario", t => t.IdUserCreate)
                .Index(t => t.IdUserCreate);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HistoricoTarefa", "IdUsuario", "dbo.Usuario");
            DropForeignKey("dbo.HistoricoTarefa", "IdTarefa", "dbo.Tarefa");
            DropForeignKey("dbo.Tarefa", "IdUserCreate", "dbo.Usuario");
            DropIndex("dbo.Tarefa", new[] { "IdUserCreate" });
            DropIndex("dbo.HistoricoTarefa", new[] { "IdUsuario" });
            DropIndex("dbo.HistoricoTarefa", new[] { "IdTarefa" });
            DropTable("dbo.Tarefa");
            DropTable("dbo.HistoricoTarefa");
        }
    }
}
