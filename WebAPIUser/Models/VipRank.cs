using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIUser.Models
{
    [Table("VipRank")]
    public class VipRank
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID",TypeName ="int")]
        public int ID { get; set; }

        [Column("VipName",TypeName ="varchar")]
        [StringLength(50)]
        public string VipName { get; set; }

        [Column("DiscountPrice",TypeName ="int")]
        public int DiscountPrice { get; set; }

        [Column("Amount",TypeName ="float")]
        public float Amount { get; set; }

        [Column("Active",TypeName ="bit")]
        public bool Active { get; set; }

        public ICollection<UserInfor> UserInfors { get; set; }
    }
}
