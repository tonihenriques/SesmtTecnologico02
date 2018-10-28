namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v13 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbDepartamento", "IDDiretoria", "dbo.tbDiretoria");
            DropIndex("dbo.tbDepartamento", new[] { "IDDiretoria" });
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
            
            AlterColumn("dbo.tbDepartamento", "IDDiretoria", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.tbDepartamento", "IDDiretoria");
            AddForeignKey("dbo.tbDepartamento", "IDDiretoria", "dbo.tbDiretoria", "IDDiretoria", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbDepartamento", "IDDiretoria", "dbo.tbDiretoria");
            DropForeignKey("dbo.tbAtividade", "idFuncao", "dbo.tbFuncao");
            DropForeignKey("dbo.tbAtividade", "idDiretoria", "dbo.tbDiretoria");
            DropIndex("dbo.tbAtividade", new[] { "idDiretoria" });
            DropIndex("dbo.tbAtividade", new[] { "idFuncao" });
            DropIndex("dbo.tbDepartamento", new[] { "IDDiretoria" });
            AlterColumn("dbo.tbDepartamento", "IDDiretoria", c => c.String(maxLength: 128));
            DropTable("dbo.tbAtividade");
            CreateIndex("dbo.tbDepartamento", "IDDiretoria");
            AddForeignKey("dbo.tbDepartamento", "IDDiretoria", "dbo.tbDiretoria", "IDDiretoria");
        }
    }
}
