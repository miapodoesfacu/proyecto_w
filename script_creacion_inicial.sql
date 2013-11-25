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

        IF OBJECT_ID('[PROYECTO_W].[DiaDisponible]') IS NOT NULL
                DROP TABLE [PROYECTO_W].[DiaDisponible] ;

        IF OBJECT_ID('[PROYECTO_W].[AgendaProfesional]') IS NOT NULL
                DROP TABLE [PROYECTO_W].[AgendaProfesional] ;

        IF OBJECT_ID('[PROYECTO_W].[Profesional]') IS NOT NULL
                DROP TABLE [PROYECTO_W].[Profesional] ;

        IF OBJECT_ID('[PROYECTO_W].[MedicamentoPorBonoFarmacia]') IS NOT NULL
                DROP TABLE [PROYECTO_W].[MedicamentoPorBonoFarmacia] ;
                
        IF OBJECT_ID('[PROYECTO_W].[Medicamento]') IS NOT NULL
        DROP TABLE [PROYECTO_W].[Medicamento] ;

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
        UNIQUE (rol_nombre), -- no repetir los nombres de roles
        PRIMARY KEY (rol_cod)
)
GO

CREATE TABLE [PROYECTO_W].[RolPorUsuario]
(
        [rolxusu_username] [varchar](255) NOT NULL,
        [rolxusu_rol_cod] [tinyint] NOT NULL,
        FOREIGN KEY([rolxusu_rol_cod]) REFERENCES [PROYECTO_W].[Rol] ([rol_cod]),
        FOREIGN KEY([rolxusu_username]) REFERENCES [PROYECTO_W].[Usuario] ([usu_username])
                ON UPDATE CASCADE,
        PRIMARY KEY(rolxusu_username, rolxusu_rol_cod)  -- unique podria haber sido, pero no
)
GO

CREATE TABLE [PROYECTO_W].[Funcionalidad]
(
        [func_cod] [tinyint] IDENTITY(1,1) NOT NULL,
        [func_nombre] [varchar](255) NOT NULL,
        UNIQUE (func_nombre),
        PRIMARY KEY (func_cod)
)
GO

CREATE TABLE [PROYECTO_W].[FuncionalidadPorRol]
(
        [funcxrol_rol_cod] [tinyint] NOT NULL,
        [funcxrol_func_cod] [tinyint] NOT NULL,
        [funcxrol_estado] [char](1) NOT NULL DEFAULT 'D',
        FOREIGN KEY([funcxrol_func_cod]) REFERENCES [PROYECTO_W].[Funcionalidad] ([func_cod]),
        FOREIGN KEY([funcxrol_rol_cod]) REFERENCES [PROYECTO_W].[Rol] ([rol_cod]),
        PRIMARY KEY(funcxrol_rol_cod, funcxrol_func_cod)
)
GO

CREATE TABLE [PROYECTO_W].[Plan]
(
        [plan_cod] [numeric](18, 0) /*IDENTITY(555555,1)*/ NOT NULL,
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
        [afil_nro] [bigint] /*IDENTITY(10000001,100)*/ NOT NULL,
        [afil_plan_cod] [numeric](18, 0) NOT NULL,
        [afil_estado] [char](1) NOT NULL DEFAULT 'H',
        [afil_cant_pers_a_cargo] [tinyint] NOT NULL DEFAULT 0,
        [afil_nro_consultas] [numeric](18, 0) NOT NULL DEFAULT 0,
        [afil_estado_civil] [varchar](2) NULL,
        [afil_fecha_baja] [datetime] NULL,
        [afil_mail] [varchar](255) NOT NULL,
        FOREIGN KEY([afil_plan_cod]) REFERENCES [PROYECTO_W].[Plan] ([plan_cod]),
        FOREIGN KEY([afil_username]) REFERENCES [PROYECTO_W].[Usuario] ([usu_username])
                ON UPDATE CASCADE,
--        UNIQUE (afil_doc_tipo, afil_doc_nro, afil_sexo), --no sabemos sexo, asique unique no
--        UNIQUE (afil_username), --SI VA A ESTAR TAMBIEN EN PROFESIONAL, VER QUE SEA LA MISMA PERSONA
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
        FOREIGN KEY([hist_nuevo_plan_cod]) REFERENCES [PROYECTO_W].[Plan] ([plan_cod]),
        PRIMARY KEY(hist_afil_nro, hist_fecha_cambio)
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
        [bonadq_suma_pagada] [smallmoney] NULL,
        [bonadq_cod] [bigint] IDENTITY(1,1) NOT NULL,
        [bonadq_afil_doc_nro] [numeric](18, 0) NOT NULL, --############### ALTER 
        FOREIGN KEY([bonadq_afil_nro]) REFERENCES [PROYECTO_W].[Afiliado] ([afil_nro]),
        FOREIGN KEY([bonadq_plan_cod]) REFERENCES [PROYECTO_W].[Plan] ([plan_cod]),
        PRIMARY KEY(bonadq_cod)
)
GO

