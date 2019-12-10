use Poster 
go
create procedure ChangeConcertHalls
@Id int, 
@newName varchar(50),
@newAddress varchar(70),
@newPhoto varbinary(max) as
begin
update ConcertHalls
set [Name] = @newName,
[Adress] = @newAddress,
[Photo] = @newPhoto
where [Id] = @Id
end;
