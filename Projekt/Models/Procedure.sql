use AdventureWorksOBP
go

create proc GetKupci
as
begin
select * from Kupac
end
go

create proc GetKupacById
@ID int
as
begin
select* from Kupac where IDKupac=@ID
end
go

create proc GetGrad
@ID int
as
begin
select * from Grad where IDGrad=@ID
end
go

create proc UpdateKupac
@ID int,@Ime nvarchar(50),@Prezime nvarchar(50),@Email nvarchar(50),@Telefon nvarchar(50),@GradID int
as
begin
update Kupac set Ime=@Ime, Prezime=@Prezime,Email=@Email,Telefon=@Telefon,GradID=@GradID where IDKupac=@ID
end
go

alter proc GetRacuni
@id int
as
begin
select * from Racun where Racun.KupacID=@id
end
go



alter proc GetStavke
@id int
as
begin
select s.IDStavka, s.RacunID, s.ProizvodID, p.IDProizvod, p.Naziv, p.BrojProizvoda, p.Boja, p.CijenaBezPDV, p.MinimalnaKolicinaNaSkladistu, p.PotkategorijaID, pt.IDPotkategorija, pt.KategorijaID, pt.Naziv as NazivPotk, k.IDKategorija, k.Naziv as NazivKat, kk.IDKreditnaKartica, kk.Broj, kk.IstekGodina, kk.IstekMjesec, kk.Tip, kom.IDKomercijalist, kom.Ime, kom.Prezime, kom.StalniZaposlenik from Stavka as s
join Proizvod as p on p.IDProizvod=s.ProizvodID
join Potkategorija as pt on pt.IDPotkategorija=p.PotkategorijaID
join Kategorija as k on k.IDKategorija=pt.KategorijaID
join Racun as r on r.IDRacun=s.RacunID
join KreditnaKartica as kk on kk.IDKreditnaKartica=r.KreditnaKarticaID
join Komercijalist as kom on kom.IDKomercijalist=r.KomercijalistID
where RacunID=@id
end
go

--proizvodi

create proc GetProizvodi
as
begin
select * from Proizvod
end
go

alter proc UpdateProizvod
@id int,
@naziv nvarchar(50),
@broj nvarchar(25),
@boja nvarchar(15),
@minKol smallint,
@cijena money,
@potkID int
as
begin
if not exists (select * from Potkategorija where IDPotkategorija=@potkID)
begin
update Proizvod set Naziv=@naziv, BrojProizvoda=@broj,Boja=@boja,MinimalnaKolicinaNaSkladistu=@minKol,CijenaBezPDV=@cijena,PotkategorijaID=null
where IDProizvod=@id
end
else
begin
update Proizvod set Naziv=@naziv, BrojProizvoda=@broj,Boja=@boja,MinimalnaKolicinaNaSkladistu=@minKol,CijenaBezPDV=@cijena,PotkategorijaID=@potkID 
where IDProizvod=@id
end
end
go

create proc DeleteProizvod
@id int
as
begin
delete from Proizvod
where IDProizvod=@id
end
go

create proc CreateProizvod
@naziv nvarchar(50),
@broj nvarchar(25),
@boja nvarchar(15),
@min smallint,
@cijena money,
@potkId int
as
begin
insert into Proizvod(Naziv, BrojProizvoda, Boja, MinimalnaKolicinaNaSkladistu, CijenaBezPDV, PotkategorijaID)
values (@naziv, @broj, @boja, @min, @cijena, @potkId)
end
go

create proc GetProizvod
@id int
as
begin
select * from Proizvod
where IDProizvod=@id
end


-- kategorija
create proc GetKategorije
as
begin
select * from Kategorija
end
go

create proc GetKategorija
@id int
as
begin
select * from Kategorija
where IDKategorija=@id
end
go

create proc UpdateKategorija
@id int,
@naziv nvarchar(50)
as
begin
update Kategorija set Naziv=@naziv
where IDKategorija=@id
end
go

create proc DeleteKategorija
@id int
as
begin
delete from Kategorija
where IDKategorija=@id
end
go


create proc CreateKategorija
@naziv nvarchar(50)
as
begin
insert into Kategorija(Naziv)
values (@naziv)
end
go

--potkategorija

create proc GetPotkategorije
as
begin
select * from Potkategorija
end
go

create proc GetPotkategorija
@id int
as
begin
select * from Potkategorija
where IDPotkategorija=@id
end
go

create proc UpdatePotkategorija
@id int,
@naziv nvarchar(50),
@kategorijaId int
as
begin
update Potkategorija set Naziv=@naziv, KategorijaID=@kategorijaId
where IDPotkategorija=@id
end
go

create proc DeletePotkategorija
@id int
as
begin
delete from Potkategorija
where IDPotkategorija=@id
end
go

create proc CreatePotkategorija
@naziv nvarchar(50),
@kategorijaId int
as
begin
insert into Potkategorija(Naziv,KategorijaID)
values (@naziv,@kategorijaId)
end
go
