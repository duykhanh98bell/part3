using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projectPart3.Models
{
    [Table("Gias")]
    public class Gia
    {
        [Key]
        public int Ma_Gia { get; set; }
        public int Gia_Goc { get; set; }
        public int Gia_Khuyen_Mai { get; set; }
        public DateTime Ngay_Ap_Dung { get; set; }
    }
}