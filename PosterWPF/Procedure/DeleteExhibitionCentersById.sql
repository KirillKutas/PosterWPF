use Poster
go
CREATE PROCEDURE DeleteExhibitionCentersById
@deleteId int AS
BEGIN
    delete ExhibitionCenters where Id = @deleteId
END;