CREATE TABLE [PROYECTO_W].[BonoConsulta]
(
        [bonocons_bonadq_cod] [bigint] NULL,
        [bonocons_cod] [bigint] NOT NULL,
        [bonocons_estado] [char](1) NOT NULL DEFAULT 'S', --Sin usar
        FOREIGN KEY([bonocons_bonadq_cod]) REFERENCES [PROYECTO_W].[BonoAdquirido] ([bonadq_cod]),
        PRIMARY KEY (bonocons_cod)
)
GO

CREATE TABLE [PROYECTO_W].[BonoFarmacia]
(
        [bonofarm_bonadq_cod] [bigint] NOT NULL,
        [bonofarm_cod] [bigint] NOT NULL,
        [bonofarm_fecha_venc] [datetime] NOT NULL,
        [bonofarm_estado] [char](1) NOT NULL DEFAULT 'S',
        FOREIGN KEY([bonofarm_bonadq_cod]) REFERENCES [PROYECTO_W].[BonoAdquirido] ([bonadq_cod]),
        PRIMARY KEY (bonofarm_cod)
)
GO

CREATE TABLE [PROYECTO_W].[Medicamento]
(
        [medicamento_nombre_cod] [bigint] IDENTITY(1,1) NOT NULL,
        [medicamento_nombre] [varchar](255) NOT NULL,
        UNIQUE (medicamento_nombre),
        PRIMARY KEY (medicamento_nombre_cod)
)
GO

CREATE TABLE [PROYECTO_W].[MedicamentoPorBonoFarmacia]
(
        [medxbonofar_bonofarm_cod] [bigint] NOT NULL,
        [medxbonofar_medicamento_nombre_cod] [bigint] NOT NULL, -- UNA VE SOLA POR BONO FARM
        [medxbonofar_medicamento_cantidad] [tinyint] NOT NULL,
        FOREIGN KEY([medxbonofar_bonofarm_cod]) REFERENCES [PROYECTO_W].[BonoFarmacia] ([bonofarm_cod]),
        FOREIGN KEY([medxbonofar_medicamento_nombre_cod]) REFERENCES [PROYECTO_W].[Medicamento]([medicamento_nombre_cod]),
        PRIMARY KEY(medxbonofar_bonofarm_cod, medxbonofar_medicamento_nombre_cod)
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
        UNIQUE (prof_doc_nro,prof_nombre),
        PRIMARY KEY (prof_cod)
)
GO

CREATE TABLE [PROYECTO_W].[AgendaProfesional]
(
        [agen_cod] [bigint] IDENTITY(1,1) NOT NULL,
        [agen_prof_cod] [bigint] NOT NULL,
        [agen_fecha_inicio] [datetime] NOT NULL,
        [agen_fecha_fin] [datetime] NOT NULL,
        [agen_hora_inicio] [time] NOT NULL,
        [agen_hora_fin] [time] NOT NULL,
        FOREIGN KEY([agen_prof_cod]) REFERENCES [PROYECTO_W].[Profesional] ([prof_cod]),
        PRIMARY KEY(agen_cod)
)
GO
-- TODO controlar fechas y horas, que sean validas, con un trigger o algo en lo insert, o algo hacer

CREATE TABLE [PROYECTO_W].[DiaDisponible]
(
        [diadisp_dia] [int] NOT NULL,
        [diadisp_agen_cod] [bigint] NOT NULL,
        FOREIGN KEY([diadisp_agen_cod]) REFERENCES [PROYECTO_W].[AgendaProfesional] ([agen_cod]),
        PRIMARY KEY(diadisp_dia, diadisp_agen_cod)
)
GO

CREATE TABLE [PROYECTO_W].[TipoEspecialidad]
(
        [tipoesp_cod] [numeric](18, 0) NOT NULL,
        [tipoesp_descripcion] [varchar](255) NOT NULL,
        UNIQUE (tipoesp_descripcion),
        PRIMARY KEY (tipoesp_cod)
)
GO

