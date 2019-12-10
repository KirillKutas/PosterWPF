use Poster
go
CREATE PROCEDURE SelectAllCICH AS
BEGIN
    select t1.Id, t2.[Date], t3.[Name] as 'ConcertsName', t4.[Name] as 'ConcertHallName', t1.[Price], t1.[FreeSpaces], t1.[ReservedSpaces] from ConcertsInConcertHalls as t1
inner join Calendar as t2 on (t1.[DateID] = t2.Id) 
inner join Concerts as t3 on (t1.ConcertsId = t3.Id)
inner join ConcertHalls as t4 on (t1.ConcertsHallsId = t4.Id)
END;
