create TABLE kullanicilar(
kullanici_id  int primary key identity,
kullanici_adi nvarchar(50) not null,
kullanici_soyadi nvarchar(50) not null,
kullanici_email nvarchar(50) not null unique,
kullanici_sifre nvarchar(50) not null,
kullanici_telefon int unique
)

create table paylasimlar(
paylasimlar_id int primary key identity,
paylasimlar_isim nvarchar(100) not null,
paylasimlar_icerik text not null
)

create table bekleyen_paylasim(
bekleyen_paylasim_id int primary key identity,
kullanici_id int not null,
paylasimlar_id int not null
)

create table sonuclanan_paylasim(
sonuclanan_paylasim_id int primary key identity,
sonuc int CHECK (sonuc IN(0,1)) , 
paylasimlar_id int not null
)

create table kabul_edilen_paylasim(
kabul_edilen_paylasim_id int primary key identity,
kullanici_id int not null ,
sonuclanan_paylasim_id int not null
)

create table kabul_edilmeyen_paylasim(
kabul_edilmeyen_paylasim_id int primary key identity,
kullanici_id int not null ,
sonuclanan_paylasim_id int not null
)

create table admin(
admin_id int primary key identity,
admin_adi nvarchar(50) not null,
admin_soyadi nvarchar(50) not null,
admin_email nvarchar(50) not null unique,
admin_sifre nvarchar(50) not null,
admin_telefon int unique
)

