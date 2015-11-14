DELIMITER $$

CREATE PROCEDURE `BusquedaCasas` (tipoTransaccion int, tipoInmueble int, ciudad int, colonia int, precioMenor decimal, precioMayor decimal)
BEGIN

SET precioMenor=COALESCE(precioMenor,0);
SET precioMayor=COALESCE(precioMayor,(SELECT (MAX(precioCasa)+1) FROM casa));

SELECT
`casa`.`idCasa` as ID,
`casa`.`precioCasa` as Precio,
nombreColonia as Colonia,
nombreCiudad as Ciudad,
nombreTipo as TipoInmueble,
nombreTipoTransaccion as TipoTransaccion,
`casa`.`recamaraCasa` as Recamaras,
`casa`.`banoCasa` as Banos,
`casa`.`terrenoCasa` as Terreno,
`casa`.`construccionCasa` as Construccion,
`casa`.`descripcionCasa` as Descripcion
FROM `casa`
INNER JOIN ciudad ON idCiudad=ciudadCasa
INNER JOIN tipotransaccion ON idTipoTransaccion=tipoTransaccionCasa
INNER JOIN tipoinmueble ON idTipo=tipoInmuebleCasa
INNER JOIN colonia ON idColonia=coloniaCasa
WHERE
tipoTransaccionCasa=COALESCE(tipoTransaccion,tipoTransaccionCasa) AND
tipoInmuebleCasa = COALESCE(tipoInmueble,tipoInmuebleCasa) AND
coloniaCasa = COALESCE(colonia,coloniaCasa) AND
ciudadCasa = COALESCE(ciudad,ciudadCasa) AND
precioCasa BETWEEN precioMenor AND precioMayor AND
enVentaCasa=TRUE;

END