using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinFree.Data.Models
{
    [Table("UserSettings")]
    public class UserSetting
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        public string Name { set; get; }

        public string GameType { set; get; }

        public double Payout { set; get; }

        [StringLength(50)]
        [Required]
        public string CoinAddress { set; get; }

        [StringLength(20)]
        public string BtcBetBase { set; get; }

        public string BetSpeed { set; get; }

        public int BetMode { set; get; }

        public int BetProbe { set; get; }

        [StringLength(20)]
        public string BtcPlus { set; get; }

        public int BetTarget { set; get; }

        public int PercentIncrease { set; get; }

        public int IncreaseWhenLost { set; get; }

        public int WinLimit { set; get; }

        public DateTime? CreateDate { set; get; }

        public DateTime? UpdateDate { set; get; }

        public bool Status { set; get; }
    }
}
