﻿USE master
GO
IF  EXISTS (SELECT name 
			FROM sys.databases 
			WHERE name = 'QLTruongMauGiao')
	DROP DATABASE QLTruongMauGiao
CREATE DATABASE QLTruongMauGiao
GO
USE QLTruongMauGiao
GO
CREATE TABLE LOP
(
	MaLop varchar(5) PRIMARY KEY,
	TenLop nvarchar(50) not null,
	SiSo int not null,
	DoTuoi int not null,
	Khoi nvarchar(20) not null
)
Select * FROM LOP
INSERT INTO LOP VALUES ('LOP01', N'Mầm 1', 20, 3, N'Mầm')
INSERT INTO LOP VALUES ('LOP02', N'Mầm 2', 21, 3, N'Mầm')
INSERT INTO LOP VALUES ('LOP03', N'Chồi 1', 23, 4, N'Chồi')
INSERT INTO LOP VALUES ('LOP04', N'Chồi 2', 22, 4, N'Chồi')
INSERT INTO LOP VALUES ('LOP05', N'Lá 1', 19, 5, N'Lá')
INSERT INTO LOP VALUES ('LOP06', N'Lá 2', 20, 5, N'Lá')


CREATE TABLE TAIKHOAN
(
	TenTK varchar(20) PRIMARY KEY,
	MatKhau varchar(30) not null,
	PhanQuyen nvarchar(30) not null,
	TrangThaiHD bit not null,
	AnhDaiDien varchar(30) not null
)
INSERT INTO TAIKHOAN VALUES ('Admin', 'admin', N'Quản lý', 0, 'default.png')
INSERT INTO TAIKHOAN VALUES ('gv001', 'gv001', N'Giáo viên', 0, 'default.png')
INSERT INTO TAIKHOAN VALUES ('gv002', 'gv002', N'Giáo viên', 0, 'default.png')
INSERT INTO TAIKHOAN VALUES ('gv003', 'gv003', N'Giáo viên', 0, 'default.png')
INSERT INTO TAIKHOAN VALUES ('gv004', 'gv004', N'Giáo viên', 0, 'default.png')
INSERT INTO TAIKHOAN VALUES ('gv005', 'gv005', N'Giáo viên', 0, 'default.png')
INSERT INTO TAIKHOAN VALUES ('gv006', 'gv006', N'Giáo viên', 0, 'default.png')
INSERT INTO TAIKHOAN VALUES ('gv007', 'gv007', N'Giáo viên', 0, 'default.png')
INSERT INTO TAIKHOAN VALUES ('gv008', 'gv008', N'Giáo viên', 0, 'default.png')
INSERT INTO TAIKHOAN VALUES ('gv009', 'gv009', N'Giáo viên', 0, 'default.png')
INSERT INTO TAIKHOAN VALUES ('gv010', 'gv010', N'Giáo viên', 0, 'default.png')
INSERT INTO TAIKHOAN VALUES ('gv011', 'gv011', N'Giáo viên', 0, 'default.png')
INSERT INTO TAIKHOAN VALUES ('gv012', 'gv012', N'Giáo viên', 0, 'default.png')

