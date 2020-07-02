using System;
using System.Collections.Generic;

namespace API.Sparta.Models
{
    public partial class TbCamNang
    {
        public int CamnangId { get; set; }
        public string CamnangTieude { get; set; }
        public string CamnangMota { get; set; }
        public string CamnangNoidung { get; set; }
        public string CamnangHinhanh { get; set; }
        public DateTime? CamnangNgaytao { get; set; }
        public int? UserId { get; set; }
        public int? LoaicamnangId { get; set; }
    }
}
