create database ProyectoIPC2_Fase1;

use ProyectoIPC2_Fase1;

create table Usuario(
idUsuarios int Identity(0,1) not null,
primary key(idUsuarios),
Nombres varchar(20) not null,
Apellidos varchar(20) not null,
NombreUsuario varchar(20) UNIQUE not null,
Contrasenia varchar (30) not null,
FechaNacimiento date not null,
Pais varchar(20) not null,
Correo varchar(40) not null,
PartidasGanadas int not null,
PartidasPerdidas int not null,
PartidasEmpatadas int not null,
TorneosJugados int not null,
TorneosGanadas int not null,
TorneosPerdidos int not null,
);

create table Partida(
idPartida int not null,
Primary key (idPartida)
);

create table DetallePartida(
idDPartida int not null,
primary key (idDPartida),
idUsuarios int not null,
foreign key (idUsuarios) references Usuario(idUsuarios) on update cascade on delete cascade,
idPartida int not null,
foreign key (idPartida) references Partida(idPartida) on update cascade on delete cascade,
Estado varchar(10),
Movimientos int,
);

create table Torneo(
idTorneo int not null,
primary key(idTorneo),
Modo varchar(15),
);

create table DetalleTorneo(
idDTorneo int not null,
primary key(idDTorneo),
idUsuarios int not null,
foreign key (idUsuarios) references Usuario(idUsuarios) on update cascade on delete cascade,
idTorneo int not null,
foreign key (idTorneo) references Torneo(idTorneo) on update cascade on delete cascade,
);

select * from Usuario


