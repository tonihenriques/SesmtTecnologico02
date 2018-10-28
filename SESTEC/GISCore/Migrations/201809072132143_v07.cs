namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v07 : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbAdmissao", "IDEmpresa", "dbo.tbEmpresa");
            DropForeignKey("dbo.tbAdmissao", "IDEmpregado", "dbo.tbEmpregado");
            DropIndex("dbo.tbAdmissao", new[] { "IDEmpresa" });
            DropIndex("dbo.tbAdmissao", new[] { "IDEmpregado" });
            DropTable("dbo.tbAdmissao");
        }
    }
}
