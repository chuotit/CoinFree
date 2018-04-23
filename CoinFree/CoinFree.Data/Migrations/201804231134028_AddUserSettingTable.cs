namespace CoinFree.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserSettingTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        GameType = c.String(),
                        Payout = c.Double(nullable: false),
                        UserID = c.String(nullable: false, maxLength: 50),
                        BtcBetBase = c.String(maxLength: 20),
                        BetSpeed = c.String(),
                        BetMode = c.Int(nullable: false),
                        BetProbe = c.Int(nullable: false),
                        BtcPlus = c.String(maxLength: 20),
                        BetTarget = c.Int(nullable: false),
                        PercentIncreases = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserSettings");
        }
    }
}
