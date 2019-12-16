use Poster
go
CREATE PROCEDURE GetCinemasByFilmsId
@FilmsId int, 
@currentDate date AS
BEGIN
    select t4.Name, t4.Genre,t4.Photo, t1.Price, t1.ReservedSpaces, t1.FreeSpaces , t1.Id from MoviesInCinemas as t1 
	inner join Calendar as t2 on (t1.DateID = t2.Id)
	inner join Cinemas as t3 on (t1.CinemasId = t3.Id) 
	inner join Films as t4 on (t1.FilmsId = t4.Id)
	where(t2.Date = @currentDate and t3.Id = @FilmsId)
END;
