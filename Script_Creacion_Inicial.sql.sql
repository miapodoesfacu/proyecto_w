USE [GD2C2013]
GO

IF SCHEMA_ID('PROYECTO_W') IS NOT NULL
BEGIN
	IF OBJECT_ID('[PROYECTO_W].[TurnoCancelacion]') IS NOT NULL
		DROP TABLE [PROYECTO_W].[TurnoCancelacion] ;

	IF OBJECT_ID('[PROYECTO_W].[TipoCancelacion]') IS NOT NULL
		DROP TABLE [PROYECTO_W].[TipoCancelacion] ;

	IF OBJECT_ID('[PROYECTO_W].[BonoPorReceta]') IS NOT NULL
		DROP TABLE [PROYECTO_W].[BonoPorReceta] ;

	IF OBJECT_ID('[PROYECTO_W].[TurnoConcretado]') IS NOT NULL
		DROP TABLE [PROYECTO_W].[TurnoConcretado] ;

	IF OBJECT_ID('[PROYECTO_W].[Receta]') IS NOT NULL
		DROP TABLE [PROYECTO_W].[Receta] ;

	IF OBJECT_ID('[PROYECTO_W].[TurnoLlegada]') IS NOT NULL
		DROP TABLE [PROYECTO_W].[TurnoLlegada] ;

	IF OBJECT_ID('[PROYECTO_W].[Turno]') IS NOT NULL
		DROP TABLE [PROYECTO_W].[Turno] ;

	IF OBJECT_ID('[PROYECTO_W].[EspecialidadPorProfesional]') IS NOT NULL
		DROP TABLE [PROYECTO_W].[EspecialidadPorProfesional] ;

	IF OBJECT_ID('[PROYECTO_W].[Especialidad]') IS NOT NULL
		DROP TABLE [PROYECTO_W].[Especialidad] ;

	IF OBJECT_ID('[PROYECTO_W].[TipoEspecialidad]') IS NOT NULL
		DROP TABLE [PROYECTO_W].[TipoEspecialidad] ;

	IF OBJECT_ID('[PROYECTO_W].[AgendaProfesional]') IS NOT NULL
		DROP TABLE [PROYECTO_W].[AgendaProfesional] ;

	IF OBJECT_ID('[PROYECTO_W].[Profesional]') IS NOT NULL
		DROP TABLE [PROYECTO_W].[Profesional] ;

	IF OBJECT_ID('[PROYECTO_W].[MedicamentoPorBonoFarmacia]') IS NOT NULL
		DROP TABLE [PROYECTO_W].[MedicamentoPorBonoFarmacia] ;

	IF OBJECT_ID('[PROYECTO_W].[BonoFarmacia]') IS NOT NULL
		DROP TABLE [PROYECTO_W].[BonoFarmacia] ;

	IF OBJECT_ID('[PROYECTO_W].[BonoConsulta]') IS NOT NULL
		DROP TABLE [PROYECTO_W].[BonoConsulta] ;

	IF OBJECT_ID('[PROYECTO_W].[BonoAdquirido]') IS NOT NULL
		DROP TABLE [PROYECTO_W].[BonoAdquirido] ;

	IF OBJECT_ID('[PROYECTO_W].[HistorialPlan]') IS NOT NULL
		DROP TABLE [PROYECTO_W].[HistorialPlan] ;

	IF OBJECT_ID('[PROYECTO_W].[Afiliado]') IS NOT NULL
		DROP TABLE [PROYECTO_W].[Afiliado] ;

	IF OBJECT_ID('[PROYECTO_W].[Plan]') IS NOT NULL
		DROP TABLE [PROYECTO_W].[Plan] ;

	IF OBJECT_ID('[PROYECTO_W].[FuncionalidadPorRol]') IS NOT NULL
		DROP TABLE [PROYECTO_W].[FuncionalidadPorRol] ;

	IF OBJECT_ID('[PROYECTO_W].[RolPorUsuario]') IS NOT NULL
		DROP TABLE [PROYECTO_W].[RolPorUsuario] ;

	IF OBJECT_ID('[PROYECTO_W].[Funcionalidad]') IS NOT NULL		
		DROP TABLE [PROYECTO_W].[Funcionalidad] ;

	IF OBJECT_ID('[PROYECTO_W].[Rol]') IS NOT NULL
		DROP TABLE [PROYECTO_W].[Rol] ;

	IF OBJECT_ID('[PROYECTO_W].[Usuario]') IS NOT NULL
		DROP TABLE [PROYECTO_W].[Usuario] ;

	DROP SCHEMA [PROYECTO_W] ;
