use Poster 
go
create procedure ChangeExhibitionCenters
@Id int, 
@newName varchar(50),
@newAddress varchar(70),
@newPhoto varbinary(max) as
begin
update ExhibitionCenters
set [Name] = @newName,
[Adress] = @newAddress,
[Photo] = @newPhoto
where [Id] = @Id
end;
