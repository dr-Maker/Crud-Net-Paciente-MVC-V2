
use mvc_centromedico;

go
drop procedure sp_listar_reserva;
go
create procedure sp_listar_reserva
as
	select 
	r.idreserva, h.idhora, h.fecha, h.horaminuto, 
	me.idmedico, 
	me.nombres nombres_me, 
	me.apellidos apellidos_me, 
	me.email email_me, 
	me.telefono telefono_me,
	me.idespecialidad, 
	esp.descripcion nom_especialidad, 
	pa.idpaciente, 
	pa.nombres nombres_pa, 
	pa.apellidos apellidos_pa, 
	pa.email email_pa, 
	pa.telefono telefono_pa, 
	pa.genero, pa.edad
	from reserva r
	join paciente pa       on  r.idpaciente       = pa.idpaciente
	join hora h            on  r.idhora           = h.idhora
	join medico me         on  h.idmedico         = me.idmedico and r.idmedico = me.idmedico
	join especialidad esp  on  me.idespecialidad  = esp.idespecialidad;
go

go
drop procedure sp_buscar_reserva;
go
create procedure sp_buscar_reserva
@idreserva int
as
	select 
	r.idreserva, h.idhora, h.fecha, h.horaminuto, 
	me.idmedico, 
	me.nombres nombres_me, 
	me.apellidos apellidos_me, 
	me.email email_me, 
	me.telefono telefono_me,
	me.idespecialidad, 
	esp.descripcion nom_especialidad, 
	pa.idpaciente, 
	pa.nombres nombres_pa, 
	pa.apellidos apellidos_pa, 
	pa.email email_pa, 
	pa.telefono telefono_pa, 
	pa.genero, pa.edad
	from reserva r
	join paciente pa       on  r.idpaciente       = pa.idpaciente
	join hora h            on  r.idhora           = h.idhora
	join medico me         on  h.idmedico         = me.idmedico and r.idmedico = me.idmedico
	join especialidad esp  on  me.idespecialidad  = esp.idespecialidad
	where r.idreserva = @idreserva;
go

-- *************************************************
go
drop procedure sp_listar_hora_filtro;
go
create procedure sp_listar_hora_filtro
@idestado int,
@fecha date,
@idmedico int,
@idespecialidad int
as
	select 
	h.idhora, h.fecha, h.horaminuto,
	me.*, esp.descripcion as nom_especialidad,
	e.idestado, e.descripcion as nom_estado
	from hora         h 
	join medico       me   on h.idmedico = me.idmedico
	join especialidad esp  on me.idespecialidad = esp.idespecialidad
	join estado       e    on h.idestado = e.idestado
	where (h.fecha = @fecha or @fecha = '1-1-1') 
	and (me.idmedico = @idmedico or @idmedico = 0) 
	and (esp.idespecialidad = @idespecialidad or @idespecialidad = 0) 
	and (h.idestado = @idestado or @idestado = 0);
go
-- *************************************************

go
drop procedure sp_mis_reservas;
go
create procedure sp_mis_reservas
@idpaciente int
as
	select 
	r.idreserva, h.idhora, h.fecha, h.horaminuto, 
	me.idmedico, 
	me.nombres nombres_me, 
	me.apellidos apellidos_me, 
	me.email email_me, 
	me.telefono telefono_me,
	me.idespecialidad, 
	esp.descripcion nom_especialidad, 
	pa.idpaciente, 
	pa.nombres nombres_pa, 
	pa.apellidos apellidos_pa, 
	pa.email email_pa, 
	pa.telefono telefono_pa, 
	pa.genero, pa.edad
	from reserva r
	join paciente pa       on  r.idpaciente       = pa.idpaciente
	join hora h            on  r.idhora           = h.idhora
	join medico me         on  h.idmedico         = me.idmedico and r.idmedico = me.idmedico
	join especialidad esp  on  me.idespecialidad  = esp.idespecialidad
	where pa.idpaciente = @idpaciente
	order by h.fecha desc, h.horaminuto desc;
go

go
drop procedure sp_hora_reserva;
go
create procedure sp_hora_reserva
@idmedico int,
@idpaciente int,
@idhora int
as
	insert into reserva (idmedico, idpaciente, idhora)
	values(@idmedico, @idpaciente, @idhora);

	update hora set idestado = 2
	where idhora = @idhora;
go

go
drop procedure sp_anular_reserva;
go
create procedure sp_anular_reserva
@idreserva int
as
	declare @idhoraold int;
	set @idhoraold=(select idhora from reserva where idreserva = @idreserva);
		
	update hora set idestado = 1
	where idhora = @idhoraold;

	delete from reserva 
	where idreserva = @idreserva;

go

-- exec sp_mis_reservas 2001;

exec sp_listar_hora_filtro 1, '1-1-1', 0, 2;
