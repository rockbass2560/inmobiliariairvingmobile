CREATE PROCEDURE UpdateCasa
(
	@ID int,
	@Calle nvarchar(400),
	@Numero nvarchar(60),
	@Precio real,
	@Colonia int,
	@Ciudad int,
	@TipoInmueble int,
	@TipoTransaccion int,
	@Forma int,
	@CodigoPostal nvarchar(20),
	@Propietario nvarchar(60),
	@Niveles int,
	@Recamara int,
	@Cochera int,
	@Bano real,
	@Terreno real,
	@Construccion real,
	@Descripcion nvarchar(800),
	@Frente real,
	@Fondo real,
	@Esquina bit,
	@Jardin bit,
	@Estudio bit,
	@Alberca bit,
	@Edad int,
	@Telefono nvarchar(30),
	@EnVenta bit,
	@Fotografia varchar(50)
)
AS
BEGIN
UPDATE [casa]
   SET [calleCasa] = @Calle
      ,[numeroCasa] = @Numero
      ,[precioCasa] = @Precio
      ,[coloniaCasa] = @Colonia
      ,[ciudadCasa] = @Ciudad
      ,[tipoInmuebleCasa] = @TipoInmueble
      ,[tipoTransaccionCasa] = @TipoTransaccion
      ,[formaCasa] = @Forma
      ,[codigoPostalCasa] = @CodigoPostal
      ,[propietarioCasa] = @Propietario
      ,[nivelesCasa] = @Niveles
      ,[recamaraCasa] = @Recamara
      ,[cocheraCasa] = @Cochera
      ,[banoCasa] = @Bano
      ,[terrenoCasa] = @Terreno
      ,[construccionCasa] = @Construccion
      ,[descripcionCasa] = @Descripcion
      ,[frenteCasa] = @Frente
      ,[fondoCasa] = @Fondo
      ,[esquinaCasa] = @Esquina
      ,[jardinCasa] = @Jardin
      ,[estudioCasa] = @Estudio
      ,[albercaCasa] = @Alberca
      ,[edadCasa] = @Edad
      ,[telefonoCasa] = @Telefono
      ,[enVentaCasa] = @EnVenta
      ,[fotografiaCasa] = @Fotografia
 WHERE idCasa=@ID
END