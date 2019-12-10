use Poster

go
create function CheckIdBC(@newId int)
returns int
as
begin
declare @count int
set @count = 0
while @count < 10000
begin
set @count = @count + 1
if(select count(Id) from BookedConcerts where Id = @count) = 0
  break;
end;
return @count
end;
go 
create procedure AddBC
@newId int, 
@newDate date,
@newConcertsName varchar(50),
@newUserMail varchar(100) as
begin
  insert into BookedConcerts(Id,[UserId],[ConcertId],[DateId])
  values(dbo.CheckIdBC(@newId), dbo.SelectIdUser(@newUserMail) , dbo.SelectIdConcerts(@newConcertsName), dbo.SelectIdDate(@newDate))
end;