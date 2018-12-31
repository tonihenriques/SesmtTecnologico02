namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MedidasDeControleExistentes", "IDAtividadesDoEstabelecimento", "dbo.tbAtividadesDoEstabelecimento");
            DropIndex("dbo.MedidasDeControleExistentes", new[] { "IDAtividadesDoEstabelecimento" });
            AddColumn("dbo.MedidasDeControleExistentes", "IDTipoDeRisco", c => c.String(maxLength: 128));
            CreateIndex("dbo.MedidasDeControleExistentes", "IDTipoDeRisco");
            AddForeignKey("dbo.MedidasDeControleExistentes", "IDTipoDeRisco", "dbo.tbTipoDeRisco", "IDTipoDeRisco");
            DropColumn("dbo.MedidasDeControleExistentes", "IDAtividadesDoEstabelecimento");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MedidasDeControleExistentes", "IDAtividadesDoEstabelecimento", c => c.String(maxLength: 128));
            DropForeignKey("dbo.MedidasDeControleExistentes", "IDTipoDeRisco", "dbo.tbTipoDeRisco");
            DropIndex("dbo.MedidasDeControleExistentes", new[] { "IDTipoDeRisco" });
            DropColumn("dbo.MedidasDeControleExistentes", "IDTipoDeRisco");
            CreateIndex("dbo.MedidasDeControleExistentes", "IDAtividadesDoEstabelecimento");
            AddForeignKey("dbo.MedidasDeControleExistentes", "IDAtividadesDoEstabelecimento", "dbo.tbAtividadesDoEstabelecimento", "IDAtividadesDoEstabelecimento");
        }
    }
}
