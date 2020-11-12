use master
go

if Exists(select databases.name from sys.databases where databases.name='QLTOUR')
	drop database QLTOUR
go

create database QLTOUR
go

use QLTOUR
go

create table LoaiTour	(
	maLoai varchar(20)primary key not null,
	tenLoai nvarchar(200)
);
create table Tour(
	maTour varchar(20)primary key  not null,
	tenTour nvarchar(200),
	maLoai varchar(20) foreign key references LoaiTour(maLoai) on delete cascade
);

create table Gia(
	id int primary key identity(1,1) not null,
	tien int ,
	ngayBatDau dateTime,
	ngayKetThuc dateTime,
	maTour varchar(20)not null foreign key references Tour(maTour) on delete cascade

);
create table DiaDiem(
	maDiaDiem varchar(20)primary key  not null,
	tenDiaDiem nvarchar(200),
	diaphuong nvarchar(100)
);
create table ChiTietTour(
	maTour varchar(20)not null foreign key references Tour(maTour) on delete cascade,
	maDiaDiem varchar(20)not null foreign key references DiaDiem(maDiaDiem) on delete cascade,
	primary key(maTour,maDiaDiem),
);
create table Doan(
	maDoan varchar(20) not null primary key,
	tenDoan nvarchar(200),
	ngayBatDau date default getDate(),
	ngayKetThuc date not null,
	maTour varchar(20) not null foreign key references Tour(maTour),
);
create table LoaiChiPhi(
	maLoaiChiPhi varchar(20) primary key not null,
	tenLoaiChiPhi nvarchar(200) not null,

);
create table ChiPhi(
	maChiphi  int IDENTITY(1,1) PRIMARY KEY,
	tien int,
	maLoaiChiPhi varchar(20)not null foreign key references LoaiChiPhi(maLoaiChiPhi) on delete cascade,
	maDoan varchar(20)not null foreign key references Doan(maDoan) on update cascade on delete cascade,
	thoigian datetime default getdate()	
);
create table KhachHang(
	maKhachHang varchar(20) not null primary key,
	tenKhachHang nvarchar(200),
	gioitinh nvarchar(20),
	cmnd varchar(20),
	diachi nvarchar(200),
	sdt varchar(20),
);
create table ThamGia(
	maKhachHang varchar(20)not null foreign key references KhachHang(maKhachHang) on delete cascade,
	maDoan varchar(20) foreign key references  Doan(maDoan)  on update cascade on delete cascade,
	primary key (maKhachHang,maDoan)

);
create table ChucVu(
	maChucVu varchar(20) not null primary key,
	tenChucVu nvarchar(200)
);
create table NhanVien(
	maNhanVien varchar(20) not null primary key,
	tenNhanVien nvarchar(200),
	gioitinh nvarchar(20),
	cmnd varchar(20),
	diachi nvarchar(200),
	sdt varchar(20),
	maChucVu varchar(20) foreign key references ChucVu(maChucVu)  on update cascade on delete cascade
);
create table PhanCong(
	maDoan varchar(20) not null foreign key references Doan(maDoan) on delete cascade,
	maNhanVien varchar(20)not null foreign key references NhanVien(maNhanVien) on delete cascade,
	primary key (maNhanVien,maDoan)
);


--Thêm dữ liệu cho loại tour
insert into LoaiTour (maLoai,tenLoai)
values	('LOAI1',N'Du lịch trong nước'),
		('LOAI2',N'Du lịch ngoài nước'),
		('LOAI3',N'Du lịch sinh thái'),
		('LOAI4',N'Du lịch xã hội và gia đình'),
		('LOAI5',N'Du lịch kết hợp nghề nghiệp'),
		('LOAI6',N'Du lịch khám phá'),
		('LOAI7',N'Du lịch về trong ngày');