INSERT INTO TAIKHOAN VALUES ('ph001', '123456', N'Phụ huynh', 0, 'default.png')
INSERT INTO TAIKHOAN VALUES ('ph002', '123456', N'Phụ huynh', 0, 'default.png')
INSERT INTO TAIKHOAN VALUES ('ph003', '123456', N'Phụ huynh', 0, 'default.png')
INSERT INTO TAIKHOAN VALUES ('ph004', '123456', N'Phụ huynh', 0, 'default.png')
INSERT INTO TAIKHOAN VALUES ('ph005', '123456', N'Phụ huynh', 0, 'default.png')
INSERT INTO TAIKHOAN VALUES ('ph006', '123456', N'Phụ huynh', 0, 'default.png')
INSERT INTO TAIKHOAN VALUES ('ph007', '123456', N'Phụ huynh', 0, 'default.png')
INSERT INTO TAIKHOAN VALUES ('ph008', '123456', N'Phụ huynh', 0, 'default.png')
INSERT INTO TAIKHOAN VALUES ('ph009', '123456', N'Phụ huynh', 0, 'default.png')
INSERT INTO TAIKHOAN VALUES ('ph010', '123456', N'Phụ huynh', 0, 'default.png')
INSERT INTO TAIKHOAN VALUES ('ph011', '123456', N'Phụ huynh', 0, 'default.png')
INSERT INTO TAIKHOAN VALUES ('ph012', '123456', N'Phụ huynh', 0, 'default.png')
INSERT INTO TAIKHOAN VALUES ('ph013', '123456', N'Phụ huynh', 0, 'default.png')
INSERT INTO TAIKHOAN VALUES ('ph014', '123456', N'Phụ huynh', 0, 'default.png')
INSERT INTO TAIKHOAN VALUES ('ph015', '123456', N'Phụ huynh', 0, 'default.png')
INSERT INTO TAIKHOAN VALUES ('ph016', '123456', N'Phụ huynh', 0, 'default.png')
INSERT INTO TAIKHOAN VALUES ('ph017', '123456', N'Phụ huynh', 0, 'default.png')
INSERT INTO TAIKHOAN VALUES ('ph018', '123456', N'Phụ huynh', 0, 'default.png')
INSERT INTO TAIKHOAN VALUES ('ph019', '123456', N'Phụ huynh', 0, 'default.png')
INSERT INTO TAIKHOAN VALUES ('ph020', '123456', N'Phụ huynh', 0, 'default.png')
INSERT INTO TAIKHOAN VALUES ('ph021', '123456', N'Phụ huynh', 0, 'default.png')
INSERT INTO TAIKHOAN VALUES ('ph022', '123456', N'Phụ huynh', 0, 'default.png')
INSERT INTO TAIKHOAN VALUES ('ph023', '123456', N'Phụ huynh', 0, 'default.png')
INSERT INTO TAIKHOAN VALUES ('ph024', '123456', N'Phụ huynh', 0, 'default.png')
INSERT INTO TAIKHOAN VALUES ('ph025', '123456', N'Phụ huynh', 0, 'default.png')
INSERT INTO TAIKHOAN VALUES ('ph026', '123456', N'Phụ huynh', 0, 'default.png')
INSERT INTO TAIKHOAN VALUES ('ph027', '123456', N'Phụ huynh', 0, 'default.png')
INSERT INTO TAIKHOAN VALUES ('ph028', '123456', N'Phụ huynh', 0, 'default.png')
INSERT INTO TAIKHOAN VALUES ('ph029', '123456', N'Phụ huynh', 0, 'default.png')



