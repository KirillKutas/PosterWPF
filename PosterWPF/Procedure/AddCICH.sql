use Poster

go
create function CheckIdCICH(@newId int)
returns int
as
begin
declare @count int
set @count = 0
while @count < 10000
begin
set @count = @count + 1
if(select count(Id) from ConcertsInConcertHalls where Id = @count) = 0
  break;
end;
return @count
end;
go
create function SelectIdConcerts(@newFilmsName varchar(50))
returns int
as
begin
  declare @Id int
   select @Id = Id from Concerts where [Name] = @newFilmsName
  return @Id
end;
go
create function SelectIdConcertHalls(@newCinemasName varchar(50))
returns int
as
begin
  declare @Id int
   select @Id = Id from ConcertHalls where [Name] = @newCinemasName
  return @Id
end;
go 
create procedure AddCICH
@newId int, 
@newDate date,
@newConcertsName varchar(50),
@newConcertHallsName varchar(50),
@newPrice int,
@newFreeSpaces int,
@newReservedSpaces int as
begin
  insert into ConcertsInConcertHalls(Id,[DateID],[ConcertsId],[ConcertsHallsId],[Price],[FreeSpaces],[ReservedSpaces])
  values(dbo.CheckIdCICH(@newId), dbo.SelectIdDate(@newDate), dbo.SelectIdConcerts(@newConcertsName), dbo.SelectIdConcertHalls(@newConcertHallsName), @newPrice, @newFreeSpaces, @newReservedSpaces)
end;