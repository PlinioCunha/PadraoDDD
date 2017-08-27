namespace Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PadraDDD : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LogSystem", "Message", c => c.String(maxLength: 5000, unicode: false));
            AlterColumn("dbo.LogSystem", "Exception", c => c.String(maxLength: 5000, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LogSystem", "Exception", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.LogSystem", "Message", c => c.String(maxLength: 100, unicode: false));
        }
    }
}
