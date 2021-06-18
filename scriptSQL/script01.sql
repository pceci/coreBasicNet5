--- Crear base de datos
USE master
GO
CREATE DATABASE BD_base
GO
USE BD_base
GO
CREATE SCHEMA seg
go
CREATE TABLE  seg.tbl_estados(
	est_codigo int NOT NULL IDENTITY (1, 1) PRIMARY KEY CLUSTERED ,
	est_nombre nvarchar(50) NOT  NULL,
	)  ON [PRIMARY]
--
insert seg.tbl_estados (est_nombre) values('Sin estado')
insert seg.tbl_estados (est_nombre) values('Activo')
insert seg.tbl_estados (est_nombre) values('Inactivo')
GO
--	
CREATE TABLE  seg.tbl_accion(
	acc_codigo int NOT NULL IDENTITY (1, 1) PRIMARY KEY CLUSTERED ,
	acc_nombre nvarchar(50) NOT  NULL,
	)  ON [PRIMARY]

--
insert  seg.tbl_accion (acc_nombre ) values('Alta')
insert  seg.tbl_accion (acc_nombre ) values('Modificar')
insert  seg.tbl_accion(acc_nombre ) values('Cambiar estado')
insert  seg.tbl_accion (acc_nombre ) values('Cambiar contraseña')
insert  seg.tbl_accion(acc_nombre ) values('Cambiar orden')
insert  seg.tbl_accion(acc_nombre ) values('Cambio permiso publicación')
insert  seg.tbl_accion(acc_nombre ) values('Eliminar')
GO
--		
-- Tabla rol
CREATE TABLE seg.tblRol
	(
	rol_codRol int NOT NULL IDENTITY (1, 1) PRIMARY KEY CLUSTERED ,
	rol_Nombre nvarchar(80) NOT NULL UNIQUE
	)  ON [PRIMARY]
	
	insert seg.tblRol(rol_Nombre) values('Administrador')
-- Tabla Regla
CREATE TABLE seg.tblRegla
	(
	rgl_codRegla int NOT NULL IDENTITY (1, 1) PRIMARY KEY CLUSTERED ,
	rgl_Descripcion nvarchar(250) NOT NULL,
	rgl_PalabraClave nvarchar(50) NOT NULL UNIQUE,
	rgl_IsAgregarSoporta bit NOT NULL DEFAULT 0,
	rgl_IsEditarSoporta bit NOT NULL DEFAULT 0,
	rgl_IsEliminarSoporta bit NOT NULL DEFAULT 0,
	rgl_codReglaPadre int  NULL
	)  ON [PRIMARY]
	insert seg.tblRegla(rgl_Descripcion,rgl_PalabraClave,rgl_IsAgregarSoporta,rgl_IsEditarSoporta,rgl_IsEliminarSoporta,rgl_codReglaPadre) 
	values('Raiz','raiz',1,1,1,null) -- 1
	,('Gestión rol','gestionrol',1,1,1,1) -- 2
    ,('Gestión regla','gestionregla',1,1,1,1) -- 3
	,('Gestión roles y reglas','gestionrolesyreglas',1,1,1,1) -- 4
    ,('Gestión usuario','gestionusuario',1,1,1,1) -- 5
	,('Gestión noticia','gestionnoticia',1,1,1,1) -- 6
GO	
-- Tabla relacion rol y regla
CREATE TABLE seg.tblRelacionRolRegla
	(
	rrr_codRelacionRolRegla int NOT NULL IDENTITY (1, 1) PRIMARY KEY CLUSTERED ,
	rrr_codRol int NOT NULL REFERENCES  seg.tblRol (rol_codRol) ,
	rrr_codRegla int NOT NULL REFERENCES  seg.tblRegla (rgl_codRegla) ,
	rrr_IsActivo bit NOT NULL ,
	rrr_IsAgregar bit NULL,
	rrr_IsEditar bit  NULL,
	rrr_IsEliminar bit  NULL,
	CONSTRAINT rectriccion UNIQUE(rrr_codRol,rrr_codRegla) 
	)  ON [PRIMARY]
	insert seg.tblRelacionRolRegla(rrr_codRol,rrr_codRegla,rrr_IsActivo,rrr_IsAgregar,rrr_IsEditar ,rrr_IsEliminar) 
	values(1,2,1,1,1,1)	
	,(1,3,1,1,1,1)	
	,(1,4,1,1,1,1)	
	,(1,5,1,1,1,1)	
	,(1,6,1,1,1,1)	
GO	
-- Tabla usuario
CREATE TABLE seg.tbl_usuarios(
	usu_codigo int NOT NULL IDENTITY (1, 1) PRIMARY KEY CLUSTERED ,
	usu_codRol int NOT NULL REFERENCES seg.tblRol(rol_codRol),
	usu_codCliente int NULL,
	usu_nombre nvarchar(50)  NULL,
	usu_apellido nvarchar(50)  NULL,
	usu_mail nvarchar(255) NOT  NULL,
	usu_login nvarchar(255)   NULL default '',
	usu_psw  varbinary(255) NOT NULL ,
    usu_pswDesencriptado nvarchar(255)   NULL default '',
	usu_dni  nvarchar(50)  NULL,
	usu_domicilio nvarchar(50)  NULL,
	usu_localidad  nvarchar(50)  NULL,
	usu_telefono  nvarchar(50)  NULL,
	usu_celular  nvarchar(50)  NULL,
	usu_observacion  nvarchar(max)  NULL,
	usu_estudios nvarchar(50)  NULL,
	usu_titulo nvarchar(50)  NULL,
	usu_cargo nvarchar(100)  NULL,
	usu_codsec int NULL,
    usu_codtip int NULL,
	usu_fecnac  datetime  NULL,
	usu_fecpsw  datetime  NULL,
	usu_estado int  NOT NULL REFERENCES seg.tbl_estados(est_codigo),
	usu_fechaUltMov datetime NOT NULL ,
	usu_codUsuarioUltMov int NULL  REFERENCES seg.tbl_usuarios(usu_codigo),
	usu_codAccion int NULL  REFERENCES seg.tbl_accion(acc_codigo)
)  ON [PRIMARY]
insert seg.tbl_usuarios(usu_codRol,usu_nombre,usu_apellido,usu_mail,usu_login,usu_psw  ,usu_estado,usu_fechaUltMov ) 
values(1,'admin','admin','admin@mail.com','admin',pwdEncrypt ('123456'),2,'01-02-1999')
GO
----

