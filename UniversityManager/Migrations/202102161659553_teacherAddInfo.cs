namespace UniversityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teacherAddInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblTeacherAdditionalInfo",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Image = c.String(nullable: false),
                        Skills = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblTeacherAdditionalInfo", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.tblTeacherAdditionalInfo", new[] { "Id" });
            DropTable("dbo.tblTeacherAdditionalInfo");
        }
    }
}
