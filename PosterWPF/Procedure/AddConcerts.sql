use Poster

go
create function CheckIdConcerts(@newId int)
returns int
as
begin
declare @count int
set @count = 0
while @count < 10000
begin
set @count = @count + 1
if(select count(Id) from Concerts where Id = @count) = 0
  break;
end;
return @count
end;
go 
create procedure AddConcerts
@newId int, 
@newName varchar(50),
@newDescription varchar(50),
@newPhoto varbinary(max),
@newGenre varchar(50),
@newTime varchar(30) as
begin
  insert into Concerts(Id,[Name],[Description],[Time],[Photo],[Genre])
  values(dbo.CheckIdConcerts(@newId),@newName,@newDescription,@newTime,@newPhoto,@newGenre)
end;