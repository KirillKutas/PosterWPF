use Poster
go
CREATE PROCEDURE DeleteCalendarById
@deleteId int AS
BEGIN
    delete Calendar where Id = @deleteId
END;
