use Poster
go
CREATE PROCEDURE DeleteFilmsById
@deleteId int AS
BEGIN
    delete Films where Id = @deleteId
END;
