namespace UniversityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class groupsrequests : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "tb.RequestToGroup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("tb.Groups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId);
            
            CreateTable(
                "tb.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("tb.RequestToGroup", "GroupId", "tb.Groups");
            DropIndex("tb.RequestToGroup", new[] { "GroupId" });
            DropTable("tb.Groups");
            DropTable("tb.RequestToGroup");
        }
    }
}
