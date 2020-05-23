namespace VideoLibraryV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CastDetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CastDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Email = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CastDetails");
        }
    }
}
