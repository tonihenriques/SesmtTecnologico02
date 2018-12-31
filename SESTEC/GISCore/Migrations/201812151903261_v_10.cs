namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbTipoDeRisco", "EClasseDoRisco", c => c.Int(nullable: false));
            AddColumn("dbo.tbTipoDeRisco", "FonteGeradora", c => c.String());
            AddColumn("dbo.tbTipoDeRisco", "Tragetoria", c => c.String());
            DropColumn("dbo.tbAtividadesDoEstabelecimento", "EClasseDoRisco");
            DropColumn("dbo.tbAtividadesDoEstabelecimento", "FonteGeradora");
            DropColumn("dbo.tbAtividadesDoEstabelecimento", "Tragetoria");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbAtividadesDoEstabelecimento", "Tragetoria", c => c.String());
            AddColumn("dbo.tbAtividadesDoEstabelecimento", "FonteGeradora", c => c.String());
            AddColumn("dbo.tbAtividadesDoEstabelecimento", "EClasseDoRisco", c => c.Int(nullable: false));
            DropColumn("dbo.tbTipoDeRisco", "Tragetoria");
            DropColumn("dbo.tbTipoDeRisco", "FonteGeradora");
            DropColumn("dbo.tbTipoDeRisco", "EClasseDoRisco");
        }
    }
}
