use Poster
go
CREATE PROCEDURE DeleteEIECById
@deleteId int AS
BEGIN
    delete ExhibitionsInExhibitionCenters where Id = @deleteId
END;
