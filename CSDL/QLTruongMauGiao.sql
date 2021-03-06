USE master
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
GO
INSERT INTO LOP VALUES ('LOP01', N'Mầm 1', 20, 3, N'Mầm')
INSERT INTO LOP VALUES ('LOP02', N'Mầm 2', 21, 3, N'Mầm')
INSERT INTO LOP VALUES ('LOP03', N'Chồi 1', 23, 4, N'Chồi')
INSERT INTO LOP VALUES ('LOP04', N'Chồi 2', 22, 4, N'Chồi')
INSERT INTO LOP VALUES ('LOP05', N'Lá 1', 19, 5, N'Lá')
INSERT INTO LOP VALUES ('LOP06', N'Lá 2', 20, 5, N'Lá')
GO

CREATE TABLE TAIKHOAN
(
	TenTK varchar(20) PRIMARY KEY,
	MatKhau varchar(30) not null,
	PhanQuyen nvarchar(30) not null,
	TrangThaiHD bit not null,
	AnhDaiDien varchar(30) not null
)
GO
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

GO

CREATE TABLE GIAOVIEN
(
	MaGV varchar(5) PRIMARY KEY,
	TenGV nvarchar(100) not null,
	NgaySinh Date not null,
	GioiTinh bit not null,
	QueQuan nvarchar(30) not null,
	DienThoai varchar(15),
	Email varchar(100),
	LoaiHopDong nvarchar(30) not null,
	Luong money not null,
	KinhNghiem nvarchar(30) not null,
	TrinhDo nvarchar(30) not null,
	ChuyenNganh nvarchar(30) not null,
	LoaiTotNghiep nvarchar(30) not null,
	TenTK varchar(20), 
	CONSTRAINT fk_fv_tk FOREIGN KEY(TenTK) REFERENCES TAIKHOAN(TenTK),
)
GO
INSERT INTO GIAOVIEN VALUES ('admin',N'Nguyễn Thu Huyền','1990/05/20',0,N'Hà Nội','0395231832','thuhuyen@gmail.com',N'Biên chế',6000000,N'5 năm',N'Cao đẳng',N'Mầm non',N'Giỏi','Admin')

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
GO

CREATE TABLE PHANCONGGIAOVIEN
(
	MaGV varchar(5) not null,
	MaLop varchar(5) not null,
	NamHoc varchar(5) not null,
	PRIMARY KEY (MaGV,MaLop,NamHoc),
	CONSTRAINT fk_pcgv_gv FOREIGN KEY (MaGV) REFERENCES GIAOVIEN(MaGV),
	CONSTRAINT fk_pcgv_lop FOREIGN KEY (MaLop) REFERENCES LOP(MaLop)
)
GO
INSERT INTO PHANCONGGIAOVIEN VALUES ('gv001','LOP01','2021')
INSERT INTO PHANCONGGIAOVIEN VALUES ('gv002','LOP01','2021')
INSERT INTO PHANCONGGIAOVIEN VALUES ('gv003','LOP02','2021')
INSERT INTO PHANCONGGIAOVIEN VALUES ('gv004','LOP02','2021')
INSERT INTO PHANCONGGIAOVIEN VALUES ('gv005','LOP03','2021')
INSERT INTO PHANCONGGIAOVIEN VALUES ('gv006','LOP03','2021')
INSERT INTO PHANCONGGIAOVIEN VALUES ('gv007','LOP04','2021')
INSERT INTO PHANCONGGIAOVIEN VALUES ('gv008','LOP04','2021')
INSERT INTO PHANCONGGIAOVIEN VALUES ('gv009','LOP05','2021')
INSERT INTO PHANCONGGIAOVIEN VALUES ('gv010','LOP05','2021')

