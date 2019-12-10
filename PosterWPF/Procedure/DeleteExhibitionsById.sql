use Poster
go
CREATE PROCEDURE DeleteExhibitionsById
@deleteId int AS
BEGIN
    delete Exhibitions where Id = @deleteId
END;
