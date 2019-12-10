use Poster
go
CREATE PROCEDURE DeleteConcertHallsById
@deleteId int AS
BEGIN
    delete ConcertHalls where Id = @deleteId
END;
