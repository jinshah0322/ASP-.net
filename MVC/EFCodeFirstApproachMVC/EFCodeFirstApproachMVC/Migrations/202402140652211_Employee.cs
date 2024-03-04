namespace EFCodeFirstApproachMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Employee : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "InterestedTechnology", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "InterestedTechnology", c => c.String(nullable: false));
        }
    }
}
