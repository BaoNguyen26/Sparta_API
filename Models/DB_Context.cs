using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.Sparta.Models
{
    public partial class DB_Context : DbContext
    {
        public DB_Context()
        {
        }

        public DB_Context(DbContextOptions<DB_Context> options)
            : base(options)
        {
        }

        public virtual DbSet<TbCamNang> TbCamNang { get; set; }
        public virtual DbSet<TbDoiTac> TbDoiTac { get; set; }
        public virtual DbSet<TbGioiThieu> TbGioiThieu { get; set; }
        public virtual DbSet<TbKhachHangDanhGia> TbKhachHangDanhGia { get; set; }
        public virtual DbSet<TbLienHe> TbLienHe { get; set; }
        public virtual DbSet<TbLoaiCamNang> TbLoaiCamNang { get; set; }
        public virtual DbSet<TbNhanVien> TbNhanVien { get; set; }
        public virtual DbSet<TbSlide> TbSlide { get; set; }
        public virtual DbSet<TbSuKien> TbSuKien { get; set; }
        public virtual DbSet<TbThongTinWeb> TbThongTinWeb { get; set; }
        public virtual DbSet<TbTinTuc> TbTinTuc { get; set; }
        public virtual DbSet<TbVideoHuongDan> TbVideoHuongDan { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=103.74.118.173,1433;Initial Catalog=admin_sparta;Persist Security Info=True;User ID=admin_sparta;Password=Qwerty123#!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "db_owner");

            modelBuilder.Entity<TbCamNang>(entity =>
            {
                entity.HasKey(e => e.CamnangId);

                entity.ToTable("tbCamNang", "dbo");

                entity.Property(e => e.CamnangId).HasColumnName("CAMNANG_ID");

                entity.Property(e => e.CamnangHinhanh)
                    .HasColumnName("CAMNANG_HINHANH")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.CamnangMota)
                    .HasColumnName("CAMNANG_MOTA")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.CamnangNgaytao)
                    .HasColumnName("CAMNANG_NGAYTAO")
                    .HasColumnType("date");

                entity.Property(e => e.CamnangNoidung)
                    .HasColumnName("CAMNANG_NOIDUNG")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.CamnangTieude)
                    .HasColumnName("CAMNANG_TIEUDE")
                    .HasMaxLength(50);

                entity.Property(e => e.LoaicamnangId).HasColumnName("LOAICAMNANG_ID");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");
            });

            modelBuilder.Entity<TbDoiTac>(entity =>
            {
                entity.HasKey(e => e.DoitacId);

                entity.ToTable("tbDoiTac", "dbo");

                entity.Property(e => e.DoitacId).HasColumnName("DOITAC_ID");

                entity.Property(e => e.DoitacHinhanh).HasColumnName("DOITAC_HINHANH");

                entity.Property(e => e.DoitacMota).HasColumnName("DOITAC_MOTA");

                entity.Property(e => e.DoitacTen).HasColumnName("DOITAC_TEN");
            });

            modelBuilder.Entity<TbGioiThieu>(entity =>
            {
                entity.HasKey(e => e.GioithieuId);

                entity.ToTable("tbGioiThieu", "dbo");

                entity.Property(e => e.GioithieuId).HasColumnName("GIOITHIEU_ID");

                entity.Property(e => e.GioithieuHinhanh).HasColumnName("GIOITHIEU_HINHANH");

                entity.Property(e => e.GioithieuLink).HasColumnName("GIOITHIEU_LINK");

                entity.Property(e => e.GioithieuMota).HasColumnName("GIOITHIEU_MOTA");

                entity.Property(e => e.GioithieuNgaytao)
                    .HasColumnName("GIOITHIEU_NGAYTAO")
                    .HasColumnType("date");

                entity.Property(e => e.GioithieuNoidung).HasColumnName("GIOITHIEU_NOIDUNG");

                entity.Property(e => e.GioithieuTieude).HasColumnName("GIOITHIEU_TIEUDE");
            });

            modelBuilder.Entity<TbKhachHangDanhGia>(entity =>
            {
                entity.HasKey(e => e.KhachhangdanhgiaId);

                entity.ToTable("tbKhachHangDanhGia", "dbo");

                entity.Property(e => e.KhachhangdanhgiaId).HasColumnName("KHACHHANGDANHGIA_ID");

                entity.Property(e => e.KhachhangdanhgiaHinhanh)
                    .HasColumnName("KHACHHANGDANHGIA_HINHANH")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.KhachhangdanhgiaNghenghiep)
                    .HasColumnName("KHACHHANGDANHGIA_NGHENGHIEP")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.KhachhangdanhgiaNoidung)
                    .HasColumnName("KHACHHANGDANHGIA_NOIDUNG")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.KhachhangdanhgiaTenkh)
                    .HasColumnName("KHACHHANGDANHGIA_TENKH")
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TbLienHe>(entity =>
            {
                entity.HasKey(e => e.LienheId);

                entity.ToTable("tbLienHe", "dbo");

                entity.Property(e => e.LienheId).HasColumnName("LIENHE_ID");

                entity.Property(e => e.LienheCoso).HasColumnName("LIENHE_COSO");

                entity.Property(e => e.LienheDiachi).HasColumnName("LIENHE_DIACHI");

                entity.Property(e => e.LienheDienthoai).HasColumnName("LIENHE_DIENTHOAI");

                entity.Property(e => e.LienheEmail).HasColumnName("LIENHE_EMAIL");

                entity.Property(e => e.LienheLinkfb).HasColumnName("LIENHE_LINKFB");

                entity.Property(e => e.LienheLinkgmap).HasColumnName("LIENHE_LINKGMAP");

                entity.Property(e => e.LienheLinkin).HasColumnName("LIENHE_LINKIN");

                entity.Property(e => e.LienheLinktw).HasColumnName("LIENHE_LINKTW");

                entity.Property(e => e.LienheTencose).HasColumnName("LIENHE_TENCOSE");
            });

            modelBuilder.Entity<TbLoaiCamNang>(entity =>
            {
                entity.HasKey(e => e.LoaicamnangId);

                entity.ToTable("tbLoaiCamNang", "dbo");

                entity.Property(e => e.LoaicamnangId).HasColumnName("LOAICAMNANG_ID");

                entity.Property(e => e.LoaicamnangTieude).HasColumnName("LOAICAMNANG_TIEUDE");
            });

            modelBuilder.Entity<TbNhanVien>(entity =>
            {
                entity.HasKey(e => e.NhanvienId);

                entity.ToTable("tbNhanVien", "dbo");

                entity.Property(e => e.NhanvienId).HasColumnName("NHANVIEN_ID");

                entity.Property(e => e.NhanvienBophan).HasColumnName("NHANVIEN_BOPHAN");

                entity.Property(e => e.NhanvienDiachi).HasColumnName("NHANVIEN_DIACHI");

                entity.Property(e => e.NhanvienEmail).HasColumnName("NHANVIEN_EMAIL");

                entity.Property(e => e.NhanvienHinhanh).HasColumnName("NHANVIEN_HINHANH");

                entity.Property(e => e.NhanvienMota).HasColumnName("NHANVIEN_MOTA");

                entity.Property(e => e.NhanvienSodienthoai).HasColumnName("NHANVIEN_SODIENTHOAI");

                entity.Property(e => e.NhanvienTen).HasColumnName("NHANVIEN_TEN");
            });

            modelBuilder.Entity<TbSlide>(entity =>
            {
                entity.HasKey(e => e.SlideId)
                    .HasName("PK_tbslide");

                entity.ToTable("tbSlide", "dbo");

                entity.Property(e => e.SlideId).HasColumnName("SLIDE_ID");

                entity.Property(e => e.SlideImage).HasColumnName("SLIDE_IMAGE");

                entity.Property(e => e.SlideLink).HasColumnName("SLIDE_LINK");

                entity.Property(e => e.SlideMota).HasColumnName("SLIDE_MOTA");

                entity.Property(e => e.SlideTieude).HasColumnName("SLIDE_TIEUDE");
            });

            modelBuilder.Entity<TbSuKien>(entity =>
            {
                entity.HasKey(e => e.SukienId);

                entity.ToTable("tbSuKien", "dbo");

                entity.Property(e => e.SukienId).HasColumnName("SUKIEN_ID");

                entity.Property(e => e.SukienDiachi).HasColumnName("SUKIEN_DIACHI");

                entity.Property(e => e.SukienMota).HasColumnName("SUKIEN_MOTA");

                entity.Property(e => e.SukienNgaygio)
                    .HasColumnName("SUKIEN_NGAYGIO")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TbThongTinWeb>(entity =>
            {
                entity.HasKey(e => e.ThongtinwebId);

                entity.ToTable("tbThongTinWeb", "dbo");

                entity.Property(e => e.ThongtinwebId).HasColumnName("THONGTINWEB_ID");

                entity.Property(e => e.ThongtinwebEmail).HasColumnName("THONGTINWEB_EMAIL");

                entity.Property(e => e.ThongtinwebFanpage).HasColumnName("THONGTINWEB_FANPAGE");

                entity.Property(e => e.ThongtinwebFblink).HasColumnName("THONGTINWEB_FBLINK");

                entity.Property(e => e.ThongtinwebGglink).HasColumnName("THONGTINWEB_GGLINK");

                entity.Property(e => e.ThongtinwebInlink).HasColumnName("THONGTINWEB_INLINK");

                entity.Property(e => e.ThongtinwebLogo).HasColumnName("THONGTINWEB_LOGO");

                entity.Property(e => e.ThongtinwebSodienthoai).HasColumnName("THONGTINWEB_SODIENTHOAI");

                entity.Property(e => e.ThongtinwebTwlink).HasColumnName("THONGTINWEB_TWLINK");
            });

            modelBuilder.Entity<TbTinTuc>(entity =>
            {
                entity.HasKey(e => e.TintucId);

                entity.ToTable("tbTinTuc", "dbo");

                entity.Property(e => e.TintucId).HasColumnName("TINTUC_ID");

                entity.Property(e => e.TintucHinhanh).HasColumnName("TINTUC_HINHANH");

                entity.Property(e => e.TintucMota).HasColumnName("TINTUC_MOTA");

                entity.Property(e => e.TintucNgaytao).HasColumnName("TINTUC_NGAYTAO");

                entity.Property(e => e.TintucNoidung).HasColumnName("TINTUC_NOIDUNG");

                entity.Property(e => e.TintucTieude).HasColumnName("TINTUC_TIEUDE");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");
            });

            modelBuilder.Entity<TbVideoHuongDan>(entity =>
            {
                entity.HasKey(e => e.VideohuongdanId);

                entity.ToTable("tbVideoHuongDan", "dbo");

                entity.Property(e => e.VideohuongdanId).HasColumnName("VIDEOHUONGDAN_ID");

                entity.Property(e => e.VideohuongdanHinhanh).HasColumnName("VIDEOHUONGDAN_HINHANH");

                entity.Property(e => e.VideohuongdanLinkvideo).HasColumnName("VIDEOHUONGDAN_LINKVIDEO");

                entity.Property(e => e.VideohuongdanTieude).HasColumnName("VIDEOHUONGDAN_TIEUDE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
