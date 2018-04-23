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

            //context.UserSettings.AddOrUpdate(
            //    new UserSetting
            //    {
            //        Name = "Base_3",
            //        GameType = "base",
            //        Payout = 3,
            //        CoinAddress = "12FW6jacTgqoWfvxkhJXixo2JW5tTryWNk",
            //        BtcBetBase = "0.00000001",
            //        BetSpeed = "slow",
            //        BetMode = 1,
            //        BetProbe = 5,
            //        BtcPlus = "0.00000010",
            //        BetTarget = 2000,
            //        PercentIncrease = 120,
            //        IncreaseWhenLost = 1,
            //        WinLimit = 1,
            //        CreateDate = DateTime.Now,
            //        UpdateDate = DateTime.Now,
            //        Status = true
            //    }
            //);
            //context.SaveChanges();
        }
    }
}
