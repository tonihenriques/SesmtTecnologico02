namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbFuncao",
                c => new
                    {
                        IDFuncao = c.String(nullable: false, maxLength: 128),
                        NomeDaFuncao = c.String(),
                        IdCargo = c.String(maxLength: 128),
                        UsuarioInclusao = c.String(),
                        DataInclusao = c.DateTime(nullable: false),
                        UsuarioExclusao = c.String(),
                        DataExclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDFuncao)
                .ForeignKey("dbo.tbCargo", t => t.IdCargo)
                .Index(t => t.IdCargo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbFuncao", "IdCargo", "dbo.tbCargo");
            DropIndex("dbo.tbFuncao", new[] { "IdCargo" });
            DropTable("dbo.tbFuncao");
        }
    }
}
