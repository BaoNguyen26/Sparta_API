using System;
using System.Collections.Generic;

namespace API.Sparta.Models
{
    public partial class TbKhachHangDanhGia
    {
        public int KhachhangdanhgiaId { get; set; }
        public string KhachhangdanhgiaTenkh { get; set; }
        public string KhachhangdanhgiaNghenghiep { get; set; }
        public string KhachhangdanhgiaHinhanh { get; set; }
        public string KhachhangdanhgiaNoidung { get; set; }
    }
}
