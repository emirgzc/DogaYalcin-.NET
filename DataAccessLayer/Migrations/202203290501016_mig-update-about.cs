namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migupdateabout : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Abouts", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Abouts", "Image", c => c.String());
        }
    }
}
