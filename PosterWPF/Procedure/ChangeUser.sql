use Poster 
go
create procedure ChangeUser
@Id int, 
@newMail varchar(100),
@newName varchar(50),
@newPassword varchar(50) as
begin
if(@Id != 1)
begin
update Users
set [E-mail] = @newMail,
[Name] = @newName,
[Password] = pwdencrypt(@newPassword) 
where [Id] = @Id
end;
end;
