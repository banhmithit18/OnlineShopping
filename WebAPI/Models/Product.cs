using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID",TypeName ="int")]
        public int ID { get; set; }

        [Column("TypeID",TypeName ="int")]
        public int TypeID { get; set; }

        [Column("BrandID",TypeName ="int")]
        public int BrandID { get; set; }

        [Column("ProductName",TypeName ="varchar")]
        [StringLength(100)]
        public string ProductName { get; set; }

        [Column("Price",TypeName ="float")]
        public float Price { get; set; }

        [Column("ProductImage",TypeName ="varchar")]
        [StringLength(100)]
        public string ProductImage { get; set; }

        [Column("CategoryID",TypeName ="int")]
        public int CategoryID { get; set; }

        [Column("Descriptions",TypeName ="varchar")]
        [StringLength(500)]
        public string Descriptions { get; set; }

        [Column("ProductUpdateDate",TypeName ="smalldatetime")]
        public DateTime ProductUpdateDate { get; set; }

        [Column("Active",TypeName ="bit")]
        public bool Active { get; set; }



    }
}
