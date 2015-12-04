namespace SafariBooks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookReviews", "BookID", "dbo.Books");
            DropIndex("dbo.BookReviews", new[] { "BookID" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            RenameColumn(table: "dbo.AspNetUserClaims", name: "UserId", newName: "User_Id");
            RenameIndex(table: "dbo.AspNetUserClaims", name: "IX_UserId", newName: "IX_User_Id");
            DropPrimaryKey("dbo.AspNetUserLogins");
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreID = c.Int(nullable: false, identity: true),
                        GenreName = c.String(nullable: false),
                        BookID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GenreID)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .Index(t => t.BookID);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewID = c.String(nullable: false, maxLength: 128),
                        EmployeeID = c.String(maxLength: 128),
                        CustomerID = c.String(maxLength: 128),
                        Rating = c.String(),
                        BookReview = c.String(maxLength: 100),
                        BookID = c.String(),
                        Book_BookID = c.Int(),
                    })
                .PrimaryKey(t => t.ReviewID)
                .ForeignKey("dbo.Books", t => t.Book_BookID)
                .ForeignKey("dbo.Customers", t => t.CustomerID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID)
                .Index(t => t.EmployeeID)
                .Index(t => t.CustomerID)
                .Index(t => t.Book_BookID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.String(nullable: false, maxLength: 128),
                        FName = c.String(nullable: false),
                        MInitial = c.String(maxLength: 1),
                        LName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        ZipCode = c.Int(nullable: false),
                        Card1 = c.String(),
                        Card = c.Int(nullable: false),
                        Card2 = c.String(),
                        Cards2 = c.Int(nullable: false),
                        Card3 = c.String(),
                        Cards3 = c.Int(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        PromotionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        BookID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderDetailID)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.BookID);
            
            CreateTable(
                "dbo.Promotions",
                c => new
                    {
                        PromotionID = c.Int(nullable: false, identity: true),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustomerID = c.Int(nullable: false),
                        Customer_CustomerID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PromotionID)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerID)
                .Index(t => t.Customer_CustomerID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.String(nullable: false, maxLength: 128),
                        FName = c.String(nullable: false),
                        MInitial = c.String(maxLength: 1),
                        LName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        ZipCode = c.Int(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(nullable: false),
                        EmployeeTypes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
            CreateTable(
                "dbo.Reorders",
                c => new
                    {
                        ReordersID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReordersID);
            
            CreateTable(
                "dbo.ReorderDetails",
                c => new
                    {
                        ReorderDetailsID = c.Int(nullable: false, identity: true),
                        ReordersID = c.Int(nullable: false),
                        BookID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReorderDetailsID)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.Reorders", t => t.ReordersID, cascadeDelete: true)
                .Index(t => t.ReordersID)
                .Index(t => t.BookID);
            
            CreateTable(
                "dbo.OrderCustomers",
                c => new
                    {
                        Order_OrderID = c.Int(nullable: false),
                        Customer_CustomerID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Order_OrderID, t.Customer_CustomerID })
                .ForeignKey("dbo.Orders", t => t.Order_OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerID, cascadeDelete: true)
                .Index(t => t.Order_OrderID)
                .Index(t => t.Customer_CustomerID);
            
            CreateTable(
                "dbo.PromotionOrders",
                c => new
                    {
                        Promotion_PromotionID = c.Int(nullable: false),
                        Order_OrderID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Promotion_PromotionID, t.Order_OrderID })
                .ForeignKey("dbo.Promotions", t => t.Promotion_PromotionID, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_OrderID, cascadeDelete: true)
                .Index(t => t.Promotion_PromotionID)
                .Index(t => t.Order_OrderID);
            
            CreateTable(
                "dbo.ReordersEmployees",
                c => new
                    {
                        Reorders_ReordersID = c.Int(nullable: false),
                        Employee_EmployeeID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Reorders_ReordersID, t.Employee_EmployeeID })
                .ForeignKey("dbo.Reorders", t => t.Reorders_ReordersID, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeID, cascadeDelete: true)
                .Index(t => t.Reorders_ReordersID)
                .Index(t => t.Employee_EmployeeID);
            
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetRoles", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String(nullable: false));
            AddPrimaryKey("dbo.AspNetUserLogins", new[] { "UserId", "LoginProvider", "ProviderKey" });
            DropColumn("dbo.Books", "Genre");
            DropColumn("dbo.AspNetRoles", "Discriminator");
            DropColumn("dbo.AspNetUsers", "FName");
            DropColumn("dbo.AspNetUsers", "MInitial");
            DropColumn("dbo.AspNetUsers", "LName");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "ZipCode");
            DropColumn("dbo.AspNetUsers", "Phone");
            DropColumn("dbo.AspNetUsers", "Password");
            DropColumn("dbo.AspNetUsers", "ConfirmPassword");
            DropColumn("dbo.AspNetUsers", "Email");
            DropColumn("dbo.AspNetUsers", "EmailConfirmed");
            DropColumn("dbo.AspNetUsers", "PhoneNumber");
            DropColumn("dbo.AspNetUsers", "PhoneNumberConfirmed");
            DropColumn("dbo.AspNetUsers", "TwoFactorEnabled");
            DropColumn("dbo.AspNetUsers", "LockoutEndDateUtc");
            DropColumn("dbo.AspNetUsers", "LockoutEnabled");
            DropColumn("dbo.AspNetUsers", "AccessFailedCount");
            DropTable("dbo.BookReviews");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BookReviews",
                c => new
                    {
                        BookReviewID = c.Int(nullable: false, identity: true),
                        BookID = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        Review = c.String(nullable: false, maxLength: 100),
                        Ratings = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookReviewID);
            
            AddColumn("dbo.AspNetUsers", "AccessFailedCount", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "LockoutEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "TwoFactorEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "PhoneNumberConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String());
            AddColumn("dbo.AspNetUsers", "EmailConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "Email", c => c.String(maxLength: 256));
            AddColumn("dbo.AspNetUsers", "ConfirmPassword", c => c.String());
            AddColumn("dbo.AspNetUsers", "Password", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.AspNetUsers", "Phone", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "ZipCode", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Address", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "LName", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "MInitial", c => c.String(maxLength: 1));
            AddColumn("dbo.AspNetUsers", "FName", c => c.String(nullable: false));
            AddColumn("dbo.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Books", "Genre", c => c.String(nullable: false));
            DropForeignKey("dbo.Reviews", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.ReorderDetails", "ReordersID", "dbo.Reorders");
            DropForeignKey("dbo.ReorderDetails", "BookID", "dbo.Books");
            DropForeignKey("dbo.ReordersEmployees", "Employee_EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.ReordersEmployees", "Reorders_ReordersID", "dbo.Reorders");
            DropForeignKey("dbo.Reviews", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.PromotionOrders", "Order_OrderID", "dbo.Orders");
            DropForeignKey("dbo.PromotionOrders", "Promotion_PromotionID", "dbo.Promotions");
            DropForeignKey("dbo.Promotions", "Customer_CustomerID", "dbo.Customers");
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "BookID", "dbo.Books");
            DropForeignKey("dbo.OrderCustomers", "Customer_CustomerID", "dbo.Customers");
            DropForeignKey("dbo.OrderCustomers", "Order_OrderID", "dbo.Orders");
            DropForeignKey("dbo.Reviews", "Book_BookID", "dbo.Books");
            DropForeignKey("dbo.Genres", "BookID", "dbo.Books");
            DropIndex("dbo.ReordersEmployees", new[] { "Employee_EmployeeID" });
            DropIndex("dbo.ReordersEmployees", new[] { "Reorders_ReordersID" });
            DropIndex("dbo.PromotionOrders", new[] { "Order_OrderID" });
            DropIndex("dbo.PromotionOrders", new[] { "Promotion_PromotionID" });
            DropIndex("dbo.OrderCustomers", new[] { "Customer_CustomerID" });
            DropIndex("dbo.OrderCustomers", new[] { "Order_OrderID" });
            DropIndex("dbo.ReorderDetails", new[] { "BookID" });
            DropIndex("dbo.ReorderDetails", new[] { "ReordersID" });
            DropIndex("dbo.Promotions", new[] { "Customer_CustomerID" });
            DropIndex("dbo.OrderDetails", new[] { "BookID" });
            DropIndex("dbo.OrderDetails", new[] { "OrderID" });
            DropIndex("dbo.Reviews", new[] { "Book_BookID" });
            DropIndex("dbo.Reviews", new[] { "CustomerID" });
            DropIndex("dbo.Reviews", new[] { "EmployeeID" });
            DropIndex("dbo.Genres", new[] { "BookID" });
            DropPrimaryKey("dbo.AspNetUserLogins");
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.AspNetRoles", "Name", c => c.String(nullable: false, maxLength: 256));
            DropColumn("dbo.AspNetUsers", "Discriminator");
            DropTable("dbo.ReordersEmployees");
            DropTable("dbo.PromotionOrders");
            DropTable("dbo.OrderCustomers");
            DropTable("dbo.ReorderDetails");
            DropTable("dbo.Reorders");
            DropTable("dbo.Employees");
            DropTable("dbo.Promotions");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            DropTable("dbo.Reviews");
            DropTable("dbo.Genres");
            AddPrimaryKey("dbo.AspNetUserLogins", new[] { "LoginProvider", "ProviderKey", "UserId" });
            RenameIndex(table: "dbo.AspNetUserClaims", name: "IX_User_Id", newName: "IX_UserId");
            RenameColumn(table: "dbo.AspNetUserClaims", name: "User_Id", newName: "UserId");
            CreateIndex("dbo.AspNetUsers", "UserName", unique: true, name: "UserNameIndex");
            CreateIndex("dbo.AspNetRoles", "Name", unique: true, name: "RoleNameIndex");
            CreateIndex("dbo.BookReviews", "BookID");
            AddForeignKey("dbo.BookReviews", "BookID", "dbo.Books", "BookID", cascadeDelete: true);
        }
    }
}
