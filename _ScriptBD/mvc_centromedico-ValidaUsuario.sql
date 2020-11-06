
use mvc_centromedico;

go
drop table tbl_usuario;
go
create table tbl_usuario(
idusuario int not null,
usuario varchar(50),
clave varchar(50),
email varchar(50),
perfil int not null,
primary key(idusuario),
unique(usuario)
);

insert into tbl_usuario 
values(1, 'admin', convert(varchar(50), HashBytes('MD5', '12345'), 2), 'admin@centro.net', 1);

select * from tbl_usuario;

go
drop procedure sp_valida_usuario;
go
create procedure sp_valida_usuario
@usuario varchar(50),
@clave varchar(50)
as
	select 
	idusuario, usuario, '*****' clave, email, perfil 
	from tbl_usuario
	where perfil = 1
	and usuario = @usuario 
	and clave = convert(varchar(50), HashBytes('MD5', @clave), 2);
go

exec sp_valida_usuario 'admin', '12345';

go
drop procedure sp_buscar_usuario;
go
create procedure sp_buscar_usuario
@idusuario int
as
	select 
	idusuario, usuario, '*****' clave, email, perfil 
	from tbl_usuario
	where idusuario = @idusuario;
go

insert into tbl_usuario
select 
idpaciente, email,
convert(varchar(50), HashBytes('MD5', '2020'), 2),
email, 2 
from paciente
where not(idpaciente =any(select idusuario from tbl_usuario))
and not(email =any(select email from tbl_usuario));

-- select * from tbl_usuario;

go
drop procedure sp_valida_paciente;
go
create procedure sp_valida_paciente
@usuario varchar(50),
@clave varchar(50)
as
	select 
	idusuario, usuario, '*****' clave, email, perfil 
	from tbl_usuario
	where perfil = 2
	and usuario = @usuario 
	and clave = convert(varchar(50), HashBytes('MD5', @clave), 2);
go

exec sp_valida_paciente 'clorca@pacientes.net', '2020';

go
drop procedure sp_registra_paciente;
go
create procedure sp_registra_paciente
@nombres varchar(50), 
@apellidos varchar(50), 
@email varchar(50), 
@telefono int, 
@genero char(1),
@edad int,
@clave varchar(50)
as
	insert into paciente (nombres, apellidos, email, telefono, genero, edad)
	values(@nombres, @apellidos, @email, @telefono, @genero, @edad);

	declare @clavenew varchar(50);
	set @clavenew = convert(varchar(50), HashBytes('MD5', @clave), 2);

	declare @idusuario bigint;
	set @idusuario = @@IDENTITY;

	insert into tbl_usuario (idusuario, usuario, clave, email, perfil)
	values(@idusuario, @email, @clavenew, @email, 2);
go

select * from tbl_usuario;

