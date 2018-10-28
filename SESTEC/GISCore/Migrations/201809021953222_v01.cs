namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v01 : DbMigration
    {
        public override void Up()
        {
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
                "dbo.tbEstabelecimento",
                c => new
                    {
                        IDEstabelecimento = c.String(nullable: false, maxLength: 128),
                        TipoDeEstabelecimento = c.Int(nullable: false),
                        Codigo = c.String(),
                        Descricao = c.String(),
                        NomeCompleto = c.String(),
                        IDDepartamento = c.String(),
                        IDEmpresa = c.String(maxLength: 128),
                        UsuarioInclusao = c.String(),
                        DataInclusao = c.DateTime(nullable: false),
                        UsuarioExclusao = c.String(),
                        DataExclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDEstabelecimento)
                .ForeignKey("dbo.tbEmpresa", t => t.IDEmpresa)
                .Index(t => t.IDEmpresa);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbEstabelecimento", "IDEmpresa", "dbo.tbEmpresa");
            DropForeignKey("dbo.tbContrato", "IdEmpresa", "dbo.tbEmpresa");
            DropForeignKey("dbo.tbEmpresa", "idCNAE", "dbo.tbCNAE");
            DropIndex("dbo.tbEstabelecimento", new[] { "IDEmpresa" });
            DropIndex("dbo.tbEmpresa", new[] { "idCNAE" });
            DropIndex("dbo.tbContrato", new[] { "IdEmpresa" });
            DropTable("dbo.tbEstabelecimento");
            DropTable("dbo.tbCNAE");
            DropTable("dbo.tbEmpresa");
            DropTable("dbo.tbContrato");
        }
    }
}
