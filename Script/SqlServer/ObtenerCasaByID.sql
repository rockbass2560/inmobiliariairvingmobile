USE controlcasa

GO

IF EXISTS(SELECT * FROM sys.procedures WHERE name='ObtenerCasaByID')
BEGIN
	DROP PROCEDURE ObtenerCasaByID
END

GO

CREATE PROCEDURE ObtenerCasaByID(@ID INT)
AS
BEGIN
	SELECT
	idCasa as ID,
	calleCasa as Calle,
	numeroCasa as Numero,
	precioCasa as Precio,
	nombreColonia as Colonia,
	nombreCiudad as Ciudad,
	nombreTipo as TipoInmueble,
	nombreTipoTransaccion as TipoTransaccion,
	codigoPostalCasa as CodigoPostal,
	nivelesCasa as Niveles,
	recamaraCasa as Recamara,
	cocheraCasa as Cochera,
	banoCasa as Banos,
	terrenoCasa as Terreno,
	construccionCasa as Construccion,
	descripcionCasa as Descripcion,
	frenteCasa as Frente,
	fondoCasa as Fondo,
	esquinaCasa as Esquina,
	jardinCasa as Jardin,
	estudioCasa as Estudio,
	albercaCasa as Alberca,
	telefonoCasa as Telefono,
	fotografiaCasa as Fotografia
	FROM casa
	INNER JOIN Colonia ON colonia.idColonia=Casa.coloniaCasa
	INNER JOIN Ciudad ON ciudad.idCiudad=ciudadCasa
	INNER JOIN TipoInmueble ON tipoInmuebleCasa=idTipo
	INNER JOIN TipoTransaccion ON tipoTransaccionCasa=idTipoTransaccion
	WHERE idCasa=@ID and enVentaCasa=1
END