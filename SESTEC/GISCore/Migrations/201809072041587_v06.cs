namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v06 : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbEmpregado");
        }
    }
}
