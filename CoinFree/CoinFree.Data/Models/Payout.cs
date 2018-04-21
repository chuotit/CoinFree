using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinFree.Data.Models
{
    [Table("Payouts")]
    public class Payout
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        
        public double Value { set; get; }
        
        public int Order { set; get; }
    }
}
