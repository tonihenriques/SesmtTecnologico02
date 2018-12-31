namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_13 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbAtividadesDoEstabelecimento", "IDEventoPerigoso", "dbo.tbEventoPerigoso");
            DropForeignKey("dbo.tbAtividadesDoEstabelecimento", "IDPossiveisDanos", "dbo.tbPossiveisDanos");
            DropForeignKey("dbo.tbTipoDeRisco", "idAtividadesDoEstabelecimento", "dbo.tbAtividadesDoEstabelecimento");
            DropIndex("dbo.tbAtividadesDoEstabelecimento", new[] { "IDPossiveisDanos" });
            DropIndex("dbo.tbAtividadesDoEstabelecimento", new[] { "IDEventoPerigoso" });
            DropIndex("dbo.tbTipoDeRisco", new[] { "idAtividadesDoEstabelecimento" });
            DropColumn("dbo.tbAtividadesDoEstabelecimento", "IDPossiveisDanos");
            DropColumn("dbo.tbAtividadesDoEstabelecimento", "IDEventoPerigoso");
            DropColumn("dbo.tbTipoDeRisco", "idAtividadesDoEstabelecimento");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbTipoDeRisco", "idAtividadesDoEstabelecimento", c => c.String(maxLength: 128));
            AddColumn("dbo.tbAtividadesDoEstabelecimento", "IDEventoPerigoso", c => c.String(maxLength: 128));
            AddColumn("dbo.tbAtividadesDoEstabelecimento", "IDPossiveisDanos", c => c.String(maxLength: 128));
            CreateIndex("dbo.tbTipoDeRisco", "idAtividadesDoEstabelecimento");
            CreateIndex("dbo.tbAtividadesDoEstabelecimento", "IDEventoPerigoso");
            CreateIndex("dbo.tbAtividadesDoEstabelecimento", "IDPossiveisDanos");
            AddForeignKey("dbo.tbTipoDeRisco", "idAtividadesDoEstabelecimento", "dbo.tbAtividadesDoEstabelecimento", "IDAtividadesDoEstabelecimento");
            AddForeignKey("dbo.tbAtividadesDoEstabelecimento", "IDPossiveisDanos", "dbo.tbPossiveisDanos", "IDPossiveisDanos");
            AddForeignKey("dbo.tbAtividadesDoEstabelecimento", "IDEventoPerigoso", "dbo.tbEventoPerigoso", "IDEventoPerigoso");
        }
    }
}
