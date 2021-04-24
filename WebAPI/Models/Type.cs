using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    [Table("Type")]
    public class Type
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID",TypeName="int")]
        public int ID { get; set; }
        
        [Column("TypeName",TypeName ="varchar")]
        [StringLength(50)]
        public string TypeName { get; set; }

        [Column("Active",TypeName ="bit")]
        public bool Active { get; set; }


    }
}
