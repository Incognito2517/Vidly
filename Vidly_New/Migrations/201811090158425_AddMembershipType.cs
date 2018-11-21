namespace Vidly_New.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipType : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Customers");
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonth = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Customers", "IsSubscribedToNewsletter", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "MembershipTypeId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Customers", "Name", c => c.String());
            AddPrimaryKey("dbo.Customers", "Id");
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Customers", "MembershipTypeId");
            DropColumn("dbo.Customers", "IsSubscribedToNewsletter");
            DropColumn("dbo.Customers", "Id");
            DropTable("dbo.MembershipTypes");
            AddPrimaryKey("dbo.Customers", "Name");
        }
    }
}
