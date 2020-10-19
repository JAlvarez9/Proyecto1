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
PartidasGanadas int,
PartidasPerdidas int,
PartidasEmpatadas int,
TorneosJugados int,
TorneosGanadas int,
TorneosPerdidos int,
);

create table Partida(
idPartida int not null,
Primary key (idPartida),
Modo varchar(15)
);

create table DetallePartida(
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
idUsuarios int not null,
foreign key (idUsuarios) references Usuario(idUsuarios) on update cascade on delete cascade,
idTorneo int not null,
foreign key (idTorneo) references Torneo(idTorneo) on update cascade on delete cascade,
Estado varchar(10),
Ronda int,
Creador Bit,
);

select * from Usuario




