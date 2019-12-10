use Poster

go
create function CheckIdBE(@newId int)
returns int
as
begin
declare @count int
set @count = 0
while @count < 10000
begin
set @count = @count + 1
if(select count(Id) from BookedExhibitions where Id = @count) = 0
  break;
end;
return @count
end;
go 
create procedure AddBE
@newId int, 
@newDate date,
@newExhibitionsName varchar(50),
@newUserMail varchar(100) as
begin
  insert into BookedExhibitions(Id,[UserId],ExhibitionId,[DateId])
  values(dbo.CheckIdBE(@newId), dbo.SelectIdUser(@newUserMail) , dbo.SelectIdExhibitions(@newExhibitionsName), dbo.SelectIdDate(@newDate))
end;