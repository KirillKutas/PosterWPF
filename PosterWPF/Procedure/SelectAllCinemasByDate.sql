use Poster
go
CREATE PROCEDURE SelectAllCinemasByDate
@currentDate date AS
BEGIN
    select t3.Name, t3.Adress, t3.Photo from MoviesInCinemas as t1 
	inner join Calendar as t2 on (t1.DateID = t2.Id)
	inner join Cinemas as t3 on (t1.CinemasId = t3.Id) 
	where(t2.Date = @currentDate)
END;