CREATE TABLE GIAOVIEN
(
	MaGV varchar(5) PRIMARY KEY,
	TenGV nvarchar(100) not null,
	NgaySinh Date not null,
	GioiTinh bit not null,
	QueQuan nvarchar(30) not null,
	DienThoai char(15) not null,
	Email varchar(100) not null,
	LoaiHopDong nvarchar(30) not null,
	Luong money not null,
	KinhNghiem nvarchar(30) not null,
	TrinhDo nvarchar(30) not null,
	ChuyenNganh nvarchar(30) not null,
	LoaiTotNghiep nvarchar(30) not null,
	TenTK varchar(20) not null, 
	CONSTRAINT fk_fv_tk FOREIGN KEY(TenTK) REFERENCES TAIKHOAN(TenTK),
)
INSERT INTO GIAOVIEN VALUES ('gv001',N'Nguyễn Thu Huyền','1990/05/20',0,N'Hà Nội','0395231832','thuhuyen@gmail.com',N'Biên chế',6000000,N'5 năm',N'Cao đẳng',N'Mầm non',N'Giỏi','gv001')
INSERT INTO GIAOVIEN VALUES ('gv002',N'Nguyễn Thị Hà','1991/07/10',0,N'Hà Nội','0395482752','NguyenHa@gmail.com',N'Biên chế',5500000,N'4 năm',N'Cao đẳng',N'Mầm non',N'Giỏi','gv002')
INSERT INTO GIAOVIEN VALUES ('gv003',N'Đặng Thị Thu Trang','1990/10/11',0,N'Hà Nội','0983059483','thuTrang@gmail.com',N'Biên chế',8000000,N'10 năm',N'Cao đẳng',N'Mầm non',N'Khá','gv003')
INSERT INTO GIAOVIEN VALUES ('gv004',N'Lê Thị Hà','1992/07/20',0,N'Hà Nội','09862871582','HaLe2007@gmail.com',N'Biên chế',5000000,N'3 năm',N'Cao đẳng',N'Mầm non',N'Giỏi','gv004')
INSERT INTO GIAOVIEN VALUES ('gv005',N'Đặng Thiên Kim','1993/08/20',0,N'Hà Nội','098628562182','DTK98@gmail.com',N'Biên chế',4500000,N'4 năm',N'Cao đẳng',N'Mầm non',N'Giỏi','gv005')
INSERT INTO GIAOVIEN VALUES ('gv006',N'Hoàng Ngọc Hạnh','1994/10/21',0,N'Hà Nội','09862621582','ngochanh@gmail.com',N'Biên chế',4800000,N'7 năm',N'Cao đẳng',N'Mầm non',N'Khá','gv006')
INSERT INTO GIAOVIEN VALUES ('gv007',N'Ngô Ngọc Diễm','1990/05/09',0,N'Hà Nội','09862871561','NND1998@gmail.com',N'Biên chế',6000000,N'10 năm',N'Cao đẳng',N'Mầm non',N'Khá','gv007')
INSERT INTO GIAOVIEN VALUES ('gv008',N'Liêu Anh Ðào','1991/04/20',0,N'Hà Nội','09862871121','DaoAnh@gmail.com',N'Biên chế',6000000,N'9 năm',N'Cao đẳng',N'Mầm non',N'Giỏi','gv008')
INSERT INTO GIAOVIEN VALUES ('gv009',N'Đoạn Bảo Trúc','1992/03/18',0,N'Hà Nội','09862871761','Baotruc@gmail.com',N'Biên chế',6000000,N'8 năm',N'Cao đẳng',N'Mầm non',N'Khá','gv009')
INSERT INTO GIAOVIEN VALUES ('gv010',N'Đinh Huệ Lan','1993/02/16',0,N'Hà Nội','09862871191','huelan@gmail.com',N'Biên chế',6000000,N'7 năm',N'Cao đẳng',N'Mầm non',N'Giỏi','gv010')
INSERT INTO GIAOVIEN VALUES ('gv011',N'Trương Minh Vy','1994/01/14',0,N'Hà Nội','09862201561','minhvi@gmail.com',N'Biên chế',6000000,N'6 năm',N'Cao đẳng',N'Mầm non',N'Khá','gv011')
INSERT INTO GIAOVIEN VALUES ('gv012',N'Phan Thạch Thảo','1995/12/12',0,N'Hà Nội','09820871561','thachthao@gmail.com',N'Biên chế',6000000,N'5 năm',N'Cao đẳng',N'Mầm non',N'Khá','gv012')

CREATE TABLE PHANCONGGIAOVIEN
(
	MaGV varchar(5) not null,
	MaLop varchar(5) not null,
	NamHoc int not null,
	PRIMARY KEY (MaGV,MaLop),
	CONSTRAINT fk_pc_gv FOREIGN KEY(MaGV) REFERENCES GIAOVIEN(MaGV),
	CONSTRAINT fk_pc_Lop FOREIGN KEY(MaLop) REFERENCES LOP(MaLop),
)

