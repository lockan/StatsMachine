namespace statsmachine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Warmachinedatamodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WarmachineGames",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        player = c.String(nullable: false),
                        faction = c.String(nullable: false),
                        result = c.Int(nullable: false),
                        resultType = c.Int(nullable: false),
                        pointSize = c.Int(nullable: false),
                        caster = c.String(),
                        themeforce = c.String(),
                        objective = c.String(),
                        scenario = c.String(),
                        controlPoints = c.Int(nullable: false),
                        opponent = c.String(),
                        opponentCaster = c.String(),
                        opponentPoints = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WarmachineGames");
        }
    }
}