CREATE TABLE [PROYECTO_W].[Especialidad]
(
        [esp_cod] [numeric](18, 0) NOT NULL,
        [esp_descripcion] [varchar](255) NOT NULL,
        [esp_tipoesp_cod] [numeric](18, 0) NOT NULL,
        FOREIGN KEY([esp_tipoesp_cod]) REFERENCES [PROYECTO_W].[TipoEspecialidad] ([tipoesp_cod]),
        UNIQUE (esp_descripcion),
        PRIMARY KEY (esp_cod)
)
GO

CREATE TABLE [PROYECTO_W].[EspecialidadPorProfesional]
(
        [espxprof_prof_cod] [bigint] NOT NULL,
        [espxprof_esp_cod] [numeric](18, 0) NOT NULL,
        FOREIGN KEY([espxprof_esp_cod]) REFERENCES [PROYECTO_W].[Especialidad] ([esp_cod]),
        FOREIGN KEY([espxprof_prof_cod]) REFERENCES [PROYECTO_W].[Profesional] ([prof_cod]),
        PRIMARY KEY(espxprof_prof_cod, espxprof_esp_cod)
)
GO

CREATE TABLE [PROYECTO_W].[Turno]
(
        [turno_nro] [numeric](18, 0) /*IDENTITY(56565,1)*/ NOT NULL,
        [turno_afil_nro] [bigint] NOT NULL,
        [turno_estado] [char](1) NOT NULL DEFAULT 'P', --Pedido,Registrado,Contretado.. aca es Pedido, A AUSENTE
        [turno_fecha] [datetime] NOT NULL,
        [turno_prof_cod] [bigint] NOT NULL,
        [turno_esp_cod] [numeric](18, 0) NOT NULL,
        FOREIGN KEY([turno_afil_nro]) REFERENCES [PROYECTO_W].[Afiliado] ([afil_nro]),
        FOREIGN KEY([turno_prof_cod]) REFERENCES [PROYECTO_W].[Profesional] ([prof_cod]),
        FOREIGN KEY([turno_esp_cod]) REFERENCES [PROYECTO_W].[Especialidad] ([esp_cod]),
        UNIQUE (turno_fecha, turno_prof_cod), --no puede estar en dos lugares a la vez el profesional
        PRIMARY KEY (turno_nro)
)
GO

CREATE TABLE [PROYECTO_W].[TurnoLlegada]
(
        [turlle_turno_nro] [numeric](18, 0) NOT NULL,
        [turlle_afil_nro_consulta] [numeric](18, 0) NOT NULL,
        [turlle_bonocons_cod] [bigint] NOT NULL,
        FOREIGN KEY([turlle_bonocons_cod]) REFERENCES [PROYECTO_W].[BonoConsulta] ([bonocons_cod]),
        FOREIGN KEY([turlle_turno_nro]) REFERENCES [PROYECTO_W].[Turno] ([turno_nro]),
        PRIMARY KEY(turlle_turno_nro)
)
GO

CREATE TABLE [PROYECTO_W].[Receta]
(
        [receta_cod] [bigint] IDENTITY(1,1) NOT NULL,
        [receta_fecha_prescripcion] [datetime] NULL,  -- ???
        [receta_bonofarm_cod] [bigint] NOT NULL,
        --FOREIGN KEY([receta_bonofarm_cod]) REFERENCES [PROYECTO_W].[BonoFarmacia] ([bonofarm_cod]),
        PRIMARY KEY (receta_cod)
)
GO

CREATE TABLE [PROYECTO_W].[TurnoConcretado]
(
        [turconcr_sintomas] [varchar](255) NULL,
        [turconcr_diagnostico] [varchar](255) NULL,
        --[turconcr_fecha] [datetime] NOT NULL,
        [turconcr_turno_nro] [numeric](18, 0) NOT NULL,
        [turconcr_receta_cod] [bigint] NULL,
        FOREIGN KEY([turconcr_receta_cod]) REFERENCES [PROYECTO_W].[Receta] ([receta_cod]),
        FOREIGN KEY([turconcr_turno_nro]) REFERENCES [PROYECTO_W].[Turno] ([turno_nro]),
        PRIMARY KEY(turconcr_turno_nro)
)
GO

CREATE TABLE [PROYECTO_W].[BonoPorReceta]
(
        [bonoxreceta_receta_cod] [bigint] NOT NULL,
        [bonoxreceta_bonofarm_cod] [bigint] NOT NULL,
        FOREIGN KEY([bonoxreceta_bonofarm_cod]) REFERENCES [PROYECTO_W].[BonoFarmacia] ([bonofarm_cod]), 
        FOREIGN KEY([bonoxreceta_receta_cod]) REFERENCES [PROYECTO_W].[Receta] ([receta_cod]),
        PRIMARY KEY(bonoxreceta_receta_cod, bonoxreceta_bonofarm_cod)
)
GO

