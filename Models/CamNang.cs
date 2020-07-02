using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Sparta.Models
{
    public class CamNang
    {
        public int CamnangId { get; set; }
        public string CamnangTieude { get; set; }
        public string CamnangMota { get; set; }
        public string CamnangNoidung { get; set; }
        public string CamnangHinhanh { get; set; }
        public int? LoaicamnangId { get; set; }
        public string LoaicamnangTieude { get; set; }
    }
}