END
GO

CREATE SCHEMA [PROYECTO_W] AUTHORIZATION [gd]
GO

CREATE TABLE [PROYECTO_W].[Usuario]
(
	[usu_username] [varchar](255) NOT NULL,
	[usu_password] [varchar](255) NOT NULL,
	[usu_cant_intentos] [tinyint] NOT NULL DEFAULT 0,
	[usu_estado] [char](1) NOT NULL DEFAULT 'H', --Habilitado
	PRIMARY KEY (usu_username)
)
GO

CREATE TABLE [PROYECTO_W].[Rol]
(
	[rol_cod] [tinyint] IDENTITY(1,1) NOT NULL,
	[rol_nombre] [varchar](255) NOT NULL,
	[rol_estado] [char](1) NOT NULL DEFAULT 'H',
	PRIMARY KEY (rol_cod)
)
GO

CREATE TABLE [PROYECTO_W].[RolPorUsuario]
(
	[rolxusu_username] [varchar](255) NOT NULL,
	[rolxusu_rol_cod] [tinyint] NOT NULL,
	FOREIGN KEY([rolxusu_rol_cod]) REFERENCES [PROYECTO_W].[Rol] ([rol_cod]),
	FOREIGN KEY([rolxusu_username]) REFERENCES [PROYECTO_W].[Usuario] ([usu_username])
		ON UPDATE CASCADE
)
GO

CREATE TABLE [PROYECTO_W].[Funcionalidad]
(
	[func_cod] [tinyint] IDENTITY(1,1) NOT NULL,
	[func_nombre] [varchar](255) NOT NULL,
	PRIMARY KEY (func_cod)
)
GO

CREATE TABLE [PROYECTO_W].[FuncionalidadPorRol]
(
	[funcxrol_rol_cod] [tinyint] NOT NULL,
	[funcxrol_func_cod] [tinyint] NOT NULL,
	[funcxrol_estado] [char](1) NOT NULL DEFAULT 'H',
	FOREIGN KEY([funcxrol_func_cod]) REFERENCES [PROYECTO_W].[Funcionalidad] ([func_cod]),
	FOREIGN KEY([funcxrol_rol_cod]) REFERENCES [PROYECTO_W].[Rol] ([rol_cod])
)
GO

CREATE TABLE [PROYECTO_W].[Plan]
(
	[plan_cod] [numeric](18, 0) IDENTITY(555555,1) NOT NULL,
	[plan_descripcion] [varchar](255) NOT NULL DEFAULT 'SIN DESCRIPCION',
	[plan_precio_bono_consulta] [numeric](18, 0) NOT NULL DEFAULT 0,
	[plan_precio_bono_farmacia] [numeric](18, 0) NOT NULL DEFAULT 0,
	[plan_precio_cuota] [smallmoney] NULL,
	CHECK (plan_precio_bono_consulta>=0 AND plan_precio_bono_farmacia>=0 AND plan_precio_cuota>=0),
	PRIMARY KEY (plan_cod)
)
GO

