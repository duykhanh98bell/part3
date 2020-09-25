using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projectPart3.Models
{
    [Table("ChiTietHoaDons")]
    public class ChiTietHoaDon
    {
        [Key]
        public int Ma_HD_Chi_Tiet { get; set; }
        public int Ma_HD { get; set; }

        [ForeignKey("Ma_HD")]
        public virtual HoaDon HoaDons { get; set; }
        public int Ma_San_Pham { get; set; }

        [ForeignKey("Ma_San_Pham")]
        public virtual SanPham SanPhams { get; set; }
        public int So_Luong { get; set; }
        public int Gia_Goc { get; set; }
        public int Gia_Khuyen_Mai { get; set; }
        public DateTime Ngay_Tao { get; set; }

    }
}