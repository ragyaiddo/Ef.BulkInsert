namespace Ragyaiddo.Ef.BulkInsertTests.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SimpleModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SimplePropInt = c.Int(nullable: false),
                        SimplePropStr = c.String(),
                        SimplePropGuid = c.Guid(nullable: false),
                        SimplePropDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SimpleModel");
        }
    }
}
