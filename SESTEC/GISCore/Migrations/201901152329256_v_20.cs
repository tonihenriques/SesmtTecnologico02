namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_20 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbAtividadeAlocada", "idTipoDeRisco", "dbo.tbTipoDeRisco");
            DropIndex("dbo.tbAtividadeAlocada", new[] { "idTipoDeRisco" });
            AddColumn("dbo.tbExposicao", "idTipoDeRisco", c => c.String());
            AddColumn("dbo.tbExposicao", "TipoDeAcesso", c => c.Int(nullable: false));
            DropColumn("dbo.tbAtividadeAlocada", "idTipoDeRisco");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbAtividadeAlocada", "idTipoDeRisco", c => c.String(maxLength: 128));
            DropColumn("dbo.tbExposicao", "TipoDeAcesso");
            DropColumn("dbo.tbExposicao", "idTipoDeRisco");
            CreateIndex("dbo.tbAtividadeAlocada", "idTipoDeRisco");
            AddForeignKey("dbo.tbAtividadeAlocada", "idTipoDeRisco", "dbo.tbTipoDeRisco", "IDTipoDeRisco");
        }
    }
}
