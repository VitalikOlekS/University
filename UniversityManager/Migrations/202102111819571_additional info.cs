namespace UniversityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class additionalinfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblUserAdditionalInfo",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Image = c.String(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .ForeignKey("tb.Groups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblUserAdditionalInfo", "GroupId", "tb.Groups");
            DropForeignKey("dbo.tblUserAdditionalInfo", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.tblUserAdditionalInfo", new[] { "GroupId" });
            DropIndex("dbo.tblUserAdditionalInfo", new[] { "Id" });
            DropTable("dbo.tblUserAdditionalInfo");
        }
    }
}
