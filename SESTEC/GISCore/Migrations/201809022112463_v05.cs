namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v05 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbAtividadesDoEstabelecimento",
                c => new
                    {
                        IDAtividadesDoEstabelecimento = c.String(nullable: false, maxLength: 128),
                        Ativo = c.String(),
                        EClasseDoRisco = c.Int(nullable: false),
                        DescricaoDestaAtividade = c.String(),
                        FonteGeradora = c.String(),
                        NomeDaImagem = c.String(),
                        Imagem = c.String(),
                        IDEstabelecimentoImagens = c.String(maxLength: 128),
                        IDEstabelecimento = c.String(maxLength: 128),
                        IDTipoDeRisco = c.String(maxLength: 128),
                        IDPossiveisDanos = c.String(maxLength: 128),
                        IDEventoPerigoso = c.String(maxLength: 128),
                        IDAlocacao = c.String(),
                        Tragetoria = c.String(),
                        UsuarioInclusao = c.String(),
                        DataInclusao = c.DateTime(nullable: false),
                        UsuarioExclusao = c.String(),
                        DataExclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDAtividadesDoEstabelecimento)
                .ForeignKey("dbo.tbEstabelecimento", t => t.IDEstabelecimento)
                .ForeignKey("dbo.tbEstabelecimentoAmbiente", t => t.IDEstabelecimentoImagens)
                .ForeignKey("dbo.tbEventoPerigoso", t => t.IDEventoPerigoso)
                .ForeignKey("dbo.tbPossiveisDanos", t => t.IDPossiveisDanos)
                .ForeignKey("dbo.tbTipoDeRisco", t => t.IDTipoDeRisco)
                .Index(t => t.IDEstabelecimentoImagens)
                .Index(t => t.IDEstabelecimento)
                .Index(t => t.IDTipoDeRisco)
                .Index(t => t.IDPossiveisDanos)
                .Index(t => t.IDEventoPerigoso);
            
            CreateTable(
                "dbo.tbEstabelecimentoAmbiente",
                c => new
                    {
                        IDEstabelecimentoImagens = c.String(nullable: false, maxLength: 128),
                        ResumoDoLocal = c.String(),
                        NomeDaImagem = c.String(),
                        Imagem = c.String(),
                        IDEstabelecimento = c.String(maxLength: 128),
                        UsuarioInclusao = c.String(),
                        DataInclusao = c.DateTime(nullable: false),
                        UsuarioExclusao = c.String(),
                        DataExclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDEstabelecimentoImagens)
                .ForeignKey("dbo.tbEstabelecimento", t => t.IDEstabelecimento)
                .Index(t => t.IDEstabelecimento);
            
            CreateTable(
                "dbo.tbEventoPerigoso",
                c => new
                    {
                        IDEventoPerigoso = c.String(nullable: false, maxLength: 128),
                        Descricao = c.String(),
                        UsuarioInclusao = c.String(),
                        DataInclusao = c.DateTime(nullable: false),
                        UsuarioExclusao = c.String(),
                        DataExclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDEventoPerigoso);
            
            CreateTable(
                "dbo.tbPossiveisDanos",
                c => new
                    {
                        IDPossiveisDanos = c.String(nullable: false, maxLength: 128),
                        DescricaoDanos = c.String(),
                        UsuarioInclusao = c.String(),
                        DataInclusao = c.DateTime(nullable: false),
                        UsuarioExclusao = c.String(),
                        DataExclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDPossiveisDanos);
            
            CreateTable(
                "dbo.tbTipoDeRisco",
                c => new
                    {
                        IDTipoDeRisco = c.String(nullable: false, maxLength: 128),
                        DescricaoDoRisco = c.String(),
                        idPossiveisDanos = c.String(maxLength: 128),
                        idEventoPerigoso = c.String(maxLength: 128),
                        Vinculado = c.Boolean(nullable: false),
                        UsuarioInclusao = c.String(),
                        DataInclusao = c.DateTime(nullable: false),
                        UsuarioExclusao = c.String(),
                        DataExclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDTipoDeRisco)
                .ForeignKey("dbo.tbEventoPerigoso", t => t.idEventoPerigoso)
                .ForeignKey("dbo.tbPossiveisDanos", t => t.idPossiveisDanos)
                .Index(t => t.idPossiveisDanos)
                .Index(t => t.idEventoPerigoso);
            
            CreateTable(
                "dbo.MedidasDeControleExistentes",
                c => new
                    {
                        IDMedidasDeControle = c.String(nullable: false, maxLength: 128),
                        MedidasExistentes = c.String(),
                        EClassificacaoDaMedida = c.Int(nullable: false),
                        NomeDaImagem = c.String(),
                        Imagem = c.String(),
                        EControle = c.Int(nullable: false),
                        IDAtividadesDoEstabelecimento = c.String(maxLength: 128),
                        UsuarioInclusao = c.String(),
                        DataInclusao = c.DateTime(nullable: false),
                        UsuarioExclusao = c.String(),
                        DataExclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDMedidasDeControle)
                .ForeignKey("dbo.tbAtividadesDoEstabelecimento", t => t.IDAtividadesDoEstabelecimento)
                .Index(t => t.IDAtividadesDoEstabelecimento);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedidasDeControleExistentes", "IDAtividadesDoEstabelecimento", "dbo.tbAtividadesDoEstabelecimento");
            DropForeignKey("dbo.tbTipoDeRisco", "idPossiveisDanos", "dbo.tbPossiveisDanos");
            DropForeignKey("dbo.tbTipoDeRisco", "idEventoPerigoso", "dbo.tbEventoPerigoso");
            DropForeignKey("dbo.tbAtividadesDoEstabelecimento", "IDTipoDeRisco", "dbo.tbTipoDeRisco");
            DropForeignKey("dbo.tbAtividadesDoEstabelecimento", "IDPossiveisDanos", "dbo.tbPossiveisDanos");
            DropForeignKey("dbo.tbAtividadesDoEstabelecimento", "IDEventoPerigoso", "dbo.tbEventoPerigoso");
            DropForeignKey("dbo.tbAtividadesDoEstabelecimento", "IDEstabelecimentoImagens", "dbo.tbEstabelecimentoAmbiente");
            DropForeignKey("dbo.tbEstabelecimentoAmbiente", "IDEstabelecimento", "dbo.tbEstabelecimento");
            DropForeignKey("dbo.tbAtividadesDoEstabelecimento", "IDEstabelecimento", "dbo.tbEstabelecimento");
            DropIndex("dbo.MedidasDeControleExistentes", new[] { "IDAtividadesDoEstabelecimento" });
            DropIndex("dbo.tbTipoDeRisco", new[] { "idEventoPerigoso" });
            DropIndex("dbo.tbTipoDeRisco", new[] { "idPossiveisDanos" });
            DropIndex("dbo.tbEstabelecimentoAmbiente", new[] { "IDEstabelecimento" });
            DropIndex("dbo.tbAtividadesDoEstabelecimento", new[] { "IDEventoPerigoso" });
            DropIndex("dbo.tbAtividadesDoEstabelecimento", new[] { "IDPossiveisDanos" });
            DropIndex("dbo.tbAtividadesDoEstabelecimento", new[] { "IDTipoDeRisco" });
            DropIndex("dbo.tbAtividadesDoEstabelecimento", new[] { "IDEstabelecimento" });
            DropIndex("dbo.tbAtividadesDoEstabelecimento", new[] { "IDEstabelecimentoImagens" });
            DropTable("dbo.MedidasDeControleExistentes");
            DropTable("dbo.tbTipoDeRisco");
            DropTable("dbo.tbPossiveisDanos");
            DropTable("dbo.tbEventoPerigoso");
            DropTable("dbo.tbEstabelecimentoAmbiente");
            DropTable("dbo.tbAtividadesDoEstabelecimento");
        }
    }
}
