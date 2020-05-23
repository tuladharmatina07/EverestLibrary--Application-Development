namespace VideoLibraryV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MemberCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MemberCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                        TotalLoanAmount = c.Int(nullable: false),
                        ReturningDate = c.DateTime(nullable: false),
                        FineAmountPerDay = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MemberCategories");
        }
    }
}
