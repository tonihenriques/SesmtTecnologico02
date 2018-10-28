namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insereDepartamento : DbMigration
    {
        public override void Up()
        {
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
                        UsuarioInclusao = c.String(),
                        DataInclusao = c.DateTime(nullable: false),
                        UsuarioExclusao = c.String(),
                        DataExclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDDepartamento)
                .ForeignKey("dbo.tbEmpresa", t => t.IDEmpresa, cascadeDelete: true)
                .Index(t => t.IDEmpresa);
            
            AlterColumn("dbo.tbEstabelecimento", "IDDepartamento", c => c.String(maxLength: 128));
            CreateIndex("dbo.tbEstabelecimento", "IDDepartamento");
            AddForeignKey("dbo.tbEstabelecimento", "IDDepartamento", "dbo.tbDepartamento", "IDDepartamento");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbEstabelecimento", "IDDepartamento", "dbo.tbDepartamento");
            DropForeignKey("dbo.tbDepartamento", "IDEmpresa", "dbo.tbEmpresa");
            DropIndex("dbo.tbDepartamento", new[] { "IDEmpresa" });
            DropIndex("dbo.tbEstabelecimento", new[] { "IDDepartamento" });
            AlterColumn("dbo.tbEstabelecimento", "IDDepartamento", c => c.String());
            DropTable("dbo.tbDepartamento");
        }
    }
}