-- Tabla log de usuario para auditoria
CREATE TABLE seg.tblUsuarioLog
	(
	ulg_codUsuarioLog int NOT NULL IDENTITY (1, 1) PRIMARY KEY CLUSTERED ,
	ulg_codUsuario int NOT NULL REFERENCES seg.tbl_usuarios(usu_codigo),
	ulg_FechaIngreso datetime NOT NULL ,
	ulg_FechaCierreSession datetime  NULL,
	ulg_Ip nvarchar(255) NULL ,
	ulg_Host nvarchar(255) NULL ,
	ulg_UserAgent nvarchar(255) NULL 
	)  ON [PRIMARY]
----------
GO
--- Recursos

create table seg.tbl_archivos
	(
	arc_codRecurso int NOT NULL IDENTITY (1, 1) PRIMARY KEY ,
	arc_codRelacion int NOT NULL, 
	arc_galeria nvarchar(50) NOT NULL ,
	arc_orden int NOT NULL,
	arc_tipo nvarchar(50) NOT NULL ,
	arc_mime nvarchar(100) NOT NULL ,
	arc_nombre nvarchar(150) NOT NULL,
	arc_titulo nvarchar(200) NULL,
	arc_descripcion nvarchar(max) NULL,
	arc_hash nvarchar(50) NOT NULL default '',
	arc_fecha datetime  NULL,
	arc_accion  int NULL  REFERENCES seg.tbl_accion(acc_codigo),
	arc_estado int NULL REFERENCES seg.tbl_estados(est_codigo),
	arc_fechaUltMov datetime NULL ,
	arc_codUsuarioUltMov int NULL  REFERENCES seg.tbl_usuarios(usu_codigo)
	)  ON [PRIMARY]
go	
--- eliminar el indice cluster que por defecto genera PRIMARY KEY 
CREATE INDEX IX_archivos_codRelacionGaleria ON seg.tbl_archivos(arc_codRelacion,arc_galeria)
 GO

 -----------
 CREATE TABLE seg.[Error](
	err_id [int] IDENTITY(1,1) NOT NULL,
	err_Nombre [nvarchar](max) NULL,
	err_Parameters [nvarchar](max) NULL,
	err_Data [nvarchar](max) NULL,
	err_HelpLink  [nvarchar](max) NULL,
	err_InnerException [nvarchar](max) NULL,
	err_Message [nvarchar](max) NULL,
	err_Source [nvarchar](max) NULL,
	err_StackTrace [nvarchar](max) NULL,
	err_fecha [datetime] NULL,
	err_tipo [nvarchar](200) NULL,
	[log_Error_Number] [int] NULL,
	[log_Error_Message] [nvarchar](4000) NULL,
	[log_Error_Severity] [int] NULL,
	[log_Error_State] [int] NULL,
	[log_Error_Line] [int] NULL,
	[log_Error_Procedure] [nvarchar](200) NULL,
	[log_UserName] [nvarchar](200) NULL,
	[log_HostName] [nvarchar](200) NULL,
	[log_Time_Stamp] [datetime] NULL,
	[log_MensajePersonalizado] [nvarchar](max) NULL)
 
----------------
---------------------------------------------------------
----------------------------------------------------------
-----------------------------------------------------------

--- Procedimiento para el logueo del sitio
IF OBJECT_ID ( 'seg.spInicioSession', 'P' ) IS NOT NULL 
    DROP PROCEDURE seg.spInicioSession;
GO
CREATE  PROCEDURE [seg].[spInicioSession] 
    @login nvarchar(255), 
    @Password nvarchar(255), 
    @Ip nvarchar(255), 
    @Host nvarchar(255),
    @UserName nvarchar(255)
AS 
BEGIN
BEGIN TRANSACTION
declare @codigoUsuarioLog int
DECLARE @codigoUsuario int
 SET @codigoUsuario =  (SELECT usu_codigo  FROM seg.tbl_usuarios
 WHERE usu_login = @login and PWDCOMPARE (@Password , usu_psw) = 1 )
IF @codigoUsuario is not null
BEGIN
INSERT INTO seg.tblUsuarioLog
(ulg_codUsuario, ulg_FechaIngreso, ulg_Ip, ulg_Host, ulg_UserAgent)
values (@codigoUsuario, GETDATE(), @Ip, @Host, @UserName);
set  @codigoUsuarioLog = SCOPE_IDENTITY()	
END
select usu_codigo,usu_login,usu_codRol, usu_nombre ,usu_apellido,ulg_codUsuarioLog,usu_estado,usu_codCliente--,usu_pswDesencriptado
from seg.tbl_usuarios  inner join  seg.tblUsuarioLog on  usu_codigo = ulg_codUsuario 
where ulg_codUsuarioLog = @codigoUsuarioLog 
COMMIT
END
GO
--- Procedimiento para el cierre del logueo del sitio
IF OBJECT_ID ( 'seg.spCerrarSession', 'P' ) IS NOT NULL 
    DROP PROCEDURE seg.spCerrarSession;
GO
CREATE PROCEDURE seg.spCerrarSession
    @IdUsuarioLog int
AS 
BEGIN
BEGIN TRANSACTION

update seg.tblUsuarioLog
set ulg_FechaCierreSession = GETDATE()
where ulg_codUsuarioLog = @IdUsuarioLog
COMMIT
END
GO
-------
--- Procedimiento cambiar contraseña personal
IF OBJECT_ID ( 'seg.spCambiarContraseñaPersonal', 'P' ) IS NOT NULL 
    DROP PROCEDURE seg.spCambiarContraseñaPersonal;
