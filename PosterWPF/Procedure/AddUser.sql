use Poster
go
create function CheckIdUsers(@newId int)
returns int
as
begin
declare @count int
set @count = 0
while @count < 10000
begin
set @count = @count + 1
if(select count(Id) from Users where Id = @count) = 0
  break;
end;
return @count
end;
go 
create procedure AddUser
@newId int, 
@newMail varchar(100),
@newName varchar(50),
@newPassword varchar(150) as
begin
insert into Users(Id,[E-mail],[Name],[Password])
values(dbo.CheckIdUsers(@newId),@newMail,@newName,pwdencrypt(@newPassword)) 
end;

