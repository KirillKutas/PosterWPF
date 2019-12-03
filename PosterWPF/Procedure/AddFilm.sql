use Poster
go 
create procedure AddFilm
@newId int, 
@newName varchar(50),
@newDescriptionAndActors varchar(50),
@newPhoto varbinary(max),
@newGenre varchar(50),
@newCountry varchar(50),
@newDuration varchar(30) as
begin
insert into Films(Id,[Name],[DescriptionAndActors],[Photo],[Genre],[Country],[Duration])
values(@newId,@newName,@newDescriptionAndActors,@newPhoto,@newGenre,@newCountry,@newDuration)
end;