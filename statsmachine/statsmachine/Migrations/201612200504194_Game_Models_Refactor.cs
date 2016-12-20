namespace statsmachine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Game_Models_Refactor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameSystems",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.id);
            
            DropTable("dbo.SupportedGames");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SupportedGames",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            DropTable("dbo.GameSystems");
        }
    }
}
