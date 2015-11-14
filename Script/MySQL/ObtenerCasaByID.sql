DELIMITER $$

DROP PROCEDURE IF EXISTS ObtenerCasaByID$$

CREATE PROCEDURE ObtenerCasaByID(ID INT)
BEGIN
	SELECT
	`casa`.`idCasa` as ID,
	`casa`.`calleCasa` as Calle,
	`casa`.`numeroCasa` as Numero,
	`casa`.`precioCasa` as Precio,
	nombreColonia as Colonia,
	nombreCiudad as Ciudad,
	nombreTipo as TipoInmueble,
	nombreTipoTransaccion as TipoTransaccion,
	`casa`.`codigoPostalCasa` as CodigoPostal,
	`casa`.`nivelesCasa` as Niveles,
	`casa`.`recamaraCasa` as Recamara,
	`casa`.`cocheraCasa` as Cochera,
	`casa`.`banoCasa` as Banos,
	`casa`.`terrenoCasa` as Terreno,
	`casa`.`construccionCasa` as Construccion,
	`casa`.`descripcionCasa` as Descripcion,
	`casa`.`frenteCasa` as Frente,
	`casa`.`fondoCasa` as Fondo,
	`casa`.`esquinaCasa` as Esquina,
	`casa`.`jardinCasa` as Jardin,
	`casa`.`estudioCasa` as Estudio,
	`casa`.`albercaCasa` as Alberca,
	`casa`.`telefonoCasa` as Telefono
	FROM `casa`
	INNER JOIN Colonia ON colonia.idColonia=Casa.coloniaCasa
	INNER JOIN Ciudad ON ciudad.idCiudad=ciudadCasa
	INNER JOIN TipoInmueble ON tipoInmuebleCasa=idTipo
	INNER JOIN TipoTransaccion ON tipoTransaccionCasa=idTipoTransaccion
	WHERE idCasa=ID;

	
END
$$
DELIMITER ;