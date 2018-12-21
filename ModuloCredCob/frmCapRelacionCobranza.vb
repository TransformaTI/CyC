Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq
Imports Microsoft.VisualBasic.ControlChars
Public Class frmCapRelacionCobranza
    Inherits System.Windows.Forms.Form
    Private _Empleado As Integer
    Private _TotalCobranza As Decimal
    Private _TotalDocumentos As Short
    Private _Cobranza As Integer
    Private Titulo As String = "Relación de cobranza"
    Private _TipoOperacion As SigaMetClasses.Enumeradores.enumTipoOperacionRelacionCobranza = SigaMetClasses.Enumeradores.enumTipoOperacionRelacionCobranza.Captura
    Private _TipoCargo As Byte
    Private _DatosCargados As Boolean
    Private _Columna As Integer = -1
    Private _SalidaInmediata As Boolean = False
    'Private _DiccCliente As New Dictionary(Of Integer, String)
    Private listaDireccionesEntrega As List(Of RTGMCore.DireccionEntrega)
    'Consulta por serie y folio del vale de crédito
    Private _folioDocumento As DocumentosBSR.SerieDocumento

    'Precarga de cobranza cobranza programada
    Private _tipoGestion As Byte = Nothing
    Private _tipoGestionDesc As String = Nothing

    'Tipos de cargo válidos
    Private dtTipoCargo As DataTable

    'Evitar transferencia de relaciones de cobranza entre ejecutivos
    Private _Cargado As Boolean = False

    'Controlar captura final o precaptura
    Private _tipoOperacionCaptura As Integer

    'Dirección para consultar datos en servicio web
    Private _URLGateway As String

    Public Property URLGateway() As String
        Get
            Return _URLGateway
        End Get
        Set(value As String)
            _URLGateway = value
        End Set
    End Property

    Public Sub New(TipoCaptura As Integer, Optional URLGateway As String = "")
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _URLGateway = URLGateway
        cboEmpleado.CargaDatos(True, 3)
        cboTipoCobranza.CargaDatos()
        _Cargado = True
        cboCelula.CargaDatos()
        'Controlar captura o precaptura de lista de cobranza
        _tipoOperacionCaptura = TipoCaptura
        If _tipoOperacionCaptura = TipoCapturaCobranza.Precaptura Then
            presPrecaptura()
        End If

        If Not GLOBAL_CapturaCobranzaAtrasada Then
            dtpFCobranza.MinDate = FechaOperacion.Date
        End If

        dtpFCobranza.Value = FechaOperacion.Date

        _DatosCargados = True
    End Sub