GO
CREATE TABLE PHUHUYNH
(
	MaPH varchar(5) PRIMARY KEY,
	TenPH nvarchar(50) not null,
	NamSinh date not null,
	GioiTinh bit not null,
	DiaChi nvarchar(100),
	DienThoai varchar(15),
	TenTK varchar(20),
	CONSTRAINT fkphv_tk FOREIGN KEY(TenTK) REFERENCES TAIKHOAN(TenTK)
)
GO
INSERT INTO PHUHUYNH VALUES ('ph001',N'Đặng Văn Sơn','1980/03/1',1,N'Hà Nội', '0391865281','ph001')
INSERT INTO PHUHUYNH VALUES ('ph002',N'Đặng Văn Tùng','1981/04/12',1,N'Hà Nội', '0391265281','ph002')
INSERT INTO PHUHUYNH VALUES ('ph003',N'Đặng Văn Thắng','1982/05/13',1,N'Hà Nội', '0391165281','ph003')
INSERT INTO PHUHUYNH VALUES ('ph004',N'Đặng Văn Tú','1983/06/14',1,N'Hà Nội', '0391865121','ph004')
INSERT INTO PHUHUYNH VALUES ('ph005',N'Đặng Văn Bá','1984/07/15',1,N'Hà Nội', '03918657211','ph005')
INSERT INTO PHUHUYNH VALUES ('ph006',N'Đặng Văn Hạnh','1985/09/16',1,N'Hà Nội', '0391862281','ph006')
INSERT INTO PHUHUYNH VALUES ('ph007',N'Đặng Văn Tài','1986/08/17',1,N'Hà Nội', '0391812781','ph007')
INSERT INTO PHUHUYNH VALUES ('ph008',N'Đặng Văn Toàn','1987/12/18',1,N'Hà Nội', '0391261281','ph008')
INSERT INTO PHUHUYNH VALUES ('ph009',N'Đặng Văn Quang','1988/11/19',1,N'Hà Nội', '0391861271','ph009')
INSERT INTO PHUHUYNH (MaPH,TenPH,NamSinh,GioiTinh,DiaChi,DienThoai,TenTK)
VALUES ('ph010',N'Nguyễn Quang Đại','1988/07/20',1,N'Hà Nội', '0477349827','ph010'),
		('ph011',N'Nguyễn Văn Tú','1980/06/01',1,N'Hà Nội', '0477349827','ph011'),
		('ph012',N'Nguyễn Trung Phú','1980/07/10',1,N'Hà Nội', '0477349827','ph012'),
		('ph013',N'Nguyễn Thị Hoa','1982/07/11',1,N'Hà Nội', '0477349827','ph013'),
		('ph014',N'Bùi Thị Xuân','1980/07/12',1,N'Hà Nội', '0477349827','ph014'),
		('ph015',N'Trần Quang Đại','1983/07/15',1,N'Hà Nội', '0477349827','ph015'),
		('ph016',N'Trần Trung Hưng','1987/07/20',1,N'Hà Nội', '0477349827','ph016')
GO

CREATE TABLE NOIDUNGDANHGIA
(
	MaNDDG varchar(5) PRIMARY KEY,
	NoiDungDanhGia nvarchar(300) not null
)
GO
INSERT INTO NOIDUNGDANHGIA VALUES('ND001',N'Thể chất')
INSERT INTO NOIDUNGDANHGIA VALUES('ND002',N'Sức khỏe')
INSERT INTO NOIDUNGDANHGIA VALUES('ND003',N'Hòa đồng')
GO
CREATE TABLE NGAYDIHOC
(
	Ngay Date PRIMARY KEY
)
GO
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
INSERT INTO NGAYDIHOC (Ngay)
VALUES ('2021/12/20'),
		('2021/12/21'),
		('2021/12/22'),
		('2021/12/23'),
		('2021/12/24')
INSERT INTO NGAYDIHOC (Ngay)
VALUES ('2021/12/27'),
		('2021/12/28'),
		('2021/12/29'),
		('2021/12/30'),
		('2021/12/31')
INSERT INTO NGAYDIHOC (Ngay)
VALUES ('2022/01/04'),
		('2022/01/05'),
		('2022/01/06'),
		('2022/01/07')
INSERT INTO NGAYDIHOC (Ngay)
VALUES ('2022/01/10'),
		('2022/01/11'),
		('2022/01/12'),
		('2022/01/13'),
		('2022/01/14')
INSERT INTO NGAYDIHOC (Ngay)
VALUES ('2022/01/17'),
		('2022/01/18'),
		('2022/01/19'),
		('2022/01/20'),
		('2022/01/21')
