CREATE DATABASE QLBANNONGSAN
GO
USE QLBANNONGSAN
GO
CREATE TABLE tblNhanVien
(
	maNV varchar(7) primary key,
	tenNV nvarchar(50) not null,
	tenDN varchar(50) not null,
	matKhau varchar(50) not null
)
go
insert into tblNhanVien
values('NV01',N'Ngô Nhật Dương', 'nhatduong', 'nhatduong'),
	('NV02',N'Nguyễn Trọng Khang', 'trongkhang', 'trongkhang'),
	('NV03',N'Lê Lương Minh Hiếu', 'minhhieu', 'minhhueu');
go
create table tblKhachHang
(
	maKH varchar(7) primary key,
	tenKH nvarchar (50) not null,
	soTienDaDung int null,
	namSinh int null,
	diachi nvarchar null
)
go
insert into tblKhachHang
values ('KH01',N'Nguyễn Trọng Khang',100000,2001,N'Quảng  Nam'),
			('KH02',N'Ngô Nhật Dương',100000,2001,N'Quảng  Nam'),
			('KH03',N'Lê Lương Minh Hiếu',100000,2001,N'Quảng  Nam');
go
create table tblDanhMucNongSan
(
	maDM varchar(7) primary key,
	tenDM nvarchar(50) not null
)
go
insert into tblDanhMucNongSan
values ('DM01', N'Rau'),
			('DM02', N'Củ'),
			('DM03', N'Quả');
go
create table tblChiTietNongSan
(
	maNS varchar(7) primary key,
	tenNS nvarchar(50) not null,
	soLuong int,
	chiTiet nvarchar(50) null,
	maDMNS varchar(7) foreign key (maDMNS) references tblDanhMucNongSan(maDM)
		on update cascade
		on delete cascade,
	gia int
)
go
insert into tblChiTietNongSan
values ('NS01',N'Rau ngót',5,null,'DM01',10000),
			('NS02',N'Khoai Lang',5,null,'DM02',10000),
			('NS03',N'Táo Mỹ',5,null,'DM03',10000);
create table tblHoaDonNhapXuat
(
	maHD varchar(7) primary key,
	maNV varchar(7) foreign key (maNV) references tblNhanVien(maNV)
		on update cascade
		on delete cascade,
	maKH varchar(7) foreign key (maKH) references tblKhachHang(maKH)
		on update cascade
		on delete cascade,
	loaiHD varchar(1) null
)
insert into tblHoaDonNhapXuat
values ('HD01','NV01','KH03','D'),
			('HD02','NV02','KH01','D'),
			('HD03','NV03','KH02',null);
create table tblChiTietHoaDon
(
	maHD varchar(7) 	foreign key (maHD) references tblHoaDonNhapXuat(maHD)
		on update cascade
		on delete cascade,
	maNS varchar(7) 	foreign key (maNS) references tblChiTietNongSan(maNS)
		on update cascade
		on delete cascade,
	soLuong int,
	donGia int
	primary key (maHD, maNS)
)
go 
insert into tblChiTietHoaDon
values ('HD01','NS01',2,20000),
			('HD02','NS02',2,20000),
			('HD03','NS03',2,20000);