CREATE TABLE [PROYECTO_W].[TipoCancelacion]
(
        [tipocanc_cod] [tinyint] IDENTITY(1,1) NOT NULL,
        [tipocanc_descripcion] [varchar](255) NOT NULL,
        UNIQUE (tipocanc_descripcion),
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
        FOREIGN KEY([turcan_turno_nro]) REFERENCES [PROYECTO_W].[Turno] ([turno_nro]),
        PRIMARY KEY(turcan_turno_nro)
)
GO

--###################################MIGRACION####################################################

USE GD2C2013
GO

-- MIGRACION PLAN MEDICO
INSERT INTO [PROYECTO_W].[Plan] (plan_cod, plan_descripcion, plan_precio_bono_consulta, plan_precio_bono_farmacia)
SELECT DISTINCT Plan_Med_Codigo, Plan_Med_Descripcion, Plan_Med_Precio_Bono_Consulta, Plan_Med_Precio_Bono_Farmacia
FROM gd_esquema.Maestra
GO

-- AUX afiliado aux Aux
CREATE TABLE #AuxAfiliado
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
        [afil_nro] [bigint] IDENTITY(10000001,100) NOT NULL,
        [afil_plan_cod] [numeric](18, 0) NOT NULL,
        [afil_estado] [char](1) NOT NULL DEFAULT 'H',
        [afil_cant_pers_a_cargo] [tinyint] NOT NULL DEFAULT 0,
        [afil_nro_consultas] [numeric](18, 0) NOT NULL DEFAULT 0,
        [afil_estado_civil] [varchar](2) NULL,
        [afil_fecha_baja] [datetime] NULL,
        [afil_mail] [varchar](255) NOT NULL,
--        FOREIGN KEY([afil_plan_cod]) REFERENCES [PROYECTO_W].[Plan] ([plan_cod]),
--        FOREIGN KEY([afil_username]) REFERENCES [PROYECTO_W].[Usuario] ([usu_username]) ON UPDATE CASCADE,
        PRIMARY KEY (afil_nro)
)
GO

-- MIGRACION AFILIADO
INSERT INTO #AuxAfiliado(afil_nombre,afil_apellido,afil_doc_nro,afil_direccion,afil_telefono,afil_fecha_nac,afil_plan_cod,afil_nro_consultas,afil_mail)
SELECT Paciente_Nombre, Paciente_Apellido, Paciente_Dni, Paciente_Direccion, Paciente_Telefono, Paciente_Fecha_Nac, Plan_Med_Codigo, COUNT(*) AS Total_Consultas, Paciente_Mail
FROM gd_esquema.Maestra
WHERE Turno_Numero IS NOT NULL AND Bono_Consulta_Numero IS NOT NULL
GROUP BY Paciente_Nombre, Paciente_Apellido, Paciente_Dni, Paciente_Direccion, Paciente_Telefono, Paciente_Fecha_Nac, Plan_Med_Codigo, Paciente_Mail
GO

INSERT INTO [PROYECTO_W].[Afiliado] 
SELECT * FROM #AuxAfiliado
GO

DROP TABLE #AuxAfiliado
GO

-- MIGRACION PROFESIONALES
INSERT INTO PROYECTO_W.Profesional (prof_nombre,prof_apellido,prof_doc_nro, prof_direccion,prof_telefono,prof_mail,prof_fecha_nac)
SELECT DISTINCT Medico_Nombre, Medico_Apellido, Medico_Dni, Medico_Direccion, Medico_Telefono, Medico_Mail, Medico_Fecha_Nac
FROM gd_esquema.Maestra
WHERE Medico_Dni IS NOT NULL
GO


-- MIGRACION TIPO ESPECIALIDAD
INSERT INTO PROYECTO_W.TipoEspecialidad
SELECT DISTINCT Tipo_Especialidad_Codigo, Tipo_Especialidad_Descripcion
FROM gd_esquema.Maestra
WHERE Tipo_Especialidad_Codigo IS NOT NULL
GO

-- MIGRACION ESPECIALIDAD
INSERT INTO PROYECTO_W.Especialidad
SELECT DISTINCT Especialidad_Codigo, Especialidad_Descripcion, Tipo_Especialidad_Codigo
FROM gd_esquema.Maestra
WHERE Especialidad_Codigo IS NOT NULL
GO

