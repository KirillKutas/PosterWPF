use Poster

go
create function CheckIdMIC(@newId int)
returns int
as
begin
declare @count int
set @count = 0
while @count < 10000
begin
set @count = @count + 1
if(select count(Id) from MoviesInCinemas where Id = @count) = 0
  break;
end;
return @count
end;
go 
create procedure AddMIC
@newId int, 
@newDateId int,
@newFilmsId int,
@newCinemasId int,
@newPrice int,
@newTime varchar(50),
@newFreeSpaces int,
@newReservedSpaces int as
begin
  insert into MoviesInCinemas(Id,[DateID],[FilmsId],[CinemasId],[Price],[Time],[FreeSpaces],[ReservedSpaces])
  values(dbo.CheckIdFilm(@newId), @newDateId, @newFilmsId, @newCinemasId, @newPrice, @newTime, @newFreeSpaces, @newReservedSpaces)
end;