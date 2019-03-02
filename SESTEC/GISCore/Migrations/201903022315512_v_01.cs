namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbAdmissao",
                c => new
                    {
                        IDAdmissao = c.String(nullable: false, maxLength: 128),
                        IDEmpregado = c.String(maxLength: 128),
                        IDEmpresa = c.String(maxLength: 128),
                        DataAdmissao = c.String(nullable: false),
                        DataDemissao = c.String(),
                        Imagem = c.String(),
                        Admitido = c.String(),
                        UsuarioInclusao = c.String(),
                        DataInclusao = c.DateTime(nullable: false),
                        UsuarioExclusao = c.String(),
                        DataExclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDAdmissao)
                .ForeignKey("dbo.tbEmpregado", t => t.IDEmpregado)
                .ForeignKey("dbo.tbEmpresa", t => t.IDEmpresa)
                .Index(t => t.IDEmpregado)
                .Index(t => t.IDEmpresa);
            
            CreateTable(
                "dbo.tbEmpregado",
                c => new
                    {
                        IDEmpregado = c.String(nullable: false, maxLength: 128),
                        CPF = c.String(nullable: false),
                        Nome = c.String(nullable: false),
                        DataNascimento = c.DateTime(nullable: false),
                        Email = c.String(nullable: false),
                        Endereco = c.String(),
                        Admitido = c.Boolean(nullable: false),
                        UsuarioInclusao = c.String(),
                        DataInclusao = c.DateTime(nullable: false),
                        UsuarioExclusao = c.String(),
                        DataExclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDEmpregado);
            
            CreateTable(
                "dbo.tbEmpresa",
                c => new
                    {
                        IDEmpresa = c.String(nullable: false, maxLength: 128),
                        CNPJ = c.String(nullable: false),
                        RazaoSocial = c.String(),
                        NomeFantasia = c.String(nullable: false),
                        URL_Site = c.String(),
                        URL_LogoMarca = c.String(nullable: false),
                        URL_WS = c.String(),
                        URL_AD = c.String(),
                        RamoDeAtividade = c.String(),
                        idCNAE = c.String(maxLength: 128),
                        GrauDeRisco = c.String(),
                        GrupoCIPA = c.String(),
                        Endereco = c.String(),
                        NumeroDeEmpregados = c.String(),
                        Masculino = c.String(),
                        Feminino = c.String(),
                        Menores = c.String(),
                        UsuarioInclusao = c.String(),
                        DataInclusao = c.DateTime(nullable: false),
                        UsuarioExclusao = c.String(),
                        DataExclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDEmpresa)
                .ForeignKey("dbo.tbCNAE", t => t.idCNAE)
                .Index(t => t.idCNAE);
            
            CreateTable(
                "dbo.tbCNAE",
                c => new
                    {
                        IDCNAE = c.String(nullable: false, maxLength: 128),
                        Codigo = c.String(),
                        DescricaoCNAE = c.String(),
                        Titulo = c.String(),
                        UsuarioInclusao = c.String(),
                        DataInclusao = c.DateTime(nullable: false),
                        UsuarioExclusao = c.String(),
                        DataExclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDCNAE);
            
            CreateTable(
                "dbo.tbContrato",
                c => new
                    {
                        IDContrato = c.String(nullable: false, maxLength: 128),
                        NumeroContrato = c.String(),
                        DescricaoContrato = c.String(),
                        DataInicio = c.String(),
                        DataFim = c.String(),
                        IdEmpresa = c.String(maxLength: 128),
                        UsuarioInclusao = c.String(),
                        DataInclusao = c.DateTime(nullable: false),
                        UsuarioExclusao = c.String(),
                        DataExclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDContrato)
                .ForeignKey("dbo.tbEmpresa", t => t.IdEmpresa)
                .Index(t => t.IdEmpresa);
            
            CreateTable(
                "dbo.tbEstabelecimento",
                c => new
                    {
                        IDEstabelecimento = c.String(nullable: false, maxLength: 128),
                        TipoDeEstabelecimento = c.Int(nullable: false),
                        Codigo = c.String(),
                        Descricao = c.String(),
                        NomeCompleto = c.String(),
                        IDDepartamento = c.String(maxLength: 128),
                        IDEmpresa = c.String(maxLength: 128),
                        UsuarioInclusao = c.String(),
                        DataInclusao = c.DateTime(nullable: false),
                        UsuarioExclusao = c.String(),
                        DataExclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDEstabelecimento)
                .ForeignKey("dbo.tbDepartamento", t => t.IDDepartamento)
                .ForeignKey("dbo.tbEmpresa", t => t.IDEmpresa)
                .Index(t => t.IDDepartamento)
                .Index(t => t.IDEmpresa);
            
            CreateTable(
                "dbo.tbDepartamento",
                c => new
                    {
                        IDDepartamento = c.String(nullable: false, maxLength: 128),
                        Codigo = c.String(nullable: false),
                        Sigla = c.String(nullable: false),
                        Descricao = c.String(),
                        Status = c.Int(nullable: false),
                        IDEmpresa = c.String(nullable: false, maxLength: 128),
                        DepartamentoVinculado = c.String(),
                        IDDiretoria = c.String(nullable: false, maxLength: 128),
                        UsuarioInclusao = c.String(),
                        DataInclusao = c.DateTime(nullable: false),
                        UsuarioExclusao = c.String(),
                        DataExclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDDepartamento)
                .ForeignKey("dbo.tbDiretoria", t => t.IDDiretoria, cascadeDelete: true)
                .ForeignKey("dbo.tbEmpresa", t => t.IDEmpresa, cascadeDelete: true)
                .Index(t => t.IDEmpresa)
                .Index(t => t.IDDiretoria);
            
            CreateTable(
                "dbo.tbDiretoria",
                c => new
                    {
                        IDDiretoria = c.String(nullable: false, maxLength: 128),
                        Codigo = c.String(nullable: false),
                        Sigla = c.String(nullable: false),
                        Descricao = c.String(),
                        Status = c.Int(nullable: false),
                        IDEmpresa = c.String(nullable: false, maxLength: 128),
                        UsuarioInclusao = c.String(),
                        DataInclusao = c.DateTime(nullable: false),
                        UsuarioExclusao = c.String(),
                        DataExclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDDiretoria)
                .ForeignKey("dbo.tbEmpresa", t => t.IDEmpresa, cascadeDelete: false)
                .Index(t => t.IDEmpresa);
            
            CreateTable(
                "dbo.tbAlocacao",
                c => new
                    {
                        IDAlocacao = c.String(nullable: false, maxLength: 128),
                        IdAdmissao = c.String(maxLength: 128),
                        Ativado = c.String(),
                        IdContrato = c.String(maxLength: 128),
                        IDDepartamento = c.String(maxLength: 128),
                        IDCargo = c.String(maxLength: 128),
                        IDFuncao = c.String(maxLength: 128),
                        idEstabelecimento = c.String(maxLength: 128),
                        IDEquipe = c.String(maxLength: 128),
                        UsuarioInclusao = c.String(),
                        DataInclusao = c.DateTime(nullable: false),
                        UsuarioExclusao = c.String(),
                        DataExclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDAlocacao)
                .ForeignKey("dbo.tbAdmissao", t => t.IdAdmissao)
                .ForeignKey("dbo.tbCargo", t => t.IDCargo)
                .ForeignKey("dbo.tbContrato", t => t.IdContrato)
                .ForeignKey("dbo.tbDepartamento", t => t.IDDepartamento)
                .ForeignKey("dbo.tbEquipe", t => t.IDEquipe)
                .ForeignKey("dbo.tbEstabelecimento", t => t.idEstabelecimento)
                .ForeignKey("dbo.tbFuncao", t => t.IDFuncao)
                .Index(t => t.IdAdmissao)
                .Index(t => t.IdContrato)
                .Index(t => t.IDDepartamento)
                .Index(t => t.IDCargo)
                .Index(t => t.IDFuncao)
                .Index(t => t.idEstabelecimento)
                .Index(t => t.IDEquipe);
            
            CreateTable(
                "dbo.tbCargo",
                c => new
                    {
                        IDCargo = c.String(nullable: false, maxLength: 128),
                        NomeDoCargo = c.String(),
                        IDDiretoria = c.String(nullable: false, maxLength: 128),
                        UsuarioInclusao = c.String(),
                        DataInclusao = c.DateTime(nullable: false),
                        UsuarioExclusao = c.String(),
                        DataExclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDCargo)
                .ForeignKey("dbo.tbDiretoria", t => t.IDDiretoria, cascadeDelete: true)
                .Index(t => t.IDDiretoria);
            
            CreateTable(
                "dbo.tbEquipe",
                c => new
                    {
                        IDEquipe = c.String(nullable: false, maxLength: 128),
                        NomeDaEquipe = c.String(),
                        ResumoAtividade = c.String(),
                        UsuarioInclusao = c.String(),
                        DataInclusao = c.DateTime(nullable: false),
                        UsuarioExclusao = c.String(),
                        DataExclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDEquipe);
            
            CreateTable(
                "dbo.tbFuncao",
                c => new
                    {
                        IDFuncao = c.String(nullable: false, maxLength: 128),
                        NomeDaFuncao = c.String(),
                        IdCargo = c.String(maxLength: 128),
                        UsuarioInclusao = c.String(),
                        DataInclusao = c.DateTime(nullable: false),
                        UsuarioExclusao = c.String(),
                        DataExclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDFuncao)
                .ForeignKey("dbo.tbCargo", t => t.IdCargo)
                .Index(t => t.IdCargo);
            
            CreateTable(
                "dbo.tbAtividade",
                c => new
                    {
                        IDAtividade = c.String(nullable: false, maxLength: 128),
                        Descricao = c.String(),
                        idFuncao = c.String(maxLength: 128),
                        idDiretoria = c.String(maxLength: 128),
                        UsuarioInclusao = c.String(),
                        DataInclusao = c.DateTime(nullable: false),
                        UsuarioExclusao = c.String(),
                        DataExclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDAtividade)
                .ForeignKey("dbo.tbDiretoria", t => t.idDiretoria)
                .ForeignKey("dbo.tbFuncao", t => t.idFuncao)
                .Index(t => t.idFuncao)
                .Index(t => t.idDiretoria);
            
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
            
            CreateTable(
                "dbo.tbPlanoDeAcao",
                c => new
                    {
                        IDPlanoDeAcao = c.String(nullable: false, maxLength: 128),
                        TipoDoPlanoDeAcao = c.Int(nullable: false),
                        DescricaoDoPlanoDeAcao = c.String(nullable: false, maxLength: 200),
                        Responsavel = c.String(),
                        DataPrevista = c.DateTime(nullable: false),
                        Entregue = c.String(),
                        ResponsavelPelaEntrega = c.String(),
                        Identificador = c.String(),
                        Gerencia = c.String(),
                        UsuarioInclusao = c.String(),
                        DataInclusao = c.DateTime(nullable: false),
                        UsuarioExclusao = c.String(),
                        DataExclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDPlanoDeAcao);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedidasDeControleExistentes", "IDAtividadesDoEstabelecimento", "dbo.tbAtividadesDoEstabelecimento");
            DropForeignKey("dbo.tbAtividadeAlocada", "idAtividadesDoEstabelecimento", "dbo.tbAtividadesDoEstabelecimento");
            DropForeignKey("dbo.tbTipoDeRisco", "idPossiveisDanos", "dbo.tbPossiveisDanos");
            DropForeignKey("dbo.tbTipoDeRisco", "idEventoPerigoso", "dbo.tbEventoPerigoso");
            DropForeignKey("dbo.tbAtividadesDoEstabelecimento", "IDTipoDeRisco", "dbo.tbTipoDeRisco");
            DropForeignKey("dbo.tbAtividadesDoEstabelecimento", "IDPossiveisDanos", "dbo.tbPossiveisDanos");
            DropForeignKey("dbo.tbAtividadesDoEstabelecimento", "IDEventoPerigoso", "dbo.tbEventoPerigoso");
            DropForeignKey("dbo.tbAtividadesDoEstabelecimento", "IDEstabelecimentoImagens", "dbo.tbEstabelecimentoAmbiente");
            DropForeignKey("dbo.tbEstabelecimentoAmbiente", "IDEstabelecimento", "dbo.tbEstabelecimento");
            DropForeignKey("dbo.tbAtividadesDoEstabelecimento", "IDEstabelecimento", "dbo.tbEstabelecimento");
            DropForeignKey("dbo.tbAtividadeAlocada", "idAlocacao", "dbo.tbAlocacao");
            DropForeignKey("dbo.tbAtividade", "idFuncao", "dbo.tbFuncao");
            DropForeignKey("dbo.tbAtividade", "idDiretoria", "dbo.tbDiretoria");
            DropForeignKey("dbo.tbAlocacao", "IDFuncao", "dbo.tbFuncao");
            DropForeignKey("dbo.tbFuncao", "IdCargo", "dbo.tbCargo");
            DropForeignKey("dbo.tbAlocacao", "idEstabelecimento", "dbo.tbEstabelecimento");
            DropForeignKey("dbo.tbAlocacao", "IDEquipe", "dbo.tbEquipe");
            DropForeignKey("dbo.tbAlocacao", "IDDepartamento", "dbo.tbDepartamento");
            DropForeignKey("dbo.tbAlocacao", "IdContrato", "dbo.tbContrato");
            DropForeignKey("dbo.tbAlocacao", "IDCargo", "dbo.tbCargo");
            DropForeignKey("dbo.tbCargo", "IDDiretoria", "dbo.tbDiretoria");
            DropForeignKey("dbo.tbAlocacao", "IdAdmissao", "dbo.tbAdmissao");
            DropForeignKey("dbo.tbAdmissao", "IDEmpresa", "dbo.tbEmpresa");
            DropForeignKey("dbo.tbEstabelecimento", "IDEmpresa", "dbo.tbEmpresa");
            DropForeignKey("dbo.tbEstabelecimento", "IDDepartamento", "dbo.tbDepartamento");
            DropForeignKey("dbo.tbDepartamento", "IDEmpresa", "dbo.tbEmpresa");
            DropForeignKey("dbo.tbDepartamento", "IDDiretoria", "dbo.tbDiretoria");
            DropForeignKey("dbo.tbDiretoria", "IDEmpresa", "dbo.tbEmpresa");
            DropForeignKey("dbo.tbContrato", "IdEmpresa", "dbo.tbEmpresa");
            DropForeignKey("dbo.tbEmpresa", "idCNAE", "dbo.tbCNAE");
            DropForeignKey("dbo.tbAdmissao", "IDEmpregado", "dbo.tbEmpregado");
            DropIndex("dbo.MedidasDeControleExistentes", new[] { "IDAtividadesDoEstabelecimento" });
            DropIndex("dbo.tbTipoDeRisco", new[] { "idEventoPerigoso" });
            DropIndex("dbo.tbTipoDeRisco", new[] { "idPossiveisDanos" });
            DropIndex("dbo.tbEstabelecimentoAmbiente", new[] { "IDEstabelecimento" });
            DropIndex("dbo.tbAtividadesDoEstabelecimento", new[] { "IDEventoPerigoso" });
            DropIndex("dbo.tbAtividadesDoEstabelecimento", new[] { "IDPossiveisDanos" });
            DropIndex("dbo.tbAtividadesDoEstabelecimento", new[] { "IDTipoDeRisco" });
            DropIndex("dbo.tbAtividadesDoEstabelecimento", new[] { "IDEstabelecimento" });
            DropIndex("dbo.tbAtividadesDoEstabelecimento", new[] { "IDEstabelecimentoImagens" });
            DropIndex("dbo.tbAtividadeAlocada", new[] { "idAlocacao" });
            DropIndex("dbo.tbAtividadeAlocada", new[] { "idAtividadesDoEstabelecimento" });
            DropIndex("dbo.tbAtividade", new[] { "idDiretoria" });
            DropIndex("dbo.tbAtividade", new[] { "idFuncao" });
            DropIndex("dbo.tbFuncao", new[] { "IdCargo" });
            DropIndex("dbo.tbCargo", new[] { "IDDiretoria" });
            DropIndex("dbo.tbAlocacao", new[] { "IDEquipe" });
            DropIndex("dbo.tbAlocacao", new[] { "idEstabelecimento" });
            DropIndex("dbo.tbAlocacao", new[] { "IDFuncao" });
            DropIndex("dbo.tbAlocacao", new[] { "IDCargo" });
            DropIndex("dbo.tbAlocacao", new[] { "IDDepartamento" });
            DropIndex("dbo.tbAlocacao", new[] { "IdContrato" });
            DropIndex("dbo.tbAlocacao", new[] { "IdAdmissao" });
            DropIndex("dbo.tbDiretoria", new[] { "IDEmpresa" });
            DropIndex("dbo.tbDepartamento", new[] { "IDDiretoria" });
            DropIndex("dbo.tbDepartamento", new[] { "IDEmpresa" });
            DropIndex("dbo.tbEstabelecimento", new[] { "IDEmpresa" });
            DropIndex("dbo.tbEstabelecimento", new[] { "IDDepartamento" });
            DropIndex("dbo.tbContrato", new[] { "IdEmpresa" });
            DropIndex("dbo.tbEmpresa", new[] { "idCNAE" });
            DropIndex("dbo.tbAdmissao", new[] { "IDEmpresa" });
            DropIndex("dbo.tbAdmissao", new[] { "IDEmpregado" });
            DropTable("dbo.tbPlanoDeAcao");
            DropTable("dbo.MedidasDeControleExistentes");
            DropTable("dbo.tbTipoDeRisco");
            DropTable("dbo.tbPossiveisDanos");
            DropTable("dbo.tbEventoPerigoso");
            DropTable("dbo.tbEstabelecimentoAmbiente");
            DropTable("dbo.tbAtividadesDoEstabelecimento");
            DropTable("dbo.tbAtividadeAlocada");
            DropTable("dbo.tbAtividade");
            DropTable("dbo.tbFuncao");
            DropTable("dbo.tbEquipe");
            DropTable("dbo.tbCargo");
            DropTable("dbo.tbAlocacao");
            DropTable("dbo.tbDiretoria");
            DropTable("dbo.tbDepartamento");
            DropTable("dbo.tbEstabelecimento");
            DropTable("dbo.tbContrato");
            DropTable("dbo.tbCNAE");
            DropTable("dbo.tbEmpresa");
            DropTable("dbo.tbEmpregado");
            DropTable("dbo.tbAdmissao");
        }
    }
}
