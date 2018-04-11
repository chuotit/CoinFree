namespace CoinFree.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CoinFree.Data.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<CoinFree.Data.CoinFreeDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CoinFree.Data.CoinFreeDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Users.AddOrUpdate(
                new User { FullName = "Tiến Công", Email = "tiencong.com@gmail.com", UserID = "686868", WebAddress = "https://freebitco.in", CoinAddress = "1u24qFDvQ1VjPEBqZUjps1NJTaiUuomHw", CoinType = "BTC", CoinAarned = "0.00000001", ReferID = "797979", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, Status = true }
            );
            context.SaveChanges();
        }
    }
}
