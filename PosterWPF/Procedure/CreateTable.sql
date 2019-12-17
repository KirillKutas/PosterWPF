create database Poster

use Poster
create table Calendar(
Id int primary key,
[Date] date unique not null
)
create table Films(
Id int primary key,
[Name] varchar(50) unique not null,
[DescriptionAndActors] varchar(50) not null,
Photo varbinary(max) not null,
Genre varchar(50) not null,
Country varchar(50) not null,
Duration varchar(30) not null
)
create table Cinemas(
Id int primary key,
[Name] varchar(50) unique not null,
[Adress] varchar(70) not null,
Photo varbinary(max) not null,
)
create table MoviesInCinemas(
Id int primary key,
DateID int references Calendar(Id) on delete cascade not null,
FilmsId int references Films(Id) on delete cascade not null,
CinemasId int references Cinemas(id) on delete cascade not null,
Price int not null,
[Time] varchar(50) not null,
[FreeSpaces] int not null,
[ReservedSpaces] int not null
)
create table Users(
Id int primary key,
[E-mail] varchar(100) unique not null,
[Name] varchar(50) not null,
[Password] varbinary(150) not null
)
insert into Users(Id,[E-mail],[Name],[Password])
values (1,'Admin','Admin',pwdencrypt('Pa$$word'))


create table Concerts(
Id int primary key,
[Name] varchar(50) unique not null,
[Description] text not null,
[Time] varchar(50) not null,
Photo varbinary(max) not null,
Genre varchar(50) not null
)
create table ConcertHalls(
Id int primary key,
[Name] varchar(50) unique not null,
[Adress] varchar(70) not null,
Photo varbinary(max) not null
)
create table ConcertsInConcertHalls(
Id int primary key,
DateID int references Calendar(Id) on delete cascade not null,
ConcertsId int references Concerts(Id) on delete cascade not null,
ConcertsHallsId int references ConcertHalls(id) on delete cascade not null,
Price int not null,
[FreeSpaces] int not null,
[ReservedSpaces] int not null
)

create table Exhibitions(
Id int primary key,
[Name] varchar(50) unique not null,
[DescriptionAndActors] text not null,
Photo varbinary(max) not null,
[Time] varchar(50) not null,
Genre varchar(50) not null
)
create table ExhibitionCenters(
Id int primary key,
[Name] varchar(50) unique not null,
[Adress] varchar(70) not null,
Photo varbinary(max) not null
)
create table ExhibitionsInExhibitionCenters(
Id int primary key,
DateID int references Calendar(Id) on delete cascade not null,
ExhibitionsId int references Exhibitions(Id) on delete cascade not null,
ExhibitionCentersId int references ExhibitionCenters(id) on delete cascade not null,
Price int not null,
[FreeSpaces] int not null,
[ReservedSpaces] int not null
)
create table BookedMovies(
Id int primary key,
UserId int references Users(Id) on delete cascade not null,
FilmId int references Films(Id) on delete cascade not null,
DateId int references Calendar(Id) not null
)
create table BookedConcerts(
Id int primary key,
UserId int references Users(Id) on delete cascade not null,
ConcertId int references Concerts(Id) on delete cascade not null,
DateId int references Calendar(Id) not null
)
create table BookedExhibitions(
Id int primary key,
UserId int references Users(Id) on delete cascade not null,
ExhibitionId int references Exhibitions(Id) on delete cascade not null,
DateId int references Calendar(Id) not null
)

