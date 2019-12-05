use Poster

go
create function CheckIdDate(@newId int)
returns int
as
begin
declare @count int
set @count = 0
while @count < 10000
begin
set @count = @count + 1
if(select count(Id) from Calendar where Id = @count) = 0
  break;
end;
return @count
end;
go 
create procedure AddDate
@newId int, 
@newDate date
as
begin
  insert into Calendar(Id,[Date])
  values(dbo.CheckIdDate(@newId),@newDate)
end;