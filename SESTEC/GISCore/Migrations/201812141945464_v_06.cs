namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_06 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbTipoDeRisco", "idEventoPerigosoPotencial", "dbo.tbEventoPerigosoPerigosoPotencial");
            DropIndex("dbo.tbTipoDeRisco", new[] { "idEventoPerigosoPotencial" });
            CreateTable(
                "dbo.tbPerigoPotencial",
                c => new
                    {
                        IDPerigosoPotencial = c.String(nullable: false, maxLength: 128),
                        DescricaoEvento = c.String(),
                        UsuarioInclusao = c.String(),
                        DataInclusao = c.DateTime(nullable: false),
                        UsuarioExclusao = c.String(),
                        DataExclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDPerigosoPotencial);
            
            AddColumn("dbo.tbTipoDeRisco", "idPerigoPotencial", c => c.String());
            AddColumn("dbo.tbTipoDeRisco", "PerigoPotencial_IDPerigosoPotencial", c => c.String(maxLength: 128));
            CreateIndex("dbo.tbTipoDeRisco", "PerigoPotencial_IDPerigosoPotencial");
            AddForeignKey("dbo.tbTipoDeRisco", "PerigoPotencial_IDPerigosoPotencial", "dbo.tbPerigoPotencial", "IDPerigosoPotencial");
            DropColumn("dbo.tbTipoDeRisco", "idEventoPerigosoPotencial");
            DropTable("dbo.tbEventoPerigosoPerigosoPotencial");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tbEventoPerigosoPerigosoPotencial",
                c => new
                    {
                        IDEventoPerigosoPotencial = c.String(nullable: false, maxLength: 128),
                        DescricaoEvento = c.String(),
                    })
                .PrimaryKey(t => t.IDEventoPerigosoPotencial);
            
            AddColumn("dbo.tbTipoDeRisco", "idEventoPerigosoPotencial", c => c.String(maxLength: 128));
            DropForeignKey("dbo.tbTipoDeRisco", "PerigoPotencial_IDPerigosoPotencial", "dbo.tbPerigoPotencial");
            DropIndex("dbo.tbTipoDeRisco", new[] { "PerigoPotencial_IDPerigosoPotencial" });
            DropColumn("dbo.tbTipoDeRisco", "PerigoPotencial_IDPerigosoPotencial");
            DropColumn("dbo.tbTipoDeRisco", "idPerigoPotencial");
            DropTable("dbo.tbPerigoPotencial");
            CreateIndex("dbo.tbTipoDeRisco", "idEventoPerigosoPotencial");
            AddForeignKey("dbo.tbTipoDeRisco", "idEventoPerigosoPotencial", "dbo.tbEventoPerigosoPerigosoPotencial", "IDEventoPerigosoPotencial");
        }
    }
}
