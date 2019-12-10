use Poster
go
CREATE PROCEDURE SelectAllEIEC AS
BEGIN
    select t1.Id, t2.[Date], t3.[Name] as 'ExhibitionsName', t4.[Name] as 'ExhibitionCentersName', t1.[Price], t1.[FreeSpaces], t1.[ReservedSpaces] from ExhibitionsInExhibitionCenters as t1
inner join Calendar as t2 on (t1.[DateID] = t2.Id) 
inner join Exhibitions as t3 on (t1.ExhibitionsId = t3.Id)
inner join ExhibitionCenters as t4 on (t1.ExhibitionCentersId = t4.Id)
END;