INSERT INTO PHANCONGGIAOVIEN VALUES ('gv001','LOP01',2021)
INSERT INTO PHANCONGGIAOVIEN VALUES ('gv002','LOP01',2021)
INSERT INTO PHANCONGGIAOVIEN VALUES ('gv003','LOP02',2021)
INSERT INTO PHANCONGGIAOVIEN VALUES ('gv004','LOP02',2021)
INSERT INTO PHANCONGGIAOVIEN VALUES ('gv005','LOP03',2021)
INSERT INTO PHANCONGGIAOVIEN VALUES ('gv006','LOP03',2021)
INSERT INTO PHANCONGGIAOVIEN VALUES ('gv007','LOP04',2021)
INSERT INTO PHANCONGGIAOVIEN VALUES ('gv008','LOP04',2021)
INSERT INTO PHANCONGGIAOVIEN VALUES ('gv009','LOP05',2021)
INSERT INTO PHANCONGGIAOVIEN VALUES ('gv010','LOP05',2021)
INSERT INTO PHANCONGGIAOVIEN VALUES ('gv011','LOP06',2021)
INSERT INTO PHANCONGGIAOVIEN VALUES ('gv012','LOP06',2021)


CREATE TABLE PHUHUYNH
(
	MaPH varchar(5) PRIMARY KEY,
	TenPH nvarchar(50) not null,
	NamSinh date not null,
	GioiTinh bit not null,
	DiaChi nvarchar(100) not null,
	DienThoai varchar(15) not null,
	TenTK varchar(20) not null,
	CONSTRAINT fkphv_tk FOREIGN KEY(TenTK) REFERENCES TAIKHOAN(TenTK),
)
INSERT INTO PHUHUYNH VALUES ('ph001',N'Đặng Văn Sơn','1980/03/1',1,N'Hà Nội', '0391865281','ph001')
INSERT INTO PHUHUYNH VALUES ('ph002',N'Đặng Văn Tùng','1981/04/12',1,N'Hà Nội', '0391265281','ph002')
INSERT INTO PHUHUYNH VALUES ('ph003',N'Đặng Văn Thắng','1982/05/13',1,N'Hà Nội', '0391165281','ph003')
INSERT INTO PHUHUYNH VALUES ('ph004',N'Đặng Văn Tú','1983/06/14',1,N'Hà Nội', '0391865121','ph004')
INSERT INTO PHUHUYNH VALUES ('ph005',N'Đặng Văn Bá','1984/07/15',1,N'Hà Nội', '03918657211','ph005')
INSERT INTO PHUHUYNH VALUES ('ph006',N'Đặng Văn Hạnh','1985/09/16',1,N'Hà Nội', '0391862281','ph006')
INSERT INTO PHUHUYNH VALUES ('ph007',N'Đặng Văn Tài','1986/08/17',1,N'Hà Nội', '0391812781','ph007')
INSERT INTO PHUHUYNH VALUES ('ph008',N'Đặng Văn Toàn','1987/12/18',1,N'Hà Nội', '0391261281','ph008')
INSERT INTO PHUHUYNH VALUES ('ph009',N'Đặng Văn Quang','1988/11/19',1,N'Hà Nội', '0391861271','ph009')
INSERT INTO PHUHUYNH VALUES ('ph010',N'Đặng Văn Quang','1988/11/19',1,N'Hà Nội', '0391861271','ph009')
INSERT INTO PHUHUYNH VALUES ('ph011',N'Đặng Văn Quang','1988/11/19',1,N'Hà Nội', '0391861271','ph009')
INSERT INTO PHUHUYNH VALUES ('ph012',N'Đặng Văn Quang','1988/11/19',1,N'Hà Nội', '0391861271','ph009')
INSERT INTO PHUHUYNH VALUES ('ph013',N'Đặng Văn Quang','1988/11/19',1,N'Hà Nội', '0391861271','ph009')
INSERT INTO PHUHUYNH VALUES ('ph014',N'Đặng Văn Quang','1988/11/19',1,N'Hà Nội', '0391861271','ph009')
INSERT INTO PHUHUYNH VALUES ('ph015',N'Đặng Văn Quang','1988/11/19',1,N'Hà Nội', '0391861271','ph009')
INSERT INTO PHUHUYNH VALUES ('ph016',N'Đặng Văn Quang','1988/11/19',1,N'Hà Nội', '0391861271','ph009')


