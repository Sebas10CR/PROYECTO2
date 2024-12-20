
CREATE TABLE Reparaciones
(
ReparacionID INT PRIMARY KEY IDENTITY(1,1),
EquipoID INT FOREIGN KEY REFERENCES Equipos(EquipoID),
FechaSolicitud DATE not null,
estado varchar(10) not null,
)
CREATE TABLE DetallesReparacion
(
DetalleID INT PRIMARY KEY IDENTITY(1,1),
ReparacionID INT FOREIGN KEY REFERENCES Reparaciones(ReparacionID),
Descripcion TEXT not null,
FechaInicio DATE not null,
FechaFin DATE not null,
estado varchar(10),
)
CREATE TABLE Asignaciones
(
AsignacionID INT PRIMARY KEY IDENTITY(1,1),
ReparacionID INT FOREIGN KEY REFERENCES Reparaciones(ReparacionID),
TecnicoID INT FOREIGN KEY REFERENCES Tecnicos(TecnicoID),
FechaAsignacion DATE,
estado varchar(10),
)










---Agregar REPARACIONES
create procedure IngresarReparacion
@EquipoID int,
@FechaSolicitud date,
@estado varchar(10)

as
begin
insert into Reparaciones values (@EquipoID, @FechaSolicitud, @estado)
end

---Borrar
create procedure BorrarReparacion
@ReparacionID int
as
begin
delete Reparaciones where ReparacionID=@ReparacionID
end

---Consultar
create procedure ConsultaReparaciones
as
begin
select *from Reparaciones
end

---Modificar
create procedure ModificarReparaciones
@ReparacionID int,
@EquipoID int,
@FechaSolicitud date,
@estado varchar (10)

as
begin
update Reparaciones set EquipoID=@EquipoID, FechaSolicitud=@FechaSolicitud, estado=@estado where ReparacionID=@ReparacionID
end



create procedure IngresarAsignacion
@ReparacionID int,
@TecnicoID int,
@FechaAsignacion date,
@estado varchar(10)

as
begin
insert into Asignaciones values (@ReparacionID, @TecnicoID, @FechaAsignacion, @estado)
end

---Borrar
create procedure BorrarAsignacion
@AsignacionID int

as
begin
delete Asignaciones where AsignacionID=@AsignacionID
end

---Consultar
create procedure ConsultaAsignacion
as
begin
select *from DetallesReparacion
end

---Modificar
create procedure ModificarAsignacion
@AsignacionID int,
@ReparacionID int,
@TecnicoID int,
@FechaAsignacion date,
@estado varchar(10)
as
begin
update Asignaciones set ReparacionID=@ReparacionID, TecnicoID=@TecnicoID, FechaAsignacion=@FechaAsignacion, estado=@estado where AsignacionID=@AsignacionID
end
