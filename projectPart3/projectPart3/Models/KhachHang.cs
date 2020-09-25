using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectPart3.Models
{
    [Table("KhachHangs")]
    public class KhachHang
    {
        [Key]
        public int Ma_Khach_Hang { get; set; }
        
        public string Ten_Khach_Hang { get; set; }
        public int Gioi_Tinh { get; set; }
        public string Email { get; set; }
        public string Dien_Thoai { get; set; }

        [StringLength(255)]
        public string Dia_Chi { get; set; }
    }
}