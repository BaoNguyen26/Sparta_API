using System;
using System.Collections.Generic;

namespace API.Sparta.Models
{
    public partial class TbGioiThieu
    {
        public int GioithieuId { get; set; }
        public string GioithieuTieude { get; set; }
        public string GioithieuMota { get; set; }
        public string GioithieuNoidung { get; set; }
        public string GioithieuLink { get; set; }
        public string GioithieuHinhanh { get; set; }
        public DateTime? GioithieuNgaytao { get; set; }
    }
}
