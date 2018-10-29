namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v33 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbExposicao", "idAlocacao", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbExposicao", "idAlocacao");
        }
    }
}
