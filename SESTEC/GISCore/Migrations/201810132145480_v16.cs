namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v16 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbPlanoDeAcao",
                c => new
                    {
                        IDPlanoDeAcao = c.String(nullable: false, maxLength: 128),
                        TipoDoPlanoDeAcao = c.String(),
                        DescricaoDoPlanoDeAcao = c.String(),
                        Responsavel = c.String(),
                        DataEntrega = c.String(),
                        Entregue = c.String(),
                        ResponsavelPelaEntrega = c.String(),
                        NomeDaImagem = c.String(),
                        Imagem = c.String(),
                        idAtividadesDoEstablelecimento = c.String(),
                        UsuarioInclusao = c.String(),
                        DataInclusao = c.DateTime(nullable: false),
                        UsuarioExclusao = c.String(),
                        DataExclusao = c.DateTime(nullable: false),
                        AtividadesDoEstablelecimento_IDAtividadesDoEstabelecimento = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IDPlanoDeAcao)
                .ForeignKey("dbo.tbAtividadesDoEstabelecimento", t => t.AtividadesDoEstablelecimento_IDAtividadesDoEstabelecimento)
                .Index(t => t.AtividadesDoEstablelecimento_IDAtividadesDoEstabelecimento);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbPlanoDeAcao", "AtividadesDoEstablelecimento_IDAtividadesDoEstabelecimento", "dbo.tbAtividadesDoEstabelecimento");
            DropIndex("dbo.tbPlanoDeAcao", new[] { "AtividadesDoEstablelecimento_IDAtividadesDoEstabelecimento" });
            DropTable("dbo.tbPlanoDeAcao");
        }
    }
}
