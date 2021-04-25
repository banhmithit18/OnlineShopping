using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIUser.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID",TypeName ="int")]
        public int ID { get; set; }

        [Column("TypeID",TypeName ="int")]
        [ForeignKey("TypeID")]
        public Type Types { get; set; }
        public int TypeID { get; set; }

        [Column("BrandID",TypeName ="int")]
        [ForeignKey("BrandID")]
        public Brand Brands { get; set; }
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
        [ForeignKey("CategoryID")]
        public Category Categories { get; set; }
        public int CategoryID { get; set; }

        [Column("Descriptions",TypeName ="varchar")]
        [StringLength(500)]
        public string Descriptions { get; set; }

        [Column("ProductUpdateDate",TypeName ="smalldatetime")]
        public DateTime ProductUpdateDate { get; set; }

        [Column("Active",TypeName ="bit")]
        public bool Active { get; set; }

        public ICollection<ProductInfo> ProductInfos { get; set; }



    }
}
