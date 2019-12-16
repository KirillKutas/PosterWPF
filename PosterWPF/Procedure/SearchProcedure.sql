use Poster
go
create procedure SearchFilms
@searchString nvarchar(50) as
begin
select * from Films where [Name] like(@searchString + '%')
end;

go
create procedure SearchCinemas
@searchString nvarchar(50) as
begin
select * from Cinemas where [Name] like(@searchString + '%')
end;

go
create procedure SearchConcerts
@searchString nvarchar(50) as
begin
select * from Concerts where [Name] like(@searchString + '%')
end;

go
create procedure SearchConcertHalls
@searchString nvarchar(50) as
begin
select * from ConcertHalls where [Name] like(@searchString + '%')
end;

go
create procedure SearchExhibitions
@searchString nvarchar(50) as
begin
select * from Exhibitions where [Name] like(@searchString + '%')
end;

go
create procedure SearchExhibitionCenters
@searchString nvarchar(50) as
begin
select * from ExhibitionCenters where [Name] like(@searchString + '%')
end;