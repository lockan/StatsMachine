namespace statsmachine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class warmachine_model_changes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WarmachineGames", "UserId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WarmachineGames", "UserId", c => c.String());
        }
    }
}
