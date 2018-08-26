namespace MvcProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        PictureId = c.Int(nullable: false, identity: true),
                        Content = c.Binary(),
                    })
                .PrimaryKey(t => t.PictureId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pictures");
        }
    }
}
