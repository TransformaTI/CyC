Public Class frmPrincipal
    Inherits System.Windows.Forms.Form
    Private WithEvents frmConCheques As SigaMetClasses.ConsultaCheques

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        Inhabilitar()
        'Add any initialization after the InitializeComponent() call


    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents stbEstatus As System.Windows.Forms.StatusBar
    Friend WithEvents mnuPrincipal As System.Windows.Forms.MainMenu
    Friend WithEvents mnuAcercade As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSalir As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCheques As System.Windows.Forms.MenuItem
    Friend WithEvents mnuArchivo As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAyuda As System.Windows.Forms.MenuItem
    Friend WithEvents sbpUsuario As System.Windows.Forms.StatusBarPanel
    Friend WithEvents sbpDepartamento As System.Windows.Forms.StatusBarPanel
    Friend WithEvents mnuVentana As System.Windows.Forms.MenuItem
    Friend WithEvents mnuVenCascada As System.Windows.Forms.MenuItem
    Friend WithEvents mnuVenHorizontal As System.Windows.Forms.MenuItem
    Friend WithEvents mnuVenVertical As System.Windows.Forms.MenuItem
    Friend WithEvents mnuConsultaDocumento As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCatalogos As System.Windows.Forms.MenuItem
    Friend WithEvents mnuOperador As System.Windows.Forms.MenuItem
    Friend WithEvents mnuConsultaMovimientos As System.Windows.Forms.MenuItem
    Friend WithEvents sbpUsuarioNombre As System.Windows.Forms.StatusBarPanel
    Friend WithEvents mnuTarjetaCredito As System.Windows.Forms.MenuItem
    Friend WithEvents mnuHerramientas As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCambioClave As System.Windows.Forms.MenuItem
    Friend WithEvents tbrPrincipal As System.Windows.Forms.ToolBar
    Friend WithEvents btnMovimientos As System.Windows.Forms.ToolBarButton
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents sbpVersion As System.Windows.Forms.StatusBarPanel
    Friend WithEvents mnuCargoPendiente As System.Windows.Forms.MenuItem
    Friend WithEvents mnuReportes As System.Windows.Forms.MenuItem
    Friend WithEvents mnuConsultaReportes As System.Windows.Forms.MenuItem
    Friend WithEvents btnReportes As System.Windows.Forms.ToolBarButton
    Friend WithEvents mnuReasignaCliente As System.Windows.Forms.MenuItem
    Friend WithEvents mnuConsultaCliente As System.Windows.Forms.MenuItem
    Friend WithEvents btnClientes As System.Windows.Forms.ToolBarButton
    Friend WithEvents mnuLiqDesc As System.Windows.Forms.MenuItem
    Friend WithEvents mnuMovCancel As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents sbpBaseDeDatos As System.Windows.Forms.StatusBarPanel
    Friend WithEvents sbpServidor As System.Windows.Forms.StatusBarPanel
    Friend WithEvents mnuCatMotivoCancelacionMovCaja As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRelCobranza As System.Windows.Forms.MenuItem
    Friend WithEvents btnRelaciones As System.Windows.Forms.ToolBarButton
    Friend WithEvents mnuModificaFechaDev As System.Windows.Forms.MenuItem
    Friend WithEvents mnuConsultaFactura As System.Windows.Forms.MenuItem
    Friend WithEvents mnuConsultaEmpresa As System.Windows.Forms.MenuItem
    Friend WithEvents mnuParametros As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDatosCredito As System.Windows.Forms.MenuItem
    Friend WithEvents mnuClientesNuevos As System.Windows.Forms.MenuItem
    Friend WithEvents mnuClientesCreditoRebasado As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCargoPendienteEmpleado As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCatEmpresas As System.Windows.Forms.MenuItem
    Friend WithEvents btnNuevaNota As System.Windows.Forms.ToolBarButton
    Friend WithEvents mnuAbrirPostit As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCerrarPostit As System.Windows.Forms.MenuItem
    Friend WithEvents mnuNotas As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuPostitLista As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuPostitUsuarioCaptura As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCatClientesDescuento As System.Windows.Forms.MenuItem
    Friend WithEvents mnuExportacion As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAntSaldos As System.Windows.Forms.MenuItem
    Friend WithEvents mnuReportesEspeciales As System.Windows.Forms.MenuItem
    Friend WithEvents mnuNotasCredito As System.Windows.Forms.MenuItem
    Friend WithEvents mnuArqueo As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem9 As System.Windows.Forms.MenuItem
    Friend WithEvents btnPagoReferenciado As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnmportarPagoRef As System.Windows.Forms.ToolBarButton
    Friend WithEvents mnuEjecutivoCyC As System.Windows.Forms.MenuItem
    Friend WithEvents btnQueja As System.Windows.Forms.ToolBarButton
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents mniContactos As System.Windows.Forms.MenuItem
    Friend WithEvents mniAutorizacionCredito As System.Windows.Forms.MenuItem
    Friend WithEvents mniSaldosPendientes As System.Windows.Forms.MenuItem
    Friend WithEvents mniSaldosPendientesCobro As System.Windows.Forms.MenuItem
    Friend WithEvents mniCargos As System.Windows.Forms.MenuItem
    Friend WithEvents mniAbonos As System.Windows.Forms.MenuItem
    Friend WithEvents mniAjustes As System.Windows.Forms.MenuItem
    Friend WithEvents mniAjustesPlanta As System.Windows.Forms.MenuItem
    Friend WithEvents btnResguardo As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCobranzaOp As System.Windows.Forms.ToolBarButton
    Friend WithEvents mniRespResguardo As System.Windows.Forms.MenuItem
    Friend WithEvents mniReprogramacion As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem10 As System.Windows.Forms.MenuItem
    Friend WithEvents mniFiliales As System.Windows.Forms.MenuItem
    Friend WithEvents mniBuroCredito As System.Windows.Forms.MenuItem
    Friend WithEvents mniAbonosExternos As System.Windows.Forms.MenuItem
    Friend WithEvents btnEntregaNotas As System.Windows.Forms.ToolBarButton
    Friend WithEvents MnuCuentasBancariasClientes As MenuItem
    Friend WithEvents MenuItem11 As MenuItem
    Friend WithEvents mnuIngresosSaldoAFavor As MenuItem
    Friend WithEvents mnuExportacionReportes As System.Windows.Forms.MenuItem
    Public Property _URLGateway As String

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrincipal))
        Me.stbEstatus = New System.Windows.Forms.StatusBar()
        Me.sbpUsuario = New System.Windows.Forms.StatusBarPanel()
        Me.sbpUsuarioNombre = New System.Windows.Forms.StatusBarPanel()
        Me.sbpDepartamento = New System.Windows.Forms.StatusBarPanel()
        Me.sbpServidor = New System.Windows.Forms.StatusBarPanel()
        Me.sbpBaseDeDatos = New System.Windows.Forms.StatusBarPanel()
        Me.sbpVersion = New System.Windows.Forms.StatusBarPanel()
        Me.mnuPrincipal = New System.Windows.Forms.MainMenu(Me.components)
        Me.mnuArchivo = New System.Windows.Forms.MenuItem()
        Me.mnuConsultaMovimientos = New System.Windows.Forms.MenuItem()
        Me.mnuConsultaDocumento = New System.Windows.Forms.MenuItem()
        Me.mnuConsultaFactura = New System.Windows.Forms.MenuItem()
        Me.mnuCheques = New System.Windows.Forms.MenuItem()
        Me.mnuConsultaEmpresa = New System.Windows.Forms.MenuItem()
        Me.mnuConsultaCliente = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.mnuDatosCredito = New System.Windows.Forms.MenuItem()
        Me.mnuClientesNuevos = New System.Windows.Forms.MenuItem()
        Me.mnuClientesCreditoRebasado = New System.Windows.Forms.MenuItem()
        Me.mniAutorizacionCredito = New System.Windows.Forms.MenuItem()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.mnuCargoPendiente = New System.Windows.Forms.MenuItem()
        Me.mnuCargoPendienteEmpleado = New System.Windows.Forms.MenuItem()
        Me.MenuItem5 = New System.Windows.Forms.MenuItem()
        Me.mnuLiqDesc = New System.Windows.Forms.MenuItem()
        Me.mnuMovCancel = New System.Windows.Forms.MenuItem()
        Me.mniAjustes = New System.Windows.Forms.MenuItem()
        Me.mniAjustesPlanta = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.mnuRelCobranza = New System.Windows.Forms.MenuItem()
        Me.MenuItem10 = New System.Windows.Forms.MenuItem()
        Me.mnuIngresosSaldoAFavor = New System.Windows.Forms.MenuItem()
        Me.MenuItem8 = New System.Windows.Forms.MenuItem()
        Me.mnuArqueo = New System.Windows.Forms.MenuItem()
        Me.MenuItem9 = New System.Windows.Forms.MenuItem()
        Me.mnuSalir = New System.Windows.Forms.MenuItem()
        Me.mnuCatalogos = New System.Windows.Forms.MenuItem()
        Me.mnuOperador = New System.Windows.Forms.MenuItem()
        Me.mnuTarjetaCredito = New System.Windows.Forms.MenuItem()
        Me.mnuCatMotivoCancelacionMovCaja = New System.Windows.Forms.MenuItem()
        Me.mnuCatEmpresas = New System.Windows.Forms.MenuItem()
        Me.mnuCatClientesDescuento = New System.Windows.Forms.MenuItem()
        Me.mnuEjecutivoCyC = New System.Windows.Forms.MenuItem()
        Me.mniRespResguardo = New System.Windows.Forms.MenuItem()
        Me.mniFiliales = New System.Windows.Forms.MenuItem()
        Me.MnuCuentasBancariasClientes = New System.Windows.Forms.MenuItem()
        Me.MenuItem11 = New System.Windows.Forms.MenuItem()
        Me.mnuReportes = New System.Windows.Forms.MenuItem()
        Me.mnuConsultaReportes = New System.Windows.Forms.MenuItem()
        Me.mnuReportesEspeciales = New System.Windows.Forms.MenuItem()
        Me.mnuAntSaldos = New System.Windows.Forms.MenuItem()
        Me.mnuExportacion = New System.Windows.Forms.MenuItem()
        Me.mnuNotasCredito = New System.Windows.Forms.MenuItem()
        Me.mniSaldosPendientes = New System.Windows.Forms.MenuItem()
        Me.mniSaldosPendientesCobro = New System.Windows.Forms.MenuItem()
        Me.mniCargos = New System.Windows.Forms.MenuItem()
        Me.mniAbonos = New System.Windows.Forms.MenuItem()
        Me.mnuExportacionReportes = New System.Windows.Forms.MenuItem()
        Me.mnuNotas = New System.Windows.Forms.MenuItem()
        Me.mnuAbrirPostit = New System.Windows.Forms.MenuItem()
        Me.mnuCerrarPostit = New System.Windows.Forms.MenuItem()
        Me.MenuItem4 = New System.Windows.Forms.MenuItem()
        Me.mnuPostitLista = New System.Windows.Forms.MenuItem()
        Me.MenuItem6 = New System.Windows.Forms.MenuItem()
        Me.mnuPostitUsuarioCaptura = New System.Windows.Forms.MenuItem()
        Me.mnuHerramientas = New System.Windows.Forms.MenuItem()
        Me.mnuCambioClave = New System.Windows.Forms.MenuItem()
        Me.mniContactos = New System.Windows.Forms.MenuItem()
        Me.mniReprogramacion = New System.Windows.Forms.MenuItem()
        Me.mniBuroCredito = New System.Windows.Forms.MenuItem()
        Me.mniAbonosExternos = New System.Windows.Forms.MenuItem()
        Me.mnuReasignaCliente = New System.Windows.Forms.MenuItem()
        Me.mnuModificaFechaDev = New System.Windows.Forms.MenuItem()
        Me.mnuParametros = New System.Windows.Forms.MenuItem()
        Me.mnuVentana = New System.Windows.Forms.MenuItem()
        Me.mnuVenCascada = New System.Windows.Forms.MenuItem()
        Me.mnuVenHorizontal = New System.Windows.Forms.MenuItem()
        Me.mnuVenVertical = New System.Windows.Forms.MenuItem()
        Me.mnuAyuda = New System.Windows.Forms.MenuItem()
        Me.mnuAcercade = New System.Windows.Forms.MenuItem()
        Me.MenuItem7 = New System.Windows.Forms.MenuItem()
        Me.tbrPrincipal = New System.Windows.Forms.ToolBar()
        Me.btnMovimientos = New System.Windows.Forms.ToolBarButton()
        Me.btnReportes = New System.Windows.Forms.ToolBarButton()
        Me.btnClientes = New System.Windows.Forms.ToolBarButton()
        Me.btnRelaciones = New System.Windows.Forms.ToolBarButton()
        Me.btnNuevaNota = New System.Windows.Forms.ToolBarButton()
        Me.btnQueja = New System.Windows.Forms.ToolBarButton()
        Me.btnmportarPagoRef = New System.Windows.Forms.ToolBarButton()
        Me.btnPagoReferenciado = New System.Windows.Forms.ToolBarButton()
        Me.btnCobranzaOp = New System.Windows.Forms.ToolBarButton()
        Me.btnResguardo = New System.Windows.Forms.ToolBarButton()
        Me.btnEntregaNotas = New System.Windows.Forms.ToolBarButton()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.sbpUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbpUsuarioNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbpDepartamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbpServidor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbpBaseDeDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbpVersion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'stbEstatus
        '
        Me.stbEstatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stbEstatus.Location = New System.Drawing.Point(0, 531)
        Me.stbEstatus.Name = "stbEstatus"
        Me.stbEstatus.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.sbpUsuario, Me.sbpUsuarioNombre, Me.sbpDepartamento, Me.sbpServidor, Me.sbpBaseDeDatos, Me.sbpVersion})
        Me.stbEstatus.ShowPanels = True
        Me.stbEstatus.Size = New System.Drawing.Size(792, 22)
        Me.stbEstatus.TabIndex = 1
        Me.stbEstatus.Text = "Módulo de Crédito y Cobranza  (Prototipo)"
        '
        'sbpUsuario
        '
        Me.sbpUsuario.Name = "sbpUsuario"
        '
        'sbpUsuarioNombre
        '
        Me.sbpUsuarioNombre.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.sbpUsuarioNombre.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.sbpUsuarioNombre.Name = "sbpUsuarioNombre"
        Me.sbpUsuarioNombre.Width = 125
        '
        'sbpDepartamento
        '
        Me.sbpDepartamento.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.sbpDepartamento.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.sbpDepartamento.Name = "sbpDepartamento"
        Me.sbpDepartamento.Width = 125
        '
        'sbpServidor
        '
        Me.sbpServidor.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.sbpServidor.Icon = CType(resources.GetObject("sbpServidor.Icon"), System.Drawing.Icon)
        Me.sbpServidor.Name = "sbpServidor"
        Me.sbpServidor.ToolTipText = "Nombre del servidor"
        Me.sbpServidor.Width = 150
        '
        'sbpBaseDeDatos
        '
        Me.sbpBaseDeDatos.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.sbpBaseDeDatos.MinWidth = 100
        Me.sbpBaseDeDatos.Name = "sbpBaseDeDatos"
        Me.sbpBaseDeDatos.ToolTipText = "Nombre de la base de datos"
        Me.sbpBaseDeDatos.Width = 150
        '
        'sbpVersion
        '
        Me.sbpVersion.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.sbpVersion.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.sbpVersion.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None
        Me.sbpVersion.Name = "sbpVersion"
        Me.sbpVersion.Width = 125
        '
        'mnuPrincipal
        '
        Me.mnuPrincipal.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuArchivo, Me.mnuCatalogos, Me.mnuReportes, Me.mnuNotas, Me.mnuHerramientas, Me.mnuVentana, Me.mnuAyuda, Me.MenuItem7})
        '
        'mnuArchivo
        '
        Me.mnuArchivo.Index = 0
        Me.mnuArchivo.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuConsultaMovimientos, Me.mnuConsultaDocumento, Me.mnuConsultaFactura, Me.mnuCheques, Me.mnuConsultaEmpresa, Me.mnuConsultaCliente, Me.MenuItem2, Me.mnuDatosCredito, Me.mnuClientesNuevos, Me.mnuClientesCreditoRebasado, Me.mniAutorizacionCredito, Me.MenuItem1, Me.mnuCargoPendiente, Me.mnuCargoPendienteEmpleado, Me.MenuItem5, Me.mnuLiqDesc, Me.mnuMovCancel, Me.mniAjustes, Me.mniAjustesPlanta, Me.MenuItem3, Me.mnuRelCobranza, Me.MenuItem10, Me.mnuIngresosSaldoAFavor, Me.MenuItem8, Me.mnuArqueo, Me.MenuItem9, Me.mnuSalir})
        Me.mnuArchivo.Text = "&Archivo"
        '
        'mnuConsultaMovimientos
        '
        Me.mnuConsultaMovimientos.Index = 0
        Me.mnuConsultaMovimientos.Shortcut = System.Windows.Forms.Shortcut.F10
        Me.mnuConsultaMovimientos.Text = "&Movimientos"
        '
        'mnuConsultaDocumento
        '
        Me.mnuConsultaDocumento.Index = 1
        Me.mnuConsultaDocumento.Shortcut = System.Windows.Forms.Shortcut.F11
        Me.mnuConsultaDocumento.Text = "&Documentos"
        '
        'mnuConsultaFactura
        '
        Me.mnuConsultaFactura.Index = 2
        Me.mnuConsultaFactura.Text = "&Facturas"
        '
        'mnuCheques
        '
        Me.mnuCheques.Index = 3
        Me.mnuCheques.Text = "C&heques"
        '
        'mnuConsultaEmpresa
        '
        Me.mnuConsultaEmpresa.Index = 4
        Me.mnuConsultaEmpresa.Text = "&Empresas"
        '
        'mnuConsultaCliente
        '
        Me.mnuConsultaCliente.Index = 5
        Me.mnuConsultaCliente.Shortcut = System.Windows.Forms.Shortcut.F12
        Me.mnuConsultaCliente.Text = "&Clientes"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 6
        Me.MenuItem2.Text = "-"
        '
        'mnuDatosCredito
        '
        Me.mnuDatosCredito.Index = 7
        Me.mnuDatosCredito.Text = "Clientes de la cartera"
        '
        'mnuClientesNuevos
        '
        Me.mnuClientesNuevos.Index = 8
        Me.mnuClientesNuevos.Text = "Clientes &nuevos a crédito"
        '
        'mnuClientesCreditoRebasado
        '
        Me.mnuClientesCreditoRebasado.Index = 9
        Me.mnuClientesCreditoRebasado.RadioCheck = True
        Me.mnuClientesCreditoRebasado.Text = "Clientes que ya rebasaron su crédito"
        '
        'mniAutorizacionCredito
        '
        Me.mniAutorizacionCredito.Index = 10
        Me.mniAutorizacionCredito.Text = "&Autorización de crédito"
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 11
        Me.MenuItem1.Text = "-"
        '
        'mnuCargoPendiente
        '
        Me.mnuCargoPendiente.Index = 12
        Me.mnuCargoPendiente.Text = "Cargos &pendientes por identificar"
        '
        'mnuCargoPendienteEmpleado
        '
        Me.mnuCargoPendienteEmpleado.Index = 13
        Me.mnuCargoPendienteEmpleado.Text = "Cargos pendientes de empleado"
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 14
        Me.MenuItem5.Text = "-"
        '
        'mnuLiqDesc
        '
        Me.mnuLiqDesc.Enabled = False
        Me.mnuLiqDesc.Index = 15
        Me.mnuLiqDesc.Text = "Liquidaciones descuadradas"
        Me.mnuLiqDesc.Visible = False
        '
        'mnuMovCancel
        '
        Me.mnuMovCancel.Index = 16
        Me.mnuMovCancel.Text = "Movimientos cancelados"
        '
        'mniAjustes
        '
        Me.mniAjustes.Index = 17
        Me.mniAjustes.Text = "&Ajustes de saldos menores a X"
        '
        'mniAjustesPlanta
        '
        Me.mniAjustesPlanta.Index = 18
        Me.mniAjustesPlanta.Text = "A&juste de faltantes planta"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 19
        Me.MenuItem3.Text = "-"
        '
        'mnuRelCobranza
        '
        Me.mnuRelCobranza.Index = 20
        Me.mnuRelCobranza.Text = "Relaciones de cobranza"
        '
        'MenuItem10
        '
        Me.MenuItem10.Index = 21
        Me.MenuItem10.Text = "Cierre de relaciones pagadas"
        '
        'mnuIngresosSaldoAFavor
        '
        Me.mnuIngresosSaldoAFavor.Enabled = False
        Me.mnuIngresosSaldoAFavor.Index = 22
        Me.mnuIngresosSaldoAFavor.Text = "Ingresos generados por saldo a favor"
        '
        'MenuItem8
        '
        Me.MenuItem8.Index = 23
        Me.MenuItem8.Text = "-"
        '
        'mnuArqueo
        '
        Me.mnuArqueo.Index = 24
        Me.mnuArqueo.Text = "&Arqueo"
        '
        'MenuItem9
        '
        Me.MenuItem9.Index = 25
        Me.MenuItem9.Text = "-"
        '
        'mnuSalir
        '
        Me.mnuSalir.Index = 26
        Me.mnuSalir.Text = "&Salir"
        '
        'mnuCatalogos
        '
        Me.mnuCatalogos.Index = 1
        Me.mnuCatalogos.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuOperador, Me.mnuTarjetaCredito, Me.mnuCatMotivoCancelacionMovCaja, Me.mnuCatEmpresas, Me.mnuCatClientesDescuento, Me.mnuEjecutivoCyC, Me.mniRespResguardo, Me.mniFiliales, Me.MnuCuentasBancariasClientes, Me.MenuItem11})
        Me.mnuCatalogos.Text = "Catálogos"
        '
        'mnuOperador
        '
        Me.mnuOperador.Index = 0
        Me.mnuOperador.Text = "Operadores"
        '
        'mnuTarjetaCredito
        '
        Me.mnuTarjetaCredito.Index = 1
        Me.mnuTarjetaCredito.Text = "&Tarjetas de crédito"
        '
        'mnuCatMotivoCancelacionMovCaja
        '
        Me.mnuCatMotivoCancelacionMovCaja.Index = 2
        Me.mnuCatMotivoCancelacionMovCaja.Text = "&Motivo de cancelación de movimientos"
        '
        'mnuCatEmpresas
        '
        Me.mnuCatEmpresas.Index = 3
        Me.mnuCatEmpresas.Text = "&Empresas"
        '
        'mnuCatClientesDescuento
        '
        Me.mnuCatClientesDescuento.Index = 4
        Me.mnuCatClientesDescuento.Text = "&Clientes con descuento"
        '
        'mnuEjecutivoCyC
        '
        Me.mnuEjecutivoCyC.Index = 5
        Me.mnuEjecutivoCyC.Text = "&Asignación de ejecutivos responsables"
        '
        'mniRespResguardo
        '
        Me.mniRespResguardo.Index = 6
        Me.mniRespResguardo.Text = "Asignacion de &responsables de resguardo"
        '
        'mniFiliales
        '
        Me.mniFiliales.Index = 7
        Me.mniFiliales.Text = "&Filiales"
        '
        'MnuCuentasBancariasClientes
        '
        Me.MnuCuentasBancariasClientes.Index = 8
        Me.MnuCuentasBancariasClientes.Text = "Cuentas bancarias por cliente"
        '
        'MenuItem11
        '
        Me.MenuItem11.Index = 9
        Me.MenuItem11.Text = "Alta pago tarjeta"
        '
        'mnuReportes
        '
        Me.mnuReportes.Index = 2
        Me.mnuReportes.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuConsultaReportes, Me.mnuReportesEspeciales, Me.mnuExportacionReportes})
        Me.mnuReportes.Text = "&Reportes"
        '
        'mnuConsultaReportes
        '
        Me.mnuConsultaReportes.Index = 0
        Me.mnuConsultaReportes.Text = "&Reportes..."
        '
        'mnuReportesEspeciales
        '
        Me.mnuReportesEspeciales.Enabled = False
        Me.mnuReportesEspeciales.Index = 1
        Me.mnuReportesEspeciales.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAntSaldos, Me.mnuExportacion, Me.mnuNotasCredito, Me.mniSaldosPendientes, Me.mniSaldosPendientesCobro, Me.mniCargos, Me.mniAbonos})
        Me.mnuReportesEspeciales.Text = "&Reportes especiales"
        '
        'mnuAntSaldos
        '
        Me.mnuAntSaldos.Index = 0
        Me.mnuAntSaldos.Text = "&Antiguedad de saldos"
        '
        'mnuExportacion
        '
        Me.mnuExportacion.Index = 1
        Me.mnuExportacion.Text = "&Exportación"
        '
        'mnuNotasCredito
        '
        Me.mnuNotasCredito.Index = 2
        Me.mnuNotasCredito.Text = "&Notas de crédito"
        '
        'mniSaldosPendientes
        '
        Me.mniSaldosPendientes.Index = 3
        Me.mniSaldosPendientes.Text = "&Saldos pendientes"
        '
        'mniSaldosPendientesCobro
        '
        Me.mniSaldosPendientesCobro.Index = 4
        Me.mniSaldosPendientesCobro.Text = "Saldos &pendientes cobro"
        '
        'mniCargos
        '
        Me.mniCargos.Index = 5
        Me.mniCargos.Text = "&Cargos"
        '
        'mniAbonos
        '
        Me.mniAbonos.Index = 6
        Me.mniAbonos.Text = "A&bonos"
        '
        'mnuExportacionReportes
        '
        Me.mnuExportacionReportes.Index = 2
        Me.mnuExportacionReportes.Text = "&Exportacion..."
        '
        'mnuNotas
        '
        Me.mnuNotas.Index = 3
        Me.mnuNotas.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAbrirPostit, Me.mnuCerrarPostit, Me.MenuItem4, Me.mnuPostitLista, Me.MenuItem6, Me.mnuPostitUsuarioCaptura})
        Me.mnuNotas.Text = "&Notas"
        '
        'mnuAbrirPostit
        '
        Me.mnuAbrirPostit.Index = 0
        Me.mnuAbrirPostit.Text = "Abrir todas mis notas"
        '
        'mnuCerrarPostit
        '
        Me.mnuCerrarPostit.Index = 1
        Me.mnuCerrarPostit.Text = "Cierra todas mis notas"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 2
        Me.MenuItem4.Text = "-"
        '
        'mnuPostitLista
        '
        Me.mnuPostitLista.Index = 3
        Me.mnuPostitLista.Text = "Tablero de notas"
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = 4
        Me.MenuItem6.Text = "-"
        '
        'mnuPostitUsuarioCaptura
        '
        Me.mnuPostitUsuarioCaptura.Index = 5
        Me.mnuPostitUsuarioCaptura.Text = "Capturar notas a usuarios..."
        '
        'mnuHerramientas
        '
        Me.mnuHerramientas.Index = 4
        Me.mnuHerramientas.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuCambioClave, Me.mniContactos, Me.mniReprogramacion, Me.mniBuroCredito, Me.mniAbonosExternos, Me.mnuReasignaCliente, Me.mnuModificaFechaDev, Me.mnuParametros})
        Me.mnuHerramientas.Text = "&Herramientas"
        '
        'mnuCambioClave
        '
        Me.mnuCambioClave.Index = 0
        Me.mnuCambioClave.Text = "&Cambio de contraseña Sigamet"
        '
        'mniContactos
        '
        Me.mniContactos.Index = 1
        Me.mniContactos.Text = "C&ontactos"
        '
        'mniReprogramacion
        '
        Me.mniReprogramacion.Index = 2
        Me.mniReprogramacion.Text = "&Reprogramación de cobranza"
        '
        'mniBuroCredito
        '
        Me.mniBuroCredito.Index = 3
        Me.mniBuroCredito.Text = "&Buró de crédito"
        '
        'mniAbonosExternos
        '
        Me.mniAbonosExternos.Index = 4
        Me.mniAbonosExternos.Text = "&Abonos externos"
        '
        'mnuReasignaCliente
        '
        Me.mnuReasignaCliente.Enabled = False
        Me.mnuReasignaCliente.Index = 5
        Me.mnuReasignaCliente.Text = "Reasignación de cliente a cargo"
        '
        'mnuModificaFechaDev
        '
        Me.mnuModificaFechaDev.Enabled = False
        Me.mnuModificaFechaDev.Index = 6
        Me.mnuModificaFechaDev.Text = "Modificación de fecha de devolución"
        '
        'mnuParametros
        '
        Me.mnuParametros.Enabled = False
        Me.mnuParametros.Index = 7
        Me.mnuParametros.Text = "&Parámetros del sistema"
        '
        'mnuVentana
        '
        Me.mnuVentana.Index = 5
        Me.mnuVentana.MdiList = True
        Me.mnuVentana.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuVenCascada, Me.mnuVenHorizontal, Me.mnuVenVertical})
        Me.mnuVentana.Text = "&Ventana"
        '
        'mnuVenCascada
        '
        Me.mnuVenCascada.Index = 0
        Me.mnuVenCascada.Text = "&Cascada"
        '
        'mnuVenHorizontal
        '
        Me.mnuVenHorizontal.Index = 1
        Me.mnuVenHorizontal.Text = "Mosaico &horizontal"
        '
        'mnuVenVertical
        '
        Me.mnuVenVertical.Index = 2
        Me.mnuVenVertical.Text = "Mosaico &vertical"
        '
        'mnuAyuda
        '
        Me.mnuAyuda.Index = 6
        Me.mnuAyuda.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAcercade})
        Me.mnuAyuda.Text = "&?"
        '
        'mnuAcercade
        '
        Me.mnuAcercade.Index = 0
        Me.mnuAcercade.Text = "&Acerca de..."
        '
        'MenuItem7
        '
        Me.MenuItem7.Index = 7
        Me.MenuItem7.Text = ""
        '
        'tbrPrincipal
        '
        Me.tbrPrincipal.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbrPrincipal.AutoSize = False
        Me.tbrPrincipal.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnMovimientos, Me.btnReportes, Me.btnClientes, Me.btnRelaciones, Me.btnNuevaNota, Me.btnQueja, Me.btnmportarPagoRef, Me.btnPagoReferenciado, Me.btnCobranzaOp, Me.btnResguardo, Me.btnEntregaNotas})
        Me.tbrPrincipal.ButtonSize = New System.Drawing.Size(85, 33)
        Me.tbrPrincipal.DropDownArrows = True
        Me.tbrPrincipal.ImageList = Me.ImageList1
        Me.tbrPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.tbrPrincipal.Name = "tbrPrincipal"
        Me.tbrPrincipal.ShowToolTips = True
        Me.tbrPrincipal.Size = New System.Drawing.Size(792, 36)
        Me.tbrPrincipal.TabIndex = 3
        '
        'btnMovimientos
        '
        Me.btnMovimientos.ImageIndex = 1
        Me.btnMovimientos.Name = "btnMovimientos"
        Me.btnMovimientos.Tag = "Movimientos"
        Me.btnMovimientos.Text = "Movimientos"
        Me.btnMovimientos.ToolTipText = "Consulta y captura de movimientos"
        '
        'btnReportes
        '
        Me.btnReportes.ImageIndex = 2
        Me.btnReportes.Name = "btnReportes"
        Me.btnReportes.Tag = "Reportes"
        Me.btnReportes.Text = "Reportes"
        Me.btnReportes.ToolTipText = "Reportes"
        '
        'btnClientes
        '
        Me.btnClientes.ImageIndex = 3
        Me.btnClientes.Name = "btnClientes"
        Me.btnClientes.Tag = "Clientes"
        Me.btnClientes.Text = "Clientes"
        Me.btnClientes.ToolTipText = "Búsqueda / consulta de clientes"
        '
        'btnRelaciones
        '
        Me.btnRelaciones.ImageIndex = 4
        Me.btnRelaciones.Name = "btnRelaciones"
        Me.btnRelaciones.Tag = "Relaciones"
        Me.btnRelaciones.Text = "Relaciones"
        Me.btnRelaciones.ToolTipText = "Relaciones de cobranza"
        '
        'btnNuevaNota
        '
        Me.btnNuevaNota.ImageIndex = 5
        Me.btnNuevaNota.Name = "btnNuevaNota"
        Me.btnNuevaNota.Tag = "NuevaNota"
        Me.btnNuevaNota.Text = "Nueva nota"
        Me.btnNuevaNota.ToolTipText = "Capturar una nueva nota personal"
        '
        'btnQueja
        '
        Me.btnQueja.ImageIndex = 8
        Me.btnQueja.Name = "btnQueja"
        Me.btnQueja.Tag = "Queja"
        Me.btnQueja.Text = "Queja"
        '
        'btnmportarPagoRef
        '
        Me.btnmportarPagoRef.ImageIndex = 7
        Me.btnmportarPagoRef.Name = "btnmportarPagoRef"
        Me.btnmportarPagoRef.Tag = "Importar"
        Me.btnmportarPagoRef.Text = "Importar"
        Me.btnmportarPagoRef.ToolTipText = "Importar archivo de transferencias bancarias"
        '
        'btnPagoReferenciado
        '
        Me.btnPagoReferenciado.ImageIndex = 6
        Me.btnPagoReferenciado.Name = "btnPagoReferenciado"
        Me.btnPagoReferenciado.Tag = "Referencia"
        Me.btnPagoReferenciado.Text = "Depósitos"
        Me.btnPagoReferenciado.ToolTipText = "Importación de archivos de pagos referenciados"
        '
        'btnCobranzaOp
        '
        Me.btnCobranzaOp.ImageIndex = 10
        Me.btnCobranzaOp.Name = "btnCobranzaOp"
        Me.btnCobranzaOp.Tag = "CobranzaOP"
        Me.btnCobranzaOp.Text = "Cobranza OP"
        Me.btnCobranzaOp.ToolTipText = "Entrega de relaciones de cobranza para operador"
        '
        'btnResguardo
        '
        Me.btnResguardo.ImageIndex = 9
        Me.btnResguardo.Name = "btnResguardo"
        Me.btnResguardo.Tag = "Resguardo"
        Me.btnResguardo.Text = "Resguardo CyC"
        '
        'btnEntregaNotas
        '
        Me.btnEntregaNotas.ImageIndex = 11
        Me.btnEntregaNotas.Name = "btnEntregaNotas"
        Me.btnEntregaNotas.Tag = "EntregaNotas"
        Me.btnEntregaNotas.Text = "Entrega "
        Me.btnEntregaNotas.ToolTipText = "Entrega de Notas"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        Me.ImageList1.Images.SetKeyName(2, "")
        Me.ImageList1.Images.SetKeyName(3, "")
        Me.ImageList1.Images.SetKeyName(4, "")
        Me.ImageList1.Images.SetKeyName(5, "")
        Me.ImageList1.Images.SetKeyName(6, "")
        Me.ImageList1.Images.SetKeyName(7, "")
        Me.ImageList1.Images.SetKeyName(8, "")
        Me.ImageList1.Images.SetKeyName(9, "")
        Me.ImageList1.Images.SetKeyName(10, "")
        Me.ImageList1.Images.SetKeyName(11, "")
        '
        'frmPrincipal
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(792, 553)
        Me.Controls.Add(Me.tbrPrincipal)
        Me.Controls.Add(Me.stbEstatus)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Menu = Me.mnuPrincipal
        Me.Name = "frmPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Módulo de Crédito y Cobranza"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.sbpUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbpUsuarioNombre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbpDepartamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbpServidor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbpBaseDeDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbpVersion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Salir()
        Me.Close()
    End Sub

    Private Sub mnuSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSalir.Click
        Salir()
    End Sub

