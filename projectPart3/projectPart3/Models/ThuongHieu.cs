using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projectPart3.Models
{
    [Table("ThuongHieus")]
    public class ThuongHieu
    {
        [Key]
        public int Ma_Thuong_Hieu { get; set; }
        public string Ten_Thuong_Hieu { get; set; }
    }
}