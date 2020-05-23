namespace VideoLibraryV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MemberDetail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MemberDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Email = c.String(),
                        PhoneNumber = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        MemberCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MemberCategories", t => t.MemberCategoryId, cascadeDelete: true)
                .Index(t => t.MemberCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MemberDetails", "MemberCategoryId", "dbo.MemberCategories");
            DropIndex("dbo.MemberDetails", new[] { "MemberCategoryId" });
            DropTable("dbo.MemberDetails");
        }
    }
}
