namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_07 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbTipoDeRisco", "PerigoPotencial_IDPerigosoPotencial", "dbo.tbPerigoPotencial");
            DropIndex("dbo.tbTipoDeRisco", new[] { "PerigoPotencial_IDPerigosoPotencial" });
            DropColumn("dbo.tbTipoDeRisco", "idPerigoPotencial");
            RenameColumn(table: "dbo.tbTipoDeRisco", name: "PerigoPotencial_IDPerigosoPotencial", newName: "idPerigoPotencial");
            DropPrimaryKey("dbo.tbPerigoPotencial");
            AddColumn("dbo.tbPerigoPotencial", "IDPerigoPotencial", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.tbTipoDeRisco", "idPerigoPotencial", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.tbPerigoPotencial", "IDPerigoPotencial");
            CreateIndex("dbo.tbTipoDeRisco", "idPerigoPotencial");
            AddForeignKey("dbo.tbTipoDeRisco", "idPerigoPotencial", "dbo.tbPerigoPotencial", "IDPerigoPotencial");
            DropColumn("dbo.tbPerigoPotencial", "IDPerigosoPotencial");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbPerigoPotencial", "IDPerigosoPotencial", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.tbTipoDeRisco", "idPerigoPotencial", "dbo.tbPerigoPotencial");
            DropIndex("dbo.tbTipoDeRisco", new[] { "idPerigoPotencial" });
            DropPrimaryKey("dbo.tbPerigoPotencial");
            AlterColumn("dbo.tbTipoDeRisco", "idPerigoPotencial", c => c.String());
            DropColumn("dbo.tbPerigoPotencial", "IDPerigoPotencial");
            AddPrimaryKey("dbo.tbPerigoPotencial", "IDPerigosoPotencial");
            RenameColumn(table: "dbo.tbTipoDeRisco", name: "idPerigoPotencial", newName: "PerigoPotencial_IDPerigosoPotencial");
            AddColumn("dbo.tbTipoDeRisco", "idPerigoPotencial", c => c.String());
            CreateIndex("dbo.tbTipoDeRisco", "PerigoPotencial_IDPerigosoPotencial");
            AddForeignKey("dbo.tbTipoDeRisco", "PerigoPotencial_IDPerigosoPotencial", "dbo.tbPerigoPotencial", "IDPerigosoPotencial");
        }
    }
}
