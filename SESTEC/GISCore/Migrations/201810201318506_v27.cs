namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v27 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbPlanoDeAcao", "DataPrevista", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbPlanoDeAcao", "DataPrevista", c => c.DateTime(nullable: false));
        }
    }
}