go		
--Thêm dữ liệu cho tour
insert into Tour (maTour,tenTour,maLoai) 
values	('TOUR1',N'DU LỊCH PHAN THIẾT - MŨI NÉ - LÀNG CHÀI XƯA','LOAI1'),
		('TOUR2',N'DU LỊCH NHA TRANG - ĐÀ LẠT','LOAI1'),
		('TOUR3',N'DU LỊCH KHÁM PHÁ CÁI BÈ - CẦN THƠ - CHÂU ĐỐC - HÀ TIÊN','LOAI1'),
		('TOUR4',N'DU LỊCH PHÚ QUỐC','LOAI1'),
		('TOUR5',N'DU LỊCH CÔN ĐẢO ','LOAI1'),
		('TOUR6',N'DU LỊCH HÀ NỘI - NINH BÌNH - HẠ LONG','LOAI1'),
		('TOUR7',N'DU LỊCH HỒ TRÀM ','LOAI1'),
		('TOUR8',N'DU LỊCH KHÁM PHÁ ĐỈNH FANSIPAN','LOAI1'),
		('TOUR9',N'DU LỊCH [MÙA NƯỚC NỔI] CAO LÃNH - TRÀM CHIM','LOAI1'),
		('TOUR10',N'DU LỊCH MÙA HOA TAM GIÁC MẠCH (HÀ NỘI - HÀ GIANG - CAO BẰNG - LẠNG SƠN)','LOAI1');
go

DECLARE @tour INT = 11;
WHILE @tour < 40
BEGIN
	insert into Tour (maTour,tenTour,maLoai) 
	values ('TOUR'+cast(@tour as varchar(20)),N'Tên tour số '+cast(@tour as varchar(20)),'LOAI'+cast(FLOOR(RAND()*(7))+1 as varchar(20)))
   SET @tour = @tour + 1;
END;

go
--Thêm dữ liệu cho giá
insert into Gia(tien,ngayBatDau,ngayKetThuc,maTour)
values	(1282423,DATEADD(week,-2,GETDATE()),DATEADD(week,8,GETDATE()),'TOUR1'),
		(142232,DATEADD(week,-4,GETDATE()),DATEADD(week,-2,GETDATE()),'TOUR1'),
		(123145,DATEADD(day,-2,GETDATE()),DATEADD(day,15,GETDATE()),'TOUR2'),
		(1152423,DATEADD(day,-3,GETDATE()),DATEADD(week,9,GETDATE()),'TOUR3'),
		(5224423,DATEADD(day,-4,GETDATE()),DATEADD(week,2,GETDATE()),'TOUR4'),
		(121421,DATEADD(day,-5,GETDATE()),DATEADD(week,3,GETDATE()),'TOUR5'),
		(123122,DATEADD(day,-6,GETDATE()),DATEADD(week,6,GETDATE()),'TOUR6'),
		(4732452,DATEADD(day,-7,GETDATE()),DATEADD(week,7,GETDATE()),'TOUR8'),
		(5463456,DATEADD(day,-8,GETDATE()),DATEADD(week,6,GETDATE()),'TOUR9'),
		(5684433,DATEADD(day,-9,GETDATE()),DATEADD(week,5,GETDATE()),'TOUR10'),
		(9878423,DATEADD(day,-10,GETDATE()),DATEADD(week,4,GETDATE()),'TOUR7');
