-- Listado 1 (especialidades que más se registraron cancelaciones) semestre 1
SELECT TOP 5 ESP.esp_descripcion as Especialidad, ESP.esp_cod as Cod_Especialidad, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 1 THEN 1 ELSE 0 END) AS Cant_Enero, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 2 THEN 1 ELSE 0 END) AS Cant_Febrero, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 3 THEN 1 ELSE 0 END) AS Cant_Marzo, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 4 THEN 1 ELSE 0 END) AS Cant_Abril, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 5 THEN 1 ELSE 0 END) AS Cant_Mayo, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 6 THEN 1 ELSE 0 END) AS Cant_Junio
FROM PROYECTO_W.TurnoCancelacion AS TURNCAN JOIN PROYECTO_W.Turno AS TURN ON TURNCAN.turcan_turno_nro = TURN.turno_nro JOIN PROYECTO_W.Especialidad AS ESP ON ESP.esp_cod = TURN.turno_esp_cod
WHERE YEAR(TURN.turno_fecha) = 2013 AND MONTH(TURN.turno_fecha) >= 1 AND MONTH(TURN.turno_fecha) <= 6
GROUP BY ESP.esp_cod, ESP.esp_descripcion
ORDER BY COUNT(*) DESC

-- Listado 1 (especialidades que más se registraron cancelaciones) semestre 2
SELECT TOP 5 ESP.esp_descripcion as Especialidad, ESP.esp_cod as Cod_Especialidad, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 7 THEN 1 ELSE 0 END) AS Cant_Julio, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 8 THEN 1 ELSE 0 END) AS Cant_Agosto, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 9 THEN 1 ELSE 0 END) AS Cant_Septiembre, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 10 THEN 1 ELSE 0 END) AS Cant_Octubre, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 11 THEN 1 ELSE 0 END) AS Cant_Noviembre, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 12 THEN 1 ELSE 0 END) AS Cant_Diciembre
FROM PROYECTO_W.TurnoCancelacion AS TURNCAN JOIN PROYECTO_W.Turno AS TURN ON TURNCAN.turcan_turno_nro = TURN.turno_nro JOIN PROYECTO_W.Especialidad AS ESP ON ESP.esp_cod = TURN.turno_esp_cod
WHERE YEAR(TURN.turno_fecha) = 2013 AND MONTH(TURN.turno_fecha) >= 7 AND MONTH(TURN.turno_fecha) <= 12
GROUP BY ESP.esp_cod, ESP.esp_descripcion
ORDER BY COUNT(*) DESC

-- Listado 2 (Cantidad total de bonos farmacia vencidos por afiliado) semestre 1
DECLARE @FECHA DATETIME
SET @FECHA = PROYECTO_W.F_FECHA_CONFIG()
SELECT TOP 5 AFIL.afil_nro AS Nro_Afil, afil_apellido + ', ' + afil_nombre AS Nom_Y_Apell, SUM(CASE WHEN MONTH(BONOFARM.bonofarm_fecha_venc) = 1 THEN 1 ELSE 0 END) AS Cant_Enero, SUM(CASE WHEN MONTH(BONOFARM.bonofarm_fecha_venc) = 2 THEN 1 ELSE 0 END) AS Cant_Febrero, SUM(CASE WHEN MONTH(BONOFARM.bonofarm_fecha_venc) = 3 THEN 1 ELSE 0 END) AS Cant_Marzo, SUM(CASE WHEN MONTH(BONOFARM.bonofarm_fecha_venc) = 4 THEN 1 ELSE 0 END) AS Cant_Abril, SUM(CASE WHEN MONTH(BONOFARM.bonofarm_fecha_venc) = 5 THEN 1 ELSE 0 END) AS Cant_Mayo, SUM(CASE WHEN MONTH(BONOFARM.bonofarm_fecha_venc) = 6 THEN 1 ELSE 0 END) AS Cant_Junio
FROM PROYECTO_W.BonoFarmacia AS BONOFARM JOIN PROYECTO_W.BonoAdquirido AS BONOADQ ON BONOFARM.bonofarm_bonadq_cod = BONOADQ.bonadq_cod JOIN PROYECTO_W.Afiliado AS AFIL ON AFIL.afil_nro = BONOADQ.bonadq_afil_nro
WHERE BONOFARM.bonofarm_cod NOT IN (SELECT bonoxreceta_bonofarm_cod FROM PROYECTO_W.BonoPorReceta) AND BONOFARM.bonofarm_fecha_venc < @FECHA AND MONTH(BONOFARM.bonofarm_fecha_venc) >= 1 AND MONTH(BONOFARM.bonofarm_fecha_venc) <= 6 AND YEAR(BONOFARM.bonofarm_fecha_venc) = 2013
GROUP BY AFIL.afil_nro, AFIL.afil_nombre, AFIL.afil_apellido
ORDER BY COUNT(*) DESC

