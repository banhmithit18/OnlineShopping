using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.ModelsAdmin
{
    [Table("Users")]
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("UserID",TypeName ="int")]
        public int UserID { get; set; }
        [Column("UserName",TypeName ="varchar")]
        [StringLength(500)]
        public string UserName { get; set; }
        [Column("UserPassword",TypeName ="varchar")]
        [StringLength(500)]
        public string UserPassword { get; set; }
        [Column("RegistrationDate",TypeName ="smalldatetime")]
        public DateTime RegistrationDate { get; set; }
        [Column("Status",TypeName ="bit")]
        public bool Status { get; set; }
    }
}
