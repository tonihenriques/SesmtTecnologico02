namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_03 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbEstabelecimento", "Empresa_IDEmpresa", "dbo.tbEmpresa");
            DropForeignKey("dbo.tbDepartamento", "IDDiretoria", "dbo.tbDiretoria");
            //DropIndex("dbo.tbEstabelecimento", new[] { "Empresa_IDEmpresa" });
            DropIndex("dbo.tbDepartamento", new[] { "IDDiretoria" });
            CreateTable(
                "dbo.tbEventoPerigosoPerigosoPotencial",
                c => new
                    {
                        IDEventoPerigosoPotencial = c.String(nullable: false, maxLength: 128),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.IDEventoPerigosoPotencial);
            
            AlterColumn("dbo.tbDepartamento", "IDEmpresa", c => c.String(maxLength: 128));
            AlterColumn("dbo.tbDepartamento", "IDDiretoria", c => c.String(maxLength: 128));
            CreateIndex("dbo.tbDepartamento", "IDEmpresa");
            CreateIndex("dbo.tbDepartamento", "IDDiretoria");
            AddForeignKey("dbo.tbDepartamento", "IDEmpresa", "dbo.tbEmpresa", "IDEmpresa");
            AddForeignKey("dbo.tbDepartamento", "IDDiretoria", "dbo.tbDiretoria", "IDDiretoria");
            //DropColumn("dbo.tbEstabelecimento", "Empresa_IDEmpresa");
            DropColumn("dbo.tbDepartamento", "DepartamentoVinculado");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbDepartamento", "DepartamentoVinculado", c => c.String());
            AddColumn("dbo.tbEstabelecimento", "Empresa_IDEmpresa", c => c.String(maxLength: 128));
            DropForeignKey("dbo.tbDepartamento", "IDDiretoria", "dbo.tbDiretoria");
            DropForeignKey("dbo.tbDepartamento", "IDEmpresa", "dbo.tbEmpresa");
            DropIndex("dbo.tbDepartamento", new[] { "IDDiretoria" });
            DropIndex("dbo.tbDepartamento", new[] { "IDEmpresa" });
            AlterColumn("dbo.tbDepartamento", "IDDiretoria", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.tbDepartamento", "IDEmpresa", c => c.String());
            DropTable("dbo.tbEventoPerigosoPerigosoPotencial");
            CreateIndex("dbo.tbDepartamento", "IDDiretoria");
            //CreateIndex("dbo.tbEstabelecimento", "Empresa_IDEmpresa");
            AddForeignKey("dbo.tbDepartamento", "IDDiretoria", "dbo.tbDiretoria", "IDDiretoria", cascadeDelete: true);
            AddForeignKey("dbo.tbEstabelecimento", "Empresa_IDEmpresa", "dbo.tbEmpresa", "IDEmpresa");
        }
    }
}
