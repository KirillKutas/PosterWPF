use Poster
go
CREATE PROCEDURE GetConcertsByConcertHallsId
@ConcertHallsId int, 
@currentDate date AS
BEGIN
    select t4.Name, t4.Genre,t4.Time,t4.Photo, t1.Price, t1.ReservedSpaces, t1.FreeSpaces , t1.Id from ConcertsInConcertHalls as t1 
	inner join Calendar as t2 on (t1.DateID = t2.Id)
	inner join ConcertHalls as t3 on (t1.ConcertsHallsId = t3.Id) 
	inner join Concerts as t4 on (t1.ConcertsId = t4.Id)
	where(t2.Date = @currentDate and t3.Id = @ConcertHallsId)
END;
