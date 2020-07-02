using System;
using System.Collections.Generic;

namespace API.Sparta.Models
{
    public partial class TbTinTuc
    {
        public int TintucId { get; set; }
        public string TintucTieude { get; set; }
        public string TintucMota { get; set; }
        public string TintucNoidung { get; set; }
        public string TintucHinhanh { get; set; }
        public string TintucNgaytao { get; set; }
        public int? UserId { get; set; }
    }
}
