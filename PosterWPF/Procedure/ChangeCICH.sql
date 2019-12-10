use Poster 
go
create procedure ChangeCICH
@Id int, 
@newDate date,
@newConcertsName varchar(50),
@newConcertHallsName varchar(50),
@newPrice int,
@newFreeSpaces int,
@newReservedSpaces int as
begin
update ConcertsInConcertHalls
set [DateID] = dbo.SelectIdDate(@newDate),
[ConcertsId] = dbo.SelectIdConcerts(@newConcertsName),
ConcertsHallsId = dbo.SelectIdConcertHalls(@newConcertHallsName),
[Price] = @newPrice,
[FreeSpaces] = @newFreeSpaces,
[ReservedSpaces] = @newReservedSpaces
where [Id] = @Id
end;
