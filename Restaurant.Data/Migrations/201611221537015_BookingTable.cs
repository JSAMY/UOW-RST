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
                   Name = c.String(nullable: false, maxLength: 25),
                   Email = c.String(nullable: false, maxLength: 50),
                   PhoneNum = c.String(nullable: false, maxLength: 50),
                   PreferredDateTime = c.DateTime(nullable: false),
                   TableNo = c.String(nullable: true, maxLength: 5),
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
