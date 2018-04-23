namespace CoinFree.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserSettingTable3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserSettings", "PercentIncrease", c => c.Int(nullable: false));
            DropColumn("dbo.UserSettings", "PercentIncreases");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserSettings", "PercentIncreases", c => c.Int(nullable: false));
            DropColumn("dbo.UserSettings", "PercentIncrease");
        }
    }
}
