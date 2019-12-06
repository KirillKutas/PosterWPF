use Poster
go
CREATE PROCEDURE SelectAllConcerts AS
BEGIN
    SELECT *
    FROM Concerts
END;
