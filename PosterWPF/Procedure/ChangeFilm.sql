use Poster 
go
create procedure ChangeFilm
@Id int, 
@newName varchar(50),
@newDescriptionAndActors varchar(50),
@newPhoto varbinary(max),
@newGenre varchar(50),
@newCountry varchar(50),
@newDuration varchar(30) as
begin
update Films
set [Name] = @newName,
[DescriptionAndActors] = @newDescriptionAndActors,
[Photo] = @newPhoto,
[Genre] = @newGenre,
[Country] = @newCountry,
[Duration] = @newDuration
where [Id] = @Id
end;
