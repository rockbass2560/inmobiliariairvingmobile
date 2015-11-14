BEGIN TRANSACTION

SELECT *
INTO casasConFotografia
FROM
	(SELECT idCasa ID,DATALENGTH(fotografiaCasa) longitud FROM casa) casa
WHERE longitud>0

ALTER TABLE casa
DROP COLUMN fotografiaCasa

ALTER TABLE casa
ADD fotografiaCasa VARCHAR(50)

UPDATE casa
SET fotografiaCasa='images/casas/'+ltrim(rtrim(str(idCasa)))+'.jpg'
WHERE idCasa IN (SELECT ID FROM casasConFotografia);


UPDATE casa
SET fotografiaCasa='images/casas/sinimagen.jpg'
WHERE idCasa NOT IN (SELECT ID FROM casasConFotografia);

DROP TABLE casasConFotografia

COMMIT
