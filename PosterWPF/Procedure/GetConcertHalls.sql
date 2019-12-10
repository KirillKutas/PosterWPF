use Poster
go
CREATE PROCEDURE SelectAllConcertHalls AS
BEGIN
    SELECT *
    FROM ConcertHalls
END;
