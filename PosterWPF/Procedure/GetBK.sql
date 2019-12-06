use Poster
go
CREATE PROCEDURE SelectAllBK AS
BEGIN
    select t1.Id, t2.[E-mail] as 'UserMail', t3.[Name] as 'Film', t4.[Date] from BookedMovies as t1
inner join Users as t2 on (t1.UserId = t2.Id) 
inner join Films as t3 on (t1.FilmId = t3.Id)
inner join Calendar as t4 on (t1.DateId = t4.Id)
END;
