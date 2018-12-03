namespace GestionProductosMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anotaciones24 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carritoes", "cliente_idUsuario", c => c.Int(nullable: false));
            AddColumn("dbo.Carritoes", "producto_idProducto", c => c.Int(nullable: false));
            CreateIndex("dbo.Carritoes", "cliente_idUsuario");
            CreateIndex("dbo.Carritoes", "producto_idProducto");
            AddForeignKey("dbo.Carritoes", "cliente_idUsuario", "dbo.Usuarios", "idUsuario", cascadeDelete: true);
            AddForeignKey("dbo.Carritoes", "producto_idProducto", "dbo.Productoes", "idProducto", cascadeDelete: true);
            DropColumn("dbo.Carritoes", "idCliente");
            DropColumn("dbo.Carritoes", "idProducto");
            DropColumn("dbo.Carritoes", "nomProd");
            DropColumn("dbo.Carritoes", "precio");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carritoes", "precio", c => c.Int(nullable: false));
            AddColumn("dbo.Carritoes", "nomProd", c => c.String(nullable: false));
            AddColumn("dbo.Carritoes", "idProducto", c => c.Int(nullable: false));
            AddColumn("dbo.Carritoes", "idCliente", c => c.Int(nullable: false));
            DropForeignKey("dbo.Carritoes", "producto_idProducto", "dbo.Productoes");
            DropForeignKey("dbo.Carritoes", "cliente_idUsuario", "dbo.Usuarios");
            DropIndex("dbo.Carritoes", new[] { "producto_idProducto" });
            DropIndex("dbo.Carritoes", new[] { "cliente_idUsuario" });
            DropColumn("dbo.Carritoes", "producto_idProducto");
            DropColumn("dbo.Carritoes", "cliente_idUsuario");
        }
    }
}
