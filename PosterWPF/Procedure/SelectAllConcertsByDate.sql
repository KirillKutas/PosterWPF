use Poster
go
CREATE PROCEDURE SelectAllConcertsByDate
@currentDate date AS
BEGIN
    select distinct t3.Name, t3.Description, t3.Time, t3.Photo, t3.Genre, t3.Id from ConcertsInConcertHalls as t1 
	inner join Calendar as t2 on (t1.DateID = t2.Id)
	inner join Concerts as t3 on (t1.ConcertsId = t3.Id) 
	where(t2.Date = @currentDate)
END;
