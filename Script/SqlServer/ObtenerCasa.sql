CREATE PROCEDURE ObtenerCasa
(
	@ID int
)
AS
BEGIN
	SELECT [idCasa] ID
      ,[calleCasa] Calle
      ,[numeroCasa] Numero
      ,[precioCasa] Precio
      ,[coloniaCasa] Colonia
      ,[ciudadCasa] Ciudad
      ,[tipoInmuebleCasa] TipoInmueble
      ,[tipoTransaccionCasa] TipoTransaccion
      ,[formaCasa] Forma
      ,[codigoPostalCasa] CodigoPostal
      ,[propietarioCasa] Propietario
      ,[nivelesCasa] Niveles
      ,[recamaraCasa] Recamara
      ,[cocheraCasa] Cochera
      ,[banoCasa] Bano
      ,[terrenoCasa] Terreno
      ,[construccionCasa] Construccion
      ,[descripcionCasa] Descripcion
      ,[frenteCasa] Frente
      ,[fondoCasa] Fondo
      ,[esquinaCasa] Esquina
      ,[jardinCasa] Jardin
      ,[estudioCasa] Estudio
      ,[albercaCasa] Alberca
      ,[edadCasa] Edad
      ,[telefonoCasa] Telefono
      ,[enVentaCasa] EnVenta
      ,[fotografiaCasa] Fotografia
  FROM [casa]
  WHERE idCasa=@ID
END