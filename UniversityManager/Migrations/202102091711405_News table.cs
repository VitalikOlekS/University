namespace UniversityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Newstable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "tb.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        ImgUrl = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        RealeseDate = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("tb.News");
        }
    }
}
