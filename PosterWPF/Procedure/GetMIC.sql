
use Poster
go
CREATE PROCEDURE SelectAllMIC AS
BEGIN
    select t1.Id, t2.[Date], t3.[Name] as 'FilmName', t4.[Name] as 'CinemaName', t1.[Price], t1.[Time], t1.[FreeSpaces], t1.[ReservedSpaces] from MoviesInCinemas as t1
inner join Calendar as t2 on (t1.[DateID] = t2.Id) 
inner join Films as t3 on (t1.FilmsId = t2.Id)
inner join Cinemas as t4 on (t1.CinemasId = t4.Id)
END;