GO
CREATE TABLE THUCDONNGAY
(
	MaTDN varchar(10) PRIMARY KEY,
	Ngay Date not null,
	BuaSang nvarchar(500),
	BuaTrua nvarchar(500),
	BuaXe nvarchar(500)
)
GO
INSERT INTO THUCDONNGAY VALUES ('TDN001','2021/09/06',N'Bánh mì',N'Cơm',N'Sữa')
INSERT INTO THUCDONNGAY VALUES ('TDN002','2021/09/07',N'Bánh mì',N'Cơm',N'Sữa')
INSERT INTO THUCDONNGAY VALUES ('TDN003','2021/09/08',N'Bánh mì',N'Cơm',N'Sữa')
INSERT INTO THUCDONNGAY VALUES ('TDN004','2021/09/09',N'Bánh mì',N'Cơm',N'Sữa')
INSERT INTO THUCDONNGAY VALUES ('TDN005','2021/09/10',N'Bánh mì',N'Cơm',N'Sữa')
INSERT INTO THUCDONNGAY VALUES ('TDN006','2021/09/11',N'Bánh mì',N'Cơm',N'Sữa')
INSERT INTO THUCDONNGAY VALUES ('TDN007','2021/09/12',N'Bánh mì',N'Cơm',N'Sữa')
INSERT INTO THUCDONNGAY VALUES ('TDN008','2021/09/13',N'Bánh mì',N'Cơm',N'Sữa')
INSERT INTO THUCDONNGAY VALUES ('TDN009','2021/09/14',N'Bánh mì',N'Cơm',N'Sữa')
INSERT INTO THUCDONNGAY VALUES ('TDN010','2021/09/15',N'Bánh mì',N'Cơm',N'Sữa')
INSERT INTO THUCDONNGAY VALUES ('TDN011','2021/09/16',N'Bánh mì',N'Cơm',N'Sữa')
INSERT INTO THUCDONNGAY VALUES ('TDN012','2021/09/17',N'Bánh mì',N'Cơm',N'Sữa')
INSERT INTO THUCDONNGAY VALUES ('TDN013','2021/09/18',N'Bánh mì',N'Cơm',N'Sữa')
INSERT INTO THUCDONNGAY VALUES ('TDN014','2021/09/19',N'Bánh mì',N'Cơm',N'Sữa')
INSERT INTO THUCDONNGAY VALUES ('TDN015','2021/09/20',N'Bánh mì',N'Cơm',N'Sữa')

GO
CREATE TABLE CHIPHI
(
	MaChiPhi varchar(5) PRIMARY KEY,
	NoiDung nvarchar(100) not null,
	DonGia money not null,
)
GO
INSERT INTO CHIPHI VALUES ('CP001',N'Học phí',2000000)
INSERT INTO CHIPHI VALUES ('CP002',N'Ăn',1000000)
INSERT INTO CHIPHI VALUES ('CP003',N'Vật tư',500000)
GO

