namespace statsmachine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addgamesandusergamestables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserGames",
                c => new
                    {
                        userid = c.String(nullable: false, maxLength: 128),
                        gameid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.userid, t.gameid });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserGames");
        }
    }
}
