use Poster
go
CREATE PROCEDURE DeleteBKById
@deleteId int AS
BEGIN
    delete BookedMovies where Id = @deleteId
END;
