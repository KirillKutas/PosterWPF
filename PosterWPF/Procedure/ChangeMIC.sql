use Poster 
go
create procedure ChangeMIC
@Id int, 
@newDate date,
@newFilmsName varchar(50),
@newCinemasName varchar(50),
@newPrice int,
@newTime varchar(50),
@newFreeSpaces int,
@newReservedSpaces int as
begin
update MoviesInCinemas
set [DateID] = dbo.SelectIdDate(@newDate),
[FilmsId] = dbo.SelectIdFilm(@newFilmsName),
[CinemasId] = dbo.SelectIdCinema(@newCinemasName),
[Price] = @newPrice,
[Time] = @newTime,
[FreeSpaces] = @newFreeSpaces,
[ReservedSpaces] = @newReservedSpaces
where [Id] = @Id
end;
