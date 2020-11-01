using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projectPart3.Models
{
    [Table("admins")]
    public class Admin
    {
        [Key]
        public int ma_admin { get; set; }
        public string tai_khoan { get; set; }
        public string mat_khau { get; set; }
    }
}