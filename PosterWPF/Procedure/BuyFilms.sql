use Poster
go
create function GetUserId(@Name nvarchar(50))
returns int as
begin
	declare @id int
	select @id = Id from Users where Name = @Name
	return @id
end;
go
create function GetFilmId(@id int)
returns int as
begin
	declare @idF int
	select @idF = FilmsId from MoviesInCinemas where Id = @id
	return @idF
end;
go
create function GetDateId(@Date date)
returns int as
begin
	declare @id int
	select @id = Id from Calendar where Date = @Date
	return @id
end;
go
create procedure BuyFilms
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
	select @freeSpace = FreeSpaces from MoviesInCinemas where Id = @Id
	if(@freeSpace > @count)
	begin
		update MoviesInCinemas set ReservedSpaces = ReservedSpaces + @count where Id = @Id
		set @IdUpdate = dbo.CheckIdBK(@id)
		set @IdFilmUpdate = dbo.GetFilmId(@Id)
		set @IdDateUpdate = dbo.GetDateId(@Date)
		set @IdUserUpdate = dbo.GetUserId(@User)
		insert BookedMovies(Id,UserId,FilmId,DateId)
		values (@IdUpdate, @IdUserUpdate, @IdFilmUpdate, @IdDateUpdate)
	end;
end;