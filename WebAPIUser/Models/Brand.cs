using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIUser.Models
{
    [Table("Brand")]
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID",TypeName ="int")]
        public int ID { get; set; }
        [Column("NameBrand",TypeName ="varchar")]
        [StringLength(50)]
        public string NameBrand { get; set; }
        [Column("Active",TypeName ="bit")]
        public bool Active { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
