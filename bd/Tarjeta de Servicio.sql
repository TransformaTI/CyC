IF EXISTS(SELECT * FROM TipoCobro WHERE TipoCobro=22)
BEGIN 
	DELETE FROM TipoCobro WHERE Descripcion='Tarjeta de Servicio'
END 
GO
INSERT INTO [TipoCobro]([TipoCobro], [Descripcion], [TipoPago], [ReporteLiquidacion], [MovimientoCajaCaptura], [Liquidacion], [Alias], [Efectivo], [Existencia], [Comision], [AplicaDescuento], [c_FormaPago])
VALUES(22, 'Tarjeta de Servicio', 1, 2, 1, 1, 'Tarjeta de Servicio', null, null, null, null,29)