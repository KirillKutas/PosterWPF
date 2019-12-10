use Poster
go
CREATE PROCEDURE DeleteBCById
@deleteId int AS
BEGIN
    delete BookedConcerts where Id = @deleteId
END;
