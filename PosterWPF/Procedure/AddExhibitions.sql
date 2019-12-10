use Poster

go
create function CheckIdExhibitions(@newId int)
returns int
as
begin
declare @count int
set @count = 0
while @count < 10000
begin
set @count = @count + 1
if(select count(Id) from Exhibitions where Id = @count) = 0
  break;
end;
return @count
end;
go 
create procedure AddExhibitions
@newId int, 
@newName varchar(50),
@newDescription varchar(50),
@newPhoto varbinary(max),
@newGenre varchar(50),
@newTime varchar(30) as
begin
  insert into Exhibitions(Id,[Name],[DescriptionAndActors],[Time],[Photo],[Genre])
  values(dbo.CheckIdExhibitions(@newId),@newName,@newDescription,@newTime,@newPhoto,@newGenre)
end;