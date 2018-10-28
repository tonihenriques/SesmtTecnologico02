namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v26 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbPlanoDeAcao", "DataPrevista", c => c.DateTime(nullable: false));
            DropColumn("dbo.tbPlanoDeAcao", "DataEntrega");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbPlanoDeAcao", "DataEntrega", c => c.String());
            DropColumn("dbo.tbPlanoDeAcao", "DataPrevista");
        }
    }
}
