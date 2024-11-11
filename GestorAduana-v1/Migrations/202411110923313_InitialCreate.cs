namespace GestorAduana_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BackOffice",
                c => new
                    {
                        IdBackOffice = c.Int(nullable: false, identity: true),
                        NombreBo = c.String(nullable: false, maxLength: 50),
                        ApellidoBo = c.String(nullable: false, maxLength: 50),
                        EmpresaId = c.Int(nullable: false),
                        Recorrido = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.IdBackOffice)
                .ForeignKey("dbo.Empresa", t => t.EmpresaId, cascadeDelete: true)
                .Index(t => t.EmpresaId);
            
            CreateTable(
                "dbo.Empresa",
                c => new
                    {
                        EmpresaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.EmpresaId);
            
            CreateTable(
                "dbo.Camionero",
                c => new
                    {
                        IdCamionero = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Apellido = c.String(nullable: false, maxLength: 50),
                        Dui = c.String(nullable: false, maxLength: 10),
                        Edad = c.Int(nullable: false),
                        Placa = c.String(nullable: false, maxLength: 20),
                        QueTransporta = c.String(nullable: false, maxLength: 100),
                        CantidadTransportada = c.Int(nullable: false),
                        EmpresaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCamionero)
                .ForeignKey("dbo.Empresa", t => t.EmpresaId, cascadeDelete: true)
                .Index(t => t.EmpresaId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        IdUsuario = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Apellido = c.String(nullable: false, maxLength: 50),
                        Username = c.String(nullable: false, maxLength: 50),
                        Contrasena = c.String(nullable: false, maxLength: 50),
                        Rol = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.IdUsuario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BackOffice", "EmpresaId", "dbo.Empresa");
            DropForeignKey("dbo.Camionero", "EmpresaId", "dbo.Empresa");
            DropIndex("dbo.Camionero", new[] { "EmpresaId" });
            DropIndex("dbo.BackOffice", new[] { "EmpresaId" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Camionero");
            DropTable("dbo.Empresa");
            DropTable("dbo.BackOffice");
        }
    }
}
