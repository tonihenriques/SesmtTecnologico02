namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v14 : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbAlocacao", "IDFuncao", "dbo.tbFuncao");
            DropForeignKey("dbo.tbAlocacao", "idEstabelecimento", "dbo.tbEstabelecimento");
            DropForeignKey("dbo.tbAlocacao", "IDEquipe", "dbo.tbEquipe");
            DropForeignKey("dbo.tbAlocacao", "IDDepartamento", "dbo.tbDepartamento");
            DropForeignKey("dbo.tbAlocacao", "IdContrato", "dbo.tbContrato");
            DropForeignKey("dbo.tbAlocacao", "IDCargo", "dbo.tbCargo");
            DropForeignKey("dbo.tbAlocacao", "IdAdmissao", "dbo.tbAdmissao");
            DropIndex("dbo.tbAlocacao", new[] { "IDEquipe" });
            DropIndex("dbo.tbAlocacao", new[] { "idEstabelecimento" });
            DropIndex("dbo.tbAlocacao", new[] { "IDFuncao" });
            DropIndex("dbo.tbAlocacao", new[] { "IDCargo" });
            DropIndex("dbo.tbAlocacao", new[] { "IDDepartamento" });
            DropIndex("dbo.tbAlocacao", new[] { "IdContrato" });
            DropIndex("dbo.tbAlocacao", new[] { "IdAdmissao" });
            DropTable("dbo.tbEquipe");
            DropTable("dbo.tbAlocacao");
        }
    }
}
