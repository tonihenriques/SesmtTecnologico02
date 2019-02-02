namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_17 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbExposicao", "idTipoDeRisco", c => c.String());
            AddColumn("dbo.tbExposicao", "TipoDeAcesso", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbExposicao", "TipoDeAcesso");
            DropColumn("dbo.tbExposicao", "idTipoDeRisco");
        }
    }
}
