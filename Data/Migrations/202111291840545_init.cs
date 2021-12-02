namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 300),
                        Email = c.String(nullable: false, maxLength: 250),
                        Mobile = c.String(nullable: false, maxLength: 150),
                        Address = c.String(nullable:true,maxLength: 1000),
                        CustomerImage = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 200),
                        Password = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        TypeId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        Description = c.String(maxLength: 800,nullable:true),
                        DateTime = c.DateTime(nullable: true),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.TransactionTypes", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.TransactionTypes",
                c => new
                    {
                        TypeId = c.Int(nullable: false, identity: true),
                        TypeTitle = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.TypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "TypeId", "dbo.TransactionTypes");
            DropForeignKey("dbo.Transactions", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Transactions", new[] { "TypeId" });
            DropIndex("dbo.Transactions", new[] { "CustomerId" });
            DropTable("dbo.TransactionTypes");
            DropTable("dbo.Transactions");
            DropTable("dbo.Logins");
            DropTable("dbo.Customers");
        }
    }
}