go
--Thêm dữ liệu cho địa điểm
insert into DiaDiem(maDiaDiem,tenDiaDiem,diaphuong) 
values	('HALONG',N'Vịnh Hạ Long',N'Quảng Ninh'),
		('TRANGAN',N'Danh Thắng Tràng An',N'Ninh Bình'),
		('LANGCHAI',N'Làng chài xưa - Mũi né',N'Phan thiết'),
		('DALAT',N'Đà Lạt',N'Lâm Đồng'),
		('NHATRANG',N'Nha Trang',N'Khánh Hòa'),
		('CHONOI',N'Chợ nổi Cái Răng',N'Cần Thơ'),
		('NUICAM',N'Núi Cấm Châu Đốc',N'An Giang'),
		('TRAMCHIM',N'Tràm chim Cao Lãnh',N'Đồng Tháp'),
		('CAONGUYENDA',N'Cao nguyên đá Đồng Văn',N'Hà Giang'),
		('THACBANGIOC',N'Thác Bản Giốc',N'Cao Bằng'),
		('FANSIPAN',N'Đỉnh Fansipan',N'Lai Châu'),
		('HOTRAM',N'Hồ Tràm',N'Vũng Tàu'),
		('CONDAO',N'Côn đảo',N'Vũng Tàu'),
		('PHUQUOC',N'Đảo Phú Quốc',N'Kiên Giang');
go
--Thêm dữ liệu cho chi tiết tour
insert into ChiTietTour(maTour,maDiaDiem)
values	('TOUR1','LANGCHAI'),
		('TOUR2','NHATRANG'),
		('TOUR2','DALAT'),
		('TOUR3','CHONOI'),
		('TOUR3','NUICAM'),
		('TOUR4','PHUQUOC'),
		('TOUR5','CONDAO'),
		('TOUR6','TRANGAN'),
		('TOUR6','HALONG'),
		('TOUR7','HOTRAM'),
		('TOUR8','FANSIPAN'),
		('TOUR9','TRAMCHIM'),
		('TOUR10','CAONGUYENDA'),
		('TOUR10','THACBANGIOC');
go
--Thêm dữ liệu cho đoàn
insert into Doan (maDoan,tenDoan,ngayBatDau,ngayKetThuc,maTour) 
values	('DOAN1',N'Đoàn Đại học Sài Gòn',getDate(),getDate(),'TOUR1'),
		('DOAN2',N'Đoàn du lịch Côn Đảo',getDate(),getDate(),'TOUR5'),
		('DOAN3',N'Đoàn thanh niên',getDate(),getDate(),'TOUR1'),
		('DOAN4',N'Đoàn Đa cấp',getDate(),getDate(),'TOUR2'),
		('DOAN5',N'Đoàn siêu đa cấp',getDate(),getDate(),'TOUR7');
go

--Thêm dữ liệu cho loại chi phí
insert into LoaiChiPhi(maLoaiChiPhi,tenLoaiChiPhi)
values	('LOAICHIPHI1',N'Ăn uống'),
		('LOAICHIPHI2',N'Taxi'),
		('LOAICHIPHI3',N'Vé vào cổng'),
		('LOAICHIPHI4',N'Khách sạn'),
		('LOAICHIPHI5',N'Dịch vụ');
go
--Thêm dữ liệu cho chi phí
insert into ChiPhi(tien,maDoan,maLoaiChiPhi)
values	(1222132,'DOAN1','LOAICHIPHI1'),
		(512232,'DOAN1','LOAICHIPHI2'),
		(50000,'DOAN1','LOAICHIPHI3'),
		(20000,'DOAN1','LOAICHIPHI4'),
		(300000,'DOAN1','LOAICHIPHI5'),
		(1222132,'DOAN2','LOAICHIPHI1'),
		(112232,'DOAN2','LOAICHIPHI2'),
		(20000,'DOAN2','LOAICHIPHI3'),
		(10000,'DOAN2','LOAICHIPHI4'),
		(200000,'DOAN2','LOAICHIPHI5'),
		(2122132,'DOAN3','LOAICHIPHI1'),
		(412232,'DOAN3','LOAICHIPHI1'),
		(20000,'DOAN3','LOAICHIPHI3'),
		(40000,'DOAN3','LOAICHIPHI4'),
		(400000,'DOAN3','LOAICHIPHI4'),
		(1222132,'DOAN4','LOAICHIPHI1'),
		(512232,'DOAN5','LOAICHIPHI2'),
		(50000,'DOAN4','LOAICHIPHI3'),
		(20000,'DOAN5','LOAICHIPHI4'),
		(300000,'DOAN4','LOAICHIPHI5');
