use Poster 
go
create procedure ChangeBK
@Id int, 
@newDate date,
@newFilmsName varchar(50),
@newUserMail varchar(100) as
begin
update BookedMovies
set [UserId] = dbo.SelectIdUser(@newUserMail),
[FilmId] = dbo.SelectIdFilm(@newFilmsName),
[DateId] = dbo.SelectIdDate(@newDate)
where [Id] = @Id
end;
