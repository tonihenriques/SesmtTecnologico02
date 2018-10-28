namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbDepartamento", "IDDiretoria", c => c.String(maxLength: 128));
            CreateIndex("dbo.tbDepartamento", "IDDiretoria");
            AddForeignKey("dbo.tbDepartamento", "IDDiretoria", "dbo.tbDiretoria", "IDDiretoria");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbDepartamento", "IDDiretoria", "dbo.tbDiretoria");
            DropIndex("dbo.tbDepartamento", new[] { "IDDiretoria" });
            DropColumn("dbo.tbDepartamento", "IDDiretoria");
        }
    }
}
