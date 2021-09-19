namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ResponsibleName = c.String(),
                        IdImages = c.Int(),
                        DateCreate = c.DateTime(nullable: false),
                        DateUpdate = c.DateTime(),
                        IdCreator = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Images", t => t.IdImages)
                .Index(t => t.IdImages);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IdImages = c.Int(),
                        IdCompany = c.Int(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                        DateUpdate = c.DateTime(),
                        IdCreator = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.IdCompany, cascadeDelete: true)
                .ForeignKey("dbo.Images", t => t.IdImages)
                .Index(t => t.IdImages)
                .Index(t => t.IdCompany);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        Size = c.Double(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                        DateUpdate = c.DateTime(),
                        IdCreator = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Visit",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdCompany = c.Int(nullable: false),
                        IdVisitor = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        IsClient = c.Boolean(nullable: false),
                        Note = c.String(),
                        DateCreate = c.DateTime(nullable: false),
                        DateUpdate = c.DateTime(),
                        IdCreator = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.IdCompany, cascadeDelete: true)
                .ForeignKey("dbo.Visitor", t => t.IdVisitor, cascadeDelete: true)
                .Index(t => t.IdCompany)
                .Index(t => t.IdVisitor);
            
            CreateTable(
                "dbo.Visitor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IdImages = c.Int(),
                        DateCreate = c.DateTime(nullable: false),
                        DateUpdate = c.DateTime(),
                        IdCreator = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Images", t => t.IdImages)
                .Index(t => t.IdImages);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visit", "IdVisitor", "dbo.Visitor");
            DropForeignKey("dbo.Visitor", "IdImages", "dbo.Images");
            DropForeignKey("dbo.Visit", "IdCompany", "dbo.Company");
            DropForeignKey("dbo.Company", "IdImages", "dbo.Images");
            DropForeignKey("dbo.Employee", "IdImages", "dbo.Images");
            DropForeignKey("dbo.Employee", "IdCompany", "dbo.Company");
            DropIndex("dbo.Visitor", new[] { "IdImages" });
            DropIndex("dbo.Visit", new[] { "IdVisitor" });
            DropIndex("dbo.Visit", new[] { "IdCompany" });
            DropIndex("dbo.Employee", new[] { "IdCompany" });
            DropIndex("dbo.Employee", new[] { "IdImages" });
            DropIndex("dbo.Company", new[] { "IdImages" });
            DropTable("dbo.Visitor");
            DropTable("dbo.Visit");
            DropTable("dbo.Images");
            DropTable("dbo.Employee");
            DropTable("dbo.Company");
        }
    }
}
