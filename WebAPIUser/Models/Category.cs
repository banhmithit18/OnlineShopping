using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID",TypeName ="int")]
        public int ID { get; set; }
        [Column("CategoryName",TypeName ="varchar")]
        [StringLength(50)]
        public string CategoryName { get; set; }
        [Column("Active",TypeName ="bit")]
        public bool Active { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
