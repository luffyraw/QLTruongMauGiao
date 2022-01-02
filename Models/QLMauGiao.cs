using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QuanLyTruongMauGiao.Models
{
    public partial class QLMauGiao : DbContext
    {
        public QLMauGiao()
            : base("name=QLMauGiao")
        {
        }

        public virtual DbSet<CHIPHI> CHIPHIs { get; set; }
        public virtual DbSet<DIEMDANH> DIEMDANHs { get; set; }
        public virtual DbSet<DONGCHIPHI> DONGCHIPHIs { get; set; }
        public virtual DbSet<GIAOVIEN> GIAOVIENs { get; set; }
        public virtual DbSet<KETQUADANHGIA> KETQUADANHGIAs { get; set; }
        public virtual DbSet<LOP> LOPs { get; set; }
        public virtual DbSet<NGAYDIHOC> NGAYDIHOCs { get; set; }
        public virtual DbSet<NOIDUNGDANHGIA> NOIDUNGDANHGIAs { get; set; }
        public virtual DbSet<PHANCONGGIAOVIEN> PHANCONGGIAOVIENs { get; set; }
        public virtual DbSet<PHIEUDANHGIA> PHIEUDANHGIAs { get; set; }
        public virtual DbSet<PHIEUTHUTIEN> PHIEUTHUTIENs { get; set; }
        public virtual DbSet<PHUHUYNH> PHUHUYNHs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }
        public virtual DbSet<THUCDONNGAY> THUCDONNGAYs { get; set; }
        public virtual DbSet<TRE> TREs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CHIPHI>()
                .Property(e => e.MaChiPhi)
                .IsUnicode(false);

            modelBuilder.Entity<CHIPHI>()
                .Property(e => e.DonGia)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CHIPHI>()
                .HasMany(e => e.DONGCHIPHIs)
                .WithRequired(e => e.CHIPHI)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DIEMDANH>()
                .Property(e => e.MaTre)
                .IsUnicode(false);

            modelBuilder.Entity<DONGCHIPHI>()
                .Property(e => e.MaPhieu)
                .IsUnicode(false);

            modelBuilder.Entity<DONGCHIPHI>()
                .Property(e => e.MaChiPhi)
                .IsUnicode(false);

            modelBuilder.Entity<GIAOVIEN>()
                .Property(e => e.MaGV)
                .IsUnicode(false);

            modelBuilder.Entity<GIAOVIEN>()
                .Property(e => e.DienThoai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GIAOVIEN>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<GIAOVIEN>()
                .Property(e => e.Luong)
                .HasPrecision(19, 4);

            modelBuilder.Entity<GIAOVIEN>()
                .Property(e => e.TenTK)
                .IsUnicode(false);

            modelBuilder.Entity<GIAOVIEN>()
                .HasMany(e => e.PHIEUDANHGIAs)
                .WithRequired(e => e.GIAOVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GIAOVIEN>()
                .HasMany(e => e.PHANCONGGIAOVIENs)
                .WithRequired(e => e.GIAOVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KETQUADANHGIA>()
                .Property(e => e.MaPhieu)
                .IsUnicode(false);

            modelBuilder.Entity<KETQUADANHGIA>()
                .Property(e => e.MaNDDG)
                .IsUnicode(false);

            modelBuilder.Entity<LOP>()
                .Property(e => e.MaLop)
                .IsUnicode(false);

            modelBuilder.Entity<LOP>()
                .HasMany(e => e.PHANCONGGIAOVIENs)
                .WithRequired(e => e.LOP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOP>()
                .HasMany(e => e.TREs)
                .WithRequired(e => e.LOP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NGAYDIHOC>()
                .HasMany(e => e.DIEMDANHs)
                .WithRequired(e => e.NGAYDIHOC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NOIDUNGDANHGIA>()
                .Property(e => e.MaNDDG)
                .IsUnicode(false);

            modelBuilder.Entity<NOIDUNGDANHGIA>()
                .HasMany(e => e.KETQUADANHGIAs)
                .WithRequired(e => e.NOIDUNGDANHGIA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHANCONGGIAOVIEN>()
                .Property(e => e.MaGV)
                .IsUnicode(false);

            modelBuilder.Entity<PHANCONGGIAOVIEN>()
                .Property(e => e.MaLop)
                .IsUnicode(false);

            modelBuilder.Entity<PHANCONGGIAOVIEN>()
                .Property(e => e.NamHoc)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUDANHGIA>()
                .Property(e => e.MaPhieu)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUDANHGIA>()
                .Property(e => e.MaTre)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUDANHGIA>()
                .Property(e => e.MaGV)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUDANHGIA>()
                .HasMany(e => e.KETQUADANHGIAs)
                .WithRequired(e => e.PHIEUDANHGIA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUTHUTIEN>()
                .Property(e => e.MaPhieu)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUTHUTIEN>()
                .Property(e => e.MaTre)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUTHUTIEN>()
                .HasMany(e => e.DONGCHIPHIs)
                .WithRequired(e => e.PHIEUTHUTIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHUHUYNH>()
                .Property(e => e.MaPH)
                .IsUnicode(false);

            modelBuilder.Entity<PHUHUYNH>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<PHUHUYNH>()
                .Property(e => e.TenTK)
                .IsUnicode(false);

            modelBuilder.Entity<PHUHUYNH>()
                .HasMany(e => e.TREs)
                .WithRequired(e => e.PHUHUYNH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.TenTK)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.AnhDaiDien)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .HasMany(e => e.GIAOVIENs)
                .WithRequired(e => e.TAIKHOAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .HasMany(e => e.PHUHUYNHs)
                .WithRequired(e => e.TAIKHOAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THUCDONNGAY>()
                .Property(e => e.MaTDN)
                .IsUnicode(false);

            modelBuilder.Entity<TRE>()
                .Property(e => e.MaTre)
                .IsUnicode(false);

            modelBuilder.Entity<TRE>()
                .Property(e => e.MaLop)
                .IsUnicode(false);

            modelBuilder.Entity<TRE>()
                .Property(e => e.MaPH)
                .IsUnicode(false);

            modelBuilder.Entity<TRE>()
                .Property(e => e.Anh)
                .IsUnicode(false);

            modelBuilder.Entity<TRE>()
                .HasMany(e => e.DIEMDANHs)
                .WithRequired(e => e.TRE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TRE>()
                .HasMany(e => e.PHIEUDANHGIAs)
                .WithRequired(e => e.TRE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TRE>()
                .HasMany(e => e.PHIEUTHUTIENs)
                .WithRequired(e => e.TRE)
                .WillCascadeOnDelete(false);
        }
    }
}
