use Poster 
go
create procedure ChangeUser
@Id int, 
@newMail varchar(100),
@newName varchar(50),
@newPassword varchar(50) as
begin
update Users
set [E-mail] = @newMail,
[Name] = @newName,
[Password] = @newPassword
where [Id] = @Id
end;
