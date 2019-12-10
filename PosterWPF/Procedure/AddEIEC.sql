use Poster

go
create function CheckIdEIEC(@newId int)
returns int
as
begin
declare @count int
set @count = 0
while @count < 10000
begin
set @count = @count + 1
if(select count(Id) from ExhibitionsInExhibitionCenters where Id = @count) = 0
  break;
end;
return @count
end;
go
create function SelectIdExhibitions(@newFilmsName varchar(50))
returns int
as
begin
  declare @Id int
   select @Id = Id from Exhibitions where [Name] = @newFilmsName
  return @Id
end;
go
create function SelectIdExhibitionCenters(@newCinemasName varchar(50))
returns int
as
begin
  declare @Id int
   select @Id = Id from ExhibitionCenters where [Name] = @newCinemasName
  return @Id
end;
go 
create procedure AddEIEC
@newId int, 
@newDate date,
@newExhibitionsName varchar(50),
@newExhibitionCentersName varchar(50),
@newPrice int,
@newFreeSpaces int,
@newReservedSpaces int as
begin
  insert into ExhibitionsInExhibitionCenters(Id,[DateID],[ExhibitionsId],[ExhibitionCentersId],[Price],[FreeSpaces],[ReservedSpaces])
  values(dbo.CheckIdEIEC(@newId), dbo.SelectIdDate(@newDate), dbo.SelectIdExhibitions(@newExhibitionsName), dbo.SelectIdExhibitionCenters(@newExhibitionCentersName), @newPrice, @newFreeSpaces, @newReservedSpaces)
end;