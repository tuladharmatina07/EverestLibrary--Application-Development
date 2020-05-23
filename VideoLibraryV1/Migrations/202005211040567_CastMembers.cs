namespace VideoLibraryV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CastMembers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CastMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DVDDetailId = c.Int(nullable: false),
                        CastDetailId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CastDetails", t => t.CastDetailId, cascadeDelete: true)
                .ForeignKey("dbo.DVDDetails", t => t.DVDDetailId, cascadeDelete: true)
                .Index(t => t.DVDDetailId)
                .Index(t => t.CastDetailId);
            
            CreateTable(
                "dbo.DVDDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DVDName = c.String(nullable: false),
                        StudioName = c.String(),
                        ReleasedDate = c.DateTime(nullable: false),
                        AgeRestriction = c.Boolean(nullable: false),
                        Length = c.Int(nullable: false),
                        CoverImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CastMembers", "DVDDetailId", "dbo.DVDDetails");
            DropForeignKey("dbo.CastMembers", "CastDetailId", "dbo.CastDetails");
            DropIndex("dbo.CastMembers", new[] { "CastDetailId" });
            DropIndex("dbo.CastMembers", new[] { "DVDDetailId" });
            DropTable("dbo.DVDDetails");
            DropTable("dbo.CastMembers");
        }
    }
}
