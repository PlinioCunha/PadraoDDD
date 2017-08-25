namespace Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LogAcessoUsuario",
                c => new
                    {
                        IdLogAcessoUsuario = c.Int(nullable: false, identity: true),
                        IdUsuario = c.Int(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        IP = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.IdLogAcessoUsuario)
                .ForeignKey("dbo.Usuario", t => t.IdUsuario)
                .Index(t => t.IdUsuario);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        IdUsuario = c.Int(nullable: false, identity: true),
                        IdPerfilUsuario = c.Int(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        Email = c.String(nullable: false, maxLength: 250, unicode: false),
                        Foto = c.String(maxLength: 250, unicode: false),
                        Senha = c.String(nullable: false, unicode: false),
                        SenhaKey = c.String(nullable: false, unicode: false),
                        DataCadastro = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        PublicKeySocial = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.IdUsuario)
                .ForeignKey("dbo.PerfilUsuario", t => t.IdPerfilUsuario)
                .Index(t => t.IdPerfilUsuario)
                .Index(t => t.Email, name: "IX_LoginNameUser");
            
            CreateTable(
                "dbo.PerfilUsuario",
                c => new
                    {
                        IdPerfilUsuario = c.Int(nullable: false, identity: true),
                        NomePerfil = c.String(nullable: false, maxLength: 100, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdPerfilUsuario);
            
            CreateTable(
                "dbo.ModulosAcesso",
                c => new
                    {
                        IdModulosAcesso = c.Int(nullable: false),
                        NomeModulo = c.String(maxLength: 100, unicode: false),
                        NomeMenuAcesso = c.String(maxLength: 100, unicode: false),
                        UrlMenu = c.String(maxLength: 100, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                        Visualizar = c.Boolean(nullable: false),
                        Editar = c.Boolean(nullable: false),
                        Excluir = c.Boolean(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        IdModuloPai = c.Int(),
                    })
                .PrimaryKey(t => t.IdModulosAcesso);
            
            CreateTable(
                "dbo.ModulosAcessoPerfilUsuario",
                c => new
                    {
                        ModulosAcesso_IdModulosAcesso = c.Int(nullable: false),
                        PerfilUsuario_IdPerfilUsuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ModulosAcesso_IdModulosAcesso, t.PerfilUsuario_IdPerfilUsuario })
                .ForeignKey("dbo.ModulosAcesso", t => t.ModulosAcesso_IdModulosAcesso)
                .ForeignKey("dbo.PerfilUsuario", t => t.PerfilUsuario_IdPerfilUsuario)
                .Index(t => t.ModulosAcesso_IdModulosAcesso)
                .Index(t => t.PerfilUsuario_IdPerfilUsuario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LogAcessoUsuario", "IdUsuario", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "IdPerfilUsuario", "dbo.PerfilUsuario");
            DropForeignKey("dbo.ModulosAcessoPerfilUsuario", "PerfilUsuario_IdPerfilUsuario", "dbo.PerfilUsuario");
            DropForeignKey("dbo.ModulosAcessoPerfilUsuario", "ModulosAcesso_IdModulosAcesso", "dbo.ModulosAcesso");
            DropIndex("dbo.ModulosAcessoPerfilUsuario", new[] { "PerfilUsuario_IdPerfilUsuario" });
            DropIndex("dbo.ModulosAcessoPerfilUsuario", new[] { "ModulosAcesso_IdModulosAcesso" });
            DropIndex("dbo.Usuario", "IX_LoginNameUser");
            DropIndex("dbo.Usuario", new[] { "IdPerfilUsuario" });
            DropIndex("dbo.LogAcessoUsuario", new[] { "IdUsuario" });
            DropTable("dbo.ModulosAcessoPerfilUsuario");
            DropTable("dbo.ModulosAcesso");
            DropTable("dbo.PerfilUsuario");
            DropTable("dbo.Usuario");
            DropTable("dbo.LogAcessoUsuario");
        }
    }
}
