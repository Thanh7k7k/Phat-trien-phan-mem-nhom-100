using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Models
{
    public class HeThongPhanPhoi
    {
        [Key]
        [Required]
        public string MaHTPP { get; set; }

        [Required]
        [StringLength(100)]
        public string TenHTPP { get; set; }

        // Quan hệ 1 - n: Một HTPP có nhiều Đại Lý
        public ICollection<DaiLy> DaiLys { get; set; }
    }
}