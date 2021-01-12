use master
go

if Exists(select databases.name from sys.databases where databases.name='QUANLYTOUR')
	drop database QUANLYTOUR
go

create database QUANLYTOUR
go

use QUANLYTOUR
go

create table LoaiTour	(
	maLoai varchar(20)primary key not null,
	tenLoai nvarchar(200)
);
create table Tour(
	maTour varchar(20)primary key  not null,
	tenTour nvarchar(200),
	maLoai varchar(20) foreign key references LoaiTour(maLoai) on delete cascade on update cascade
);

create table Gia(
	id int primary key identity(1,1) not null,
	tien int ,
	ngayBatDau dateTime,
	ngayKetThuc dateTime,
	maTour varchar(20)not null foreign key references Tour(maTour) on delete cascade on update cascade

);
create table DiaDiem(
	maDiaDiem varchar(20)primary key  not null,
	tenDiaDiem nvarchar(200),
	diaphuong nvarchar(100)
);
create table ChiTietTour(
	maTour varchar(20)not null foreign key references Tour(maTour) on delete cascade on update cascade,
	maDiaDiem varchar(20)not null foreign key references DiaDiem(maDiaDiem) on delete cascade on update cascade,
	primary key(maTour,maDiaDiem),
);
create table Doan(
	maDoan varchar(20) not null primary key,
	tenDoan nvarchar(200),
	ngayBatDau date default getDate(),
	ngayKetThuc date not null,
	maTour varchar(20) not null foreign key references Tour(maTour) on update cascade on delete cascade,
);
create table LoaiChiPhi(
	maLoaiChiPhi varchar(20) primary key not null,
	tenLoaiChiPhi nvarchar(200) not null,

);
create table ChiPhi(
	maChiphi  int IDENTITY(1,1) PRIMARY KEY,
	tien int default 0,
	maLoaiChiPhi varchar(20)not null foreign key references LoaiChiPhi(maLoaiChiPhi) on delete cascade on update cascade,
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
	maKhachHang varchar(20)not null foreign key references KhachHang(maKhachHang) on delete cascade on update cascade,
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
	maDoan varchar(20) not null foreign key references Doan(maDoan)on update cascade on delete cascade,
	maNhanVien varchar(20)not null foreign key references NhanVien(maNhanVien) on delete cascade on update cascade,
	primary key (maNhanVien,maDoan)
);
go
--Trigger phân công cho nhân viên
CREATE TRIGGER trigger_insertPhanCong ON PhanCong
INSTEAD OF Insert
AS SET NOCOUNT ON
begin
	declare @ngaybd date 
	declare @ngaykt date
	declare @manv varchar(20)
	declare @madoan varchar(20)
	select @ngaybd=ngayBatDau,@ngaykt=ngayKetThuc,@manv=maNhanVien,@madoan=inserted.maDoan from inserted,Doan where inserted.maDoan=Doan.maDoan
	if not exists(select * from PhanCong as pc,Doan as d 
					where d.maDoan=pc.maDoan
					and pc.maNhanVien=@manv
					and ( (@ngaybd<=d.ngayKetThuc and @ngaykt>=d.ngayKetThuc)
						or (@ngaybd<=d.ngayBatDau and @ngaykt>=d.ngayBatDau)
						or (@ngaybd>=d.ngayBatDau and @ngaykt<=d.ngayKetThuc)
						))
	begin
		insert into PhanCong (maDoan,maNhanVien) values (@madoan,@manv)
	end
end
go

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
DECLARE @tour INT = 1;
WHILE @tour <= 20
BEGIN
	insert into Tour (maTour,tenTour,maLoai) 
	values ('TOUR'+cast(@tour as varchar(20)),N'Tên tour số '+cast(@tour as varchar(20)),'LOAI'+cast(FLOOR(RAND()*(7))+1 as varchar(20)))
   SET @tour = @tour + 1;
END;