GO
CREATE PROCEDURE seg.spCambiarContraseñaPersonal
    @usu_codigo int,
	@PasswordViejo  nvarchar(255) ,
	@PasswordNuevo  nvarchar(255) ,
	@usu_codAccion int
AS 
BEGIN
BEGIN TRANSACTION

declare @cant int
select @cant = COUNT(usu_codigo) from
seg.tbl_usuarios
WHERE usu_codigo = @usu_codigo and PWDCOMPARE (@PasswordViejo , usu_psw) = 1 

if @cant = 1
begin
UPDATE seg.tbl_usuarios
SET   usu_psw = pwdEncrypt (@PasswordNuevo),
      usu_pswDesencriptado = @PasswordNuevo,
	  usu_fechaUltMov =  GetDate(),
      usu_codUsuarioUltMov = @usu_codigo,
      usu_codAccion = @usu_codAccion
WHERE usu_codigo = @usu_codigo
end

select @cant

COMMIT
END
GO
---
--- Gestion regla
IF OBJECT_ID ( 'seg.spGestionRegla', 'P' ) IS NOT NULL 
	DROP PROCEDURE seg.spGestionRegla;
GO
CREATE PROCEDURE seg.spGestionRegla
	@rgl_codRegla int,
	@rgl_Descripcion nvarchar(250),
	@rgl_PalabraClave nvarchar(50),	
	@rgl_IsAgregarSoporta  bit,
	@rgl_IsEditarSoporta  bit,
	@rgl_IsEliminarSoporta  bit,
	@rgl_codReglaPadre int,
	@filtro nvarchar(50),
	@accion nvarchar(50)--,
--	@orderby nvarchar(50)
AS 
IF @accion = 'INSERT'
		BEGIN
declare @codigoRegla int 

INSERT INTO seg.tblRegla
(rgl_Descripcion, rgl_PalabraClave, rgl_IsAgregarSoporta,rgl_IsEditarSoporta,rgl_IsEliminarSoporta,rgl_codReglaPadre)
values (@rgl_Descripcion, @rgl_PalabraClave, @rgl_IsAgregarSoporta,@rgl_IsEditarSoporta,@rgl_IsEliminarSoporta,@rgl_codReglaPadre)

set @codigoRegla = SCOPE_IDENTITY()	

select @codigoRegla as rgl_codRegla
		END
	ELSE IF @accion = 'UPDATE'
		BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
		DECLARE @isAgregar as bit 
DECLARE @isEditar as bit
DECLARE @isEliminar as bit

SELECT  @isAgregar = rgl_IsAgregarSoporta ,  @isEditar = rgl_IsEditarSoporta,
@isEliminar = rgl_IsEliminarSoporta
from seg.tblRegla
WHERE rgl_codRegla = @rgl_codRegla


UPDATE seg.tblRegla
SET rgl_Descripcion = @rgl_Descripcion,
	rgl_IsAgregarSoporta = @rgl_IsAgregarSoporta,
	rgl_IsEditarSoporta = @rgl_IsEditarSoporta,
	rgl_IsEliminarSoporta = @rgl_IsEliminarSoporta,
	rgl_codReglaPadre =  @rgl_codReglaPadre
WHERE rgl_codRegla = @rgl_codRegla

if @isAgregar <> @rgl_IsAgregarSoporta
begin
if @rgl_IsAgregarSoporta = 0
begin
UPDATE seg.tblRelacionRolRegla
SET rrr_IsAgregar = NULL
where rrr_codRegla = @rgl_codRegla
end
else
begin
UPDATE seg.tblRelacionRolRegla
SET rrr_IsAgregar = 0
where rrr_codRegla = @rgl_codRegla
end
end

if @isEditar <> @rgl_IsEditarSoporta
begin
if @rgl_IsEditarSoporta = 0
begin
UPDATE seg.tblRelacionRolRegla
SET rrr_IsEditar = NULL
where rrr_codRegla = @rgl_codRegla
end
else
begin 
UPDATE seg.tblRelacionRolRegla
SET rrr_IsEditar = 0
where rrr_codRegla = @rgl_codRegla
end
end

if @isEliminar <> @rgl_IsEliminarSoporta
begin
if @rgl_IsEliminarSoporta = 0
begin
UPDATE seg.tblRelacionRolRegla
SET rrr_IsEliminar = NULL
where rrr_codRegla = @rgl_codRegla
end
else
begin
UPDATE seg.tblRelacionRolRegla
SET rrr_IsEliminar = 0
where rrr_codRegla = @rgl_codRegla
end
end
				
		COMMIT TRANSACTION 
		END TRY
		BEGIN CATCH
		ROLLBACK TRANSACTION 
		END CATCH
	
		END
--	ELSE IF @accion = 'ESTADO'
	--	BEGIN
		--	UPDATE seg.tblRegla SET
		--		 cli_estado = @cli_estado
		--	WHERE
		--		rgl_codRegla = @rgl_codRegla
	--	END
	ELSE IF @accion = 'DELETE'
		BEGIN	
BEGIN TRANSACTION
BEGIN TRY
select rgl_codRegla from seg.tblRegla where rgl_codReglaPadre = @rgl_codRegla
IF @@ROWCOUNT = 0
begin
delete from seg.tblRelacionRolRegla where rrr_codRegla = @rgl_codRegla
delete from seg.tblRegla where rgl_codRegla = @rgl_codRegla
end
COMMIT TRANSACTION 
END TRY
BEGIN CATCH
ROLLBACK TRANSACTION 
END CATCH		
		END	
	ELSE IF @accion = 'SELECT'
		BEGIN
			IF @rgl_codRegla <> 0
				BEGIN
					SELECT rgl_codRegla,rgl_Descripcion,rgl_PalabraClave,rgl_IsAgregarSoporta,rgl_IsEditarSoporta,rgl_IsEliminarSoporta,rgl_codReglaPadre
					FROM seg.tblRegla
					WHERE rgl_codRegla = @rgl_codRegla
				END
			ELSE
				BEGIN
				IF @filtro <> ''
					BEGIN
						SELECT rgl_codRegla,rgl_Descripcion,rgl_PalabraClave,rgl_IsAgregarSoporta,rgl_IsEditarSoporta,rgl_IsEliminarSoporta,rgl_codReglaPadre
						FROM seg.tblRegla
						WHERE rgl_Descripcion LIKE '%' + @filtro + '%' OR rgl_PalabraClave LIKE  '%' +  @filtro  + '%' 
						ORDER BY rgl_Descripcion ASC
					END
				ELSE
					BEGIN
						SELECT rgl_codRegla,rgl_Descripcion,rgl_PalabraClave,rgl_IsAgregarSoporta,rgl_IsEditarSoporta,rgl_IsEliminarSoporta,rgl_codReglaPadre
						FROM seg.tblRegla
						ORDER BY rgl_Descripcion  ASC
					END					
				END
		END
	ELSE IF @accion = 'COMBO'
		BEGIN
			SELECT rgl_codRegla,rgl_Descripcion, rgl_PalabraClave
			FROM seg.tblRegla
			ORDER BY rgl_Descripcion ASC
		END