CREATE TABLE NOIDUNGDANHGIA
(
	MaNDDG varchar(5) PRIMARY KEY,
	NoiDungDanhGia nvarchar(300) not null
)
INSERT INTO NOIDUNGDANHGIA VALUES('ND001',N'Thể chất')
INSERT INTO NOIDUNGDANHGIA VALUES('ND002',N'Sức khỏe')
INSERT INTO NOIDUNGDANHGIA VALUES('ND003',N'Hòa đồng')

CREATE TABLE THUCDONNGAY
(
	MaTDN varchar(10) PRIMARY KEY,
	Ngay Date not null,
	BuaSang nvarchar(500) not null,
	BuaTrua nvarchar(500) not null,
	BuaXe nvarchar(500) not null,
)
INSERT INTO THUCDONNGAY VALUES ('TDN01','2021/09/06',N'Bánh mì',N'Cơm',N'Sữa')
INSERT INTO THUCDONNGAY VALUES ('TDN02','2021/09/07',N'Bánh mì',N'Cơm',N'Sữa')
INSERT INTO THUCDONNGAY VALUES ('TDN03','2021/09/08',N'Bánh mì',N'Cơm',N'Sữa')
INSERT INTO THUCDONNGAY VALUES ('TDN04','2021/09/09',N'Bánh mì',N'Cơm',N'Sữa')
INSERT INTO THUCDONNGAY VALUES ('TDN05','2021/09/10',N'Bánh mì',N'Cơm',N'Sữa')
INSERT INTO THUCDONNGAY VALUES ('TDN06','2021/09/11',N'Bánh mì',N'Cơm',N'Sữa')
INSERT INTO THUCDONNGAY VALUES ('TDN07','2021/09/12',N'Bánh mì',N'Cơm',N'Sữa')
INSERT INTO THUCDONNGAY VALUES ('TDN08','2021/09/13',N'Bánh mì',N'Cơm',N'Sữa')
INSERT INTO THUCDONNGAY VALUES ('TDN09','2021/09/14',N'Bánh mì',N'Cơm',N'Sữa')
INSERT INTO THUCDONNGAY VALUES ('TDN10','2021/09/15',N'Bánh mì',N'Cơm',N'Sữa')
INSERT INTO THUCDONNGAY VALUES ('TDN11','2021/09/16',N'Bánh mì',N'Cơm',N'Sữa')
INSERT INTO THUCDONNGAY VALUES ('TDN12','2021/09/17',N'Bánh mì',N'Cơm',N'Sữa')
INSERT INTO THUCDONNGAY VALUES ('TDN13','2021/09/18',N'Bánh mì',N'Cơm',N'Sữa')
INSERT INTO THUCDONNGAY VALUES ('TDN14','2021/09/19',N'Bánh mì',N'Cơm',N'Sữa')
INSERT INTO THUCDONNGAY VALUES ('TDN15','2021/09/20',N'Bánh mì',N'Cơm',N'Sữa')


CREATE TABLE CHIPHI
(
	MaChiPhi varchar(5) PRIMARY KEY,
	NoiDung nvarchar(100) not null,
	DonGia money not null,
)
INSERT INTO CHIPHI VALUES ('CP001',N'Học phí',2000000)
INSERT INTO CHIPHI VALUES ('CP002',N'Ăn',1000000)
INSERT INTO CHIPHI VALUES ('CP003',N'Vật tư',500000)

CREATE TABLE NGAYDIHOC
(
	Ngay Date PRIMARY KEY
)

INSERT INTO NGAYDIHOC VALUES ('2021/09/06')
INSERT INTO NGAYDIHOC VALUES ('2021/09/07')
INSERT INTO NGAYDIHOC VALUES ('2021/09/08')
INSERT INTO NGAYDIHOC VALUES ('2021/09/09')
INSERT INTO NGAYDIHOC VALUES ('2021/09/10')
INSERT INTO NGAYDIHOC VALUES ('2021/09/11')
INSERT INTO NGAYDIHOC VALUES ('2021/09/12')
INSERT INTO NGAYDIHOC VALUES ('2021/09/13')
INSERT INTO NGAYDIHOC VALUES ('2021/09/14')
INSERT INTO NGAYDIHOC VALUES ('2021/09/15')
INSERT INTO NGAYDIHOC VALUES ('2021/09/16')
INSERT INTO NGAYDIHOC VALUES ('2021/09/17')
INSERT INTO NGAYDIHOC VALUES ('2021/09/18')
INSERT INTO NGAYDIHOC VALUES ('2021/09/19')
INSERT INTO NGAYDIHOC VALUES ('2021/09/20')

