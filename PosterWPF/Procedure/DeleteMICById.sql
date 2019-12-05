use Poster
go
CREATE PROCEDURE DeleteMICById
@deleteId int AS
BEGIN
    delete MoviesInCinemas where Id = @deleteId
END;
