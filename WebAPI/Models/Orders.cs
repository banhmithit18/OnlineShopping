using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    [Table("Orders")]
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID",TypeName ="int")]
        public int ID { get; set; }
        [Column("UserID",TypeName ="int")]
        [ForeignKey("UserID")]
        public Users Users { get; set; }
        public int UserID { get; set; }
        [Column("DiscountCodeID",TypeName ="int")]
        [ForeignKey("DiscountCodeID")]
        public Discount Discounts { get; set; }
        public int DiscountCodeID { get; set; }
        [Column("Total",TypeName ="float")]
        public float Total { get; set; }
        [Column("OrderDate",TypeName ="smalldatetime")]
        public DateTime OrderDate { get; set; }
        [Column("Active",TypeName ="bit")]
        public bool Active { get; set; }

        public ICollection<Orderdetail> Orderdetails { get; set; }
    }
}
