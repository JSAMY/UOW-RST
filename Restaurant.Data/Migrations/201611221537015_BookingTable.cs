namespace Restaurant.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookingTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
               "dbo.Booking",
               c => new
               {
                   Id = c.Int(nullable: false, identity: true),
                   Name = c.String(nullable: false),
                   Email = c.String(nullable: false),
                   PhoneNum = c.String(nullable: false),
                   PreferredDateTime = c.DateTime(nullable: false),
                   TableNo = c.String(nullable: false),
                   CreatedAt = c.DateTime(nullable: false),
               })
               .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Booking");
        }
    }
}
