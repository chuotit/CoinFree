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

            //context.Payouts.AddOrUpdate(
            //    new Payout { Value = 1, Order = 1 },
            //    new Payout { Value = 1.5, Order = 2 },
            //    new Payout { Value = 2, Order = 3 },
            //    new Payout { Value = 2.5, Order = 4 },
            //    new Payout { Value = 3, Order = 5 },
            //    new Payout { Value = 4, Order = 6 },
            //    new Payout { Value = 5, Order = 7 },
            //    new Payout { Value = 6, Order = 8 },
            //    new Payout { Value = 7, Order = 9 },
            //    new Payout { Value = 8, Order = 10 },
            //    new Payout { Value = 9, Order = 11 },
            //    new Payout { Value = 10, Order = 12 }
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
