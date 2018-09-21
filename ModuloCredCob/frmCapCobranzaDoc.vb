Option Strict On
Option Explicit On 
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic.ControlChars

Public Class frmCapCobranzaDoc
    Inherits System.Windows.Forms.Form
    Private Titulo As String = "Captura de cobranza"
    Private ModoLibre As Boolean = False
    Private AbonosParcialesDocumento As Decimal
    Private _TipoMovimientoCaja As Byte
    Private _SoloDocumentosCartera As Boolean
    Private _ListaCobros As ListBox
    Private _RelacionCobranza As ArrayList
    Public ListaCobroPedido As New ArrayList()
    Private _ImporteNC As Decimal
    Private _ObservacionesNC As String
    Private _FolioNC As Integer
    Private _SerieNC As String
    Private _FacturaNC As Integer
    Private _FFacturaNC As DateTime

    'Para control de saldos a favor 30/03/2005
    Private _AceptaSaldoAFavor As Boolean
    Private _Cliente As Integer
    Private _ClientesRelacionados As DataTable

    'Para desplegar el importe con descuento
    Private frmDescuento As ImporteDescuento.frmDiscount

    Private frmSaldosPendientes As CyCSaldoAFavor.SaldosPendientes

    'Vales de crédito con serie
    Private _folioDocumento As DocumentosBSR.SerieDocumento
    Private _URLGateway As String = ""
#Region "Variables y propiedades"
    Dim decImporteTotalCobranza As Decimal
    Dim aListaPedidos As New ArrayList()

    Dim ListaValesCredito As New ArrayList() 'Lista de los números de vale de crédito recuperados

    Dim ListaCobro As New ArrayList() 'Lista de los diferentes cobros (efectivo, vale o cheque)
    Dim objPedido As SigaMetClasses.sPedido
    Private _TipoCobro As SigaMetClasses.Enumeradores.enumTipoCobro
    Private _ImporteCobro As Decimal 'Indica el importe total del cobro (e,v o ch.)
    Private _ImporteRestante As Decimal 'Indica cuanto hace falta por aplicar del documento (efectivo, vale o cheque)
    'Se agregó para control de saldos a favor
    Private _SaldoAFavor As Boolean

    Public Property TipoCobro() As SigaMetClasses.Enumeradores.enumTipoCobro
        Get
            Return _TipoCobro
        End Get
        Set(ByVal Value As SigaMetClasses.Enumeradores.enumTipoCobro)
            _TipoCobro = Value
            If _TipoCobro <> SigaMetClasses.Enumeradores.enumTipoCobro.EfectivoVales Then
                chkAutocalcular.Enabled = False
            End If
        End Set
    End Property

    Public Property ImporteCobro() As Decimal
        Get
            Return _ImporteCobro
        End Get
        Set(ByVal Value As Decimal)
            _ImporteCobro = Value
            _ImporteRestante = Value
        End Set
    End Property

    Public ReadOnly Property ImporteRestante() As Decimal
        Get
            Return _ImporteRestante
        End Get
    End Property

    'Para control de saldos a favor 30/03/2005
    Public ReadOnly Property SaldoAFavor() As Boolean
        Get
            Return _SaldoAFavor
        End Get
    End Property

    Public Property Cliente() As Integer
        Get
            Return _Cliente
        End Get
        Set(ByVal Value As Integer)
            _Cliente = Value
        End Set
    End Property

    Public Property ClientesRelacionados(ByVal Cliente As Integer) As DataTable
        Get
            Return _ClientesRelacionados
        End Get
        Set(ByVal Value As DataTable)
            _ClientesRelacionados = Value
            _Cliente = Cliente
            txtCliente.Text = CStr(Cliente)
        End Set
    End Property
    '*************

