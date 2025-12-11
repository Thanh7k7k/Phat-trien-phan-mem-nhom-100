using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoMVC.Models
{
    public class DaiLy
    {
        [Key]
        [Required]
        public string MaDaiLy { get => field; set => field = value; }

        [Required]
        [StringLength(100)]
        public string TenDaiLy { get; set; }

        [StringLength(200)]
        public string DiaChi { get; set; }

        [StringLength(100)]
        public string NguoiDaiDien { get; set; }

        [Phone]
        public string DienThoai { get; set; }

        [Required]
        [ForeignKey("HeThongPhanPhoi")]
        public string MaHTPP { get; set; }

        // Khóa ngoại liên kết đến HeThongPhanPhoi
        public HeThongPhanPhoi HeThongPhanPhoi { get; set; }
    }
}
