USE controlcasa


IF EXISTS(SELECT * FROM sys.procedures WHERE name='CreateID')
BEGIN
	DROP PROCEDURE CreateID
END

GO


CREATE PROCEDURE CreateID
AS
BEGIN

SET NOCOUNT ON

INSERT INTO [controlcasa].[dbo].[casa]
           ([calleCasa]
           ,[numeroCasa]
           ,[precioCasa]
           ,[coloniaCasa]
           ,[ciudadCasa]
           ,[tipoInmuebleCasa]
           ,[tipoTransaccionCasa]
           ,[formaCasa])
     VALUES
          (
			'',
			0,
			0,
			1,
			1,
			1,
			1,
			1
          )


SELECT IDENT_CURRENT('casa') LASTID

END