go
--Thêm dữ liệu cho giá
DECLARE @gia INT = 1;
WHILE @gia <= 20
BEGIN
	insert into Gia(tien,ngayBatDau,ngayKetThuc,maTour)
	values (cast(FLOOR(RAND()*(1000000-500000+1))+500000 as Int)/10000*10000,DATEADD(week,-2,GETDATE()),DATEADD(week,4,GETDATE()),'TOUR'+cast(@gia as varchar(20))),	
	(cast(FLOOR(RAND()*(1000000-500000+1))+500000 as Int)/10000*10000,DATEADD(week,-4,GETDATE()),DATEADD(week,-2,GETDATE()),'TOUR'+cast(@gia as varchar(20))),
	(cast(FLOOR(RAND()*(1000000-500000+1))+500000 as Int)/10000*10000,DATEADD(week,-6,GETDATE()),DATEADD(week,-4,GETDATE()),'TOUR'+cast(@gia as varchar(20)))

   SET @gia = @gia + 1;
END;
go
--Thêm dữ liệu cho địa điểm
insert into DiaDiem(maDiaDiem,tenDiaDiem,diaphuong) 
values	('DIADIEM1',N'Vịnh Hạ Long',N'Quảng Ninh'),
		('DIADIEM2',N'Danh Thắng Tràng An',N'Ninh Bình'),
		('DIADIEM3',N'Làng chài xưa - Mũi né',N'Phan thiết'),
		('DIADIEM4',N'Đà Lạt',N'Lâm Đồng'),
		('DIADIEM5',N'Nha Trang',N'Khánh Hòa'),
		('DIADIEM6',N'Chợ nổi Cái Răng',N'Cần Thơ'),
		('DIADIEM7',N'Núi Cấm Châu Đốc',N'An Giang'),
		('DIADIEM8',N'Tràm chim Cao Lãnh',N'Đồng Tháp'),
		('DIADIEM9',N'Cao nguyên đá Đồng Văn',N'Hà Giang'),
		('DIADIEM10',N'Thác Bản Giốc',N'Cao Bằng'),
		('DIADIEM11',N'Đỉnh Fansipan',N'Lai Châu'),
		('DIADIEM12',N'Hồ Tràm',N'Vũng Tàu'),
		('DIADIEM13',N'Côn đảo',N'Vũng Tàu'),
		('DIADIEM14',N'Đảo Phú Quốc',N'Kiên Giang');
go

--Thêm dữ liệu cho chi tiết tour
DECLARE @diadiem INT = 1;
WHILE @diadiem <= 100
BEGIN
	DECLARE @matour varchar(20) = 'TOUR'+cast(cast(FLOOR(RAND()*(20))+1 as Int)as varchar(20));
	DECLARE @madiadiem varchar(20) = 'DIADIEM'+cast(cast(FLOOR(RAND()*(14))+1 as Int)as varchar(20));
	if not exists (select * from ChiTietTour where maTour= @matour and maDiaDiem=@madiadiem)
	begin
		insert into ChiTietTour (maTour,maDiaDiem)
		values (@matour,@madiadiem)
	end
   SET @diadiem = @diadiem + 1;
END;
go

--Thêm dữ liệu cho đoàn
DECLARE @doan INT = 1;
WHILE @doan <= 5
BEGIN
	insert into Doan (maDoan,tenDoan,ngayBatDau,ngayKetThuc,maTour) 
	values ('DOAN'+cast(@doan as varchar(20)),N'Tên của đoàn số '+cast(@doan as nvarchar(20)),DATEADD(day,-12,GETDATE()),DATEADD(day,-8,GETDATE()),'TOUR'+cast(cast(FLOOR(RAND()*(20))+1 as Int)as varchar(20)))
	SET @doan = @doan + 1;
END;
go

DECLARE @doan INT = 6;
WHILE @doan <= 10
BEGIN
	insert into Doan (maDoan,tenDoan,ngayBatDau,ngayKetThuc,maTour) 
	values ('DOAN'+cast(@doan as varchar(20)),N'Tên của đoàn số '+cast(@doan as nvarchar(20)),DATEADD(day,20,GETDATE()),DATEADD(day,24,GETDATE()),'TOUR'+cast(cast(FLOOR(RAND()*(20))+1 as Int)as varchar(20)))
	SET @doan = @doan + 1;
END;
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
DECLARE @chiphi INT = 1;
WHILE @chiphi <= 100
BEGIN
	insert into ChiPhi(tien,maDoan,maLoaiChiPhi,thoigian)
	values	(cast(FLOOR(RAND()*(200000-10000+1))+10000 as Int)/10000*10000,'DOAN'+cast(cast(FLOOR(RAND()*(5))+1 as Int)as varchar(20)),'LOAICHIPHI'+cast(cast(FLOOR(RAND()*(5))+1 as Int)as varchar(20)),DATEADD(day,cast(FLOOR(RAND()*(-12+8+1))-8 as Int),GETDATE()));
	SET @chiphi = @chiphi + 1;
