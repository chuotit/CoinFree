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
            context.Payouts.AddOrUpdate(
                new Payout { Value = 1, Order = 1},
                new Payout { Value = 1.5, Order = 2},
                new Payout { Value = 2, Order = 3},
                new Payout { Value = 2.5, Order = 4},
                new Payout { Value = 3, Order = 5},
                new Payout { Value = 3.5, Order = 6},
                new Payout { Value = 4, Order = 7},
                new Payout { Value = 5, Order = 8},
                new Payout { Value = 6, Order = 9},
                new Payout { Value = 7, Order = 10},
                new Payout { Value = 8, Order = 11},
                new Payout { Value = 9, Order = 12},
                new Payout { Value = 10, Order = 13},
                new Payout { Value = 11, Order = 14},
                new Payout { Value = 12, Order = 15},
                new Payout { Value = 13, Order = 16},
                new Payout { Value = 14, Order = 17},
                new Payout { Value = 15, Order = 18},
                new Payout { Value = 16, Order = 19},
                new Payout { Value = 17, Order = 20},
                new Payout { Value = 18, Order = 21},
                new Payout { Value = 19, Order = 22},
                new Payout { Value = 20, Order = 23},
                new Payout { Value = 21, Order = 24},
                new Payout { Value = 22, Order = 25},
                new Payout { Value = 23, Order = 26},
                new Payout { Value = 24, Order = 27},
                new Payout { Value = 25, Order = 28},
                new Payout { Value = 26, Order = 29},
                new Payout { Value = 27, Order = 30},
                new Payout { Value = 28, Order = 31},
                new Payout { Value = 29, Order = 32},
                new Payout { Value = 30, Order = 33},
                new Payout { Value = 31, Order = 34},
                new Payout { Value = 32, Order = 35},
                new Payout { Value = 33, Order = 36},
                new Payout { Value = 34, Order = 37},
                new Payout { Value = 35, Order = 38},
                new Payout { Value = 36, Order = 39},
                new Payout { Value = 37, Order = 40},
                new Payout { Value = 38, Order = 41},
                new Payout { Value = 39, Order = 42},
                new Payout { Value = 40, Order = 43},
                new Payout { Value = 41, Order = 44},
                new Payout { Value = 42, Order = 45},
                new Payout { Value = 43, Order = 46},
                new Payout { Value = 44, Order = 47},
                new Payout { Value = 45, Order = 48},
                new Payout { Value = 46, Order = 49},
                new Payout { Value = 47, Order = 50},
                new Payout { Value = 48, Order = 51},
                new Payout { Value = 49, Order = 52},
                new Payout { Value = 50, Order = 53},
                new Payout { Value = 51, Order = 54},
                new Payout { Value = 52, Order = 55},
                new Payout { Value = 53, Order = 56},
                new Payout { Value = 54, Order = 57},
                new Payout { Value = 55, Order = 58},
                new Payout { Value = 56, Order = 59},
                new Payout { Value = 57, Order = 60},
                new Payout { Value = 58, Order = 61},
                new Payout { Value = 59, Order = 62},
                new Payout { Value = 60, Order = 63},
                new Payout { Value = 61, Order = 64},
                new Payout { Value = 62, Order = 65},
                new Payout { Value = 63, Order = 66},
                new Payout { Value = 64, Order = 67},
                new Payout { Value = 65, Order = 68},
                new Payout { Value = 66, Order = 69},
                new Payout { Value = 67, Order = 70},
                new Payout { Value = 68, Order = 71},
                new Payout { Value = 69, Order = 72},
                new Payout { Value = 70, Order = 73},
                new Payout { Value = 71, Order = 74},
                new Payout { Value = 72, Order = 75},
                new Payout { Value = 73, Order = 76},
                new Payout { Value = 74, Order = 77},
                new Payout { Value = 75, Order = 78},
                new Payout { Value = 76, Order = 79},
                new Payout { Value = 77, Order = 80},
                new Payout { Value = 78, Order = 81},
                new Payout { Value = 79, Order = 82},
                new Payout { Value = 80, Order = 83},
                new Payout { Value = 81, Order = 84},
                new Payout { Value = 82, Order = 85},
                new Payout { Value = 83, Order = 86},
                new Payout { Value = 84, Order = 87},
                new Payout { Value = 85, Order = 88},
                new Payout { Value = 86, Order = 89},
                new Payout { Value = 87, Order = 90},
                new Payout { Value = 88, Order = 91},
                new Payout { Value = 89, Order = 92},
                new Payout { Value = 90, Order = 93},
                new Payout { Value = 91, Order = 94},
                new Payout { Value = 92, Order = 95},
                new Payout { Value = 93, Order = 96},
                new Payout { Value = 94, Order = 97},
                new Payout { Value = 95, Order = 98},
                new Payout { Value = 96, Order = 99},
                new Payout { Value = 97, Order = 100},
                new Payout { Value = 98, Order = 101},
                new Payout { Value = 99, Order = 102},
                new Payout { Value = 100, Order = 103}
                );

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
