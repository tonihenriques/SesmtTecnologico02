namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_21 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbExposicao", "idTipoDeRisco", c => c.String(maxLength: 128));
            CreateIndex("dbo.tbExposicao", "idTipoDeRisco");
            AddForeignKey("dbo.tbExposicao", "idTipoDeRisco", "dbo.tbTipoDeRisco", "IDTipoDeRisco");
            DropColumn("dbo.tbExposicao", "TipoDeAcesso");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbExposicao", "TipoDeAcesso", c => c.Int(nullable: false));
            DropForeignKey("dbo.tbExposicao", "idTipoDeRisco", "dbo.tbTipoDeRisco");
            DropIndex("dbo.tbExposicao", new[] { "idTipoDeRisco" });
            AlterColumn("dbo.tbExposicao", "idTipoDeRisco", c => c.String());
        }
    }
}
