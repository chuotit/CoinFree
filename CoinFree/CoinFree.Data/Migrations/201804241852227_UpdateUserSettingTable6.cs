namespace CoinFree.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserSettingTable6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserSettings", "CreateDate", c => c.DateTime());
            AlterColumn("dbo.UserSettings", "UpdateDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserSettings", "UpdateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.UserSettings", "CreateDate", c => c.DateTime(nullable: false));
        }
    }
}
