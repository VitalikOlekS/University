namespace UniversityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dateStart : DbMigration
    {
        public override void Up()
        {
            AddColumn("tb.Groups", "EducationStartDate", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("tb.Groups", "EducationStartDate");
        }
    }
}
