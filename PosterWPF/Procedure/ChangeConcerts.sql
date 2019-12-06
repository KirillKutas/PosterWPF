use Poster 
go
create procedure ChangeConcerts
@Id int, 
@newName varchar(50),
@newDescription varchar(50),
@newPhoto varbinary(max),
@newGenre varchar(50),
@newTime varchar(30) as
begin
update Concerts
set [Name] = @newName,
[Description] = @newDescription,
[Time] = @newTime,
[Photo] = @newPhoto,
[Genre] = @newGenre
where [Id] = @Id
end;
