use Poster
go
create procedure auth
@Pass varchar(150),
@Mail varchar(100),
@out int output as
begin
	declare @Userpass varbinary(150)
	select @Userpass = Password from Users where [E-mail] = @Mail
	set @out = pwdcompare(@Pass,@Userpass,0)
end;