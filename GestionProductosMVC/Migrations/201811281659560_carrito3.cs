namespace GestionProductosMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carrito3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carritoes", "idCliente_idUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.Carritoes", "idProducto_idProducto", "dbo.Productoes");
            DropIndex("dbo.Carritoes", new[] { "idCliente_idUsuario" });
            DropIndex("dbo.Carritoes", new[] { "idProducto_idProducto" });
            AddColumn("dbo.Carritoes", "idCliente", c => c.Int(nullable: false));
            AddColumn("dbo.Carritoes", "idProducto", c => c.Int(nullable: false));
            DropColumn("dbo.Carritoes", "idCliente_idUsuario");
            DropColumn("dbo.Carritoes", "idProducto_idProducto");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carritoes", "idProducto_idProducto", c => c.Int(nullable: false));
            AddColumn("dbo.Carritoes", "idCliente_idUsuario", c => c.Int(nullable: false));
            DropColumn("dbo.Carritoes", "idProducto");
            DropColumn("dbo.Carritoes", "idCliente");
            CreateIndex("dbo.Carritoes", "idProducto_idProducto");
            CreateIndex("dbo.Carritoes", "idCliente_idUsuario");
            AddForeignKey("dbo.Carritoes", "idProducto_idProducto", "dbo.Productoes", "idProducto", cascadeDelete: true);
            AddForeignKey("dbo.Carritoes", "idCliente_idUsuario", "dbo.Usuarios", "idUsuario", cascadeDelete: true);
        }
    }
}