-- Listado 2 (Cantidad total de bonos farmacia vencidos por afiliado) semestre 2
--DECLARE @FECHA DATETIME
SET @FECHA = PROYECTO_W.F_FECHA_CONFIG()
SELECT TOP 5 AFIL.afil_nro AS Nro_Afil, afil_apellido + ', ' + afil_nombre AS Nom_Y_Apell, SUM(CASE WHEN MONTH(BONOFARM.bonofarm_fecha_venc) = 7 THEN 1 ELSE 0 END) AS Cant_Julio, SUM(CASE WHEN MONTH(BONOFARM.bonofarm_fecha_venc) = 8 THEN 1 ELSE 0 END) AS Cant_Agosto, SUM(CASE WHEN MONTH(BONOFARM.bonofarm_fecha_venc) = 9 THEN 1 ELSE 0 END) AS Cant_Septiembre, SUM(CASE WHEN MONTH(BONOFARM.bonofarm_fecha_venc) = 10 THEN 1 ELSE 0 END) AS Cant_Octubre, SUM(CASE WHEN MONTH(BONOFARM.bonofarm_fecha_venc) = 11 THEN 1 ELSE 0 END) AS Cant_Noviembre, SUM(CASE WHEN MONTH(BONOFARM.bonofarm_fecha_venc) = 12 THEN 1 ELSE 0 END) AS Cant_Diciembre
FROM PROYECTO_W.BonoFarmacia AS BONOFARM JOIN PROYECTO_W.BonoAdquirido AS BONOADQ ON BONOFARM.bonofarm_bonadq_cod = BONOADQ.bonadq_cod JOIN PROYECTO_W.Afiliado AS AFIL ON AFIL.afil_nro = BONOADQ.bonadq_afil_nro
WHERE BONOFARM.bonofarm_cod NOT IN (SELECT bonoxreceta_bonofarm_cod FROM PROYECTO_W.BonoPorReceta) AND BONOFARM.bonofarm_fecha_venc < @FECHA AND MONTH(BONOFARM.bonofarm_fecha_venc) >= 7 AND MONTH(BONOFARM.bonofarm_fecha_venc) <= 12 AND YEAR(BONOFARM.bonofarm_fecha_venc) = 2013
GROUP BY AFIL.afil_nro, AFIL.afil_nombre, AFIL.afil_apellido
ORDER BY COUNT(*) DESC

-- Listado 3 (Especialidades con mas bonos farmacia recetados) semestre 1
SELECT TOP 5 ESP.esp_descripcion AS Especialidad, ESP.esp_cod AS Cod_Especialidad, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 1 THEN 1 ELSE 0 END) AS Cant_Enero, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 2 THEN 1 ELSE 0 END) AS Cant_Febrero, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 3 THEN 1 ELSE 0 END) AS Cant_Marzo, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 4 THEN 1 ELSE 0 END) AS Cant_Abril, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 5 THEN 1 ELSE 0 END) AS Cant_Mayo, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 6 THEN 1 ELSE 0 END) AS Cant_Junio
FROM PROYECTO_W.TurnoConcretado AS TURNCON JOIN PROYECTO_W.Turno AS TURN ON TURNCON.turconcr_turno_nro = TURN.turno_nro JOIN PROYECTO_W.Especialidad AS ESP ON TURN.turno_esp_cod = ESP.esp_cod JOIN PROYECTO_W.BonoPorReceta ON TURNCON.turconcr_receta_cod = bonoxreceta_receta_cod
WHERE TURNCON.turconcr_receta_cod IS NOT NULL AND MONTH(TURN.turno_fecha) >= 1 AND MONTH(TURN.turno_fecha) <= 6 AND YEAR(TURN.turno_fecha) = 2013
GROUP BY ESP.esp_cod, ESP.esp_descripcion
ORDER BY COUNT(*) DESC

