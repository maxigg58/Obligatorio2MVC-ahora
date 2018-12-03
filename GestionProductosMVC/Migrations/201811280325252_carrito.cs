namespace GestionProductosMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carrito : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carritoes",
                c => new
                    {
                        idSolicitud = c.Int(nullable: false, identity: true),
                        cantidad = c.Int(nullable: false),
                        precio = c.Int(nullable: false),
                        fechaRegistro = c.DateTime(nullable: false),
                        idCliente_idUsuario = c.Int(nullable: false),
                        idProducto_idProducto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idSolicitud)
                .ForeignKey("dbo.Usuarios", t => t.idCliente_idUsuario, cascadeDelete: true)
                .ForeignKey("dbo.Productoes", t => t.idProducto_idProducto, cascadeDelete: true)
                .Index(t => t.idCliente_idUsuario)
                .Index(t => t.idProducto_idProducto);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carritoes", "idProducto_idProducto", "dbo.Productoes");
            DropForeignKey("dbo.Carritoes", "idCliente_idUsuario", "dbo.Usuarios");
            DropIndex("dbo.Carritoes", new[] { "idProducto_idProducto" });
            DropIndex("dbo.Carritoes", new[] { "idCliente_idUsuario" });
            DropTable("dbo.Carritoes");
        }
    }
}
