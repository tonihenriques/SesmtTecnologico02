namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbPlanoDeAcao", "Identificador", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbPlanoDeAcao", "Identificador");
        }
    }
}
