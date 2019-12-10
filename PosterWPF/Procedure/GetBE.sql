use Poster
go
CREATE PROCEDURE SelectAllBE AS
BEGIN
    select t1.Id, t2.[E-mail] as 'UserMail', t3.[Name] as 'Exhibition', t4.[Date] from BookedExhibitions as t1
inner join Users as t2 on (t1.UserId = t2.Id) 
inner join Exhibitions as t3 on (t1.ExhibitionId = t3.Id)
inner join Calendar as t4 on (t1.DateId = t4.Id)
END;
