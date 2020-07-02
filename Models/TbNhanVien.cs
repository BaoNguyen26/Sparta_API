using System;
using System.Collections.Generic;

namespace API.Sparta.Models
{
    public partial class TbNhanVien
    {
        public int NhanvienId { get; set; }
        public string NhanvienTen { get; set; }
        public string NhanvienDiachi { get; set; }
        public string NhanvienSodienthoai { get; set; }
        public string NhanvienMota { get; set; }
        public string NhanvienBophan { get; set; }
        public string NhanvienEmail { get; set; }
        public string NhanvienHinhanh { get; set; }
    }
}
