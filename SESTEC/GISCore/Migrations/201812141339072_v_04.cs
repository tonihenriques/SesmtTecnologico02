namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_04 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbEventoPerigosoPerigosoPotencial", "DescricaoEvento", c => c.String());
            DropColumn("dbo.tbEventoPerigosoPerigosoPotencial", "Descricao");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbEventoPerigosoPerigosoPotencial", "Descricao", c => c.String());
            DropColumn("dbo.tbEventoPerigosoPerigosoPotencial", "DescricaoEvento");
        }
    }
}
