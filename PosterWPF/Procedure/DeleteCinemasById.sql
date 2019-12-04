use Poster
go
CREATE PROCEDURE DeleteCinemasById
@deleteId int AS
BEGIN
    delete Cinemas where Id = @deleteId
END;
