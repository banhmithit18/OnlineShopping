using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.ModelsAdmin
{
    [Table("Orderdetail")]
    public class Orderdetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID",TypeName ="int")]
        public int ID { get; set; }
        [Column("OrderID",TypeName ="int")]
        public int OrderID { get; set; }
        [Column("ProductID",TypeName ="int")]
        public int ProductID { get; set; }
        [Column("Price",TypeName ="float")]
        public float Price { get; set; }
        [Column("Quantity",TypeName ="int")]
        public int Quantity { get; set; }
    }
}