GO		
-- fin gestion regla	
--- Recuperar acciones de usuario
IF OBJECT_ID ( 'seg.spRecuperarAccionesUsuario', 'P' ) IS NOT NULL 
    DROP PROCEDURE seg.spRecuperarAccionesUsuario;
GO
CREATE PROCEDURE seg.spRecuperarAccionesUsuario
   @IdRol int
AS 
BEGIN TRANSACTION
IF OBJECT_ID ( 'tempdb..#TempRoles' ) IS NOT NULL 
begin
   DROP TABLE #TempRoles
end

select * 
into #TempRoles
from seg.tblRelacionRolRegla 
where rrr_codRol = @IdRol

select  rgl_codRegla, rrr_codRelacionRolRegla,rgl_PalabraClave,rgl_Descripcion, rrr_IsActivo, rrr_IsAgregar, rrr_IsEditar, rrr_IsEliminar
from seg.tblRegla
LEFT  join #TempRoles on rgl_codRegla = rrr_codRegla

DROP TABLE #TempRoles	
COMMIT
GO
--- fin Recuperar acciones de usuario
--- Recuperar todas las reglas por niveles
IF OBJECT_ID ( 'seg.spRecuperarTodasReglasPorNiveles', 'P' ) IS NOT NULL 
    DROP PROCEDURE seg.spRecuperarTodasReglasPorNiveles;
GO
CREATE PROCEDURE seg.spRecuperarTodasReglasPorNiveles
AS 
WITH tblReglaTemp (rgl_codRegla, rgl_Descripcion,rgl_PalabraClave, rgl_codReglaPadre,rgl_IsAgregarSoporta,rgl_IsEditarSoporta,rgl_IsEliminarSoporta, Level)
AS
(
-- select base
    SELECT rgl_codRegla, rgl_Descripcion,rgl_PalabraClave, rgl_codReglaPadre,rgl_IsAgregarSoporta,rgl_IsEditarSoporta,rgl_IsEliminarSoporta,
        0 AS Level
    FROM seg.tblRegla AS e
    WHERE rgl_codReglaPadre IS NULL
    UNION ALL
-- Select recursivo
    SELECT e.rgl_codRegla, e.rgl_Descripcion,e.rgl_PalabraClave, e.rgl_codReglaPadre,e.rgl_IsAgregarSoporta,e.rgl_IsEditarSoporta,e.rgl_IsEliminarSoporta,
        Level + 1
   FROM seg.tblRegla AS e
    INNER JOIN tblReglaTemp AS d
        ON e.rgl_codReglaPadre = d.rgl_codRegla
)
SELECT rgl_codRegla, rgl_Descripcion,rgl_PalabraClave, rgl_codReglaPadre,rgl_IsAgregarSoporta,rgl_IsEditarSoporta,rgl_IsEliminarSoporta, Level
FROM tblReglaTemp

GO
--- fin Recuperar todas las reglas por niveles
--- Gestion rol
IF OBJECT_ID ( 'seg.spGestionRol', 'P' ) IS NOT NULL 
	DROP PROCEDURE seg.spGestionRol;
GO
CREATE PROCEDURE seg.spGestionRol
	@rol_codRol int,
	@rol_Nombre nvarchar(80),
	@filtro nvarchar(50),
	@accion nvarchar(50)--,
	--@orderby nvarchar(50)
AS 
IF @accion = 'INSERT'
		BEGIN
declare @codigoRol int 

INSERT INTO  seg.tblRol
(rol_Nombre)
values (@rol_Nombre)

set @codigoRol = SCOPE_IDENTITY()	

select @codigoRol as rol_codRol
		END
	ELSE IF @accion = 'UPDATE'
		BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
		
		UPDATE tblRol
SET rol_Nombre = @rol_Nombre
WHERE rol_codRol = @rol_codRol
				
		COMMIT TRANSACTION 
		END TRY
		BEGIN CATCH
		ROLLBACK TRANSACTION 
		END CATCH
	
		END
	ELSE IF @accion = 'DELETE'
		BEGIN
		
		BEGIN TRANSACTION
		BEGIN TRY
--delete from tblUsuario where usr_codRol = @rol_codRol
--delete from tblRelacionRolRegla where rrr_codRol = @rol_codRol
delete from tblRol where rol_codRol = @rol_codRol
      COMMIT TRANSACTION 
		END TRY
		BEGIN CATCH
		ROLLBACK TRANSACTION 
		END CATCH
		
		END		
--	ELSE IF @rgl_accion = 'ESTADO'
	--	BEGIN
		--	UPDATE seg.tblRegla SET
		--		 cli_estado = @cli_estado
		--	WHERE
		--		rgl_codRegla = @rgl_codRegla
	--	END
	ELSE IF @accion = 'SELECT'
		BEGIN
			IF @rol_codRol <> 0
				BEGIN
					SELECT rol_codRol,rol_Nombre
					FROM seg.tblRol
					WHERE rol_codRol = @rol_codRol
				END
			ELSE
				BEGIN
				IF @filtro <> ''
					BEGIN
						SELECT rol_codRol,rol_Nombre
						FROM seg.tblRol
						WHERE rol_Nombre LIKE '%' + @filtro + '%' 
						--+ ' ' + @orderby 
						ORDER BY rol_Nombre ASC
					END
				ELSE
					BEGIN
						SELECT rol_codRol,rol_Nombre
						FROM seg.tblRol
						--' ' + @orderby 
						ORDER BY rol_Nombre ASC
					END					
				END
		END
	ELSE IF @accion = 'COMBO'
		BEGIN
						SELECT rol_codRol,rol_Nombre
						FROM seg.tblRol
						ORDER BY rol_Nombre ASC
		END