CREATE TABLE TRE
(
	MaTre varchar(5) PRIMARY KEY,
	MaLop varchar(5) not null,
	MaPH varchar(5) not null,
	TenTre nvarchar(100) not null,
	NgaySinh Date not null,
	GioiTinh bit not null,
	QueQuan nvarchar(50) not null,
	DanToc nvarchar(30) not null,
	NgayNhapHoc datetime not null,
	Anh varchar(30) not null
	CONSTRAINT fk_TRE_LOP FOREIGN KEY (MaLop) REFERENCES LOP(MaLop),
	CONSTRAINT fk_TRE_PH FOREIGN KEY (MaPH) REFERENCES PHUHUYNH(MaPH) 
)

INSERT INTO TRE VALUES ('TRE01','LOP01','ph001',N'Nguyễn Văn Tuấn','2018/02/01',1,N'Hà Nội',N'Kinh','2021/01/10','default.png')
INSERT INTO TRE VALUES ('TRE02','LOP01','ph002',N'Nguyễn Văn Tài','2018/10/02',1,N'Hà Nội',N'Kinh','2021/01/10','default.png')
INSERT INTO TRE VALUES ('TRE03','LOP02','ph003',N'Trần Văn An','2018/08/03',1,N'Hà Nội',N'Kinh','2021/01/10','default.png')
INSERT INTO TRE VALUES ('TRE04','LOP02','ph004',N'Hoàng Văn Tỉnh','2018/06/04',1,N'Hà Nội',N'Kinh','2021/01/10','default.png')
INSERT INTO TRE VALUES ('TRE05','LOP03','ph005',N'Đinh Mạnh Tiến','2018/04/05',1,N'Hà Nội',N'Kinh','2021/01/10','default.png')
INSERT INTO TRE VALUES ('TRE06','LOP03','ph006',N'Nguyễn Thành Công','2018/03/07',1,N'Hà Nội',N'Kinh','2021/01/10','default.png')
INSERT INTO TRE VALUES ('TRE07','LOP04','ph007',N'Nguyễn Tiến Lên','2019/10/21',1,N'Hà Nội',N'Kinh','2021/01/10','default.png')
INSERT INTO TRE VALUES ('TRE08','LOP05','ph008',N'Nguyễn Văn Long','2019/11/22',1,N'Hà Nội',N'Kinh','2021/01/10','default.png')
INSERT INTO TRE VALUES ('TRE09','LOP06','ph009',N'Đặng Thị Thu Hà','2019/12/23',0,N'Hà Nội',N'Kinh','2021/01/10','default.png')
INSERT INTO TRE VALUES ('TRE10','LOP05','ph010',N'Nguyễn Hà Vi','2019/10/24',0,N'Hà Nội',N'Kinh','2020/01/10','default.png')
INSERT INTO TRE VALUES ('TRE11','LOP05','ph011',N'Đặng Thị Thảo','2019/09/11',0,N'Hà Nội',N'Kinh','2020/01/10','default.png')
INSERT INTO TRE VALUES ('TRE12','LOP05','ph012',N'Nguyễn Hoàng Mai','2019/08/25',0,N'Hà Nội',N'Kinh','2020/01/10','default.png')
INSERT INTO TRE VALUES ('TRE13','LOP05','ph013',N'Đặng Thanh Mai','2019/07/28',0,N'Hà Nội',N'Kinh','2020/01/10','default.png')
INSERT INTO TRE VALUES ('TRE14','LOP05','ph014',N'Nguyễn Thanh Mai','2017/11/15',0,N'Hà Nội',N'Kinh','2020/01/10','default.png')
INSERT INTO TRE VALUES ('TRE15','LOP05','ph015',N'Lê Thị Thắm','2017/12/17',0,N'Hà Nội',N'Kinh','2020/01/10','default.png')
INSERT INTO TRE VALUES ('TRE16','LOP05','ph016',N'Lê Thị Thơm','2017/06/13',0,N'Hà Nội',N'Kinh','2020/01/10','default.png')

