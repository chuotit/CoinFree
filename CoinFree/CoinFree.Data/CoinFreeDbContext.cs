using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoinFree.Data.Models;

namespace CoinFree.Data
{
    public class CoinFreeDbContext : DbContext
    {
        public CoinFreeDbContext() : base("CoinFreeDB")
        {

        }

        public DbSet<User> Users { set; get; }
    }
}
