namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_24 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbAnaliseRisco", "IDAtividadeAlocada", c => c.String(maxLength: 128));
            AlterColumn("dbo.tbAnaliseRisco", "IDAlocacao", c => c.String(maxLength: 128));
            CreateIndex("dbo.tbAnaliseRisco", "IDAtividadeAlocada");
            CreateIndex("dbo.tbAnaliseRisco", "IDAlocacao");
            AddForeignKey("dbo.tbAnaliseRisco", "IDAlocacao", "dbo.tbAlocacao", "IDAlocacao");
            AddForeignKey("dbo.tbAnaliseRisco", "IDAtividadeAlocada", "dbo.tbAtividadeAlocada", "IDAtividadeAlocada");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbAnaliseRisco", "IDAtividadeAlocada", "dbo.tbAtividadeAlocada");
            DropForeignKey("dbo.tbAnaliseRisco", "IDAlocacao", "dbo.tbAlocacao");
            DropIndex("dbo.tbAnaliseRisco", new[] { "IDAlocacao" });
            DropIndex("dbo.tbAnaliseRisco", new[] { "IDAtividadeAlocada" });
            AlterColumn("dbo.tbAnaliseRisco", "IDAlocacao", c => c.String());
            DropColumn("dbo.tbAnaliseRisco", "IDAtividadeAlocada");
        }
    }
}
