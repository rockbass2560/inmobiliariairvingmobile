USE controlcasa
GO

IF EXISTS(SELECT * FROM SYS.PROCEDURES WHERE NAME='ObtenerCatalogo')
BEGIN
	DROP PROCEDURE ObtenerCatalogo
END

GO

CREATE PROCEDURE ObtenerCatalogo(@tableFrom VARCHAR(MAX),@fieldFrom VARCHAR(MAX),@tableJoin VARCHAR(MAX),@fieldJoin VARCHAR(MAX))  
AS  
BEGIN  
 --Se arma la consulta sql generica...  
 DECLARE @sqlStatement VARCHAR(MAX)  
 SET @sqlStatement = 
 'SELECT DISTINCT '+ @tableJoin +'.* 
 FROM '+@tableFrom+
 ' INNER JOIN '+@tableJoin+' ON '+@fieldFrom+'='+@fieldJoin+  
 ' INNER JOIN tipoTransaccion TI ON TI.idTipoTransaccion=casa.tipoTransaccionCasa 
 AND TI.idTipoTransaccion IN (1,2,3) 
 WHERE enVentaCasa=1'  
 EXEC(@sqlStatement)
END 