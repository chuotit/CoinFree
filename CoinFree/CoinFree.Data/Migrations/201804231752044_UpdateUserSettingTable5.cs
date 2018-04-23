namespace CoinFree.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserSettingTable5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserSettings", "WinLimit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserSettings", "WinLimit");
        }
    }
}
