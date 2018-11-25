namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v02 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbEstabelecimento", "Empresa_IDEmpresa", "dbo.tbEmpresa");
            DropForeignKey("dbo.tbDepartamento", "IDDiretoria", "dbo.tbDiretoria");
            DropIndex("dbo.tbEstabelecimento", new[] { "Empresa_IDEmpresa" });
            DropIndex("dbo.tbDepartamento", new[] { "IDDiretoria" });
            AlterColumn("dbo.tbDepartamento", "IDDiretoria", c => c.String(maxLength: 128));
            CreateIndex("dbo.tbDepartamento", "IDDiretoria");
            AddForeignKey("dbo.tbDepartamento", "IDDiretoria", "dbo.tbDiretoria", "IDDiretoria");
            DropColumn("dbo.tbEstabelecimento", "Empresa_IDEmpresa");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbEstabelecimento", "Empresa_IDEmpresa", c => c.String(maxLength: 128));
            DropForeignKey("dbo.tbDepartamento", "IDDiretoria", "dbo.tbDiretoria");
            DropIndex("dbo.tbDepartamento", new[] { "IDDiretoria" });
            AlterColumn("dbo.tbDepartamento", "IDDiretoria", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.tbDepartamento", "IDDiretoria");
            CreateIndex("dbo.tbEstabelecimento", "Empresa_IDEmpresa");
            AddForeignKey("dbo.tbDepartamento", "IDDiretoria", "dbo.tbDiretoria", "IDDiretoria", cascadeDelete: true);
            AddForeignKey("dbo.tbEstabelecimento", "Empresa_IDEmpresa", "dbo.tbEmpresa", "IDEmpresa");
        }
    }
}