-- MIGRACION TURNOS PEDIDOS PACIENTE
INSERT INTO [PROYECTO_W].[Turno] (turno_nro, turno_afil_nro, turno_fecha, turno_prof_cod,turno_esp_cod) 
SELECT DISTINCT MAE.Turno_Numero, AFI.afil_nro, MAE.Turno_Fecha, PRO.prof_cod, MAE.Especialidad_Codigo
FROM gd_esquema.Maestra AS MAE
JOIN PROYECTO_W.Afiliado AS AFI ON MAE.Paciente_Dni = AFI.afil_doc_nro
JOIN PROYECTO_W.Profesional AS PRO ON MAE.Medico_Dni = PRO.prof_doc_nro
WHERE MAE.Turno_Numero IS NOT NULL
GO -- PEDIDOS ES EL ESTADO POR DEFAULT

DECLARE @FECHA_ACTUAL DATETIME = '2013-14-04'  -- fecha , esa que saldria de config
UPDATE TUR SET turno_estado='N' -- Ni se registraron, pasó la fecha y no hay ninguna fila que diga que utilizaron bono consulta
FROM [PROYECTO_W].[Turno] AS TUR
WHERE NOT EXISTS
(
SELECT turno_nro
FROM gd_esquema.Maestra as MAE
WHERE MAE.Turno_Numero = TUR.turno_nro
AND MAE.Turno_Fecha <= @FECHA_ACTUAL AND MAE.Bono_Consulta_Numero IS NOT NULL
)

UPDATE TUR SET turno_estado='P' -- Pedido, fecha en futuro, no existe ninguna fila que diga que se registraron
FROM [PROYECTO_W].[Turno] AS TUR
WHERE TUR.turno_fecha > @FECHA_ACTUAL AND NOT EXISTS
(
SELECT turno_nro
FROM gd_esquema.Maestra as MAE
WHERE MAE.Turno_Numero = TUR.turno_nro AND MAE.Bono_Consulta_Numero IS NOT NULL
)

UPDATE TUR SET turno_estado='A' -- se Atendieron, independientemente de la fecha, figuran atendidos
FROM [PROYECTO_W].[Turno] AS TUR
WHERE EXISTS
(
SELECT turno_nro
FROM gd_esquema.Maestra as MAE
WHERE MAE.Turno_Numero = TUR.turno_nro
AND MAE.Bono_Consulta_Numero IS NOT NULL AND MAE.Consulta_Sintomas IS NOT NULL
)
GO

-- MIGRACION BONO ADQUIRIDO
-- No falta la suma pagada (consultar con los precios del plan)
INSERT INTO 
PROYECTO_W.BonoAdquirido 
        (bonadq_afil_nro, bonadq_tipo_bono, bonadq_fecha_compra, bonadq_fecha_impresion,bonadq_cantidad_comprada, bonadq_plan_cod, bonadq_afil_doc_nro)
SELECT  AFIL.afil_nro AS Afil_Cod, 'Consulta' AS Tipo_Bono, Compra_Bono_Fecha, Bono_Consulta_Fecha_Impresion AS Fecha_Impresion, 
        COUNT (*) AS Cant_Comprada, Plan_Med_Codigo, Paciente_Dni
FROM gd_esquema.Maestra A
JOIN PROYECTO_W.Afiliado AS AFIL ON A.Paciente_Dni = AFIL.afil_doc_nro
WHERE Compra_Bono_Fecha IS NOT NULL AND Bono_Consulta_Numero IS NOT NULL
GROUP BY AFIL.afil_nro, Compra_Bono_Fecha, Bono_Consulta_Fecha_Impresion, Plan_Med_Codigo, A.Paciente_Dni
UNION 
SELECT AFIL.afil_nro AS Afil_Cod, 'Farmacia' AS Tipo_Bono, Compra_Bono_Fecha, Bono_Farmacia_Fecha_Impresion AS Fecha_Impresion, 
        COUNT (*) AS Cant_Comprada, Plan_Med_Codigo, Paciente_Dni
FROM gd_esquema.Maestra A
JOIN PROYECTO_W.Afiliado AS AFIL ON A.Paciente_Dni = AFIL.afil_doc_nro
WHERE Compra_Bono_Fecha IS NOT NULL AND Bono_Farmacia_Numero IS NOT NULL
GROUP BY AFIL.afil_nro, Compra_Bono_Fecha, Bono_Farmacia_Fecha_Impresion, Plan_Med_Codigo, A.Paciente_Dni
GO

