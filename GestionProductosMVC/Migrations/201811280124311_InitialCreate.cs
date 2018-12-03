namespace GestionProductosMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        idUsuario = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Nombre = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.idUsuario);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        EmailLogin = c.String(nullable: false, maxLength: 128),
                        PasswordLogin = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.EmailLogin);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        idProducto = c.Int(nullable: false, identity: true),
                        NombreProducto = c.String(nullable: false),
                        Descripcion = c.String(nullable: false),
                        Costo = c.Int(nullable: false),
                        PrecioVenta = c.Int(nullable: false),
                        TiempoPreviso = c.Int(),
                        PaisOrigen = c.String(),
                        CantMinimaAPedir = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.idProducto);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Productoes");
            DropTable("dbo.Logins");
            DropTable("dbo.Usuarios");
        }
    }
}
