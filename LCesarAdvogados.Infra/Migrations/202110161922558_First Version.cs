namespace LCesarAdvogados.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstVersion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        IdPost = c.Int(nullable: false, identity: true),
                        TituloPost = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        ImagemPost = c.String(unicode: false),
                        ConteudoPost = c.String(unicode: false),
                        DataCadastro = c.DateTime(nullable: false, precision: 0),
                        Status = c.Boolean(nullable: false),
                        ResumoPost = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.IdPost);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        IdUsuario = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        Login = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                        Email = c.String(nullable: false, unicode: false),
                        Senha = c.String(nullable: false, maxLength: 15, storeType: "nvarchar"),
                        DataCadastro = c.DateTime(nullable: false, precision: 0),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdUsuario);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuario");
            DropTable("dbo.Posts");
        }
    }
}
