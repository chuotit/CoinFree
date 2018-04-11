namespace CoinFree.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 100),
                        UserID = c.String(nullable: false, maxLength: 50),
                        WebAddress = c.String(nullable: false, maxLength: 100),
                        CoinAddress = c.String(nullable: false, maxLength: 100),
                        CoinType = c.String(nullable: false, maxLength: 10),
                        CoinAarned = c.String(maxLength: 20),
                        ReferID = c.String(nullable: false, maxLength: 50),
                        Note = c.String(storeType: "ntext"),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
