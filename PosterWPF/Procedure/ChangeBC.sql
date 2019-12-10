use Poster 
go
create procedure ChangeBC
@Id int, 
@newDate date,
@newConcertsName varchar(50),
@newUserMail varchar(100) as
begin
update BookedConcerts
set [UserId] = dbo.SelectIdUser(@newUserMail),
ConcertId = dbo.SelectIdConcerts(@newConcertsName),
[DateId] = dbo.SelectIdDate(@newDate)
where [Id] = @Id
end;
