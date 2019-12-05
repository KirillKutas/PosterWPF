use Poster 
go
create procedure ChangeCalendar
@Id int, 
@newDate date as
begin
update Calendar
set [Date] = @newDate
where [Id] = @Id
end;
