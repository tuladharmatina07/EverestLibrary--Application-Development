namespace VideoLibraryV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Loans", "ReturnedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Loans", "ReturnedDate", c => c.DateTime(nullable: false));
        }
    }
}
