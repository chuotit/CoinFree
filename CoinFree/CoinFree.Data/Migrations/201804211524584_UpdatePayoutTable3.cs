namespace CoinFree.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePayoutTable3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payouts", "Order", c => c.Int(nullable: false));
            DropColumn("dbo.Payouts", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payouts", "Name", c => c.String(maxLength: 5, unicode: false));
            DropColumn("dbo.Payouts", "Order");
        }
    }
}
