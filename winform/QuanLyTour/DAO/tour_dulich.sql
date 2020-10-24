-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th10 20, 2020 lúc 09:24 AM
-- Phiên bản máy phục vụ: 10.1.37-MariaDB
-- Phiên bản PHP: 7.0.33

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu:  tour_dulich 
--

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng  tours 
--

CREATE TABLE  tours  (
   tour_id int NOT NULL,
   tour_ten  nvarchar(200) NOT NULL,
   tour_mota  nvarchar(200) NOT NULL,
   loai_id int NOT NULL,
   gia_id int NOT NULL
) 

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng  tour_chiphi 
--

CREATE TABLE  tour_chiphi  (
   chiphi_id int NOT NULL,
   doan_id int NOT NULL,
   chiphi_total  decimal(10,0) NOT NULL,
   chiphi_chitiet  nvarchar(200) NOT NULL -- 'lưu danh sách chi phí (json)'
) 

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng  tour_chitiet 
--

CREATE TABLE  tour_chitiet  (
   ct_id int NOT NULL,
   tour_id int NOT NULL,
   dd_id int NOT NULL,
   ct_thutu int NOT NULL
) 

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng  tour_diadiem 
--

CREATE TABLE  tour_diadiem  (
   dd_id int NOT NULL,
   dd_thanhpho  nvarchar(200) NOT NULL,
   dd_ten  nvarchar(200) NOT NULL,
   dd_mota  nvarchar(200) NOT NULL
) 

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng  tour_doan 
--

CREATE TABLE  tour_doan  (
   doan_id int NOT NULL,
   tour_id int NOT NULL,
   doan_name  nvarchar(200) NOT NULL,
   doan_ngaydi  date NOT NULL,
   doan_ngayve  date NOT NULL,
   doan_chitietchuongtrinh  nvarchar(200) NOT NULL
) 

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng  tour_gia 
--

CREATE TABLE  tour_gia  (
   gia_id int NOT NULL,
   gia_sotien  decimal(10,0) NOT NULL,
   tour_id int NOT NULL,
   gia_tungay  date NOT NULL,
   gia_denngay  date NOT NULL
) 

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng  tour_khachang 
--

CREATE TABLE  tour_khachang  (
   nv_id int NOT NULL,
   nv_ten  nvarchar(200) NOT NULL,
   nv_sdt  nvarchar(200) NOT NULL,
   nv_ngaysinh  date NOT NULL,
   nv_email  nvarchar(200) NOT NULL,
   nv_nhiemvu  nvarchar(200) NOT NULL
) 

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng  tour_loai 
--

CREATE TABLE  tour_loai  (
   loai_id int NOT NULL,
   loai_ten  nvarchar(200) NOT NULL,
   loai_mota  nvarchar(200) NOT NULL
) 

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng  tour_loaichiphi 
--

CREATE TABLE  tour_loaichiphi  (
   cp_id int NOT NULL,
   cp_ten  nvarchar(200) NOT NULL,
   cp_mota  nvarchar(200) NOT NULL
) 

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng  tour_nguoidi 
--

CREATE TABLE  tour_nguoidi  (
   nguoidi_id int NOT NULL,
   doan_id int NOT NULL,
   nguoidi_dsnhanvien  nvarchar(200) NOT NULL -- 'lưu danh sách mã số nhân viên đi (json)',
   nguoidi_dskhach  nvarchar(200) NOT NULL -- 'lưu danh sách mã số khách hàng (json)'
) 

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng  tour_nhanvien 
--

CREATE TABLE  tour_nhanvien  (
   kh_id int NOT NULL,
   kh_ten  nvarchar(200) NOT NULL,
   kh_sdt  nvarchar(200) NOT NULL,
   kh_ngaysinh  date NOT NULL,
   kh_email  nvarchar(200) NOT NULL,
   kh_cmnd  nvarchar(200) NOT NULL
) 

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng  tours 
--
ALTER TABLE  tours 
  ADD PRIMARY KEY ( tour_id ),
  ADD KEY  loai_id  ( loai_id ),
  ADD KEY  gia_id  ( gia_id );

--
-- Chỉ mục cho bảng  tour_chiphi 
--
ALTER TABLE  tour_chiphi 
  ADD PRIMARY KEY ( chiphi_id , doan_id ),
  ADD KEY  doan_id  ( doan_id );

--
-- Chỉ mục cho bảng  tour_chitiet 
--
ALTER TABLE  tour_chitiet 
  ADD PRIMARY KEY ( ct_id ),
  ADD KEY  tour_id  ( tour_id , dd_id ),
  ADD KEY  dd_id  ( dd_id );

