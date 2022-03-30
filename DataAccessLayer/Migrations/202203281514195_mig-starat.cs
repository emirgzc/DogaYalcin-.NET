namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migstarat : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        AboutId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Desc = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.AboutId);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        Title = c.String(),
                        Desc = c.String(),
                        BlogDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BlogId);
            
            CreateTable(
                "dbo.Galeris",
                c => new
                    {
                        PhotoId = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        DateImage = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PhotoId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServicesId = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        Title = c.String(),
                        Desc = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ServicesId);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        SetId = c.Int(nullable: false, identity: true),
                        Phone = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        WorkToDay = c.String(),
                        Twitter = c.String(),
                        Instagram = c.String(),
                        Facebook = c.String(),
                        Linkedin = c.String(),
                        Youtube = c.String(),
                        Map = c.String(),
                    })
                .PrimaryKey(t => t.SetId);
            
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        SliderId = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        Title = c.String(),
                        Desc = c.String(),
                        SliderAddDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SliderId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sliders");
            DropTable("dbo.Settings");
            DropTable("dbo.Services");
            DropTable("dbo.Galeris");
            DropTable("dbo.Blogs");
            DropTable("dbo.Admins");
            DropTable("dbo.Abouts");
        }
    }
}