#End Region

    Public Sub New(ByVal TipoMovimientoCaja As Byte, _
                   ByVal SoloDocumentosCartera As Boolean, _
                   ByVal ListaCobros As ListBox, _
                   Optional ByVal AceptaSaldoAFavor As Boolean = False)

        MyBase.New()
        InitializeComponent()
        _TipoMovimientoCaja = TipoMovimientoCaja
        _SoloDocumentosCartera = SoloDocumentosCartera
        _ListaCobros = ListaCobros

        _AceptaSaldoAFavor = AceptaSaldoAFavor

        'La búsqueda será solo por pedidoreferencia para los tipos de movimiento de cargos
        'para los que no aplica valecredito
        tipoBusquedaDefault(tipoMovAplicaValeCredito(TipoMovimientoCaja))

        'Para definir cuales tipocobro acep
    End Sub

    Public Sub New(ByVal TipoMovimientoCaja As Byte,
                   ByVal SoloDocumentosCartera As Boolean,
                   ByVal ListaCobros As ListBox,
                   ByVal RelacionCobranza As ArrayList)

        MyBase.New()
        InitializeComponent()
        _TipoMovimientoCaja = TipoMovimientoCaja
        _SoloDocumentosCartera = SoloDocumentosCartera
        _ListaCobros = ListaCobros
        _RelacionCobranza = RelacionCobranza

        'La captura de cobros de relación de cobranza es por pedidoreferencia
        tipoBusquedaDefault(False)

        Dim oPedido As SigaMetClasses.sPedido
        For Each oPedido In _RelacionCobranza
            lstRelacionCobranza.Items.Add(oPedido.PedidoReferencia)
        Next

        pnlRelacionCobranza.Visible = True
        pnlRelacionCobranza.BringToFront() '
        lblMensajeRelacionCobranza.AutoSize = False
        lblMensajeRelacionCobranza.Visible = True
        lblMensajeRelacionCobranza2.Visible = True
        txtPedidoReferencia.Enabled = False
        lstRelacionCobranza.SelectedItem = 0
        lstRelacionCobranza.Focus()
        AcceptButton = btnBuscar

    End Sub

    Public Sub New(ByVal TipoMovimientoCaja As Byte,
                   ByVal ImporteNC As Decimal,
                   ByVal Cliente As Integer,
                   ByVal ObservacionesNC As String,
                   ByVal FolioNC As Integer,
                   ByVal SerieNC As String,
                   ByVal FacturaNC As Integer,
                   ByVal FFactura As DateTime,
                   ByVal ListaCobros As ListBox)

        MyBase.New()
        InitializeComponent()
        _TipoMovimientoCaja = TipoMovimientoCaja
        _ImporteNC = ImporteNC
        _Cliente = Cliente
        _ObservacionesNC = ObservacionesNC
        _FolioNC = FolioNC
        _SerieNC = SerieNC
        _FacturaNC = FacturaNC
        _FFacturaNC = FFactura
        _ListaCobros = ListaCobros

        chkAutocalcular.Enabled = False
        txtCliente.Enabled = False
        chkPedidoReferencia.Checked = True

        'La búsqueda será solo por pedidoreferencia para los tipos de movimiento de cargos
        'para los que no aplica valecredito
        tipoBusquedaDefault(tipoMovAplicaValeCredito(TipoMovimientoCaja))

        'Para definir cuales tipocobro acep
    End Sub

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    'Public Sub New(ByVal intConsecutivo As Integer)
    '    MyBase.New()
    '    InitializeComponent()
    '    Consecutivo = intConsecutivo
    'End Sub

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
    Friend WithEvents ttDatosPedido As System.Windows.Forms.ToolTip
    Friend WithEvents cmListaPedidos As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuEliminar As System.Windows.Forms.MenuItem
    Friend WithEvents btnCancelar As ControlesBase.BotonBase
    Friend WithEvents btnAceptar As ControlesBase.BotonBase
    Friend WithEvents txtPedidoReferencia As ControlesBase.TextBoxBase
    Friend WithEvents lstDocumento As System.Windows.Forms.ListBox
    Friend WithEvents lblImporteTotalCobranza As System.Windows.Forms.Label
    Friend WithEvents lblImportePorAplicar As System.Windows.Forms.Label
    Friend WithEvents lblTotalCobro As System.Windows.Forms.Label
    Friend WithEvents lblTipoCobro As System.Windows.Forms.Label
    Friend WithEvents Label5 As ControlesBase.LabelBase
    Friend WithEvents Label3 As ControlesBase.LabelBase
    Friend WithEvents Label4 As ControlesBase.LabelBase
    Friend WithEvents Label6 As ControlesBase.LabelBase
    Friend WithEvents grpDatosCobro As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As ControlesBase.LabelBase
    Friend WithEvents Label1 As ControlesBase.LabelBase
    Friend WithEvents Label7 As ControlesBase.LabelBase
    Friend WithEvents lblPedidoReferenciaImporte As System.Windows.Forms.Label
    Friend WithEvents txtImporteAbono As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents txtCliente As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents LabelBase1 As ControlesBase.LabelBase
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkAutocalcular As System.Windows.Forms.CheckBox
    Friend WithEvents LabelBase2 As ControlesBase.LabelBase
    Friend WithEvents lblPedidoSaldoReal As System.Windows.Forms.Label
    Friend WithEvents LabelBase3 As ControlesBase.LabelBase
    Friend WithEvents lblPedidoSaldoMovimiento As System.Windows.Forms.Label
    Friend WithEvents lstRelacionCobranza As System.Windows.Forms.ListBox
    Friend WithEvents pnlRelacionCobranza As System.Windows.Forms.Panel
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnConsultaDescuento As System.Windows.Forms.Button
    Friend WithEvents chkPedidoReferencia As System.Windows.Forms.CheckBox
    Friend WithEvents lblTipoCriterio As System.Windows.Forms.Label
    Friend WithEvents lblMensajeRelacionCobranza2 As ControlesBase.LabelBase
    Friend WithEvents btnBusquedaLocal As System.Windows.Forms.Button
    Friend WithEvents btnClienteFecha As System.Windows.Forms.Button
    Friend WithEvents lblMensajeRelacionCobranza As ControlesBase.LabelBase
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCapCobranzaDoc))
        Me.txtPedidoReferencia = New ControlesBase.TextBoxBase()
        Me.lstDocumento = New System.Windows.Forms.ListBox()
        Me.cmListaPedidos = New System.Windows.Forms.ContextMenu()
        Me.mnuEliminar = New System.Windows.Forms.MenuItem()
        Me.lblImporteTotalCobranza = New System.Windows.Forms.Label()
        Me.ttDatosPedido = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnConsultaDescuento = New System.Windows.Forms.Button()
        Me.Label5 = New ControlesBase.LabelBase()
        Me.btnCancelar = New ControlesBase.BotonBase()
        Me.btnAceptar = New ControlesBase.BotonBase()
        Me.Label3 = New ControlesBase.LabelBase()
        Me.Label4 = New ControlesBase.LabelBase()
        Me.Label6 = New ControlesBase.LabelBase()
        Me.lblImportePorAplicar = New System.Windows.Forms.Label()
        Me.grpDatosCobro = New System.Windows.Forms.GroupBox()
        Me.Label2 = New ControlesBase.LabelBase()
        Me.Label1 = New ControlesBase.LabelBase()
        Me.lblTotalCobro = New System.Windows.Forms.Label()
        Me.lblTipoCobro = New System.Windows.Forms.Label()
        Me.chkAutocalcular = New System.Windows.Forms.CheckBox()
        Me.Label7 = New ControlesBase.LabelBase()
        Me.lblPedidoReferenciaImporte = New System.Windows.Forms.Label()
        Me.txtImporteAbono = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.txtCliente = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.LabelBase1 = New ControlesBase.LabelBase()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnClienteFecha = New System.Windows.Forms.Button()
        Me.lblPedidoSaldoReal = New System.Windows.Forms.Label()
        Me.LabelBase2 = New ControlesBase.LabelBase()
        Me.lblPedidoSaldoMovimiento = New System.Windows.Forms.Label()
        Me.LabelBase3 = New ControlesBase.LabelBase()
        Me.lstRelacionCobranza = New System.Windows.Forms.ListBox()
        Me.pnlRelacionCobranza = New System.Windows.Forms.Panel()
        Me.lblMensajeRelacionCobranza = New ControlesBase.LabelBase()
        Me.lblMensajeRelacionCobranza2 = New ControlesBase.LabelBase()
        Me.btnBusquedaLocal = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.chkPedidoReferencia = New System.Windows.Forms.CheckBox()
        Me.lblTipoCriterio = New System.Windows.Forms.Label()
        Me.grpDatosCobro.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.pnlRelacionCobranza.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtPedidoReferencia
        '
        Me.txtPedidoReferencia.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPedidoReferencia.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtPedidoReferencia.Location = New System.Drawing.Point(16, 208)
        Me.txtPedidoReferencia.Name = "txtPedidoReferencia"
        Me.txtPedidoReferencia.Size = New System.Drawing.Size(184, 30)
        Me.txtPedidoReferencia.TabIndex = 0
        '
        'lstDocumento
        '
        Me.lstDocumento.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstDocumento.ContextMenu = Me.cmListaPedidos
        Me.lstDocumento.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstDocumento.ItemHeight = 14
        Me.lstDocumento.Location = New System.Drawing.Point(8, 336)
        Me.lstDocumento.Name = "lstDocumento"
        Me.lstDocumento.Size = New System.Drawing.Size(472, 88)
        Me.lstDocumento.TabIndex = 2
        '
        'cmListaPedidos
        '
        Me.cmListaPedidos.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuEliminar})
        '
        'mnuEliminar
        '
        Me.mnuEliminar.Index = 0
        Me.mnuEliminar.Text = "Eliminar pedido"
        '
        'lblImporteTotalCobranza
        '
        Me.lblImporteTotalCobranza.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblImporteTotalCobranza.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.lblImporteTotalCobranza.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblImporteTotalCobranza.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteTotalCobranza.Location = New System.Drawing.Point(336, 432)
        Me.lblImporteTotalCobranza.Name = "lblImporteTotalCobranza"
        Me.lblImporteTotalCobranza.Size = New System.Drawing.Size(144, 24)
        Me.lblImporteTotalCobranza.TabIndex = 32
        Me.lblImporteTotalCobranza.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnConsultaDescuento
        '
        Me.btnConsultaDescuento.BackColor = System.Drawing.SystemColors.Control
        Me.btnConsultaDescuento.Image = CType(resources.GetObject("btnConsultaDescuento.Image"), System.Drawing.Image)
        Me.btnConsultaDescuento.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnConsultaDescuento.Location = New System.Drawing.Point(496, 238)
        Me.btnConsultaDescuento.Name = "btnConsultaDescuento"
        Me.btnConsultaDescuento.Size = New System.Drawing.Size(28, 24)
        Me.btnConsultaDescuento.TabIndex = 63
        Me.btnConsultaDescuento.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.ttDatosPedido.SetToolTip(Me.btnConsultaDescuento, "Información sobre descuentos")
        Me.btnConsultaDescuento.UseVisualStyleBackColor = False
        Me.btnConsultaDescuento.Visible = False
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(176, 437)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(151, 13)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Importe total en pedidos:"
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(496, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(496, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 184)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 19)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Documento"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(248, 243)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(137, 13)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "Importe para el abono:"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(176, 469)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 13)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "Por aplicar:"
        '
        'lblImportePorAplicar
        '
        Me.lblImportePorAplicar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblImportePorAplicar.BackColor = System.Drawing.Color.Khaki
        Me.lblImportePorAplicar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblImportePorAplicar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImportePorAplicar.ForeColor = System.Drawing.Color.Red
        Me.lblImportePorAplicar.Location = New System.Drawing.Point(336, 464)
        Me.lblImportePorAplicar.Name = "lblImportePorAplicar"
        Me.lblImportePorAplicar.Size = New System.Drawing.Size(144, 24)
        Me.lblImportePorAplicar.TabIndex = 39
        Me.lblImportePorAplicar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpDatosCobro
        '
        Me.grpDatosCobro.Controls.Add(Me.Label2)
        Me.grpDatosCobro.Controls.Add(Me.Label1)
        Me.grpDatosCobro.Controls.Add(Me.lblTotalCobro)
        Me.grpDatosCobro.Controls.Add(Me.lblTipoCobro)
        Me.grpDatosCobro.Controls.Add(Me.chkAutocalcular)
        Me.grpDatosCobro.Location = New System.Drawing.Point(8, 8)
        Me.grpDatosCobro.Name = "grpDatosCobro"
        Me.grpDatosCobro.Size = New System.Drawing.Size(472, 96)
        Me.grpDatosCobro.TabIndex = 41
        Me.grpDatosCobro.TabStop = False
        Me.grpDatosCobro.Text = "Datos del cobro por aplicar"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(304, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "Total:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Tipo de cobro:"
        '
        'lblTotalCobro
        '
        Me.lblTotalCobro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalCobro.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCobro.Location = New System.Drawing.Point(352, 32)
        Me.lblTotalCobro.Name = "lblTotalCobro"
        Me.lblTotalCobro.Size = New System.Drawing.Size(112, 21)
        Me.lblTotalCobro.TabIndex = 46
        Me.lblTotalCobro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTipoCobro
        '
        Me.lblTipoCobro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTipoCobro.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoCobro.Location = New System.Drawing.Point(96, 32)
        Me.lblTipoCobro.Name = "lblTipoCobro"
        Me.lblTipoCobro.Size = New System.Drawing.Size(112, 21)
        Me.lblTipoCobro.TabIndex = 45
        Me.lblTipoCobro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkAutocalcular
        '
        Me.chkAutocalcular.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAutocalcular.Location = New System.Drawing.Point(16, 64)
        Me.chkAutocalcular.Name = "chkAutocalcular"
        Me.chkAutocalcular.Size = New System.Drawing.Size(368, 24)
        Me.chkAutocalcular.TabIndex = 57
        Me.chkAutocalcular.Text = "Autocalcular el importe del cobro con la captura de los documentos"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(248, 171)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(122, 13)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "Importe del documento:"
        '
        'lblPedidoReferenciaImporte
        '
        Me.lblPedidoReferenciaImporte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPedidoReferenciaImporte.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPedidoReferenciaImporte.Location = New System.Drawing.Point(384, 168)
        Me.lblPedidoReferenciaImporte.Name = "lblPedidoReferenciaImporte"
        Me.lblPedidoReferenciaImporte.Size = New System.Drawing.Size(96, 21)
        Me.lblPedidoReferenciaImporte.TabIndex = 49
        Me.lblPedidoReferenciaImporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtImporteAbono
        '
        Me.txtImporteAbono.BackColor = System.Drawing.SystemColors.Window
        Me.txtImporteAbono.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporteAbono.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtImporteAbono.Location = New System.Drawing.Point(384, 240)
        Me.txtImporteAbono.Name = "txtImporteAbono"
        Me.txtImporteAbono.Size = New System.Drawing.Size(96, 21)
        Me.txtImporteAbono.TabIndex = 50
        Me.txtImporteAbono.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 272)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(472, 56)
        Me.GroupBox1.TabIndex = 51
        Me.GroupBox1.TabStop = False
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(8, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(456, 32)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Lista de documentos agregados a la cobranza.  Dé doble clic en los registros de l" &
    "a lista para desplegar más información acerca de los documentos."
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscarCliente.Image = CType(resources.GetObject("btnBuscarCliente.Image"), System.Drawing.Image)
        Me.btnBuscarCliente.Location = New System.Drawing.Point(405, 16)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(26, 21)
        Me.btnBuscarCliente.TabIndex = 53
        Me.btnBuscarCliente.UseVisualStyleBackColor = False
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.Color.Black
        Me.txtCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.ForeColor = System.Drawing.Color.Gold
        Me.txtCliente.Location = New System.Drawing.Point(280, 16)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(120, 21)
        Me.txtCliente.TabIndex = 54
        '
        'LabelBase1
        '
        Me.LabelBase1.AutoSize = True
        Me.LabelBase1.ForeColor = System.Drawing.Color.MediumBlue
        Me.LabelBase1.Location = New System.Drawing.Point(24, 19)
        Me.LabelBase1.Name = "LabelBase1"
        Me.LabelBase1.Size = New System.Drawing.Size(233, 13)
        Me.LabelBase1.TabIndex = 55
        Me.LabelBase1.Text = "Desplegar los documentos del siguiente cliente:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnClienteFecha)
        Me.GroupBox2.Controls.Add(Me.LabelBase1)
        Me.GroupBox2.Controls.Add(Me.txtCliente)
        Me.GroupBox2.Controls.Add(Me.btnBuscarCliente)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 112)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(472, 48)
        Me.GroupBox2.TabIndex = 56
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Búsqueda avanzada de documentos (F3)"
        '
        'btnClienteFecha
        '
        Me.btnClienteFecha.BackColor = System.Drawing.SystemColors.Control
        Me.btnClienteFecha.Image = CType(resources.GetObject("btnClienteFecha.Image"), System.Drawing.Image)
        Me.btnClienteFecha.Location = New System.Drawing.Point(440, 16)
        Me.btnClienteFecha.Name = "btnClienteFecha"
        Me.btnClienteFecha.Size = New System.Drawing.Size(26, 21)
        Me.btnClienteFecha.TabIndex = 56
        Me.btnClienteFecha.UseVisualStyleBackColor = False
        '
        'lblPedidoSaldoReal
        '
        Me.lblPedidoSaldoReal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPedidoSaldoReal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPedidoSaldoReal.ForeColor = System.Drawing.Color.Red
        Me.lblPedidoSaldoReal.Location = New System.Drawing.Point(384, 192)
        Me.lblPedidoSaldoReal.Name = "lblPedidoSaldoReal"
        Me.lblPedidoSaldoReal.Size = New System.Drawing.Size(96, 21)
        Me.lblPedidoSaldoReal.TabIndex = 58
        Me.lblPedidoSaldoReal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelBase2
        '
        Me.LabelBase2.AutoSize = True
        Me.LabelBase2.Location = New System.Drawing.Point(248, 195)
        Me.LabelBase2.Name = "LabelBase2"
        Me.LabelBase2.Size = New System.Drawing.Size(131, 13)
        Me.LabelBase2.TabIndex = 57
        Me.LabelBase2.Text = "Saldo real del documento:"
        '
        'lblPedidoSaldoMovimiento
        '
        Me.lblPedidoSaldoMovimiento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPedidoSaldoMovimiento.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPedidoSaldoMovimiento.ForeColor = System.Drawing.Color.ForestGreen
        Me.lblPedidoSaldoMovimiento.Location = New System.Drawing.Point(384, 216)
        Me.lblPedidoSaldoMovimiento.Name = "lblPedidoSaldoMovimiento"
        Me.lblPedidoSaldoMovimiento.Size = New System.Drawing.Size(96, 21)
        Me.lblPedidoSaldoMovimiento.TabIndex = 60
        Me.lblPedidoSaldoMovimiento.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelBase3
        '
        Me.LabelBase3.AutoSize = True
        Me.LabelBase3.Location = New System.Drawing.Point(248, 219)
        Me.LabelBase3.Name = "LabelBase3"
        Me.LabelBase3.Size = New System.Drawing.Size(120, 13)
        Me.LabelBase3.TabIndex = 59
        Me.LabelBase3.Text = "Saldo en el movimiento:"
        '
        'lstRelacionCobranza
        '
        Me.lstRelacionCobranza.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lstRelacionCobranza.Dock = System.Windows.Forms.DockStyle.Right
        Me.lstRelacionCobranza.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstRelacionCobranza.ForeColor = System.Drawing.Color.MediumBlue
        Me.lstRelacionCobranza.Location = New System.Drawing.Point(240, 0)
        Me.lstRelacionCobranza.Name = "lstRelacionCobranza"
        Me.lstRelacionCobranza.Size = New System.Drawing.Size(232, 56)
        Me.lstRelacionCobranza.TabIndex = 56
        '
        'pnlRelacionCobranza
        '
        Me.pnlRelacionCobranza.Controls.Add(Me.lblMensajeRelacionCobranza)
        Me.pnlRelacionCobranza.Controls.Add(Me.lstRelacionCobranza)
        Me.pnlRelacionCobranza.Controls.Add(Me.lblMensajeRelacionCobranza2)
        Me.pnlRelacionCobranza.Controls.Add(Me.btnBusquedaLocal)
        Me.pnlRelacionCobranza.Location = New System.Drawing.Point(8, 112)
        Me.pnlRelacionCobranza.Name = "pnlRelacionCobranza"
        Me.pnlRelacionCobranza.Size = New System.Drawing.Size(472, 56)
        Me.pnlRelacionCobranza.TabIndex = 61
        Me.pnlRelacionCobranza.Visible = False
        '
        'lblMensajeRelacionCobranza
        '
        Me.lblMensajeRelacionCobranza.AutoSize = True
        Me.lblMensajeRelacionCobranza.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblMensajeRelacionCobranza.Location = New System.Drawing.Point(8, 8)
        Me.lblMensajeRelacionCobranza.Name = "lblMensajeRelacionCobranza"
        Me.lblMensajeRelacionCobranza.Size = New System.Drawing.Size(163, 13)
        Me.lblMensajeRelacionCobranza.TabIndex = 67
        Me.lblMensajeRelacionCobranza.Text = "Lista de documentos incluidos en"
        Me.lblMensajeRelacionCobranza.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblMensajeRelacionCobranza.Visible = False
        '
        'lblMensajeRelacionCobranza2
        '
        Me.lblMensajeRelacionCobranza2.AutoSize = True
        Me.lblMensajeRelacionCobranza2.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblMensajeRelacionCobranza2.Location = New System.Drawing.Point(8, 28)
        Me.lblMensajeRelacionCobranza2.Name = "lblMensajeRelacionCobranza2"
        Me.lblMensajeRelacionCobranza2.Size = New System.Drawing.Size(121, 13)
        Me.lblMensajeRelacionCobranza2.TabIndex = 66
        Me.lblMensajeRelacionCobranza2.Text = "la relación de cobranza:"
        Me.lblMensajeRelacionCobranza2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblMensajeRelacionCobranza2.Visible = False
        '
        'btnBusquedaLocal
        '
        Me.btnBusquedaLocal.BackColor = System.Drawing.SystemColors.Control
        Me.btnBusquedaLocal.Image = CType(resources.GetObject("btnBusquedaLocal.Image"), System.Drawing.Image)
        Me.btnBusquedaLocal.Location = New System.Drawing.Point(200, 4)
        Me.btnBusquedaLocal.Name = "btnBusquedaLocal"
        Me.btnBusquedaLocal.Size = New System.Drawing.Size(32, 20)
        Me.btnBusquedaLocal.TabIndex = 66
        Me.btnBusquedaLocal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBusquedaLocal.UseVisualStyleBackColor = False
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(208, 208)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 30)
        Me.btnBuscar.TabIndex = 62
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'chkPedidoReferencia
        '
        Me.chkPedidoReferencia.Location = New System.Drawing.Point(16, 248)
        Me.chkPedidoReferencia.Name = "chkPedidoReferencia"
        Me.chkPedidoReferencia.Size = New System.Drawing.Size(184, 16)
        Me.chkPedidoReferencia.TabIndex = 64
        Me.chkPedidoReferencia.Text = "Consulta por número de pedido"
        '
        'lblTipoCriterio
        '
        Me.lblTipoCriterio.AutoSize = True
        Me.lblTipoCriterio.Location = New System.Drawing.Point(120, 188)
        Me.lblTipoCriterio.Name = "lblTipoCriterio"
        Me.lblTipoCriterio.Size = New System.Drawing.Size(0, 13)
        Me.lblTipoCriterio.TabIndex = 65
        '
        'frmCapCobranzaDoc
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(586, 503)
        Me.Controls.Add(Me.lblTipoCriterio)
        Me.Controls.Add(Me.chkPedidoReferencia)
        Me.Controls.Add(Me.btnConsultaDescuento)
        Me.Controls.Add(Me.LabelBase3)
        Me.Controls.Add(Me.LabelBase2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.lblPedidoSaldoMovimiento)
        Me.Controls.Add(Me.lblPedidoSaldoReal)
        Me.Controls.Add(Me.txtImporteAbono)
        Me.Controls.Add(Me.grpDatosCobro)
        Me.Controls.Add(Me.lblImportePorAplicar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.lblImporteTotalCobranza)
        Me.Controls.Add(Me.lstDocumento)
        Me.Controls.Add(Me.txtPedidoReferencia)
        Me.Controls.Add(Me.lblPedidoReferenciaImporte)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.pnlRelacionCobranza)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCapCobranzaDoc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Captura relación de cobranza"
        Me.grpDatosCobro.ResumeLayout(False)
        Me.grpDatosCobro.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.pnlRelacionCobranza.ResumeLayout(False)
        Me.pnlRelacionCobranza.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Funciones"
    Private Function ConsultaPedido(ByVal PedidoReferencia As String) As Boolean
        'Se modifico este query para no tener dependencia en la vista.
        'Se agregó a la consulta la función dbo.validaPedidoEdificioAdministrado(p.PedidoReferencia) AS PedidoEdificio para
        'validar el abono a edificios administrados *JAGD 28-12-2004*
        'Dim strQuery As String = _
        '"SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED " & _
        '"SELECT p.Celula, p.AñoPed, p.Pedido, p.Total, p.Saldo, " & _
        '"p.Cliente, c.Nombre, p.PedidoReferencia, p.CyC, p.TipoCargo, tcargo.Descripcion as TipoCargoDescripcion, " & _
        '"Isnull(tmctc.TipoCargo,0) as SePermite, p.Cartera " & _
        '", dbo.validaPedidoEdificioAdministrado(p.PedidoReferencia) AS PedidoEdificio " & _
        '"FROM Pedido p " & _
        '"JOIN Cliente c ON p.Cliente = c.Cliente " & _
        '"JOIN TipoCargo tcargo ON p.TipoCargo = tcargo.TipoCargo " & _
        '"LEFT JOIN TipoMovimientoCajaTipoCargo tmctc " & _
        '"   JOIN TipoCargo tc ON tmctc.TipoCargo = tc.TipoCargo " & _
        '"ON p.TipoCargo = tmctc.TipoCargo AND tmctc.TipoMovimientoCaja = " & _TipoMovimientoCaja.ToString & _
        '" WHERE p.PedidoReferencia = '" & PedidoReferencia & "'"

        'If _SoloDocumentosCartera Then strQuery &= " AND p.CyC = 1 " '26 de sep

        Dim cn As New SqlConnection(ConString)
        cn.Open()
        'Dim cmd As New SqlCommand(strQuery)
        Dim cmd As New SqlCommand("spCyCConsultaDatosDocumento")

        With cmd
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Add("@TipoMovimientoCaja", SqlDbType.TinyInt).Value = _TipoMovimientoCaja
            cmd.Parameters.Add("@SoloDocumentosCartera", SqlDbType.Bit).Value = _SoloDocumentosCartera

            If chkPedidoReferencia.Checked Then
                cmd.Parameters.Add("@PedidoReferencia", SqlDbType.VarChar, 20).Value = PedidoReferencia
            Else
                'Dim valeCredito As Integer
                Try
                    'valeCredito = CType(PedidoReferencia, Integer)
                    DocumentosBSR.SerieDocumento.SeparaSerie(PedidoReferencia)
                Catch ex As System.OverflowException
                    MessageBox.Show("El número de documento no corresponde a un vale de crédito" & CrLf &
                                    "Verifique por favor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Function
                End Try
                'cmd.Parameters.Add("@ValeCredito", SqlDbType.Int).Value = CType(PedidoReferencia, Integer)
                'cmd.Parameters.Add("@ValeCredito", SqlDbType.Int).Value = valeCredito
                If DocumentosBSR.SerieDocumento.Serie.Length > 0 Then
                    cmd.Parameters.Add("@SerieValeCredito", SqlDbType.VarChar).Value = DocumentosBSR.SerieDocumento.Serie
                End If
                cmd.Parameters.Add("@ValeCredito", SqlDbType.Int).Value = DocumentosBSR.SerieDocumento.FolioNota
            End If

            cmd.Connection = cn

        End With
        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

        Try
            LimpiaPedido()
            Do While dr.Read
                objPedido.Celula = CType(dr("Celula"), Byte)
                objPedido.AnoPed = CType(dr("AñoPed"), Short)
                objPedido.Pedido = CType(dr("Pedido"), Integer)
                objPedido.Importe = CType(dr("Total"), Decimal)
                objPedido.Saldo = CType(dr("Saldo"), Decimal)
                objPedido.ImporteAbono = 0
                objPedido.Cliente = CType(dr("Cliente"), Integer)
                objPedido.Nombre = CType(dr("Nombre"), String)
                objPedido.PedidoReferencia = Trim(CType(dr("PedidoReferencia"), String))
                If Not IsDBNull(dr("CyC")) Then objPedido.Libra = CType(dr("CyC"), Boolean)
                objPedido.TipoCargo = CType(dr("TipoCargo"), Byte)
                objPedido.TipoCargoDescripcion = CType(dr("TipoCargoDescripcion"), String)
                objPedido.SePermiteAbonar = CType(dr("SePermite"), Byte)
                objPedido.Cartera = CType(dr("Cartera"), Byte)

                'Búsqueda de documentos por vale de crédito
                objPedido.ValeCredito = CType(dr("ValeCredito"), Integer)

                'Para validar el abono a edificios administrados JAGD 28/12/2004
                objPedido.PedidoEdificio = CType(dr("PedidoEdificio"), Boolean)

                ' Recuperar nuevo campo IdCRM RM 14/09/2018
                objPedido.IDCRM = DirectCast(dr("IdCRM"), Integer)
            Loop
            If objPedido.PedidoReferencia <> "" Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message)
        Finally
            dr.Close()
            cn.Close()
        End Try
    End Function

    Private Sub LimpiaPedido()
        With objPedido
            .Celula = 0
            .AnoPed = 0
            .Pedido = 0
            .Importe = 0
            .Saldo = 0
            .ImporteAbono = 0
            .Cliente = 0
            .Nombre = ""
            .PedidoReferencia = ""
            .Libra = False
        End With
    End Sub


    Private Function BuscaPedidoGlobal(ByVal PedidoReferencia As String) As Integer
        'Función que busca en los demás cobros si ya se capturó este documento.
        '10 de febrero del 2003
        AbonosParcialesDocumento = 0
        Dim sc As SigaMetClasses.sCobro
        Dim sp As SigaMetClasses.sPedido
        For Each sc In _ListaCobros.Items
            If Not IsNothing(sc.ListaPedidos) Then
                For Each sp In sc.ListaPedidos
                    If sp.PedidoReferencia = PedidoReferencia Then
                        AbonosParcialesDocumento += sp.ImporteAbono
                    End If
                Next
            End If
        Next
    End Function

    Private Function BuscaPedidoLocal(ByVal PedidoReferencia As String) As Integer
        'Funcion que busca en el ArrayList el pedido a ver si ya se capturo
        'Devuelve -1 si no encontro nada, de lo contrario devuelve el indice en donde
        'se encuentra el pedido.

        Dim a As Integer = 0

        If chkPedidoReferencia.Checked Then
            For a = 0 To aListaPedidos.Count - 1
                If Trim(CType(aListaPedidos(a), String)) = Trim(PedidoReferencia) Then
                    'El pedido ya se capturó
                    Return a
                    Exit Function
                End If
            Next
        Else 'para buscar también en la lista de vales de crédito
            For a = 0 To ListaValesCredito.Count - 1
                If Val(Trim(CType(ListaValesCredito(a), String))) = Val(Trim(PedidoReferencia)) Then
                    'El pedido ya se capturó
                    Return a
                    Exit Function
                End If
            Next
        End If

        Return -1

    End Function

    Private Sub LimpiaCaptura()
        txtPedidoReferencia.Text = ""
        lblPedidoReferenciaImporte.Text = ""
        lblPedidoSaldoReal.Text = ""
        lblPedidoSaldoMovimiento.Text = ""
        txtImporteAbono.Text = ""
        txtPedidoReferencia.Focus()
        AbonosParcialesDocumento = 0
        If lstRelacionCobranza.Visible = True Then
            lstRelacionCobranza.Items.RemoveAt(lstRelacionCobranza.SelectedIndex)
            lstRelacionCobranza.SelectedItem = 0
            lstRelacionCobranza.Focus()
        Else
            txtPedidoReferencia.Focus()
        End If

        'Para desplegar el importe total menos el descuento del cargo, si aplica
        btnConsultaDescuento.Visible = False
    End Sub

    Private Sub AgregaPedido()
        'Metodo para agregar el pedido especificado en el ListBox
        decImporteTotalCobranza += objPedido.ImporteAbono
        lblImporteTotalCobranza.Text = decImporteTotalCobranza.ToString("C")

        'Verifico que la suma de los importes de los pedidos no sobrepase el importe
        'del cobro al que estan relacionados.

        If Not ModoLibre Then
            _ImporteRestante -= objPedido.ImporteAbono
        Else
            _ImporteRestante = 0
            _ImporteCobro = decImporteTotalCobranza
            lblTotalCobro.Text = decImporteTotalCobranza.ToString("C")
        End If
        lblImportePorAplicar.Text = _ImporteRestante.ToString("C")

        'Agrego el objeto al ListBox
        lstDocumento.Items.Add(objPedido)
        'Agrego la referencia unicamente al ArrayList
        aListaPedidos.Add(CType(objPedido.PedidoReferencia, String))

        'Para validar que no capture dos veces el mismo vale de crédito
        'Los pedidos sin vale de crédito traen un cero en el campo correspondiente
        If CType(objPedido.ValeCredito, Integer) > 0 Then
            ListaValesCredito.Add(CType(objPedido.ValeCredito, Integer))
        End If
    End Sub

