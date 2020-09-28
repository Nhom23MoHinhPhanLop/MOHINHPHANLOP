use master
go

if EXISTS (select databases.name from sys.databases where databases.name='QLTOUR')
drop database QLTOUR
go

create database QLTOUR
go

use QLTOUR
go

create table LOAITOUR(
	maloai char(10) primary key not null,
	tenloai nvarchar(50) default N'Loại chưa được đặt tên'
)
go

create table TOUR(
	matour char(10) primary key not null,
	tentour nvarchar(100) default N'Tour chưa được đặt tên',
	maloai char(10) foreign key references LOAITOUR (maloai)
)
go

create table GIA(
	magia char(10) primary key not null,
	gia float not null,
	ngaybatdau date default getDate(),
	ngayketthuc date ,
	matour char(10) foreign key references TOUR(matour)
)
go

create table DIADIEM(
	madiadiem char(10) primary key not null,
	tendiadiem nvarchar(100) default N'Địa điểm chưa đặt tên',
)
go

create table CHITIETTOUR(
	tt nvarchar(500) default N'Không có gì hết',
	matour char(10) foreign key references TOUR(matour),
	madiadiem char(10) foreign key references DIADIEM(madiadiem),
	CONSTRAINT fk_chiTietTour PRIMARY KEY (matour,madiadiem)	

)
go

insert into LOAITOUR values
	('loai1',N'Tour tự phát'),
	('loai2',N'Tour tự đi'),
	('loai3',N'Tour tự kỷ')
go
insert into TOUR values
	('tour1',N'Tour du lịch mùa dịch','loai3'),
	('tour2',N'Tour du lịch vào tâm dịch','loai1'),
	('tour3',N'Tour du lịch phòng dịch','loai2'),
	('tour4',N'Tour du lịch đến nơi chưa có dịch','loai2'),
	('tour5',N'Tour du lịch miễn dịch','loai1')
go
insert into GIA (magia,gia,ngayketthuc,matour)values
	('gia1',100000,'2020-12-12','tour1'),
	('gia2',200000,'2020-12-12','tour2'),
	('gia3',300000,'2020-12-12','tour3'),
	('gia4',400000,'2020-12-12','tour4'),
	('gia5',500000,'2020-12-12','tour5')
go

insert into DIADIEM values
	('diadiem1',N'Hà nội'),
	('diadiem2',N'Hà Giang'),
	('diadiem3',N'Phú Yên'),
	('diadiem4',N'Phú Thọ'),
	('diadiem5',N'Phú Quốc'),
	('diadiem6',N'Hồ chí minh')
go

insert into CHITIETTOUR (tt,matour,madiadiem) values
	(N'Thông tin chi tiết 1.1','tour1','diadiem1'),
	(N'Thông tin chi tiết 3.1','tour3','diadiem2'),
	(N'Thông tin chi tiết 1.2','tour1','diadiem3'),
	(N'Thông tin chi tiết 2','tour2','diadiem4'),
	(N'Thông tin chi tiết 5','tour5','diadiem5'),
	(N'Thông tin chi tiết 4','tour4','diadiem6'),
	(N'Thông tin chi tiết 3.2','tour3','diadiem1')
go



select TOUR.matour,tentour,gia,ngaybatdau,ngayketthuc,tt,tendiadiem, tenloai
from TOUR,GIA,CHITIETTOUR,DIADIEM,LOAITOUR 
where TOUR.maloai=LOAITOUR.maloai 
		and TOUR.matour=GIA.matour 
		and TOUR.matour=CHITIETTOUR.matour 
		and DIADIEM.madiadiem=CHITIETTOUR.madiadiem
