use Poster 
go
create procedure ChangeEIEC
@Id int, 
@newDate date,
@newExhibitionsName varchar(50),
@newExhibitionCentersName varchar(50),
@newPrice int,
@newFreeSpaces int,
@newReservedSpaces int as
begin
update ExhibitionsInExhibitionCenters
set [DateID] = dbo.SelectIdDate(@newDate),
[ExhibitionsId] = dbo.SelectIdExhibitions(@newExhibitionsName),
ExhibitionCentersId = dbo.SelectIdExhibitionCenters(@newExhibitionCentersName),
[Price] = @newPrice,
[FreeSpaces] = @newFreeSpaces,
[ReservedSpaces] = @newReservedSpaces
where [Id] = @Id
end;
