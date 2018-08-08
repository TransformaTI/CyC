Imports System.Data.SqlClient
Imports ExportData
Imports CobranzaExterna
Imports RTGMGateway

Public Class frmRelacionCobranza
    Inherits System.Windows.Forms.Form
    Private _Cobranza As Integer
    Private _TipoCobranza As Integer
    Private _Empleado As Integer
    Private _UsuarioCaptura As String
    Private _Status As String
    Private _dsCobranza As DataSet
    Private Titulo As String = "Relaciones de cobranza"
    Private _PedidoReferencia As String
    Private _RelacionEjecutivo As Boolean
    Private _UrlGateway As String
    Private CLIENTETEMP As Integer

    'Captura de solicitudes de cobranza
    Private _tipoOperacionCobranza As Integer = TipoCapturaCobranza.Captura

#Region " Windows Form Designer generated code "

    Public Sub New(URLGateway As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        _UrlGateway = URLGateway


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
    Friend WithEvents tbrBarra As System.Windows.Forms.ToolBar
    Friend WithEvents tbbCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents imgLista16 As System.Windows.Forms.ImageList
    Friend WithEvents tbbCapturar As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbCancelar As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbSep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpDatos As System.Windows.Forms.TabPage
    Friend WithEvents dtpFCobranza As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Estilo1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colCobranza As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFCobranza As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colEmpleado As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents lblObservaciones As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblFActualizacion As System.Windows.Forms.Label
    Friend WithEvents colObservaciones As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFActualizacion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tbbRefrescar As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbSep2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents colDocumentos As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTotal As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tbbImprimir As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbSep3 As System.Windows.Forms.ToolBarButton
    Friend WithEvents grdCobranza As System.Windows.Forms.DataGrid
    Friend WithEvents styPedidoCobranza As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colPCPedidoReferencia As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colPCCliente As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colPCNombre As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colPCTipoCargoTipoPedido As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colPCLitros As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colPCFCargo As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colPCRutaSuministro As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colPCCelula As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tbbCerrarCobranza As System.Windows.Forms.ToolBarButton
    Friend WithEvents colPCSaldo As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colStatus As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblUsuarioCancelacion As System.Windows.Forms.Label
    Friend WithEvents colUsuarioCancelacion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colUsuarioCancelacionNombre As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblMotivoCancelacion As System.Windows.Forms.Label
    Friend WithEvents colMotivoCancelacionCobranzaDescripcion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblFCancelacion As System.Windows.Forms.Label
    Friend WithEvents colFCancelacion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTipoRelacion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colPCGestionInicialDescripcion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colEmpleadoNombre As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colUsuarioCaptura As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colPCGestionFinalDescripcion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tbbModificar As System.Windows.Forms.ToolBarButton
    Friend WithEvents mnuBarra As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuImpRelacion As System.Windows.Forms.MenuItem
    Friend WithEvents mnuImpRelacionCierre As System.Windows.Forms.MenuItem
    Friend WithEvents tbbConsultarDocumento As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbSep4 As System.Windows.Forms.ToolBarButton
    Friend WithEvents colTipoCobranzaDescripcion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents mnuImpRelacionRuta As System.Windows.Forms.MenuItem
    Friend WithEvents tpDatosDocumento As System.Windows.Forms.TabPage
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblObservacionesDoc As System.Windows.Forms.Label
    Friend WithEvents lblDocumentoGestion As System.Windows.Forms.Label
    Friend WithEvents lblFCompromisoGestion As System.Windows.Forms.Label
    Friend WithEvents lblGestionFinal As System.Windows.Forms.Label
    Friend WithEvents chkSolicitud As System.Windows.Forms.CheckBox
    Friend WithEvents tbbIntegrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbSep5 As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbExportar As System.Windows.Forms.ToolBarButton
    Friend WithEvents grdPedidoCobranza As System.Windows.Forms.DataGrid
    Friend WithEvents tbbSep6 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton1 As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmRelacionCobranza))
        Me.tbrBarra = New System.Windows.Forms.ToolBar()
        Me.tbbCapturar = New System.Windows.Forms.ToolBarButton()
        Me.tbbModificar = New System.Windows.Forms.ToolBarButton()
        Me.tbbCancelar = New System.Windows.Forms.ToolBarButton()
        Me.tbbCerrarCobranza = New System.Windows.Forms.ToolBarButton()
        Me.tbbSep5 = New System.Windows.Forms.ToolBarButton()
        Me.tbbIntegrar = New System.Windows.Forms.ToolBarButton()
        Me.tbbSep4 = New System.Windows.Forms.ToolBarButton()
        Me.tbbConsultarDocumento = New System.Windows.Forms.ToolBarButton()
        Me.tbbSep1 = New System.Windows.Forms.ToolBarButton()
        Me.tbbRefrescar = New System.Windows.Forms.ToolBarButton()
        Me.tbbSep2 = New System.Windows.Forms.ToolBarButton()
        Me.tbbImprimir = New System.Windows.Forms.ToolBarButton()
        Me.mnuBarra = New System.Windows.Forms.ContextMenu()
        Me.mnuImpRelacion = New System.Windows.Forms.MenuItem()
        Me.mnuImpRelacionRuta = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.mnuImpRelacionCierre = New System.Windows.Forms.MenuItem()
        Me.tbbSep3 = New System.Windows.Forms.ToolBarButton()
        Me.tbbCerrar = New System.Windows.Forms.ToolBarButton()
        Me.tbbExportar = New System.Windows.Forms.ToolBarButton()
        Me.imgLista16 = New System.Windows.Forms.ImageList(Me.components)
        Me.grdCobranza = New System.Windows.Forms.DataGrid()
        Me.Estilo1 = New System.Windows.Forms.DataGridTableStyle()
        Me.colCobranza = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTipoCobranzaDescripcion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFCobranza = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colEmpleado = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colEmpleadoNombre = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colUsuarioCaptura = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colStatus = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colDocumentos = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTotal = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colObservaciones = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFActualizacion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colUsuarioCancelacion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colUsuarioCancelacionNombre = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colMotivoCancelacionCobranzaDescripcion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFCancelacion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTipoRelacion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpDatos = New System.Windows.Forms.TabPage()
        Me.lblFCancelacion = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblMotivoCancelacion = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblUsuarioCancelacion = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblFActualizacion = New System.Windows.Forms.Label()
        Me.lblObservaciones = New System.Windows.Forms.Label()
        Me.tpDatosDocumento = New System.Windows.Forms.TabPage()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblDocumentoGestion = New System.Windows.Forms.Label()
        Me.lblFCompromisoGestion = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblGestionFinal = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblObservacionesDoc = New System.Windows.Forms.Label()
        Me.dtpFCobranza = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.grdPedidoCobranza = New System.Windows.Forms.DataGrid()
        Me.styPedidoCobranza = New System.Windows.Forms.DataGridTableStyle()
        Me.colPCPedidoReferencia = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colPCGestionInicialDescripcion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colPCGestionFinalDescripcion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colPCTipoCargoTipoPedido = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colPCRutaSuministro = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colPCCelula = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colPCFCargo = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colPCCliente = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colPCNombre = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colPCLitros = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colPCSaldo = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.chkSolicitud = New System.Windows.Forms.CheckBox()
        Me.tbbSep6 = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton1 = New System.Windows.Forms.ToolBarButton()
        CType(Me.grdCobranza, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.tpDatos.SuspendLayout()
        Me.tpDatosDocumento.SuspendLayout()
        CType(Me.grdPedidoCobranza, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbrBarra
        '
        Me.tbrBarra.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbrBarra.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.tbbCapturar, Me.tbbModificar, Me.tbbCancelar, Me.tbbCerrarCobranza, Me.tbbSep5, Me.tbbIntegrar, Me.tbbSep4, Me.tbbConsultarDocumento, Me.tbbSep1, Me.tbbRefrescar, Me.tbbSep2, Me.tbbImprimir, Me.tbbSep3, Me.tbbExportar, Me.ToolBarButton1, Me.tbbCerrar, Me.tbbSep6})
        Me.tbrBarra.ButtonSize = New System.Drawing.Size(65, 36)
        Me.tbrBarra.DropDownArrows = True
        Me.tbrBarra.ImageList = Me.imgLista16
        Me.tbrBarra.Name = "tbrBarra"
        Me.tbrBarra.ShowToolTips = True
        Me.tbrBarra.Size = New System.Drawing.Size(960, 39)
        Me.tbrBarra.TabIndex = 0
        '
        'tbbCapturar
        '
        Me.tbbCapturar.ImageIndex = 0
        Me.tbbCapturar.Tag = "Capturar"
        Me.tbbCapturar.Text = "Capturar"
        '
        'tbbModificar
        '
        Me.tbbModificar.ImageIndex = 7
        Me.tbbModificar.Tag = "Modificar"
        Me.tbbModificar.Text = "Modificar"
        Me.tbbModificar.ToolTipText = "Modificar la relación de cobranza"
        '
        'tbbCancelar
        '
        Me.tbbCancelar.ImageIndex = 1
        Me.tbbCancelar.Tag = "Cancelar"
        Me.tbbCancelar.Text = "Cancelar"
        '
        'tbbCerrarCobranza
        '
        Me.tbbCerrarCobranza.ImageIndex = 6
        Me.tbbCerrarCobranza.Tag = "CerrarCobranza"
        Me.tbbCerrarCobranza.Text = "Cerrar cob."
        Me.tbbCerrarCobranza.ToolTipText = "Cerrar la cobranza"
        '
        'tbbSep5
        '
        Me.tbbSep5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbbIntegrar
        '
        Me.tbbIntegrar.ImageIndex = 10
        Me.tbbIntegrar.Tag = "Integrar"
        Me.tbbIntegrar.Text = "Integrar"
        '
        'tbbSep4
        '
        Me.tbbSep4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbbConsultarDocumento
        '
        Me.tbbConsultarDocumento.ImageIndex = 8
        Me.tbbConsultarDocumento.Tag = "ConsultarDocumento"
        Me.tbbConsultarDocumento.Text = "Documento"
        Me.tbbConsultarDocumento.ToolTipText = "Consultar el documento seleccionado"
        '
        'tbbSep1
        '
        Me.tbbSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbbRefrescar
        '
        Me.tbbRefrescar.ImageIndex = 3
        Me.tbbRefrescar.Tag = "Refrescar"
        Me.tbbRefrescar.Text = "Refrescar"
        Me.tbbRefrescar.ToolTipText = "Refrescar información"
        '
        'tbbSep2
        '
        Me.tbbSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbbImprimir
        '
        Me.tbbImprimir.DropDownMenu = Me.mnuBarra
        Me.tbbImprimir.ImageIndex = 5
        Me.tbbImprimir.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
        Me.tbbImprimir.Tag = "Imprimir"
        Me.tbbImprimir.Text = "Imprimir"
        Me.tbbImprimir.ToolTipText = "Imprimir"
        '
        'mnuBarra
        '
        Me.mnuBarra.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuImpRelacion, Me.mnuImpRelacionRuta, Me.MenuItem2, Me.mnuImpRelacionCierre})
        '
        'mnuImpRelacion
        '
        Me.mnuImpRelacion.Index = 0
        Me.mnuImpRelacion.Text = "Relación de cobranza (por nombre)"
        '
        'mnuImpRelacionRuta
        '
        Me.mnuImpRelacionRuta.Index = 1
        Me.mnuImpRelacionRuta.Text = "Relación de cobranza (por ruta)"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 2
        Me.MenuItem2.Text = "-"
        '
        'mnuImpRelacionCierre
        '
        Me.mnuImpRelacionCierre.Index = 3
        Me.mnuImpRelacionCierre.Text = "Cierre de relación de cobranza"
        '
        'tbbSep3
        '
        Me.tbbSep3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbbCerrar
        '
        Me.tbbCerrar.ImageIndex = 2
        Me.tbbCerrar.Tag = "Cerrar"
        Me.tbbCerrar.Text = "&Cerrar"
        Me.tbbCerrar.ToolTipText = "Cerrar"
        '
        'tbbExportar
        '
        Me.tbbExportar.ImageIndex = 10
        Me.tbbExportar.Tag = "Exportar"
        Me.tbbExportar.Text = "Exportar"
        '
        'imgLista16
        '
        Me.imgLista16.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgLista16.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgLista16.ImageStream = CType(resources.GetObject("imgLista16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLista16.TransparentColor = System.Drawing.Color.Transparent
        '
        'grdCobranza
        '
        Me.grdCobranza.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdCobranza.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.grdCobranza.CaptionBackColor = System.Drawing.Color.DarkSlateBlue
        Me.grdCobranza.CaptionForeColor = System.Drawing.Color.White
        Me.grdCobranza.CaptionText = "Lista de relaciones de cobranza"
        Me.grdCobranza.DataMember = ""
        Me.grdCobranza.HeaderForeColor = System.Drawing.SystemColors.WindowText
        Me.grdCobranza.Location = New System.Drawing.Point(0, 44)
        Me.grdCobranza.Name = "grdCobranza"
        Me.grdCobranza.ReadOnly = True
        Me.grdCobranza.Size = New System.Drawing.Size(960, 288)
        Me.grdCobranza.TabIndex = 1
        Me.grdCobranza.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.Estilo1})
        '
        'Estilo1
        '
        Me.Estilo1.DataGrid = Me.grdCobranza
        Me.Estilo1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colCobranza, Me.colTipoCobranzaDescripcion, Me.colFCobranza, Me.colEmpleado, Me.colEmpleadoNombre, Me.colUsuarioCaptura, Me.colStatus, Me.colDocumentos, Me.colTotal, Me.colObservaciones, Me.colFActualizacion, Me.colUsuarioCancelacion, Me.colUsuarioCancelacionNombre, Me.colMotivoCancelacionCobranzaDescripcion, Me.colFCancelacion, Me.colTipoRelacion})
        Me.Estilo1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.Estilo1.MappingName = "Cobranza"
        Me.Estilo1.RowHeadersVisible = False
        '
        'colCobranza
        '
        Me.colCobranza.Format = ""
        Me.colCobranza.FormatInfo = Nothing
        Me.colCobranza.HeaderText = "Cobranza"
        Me.colCobranza.MappingName = "Cobranza"
        Me.colCobranza.Width = 75
        '
        'colTipoCobranzaDescripcion
        '
        Me.colTipoCobranzaDescripcion.Format = ""
        Me.colTipoCobranzaDescripcion.FormatInfo = Nothing
        Me.colTipoCobranzaDescripcion.HeaderText = "Tipo de cobranza"
        Me.colTipoCobranzaDescripcion.MappingName = "TipoCobranzaDescripcion"
        Me.colTipoCobranzaDescripcion.Width = 200
        '
        'colFCobranza
        '
        Me.colFCobranza.Format = ""
        Me.colFCobranza.FormatInfo = Nothing
        Me.colFCobranza.HeaderText = "F.Cobranza"
        Me.colFCobranza.MappingName = "FCobranza"
        Me.colFCobranza.Width = 75
        '
        'colEmpleado
        '
        Me.colEmpleado.Format = ""
        Me.colEmpleado.FormatInfo = Nothing
        Me.colEmpleado.HeaderText = "Responsable"
        Me.colEmpleado.MappingName = "Empleado"
        Me.colEmpleado.Width = 75
        '
        'colEmpleadoNombre
        '
        Me.colEmpleadoNombre.Format = ""
        Me.colEmpleadoNombre.FormatInfo = Nothing
        Me.colEmpleadoNombre.HeaderText = "Nombre"
        Me.colEmpleadoNombre.MappingName = "EmpleadoNombre"
        Me.colEmpleadoNombre.Width = 250
        '
        'colUsuarioCaptura
        '
        Me.colUsuarioCaptura.Format = ""
        Me.colUsuarioCaptura.FormatInfo = Nothing
        Me.colUsuarioCaptura.HeaderText = "Capturó"
        Me.colUsuarioCaptura.MappingName = "UsuarioCaptura"
        Me.colUsuarioCaptura.Width = 75
        '
        'colStatus
        '
        Me.colStatus.Format = ""
        Me.colStatus.FormatInfo = Nothing
        Me.colStatus.HeaderText = "Estatus"
        Me.colStatus.MappingName = "Status"
        Me.colStatus.Width = 75
        '
        'colDocumentos
        '
        Me.colDocumentos.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.colDocumentos.Format = ""
        Me.colDocumentos.FormatInfo = Nothing
        Me.colDocumentos.HeaderText = "# Docs."
        Me.colDocumentos.MappingName = "Pedidos"
        Me.colDocumentos.Width = 75
        '
        'colTotal
        '
        Me.colTotal.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colTotal.Format = "#,##.00"
        Me.colTotal.FormatInfo = Nothing
        Me.colTotal.HeaderText = "Total"
        Me.colTotal.MappingName = "Total"
        Me.colTotal.Width = 75
        '
        'colObservaciones
        '
        Me.colObservaciones.Format = ""
        Me.colObservaciones.FormatInfo = Nothing
        Me.colObservaciones.HeaderText = "Observaciones"
        Me.colObservaciones.MappingName = "Observaciones"
        Me.colObservaciones.Width = 0
        '
        'colFActualizacion
        '
        Me.colFActualizacion.Format = ""
        Me.colFActualizacion.FormatInfo = Nothing
        Me.colFActualizacion.HeaderText = "FActualizacion"
        Me.colFActualizacion.MappingName = "FActualizacion"
        Me.colFActualizacion.Width = 0
        '
        'colUsuarioCancelacion
        '
        Me.colUsuarioCancelacion.Format = ""
        Me.colUsuarioCancelacion.FormatInfo = Nothing
        Me.colUsuarioCancelacion.HeaderText = "Usuario cancelación"
        Me.colUsuarioCancelacion.MappingName = "UsuarioCancelacion"
        Me.colUsuarioCancelacion.Width = 0
        '
        'colUsuarioCancelacionNombre
        '
        Me.colUsuarioCancelacionNombre.Format = ""
        Me.colUsuarioCancelacionNombre.FormatInfo = Nothing
        Me.colUsuarioCancelacionNombre.HeaderText = "Nombre"
        Me.colUsuarioCancelacionNombre.MappingName = "UsuarioCancelacionNombre"
        Me.colUsuarioCancelacionNombre.Width = 0
        '
        'colMotivoCancelacionCobranzaDescripcion
        '
        Me.colMotivoCancelacionCobranzaDescripcion.Format = ""
        Me.colMotivoCancelacionCobranzaDescripcion.FormatInfo = Nothing
        Me.colMotivoCancelacionCobranzaDescripcion.HeaderText = "Motivo de cancelación"
        Me.colMotivoCancelacionCobranzaDescripcion.MappingName = "MotivoCancelacionCobranzaDescripcion"
        Me.colMotivoCancelacionCobranzaDescripcion.Width = 0
        '
        'colFCancelacion
        '
        Me.colFCancelacion.Format = ""
        Me.colFCancelacion.FormatInfo = Nothing
        Me.colFCancelacion.HeaderText = "FCancelacion"
        Me.colFCancelacion.MappingName = "FCancelacion"
        Me.colFCancelacion.Width = 0
        '
        'colTipoRelacion
        '
        Me.colTipoRelacion.Format = ""
        Me.colTipoRelacion.FormatInfo = Nothing
        Me.colTipoRelacion.HeaderText = "TipoCobranza"
        Me.colTipoRelacion.MappingName = "TipoCobranza"
        Me.colTipoRelacion.Width = 0
        '
        'btnCerrar
        '
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Location = New System.Drawing.Point(400, 16)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(48, 23)
        Me.btnCerrar.TabIndex = 2
        Me.btnCerrar.Text = "&Cerrar"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpDatos, Me.tpDatosDocumento})
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TabControl1.Location = New System.Drawing.Point(0, 565)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(960, 104)
        Me.TabControl1.TabIndex = 3
        '
        'tpDatos
        '
        Me.tpDatos.BackColor = System.Drawing.Color.Gainsboro
        Me.tpDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblFCancelacion, Me.Label2, Me.Label6, Me.lblMotivoCancelacion, Me.Label5, Me.lblUsuarioCancelacion, Me.Label4, Me.Label3, Me.lblFActualizacion, Me.lblObservaciones})
        Me.tpDatos.Location = New System.Drawing.Point(4, 22)
        Me.tpDatos.Name = "tpDatos"
        Me.tpDatos.Size = New System.Drawing.Size(952, 78)
        Me.tpDatos.TabIndex = 0
        Me.tpDatos.Text = "Datos de la relación de cobranza"
        '
        'lblFCancelacion
        '
        Me.lblFCancelacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFCancelacion.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblFCancelacion.Location = New System.Drawing.Point(112, 40)
        Me.lblFCancelacion.Name = "lblFCancelacion"
        Me.lblFCancelacion.Size = New System.Drawing.Size(160, 21)
        Me.lblFCancelacion.TabIndex = 9
        Me.lblFCancelacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 14)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "F.Cancelación:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(608, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(118, 14)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Motivo de cancelación:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMotivoCancelacion
        '
        Me.lblMotivoCancelacion.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblMotivoCancelacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMotivoCancelacion.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblMotivoCancelacion.Location = New System.Drawing.Point(728, 40)
        Me.lblMotivoCancelacion.Name = "lblMotivoCancelacion"
        Me.lblMotivoCancelacion.Size = New System.Drawing.Size(208, 21)
        Me.lblMotivoCancelacion.TabIndex = 6
        Me.lblMotivoCancelacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(300, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 14)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Canceló:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUsuarioCancelacion
        '
        Me.lblUsuarioCancelacion.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblUsuarioCancelacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblUsuarioCancelacion.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblUsuarioCancelacion.Location = New System.Drawing.Point(384, 40)
        Me.lblUsuarioCancelacion.Name = "lblUsuarioCancelacion"
        Me.lblUsuarioCancelacion.Size = New System.Drawing.Size(216, 21)
        Me.lblUsuarioCancelacion.TabIndex = 4
        Me.lblUsuarioCancelacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 14)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "F.Actualización:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(300, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 14)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Observaciones:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFActualizacion
        '
        Me.lblFActualizacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFActualizacion.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblFActualizacion.Location = New System.Drawing.Point(112, 16)
        Me.lblFActualizacion.Name = "lblFActualizacion"
        Me.lblFActualizacion.Size = New System.Drawing.Size(160, 21)
        Me.lblFActualizacion.TabIndex = 1
        Me.lblFActualizacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblObservaciones
        '
        Me.lblObservaciones.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblObservaciones.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblObservaciones.Location = New System.Drawing.Point(384, 16)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(552, 21)
        Me.lblObservaciones.TabIndex = 0
        Me.lblObservaciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tpDatosDocumento
        '
        Me.tpDatosDocumento.BackColor = System.Drawing.Color.Gainsboro
        Me.tpDatosDocumento.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label13, Me.lblDocumentoGestion, Me.lblFCompromisoGestion, Me.Label10, Me.Label11, Me.lblGestionFinal, Me.Label7, Me.lblObservacionesDoc})
        Me.tpDatosDocumento.Location = New System.Drawing.Point(4, 22)
        Me.tpDatosDocumento.Name = "tpDatosDocumento"
        Me.tpDatosDocumento.Size = New System.Drawing.Size(952, 78)
        Me.tpDatosDocumento.TabIndex = 1
        Me.tpDatosDocumento.Text = "Datos del documento"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(284, 19)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(105, 14)
        Me.Label13.TabIndex = 15
        Me.Label13.Text = "Documento gestión:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDocumentoGestion
        '
        Me.lblDocumentoGestion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDocumentoGestion.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblDocumentoGestion.Location = New System.Drawing.Point(392, 16)
        Me.lblDocumentoGestion.Name = "lblDocumentoGestion"
        Me.lblDocumentoGestion.Size = New System.Drawing.Size(200, 21)
        Me.lblDocumentoGestion.TabIndex = 14
        Me.lblDocumentoGestion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFCompromisoGestion
        '
        Me.lblFCompromisoGestion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFCompromisoGestion.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblFCompromisoGestion.Location = New System.Drawing.Point(112, 40)
        Me.lblFCompromisoGestion.Name = "lblFCompromisoGestion"
        Me.lblFCompromisoGestion.Size = New System.Drawing.Size(160, 21)
        Me.lblFCompromisoGestion.TabIndex = 13
        Me.lblFCompromisoGestion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 43)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 14)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "F.Compromiso:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 14)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Gestion Final:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGestionFinal
        '
        Me.lblGestionFinal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblGestionFinal.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblGestionFinal.Location = New System.Drawing.Point(112, 16)
        Me.lblGestionFinal.Name = "lblGestionFinal"
        Me.lblGestionFinal.Size = New System.Drawing.Size(160, 21)
        Me.lblGestionFinal.TabIndex = 10
        Me.lblGestionFinal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(284, 43)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 14)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Observaciones:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblObservacionesDoc
        '
        Me.lblObservacionesDoc.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblObservacionesDoc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblObservacionesDoc.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblObservacionesDoc.Location = New System.Drawing.Point(392, 40)
        Me.lblObservacionesDoc.Name = "lblObservacionesDoc"
        Me.lblObservacionesDoc.Size = New System.Drawing.Size(544, 21)
        Me.lblObservacionesDoc.TabIndex = 3
        Me.lblObservacionesDoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFCobranza
        '
        Me.dtpFCobranza.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.dtpFCobranza.Location = New System.Drawing.Point(648, 4)
        Me.dtpFCobranza.Name = "dtpFCobranza"
        Me.dtpFCobranza.Size = New System.Drawing.Size(216, 21)
        Me.dtpFCobranza.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(576, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 14)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "F.Cobranza:"
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnBuscar.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Bitmap)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(880, 4)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.TabIndex = 6
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grdPedidoCobranza
        '
        Me.grdPedidoCobranza.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdPedidoCobranza.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.grdPedidoCobranza.CaptionBackColor = System.Drawing.Color.LightSteelBlue
        Me.grdPedidoCobranza.DataMember = ""
        Me.grdPedidoCobranza.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdPedidoCobranza.Location = New System.Drawing.Point(0, 336)
        Me.grdPedidoCobranza.Name = "grdPedidoCobranza"
        Me.grdPedidoCobranza.ReadOnly = True
        Me.grdPedidoCobranza.Size = New System.Drawing.Size(960, 228)
        Me.grdPedidoCobranza.TabIndex = 7
        Me.grdPedidoCobranza.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.styPedidoCobranza})
        '
        'styPedidoCobranza
        '
        Me.styPedidoCobranza.AlternatingBackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.styPedidoCobranza.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.styPedidoCobranza.DataGrid = Me.grdPedidoCobranza
        Me.styPedidoCobranza.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colPCPedidoReferencia, Me.colPCGestionInicialDescripcion, Me.colPCGestionFinalDescripcion, Me.colPCTipoCargoTipoPedido, Me.colPCRutaSuministro, Me.colPCCelula, Me.colPCFCargo, Me.colPCCliente, Me.colPCNombre, Me.colPCLitros, Me.colPCSaldo})
        Me.styPedidoCobranza.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None
        Me.styPedidoCobranza.HeaderBackColor = System.Drawing.Color.LightSteelBlue
        Me.styPedidoCobranza.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.styPedidoCobranza.MappingName = "PedidoCobranza"
        Me.styPedidoCobranza.RowHeadersVisible = False
        '
        'colPCPedidoReferencia
        '
        Me.colPCPedidoReferencia.Format = ""
        Me.colPCPedidoReferencia.FormatInfo = Nothing
        Me.colPCPedidoReferencia.HeaderText = "Documento"
        Me.colPCPedidoReferencia.MappingName = "PedidoReferencia"
        Me.colPCPedidoReferencia.Width = 150
        '
        'colPCGestionInicialDescripcion
        '
        Me.colPCGestionInicialDescripcion.Format = ""
        Me.colPCGestionInicialDescripcion.FormatInfo = Nothing
        Me.colPCGestionInicialDescripcion.HeaderText = "Gestión inicial"
        Me.colPCGestionInicialDescripcion.MappingName = "GestionInicialDescripcion"
        Me.colPCGestionInicialDescripcion.Width = 80
        '
        'colPCGestionFinalDescripcion
        '
        Me.colPCGestionFinalDescripcion.Format = ""
        Me.colPCGestionFinalDescripcion.FormatInfo = Nothing
        Me.colPCGestionFinalDescripcion.HeaderText = "Gestión final"
        Me.colPCGestionFinalDescripcion.MappingName = "GestionFinalDescripcion"
        Me.colPCGestionFinalDescripcion.NullText = ""
        Me.colPCGestionFinalDescripcion.Width = 80
        '
        'colPCTipoCargoTipoPedido
        '
        Me.colPCTipoCargoTipoPedido.Format = ""
        Me.colPCTipoCargoTipoPedido.FormatInfo = Nothing
        Me.colPCTipoCargoTipoPedido.HeaderText = "Tipo de documento"
        Me.colPCTipoCargoTipoPedido.MappingName = "TipoCargoTipoPedido"
        Me.colPCTipoCargoTipoPedido.Width = 170
        '
        'colPCRutaSuministro
        '
        Me.colPCRutaSuministro.Format = ""
        Me.colPCRutaSuministro.FormatInfo = Nothing
        Me.colPCRutaSuministro.HeaderText = "Ruta"
        Me.colPCRutaSuministro.MappingName = "RutaSuministro"
        Me.colPCRutaSuministro.Width = 50
        '
        'colPCCelula
        '
        Me.colPCCelula.Format = ""
        Me.colPCCelula.FormatInfo = Nothing
        Me.colPCCelula.HeaderText = "Célula"
        Me.colPCCelula.MappingName = "PedidoCelula"
        Me.colPCCelula.Width = 50
        '
        'colPCFCargo
        '
        Me.colPCFCargo.Format = ""
        Me.colPCFCargo.FormatInfo = Nothing
        Me.colPCFCargo.HeaderText = "F.Cargo"
        Me.colPCFCargo.MappingName = "FCargo"
        Me.colPCFCargo.Width = 75
        '
        'colPCCliente
        '
        Me.colPCCliente.Format = ""
        Me.colPCCliente.FormatInfo = Nothing
        Me.colPCCliente.HeaderText = "Cliente"
        Me.colPCCliente.MappingName = "Cliente"
        Me.colPCCliente.Width = 75
        '
        'colPCNombre
        '
        Me.colPCNombre.Format = ""
        Me.colPCNombre.FormatInfo = Nothing
        Me.colPCNombre.HeaderText = "Nombre"
        Me.colPCNombre.MappingName = "Nombre"
        Me.colPCNombre.Width = 120
        '
        'colPCLitros
        '
        Me.colPCLitros.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colPCLitros.Format = "#,##"
        Me.colPCLitros.FormatInfo = Nothing
        Me.colPCLitros.HeaderText = "Litros"
        Me.colPCLitros.MappingName = "Litros"
        Me.colPCLitros.Width = 75
        '
        'colPCSaldo
        '
        Me.colPCSaldo.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colPCSaldo.Format = "#,##.00"
        Me.colPCSaldo.FormatInfo = Nothing
        Me.colPCSaldo.HeaderText = "Saldo"
        Me.colPCSaldo.MappingName = "Saldo"
        Me.colPCSaldo.Width = 75
        '
        'chkSolicitud
        '
        Me.chkSolicitud.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.chkSolicitud.Location = New System.Drawing.Point(648, 26)
        Me.chkSolicitud.Name = "chkSolicitud"
        Me.chkSolicitud.Size = New System.Drawing.Size(216, 16)
        Me.chkSolicitud.TabIndex = 8
        Me.chkSolicitud.Text = "Solicitud de documentos"
        '
        'ToolBarButton1
        '
        Me.ToolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'frmRelacionCobranza
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(960, 669)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkSolicitud, Me.grdPedidoCobranza, Me.btnBuscar, Me.Label1, Me.dtpFCobranza, Me.TabControl1, Me.grdCobranza, Me.tbrBarra, Me.btnCerrar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRelacionCobranza"
        Me.Text = "Relaciones de cobranza"
        CType(Me.grdCobranza, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.tpDatos.ResumeLayout(False)
        Me.tpDatosDocumento.ResumeLayout(False)
        CType(Me.grdPedidoCobranza, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Procedimientos"
    'TODO: Optimizar
    Private Sub CargaDatos(ByVal FCobranza As Date)
        Cursor = Cursors.WaitCursor
        'Se cambió por la consulta desde un procedimiento almacenado
        'Dim strQuery As String = "SELECT * FROM vwCYCCobranza WHERE FCobranza = '" & FCobranza & "' ORDER BY Cobranza"

        Dim cmd As New SqlCommand()
        cmd.Connection = SigaMetClasses.DataLayer.Conexion
        cmd.CommandType = CommandType.StoredProcedure

        Dim strQuery As String = Nothing

        If _tipoOperacionCobranza = TipoCapturaCobranza.Captura Then
            'strQuery = "EXECUTE spCyCConsultaVwCYCCobranza '" & FCobranza & "'"
            cmd.CommandText = "spCyCConsultaVwCYCCobranza"
            cmd.Parameters.Add("@FCobranza", SqlDbType.DateTime).Value = FCobranza
        Else
            'strQuery = "EXECUTE spCyCConsultaVwCYCSolicitudCobranza '" & FCobranza & "'"
            cmd.CommandText = "spCyCConsultaVwCYCSolicitudCobranza"
            cmd.Parameters.Add("@FCobranza", SqlDbType.DateTime).Value = FCobranza
        End If

        'Dim da As New SqlDataAdapter(strQuery, ConString)
        Dim da As New SqlDataAdapter(cmd)
        _dsCobranza = New DataSet("Cobranza")
        _PedidoReferencia = ""
        tbbConsultarDocumento.Enabled = False

        Try
            da.Fill(_dsCobranza, "Cobranza")
            'Se cambió por la consulta desde un procedimiento almacenado
            'da.SelectCommand.CommandText = "SELECT pc.* FROM vwCYCPedidoCobranza pc JOIN vwCYCCobranza co on pc.Cobranza = co.Cobranza WHERE co.FCobranza = '" & dtpFCobranza.Value.Date & "' ORDER BY co.Cobranza, pc.Nombre, pc.FCargo, pc.GestionInicial"

            'If _tipoOperacionCobranza = TipoCapturaCobranza.Captura Then
            '    da.SelectCommand.CommandText = "EXECUTE spCyCPedidoCobranzaCobranza '" & dtpFCobranza.Value.Date & "'"
            'Else
            '    da.SelectCommand.CommandText = "EXECUTE spCyCPedidoCobranzaSolicitudCobranza '" & dtpFCobranza.Value.Date & "'"
            'End If

            'da.Fill(_dsCobranza, "PedidoCobranza")

            grdCobranza.DataSource = _dsCobranza.Tables("Cobranza")
            grdCobranza.CaptionText = "Relaciones de cobranza del " & dtpFCobranza.Value.ToLongDateString & " (" & _dsCobranza.Tables("Cobranza").Rows.Count.ToString & " en total)"

            'Botones
            tbbModificar.Enabled = False
            tbbCancelar.Enabled = False
            tbbCerrarCobranza.Enabled = False
            tbbImprimir.Enabled = False

            grdPedidoCobranza.DataSource = Nothing
            grdPedidoCobranza.CaptionText = String.Empty

            lblObservaciones.Text = String.Empty
            lblFActualizacion.Text = String.Empty
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            da.Dispose()
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub CargarDetallePedidos(ByVal Cobranza As Integer)
        Cursor = Cursors.WaitCursor

        Dim cmd As New SqlCommand()
        cmd.Connection = SigaMetClasses.DataLayer.Conexion
        cmd.CommandType = CommandType.StoredProcedure

        Dim da As New SqlDataAdapter()
        da.SelectCommand = cmd

        If _dsCobranza.Tables.Contains("PedidoCobranza") Then
            _dsCobranza.Tables("PedidoCobranza").Clear()
        End If


        Try
            If _tipoOperacionCobranza = TipoCapturaCobranza.Captura Then
                da.SelectCommand.CommandText = "spCyCConsultaPedidoCobranza"
                da.SelectCommand.Parameters.Add("@Cobranza", SqlDbType.Int).Value = Cobranza
            Else
                da.SelectCommand.CommandText = "spCyCConsultaPedidoSolicitudCobranza"
                da.SelectCommand.Parameters.Add("@SolicitudCobranza", SqlDbType.Int).Value = Cobranza
            End If

            da.Fill(_dsCobranza, "PedidoCobranza")
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            da.Dispose()
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Capturar()
        'Permitir la captura de listas, o de solicitud de documentos a resguardo
        'If Not oSeguridad.TieneAcceso("RELACIONES_CAPTURA_FULL") Then
        '    If Not oSeguridad.TieneAcceso("RELACIONES_CAPTURA_OWN") Then
        '        'Para precaptura de relaciones de cobranza
        '        If Not oSeguridad.TieneAcceso("PRECAPT_COBRANZA") Then
        '            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Main.GLOBAL_NombreAplicacion, _
        '            MessageBoxButtons.OK, MessageBoxIcon.Information)
        '            Exit Sub
        '        End If
        '    End If
        'End If

        If _tipoOperacionCobranza = TipoCapturaCobranza.Captura Then
            If Not oSeguridad.TieneAcceso("RELACIONES_CAPTURA_FULL") OrElse
            Not oSeguridad.TieneAcceso("RELACIONES_CAPTURA_OWN") Then
                MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Main.GLOBAL_NombreAplicacion,
                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        Else
            If Not oSeguridad.TieneAcceso("PRECAPT_COBRANZA") Then
                MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Main.GLOBAL_NombreAplicacion,
                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If

        Cursor = Cursors.WaitCursor
        Dim frmCapRel As New frmCapRelacionCobranza(_tipoOperacionCobranza)

        If frmCapRel.ShowDialog() = DialogResult.OK Then
            chkSolicitud.Checked = (Not _tipoOperacionCobranza = TipoCapturaCobranza.Captura)
            CargaDatos(dtpFCobranza.Value.Date)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub Cancelar()
        Dim frmMotivoCancel As New SigaMetClasses.MotivoCancelacion(_Cobranza.ToString, SigaMetClasses.Enumeradores.enumDestinoCancelacion.Cobranza)
        If frmMotivoCancel.ShowDialog() = DialogResult.OK Then
            Dim oCobranza As New SigaMetClasses.cCobranza()
            Try
                If _tipoOperacionCobranza = TipoCapturaCobranza.Captura Then
                    oCobranza = New SigaMetClasses.cCobranza()
                    oCobranza.Cancela(_Cobranza, frmMotivoCancel.MotivoCancelacion, Main.GLOBAL_IDUsuario)
                Else
                    Dim precaptura As New RelacionCobranza.PreCapturaCobranza(SigaMetClasses.DataLayer.Conexion)
                    precaptura.CancelacionSolicitudCobranza(_Cobranza, frmMotivoCancel.MotivoCancelacion, Main.GLOBAL_IDUsuario)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                oCobranza.Dispose()
            End Try
            CargaDatos(dtpFCobranza.Value.Date)
        End If
    End Sub

    Private Sub Modificar()
        Cursor = Cursors.WaitCursor
        Dim x As New frmCapRelacionCobranza(_tipoOperacionCobranza, _Cobranza, URLGateway:=_UrlGateway)
        If x.ShowDialog() = DialogResult.OK Then
            Me.CargaDatos(dtpFCobranza.Value.Date)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub CerrarCobranza()
        Cursor = Cursors.WaitCursor
        'Se cambió por la consulta desde procedimiento almacenado    17-03-2005
        'Dim da As New SqlDataAdapter("SELECT * FROM vwCYCPedidoCobranza Where Cobranza = " & _Cobranza.ToString & " ORDER BY PedidoReferencia", ConString)
        'Dim da As New SqlDataAdapter("EXECUTE spCyCConsultaVwCYCPedidoCobranza " & _Cobranza.ToString, ConString)
        Dim cmd As New SqlCommand()
        cmd.Connection = SigaMetClasses.DataLayer.Conexion
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "spCyCConsultaVwCYCPedidoCobranza"
        cmd.Parameters.Add("@Cobranza", SqlDbType.Int).Value = _Cobranza

        Dim da As New SqlDataAdapter(cmd)

        da.Fill(_dsCobranza, "RelacionCobranza")
        Dim objCierre As New frmCierreRelacionCobranza(_dsCobranza, _Cobranza, _UrlGateway)
        If objCierre.ShowDialog() = DialogResult.OK Then
            CargaDatos(dtpFCobranza.Value.Date)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub entregarCobranza()
        Cursor = Cursors.WaitCursor
        Dim frmCobranzaEntrega As frmCapRelacionCobranza
        Dim strURL As String = ConsultaURLGateway()

        If (Not String.IsNullOrEmpty(strURL)) Then
            frmCobranzaEntrega = New frmCapRelacionCobranza(TipoCapturaCobranza.Entrega, _Cobranza, strURL)
        Else
            frmCobranzaEntrega = New frmCapRelacionCobranza(TipoCapturaCobranza.Entrega, _Cobranza)
        End If

        If frmCobranzaEntrega.ShowDialog() = DialogResult.OK Then
            Me.CargaDatos(dtpFCobranza.Value.Date)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub relacionCobranzaAutomaticaOperador()
        If Not oSeguridad.TieneAcceso("RELACIONES_CAPTURA_FULL") Then
            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Main.GLOBAL_NombreAplicacion,
                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim oper As New ProgramacionCobranza.ConsultaProgramaOperador(SigaMetClasses.DataLayer.Conexion, GLOBAL_IDUsuario)
        If oper.ShowDialog() = DialogResult.OK Then
            CargaDatos(dtpFCobranza.Value.Date)
        End If
    End Sub
#End Region

#Region "Impresion"

    Private Sub ImprimirRelacion()
        Dim frmReporte As frmConsultaReporte

        If _tipoOperacionCobranza = TipoCapturaCobranza.Captura Then
            frmReporte = New frmConsultaReporte(frmConsultaReporte.enumTipoReporte.RelacionCobranza, 0, FechaOperacion.Date, _Cobranza, 0)
        Else
            frmReporte = New frmConsultaReporte(frmConsultaReporte.enumTipoReporte.SolicitudCobranza, 0, FechaOperacion.Date, _Cobranza, 0)
        End If

        Cursor = Cursors.WaitCursor
        frmReporte.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub ImprimirRelacionRuta()
        If Not _tipoOperacionCobranza = TipoCapturaCobranza.Captura Then
            MessageBox.Show("Esta operacion no está disponible", "Entrega de documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Dim frmReporte As New frmConsultaReporte(frmConsultaReporte.enumTipoReporte.RelacionCobranza, 1, FechaOperacion.Date, _Cobranza, 0)
        frmReporte.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub ImprimirRelacionCierre()
        If Not _tipoOperacionCobranza = TipoCapturaCobranza.Captura Then
            MessageBox.Show("Esta operacion no está disponible", "Entrega de documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Dim frmReporte As New frmConsultaReporte(frmConsultaReporte.enumTipoReporte.RelacionCierre, 0, FechaOperacion.Date, _Cobranza, 0)
        frmReporte.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub ImprimeRelacion()
        If _Empleado <> Main.GLOBAL_IDEmpleado Then
            If oSeguridad.TieneAcceso("RELACIONES_IMPRIME_FULL") Then
                ImprimirRelacion()
            Else
                MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        Else
            If oSeguridad.TieneAcceso("RELACIONES_IMPRIME_OWN") Then
                ImprimirRelacion()
            Else
                MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If

    End Sub

    Private Sub ImprimeRelacionRuta()
        If _Empleado <> Main.GLOBAL_IDEmpleado Then
            If oSeguridad.TieneAcceso("RELACIONES_IMPRIME_FULL") Then
                ImprimirRelacionRuta()
            Else
                MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        Else
            If oSeguridad.TieneAcceso("RELACIONES_IMPRIME_OWN") Then
                ImprimirRelacionRuta()
            Else
                MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub ImprimeRelacionCierre()
        If _Empleado <> Main.GLOBAL_IDEmpleado Then
            If oSeguridad.TieneAcceso("RELACIONES_IMPRIME_FULL") Then
                ImprimirRelacionCierre()
            Else
                MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        Else
            If oSeguridad.TieneAcceso("RELACIONES_IMPRIME_OWN") Then
                ImprimirRelacionCierre()
            Else
                MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub mnuImpRelacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuImpRelacion.Click
        ImprimeRelacion()
    End Sub

    Private Sub mnuImpRelacionRuta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuImpRelacionRuta.Click
        ImprimeRelacionRuta()
    End Sub

    Private Sub mnuImpRelacionCierre_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuImpRelacionCierre.Click
        ImprimeRelacionCierre()
    End Sub

#End Region

    'Cierre de la relación de cobranza IVTR
    Private Sub cierra(ByRef cobranza As Integer)
        Dim cnn As New SqlConnection(ConString)
        Dim cmd As New SqlCommand("spCYCCobranzaCierra", cnn)
        Dim parCob As New SqlParameter("@Cobranza", SqlDbType.Int)
        cmd.CommandType = CommandType.StoredProcedure
        parCob.Value = cobranza
        cmd.Parameters.Add(parCob)
        Try
            cnn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            cnn.Close()
        End Try
    End Sub


#Region "Barra de botones"
    Private Sub tbrBarra_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrBarra.ButtonClick
        Select Case e.Button.Tag.ToString()
            Case Is = "Capturar"
                Capturar()
            Case Is = "Modificar"
                If _tipoOperacionCobranza = TipoCapturaCobranza.Captura Then
                    If _Status <> "ABIERTO" Then
                        MessageBox.Show("La cobranza " & _Cobranza.ToString & " no puede ser modificada por que tiene estatus " & _Status, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If

                    'Validar el tipo de cobranza y los permisos
                    If Not AutorizaCapturaCobranza(CType(_TipoCobranza, Byte)) Then
                        MessageBox.Show("No tiene permiso para modificar este tipo de cobranza",
                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If

                    If _UsuarioCaptura <> Main.GLOBAL_IDUsuario Then
                        If oSeguridad.TieneAcceso("RELACIONES_MODIFICA_FULL") Then
                            Modificar()
                        Else
                            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                    Else
                        If Not oSeguridad.TieneAcceso("RELACIONES_MODIFICA_OWN") Then
                            Modificar()
                        Else
                            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                    End If
                Else
                    If _Status <> "EMITIDO" Then
                        MessageBox.Show("La solicitud de cobranza " & _Cobranza.ToString & " no puede ser modificada por que tiene estatus " & _Status, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If

                    Modificacion(False)
                End If
            Case Is = "Cancelar"
                If _tipoOperacionCobranza = TipoCapturaCobranza.Captura Then
                    If _Status <> "ABIERTO" Then
                        MessageBox.Show("La cobranza " & _Cobranza.ToString & " no puede ser cancelada por que tiene estatus " & _Status, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                    If _UsuarioCaptura <> Main.GLOBAL_IDUsuario Then
                        If oSeguridad.TieneAcceso("RELACIONES_CANCELA_FULL") Then
                            Cancelar()
                        Else
                            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                    Else
                        If oSeguridad.TieneAcceso("RELACIONES_CANCELA_OWN") Then
                            Cancelar()
                        Else
                            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                    End If
                Else
                    If _Status <> "EMITIDO" Then
                        MessageBox.Show("La cobranza " & _Cobranza.ToString & " no puede ser modificada por que tiene estatus " & _Status, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If

                    Modificacion(True)
                End If
            Case Is = "CerrarCobranza"
                If _tipoOperacionCobranza = TipoCapturaCobranza.Captura Then
                    Dim CobranzaEjec As Boolean = False

                    If _Status <> "ABIERTO" Then
                        MessageBox.Show("La relación de cobranza " & _Cobranza.ToString & " no puede ser cerrada porque tiene estatus " & _Status, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If

                    'Cerrar relacion de cobranza para planeacion, se debe validar el perfil del usuario para el cierre
                    If _TipoCobranza = 10 Or _TipoCobranza = GLOBAL_ListaDevEjecutivo Then
                        If oSeguridad.TieneAcceso("CIERRE_REL_COB_EJEC_ADMIN") Then
                            Dim oForm As New frmCierreRelCobPlaneacion(_dsCobranza, _Cobranza)
                            oForm.ShowDialog()
                            oForm = Nothing
                            CargaDatos(dtpFCobranza.Value.Date)
                            Exit Sub
                        Else
                            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                    End If

                    If Main.requiereAutorizacionCierre(SigaMetClasses.DataLayer.Conexion, CType(_TipoCobranza, Byte)) Then
                        If oSeguridad.TieneAcceso("TRANS_REL_COB_EJECUTIVO") Then
                            'Cierre de la cobranza
                            If MessageBox.Show("¿Desea cerrar la relación de cobranza?", "CyC", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                cierra(_Cobranza)
                                CargaDatos(dtpFCobranza.Value.Date)
                                Exit Sub
                            Else
                                Exit Sub
                            End If
                        Else
                            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                    End If

                    If _Empleado <> Main.GLOBAL_IDEmpleado Then
                        If oSeguridad.TieneAcceso("RELACIONES_CIERRA_FULL") Then
                            CerrarCobranza()
                        Else
                            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                    Else
                        If oSeguridad.TieneAcceso("RELACIONES_CIERRA_OWN") Then
                            CerrarCobranza()
                        Else
                            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                    End If
                Else
                    If _Status.Trim <> "EMITIDO" Then
                        MessageBox.Show("La cobranza " & _Cobranza.ToString & " no puede ser modificada por que tiene estatus " & _Status, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If

                    If Not oSeguridad.TieneAcceso("ENTREGA_COBRANZA_PRECAPT") Then
                        MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                    entregarCobranza()

                End If
            Case Is = "ConsultarDocumento"
                ConsultaDocumento(_PedidoReferencia)
            Case Is = "Refrescar"
                CargaDatos(dtpFCobranza.Value.Date)
            Case Is = "Imprimir"
                ImprimeRelacion()
            Case Is = "Cerrar"
                Me.Close()
            Case Is = "RelacionOperador"
                relacionCobranzaAutomaticaOperador()
            Case Is = "Integrar"
                integrarLista()
            Case Is = "Exportar"
                GeneraArchivos()
        End Select
    End Sub

#End Region

    'Private Function RelEjecutivo(ByVal TipoRelacion As Int32) As Boolean
    '    If TipoRelacion = 4 Then
    '        Return True
    '    Else
    '        Return False
    '    End If
    'End Function

#Region "Cobranza Externa"
    Private Sub GeneraArchivos()
        If _tipoOperacionCobranza = TipoCapturaCobranza.Precaptura Then
            Exit Sub
        End If

        Dim exp As New ExportaDatos()
        Dim sf As New SaveFileDialog()

        Dim ec As New ExportacionCobranzaExterna(_UsuarioCaptura, SigaMetClasses.DataLayer.Conexion)

        If (oSeguridad.TieneAcceso("ExportaCobranza")) Then
            If (MessageBox.Show("¿Desea exportar la Lista de Cobranza seleccionada?", "Relacion Cobranza", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then

                sf.FileName = "RC" & _Cobranza & DateTime.Now.Day.ToString() & DateTime.Now.Month.ToString() & DateTime.Now.Year.ToString()

                Try
                    If (sf.ShowDialog() = DialogResult.OK) Then
                        _Cobranza = CType(grdCobranza.Item(grdCobranza.CurrentRowIndex, 0), Integer)
                        ec.CargarExportarCobranza(_Cobranza)
                        If (Not ec.ClientesCobranza.Rows.Count > 0) Then
                            'Si no se han guardado las tablas con los detalles de la cobranza
                            ec.ConsultarCobranza(_Cobranza)
                            ec.ProcesarArchivo(_Cobranza, _UsuarioCaptura) 'guardar el detalle
                            ec.CargarExportarCobranza(_Cobranza)
                        End If

                        ec.GenerarArchivoPedidosCobranza(sf.FileName & "CRG.txt", _Cobranza)
                        ec.GenerarArchivoClientesCobranza(sf.FileName & "CTE.txt", _Cobranza)
                        ec.GenerarArchivodtDetalleClientesCobranza(sf.FileName & "DCT.txt", _Cobranza)
                        MessageBox.Show("Se han generado los archivos correctamente", "Relacion Cobranza", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Relacion Cobranza", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try
            End If
        Else
            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, "Relacion Cobranza", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub
#End Region

    Private Sub ConsultaDocumento(ByVal PedidoReferencia As String)
        Cursor = Cursors.WaitCursor
        Dim oConDoc As New SigaMetClasses.ConsultaCargo(PedidoReferencia)
        oConDoc.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmRelacionCobranza_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpFCobranza.Value = FechaOperacion.Date
        CargaDatos(dtpFCobranza.Value)
        If Main.GLOBAL_CajaUsuario = 0 Then
            tbbCerrarCobranza.Visible = False
        End If
    End Sub

    Private Sub grdCobranza_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdCobranza.CurrentCellChanged
        _Cobranza = CType(grdCobranza.Item(grdCobranza.CurrentRowIndex, 0), Integer)
        _Empleado = CType(grdCobranza.Item(grdCobranza.CurrentRowIndex, 3), Integer)
        _UsuarioCaptura = Trim(CType(grdCobranza.Item(grdCobranza.CurrentRowIndex, 5), String))
        _Status = Trim(CType(grdCobranza.Item(grdCobranza.CurrentRowIndex, 6), String))
        _TipoCobranza = CType(grdCobranza.Item(grdCobranza.CurrentRowIndex, 15), Integer)

        Dim Filtro As String = "Cobranza = " & _Cobranza.ToString
        grdCobranza.Select(grdCobranza.CurrentRowIndex)
        'FILTRO POR NÚMERO DE COBRANZA, AQUÍ DEBERÍA CARGAR LOS DATOS DE ESA COBRANZA DE LA BASE DE SIGAMET
        CargarDetallePedidos(_Cobranza)
        '_dsCobranza.Tables("PedidoCobranza").DefaultView.RowFilter = Filtro
        Try
            Dim oGateway As RTGMGateway.RTGMGateway
            Dim oSolicitud As RTGMGateway.SolicitudGateway
            Dim oDireccionEntrega As RTGMCore.DireccionEntrega

            If _UrlGateway <> "" Then
                Dim drow As DataRow

                oGateway = New RTGMGateway.RTGMGateway(GLOBAL_Modulo, ConString)
                oSolicitud = New RTGMGateway.SolicitudGateway()
                oGateway.URLServicio = _UrlGateway
                oSolicitud.IDEmpresa = GLOBAL_Corporativo
                If _dsCobranza.Tables("PedidoCobranza").Rows.Count > 0 Then
                    For Each drow In _dsCobranza.Tables("PedidoCobranza").Rows
                        CLIENTETEMP = (CType(drow("Cliente"), Integer))
                        oSolicitud.IDCliente = CLIENTETEMP
                        oDireccionEntrega = oGateway.buscarDireccionEntrega(oSolicitud)
                        If Not IsNothing(oDireccionEntrega) Then
                            drow("Nombre") = If(IsNothing(oDireccionEntrega.Nombre), Nothing, oDireccionEntrega.Nombre.Trim())
                        End If
                    Next
                End If
            End If
            grdPedidoCobranza.DataSource = _dsCobranza.Tables("PedidoCobranza")
            grdPedidoCobranza.CaptionText = "Documentos incluidos en la relación de cobranza: " & _Cobranza.ToString & " (" & _dsCobranza.Tables("PedidoCobranza").DefaultView.Count.ToString & " documentos en total)"
        Catch ex As Exception
            MessageBox.Show("Error" + ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        lblObservaciones.Text = CType(grdCobranza.Item(grdCobranza.CurrentRowIndex, 9), String)
        lblFActualizacion.Text = CType(grdCobranza.Item(grdCobranza.CurrentRowIndex, 10), Date).ToString
        If Not IsDBNull(grdCobranza.Item(grdCobranza.CurrentRowIndex, 12)) Then
            lblUsuarioCancelacion.Text = Trim(CType(grdCobranza.Item(grdCobranza.CurrentRowIndex, 12), String))
            lblMotivoCancelacion.Text = CType(grdCobranza.Item(grdCobranza.CurrentRowIndex, 13), String)
            lblFCancelacion.Text = CType(grdCobranza.Item(grdCobranza.CurrentRowIndex, 14), Date).ToString
        Else
            lblUsuarioCancelacion.Text = String.Empty
            lblMotivoCancelacion.Text = String.Empty
            lblFCancelacion.Text = String.Empty
        End If

        datosDocumento(String.Empty)

        tbbModificar.Enabled = True
        tbbCancelar.Enabled = True
        tbbCerrarCobranza.Enabled = True
        tbbImprimir.Enabled = True

    End Sub

    Private Sub grdPedidoCobranza_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdPedidoCobranza.CurrentCellChanged
        grdPedidoCobranza.Select(grdPedidoCobranza.CurrentRowIndex)
        _PedidoReferencia = Trim(CType(grdPedidoCobranza.Item(grdPedidoCobranza.CurrentRowIndex, 0), String))
        If Len(_PedidoReferencia) > 0 Then
            tbbConsultarDocumento.Enabled = True
            datosDocumento(_PedidoReferencia)
        End If

    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        CargaDatos(dtpFCobranza.Value.Date)
    End Sub

    Private Sub datosDocumento(ByVal PedidoReferencia As String)
        If PedidoReferencia.Trim.Length > 0 Then
            Dim drv As DataRowView
            For Each drv In _dsCobranza.Tables("PedidoCobranza").DefaultView
                If CType(drv("PedidoReferencia"), String).Trim = PedidoReferencia.Trim Then
                    lblGestionFinal.Text = CType(IIf(IsDBNull(drv("GestionFinalDescripcion")), "", drv("GestionFinalDescripcion")), String)
                    lblFCompromisoGestion.Text = CType(IIf(IsDBNull(drv("FCompromisoGestion")), "", drv("FCompromisoGestion")), String)
                    lblDocumentoGestion.Text = CType(IIf(IsDBNull(drv("DocumentoGestion")), "", drv("DocumentoGestion")), String)
                    lblObservacionesDoc.Text = CType(IIf(IsDBNull(drv("Observaciones")), "", drv("Observaciones")), String)
                    Exit For
                End If
            Next
        Else
            lblGestionFinal.Text = String.Empty
            lblFCompromisoGestion.Text = String.Empty
            lblDocumentoGestion.Text = String.Empty
            lblObservacionesDoc.Text = String.Empty
        End If
    End Sub

    Private Sub chkSolicitud_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSolicitud.CheckedChanged
        If chkSolicitud.Checked Then
            grdCobranza.Text = "Lista de solicitudes de documentos de cobranza"
            Me.Text = "Solicitudes de documentos de cobranza"
            _tipoOperacionCobranza = TipoCapturaCobranza.Precaptura
            tbbCerrarCobranza.Text = "Entregar cob."
        Else
            grdCobranza.Text = "Lista de relaciones de cobranza"
            Me.Text = "Relaciones de cobranza"
            _tipoOperacionCobranza = TipoCapturaCobranza.Captura
            tbbCerrarCobranza.Text = "Cerrar cob."
        End If
        CargaDatos(dtpFCobranza.Value.Date)
    End Sub

    Private Sub integrarLista()
        If Not _tipoOperacionCobranza = TipoCapturaCobranza.Precaptura Then
            Exit Sub
        End If

        If Not oSeguridad.TieneAcceso("INTEGRAR_SOL_COB") Then
            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If Not _dsCobranza.Tables("Cobranza").Rows.Count > 0 Then
            Exit Sub
        End If

        If MessageBox.Show("¿Desea generar integrar por empleado" & vbCrLf & _
                    "las solicitudes cobranza precapturadas?", "Integración de solicitudes de cobranza", _
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            'el objeto implementa todas las funciones de generación de cobranza
            Dim integracionSolCobranza As RelacionCobranza.IntegracionPreCapturaCobranza = _
                New RelacionCobranza.IntegracionPreCapturaCobranza(SigaMetClasses.DataLayer.Conexion, _
                dtpFCobranza.Value.Date, GLOBAL_IDUsuario, 1)
            integracionSolCobranza.CargarListaDocumentos(dtpFCobranza.Value.Date)

            If MessageBox.Show("Se generarán las siguientes solicitudes de cobranza:" & vbCrLf & vbCrLf & _
                integracionSolCobranza.MensajeListaDocumentos() & vbCrLf & _
                "¿Desea continuar?", "Integración de solicitudes de cobranza", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Dim _mensajeError As String = Nothing

                'Procesar la lista de cobranza
                Try
                    integracionSolCobranza.ProcesarLista()
                Catch ex As Exception
                    _mensajeError = ex.Message
                End Try

                'Actualizar vista en pantalla
                CargaDatos(dtpFCobranza.Value.Date)

                'Detectar error de proceso
                If integracionSolCobranza.ErrorProceso Then
                    MessageBox.Show("Ha ocurrido un error:" & vbCrLf & _
                                        _mensajeError & vbCrLf & _
                                        "No fué posible procesar todas las solicitudes de cobranza", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    If MessageBox.Show("Se generaron las siguientes solicitudes:" & vbCrLf & _
                                        integracionSolCobranza.MensajeListaSolicitudesGeneradas & vbCrLf & _
                                        "¿Desea imprimirlas?", _
                                        Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        'Imprimir las listas de cobranza generadas
                        Dim prDr As DataRow
                        For Each prDr In integracionSolCobranza.ListaEmpleados.Rows
                            imprimirComprobanteSolicitudCobranza(Convert.ToInt32(prDr("SolicitudCobranza")))
                        Next
                    End If
                End If

                'Detectar error de cancelación
                If integracionSolCobranza.ErrorCancelacion Then
                    MessageBox.Show("Ha ocurrido un error:" & vbCrLf & _
                                        _mensajeError & vbCrLf & _
                                        "Cancele manualmente las solicitudes siguientes:" & vbCrLf & _
                                        integracionSolCobranza.MensajeListaSolicitudesParaCancelar(), _
                                        Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub

    Private Sub imprimirComprobanteSolicitudCobranza(ByVal NuevaCobranza As Integer)
        'Solo se despliega la pantalla cuando se genera la lista
        If NuevaCobranza > 0 Then
            Cursor = Cursors.WaitCursor
            Dim frmReporte As New frmConsultaReporte(frmConsultaReporte.enumTipoReporte.SolicitudCobranza, 0, DateTime.Now.Date, NuevaCobranza, 0)
            frmReporte.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub Modificacion(ByVal Cancelacion As Boolean)
        If _UsuarioCaptura = Main.GLOBAL_IDUsuario AndAlso Not (oSeguridad.TieneAcceso("PRECAPT_MODIF_PROPIAS") OrElse
                oSeguridad.TieneAcceso("PRECAPT_MODIF_TODAS")) Then
            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If _UsuarioCaptura <> Main.GLOBAL_IDUsuario AndAlso Not oSeguridad.TieneAcceso("PRECAPT_MODIF_TODAS") Then
            MessageBox.Show(SigaMetClasses.M_NO_PRIVILEGIOS, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If Cancelacion Then
            Cancelar()
        Else
            Modificar()
        End If
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

    Public Sub MensajeURLGATEWAY()
        If _UrlGateway = "" Then
            If _UrlGateway Is Nothing Then
            Else
                MessageBox.Show("El parámetro URLGateway está vacío.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub
End Class