-- Suma pagada Bono Adquirido Consulta
UPDATE BA SET BA.bonadq_suma_pagada = BA.bonadq_cantidad_comprada * PL.plan_precio_bono_consulta
FROM PROYECTO_W.BonoAdquirido AS BA
JOIN [GD2C2013].[PROYECTO_W].[Plan] AS PL
ON BA.bonadq_plan_cod = PL.plan_cod
WHERE BA.bonadq_tipo_bono = 'Consulta'
GO
-- Suma pagada Bono Adquirido Farmacia
UPDATE BA SET BA.bonadq_suma_pagada = BA.bonadq_cantidad_comprada * PL.plan_precio_bono_farmacia
FROM PROYECTO_W.BonoAdquirido AS BA
JOIN [GD2C2013].[PROYECTO_W].[Plan] AS PL
ON BA.bonadq_plan_cod = PL.plan_cod
WHERE BA.bonadq_tipo_bono = 'Farmacia'
GO


-- ##################################################################################
-- TABLA AUXILIAR BONOCONSULTA
CREATE TABLE [PROYECTO_W].[#Bono_Consulta_Aux] (
bonoconsaux_cod bigint not null,
bonoconsaux_estado char(1) not null )
GO

-- MIGRACION BONO CONSULTA
-- Falta nro de bono adquirido buscarlo por fecha en esa tabla
-- Bonos usados y no usados EL 46498 NUNCA LO UTILIZARON
-- Tabla AUX
INSERT INTO #Bono_Consulta_Aux (bonoconsaux_cod, bonoconsaux_estado)
SELECT A.Bono_Consulta_Numero, 'Estado' = 
        CASE
                WHEN EXISTS (SELECT B.Bono_Consulta_Numero
                                FROM gd_esquema.Maestra B
                                WHERE B.Bono_Consulta_Numero IS NOT NULL AND B.Turno_Numero IS NOT NULL AND A.Bono_Consulta_Numero = B.Bono_Consulta_Numero) -- Bono utilizado
            THEN 'U'
                ELSE 'S'
        END
FROM gd_esquema.Maestra A
WHERE Bono_Consulta_Numero IS NOT NULL AND Turno_Numero IS NULL  -- Bono Comprados
GO

-- INSERT EN LA TABLA

INSERT INTO PROYECTO_W.BonoConsulta (bonocons_bonadq_cod, bonocons_cod, bonocons_estado)
SELECT C.bonadq_cod, A.bonoconsaux_cod, A.bonoconsaux_estado
FROM PROYECTO_W.#Bono_Consulta_Aux A, gd_esquema.Maestra B, PROYECTO_W.BonoAdquirido C
WHERE A.bonoconsaux_cod = B.Bono_Consulta_Numero AND B.Turno_Numero IS NULL AND B.Bono_Consulta_Numero IS NOT NULL AND B.Paciente_Dni = C.bonadq_afil_doc_nro AND B.Compra_Bono_Fecha = C.bonadq_fecha_compra AND C.bonadq_tipo_bono = 'Consulta'-- Bono Comprado
GO

