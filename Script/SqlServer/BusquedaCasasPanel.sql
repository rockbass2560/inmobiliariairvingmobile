USE controlcasa

GO

IF EXISTS(SELECT * FROM sys.procedures WHERE name='BusquedaCasasPanel')
	DROP PROCEDURE BusquedaCasasPanel
GO

CREATE PROCEDURE BusquedaCasasPanel
(
	@index INT=0,
	@count INT=100
)
AS
BEGIN

SELECT
	idCasa as ID,
	calleCasa as Calle,
	precioCasa as Precio,
	nombreColonia as Colonia,
	nombreCiudad as Ciudad,
	nombreTipo as TipoInmueble,
	nombreTipoTransaccion as TipoTransaccion,
	recamaraCasa as Recamaras,
	banoCasa as Banos,
	terrenoCasa as Terreno,
	construccionCasa as Construccion,
	descripcionCasa as Descripcion,
	fotografiaCasa as Fotografia,
	enVentaCasa as EnVenta
FROM
   (
		SELECT
			idCasa,
			calleCasa,
			precioCasa,
			coloniaCasa,
			ciudadCasa,
			tipoInmuebleCasa,
			tipoTransaccionCasa,
			recamaraCasa,
			banoCasa,
			terrenoCasa,
			construccionCasa,
			descripcionCasa,
			fotografiaCasa,
			enVentaCasa,
			Row_Number() OVER (ORDER BY idCasa) AS RowNumber
		FROM casa
		--WHERE
			--enVentaCasa=1
	) AS casa
INNER JOIN ciudad ON idCiudad=ciudadCasa
INNER JOIN tipotransaccion ON idTipoTransaccion=casa.tipoTransaccionCasa
INNER JOIN tipoinmueble ON idTipo=casa.tipoInmuebleCasa
INNER JOIN colonia ON idColonia=coloniaCasa
WHERE RowNumber > @index AND RowNumber <= @count
ORDER BY ID
END