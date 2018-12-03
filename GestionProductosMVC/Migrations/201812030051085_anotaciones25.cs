namespace GestionProductosMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anotaciones25 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Usuarios", "Carrito_idSolicitud", "dbo.Carritoes");
            DropForeignKey("dbo.Productoes", "Carrito_idSolicitud", "dbo.Carritoes");
            DropIndex("dbo.Usuarios", new[] { "Carrito_idSolicitud" });
            DropIndex("dbo.Productoes", new[] { "Carrito_idSolicitud" });
            DropColumn("dbo.Usuarios", "Carrito_idSolicitud");
            DropColumn("dbo.Productoes", "Carrito_idSolicitud");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Productoes", "Carrito_idSolicitud", c => c.Int());
            AddColumn("dbo.Usuarios", "Carrito_idSolicitud", c => c.Int());
            CreateIndex("dbo.Productoes", "Carrito_idSolicitud");
            CreateIndex("dbo.Usuarios", "Carrito_idSolicitud");
            AddForeignKey("dbo.Productoes", "Carrito_idSolicitud", "dbo.Carritoes", "idSolicitud");
            AddForeignKey("dbo.Usuarios", "Carrito_idSolicitud", "dbo.Carritoes", "idSolicitud");
        }
    }
}
