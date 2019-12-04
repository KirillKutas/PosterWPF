use Poster 
go
create procedure ChangeMIC
@Id int, 
@newDateId int,
@newFilmsId int,
@newCinemasId int,
@newPrice int,
@newTime varchar(50),
@newFreeSpaces int,
@newReservedSpaces int as
begin
update MoviesInCinemas
set [DateID] = @newDateId,
[FilmsId] = @newFilmsId,
[CinemasId] = @newCinemasId,
[Price] = @newPrice,
[Time] = @newTime,
[FreeSpaces] = @newFreeSpaces,
[ReservedSpaces] = @newReservedSpaces
where [Id] = @Id
end;
