namespace GestionProductosMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carrito15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "Carrito_idSolicitud", c => c.Int());
            AddColumn("dbo.Productoes", "Carrito_idSolicitud", c => c.Int());
            CreateIndex("dbo.Usuarios", "Carrito_idSolicitud");
            CreateIndex("dbo.Productoes", "Carrito_idSolicitud");
            AddForeignKey("dbo.Usuarios", "Carrito_idSolicitud", "dbo.Carritoes", "idSolicitud");
            AddForeignKey("dbo.Productoes", "Carrito_idSolicitud", "dbo.Carritoes", "idSolicitud");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productoes", "Carrito_idSolicitud", "dbo.Carritoes");
            DropForeignKey("dbo.Usuarios", "Carrito_idSolicitud", "dbo.Carritoes");
            DropIndex("dbo.Productoes", new[] { "Carrito_idSolicitud" });
            DropIndex("dbo.Usuarios", new[] { "Carrito_idSolicitud" });
            DropColumn("dbo.Productoes", "Carrito_idSolicitud");
            DropColumn("dbo.Usuarios", "Carrito_idSolicitud");
        }
    }
}
