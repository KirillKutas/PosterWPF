use Poster
go 
create procedure AddUser
@newId int, 
@newMail varchar(100),
@newName varchar(50),
@newPassword varchar(50) as
begin
insert into Users(Id,[E-mail],[Name],[Password])
values(@newId,@newMail,@newName,@newPassword)
end;