END;
go

--Thêm dữ liệu cho khách hàng
DECLARE @kh INT = 1;
WHILE @kh < 100
BEGIN
	insert into KhachHang (maKhachHang,tenKhachHang,gioitinh,cmnd,diachi,sdt)
	values ('KH'+cast(@kh as varchar(20)),N'Khách hàng '+cast(@kh as varchar(20)),N'Nam','123456781',cast(@kh as nvarchar(20))+N' Nguyễn Trãi',0988282791+@kh)
   SET @kh = @kh + 1;
END;
go

--Thêm dữ liệu cho tham gia(khách hàng thuộc đoàn nào )
DECLARE @thamgia INT = 1;
WHILE @thamgia < 100
BEGIN
	DECLARE @makh varchar(20) = 'KH'+cast(@thamgia as varchar(20))
	DECLARE @madoan varchar(20) = 'DOAN'+cast(cast(FLOOR(RAND()*(10))+1 as Int)as varchar(20))
	
	insert into ThamGia (maKhachHang,maDoan)
	values	(@makh,@madoan)
	
	SET @thamgia = @thamgia + 1;
END;
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
DECLARE @nhanvien INT = 1;

WHILE @nhanvien <= 20
BEGIN
   insert into NhanVien(maNhanVien,tenNhanVien,maChucVu,gioitinh,cmnd,diachi,sdt)
	values	('NV'+cast(@nhanvien as varchar(20)),N'Nhân Viên '+ cast(@nhanvien as varchar(2)),'CHUCVU'+cast(FLOOR(RAND()*(7))+1 as varchar(20)),N'Nam','123456781',cast(@nhanvien as nvarchar(20))+N' Hàm Nghi',0926216051+@nhanvien)
   SET @nhanvien = @nhanvien + 1;
END;
go

--Thêm dữ liệu cho phân công
DECLARE @phancong INT = 1;
WHILE @phancong < 100
BEGIN
	DECLARE @manv varchar(20) = 'NV'+cast(cast(FLOOR(RAND()*(20))+1 as Int)as varchar(20));
	DECLARE @madoan varchar(20) = 'DOAN'+cast(cast(FLOOR(RAND()*(10))+1 as Int)as varchar(20));
	
	if not exists (select * from PhanCong where maNhanVien= @manv and maDoan=@madoan)
	begin
		insert into PhanCong(maNhanVien,maDoan)
		values	(@manv,@madoan)
	end
	SET @phancong = @phancong + 1;
END;
go
--DECLARE @phancong INT = 1;
--WHILE @phancong < 100
--BEGIN
--	DECLARE @manv varchar(20) = 'NV'+cast(cast(FLOOR(RAND()*(20))+1 as Int)as varchar(20));
--	DECLARE @madoan varchar(20) = 'DOAN'+cast(cast(FLOOR(RAND()*(10))+1 as Int)as varchar(20));
	
--	if not exists (select * from PhanCong where maNhanVien= @manv and maDoan=@madoan)
--	begin
--		declare @ngaybd date 
--		declare @ngaykt date
--		select @ngaybd=ngayBatDau,@ngaykt=ngayKetThuc from Doan where maDoan=@madoan
--		if not exists(select * from NhanVien as nv,PhanCong as pc,Doan as d 
--						where nv.maNhanVien=pc.maNhanVien 
--						and d.maDoan=pc.maDoan
--						and nv.maNhanVien=@manv
--						and ( (@ngaybd<=d.ngayKetThuc and @ngaykt>=d.ngayKetThuc)
--							or (@ngaybd<=d.ngayBatDau and @ngaykt>=d.ngayBatDau)
--							or (@ngaybd>=d.ngayBatDau and @ngaykt<=d.ngayKetThuc)
--							))
--		begin
--			insert into PhanCong(maNhanVien,maDoan)
--			values	(@manv,@madoan)
--		end
--	end
--	SET @phancong = @phancong + 1;
--END;
--go

