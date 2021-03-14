namespace UniversityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentgroup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblStudentGroup",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
            DropForeignKey("dbo.tblStudentGroup", "GroupId", "tb.Groups");
            DropForeignKey("dbo.tblStudentGroup", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.tblStudentGroup", new[] { "GroupId" });
            DropIndex("dbo.tblStudentGroup", new[] { "Id" });
            DropTable("dbo.tblStudentGroup");
        }
    }
}
