using System;
using System.Collections.Generic;

namespace API.Sparta.Models
{
    public partial class TbSuKien
    {
        public int SukienId { get; set; }
        public DateTime? SukienNgaygio { get; set; }
        public string SukienDiachi { get; set; }
        public string SukienMota { get; set; }
    }
}
