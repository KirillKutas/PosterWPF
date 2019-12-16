use Poster
go
CREATE PROCEDURE SelectAllFilmsByDate
@currentDate date AS
BEGIN
    select t3.Id, t3.Name, t3.DescriptionAndActors,t3.Photo,t3.Genre,t3.Country,t3.Duration from MoviesInCinemas as t1 
	inner join Calendar as t2 on (t1.DateID = t2.Id)
	inner join Films as t3 on (t1.FilmsId = t3.Id) 
	where(t2.Date = @currentDate)
END;