CREATE TABLE DIEMDANH
(
	MaTre varchar(5) not null,
	Ngay Date not null,
	DiemDanh bit not null,
	DangKiBuaAn bit not null,
	PRIMARY KEY(MaTre, Ngay),
	CONSTRAINT fk_dd_tre FOREIGN KEY (MaTre) REFERENCES TRE(MaTre),
	CONSTRAINT fk_dd_Ngay FOREIGN KEY (Ngay) REFERENCES NGAYDIHOC(Ngay),
)

INSERT INTO DIEMDANH VALUES ('TRE01','2021/09/06',1,1)
INSERT INTO DIEMDANH VALUES ('TRE01','2021/09/07',1,1)
INSERT INTO DIEMDANH VALUES ('TRE01','2021/09/08',1,1)
INSERT INTO DIEMDANH VALUES ('TRE01','2021/09/09',1,1)
INSERT INTO DIEMDANH VALUES ('TRE02','2021/09/06',1,1)
INSERT INTO DIEMDANH VALUES ('TRE02','2021/09/07',1,1)
INSERT INTO DIEMDANH VALUES ('TRE02','2021/09/08',1,1)
INSERT INTO DIEMDANH VALUES ('TRE02','2021/09/09',1,1)
INSERT INTO DIEMDANH VALUES ('TRE03','2021/09/06',1,1)
INSERT INTO DIEMDANH VALUES ('TRE03','2021/09/07',1,1)
INSERT INTO DIEMDANH VALUES ('TRE04','2021/09/06',1,1)

CREATE TABLE PHIEUTHUTIEN
(
	MaPhieu varchar(5) PRIMARY KEY,
	MaTre varchar(5) not null,
	NgayLapPhieu datetime not null,
	CONSTRAINT fk_phieu_tre FOREIGN KEY (MaTre) REFERENCES Tre(MaTre)
)
INSERT INTO PHIEUTHUTIEN VALUES ('P0001','TRE01','2021/09/06')
INSERT INTO PHIEUTHUTIEN VALUES ('P0002','TRE02','2021/09/06')
INSERT INTO PHIEUTHUTIEN VALUES ('P0003','TRE03','2021/09/06')
INSERT INTO PHIEUTHUTIEN VALUES ('P0004','TRE04','2021/09/06')
INSERT INTO PHIEUTHUTIEN VALUES ('P0005','TRE05','2021/09/06')
INSERT INTO PHIEUTHUTIEN VALUES ('P0006','TRE06','2021/09/06')
INSERT INTO PHIEUTHUTIEN VALUES ('P0007','TRE07','2021/09/06')
INSERT INTO PHIEUTHUTIEN VALUES ('P0008','TRE08','2021/09/06')
INSERT INTO PHIEUTHUTIEN VALUES ('P0009','TRE09','2021/09/06')
INSERT INTO PHIEUTHUTIEN VALUES ('P0010','TRE10','2021/09/06')
INSERT INTO PHIEUTHUTIEN VALUES ('P0011','TRE11','2021/09/06')