#Region " Windows Form Designer generated code "

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents colDocumento As System.Windows.Forms.ColumnHeader
    Friend WithEvents colCliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents colNombre As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvwLista As System.Windows.Forms.ListView
    Friend WithEvents colFCargo As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtPedidoReferencia As System.Windows.Forms.TextBox
    Friend WithEvents imgLista16 As System.Windows.Forms.ImageList
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents sbpEstatus As System.Windows.Forms.StatusBar
    Friend WithEvents sbpTotalImporte As System.Windows.Forms.StatusBarPanel
    Friend WithEvents sbpTotal As System.Windows.Forms.StatusBarPanel
    Friend WithEvents mnuLista As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuEliminar As System.Windows.Forms.MenuItem
    Friend WithEvents colAñoPed As System.Windows.Forms.ColumnHeader
    Friend WithEvents colCelula As System.Windows.Forms.ColumnHeader
    Friend WithEvents colPedido As System.Windows.Forms.ColumnHeader
    Friend WithEvents colRutaSuministro As System.Windows.Forms.ColumnHeader
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuConsultaDocumento As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuConsultaCliente As System.Windows.Forms.MenuItem
    Friend WithEvents colTipoCargoTipoPedido As System.Windows.Forms.ColumnHeader
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCambioGestion As System.Windows.Forms.MenuItem
    Friend WithEvents colGestionInicialDescripcion As System.Windows.Forms.ColumnHeader
    Friend WithEvents colGestionInicial As System.Windows.Forms.ColumnHeader
    Friend WithEvents cboEmpleado As SigaMetClasses.Combos.ComboEmpleado
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents colTotal As System.Windows.Forms.ColumnHeader
    Friend WithEvents colSaldo As System.Windows.Forms.ColumnHeader
    Friend WithEvents colFactura As System.Windows.Forms.ColumnHeader
    Friend WithEvents colFacturaSerie As System.Windows.Forms.ColumnHeader
    Friend WithEvents dtpFCobranza As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnSep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSep2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbBarra As System.Windows.Forms.ToolBar
    Friend WithEvents btnEliminar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnConsultaDocumento As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnConsultaCliente As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCambiarGestion As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblTituloLista As System.Windows.Forms.Label
    Friend WithEvents cboTipoCobranza As SigaMetClasses.Combos.ComboTipoCobranza
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboCelula As SigaMetClasses.Combos.ComboCelula
    Friend WithEvents lblCelula As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuConsultaFactura As System.Windows.Forms.MenuItem
    Friend WithEvents btnPrecargar As System.Windows.Forms.ToolBarButton
    Friend WithEvents chkPedidoReferencia As System.Windows.Forms.CheckBox
    Friend WithEvents colValeCredito As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnCobOperador As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCapRelacionCobranza))
        Me.lvwLista = New System.Windows.Forms.ListView()
        Me.colDocumento = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colAñoPed = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCelula = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colPedido = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colGestionInicial = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colGestionInicialDescripcion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colRutaSuministro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTipoCargoTipoPedido = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colFCargo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colNombre = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTotal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colSaldo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colFactura = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colFacturaSerie = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colValeCredito = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.mnuLista = New System.Windows.Forms.ContextMenu()
        Me.mnuEliminar = New System.Windows.Forms.MenuItem()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.mnuConsultaDocumento = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.mnuConsultaCliente = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.mnuConsultaFactura = New System.Windows.Forms.MenuItem()
        Me.MenuItem4 = New System.Windows.Forms.MenuItem()
        Me.mnuCambioGestion = New System.Windows.Forms.MenuItem()
        Me.imgLista16 = New System.Windows.Forms.ImageList(Me.components)
        Me.txtPedidoReferencia = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.sbpEstatus = New System.Windows.Forms.StatusBar()
        Me.sbpTotal = New System.Windows.Forms.StatusBarPanel()
        Me.sbpTotalImporte = New System.Windows.Forms.StatusBarPanel()
        Me.cboEmpleado = New SigaMetClasses.Combos.ComboEmpleado()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFCobranza = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbBarra = New System.Windows.Forms.ToolBar()
        Me.btnEliminar = New System.Windows.Forms.ToolBarButton()
        Me.btnSep1 = New System.Windows.Forms.ToolBarButton()
        Me.btnConsultaDocumento = New System.Windows.Forms.ToolBarButton()
        Me.btnConsultaCliente = New System.Windows.Forms.ToolBarButton()
        Me.btnSep2 = New System.Windows.Forms.ToolBarButton()
        Me.btnCambiarGestion = New System.Windows.Forms.ToolBarButton()
        Me.btnPrecargar = New System.Windows.Forms.ToolBarButton()
        Me.btnCobOperador = New System.Windows.Forms.ToolBarButton()
        Me.lblTituloLista = New System.Windows.Forms.Label()
        Me.cboTipoCobranza = New SigaMetClasses.Combos.ComboTipoCobranza()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboCelula = New SigaMetClasses.Combos.ComboCelula()
        Me.lblCelula = New System.Windows.Forms.Label()
        Me.chkPedidoReferencia = New System.Windows.Forms.CheckBox()
        CType(Me.sbpTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbpTotalImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lvwLista
        '
        Me.lvwLista.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lvwLista.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwLista.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colDocumento, Me.colAñoPed, Me.colCelula, Me.colPedido, Me.colGestionInicial, Me.colGestionInicialDescripcion, Me.colRutaSuministro, Me.colTipoCargoTipoPedido, Me.colFCargo, Me.colCliente, Me.colNombre, Me.colTotal, Me.colSaldo, Me.colFactura, Me.colFacturaSerie, Me.ColumnHeader1, Me.colValeCredito})
        Me.lvwLista.ContextMenu = Me.mnuLista
        Me.lvwLista.FullRowSelect = True
        Me.lvwLista.Location = New System.Drawing.Point(8, 224)
        Me.lvwLista.Name = "lvwLista"
        Me.lvwLista.Size = New System.Drawing.Size(992, 368)
        Me.lvwLista.SmallImageList = Me.imgLista16
        Me.lvwLista.TabIndex = 0
        Me.lvwLista.UseCompatibleStateImageBehavior = False
        Me.lvwLista.View = System.Windows.Forms.View.Details
        '
        'colDocumento
        '
        Me.colDocumento.Text = "Documento"
        Me.colDocumento.Width = 150
        '
        'colAñoPed
        '
        Me.colAñoPed.Text = ""
        Me.colAñoPed.Width = 0
        '
        'colCelula
        '
        Me.colCelula.Text = ""
        Me.colCelula.Width = 0
        '
        'colPedido
        '
        Me.colPedido.Text = ""
        Me.colPedido.Width = 0
        '
        'colGestionInicial
        '
        Me.colGestionInicial.Width = 0
        '
        'colGestionInicialDescripcion
        '
        Me.colGestionInicialDescripcion.Text = "Tipo gestión"
        Me.colGestionInicialDescripcion.Width = 70
        '
        'colRutaSuministro
        '
        Me.colRutaSuministro.Text = "Ruta"
        '
        'colTipoCargoTipoPedido
        '
        Me.colTipoCargoTipoPedido.Text = "Tipo de documento"
        Me.colTipoCargoTipoPedido.Width = 130
        '
        'colFCargo
        '
        Me.colFCargo.Text = "F.Cargo"
        Me.colFCargo.Width = 80
        '
        'colCliente
        '
        Me.colCliente.Text = "Cliente"
        Me.colCliente.Width = 90
        '
        'colNombre
        '
        Me.colNombre.Text = "Nombre"
        Me.colNombre.Width = 160
        '
        'colTotal
        '
        Me.colTotal.Text = "Total"
        Me.colTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colTotal.Width = 80
        '
        'colSaldo
        '
        Me.colSaldo.Text = "Saldo"
        Me.colSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colSaldo.Width = 80
        '
        'colFactura
        '
        Me.colFactura.Text = "Factura"
        '
        'colFacturaSerie
        '
        Me.colFacturaSerie.Text = "Serie"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = ""
        Me.ColumnHeader1.Width = 0
        '
        'colValeCredito
        '
        Me.colValeCredito.Width = 0
        '
        'mnuLista
        '
        Me.mnuLista.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuEliminar, Me.MenuItem1, Me.mnuConsultaDocumento, Me.MenuItem3, Me.mnuConsultaCliente, Me.MenuItem2, Me.mnuConsultaFactura, Me.MenuItem4, Me.mnuCambioGestion})
        '
        'mnuEliminar
        '
        Me.mnuEliminar.Index = 0
        Me.mnuEliminar.Text = "&Eliminar de la lista"
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 1
        Me.MenuItem1.Text = "-"
        '
        'mnuConsultaDocumento
        '
        Me.mnuConsultaDocumento.Index = 2
        Me.mnuConsultaDocumento.Text = "Consultar datos del documento"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 3
        Me.MenuItem3.Text = "-"
        '
        'mnuConsultaCliente
        '
        Me.mnuConsultaCliente.Index = 4
        Me.mnuConsultaCliente.Text = "Consultar datos del cliente"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 5
        Me.MenuItem2.Text = "-"
        '
        'mnuConsultaFactura
        '
        Me.mnuConsultaFactura.Index = 6
        Me.mnuConsultaFactura.Text = "Consultar datos de la factura"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 7
        Me.MenuItem4.Text = "-"
        '
        'mnuCambioGestion
        '
        Me.mnuCambioGestion.Index = 8
        Me.mnuCambioGestion.Text = "Cambiar tipo de gestión..."
        '
        'imgLista16
        '
        Me.imgLista16.ImageStream = CType(resources.GetObject("imgLista16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLista16.TransparentColor = System.Drawing.Color.Transparent
        Me.imgLista16.Images.SetKeyName(0, "")
        Me.imgLista16.Images.SetKeyName(1, "")
        Me.imgLista16.Images.SetKeyName(2, "")
        Me.imgLista16.Images.SetKeyName(3, "")
        Me.imgLista16.Images.SetKeyName(4, "")
        Me.imgLista16.Images.SetKeyName(5, "")
        Me.imgLista16.Images.SetKeyName(6, "")
        Me.imgLista16.Images.SetKeyName(7, "")
        Me.imgLista16.Images.SetKeyName(8, "")
        '
        'txtPedidoReferencia
        '
        Me.txtPedidoReferencia.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPedidoReferencia.Location = New System.Drawing.Point(104, 158)
        Me.txtPedidoReferencia.Name = "txtPedidoReferencia"
        Me.txtPedidoReferencia.Size = New System.Drawing.Size(176, 21)
        Me.txtPedidoReferencia.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 161)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Documento:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(288, 157)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 1
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(928, 40)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(928, 72)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(104, 112)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(416, 40)
        Me.txtObservaciones.TabIndex = 4
        Me.txtObservaciones.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Observaciones:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'sbpEstatus
        '
        Me.sbpEstatus.Location = New System.Drawing.Point(0, 599)
        Me.sbpEstatus.Name = "sbpEstatus"
        Me.sbpEstatus.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.sbpTotal, Me.sbpTotalImporte})
        Me.sbpEstatus.ShowPanels = True
        Me.sbpEstatus.Size = New System.Drawing.Size(1008, 22)
        Me.sbpEstatus.TabIndex = 11
        Me.sbpEstatus.Text = "StatusBar1"
        '
        'sbpTotal
        '
        Me.sbpTotal.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.sbpTotal.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.sbpTotal.Name = "sbpTotal"
        Me.sbpTotal.Width = 495
        '
        'sbpTotalImporte
        '
        Me.sbpTotalImporte.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.sbpTotalImporte.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.sbpTotalImporte.Name = "sbpTotalImporte"
        Me.sbpTotalImporte.Width = 495
        '
        'cboEmpleado
        '
        Me.cboEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmpleado.Location = New System.Drawing.Point(104, 64)
        Me.cboEmpleado.Name = "cboEmpleado"
        Me.cboEmpleado.Size = New System.Drawing.Size(416, 21)
        Me.cboEmpleado.TabIndex = 2
        Me.cboEmpleado.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Empleado:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFCobranza
        '
        Me.dtpFCobranza.Location = New System.Drawing.Point(104, 88)
        Me.dtpFCobranza.Name = "dtpFCobranza"
        Me.dtpFCobranza.Size = New System.Drawing.Size(208, 21)
        Me.dtpFCobranza.TabIndex = 3
        Me.dtpFCobranza.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "F.Cobranza:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbBarra
        '
        Me.tbBarra.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbBarra.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnEliminar, Me.btnSep1, Me.btnConsultaDocumento, Me.btnConsultaCliente, Me.btnSep2, Me.btnCambiarGestion, Me.btnPrecargar, Me.btnCobOperador})
        Me.tbBarra.ButtonSize = New System.Drawing.Size(18, 18)
        Me.tbBarra.DropDownArrows = True
        Me.tbBarra.ImageList = Me.imgLista16
        Me.tbBarra.Location = New System.Drawing.Point(0, 0)
        Me.tbBarra.Name = "tbBarra"
        Me.tbBarra.ShowToolTips = True
        Me.tbBarra.Size = New System.Drawing.Size(1008, 28)
        Me.tbBarra.TabIndex = 16
        '
        'btnEliminar
        '
        Me.btnEliminar.ImageIndex = 3
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Tag = "Eliminar"
        Me.btnEliminar.ToolTipText = "Eliminar de la lista el documento seleccionado"
        '
        'btnSep1
        '
        Me.btnSep1.Name = "btnSep1"
        Me.btnSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnConsultaDocumento
        '
        Me.btnConsultaDocumento.ImageIndex = 4
        Me.btnConsultaDocumento.Name = "btnConsultaDocumento"
        Me.btnConsultaDocumento.Tag = "ConsultarDocumento"
        Me.btnConsultaDocumento.ToolTipText = "Consultar más datos del documento seleccionado"
        '
        'btnConsultaCliente
        '
        Me.btnConsultaCliente.ImageIndex = 1
        Me.btnConsultaCliente.Name = "btnConsultaCliente"
        Me.btnConsultaCliente.Tag = "ConsultarCliente"
        Me.btnConsultaCliente.ToolTipText = "Consultar más datos del cliente seleccionado"
        '
        'btnSep2
        '
        Me.btnSep2.Name = "btnSep2"
        Me.btnSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnCambiarGestion
        '
        Me.btnCambiarGestion.ImageIndex = 5
        Me.btnCambiarGestion.Name = "btnCambiarGestion"
        Me.btnCambiarGestion.Tag = "CambiarGestion"
        Me.btnCambiarGestion.ToolTipText = "Cambia el tipo de gestión de los documentos seleccionados"
        '
        'btnPrecargar
        '
        Me.btnPrecargar.ImageIndex = 7
        Me.btnPrecargar.Name = "btnPrecargar"
        Me.btnPrecargar.Tag = "PreCargar"
        Me.btnPrecargar.ToolTipText = "Precarga la lista de documentos a gestionar para el día"
        '
        'btnCobOperador
        '
        Me.btnCobOperador.ImageIndex = 8
        Me.btnCobOperador.Name = "btnCobOperador"
        Me.btnCobOperador.Tag = "CobranzaOperador"
        Me.btnCobOperador.ToolTipText = "Lista de cobranza para ejecutivo (Créditos de operador)"
        '
        'lblTituloLista
        '
        Me.lblTituloLista.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTituloLista.BackColor = System.Drawing.Color.RoyalBlue
        Me.lblTituloLista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTituloLista.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloLista.ForeColor = System.Drawing.Color.White
        Me.lblTituloLista.Location = New System.Drawing.Point(8, 200)
        Me.lblTituloLista.Name = "lblTituloLista"
        Me.lblTituloLista.Size = New System.Drawing.Size(992, 21)
        Me.lblTituloLista.TabIndex = 17
        Me.lblTituloLista.Text = "Documentos incluidos en la relación de cobranza"
        Me.lblTituloLista.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboTipoCobranza
        '
        Me.cboTipoCobranza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoCobranza.Location = New System.Drawing.Point(104, 40)
        Me.cboTipoCobranza.Name = "cboTipoCobranza"
        Me.cboTipoCobranza.Size = New System.Drawing.Size(416, 21)
        Me.cboTipoCobranza.TabIndex = 18
        Me.cboTipoCobranza.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Tipo:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCelula
        '
        Me.cboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelula.ForeColor = System.Drawing.Color.MediumBlue
        Me.cboCelula.Location = New System.Drawing.Point(584, 64)
        Me.cboCelula.Name = "cboCelula"
        Me.cboCelula.Size = New System.Drawing.Size(121, 21)
        Me.cboCelula.TabIndex = 21
        '
        'lblCelula
        '
        Me.lblCelula.AutoSize = True
        Me.lblCelula.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCelula.Location = New System.Drawing.Point(536, 67)
        Me.lblCelula.Name = "lblCelula"
        Me.lblCelula.Size = New System.Drawing.Size(44, 13)
        Me.lblCelula.TabIndex = 22
        Me.lblCelula.Text = "Célula:"
        Me.lblCelula.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkPedidoReferencia
        '
        Me.chkPedidoReferencia.Location = New System.Drawing.Point(104, 181)
        Me.chkPedidoReferencia.Name = "chkPedidoReferencia"
        Me.chkPedidoReferencia.Size = New System.Drawing.Size(184, 16)
        Me.chkPedidoReferencia.TabIndex = 65
        Me.chkPedidoReferencia.Text = "Consulta por número de pedido"
        '
        'frmCapRelacionCobranza
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(1008, 621)
        Me.Controls.Add(Me.chkPedidoReferencia)
        Me.Controls.Add(Me.lblCelula)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboCelula)
        Me.Controls.Add(Me.cboTipoCobranza)
        Me.Controls.Add(Me.lblTituloLista)
        Me.Controls.Add(Me.tbBarra)
        Me.Controls.Add(Me.dtpFCobranza)
        Me.Controls.Add(Me.cboEmpleado)
        Me.Controls.Add(Me.sbpEstatus)
        Me.Controls.Add(Me.txtObservaciones)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.txtPedidoReferencia)
        Me.Controls.Add(Me.lvwLista)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCapRelacionCobranza"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Captura de relación de cobranza"
        CType(Me.sbpTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbpTotalImporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public Sub New(ByVal TipoCaptura As Integer, ByVal Cobranza As Integer, Optional URLGateway As String = "", Optional ByVal listaDireccionesEntrega As List(Of RTGMCore.DireccionEntrega) = Nothing)
        MyBase.New()
        InitializeComponent()
        _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionRelacionCobranza.Modificacion
        _Cobranza = Cobranza
        _URLGateway = URLGateway
        cboTipoCobranza.CargaDatos()
        cboEmpleado.CargaDatos(True, 3)
        cboCelula.CargaDatos()
        Me.listaDireccionesEntrega = listaDireccionesEntrega
        'Controlar captura o precaptura de lista de cobranza
        _tipoOperacionCaptura = TipoCaptura
        If _tipoOperacionCaptura = TipoCapturaCobranza.Precaptura Then
            presPrecaptura()
        End If

        Select Case _tipoOperacionCaptura
            Case TipoCapturaCobranza.Precaptura
                Me.Text = "Precaptura de lista de cobranza"
            Case TipoCapturaCobranza.Entrega
                _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionRelacionCobranza.Captura
                Me.Text = "Entrega de documentos de cobranza"
        End Select

        'Para evitar la captura de cobranza con días de atraso
        If Not GLOBAL_CapturaCobranzaAtrasada Then
            dtpFCobranza.MinDate = FechaOperacion.Date
        End If
        dtpFCobranza.Value = FechaOperacion.Date

        If _tipoOperacionCaptura = TipoCapturaCobranza.Captura Then
            ConsultaCobranza(_Cobranza)
        Else
            consultaPrecaptura(_Cobranza)
        End If

        'Para entrega de docuementos se inactivan todos los controles
        If _tipoOperacionCaptura = TipoCapturaCobranza.Entrega Then
            cboEmpleado.Enabled = False
            cboTipoCobranza.Enabled = False
            txtPedidoReferencia.Enabled = False
            btnBuscar.Enabled = False
        End If

        _DatosCargados = True
    End Sub

    Private Sub ConsultaCobranza(ByVal Cobranza As Integer)
        Dim strQuery As String

        strQuery = "SELECT Cobranza, TipoCobranza, FCobranza, Empleado, Observaciones FROM Cobranza Where Cobranza = " & Cobranza.ToString
        Dim da As New SqlDataAdapter(strQuery, ConString)
        Dim dt As New DataTable("Cobranza")

        Try
            da.Fill(dt)
            If dt.Rows.Count = 1 Then
                cboTipoCobranza.SelectedValue = CType(dt.Rows(0).Item("TipoCobranza"), Byte)
                _Empleado = CType(dt.Rows(0).Item("Empleado"), Integer)
                cboEmpleado.SelectedValue = _Empleado
                txtObservaciones.Text = CType(dt.Rows(0).Item("Observaciones"), String)

                ' 16/10/2018. RM - Evitar que se genere error
                If FechaOperacion > CType(dt.Rows(0).Item("FCobranza"), Date) Then
                    Throw New Exception("La fecha de operación es mayor a la fecha de la cobranza.")
                End If

                dtpFCobranza.Value = CType(dt.Rows(0).Item("FCobranza"), Date)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            da.Dispose()
            dt.Dispose()

        End Try

        Dim cn As New SqlConnection(ConString)
        Dim cmd As New SqlCommand("spCYCRelacionCobranzaConsultaDetalle", cn)
        With cmd
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 180
            .Parameters.Add("@Cobranza", SqlDbType.Int).Value = Cobranza
        End With

        Try
            cn.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            LlenaLista(dr)

        Catch ex As Exception
            MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cmd.Connection = Nothing
            cmd.Dispose()
            cn.Dispose()
        End Try
    End Sub

    Private Sub ConsultaPedido(ByVal PedidoReferencia As String)

        If PedidoReferencia.Length < 1 Then
            Exit Sub
        End If

        'Dim cn As New SqlConnection(SigaMetClasses.LeeInfoConexion(False))
        Dim cn As SqlConnection = GLOBAL_connection
        Dim cmd As New SqlCommand("spCYCRelacionCobranzaConsultaDocumento", cn)
        With cmd
            .CommandType = CommandType.StoredProcedure

            If chkPedidoReferencia.Checked Then
                cmd.Parameters.Add("@PedidoReferencia", SqlDbType.VarChar, 20).Value = PedidoReferencia
            Else
                'Dim valeCredito As Integer
                Try
                    DocumentosBSR.SerieDocumento.SeparaSerie(PedidoReferencia)
                    'valeCredito = CType(PedidoReferencia, Integer)
                Catch ex As System.OverflowException
                    MessageBox.Show("El número de documento no corresponde a un vale de crédito" & CrLf &
                                    "Verifique por favor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End Try
                'cmd.Parameters.Add("@ValeCredito", SqlDbType.Int).Value = CType(PedidoReferencia, Integer)
                If DocumentosBSR.SerieDocumento.Serie.Length > 0 Then
                    cmd.Parameters.Add("@SerieValeCredito", SqlDbType.VarChar).Value = DocumentosBSR.SerieDocumento.Serie
                End If
                cmd.Parameters.Add("@ValeCredito", SqlDbType.Int).Value = DocumentosBSR.SerieDocumento.FolioNota
            End If
        End With

        Try
            cmd.Connection = cn
            cn.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            LlenaLista(dr)

            txtPedidoReferencia.Text = String.Empty
            txtPedidoReferencia.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cmd.Connection = Nothing
            cmd.Dispose()
            'cn.Dispose()
        End Try


    End Sub

    Private Sub LlenaLista(ByVal drLista As SqlDataReader)
        'NO MODIFICAR
        'ATTE. RDC
        Dim _Agregado As Boolean

        'AVISAR SI NO SE ENCUENTRA EL DOCUMENTO

        Dim _Encontrado As Boolean = False

        Do While drLista.Read ' And _Agregado = False 'Agrego el flag de Agregado para aquellos documentos que estan en más de una factura
            Dim strMensaje As String
            Dim strPedidoReferencia As String = Trim(CType(drLista("PedidoReferencia"), String))

            'FLAG -- DOCUMENTO ENCONTRADO

            _Encontrado = True

            'MARCAR LOS DOCUMENTOS QUE DEBEN AGREGARSE
            Dim _Agregar As Boolean = True

            'Validación del Tipo de Cargo al documento que se esta agregando
            'Con esta restricción se impide que se "combinen" diferentes tipos de cargo en la lista.
            If lvwLista.Items.Count = 0 Then
                _TipoCargo = CType(drLista("TipoCargo"), Byte)
            End If

            If _TipoCargo <> CType(drLista("TipoCargo"), Byte) Then
                strMensaje = "El documento " & strPedidoReferencia & " es " &
                            " de tipo " & CType(drLista("TipoCargoTipoPedido"), String) & Chr(13) &
                            " y no puede ser capturado en esta lista."
                MessageBox.Show(strMensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            'Validación del tipo de cargo del documento que se está capturando
            'Si la tabla está vacia o nula no validar aquí
            If Not dtTipoCargo Is Nothing Then
                If Not _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionRelacionCobranza.Modificacion _
                    AndAlso Not dtTipoCargo.Rows.Contains(_TipoCargo) Then
                    strMensaje = "El documento " & strPedidoReferencia & " es " &
                                " de tipo " & CType(drLista("TipoCargoTipoPedido"), String) & Chr(13) &
                                " y no puede ser capturado en esta lista."
                    MessageBox.Show(strMensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If

            If CType(drLista("TipoCobro"), Byte) = 5 And _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionRelacionCobranza.Captura Then
                strMensaje = "El documento " & strPedidoReferencia & " es de tipo [" & Trim(CType(drLista("TipoCobroDescripcion"), String)) & "]" & Chr(13) &
                "¿Desea agregar este documento a la relación de cobranza?"
                If MessageBox.Show(strMensaje, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then
                    Exit Sub
                End If
            End If

            'No se permite la captura de documentos pagagos en la lista de cobranza. JAGD 18/02/2006
            If CType(drLista("Saldo"), Decimal) = 0 And _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionRelacionCobranza.Captura Then
                'Si el tipo de cobranza no es la de archivo muerto, se deben validar todas las condiciones para permitr la captura
                'de documentos pagados
                If Not CType(cboTipoCobranza.SelectedValue, Byte) = 14 Then
                    If GLOBAL_RCCaptDocumentoPagado Then
                        strMensaje = "El documento " & strPedidoReferencia & " ya está pagado" &
                        "¿Desea agregar este documento a la relación de cobranza?"
                        If MessageBox.Show(strMensaje, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then
                            Exit Sub
                        End If
                    Else
                        strMensaje = "El documento " & strPedidoReferencia & " ya " &
                                     "se encuentra pagado" & Chr(13) &
                                     "y no puede ser capturado en esta lista."
                        MessageBox.Show(strMensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                        'No agregar los documentos pagados
                        _Agregar = False

                        If Not _tipoOperacionCaptura = TipoCapturaCobranza.Entrega Then
                            Exit Sub
                        End If
                    End If
                End If
            End If

            'No se permite la captura de documentos con saldo en la lista de cobranza para archivo muerto
            If CType(cboTipoCobranza.SelectedValue, Byte) = 14 AndAlso CType(drLista("Saldo"), Decimal) > 0 Then
                strMensaje = "El documento " & strPedidoReferencia &
                                                     " tiene saldo pendiente" & Chr(13) &
                                                     "y no puede ser capturado en esta lista."
                MessageBox.Show(strMensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            'Validación solicitada por JLHT el 21 de mayo del 2004
            'TODO sugerir parámetro
            If CType(drLista("Cartera"), Byte) = 6 And _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionRelacionCobranza.Captura Then
                'If Main.GLOBAL_IDUsuario <> "JOALRA" Then
                If Not oSeguridad.TieneAcceso("CAPTURA_CarteraEspecial") Then
                    MessageBox.Show("Sólo el gerente de crédito puede capturar este documento.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
            'Fin de la validación

            'Validar clientes que pagan con transferencia
            If CType(IIf(IsDBNull(drLista("TipoCobroCliente")), 0, drLista("TipoCobroCliente")), Byte) = 10 Then
                Dim mensaje As New System.Text.StringBuilder()
                mensaje.Append("Este cliente paga regularmente con transferencia bancaria")
                If Not IsDBNull(drLista("ProximaGestion")) Then
                    mensaje.Append(vbCrLf)
                    mensaje.Append("y su próxima gestión es: ")
                    mensaje.Append(CType(drLista("ProximaGestion"), String))
                End If
                mensaje.Append(vbCrLf)
                mensaje.Append("¿Desea capturarlo para gestión de revisión?")
                mensaje.Append(vbCrLf)
                mensaje.Append(vbCrLf)
                mensaje.Append("Sí:")
                mensaje.Append(vbTab)
                mensaje.Append("Capturar para gestión de revisión")
                mensaje.Append(vbCrLf)
                mensaje.Append("No:")
                mensaje.Append(vbTab)
                mensaje.Append("Capturar para gestión de cobro")
                mensaje.Append(vbCrLf)
                mensaje.Append("Cancelar:")
                mensaje.Append(vbTab)
                mensaje.Append("No Capturar")
                Select Case MessageBox.Show(mensaje.ToString(), Me.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                    Case DialogResult.Yes
                        'establecer el tipo de gestión para revisión
                        _tipoGestion = 2
                        _tipoGestionDesc = "Revisión"
                    Case DialogResult.Cancel
                        Exit Sub
                End Select
            End If

            Cursor = Cursors.WaitCursor

            Dim oPedido As New ListViewItem(Trim(CType(drLista("PedidoReferencia"), String)), 0)
            oPedido.SubItems.Add(CType(drLista("AñoPed"), String))
            oPedido.SubItems.Add(CType(drLista("Celula"), String))
            oPedido.SubItems.Add(CType(drLista("Pedido"), String))

            'Carga del tipo de gestión inicial correspondiente según la precarga
            If _tipoGestion <> Nothing Then
                oPedido.SubItems.Add(_tipoGestion.ToString)
                oPedido.SubItems.Add(_tipoGestionDesc.Trim)
                _tipoGestion = Nothing
                _tipoGestionDesc = Nothing
            Else
                oPedido.SubItems.Add(CType(drLista("GestionInicial"), String))
                oPedido.SubItems.Add(CType(drLista("GestionInicialDescripcion"), String))
            End If
            oPedido.SubItems.Add(CType(drLista("RutaSuministro"), String))
            oPedido.SubItems.Add(Trim(CType(drLista("TipoCargoTipoPedido"), String)))
            If CType(drLista("TipoCobro"), Byte) <> 5 Then
                oPedido.ImageIndex = 0
            Else
                oPedido.ImageIndex = 6
            End If
            If Not IsDBNull(drLista("FCargo")) Then
                oPedido.SubItems.Add(CType(drLista("FCargo"), Date).ToShortDateString)
            Else
                oPedido.SubItems.Add("")
            End If
            oPedido.SubItems.Add(CType(drLista("Cliente"), String))
            If String.IsNullOrEmpty(_URLGateway) Then
                oPedido.SubItems.Add(Trim(CType(drLista("Nombre"), String)))
            Else
                Dim _cliente As Integer
                _cliente = CType(drLista("Cliente"), Integer)
                Dim direntrega As New RTGMCore.DireccionEntrega
                direntrega = listaDireccionesEntrega.FirstOrDefault(Function(x) x.IDDireccionEntrega = _cliente)
                If Not IsNothing(direntrega) Then
                    oPedido.SubItems.Add(direntrega.Nombre)
                Else
                    Dim _Ccliente As String
                    _Ccliente = consultaClienteCRM(_cliente)
                    oPedido.SubItems.Add(_Ccliente)
                End If
            End If
            oPedido.SubItems.Add(CType(drLista("Total"), Decimal).ToString("N"))
            oPedido.SubItems.Add(CType(drLista("Saldo"), Decimal).ToString("N"))
            If Not IsDBNull(drLista("Factura")) Then
                oPedido.SubItems.Add(CType(drLista("Factura"), String))
                oPedido.SubItems.Add(CType(drLista("SerieFactura"), String))
            Else
                oPedido.SubItems.Add("")
                oPedido.SubItems.Add("")
            End If

            'agrego el vale de crédito para validar que no se capture 2 veces
            oPedido.SubItems.Add(CType(drLista("ValeCredito"), String))

            _TotalCobranza += CType(drLista("Saldo"), Decimal)

            If _Agregar Then
                lvwLista.Items.Add(oPedido)
                oPedido.EnsureVisible()
            End If

            Estatus()

            Cursor = Cursors.Default
            _Agregado = True
        Loop

        'AVISAR SI NO SE ENCUENTRA EL DOCUMENTO ESPECIFICADO

        If Not _Encontrado Then
            If Not chkPedidoReferencia.Checked Then
                MessageBox.Show("No se encontró un documento asociado al vale de crédito especificado," & Chr(13) &
                                "intente la búsqueda por número de pedido (Pedido referencia)", "Relación de cobranza", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("No se encontró el documento especificado", "Relación de cobranza", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        End If

    End Sub

    Private Sub Estatus()
        sbpTotal.Text = lvwLista.Items.Count.ToString & " documento(s)"
        sbpTotalImporte.Text = _TotalCobranza.ToString("N")
    End Sub

    Private Function ConsultaPedidoLocal(ByVal PedidoReferencia As String) As Boolean
        'Dim lvwItem As ListViewItem
        'For Each lvwItem In lvwLista.Items
        '    If chkPedidoReferencia.Checked Then
        '        If lvwItem.Text = PedidoReferencia Then
        '            MessageBox.Show("El documento ya se capturó en la lista.", "Relación de cobranza", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '            lvwItem.EnsureVisible()
        '            txtPedidoReferencia.SelectAll()

        '            Return True
        '        End If
        '    Else
        '        If CInt(Val(lvwItem.SubItems(14).Text)) = CInt(Val(PedidoReferencia)) Then
        '            MessageBox.Show("El documento ya se capturó en la lista.", "Relación de cobranza", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '            lvwItem.EnsureVisible()
        '            txtPedidoReferencia.SelectAll()

        '            Return True
        '        End If
        '    End If
        'Next
        'Return False
        Dim lvwItem As ListViewItem
        For Each lvwItem In lvwLista.Items
            If chkPedidoReferencia.Checked Then
                If lvwItem.Text = PedidoReferencia Then
                    MessageBox.Show("El documento ya se capturó en la lista.", "Relación de cobranza", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    lvwItem.EnsureVisible()
                    txtPedidoReferencia.SelectAll()

                    Return True
                End If
            Else
                Try
                    DocumentosBSR.SerieDocumento.SeparaSerie(PedidoReferencia)
                    'valeCredito = CType(PedidoReferencia, Integer)
                Catch ex As System.OverflowException
                    MessageBox.Show("El número de documento no corresponde a un vale de crédito" & CrLf &
                                    "Verifique por favor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Function
                End Try

                'If CInt(Val(lvwItem.SubItems(14).Text)) = CInt(Val(PedidoReferencia)) Then
                If CInt(Val(lvwItem.SubItems(15).Text)) = CInt(Val(DocumentosBSR.SerieDocumento.FolioNota)) Then
                    MessageBox.Show("El documento ya se capturó en la lista.", "Relación de cobranza", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    lvwItem.EnsureVisible()
                    txtPedidoReferencia.SelectAll()

                    Return True
                End If
            End If
        Next
        Return False
    End Function

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        If Not ConsultaPedidoLocal(txtPedidoReferencia.Text.Trim) Then
            ConsultaPedido(Trim(Replace(txtPedidoReferencia.Text, "'", "")))
        End If
    End Sub

    Private Sub txtPedidoReferencia_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPedidoReferencia.Enter
        txtPedidoReferencia.BackColor = Color.LightGoldenrodYellow
        txtPedidoReferencia.SelectAll()
        Me.AcceptButton = btnBuscar
    End Sub

    Private Sub txtPedidoReferencia_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPedidoReferencia.Leave
        txtPedidoReferencia.BackColor = Color.White
        Me.AcceptButton = Nothing
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If CapturaValida() Then
            If MessageBox.Show(SigaMetClasses.M_ESTAN_CORRECTOS, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                'Verificar el saldo de los documentos capturados cuando se trate de solicitudes de cobranza de archivo muerto
                If CType(cboTipoCobranza.SelectedValue, Byte) = 14 AndAlso validacionSaldoDocumentoCobranzaArchivo() Then
                    Exit Sub
                End If

                If _tipoOperacionCaptura = TipoCapturaCobranza.Captura OrElse _tipoOperacionCaptura = TipoCapturaCobranza.Entrega Then
                    AltaModifica()
                Else
                    precapturaAltaModifica()
                End If
            End If
        End If
    End Sub

    Private Function CapturaValida() As Boolean
        If CType(cboEmpleado.SelectedValue, Integer) <> 0 Then
            If lvwLista.Items.Count > 0 Then
                Return True
            Else
                MessageBox.Show("No se han capturado documentos en la relación de cobranza.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtPedidoReferencia.Focus()
                Return False
            End If
        Else
            MessageBox.Show("Debe seleccionar el empleado.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboEmpleado.Focus()
            Return False
        End If
    End Function

    Private Sub AltaModifica()
        Cursor = Cursors.WaitCursor
        Dim itemPedido As ListViewItem
        Dim arrPedidos As New ArrayList()
        Dim iNuevoFolio As Integer
        For Each itemPedido In lvwLista.Items
            Dim oPedido As SigaMetClasses.sPedido
            oPedido.AnoPed = CType(itemPedido.SubItems(1).Text, Short)
            oPedido.Celula = CType(itemPedido.SubItems(2).Text, Byte)
            oPedido.Pedido = CType(itemPedido.SubItems(3).Text, Integer)
            oPedido.TipoCargo = CType(itemPedido.SubItems(4).Text, Byte)
            oPedido.Saldo = CType(itemPedido.SubItems(12).Text, Decimal)
            arrPedidos.Add(oPedido)
        Next
        Dim oCobranza As New SigaMetClasses.cCobranza()
        Try
            'Inserción de nueva cobranza
            If _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionRelacionCobranza.Captura Then
                If Main.requiereAutorizacionCierre(SigaMetClasses.DataLayer.Conexion, CType(cboTipoCobranza.SelectedValue, Byte)) Then 'La condición de autorización
                    'para cierre se toma del catálogo tipocobranza.
                    'Parametrización de la solicitud de autorización para el cierre de la cobranza. JAGD 18/02/2007
                    Dim status As String = "CERRADO"
                    If GLOBAL_AutCierreRelEjeCyC AndAlso
                    GLOBAL_IDEmpleado <> System.Convert.ToInt32(cboEmpleado.SelectedValue) _
                    AndAlso Not oSeguridad.TieneAcceso("TRANS_REL_COB_EJECUTIVO") Then
                        'Se eliminó la llamada a la función de alta del else, se validan los tipos de cobranza que requieren autorización, del catálogo
                        'los otros tipos de cobranza se guardarán con la llamada original JAGD 18/02/2007
                        status = "ABIERTO"
                    End If
                    iNuevoFolio = oCobranza.Alta(dtpFCobranza.Value.Date, CType(cboTipoCobranza.SelectedValue, Byte), Main.GLOBAL_IDUsuario, CType(cboEmpleado.SelectedValue, Integer), _TotalCobranza, txtObservaciones.Text, arrPedidos, status)
                Else
                    iNuevoFolio = oCobranza.Alta(dtpFCobranza.Value.Date, CType(cboTipoCobranza.SelectedValue, Byte), Main.GLOBAL_IDUsuario, CType(cboEmpleado.SelectedValue, Integer), _TotalCobranza, txtObservaciones.Text, arrPedidos)
                End If

                If _tipoOperacionCaptura = TipoCapturaCobranza.Entrega Then
                    'Marcar como entregada la lista de solicitud de cobranza
                    entregaListaCobranzaPrecaptura(iNuevoFolio)
                End If

                If MessageBox.Show("La relación fue grabada exitosamente con el folio: " & iNuevoFolio.ToString & vbCrLf &
                        "¿Desea imprimir el comprobante?", Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                    ImprimirRelacion(iNuevoFolio)
                End If
            End If

            'Modificacion de la cobranza
            If _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionRelacionCobranza.Modificacion Then
                oCobranza.Modifica(_Cobranza, dtpFCobranza.Value.Date, GLOBAL_IDUsuario, CType(cboEmpleado.SelectedValue, Integer), _TotalCobranza, txtObservaciones.Text, CType(cboTipoCobranza.SelectedValue, Byte), arrPedidos)
                If MessageBox.Show(SigaMetClasses.M_DATOS_OK & vbCrLf &
                    "¿Desea imprimir el comprobante?", Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                    ImprimirRelacion(_Cobranza)
                End If
                _SalidaInmediata = True
            End If

            Cursor = Cursors.Default

            'Inactivar el botón de aceptar al terminar la captura 27/02/2007
            Me.btnAceptar.Enabled = False

            Me.DialogResult = DialogResult.OK

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

#Region "Menu contextual"

    Private Sub mnuEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEliminar.Click
        Eliminar()
    End Sub

    Private Sub mnuConsultaDocumento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConsultaDocumento.Click
        ConsultaDocumento(Trim(lvwLista.FocusedItem.Text), CType(lvwLista.FocusedItem.SubItems(9).Text, Integer))
    End Sub

    Private Sub mnuConsultaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConsultaCliente.Click
        ConsultaCliente(CType(lvwLista.FocusedItem.SubItems(9).Text, Integer))
    End Sub

    Private Sub mnuConsultaFactura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConsultaFactura.Click
        If Trim(lvwLista.FocusedItem.SubItems(13).Text) <> "" Then
            Cursor = Cursors.WaitCursor
            Dim oConsultaFactura As New SigaMetClasses.ConsultaFactura(CType(lvwLista.FocusedItem.SubItems(13).Text, Integer), CType(lvwLista.FocusedItem.SubItems(14).Text, String), _Cliente:=listaDireccionesEntrega)
            oConsultaFactura.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub mnuCambioGestion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCambioGestion.Click
        CambiarGestion()
    End Sub

#End Region

    Private Sub ConsultaDocumento(ByVal PedidoReferencia As String, ByVal cliente As Integer)
        Cursor = Cursors.WaitCursor
        Dim direccionEntrega As RTGMCore.DireccionEntrega
        direccionEntrega = listaDireccionesEntrega.FirstOrDefault(Function(x) x.IDDireccionEntrega = cliente)
        Dim objConsultaDocumento As New SigaMetClasses.ConsultaCargo(PedidoReferencia, _ClienteRow:=direccionEntrega)
        objConsultaDocumento.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub ConsultaCliente(ByVal Cliente As Integer)
        Cursor = Cursors.WaitCursor
        Dim objConsultaCliente As New SigaMetClasses.frmConsultaCliente(Cliente, Nuevo:=0, Usuario:=GLOBAL_IDUsuario, _ClienteRow:=listaDireccionesEntrega.FirstOrDefault(Function(x) x.IDDireccionEntrega = Cliente))
        objConsultaCliente.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub CambiarGestion()
        If _tipoOperacionCaptura <> TipoCapturaCobranza.Entrega Then

            Dim bytTipo As Byte
            bytTipo = CType(lvwLista.Items(lvwLista.FocusedItem.Index).SubItems(4).Text, Byte)
            Dim frmGestion As New frmTipoGestionCobranza(bytTipo)
            If frmGestion.ShowDialog = DialogResult.OK Then
                Dim NuevoColor As Color
                If frmGestion.TipoGestionCobranza = 1 Then NuevoColor = Color.Black Else NuevoColor = Color.Red

                Dim iRenglon As Integer
                For iRenglon = 0 To lvwLista.SelectedItems.Count - 1
                    lvwLista.Items(lvwLista.SelectedItems.Item(iRenglon).Index).ForeColor = NuevoColor
                    lvwLista.Items(lvwLista.SelectedItems.Item(iRenglon).Index).SubItems(4).Text = CType(frmGestion.TipoGestionCobranza, String)
                    lvwLista.Items(lvwLista.SelectedItems.Item(iRenglon).Index).SubItems(5).Text = frmGestion.Descripcion
                Next
            End If
        Else
            mensajeOperacionInvalidaEntrega()
        End If
    End Sub

    Private Sub frmCapRelacionCobranza_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ActivaOpcionesControl(False)
        listaDireccionesEntrega = New List(Of RTGMCore.DireccionEntrega)
        chkPedidoReferencia.Checked = Not GLOBAL_BusquedaPorValeCredito
        chkPedidoReferencia.Visible = GLOBAL_BusquedaPorValeCredito

        If _DatosCargados AndAlso _Empleado <> 0 Then
            cboEmpleado.SelectedValue = _Empleado
        End If

        If _tipoOperacionCaptura = TipoCapturaCobranza.Captura AndAlso
            Not AutorizaCapturaCobranza(CType(cboTipoCobranza.SelectedValue, Byte)) Then
            btnAceptar.Enabled = False
        End If

        AddHandler cboTipoCobranza.SelectedValueChanged, AddressOf cboTipoCobranza_SelectedValueChanged
        dtTipoCargo = Main.TipoCargoCobranza(GLOBAL_connection, CType(cboTipoCobranza.SelectedValue, Byte))
    End Sub

    Private Sub lvwLista_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwLista.SelectedIndexChanged
        If lvwLista.Items.Count > 0 Then
            ActivaOpcionesControl(True)
        Else
            ActivaOpcionesControl(False)
        End If

    End Sub

    Private Sub ActivaOpcionesControl(ByVal Activar As Boolean)
        btnEliminar.Enabled = Activar
        btnConsultaCliente.Enabled = Activar
        btnConsultaDocumento.Enabled = Activar
        btnCambiarGestion.Enabled = Activar

        mnuEliminar.Enabled = Activar
        mnuCambioGestion.Enabled = Activar
        mnuConsultaDocumento.Enabled = Activar
        mnuConsultaCliente.Enabled = Activar
    End Sub

    Private Sub tbBarra_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbBarra.ButtonClick
        Select Case e.Button.Tag.ToString()
            Case "Eliminar"
                Eliminar()
            Case "ConsultarDocumento"
                ConsultaDocumento(Trim(lvwLista.FocusedItem.Text), CType(lvwLista.FocusedItem.SubItems(9).Text, Integer))
            Case "ConsultarCliente"
                ConsultaCliente(CType(lvwLista.FocusedItem.SubItems(9).Text, Integer))
            Case "CambiarGestion"
                CambiarGestion()
            Case "PreCargar"
                PreCarga2()
            Case "CobranzaOperador"
                PreCargaCobranzaOperador()
                'PreCargar(dtpFCobranza.Value, CType(cboCelula.Celula, Byte), _
                '    CType(cboEmpleado.SelectedValue, Integer), CType(cboTipoCobranza.SelectedValue, Byte))
        End Select
    End Sub

    Private Sub PreCarga2()
        If _tipoOperacionCaptura <> TipoCapturaCobranza.Entrega Then
            'Dim programacioncobranza As New _
            'ProgramacionCobranza.ConsultaProgramaCobranza(Main.DSCatalogos.Tables("Celulas"),
            '    DirectCast(cboEmpleado.DataSource, DataTable),
            '    Main.DSCatalogos.Tables("EjecutivosCyC"),
            '    CType(cboEmpleado.SelectedValue, Integer),
            '    GLOBAL_connection,
            '    GLOBAL_CargaClientesSinDatosPrg,
            '     _URLGateway)

            'programacioncobranza.PermitirTodosEjecutivos = oSeguridad.TieneAcceso("INTEGRAR_SOL_COB")

            'If programacioncobranza.ShowDialog() = DialogResult.OK Then
            '    cargaAutomatica(programacioncobranza.ListaDocumentos)
            'End If
        Else
            mensajeOperacionInvalidaEntrega()
        End If
    End Sub

    Private Sub PreCargaCobranzaOperador()
        If _tipoOperacionCaptura <> TipoCapturaCobranza.Entrega Then
            Dim programacioncobranza As New _
                ProgramacionCobranza.ConsultaCobranzaEjecutivoOperador(Main.DSCatalogos.Tables("Celulas"),
                Main.DSCatalogos.Tables("Rutas"),
                DirectCast(cboEmpleado.DataSource, DataTable),
                CType(cboEmpleado.SelectedValue, Integer),
                GLOBAL_connection, GLOBAL_Modulo, ConString, _URLGateway, _listaDireccionesEntrega:=listaDireccionesEntrega)

            If programacioncobranza.ShowDialog() = DialogResult.OK Then
                cargarDiccionario(programacioncobranza.ListaClientes)
                cargaAutomatica(programacioncobranza.ListaDocumentos)
            End If
        Else
            mensajeOperacionInvalidaEntrega()
        End If
    End Sub

    Private Sub cargarDiccionario(ByVal cliente As List(Of RTGMCore.DireccionEntrega))

        For Each entrega As RTGMCore.DireccionEntrega In cliente
            Dim direntrega As New RTGMCore.DireccionEntrega
            direntrega = listaDireccionesEntrega.FirstOrDefault(Function(x) x.IDDireccionEntrega = entrega.IDDireccionEntrega)
            If IsNothing(direntrega) Then
                listaDireccionesEntrega.Add(entrega)
            End If
        Next
    End Sub

    Private Sub cargaAutomatica(ByVal SourceTable As DataTable)
        chkPedidoReferencia.Checked = True
        Dim dr As DataRow
        For Each dr In SourceTable.Rows
            txtPedidoReferencia.Text = CType(dr("Documento"), String)
            _tipoGestion = CType(dr("KTG"), Byte)
            _tipoGestionDesc = CType(dr("Tipo Gestión"), String)
            btnBuscar_Click(Nothing, Nothing)
        Next
        _tipoGestion = Nothing
        _tipoGestionDesc = Nothing
    End Sub


    Private Sub PreCargar(ByVal fecha As Date, ByVal celula As Integer, ByVal empleado As Integer, ByVal tipoCobranza As Byte)

        Static fechaCob As Date
        Static empleadoCob As Integer

        If lvwLista.Items.Count > 0 And empleadoCob <> empleado And fecha = fechaCob And empleado > 0 Then

            If MessageBox.Show("¿Desea acumular los documentos " & CrLf &
                    "del empleado no.  " & CStr(empleadoCob) & " al empleado actual?",
                     Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                lvwLista.Items.Clear()
                lvwLista.Items.Clear()
                _TotalCobranza = 0
                Estatus()
            End If

        Else

            If lvwLista.Items.Count > 0 Then

                If MessageBox.Show("Esto borrará la lista actual " & CrLf & "¿Desea continuar?",
                        Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    lvwLista.Items.Clear()
                    _TotalCobranza = 0
                    Estatus()
                Else
                    Exit Sub
                End If

            End If

        End If

        fechaCob = fecha
        empleadoCob = empleado

        'Dim cn As New SqlConnection(SigaMetClasses.LeeInfoConexion(False))
        Dim cn As SqlConnection = GLOBAL_connection
        Dim cmdSelect As New SqlCommand()
        cmdSelect.CommandText = "spCyCObtencionProgramacionDeCobranza"
        cmdSelect.CommandType = CommandType.StoredProcedure
        cmdSelect.Connection = cn
        cmdSelect.Parameters.Clear()
        cmdSelect.Parameters.Add("@fechaInicio", SqlDbType.DateTime).Value = fecha
        If CInt(empleado) > 0 Then
            cmdSelect.Parameters.Add("@codigoEmpleado", SqlDbType.Int).Value = empleado
        End If
        If CInt(celula) > 0 Then
            cmdSelect.Parameters.Add("@celula", SqlDbType.Int).Value = celula
        End If
        If CInt(tipoCobranza) = 3 Then
            cmdSelect.Parameters.Add("@SoloCyC", SqlDbType.Bit).Value = 0
        End If
        Try
            cn.Open()
            Dim drPC As SqlDataReader = cmdSelect.ExecuteReader
            LlenaLista(drPC)
        Catch ex As SqlException
            MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cmdSelect.Connection = Nothing
            cmdSelect.Dispose()
            'cn.Dispose()
        End Try

    End Sub

    Private Sub Eliminar()
        If _tipoOperacionCaptura <> TipoCapturaCobranza.Entrega Then

            _TotalCobranza -= CType(lvwLista.FocusedItem.SubItems(12).Text, Decimal)
            lvwLista.Items.Remove(lvwLista.FocusedItem)
            Estatus()
            If lvwLista.Items.Count > 0 Then
                ActivaOpcionesControl(True)
            Else
                _TipoCargo = 0
                ActivaOpcionesControl(False)
            End If
        Else
            mensajeOperacionInvalidaEntrega()
        End If
    End Sub

    Private Sub cboTipoCobranza_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles cboTipoCobranza.SelectedValueChanged
        'Tipos válidos+
        dtTipoCargo = Main.TipoCargoCobranza(GLOBAL_connection, CType(cboTipoCobranza.SelectedValue, Byte))

        If _DatosCargados Then
            If _tipoOperacionCaptura = TipoCapturaCobranza.Captura AndAlso
            Not AutorizaCapturaCobranza(CType(cboTipoCobranza.SelectedValue, Byte)) Then
                MessageBox.Show("No tiene permiso para capturar este tipo de cobranza",
                    Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                btnAceptar.Enabled = False
                Exit Sub
            Else
                btnAceptar.Enabled = True
            End If

            If _tipoOperacionCaptura = TipoCapturaCobranza.Captura Then
                If CType(cboTipoCobranza.SelectedValue, Byte) = 10 AndAlso Not oSeguridad.TieneAcceso("CIERRE_REL_COB_EJEC_ADMIN") Then
                    cboTipoCobranza.SelectedValue = 1
                    MessageBox.Show("No tiene permiso para capturar este tipo de cobranza",
                        Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If

            'Se habilitó el combo de célula para permitir filtrar los registros por célula en cobranza de operador
            If CType(cboTipoCobranza.SelectedValue, Byte) = 3 Or CType(cboTipoCobranza.SelectedValue, Byte) = 1 Then
                cboCelula.Visible = True

                lblCelula.Visible = True
                If CType(cboTipoCobranza.SelectedValue, Byte) = 3 Then
                    cboEmpleado.CargaDatosOperador(True, CType(cboCelula.SelectedValue, Byte))
                Else
                    cboEmpleado.CargaDatos(True, 3)
                End If
            Else
                cboCelula.Visible = False
                lblCelula.Visible = False

                CargaComboEmpleado()

                If _Empleado <> 0 Then cboEmpleado.SelectedValue = _Empleado
            End If
        End If
    End Sub

    Private Sub cboCelula_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCelula.SelectedIndexChanged
        If _DatosCargados Then
            If CType(cboTipoCobranza.SelectedValue, Byte) = 3 Then
                cboEmpleado.CargaDatosOperador(True, CType(cboCelula.Celula, Byte))
            End If
        End If
    End Sub
    'texis sortOrder cast
    Private Sub lvwLista_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvwLista.ColumnClick
        If e.Column <> _Columna Then
            _Columna = e.Column
            lvwLista.Sorting = Windows.Forms.SortOrder.Ascending
        Else
            If lvwLista.Sorting = SortOrder.Ascending Then
                lvwLista.Sorting = Windows.Forms.SortOrder.Descending
            Else
                lvwLista.Sorting = Windows.Forms.SortOrder.Ascending
            End If
        End If
        lvwLista.Sort()

        Select Case e.Column
            Case 6, 9, 11, 12
                lvwLista.ListViewItemSorter = New SigaMetClasses.ListViewComparador(e.Column, lvwLista.Sorting, SigaMetClasses.ListViewComparador.enumTipoDatoComparacion.Numerico)
            Case 8
                lvwLista.ListViewItemSorter = New SigaMetClasses.ListViewComparador(e.Column, lvwLista.Sorting, SigaMetClasses.ListViewComparador.enumTipoDatoComparacion.Fecha)
            Case Else
                lvwLista.ListViewItemSorter = New SigaMetClasses.ListViewComparador(e.Column, lvwLista.Sorting)
        End Select

    End Sub

    Private Sub frmCapRelacionCobranza_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not _SalidaInmediata Then
            If MessageBox.Show("¿Desea salir de la captura?", Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                e.Cancel = True
            End If
        End If

    End Sub

    Private Sub cboEmpleado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEmpleado.SelectedIndexChanged
        'Evento que controlará el  cambio del empleado
        'Debug.WriteLine("cambio" & cboEmpleado.SelectedValue.ToString)
        'Try
        '    Dim Empleado As Integer = System.Convert.ToInt32(cboEmpleado.SelectedValue())
        '    If Puesto(Empleado) Then
        '        MessageBox.Show("Es ejecutivo de crédito")
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
    End Sub

    'Private Function Puesto(ByVal Contrato As Integer) As Boolean
    '    Dim Ejecutivo As Integer
    '    Dim cnn As New SqlConnection(ConString)
    '    Dim cmd As New SqlCommand("sp_cycconsultapuesto", cnn)
    '    cmd.CommandType = CommandType.StoredProcedure
    '    Dim parCte As New SqlParameter("@Empleado", SqlDbType.Int)
    '    parCte.Value = Contrato
    '    cmd.Parameters.Add(parCte)
    '    Try
    '        cnn.Open()
    '        Ejecutivo = System.Convert.ToInt32(cmd.ExecuteScalar())
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    Finally
    '        cnn.Close()
    '    End Try



    '    If Ejecutivo = 0 Then
    '        Return False
    '    Else
    '        Return True
    '    End If
    'End Function

    Private Sub mnuPrecarga_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    'Impresión de la relación de cobranza
    Private Sub ImprimirRelacion(ByVal Cobranza As Integer)
        Cursor = Cursors.WaitCursor
        Dim frmReporte As New frmConsultaReporte(frmConsultaReporte.enumTipoReporte.RelacionCobranza, 0, FechaOperacion.Date, Cobranza, 0)
        frmReporte.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub txtPedidoReferencia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPedidoReferencia.TextChanged

    End Sub

    'Private Sub cboTipoCobranza_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoCobranza.SelectedIndexChanged




    '    'If _Cargado = True And Not oSeguridad.TieneAcceso("TRANS_REL_COB_EJECUTIVO") Then
    '    '    Dim valor As Integer = System.Convert.ToInt32(cboTipoCobranza.SelectedValue())
    '    '    If valor = 2 Or valor = 4 Then
    '    '        MessageBox.Show("Usted no puede realizar ésta operación", "CyC", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '    '        txtPedidoReferencia.Text = ""
    '    '        txtPedidoReferencia.Enabled = False
    '    '    Else
    '    '        txtPedidoReferencia.Enabled = True
    '    '    End If
    '    'End If
    'End Sub

    Private Sub CargaComboEmpleado()
        Select Case CType(cboTipoCobranza.SelectedValue, Integer)
            Case 1, 11
                cboEmpleado.CargaDatos(True, 3)
            Case 2, 7, 10, 12
                cboEmpleado.CargaDatos(True, 4) 'Cobranza para ejecutivo (tipo 7 con cierre de cobranza, si aplica)
            Case 4, 9, 13
                cboEmpleado.CargaDatos(True, 6) 'Cobranza para ventanilla de cyc y/o control de documentos, mientras se define
                'un puesto específico
            Case 8
                cboEmpleado.CargaDatos(True, 14) 'Cobranza para gestión judicial
            Case 14
                cboEmpleado.CargaDatos(True, 16) 'Documentos pagados para archivo muerto
        End Select
    End Sub


#Region "Precaptura de listas de cobranza"

    Private Sub presPrecaptura()
        Me.Text = "Precaptura de lista de cobranza"
        lblTituloLista.Text = "Documentos incluidos en la solicitud de cobranza"
        lblTituloLista.BackColor = Color.Maroon
    End Sub

    '*
    Private Sub precapturaAltaModifica()
        Cursor = Cursors.WaitCursor
        Dim itemPedido As ListViewItem
        Dim precaptura As New RelacionCobranza.PreCapturaCobranza(SigaMetClasses.DataLayer.Conexion)
        Dim iNuevoFolio As Integer
        For Each itemPedido In lvwLista.Items
            Dim newRow As DataRow = precaptura.dtListaDocumentos.NewRow()
            newRow("Celula") = CType(itemPedido.SubItems(2).Text, Short)
            newRow("AñoPed") = CType(itemPedido.SubItems(1).Text, Short)
            newRow("Pedido") = CType(itemPedido.SubItems(3).Text, Integer)
            newRow("Gestion") = CType(itemPedido.SubItems(4).Text, Byte)
            precaptura.dtListaDocumentos.Rows.Add(newRow)
        Next
        Try
            precaptura.CancelacionSolicitudCobranza(_Cobranza, 2, GLOBAL_IDUsuario)
            iNuevoFolio = precaptura.AltaMovimiento(dtpFCobranza.Value.Date, Main.GLOBAL_IDUsuario,
                CType(cboEmpleado.SelectedValue, Integer), _TotalCobranza,
                txtObservaciones.Text, CType(cboTipoCobranza.SelectedValue, Byte),
                precaptura.dtListaDocumentos)
            Cursor = Cursors.Default
            If MessageBox.Show("La solicitud de relación fue grabada exitosamente con el folio: " & iNuevoFolio.ToString & vbCrLf &
            "¿Desea imprimir el comprobante?", Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                ImprimirSolicitud(iNuevoFolio)
            End If
            'Inactivar el botón de aceptar al terminar la captura 27/02/2007
            Me.btnAceptar.Enabled = False
            Me.DialogResult = DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub consultaPrecaptura(ByVal SolicitudCobranza As Integer)
        Dim strQuery As String

        strQuery = "SELECT Cobranza, TipoCobranza, FCobranza, Empleado, Observaciones FROM SolicitudCobranza Where SolicitudCobranza = " & SolicitudCobranza.ToString
        Dim da As New SqlDataAdapter(strQuery, ConString)
        Dim dt As New DataTable("Cobranza")

        Try
            da.Fill(dt)
            If dt.Rows.Count = 1 Then
                cboTipoCobranza.SelectedValue = CType(dt.Rows(0).Item("TipoCobranza"), Byte)
                CargaComboEmpleado()
                _Empleado = CType(dt.Rows(0).Item("Empleado"), Integer)
                cboEmpleado.SelectedValue = _Empleado
                'Se desplegará por defecto el valor del día cuando sea menor que la fecha mínima
                If dtpFCobranza.MinDate > CType(dt.Rows(0).Item("FCobranza"), Date) Then
                    dtpFCobranza.Value = Date.Today
                Else
                    dtpFCobranza.Value = CType(dt.Rows(0).Item("FCobranza"), Date)
                End If
                txtObservaciones.Text = CType(dt.Rows(0).Item("Observaciones"), String)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            da.Dispose()
            dt.Dispose()

        End Try

        Dim cn As New SqlConnection(ConString)
        Dim cmd As New SqlCommand("spCYCSolicitudCobranzaConsultaDetalle", cn)
        With cmd
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 180
            .Parameters.Add("@Cobranza", SqlDbType.Int).Value = SolicitudCobranza
        End With

        Try
            cn.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            LlenaLista(dr)

            If (Not String.IsNullOrEmpty(URLGateway)) Then
                recargaPrecapturados()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cmd.Connection = Nothing
            cmd.Dispose()
            cn.Dispose()
        End Try
    End Sub

    Private Sub entregaListaCobranzaPrecaptura(ByVal NuevaCobranza As Integer)
        Dim precaptura As New RelacionCobranza.PreCapturaCobranza(SigaMetClasses.DataLayer.Conexion)
        Try
            precaptura.ActualizacionSolicitudCobranza(_Cobranza, NuevaCobranza, GLOBAL_IDUsuario)
        Catch ex As Exception
            MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub mensajeOperacionInvalidaEntrega()
        MessageBox.Show("Esta operacion no está disponible", "Entrega de documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    'Impresión de la relación de cobranza
    Private Sub ImprimirSolicitud(ByVal Cobranza As Integer)
        Cursor = Cursors.WaitCursor
        Dim frmReporte As New frmConsultaReporte(frmConsultaReporte.enumTipoReporte.SolicitudCobranza, 0, FechaOperacion.Date, Cobranza, 0)
        frmReporte.ShowDialog()
        Cursor = Cursors.Default
    End Sub
#End Region

    Private Function validacionSaldoDocumentoCobranzaArchivo() As Boolean
        Dim retVal As Boolean = False
        Dim lvItem As ListViewItem
        For Each lvItem In lvwLista.Items
            If CType(lvItem.SubItems(12).Text, Decimal) > 0 Then
                lvItem.Selected = True
                MessageBox.Show("El documento " & lvItem.SubItems(0).Text & " tiene saldo pendiente," & vbCrLf &
                    "retírelo de la lista para continuar.", "Cobranza", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                retVal = True
                Exit For
            End If
        Next
        Return retVal
    End Function

    Private Function consultaClienteCRM(ByVal cliente As Integer) As String
        Dim Gateway As RTGMGateway.RTGMGateway
        Dim Solicitud As RTGMGateway.SolicitudGateway
        Dim DireccionEntrega As New RTGMCore.DireccionEntrega
        Dim Nombre As String = ""

        Try
            If (Not String.IsNullOrEmpty(URLGateway)) Then
                If Not listaDireccionesEntrega.Exists(Function(x) x.IDDireccionEntrega = cliente) Then
                    Gateway = New RTGMGateway.RTGMGateway(GLOBAL_Modulo, ConString)
                    Gateway.URLServicio = URLGateway
                    Solicitud = New RTGMGateway.SolicitudGateway() With {
                        .IDCliente = cliente}

                    DireccionEntrega = Gateway.buscarDireccionEntrega(Solicitud)
                Else
                    DireccionEntrega = listaDireccionesEntrega.FirstOrDefault(Function(x) x.IDDireccionEntrega = cliente)
                End If


                If DireccionEntrega.Nombre IsNot Nothing Then
                    If Not listaDireccionesEntrega.Exists(Function(x) x.IDDireccionEntrega = cliente) Then
                        listaDireccionesEntrega.Add(DireccionEntrega)
                    End If
                    Nombre = DireccionEntrega.Nombre.Trim
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return Nombre
    End Function

    Private Sub recargaPrecapturados()
        ' Indice de la columna 'Cliente' en lvwLista
        Dim idxCliente As Integer = Me.colCliente.Index
        ' Indice de la columna 'Nombre' en lvwLista
        Dim idxNombre As Integer = Me.colNombre.Index
        Dim cliente As Integer

        Try
            If Not IsNothing(lvwLista) Then
                If (lvwLista.Items.Count > 0) Then

                    For Each item As ListViewItem In lvwLista.Items
                        cliente = Convert.ToInt32(item.SubItems(idxCliente).Text)
                        If listaDireccionesEntrega.Count > 0 Then
                            Dim direntrega As New RTGMCore.DireccionEntrega
                            direntrega = listaDireccionesEntrega.FirstOrDefault(Function(x) x.IDDireccionEntrega = cliente)
                            If Not IsNothing(direntrega) Then
                                item.SubItems(idxNombre).Text = direntrega.Nombre
                            Else
                                Dim _Ccliente As String
                                _Ccliente = consultaClienteCRM(cliente)
                                item.SubItems(idxNombre).Text = _Ccliente
                            End If
                        Else
                            item.SubItems(idxNombre).Text = consultaClienteCRM(cliente)
                        End If
                    Next item
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error: " & vbCrLf & ex.Message, Me.Titulo,
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class