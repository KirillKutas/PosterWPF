use Poster

go
create function CheckIdFilm(@newId int)
returns int
as
begin
declare @count int
set @count = 0
while @count < 10000
begin
set @count = @count + 1
if(select count(Id) from Films where Id = @count) = 0
  break;
end;
return @count
end;
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
  values(dbo.CheckIdFilm(@newId),@newName,@newDescriptionAndActors,@newPhoto,@newGenre,@newCountry,@newDuration)
end;