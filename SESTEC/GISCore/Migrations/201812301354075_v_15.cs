namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_15 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rel_AtivEstabTipoRisco", "AtividadesDoEstabelecimento_IDAtividadesDoEstabelecimento", "dbo.tbAtividadesDoEstabelecimento");
            DropForeignKey("dbo.Rel_AtivEstabTipoRisco", "idTipoDeRisco", "dbo.tbTipoDeRisco");
            DropIndex("dbo.Rel_AtivEstabTipoRisco", new[] { "idTipoDeRisco" });
            DropIndex("dbo.Rel_AtivEstabTipoRisco", new[] { "AtividadesDoEstabelecimento_IDAtividadesDoEstabelecimento" });
            AddColumn("dbo.tbTipoDeRisco", "idAtividadesDoEstabelecimento", c => c.String(maxLength: 128));
            CreateIndex("dbo.tbTipoDeRisco", "idAtividadesDoEstabelecimento");
            AddForeignKey("dbo.tbTipoDeRisco", "idAtividadesDoEstabelecimento", "dbo.tbAtividadesDoEstabelecimento", "IDAtividadesDoEstabelecimento");
            DropColumn("dbo.Rel_AtivEstabTipoRisco", "idAtividadeEstabelecimento");
            DropColumn("dbo.Rel_AtivEstabTipoRisco", "idTipoDeRisco");
            DropColumn("dbo.Rel_AtivEstabTipoRisco", "AtividadesDoEstabelecimento_IDAtividadesDoEstabelecimento");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rel_AtivEstabTipoRisco", "AtividadesDoEstabelecimento_IDAtividadesDoEstabelecimento", c => c.String(maxLength: 128));
            AddColumn("dbo.Rel_AtivEstabTipoRisco", "idTipoDeRisco", c => c.String(maxLength: 128));
            AddColumn("dbo.Rel_AtivEstabTipoRisco", "idAtividadeEstabelecimento", c => c.String());
            DropForeignKey("dbo.tbTipoDeRisco", "idAtividadesDoEstabelecimento", "dbo.tbAtividadesDoEstabelecimento");
            DropIndex("dbo.tbTipoDeRisco", new[] { "idAtividadesDoEstabelecimento" });
            DropColumn("dbo.tbTipoDeRisco", "idAtividadesDoEstabelecimento");
            CreateIndex("dbo.Rel_AtivEstabTipoRisco", "AtividadesDoEstabelecimento_IDAtividadesDoEstabelecimento");
            CreateIndex("dbo.Rel_AtivEstabTipoRisco", "idTipoDeRisco");
            AddForeignKey("dbo.Rel_AtivEstabTipoRisco", "idTipoDeRisco", "dbo.tbTipoDeRisco", "IDTipoDeRisco");
            AddForeignKey("dbo.Rel_AtivEstabTipoRisco", "AtividadesDoEstabelecimento_IDAtividadesDoEstabelecimento", "dbo.tbAtividadesDoEstabelecimento", "IDAtividadesDoEstabelecimento");
        }
    }
}