GO		
-- fin gestion rol	
--- Gestion relacion rol y regla
IF OBJECT_ID ( 'seg.spGestionRelacionRoleRegla', 'P' ) IS NOT NULL 
	DROP PROCEDURE seg.spGestionRelacionRoleRegla;
GO
CREATE PROCEDURE seg.spGestionRelacionRoleRegla
	@rrr_codRol int,
	@rrr_codRegla int,	
	--@filtro nvarchar(50),
	@accion nvarchar(50),
    @strXML as xml
AS 
IF @accion = 'UPDATE' or @accion = 'INSERT'
		BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
IF OBJECT_ID ( 'tempdb..#TempReglaRol' ) IS NOT NULL 
begin
   DROP TABLE #TempReglaRol
end

SELECT IDRegla = T.Item.value('@idRegla', 'int') ,
       IDRelacionReglaRol = T.Item.value('@idRelacionReglaRol', 'int'),
       IsActivo  = T.Item.value('@isActivo',  'bit'),
       IsAgregado  = T.Item.value('@isAgregado',  'bit'),
       IsEditado  = T.Item.value('@isEditado',  'bit'),
       IsEliminado  = T.Item.value('@isEliminado',  'bit')
into #TempReglaRol
FROM   @strXML.nodes('/Root/Regla') AS T(Item)

-- Se agrega las nuevas relaciones reglas y rol
INSERT INTO seg.tblRelacionRolRegla (rrr_codRol, rrr_codRegla, rrr_IsActivo,rrr_IsAgregar,rrr_IsEditar,rrr_IsEliminar)
SELECT @rrr_codRol, IDRegla, IsActivo, IsAgregado, IsEditado, IsEliminado
FROM #TempReglaRol
WHERE IDRelacionReglaRol = -1

---- Se elimina la relaciones reglas y rol
--DELETE   FROM tblRelacionRolRegla 
--where rrr_codRelacionRolRegla in (select IDRelacionReglaRol from #TempReglaRol
--WHERE IsActivo  = 0  and
--(IsAgregado is null or IsAgregado = 0)
--and (IsEditado is null or IsEditado = 0)
--and (IsEliminado is null or IsEliminado = 0) )

-- Se modifica la tabla relacion reglas y rol
UPDATE seg.tblRelacionRolRegla
SET rrr_IsActivo = tb2.IsActivo,
    rrr_IsAgregar = tb2.IsAgregado,
    rrr_IsEditar = tb2.IsEditado,
    rrr_IsEliminar = tb2.IsEliminado
FROM seg.tblRelacionRolRegla tb1
INNER JOIN #TempReglaRol tb2 on
	tb1.rrr_codRelacionRolRegla = tb2.IDRelacionReglaRol
	
DROP TABLE #TempReglaRol	
 		
		COMMIT TRANSACTION 
		END TRY
		BEGIN CATCH
		ROLLBACK TRANSACTION 
		END CATCH
	
		END
--	ELSE IF @accion = 'ESTADO'
	--	BEGIN
		--	UPDATE seg.tblRegla SET
		--		 cli_estado = @cli_estado
		--	WHERE
		--		rgl_codRegla = @rgl_codRegla
	--	END
	ELSE IF @accion = 'SELECT'
		BEGIN
			IF @rrr_codRol <> 0
				BEGIN
					SELECT rrr_codRelacionRolRegla,rrr_codRol,rrr_codRegla,rrr_IsActivo,rrr_IsAgregar,rrr_IsEditar,rrr_IsEliminar
                    FROM seg.tblRelacionRolRegla
					WHERE rrr_codRol = @rrr_codRol
				END
			ELSE IF @rrr_codRegla <> 0
				BEGIN
					SELECT rrr_codRelacionRolRegla,rrr_codRol,rrr_codRegla,rrr_IsActivo,rrr_IsAgregar,rrr_IsEditar,rrr_IsEliminar
                    FROM seg.tblRelacionRolRegla
					WHERE rrr_codRegla = @rrr_codRegla
				END
			ELSE
				BEGIN
				--IF @filtro <> ''
				--	BEGIN
				--    	SELECT rrr_codRelacionRolRegla,rrr_codRol,rrr_codRegla,rrr_IsActivo,rrr_IsAgregar,rrr_IsEditar,rrr_IsEliminar
				--		FROM seg.tblRelacionRolRegla
				--	END
				--ELSE
				--	BEGIN
				    	SELECT rrr_codRelacionRolRegla,rrr_codRol,rrr_codRegla,rrr_IsActivo,rrr_IsAgregar,rrr_IsEditar,rrr_IsEliminar
                        FROM seg.tblRelacionRolRegla
					--END					
				END
		END
	--ELSE IF @accion = 'COMBO'
	--	BEGIN
	--		SELECT rgl_codRegla,rgl_Descripcion, rgl_PalabraClave
	--		FROM seg.tblRegla
	--		ORDER BY rgl_Descripcion ASC
	--	END
-- fin gestion rol y regla	
GO
-------------------------------------------
--- Gestion usuario
IF OBJECT_ID ( 'seg.spGestionUsuario', 'P' ) IS NOT NULL 
	DROP PROCEDURE seg.spGestionUsuario;
