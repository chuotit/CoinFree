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
            //context.Payouts.AddOrUpdate(
            //    new Payout { Value = 1, Order = 1 }
            //    );
            //context.SaveChanges();
        }
    }
}
