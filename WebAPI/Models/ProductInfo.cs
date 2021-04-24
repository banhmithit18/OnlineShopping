using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    [Table("ProductInfo")]
    public class ProductInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID",TypeName ="int")]
        public int ID { get; set; }
        [Column("ProductID",TypeName ="int")]
        [ForeignKey("ProductID")]
        public Product Product { get; set; }
        public int ProductID { get; set; }

        [Column("Quantity",TypeName ="int")]
        public int Quantity { get; set; }
        [Column("Color",TypeName ="varchar")]
        [StringLength(20)]
        public string Color { get; set; }
        [Column("Size",TypeName ="varchar")]
        [StringLength(10)]
        public string Size { get; set; }
        [Column("Active",TypeName ="bit")]
        public bool Active { get; set; }

    }
}
