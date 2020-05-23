namespace VideoLibraryV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProducerMembers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProducerMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DVDDetailId = c.Int(nullable: false),
                        ProducerDetailId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DVDDetails", t => t.DVDDetailId, cascadeDelete: true)
                .ForeignKey("dbo.ProducerDetails", t => t.ProducerDetailId, cascadeDelete: true)
                .Index(t => t.DVDDetailId)
                .Index(t => t.ProducerDetailId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProducerMembers", "ProducerDetailId", "dbo.ProducerDetails");
            DropForeignKey("dbo.ProducerMembers", "DVDDetailId", "dbo.DVDDetails");
            DropIndex("dbo.ProducerMembers", new[] { "ProducerDetailId" });
            DropIndex("dbo.ProducerMembers", new[] { "DVDDetailId" });
            DropTable("dbo.ProducerMembers");
        }
    }
}