go
		
--Thêm dữ liệu cho khách hàng
insert into KhachHang (maKhachHang,tenKhachHang)
values	('KH1',N'Huỳnh Minh Chiến'),
		('KH2',N'Huỳnh Như Huỳnh'),
		('KH3',N'Huỳnh Văn Tèo'),
		('KH4',N'Nguyễn Thị Đậu'),
		('KH5',N'Võ Sư'),
		('KH6',N'Hoàng Thượng'),
		('KH7',N'Tào Lao');
go
DECLARE @kh INT = 10;

WHILE @kh < 40
BEGIN
	insert into KhachHang (maKhachHang,tenKhachHang)
	values ('KH'+cast(@kh as varchar(20)),N'Khách hàng '+cast(@kh as varchar(20)))
   SET @kh = @kh + 1;
END;
go
--Thêm dữ liệu cho tham gia(khách hàng thuộc đoàn nào )
insert into ThamGia (maKhachHang,maDoan)
values	('KH1','DOAN1'),
		('KH2','DOAN1'),
		('KH3','DOAN1'),
		('KH4','DOAN2'),
		('KH5','DOAN3'),
		('KH7','DOAN5'),
		('KH7','DOAN4'),
		('KH1','DOAN2');
go
--Thêm dữ liệu cho chức vụ
insert into ChucVu(maChucVu,tenChucVu)
values	('CHUCVU1',N'Hướng dẫn viên'),
		('CHUCVU2',N'Tiền trạm'),
		('CHUCVU3',N'Thông dịch viên'),
		('CHUCVU4',N'Tài xế'),
		('CHUCVU5',N'Dịch vụ'),
		('CHUCVU6',N'Giám sát'),
		('CHUCVU7',N'Quản lý');
go
--Thêm dữ liệu cho nhân viên
insert into NhanVien(maNhanVien,tenNhanVien,maChucVu)
values	('NV1',N'Hoàng Nhân Viên','CHUCVU1'),
		('NV2',N'Huỳnh Nhân Viễn','CHUCVU4'),
		('NV3',N'Nguyễn Văn Viện','CHUCVU2'),
		('NV4',N'Trần Thị Nhân','CHUCVU5'),
		('NV5',N'Lê Văn Vở','CHUCVU6'),
		('NV6',N'Hoàng Tất Thắng','CHUCVU7'),
		('NV7',N'Minh Minh','CHUCVU2'),
		('NV8',N'Thông Dịch','CHUCVU3');
go
DECLARE @cnt INT = 10;

WHILE @cnt < 20
BEGIN
   insert into NhanVien(maNhanVien,tenNhanVien,maChucVu)
	values	('NV'+cast(@cnt as varchar(20)),N'Nhân Viên '+ cast(@cnt as varchar(2)),'CHUCVU'+cast(FLOOR(RAND()*(7))+1 as varchar(20)))
   SET @cnt = @cnt + 1;
END;
go

--Thêm dữ liệu cho phân công
insert into PhanCong(maNhanVien,maDoan)
values	('NV1','DOAN1'),
		('NV1','DOAN2'),
		('NV1','DOAN3'),
		('NV1','DOAN4'),
		('NV1','DOAN5'),
		('NV2','DOAN1'),
		('NV2','DOAN2'),
		('NV2','DOAN3'),
		('NV2','DOAN4'),
		('NV2','DOAN5'),
		('NV3','DOAN1'),
		('NV4','DOAN5'),
		('NV5','DOAN4'),
		('NV6','DOAN3'),
		('NV7','DOAN2'),
		('NV8','DOAN1'),
		('NV8','DOAN3'),
		('NV7','DOAN4'),
		('NV6','DOAN5');
go
select COUNT(*) as counts from Doan where maDoan='DOAN12'