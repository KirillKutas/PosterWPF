use Poster
go
CREATE PROCEDURE SelectAllBC AS
BEGIN
    select t1.Id, t2.[E-mail] as 'UserMail', t3.[Name] as 'Concert', t4.[Date] from BookedConcerts as t1
inner join Users as t2 on (t1.UserId = t2.Id) 
inner join Concerts as t3 on (t1.ConcertId = t3.Id)
inner join Calendar as t4 on (t1.DateId = t4.Id)
END;
