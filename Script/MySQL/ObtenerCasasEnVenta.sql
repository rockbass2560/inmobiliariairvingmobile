delimiter $$

DROP PROCEDURE IF EXISTS ObtenerCasasEnVenta$$

CREATE PROCEDURE `ObtenerCasasEnVenta`(EnVenta bool)
BEGIN
	SELECT
	`casa`.`idCasa`,
	`casa`.`calleCasa`,
	`casa`.`numeroCasa`,
	`casa`.`precioCasa`,
	`casa`.`coloniaCasa`,
	`casa`.`ciudadCasa`,
	`casa`.`tipoInmuebleCasa`,
	`casa`.`tipoTransaccionCasa`,
	`casa`.`formaCasa`,
	`casa`.`codigoPostalCasa`,
	`casa`.`propietarioCasa`,
	`casa`.`nivelesCasa`,
	`casa`.`recamaraCasa`,
	`casa`.`cocheraCasa`,
	`casa`.`banoCasa`,
	`casa`.`terrenoCasa`,
	`casa`.`construccionCasa`,
	`casa`.`descripcionCasa`,
	`casa`.`frenteCasa`,
	`casa`.`fondoCasa`,
	`casa`.`esquinaCasa`,
	`casa`.`jardinCasa`,
	`casa`.`estudioCasa`,
	`casa`.`albercaCasa`,
	`casa`.`edadCasa`,
	`casa`.`telefonoCasa`,
	`casa`.`enVentaCasa`
	FROM `controlcasa`.`casa`
	WHERE enVentaCasa=EnVenta;

END$$

