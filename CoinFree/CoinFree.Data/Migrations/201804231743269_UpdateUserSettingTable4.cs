namespace CoinFree.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserSettingTable4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserSettings", "IncreaseWhenLost", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserSettings", "IncreaseWhenLost");
        }
    }
}
