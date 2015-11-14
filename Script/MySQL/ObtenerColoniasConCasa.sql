/*
	STORE PROCEDURE QUE TRAERA TODAS LAS COLONIAS QUE ESTEN RELACIONADAS CON 1 O MAS CASAS
*/
DELIMITER $$

DROP PROCEDURE IF EXISTS ObtenerColoniasConCasa$$

CREATE PROCEDURE ObtenerColoniasConCasa()
BEGIN
	SELECT
	`colonia`.`idColonia`,
	`colonia`.`nombreColonia`
	FROM `controlcasa`.`colonia`
	INNER JOIN casa ON casa.coloniaCasa=idColonia;
END
$$