CREATE TABLE DONGCHIPHI
(
	MaPhieu varchar(5) not null,
	MaChiPhi varchar(5) not null,
	SoLuong int not null,
	GhiChu nvarchar(200) not null,
	PRIMARY KEY (MaPhieu, MaChiPhi),
	CONSTRAINT fk_dong_phieu FOREIGN KEY (MaPhieu) REFERENCES PHIEUTHUTIEN(MaPhieu),
	CONSTRAINT fk_dong_chiphi FOREIGN KEY (MaChiPhi) REFERENCES CHIPHI(MaChiPhi),
)
INSERT INTO DONGCHIPHI VALUES ('P0001','CP001',1,N'Hoàn thành')
INSERT INTO DONGCHIPHI VALUES ('P0001','CP002',1,N'Hoàn thành')
INSERT INTO DONGCHIPHI VALUES ('P0001','CP003',1,N'Hoàn thành')
INSERT INTO DONGCHIPHI VALUES ('P0002','CP001',1,N'Hoàn thành')
INSERT INTO DONGCHIPHI VALUES ('P0002','CP002',1,N'Hoàn thành')
INSERT INTO DONGCHIPHI VALUES ('P0002','CP003',1,N'Hoàn thành')
INSERT INTO DONGCHIPHI VALUES ('P0003','CP001',1,N'Hoàn thành')
INSERT INTO DONGCHIPHI VALUES ('P0003','CP002',1,N'Hoàn thành')
INSERT INTO DONGCHIPHI VALUES ('P0003','CP003',1,N'Hoàn thành')

CREATE TABLE PHIEUDANHGIA
(
	MaPhieu varchar(5) PRIMARY KEY,
	MaTre varchar(5) not null,
	MaGV varchar(5) not null,
	NgayTao Date not null,
	NamHoc int not null,
	CONSTRAINT fk_phieudg_tre FOREIGN KEY (MaTre) REFERENCES TRE(MaTre),
	CONSTRAINT fk_kq_gb FOREIGN KEY (MaGV) REFERENCES GIAOVIEN(MaGV),
)
INSERT INTO PHIEUDANHGIA VALUES ('PDG01','TRE01','gv001','2021/10/06',2021)
INSERT INTO PHIEUDANHGIA VALUES ('PDG02','TRE01','gv001','2021/11/06',2021)
INSERT INTO PHIEUDANHGIA VALUES ('PDG03','TRE02','gv002','2021/10/06',2021)
INSERT INTO PHIEUDANHGIA VALUES ('PDG04','TRE02','gv002','2021/11/06',2021)
INSERT INTO PHIEUDANHGIA VALUES ('PDG05','TRE03','gv002','2021/10/06',2021)
INSERT INTO PHIEUDANHGIA VALUES ('PDG06','TRE03','gv003','2021/11/06',2021)
INSERT INTO PHIEUDANHGIA VALUES ('PDG07','TRE04','gv003','2021/10/06',2021)
INSERT INTO PHIEUDANHGIA VALUES ('PDG08','TRE04','gv004','2021/11/06',2021)
INSERT INTO PHIEUDANHGIA VALUES ('PDG09','TRE05','gv005','2021/10/06',2021)

CREATE TABLE KETQUADANHGIA
(
	MaPhieu varchar(5) not null,
	MaNDDG varchar(5) not null,
	kq nvarchar(200) not null,
	PRIMARY KEY (MaPhieu, MaNDDG),
	CONSTRAINT fk_kq_phieu FOREIGN KEY (MaPhieu) REFERENCES PHIEUDANHGIA(MaPhieu),
	CONSTRAINT fk_kq_nd FOREIGN KEY (MaNDDG) REFERENCES NOIDUNGDANHGIA(MaNDDG),
)
INSERT INTO KETQUADANHGIA VALUES ('PDG01','ND001',N'Tốt')
INSERT INTO KETQUADANHGIA VALUES ('PDG01','ND002',N'Tốt')
INSERT INTO KETQUADANHGIA VALUES ('PDG01','ND003',N'Tốt')
INSERT INTO KETQUADANHGIA VALUES ('PDG02','ND001',N'Tốt')
INSERT INTO KETQUADANHGIA VALUES ('PDG02','ND002',N'Tốt')
INSERT INTO KETQUADANHGIA VALUES ('PDG02','ND003',N'Tốt')
INSERT INTO KETQUADANHGIA VALUES ('PDG03','ND001',N'Tốt')
INSERT INTO KETQUADANHGIA VALUES ('PDG03','ND002',N'Tốt')
INSERT INTO KETQUADANHGIA VALUES ('PDG03','ND003',N'Tốt')

