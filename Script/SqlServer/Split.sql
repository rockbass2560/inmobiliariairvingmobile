use controlcasa

IF EXISTS(SELECT name FROM sys.objects WHERE type_desc LIKE '%FUNCTION%' AND name='Split')
BEGIN
	DROP FUNCTION Split
END

GO

CREATE FUNCTION Split(@sParametroList varchar(max))
RETURNS @ListaTemporal TABLE
(
	ID varchar(max)
)
BEGIN
	DECLARE @cDelimitador VARCHAR(1) = ',' -- Separador de Datos
	DECLARE @sItem VARCHAR(MAX)
	
	WHILE CHARINDEX(@cDelimitador,@sParametroList,0) <> 0
	BEGIN
		SELECT
			@sItem=RTRIM(LTRIM(SUBSTRING(@sParametroList,1,
			CHARINDEX(@cDelimitador,@sParametroList,0)-1))),
			@sParametroList=RTRIM(LTRIM(SUBSTRING(@sParametroList,
			CHARINDEX(@cDelimitador,@sParametroList,0)
			+LEN(@cDelimitador),LEN(@sParametroList))))
		IF LEN(@sItem) > 0
			INSERT INTO @ListaTemporal SELECT @sItem
		END
		IF LEN(@sParametroList) > 0
			INSERT INTO @ListaTemporal SELECT @sParametroList -- Coloca luego del último elemento
		RETURN
	RETURN
END