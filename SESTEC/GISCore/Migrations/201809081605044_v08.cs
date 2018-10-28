namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v08 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbCargo",
                c => new
                    {
                        IDCargo = c.String(nullable: false, maxLength: 128),
                        NomeDoCargo = c.String(),
                        UsuarioInclusao = c.String(),
                        DataInclusao = c.DateTime(nullable: false),
                        UsuarioExclusao = c.String(),
                        DataExclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDCargo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbCargo");
        }
    }
}
