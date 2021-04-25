using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIUser.Models
{
    [Table("Discount")]
    public class Discount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID",TypeName ="int")]
        public int ID { get; set; }
        [Column("DiscountCode",TypeName ="varchar")]
        [StringLength(50)]
        public string DiscountCode { get; set; }
        [Column("DiscountPrice",TypeName ="int")]
        public int DiscountPrice { get; set; }
        [Column("Active",TypeName ="bit")]
        public bool Active { get; set; }

        public ICollection<Orders> Orders { get; set; }
    }
}
