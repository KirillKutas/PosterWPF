use Poster
go
CREATE PROCEDURE DeleteUserById
@deleteId int AS
BEGIN
    delete Users where Id = @deleteId
END;