-- Listado 3 (Especialidades con mas bonos farmacia recetados) semestre 2
SELECT TOP 5 ESP.esp_descripcion as Especialidad, ESP.esp_cod as Cod_Especialidad, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 7 THEN 1 ELSE 0 END) AS Cant_Julio, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 8 THEN 1 ELSE 0 END) AS Cant_Agosto, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 9 THEN 1 ELSE 0 END) AS Cant_Septiembre, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 10 THEN 1 ELSE 0 END) AS Cant_Octubre, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 11 THEN 1 ELSE 0 END) AS Cant_Noviembre, SUM(CASE WHEN MONTH(TURN.turno_fecha) = 12 THEN 1 ELSE 0 END) AS Cant_Diciembre
FROM PROYECTO_W.TurnoConcretado AS TURNCON JOIN PROYECTO_W.Turno AS TURN ON TURNCON.turconcr_turno_nro = TURN.turno_nro JOIN PROYECTO_W.Especialidad AS ESP ON TURN.turno_esp_cod = ESP.esp_cod JOIN PROYECTO_W.BonoPorReceta ON TURNCON.turconcr_receta_cod = bonoxreceta_receta_cod
WHERE TURNCON.turconcr_receta_cod IS NOT NULL AND MONTH(TURN.turno_fecha) >= 7 AND MONTH(TURN.turno_fecha) <= 12 AND YEAR(TURN.turno_fecha) = 2013
GROUP BY ESP.esp_cod, ESP.esp_descripcion
ORDER BY COUNT(*) DESC

-- Listado 4 (Afiliados que usaron bonos que no compraron) semestre 1
SELECT afil_nro AS Afil_Cod, afil_apellido + ', ' + afil_apellido AS Nom_Apell_Afil, SUM(CASE WHEN MONTH(turno_fecha) = 1 THEN 1 ELSE 0 END) AS Cant_Enero, SUM(CASE WHEN MONTH(turno_fecha) = 2 THEN 1 ELSE 0 END) AS Cant_Febrero, SUM(CASE WHEN MONTH(turno_fecha) = 3 THEN 1 ELSE 0 END) AS Cant_Marzo, SUM(CASE WHEN MONTH(turno_fecha) = 4 THEN 1 ELSE 0 END) AS Cant_Abril, SUM(CASE WHEN MONTH(turno_fecha) = 5 THEN 1 ELSE 0 END) AS Cant_Mayo, SUM(CASE WHEN MONTH(turno_fecha) = 6 THEN 1 ELSE 0 END) AS Cant_Junio 
FROM PROYECTO_W.V_LISTADO_4
WHERE YEAR(turno_fecha) = 2013 AND MONTH(turno_fecha) >= 1 AND MONTH(turno_fecha) <= 6
GROUP BY afil_nro, afil_nombre, afil_apellido
ORDER BY COUNT(*) DESC

-- Listado 4 (Afiliados que usaron bonos que no compraron) semestre 2
SELECT afil_nro AS Afil_Cod, afil_apellido + ', ' + afil_apellido AS Nom_Apell_Afil, SUM(CASE WHEN MONTH(turno_fecha) = 7 THEN 1 ELSE 0 END) AS Cant_Julio, SUM(CASE WHEN MONTH(turno_fecha) = 8 THEN 1 ELSE 0 END) AS Cant_Agosto, SUM(CASE WHEN MONTH(turno_fecha) = 9 THEN 1 ELSE 0 END) AS Cant_Septiembre, SUM(CASE WHEN MONTH(turno_fecha) = 10 THEN 1 ELSE 0 END) AS Cant_Octubre, SUM(CASE WHEN MONTH(turno_fecha) = 11 THEN 1 ELSE 0 END) AS Cant_Noviembre, SUM(CASE WHEN MONTH(turno_fecha) = 12 THEN 1 ELSE 0 END) AS Cant_Diciembre
FROM PROYECTO_W.V_LISTADO_4
WHERE YEAR(turno_fecha) = 2013 AND MONTH(turno_fecha) >= 7 AND MONTH(turno_fecha) <= 12
GROUP BY afil_nro, afil_nombre, afil_apellido
ORDER BY COUNT(*) DESC