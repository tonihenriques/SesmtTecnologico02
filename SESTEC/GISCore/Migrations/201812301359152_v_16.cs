namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_16 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbAtividadesDoEstabelecimento", "IDPossiveisDanos", c => c.String(maxLength: 128));
            AddColumn("dbo.tbAtividadesDoEstabelecimento", "IDEventoPerigoso", c => c.String(maxLength: 128));
            CreateIndex("dbo.tbAtividadesDoEstabelecimento", "IDPossiveisDanos");
            CreateIndex("dbo.tbAtividadesDoEstabelecimento", "IDEventoPerigoso");
            AddForeignKey("dbo.tbAtividadesDoEstabelecimento", "IDEventoPerigoso", "dbo.tbEventoPerigoso", "IDEventoPerigoso");
            AddForeignKey("dbo.tbAtividadesDoEstabelecimento", "IDPossiveisDanos", "dbo.tbPossiveisDanos", "IDPossiveisDanos");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbAtividadesDoEstabelecimento", "IDPossiveisDanos", "dbo.tbPossiveisDanos");
            DropForeignKey("dbo.tbAtividadesDoEstabelecimento", "IDEventoPerigoso", "dbo.tbEventoPerigoso");
            DropIndex("dbo.tbAtividadesDoEstabelecimento", new[] { "IDEventoPerigoso" });
            DropIndex("dbo.tbAtividadesDoEstabelecimento", new[] { "IDPossiveisDanos" });
            DropColumn("dbo.tbAtividadesDoEstabelecimento", "IDEventoPerigoso");
            DropColumn("dbo.tbAtividadesDoEstabelecimento", "IDPossiveisDanos");
        }
    }
}
