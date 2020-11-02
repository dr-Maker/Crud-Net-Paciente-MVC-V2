
-- create database mvc_centromedico;

use mvc_centromedico;

drop table reserva;
drop table paciente;
drop table hora;
drop table medico;
drop table especialidad;
drop table estado;

create table estado(
idestado int not null,
descripcion varchar(50),
primary key(idestado)
);

create table especialidad(
idespecialidad int not null,
descripcion varchar(50),
primary key(idespecialidad)
);

create table medico(
idmedico int identity(1001,1),
nombres varchar(50),
apellidos varchar(50),
email varchar(50),
telefono int not null,
idespecialidad int not null,
primary key(idmedico),
foreign key(idespecialidad) references especialidad(idespecialidad)
);

create table paciente(
idpaciente int identity(2001,1),
nombres varchar(50),
apellidos varchar(50),
email varchar(50),
telefono int not null,
genero char(1),
edad int not null,
primary key(idpaciente)
);

create table hora(
idhora int identity(5001,1),
fecha date not null,
horaminuto time not null,
idmedico int not null,
idestado int not null,
primary key(idhora),
unique(fecha, horaminuto, idmedico),
foreign key(idmedico) references medico(idmedico),
foreign key(idestado) references estado(idestado)
);

create table reserva(
idreserva int identity(6001,1),
idmedico int not null,
idpaciente int not null,
idhora int not null,
primary key(idreserva),
foreign key(idmedico) references medico(idmedico), 
foreign key(idpaciente) references paciente(idpaciente), 
foreign key(idhora) references hora(idhora)
);

insert into estado values(1, 'Disponible');
insert into estado values(2, 'Reservada');

insert into especialidad values('1', 'Medicina general');
insert into especialidad values('2', 'Pediatría');
insert into especialidad values('3', 'Oftalmología');
insert into especialidad values('4', 'Neurología');
insert into especialidad values('5', 'Cardiología');
insert into especialidad values('6', 'Traumatología');
insert into especialidad values('7', 'Dermatología');
insert into especialidad values('8', 'Ginecología');

insert into medico values('Felipe', 'Salas', 'fsalas@medico.net', '952785217', '1');
insert into medico values('German', 'Torres', 'gtorres@medico.net', '959464717', '2');
insert into medico values('Adela', 'Parra', 'aparra@medico.net', '968714124', '3');
insert into medico values('Victor', 'Lara', 'vlara@medico.net', '969146178', '4');
insert into medico values('Cecilia', 'Kolsch', 'ckolsch@medico.net', '966581549', '5');
insert into medico values('Ximena', 'Brand', 'xbrand@medico.net', '963477514', '6');
insert into medico values('Rene', 'Garrido', 'rgarrido@medico.net', '967876730', '7');
insert into medico values('Mireya', 'Tapia', 'mtapia@medico.net', '966161745', '8');
insert into medico values('Ricardo', 'Padilla', 'rpadilla@medico.net', '961550978', '1');

insert into paciente values('Christian', 'Lorca', 'clorca@pacientes.net', '989523595', 'M', '32');
insert into paciente values('Maria', 'Castillo', 'mcastillo@pacientes.net', '979293247', 'F', '28');
insert into paciente values('Rebeca', 'Rios', 'rrios@pacientes.net', '985319196', 'F', '24');
insert into paciente values('Miguel', 'Tapia', 'mtapia@pacientes.net', '978819879', 'M', '19');

/* */
insert into hora values('2020-11-19','09:00','1001','2' );
insert into hora values('2020-11-19','10:00','1002','2' );
insert into hora values('2020-11-19','11:00','1003','2' );
insert into hora values('2020-11-19','12:00','1004','2' );
insert into hora values('2020-11-19','13:00','1005','1' );
insert into hora values('2020-11-19','09:00','1006','1' );
insert into hora values('2020-11-19','10:00','1007','1' );
insert into hora values('2020-11-19','11:00','1008','1' );
insert into hora values('2020-11-20','09:00','1009','1' );
insert into hora values('2020-11-20','10:00','1001','1' );
insert into hora values('2020-11-20','11:00','1002','1' );
insert into hora values('2020-11-20','12:00','1003','1' );
insert into hora values('2020-11-20','13:00','1004','1' );
insert into hora values('2020-11-20','10:00','1005','1' );
insert into hora values('2020-11-20','11:00','1006','1' );
insert into hora values('2020-11-20','12:00','1007','1' );
insert into hora values('2020-11-21','09:00','1008','1' );
insert into hora values('2020-11-21','10:00','1009','1' );
insert into hora values('2020-11-21','11:00','1001','1' );
insert into hora values('2020-11-21','12:00','1002','1' );
insert into hora values('2020-11-21','13:00','1003','1' );
insert into hora values('2020-11-21','11:00','1004','1' );
insert into hora values('2020-11-21','12:00','1005','1' );
insert into hora values('2020-11-21','13:00','1006','1' );

insert into reserva values(1001, 2001, 5001);
insert into reserva values(1002, 2002, 5002);
insert into reserva values(1003, 2003, 5003);
insert into reserva values(1004, 2004, 5004);

insert into reserva values(1003, 2001, 5012);
insert into reserva values(1005, 2001, 5023);
 /* */

select 
h.idhora, h.fecha, h.horaminuto,
me.*, esp.descripcion as nom_especialidad,
e.idestado, e.descripcion as nom_estado
from hora         h 
join medico       me   on h.idmedico = me.idmedico
join especialidad esp  on me.idespecialidad = esp.idespecialidad
join estado       e    on h.idestado = e.idestado 
-- where h.idestado = 1;

