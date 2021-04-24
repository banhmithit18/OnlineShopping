using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    [Table("UserInfor")]
    public class UserInfor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("UserInfoID",TypeName ="int")]
        public int UserInfoID { get; set; }

        [Column("FullName",TypeName ="varchar")]
        [StringLength(100)]
        public string FullName { get; set; }
        [Column("Age",TypeName ="tinyint")]
        public int Age { get; set; }

        [Column("Gender",TypeName ="varchar")]
        [StringLength(10)]
        public string Gender { get; set; }

        [Column("Email",TypeName ="varchar")]
        [StringLength(150)]
        public string Email { get; set; }

        [Column("Phone",TypeName ="varchar")]
        [StringLength(20)]
        public string Phone { get; set; }

        [Column("Address1",TypeName ="varchar")]
        [StringLength(100)]
        public string Address1 { get; set; }

        [Column("Address2",TypeName ="varchar")]
        [StringLength(100)]
        public string Address2 { get; set; }

        [Column("VIPRankID",TypeName ="int")]
        public int VIPRankID { get; set; }

        [Column("SpentAmount",TypeName ="float")]
        public float SpentAmount { get; set; }




    }
}