CREATE TABLE TRE
(
	MaTre varchar(6) PRIMARY KEY,
	MaLop varchar(5) not null,
	MaPH varchar(5) not null,
	TenTre nvarchar(100) not null,
	NgaySinh Date not null,
	GioiTinh bit not null,
	QueQuan nvarchar(50),
	DanToc nvarchar(30),
	NgayNhapHoc datetime,
	Anh varchar(100),
	CONSTRAINT fk_TRE_LOP FOREIGN KEY (MaLop) REFERENCES LOP(MaLop),
	CONSTRAINT fk_TRE_PH FOREIGN KEY (MaPH) REFERENCES PHUHUYNH(MaPH) 
)
GO
INSERT INTO TRE VALUES ('TRE001','LOP01','ph001',N'Nguyễn Văn Tuấn','2018/02/01',1,N'Hà Nội',N'Kinh','2021/01/10','default.png')
INSERT INTO TRE VALUES ('TRE002','LOP01','ph002',N'Nguyễn Văn Tài','2018/10/02',1,N'Hà Nội',N'Kinh','2021/01/10','default.png')
INSERT INTO TRE VALUES ('TRE003','LOP02','ph003',N'Trần Văn An','2018/08/03',1,N'Hà Nội',N'Kinh','2021/01/10','default.png')
INSERT INTO TRE VALUES ('TRE004','LOP02','ph004',N'Hoàng Văn Tỉnh','2018/06/04',1,N'Hà Nội',N'Kinh','2021/01/10','default.png')
INSERT INTO TRE VALUES ('TRE005','LOP03','ph005',N'Đinh Mạnh Tiến','2018/04/05',1,N'Hà Nội',N'Kinh','2021/01/10','default.png')
INSERT INTO TRE VALUES ('TRE006','LOP03','ph006',N'Nguyễn Thành Công','2018/03/07',1,N'Hà Nội',N'Kinh','2021/01/10','default.png')
INSERT INTO TRE VALUES ('TRE007','LOP04','ph007',N'Nguyễn Tiến Lên','2019/10/21',1,N'Hà Nội',N'Kinh','2021/01/10','default.png')
INSERT INTO TRE VALUES ('TRE008','LOP05','ph008',N'Nguyễn Văn Long','2019/11/22',1,N'Hà Nội',N'Kinh','2021/01/10','default.png')
INSERT INTO TRE VALUES ('TRE009','LOP06','ph009',N'Đặng Thị Thu Hà','2019/12/23',0,N'Hà Nội',N'Kinh','2021/01/10','default.png')
INSERT INTO TRE VALUES ('TRE010','LOP05','ph010',N'Nguyễn Hà Vi','2019/10/24',0,N'Hà Nội',N'Kinh','2020/01/10','default.png')
INSERT INTO TRE VALUES ('TRE011','LOP05','ph011',N'Đặng Thị Thảo','2019/09/11',0,N'Hà Nội',N'Kinh','2020/01/10','default.png')
INSERT INTO TRE VALUES ('TRE012','LOP05','ph012',N'Nguyễn Hoàng Mai','2019/08/25',0,N'Hà Nội',N'Kinh','2020/01/10','default.png')
INSERT INTO TRE VALUES ('TRE013','LOP05','ph013',N'Đặng Thanh Mai','2019/07/28',0,N'Hà Nội',N'Kinh','2020/01/10','default.png')
INSERT INTO TRE VALUES ('TRE014','LOP05','ph014',N'Nguyễn Thanh Mai','2017/11/15',0,N'Hà Nội',N'Kinh','2020/01/10','default.png')
INSERT INTO TRE VALUES ('TRE015','LOP05','ph015',N'Lê Thị Thắm','2017/12/17',0,N'Hà Nội',N'Kinh','2020/01/10','default.png')
INSERT INTO TRE VALUES ('TRE016','LOP05','ph016',N'Lê Thị Thơm','2017/06/13',0,N'Hà Nội',N'Kinh','2020/01/10','default.png')
GO
CREATE TABLE DIEMDANH
(
	MaTre varchar(6) not null,
	Ngay Date not null,
	DiemDanh bit not null,
	DangKiBuaAn bit not null,
	PRIMARY KEY(MaTre, Ngay),
	CONSTRAINT fk_dd_tre FOREIGN KEY (MaTre) REFERENCES TRE(MaTre),
	CONSTRAINT fk_dd_Ngay FOREIGN KEY (Ngay) REFERENCES NGAYDIHOC(Ngay),
)
GO
INSERT INTO DIEMDANH VALUES ('TRE001','2021/09/06',1,1)
INSERT INTO DIEMDANH VALUES ('TRE001','2021/09/07',1,1)
INSERT INTO DIEMDANH VALUES ('TRE001','2021/09/08',1,1)
INSERT INTO DIEMDANH VALUES ('TRE001','2021/09/09',1,1)
INSERT INTO DIEMDANH VALUES ('TRE002','2021/09/06',1,1)
INSERT INTO DIEMDANH VALUES ('TRE002','2021/09/07',1,1)
INSERT INTO DIEMDANH VALUES ('TRE002','2021/09/08',1,1)
INSERT INTO DIEMDANH VALUES ('TRE002','2021/09/09',1,1)
INSERT INTO DIEMDANH VALUES ('TRE003','2021/09/06',1,1)
INSERT INTO DIEMDANH VALUES ('TRE003','2021/09/07',1,1)
INSERT INTO DIEMDANH VALUES ('TRE004','2021/09/06',1,1)
GO
CREATE TABLE PHIEUTHUTIEN
(
	MaPhieu varchar(5) PRIMARY KEY,
	MaTre varchar(6) not null,
	NgayLapPhieu datetime not null,
	TrangThai bit NOT NULL,
	CONSTRAINT fk_phieu_tre FOREIGN KEY (MaTre) REFERENCES Tre(MaTre)
)
GO
INSERT INTO PHIEUTHUTIEN VALUES ('P001','TRE001','2021/09/06',1)
INSERT INTO PHIEUTHUTIEN VALUES ('P002','TRE002','2021/09/06',1)
INSERT INTO PHIEUTHUTIEN VALUES ('P003','TRE003','2021/09/06',1)
INSERT INTO PHIEUTHUTIEN VALUES ('P004','TRE004','2021/09/06',1)
INSERT INTO PHIEUTHUTIEN VALUES ('P005','TRE005','2021/09/06',1)
INSERT INTO PHIEUTHUTIEN VALUES ('P006','TRE006','2021/09/06',1)
INSERT INTO PHIEUTHUTIEN VALUES ('P007','TRE007','2021/09/06',1)
INSERT INTO PHIEUTHUTIEN VALUES ('P008','TRE008','2021/09/06',1)
INSERT INTO PHIEUTHUTIEN VALUES ('P009','TRE009','2021/09/06',1)
INSERT INTO PHIEUTHUTIEN VALUES ('P010','TRE010','2021/09/06',1)
INSERT INTO PHIEUTHUTIEN VALUES ('P011','TRE011','2021/09/06',1)
GO
CREATE TABLE DONGCHIPHI
(
	MaPhieu varchar(5) not null,
	MaChiPhi varchar(5) not null,
	SoLuong int not null,
	PRIMARY KEY (MaPhieu, MaChiPhi),
	CONSTRAINT fk_dong_phieu FOREIGN KEY (MaPhieu) REFERENCES PHIEUTHUTIEN(MaPhieu),
	CONSTRAINT fk_dong_chiphi FOREIGN KEY (MaChiPhi) REFERENCES CHIPHI(MaChiPhi),
)
GO
INSERT INTO DONGCHIPHI VALUES ('P001','CP001',1)
INSERT INTO DONGCHIPHI VALUES ('P001','CP002',1)
INSERT INTO DONGCHIPHI VALUES ('P001','CP003',1)
INSERT INTO DONGCHIPHI VALUES ('P002','CP001',1)
INSERT INTO DONGCHIPHI VALUES ('P002','CP002',1)
INSERT INTO DONGCHIPHI VALUES ('P002','CP003',1)
INSERT INTO DONGCHIPHI VALUES ('P003','CP001',1)
INSERT INTO DONGCHIPHI VALUES ('P003','CP002',1)
INSERT INTO DONGCHIPHI VALUES ('P003','CP003',1)
GO
CREATE TABLE PHIEUDANHGIA
(
	MaPhieu varchar(5) PRIMARY KEY,
	MaTre varchar(6) not null,
	MaGV varchar(5) not null,
	NgayTao Date not null,
	NamHoc int not null,
	CONSTRAINT fk_phieudg_tre FOREIGN KEY (MaTre) REFERENCES TRE(MaTre),
	CONSTRAINT fk_kq_gb FOREIGN KEY (MaGV) REFERENCES GIAOVIEN(MaGV),
)
GO
INSERT INTO PHIEUDANHGIA VALUES ('PDG01','TRE001','gv001','2021/10/06',2021)
INSERT INTO PHIEUDANHGIA VALUES ('PDG02','TRE001','gv001','2021/11/06',2021)
INSERT INTO PHIEUDANHGIA VALUES ('PDG03','TRE002','gv002','2021/10/06',2021)
INSERT INTO PHIEUDANHGIA VALUES ('PDG04','TRE002','gv002','2021/11/06',2021)
INSERT INTO PHIEUDANHGIA VALUES ('PDG05','TRE003','gv002','2021/10/06',2021)
INSERT INTO PHIEUDANHGIA VALUES ('PDG06','TRE003','gv003','2021/11/06',2021)
INSERT INTO PHIEUDANHGIA VALUES ('PDG07','TRE004','gv003','2021/10/06',2021)
INSERT INTO PHIEUDANHGIA VALUES ('PDG08','TRE004','gv004','2021/11/06',2021)
INSERT INTO PHIEUDANHGIA VALUES ('PDG09','TRE005','gv005','2021/10/06',2021)
GO
CREATE TABLE KETQUADANHGIA
(
	MaPhieu varchar(5) not null,
	MaNDDG varchar(5) not null,
	kq nvarchar(200) not null,
	PRIMARY KEY (MaPhieu, MaNDDG),
	CONSTRAINT fk_kq_phieu FOREIGN KEY (MaPhieu) REFERENCES PHIEUDANHGIA(MaPhieu),
	CONSTRAINT fk_kq_nd FOREIGN KEY (MaNDDG) REFERENCES NOIDUNGDANHGIA(MaNDDG),
)
GO
INSERT INTO KETQUADANHGIA VALUES ('PDG01','ND001',N'Tốt')
INSERT INTO KETQUADANHGIA VALUES ('PDG01','ND002',N'Tốt')
INSERT INTO KETQUADANHGIA VALUES ('PDG01','ND003',N'Tốt')
INSERT INTO KETQUADANHGIA VALUES ('PDG02','ND001',N'Tốt')
INSERT INTO KETQUADANHGIA VALUES ('PDG02','ND002',N'Tốt')
INSERT INTO KETQUADANHGIA VALUES ('PDG02','ND003',N'Tốt')
INSERT INTO KETQUADANHGIA VALUES ('PDG03','ND001',N'Tốt')
INSERT INTO KETQUADANHGIA VALUES ('PDG03','ND002',N'Tốt')
INSERT INTO KETQUADANHGIA VALUES ('PDG03','ND003',N'Tốt')

GO