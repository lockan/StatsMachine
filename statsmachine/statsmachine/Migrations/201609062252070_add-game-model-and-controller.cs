namespace statsmachine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addgamemodelandcontroller : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Games");
        }
    }
}
