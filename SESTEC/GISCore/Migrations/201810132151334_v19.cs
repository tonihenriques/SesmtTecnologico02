namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v19 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbPlanoDeAcao", "IDAtividadesDoEstablelecimento", c => c.String());
            AddColumn("dbo.tbPlanoDeAcao", "AtividadesDoEstablelecimento_IDAtividadesDoEstabelecimento", c => c.String(maxLength: 128));
            CreateIndex("dbo.tbPlanoDeAcao", "AtividadesDoEstablelecimento_IDAtividadesDoEstabelecimento");
            AddForeignKey("dbo.tbPlanoDeAcao", "AtividadesDoEstablelecimento_IDAtividadesDoEstabelecimento", "dbo.tbAtividadesDoEstabelecimento", "IDAtividadesDoEstabelecimento");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbPlanoDeAcao", "AtividadesDoEstablelecimento_IDAtividadesDoEstabelecimento", "dbo.tbAtividadesDoEstabelecimento");
            DropIndex("dbo.tbPlanoDeAcao", new[] { "AtividadesDoEstablelecimento_IDAtividadesDoEstabelecimento" });
            DropColumn("dbo.tbPlanoDeAcao", "AtividadesDoEstablelecimento_IDAtividadesDoEstabelecimento");
            DropColumn("dbo.tbPlanoDeAcao", "IDAtividadesDoEstablelecimento");
        }
    }
}
