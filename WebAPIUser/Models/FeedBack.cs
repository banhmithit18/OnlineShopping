using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    [Table("FeedBack")]
    public class FeedBack
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID",TypeName ="int")]
        public int ID { get; set; }
        [Column("Subject",TypeName ="varchar")]
        [StringLength(500)]
        public string Subject { get; set; }
        [Column("Message",TypeName ="varchar")]
        public string Message { get; set; }
        [Column("Name",TypeName ="varchar")]
        [StringLength(150)]
        public string Name { get; set; }
        [Column("ContactNumber",TypeName ="varchar")]
        [StringLength(20)]
        public string ContactNumber { get; set; }
        [Column("Email",TypeName ="varchar")]
        [StringLength(150)]
        public string Email { get; set; }
        [Column("ReceivedDate",TypeName ="smalldatetime")]
        public DateTime ReceivedDate { get; set; }

        [Column("Status",TypeName ="bit")]
        public bool Status { get; set; }

    }
}
