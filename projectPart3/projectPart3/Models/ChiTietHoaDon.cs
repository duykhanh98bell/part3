using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projectPart3.Models
{
    [Table("chitiethoadons")]
    public class ChiTietHoaDon
    {
        [Key]
        public int ma_hd_chi_tiet { get; set; }
        public int ma_hd { get; set; }

        [ForeignKey("ma_hd")]
        public virtual HoaDon hoadons { get; set; }
        public int ma_san_pham { get; set; }

        [ForeignKey("ma_san_pham")]
        public virtual SanPham sanphams { get; set; }
        public int so_luong { get; set; }
        public int gia_goc { get; set; }
        public int gia_khuyen_mai { get; set; }
        public DateTime ngay_tao { get; set; }

    }
}