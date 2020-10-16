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
);

create table TOUR(
	matour char(10) primary key not null,
	tentour nvarchar(100) default N'Tour chưa được đặt tên',
	maloai char(10) foreign key references LOAITOUR (maloai)
);
create table GIA(
	magia char(10) primary key not null,
	gia float not null,
	ngaybatdau date default getDate(),
	ngayketthuc date ,
	matour char(10) foreign key references TOUR(matour)
);
create table DIADIEM(
	madiadiem char(10) primary key not null,
	tendiadiem nvarchar(100) default N'Địa điểm chưa đặt tên',
);
create table CHITIETTOUR(
	tt nvarchar(500) default N'Không có gì hết',
	matour char(10) foreign key references TOUR(matour),
	madiadiem char(10) foreign key references DIADIEM(madiadiem),
	CONSTRAINT fk_chiTietTour PRIMARY KEY (matour,madiadiem)	

);
insert into LOAITOUR values
	('loai1',N'Tour tự phát'),
	('loai2',N'Tour tự đi'),
	('loai3',N'Tour tự kỷ');
insert into TOUR values
	('tour1',N'Tour du lịch mùa dịch','loai3'),
	('tour2',N'Tour du lịch vào tâm dịch','loai1'),
	('tour3',N'Tour du lịch phòng dịch','loai2'),
	('tour4',N'Tour du lịch đến nơi chưa có dịch','loai2'),
	('tour5',N'Tour du lịch miễn dịch','loai1');
insert into GIA (magia,gia,ngayketthuc,matour)values
	('gia1',100000,'2020-12-12','tour1'),
	('gia2',200000,'2020-12-12','tour2'),
	('gia3',300000,'2020-12-12','tour3'),
	('gia4',400000,'2020-12-12','tour4'),
	('gia5',500000,'2020-12-12','tour5');

insert into DIADIEM values
	('diadiem1',N'Hà nội'),
	('diadiem2',N'Hà Giang'),
	('diadiem3',N'Phú Yên'),
	('diadiem4',N'Phú Thọ'),
	('diadiem5',N'Phú Quốc'),
	('diadiem6',N'Hồ chí minh');

insert into CHITIETTOUR (tt,matour,madiadiem) values
	(N'Thông tin chi tiết 1.1','tour1','diadiem1'),
	(N'Thông tin chi tiết 3.1','tour3','diadiem2'),
	(N'Thông tin chi tiết 1.2','tour1','diadiem3'),
	(N'Thông tin chi tiết 2','tour2','diadiem4'),
	(N'Thông tin chi tiết 5','tour5','diadiem5'),
	(N'Thông tin chi tiết 4','tour4','diadiem6'),
	(N'Thông tin chi tiết 3.2','tour3','diadiem1');


select TOUR.matour,tentour,gia,ngaybatdau,ngayketthuc,tt,tendiadiem, tenloai
from TOUR,GIA,CHITIETTOUR,DIADIEM,LOAITOUR 
where TOUR.maloai=LOAITOUR.maloai 
		and TOUR.matour=GIA.matour 
		and TOUR.matour=CHITIETTOUR.matour 
		and DIADIEM.madiadiem=CHITIETTOUR.madiadiem
go
--Loại tour


--Lấy danh sách loại tour
create procedure proc_getTourProgram
as
select * from LOAITOUR
go
--Lấy loại tour từ mã tour
create procedure proc_getTourProgramById @matour char(10)
as
select * from LOAITOUR where maloai =(select maloai from TOUR where matour = @matour)
go

--Thêm loại tour
create procedure proc_insertTourProgram @maloai char(10),@tenloai nvarchar(50)
as
insert into LOAITOUR (maloai,tenloai) values (@maloai,@tenloai)
go

--Sửa loại tour
create procedure proc_updateTourProgram @maloai char(10),@tenloai nvarchar(50)
as
update LOAITOUR set tenloai=@tenloai where maloai=@maloai;
go

--Xóa loại tour
create procedure proc_deleteTourProgram @maloai char(10)
as
delete LOAITOUR where maloai=@maloai
go

--drop procedure proc_getTourProgramById
--exec proc_getTourProgramById @matour ='tour1';

--Tour
--Lấy thông tin tour,Lấy danh sách tất cả tour,xóa 1 tour,thêm 1 tour,cập nhật tours
--


