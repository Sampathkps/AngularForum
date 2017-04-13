using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularForum.Models
{
    [Table("Forum")]
    public class ForumModel
    {
        [Key]
        public int ForumID { get; set; }

        [Required(ErrorMessage ="Subject Required")]
        public string Subject { get; set; }
        public int CategoryID { get; set; }
        public string PostedBy { get; set; }
        public string Description { get; set; }
        public DateTime ForumDate { get; set; }
    }
}