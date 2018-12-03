namespace GestionProductosMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carrito12 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        idPedido = c.Int(nullable: false, identity: true),
                        idOrdenCompra = c.Int(nullable: false),
                        idCliente = c.Int(nullable: false),
                        fecha = c.DateTime(nullable: false),
                        totalPedido = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idPedido);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pedidoes");
        }
    }
}
