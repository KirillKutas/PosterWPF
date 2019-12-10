use Poster
go
CREATE PROCEDURE DeleteCICHById
@deleteId int AS
BEGIN
    delete ConcertsInConcertHalls where Id = @deleteId
END;
