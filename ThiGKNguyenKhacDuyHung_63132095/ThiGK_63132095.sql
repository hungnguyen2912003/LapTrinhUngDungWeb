create database ThiGK_63132095

use ThiGK_63132095

create table Loaisach(
	maloaisach varchar(10) primary key,
	tenloaisach nvarchar(20),
	ghichu nvarchar(20)
);
go
create table Sach(
	masach varchar(10) primary key,
	tensach nvarchar(20),
	ngayxuatban DateTime,
	nhaxuatban nvarchar(20),
	anhbia varchar(Max),
	maloaisach varchar(10)
);
go
alter table Sach
add constraint fk_sach_loaisach foreign key (maloaisach) references dbo.Loaisach(maloaisach)
go
insert into Loaisach(maloaisach, tenloaisach, ghichu)
values
('ABC123', N'Sách giáo khoa', N'Sách giáo khoa 2'),
('TA003', N'Sách tiếng anh', N'Sách tiếng anh 3'),
('KH605', N'Sách khoa học', N'Sách khoa học 4');
go
insert into Sach(masach, tensach, ngayxuatban, nhaxuatban, anhbia, maloaisach)
values
('SGK354', N'Ngữ Văn', '2018-01-20', N'Kim Đồng', 'anh1.png', 'ABC123'),
('ELB350', N'Tiếng Anh', '2020-07-12', N'Phương Nam', 'anh2.png', 'TA003'),
('KHTN20', N'Khoa học', '2022-05-06', N'Giáo dục', 'anh3.png', 'KH605');