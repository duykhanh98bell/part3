using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projectPart3.Models
{
    [Table("SanPhams")]
    public class SanPham
    {
        [Key]
        public int Ma_SP { get; set; }
        public int Ma_Gia { get; set; }

        [ForeignKey("Ma_Gia")]
        public virtual Gia Gias { get; set; }
        public int Ma_NCC { get; set; }

        [ForeignKey("Ma_NCC")]
        public virtual NhaCungCap NhaCungCaps { get; set; }
        public int Ma_Danh_Muc { get; set; }

        [ForeignKey("Ma_Danh_Muc")]
        public virtual DanhMuc DanhMucs { get; set; }
        public int Trang_Thai { get; set; }
        public string Ghi_Chu { get; set; }
        public string Xuat_Xu { get; set; }
        public string Mo_Ta { get; set; }
        public string Hinh_Anh { get; set; }
        public DateTime Ngay_Tao { get; set; }

    }
}