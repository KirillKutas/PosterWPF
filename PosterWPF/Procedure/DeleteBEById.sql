use Poster
go
CREATE PROCEDURE DeleteBEById
@deleteId int AS
BEGIN
    delete BookedExhibitions where Id = @deleteId
END;
