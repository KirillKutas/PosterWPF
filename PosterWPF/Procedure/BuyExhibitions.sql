use Poster
go
create function GetExhibitionId(@id int)
returns int as
begin
	declare @idF int
	select @idF = ExhibitionsId from ExhibitionsInExhibitionCenters where Id = @id
	return @idF
end;
go
create procedure BuyExhibitions
@Id int,
@count int,
@User nvarchar(50),
@Date date as
begin
	declare @freeSpace int
	declare @IdUpdate int
	declare @IdUserUpdate int
	declare @IdFilmUpdate int
	declare @IdDateUpdate int
	select @freeSpace = FreeSpaces from ExhibitionsInExhibitionCenters where Id = @Id
	if(@freeSpace > @count)
	begin
		update ExhibitionsInExhibitionCenters set ReservedSpaces = ReservedSpaces + @count where Id = @Id
		set @IdUpdate = dbo.CheckIdBK(@id)
		set @IdFilmUpdate = dbo.GetExhibitionId(@Id)
		set @IdDateUpdate = dbo.GetDateId(@Date)
		set @IdUserUpdate = dbo.GetUserId(@User)
		insert BookedExhibitions(Id,UserId,ExhibitionId,DateId)
		values (@IdUpdate, @IdUserUpdate, @IdFilmUpdate, @IdDateUpdate)
	end;
end;