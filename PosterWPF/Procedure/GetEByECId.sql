use Poster
go
CREATE PROCEDURE GetEByECId
@ECId int, 
@currentDate date AS
BEGIN
    select t4.Name, t4.Genre,t4.Time,t4.Photo, t1.Price, t1.ReservedSpaces, t1.FreeSpaces , t1.Id from ExhibitionsInExhibitionCenters as t1 
	inner join Calendar as t2 on (t1.DateID = t2.Id)
	inner join ExhibitionCenters as t3 on (t1.ExhibitionCentersId = t3.Id) 
	inner join Exhibitions as t4 on (t1.ExhibitionsId = t4.Id)
	where(t2.Date = @currentDate and t3.Id = @ECId)
END;
