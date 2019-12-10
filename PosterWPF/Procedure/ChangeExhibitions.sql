use Poster 
go
create procedure ChangeExhibitions
@Id int, 
@newName varchar(50),
@newDescription varchar(50),
@newPhoto varbinary(max),
@newGenre varchar(50),
@newTime varchar(30) as
begin
update Exhibitions
set [Name] = @newName,
[DescriptionAndActors] = @newDescription,
[Time] = @newTime,
[Photo] = @newPhoto,
[Genre] = @newGenre
where [Id] = @Id
end;
