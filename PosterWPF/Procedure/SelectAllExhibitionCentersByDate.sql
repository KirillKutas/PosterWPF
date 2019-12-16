use Poster
go
CREATE PROCEDURE SelectAllExhibitionCentersByDate
@currentDate date AS
BEGIN
    select t3.Name, t3.Adress, t3.Photo, t3.Id from ExhibitionsInExhibitionCenters as t1 
	inner join Calendar as t2 on (t1.DateID = t2.Id)
	inner join ExhibitionCenters as t3 on (t1.ExhibitionCentersId = t3.Id) 
	where(t2.Date = @currentDate)
END;
