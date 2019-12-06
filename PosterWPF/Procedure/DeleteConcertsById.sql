use Poster
go
CREATE PROCEDURE DeleteConcertsById
@deleteId int AS
BEGIN
    delete Concerts where Id = @deleteId
END;
