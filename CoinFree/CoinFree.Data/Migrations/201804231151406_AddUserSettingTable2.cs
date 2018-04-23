namespace CoinFree.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserSettingTable2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserSettings", "CoinAddress", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.UserSettings", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserSettings", "UserID", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.UserSettings", "CoinAddress");
        }
    }
}
