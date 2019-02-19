namespace GISCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_22 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbAnaliseRisco",
                c => new
                    {
                        IDAnaliseRisco = c.String(nullable: false, maxLength: 128),
                        IDEmpregado = c.String(),
                        IDEmpresa = c.String(),
                        IDAlocacao = c.String(),
                        Imagem = c.String(),
                        IDAtividadesDoEstabelecimento = c.String(),
                        IDRisco = c.String(),
                        IDPossiveisDanos = c.String(),
                        IDControle = c.String(),
                        UsuarioInclusao = c.String(),
                        DataInclusao = c.DateTime(nullable: false),
                        UsuarioExclusao = c.String(),
                        DataExclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDAnaliseRisco);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbAnaliseRisco");
        }
    }
}