--function trả về tổng chi phí của 1 đoàn trong 1 khoảng thời gian
create function func_chiphicuadoan( @madoan varchar(20),@ngaybd date,@ngaykt date)
returns integer
as
begin
	DECLARE @tongchiphi INTEGER 

	set @tongchiphi= (select isnull(sum(tien),0)  from ChiPhi where maDoan=@madoan and thoigian>=@ngaybd and thoigian<=@ngaykt)

	RETURN @tongchiphi
end
go

--function trả về tổng chi phí của 1 tour trong 1 khoảng thời gian
create function func_chiphicuatour( @matour varchar(20),@ngaybd date,@ngaykt date)
returns integer
as
begin
	DECLARE @tongchiphi INTEGER 

	set @tongchiphi= (select isnull(sum(tien),0)  
						from ChiPhi,Doan 
						where Doan.maTour=@matour 
						and ChiPhi.maDoan=Doan.maDoan
						and thoigian>=@ngaybd
						and thoigian<=@ngaykt
						and doan.ngayBatDau >= @ngaybd
						and doan.ngayBatDau<= @ngaykt)

	RETURN @tongchiphi
end
go

--function trả về số đoàn của 1 tour 
create function func_tongdoancuatour( @matour varchar(20),@ngaybd date,@ngaykt date)
returns integer
as
begin
	DECLARE @tongdoan INTEGER 

	set @tongdoan= (select isnull(count(maDoan),0)  
						from Doan
						where maTour=@matour
						and doan.ngayBatDau >= @ngaybd
						and doan.ngayBatDau<= @ngaykt
						)

	RETURN @tongdoan
end
go

--function trả về số khách hàng của 1 tour 
create function func_tongkhachhangcuatour( @matour varchar(20),@ngaybd date,@ngaykt date)
returns integer
as
begin
	DECLARE @tongkh INTEGER 

	set @tongkh= (select isnull(count(maKhachHang),0)  
						from Doan,ThamGia
						where Doan.maDoan=ThamGia.maDoan
						and maTour=@matour
						and doan.ngayBatDau >= @ngaybd
						and doan.ngayBatDau<= @ngaykt
						)
	RETURN @tongkh
end
go

--function trả về số khách hàng của 1 đoàn 
create function func_tongkhachhangcuadoan( @madoan varchar(20))
returns integer
as
begin
	DECLARE @tongkh INTEGER 

	set @tongkh= (select isnull(count(maKhachHang),0)  
					from ThamGia
					where maDoan=@madoan)
	RETURN @tongkh
end
go

--proc lấy giá hiện tại của tour
create proc proc_getGiaHienTai @matour varchar(20)
as
begin
	declare @homnay datetime = getDate()
	if exists (select * from Gia where maTour =@matour and ngayBatDau<=@homnay and ngayKetThuc>= @homnay)
	begin
		select * from Gia where maTour =@matour and ngayBatDau<=@homnay and ngayKetThuc>= @homnay
	end
	else
	begin
		if exists(select * from Gia where maTour =@matour and ngayKetThuc = (select max(ngayKetThuc) from Gia where maTour=@matour and ngayKetThuc<=@homnay))
		begin
			select * from Gia where maTour =@matour and ngayKetThuc = (select max(ngayKetThuc) from Gia where maTour=@matour and ngayKetThuc<=@homnay)
		end
		else
		begin
			select * from Gia where maTour =@matour and ngayBatDau = (select min(ngayBatDau) from Gia where maTour=@matour and ngayBatDau>=@homnay)
		end
	end
end
go

--proc trả về số lần đi tour của nhân viên trong khoảng thời gian
create proc proc_SoLanDiTour @ngaybd date, @ngaykt date
as
begin
	select nv.maNhanVien  as N'Mã nhân viên', nv.tenNhanVien as 'Họ tên', count(d.maDoan) as 'Số lần đi tour' 
	from NhanVien as nv,PhanCong as pc,Doan as d 
	where nv.maNhanVien=pc.maNhanVien 
	and d.maDoan=pc.maDoan
	and d.ngayBatDau>=@ngaybd 
	and d.ngayBatDau<=@ngaykt
	group by nv.maNhanVien ,nv.tenNhanVien
	union all
	
	select nv.maNhanVien  as N'Mã nhân viên', nv.tenNhanVien as 'Họ tên', 0 as 'Số lần đi tour' 
	from NhanVien as nv
	where nv.maNhanVien not in(
	select pc.maNhanVien
	from PhanCong as pc,Doan as d 
	where d.maDoan=pc.maDoan
	and d.ngayBatDau>=@ngaybd 
	and d.ngayBatDau<=@ngaykt)
	


