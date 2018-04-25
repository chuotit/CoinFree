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

            //context.Users.AddOrUpdate(
            //    new User
            //    {
            //        FullName = "CongVT.BTC",
            //        Email = "congvt.btc@gmail.com",
            //        UserID = "13402140",
            //        WebAddress = "https://freebitco.in",
            //        CoinAddress = "12FW6jacTgqoWfvxkhJXixo2JW5tTryWNk",
            //        CoinType = "BTC",
            //        CoinAarned = "0.00000000",
            //        ReferID = "9719342",
            //        Note = "",
            //        CreateDate = DateTime.Now,
            //        UpdateDate = DateTime.Now,
            //        Status = true
            //    }
            //    );

            //context.UserSettings.AddOrUpdate(
            //    new UserSetting
            //    {
            //        Name = "Base_10",
            //        GameType = "base",
            //        Payout = 10,
            //        CoinAddress = "12FW6jacTgqoWfvxkhJXixo2JW5tTryWNk",
            //        BtcBetBase = "0.00000001",
            //        BetSpeed = "slow",
            //        BetMode = 1,
            //        BetProbe = 15,
            //        BtcPlus = "0.00000005",
            //        BetTarget = 2000,
            //        PercentIncrease = 70,
            //        IncreaseWhenLost = 3,
            //        WinLimit = 1,
            //        CreateDate = DateTime.Now,
            //        UpdateDate = DateTime.Now,
            //        Status = true
            //    }
            //);
            context.SaveChanges();
        }
    }
}
