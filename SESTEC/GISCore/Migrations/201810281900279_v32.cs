namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v32 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbExposicao", "idAlocacao", "dbo.tbAlocacao");
            DropIndex("dbo.tbExposicao", new[] { "idAlocacao" });
            AddColumn("dbo.tbExposicao", "idAtividadeAlocada", c => c.String(maxLength: 128));
            CreateIndex("dbo.tbExposicao", "idAtividadeAlocada");
            AddForeignKey("dbo.tbExposicao", "idAtividadeAlocada", "dbo.tbAtividadeAlocada", "IDAtividadeAlocada");
            DropColumn("dbo.tbExposicao", "idAlocacao");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbExposicao", "idAlocacao", c => c.String(maxLength: 128));
            DropForeignKey("dbo.tbExposicao", "idAtividadeAlocada", "dbo.tbAtividadeAlocada");
            DropIndex("dbo.tbExposicao", new[] { "idAtividadeAlocada" });
            DropColumn("dbo.tbExposicao", "idAtividadeAlocada");
            CreateIndex("dbo.tbExposicao", "idAlocacao");
            AddForeignKey("dbo.tbExposicao", "idAlocacao", "dbo.tbAlocacao", "IDAlocacao");
        }
    }
}
