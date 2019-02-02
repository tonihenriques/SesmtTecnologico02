namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_19 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbExposicao", "idTipoDeRisco", "dbo.tbTipoDeRisco");
            DropIndex("dbo.tbExposicao", new[] { "idTipoDeRisco" });
            AddColumn("dbo.tbAtividadeAlocada", "idTipoDeRisco", c => c.String(maxLength: 128));
            CreateIndex("dbo.tbAtividadeAlocada", "idTipoDeRisco");
            AddForeignKey("dbo.tbAtividadeAlocada", "idTipoDeRisco", "dbo.tbTipoDeRisco", "IDTipoDeRisco");
            DropColumn("dbo.tbExposicao", "idTipoDeRisco");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbExposicao", "idTipoDeRisco", c => c.String(maxLength: 128));
            DropForeignKey("dbo.tbAtividadeAlocada", "idTipoDeRisco", "dbo.tbTipoDeRisco");
            DropIndex("dbo.tbAtividadeAlocada", new[] { "idTipoDeRisco" });
            DropColumn("dbo.tbAtividadeAlocada", "idTipoDeRisco");
            CreateIndex("dbo.tbExposicao", "idTipoDeRisco");
            AddForeignKey("dbo.tbExposicao", "idTipoDeRisco", "dbo.tbTipoDeRisco", "IDTipoDeRisco");
        }
    }
}
