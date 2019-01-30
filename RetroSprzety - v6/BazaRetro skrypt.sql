USE MASTER
GO
ALTER DATABASE retro_sklep
SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
DROP DATABASE retro_sklep
GO

USE master
GO
IF EXISTS(select * from sys.databases where name='retro_sklep')
DROP DATABASE retro_sklep
GO
CREATE DATABASE retro_sklep
ON
(NAME = 'retro_sklep',FILENAME =N'C:\retro_sklep.mdf', SIZE =3072KB, MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB)
LOG ON
(NAME = 'retro_sklep_log', FILENAME = N'C:\retro_sklep.ldf', SIZE =1536KB, MAXSIZE = 2048GB, FILEGROWTH = 10%)
GO


USE retro_sklep
GO

CREATE TABLE klienci(
ID_KLIENT decimal(4) not null,
IMIĘ varchar(50) not null,
NAZWISKO varchar(50) not null,
ADRES varchar(50)
CONSTRAINT [PK_Klient] PRIMARY KEY CLUSTERED([ID_KLIENT] ASC)
)

CREATE TABLE producenci(
ID_PRODUCENTA decimal(4) constraint pk_producent primary key,
NAZWA varchar(50) not null,
ROK_ZALOZENIA date not null,
CZY_AKTYWNY varchar(3)
)
CREATE TABLE details(
ID_DETAILS decimal(4) not null,
ILOSC_GLOSNIKOW decimal(2),
MATRYCA varchar(30),
POJEMNOSC decimal(4),
ILOSC_POLEK decimal(2),
RODZAJ_RADIA varchar(30),
OPIS text
CONSTRAINT [PK_Details] PRIMARY KEY CLUSTERED([ID_DETAILS] ASC)

)
CREATE TABLE produkty (
ID_PRODUKTU decimal(4) not null,
ID_DETAILS decimal(4) not null,
NAZWA varchar(30) not null,
TWORZYWO varchar(30) not null,
CENA decimal(8,2) not null,
DO_RENOWACJI varchar(3),
SZEROKOSC decimal(7,2) not null,
GŁĘBOKOSC decimal(7,2) not null,
WYSOKOSC decimal(7,2) not null,
ZDJECIE image,
ROK_PRODUKCJI date,
ID_PRODUCENTA decimal(4) not null
CONSTRAINT [PK_Produkt] PRIMARY KEY CLUSTERED([ID_PRODUKTU] ASC),
CONSTRAINT [FK_Details] FOREIGN KEY (ID_DETAILS) REFERENCES details(ID_DETAILS),
CONSTRAINT [FK_Producent] FOREIGN KEY (ID_Producenta) REFERENCES Producenci(ID_Producenta)
)
CREATE TABLE transakcje (
ID_TRANSAKCJI decimal(4) constraint pk_trans primary key,
ID_KLIENTA decimal(4) not null references klienci(ID_KLIENT)
)
CREATE TABLE poz_transakcje(
ID_WIERSZA decimal(4),
ID_TRANSAKCJI decimal(4),
ID_PRODUKTU decimal(4)
CONSTRAINT [PK_WIERSZ] PRIMARY KEY CLUSTERED (ID_WIERSZA),
CONSTRAINT [FK_TRANAKCJA] FOREIGN KEY(ID_TRANSAKCJI) REFERENCES transakcje(ID_TRANSAKCJI),
CONSTRAINT [FK_PRODUKT] FOREIGN KEY(ID_PRODUKTU) REFERENCES produkty(ID_PRODUKTU)
)