end
go


--proc thống kê doanh thu, chi phí của tất cả đoàn trong 1 khoảng thời gian 
create proc proc_thongkedoanhthudoan @ngaybd date,@ngaykt date
as
begin
	select  doan.maDoan as N'Mã đoàn',
		doan.tenDoan as N'Tên đoàn',
		dbo.func_tongkhachhangcuadoan(doan.maDoan) as N'Số Khách',
		sum(gia.tien) as N'Doanh thu',
		dbo.func_chiphicuadoan(doan.maDoan,@ngaybd,@ngaykt) as 'Tổng chi phí',
		(sum(gia.tien)-dbo.func_chiphicuadoan(doan.maDoan,@ngaybd,@ngaykt))as N'Lãi'
		from thamgia,doan,gia
	where thamgia.maDoan=doan.maDoan 
	and doan.maTour=gia.maTour
	and doan.ngayBatDau >= @ngaybd
	and doan.ngayBatDau<= @ngaykt
	and  doan.ngayBatDau >=gia.ngayBatDau
	and doan.ngayBatDau<= gia.ngayKetThuc
	group by doan.maDoan,doan.tenDoan
	
end
go

--proc thống kê doanh thu, chi phí, của tất cả tour trong 1 khoảng thời gian 
create proc proc_thongkedoanhthutour @ngaybd date,@ngaykt date
as
begin
	(select	tour.maTour as N'Mã tour',
			tour.tenTour as N'Tên tour',
			dbo.func_tongdoancuatour(tour.maTour,@ngaybd,@ngaykt) as N'Tổng số đoàn',
			dbo.func_tongkhachhangcuatour(tour.maTour,@ngaybd,@ngaykt) as N'Tổng số khách hàng',
			sum(gia.tien) as N'Tổng doanh thu',
			dbo.func_chiphicuatour(tour.maTour,@ngaybd,@ngaykt) as N'Tổng chi phí' ,
			(sum(gia.tien)-dbo.func_chiphicuatour(tour.maTour,@ngaybd,@ngaykt)) as N'Lãi' 
	from tour 
		left join doan on doan.maTour=tour.maTour
		left join thamgia on thamgia.maDoan=doan.maDoan
		left join gia on tour.maTour=gia.maTour
	where 
	doan.ngayBatDau >= @ngaybd
	and doan.ngayBatDau<= @ngaykt
	and  doan.ngayBatDau >=gia.ngayBatDau
	and doan.ngayBatDau<= gia.ngayKetThuc
	group by tour.maTour,tour.tenTour)
	--union
	--(select tour.maTour as N'Mã tour',
	--		tour.tenTour as N'Tên tour',
	--		0 as N'Tổng số đoàn',
	--		0 as N'Tổng số khách hàng',
	--		0 as N'Tổng doanh thu',
	--		0 as N'Tổng chi phí' ,
	--		0 as N'Lãi'
	--from Tour 
	--where maTour not in (select distinct maTour from doan )
	--)
end
go
--proc thống kê doanh thu, chi phí của tất cả đoàn trong 1 khoảng thời gian 
create proc proc_thongkedoanhthudoanbytour @matour varchar(20), @ngaybd date,@ngaykt date
as
begin
	select  doan.maDoan as N'Mã đoàn',
		doan.tenDoan as N'Tên đoàn',
		dbo.func_tongkhachhangcuadoan(doan.maDoan) as N'Số Khách',
		gia.tien as N'Giá tour',
		sum(gia.tien) as N'Doanh thu',
		dbo.func_chiphicuadoan(doan.maDoan,@ngaybd,@ngaykt) as 'Tổng chi phí',
		(sum(gia.tien)-dbo.func_chiphicuadoan(doan.maDoan,@ngaybd,@ngaykt))as N'Lãi'
		from thamgia,doan,gia
	where thamgia.maDoan=doan.maDoan 
	and doan.maTour=@matour
	and doan.maTour=gia.maTour
	and doan.ngayBatDau >= @ngaybd
	and doan.ngayBatDau<= @ngaykt
	and  doan.ngayBatDau >=gia.ngayBatDau
	and doan.ngayBatDau<= gia.ngayKetThuc
	group by doan.maDoan,doan.tenDoan,gia.tien
	
