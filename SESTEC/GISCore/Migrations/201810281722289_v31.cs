namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v31 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbExposicao",
                c => new
                    {
                        IDExposicao = c.String(nullable: false, maxLength: 128),
                        idAlocacao = c.String(maxLength: 128),
                        TempoEstimado = c.String(),
                        EExposicaoInsalubre = c.Int(nullable: false),
                        EExposicaoCalor = c.Int(nullable: false),
                        EExposicaoSeg = c.Int(nullable: false),
                        EProbabilidadeSeg = c.Int(nullable: false),
                        ESeveridadeSeg = c.Int(nullable: false),
                        UsuarioInclusao = c.String(),
                        DataInclusao = c.DateTime(nullable: false),
                        UsuarioExclusao = c.String(),
                        DataExclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDExposicao)
                .ForeignKey("dbo.tbAlocacao", t => t.idAlocacao)
                .Index(t => t.idAlocacao);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbExposicao", "idAlocacao", "dbo.tbAlocacao");
            DropIndex("dbo.tbExposicao", new[] { "idAlocacao" });
            DropTable("dbo.tbExposicao");
        }
    }
}
