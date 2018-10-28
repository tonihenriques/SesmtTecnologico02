namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v09 : DbMigration
    {
        public override void Up()
        {
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
                .ForeignKey("dbo.tbEmpresa", t => t.IDEmpresa, cascadeDelete: true)
                .Index(t => t.IDEmpresa);
            
            AddColumn("dbo.tbCargo", "IDDiretoria", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.tbCargo", "IDDiretoria");
            AddForeignKey("dbo.tbCargo", "IDDiretoria", "dbo.tbDiretoria", "IDDiretoria", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbCargo", "IDDiretoria", "dbo.tbDiretoria");
            DropForeignKey("dbo.tbDiretoria", "IDEmpresa", "dbo.tbEmpresa");
            DropIndex("dbo.tbDiretoria", new[] { "IDEmpresa" });
            DropIndex("dbo.tbCargo", new[] { "IDDiretoria" });
            DropColumn("dbo.tbCargo", "IDDiretoria");
            DropTable("dbo.tbDiretoria");
        }
    }
}