#Region "Postits"

    Private Sub PostitUsuarioCaptura()
        Cursor = Cursors.WaitCursor
        Dim oUsuario As New SigaMetClasses.PostitUsuarioCaptura(GLOBAL_IDUsuario)
        oUsuario.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub AbreMisPostits()
        Cursor = Cursors.WaitCursor
        SigaMetClasses.AbrePostitUsuario(GLOBAL_IDUsuario, Me)
        Cursor = Cursors.Default
    End Sub

    Private Sub CierraMisPostits()
        Cursor = Cursors.WaitCursor
        Dim p As SigaMetClasses.Postit = Nothing
        For Each p In Me.OwnedForms
            p.Close()
        Next

        If Not IsNothing(p) Then
            p.Dispose()
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub TableroNotas()
        Cursor = Cursors.WaitCursor
        Dim oTablero As New SigaMetClasses.PostitLista(SigaMetClasses.Postit.enumTipoPostit.Usuario, GLOBAL_IDUsuario,
                                            Usuario:=GLOBAL_IDUsuario)
        oTablero.ShowDialog()
        Cursor = Cursors.Default

    End Sub
#End Region

    Private Sub frmPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sbpUsuario.Text = GLOBAL_IDUsuario
        sbpUsuarioNombre.Text = GLOBAL_UsuarioNombre
        sbpDepartamento.Text = GLOBAL_CelulaDescripcion
        sbpServidor.Text = GLOBAL_Servidor
        sbpBaseDeDatos.Text = GLOBAL_Database
        sbpVersion.Text = "CyC Versión: " & Application.ProductVersion.ToString

        Me.Text = Me.Text & " - " & GLOBAL_NombreEmpresa

        If Main.GLOBAL_SeguridadNT = True Then
            sbpVersion.Text &= " NT"
        End If

        DeshabilitaOpcionesMenu()

        Dim oConfig As New SigaMetClasses.cConfig(GLOBAL_Modulo, CShort(GLOBAL_Empresa), GLOBAL_Sucursal)
        Dim strURLGateway As String

        Try
            strURLGateway = CType(oConfig.Parametros("URLGateway"), String).Trim()
        Catch saex As System.ArgumentException
            If saex.Message.Contains("Index") Then
                strURLGateway = ""
            End If
        Catch ex As Exception
            MessageBox.Show("Error general", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'Dim oPanelControl As New frmPanelControl()
        'oPanelControl.Show()
        AbreMisPostits()

        If oSeguridad.TieneAcceso("ArchivoExportacion") OrElse
           oSeguridad.TieneAcceso("SituacionCartera") OrElse
           oSeguridad.TieneAcceso("NotasCredito") Then

            mnuReportesEspeciales.Enabled = True

        End If

        'Pagos referenciados, para no mostrar los botones en la toolbar si no tienen acceso
        If Not oSeguridad.TieneAcceso("MOVIMIENTOS_PAGOREF") Then
            tbrPrincipal.Buttons.Remove(btnPagoReferenciado)
        End If

        If Not oSeguridad.TieneAcceso("IMPORTACION_PAGOREF") Then
            tbrPrincipal.Buttons.Remove(btnmportarPagoRef)
        End If

        'Controles para resguardo, no mostrar si el usuario no tiene el permiso adecuado
        If Not oSeguridad.TieneAcceso("EntregaCobOperador") Then
            tbrPrincipal.Buttons.Remove(btnCobranzaOp)
        End If
        If Not oSeguridad.TieneAcceso("ListaCobranzaResg") Then
            tbrPrincipal.Buttons.Remove(btnResguardo)
        End If

        'Pagos referenciados, para no mostrar los botones en la toolbar si no tienen acceso
        If Not oSeguridad.TieneAcceso("EntregaNotasBlancas") Then
            tbrPrincipal.Buttons.Remove(btnEntregaNotas)
        End If

        'Ingresos por saldo a favor, habilitar la opción si el usuario tiene acceso
        If oSeguridad.TieneAcceso("SaldoAFavorCALIDAD") Or
            oSeguridad.TieneAcceso("SaldoAFavorUSCAP") Or
            oSeguridad.TieneAcceso("SaldoAFavorCONSULTA") Then
            mnuIngresosSaldoAFavor.Enabled = True
        End If

    End Sub

    Private Sub ImprimirFormatoChequeDevuelto(ByVal PedidoReferencia As String)
        Dim frmRep As New frmConsultaReporte(frmConsultaReporte.enumTipoReporte.ComprobanteChequeDevuelto, PedidoReferencia)
        frmRep.ShowDialog()
    End Sub

    'Entrega de Notas Blancas
    Private Sub EntregaNotasBlancas()
        Dim frmEntregaNotas As New UINotas.frmEntregaNotaBlanca(GLOBAL_UsuarioNombre)
        frmEntregaNotas.MdiParent = Me
        frmEntregaNotas.Show()
    End Sub

    Private Sub tbrPrincipal_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrPrincipal.ButtonClick
        Select Case e.Button.Tag.ToString()
            Case "Movimientos"
                ConsultaMovimientos()
            Case "Reportes"
                ConsultaReportes()
            Case "Clientes"
                ConsultaClientes()
            Case "Relaciones"
                ConsultaRelacionCobranza()
            Case "NuevaNota"
                Cursor = Cursors.WaitCursor
                Dim oPostit As New SigaMetClasses.Postit(SigaMetClasses.Postit.enumTipoPostit.Usuario, GLOBAL_IDUsuario, Usuario:=GLOBAL_IDUsuario, Contenedor:=Me)
                oPostit.Show()
                Cursor = Cursors.Default
            Case "Referencia"
                PagoReferenciado()
            Case "Importar"
                ImportacionArchivoPagoReferenciado()
            Case "Queja"
                AltaQueja()
            Case "Resguardo"
                GeneracionCobranzaResguardo()
            Case "CobranzaOP"
                EntregaCobranzaOperador()
            Case "EntregaNotas"
                EntregaNotasBlancas()
        End Select
    End Sub

#Region "Botones y menús"

    Private Sub CatalogoEmpresas()
        Dim f As Form
        For Each f In Me.MdiChildren
            If f.Name = "CatalogoEmpresa" Then
                f.Focus()
                Exit Sub
            End If
        Next
        Cursor = Cursors.WaitCursor
        Dim oCatEmpresa As New SigaMetClasses.CatalogoEmpresa()
        oCatEmpresa.MdiParent = Me
        oCatEmpresa.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub ClientesNuevos()
        Dim f As Form
        For Each f In Me.MdiChildren
            If f.Name = "frmConsultaClientesNuevos" Then
                f.Focus()
                Exit Sub
            End If
        Next
        Cursor = Cursors.WaitCursor
        Dim frmClientesNuevos As New frmConsultaClientesNuevos()
        frmClientesNuevos.MdiParent = Me
        frmClientesNuevos.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub ClientesCreditoRebasado()
        Dim f As Form
        For Each f In Me.MdiChildren
            If f.Name = "frmClientesCreditoRebasado" Then
                f.Focus()
                Exit Sub
            End If
        Next
        Cursor = Cursors.WaitCursor
        Dim frmRebasado As New frmClientesCreditoRebasado()
        frmRebasado.MdiParent = Me
        frmRebasado.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub ConsultaDatosCredito()
        If Not oSeguridad.TieneAcceso("CLIENTESCARTERA") Then
            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Main.GLOBAL_NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim f As Form
        For Each f In Me.MdiChildren
            If f.Name = "frmClientesCartera" Then
                f.Focus()
                Exit Sub
            End If
        Next

        Try
            Cursor = Cursors.WaitCursor

            If String.IsNullOrEmpty(_URLGateway) Then
                Dim oDatosCredito As New frmClientesCartera()
                oDatosCredito.MdiParent = Me
                oDatosCredito.WindowState = FormWindowState.Maximized
                oDatosCredito.Show()
            Else
                Dim oDatosCredito As New frmClientesCartera(_URLGateway)
                oDatosCredito.MdiParent = Me
                oDatosCredito.WindowState = FormWindowState.Maximized
                oDatosCredito.Show()
            End If
        Catch ex As Exception
            MessageBox.Show("Error" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub CatalogoOperador()
        If Not oSeguridad.TieneAcceso("OPERADORES") Then
            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Main.GLOBAL_NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim f As Form
        For Each f In Me.MdiChildren
            If f.Name = "frmCatOperador" Then
                f.Focus()
                Exit Sub
            End If
        Next

        Try
            Cursor = Cursors.WaitCursor

            If String.IsNullOrEmpty(_URLGateway) Then
                Dim frmCatOp As New frmCatOperador()
                frmCatOp.MdiParent = Me
                frmCatOp.Show()
            Else
                Dim frmCatOp As New frmCatOperador(_URLGateway)
                frmCatOp.MdiParent = Me
                frmCatOp.Show()
            End If
        Catch ex As Exception
            MessageBox.Show("Error" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub CatalogoTarjetaCredito()
        If Not oSeguridad.TieneAcceso("TARJETASCREDITO") Then
            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Main.GLOBAL_NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim f As Form
        For Each f In Me.MdiChildren
            If f.Name = "frmCatTarjetaCredito" Then
                f.Focus()
                Exit Sub
            End If
        Next
        Dim frmTC As New frmCatTarjetaCredito()
        frmTC.MdiParent = Me
        frmTC.Show()
    End Sub

    Private Sub CargosPendientes()
        Dim f As Form
        For Each f In Me.MdiChildren
            If f.Name = "frmCargosPendientes" Then
                f.Focus()
                Exit Sub
            End If
        Next
        Dim frmConsultaCargosPendientes As New frmCargosPendientes()
        frmConsultaCargosPendientes.MdiParent = Me
        frmConsultaCargosPendientes.Show()
    End Sub

    Private Sub ConsultaCheques()
        If Not oSeguridad.TieneAcceso("CHEQUES") Then
            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Main.GLOBAL_NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim f As Form
        For Each f In Me.MdiChildren
            If f.Name = "frmConsultaCheques" Then
                f.Focus()
                Exit Sub
            End If
        Next
        Cursor = Cursors.WaitCursor
        frmConCheques = New SigaMetClasses.ConsultaCheques(4, Main.GLOBAL_IDUsuario, GLOBAL_Corporativo, GLOBAL_Sucursal)
        AddHandler frmConCheques.ImprimirChequeDevuelto, AddressOf ImprimirFormatoChequeDevuelto
        With frmConCheques
            .MdiParent = Me
            .CargaListaCheques()
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
        Cursor = Cursors.Default
    End Sub

    Private Sub ConsultaReportes()
        If Not oSeguridad.TieneAcceso("REPORTES") Then
            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Main.GLOBAL_NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim f As Form
        For Each f In Me.MdiChildren
            If f.Name = "frmListaReporte" Then
                f.Focus()
                Exit Sub
            End If
        Next
        Cursor = Cursors.WaitCursor
        'Dim _Servidor, _BaseDatos As String
        'If Main.GLOBAL_SeguridadNT = True Then
        '    _UserID = "sigametcls"
        '    _Password = "romanos122"
        'Else
        '    _UserID = Main.GLOBAL_IDUsuario
        '    _Password = Main.GLOBAL_Password
        'End If
        'Dim frmConRep As New ReporteDinamico.frmListaReporte(4, _
        '                Main.GLOBAL_RutaReportes, _
        '                Main.GLOBAL_Servidor, _
        '                Main.GLOBAL_Database, _
        '                Main.GLOBAL_IDUsuario, _
        '                GLOBAL_connection, _
        '                True)


        Dim frmConRep As New ReporteDinamico.frmListaReporte(4,
                        Main.GLOBAL_RutaReportes,
                        Main.GLOBAL_Servidor,
                        Main.GLOBAL_Database,
                        Main.GLOBAL_IDUsuario,
                        GLOBAL_connection,
                        Main.GLOBAL_Corporativo,
                        Main.GLOBAL_Sucursal,
                        True)
        frmConRep.MdiParent = Me
        frmConRep.WindowState = FormWindowState.Maximized
        frmConRep.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub ConsultaMovimientos()
        Try
            If Trim(_URLGateway) = "" Then
                If Not oSeguridad.TieneAcceso("MOVIMIENTOS") Then
                    MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Main.GLOBAL_NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                Dim f As Form
                For Each f In Me.MdiChildren
                    If f.Name = "ConsultaMovimientos" Then
                        f.Focus()
                        Exit Sub
                    End If
                Next
                Dim frmConMov As New frmConsultaMovimientos()
                frmConMov.MdiParent = Me
                frmConMov.Modulo = GLOBAL_Modulo
                frmConMov.Show()

            Else
                If Not oSeguridad.TieneAcceso("MOVIMIENTOS") Then
                    MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Main.GLOBAL_NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                Dim f As Form
                For Each f In Me.MdiChildren
                    If f.Name = "ConsultaMovimientos" Then
                        f.Focus()
                        Exit Sub
                    End If
                Next

                Dim frmConMov As New frmConsultaMovimientos(_URLGateway, GLOBAL_Modulo, ConString)
                frmConMov.MdiParent = Me
                frmConMov.Modulo = GLOBAL_Modulo
                frmConMov.Show()
            End If
        Catch ex As Exception
            MsgBox("Error con parámetro URLGateway" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub ConsultaDocumento()
        Try
            Dim frmConsultaDoc As SigaMetClasses.ConsultaCargo
			Dim oConfig As New SigaMetClasses.cConfig(GLOBAL_Modulo, GLOBAL_Corporativo, GLOBAL_Sucursal)
			Dim strURLGateway As String = CStr(oConfig.Parametros("URLGateway")).Trim

			If Not oSeguridad.TieneAcceso("DOCUMENTOS") Then
                MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Main.GLOBAL_NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim f As Form
            For Each f In Me.MdiChildren
                If f.Name = "ConsultaCargo" Then
                    f.Focus()
                    Exit Sub
                End If
            Next

            If (String.IsNullOrEmpty(strURLGateway)) Then
                frmConsultaDoc = New SigaMetClasses.ConsultaCargo()
            Else
                frmConsultaDoc = New SigaMetClasses.ConsultaCargo(strURLGateway)
            End If

            frmConsultaDoc.MdiParent = Me
            frmConsultaDoc.Show()
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error:" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ConsultaClientes()
        Try
            Dim oConfig As SigaMetClasses.cConfig
            Dim strURLGateway As String
            Dim oBuscaCliente As SigaMetClasses.BusquedaCliente

            If Not oSeguridad.TieneAcceso("BUSQUEDACLIENTES") Then
                MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Main.GLOBAL_NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim f As Form
            For Each f In Me.MdiChildren
                If f.Name = "BusquedaCliente" Then
                    f.Focus()
                    Exit Sub
                End If
            Next

            Cursor = Cursors.WaitCursor
            Dim _ModificaDatosCliente As Boolean =
                oSeguridad.TieneAcceso("CLIENTES_MODIFICA")
            Dim _ModificaDatosCredito As Boolean =
                oSeguridad.TieneAcceso("CLIENTESCARTERA_MODIFICA")
            Dim _CambioEmpleadoNomina As Boolean =
                oSeguridad.TieneAcceso("CAMBIO_EMPLEADONOMINA")
            Dim _CambioClientePadre As Boolean =
                        oSeguridad.TieneAcceso("CAMBIO_CLIENTEPADRE")

            oConfig = New SigaMetClasses.cConfig(GLOBAL_Modulo, GLOBAL_Corporativo, GLOBAL_Sucursal)
            If oConfig.Parametros.Contains("URLGateway") Then
                strURLGateway = CStr(oConfig.Parametros("URLGateway")).Trim
            Else
                strURLGateway = String.Empty
            End If


            If (String.IsNullOrEmpty(strURLGateway)) Then
                oBuscaCliente = New SigaMetClasses.BusquedaCliente(PermiteSeleccionar:=False,
                            AutoSeleccionarRegistroUnico:=False,
                            PermiteModificarDatosCliente:=_ModificaDatosCliente,
                            PermiteModificarDatosCredito:=_ModificaDatosCredito,
                            Usuario:=Main.GLOBAL_IDUsuario,
                            PermiteCambioEmpleadoNomina:=_CambioEmpleadoNomina,
                            PermiteCambioClientePadre:=_CambioClientePadre,
                            DSCatalogos:=DSCatalogos, CadCon:=ConString, Modulo:=GLOBAL_Modulo)
            Else
                oBuscaCliente = New SigaMetClasses.BusquedaCliente(PermiteSeleccionar:=False,
                            AutoSeleccionarRegistroUnico:=False,
                            PermiteModificarDatosCliente:=_ModificaDatosCliente,
                            PermiteModificarDatosCredito:=_ModificaDatosCredito,
                            Usuario:=Main.GLOBAL_IDUsuario,
                            PermiteCambioEmpleadoNomina:=_CambioEmpleadoNomina,
                            PermiteCambioClientePadre:=_CambioClientePadre,
                            DSCatalogos:=DSCatalogos,
                            URLGateway:=strURLGateway, CadCon:=ConString, Modulo:=GLOBAL_Modulo)
            End If

            oBuscaCliente.MdiParent = Me
            oBuscaCliente.Show()
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error:" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ConsultaRelacionCobranza()
        If Not oSeguridad.TieneAcceso("RELACIONES") Then
            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Main.GLOBAL_NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim f As Form
        For Each f In Me.MdiChildren
            If f.Name = "frmRelacionCobranza" Then
                f.Focus()
                Exit Sub
            End If
        Next
        Cursor = Cursors.WaitCursor
        Dim frmRelCob As New frmRelacionCobranza(_URLGateway)
        frmRelCob.MdiParent = Me
        frmRelCob.WindowState = FormWindowState.Maximized
        frmRelCob.Show()
        Cursor = Cursors.Default

    End Sub

    Private Sub ConsultaFactura()
        Cursor = Cursors.WaitCursor

        Try
            If Not oSeguridad.TieneAcceso("FACTURAS") Then
                MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Main.GLOBAL_NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim f As Form
            For Each f In Me.MdiChildren
                If f.Name = "ConsultaFactura" Then
                    f.Focus()
                    Exit Sub
                End If
            Next

            If Trim(_URLGateway) = "" Then
                Dim oConsultaFactura As New SigaMetClasses.ConsultaFactura()
                oConsultaFactura.MdiParent = Me
                oConsultaFactura.Show()
            Else
                Dim oConsultaFactura As New SigaMetClasses.ConsultaFactura(_URLGateway, GLOBAL_Modulo, ConString)
                oConsultaFactura.MdiParent = Me
                'oConsultaFactura.Close()
                oConsultaFactura.Show()

                'MessageBox.Show("El parámetro _URLGateway esta vacio", Main.GLOBAL_NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox("Error con parámetro URLGateway" & vbCrLf & ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ConsultaEmpresa()
        If Not oSeguridad.TieneAcceso("EMPRESAS") Then
            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Main.GLOBAL_NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim f As Form
        For Each f In Me.MdiChildren
            If f.Name = "ConsultaEmpresa" Then
                f.Focus()
                Exit Sub
            End If
        Next
        Cursor = Cursors.WaitCursor
        Dim oConsultaEmpresa As New SigaMetClasses.ConsultaEmpresa(True)
        oConsultaEmpresa.MdiParent = Me
        oConsultaEmpresa.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub ConsultaMotivoCancelacion()
        If Not oSeguridad.TieneAcceso("CATMOTIVOCANCELMOV") Then
            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Main.GLOBAL_NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Dim frmCatMotivoCancelacionMovCaja As New frmCatMotivoCancelacionMovCaja()
        frmCatMotivoCancelacionMovCaja.MdiParent = Me
        frmCatMotivoCancelacionMovCaja.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub mnuConsultaFactura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConsultaFactura.Click
        ConsultaFactura()
    End Sub

    Private Sub mnuConsultaEmpresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConsultaEmpresa.Click
        ConsultaEmpresa()
    End Sub

    Private Sub mnuParametros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuParametros.Click
        Cursor = Cursors.WaitCursor
        Dim oParametros As New SigaMetClasses.ConsultaParametros(4)
        oParametros.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub mnuDatosCredito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDatosCredito.Click
        ConsultaDatosCredito()
    End Sub

    Private Sub mnuVentana_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuVentana.Popup
        If Me.MdiChildren.Length > 0 Then
            mnuVenCascada.Enabled = True
            mnuVenHorizontal.Enabled = True
            mnuVenVertical.Enabled = True
        Else
            mnuVenCascada.Enabled = False
            mnuVenHorizontal.Enabled = False
            mnuVenVertical.Enabled = False
        End If
    End Sub

    Private Sub mnuReasignaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReasignaCliente.Click
        Dim frmReasigna As New SigaMetClasses.ReasignaCargoCliente(Main.GLOBAL_IDUsuario)
        frmReasigna.ShowDialog()
    End Sub

    Private Sub mnuConsultaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConsultaCliente.Click
        ConsultaClientes()
    End Sub

    Private Sub mnuLiqDesc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLiqDesc.Click
        ConsultaLiqDesc()
    End Sub

    Private Sub mnuMovCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMovCancel.Click
        Dim frmMovCancel As New frmConsultaMovimientosCancelados()
        frmMovCancel.MdiParent = Me
        frmMovCancel.Show()
    End Sub

    Private Sub mnuCatMotivoCancelacionMovCaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCatMotivoCancelacionMovCaja.Click
        ConsultaMotivoCancelacion()
    End Sub

    Private Sub mnuRelCobranza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelCobranza.Click
        ConsultaRelacionCobranza()
    End Sub

    Private Sub mnuModificaFechaDev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuModificaFechaDev.Click
        ModificaFechaCargoCheque()
    End Sub

    Private Sub mnuCargoPendiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCargoPendiente.Click
        CargosPendientes()
    End Sub

    Private Sub mnuVenCascada_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVenCascada.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub mnuVenHorizontal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVenHorizontal.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub mnuVenVertical_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVenVertical.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub mnuConsultaReportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConsultaReportes.Click
        ConsultaReportes()
    End Sub

    Private Sub mnuCargaTransferencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frmCargaTransfer As New frmCargaArchivoTransfer()
        frmCargaTransfer.MdiParent = Me
        frmCargaTransfer.Show()
    End Sub

    Private Sub mnuCheques_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCheques.Click
        ConsultaCheques()
    End Sub

    Private Sub mnuConsultaDocumento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConsultaDocumento.Click
        ConsultaDocumento()
    End Sub

    Private Sub mnuOperador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOperador.Click
        CatalogoOperador()
    End Sub

    Private Sub mnuConsultaMovimientos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConsultaMovimientos.Click
        ConsultaMovimientos()
    End Sub

    Private Sub mnuAcercade_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAcercade.Click
        Dim frmAbout As New SigaMetClasses.AcercaDe("CyC³ {.net 3.5}", Application.ProductVersion, "Gas Metropolitano, S.A. de C.V.")
        frmAbout.ShowDialog()

    End Sub

    Private Sub mnuTarjetaCredito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTarjetaCredito.Click
        CatalogoTarjetaCredito()
    End Sub

    Private Sub mnuCambioClave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCambioClave.Click
        Dim frmCambioClave As New SigaMetClasses.CambioClave(Main.GLOBAL_IDUsuario, GLOBAL_Corporativo, GLOBAL_Sucursal)
        frmCambioClave.ShowDialog()
    End Sub

    Sub SesionIniciadaPagoReferenciado(ByVal sender As Object, ByVal e As System.EventArgs)
        SesionIniciada = DirectCast(sender, PagoReferenciado.PagoReferenciado).SesionIniciada
        ConsecutivoInicioDeSesion = CType(DirectCast(sender, PagoReferenciado.PagoReferenciado).Consecutivo, Byte)
    End Sub

    Sub SesionIniciadaAbonoExterno(ByVal sender As Object, ByVal e As System.EventArgs)
        SesionIniciada = DirectCast(sender, AbonoExterno.AbonoExterno).SesionIniciada
        ConsecutivoInicioDeSesion = CType(DirectCast(sender, AbonoExterno.AbonoExterno).Consecutivo, Byte)
    End Sub

#End Region

    Private Sub frmPrincipal_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If MessageBox.Show("¿Desea salir de la aplicación?", "Módulo de CyC", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
            e.Cancel = True
        End If

        'Guarda las notas pendientes
        sbpUsuarioNombre.Text = "Guardando las notas pendientes..."

        CierraMisPostits()

    End Sub

    Private Sub ConsultaLiqDesc()
        Dim f As Form
        For Each f In Me.MdiChildren
            If f.Name = "frmLiquidacionesDescuadradas" Then
                f.Focus()
                Exit Sub
            End If
        Next
        Dim frmConsLiqDesc As New frmLiquidacionesDescuadradas()
        frmConsLiqDesc.MdiParent = Me
        frmConsLiqDesc.Show()
    End Sub


    Private Sub ModificaFechaCargoCheque()
        Dim oModif As New SigaMetClasses.ModificaFechaCargoCheque()
        oModif.ShowDialog()
    End Sub

    Private Sub mnuClientesNuevos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClientesNuevos.Click
        ClientesNuevos()
    End Sub

    Private Sub mnuClientesCreditoRebasado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClientesCreditoRebasado.Click
        ClientesCreditoRebasado()
    End Sub

    Private Sub mnuCargoPendienteEmpleado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCargoPendienteEmpleado.Click
        Dim oCargosPendientesEmpleado As New frmCargosPendientesEmpleado()
        oCargosPendientesEmpleado.MdiParent = Me
        oCargosPendientesEmpleado.Show()

    End Sub

    Private Sub mnuCatEmpresas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCatEmpresas.Click
        CatalogoEmpresas()
    End Sub

    Private Sub mnuAbrirPostit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAbrirPostit.Click
        AbreMisPostits()

    End Sub

    Private Sub mnuCerrarPostit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCerrarPostit.Click
        CierraMisPostits()
    End Sub

    Private Sub mnuPostitLista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPostitLista.Click
        TableroNotas()
    End Sub

    Private Sub mnuPostitUsuarioCaptura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPostitUsuarioCaptura.Click
        PostitUsuarioCaptura()
    End Sub


    Private Sub mnuCatClientesDescuento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCatClientesDescuento.Click
        Cursor = Cursors.WaitCursor
        Dim f As Form
        For Each f In Me.MdiChildren
            If f.Name = "frmDescuentos" Then
                f.Focus()
                Exit Sub
            End If
        Next
        Cursor = Cursors.Default
        Dim Descuentos As New frmDescuentos(GLOBAL_connection)
        Descuentos.MdiParent = Me
        Descuentos.Show()
    End Sub

    Private Sub mnuExportacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExportacion.Click
        If oSeguridad.TieneAcceso("ArchivoExportacion") Then
            Dim f As Form
            For Each f In Me.MdiChildren
                If f.Name = "frmExportaCargos" Then
                    f.Focus()
                    Exit Sub
                End If
            Next
            Cursor = Cursors.WaitCursor
            Dim cnSigamet As New SqlClient.SqlConnection(GLOBAL_CadenaConexionExport)
            Cursor = Cursors.Default
            Dim Exportacion As New frontReportesEspeciales.frmExportaCargos(cnSigamet)
            Exportacion.MdiParent = Me
            Exportacion.Show()
            'cnSigamet.Dispose()
        Else
            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub mnuAntSaldos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAntSaldos.Click
        If oSeguridad.TieneAcceso("AntiguedadSaldos") Then
            Dim f As Form
            For Each f In Me.MdiChildren
                If f.Name = "AntiguedadSaldos" Then
                    f.Focus()
                    Exit Sub
                End If
            Next
            Cursor = Cursors.WaitCursor
            Dim cnSigamet As New SqlClient.SqlConnection(GLOBAL_CadenaConexionExport)
            Cursor = Cursors.Default
            Dim AntiguedadSaldos As New frontReportesEspeciales.AntiguedadSaldos(cnSigamet)
            AntiguedadSaldos.MdiParent = Me
            AntiguedadSaldos.Show()
            'cnSigamet.Dispose()
        Else
            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub mnuNotasCredito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNotasCredito.Click
        If oSeguridad.TieneAcceso("NotasCredito") Then
            Dim f As Form
            For Each f In Me.MdiChildren
                If f.Name = "Notas de credito" Then
                    f.Focus()
                    Exit Sub
                End If
            Next
            Cursor = Cursors.WaitCursor
            Dim cnSigamet As New SqlClient.SqlConnection(ConString)
            Cursor = Cursors.Default
            Dim notasDeCredito As New frontReportesEspeciales.notasDeCredito(cnSigamet)
            notasDeCredito.MdiParent = Me
            notasDeCredito.Show()
            'cnSigamet.Dispose()
        Else
            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub mnuArqueo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuArqueo.Click
        If oSeguridad.TieneAcceso("ArqueoCyC") Then
            Dim f As Form
            For Each f In Me.MdiChildren
                If f.Name = "FrmArqueos" Then
                    f.Focus()
                    Exit Sub
                End If
            Next
            Cursor = Cursors.WaitCursor
            Cursor = Cursors.Default
            Dim Arqueo As New FormsArqueo.FrmArqueos(GLOBAL_connection, GLOBAL_RutaReportes)
            Arqueo.WindowState = FormWindowState.Maximized
            Arqueo.MdiParent = Me
            Arqueo.Show()
        Else
            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

#Region "Transferencias bancarias"
    Private Sub PagoReferenciado()
        If Not oSeguridad.TieneAcceso("MOVIMIENTOS_PAGOREF") Then
            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Main.GLOBAL_NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim f As Form
        For Each f In Me.MdiChildren
            If f.Name = "PagoReferenciado" Then
                f.Focus()

                Exit Sub
            End If
        Next

        Cursor = Cursors.WaitCursor

        Dim pgref As New PagoReferenciado.PagoReferenciado(GLOBAL_connection, GLOBAL_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion,
            GLOBAL_IDEmpleado, GLOBAL_IDUsuario, GLOBAL_DiasAjuste, SesionIniciada, FechaInicioSesion, GLOBAL_SaldoAFavorActivo, GLOBAL_RutaReportes, GLOBAL_PGREFImporteExacto)
        pgref.MdiParent = Me

        AddHandler pgref.DataSaved, AddressOf SesionIniciadaPagoReferenciado

        pgref.WindowState = FormWindowState.Maximized
        Cursor = Cursors.Default
        pgref.Show()
    End Sub

    Private Sub ImportacionArchivoPagoReferenciado()
        If Not oSeguridad.TieneAcceso("IMPORTACION_PAGOREF") Then
            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Main.GLOBAL_NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim f As Form
        For Each f In Me.MdiChildren
            If f.Name = "frmInterface" Then
                f.Focus()
                Exit Sub
            End If
        Next

        Cursor = Cursors.WaitCursor
        Dim importacionPGRef As New DLLForm.frmInterface()
        importacionPGRef.Conexion = GLOBAL_connection
        importacionPGRef.CnnValidar = GLOBAL_connection
        importacionPGRef.MdiParent = Me
        importacionPGRef.WindowState = FormWindowState.Maximized
        Cursor = Cursors.Default
        importacionPGRef.Show()
    End Sub
    Private Sub Inhabilitar()
        Try
            Dim oConfig As New SigaMetClasses.cConfig(GLOBAL_Modulo, GLOBAL_Corporativo, GLOBAL_Sucursal)
            _URLGateway = CType(oConfig.Parametros("URLGateway"), String)
            'If _URLGateway <> "" Then
            '    mnuArqueo.Enabled = False
            '    mnuClientesCreditoRebasado.Enabled = False
            '    btnQueja.Enabled = False
            'End If
        Catch saex As System.ArgumentException
            If saex.Message.Contains("Index") Then
                _URLGateway = ""
            End If
        Catch ex As Exception
            MessageBox.Show("Error general", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Quejas"

    Private Sub AltaQueja()
        Dim f As Form
        For Each f In Me.MdiChildren
            If f.Name = "frmSeguimientoQueja" Then
                f.Focus()
                Exit Sub
            End If
        Next
        Try
            QuejasLibrary.Public.[Global].ConfiguraLibrary(SigametSeguridad.Seguridad.Conexion.ConnectionString,
                SigametSeguridad.Seguridad.Conexion, GLOBAL_IDUsuario, 1)
            f = New QuejasLibrary.frmSeguimientoQueja(Convert.ToInt32(_URLGateway))
            f.WindowState = FormWindowState.Maximized
            f.MdiParent = Me
            f.Show()
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error:" & vbCrLf & ex.Message & vbCrLf &
                ex.StackTrace, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

    Private Sub mnuEjecutivoCyC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEjecutivoCyC.Click
        If oSeguridad.TieneAcceso("CLIENTESCARTERA_MODIFICA") Then
            Dim f As Form
            For Each f In Me.MdiChildren
                If f.Name = "AsignacionEjecCyC" Then
                    f.Focus()
                    Exit Sub
                End If
            Next
            Cursor = Cursors.WaitCursor
            Cursor = Cursors.Default
            Dim _asignacionEjecCyC As New AsignacionMultiple.AsignacionEjecCyC(DSCatalogos.Tables("EjecutivosCyC"), GLOBAL_connection)
            _asignacionEjecCyC.WindowState = FormWindowState.Maximized
            _asignacionEjecCyC.MdiParent = Me
            Try
                _asignacionEjecCyC.Show()
            Catch EX As Exception
                Debug.WriteLine(EX.Message)
            End Try
        Else
            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub mniContactos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniContactos.Click
        Dim f As Form
        For Each f In Me.MdiChildren
            If f.Name = "AsignacionEjecCyC" Then
                f.Focus()
                Exit Sub
            End If
        Next
        Dim frmContactos As New CRMContactos.ListaContactos(SigaMetClasses.DataLayer.Conexion)
        frmContactos.MdiParent = Me
        frmContactos.Show()
    End Sub


    Private Sub mniAutorizacionCredito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniAutorizacionCredito.Click
        If oSeguridad.TieneAcceso("AUTCREDITO_CLIENTE") Then
            Dim f As Form
            For Each f In Me.MdiChildren
                If f.Name = "Solicitantes" Then
                    f.Focus()
                    Exit Sub
                End If
            Next
            Cursor = Cursors.WaitCursor
            Cursor = Cursors.Default
            Dim _autorizacionCyC As New AutorizacionCredito.Solicitantes(GLOBAL_IDUsuario, GLOBAL_MaxImporteCredito,
                GLOBAL_ClaveCreditoAutorizado, SigaMetClasses.DataLayer.Conexion)
            _autorizacionCyC.WindowState = FormWindowState.Maximized
            _autorizacionCyC.MdiParent = Me
            Try
                _autorizacionCyC.Show()
            Catch EX As Exception
                Debug.WriteLine(EX.Message)
            End Try
        Else
            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub mniSaldosPendientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniSaldosPendientes.Click
        If oSeguridad.TieneAcceso("SaldosPendientes") Then
            Dim f As Form
            For Each f In Me.MdiChildren
                If f.Name = "SaldosPendientesPorResponsable" Then
                    f.Focus()
                    Exit Sub
                End If
            Next
            Cursor = Cursors.WaitCursor
            Cursor = Cursors.Default
            Dim notasDeCredito As New frontReportesEspeciales.SaldosPendientesPorResponsable(New SqlClient.SqlConnection(GLOBAL_CadenaConexionExport))
            notasDeCredito.WindowState = FormWindowState.Maximized
            notasDeCredito.MdiParent = Me
            notasDeCredito.Show()
        Else
            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub mniSaldosPendientesCobro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniSaldosPendientesCobro.Click
        If oSeguridad.TieneAcceso("SaldosPendientes") Then
            Dim f As Form
            For Each f In Me.MdiChildren
                If f.Name = "SaldosPendientes" Then
                    f.Focus()
                    Exit Sub
                End If
            Next
            Cursor = Cursors.WaitCursor
            Cursor = Cursors.Default
            Dim notasDeCredito As New frontReportesEspeciales.SaldosPendientes(New SqlClient.SqlConnection(GLOBAL_CadenaConexionExport))
            notasDeCredito.WindowState = FormWindowState.Maximized
            notasDeCredito.MdiParent = Me
            notasDeCredito.Show()
        Else
            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub mniCargos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniCargos.Click
        If oSeguridad.TieneAcceso("SaldosPendientes") Then
            Dim f As Form
            For Each f In Me.MdiChildren
                If f.Name = "Cargos" Then
                    f.Focus()
                    Exit Sub
                End If
            Next
            Cursor = Cursors.WaitCursor
            Cursor = Cursors.Default
            Dim notasDeCredito As New frontReportesEspeciales.Cargos(New SqlClient.SqlConnection(GLOBAL_CadenaConexionExport))
            notasDeCredito.WindowState = FormWindowState.Maximized
            notasDeCredito.MdiParent = Me
            notasDeCredito.Show()
        Else
            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub mniAbonos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniAbonos.Click
        If oSeguridad.TieneAcceso("SaldosPendientes") Then
            Dim f As Form
            For Each f In Me.MdiChildren
                If f.Name = "Abonos" Then
                    f.Focus()
                    Exit Sub
                End If
            Next
            Cursor = Cursors.WaitCursor
            Cursor = Cursors.Default
            Dim notasDeCredito As New frontReportesEspeciales.Abonos(New SqlClient.SqlConnection(GLOBAL_CadenaConexionExport))
            notasDeCredito.WindowState = FormWindowState.Maximized
            notasDeCredito.MdiParent = Me
            notasDeCredito.Show()
        Else
            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub mniAjustes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniAjustes.Click
        If oSeguridad.TieneAcceso("AjusteDeSaldosMenoresX") Then
            Dim f As Form
            For Each f In Me.MdiChildren
                If f.Name = "AjusteSaldoMenorX" Then
                    f.Focus()
                    Exit Sub
                End If
            Next
            Cursor = Cursors.WaitCursor
            Cursor = Cursors.Default

            Dim ajuste As AjustesCartera.AjusteSaldoMenorX = New AjustesCartera.AjusteSaldoMenorX(GLOBAL_IDUsuario,
                GLOBAL_IDEmpleado, GLOBAL_CajaUsuario, FechaOperacion, FechaOperacion, ConsecutivoInicioDeSesion, SesionIniciada)
            ajuste.MdiParent = Me
            ajuste.WindowState = FormWindowState.Maximized
            ajuste.Show()
        Else
            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub mniAjustesPlanta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniAjustesPlanta.Click
        If oSeguridad.TieneAcceso("AjusteEficiencias") Then
            Dim f As Form
            For Each f In Me.MdiChildren
                If f.Name = "AjusteSaldoMenorX" Then
                    f.Focus()
                    Exit Sub
                End If
            Next
            Cursor = Cursors.WaitCursor
            Cursor = Cursors.Default

            Dim ajuste As AjustesCartera.AjusteSaldoMenorX = New AjustesCartera.AjusteSaldoMenorX(GLOBAL_IDUsuario,
                GLOBAL_IDEmpleado, GLOBAL_CajaUsuario, FechaOperacion, FechaOperacion, ConsecutivoInicioDeSesion, SesionIniciada, GLOBAL_TipoCargoEfiNeg)
            ajuste.MdiParent = Me
            ajuste.WindowState = FormWindowState.Maximized
            ajuste.Show()
        Else
            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

#Region "Documentos resguardo"
    Private Sub EntregaCobranzaOperador()
        If oSeguridad.TieneAcceso("EntregaCobOperador") Then
            Dim f As Form
            For Each f In Me.MdiChildren
                If f.Name = "RelacionesOperador" Then
                    f.Focus()
                    Exit Sub
                End If
            Next
            Cursor = Cursors.WaitCursor
            Cursor = Cursors.Default

            Dim cobOperador As ResguardoCyC.RelacionesOperador = New ResguardoCyC.RelacionesOperador(GLOBAL_IDUsuario, GLOBAL_RespResguardoOP, GLOBAL_RutaReportes)
            cobOperador.MdiParent = Me
            cobOperador.WindowState = FormWindowState.Maximized
            cobOperador.Show()
        Else
            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub GeneracionCobranzaResguardo()
        Dim cobResguardo As ResguardoCyC.ListaCobranza
        Dim strURLGateway As String

        If oSeguridad.TieneAcceso("ListaCobranzaResg") Then
            Dim f As Form
            For Each f In Me.MdiChildren
                If f.Name = "ListaCobranza" Then
                    f.Focus()
                    Exit Sub
                End If
            Next
            Cursor = Cursors.WaitCursor
            Cursor = Cursors.Default

            strURLGateway = ConsultaURLGateway()

            If (ValidaURL(strURLGateway)) Then
                'cobResguardo = New ResguardoCyC.ListaCobranza(True, GLOBAL_IDUsuario, GLOBAL_RespResguardo, GLOBAL_RespResguardoCyC, GLOBAL_RespResguardoOP, GLOBAL_RutaReportes, strURLGateway)
            Else
                cobResguardo = New ResguardoCyC.ListaCobranza(True, GLOBAL_IDUsuario, GLOBAL_RespResguardo,
                    GLOBAL_RespResguardoCyC, GLOBAL_RespResguardoOP, GLOBAL_RutaReportes)
            End If

            cobResguardo.MdiParent = Me
            cobResguardo.WindowState = FormWindowState.Maximized
            cobResguardo.Show()
        Else
            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
#End Region


    Private Sub mniRespResguardo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniRespResguardo.Click
        If oSeguridad.TieneAcceso("AsignacionResguardo") Then
            Dim f As Form
            For Each f In Me.MdiChildren
                If f.Name = "AsignacionEjecutivos" Then
                    f.Focus()
                    Exit Sub
                End If
            Next
            Cursor = Cursors.WaitCursor
            Dim ajuste As ResguardoCyC.AsignacionEjecutivos = New ResguardoCyC.AsignacionEjecutivos()
            ajuste.MdiParent = Me
            ajuste.StartPosition = FormStartPosition.CenterParent
            Cursor = Cursors.Default
            ajuste.Show()
        Else
            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub mniReprogramacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniReprogramacion.Click
        If oSeguridad.TieneAcceso("ReprogramacionCobranza") Then
            Dim frmReprogramacion As New RelacionCobranza.ReprogramacionCobranza(GLOBAL_IDUsuario)
            frmReprogramacion.ShowDialog()
        Else
            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub MenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem10.Click
        If oSeguridad.TieneAcceso("CierreCobranzaPagada") Then
            Dim cierreCobranzaPagada As New CierreCobranza.CierreDeCobranzaPagada(GLOBAL_IDUsuario, SigaMetClasses.DataLayer.Conexion)
            cierreCobranzaPagada.MdiParent = Me
            cierreCobranzaPagada.Show()
        Else
            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub mniFiliales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniFiliales.Click
        If oSeguridad.TieneAcceso("CatalogoFiliales") Then
            Dim Filiales As Filiales.frmFiliales = New Filiales.frmFiliales(oSeguridad.TieneAcceso("ControlCatalogoFiliales"), GLOBAL_IDUsuario)
            Filiales.StartPosition = FormStartPosition.CenterParent
            Filiales.ShowDialog()
        Else
            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub mniBuroCredito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniBuroCredito.Click
        If oSeguridad.TieneAcceso("BCAcceso") Then
            Dim f As Form
            For Each f In Me.MdiChildren
                If f.Name = "frmBuroCredito" Then
                    f.Focus()
                    Exit Sub
                End If
            Next
            Cursor = Cursors.WaitCursor
            BuroDeCredito.DataManager.Instance.Connection = SigaMetClasses.DataLayer.Conexion
            Dim bcControl As BuroDeCredito.frmBuroCredito = New BuroDeCredito.frmBuroCredito(GLOBAL_IDUsuario,
                GLOBAL_Password, GLOBAL_IDEmpleado)
            bcControl.MdiParent = Me
            bcControl.StartPosition = FormStartPosition.CenterParent
            Cursor = Cursors.Default
            bcControl.Show()
        Else
            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub mniAbonosExternos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniAbonosExternos.Click
        If oSeguridad.TieneAcceso("AplicacionAbonosExternos") Then
            Dim f As Form
            For Each f In Me.MdiChildren
                If f.Name = "AdministracionAbonosExternos" Then
                    f.Focus()
                    Exit Sub
                End If
            Next

            'Acceso a la pantalla de administración de abonos externos, con las siguientes funcionalidades:
            '* Carga de archivos de abonos externos
            '* Ingreso (automático o bajo demanda) a la pantalla de aplicación de abonos externos
            Dim admAbonosExternos As AdministracionAbonosExternos.AdministracionAbonosExternos =
                New AdministracionAbonosExternos.AdministracionAbonosExternos()
            'Controlador de evento para indicar cuando se cargó un archivo, a fín de mostrar automáticamente la pantalla de aplicación
            'de abonos
            AddHandler admAbonosExternos.ArchivoCargado, AddressOf AbonosExternosArchivoCargado
            'Controlador de evento para indicar cuando se debe abrir la ventana de aplicación de abonos para proceso de archivos precargados
            'en el sistema.
            AddHandler admAbonosExternos.ProcesarArchivosCargados, AddressOf AbonosExternosProcesarArchivosCargados

            admAbonosExternos.ShowDialog()
        Else
            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub AbonosExternosArchivoCargado(ByVal sender As System.Object, ByVal e As LabelEditEventArgs)
        'Controlador de evento llamado cuando se completa la carga de un archivo de abonos a la base de datos de sigamet
        'En este handler la pantalla de aplicación de abonos se invoca en modo de "archivo único", es decir, después de cargar 
        'el archivo a la base de datos, esta información se muestra en la pantalla de aplicación de abonos.
        Dim _idEmpleado As Integer = GLOBAL_EmpleadoAbonoExterno
        If _idEmpleado = 0 Then
            _idEmpleado = GLOBAL_IDEmpleado
        End If

        'Acceso a la pantalla de aplicación de abonos externos, se proporcionan los parámetros necesarios para la integración de un movimiento
        'de caja, además se proporcionan las claves del archivo que será procesado
        Dim aplAbonoExterno As New AbonoExterno.AbonoExterno(GLOBAL_connection, GLOBAL_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion,
            _idEmpleado, GLOBAL_IDUsuario, GLOBAL_DiasAjuste, SesionIniciada,
            FechaInicioSesion, GLOBAL_SaldoAFavorActivo, GLOBAL_RutaReportes, GLOBAL_PGREFImporteExacto,
            e.Item, e.Label)
        DirectCast(sender, Form).Close()

        aplAbonoExterno.MdiParent = Me

        'Eventhandler para indicar la conclusión del proceso de alta de movimiento de cobranza, después del término del proceso,
        'se actualiza la bandera de inicio de sesión del folio de corte de caja.
        AddHandler aplAbonoExterno.DataSaved, AddressOf SesionIniciadaAbonoExterno
        'Eventhancler para indicar el cierre de la pantalla de aplicación de movimientos de cobranza, en este modo de captura, se abre
        'nuevamente la pantalla de administración de archivos para permitir la carga de nuevos archivos.
        AddHandler aplAbonoExterno.ProcessEnded, AddressOf AbonosExternosSalidaProceso

        aplAbonoExterno.WindowState = FormWindowState.Maximized
        aplAbonoExterno.Show()
    End Sub

    Private Sub AbonosExternosProcesarArchivosCargados(ByVal sender As System.Object, ByVal e As EventArgs)
        'Cierre de la pantalla de carga de archivos
        DirectCast(sender, Form).Close()

        Dim _idEmpleado As Integer = GLOBAL_EmpleadoAbonoExterno
        If _idEmpleado = 0 Then
            _idEmpleado = GLOBAL_IDEmpleado
        End If

        'Acceso a la pantalla de aplicación de abonos externos, se proporcionan los parámetros necesarios para la integración de un movimiento
        'de caja
        Dim aplAbonoExterno As New AbonoExterno.AbonoExterno(GLOBAL_connection, GLOBAL_CajaUsuario, FechaOperacion, ConsecutivoInicioDeSesion,
            _idEmpleado, GLOBAL_IDUsuario, GLOBAL_DiasAjuste, SesionIniciada,
            FechaInicioSesion, GLOBAL_SaldoAFavorActivo, GLOBAL_RutaReportes, GLOBAL_PGREFImporteExacto)
        aplAbonoExterno.MdiParent = Me

        AddHandler aplAbonoExterno.DataSaved, AddressOf SesionIniciadaAbonoExterno
        aplAbonoExterno.WindowState = FormWindowState.Maximized
        aplAbonoExterno.Show()
    End Sub

    Private Sub AbonosExternosSalidaProceso(ByVal sender As System.Object, ByVal e As EventArgs)
        DirectCast(sender, Form).Close()
        mniAbonosExternos_Click(sender, e)
    End Sub

    Private Sub mnuExportacionReportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExportacionReportes.Click
        If (oSeguridad.TieneAcceso("ExportacionReportes")) Then
            Dim f As Form
            For Each f In Me.MdiChildren
                If f.Name = "frmListaReportes" Then
                    f.Focus()
                    Exit Sub
                End If
            Next
            Cursor = Cursors.WaitCursor

            Dim frmReporteExportacion As New ExportacionDirectaReportes.frmListaReportes(4, GLOBAL_Corporativo, GLOBAL_Sucursal)
            frmReporteExportacion.MdiParent = Me
            frmReporteExportacion.WindowState = FormWindowState.Maximized
            Cursor = Cursors.Default
            frmReporteExportacion.Show()
        Else
            MessageBox.Show("No tiene acceso a esta operación.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub mnuAyuda_Click(sender As System.Object, e As System.EventArgs) Handles mnuAyuda.Click

    End Sub

    Private Function ConsultaURLGateway() As String
        Dim URLGateway As String = ""
        Dim oConfig As SigaMetClasses.cConfig

        Try
            oConfig = New SigaMetClasses.cConfig(GLOBAL_Modulo, GLOBAL_Corporativo, GLOBAL_Sucursal)
            URLGateway = CStr(oConfig.Parametros("URLGateway")).Trim
        Catch ex As Exception
            URLGateway = ""
        End Try

        Return URLGateway
    End Function

    Private Function ValidaURL(URL As String) As Boolean
        Dim uriValidada As Uri

        Return Uri.TryCreate(URL, UriKind.Absolute, uriValidada)
    End Function

    ''' <summary>
    ''' Deshabilita opciones de menú si se encuentra un parámetro válido
    ''' URLGateway en la tabla 'Parametro'
    ''' </summary>
    Private Sub DeshabilitaOpcionesMenu()
        Dim strURL As String = ConsultaURLGateway()

        If (strURL > "") Then
            If (ValidaURL(strURL)) Then
                'mniAutorizacionCredito.Enabled = False
                'mnuCatClientesDescuento.Enabled = False
                'mnuEjecutivoCyC.Enabled = False
                'mniBuroCredito.Enabled = False
            End If
        End If
    End Sub

    Private Sub MnuCuentasBancariasClientes_Click(sender As Object, e As EventArgs) Handles MnuCuentasBancariasClientes.Click
        CatalogoCuentaBancaria()
    End Sub

    Private Sub CatalogoCuentaBancaria()
        Dim f As Form
        For Each f In Me.MdiChildren
            If f.Name = "frmCatCuentaBancariaCliente" Then
                f.Focus()
                Exit Sub
            End If
        Next
        Cursor = Cursors.WaitCursor
        Dim CuentaBancariaClientees As New SigaMetClasses.frmCatCuentaBancariaCliente(GLOBAL_IDUsuario)
        CuentaBancariaClientees.MdiParent = Me
        'CuentaBancariaClientees.WindowState = FormWindowState.Maximized
        Cursor = Cursors.Default
        CuentaBancariaClientees.Text = "Catálogo de cuentas bancarias del cliente"
        CuentaBancariaClientees.Show()


    End Sub

    Private Sub MenuItem11_Click(sender As Object, e As EventArgs) Handles MenuItem11.Click
        Dim f As Form
        For Each f In Me.MdiChildren
            If f.Name = "frmAltaPagoTarjeta" Then
                f.Focus()
                Exit Sub
            End If
        Next
        Cursor = Cursors.WaitCursor
        Dim CuentaBancariaClientees As New SigaMetClasses.frmAltaPagoTarjeta(GLOBAL_IDUsuario)
        CuentaBancariaClientees.MdiParent = Me
        'CuentaBancariaClientees.WindowState = FormWindowState.Maximized
        Cursor = Cursors.Default

        CuentaBancariaClientees.Show()
    End Sub

    Private Sub mnuIngresosSaldoAFavor_Click(sender As Object, e As EventArgs) Handles mnuIngresosSaldoAFavor.Click
        ConsultaIngresosSaldoAFavor()
    End Sub

    Private Sub ConsultaIngresosSaldoAFavor()
        Dim frmConsultaIngresos As SigaMetClasses.frmConsultaIngresosSaldoAFavor
        Const M_DOS_PRIVILEGIOS As String = "No puede tener los privilegios CALIDAD y USCAP al mismo tiempo."
        Dim accesoCalidad As Boolean
        Dim accesoUSCAP As Boolean
        Dim accesoConsulta As Boolean

        Try
            accesoCalidad = oSeguridad.TieneAcceso("SaldoAFavorCALIDAD")
            accesoUSCAP = oSeguridad.TieneAcceso("SaldoAFavorUSCAP")
            accesoConsulta = oSeguridad.TieneAcceso("SaldoAFavorCONSULTA")

            If (Not accesoCalidad) And (Not accesoUSCAP) And (Not accesoConsulta) Then
                MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Main.GLOBAL_NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            ElseIf (accesoCalidad And accesoUSCAP) Then
                ' No puede tener los dos privilegios 
                MessageBox.Show(M_DOS_PRIVILEGIOS, Main.GLOBAL_NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            ElseIf (accesoCalidad Or accesoUSCAP Or accesoConsulta) Then
                Dim f As Form
                For Each f In Me.MdiChildren
                    If f.Name = "frmConsultaIngresosSaldoAFavor" Then
                        f.Focus()
                        Exit Sub
                    End If
                Next

                If (accesoCalidad) Then
                    frmConsultaIngresos = New SigaMetClasses.frmConsultaIngresosSaldoAFavor("CALIDAD")
                    frmConsultaIngresos.MdiParent = Me
                    frmConsultaIngresos.Show()
                    Exit Sub
                ElseIf (accesoUSCAP) Then
                    frmConsultaIngresos = New SigaMetClasses.frmConsultaIngresosSaldoAFavor("USCAP")
                    frmConsultaIngresos.MdiParent = Me
                    frmConsultaIngresos.Show()
                    Exit Sub
                ElseIf (accesoConsulta) Then
                    frmConsultaIngresos = New SigaMetClasses.frmConsultaIngresosSaldoAFavor("CONSULTA")
                    frmConsultaIngresos.MdiParent = Me
                    frmConsultaIngresos.Show()
                    Exit Sub
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error:" & vbCrLf & ex.Message, Main.GLOBAL_NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
