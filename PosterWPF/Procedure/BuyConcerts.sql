use Poster
go
create function GetConcertId(@id int)
returns int as
begin
	declare @idF int
	select @idF = ConcertsId from ConcertsInConcertHalls where Id = @id
	return @idF
end;
go
create procedure BuyConcerts
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
	select @freeSpace = FreeSpaces from ConcertsInConcertHalls where Id = @Id
	if(@freeSpace > @count)
	begin
		update ConcertsInConcertHalls set ReservedSpaces = ReservedSpaces + @count where Id = @Id
		set @IdUpdate = dbo.CheckIdBK(@id)
		set @IdFilmUpdate = dbo.GetConcertId(@Id)
		set @IdDateUpdate = dbo.GetDateId(@Date)
		set @IdUserUpdate = dbo.GetUserId(@User)
		insert BookedConcerts(Id,UserId,ConcertId,DateId)
		values (@IdUpdate, @IdUserUpdate, @IdFilmUpdate, @IdDateUpdate)
	end;
end;