CREATE TABLE [PROYECTO_W].[Afiliado]
(
	[afil_nombre] [varchar](255) NOT NULL,
	[afil_apellido] [varchar](255) NOT NULL,
	[afil_doc_tipo] [varchar](3) NOT NULL DEFAULT 'DNI',
	[afil_doc_nro] [numeric](18, 0) NOT NULL,
	[afil_direccion] [varchar](255) NOT NULL,
	[afil_telefono] [numeric](18, 0) NOT NULL,
	[afil_fecha_nac] [datetime] NOT NULL,
	[afil_sexo] [char](1) NULL,
	[afil_username] [varchar](255) NULL,
	[afil_nro] [bigint] IDENTITY(101,100) NOT NULL,
	[afil_plan_cod] [numeric](18, 0) NOT NULL,
	[afil_estado] [char](1) NULL,
	[afil_cant_pers_a_cargo] [tinyint] NOT NULL DEFAULT 0,
	[afil_nro_consultas] [numeric](18, 0) NOT NULL DEFAULT 0,
	[afil_estado_civil] [varchar](2) NULL,
	[afil_fecha_baja] [datetime] NULL,
	[afil_mail] [varchar](255) NOT NULL,
	FOREIGN KEY([afil_plan_cod]) REFERENCES [PROYECTO_W].[Plan] ([plan_cod]),
	FOREIGN KEY([afil_username]) REFERENCES [PROYECTO_W].[Usuario] ([usu_username])
		ON UPDATE CASCADE,
	PRIMARY KEY (afil_nro)
)
GO

CREATE TABLE [PROYECTO_W].[HistorialPlan]
(
	[hist_afil_nro] [bigint] NOT NULL,
	[hist_fecha_cambio] [datetime] NOT NULL,
	[hist_nuevo_plan_cod] [numeric](18, 0) NOT NULL,
	[hist_motivo_cambio] [varchar](255) NULL,
	FOREIGN KEY([hist_afil_nro]) REFERENCES [PROYECTO_W].[Afiliado] ([afil_nro]),
	FOREIGN KEY([hist_nuevo_plan_cod]) REFERENCES [PROYECTO_W].[Plan] ([plan_cod])
)
GO

CREATE TABLE [PROYECTO_W].[BonoAdquirido]
(
	[bonadq_tipo_bono] [varchar](255) NOT NULL,
	[bonadq_fecha_compra] [datetime] NOT NULL,
	[bonadq_fecha_impresion] [datetime] NOT NULL,
	[bonadq_cantidad_comprada] [tinyint] NOT NULL,
	[bonadq_afil_nro] [bigint] NOT NULL,
	[bonadq_plan_cod] [numeric](18, 0) NOT NULL,
	[bonadq_suma_pagada] [smallmoney] NOT NULL,
	[bonadq_cod] [bigint] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	FOREIGN KEY([bonadq_afil_nro]) REFERENCES [PROYECTO_W].[Afiliado] ([afil_nro]),
	FOREIGN KEY([bonadq_plan_cod]) REFERENCES [PROYECTO_W].[Plan] ([plan_cod])
)
GO

CREATE TABLE [PROYECTO_W].[BonoConsulta]
(
	[bonocons_bonadq_cod] [bigint] NOT NULL,
	[bonocons_cod] [bigint] IDENTITY(1,1) NOT NULL,
	[bonocons_estado] [char](1) NOT NULL DEFAULT 'S', --Sin usar
	FOREIGN KEY([bonocons_bonadq_cod]) REFERENCES [PROYECTO_W].[BonoAdquirido] ([bonadq_cod]),
	PRIMARY KEY (bonocons_cod)
)
GO

CREATE TABLE [PROYECTO_W].[BonoFarmacia]
(
	[bonofarm_bonadq_cod] [bigint] NOT NULL,
	[bonofarm_cod] [bigint] IDENTITY(1,1) NOT NULL,
	[bonofarm_fecha_venc] [datetime] NOT NULL,
	[bonofarm_estado] [char](1) NOT NULL DEFAULT 'S',
	FOREIGN KEY([bonofarm_bonadq_cod]) REFERENCES [PROYECTO_W].[BonoAdquirido] ([bonadq_cod]),
	PRIMARY KEY (bonofarm_cod)
)
GO

