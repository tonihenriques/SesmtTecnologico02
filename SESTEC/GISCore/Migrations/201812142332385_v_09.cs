namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_09 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbAtividadesDoEstabelecimento", "IDTipoDeRisco", "dbo.tbTipoDeRisco");
            DropIndex("dbo.tbAtividadesDoEstabelecimento", new[] { "IDTipoDeRisco" });
            AddColumn("dbo.tbTipoDeRisco", "idAtividadesDoEstabelecimento", c => c.String(maxLength: 128));
            CreateIndex("dbo.tbTipoDeRisco", "idAtividadesDoEstabelecimento");
            AddForeignKey("dbo.tbTipoDeRisco", "idAtividadesDoEstabelecimento", "dbo.tbAtividadesDoEstabelecimento", "IDAtividadesDoEstabelecimento");
            DropColumn("dbo.tbAtividadesDoEstabelecimento", "IDTipoDeRisco");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbAtividadesDoEstabelecimento", "IDTipoDeRisco", c => c.String(maxLength: 128));
            DropForeignKey("dbo.tbTipoDeRisco", "idAtividadesDoEstabelecimento", "dbo.tbAtividadesDoEstabelecimento");
            DropIndex("dbo.tbTipoDeRisco", new[] { "idAtividadesDoEstabelecimento" });
            DropColumn("dbo.tbTipoDeRisco", "idAtividadesDoEstabelecimento");
            CreateIndex("dbo.tbAtividadesDoEstabelecimento", "IDTipoDeRisco");
            AddForeignKey("dbo.tbAtividadesDoEstabelecimento", "IDTipoDeRisco", "dbo.tbTipoDeRisco", "IDTipoDeRisco");
        }
    }
}
