using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIUser.Models
{
    [Table("Orderdetail")]
    public class Orderdetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID",TypeName ="int")]
        public int ID { get; set; }
        [Column("OrderID",TypeName ="int")]
        [ForeignKey("OrderID")]
        public Orders Orders { get; set; }
        public int OrderID { get; set; }
        [Column("ProductInfoID",TypeName ="int")]
        [ForeignKey("ProductInfoID")]
        public ProductInfo ProductInfos { get; set; }
        public int ProductInfoID { get; set; }
        [Column("Price",TypeName ="float")]
        public float Price { get; set; }
        [Column("Quantity",TypeName ="int")]
        public int Quantity { get; set; }
    }
}
