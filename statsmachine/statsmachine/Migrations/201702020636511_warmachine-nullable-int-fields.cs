namespace statsmachine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class warmachinenullableintfields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WarmachineGames", "pointSize", c => c.Int());
            AlterColumn("dbo.WarmachineGames", "controlPoints", c => c.Int());
            AlterColumn("dbo.WarmachineGames", "opponentPoints", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WarmachineGames", "opponentPoints", c => c.Int(nullable: false));
            AlterColumn("dbo.WarmachineGames", "controlPoints", c => c.Int(nullable: false));
            AlterColumn("dbo.WarmachineGames", "pointSize", c => c.Int(nullable: false));
        }
    }
}