GO
CREATE PROCEDURE seg.spGestionUsuario
    @usu_codigo int,
    @usu_nombre nvarchar(50), 
	@usu_apellido nvarchar(50),
    @usu_codRol int,
    @usu_codCliente int,
    @usu_mail  nvarchar(255),
    @usu_login  nvarchar(255),
	@usu_psw  nvarchar(255),--varbinary(255)
	@usu_observacion nvarchar(max),
	@usu_codUsuarioUltMov int,
	@usu_codAccion int,
	@usu_estado int,
	@filtro nvarchar(50),
	@accion nvarchar(50)
AS 
IF @accion = 'INSERT'
		BEGIN
		--BEGIN TRANSACTION
		--BEGIN TRY

INSERT INTO seg.tbl_usuarios
(usu_nombre , usu_apellido , usu_codRol , usu_mail ,usu_login, usu_observacion,usu_psw,usu_pswDesencriptado,usu_fechaUltMov,usu_codUsuarioUltMov,usu_codAccion,usu_estado,usu_codCliente)
values (@usu_nombre,@usu_apellido,  @usu_codRol,  @usu_mail,@usu_login, @usu_observacion, pwdEncrypt (@usu_psw),@usu_psw,GetDate(),@usu_codUsuarioUltMov,@usu_codAccion,@usu_estado,@usu_codCliente)

select SCOPE_IDENTITY() as usu_codigo
		
	--COMMIT TRANSACTION 
	--	END TRY
	--	BEGIN CATCH
	--	ROLLBACK TRANSACTION 
	--	END CATCH
		END
	ELSE IF @accion = 'UPDATE'
		BEGIN
		BEGIN TRANSACTION
		BEGIN TRY
		
		UPDATE seg.tbl_usuarios
SET  usu_nombre = @usu_nombre,
 usu_apellido = @usu_apellido,
 usu_codRol =  @usu_codRol,
 usu_codCliente = @usu_codCliente,
 usu_mail = @usu_mail,
 usu_login = @usu_login,
 usu_observacion = @usu_observacion,
 usu_fechaUltMov = GetDate(),
 usu_codUsuarioUltMov = @usu_codUsuarioUltMov,
usu_codAccion = @usu_codAccion
WHERE usu_codigo = @usu_codigo
				
		COMMIT TRANSACTION 
		END TRY
		BEGIN CATCH
		ROLLBACK TRANSACTION 
		END CATCH
	
		END
	ELSE IF @accion = 'ESTADO'
		BEGIN

		BEGIN TRANSACTION
		BEGIN TRY
		UPDATE seg.tbl_usuarios
		SET   usu_fechaUltMov = GetDate(),
		usu_codUsuarioUltMov = @usu_codUsuarioUltMov,
		usu_estado = @usu_estado,
		usu_codAccion = @usu_codAccion
		WHERE usu_codigo = @usu_codigo
		COMMIT TRANSACTION 
		END TRY
		BEGIN CATCH
		ROLLBACK TRANSACTION 
		END CATCH
		
		END
	ELSE IF @accion = 'DELETE'
		BEGIN	
--BEGIN TRANSACTION
--BEGIN TRY


DELETE seg.tblUsuarioLog
WHERE ulg_codUsuario = @usu_codigo

DELETE seg.tbl_usuarios	
WHERE usu_codigo = @usu_codigo

--COMMIT TRANSACTION 
--END TRY
--BEGIN CATCH
--ROLLBACK TRANSACTION 
--END CATCH		
		END	
ELSE IF @accion = 'CAMBIOCONTRASEÑA'
		BEGIN	
--BEGIN TRANSACTION
--BEGIN TRY

UPDATE seg.tbl_usuarios
SET   usu_psw = pwdEncrypt (@usu_psw),
      usu_pswDesencriptado = @usu_psw,
	  usu_fechaUltMov =  GetDate(),
      usu_codUsuarioUltMov = @usu_codUsuarioUltMov,
      usu_codAccion = @usu_codAccion
WHERE usu_codigo = @usu_codigo

END					
	ELSE IF @accion = 'SELECT'
		BEGIN
			IF @usu_codigo <> 0
				BEGIN
					SELECT  usu_codigo,usu_codRol,rol_Nombre,usu_nombre + ' ' + usu_apellido as NombreYapellido  ,usu_nombre,usu_apellido,usu_login,usu_mail,usu_pswDesencriptado,usu_observacion,usu_estado,usu_codCliente
					FROM seg.tbl_usuarios
					INNER JOIN  seg.tblRol on rol_codRol	= usu_codRol	
					--LEFT JOIN tbl_Clientes on cli_codigo = usu_codCliente
					WHERE usu_codigo = @usu_codigo
				END
			ELSE
				BEGIN
				IF @filtro <> ''
					BEGIN
					SELECT  usu_codigo,usu_codRol,rol_Nombre,usu_nombre + ' ' + usu_apellido as NombreYapellido  ,usu_nombre,usu_apellido,usu_login,usu_mail,usu_pswDesencriptado,usu_observacion,usu_estado,usu_codCliente
					FROM seg.tbl_usuarios
					INNER JOIN  seg.tblRol on rol_codRol	= usu_codRol
					--LEFT JOIN tbl_Clientes on cli_codigo = usu_codCliente		
					WHERE  usu_nombre  LIKE   '%' + @filtro + '%'  OR usu_apellido LIKE  '%' + @filtro + '%'  OR usu_mail LIKE  '%' + @filtro  + '%' OR rol_Nombre LIKE  '%' + @filtro  + '%' 
					END
				ELSE
					BEGIN
						SELECT  usu_codigo,usu_codRol,rol_Nombre,usu_nombre + ' ' + usu_apellido as NombreYapellido  ,usu_nombre,usu_apellido,usu_login,usu_mail,usu_pswDesencriptado,usu_observacion,usu_estado,usu_codCliente
					    FROM seg.tbl_usuarios
					    INNER JOIN  seg.tblRol on rol_codRol	= usu_codRol
					   -- LEFT JOIN tbl_Clientes on cli_codigo = usu_codCliente	
						--ORDER BY NombreYapellido  ASC
					END					
				END
		END
	ELSE IF @accion = 'COMBO'
		BEGIN
			SELECT usu_codigo
                   ,usu_nombre + ' ' + usu_apellido as NombreYapellido   
				   ,usu_codRol				   
            FROM seg.tbl_usuarios
            order by NombreYapellido    
		END