--
-- Chỉ mục cho bảng  tour_diadiem 
--
ALTER TABLE  tour_diadiem 
  ADD PRIMARY KEY ( dd_id );

--
-- Chỉ mục cho bảng  tour_doan 
--
ALTER TABLE  tour_doan 
  ADD PRIMARY KEY ( doan_id ),
  ADD KEY  tour_id  ( tour_id );

--
-- Chỉ mục cho bảng  tour_gia 
--
ALTER TABLE  tour_gia 
  ADD PRIMARY KEY ( gia_id ),
  ADD KEY  tour_id  ( tour_id );

--
-- Chỉ mục cho bảng  tour_khachang 
--
ALTER TABLE  tour_khachang 
  ADD PRIMARY KEY ( nv_id );

--
-- Chỉ mục cho bảng  tour_loai 
--
ALTER TABLE  tour_loai 
  ADD PRIMARY KEY ( loai_id );

--
-- Chỉ mục cho bảng  tour_loaichiphi 
--
ALTER TABLE  tour_loaichiphi 
  ADD PRIMARY KEY ( cp_id );

--
-- Chỉ mục cho bảng  tour_nguoidi 
--
ALTER TABLE  tour_nguoidi 
  ADD PRIMARY KEY ( nguoidi_id , doan_id ),
  ADD KEY  doan_id  ( doan_id );

--
-- Chỉ mục cho bảng  tour_nhanvien 
--
ALTER TABLE  tour_nhanvien 
  ADD PRIMARY KEY ( kh_id );

--
-- AUTO_INCREMENT cho các bảng đã đổ
--

--
-- AUTO_INCREMENT cho bảng  tours 
--
ALTER TABLE  tours 
  MODIFY  tour_id int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng  tour_chiphi 
--
ALTER TABLE  tour_chiphi 
  MODIFY  chiphi_id int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng  tour_chitiet 
--
ALTER TABLE  tour_chitiet 
  MODIFY  ct_id int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng  tour_diadiem 
--
ALTER TABLE  tour_diadiem 
  MODIFY  dd_id int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng  tour_doan 
--
ALTER TABLE  tour_doan 
  MODIFY  doan_id int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng  tour_gia 
--
ALTER TABLE  tour_gia 
  MODIFY  gia_id int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng  tour_khachang 
--
ALTER TABLE  tour_khachang 
  MODIFY  nv_id int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng  tour_loai 
--
ALTER TABLE  tour_loai 
  MODIFY  loai_id int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng  tour_loaichiphi 
--
ALTER TABLE  tour_loaichiphi 
  MODIFY  cp_id int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng  tour_nguoidi 
--
ALTER TABLE  tour_nguoidi  
  MODIFY  nguoidi_id int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng  tour_nhanvien 
--
ALTER TABLE  tour_nhanvien 
  MODIFY  kh_id int NOT NULL AUTO_INCREMENT;

--
-- Các ràng buộc cho các bảng đã đổ
--

--
-- Các ràng buộc cho bảng  tours 
--
ALTER TABLE  tours 
  ADD CONSTRAINT  tours_ibfk_1  FOREIGN KEY ( loai_id ) REFERENCES  tour_loai  ( loai_id ),
  ADD CONSTRAINT  tours_ibfk_2  FOREIGN KEY ( gia_id ) REFERENCES  tour_gia  ( gia_id );

--
-- Các ràng buộc cho bảng  tour_chiphi 
--
ALTER TABLE  tour_chiphi 
  ADD CONSTRAINT  tour_chiphi_ibfk_1  FOREIGN KEY ( doan_id ) REFERENCES  tour_doan  ( doan_id );

--
-- Các ràng buộc cho bảng  tour_chitiet 
--
ALTER TABLE  tour_chitiet 
  ADD CONSTRAINT  tour_chitiet_ibfk_1  FOREIGN KEY ( tour_id ) REFERENCES  tours  ( tour_id ),
  ADD CONSTRAINT  tour_chitiet_ibfk_2  FOREIGN KEY ( dd_id ) REFERENCES  tour_diadiem  ( dd_id );

--
-- Các ràng buộc cho bảng  tour_doan 
--
ALTER TABLE  tour_doan 
  ADD CONSTRAINT  tour_doan_ibfk_1  FOREIGN KEY ( tour_id ) REFERENCES  tours  ( tour_id );

--
-- Các ràng buộc cho bảng  tour_nguoidi 
--
ALTER TABLE  tour_nguoidi 
  ADD CONSTRAINT  tour_nguoidi_ibfk_1  FOREIGN KEY ( doan_id ) REFERENCES  tour_doan  ( doan_id );
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