-- BORRAR LA TABLA AUX
DROP TABLE [PROYECTO_W].[#Bono_Consulta_Aux]
GO

-- ##################################################################################
-- TABLA AUXILIAR BONO FARMACIA
CREATE TABLE [PROYECTO_W].[#Bono_Farmacia_Aux] (
bonofarsaux_cod bigint not null,
bonofarsaux_estado char(1) not null,
bonofaraux_fecha_venc datetime not null )
GO

-- MIGRACION BONO FARMACIA
INSERT INTO #Bono_Farmacia_Aux (bonofarsaux_cod, bonofaraux_fecha_venc, bonofarsaux_estado)
SELECT A.Bono_Farmacia_Numero, Bono_Farmacia_Fecha_Vencimiento, 'U' AS Estado 
FROM gd_esquema.Maestra A
WHERE Bono_Farmacia_Numero IS NOT NULL AND Turno_Numero IS NULL  -- Bono Comprados
GO

-- INSERT TABLA ORIGINAL BONO FARMACIA
INSERT INTO PROYECTO_W.BonoFarmacia (bonofarm_bonadq_cod, bonofarm_cod, bonofarm_estado, bonofarm_fecha_venc)
SELECT C.bonadq_cod, A.bonofarsaux_cod, A.bonofarsaux_estado, bonofaraux_fecha_venc
FROM PROYECTO_W.#Bono_Farmacia_Aux A, gd_esquema.Maestra B, PROYECTO_W.BonoAdquirido C
WHERE A.bonofarsaux_cod = B.Bono_Farmacia_Numero AND B.Turno_Numero IS NULL AND B.Bono_Farmacia_Numero IS NOT NULL AND B.Paciente_Dni = C.bonadq_afil_doc_nro AND B.Compra_Bono_Fecha = C.bonadq_fecha_compra AND C.bonadq_tipo_bono = 'Farmacia'-- Bono Comprado
GO

-- BORRAR LA TABLA AUX
DROP TABLE [PROYECTO_W].[#Bono_Farmacia_Aux]
GO

--#########################################################
-- BORRAR CAMPO DNI DE BONO ADQUIRIDO
ALTER TABLE [PROYECTO_W].[BonoAdquirido] DROP COLUMN [bonadq_afil_doc_nro]
GO

-- INGRESO DE MEDICAMENTOS EN TABLA DE MEDICAMENTOS
INSERT INTO PROYECTO_W.Medicamento (medicamento_nombre)
SELECT DISTINCT Bono_Farmacia_Medicamento 
FROM gd_esquema.Maestra
WHERE Bono_Farmacia_Medicamento IS NOT NULL
GO

-- MIGRACION MEDICAMENTOS POR BONO FARMACIA
INSERT INTO PROYECTO_W.MedicamentoPorBonoFarmacia (medxbonofar_bonofarm_cod, medxbonofar_medicamento_nombre_cod, medxbonofar_medicamento_cantidad)
SELECT Bono_Farmacia_Numero, MED.medicamento_nombre_cod, 1 AS Cant_Med
FROM gd_esquema.Maestra AS MAE
RIGHT JOIN PROYECTO_W.Medicamento AS MED
ON MAE.Bono_Farmacia_Medicamento = MED.medicamento_nombre
WHERE Bono_Farmacia_Medicamento IS NOT NULL
GO

-- MIGRACION TABLA TURNO_LLEGADA
INSERT INTO PROYECTO_W.TurnoLlegada (turlle_turno_nro, turlle_afil_nro_consulta, turlle_bonocons_cod)
SELECT A.turno_nro, ROW_NUMBER() OVER(PARTITION BY A.turno_afil_nro ORDER BY A.turno_fecha) AS Nro_Consulta, B.Bono_Consulta_Numero AS Bono_Nro
FROM PROYECTO_W.Turno A, gd_esquema.Maestra B
WHERE A.turno_estado = 'A' AND A.turno_nro = B.Turno_Numero AND B.Bono_Consulta_Numero IS NOT NULL
GO

-- MIGRACION RECETA
INSERT INTO PROYECTO_W.Receta (receta_bonofarm_cod, receta_fecha_prescripcion)
SELECT Bono_Farmacia_Numero, Bono_Farmacia_Fecha_Vencimiento
FROM gd_esquema.Maestra
WHERE Bono_Farmacia_Medicamento IS NOT NULL
GO

-- MIGRACION TABLA BONO POR RECETA
INSERT INTO PROYECTO_W.BonoPorReceta (bonoxreceta_bonofarm_cod, bonoxreceta_receta_cod)
SELECT receta_bonofarm_cod, receta_cod
FROM PROYECTO_W.Receta
GO

-- MIGRACION TURNO CONCRETADO
INSERT INTO PROYECTO_W.TurnoConcretado (turconcr_sintomas, turconcr_diagnostico, turconcr_turno_nro, turconcr_receta_cod)
SELECT Consulta_Sintomas, Consulta_Enfermedades, Turno_Numero, B.receta_cod
FROM gd_esquema.Maestra A, PROYECTO_W.Receta B
WHERE A.Bono_Farmacia_Medicamento IS NOT NULL AND A.Bono_Farmacia_Numero = B.receta_bonofarm_cod
ORDER BY Turno_Numero
GO

-- BORRAR COLUMNA BONO_FARM DE RECETA
ALTER TABLE [PROYECTO_W].[Receta] DROP COLUMN [receta_bonofarm_cod]
GO

-- MIGRACION ESPECIALIDAD POR PROFESIONAL
INSERT INTO PROYECTO_W.EspecialidadPorProfesional (espxprof_prof_cod, espxprof_esp_cod)
SELECT DISTINCT B.prof_cod, Especialidad_Codigo
FROM gd_esquema.Maestra A, PROYECTO_W.Profesional B
WHERE A.Turno_Numero IS NOT NULL AND A.Bono_Consulta_Numero IS NULL AND A.Medico_Dni = B.prof_doc_nro
GO

-- LO QUE HACE A LO ULTIMO
ALTER TABLE [PROYECTO_W].[TurnoConcretado]
ADD CONSTRAINT FK_TurnoConcretado_turconcr_receta_cod
FOREIGN KEY([turconcr_receta_cod]) REFERENCES [PROYECTO_W].[Receta] ([receta_cod])
GO

ALTER TABLE [PROYECTO_W].[BonoPorReceta]
ADD CONSTRAINT FK_BonoPorReceta_bonoxreceta_receta_cod
FOREIGN KEY([bonoxreceta_receta_cod]) REFERENCES [PROYECTO_W].[Receta] ([receta_cod])
GO

SET IDENTITY_INSERT [PROYECTO_W].[Receta] ON
GO

--#-#-# INSERT DE COSAS Y ESO
        -- INSERT DE FUNCIONALIDAD
INSERT INTO PROYECTO_W.Funcionalidad (func_nombre) VALUES ('ABM_LOGIN'),
('ABM_REGISTRO_USUA'), ('ABM_AFILIADO'), ('ABM_PROFESIONAL'), ('ABM_ESP_MED'),
('ABM_PLAN'), ('ABM_AGEN_PROF'), ('ABM_BONOS'), ('ABM_TURNO'), 
('ABM_REGISTRO_LLEGADA'), ('ABM_REG_ATENCION'), ('ABM_CANCELACION'), ('ABM_RECETA'),
('ABM_ESTADISTICO');
GO
        -- INSERT DE ROL
INSERT INTO PROYECTO_W.Rol (rol_nombre) VALUES ('ADMINISTRADOR'),
('AFILIADO'), ('PROFESIONAL');
GO
        -- INSERT DE FUNCIONALIDAD POR ROL
INSERT INTO PROYECTO_W.FuncionalidadPorRol (funcxrol_rol_cod,funcxrol_func_cod)
SELECT R.rol_cod, F.func_cod
FROM PROYECTO_W.Funcionalidad AS F
CROSS JOIN PROYECTO_W.Rol AS R
ORDER BY R.rol_cod
GO
        -- FUNCIONALIDADES DEL ROL ADMINISTRADOR HABILITADO TODO, DE LOS DEMAS ROLES ESTA TODO DESACTIVADO
UPDATE FPR SET funcxrol_estado='H'
FROM PROYECTO_W.FuncionalidadPorRol AS FPR
JOIN PROYECTO_W.Rol AS ROL ON ROL.rol_cod = FPR.funcxrol_rol_cod
WHERE ROL.rol_nombre = 'ADMINISTRADOR'
GO
        -- INSERT DE USUARIO ADMIN,,, PONER PASSWORD BIEN DESPUES CON SHA256 Y ESO TODO
INSERT INTO PROYECTO_W.Usuario (usu_username,usu_password) -- cant intentos cero por defaul, etado 'H' po defol
VALUES ('admin','w23e')
GO
        -- INSERT DE ROL ADMINISTRADOR PARA USER ADMIN
INSERT INTO PROYECTO_W.RolPorUsuario (rolxusu_rol_cod,rolxusu_username)
SELECT ROL.rol_cod,USUA.usu_username
FROM PROYECTO_W.Rol AS ROL, PROYECTO_W.Usuario AS USUA
WHERE ROL.rol_nombre = 'ADMINISTRADOR' AND USUA.usu_username = 'admin'
GO

--#-#-# TRIGGERS
		-- MATRICULA DEBE SER NULL O UNICA; SINO NO SE INSERTA Y DA ERROR
CREATE TRIGGER TR_PROFESIONAL_MATRICULA
ON PROYECTO_W.Profesional
INSTEAD OF INSERT
AS
IF EXISTS 
(
SELECT * FROM inserted AS INS 
JOIN PROYECTO_W.Profesional AS PRO ON PRO.prof_matricula = INS.prof_matricula
WHERE INS.prof_matricula IS NOT NULL
)
BEGIN
RAISERROR('NO SE REALIZA INSERT CON MATRICULAS EXISTENTES',16,1)
END
ELSE
BEGIN
INSERT INTO PROYECTO_W.Profesional 
(prof_apellido,prof_direccion,prof_doc_nro,prof_doc_tipo,prof_estado,prof_fecha_nac,prof_mail
,prof_matricula,prof_nombre,prof_sexo,prof_telefono,prof_username)
SELECT prof_apellido,prof_direccion,prof_doc_nro,prof_doc_tipo,prof_estado,prof_fecha_nac,prof_mail
,prof_matricula,prof_nombre,prof_sexo,prof_telefono,prof_username FROM INSERTED
END

-- HABRIA QUE PONER RESTRICCIONES, QUE UN ADMIN NO SE PUEDA ASIGNAR A USUARIOS AFILIADOS Y PROFESIONALES
-- QUE UN USERNAME NO PUEDA SER DE USUARIO Y PROF DISTINTOS A LA VEZ,, ETC