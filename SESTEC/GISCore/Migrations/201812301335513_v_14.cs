namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_14 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rel_AtivEstabTipoRisco",
                c => new
                    {
                        IDAtivEstabTipoRisco = c.String(nullable: false, maxLength: 128),
                        idAtividadeEstabelecimento = c.String(),
                        idTipoDeRisco = c.String(maxLength: 128),
                        UsuarioInclusao = c.String(),
                        DataInclusao = c.DateTime(nullable: false),
                        UsuarioExclusao = c.String(),
                        DataExclusao = c.DateTime(nullable: false),
                        AtividadesDoEstabelecimento_IDAtividadesDoEstabelecimento = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IDAtivEstabTipoRisco)
                .ForeignKey("dbo.tbAtividadesDoEstabelecimento", t => t.AtividadesDoEstabelecimento_IDAtividadesDoEstabelecimento)
                .ForeignKey("dbo.tbTipoDeRisco", t => t.idTipoDeRisco)
                .Index(t => t.idTipoDeRisco)
                .Index(t => t.AtividadesDoEstabelecimento_IDAtividadesDoEstabelecimento);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rel_AtivEstabTipoRisco", "idTipoDeRisco", "dbo.tbTipoDeRisco");
            DropForeignKey("dbo.Rel_AtivEstabTipoRisco", "AtividadesDoEstabelecimento_IDAtividadesDoEstabelecimento", "dbo.tbAtividadesDoEstabelecimento");
            DropIndex("dbo.Rel_AtivEstabTipoRisco", new[] { "AtividadesDoEstabelecimento_IDAtividadesDoEstabelecimento" });
            DropIndex("dbo.Rel_AtivEstabTipoRisco", new[] { "idTipoDeRisco" });
            DropTable("dbo.Rel_AtivEstabTipoRisco");
        }
    }
}
