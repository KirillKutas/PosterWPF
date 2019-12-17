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
create function SelectIdFilm(@newFilmsName varchar(50))
returns int
as
begin
  declare @Id int
   select @Id = Id from films where [Name] = @newFilmsName
  return @Id
end;
go
create function SelectIdCinema(@newCinemasName varchar(50))
returns int
as
begin
  declare @Id int
   select @Id = Id from Cinemas where [Name] = @newCinemasName
  return @Id
end;
go
create function SelectIdDate(@newDate date)
returns int
as
begin
  declare @Id int
   select @Id = Id from Calendar where [Date] = @newDate
  return @Id
end;
go 
create procedure AddMIC
@newId int, 
@newDate date,
@newFilmsName varchar(50),
@newCinemasName varchar(50),
@newPrice int,
@newTime varchar(50),
@newFreeSpaces int,
@newReservedSpaces int as
begin
	if(@newFreeSpaces > @newReservedSpaces)
	begin
	 insert into MoviesInCinemas(Id,[DateID],[FilmsId],[CinemasId],[Price],[Time],[FreeSpaces],[ReservedSpaces])
  values(dbo.CheckIdMIC(@newId), dbo.SelectIdDate(@newDate), dbo.SelectIdFilm(@newFilmsName), dbo.SelectIdCinema(@newCinemasName), @newPrice, @newTime, @newFreeSpaces, @newReservedSpaces)

	end;
 end;