#End Region

#Region "Menu contextual"
    Private Sub mnuEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEliminar.Click
        Dim statusCheckPedidoReferencia As Boolean = chkPedidoReferencia.Checked
        Try
            If lstDocumento.SelectedIndex <> -1 Then
                chkPedidoReferencia.Checked = True
                Dim decImporteEliminado As Decimal = CType(lstDocumento.Items(lstDocumento.SelectedIndex), SigaMetClasses.sPedido).ImporteAbono
                Dim i As Integer = BuscaPedidoLocal(CType(lstDocumento.Items(lstDocumento.SelectedIndex), SigaMetClasses.sPedido).PedidoReferencia)
                eliminarValeCredito(DirectCast(lstDocumento.Items(i), SigaMetClasses.sPedido).ValeCredito) 'no borraba el vale de crédito al borrar el pedido
                lstDocumento.Items.RemoveAt(lstDocumento.SelectedIndex)
                aListaPedidos.RemoveAt(i)
                decImporteTotalCobranza -= decImporteEliminado
                _ImporteRestante += decImporteEliminado
                lblImporteTotalCobranza.Text = decImporteTotalCobranza.ToString("C")
                lblImportePorAplicar.Text = ImporteRestante.ToString("C")
                If ModoLibre Then
                    lblTotalCobro.Text = decImporteTotalCobranza.ToString("C")
                    _ImporteRestante = 0
                    lblImportePorAplicar.Text = _ImporteRestante.ToString("C")
                End If
                txtPedidoReferencia.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            chkPedidoReferencia.Checked = statusCheckPedidoReferencia
        End Try

    End Sub

    Private Sub cmListaPedidos_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmListaPedidos.Popup
        If lstDocumento.Items.Count <= 0 Then
            mnuEliminar.Enabled = False
        Else
            If lstDocumento.SelectedIndex <> -1 Then
                mnuEliminar.Enabled = True
            Else
                mnuEliminar.Enabled = False
            End If
        End If
    End Sub