end
go
--proc thống kê chi phí của 1 tour trong 1 khoảng thời gian
create proc proc_thongkechiphicuatour @matour varchar(20),@ngaybd date,@ngaykt date
as
begin
	select tenLoaiChiPhi,LoaiChiPhi.maLoaiChiPhi,isnull(sum(tien),0) as sotien
	from ChiPhi,Doan ,LoaiChiPhi
	where Doan.maTour=@matour 
	and ChiPhi.maDoan=Doan.maDoan
	and thoigian>=@ngaybd
	and thoigian<=@ngaykt
	and doan.ngayBatDau >= @ngaybd
	and doan.ngayBatDau<= @ngaykt
	and ChiPhi.maLoaiChiPhi=LoaiChiPhi.maLoaiChiPhi
	group by tenLoaiChiPhi,LoaiChiPhi.maLoaiChiPhi
end
go


--proc thống kê chi phí của 1 đoàn trong 1 khoảng thời gian
create proc proc_thongkechiphicuadoan @madoan varchar(20),@ngaybd date,@ngaykt date
as
begin
	select tenLoaiChiPhi,LoaiChiPhi.maLoaiChiPhi,isnull(sum(tien),0) as sotien
	from ChiPhi,Doan ,LoaiChiPhi
	where Doan.maDoan=@madoan 
	and ChiPhi.maDoan=Doan.maDoan
	and thoigian>=@ngaybd
	and thoigian<=@ngaykt
	and doan.ngayBatDau >= @ngaybd
	and doan.ngayBatDau<= @ngaykt
	and ChiPhi.maLoaiChiPhi=LoaiChiPhi.maLoaiChiPhi
	group by tenLoaiChiPhi,LoaiChiPhi.maLoaiChiPhi
end
go

--Tìm kiếm đoàn
create proc proc_timkiemDoan @keyword nvarchar(2000)
as
begin
	select * 
	from Doan,Tour
	where Doan.maTour=Tour.maTour and 
	(UPPER(maDoan) LIKE '%'+@keyword+'%'
	or UPPER(tenDoan) LIKE '%'+@keyword+'%'
	or UPPER(tenDoan) LIKE '%'+@keyword+'%'
	or ngayBatDau = try_cast(@keyword as date) 
	or ngayKetThuc = try_cast(@keyword as date)
	or UPPER(Doan.maTour) LIKE '%'+@keyword+'%'
	or UPPER(tenTour) LIKE '%'+@keyword+'%'
	or UPPER(maLoai) LIKE '%'+@keyword+'%' )
end
go

--Tìm kiếm khách hàng ko có trong đoàn
create proc proc_timkiemKhachHang @keyword nvarchar(2000)
as
begin

	select * 
	from KhachHang 
	where
	(UPPER(KhachHang.maKhachHang) LIKE '%'+@keyword+'%'
	or UPPER(tenKhachHang) LIKE '%'+@keyword+'%'
	or UPPER(gioitinh) LIKE '%'+@keyword+'%'
	or UPPER(cmnd) LIKE '%'+@keyword+'%'
	or UPPER(sdt) LIKE '%'+@keyword+'%'
	or UPPER(diachi) LIKE '%'+@keyword+'%')
end
go

--Tìm kiếm khách hàng trong đoàn
create proc proc_timkiemKhachHangTrongDoan @madoan varchar(20), @keyword nvarchar(2000)
as
begin
	select * 
	from KhachHang,ThamGia 
	where Khachhang.maKhachHang = ThamGia.maKhachHang 
	and maDoan=@madoan
	and (UPPER(KhachHang.maKhachHang) LIKE '%'+@keyword+'%'
	or UPPER(tenKhachHang) LIKE '%'+@keyword+'%'
	or UPPER(gioitinh) LIKE '%'+@keyword+'%'
	or UPPER(cmnd) LIKE '%'+@keyword+'%'
	or UPPER(sdt) LIKE '%'+@keyword+'%'
	or UPPER(diachi) LIKE '%'+@keyword+'%')
