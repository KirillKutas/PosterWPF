use Poster
go
CREATE PROCEDURE SelectAllExhibitionsByDate
@currentDate date AS
BEGIN
    select distinct t3.Name, t3.DescriptionAndActors, t3.Photo, t3.Time, t3.Genre, t3.Id from ExhibitionsInExhibitionCenters as t1 
	inner join Calendar as t2 on (t1.DateID = t2.Id)
	inner join Exhibitions as t3 on (t1.ExhibitionsId = t3.Id) 
	where(t2.Date = @currentDate)
END;
