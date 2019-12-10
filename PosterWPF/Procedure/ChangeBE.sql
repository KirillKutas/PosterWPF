use Poster 
go
create procedure ChangeBE
@Id int, 
@newDate date,
@newExhibitionName varchar(50),
@newUserMail varchar(100) as
begin
update BookedExhibitions
set [UserId] = dbo.SelectIdUser(@newUserMail),
ExhibitionId = dbo.SelectIdExhibitions(@newExhibitionName),
[DateId] = dbo.SelectIdDate(@newDate)
where [Id] = @Id
end;