CREATE TABLE [PROYECTO_W].[MedicamentoPorBonoFarmacia]
(
	[medxbonofar_bonofarm_cod] [bigint] NOT NULL,
	[medxbonofar_medicamento_nombre] [varchar](255) NOT NULL,
	[medxbonofar_medicamento_cantidad] [tinyint] NOT NULL,
	FOREIGN KEY([medxbonofar_bonofarm_cod]) REFERENCES [PROYECTO_W].[BonoFarmacia] ([bonofarm_cod])
)
GO

CREATE TABLE [PROYECTO_W].[Profesional]
(
	[prof_nombre] [varchar](255) NOT NULL,
	[prof_apellido] [varchar](255) NOT NULL,
	[prof_doc_tipo] [varchar](3) NULL DEFAULT 'DNI',
	[prof_doc_nro] [numeric](18, 0) NOT NULL,
	[prof_direccion] [varchar](255) NOT NULL,
	[prof_telefono] [numeric](18, 0) NOT NULL,
	[prof_mail] [varchar](255) NOT NULL,
	[prof_fecha_nac] [datetime] NOT NULL,
	[prof_sexo] [char](1) NULL,
	[prof_username] [varchar](255) NULL,
	[prof_matricula] [varchar](255) NULL,
	[prof_estado] [char](1) NOT NULL DEFAULT 'H', --Habilitado = activo
	[prof_cod] [bigint] IDENTITY(1,1) NOT NULL,
	FOREIGN KEY([prof_username]) REFERENCES [PROYECTO_W].[Usuario] ([usu_username])
		ON UPDATE CASCADE,
	PRIMARY KEY (prof_cod)
)
GO

CREATE TABLE [PROYECTO_W].[AgendaProfesional]
(
	[agen_prof_cod] [bigint] NOT NULL,
	[agen_fecha_inicio] [datetime] NOT NULL,
	[agen_fecha_fin] [datetime] NOT NULL,
	FOREIGN KEY([agen_prof_cod]) REFERENCES [PROYECTO_W].[Profesional] ([prof_cod])
)
GO

CREATE TABLE [PROYECTO_W].[TipoEspecialidad]
(
	[tipoesp_cod] [numeric](18, 0) NOT NULL,
	[tipoesp_descripcion] [varchar](255) NOT NULL,
	PRIMARY KEY (tipoesp_cod)
)
GO

CREATE TABLE [PROYECTO_W].[Especialidad]
(
	[esp_cod] [numeric](18, 0) NOT NULL,
	[esp_descripcion] [varchar](255) NOT NULL,
	[esp_tipoesp_cod] [numeric](18, 0) NOT NULL,
	FOREIGN KEY([esp_tipoesp_cod]) REFERENCES [PROYECTO_W].[TipoEspecialidad] ([tipoesp_cod]),
	PRIMARY KEY (esp_cod)
)
GO

CREATE TABLE [PROYECTO_W].[EspecialidadPorProfesional]
(
	[espxprof_prof_cod] [bigint] NOT NULL,
	[espxprof_esp_cod] [numeric](18, 0) NOT NULL,
	FOREIGN KEY([espxprof_esp_cod]) REFERENCES [PROYECTO_W].[Especialidad] ([esp_cod]),
	FOREIGN KEY([espxprof_prof_cod]) REFERENCES [PROYECTO_W].[Profesional] ([prof_cod])
)
GO

