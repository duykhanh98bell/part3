using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectPart3.Models
{
    [Table("khachhangs")]
    public class KhachHang
    {
        [Key]
        public int ma_khach_hang { get; set; }
        
        public string ten_khach_hang { get; set; }
        public int gioi_tinh { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string dien_thoai { get; set; }

        [StringLength(255)]
        public string dia_chi { get; set; }
    }
}