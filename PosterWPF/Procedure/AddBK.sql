use Poster

go
create function CheckIdBK(@newId int)
returns int
as
begin
declare @count int
set @count = 0
while @count < 10000
begin
set @count = @count + 1
if(select count(Id) from BookedMovies where Id = @count) = 0
  break;
end;
return @count
end;
go
create function SelectIdUser(@newUserMail varchar(100))
returns int
as
begin
  declare @Id int
   select @Id = Id from Users where [E-mail] = @newUserMail
  return @Id
end;
go 
create procedure AddBK
@newId int, 
@newDate date,
@newFilmsName varchar(50),
@newUserMail varchar(100) as
begin
  insert into BookedMovies(Id,[UserId],[FilmId],[DateId])
  values(dbo.CheckIdBK(@newId), dbo.SelectIdUser(@newUserMail) , dbo.SelectIdFilm(@newFilmsName), dbo.SelectIdDate(@newDate))
end;