CREATE TABLE [PROYECTO_W].[Turno]
(
	[turno_nro] [numeric](18, 0) IDENTITY(56565,1) NOT NULL,
	[turno_afil_nro] [bigint] NOT NULL,
	[turno_estado] [char](1) NOT NULL DEFAULT 'P', --Pedido,Registrado,Contretado.. aca es Pedido, L perdido
	[turno_fecha] [datetime] NOT NULL,
	[turno_prof_cod] [bigint] NOT NULL,
	[turno_esp_cod] [numeric](18, 0) NOT NULL,
	FOREIGN KEY([turno_afil_nro]) REFERENCES [PROYECTO_W].[Afiliado] ([afil_nro]),
	FOREIGN KEY([turno_prof_cod]) REFERENCES [PROYECTO_W].[Profesional] ([prof_cod]),
	FOREIGN KEY([turno_esp_cod]) REFERENCES [PROYECTO_W].[Especialidad] ([esp_cod]),
	PRIMARY KEY (turno_nro)
)
GO

CREATE TABLE [PROYECTO_W].[TurnoLlegada]
(
	[turlle_turno_nro] [numeric](18, 0) NOT NULL,
	[turlle_afil_nro_consulta] [numeric](18, 0) NOT NULL,
	[turlle_bonocons_cod] [bigint] NOT NULL,
	FOREIGN KEY([turlle_bonocons_cod]) REFERENCES [PROYECTO_W].[BonoConsulta] ([bonocons_cod]),
	FOREIGN KEY([turlle_turno_nro]) REFERENCES [PROYECTO_W].[Turno] ([turno_nro])
)
GO

CREATE TABLE [PROYECTO_W].[Receta]
(
	[receta_cod] [bigint] IDENTITY(1,1) NOT NULL,
	[receta_fecha_prescripcion] [datetime] NULL,  -- ???
	PRIMARY KEY (receta_cod)
)
GO

CREATE TABLE [PROYECTO_W].[TurnoConcretado]
(
	[turconcr_sintomas] [varchar](255) NULL,
	[turconcr_diagnostico] [varchar](255) NULL,
	[turconcr_fecha] [datetime] NOT NULL,
	[turconcr_turno_nro] [numeric](18, 0) NOT NULL,
	[turconcr_receta_cod] [bigint] NULL,
	FOREIGN KEY([turconcr_receta_cod]) REFERENCES [PROYECTO_W].[Receta] ([receta_cod]),
	FOREIGN KEY([turconcr_turno_nro]) REFERENCES [PROYECTO_W].[Turno] ([turno_nro])
)
GO

CREATE TABLE [PROYECTO_W].[BonoPorReceta]
(
	[bonoxreceta_receta_cod] [bigint] NOT NULL,
	[bonoxreceta_bonofarm_cod] [bigint] NOT NULL,
	FOREIGN KEY([bonoxreceta_bonofarm_cod]) REFERENCES [PROYECTO_W].[BonoFarmacia] ([bonofarm_cod]),
	FOREIGN KEY([bonoxreceta_receta_cod]) REFERENCES [PROYECTO_W].[Receta] ([receta_cod])
)
GO

CREATE TABLE [PROYECTO_W].[TipoCancelacion]
(
	[tipocanc_cod] [tinyint] IDENTITY(1,1) NOT NULL,
	[tipocanc_descripcion] [varchar](255) NOT NULL,
	PRIMARY KEY (tipocanc_cod)
)
GO

CREATE TABLE [PROYECTO_W].[TurnoCancelacion]
(
	[turcan_fecha] [datetime] NOT NULL,
	[turcan_turno_nro] [numeric](18, 0) NOT NULL,
	[turcan_tipocanc_cod] [tinyint] NOT NULL,
	[turcan_motivo] [varchar](255) NULL,
	FOREIGN KEY([turcan_tipocanc_cod]) REFERENCES [PROYECTO_W].[TipoCancelacion] ([tipocanc_cod]),
	FOREIGN KEY([turcan_turno_nro]) REFERENCES [PROYECTO_W].[Turno] ([turno_nro])
)
GO