GO		
-- fin gestion usuario
 --- procedimientos recursos
 IF OBJECT_ID ( 'seg.spGestionArchivo', 'P' ) IS NOT NULL 
	DROP PROCEDURE seg.spGestionArchivo;
GO
CREATE PROCEDURE  seg.spGestionArchivo
	@arc_codRecurso int,
	@arc_codRelacion int,
	@arc_galeria nvarchar(50) ,
	--@arc_orden int,
	@arc_tipo nvarchar(50),
	@arc_mime nvarchar(100),
	@arc_nombre nvarchar(150) ,
	@arc_titulo nvarchar(200),
	@arc_descripcion nvarchar(max) ,
	@arc_hash nvarchar(50) ,
	@arc_codUsuarioUltMov int,
	@arc_estado int,
	@arc_accion int,
	@accion nvarchar(50),
	@filtro nvarchar(50)		
AS
BEGIN
	declare @pos_actual int
	declare @pos_nueva int
	declare @arc_codenr int
	declare @arc_maximo int
	
	IF @accion = 'INSERT'
		BEGIN


	SELECT @arc_maximo = ISNULL(MAX(arc_orden),0) 	FROM seg.tbl_archivos 	WHERE arc_codRelacion = @arc_codRelacion AND arc_galeria = @arc_galeria 

	INSERT INTO seg.tbl_archivos
	(arc_codRelacion,arc_galeria, arc_orden, arc_titulo, arc_descripcion, arc_nombre , arc_tipo,arc_mime ,arc_fecha, arc_estado,arc_accion, arc_codUsuarioUltMov, arc_fechaUltMov)
	values(@arc_codRelacion,@arc_galeria,(@arc_maximo+1), @arc_titulo, @arc_descripcion, @arc_nombre ,@arc_tipo, @arc_mime ,GetDate(), @arc_estado,@arc_accion, @arc_codUsuarioUltMov, GetDate())

select  SCOPE_IDENTITY() as arc_codRecurso

		END
	ELSE IF @accion = 'UPDATE'
		BEGIN
			UPDATE seg.tbl_archivos SET
			arc_codRelacion = @arc_codRelacion,
			arc_galeria = @arc_galeria,
			--arc_orden = @arc_orden,
			arc_titulo = @arc_titulo, 
			arc_descripcion = @arc_descripcion,
			arc_nombre = @arc_nombre, 
			arc_tipo = @arc_tipo,
			arc_mime = @arc_mime,
			--arc_estado = @arc_estado,
			arc_accion = @arc_accion,
			arc_codUsuarioUltMov = @arc_codUsuarioUltMov, 
			arc_fechaUltMov = GetDate()
			WHERE
				arc_codRecurso  = @arc_codRecurso 
		END
	ELSE IF @accion = 'DELETE'
		BEGIN
			Declare	@arc_codRelacionTemp int
			Declare	@arc_galeriaTemp nvarchar(50) 
			SELECT @pos_actual = arc_orden,@arc_codRelacionTemp = arc_codRelacion,@arc_galeriaTemp = arc_galeria  FROM seg.tbl_archivos WHERE arc_codRecurso = @arc_codRecurso 
			DELETE FROM  seg.tbl_archivos WHERE arc_codRecurso  = @arc_codRecurso 
				UPDATE seg.tbl_archivos SET
				arc_orden = arc_orden - 1
				where arc_codRelacion =  @arc_codRelacionTemp AND arc_galeria = @arc_galeriaTemp AND arc_orden > @pos_actual
		END
	ELSE IF @accion = 'ESTADO'
		BEGIN
			UPDATE  seg.tbl_archivos SET
				arc_estado = @arc_estado,
				arc_accion = @arc_accion,
				arc_codUsuarioUltMov = @arc_codUsuarioUltMov, 
				arc_fechaUltMov = GetDate()
			WHERE
				 arc_codRecurso  = @arc_codRecurso 
		END
	ELSE IF @accion = 'SELECT'
		BEGIN
			IF @arc_codRecurso <> 0
				BEGIN
					SELECT  arc_codRecurso,arc_codRelacion,arc_galeria,arc_orden,arc_tipo,arc_mime,arc_nombre,arc_titulo,arc_descripcion,arc_hash,arc_fecha,arc_accion,arc_estado,arc_fechaUltMov,arc_codUsuarioUltMov, usu_nombre + ' ' + usu_apellido as NombreYapellido
					FROM seg.tbl_archivos
					 inner join  seg.tbl_usuarios on  usu_codigo = arc_codUsuarioUltMov
					WHERE	arc_codRecurso = @arc_codRecurso
				END
			ELSE
				BEGIN
				IF @filtro <> ''
					BEGIN
							SELECT  arc_codRecurso,arc_codRelacion,arc_galeria,arc_orden,arc_tipo,arc_mime,arc_nombre,arc_titulo,arc_descripcion,arc_hash,arc_fecha,arc_accion,arc_estado,arc_fechaUltMov,arc_codUsuarioUltMov, usu_nombre + ' ' + usu_apellido as NombreYapellido
							FROM seg.tbl_archivos
					    	 inner join  seg.tbl_usuarios on  usu_codigo = arc_codUsuarioUltMov
						WHERE	(arc_titulo LIKE @filtro OR arc_nombre LIKE @filtro OR arc_descripcion LIKE @filtro OR arc_galeria LIKE @filtro OR arc_mime LIKE @filtro OR arc_tipo LIKE @filtro)
								AND arc_codRelacion = @arc_codRelacion AND arc_galeria = @arc_galeria --AND arc_estado = @arc_estado
						ORDER BY arc_orden ASC	
					END
				ELSE
					BEGIN
							SELECT  arc_codRecurso,arc_codRelacion,arc_galeria,arc_orden,arc_tipo,arc_mime,arc_nombre,arc_titulo,arc_descripcion,arc_hash,arc_fecha,arc_accion,arc_estado,arc_fechaUltMov,arc_codUsuarioUltMov, usu_nombre + ' ' + usu_apellido as NombreYapellido
							FROM seg.tbl_archivos
					    	 inner join  seg.tbl_usuarios on  usu_codigo = arc_codUsuarioUltMov
						WHERE arc_codRelacion = @arc_codRelacion AND arc_galeria = @arc_galeria --AND arc_estado = @arc_estado
						ORDER BY arc_orden ASC	
					END					
				END
		END
	ELSE IF @accion = 'COMBO'
		BEGIN	
		SELECT arc_codRecurso,arc_titulo
        FROM seg.tbl_archivos
        WHERE arc_estado = @arc_estado
		ORDER BY arc_orden ASC	
		END
	ELSE IF @accion = 'SUBIR'
		BEGIN
			--Busco la posicion actual
			SELECT @pos_actual = arc_orden FROM seg.tbl_archivos WHERE arc_codRecurso = @arc_codRecurso -- AND arc_grupo = @arc_grupo
			IF @pos_actual <> 1
				BEGIN
					--Asigno la posicion nueva
					SET @pos_nueva = @pos_actual - 1
					--Busco el codigo para hacer el enroque
					SELECT @arc_codenr = arc_codRecurso FROM  seg.tbl_archivos WHERE arc_codRelacion = @arc_codRelacion AND arc_galeria = @arc_galeria AND arc_orden = @pos_nueva 
					UPDATE  seg.tbl_archivos 
					SET arc_orden = @pos_nueva,		
						arc_accion = @arc_accion,
						arc_codUsuarioUltMov = @arc_codUsuarioUltMov, 
						arc_fechaUltMov = GetDate() 
					WHERE arc_codRecurso = @arc_codRecurso
					UPDATE  seg.tbl_archivos 
					SET arc_orden = @pos_actual,
						arc_accion = @arc_accion,
						arc_codUsuarioUltMov = @arc_codUsuarioUltMov, 
						arc_fechaUltMov = GetDate() 
					 WHERE arc_codRecurso = @arc_codenr
				END
		END
	ELSE IF @accion = 'BAJAR'
		BEGIN
			--Busco la posicion actual
			SELECT @pos_actual = arc_orden FROM seg.tbl_archivos WHERE arc_codRecurso = @arc_codRecurso -- AND arc_grupo = @arc_grupo
			SELECT @arc_maximo = MAX(arc_orden) FROM seg.tbl_archivos WHERE arc_codRelacion = @arc_codRelacion AND arc_galeria = @arc_galeria
			IF @pos_actual < @arc_maximo
				BEGIN
					--Asigno la posicion nueva
					SET @pos_nueva = @pos_actual + 1
					--Busco el codigo para hacer el enroque
					SELECT @arc_codenr = arc_codRecurso FROM seg.tbl_archivos WHERE  arc_codRelacion = @arc_codRelacion AND arc_galeria = @arc_galeria AND arc_orden = @pos_nueva
					UPDATE seg.tbl_archivos 
					SET arc_orden = @pos_nueva,
						arc_accion = @arc_accion,
						arc_codUsuarioUltMov = @arc_codUsuarioUltMov, 
						arc_fechaUltMov = GetDate()  
					WHERE  arc_codRecurso = @arc_codRecurso
					UPDATE seg.tbl_archivos
					SET arc_orden = @pos_actual,
						arc_accion = @arc_accion,
						arc_codUsuarioUltMov = @arc_codUsuarioUltMov, 
						arc_fechaUltMov = GetDate() 
				    WHERE arc_codRecurso = @arc_codenr
				END
		END