end
go
--Tìm kiếm nhân viên ko có trong đoàn
create proc proc_timkiemNhanVien @keyword nvarchar(2000)
as
begin
	select * 
	from NhanVien ,ChucVu 
	where NhanVien.maChucVu=ChucVu.maChucVu 
	and(UPPER(NhanVien.maNhanVien) LIKE '%'+@keyword+'%'
	or UPPER(tenNhanVien) LIKE '%'+@keyword+'%'
	or UPPER(gioitinh) LIKE '%'+@keyword+'%'
	or UPPER(cmnd) LIKE '%'+@keyword+'%'
	or UPPER(sdt) LIKE '%'+@keyword+'%'
	or UPPER(diachi) LIKE '%'+@keyword+'%'
	or UPPER(NhanVien.maChucVu) LIKE '%'+@keyword+'%'
	or UPPER(tenChucVu) LIKE '%'+@keyword+'%')
end
go

--Tìm kiếm Nhân viên trong đoàn
create proc proc_timkiemNhanVienTrongDoan @madoan varchar(20), @keyword nvarchar(2000)
as
begin
	select * from NhanVien,PhanCong,ChucVu 
	where NhanVien.maChucVu=ChucVu.maChucVu 
	and NhanVien.maNhanVien=PhanCong.maNhanVien 
	and maDoan=@madoan
	and(UPPER(NhanVien.maNhanVien) LIKE '%'+@keyword+'%'
	or UPPER(tenNhanVien) LIKE '%'+@keyword+'%'
	or UPPER(gioitinh) LIKE '%'+@keyword+'%'
	or UPPER(cmnd) LIKE '%'+@keyword+'%'
	or UPPER(sdt) LIKE '%'+@keyword+'%'
	or UPPER(diachi) LIKE '%'+@keyword+'%'
	or UPPER(NhanVien.maChucVu) LIKE '%'+@keyword+'%'
	or UPPER(tenChucVu) LIKE '%'+@keyword+'%')
end
go

--Tìm kiếm tour
create proc proc_timkiemTour @keyword nvarchar(2000)
as
begin
	select * from Tour,LoaiTour 
	where Tour.maLoai=LoaiTour.maLoai
	and(UPPER(maTour) LIKE '%'+@keyword+'%'
	or UPPER(tenTour) LIKE '%'+@keyword+'%'
	or UPPER(Tour.maLoai) LIKE '%'+@keyword+'%'
	or UPPER(tenLoai) LIKE '%'+@keyword+'%')
end
go

select * 
	from KhachHang,ThamGia 
	where Khachhang.maKhachHang = ThamGia.maKhachHang 
	and maDoan='DOAN1'

	exec proc_timkiemKhachHangTrongDoan 'DOAN1',N'4 NGUYỄN TRÃI'
	select * 
	from KhachHang 
	exec proc_timkiemKhachHang N'KH1'

--Test
--declare @ngaybd date = dateadd(week,-11,getdate())
--declare @ngaykt date = dateadd(week,45,getdate())
--exec proc_SoLanDiTour @ngaybd ,@ngaykt

----exec proc_thongkechiphicuatour 'TOUR5', @ngaybd ,@ngaykt

--exec proc_thongkedoanhthutour @ngaybd ,@ngaykt
--exec proc_thongkedoanhthudoan  @ngaybd ,@ngaykt

--select * from Tour
--left join doan on doan.maTour=tour.maTour 
--left join gia on tour.maTour=gia.maTour
--left join thamgia on doan.maDoan=thamgia.maDoan
--where doan.ngayBatDau <= dateadd(week,1,getdate())



--Thống kê tình hình hoạt động theo mỗi tour (doanh số, số đoàn tham quan,…) 
	--Doanh số, số đoàn tham quan, số khách hàng theo mỗi tour (hiển thị tất cả các tour)
	--Doanh số, số khách hàng theo mỗi đoàn (hiển thị tất cả các đoàn)
	--DONE proc_thongkedoanhthutour

--Thống kê chi phí (một tour, chi phí khách sạn, ăn uống trong một khoảng thời gian…)
	--Hiển thị danh sách tour
		--Các chi phí của tour trong khoảng thời gian(biểu đồ tròn )


--Doanh thu của một đoàn, của một tour trong một khoảng thời gian.
	--Hiển thị danh sách tour và đoàn
		--Doanh thu và tổng chi phí của đoàn hoặc tour
		--Kèm câu trên
	--DONE proc_thongkedoanhthudoanbytour
--Thống kê số lần đi tour của từng nhân viên trogng khoản thời gian. 
	--Thống kê nhân viên
	--DONE proc_SoLanDiTour
