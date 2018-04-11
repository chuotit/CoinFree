using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinFree.Data.Models
{
    [Table("Users")]
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [StringLength(50)]
        [Column(TypeName ="nvarchar")]
        [Required]
        public string FullName { set; get; }

        [StringLength(100)]
        [Column(TypeName = "nvarchar")]
        [Required]
        public string Email { set; get; }

        [StringLength(50)]
        [Required]
        public string UserID { set; get; }

        [StringLength(100)]
        [Required]
        public string WebAddress { set; get; }

        [StringLength(100)]
        [Required]
        public string CoinAddress { set; get; }

        [StringLength(10)]
        [Required]
        public string CoinType { set; get; }

        [StringLength(20)]
        public string CoinAarned { set; get; }

        [StringLength(50)]
        [Required]
        public string ReferID { set; get; }

        [Column(TypeName = "ntext")]
        [StringLength(10)]
        public string Note { set; get; }

        public DateTime CreateDate { set; get; }

        public DateTime UpdateDate { set; get; }

        public bool Status { set; get; }
    }
}