END
GO
 -----------
 
CREATE procedure seg.[spLogError]
@mensaje nvarchar(max) 
 AS
-- Declaration statements
DECLARE @Error_Number int
DECLARE @Error_Message nvarchar(4000)
DECLARE @Error_Severity int
DECLARE @Error_State int
DECLARE @Error_Procedure nvarchar(200)
DECLARE @Error_Line int
DECLARE @UserName nvarchar(200)
DECLARE @HostName nvarchar(200)
DECLARE @Time_Stamp datetime

-- Initialize variables
SELECT @Error_Number = isnull(error_number(),0),
@Error_Message = isnull(error_message(),'NULL Message'),
@Error_Severity = isnull(error_severity(),0),
@Error_State = isnull(error_state(),1),
@Error_Line = isnull(error_line(), 0),
@Error_Procedure = isnull(error_procedure(),''),
@UserName = SUSER_SNAME(),
@HostName = HOST_NAME(),
@Time_Stamp = GETDATE();

-- Insert into the dbo.ErrorHandling table
INSERT INTO seg.[Error] (log_Error_Number, log_Error_Message, log_Error_Severity, log_Error_State, log_Error_Line,
log_Error_Procedure, log_UserName, log_HostName, log_Time_Stamp,log_MensajePersonalizado,err_Nombre,err_fecha,err_tipo)
SELECT @Error_Number, @Error_Message, @Error_Severity, @Error_State, @Error_Line,
@Error_Procedure, @UserName, @HostName, @Time_Stamp,@mensaje,@Error_Procedure,@Time_Stamp,'SQL'

GO
----------------------------

create procedure seg.[spError]
@err_Nombre [nvarchar](max) ,
@err_Parameters [nvarchar](max) ,
@err_Data [nvarchar](max) ,
@err_HelpLink  [nvarchar](max) ,
@err_InnerException [nvarchar](max) ,
@err_Message [nvarchar](max) ,
@err_Source [nvarchar](max) ,
@err_StackTrace [nvarchar](max) ,
@err_fecha [datetime] ,
@err_tipo [nvarchar](200) 
AS

-- Insert into the dbo.ErrorHandling table
INSERT INTO seg.[Error] (err_Nombre, err_Parameters, err_Data, err_HelpLink, err_InnerException,
err_Message, err_Source, err_StackTrace, err_fecha,err_tipo)
SELECT @err_Nombre, @err_Parameters, @err_Data, @err_HelpLink, @err_InnerException,
@err_Message, @err_Source, @err_StackTrace, @err_fecha,@err_tipo
GO
	