USE master
GO
USE retro_sklep
GO
INSERT INTO producenci values (1,'Philips', '1891-01-01', 'TAK');
INSERT INTO producenci values (2,'Panasonic', '1918-01-01', 'TAK');
INSERT INTO producenci values (3,'Unimor', '1972-01-01', 'NIE');
INSERT INTO producenci values (4,'Radmor', '1891-01-01', 'TAK');
INSERT INTO producenci values (5,'Orion', '1958-01-01', 'TAK');
INSERT INTO producenci values (6,'Stern-Radio Sonnberg', '1945-01-01', 'TAK');
INSERT INTO producenci values (7,'ZSRR', '1922-12-30', 'TAK');
INSERT INTO producenci values (8,'Bauknecht', '1919-01-01', 'TAK');
INSERT INTO details values (1,1, 'KINESKOP', null, null, null,null);
INSERT INTO details values (2,2, 'KINESKOP', null, null, null,null);
INSERT INTO details values (3,1, null, null, null, 'LAMPOWE',null);
INSERT INTO details values (4,2, null, null, null, 'GRAMOFON',null);
INSERT INTO details values (5,1, null, null, null, 'TRANZYSTOROWE',null);
INSERT INTO details values (6,null, null, 3, 0, null, 'TURYSTYCZNA');
INSERT INTO produkty values (1,1, 'NEPTUN 150', 'PLASTIK', 300,'TAK', 34,27,33, null, null,3);
INSERT INTO produkty values (2,2, 'NEPTUN 453A', 'PLASTIK',800,'NIE', 38,28,34, null, null,3);
INSERT INTO produkty values (3,1, 'NEPTUN M1515', 'PLASTIK',220,'TAK', 31,25,31, null, null,3);
INSERT INTO produkty values (4,3, 'Super 696/57GWU', 'DREWNO',650,'TAK', 41,16,29, null, null,6);
INSERT INTO produkty values (5,4, 'Diora ADAM', 'DREWNO',1500,'TAK', 41,16,29, null, null,3);
INSERT INTO produkty values (6,5, 'ROSSIJA', 'DREWNO',40,'TAK', 41,16,29, null, null,7);
INSERT INTO produkty values (7,6, 'Lodówka turystyczna', 'PLASTIK',40,'NIE', 25,15,35, null, null,7);
INSERT INTO klienci values (1,'Jan', 'Zamoyski', 'ul. Polska 25, Kraków');
INSERT INTO klienci values (2,'Ewelina', 'Ka³amarska', 'ul. Kolejowa 1, Nieborowice');
INSERT INTO klienci values (3,'Stefan', 'Batorski', 'al. Niepodleg³oci 240, Warszawa');
INSERT INTO transakcje values (1,1);
INSERT INTO transakcje values (2,3);
INSERT INTO transakcje values (3,2);
INSERT INTO transakcje values (4,1);
INSERT INTO transakcje values (5,1);
INSERT INTO poz_transakcje values (1,1,1);
INSERT INTO poz_transakcje values (2,2,6);
INSERT INTO poz_transakcje values (3,3,5);
INSERT INTO poz_transakcje values (4,4,4);
INSERT INTO poz_transakcje values (5,4,7);
INSERT INTO poz_transakcje values (6,5,3);



CREATE VIEW dawniProducenci AS(
select p.NAZWA, pr.NAZWA from produkty p
join producenci pr on p.ID_PRODUCENTA = pr.ID_PRODUCENTA
where pr.CZY_AKTYWNY = 'NIE')

CREATE VIEW dzialajacyProducenciView AS
select p.NAZWA, pr.NAZWA from produkty p
join producenci pr on p.ID_PRODUCENTA = pr.ID_PRODUCENTA
where pr.CZY_AKTYWNY = 'TAK';

CREATE VIEW produktyDoRenowacjiView AS
select p.NAZWA, pr.NAZWA from produkty p
join producenci pr on p.ID_PRODUCENTA = pr.ID_PRODUCENTA
where p.DO_RENOWACJI = 'TAK';

CREATE VIEW kupionePrzedmioty AS( select k.NAZWISKO, pr.NAZWA from poz_transakcje pt
join produkty pr on pr.ID_PRODUKTU = pt.ID_PRODUKTU
join transakcje t on pt.ID_TRANSAKCJI = t.ID_TRANSAKCJI
join klienci k on k.ID_KLIENT = t.ID_KLIENTA);