#End Region

#Region "Botón Aceptar P. Saldo a favor"
    Private Sub btnAceptarSF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles btnAceptar.Click
        If lstDocumento.Items.Count > 0 Then
            'Esto valida que solo se pueda dejar un sobrante para cheques, ahora también incluirá fichas y transferencias
            If _ImporteRestante <= 0 _
                    Or _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.Cheque _
                    Or _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.FichaDeposito _
                    Or _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.Transferencia _
                    Or _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.Vales _
                    Or _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.NotaIngreso Then
                If MessageBox.Show(M_ESTAN_CORRECTOS, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) _
                        = DialogResult.Yes Then
                    'Aquí se va a validar el sobrante de tiposcobro que acepten saldo a favor
                    'Checar cuáles tipos de cargo admiten saldo a favor
                    If _AceptaSaldoAFavor And _ImporteRestante > 0 Then
                        Dim msgWindow As String = "Otros ingresos"
                        If GLOBAL_AplicacionSaldoAFavor Then
                            msgWindow = "Saldo a favor"
                        End If
                        'Si el cliente tiene el perfíl correcto se permite la captura del saldo a favor aun cuando el cliente tenga saldos pendientes
                        If oSeguridad.TieneAcceso("CAPTURA_SALDOAFAVOR_NOPEND") Then
                            If MessageBox.Show("Faltan por relacionar " & _ImporteRestante.ToString("C") & CrLf &
                                               "Haga clic en 'Sí' para registrar el sobrante como '" & msgWindow & "'," & CrLf &
                                               "haga clic en 'No', para continuar abonando", Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
                                Exit Sub
                            Else
                                _SaldoAFavor = True
                            End If
                        Else
                            'Buscar en esta sección saldos pendientes por abonar para que se agote el sobrante
                            frmSaldosPendientes = New CyCSaldoAFavor.SaldosPendientes(_Cliente, _TipoMovimientoCaja,
                                                                                    _ImporteRestante.ToString("c"), lstDocumento, _ListaCobros, ConString)
                            If frmSaldosPendientes.SaldoPendiente Then
                                If frmSaldosPendientes.ShowDialog() = DialogResult.OK Then
                                    txtPedidoReferencia.Text = frmSaldosPendientes.PedidoReferenciaSeleccionado
                                    Exit Sub
                                Else
                                    MessageBox.Show("Faltan por relacionar " & _ImporteRestante.ToString("C"), Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    Exit Sub
                                End If
                            Else
                                'Aquí debería consultar si se guarda como saldo a favor
                                If MessageBox.Show("Faltan por relacionar " & _ImporteRestante.ToString("C") & CrLf &
                                                   "Haga clic en 'Sí' para registrar el sobrante como '" & msgWindow & "'," & CrLf &
                                                   "haga clic en 'No', para continuar abonando", Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
                                    Exit Sub
                                Else
                                    _SaldoAFavor = True
                                End If
                            End If
                        End If
                    End If
                    Dim s As SigaMetClasses.sPedido
                    For Each s In lstDocumento.Items
                        ListaCobroPedido.Add(s)
                    Next
                    'If TipoCobro = enumTipoCobro.Efectivo Or TipoCobro = enumTipoCobro.Vales Then CapturaEfectivoVales = True
                    'Cambiado el 09 de octubre del 2002
                    'Bloqueamos el boton para que no se captura dos veces EfectivoVales
                    If _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.EfectivoVales Then
                        _ImporteCobro = Me.decImporteTotalCobranza
                        CapturaEfectivoVales = True
                        CapturaMixtaEfectivoVales = True
                    End If
                    DialogResult = DialogResult.OK
                End If
            Else
                MessageBox.Show("Falta por relacionar " & _ImporteRestante.ToString("C"), Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("No se han capturado documentos en la cobranza.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
#End Region

#Region "Botón Aceptar S. Saldo a Favor"
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If lstDocumento.Items.Count > 0 Then
                If _ImporteRestante <= 0 _
                        Or _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.Cheque _
                        Or _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.NotaIngreso Then
                    If MessageBox.Show(M_ESTAN_CORRECTOS, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) _
                            = DialogResult.Yes Then
                        Dim s As SigaMetClasses.sPedido
                        For Each s In lstDocumento.Items
                            ListaCobroPedido.Add(s)
                        Next
                        'If TipoCobro = enumTipoCobro.Efectivo Or TipoCobro = enumTipoCobro.Vales Then CapturaEfectivoVales = True
                        'Cambiado el 09 de octubre del 2002
                        'Bloqueamos el boton para que no se captura dos veces EfectivoVales
                        If _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.EfectivoVales Then
                            _ImporteCobro = Me.decImporteTotalCobranza
                            CapturaEfectivoVales = True
                            CapturaMixtaEfectivoVales = True
                        End If
                        DialogResult = DialogResult.OK
                    End If
                Else
                    MessageBox.Show("Falta por relacionar " & _ImporteRestante.ToString("C"), Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Else
                MessageBox.Show("No se han capturado documentos en la cobranza.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

    End Sub
#End Region

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        objPedido = Nothing
        Me.Close()
    End Sub

    Private Sub AceptaCaptura(ByVal PedidoReferencia As String)
        btnConsultaDescuento.Visible = False
        'BuscaPedidoGlobal(PedidoReferencia) cuando se usa la búsqueda por vale no regresa el saldo en el movimiento

        Dim format As String
        If GLOBAL_FormatoCapturaSaldos Then
            format = "N" 'TODO: parametrizar el formato de despliegue de texto
        Else
            format = "#.0000" 'String.Empty
        End If

        BuscaPedidoGlobal(objPedido.PedidoReferencia)
        lblPedidoReferenciaImporte.Text = objPedido.Importe.ToString(format)
        lblPedidoSaldoReal.Text = objPedido.Saldo.ToString(format)
        lblPedidoSaldoMovimiento.Text = (objPedido.Saldo - AbonosParcialesDocumento).ToString(format)
        If Not ModoLibre Then
            If ImporteRestante > objPedido.Saldo Then
                txtImporteAbono.Text = (objPedido.Saldo - AbonosParcialesDocumento).ToString(format)
            Else
                txtImporteAbono.Text = ImporteRestante.ToString(format)
            End If
        Else
            txtImporteAbono.Text = (objPedido.Saldo - AbonosParcialesDocumento).ToString(format)
        End If
        txtImporteAbono.Focus()
        'Para desplegar el importe total menos el descuento del cargo, si aplica
        frmDescuento = New ImporteDescuento.frmDiscount(objPedido.Cliente, objPedido.PedidoReferencia, GLOBAL_connection)
        If frmDescuento.DescuentoValido Then
            btnConsultaDescuento.Visible = True
        Else
            btnConsultaDescuento.Visible = False
        End If
    End Sub

    Private Sub AgregaPedidoLista()
        'Para desplegar el importe total menos el descuento del cargo, si aplica
        btnConsultaDescuento.Visible = False

        Dim strPedidoReferencia As String = Replace(UCase(Trim(txtPedidoReferencia.Text)), "'", "")
        If strPedidoReferencia <> "" Then
            Dim i As Integer = BuscaPedidoLocal(strPedidoReferencia)
            If i = -1 Then
                If ConsultaPedido(strPedidoReferencia) = True Then
                    'Validación temporal pedida por JLHT el 21 de mayo del 2004 -Se valida ahora por perfil de usuario-
                    If objPedido.Cartera = 6 Then
                        If Not oSeguridad.TieneAcceso("ABONO_CARTERAESPECIAL") Then
                            MessageBox.Show("Sólo el gerente de crédito puede abonar a este documento.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                        'Validación temporal pedida por JLHT el 21 de mayo del 2004 -Se valida ahora por perfil de usuario-
                        'If Main.GLOBAL_IDUsuario <> "JOALRA" Then
                        '    If Main.GLOBAL_IDUsuario <> "ALCAPE" Then
                        '        If Main.GLOBAL_IDUsuario <> "ELDELU" Then
                        '            MessageBox.Show("Sólo el gerente de crédito puede abonar a este documento.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        '            Exit Sub
                        '        End If
                        '    End If
                        'End If
                    End If
                    'Fin de la validación


                    'Aqui cambiar simbolo
                    If objPedido.SePermiteAbonar = 0 Then
                        If MessageBox.Show("El documento: " & strPedidoReferencia & " es de tipo de cargo [" & objPedido.TipoCargoDescripcion & "]" & Chr(13) &
                                           "y no puede ser capturado en este tipo de movimiento." & Chr(13) &
                                           "¿Desea ver el detalle de este documento?", Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then
                            Dim frmDetalleDocumento As New SigaMetClasses.ConsultaCargo(strPedidoReferencia,,)
                            frmDetalleDocumento.ShowDialog()

                        End If
                        activaTxtAbono(False)
                        Exit Sub
                    End If

                    'Validacion para impedir abono a pedidos de gas de edificios administrados JAGD 28/12/2004
                    If objPedido.PedidoEdificio And GLOBAL_NoAbonarClientePadreEdificio Then
                        If Not oSeguridad.TieneAcceso("NoAbonarAClientePadreEdif") Then
                            If MessageBox.Show("El documento: " & strPedidoReferencia & " de tipo de cargo [" & objPedido.TipoCargoDescripcion & "]" & Chr(13) &
                                               "pertenece a un cliente padre de Edificio Administrado y no puede ser abonado." & Chr(13) &
                                               "¿Desea ver el detalle de este documento?", Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then
                                Dim frmDetalleDocumento As New SigaMetClasses.ConsultaCargo(strPedidoReferencia,,)
                                frmDetalleDocumento.ShowDialog()
                            End If
                            Exit Sub
                        End If
                    End If

                    'Validacion para limitar abono a pedidos de lecturas de edificios administrados JAGD 30/01/2005
                    'If abonoClienteHijo(objPedido.Cliente) And objPedido.PedidoEdificio Then
                    If objPedido.PedidoEdificio Then
                        If Not oSeguridad.TieneAcceso("NoAbonarAClientePadreEdif") Then
                            MessageBox.Show("El documento: " & strPedidoReferencia & " de tipo de cargo [" & objPedido.TipoCargoDescripcion & "]" & Chr(13) &
                                               "pertenece a un cliente de Edificio Administrado y solo puede ser abonado por el encargado de Edificios.", Titulo,
                                               MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If
                    End If

                    'Validación captura de saldos a favor solo de clientes con el mismo cliente padre (el cliente padre del cobro origen)
                    If TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.SaldoAFavor Then
                        'Se parametriza por perfil la aplicación libre del saldo pendiente a clientes no relacionados con el contrato origen
                        If Not oSeguridad.TieneAcceso("APLICACIONLIBRE_SALDOAFAVOR") AndAlso
                            Not validaClienteSF(objPedido.Cliente, _ClientesRelacionados) Then
                            MessageBox.Show("El documento: " & strPedidoReferencia & " de tipo de cargo [" & objPedido.TipoCargoDescripcion.Trim & "]" & Chr(13) &
                                                                    "no pertenece al cliente " & CStr(_Cliente) & ", o a los clientes relacionados con este" & Chr(13) &
                                                                    "por medio de su cliente padre.", "Saldos a favor",
                                                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            activaTxtAbono(False)
                            Exit Sub
                        End If
                    End If

                    'Validación captura de saldos a favor solo de clientes con el mismo cliente padre
                    If TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.Cheque AndAlso
                        GLOBAL_ValidarClienteCheque Then
                        'Se parametriza por perfil la aplicación libre del cheque a clientes no relacionados con el contrato origen
                        If Not oSeguridad.TieneAcceso("APLICACIONLIBRE_CHEQUE") AndAlso
                            Not validaClienteSF(objPedido.Cliente, _ClientesRelacionados) Then
                            MessageBox.Show("El documento: " & strPedidoReferencia & " de tipo de cargo [" & objPedido.TipoCargoDescripcion.Trim & "]" & Chr(13) &
                                                                    "no pertenece al cliente " & CStr(_Cliente) & ", o a los clientes relacionados con este" & Chr(13) &
                                                                    "por medio de su cliente padre.", "Captura de cheques",
                                                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            activaTxtAbono(False)
                            Exit Sub
                        End If
                    End If
                    '***

                    If objPedido.Saldo <= 0 Then
                        If MessageBox.Show("El documento " & Trim(txtPedidoReferencia.Text) & " ya fue pagado en su totalidad." & Chr(13) &
                                           "¿Desea ver el detalle de este documento?", Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then

                            Dim frmDetalleDocumento As New SigaMetClasses.ConsultaCargo(strPedidoReferencia, SigaMetClasses.ConsultaCargo.enumConsultaCargo.HistoricoAbonos)
                            frmDetalleDocumento.ShowDialog()
                        End If
                        Exit Sub
                    Else
                        AceptaCaptura(strPedidoReferencia)
                    End If
                Else
                    If chkPedidoReferencia.Checked Then
                        If MessageBox.Show("El documento " & strPedidoReferencia & " no existe en la base de datos, no pertenece" & Chr(13) &
                                           "a la cartera de crédito o tiene los datos incompletos." & Chr(13) &
                                           "¿Desea ver el detalle de este documento?", Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            Dim frmDetalle As New SigaMetClasses.ConsultaCargo(strPedidoReferencia,,)
                            frmDetalle.ShowDialog()
                        End If
                    Else
                        If MessageBox.Show("No se encontró el documento relacionado al vale de crédito " & strPedidoReferencia & Chr(13) &
                                           "¿Desea buscar por número de pedido?", Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            chkPedidoReferencia.Checked = True
                        End If
                    End If
                End If
            Else
                If chkPedidoReferencia.Checked Then
                    MessageBox.Show("El pedido " & strPedidoReferencia & " ya se capturó.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    lstDocumento.SelectedIndex = i
                Else
                    MessageBox.Show("El pedido con vale de crédito " & strPedidoReferencia & " ya se capturó.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    lstDocumento.SelectedIndex = i
                End If
            End If
        End If
    End Sub

    Private Sub txtPedidoReferencia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPedidoReferencia.KeyDown
        If e.KeyCode = Keys.Enter Then AgregaPedidoLista()
    End Sub

    Private Sub frmCapRelacionCobranza_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lstDocumento.DisplayMember = "InformacionCompleta"
        lstDocumento.ValueMember = "Pedido"

        lblTipoCobro.Text = TipoCobro.ToString
        lblTotalCobro.Text = ImporteCobro.ToString("C")
        lblImportePorAplicar.Text = ImporteRestante.ToString("C")
        txtCliente.Text = _Cliente.ToString()

        'Se parametriza la aplicación del saldo a favor
        If GLOBAL_SaldoAFavorActivo And oSeguridad.TieneAcceso("CAPTURA_SALDOAFAVOR") Then
            AddHandler btnAceptar.Click, AddressOf btnAceptarSF_Click
        Else
            AddHandler btnAceptar.Click, AddressOf btnAceptar_Click
        End If

        'Para definir cuales tipos de cobro admiten saldo a favor
        Select Case _TipoCobro
            Case SigaMetClasses.Enumeradores.enumTipoCobro.Cheque,
                 SigaMetClasses.Enumeradores.enumTipoCobro.FichaDeposito,
                 SigaMetClasses.Enumeradores.enumTipoCobro.Transferencia,
                 SigaMetClasses.Enumeradores.enumTipoCobro.NotaCredito,
                 SigaMetClasses.Enumeradores.enumTipoCobro.Vales
                _AceptaSaldoAFavor = True
            Case Else
                _AceptaSaldoAFavor = False
        End Select
    End Sub

    Private Sub lstDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstDocumento.SelectedIndexChanged
        'Armo el tooltip segun el registro seleccionado
        If lstDocumento.SelectedIndex <> -1 Then
            Dim strTip As String
            strTip = "Documento: " & CType(lstDocumento.Items(lstDocumento.SelectedIndex), SigaMetClasses.sPedido).PedidoReferencia & Chr(13) &
                     "Cliente: " & CType(lstDocumento.Items(lstDocumento.SelectedIndex), SigaMetClasses.sPedido).Cliente.ToString & Chr(13) &
                     "Nombre: " & CType(lstDocumento.Items(lstDocumento.SelectedIndex), SigaMetClasses.sPedido).Nombre & Chr(13) &
                     "Importe del documento: " & CType(lstDocumento.Items(lstDocumento.SelectedIndex), SigaMetClasses.sPedido).Importe.ToString("N") & Chr(13) &
                     "Importe del abono: " & CType(lstDocumento.Items(lstDocumento.SelectedIndex), SigaMetClasses.sPedido).ImporteAbono.ToString("N")
            ttDatosPedido.SetToolTip(lstDocumento, strTip)
        End If
    End Sub

    Private Function ValidaCaptura() As Boolean
        If txtPedidoReferencia.Text <> "" Then
            If txtImporteAbono.Text <> "" Then
                If IsNumeric(txtImporteAbono.Text) Then
                    If CDec(txtImporteAbono.Text) > 0 Then
                        If CDec(txtImporteAbono.Text) <= (objPedido.Saldo - Me.AbonosParcialesDocumento) Then
                            Return True
                        Else
                            MessageBox.Show("El importe del abono no puede sobrepasar el saldo del documento.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Return False
                        End If
                    Else
                        MessageBox.Show("El importe del abono debe ser mayor que cero.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return False
                    End If
                Else
                    MessageBox.Show("Debe teclear un importe válido para el abono.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return False
                End If
            Else
                MessageBox.Show("Debe teclear el importe del abono.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If
        Else
            MessageBox.Show("Debe teclear el número de documento.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
    End Function

    Private Sub txtImporteAbono_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtImporteAbono.KeyDown
        If e.KeyCode = Keys.Enter Then
            If ValidaCaptura() = False Then
                Exit Sub
            End If

            'para verificar si el documento ya se capturó en otros movimientos y el importe del abono actual excede al saldo
            'Dim objValidaSaldo As New ValidaSaldosCaja.DocumentosErroneos(txtPedidoReferencia.Text.Trim, CDbl(txtImporteAbono.Text), ConString)
            Dim objValidaSaldo As New ValidaSaldosCaja.DocumentosErroneos(objPedido.PedidoReferencia, CDbl(txtImporteAbono.Text), ConString)
            If Not (objValidaSaldo.CapturaCorrecta) Then
                objValidaSaldo.ShowDialog()
            End If

            If Not ModoLibre Then

                If decImporteTotalCobranza + CDec(txtImporteAbono.Text) <= ImporteCobro Then
                    If CDec(txtImporteAbono.Text) <= ImporteCobro Then

                        objPedido.ImporteAbono = CType(txtImporteAbono.Text, Decimal)
                        AgregaPedido()
                        LimpiaCaptura()
                    Else
                        MessageBox.Show("El importe del abono no puede sobrepasar el importe del cobro.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Else
                    MessageBox.Show("El importe de los abonos no puede sobrepasar el importe del cobro.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If

            Else
                objPedido.ImporteAbono = CType(txtImporteAbono.Text, Decimal)
                AgregaPedido()
                LimpiaCaptura()
            End If

        End If
    End Sub

    Private Sub ConsultaDocumentosCliente()
        Dim oConfig As New SigaMetClasses.cConfig(GLOBAL_Modulo, CShort(GLOBAL_Empresa), GLOBAL_Sucursal)
        Try
            _URLGateway = CType(oConfig.Parametros("URLGateway"), String).Trim()
        Catch ex As Exception
            _URLGateway = ""
        End Try

        If txtCliente.Text <> "" Then
            Dim frmConCliente As SigaMetClasses.frmConsultaCliente
            frmConCliente = New SigaMetClasses.frmConsultaCliente(CType(txtCliente.Text, Integer),
                                     PermiteSeleccionarDocumento:=True,
                                     SoloDocumentosACredito:=True, URLGateway:=_URLGateway, Modulo:=GLOBAL_Modulo, CadenaCon:=ConString)
            If frmConCliente.ShowDialog() = DialogResult.OK Then
                txtPedidoReferencia.Text = frmConCliente.PedidoReferenciaSeleccionado
                txtPedidoReferencia.Focus()
                chkPedidoReferencia.Checked = True
            End If
        End If
    End Sub

    Private Sub ConsultaDocumenosClientePorPeriodo()

        Dim oConfig As New SigaMetClasses.cConfig(GLOBAL_Modulo, CShort(GLOBAL_Empresa), GLOBAL_Sucursal)
        Try
            _URLGateway = CType(oConfig.Parametros("URLGateway"), String).Trim()
        Catch ex As Exception
            _URLGateway = ""
        End Try


        If txtCliente.Text <> "" Then
            If Not chkAutocalcular.Checked And Not ImporteCobro > 0 Then
                MessageBox.Show("Seleccione la casilla 'autocalcular' para" & vbCrLf &
                    "realizar la consulta de documentos.", "CyC", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim frmConCliente As SigaMetClasses.frmConsultaClienteMultiple

            frmConCliente = New SigaMetClasses.frmConsultaClienteMultiple(CType(txtCliente.Text, Integer),
                                    aListaPedidos,
                                    _ListaCobros,
                                    ImporteRestante,
                                    chkAutocalcular.Checked,
                                    oSeguridad.TieneAcceso("ABONO_CARTERAESPECIAL"),
                                    GLOBAL_NoAbonarClientePadreEdificio,
                                    oSeguridad.TieneAcceso("NoAbonarAClientePadreEdif"),
                                    PermiteSeleccionarDocumento:=True,
                                    SoloDocumentosACredito:=True, URLGateway:=_URLGateway, CadCon:=ConString, Modulo:=GLOBAL_Modulo)

            If frmConCliente.ShowDialog() = DialogResult.OK Then
                Dim documento As SigaMetClasses.DocumentoCliente

                For Each documento In frmConCliente.DocumentosSeleccionados
                    chkPedidoReferencia.Checked = True
                    txtPedidoReferencia.Text = documento.PedidoReferencia
                    AgregaPedidoLista()

                    Dim e As New System.Windows.Forms.KeyEventArgs(Keys.Enter)
                    txtImporteAbono_KeyDown(Me, e)
                Next
            End If
        End If
    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        ConsultaDocumentosCliente()
    End Sub

    Private Sub btnClienteFecha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClienteFecha.Click
        ConsultaDocumenosClientePorPeriodo()
    End Sub

    Private Sub txtCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCliente.KeyPress
        If e.KeyChar = Chr(13) Then
            ConsultaDocumentosCliente()
        End If
    End Sub

    Private Sub frmCapCobranzaDoc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F3 Then
            txtCliente.Focus()
        End If
    End Sub

    Private Sub chkAutocalcular_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutocalcular.CheckedChanged
        ModoLibre = chkAutocalcular.Checked
        If ModoLibre Then
            Me.Text = "Captura relación de cobranza (Modo Libre)"
            lblTotalCobro.Text = Me.decImporteTotalCobranza.ToString("N")
        Else
            Me.Text = "Captura relación de cobranza"
        End If
        txtPedidoReferencia.Focus()
        txtPedidoReferencia.SelectAll()
    End Sub

    Private Sub lstRelacionCobranza_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstRelacionCobranza.SelectedIndexChanged
        txtPedidoReferencia.Text = lstRelacionCobranza.Text
    End Sub

    Private Sub txtPedidoReferencia_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPedidoReferencia.Enter
        Me.AcceptButton = btnBuscar
    End Sub

    Private Sub txtPedidoReferencia_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPedidoReferencia.Leave
        Me.AcceptButton = Nothing
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        AgregaPedidoLista()
    End Sub

    Private Sub lstRelacionCobranza_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstRelacionCobranza.DoubleClick
        AgregaPedidoLista()
    End Sub

    Private Sub txtImporteAbono_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtImporteAbono.Enter
        AcceptButton = Nothing
    End Sub

    Private Sub txtImporteAbono_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtImporteAbono.Leave
        AcceptButton = btnBuscar
    End Sub

#Region "Importes con descuento"

    Private Sub btnConsultaDescuento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultaDescuento.Click
        If frmDescuento.ShowDialog = DialogResult.OK Then
            txtImporteAbono.Text = frmDescuento.ImporteMenosDescuento.ToString("N")
        End If
        txtImporteAbono.Focus()
        'Para desplegar el importe total menos el descuento del cargo, si aplica
        btnConsultaDescuento.Visible = False
    End Sub

#End Region

#Region "Validación de clientes hijos de edificio administrado"

    Private Function abonoClienteHijo(ByVal Cliente As Integer) As Boolean
        Dim retValue As Boolean = False
        Dim cn As New SqlConnection(ConString)
        Dim cmd As New SqlCommand("spCyCValidacionAbonoClienteHijoADMEEDif")
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Connection = cn
        cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
        Try
            cn.Open()
            retValue = CType(cmd.ExecuteScalar, Boolean)
        Catch ex As SqlException
            retValue = False
            MessageBox.Show("Ha ocurrido el siguiente error:" & Microsoft.VisualBasic.ControlChars.CrLf & ex.Number & " " & ex.Message, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            retValue = False
            MessageBox.Show("Ha ocurrido el siguiente error:" & Microsoft.VisualBasic.ControlChars.CrLf & ex.Message, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cmd.Dispose()
            cn.Dispose()
        End Try
        Return retValue
    End Function

#End Region

#Region "Saldos a favor"

    Private Function puedeCapturarSaldoAFavor(ByVal Cliente As Integer) As Short
        Dim SaldosAFavorCapturados As Short
        Dim cn As New SqlConnection(ConString)
        Dim cmdSelect As New SqlCommand("spCyCValidaRegistroSaldoAFavor", cn)
        cmdSelect.CommandType = CommandType.StoredProcedure
        cmdSelect.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
        Try
            cn.Open()
            SaldosAFavorCapturados = CType(cmdSelect.ExecuteScalar, Short)
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido el siguiente error:" & Microsoft.VisualBasic.ControlChars.CrLf & ex.Message, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cn.Dispose()
            cmdSelect.Dispose()
        End Try
        Return SaldosAFavorCapturados
    End Function

    Private Function validaClienteSF(ByVal Cliente As Integer, ByVal dtClientes As DataTable) As Boolean
        Dim dr As DataRow
        Dim retValue As Boolean
        retValue = False
        For Each dr In dtClientes.Rows
            If CType(dr.Item("Cliente"), Integer) = Cliente Then
                retValue = True
                Exit For
            End If
        Next
        Return retValue
    End Function

#End Region

#Region "Old Code"

    'Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
    '    If lstDocumento.Items.Count > 0 Then
    '        If _ImporteRestante <= 0 Or (_TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.Cheque _
    '            Or _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.FichaDeposito _
    '            Or _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.Transferencia) _
    '            Or _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.NotaIngreso Then
    '            'Se desactivó para el control de saldos a favor
    '            'If _ImporteRestante <= 0 Or _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.Cheque _
    '            'Or _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.NotaIngreso Then
    '            If MessageBox.Show(M_ESTAN_CORRECTOS, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = _
    '                DialogResult.Yes Then
    '                If (_TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.Cheque _
    '                Or _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.FichaDeposito _
    '                Or _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.Transferencia) _
    '                AndAlso _ImporteRestante > GLOBAL_ValorMinimoSaldoAFavor AndAlso CType(oSeguridad.TieneAcceso("CAPTURA_SALDOAFAVOR"), Boolean) Then
    '                    If MessageBox.Show("Falta por relacionar " & _ImporteRestante.ToString("C") & CrLf & _
    '                                                           "Para registrar esta cantidad como saldo a favor" & CrLf & _
    '                                                           "presione 'Sí/Yes', para continuar abonando presione 'No'", Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = _
    '                                                           DialogResult.Yes Then
    '                        If puedeCapturarSaldoAFavor(_Cliente) < GLOBAL_MaxSaldosAFavorAplParcialPendiente Then
    '                            _SaldoAFavor = True
    '                        Else
    '                            MessageBox.Show("Ya no puede capturar más saldos a favor para este" & CrLf & _
    '                                                                "cliente, porque ya existen " & GLOBAL_MaxSaldosAFavorAplParcialPendiente.ToString & " sin aplicar." & _
    '                                                                CrLf & "Debe abonar el sobrante para cerrar el cobro", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                            _SaldoAFavor = False
    '                            Exit Sub
    '                        End If
    '                    Else
    '                        _SaldoAFavor = False
    '                        Exit Sub
    '                    End If
    '                End If
    '                Dim s As SigaMetClasses.sPedido
    '                For Each s In lstDocumento.Items
    '                    ListaCobroPedido.Add(s)
    '                Next
    '                'If TipoCobro = enumTipoCobro.Efectivo Or TipoCobro = enumTipoCobro.Vales Then CapturaEfectivoVales = True
    '                'Cambiado el 09 de octubre del 2002
    '                'Bloqueamos el boton para que no se captura dos veces EfectivoVales
    '                If _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.EfectivoVales Then
    '                    _ImporteCobro = Me.decImporteTotalCobranza
    '                    CapturaEfectivoVales = True
    '                    CapturaMixtaEfectivoVales = True
    '                End If
    '                DialogResult = DialogResult.OK
    '            End If
    '        Else
    '            MessageBox.Show("Falta por relacionar " & _ImporteRestante.ToString("C"), Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        End If
    '    Else
    '        MessageBox.Show("No se han capturado documentos en la cobranza.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '    End If
    'End Sub

    '#Region "Botón Aceptar P. Saldo a favor"

    '    Private Sub btnAceptarSF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles btnAceptar.Click
    '        If lstDocumento.Items.Count > 0 Then
    '            If (_ImporteRestante <= 0 Or _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.NotaIngreso Or _
    '                (_TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.Cheque _
    '                Or _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.FichaDeposito _
    '                Or _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.Transferencia)) Then

    '                If MessageBox.Show(M_ESTAN_CORRECTOS, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) _
    '                        = DialogResult.Yes Then

    '                    If _ImporteRestante > GLOBAL_ValorMinimoSaldoAFavor Then

    '                        If (_TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.Cheque _
    '                            Or _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.FichaDeposito _
    '                            Or _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.Transferencia) _
    '                            AndAlso CType(oSeguridad.TieneAcceso("CAPTURA_SALDOAFAVOR"), Boolean) Then
    '                            'Preguntar si se guarda el saldo a favor o se sigue abonando
    '                            If MessageBox.Show("Falta por relacionar " & _ImporteRestante.ToString("C") & CrLf & _
    '                                                                   "Para registrar esta cantidad como saldo a favor" & CrLf & _
    '                                                                   "presione 'Sí/Yes', para continuar abonando presione 'No'", Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = _
    '                                                                                          DialogResult.Yes Then
    '                                If puedeCapturarSaldoAFavor(_Cliente) < GLOBAL_MaxSaldosAFavorAplParcialPendiente Then
    '                                    _SaldoAFavor = True
    '                                Else
    '                                    MessageBox.Show("Ya no puede capturar más saldos a favor para este" & CrLf & _
    '                                                                        "cliente, porque ya existen " & GLOBAL_MaxSaldosAFavorAplParcialPendiente.ToString & " sin aplicar." & _
    '                                                                        CrLf & "Debe abonar el sobrante para cerrar el cobro", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                                    _SaldoAFavor = False
    '                                    Exit Sub
    '                                End If
    '                                'Else
    '                                '    _SaldoAFavor = False
    '                                '    Exit Sub
    '                            End If

    '                        Else
    '                            'Seguir abonando
    '                            MessageBox.Show("Falta por relacionar " & _ImporteRestante.ToString("C"), Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                            Exit Sub
    '                        End If
    '                    Else
    '                        'Preguntar si se guarda como otros ingresos y seguir abonando
    '                        If _ImporteRestante > 0 Then
    '                            If MessageBox.Show("Falta por relacionar " & _ImporteRestante.ToString("C") & CrLf & _
    '                                                                   "Para registrar esta cantidad como 'Otros Ingresos'" & CrLf & _
    '                                                                   "presione 'Sí/Yes', para continuar abonando presione 'No'", Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = _
    '                                                                   DialogResult.Yes Then
    '                                _SaldoAFavor = False
    '                            Else
    '                                Exit Sub
    '                            End If
    '                        End If

    '                    End If

    '                    Dim s As SigaMetClasses.sPedido
    '                    For Each s In lstDocumento.Items
    '                        ListaCobroPedido.Add(s)
    '                    Next

    '                    If _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.EfectivoVales Then
    '                        _ImporteCobro = Me.decImporteTotalCobranza
    '                        CapturaEfectivoVales = True
    '                        CapturaMixtaEfectivoVales = True
    '                    End If

    '                    DialogResult = DialogResult.OK
    '                End If

    '            Else
    '                MessageBox.Show("Falta por relacionar " & _ImporteRestante.ToString("C"), Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '            End If
    '        Else
    '            MessageBox.Show("No se han capturado documentos en la cobranza.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        End If
    '    End Sub

    '#End Region

#End Region

#Region "Búsqueda por vale de crédito"

    Private Sub tipoBusquedaDefault(ByVal porValeCredito As Boolean)
        If Not porValeCredito Then
            chkPedidoReferencia.Checked = True
            chkPedidoReferencia.Visible = False
            lblTipoCriterio.Text = "(Pedido referencia)"
        Else
            lblTipoCriterio.Text = "(Folio vale crédito)"
        End If
    End Sub

    Private Function tipoMovAplicaValeCredito(ByVal TipoMovimientoCaja As Byte) As Boolean
        Dim retValue As Boolean = False,
            cn As New SqlConnection(ConString),
            cmd As New SqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED" &
                          " SELECT dbo.CyCConsultaTipoMovValeCredito(" & TipoMovimientoCaja.ToString & ")", cn)
        Try
            cn.Open()
            retValue = CType(TipoMovimientoCaja = CType(cmd.ExecuteScalar, Byte), Boolean)
        Catch ex As Exception
            retValue = False
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Dispose()
            cmd.Dispose()
        End Try
        Return retValue
    End Function

    Private Sub eliminarValeCredito(ByVal ValeCredito As Integer)
        If ValeCredito <> 0 Then
            Dim a As Integer
            For a = 0 To ListaValesCredito.Count - 1
                If CType(ListaValesCredito(a), Integer) = ValeCredito Then
                    ListaValesCredito.RemoveAt(a)
                    Exit For
                End If
            Next
        End If
    End Sub

#End Region

#Region "Captura de tipos de cargo en el movimiento correcto"

    Private Sub activaTxtAbono(ByVal Activar As Boolean)
        txtImporteAbono.ReadOnly = Not Activar
        txtImporteAbono.Enabled = Activar
    End Sub

#End Region

    Private Sub chkPedidoReferencia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPedidoReferencia.CheckedChanged
        If CType(sender, CheckBox).Checked Then
            lblTipoCriterio.Text = "(Pedido referencia)"
        Else
            lblTipoCriterio.Text = "(Folio vale crédito)"
        End If
    End Sub

    Private Sub txtPedidoReferencia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPedidoReferencia.TextChanged
        activaTxtAbono(True)
    End Sub

    Private Sub btnBusquedaLocal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBusquedaLocal.Click
        busquedaLocalDocumentos()
    End Sub

    Private Sub busquedaLocalDocumentos()
        Dim frmBusquedaLocal As New DocumentosBSR.frmBusqueda()

        If frmBusquedaLocal.ShowDialog() = DialogResult.OK Then
            Dim _documento As String

            If frmBusquedaLocal.TipoBusqueda Then
                _documento = frmBusquedaLocal.DocumentoCompleto.ToString().Trim()
            Else
                _documento = mappingPedidoValeCredito(frmBusquedaLocal.Serie, frmBusquedaLocal.FolioNota)
            End If

            If _documento <> Nothing Then
                Dim lItem As String

                lstRelacionCobranza.SelectedItem = Nothing

                For Each lItem In lstRelacionCobranza.Items
                    If lItem = _documento.Trim() Then
                        lstRelacionCobranza.SelectedItem = lItem
                        btnBuscar_Click(Nothing, Nothing)
                        Exit Sub
                    End If
                Next
            End If

            MessageBox.Show("No se encontró el documento especifcado" & vbCrLf &
                "Verifique", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Function mappingPedidoValeCredito(ByVal Serie As String, ByVal Folio As Integer) As String
        Dim dataClass As New SGDAC.DAC(SigaMetClasses.DataLayer.Conexion)
        Dim params(1) As SqlParameter

        Dim documento As String = Nothing

        params(0) = New SqlParameter("@SerieValeCredito", SqlDbType.VarChar)
        params(0).Value = Serie

        params(1) = New SqlParameter("@ValeCredito", SqlDbType.Int)
        params(1).Value = Folio

        Try
            documento = CType(dataClass.LoadScalarData("spCyCMappingPedidoValeCredito", CommandType.StoredProcedure, params), String)
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error " & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dataClass.CloseConnection()
        End Try

        Return documento
    End Function

    Private Sub btnAceptar_Click_1(sender As Object, e As EventArgs) Handles btnAceptar.Click

    End Sub
End Class