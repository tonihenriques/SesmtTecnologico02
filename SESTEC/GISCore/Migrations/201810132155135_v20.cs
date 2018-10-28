namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v20 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbPlanoDeAcao", "AtividadesDoEstablelecimento_IDAtividadesDoEstabelecimento", "dbo.tbAtividadesDoEstabelecimento");
            DropIndex("dbo.tbPlanoDeAcao", new[] { "AtividadesDoEstablelecimento_IDAtividadesDoEstabelecimento" });
            DropColumn("dbo.tbPlanoDeAcao", "IDAtividadesDoEstablelecimento");
            DropColumn("dbo.tbPlanoDeAcao", "AtividadesDoEstablelecimento_IDAtividadesDoEstabelecimento");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbPlanoDeAcao", "AtividadesDoEstablelecimento_IDAtividadesDoEstabelecimento", c => c.String(maxLength: 128));
            AddColumn("dbo.tbPlanoDeAcao", "IDAtividadesDoEstablelecimento", c => c.String());
            CreateIndex("dbo.tbPlanoDeAcao", "AtividadesDoEstablelecimento_IDAtividadesDoEstabelecimento");
            AddForeignKey("dbo.tbPlanoDeAcao", "AtividadesDoEstablelecimento_IDAtividadesDoEstabelecimento", "dbo.tbAtividadesDoEstabelecimento", "IDAtividadesDoEstabelecimento");
        }
    }
}
