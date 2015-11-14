USE controlcasa

GO

IF EXISTS(SELECT * FROM sys.procedures WHERE name='BusquedaCasas')
	DROP PROCEDURE BusquedaCasas
GO

CREATE PROCEDURE BusquedaCasas
(
	@tipoTransaccion VARCHAR(MAX)=NULL, 
	@tipoInmueble VARCHAR(MAX)=NULL, 
	@ciudad VARCHAR(MAX)=NULL, 
	@colonia VARCHAR(MAX)=NULL, 
	@precioMenor decimal=NULL, 
	@precioMayor decimal=NULL,
	@index INT=0,
	@count INT=10
)
AS
BEGIN

DECLARE @tipoTransaccionTable TABLE (ID INT)
DECLARE @tipoInmuebleTable TABLE (ID INT)
DECLARE @ciudadTable TABLE (ID INT)
DECLARE @coloniaTable TABLE (ID INT)

IF ISNULL(@tipoTransaccion,'1')='1'
BEGIN
	INSERT INTO @tipoTransaccionTable
	VALUES(1),(2),(3)
END
ELSE
BEGIN
	INSERT INTO @tipoTransaccionTable
	SELECT ID FROM Split(@tipoTransaccion)
END

IF ISNULL(@tipoInmueble,'1')='1'
BEGIN
	INSERT INTO @tipoInmuebleTable
	SELECT idTipo FROM tipoinmueble	
END
ELSE
BEGIN
	INSERT INTO @tipoInmuebleTable
	SELECT ID FROM Split(@tipoTransaccion)
END

IF ISNULL(@ciudad,'1')='1'
BEGIN
	INSERT INTO @ciudadTable
	SELECT idCiudad FROM ciudad
END
ELSE
BEGIN
	INSERT INTO @ciudadTable
	SELECT ID FROM Split(@ciudad)
END

IF ISNULL(@colonia,'1')='1'
BEGIN
	INSERT INTO @coloniaTable
	SELECT idColonia FROM colonia
END
ELSE
BEGIN
	INSERT INTO @coloniaTable
	SELECT ID FROM Split(@colonia)
END

SET @precioMenor=COALESCE(@precioMenor,0);
SET @precioMayor=COALESCE(@precioMayor,(SELECT (MAX(precioCasa)+1) FROM casa));

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
	fotografiaCasa as Fotografia
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
			Row_Number() OVER (ORDER BY idCasa) AS RowNumber
		FROM casa
		WHERE
			tipoTransaccionCasa IN (SELECT ID FROM @tipoTransaccionTable) AND
			tipoInmuebleCasa IN (SELECT ID FROM @tipoTransaccionTable) AND
			coloniaCasa IN (SELECT ID FROM @coloniaTable) AND
			ciudadCasa IN (SELECT ID FROM @ciudadTable) AND
			precioCasa BETWEEN @precioMenor AND @precioMayor AND
			enVentaCasa=1
	) AS casa
INNER JOIN ciudad ON idCiudad=ciudadCasa
INNER JOIN tipotransaccion ON idTipoTransaccion=casa.tipoTransaccionCasa
INNER JOIN tipoinmueble ON idTipo=casa.tipoInmuebleCasa
INNER JOIN colonia ON idColonia=coloniaCasa
WHERE RowNumber > @index AND RowNumber <= @count
ORDER BY ID
END