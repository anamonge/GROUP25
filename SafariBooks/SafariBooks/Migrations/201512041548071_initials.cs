namespace SafariBooks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initials : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Coupons",
                c => new
                    {
                        CouponsID = c.String(nullable: false, maxLength: 20),
                        CouponTypes = c.Int(nullable: false),
                        PromotionDetails = c.String(nullable: false),
                        Couponvalue = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CouponsID);
            
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        DiscountsID = c.String(nullable: false, maxLength: 20),
                        discountname = c.String(nullable: false),
                        value = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.DiscountsID);
            
            AddColumn("dbo.Orders", "Coupons_CouponsID", c => c.String(maxLength: 20));
            CreateIndex("dbo.Orders", "Coupons_CouponsID");
            AddForeignKey("dbo.Orders", "Coupons_CouponsID", "dbo.Coupons", "CouponsID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Coupons_CouponsID", "dbo.Coupons");
            DropIndex("dbo.Orders", new[] { "Coupons_CouponsID" });
            DropColumn("dbo.Orders", "Coupons_CouponsID");
            DropTable("dbo.Discounts");
            DropTable("dbo.Coupons");
        }
    }
}
