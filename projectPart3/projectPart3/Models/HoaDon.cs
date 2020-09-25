using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace projectPart3.Models
{
    [Table("HoaDons")]
    public class HoaDon
    {
        [Key]
        public int Ma_HD { get; set; }
        public int Ma_KH { get; set;  }
        public int Tong_Tien { get; set; }
        public int Trang_Thai { get; set; }
        public string Ghi_Chu { get; set; }
        public DateTime Ngay_Tao { get; set; }

        [ForeignKey("Ma_KH")]
        public virtual KhachHang KhachHangs { get; set; }
    }
}