using AngularForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularForum.ViewModel
{
    public class ForumViewModel
    {
        public int ForumID { get; set; }       
        public string Subject { get; set; }
        public string Description { get; set; }
        public string PostedBy { get; set; }
        public DateTime ForumDate { get; set; }
        public int CategoryID { get; set; }
    }
}