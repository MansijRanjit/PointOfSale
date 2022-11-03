create database POSMd
use posmd

create table tbBrand
(
  id int primary key identity(1,1) not null,
  brand varchar(50) not null,

)

select * from tbBrand


create table tbCategory
(
  id int primary key identity(1,1) not null,
  category varchar(50) not null,

)

select * from tbCategory


create table tbProduct
(
  pcode varchar(50) primary key not null,
  barcode varchar(50),
  pdesc varchar(MAX) not null,
  bid int not null,
  cid int not null,
  price decimal(18,2) not null,
  qty int ,
  reorder int
)
ALTER TABLE tbProduct ADD FOREIGN KEY (bid) REFERENCES tbBrand(id);

select * from tbProduct
select * from tbCategory
select * from tbBrand



create table tbSupplier
(
  id int primary key identity(1,1) not null,
  supplier varchar(50) not null,
  addres text not null,
  contactperson varchar(50) not null,
  phone varchar(50) not null,
  email varchar(50) not null,
  fax varchar(50) not null
)

select * from tbSupplier


create table tbUser
(
  username varchar(50) primary key not null,
  password varchar(50) not null,
  role varchar(50) not null,
  name varchar(50) not null,
  isactive varchar(50),
)

select * from tbUser

create table tbCart
(
	id int primary key identity(1,1),
	transno varchar(50),
	pcode varchar(50),
	price decimal(18,2),
	qty int default 0,
	disc_percent decimal(18,2) default 0,
	disc decimal(18,2) default 0,
	total decimal(18,2),
	sdate date,
	status varchar(50) default 'Pending',
	cashier varchar(50)
)
ALTER TABLE tbCart ADD FOREIGN KEY (pcode) REFERENCES tbProduct(pcode);

create table tbStockIn
(
	id int primary key identity(1,1),
	refno varchar(50),
	pcode varchar(50),
	qty int default 0,
	sdate datetime,
	stockinby varchar(50),
	status varchar(50) default 'Pending',
	supplierid int
)

ALTER TABLE tbStockIn ADD FOREIGN KEY (supplierid) REFERENCES tbSupplier(id);

ALTER TABLE tbStockIn ADD FOREIGN KEY (pcode) REFERENCES tbProduct(pcode);

