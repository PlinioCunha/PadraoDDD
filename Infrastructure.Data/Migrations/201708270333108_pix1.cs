namespace Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pix1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Tarefa", name: "IdUserCreate", newName: "IdUsuarioCreate");
            RenameIndex(table: "dbo.Tarefa", name: "IX_IdUserCreate", newName: "IX_IdUsuarioCreate");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Tarefa", name: "IX_IdUsuarioCreate", newName: "IX_IdUserCreate");
            RenameColumn(table: "dbo.Tarefa", name: "IdUsuarioCreate", newName: "IdUserCreate");
        }
    }
}
