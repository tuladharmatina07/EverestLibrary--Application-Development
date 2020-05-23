namespace VideoLibraryV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Loans : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Loans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IssuedDate = c.DateTime(nullable: false),
                        ReturnedDate = c.DateTime(nullable: false),
                        FineAmount = c.Int(nullable: false),
                        MemberDetailId = c.Int(nullable: false),
                        DVDDetailId = c.Int(nullable: false),
                        LoanTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DVDDetails", t => t.DVDDetailId, cascadeDelete: true)
                .ForeignKey("dbo.LoanTypes", t => t.LoanTypeId, cascadeDelete: true)
                .ForeignKey("dbo.MemberDetails", t => t.MemberDetailId, cascadeDelete: true)
                .Index(t => t.MemberDetailId)
                .Index(t => t.DVDDetailId)
                .Index(t => t.LoanTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Loans", "MemberDetailId", "dbo.MemberDetails");
            DropForeignKey("dbo.Loans", "LoanTypeId", "dbo.LoanTypes");
            DropForeignKey("dbo.Loans", "DVDDetailId", "dbo.DVDDetails");
            DropIndex("dbo.Loans", new[] { "LoanTypeId" });
            DropIndex("dbo.Loans", new[] { "DVDDetailId" });
            DropIndex("dbo.Loans", new[] { "MemberDetailId" });
            DropTable("dbo.Loans");
        }
    }
}
