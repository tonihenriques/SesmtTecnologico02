namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v30 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbPlanoDeAcao", "Gerencia", c => c.String());
            AlterColumn("dbo.tbPlanoDeAcao", "TipoDoPlanoDeAcao", c => c.Int(nullable: false));
            AlterColumn("dbo.tbPlanoDeAcao", "DescricaoDoPlanoDeAcao", c => c.String(nullable: false, maxLength: 200));
            DropColumn("dbo.tbPlanoDeAcao", "NomeDaImagem");
            DropColumn("dbo.tbPlanoDeAcao", "Imagem");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbPlanoDeAcao", "Imagem", c => c.String());
            AddColumn("dbo.tbPlanoDeAcao", "NomeDaImagem", c => c.String());
            AlterColumn("dbo.tbPlanoDeAcao", "DescricaoDoPlanoDeAcao", c => c.String());
            AlterColumn("dbo.tbPlanoDeAcao", "TipoDoPlanoDeAcao", c => c.String());
            DropColumn("dbo.tbPlanoDeAcao", "Gerencia");
        }
    }
}
