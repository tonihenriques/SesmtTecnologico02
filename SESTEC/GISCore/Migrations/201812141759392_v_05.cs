namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_05 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbTipoDeRisco", "idEventoPerigosoPotencial", c => c.String(maxLength: 128));
            CreateIndex("dbo.tbTipoDeRisco", "idEventoPerigosoPotencial");
            AddForeignKey("dbo.tbTipoDeRisco", "idEventoPerigosoPotencial", "dbo.tbEventoPerigosoPerigosoPotencial", "IDEventoPerigosoPotencial");
            DropColumn("dbo.tbTipoDeRisco", "DescricaoDoRisco");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbTipoDeRisco", "DescricaoDoRisco", c => c.String());
            DropForeignKey("dbo.tbTipoDeRisco", "idEventoPerigosoPotencial", "dbo.tbEventoPerigosoPerigosoPotencial");
            DropIndex("dbo.tbTipoDeRisco", new[] { "idEventoPerigosoPotencial" });
            DropColumn("dbo.tbTipoDeRisco", "idEventoPerigosoPotencial");
        }
    }
}
