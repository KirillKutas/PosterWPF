use Poster 
go
create procedure ChangeCinema
@Id int, 
@newName varchar(50),
@newAddress varchar(70),
@newPhoto varbinary(max) as
begin
update Cinemas
set [Name] = @newName,
[Adress] = @newAddress,
[Photo] = @newPhoto
where [Id] = @Id
end;
