namespace CoinFree.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePayoutTable2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payouts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 5, unicode: false),
                        Value = c.String(maxLength: 5, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Payouts");
        }
    }
}
