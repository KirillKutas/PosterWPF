use Poster
go
CREATE PROCEDURE SelectAllUsers AS
BEGIN
    SELECT *
    FROM Users
END;
