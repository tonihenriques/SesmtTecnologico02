namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v15 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbAtividadeAlocada",
                c => new
                    {
                        IDAtividadeAlocada = c.String(nullable: false, maxLength: 128),
                        idAtividadesDoEstabelecimento = c.String(maxLength: 128),
                        idAlocacao = c.String(maxLength: 128),
                        UsuarioInclusao = c.String(),
                        DataInclusao = c.DateTime(nullable: false),
                        UsuarioExclusao = c.String(),
                        DataExclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDAtividadeAlocada)
                .ForeignKey("dbo.tbAlocacao", t => t.idAlocacao)
                .ForeignKey("dbo.tbAtividadesDoEstabelecimento", t => t.idAtividadesDoEstabelecimento)
                .Index(t => t.idAtividadesDoEstabelecimento)
                .Index(t => t.idAlocacao);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbAtividadeAlocada", "idAtividadesDoEstabelecimento", "dbo.tbAtividadesDoEstabelecimento");
            DropForeignKey("dbo.tbAtividadeAlocada", "idAlocacao", "dbo.tbAlocacao");
            DropIndex("dbo.tbAtividadeAlocada", new[] { "idAlocacao" });
            DropIndex("dbo.tbAtividadeAlocada", new[] { "idAtividadesDoEstabelecimento" });
            DropTable("dbo.tbAtividadeAlocada");
        }
    }
}
