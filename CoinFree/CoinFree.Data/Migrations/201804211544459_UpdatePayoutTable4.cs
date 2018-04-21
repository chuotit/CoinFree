namespace CoinFree.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePayoutTable4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Payouts", "Value", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Payouts", "Value", c => c.String(maxLength: 5, unicode: false));
        }
    }
}
