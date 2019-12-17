use Poster
go
CREATE PROCEDURE DeleteUserById
@deleteId int AS
BEGIN
	if(@deleteId != 1)
	begin
	    delete Users where Id = @deleteId
	end;
END;
