use Poster

go
create function CheckIdConcertHalls(@newId int)
returns int
as
begin
declare @count int
set @count = 0
while @count < 10000
begin
set @count = @count + 1
if(select count(Id) from ConcertHalls where Id = @count) = 0
  break;
end;
return @count
end;
go 
create procedure AddConcertHalls
@newId int, 
@newName varchar(50),
@newAddress varchar(70),
@newPhoto varbinary(max) as
begin
  insert into ConcertHalls(Id,[Name],[Adress],[Photo])
  values(dbo.CheckIdConcertHalls(@newId),@newName,@newAddress,@newPhoto)
end;