using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projectPart3.Models
{
    [Table("DanhMucs")]
    public class DanhMuc
    {
        [Key]
        public int Ma_Danh_Muc { get; set; }
        public string Ten_Danh_Muc { get; set; }
    }
}