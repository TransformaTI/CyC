Imports System.Collections.Generic
Imports System.Data.SqlClient

Public Class frmSelTipoCobro
    Inherits System.Windows.Forms.Form
    Private Titulo As String = "Captura de cobranza"
    Private _Consecutivo As Integer
    Public Cobro As SigaMetClasses.sCobro
    Public ImporteTotalCobro As Decimal = 0
    Private _TipoCobro As SigaMetClasses.Enumeradores.enumTipoCobro
    Private _TipoMovimientoCaja As Byte
    Private _SoloDocumentosCartera As Boolean
    Private _CapturaDetalle As Boolean
    Private _ListaCobros As ListBox
    Private _RelacionCobranza As ArrayList
    Private _EsRelacionCobranza As Boolean
    Private _CargaNotaIngreso As Boolean
    Private _IdCliente As String
    Private _NombreCliente As String
    Private _FacturaNC As Integer

    'Control de cheques posfechados
    Private _ChequePosfechado As Boolean
    Friend WithEvents tbNotaCredito As TabPage
    Friend WithEvents btnAceptarNC As ControlesBase.BotonBase
    Friend WithEvents gpbNotaCredito As GroupBox
    Friend WithEvents txtObserv As TextBox
    Friend WithEvents lblObserv As Label
    Friend WithEvents lblFechaDato As Label
    Friend WithEvents lblImpoteDato As Label
    Friend WithEvents lblFecha As Label
    Friend WithEvents lblImp As Label
    Friend WithEvents lblFolio As Label
    Friend WithEvents lblSerie As Label
    Friend WithEvents txtFolio As TextBox
    Friend WithEvents txtSerie As TextBox
    Friend WithEvents lblNombreClienteDato As Label
    Friend WithEvents lblNombreCliente As Label
    Friend WithEvents lblIdClienteDato As Label
    Friend WithEvents lblIdCliente As Label
    Friend WithEvents tbDacionPago As TabPage
    Friend WithEvents grpDacionPago As GroupBox
    Friend WithEvents dtpDPFechaAplicacion As DateTimePicker
    Friend WithEvents dtpDPFechaConvenio As DateTimePicker
    Friend WithEvents lblDPNombre As Label
    Friend WithEvents lblDPCliente As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtDPDescripcion As TextBox
    Friend WithEvents btnAceptarDP As ControlesBase.BotonBase
    Friend WithEvents txtDPMonto As SigaMetClasses.Controles.txtNumeroDecimal
    Public CargoTarjetaSeleccionado As SigaMetClasses.CargoTarjeta

    Public ReadOnly Property Posfechado() As Boolean
        Get
            Return _ChequePosfechado
        End Get
    End Property

    'Constructor para la captura normal de cobranza
    Public Sub New(ByVal intConsecutivo As Integer,
                   ByVal TipoMovimientoCaja As Byte,
                   ByVal ListaCobros As ListBox,
                   ByVal IdCliente As String,
                   ByVal Cliente As String,
          Optional ByVal SoloDocumentosCartera As Boolean = True,
          Optional ByVal CapturaDetalle As Boolean = True)
        MyBase.New()
        InitializeComponent()
        If CapturaEfectivoVales = True Then
            btnAceptarEfectivoVales.Enabled = False
        End If
        If CapturaMixtaEfectivoVales = True Then
            'btnAceptarEfectivo.Enabled = False
            'btnAceptarVale.Enabled = False
        End If
        _Consecutivo = intConsecutivo
        _TipoMovimientoCaja = TipoMovimientoCaja
        _SoloDocumentosCartera = SoloDocumentosCartera
        _CapturaDetalle = CapturaDetalle
        _ListaCobros = ListaCobros
        _IdCliente = IdCliente
        _NombreCliente = Cliente


    End Sub

    'Constructor para las Relaciones de Cobranza
    Public Sub New(ByVal intConsecutivo As Integer,
                   ByVal ListaCobros As ListBox,
                   ByVal RelacionCobranza As ArrayList,
                   ByVal TipoMovimientoCaja As Byte)
        MyBase.New()
        InitializeComponent()
        If CapturaEfectivoVales = True Then
            btnAceptarEfectivoVales.Enabled = False
        End If
        _Consecutivo = intConsecutivo
        _TipoMovimientoCaja = TipoMovimientoCaja
        _SoloDocumentosCartera = True
        _CapturaDetalle = True
        _ListaCobros = ListaCobros
        _RelacionCobranza = RelacionCobranza
        _EsRelacionCobranza = True
        tabTipoCobro.SelectedTab = tbChequeFicha
        txtDocumento.Focus()
        txtDocumento.SelectAll()

    End Sub

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        InitializeComponent()
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
    Friend WithEvents tabTipoCobro As System.Windows.Forms.TabControl
    Friend WithEvents dtpFechaCheque As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblObservaciones As ControlesBase.LabelBase
    Friend WithEvents lblNoCheque As ControlesBase.LabelBase
    Friend WithEvents lblFechaCheque As ControlesBase.LabelBase
    Friend WithEvents lblNoCuenta As ControlesBase.LabelBase
    Friend WithEvents lblImporte As ControlesBase.LabelBase
    Friend WithEvents lblCliente As ControlesBase.LabelBase
    Friend WithEvents tbEfectivoVales As System.Windows.Forms.TabPage
    Friend WithEvents btnAceptarEfectivoVales As ControlesBase.BotonBase
    Friend WithEvents grpEfectivoVales As System.Windows.Forms.GroupBox
    Friend WithEvents lblTotalEfectivoVales As ControlesBase.LabelBase
    Friend WithEvents imgLista As System.Windows.Forms.ImageList
    Friend WithEvents tbTarjetaCredito As System.Windows.Forms.TabPage
    Friend WithEvents grpTarjetaCredito As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As ControlesBase.LabelBase
    Friend WithEvents LabelBase1 As ControlesBase.LabelBase
    Friend WithEvents LabelBase3 As ControlesBase.LabelBase
    Friend WithEvents btnAceptarTarjetaCredito As ControlesBase.BotonBase
    Friend WithEvents lblTarjetaCredito As System.Windows.Forms.Label
    Friend WithEvents lblTitular As System.Windows.Forms.Label
    Friend WithEvents lblTipoTarjetaCredito As System.Windows.Forms.Label
    Friend WithEvents LabelBase4 As ControlesBase.LabelBase
    Friend WithEvents lblVigencia As System.Windows.Forms.Label
    Friend WithEvents LabelBase5 As ControlesBase.LabelBase
    Friend WithEvents btnBuscarClienteTC As System.Windows.Forms.Button
    Friend WithEvents LabelBase6 As ControlesBase.LabelBase
    Friend WithEvents lblBancoNombre As System.Windows.Forms.Label
    Friend WithEvents LabelBase7 As ControlesBase.LabelBase
    Friend WithEvents lblClienteNombre As System.Windows.Forms.Label
    Friend WithEvents lblBanco As System.Windows.Forms.Label
    Friend WithEvents ComboBanco As SigaMetClasses.Combos.ComboBanco
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalEfectivoVales As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtNumeroCuenta As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtClienteCheque As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtClienteTC As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtImporteTC As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents btnAceptarChequeFicha As ControlesBase.BotonBase
    Friend WithEvents tbChequeFicha As System.Windows.Forms.TabPage
    Friend WithEvents grpChequeFicha As System.Windows.Forms.GroupBox
    Friend WithEvents rbCheque As System.Windows.Forms.RadioButton
    Friend WithEvents rbFicha As System.Windows.Forms.RadioButton
    Friend WithEvents txtImporteDocumento As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents rbNotaCredito As System.Windows.Forms.RadioButton
    Friend WithEvents rbNotaIngreso As System.Windows.Forms.RadioButton
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents btnLeerCodigo As System.Windows.Forms.Button
    Friend WithEvents LabelBase8 As ControlesBase.LabelBase
    Friend WithEvents ttMensaje As System.Windows.Forms.ToolTip
    Friend WithEvents chkCargarNI As System.Windows.Forms.CheckBox
    Friend WithEvents txtDocumento As System.Windows.Forms.TextBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents rbTransferencia As System.Windows.Forms.RadioButton
    Friend WithEvents lblCtaDestino As ControlesBase.LabelBase
    Friend WithEvents ComboBancoOrigen As SigaMetClasses.Combos.ComboBanco
    Friend WithEvents lblBancoDestino As ControlesBase.LabelBase
    Friend WithEvents lblBancoOrigen As ControlesBase.LabelBase
    Friend WithEvents txtNumeroCuentaOrigen As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents tbSaldoAFavor As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents grpOrigen As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblSFCliente As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnSFBuscar As System.Windows.Forms.Button
    Friend WithEvents txtSFAñoAtt As System.Windows.Forms.TextBox
    Friend WithEvents txtSFFolioAtt As System.Windows.Forms.TextBox
    Friend WithEvents txtSFCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtSFClave As System.Windows.Forms.TextBox
    Friend WithEvents lblSFImporte As System.Windows.Forms.Label
    Friend WithEvents lblSaldoAFavorNombre As System.Windows.Forms.Label
    Friend WithEvents btnAceptarSF As ControlesBase.BotonBase
    Friend WithEvents lblSFCobro As System.Windows.Forms.Label
    Friend WithEvents lblSFTipo As System.Windows.Forms.Label
    Friend WithEvents lblSFMovimientoOrigen As System.Windows.Forms.Label
    Friend WithEvents lblSFAñoCobro As System.Windows.Forms.Label
    'Friend WithEvents cboNumeroCuenta As System.Windows.Forms.ComboBox
    Friend WithEvents cboNumeroCuenta As SigaMetClasses.Controles.cboNumeroEntero
    Friend WithEvents chkCapturaTPV As System.Windows.Forms.CheckBox
    Friend WithEvents lblTxtTarjeta As ControlesBase.LabelBase
    Friend WithEvents txtNumeroTarjeta As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents comboBancoTDC As SigaMetClasses.Combos.ComboBanco
    Friend WithEvents ComboBanco1 As SigaMetClasses.Combos.ComboBanco
    Friend WithEvents btnBusquedaCliente As System.Windows.Forms.Button
    Friend WithEvents btnAceptarNotaCredito As ControlesBase.BotonBase
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelTipoCobro))
        Me.tabTipoCobro = New System.Windows.Forms.TabControl()
        Me.tbEfectivoVales = New System.Windows.Forms.TabPage()
        Me.grpEfectivoVales = New System.Windows.Forms.GroupBox()
        Me.txtTotalEfectivoVales = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.lblTotalEfectivoVales = New ControlesBase.LabelBase()
        Me.btnAceptarEfectivoVales = New ControlesBase.BotonBase()
        Me.tbTarjetaCredito = New System.Windows.Forms.TabPage()
        Me.chkCapturaTPV = New System.Windows.Forms.CheckBox()
        Me.btnAceptarTarjetaCredito = New ControlesBase.BotonBase()
        Me.grpTarjetaCredito = New System.Windows.Forms.GroupBox()
        Me.txtImporteTC = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtClienteTC = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.lblBanco = New System.Windows.Forms.Label()
        Me.LabelBase7 = New ControlesBase.LabelBase()
        Me.lblClienteNombre = New System.Windows.Forms.Label()
        Me.LabelBase6 = New ControlesBase.LabelBase()
        Me.lblVigencia = New System.Windows.Forms.Label()
        Me.LabelBase5 = New ControlesBase.LabelBase()
        Me.lblTipoTarjetaCredito = New System.Windows.Forms.Label()
        Me.LabelBase4 = New ControlesBase.LabelBase()
        Me.lblBancoNombre = New System.Windows.Forms.Label()
        Me.LabelBase3 = New ControlesBase.LabelBase()
        Me.lblTarjetaCredito = New System.Windows.Forms.Label()
        Me.lblTxtTarjeta = New ControlesBase.LabelBase()
        Me.LabelBase1 = New ControlesBase.LabelBase()
        Me.Label20 = New ControlesBase.LabelBase()
        Me.lblTitular = New System.Windows.Forms.Label()
        Me.btnBuscarClienteTC = New System.Windows.Forms.Button()
        Me.txtNumeroTarjeta = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.comboBancoTDC = New SigaMetClasses.Combos.ComboBanco()
        Me.tbChequeFicha = New System.Windows.Forms.TabPage()
        Me.rbTransferencia = New System.Windows.Forms.RadioButton()
        Me.chkCargarNI = New System.Windows.Forms.CheckBox()
        Me.LabelBase8 = New ControlesBase.LabelBase()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.rbNotaIngreso = New System.Windows.Forms.RadioButton()
        Me.btnAceptarChequeFicha = New ControlesBase.BotonBase()
        Me.grpChequeFicha = New System.Windows.Forms.GroupBox()
        Me.btnBusquedaCliente = New System.Windows.Forms.Button()
        Me.cboNumeroCuenta = New SigaMetClasses.Controles.cboNumeroEntero()
        Me.txtDocumento = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.txtImporteDocumento = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtClienteCheque = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.txtNumeroCuenta = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.ComboBanco = New SigaMetClasses.Combos.ComboBanco()
        Me.lblBancoDestino = New ControlesBase.LabelBase()
        Me.lblObservaciones = New ControlesBase.LabelBase()
        Me.dtpFechaCheque = New System.Windows.Forms.DateTimePicker()
        Me.lblNoCheque = New ControlesBase.LabelBase()
        Me.lblFechaCheque = New ControlesBase.LabelBase()
        Me.lblNoCuenta = New ControlesBase.LabelBase()
        Me.lblImporte = New ControlesBase.LabelBase()
        Me.lblCliente = New ControlesBase.LabelBase()
        Me.lblBancoOrigen = New ControlesBase.LabelBase()
        Me.ComboBancoOrigen = New SigaMetClasses.Combos.ComboBanco()
        Me.txtNumeroCuentaOrigen = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.lblCtaDestino = New ControlesBase.LabelBase()
        Me.rbNotaCredito = New System.Windows.Forms.RadioButton()
        Me.rbFicha = New System.Windows.Forms.RadioButton()
        Me.rbCheque = New System.Windows.Forms.RadioButton()
        Me.btnLeerCodigo = New System.Windows.Forms.Button()
        Me.tbSaldoAFavor = New System.Windows.Forms.TabPage()
        Me.btnAceptarSF = New ControlesBase.BotonBase()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblSFAñoCobro = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblSFImporte = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblSFCobro = New System.Windows.Forms.Label()
        Me.lblSFTipo = New System.Windows.Forms.Label()
        Me.lblSFMovimientoOrigen = New System.Windows.Forms.Label()
        Me.lblSaldoAFavorNombre = New System.Windows.Forms.Label()
        Me.lblSFCliente = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.grpOrigen = New System.Windows.Forms.GroupBox()
        Me.txtSFAñoAtt = New System.Windows.Forms.TextBox()
        Me.btnSFBuscar = New System.Windows.Forms.Button()
        Me.txtSFFolioAtt = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSFCliente = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSFClave = New System.Windows.Forms.TextBox()
        Me.tbNotaCredito = New System.Windows.Forms.TabPage()
        Me.gpbNotaCredito = New System.Windows.Forms.GroupBox()
        Me.lblNombreCliente = New System.Windows.Forms.Label()
        Me.lblIdClienteDato = New System.Windows.Forms.Label()
        Me.txtFolio = New System.Windows.Forms.TextBox()
        Me.lblFolio = New System.Windows.Forms.Label()
        Me.lblIdCliente = New System.Windows.Forms.Label()
        Me.txtObserv = New System.Windows.Forms.TextBox()
        Me.lblObserv = New System.Windows.Forms.Label()
        Me.lblFechaDato = New System.Windows.Forms.Label()
        Me.lblImpoteDato = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.lblImp = New System.Windows.Forms.Label()
        Me.lblSerie = New System.Windows.Forms.Label()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.lblNombreClienteDato = New System.Windows.Forms.Label()
        Me.btnAceptarNC = New ControlesBase.BotonBase()
        Me.tbDacionPago = New System.Windows.Forms.TabPage()
        Me.btnAceptarDP = New ControlesBase.BotonBase()
        Me.grpDacionPago = New System.Windows.Forms.GroupBox()
        Me.txtDPDescripcion = New System.Windows.Forms.TextBox()
        Me.dtpDPFechaAplicacion = New System.Windows.Forms.DateTimePicker()
        Me.dtpDPFechaConvenio = New System.Windows.Forms.DateTimePicker()
        Me.lblDPNombre = New System.Windows.Forms.Label()
        Me.lblDPCliente = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.imgLista = New System.Windows.Forms.ImageList(Me.components)
        Me.ttMensaje = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.ComboBanco1 = New SigaMetClasses.Combos.ComboBanco()
        Me.txtDPMonto = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.tabTipoCobro.SuspendLayout()
        Me.tbEfectivoVales.SuspendLayout()
        Me.grpEfectivoVales.SuspendLayout()
        Me.tbTarjetaCredito.SuspendLayout()
        Me.grpTarjetaCredito.SuspendLayout()
        Me.tbChequeFicha.SuspendLayout()
        Me.grpChequeFicha.SuspendLayout()
        Me.tbSaldoAFavor.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grpOrigen.SuspendLayout()
        Me.tbNotaCredito.SuspendLayout()
        Me.gpbNotaCredito.SuspendLayout()
        Me.tbDacionPago.SuspendLayout()
        Me.grpDacionPago.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabTipoCobro
        '
        Me.tabTipoCobro.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.tabTipoCobro.Controls.Add(Me.tbEfectivoVales)
        Me.tabTipoCobro.Controls.Add(Me.tbTarjetaCredito)
        Me.tabTipoCobro.Controls.Add(Me.tbChequeFicha)
        Me.tabTipoCobro.Controls.Add(Me.tbSaldoAFavor)
        Me.tabTipoCobro.Controls.Add(Me.tbNotaCredito)
        Me.tabTipoCobro.Controls.Add(Me.tbDacionPago)
        Me.tabTipoCobro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabTipoCobro.HotTrack = True
        Me.tabTipoCobro.Location = New System.Drawing.Point(0, 0)
        Me.tabTipoCobro.Multiline = True
        Me.tabTipoCobro.Name = "tabTipoCobro"
        Me.tabTipoCobro.SelectedIndex = 0
        Me.tabTipoCobro.Size = New System.Drawing.Size(618, 396)
        Me.tabTipoCobro.TabIndex = 0
        '
        'tbEfectivoVales
        '
        Me.tbEfectivoVales.BackColor = System.Drawing.SystemColors.Control
        Me.tbEfectivoVales.Controls.Add(Me.grpEfectivoVales)
        Me.tbEfectivoVales.Controls.Add(Me.btnAceptarEfectivoVales)
        Me.tbEfectivoVales.ImageIndex = 0
        Me.tbEfectivoVales.Location = New System.Drawing.Point(4, 4)
        Me.tbEfectivoVales.Name = "tbEfectivoVales"
        Me.tbEfectivoVales.Size = New System.Drawing.Size(610, 370)
        Me.tbEfectivoVales.TabIndex = 3
        Me.tbEfectivoVales.Text = "Efectivo y / o vales"
        '
        'grpEfectivoVales
        '
        Me.grpEfectivoVales.Controls.Add(Me.txtTotalEfectivoVales)
        Me.grpEfectivoVales.Controls.Add(Me.lblTotalEfectivoVales)
        Me.grpEfectivoVales.Location = New System.Drawing.Point(48, 138)
        Me.grpEfectivoVales.Name = "grpEfectivoVales"
        Me.grpEfectivoVales.Size = New System.Drawing.Size(272, 48)
        Me.grpEfectivoVales.TabIndex = 32
        Me.grpEfectivoVales.TabStop = False
        Me.grpEfectivoVales.Text = "Datos del efectivo o vales de despensa"
        '
        'txtTotalEfectivoVales
        '
        Me.txtTotalEfectivoVales.Location = New System.Drawing.Point(136, 16)
        Me.txtTotalEfectivoVales.Name = "txtTotalEfectivoVales"
        Me.txtTotalEfectivoVales.Size = New System.Drawing.Size(120, 21)
        Me.txtTotalEfectivoVales.TabIndex = 0
        '
        'lblTotalEfectivoVales
        '
        Me.lblTotalEfectivoVales.AutoSize = True
        Me.lblTotalEfectivoVales.Location = New System.Drawing.Point(16, 19)
        Me.lblTotalEfectivoVales.Name = "lblTotalEfectivoVales"
        Me.lblTotalEfectivoVales.Size = New System.Drawing.Size(74, 13)
        Me.lblTotalEfectivoVales.TabIndex = 28
        Me.lblTotalEfectivoVales.Text = "Importe total:"
        '
        'btnAceptarEfectivoVales
        '
        Me.btnAceptarEfectivoVales.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptarEfectivoVales.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptarEfectivoVales.Image = CType(resources.GetObject("btnAceptarEfectivoVales.Image"), System.Drawing.Image)
        Me.btnAceptarEfectivoVales.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptarEfectivoVales.Location = New System.Drawing.Point(360, 150)
        Me.btnAceptarEfectivoVales.Name = "btnAceptarEfectivoVales"
        Me.btnAceptarEfectivoVales.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptarEfectivoVales.TabIndex = 1
        Me.btnAceptarEfectivoVales.Text = "&Aceptar"
        Me.btnAceptarEfectivoVales.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptarEfectivoVales.UseVisualStyleBackColor = False
        '
        'tbTarjetaCredito
        '
        Me.tbTarjetaCredito.Controls.Add(Me.chkCapturaTPV)
        Me.tbTarjetaCredito.Controls.Add(Me.btnAceptarTarjetaCredito)
        Me.tbTarjetaCredito.Controls.Add(Me.grpTarjetaCredito)
        Me.tbTarjetaCredito.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTarjetaCredito.Location = New System.Drawing.Point(4, 4)
        Me.tbTarjetaCredito.Name = "tbTarjetaCredito"
        Me.tbTarjetaCredito.Size = New System.Drawing.Size(610, 370)
        Me.tbTarjetaCredito.TabIndex = 0
        Me.tbTarjetaCredito.Text = "Tarjeta de crédito"
        '
        'chkCapturaTPV
        '
        Me.chkCapturaTPV.Location = New System.Drawing.Point(48, 16)
        Me.chkCapturaTPV.Name = "chkCapturaTPV"
        Me.chkCapturaTPV.Size = New System.Drawing.Size(160, 24)
        Me.chkCapturaTPV.TabIndex = 31
        Me.chkCapturaTPV.Text = "Capturar recibo TPV"
        '
        'btnAceptarTarjetaCredito
        '
        Me.btnAceptarTarjetaCredito.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptarTarjetaCredito.Image = CType(resources.GetObject("btnAceptarTarjetaCredito.Image"), System.Drawing.Image)
        Me.btnAceptarTarjetaCredito.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptarTarjetaCredito.Location = New System.Drawing.Point(498, 150)
        Me.btnAceptarTarjetaCredito.Name = "btnAceptarTarjetaCredito"
        Me.btnAceptarTarjetaCredito.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptarTarjetaCredito.TabIndex = 3
        Me.btnAceptarTarjetaCredito.Text = "&Aceptar"
        Me.btnAceptarTarjetaCredito.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpTarjetaCredito
        '
        Me.grpTarjetaCredito.Controls.Add(Me.txtImporteTC)
        Me.grpTarjetaCredito.Controls.Add(Me.txtClienteTC)
        Me.grpTarjetaCredito.Controls.Add(Me.lblBanco)
        Me.grpTarjetaCredito.Controls.Add(Me.LabelBase7)
        Me.grpTarjetaCredito.Controls.Add(Me.lblClienteNombre)
        Me.grpTarjetaCredito.Controls.Add(Me.LabelBase6)
        Me.grpTarjetaCredito.Controls.Add(Me.lblVigencia)
        Me.grpTarjetaCredito.Controls.Add(Me.LabelBase5)
        Me.grpTarjetaCredito.Controls.Add(Me.lblTipoTarjetaCredito)
        Me.grpTarjetaCredito.Controls.Add(Me.LabelBase4)
        Me.grpTarjetaCredito.Controls.Add(Me.lblBancoNombre)
        Me.grpTarjetaCredito.Controls.Add(Me.LabelBase3)
        Me.grpTarjetaCredito.Controls.Add(Me.lblTarjetaCredito)
        Me.grpTarjetaCredito.Controls.Add(Me.lblTxtTarjeta)
        Me.grpTarjetaCredito.Controls.Add(Me.LabelBase1)
        Me.grpTarjetaCredito.Controls.Add(Me.Label20)
        Me.grpTarjetaCredito.Controls.Add(Me.lblTitular)
        Me.grpTarjetaCredito.Controls.Add(Me.btnBuscarClienteTC)
        Me.grpTarjetaCredito.Controls.Add(Me.txtNumeroTarjeta)
        Me.grpTarjetaCredito.Controls.Add(Me.comboBancoTDC)
        Me.grpTarjetaCredito.Location = New System.Drawing.Point(48, 48)
        Me.grpTarjetaCredito.Name = "grpTarjetaCredito"
        Me.grpTarjetaCredito.Size = New System.Drawing.Size(280, 253)
        Me.grpTarjetaCredito.TabIndex = 30
        Me.grpTarjetaCredito.TabStop = False
        Me.grpTarjetaCredito.Text = "Datos de la tarjeta de crédito"
        '
        'txtImporteTC
        '
        Me.txtImporteTC.Location = New System.Drawing.Point(104, 216)
        Me.txtImporteTC.Name = "txtImporteTC"
        Me.txtImporteTC.Size = New System.Drawing.Size(160, 21)
        Me.txtImporteTC.TabIndex = 4
        '
        'txtClienteTC
        '
        Me.txtClienteTC.Location = New System.Drawing.Point(104, 32)
        Me.txtClienteTC.Name = "txtClienteTC"
        Me.txtClienteTC.Size = New System.Drawing.Size(100, 21)
        Me.txtClienteTC.TabIndex = 0
        '
        'lblBanco
        '
        Me.lblBanco.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBanco.Location = New System.Drawing.Point(104, 144)
        Me.lblBanco.Name = "lblBanco"
        Me.lblBanco.Size = New System.Drawing.Size(44, 21)
        Me.lblBanco.TabIndex = 42
        Me.lblBanco.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBanco.Visible = False
        '
        'LabelBase7
        '
        Me.LabelBase7.AutoSize = True
        Me.LabelBase7.Location = New System.Drawing.Point(16, 65)
        Me.LabelBase7.Name = "LabelBase7"
        Me.LabelBase7.Size = New System.Drawing.Size(48, 13)
        Me.LabelBase7.TabIndex = 40
        Me.LabelBase7.Text = "Nombre:"
        '
        'lblClienteNombre
        '
        Me.lblClienteNombre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblClienteNombre.Location = New System.Drawing.Point(104, 56)
        Me.lblClienteNombre.Name = "lblClienteNombre"
        Me.lblClienteNombre.Size = New System.Drawing.Size(160, 32)
        Me.lblClienteNombre.TabIndex = 41
        Me.lblClienteNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelBase6
        '
        Me.LabelBase6.AutoSize = True
        Me.LabelBase6.Location = New System.Drawing.Point(16, 219)
        Me.LabelBase6.Name = "LabelBase6"
        Me.LabelBase6.Size = New System.Drawing.Size(49, 13)
        Me.LabelBase6.TabIndex = 39
        Me.LabelBase6.Text = "Importe:"
        '
        'lblVigencia
        '
        Me.lblVigencia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblVigencia.Location = New System.Drawing.Point(104, 192)
        Me.lblVigencia.Name = "lblVigencia"
        Me.lblVigencia.Size = New System.Drawing.Size(160, 21)
        Me.lblVigencia.TabIndex = 38
        Me.lblVigencia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelBase5
        '
        Me.LabelBase5.AutoSize = True
        Me.LabelBase5.Location = New System.Drawing.Point(16, 195)
        Me.LabelBase5.Name = "LabelBase5"
        Me.LabelBase5.Size = New System.Drawing.Size(50, 13)
        Me.LabelBase5.TabIndex = 37
        Me.LabelBase5.Text = "Vigencia:"
        '
        'lblTipoTarjetaCredito
        '
        Me.lblTipoTarjetaCredito.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTipoTarjetaCredito.Location = New System.Drawing.Point(104, 168)
        Me.lblTipoTarjetaCredito.Name = "lblTipoTarjetaCredito"
        Me.lblTipoTarjetaCredito.Size = New System.Drawing.Size(160, 21)
        Me.lblTipoTarjetaCredito.TabIndex = 36
        Me.lblTipoTarjetaCredito.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelBase4
        '
        Me.LabelBase4.AutoSize = True
        Me.LabelBase4.Location = New System.Drawing.Point(16, 171)
        Me.LabelBase4.Name = "LabelBase4"
        Me.LabelBase4.Size = New System.Drawing.Size(82, 13)
        Me.LabelBase4.TabIndex = 35
        Me.LabelBase4.Text = "Tipo de tarjeta:"
        '
        'lblBancoNombre
        '
        Me.lblBancoNombre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBancoNombre.Location = New System.Drawing.Point(104, 144)
        Me.lblBancoNombre.Name = "lblBancoNombre"
        Me.lblBancoNombre.Size = New System.Drawing.Size(160, 21)
        Me.lblBancoNombre.TabIndex = 34
        Me.lblBancoNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelBase3
        '
        Me.LabelBase3.AutoSize = True
        Me.LabelBase3.Location = New System.Drawing.Point(16, 147)
        Me.LabelBase3.Name = "LabelBase3"
        Me.LabelBase3.Size = New System.Drawing.Size(40, 13)
        Me.LabelBase3.TabIndex = 33
        Me.LabelBase3.Text = "Banco:"
        '
        'lblTarjetaCredito
        '
        Me.lblTarjetaCredito.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTarjetaCredito.Location = New System.Drawing.Point(104, 120)
        Me.lblTarjetaCredito.Name = "lblTarjetaCredito"
        Me.lblTarjetaCredito.Size = New System.Drawing.Size(160, 21)
        Me.lblTarjetaCredito.TabIndex = 32
        Me.lblTarjetaCredito.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTxtTarjeta
        '
        Me.lblTxtTarjeta.AutoSize = True
        Me.lblTxtTarjeta.Location = New System.Drawing.Point(16, 123)
        Me.lblTxtTarjeta.Name = "lblTxtTarjeta"
        Me.lblTxtTarjeta.Size = New System.Drawing.Size(66, 13)
        Me.lblTxtTarjeta.TabIndex = 26
        Me.lblTxtTarjeta.Text = "No. Tarjeta:"
        '
        'LabelBase1
        '
        Me.LabelBase1.AutoSize = True
        Me.LabelBase1.Location = New System.Drawing.Point(16, 99)
        Me.LabelBase1.Name = "LabelBase1"
        Me.LabelBase1.Size = New System.Drawing.Size(41, 13)
        Me.LabelBase1.TabIndex = 24
        Me.LabelBase1.Text = "Titular:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(16, 35)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(44, 13)
        Me.Label20.TabIndex = 22
        Me.Label20.Text = "Cliente:"
        '
        'lblTitular
        '
        Me.lblTitular.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTitular.Location = New System.Drawing.Point(104, 96)
        Me.lblTitular.Name = "lblTitular"
        Me.lblTitular.Size = New System.Drawing.Size(160, 21)
        Me.lblTitular.TabIndex = 31
        Me.lblTitular.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnBuscarClienteTC
        '
        Me.btnBuscarClienteTC.Image = CType(resources.GetObject("btnBuscarClienteTC.Image"), System.Drawing.Image)
        Me.btnBuscarClienteTC.Location = New System.Drawing.Point(216, 32)
        Me.btnBuscarClienteTC.Name = "btnBuscarClienteTC"
        Me.btnBuscarClienteTC.Size = New System.Drawing.Size(48, 21)
        Me.btnBuscarClienteTC.TabIndex = 1
        '
        'txtNumeroTarjeta
        '
        Me.txtNumeroTarjeta.Location = New System.Drawing.Point(104, 120)
        Me.txtNumeroTarjeta.Name = "txtNumeroTarjeta"
        Me.txtNumeroTarjeta.Size = New System.Drawing.Size(160, 21)
        Me.txtNumeroTarjeta.TabIndex = 2
        Me.txtNumeroTarjeta.Visible = False
        '
        'comboBancoTDC
        '
        Me.comboBancoTDC.Location = New System.Drawing.Point(104, 144)
        Me.comboBancoTDC.Name = "comboBancoTDC"
        Me.comboBancoTDC.Size = New System.Drawing.Size(160, 21)
        Me.comboBancoTDC.TabIndex = 3
        Me.comboBancoTDC.Text = "ComboBanco1"
        Me.comboBancoTDC.Visible = False
        '
        'tbChequeFicha
        '
        Me.tbChequeFicha.Controls.Add(Me.rbTransferencia)
        Me.tbChequeFicha.Controls.Add(Me.chkCargarNI)
        Me.tbChequeFicha.Controls.Add(Me.LabelBase8)
        Me.tbChequeFicha.Controls.Add(Me.txtCodigo)
        Me.tbChequeFicha.Controls.Add(Me.rbNotaIngreso)
        Me.tbChequeFicha.Controls.Add(Me.btnAceptarChequeFicha)
        Me.tbChequeFicha.Controls.Add(Me.grpChequeFicha)
        Me.tbChequeFicha.Controls.Add(Me.rbNotaCredito)
        Me.tbChequeFicha.Controls.Add(Me.rbFicha)
        Me.tbChequeFicha.Controls.Add(Me.rbCheque)
        Me.tbChequeFicha.Controls.Add(Me.btnLeerCodigo)
        Me.tbChequeFicha.Location = New System.Drawing.Point(4, 4)
        Me.tbChequeFicha.Name = "tbChequeFicha"
        Me.tbChequeFicha.Size = New System.Drawing.Size(610, 370)
        Me.tbChequeFicha.TabIndex = 2
        Me.tbChequeFicha.Text = "Cheque / Ficha de deposito"
        '
        'rbTransferencia
        '
        Me.rbTransferencia.Enabled = False
        Me.rbTransferencia.Location = New System.Drawing.Point(280, 16)
        Me.rbTransferencia.Name = "rbTransferencia"
        Me.rbTransferencia.Size = New System.Drawing.Size(136, 16)
        Me.rbTransferencia.TabIndex = 39
        Me.rbTransferencia.Text = "&Transferencia bancaria"
        '
        'chkCargarNI
        '
        Me.chkCargarNI.Checked = True
        Me.chkCargarNI.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCargarNI.Location = New System.Drawing.Point(280, 40)
        Me.chkCargarNI.Name = "chkCargarNI"
        Me.chkCargarNI.Size = New System.Drawing.Size(180, 16)
        Me.chkCargarNI.TabIndex = 38
        Me.chkCargarNI.Text = "Usar nota de ingreso capturada"
        Me.chkCargarNI.Visible = False
        '
        'LabelBase8
        '
        Me.LabelBase8.AutoSize = True
        Me.LabelBase8.Location = New System.Drawing.Point(24, 64)
        Me.LabelBase8.Name = "LabelBase8"
        Me.LabelBase8.Size = New System.Drawing.Size(63, 13)
        Me.LabelBase8.TabIndex = 37
        Me.LabelBase8.Text = "Usar lector:"
        '
        'txtCodigo
        '
        Me.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigo.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtCodigo.Location = New System.Drawing.Point(112, 64)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(240, 18)
        Me.txtCodigo.TabIndex = 0
        Me.ttMensaje.SetToolTip(Me.txtCodigo, "Posicione el cursor en este lugar y deslice el cheque por el lector de código")
        '
        'rbNotaIngreso
        '
        Me.rbNotaIngreso.Location = New System.Drawing.Point(168, 40)
        Me.rbNotaIngreso.Name = "rbNotaIngreso"
        Me.rbNotaIngreso.Size = New System.Drawing.Size(104, 16)
        Me.rbNotaIngreso.TabIndex = 36
        Me.rbNotaIngreso.Text = "&Nota de ingreso"
        '
        'btnAceptarChequeFicha
        '
        Me.btnAceptarChequeFicha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptarChequeFicha.Image = CType(resources.GetObject("btnAceptarChequeFicha.Image"), System.Drawing.Image)
        Me.btnAceptarChequeFicha.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptarChequeFicha.Location = New System.Drawing.Point(512, 150)
        Me.btnAceptarChequeFicha.Name = "btnAceptarChequeFicha"
        Me.btnAceptarChequeFicha.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptarChequeFicha.TabIndex = 2
        Me.btnAceptarChequeFicha.Text = "&Aceptar"
        Me.btnAceptarChequeFicha.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpChequeFicha
        '
        Me.grpChequeFicha.Controls.Add(Me.btnBusquedaCliente)
        Me.grpChequeFicha.Controls.Add(Me.cboNumeroCuenta)
        Me.grpChequeFicha.Controls.Add(Me.txtDocumento)
        Me.grpChequeFicha.Controls.Add(Me.lblNombre)
        Me.grpChequeFicha.Controls.Add(Me.btnBuscarCliente)
        Me.grpChequeFicha.Controls.Add(Me.txtImporteDocumento)
        Me.grpChequeFicha.Controls.Add(Me.txtClienteCheque)
        Me.grpChequeFicha.Controls.Add(Me.txtNumeroCuenta)
        Me.grpChequeFicha.Controls.Add(Me.txtObservaciones)
        Me.grpChequeFicha.Controls.Add(Me.ComboBanco)
        Me.grpChequeFicha.Controls.Add(Me.lblBancoDestino)
        Me.grpChequeFicha.Controls.Add(Me.lblObservaciones)
        Me.grpChequeFicha.Controls.Add(Me.dtpFechaCheque)
        Me.grpChequeFicha.Controls.Add(Me.lblNoCheque)
        Me.grpChequeFicha.Controls.Add(Me.lblFechaCheque)
        Me.grpChequeFicha.Controls.Add(Me.lblNoCuenta)
        Me.grpChequeFicha.Controls.Add(Me.lblImporte)
        Me.grpChequeFicha.Controls.Add(Me.lblCliente)
        Me.grpChequeFicha.Controls.Add(Me.lblBancoOrigen)
        Me.grpChequeFicha.Controls.Add(Me.ComboBancoOrigen)
        Me.grpChequeFicha.Controls.Add(Me.txtNumeroCuentaOrigen)
        Me.grpChequeFicha.Controls.Add(Me.lblCtaDestino)
        Me.grpChequeFicha.Location = New System.Drawing.Point(24, 80)
        Me.grpChequeFicha.Name = "grpChequeFicha"
        Me.grpChequeFicha.Size = New System.Drawing.Size(328, 285)
        Me.grpChequeFicha.TabIndex = 0
        Me.grpChequeFicha.TabStop = False
        '
        'btnBusquedaCliente
        '
        Me.btnBusquedaCliente.Image = CType(resources.GetObject("btnBusquedaCliente.Image"), System.Drawing.Image)
        Me.btnBusquedaCliente.Location = New System.Drawing.Point(228, 96)
        Me.btnBusquedaCliente.Name = "btnBusquedaCliente"
        Me.btnBusquedaCliente.Size = New System.Drawing.Size(40, 21)
        Me.btnBusquedaCliente.TabIndex = 36
        Me.btnBusquedaCliente.Tag = "Búsqueda de clientes"
        '
        'cboNumeroCuenta
        '
        Me.cboNumeroCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNumeroCuenta.Location = New System.Drawing.Point(120, 72)
        Me.cboNumeroCuenta.Name = "cboNumeroCuenta"
        Me.cboNumeroCuenta.Size = New System.Drawing.Size(192, 21)
        Me.cboNumeroCuenta.TabIndex = 2
        Me.cboNumeroCuenta.Visible = False
        '
        'txtDocumento
        '
        Me.txtDocumento.Location = New System.Drawing.Point(120, 24)
        Me.txtDocumento.MaxLength = 10
        Me.txtDocumento.Name = "txtDocumento"
        Me.txtDocumento.Size = New System.Drawing.Size(192, 21)
        Me.txtDocumento.TabIndex = 0
        '
        'lblNombre
        '
        Me.lblNombre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNombre.Location = New System.Drawing.Point(120, 120)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(192, 21)
        Me.lblNombre.TabIndex = 5
        Me.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.Image = CType(resources.GetObject("btnBuscarCliente.Image"), System.Drawing.Image)
        Me.btnBuscarCliente.Location = New System.Drawing.Point(272, 96)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(40, 21)
        Me.btnBuscarCliente.TabIndex = 31
        Me.btnBuscarCliente.Tag = "Consulta de datos del cliente"
        '
        'txtImporteDocumento
        '
        Me.txtImporteDocumento.Location = New System.Drawing.Point(120, 168)
        Me.txtImporteDocumento.Name = "txtImporteDocumento"
        Me.txtImporteDocumento.Size = New System.Drawing.Size(192, 21)
        Me.txtImporteDocumento.TabIndex = 7
        '
        'txtClienteCheque
        '
        Me.txtClienteCheque.Location = New System.Drawing.Point(120, 96)
        Me.txtClienteCheque.Name = "txtClienteCheque"
        Me.txtClienteCheque.Size = New System.Drawing.Size(104, 21)
        Me.txtClienteCheque.TabIndex = 4
        '
        'txtNumeroCuenta
        '
        Me.txtNumeroCuenta.Location = New System.Drawing.Point(120, 72)
        Me.txtNumeroCuenta.Name = "txtNumeroCuenta"
        Me.txtNumeroCuenta.Size = New System.Drawing.Size(192, 21)
        Me.txtNumeroCuenta.TabIndex = 2
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(120, 240)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(192, 32)
        Me.txtObservaciones.TabIndex = 8
        '
        'ComboBanco
        '
        Me.ComboBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBanco.DropDownWidth = 200
        Me.ComboBanco.Location = New System.Drawing.Point(120, 144)
        Me.ComboBanco.Name = "ComboBanco"
        Me.ComboBanco.Size = New System.Drawing.Size(192, 21)
        Me.ComboBanco.TabIndex = 6
        '
        'lblBancoDestino
        '
        Me.lblBancoDestino.AutoSize = True
        Me.lblBancoDestino.Location = New System.Drawing.Point(8, 147)
        Me.lblBancoDestino.Name = "lblBancoDestino"
        Me.lblBancoDestino.Size = New System.Drawing.Size(40, 13)
        Me.lblBancoDestino.TabIndex = 15
        Me.lblBancoDestino.Text = "Banco:"
        '
        'lblObservaciones
        '
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.Location = New System.Drawing.Point(8, 240)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(82, 13)
        Me.lblObservaciones.TabIndex = 21
        Me.lblObservaciones.Text = "Observaciones:"
        '
        'dtpFechaCheque
        '
        Me.dtpFechaCheque.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaCheque.Location = New System.Drawing.Point(120, 48)
        Me.dtpFechaCheque.Name = "dtpFechaCheque"
        Me.dtpFechaCheque.Size = New System.Drawing.Size(192, 21)
        Me.dtpFechaCheque.TabIndex = 1
        '
        'lblNoCheque
        '
        Me.lblNoCheque.AutoSize = True
        Me.lblNoCheque.Location = New System.Drawing.Point(8, 27)
        Me.lblNoCheque.Name = "lblNoCheque"
        Me.lblNoCheque.Size = New System.Drawing.Size(85, 13)
        Me.lblNoCheque.TabIndex = 3
        Me.lblNoCheque.Text = "No. Documento:"
        '
        'lblFechaCheque
        '
        Me.lblFechaCheque.AutoSize = True
        Me.lblFechaCheque.Location = New System.Drawing.Point(8, 51)
        Me.lblFechaCheque.Name = "lblFechaCheque"
        Me.lblFechaCheque.Size = New System.Drawing.Size(96, 13)
        Me.lblFechaCheque.TabIndex = 16
        Me.lblFechaCheque.Text = "Fecha documento:"
        '
        'lblNoCuenta
        '
        Me.lblNoCuenta.AutoSize = True
        Me.lblNoCuenta.Location = New System.Drawing.Point(8, 75)
        Me.lblNoCuenta.Name = "lblNoCuenta"
        Me.lblNoCuenta.Size = New System.Drawing.Size(66, 13)
        Me.lblNoCuenta.TabIndex = 12
        Me.lblNoCuenta.Text = "No. Cuenta:"
        '
        'lblImporte
        '
        Me.lblImporte.AutoSize = True
        Me.lblImporte.Location = New System.Drawing.Point(8, 171)
        Me.lblImporte.Name = "lblImporte"
        Me.lblImporte.Size = New System.Drawing.Size(49, 13)
        Me.lblImporte.TabIndex = 19
        Me.lblImporte.Text = "Importe:"
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Location = New System.Drawing.Point(8, 104)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(44, 13)
        Me.lblCliente.TabIndex = 13
        Me.lblCliente.Text = "Cliente:"
        '
        'lblBancoOrigen
        '
        Me.lblBancoOrigen.AutoSize = True
        Me.lblBancoOrigen.Location = New System.Drawing.Point(8, 195)
        Me.lblBancoOrigen.Name = "lblBancoOrigen"
        Me.lblBancoOrigen.Size = New System.Drawing.Size(73, 13)
        Me.lblBancoOrigen.TabIndex = 35
        Me.lblBancoOrigen.Text = "Banco origen:"
        '
        'ComboBancoOrigen
        '
        Me.ComboBancoOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBancoOrigen.DropDownWidth = 200
        Me.ComboBancoOrigen.Enabled = False
        Me.ComboBancoOrigen.Location = New System.Drawing.Point(120, 192)
        Me.ComboBancoOrigen.Name = "ComboBancoOrigen"
        Me.ComboBancoOrigen.Size = New System.Drawing.Size(192, 21)
        Me.ComboBancoOrigen.TabIndex = 34
        '
        'txtNumeroCuentaOrigen
        '
        Me.txtNumeroCuentaOrigen.Enabled = False
        Me.txtNumeroCuentaOrigen.Location = New System.Drawing.Point(120, 216)
        Me.txtNumeroCuentaOrigen.Name = "txtNumeroCuentaOrigen"
        Me.txtNumeroCuentaOrigen.Size = New System.Drawing.Size(192, 21)
        Me.txtNumeroCuentaOrigen.TabIndex = 3
        '
        'lblCtaDestino
        '
        Me.lblCtaDestino.AutoSize = True
        Me.lblCtaDestino.Location = New System.Drawing.Point(8, 219)
        Me.lblCtaDestino.Name = "lblCtaDestino"
        Me.lblCtaDestino.Size = New System.Drawing.Size(101, 13)
        Me.lblCtaDestino.TabIndex = 33
        Me.lblCtaDestino.Text = "No. Cuenta Origen:"
        '
        'rbNotaCredito
        '
        Me.rbNotaCredito.Location = New System.Drawing.Point(168, 16)
        Me.rbNotaCredito.Name = "rbNotaCredito"
        Me.rbNotaCredito.Size = New System.Drawing.Size(104, 16)
        Me.rbNotaCredito.TabIndex = 35
        Me.rbNotaCredito.Text = "&Nota de crédito"
        '
        'rbFicha
        '
        Me.rbFicha.Location = New System.Drawing.Point(32, 40)
        Me.rbFicha.Name = "rbFicha"
        Me.rbFicha.Size = New System.Drawing.Size(120, 16)
        Me.rbFicha.TabIndex = 30
        Me.rbFicha.Text = "&Ficha de depósito"
        '
        'rbCheque
        '
        Me.rbCheque.Checked = True
        Me.rbCheque.Location = New System.Drawing.Point(32, 16)
        Me.rbCheque.Name = "rbCheque"
        Me.rbCheque.Size = New System.Drawing.Size(64, 16)
        Me.rbCheque.TabIndex = 29
        Me.rbCheque.TabStop = True
        Me.rbCheque.Text = "&Cheque"
        '
        'btnLeerCodigo
        '
        Me.btnLeerCodigo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLeerCodigo.Image = CType(resources.GetObject("btnLeerCodigo.Image"), System.Drawing.Image)
        Me.btnLeerCodigo.Location = New System.Drawing.Point(320, 64)
        Me.btnLeerCodigo.Name = "btnLeerCodigo"
        Me.btnLeerCodigo.Size = New System.Drawing.Size(32, 18)
        Me.btnLeerCodigo.TabIndex = 1
        Me.btnLeerCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ttMensaje.SetToolTip(Me.btnLeerCodigo, "Codifica el resultado de la lectura")
        '
        'tbSaldoAFavor
        '
        Me.tbSaldoAFavor.Controls.Add(Me.btnAceptarSF)
        Me.tbSaldoAFavor.Controls.Add(Me.GroupBox1)
        Me.tbSaldoAFavor.Controls.Add(Me.grpOrigen)
        Me.tbSaldoAFavor.Location = New System.Drawing.Point(4, 4)
        Me.tbSaldoAFavor.Name = "tbSaldoAFavor"
        Me.tbSaldoAFavor.Size = New System.Drawing.Size(610, 370)
        Me.tbSaldoAFavor.TabIndex = 4
        Me.tbSaldoAFavor.Text = "Saldo a favor"
        '
        'btnAceptarSF
        '
        Me.btnAceptarSF.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptarSF.Image = CType(resources.GetObject("btnAceptarSF.Image"), System.Drawing.Image)
        Me.btnAceptarSF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptarSF.Location = New System.Drawing.Point(388, 161)
        Me.btnAceptarSF.Name = "btnAceptarSF"
        Me.btnAceptarSF.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptarSF.TabIndex = 4
        Me.btnAceptarSF.Text = "&Aceptar"
        Me.btnAceptarSF.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblSFAñoCobro)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.lblSFImporte)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.lblSFCobro)
        Me.GroupBox1.Controls.Add(Me.lblSFTipo)
        Me.GroupBox1.Controls.Add(Me.lblSFMovimientoOrigen)
        Me.GroupBox1.Controls.Add(Me.lblSaldoAFavorNombre)
        Me.GroupBox1.Controls.Add(Me.lblSFCliente)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 141)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(358, 210)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'lblSFAñoCobro
        '
        Me.lblSFAñoCobro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSFAñoCobro.Location = New System.Drawing.Point(144, 116)
        Me.lblSFAñoCobro.Name = "lblSFAñoCobro"
        Me.lblSFAñoCobro.Size = New System.Drawing.Size(48, 23)
        Me.lblSFAñoCobro.TabIndex = 16
        Me.lblSFAñoCobro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(12, 176)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(49, 13)
        Me.Label15.TabIndex = 15
        Me.Label15.Text = "Importe:"
        '
        'lblSFImporte
        '
        Me.lblSFImporte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSFImporte.Location = New System.Drawing.Point(144, 172)
        Me.lblSFImporte.Name = "lblSFImporte"
        Me.lblSFImporte.Size = New System.Drawing.Size(200, 23)
        Me.lblSFImporte.TabIndex = 14
        Me.lblSFImporte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 147)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(31, 13)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "Tipo:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 120)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(40, 13)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "Cobro:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 94)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(98, 13)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Movimiento origen:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 48)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 13)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Nombre:"
        '
        'lblSFCobro
        '
        Me.lblSFCobro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSFCobro.Location = New System.Drawing.Point(195, 116)
        Me.lblSFCobro.Name = "lblSFCobro"
        Me.lblSFCobro.Size = New System.Drawing.Size(149, 23)
        Me.lblSFCobro.TabIndex = 4
        Me.lblSFCobro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSFTipo
        '
        Me.lblSFTipo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSFTipo.Location = New System.Drawing.Point(144, 143)
        Me.lblSFTipo.Name = "lblSFTipo"
        Me.lblSFTipo.Size = New System.Drawing.Size(200, 23)
        Me.lblSFTipo.TabIndex = 3
        Me.lblSFTipo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSFMovimientoOrigen
        '
        Me.lblSFMovimientoOrigen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSFMovimientoOrigen.Location = New System.Drawing.Point(144, 90)
        Me.lblSFMovimientoOrigen.Name = "lblSFMovimientoOrigen"
        Me.lblSFMovimientoOrigen.Size = New System.Drawing.Size(200, 23)
        Me.lblSFMovimientoOrigen.TabIndex = 2
        Me.lblSFMovimientoOrigen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSaldoAFavorNombre
        '
        Me.lblSaldoAFavorNombre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSaldoAFavorNombre.Location = New System.Drawing.Point(144, 48)
        Me.lblSaldoAFavorNombre.Name = "lblSaldoAFavorNombre"
        Me.lblSaldoAFavorNombre.Size = New System.Drawing.Size(200, 38)
        Me.lblSaldoAFavorNombre.TabIndex = 1
        '
        'lblSFCliente
        '
        Me.lblSFCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSFCliente.Location = New System.Drawing.Point(144, 21)
        Me.lblSFCliente.Name = "lblSFCliente"
        Me.lblSFCliente.Size = New System.Drawing.Size(200, 23)
        Me.lblSFCliente.TabIndex = 0
        Me.lblSFCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 13)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Cliente:"
        '
        'grpOrigen
        '
        Me.grpOrigen.Controls.Add(Me.txtSFAñoAtt)
        Me.grpOrigen.Controls.Add(Me.btnSFBuscar)
        Me.grpOrigen.Controls.Add(Me.txtSFFolioAtt)
        Me.grpOrigen.Controls.Add(Me.Label4)
        Me.grpOrigen.Controls.Add(Me.Label3)
        Me.grpOrigen.Controls.Add(Me.txtSFCliente)
        Me.grpOrigen.Controls.Add(Me.Label2)
        Me.grpOrigen.Controls.Add(Me.Label1)
        Me.grpOrigen.Controls.Add(Me.txtSFClave)
        Me.grpOrigen.Location = New System.Drawing.Point(14, 16)
        Me.grpOrigen.Name = "grpOrigen"
        Me.grpOrigen.Size = New System.Drawing.Size(359, 120)
        Me.grpOrigen.TabIndex = 0
        Me.grpOrigen.TabStop = False
        Me.grpOrigen.Text = "Movimiento origen"
        '
        'txtSFAñoAtt
        '
        Me.txtSFAñoAtt.Location = New System.Drawing.Point(144, 67)
        Me.txtSFAñoAtt.Name = "txtSFAñoAtt"
        Me.txtSFAñoAtt.Size = New System.Drawing.Size(147, 21)
        Me.txtSFAñoAtt.TabIndex = 9
        '
        'btnSFBuscar
        '
        Me.btnSFBuscar.Image = CType(resources.GetObject("btnSFBuscar.Image"), System.Drawing.Image)
        Me.btnSFBuscar.Location = New System.Drawing.Point(301, 20)
        Me.btnSFBuscar.Name = "btnSFBuscar"
        Me.btnSFBuscar.Size = New System.Drawing.Size(48, 21)
        Me.btnSFBuscar.TabIndex = 8
        '
        'txtSFFolioAtt
        '
        Me.txtSFFolioAtt.Location = New System.Drawing.Point(144, 90)
        Me.txtSFFolioAtt.Name = "txtSFFolioAtt"
        Me.txtSFFolioAtt.Size = New System.Drawing.Size(147, 21)
        Me.txtSFFolioAtt.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Folio:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Añoatt:"
        '
        'txtSFCliente
        '
        Me.txtSFCliente.Location = New System.Drawing.Point(144, 44)
        Me.txtSFCliente.Name = "txtSFCliente"
        Me.txtSFCliente.Size = New System.Drawing.Size(147, 21)
        Me.txtSFCliente.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Cliente:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Clave del movimiento:"
        '
        'txtSFClave
        '
        Me.txtSFClave.Location = New System.Drawing.Point(144, 21)
        Me.txtSFClave.Name = "txtSFClave"
        Me.txtSFClave.Size = New System.Drawing.Size(147, 21)
        Me.txtSFClave.TabIndex = 0
        '
        'tbNotaCredito
        '
        Me.tbNotaCredito.Controls.Add(Me.gpbNotaCredito)
        Me.tbNotaCredito.Controls.Add(Me.btnAceptarNC)
        Me.tbNotaCredito.Location = New System.Drawing.Point(4, 4)
        Me.tbNotaCredito.Name = "tbNotaCredito"
        Me.tbNotaCredito.Size = New System.Drawing.Size(610, 370)
        Me.tbNotaCredito.TabIndex = 5
        Me.tbNotaCredito.Text = "Nota de Credito"
        Me.tbNotaCredito.UseVisualStyleBackColor = True
        '
        'gpbNotaCredito
        '
        Me.gpbNotaCredito.Controls.Add(Me.lblNombreCliente)
        Me.gpbNotaCredito.Controls.Add(Me.lblIdClienteDato)
        Me.gpbNotaCredito.Controls.Add(Me.txtFolio)
        Me.gpbNotaCredito.Controls.Add(Me.lblFolio)
        Me.gpbNotaCredito.Controls.Add(Me.lblIdCliente)
        Me.gpbNotaCredito.Controls.Add(Me.txtObserv)
        Me.gpbNotaCredito.Controls.Add(Me.lblObserv)
        Me.gpbNotaCredito.Controls.Add(Me.lblFechaDato)
        Me.gpbNotaCredito.Controls.Add(Me.lblImpoteDato)
        Me.gpbNotaCredito.Controls.Add(Me.lblFecha)
        Me.gpbNotaCredito.Controls.Add(Me.lblImp)
        Me.gpbNotaCredito.Controls.Add(Me.lblSerie)
        Me.gpbNotaCredito.Controls.Add(Me.txtSerie)
        Me.gpbNotaCredito.Controls.Add(Me.lblNombreClienteDato)
        Me.gpbNotaCredito.Location = New System.Drawing.Point(30, 18)
        Me.gpbNotaCredito.Name = "gpbNotaCredito"
        Me.gpbNotaCredito.Size = New System.Drawing.Size(338, 313)
        Me.gpbNotaCredito.TabIndex = 0
        Me.gpbNotaCredito.TabStop = False
        Me.gpbNotaCredito.Text = "Nota de Credito"
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.AutoSize = True
        Me.lblNombreCliente.Location = New System.Drawing.Point(18, 54)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(84, 13)
        Me.lblNombreCliente.TabIndex = 12
        Me.lblNombreCliente.Text = "Nombre Cliente:"
        '
        'lblIdClienteDato
        '
        Me.lblIdClienteDato.AutoSize = True
        Me.lblIdClienteDato.Location = New System.Drawing.Point(108, 28)
        Me.lblIdClienteDato.Name = "lblIdClienteDato"
        Me.lblIdClienteDato.Size = New System.Drawing.Size(18, 13)
        Me.lblIdClienteDato.TabIndex = 11
        Me.lblIdClienteDato.Tag = ""
        Me.lblIdClienteDato.Text = "ID"
        '
        'txtFolio
        '
        Me.txtFolio.Location = New System.Drawing.Point(108, 83)
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Size = New System.Drawing.Size(201, 21)
        Me.txtFolio.TabIndex = 0
        '
        'lblFolio
        '
        Me.lblFolio.AutoSize = True
        Me.lblFolio.Location = New System.Drawing.Point(69, 86)
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Size = New System.Drawing.Size(33, 13)
        Me.lblFolio.TabIndex = 3
        Me.lblFolio.Text = "Folio:"
        '
        'lblIdCliente
        '
        Me.lblIdCliente.AutoSize = True
        Me.lblIdCliente.Location = New System.Drawing.Point(58, 28)
        Me.lblIdCliente.Name = "lblIdCliente"
        Me.lblIdCliente.Size = New System.Drawing.Size(44, 13)
        Me.lblIdCliente.TabIndex = 10
        Me.lblIdCliente.Text = "Cliente:"
        '
        'txtObserv
        '
        Me.txtObserv.Location = New System.Drawing.Point(108, 222)
        Me.txtObserv.Multiline = True
        Me.txtObserv.Name = "txtObserv"
        Me.txtObserv.Size = New System.Drawing.Size(201, 75)
        Me.txtObserv.TabIndex = 2
        '
        'lblObserv
        '
        Me.lblObserv.AutoSize = True
        Me.lblObserv.Location = New System.Drawing.Point(20, 225)
        Me.lblObserv.Name = "lblObserv"
        Me.lblObserv.Size = New System.Drawing.Size(82, 13)
        Me.lblObserv.TabIndex = 8
        Me.lblObserv.Text = "Observaciones:"
        '
        'lblFechaDato
        '
        Me.lblFechaDato.AutoSize = True
        Me.lblFechaDato.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaDato.ForeColor = System.Drawing.Color.Blue
        Me.lblFechaDato.Location = New System.Drawing.Point(108, 190)
        Me.lblFechaDato.Name = "lblFechaDato"
        Me.lblFechaDato.Size = New System.Drawing.Size(0, 14)
        Me.lblFechaDato.TabIndex = 7
        '
        'lblImpoteDato
        '
        Me.lblImpoteDato.AutoSize = True
        Me.lblImpoteDato.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImpoteDato.ForeColor = System.Drawing.Color.Blue
        Me.lblImpoteDato.Location = New System.Drawing.Point(108, 161)
        Me.lblImpoteDato.Name = "lblImpoteDato"
        Me.lblImpoteDato.Size = New System.Drawing.Size(0, 14)
        Me.lblImpoteDato.TabIndex = 6
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(62, 190)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(40, 13)
        Me.lblFecha.TabIndex = 5
        Me.lblFecha.Text = "Fecha:"
        '
        'lblImp
        '
        Me.lblImp.AutoSize = True
        Me.lblImp.Location = New System.Drawing.Point(53, 161)
        Me.lblImp.Name = "lblImp"
        Me.lblImp.Size = New System.Drawing.Size(49, 13)
        Me.lblImp.TabIndex = 4
        Me.lblImp.Text = "Importe:"
        '
        'lblSerie
        '
        Me.lblSerie.AutoSize = True
        Me.lblSerie.Location = New System.Drawing.Point(67, 126)
        Me.lblSerie.Name = "lblSerie"
        Me.lblSerie.Size = New System.Drawing.Size(35, 13)
        Me.lblSerie.TabIndex = 2
        Me.lblSerie.Text = "Serie:"
        '
        'txtSerie
        '
        Me.txtSerie.Location = New System.Drawing.Point(108, 123)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(201, 21)
        Me.txtSerie.TabIndex = 1
        '
        'lblNombreClienteDato
        '
        Me.lblNombreClienteDato.AutoSize = True
        Me.lblNombreClienteDato.Location = New System.Drawing.Point(108, 54)
        Me.lblNombreClienteDato.Name = "lblNombreClienteDato"
        Me.lblNombreClienteDato.Size = New System.Drawing.Size(21, 13)
        Me.lblNombreClienteDato.TabIndex = 13
        Me.lblNombreClienteDato.Text = "NC"
        '
        'btnAceptarNC
        '
        Me.btnAceptarNC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptarNC.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptarNC.Image = CType(resources.GetObject("btnAceptarNC.Image"), System.Drawing.Image)
        Me.btnAceptarNC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptarNC.Location = New System.Drawing.Point(519, 161)
        Me.btnAceptarNC.Name = "btnAceptarNC"
        Me.btnAceptarNC.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptarNC.TabIndex = 3
        Me.btnAceptarNC.Text = "&Aceptar"
        Me.btnAceptarNC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptarNC.UseVisualStyleBackColor = False
        '
        'tbDacionPago
        '
        Me.tbDacionPago.BackColor = System.Drawing.SystemColors.Control
        Me.tbDacionPago.Controls.Add(Me.btnAceptarDP)
        Me.tbDacionPago.Controls.Add(Me.grpDacionPago)
        Me.tbDacionPago.Location = New System.Drawing.Point(4, 4)
        Me.tbDacionPago.Name = "tbDacionPago"
        Me.tbDacionPago.Size = New System.Drawing.Size(610, 370)
        Me.tbDacionPago.TabIndex = 6
        Me.tbDacionPago.Text = "Dación en pago"
        '
        'btnAceptarDP
        '
        Me.btnAceptarDP.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptarDP.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptarDP.Image = CType(resources.GetObject("btnAceptarDP.Image"), System.Drawing.Image)
        Me.btnAceptarDP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptarDP.Location = New System.Drawing.Point(519, 109)
        Me.btnAceptarDP.Name = "btnAceptarDP"
        Me.btnAceptarDP.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptarDP.TabIndex = 7
        Me.btnAceptarDP.Text = "&Aceptar"
        Me.btnAceptarDP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptarDP.UseVisualStyleBackColor = False
        '
        'grpDacionPago
        '
        Me.grpDacionPago.Controls.Add(Me.txtDPMonto)
        Me.grpDacionPago.Controls.Add(Me.txtDPDescripcion)
        Me.grpDacionPago.Controls.Add(Me.dtpDPFechaAplicacion)
        Me.grpDacionPago.Controls.Add(Me.dtpDPFechaConvenio)
        Me.grpDacionPago.Controls.Add(Me.lblDPNombre)
        Me.grpDacionPago.Controls.Add(Me.lblDPCliente)
        Me.grpDacionPago.Controls.Add(Me.Label16)
        Me.grpDacionPago.Controls.Add(Me.Label14)
        Me.grpDacionPago.Controls.Add(Me.Label8)
        Me.grpDacionPago.Controls.Add(Me.Label7)
        Me.grpDacionPago.Controls.Add(Me.Label6)
        Me.grpDacionPago.Controls.Add(Me.Label5)
        Me.grpDacionPago.Location = New System.Drawing.Point(19, 13)
        Me.grpDacionPago.Name = "grpDacionPago"
        Me.grpDacionPago.Size = New System.Drawing.Size(402, 264)
        Me.grpDacionPago.TabIndex = 0
        Me.grpDacionPago.TabStop = False
        Me.grpDacionPago.Text = "Dación en pago:"
        '
        'txtDPDescripcion
        '
        Me.txtDPDescripcion.Location = New System.Drawing.Point(121, 155)
        Me.txtDPDescripcion.Multiline = True
        Me.txtDPDescripcion.Name = "txtDPDescripcion"
        Me.txtDPDescripcion.Size = New System.Drawing.Size(260, 84)
        Me.txtDPDescripcion.TabIndex = 6
        '
        'dtpDPFechaAplicacion
        '
        Me.dtpDPFechaAplicacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDPFechaAplicacion.Location = New System.Drawing.Point(121, 103)
        Me.dtpDPFechaAplicacion.Name = "dtpDPFechaAplicacion"
        Me.dtpDPFechaAplicacion.Size = New System.Drawing.Size(100, 21)
        Me.dtpDPFechaAplicacion.TabIndex = 4
        '
        'dtpDPFechaConvenio
        '
        Me.dtpDPFechaConvenio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDPFechaConvenio.Location = New System.Drawing.Point(121, 77)
        Me.dtpDPFechaConvenio.Name = "dtpDPFechaConvenio"
        Me.dtpDPFechaConvenio.Size = New System.Drawing.Size(100, 21)
        Me.dtpDPFechaConvenio.TabIndex = 3
        '
        'lblDPNombre
        '
        Me.lblDPNombre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDPNombre.Location = New System.Drawing.Point(121, 51)
        Me.lblDPNombre.Name = "lblDPNombre"
        Me.lblDPNombre.Size = New System.Drawing.Size(260, 21)
        Me.lblDPNombre.TabIndex = 2
        '
        'lblDPCliente
        '
        Me.lblDPCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDPCliente.Location = New System.Drawing.Point(121, 25)
        Me.lblDPCliente.Name = "lblDPCliente"
        Me.lblDPCliente.Size = New System.Drawing.Size(100, 21)
        Me.lblDPCliente.TabIndex = 1
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(50, 155)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 13)
        Me.Label16.TabIndex = 5
        Me.Label16.Text = "Descripción:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(74, 129)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(41, 13)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "Monto:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(11, 103)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 13)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Fecha de aplicación:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 77)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Fecha del convenio:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(67, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Nombre:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(71, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Cliente:"
        '
        'imgLista
        '
        Me.imgLista.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgLista.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgLista.TransparentColor = System.Drawing.Color.Transparent
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(128, 56)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "&Cancelar"
        '
        'ComboBanco1
        '
        Me.ComboBanco1.Location = New System.Drawing.Point(104, 144)
        Me.ComboBanco1.Name = "ComboBanco1"
        Me.ComboBanco1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBanco1.TabIndex = 0
        '
        'txtDPMonto
        '
        Me.txtDPMonto.Location = New System.Drawing.Point(121, 129)
        Me.txtDPMonto.Name = "txtDPMonto"
        Me.txtDPMonto.Size = New System.Drawing.Size(100, 21)
        Me.txtDPMonto.TabIndex = 5
        '
        'frmSelTipoCobro
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(618, 396)
        Me.Controls.Add(Me.tabTipoCobro)
        Me.Controls.Add(Me.btnCancelar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSelTipoCobro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Captura de cobros"
        Me.tabTipoCobro.ResumeLayout(False)
        Me.tbEfectivoVales.ResumeLayout(False)
        Me.grpEfectivoVales.ResumeLayout(False)
        Me.grpEfectivoVales.PerformLayout()
        Me.tbTarjetaCredito.ResumeLayout(False)
        Me.grpTarjetaCredito.ResumeLayout(False)
        Me.grpTarjetaCredito.PerformLayout()
        Me.tbChequeFicha.ResumeLayout(False)
        Me.tbChequeFicha.PerformLayout()
        Me.grpChequeFicha.ResumeLayout(False)
        Me.grpChequeFicha.PerformLayout()
        Me.tbSaldoAFavor.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpOrigen.ResumeLayout(False)
        Me.grpOrigen.PerformLayout()
        Me.tbNotaCredito.ResumeLayout(False)
        Me.gpbNotaCredito.ResumeLayout(False)
        Me.gpbNotaCredito.PerformLayout()
        Me.tbDacionPago.ResumeLayout(False)
        Me.grpDacionPago.ResumeLayout(False)
        Me.grpDacionPago.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Cobros"

    'EFECTIVO Y / O VALES
    Private Sub btnAceptarEfectivoVales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptarEfectivoVales.Click
        'Validar que el tipo de cobro seleccionado se puede capturar en este tipo de movimiento JAG 23-01-2008
        If GLOBAL_ValidarTipoCobro Then
            If Not ValidarTipoCobro(_TipoMovimientoCaja, SigaMetClasses.Enumeradores.enumTipoCobro.EfectivoVales) Then
                Exit Sub
            End If
        End If

        If CapturaEfectivoVales = False Then
            If txtTotalEfectivoVales.Text <> "" And IsNumeric(txtTotalEfectivoVales.Text) Then
                If _CapturaDetalle = True Then
                    Dim frmCaptura As frmCapCobranzaDoc
                    If Not _EsRelacionCobranza Then
                        frmCaptura = New frmCapCobranzaDoc(_TipoMovimientoCaja, _SoloDocumentosCartera, _ListaCobros)
                    Else
                        frmCaptura = New frmCapCobranzaDoc(_TipoMovimientoCaja, _SoloDocumentosCartera, _ListaCobros, _RelacionCobranza)
                    End If

                    frmCaptura.TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.EfectivoVales
                    frmCaptura.ImporteCobro = CType(txtTotalEfectivoVales.Text, Decimal)

                    If frmCaptura.ShowDialog = DialogResult.OK Then
                        With Cobro
                            .Consecutivo = _Consecutivo
                            .AnoCobro = CType(FechaOperacion.Year, Short)
                            .TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.EfectivoVales
                            .Total = frmCaptura.ImporteCobro
                            .ListaPedidos = frmCaptura.ListaCobroPedido
                            ImporteTotalCobro = .Total
                        End With
                        DialogResult = DialogResult.OK
                    End If

                Else
                    With Cobro
                        .Consecutivo = _Consecutivo
                        .AnoCobro = CType(FechaOperacion.Year, Short)
                        .TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.EfectivoVales
                        .Total = CType(txtTotalEfectivoVales.Text, Decimal)
                        ImporteTotalCobro = .Total
                        .ListaPedidos = Nothing
                    End With
                    DialogResult = DialogResult.OK
                End If

            End If
        Else
            MessageBox.Show("Ya capturó efectivo o vales")
        End If
    End Sub

    'TARJETA DE CREDITO
    Private Sub btnAceptarTarjetaCredito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptarTarjetaCredito.Click
        'Validar que el tipo de cobro seleccionado se puede capturar en este tipo de movimiento JAG 23-01-2008
        If GLOBAL_ValidarTipoCobro Then
            If Not ValidarTipoCobro(_TipoMovimientoCaja, SigaMetClasses.Enumeradores.enumTipoCobro.TarjetaCredito) Then
                Exit Sub
            End If
        End If

        If lblClienteNombre.Text <> "" Then
            If txtImporteTC.Text <> "" And IsNumeric(txtImporteTC.Text) Then
                If _CapturaDetalle = True Then
                    Dim frmCaptura As New frmCapCobranzaDoc(_TipoMovimientoCaja, _SoloDocumentosCartera, _ListaCobros)
                    frmCaptura.TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.TarjetaCredito
                    frmCaptura.ImporteCobro = CType(txtImporteTC.Text, Decimal)

                    If frmCaptura.ShowDialog = DialogResult.OK Then
                        With Cobro
                            .Consecutivo = _Consecutivo
                            .AnoCobro = CType(FechaOperacion.Year, Short)
                            .TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.TarjetaCredito
                            .Total = frmCaptura.ImporteCobro
                            .Cliente = CType(txtClienteTC.Text, Integer)
                            .Banco = CType(lblBanco.Text, Short)
                            .NoCuenta = lblTarjetaCredito.Text
                            .ListaPedidos = frmCaptura.ListaCobroPedido
                            ImporteTotalCobro = .Total
                        End With
                        DialogResult = DialogResult.OK
                    End If
                Else
                    With Cobro
                        .Consecutivo = _Consecutivo
                        .AnoCobro = CType(FechaOperacion.Year, Short)
                        .TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.TarjetaCredito
                        .Total = CType(txtImporteTC.Text, Decimal)
                        .Cliente = CType(txtClienteTC.Text, Integer)
                        .Banco = CType(lblBanco.Text, Short)
                        .NoCuenta = lblTarjetaCredito.Text
                        .ListaPedidos = Nothing
                        ImporteTotalCobro = .Total
                    End With
                    DialogResult = DialogResult.OK
                End If
            Else
                MessageBox.Show("Debe teclear el importe del cobro.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("Debe teclear el número de cliente.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        If chkCapturaTPV.Checked Then
            If txtNumeroTarjeta.Text.Trim.Length = 0 Then
                MessageBox.Show("Debe teclear el número de autorización.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub



    'CHEQUE Y FICHA DE DEPOSITO
    Private Sub btnAceptarChequeFicha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptarChequeFicha.Click
        'Validar que el tipo de cobro seleccionado se puede capturar en este tipo de movimiento JAG 23-01-2008
        If GLOBAL_ValidarTipoCobro Then
            If Not ValidarTipoCobro(_TipoMovimientoCaja, _TipoCobro) Then
                Exit Sub
            End If
        End If

        'Control de clientes en pagos con cheque
        Dim _cuentaErronea As Boolean

        'Control de cheques posfechados
        Dim _posfechado As Boolean
        '*****

        'Aplicación de notas de crédito válidas
        If _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.NotaCredito And GLOBAL_AplicaValidaciónNotaCredito Then
            'If Not validaNotaCredito(CType(txtDocumento.Text.Trim, Integer)) Then
            '    MessageBox.Show("Esta nota de crédito ya fue aplicada, está cancelada, no es una nota de" & Chr(13) & _
            '                                        "crédito válida o no es una nota de crédito manual, por favor verifique", "Nota no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    Exit Sub
            'End If
        End If

        If txtDocumento.Text.Trim.Length <> 7 And rbCheque.Checked = True Then
            MessageBox.Show("El número de documento debe ser de 7 dígitos.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDocumento.Focus()
            txtDocumento.SelectAll()
            Exit Sub
        End If

        If rbCheque.Checked = True AndAlso
            Not (txtNumeroCuenta.Text.Trim.Length >= CType(Main.GLOBAL_MinLenCuenta, Integer) AndAlso
                txtNumeroCuenta.Text.Trim.Length <= CType(Main.GLOBAL_MaxLenCuenta, Integer)) Then
            MessageBox.Show(mensajeNumeroCuenta(Main.GLOBAL_MinLenCuenta, Main.GLOBAL_MaxLenCuenta) & vbCrLf &
                "verifique.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDocumento.Focus()
            txtDocumento.SelectAll()
            Exit Sub
        End If

        'Validar aquí el consecutivo del número de cheque, parametrizar
        If rbCheque.Checked = True AndAlso GLOBAL_ValidarConsCheque Then
            Try
                If Not numeroCuentaClienteValido(SigaMetClasses.DataLayer.Conexion, CType(txtClienteCheque.Text, Integer),
                    CType(ComboBanco.SelectedValue, Short), Trim(txtNumeroCuenta.Text)) Then
                    Dim _mensajeChequeErroneo As String = "El cliente " & txtClienteCheque.Text.Trim &
                        " no paga regularmente con el número de cuenta que capturó."
                    'Usuario no autorizado para esta captura, no se permite realizarla
                    If Not oSeguridad.TieneAcceso("CAPT_CHQ_CONSECUTIVOERR") Then
                        MessageBox.Show(_mensajeChequeErroneo & vbCrLf &
                        "No podrá continuar con el registro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    Else
                        'Autorización para captura del documento con consecutivo erróneo
                        If MessageBox.Show(_mensajeChequeErroneo & vbCrLf &
                            "¿Desea continuar con su registro?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                            <> DialogResult.Yes Then
                            Exit Sub
                        Else
                            _cuentaErronea = True
                        End If
                    End If
                    '*****
                End If
            Catch ex As Exception
                EventLog.WriteEntry("Application", ex.ToString)
            End Try
        End If
        '*****

        'Control de cheques posfechados
        If rbCheque.Checked = True And GLOBAL_Posfechado Then
            'Comparar contra el periodo máximo
            If DateDiff(DateInterval.Day, DateTime.Today.Date, dtpFechaCheque.Value.Date) > GLOBAL_LimitePosfechado Then
                If MessageBox.Show("Este documento se registrará como posfechado" & vbCrLf &
                                        "¿Desea continuar con su registro?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                                        <> DialogResult.Yes Then
                    Exit Sub
                Else
                    _posfechado = True
                End If
            End If
        End If
        '*****

        If _CargaNotaIngreso = False Then
            If Not ValidaCapturaChequeFicha() Then
                Exit Sub
            End If
        End If

        'Validación de notas de ingreso
        If rbNotaIngreso.Checked AndAlso GLOBAL_ValidarNI Then
            If Not validarNotadeIngreso(txtDocumento.Text) Then
                Exit Sub
            End If
        End If

        If _CapturaDetalle = True Then
            If txtClienteCheque.Text.Trim = "" Then
                MessageBox.Show("El documento no tiene cliente  asignado.", Me.Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If BuscaCobroGlobal(UCase(Trim(txtDocumento.Text)),
                                            CType(Trim(txtClienteCheque.Text), Integer),
                                            CType(ComboBanco.SelectedValue, Short)) = False Then

                Dim frmCaptura As frmCapCobranzaDoc
                If Not _EsRelacionCobranza Then
                    frmCaptura = New frmCapCobranzaDoc(_TipoMovimientoCaja, _SoloDocumentosCartera, _ListaCobros)
                Else
                    frmCaptura = New frmCapCobranzaDoc(_TipoMovimientoCaja, _SoloDocumentosCartera, _ListaCobros, _RelacionCobranza)
                End If
                frmCaptura.TipoCobro = _TipoCobro
                frmCaptura.ImporteCobro = CType(txtImporteDocumento.Text, Decimal)

                'Para control de saldos a favor (Le pasamos el cliente del cheque para validar que se pueda capturar) 04/04/2005
                frmCaptura.Cliente = CType(Val(txtClienteCheque.Text), Integer)

                'Validar el contrato en la aplicación de pagos con cheque
                If GLOBAL_ValidarClienteCheque Then
                    Dim ClientesRelacionados As New CyCSaldoAFavor.saldoAFavor()
                    frmCaptura.ClientesRelacionados(CType(Val(txtClienteCheque.Text), Integer)) =
                        ClientesRelacionados.ClientesRelacionados(CType(Val(txtClienteCheque.Text), Integer), GLOBAL_connection)
                End If
                '****

                If frmCaptura.ShowDialog() = DialogResult.OK Then
                    With Cobro
                        .Consecutivo = _Consecutivo
                        .AnoCobro = CType(FechaOperacion.Year, Short)
                        .TipoCobro = _TipoCobro
                        .Total = frmCaptura.ImporteCobro
                        .Saldo = frmCaptura.ImporteRestante
                        .NoCheque = Trim(txtDocumento.Text)
                        .FechaCheque = dtpFechaCheque.Value.Date
                        .NoCuenta = Trim(txtNumeroCuenta.Text)
                        .Cliente = CType(txtClienteCheque.Text, Integer)
                        .Banco = CType(ComboBanco.SelectedValue, Short)
                        .Observaciones = Trim(txtObservaciones.Text)
                        .ListaPedidos = frmCaptura.ListaCobroPedido
                        ImporteTotalCobro = .Total

                        'Se agregó para captura de transferencias bancarias
                        '23-03-2005 JAG
                        .NoCuentaDestino = txtNumeroCuentaOrigen.Text
                        .BancoOrigen = CType(ComboBancoOrigen.SelectedValue, Short)

                        .SaldoAFavor = frmCaptura.SaldoAFavor

                        'Control de cheques posfechados
                        If rbCheque.Checked = True Then
                            .Posfechado = _posfechado
                        End If
                    End With

                    'Control de clientes en pagos con cheque
                    If _cuentaErronea Then
                        'Registrar en bitácora si se realiza el registro
                        Try
                            Main.BitacoraCheque(SigaMetClasses.DataLayer.Conexion, Nothing, Nothing, CType(txtClienteCheque.Text, Integer),
                                "Registro de cheque con cuenta errónea: " & CType(CType(ComboBanco.SelectedItem(), DataRowView)(1), String).Trim &
                                " " & Trim(txtNumeroCuenta.Text) & " " & Trim(txtDocumento.Text), GLOBAL_IDUsuario)
                        Catch ex As Exception
                            EventLog.WriteEntry("Application", ex.ToString)
                        End Try
                    End If
                    '*****

                    'Control de cheques posfechados
                    _ChequePosfechado = Cobro.Posfechado
                    '*****

                    DialogResult = DialogResult.OK
                End If
            Else
                MessageBox.Show("El cobro ya existe en el movimiento.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            With Cobro
                .Consecutivo = _Consecutivo
                .AnoCobro = CType(FechaOperacion.Year, Short)
                .TipoCobro = _TipoCobro
                .Total = CType(txtImporteDocumento.Text, Decimal)
                .Saldo = 0
                .NoCheque = Trim(txtDocumento.Text)
                .FechaCheque = dtpFechaCheque.Value.Date
                .NoCuenta = Trim(txtNumeroCuenta.Text)
                .Cliente = CType(txtClienteCheque.Text, Integer)
                .Banco = CType(ComboBanco.SelectedValue, Short)
                .Observaciones = Trim(txtObservaciones.Text)
                .ListaPedidos = Nothing
                ImporteTotalCobro = .Total
            End With
            DialogResult = DialogResult.OK
        End If
    End Sub

    'Nota de Credito
    Private Sub btnAceptarNC_Click(sender As Object, e As EventArgs) Handles btnAceptarNC.Click

        'Validar que el tipo de cobro seleccionado se puede capturar en este tipo de movimiento JAG 23-01-2008
        If GLOBAL_ValidarTipoCobro Then
            If Not ValidarTipoCobro(_TipoMovimientoCaja, _TipoCobro) Then
                Exit Sub
            End If
        End If

        If lblIdClienteDato.Text <> "" Then
            If lblImpoteDato.Text <> "" Then
                If _CapturaDetalle = True Then
                    Dim frmCaptura As New frmCapCobranzaDoc(_TipoMovimientoCaja, CType(lblImpoteDato.Text, Decimal), CType(lblIdClienteDato.Text, Integer), txtObserv.Text,
                                                            CType(txtFolio.Text, Integer), txtSerie.Text, _FacturaNC, CType(lblFechaDato.Text, DateTime), _ListaCobros)
                    frmCaptura.TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.NotaCredito
                    frmCaptura.ImporteCobro = CType(lblImpoteDato.Text, Decimal)

                    If frmCaptura.ShowDialog = DialogResult.OK Then
                        With Cobro
                            .Consecutivo = _Consecutivo
                            .AnoCobro = CType(FechaOperacion.Year, Short)
                            .TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.NotaCredito
                            .Total = frmCaptura.ImporteCobro
                            .Cliente = CType(lblIdClienteDato.Text, Integer)
                            '.Banco = CType(lblBanco.Text, Short)
                            '.NoCuenta = lblTarjetaCredito.Text
                            .ListaPedidos = frmCaptura.ListaCobroPedido
                            ImporteTotalCobro = .Total
                        End With
                        DialogResult = DialogResult.OK
                    End If
                Else
                    With Cobro
                        .Consecutivo = _Consecutivo
                        .AnoCobro = CType(FechaOperacion.Year, Short)
                        .TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.NotaCredito
                        .Total = CType(lblImpoteDato.Text, Decimal)
                        .Cliente = CType(lblIdClienteDato.Text, Integer)
                        '.Banco = CType(lblBanco.Text, Short)
                        '.NoCuenta = lblTarjetaCredito.Text
                        .ListaPedidos = Nothing
                        ImporteTotalCobro = .Total
                    End With
                    DialogResult = DialogResult.OK
                End If
            Else
                MessageBox.Show("Debe teclear el importe del cobro.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("Debe teclear el número de cliente.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        If chkCapturaTPV.Checked Then
            If txtNumeroTarjeta.Text.Trim.Length = 0 Then
                MessageBox.Show("Debe teclear el número de autorización.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If

    End Sub

#End Region


    Private Function BuscaCobroGlobal(ByVal Documento As String,
                                      ByVal Cliente As Integer,
                                      ByVal Banco As Short) As Boolean
        Dim _sCobro As SigaMetClasses.sCobro
        For Each _sCobro In _ListaCobros.Items
            If _sCobro.NoCheque = Documento And
                _sCobro.Cliente = Cliente And
                _sCobro.Banco = Banco Then
                Return True
                Exit Function
            End If
        Next
        Return False

    End Function

    Private Function ValidaCapturaChequeFicha() As Boolean
        If txtImporteDocumento.Text = "" Or Not IsNumeric(txtImporteDocumento.Text) Then
            MessageBox.Show("Debe teclear el importe del documento.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        If Trim(txtDocumento.Text) = "" Or Not IsNumeric(txtDocumento.Text) Then
            MessageBox.Show("Debe teclear el número del documento.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDocumento.Focus()
            txtDocumento.SelectAll()
            Return False
        End If

        If txtDocumento.Text.Trim.Length <> 7 And rbCheque.Checked = True Then
            MessageBox.Show("El número de documento debe ser de 7 dígitos.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDocumento.Focus()
            txtDocumento.SelectAll()
            Return False
        End If

        If Trim(txtNumeroCuenta.Text) = "" Or Not IsNumeric(txtNumeroCuenta.Text) Then
            MessageBox.Show("Debe teclear el número de cuenta.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNumeroCuenta.Focus()
            txtNumeroCuenta.SelectAll()
            Return False
        End If

        If txtClienteCheque.Text = "" Or Not IsNumeric(txtClienteCheque.Text) Or lblNombre.Text = "" Then
            MessageBox.Show("Debe teclear el número de un cliente válido.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtClienteCheque.Focus()
            txtClienteCheque.SelectAll()
            Return False
        End If

        If _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.Cheque Or _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.FichaDeposito Then
            If CType(ComboBanco.SelectedValue, Short) <= 0 Then
                MessageBox.Show("Debe seleccionar el banco.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If
        End If

        'Modificación para captura de transferencias bancarias
        '23-03-2005 Jorge A. Guerrero Domínguez
        If _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.Transferencia Then

            If Trim(txtNumeroCuentaOrigen.Text) = "" Or Not IsNumeric(txtNumeroCuentaOrigen.Text) Then
                MessageBox.Show("Debe teclear el número de cuenta origen.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtNumeroCuenta.Focus()
                txtNumeroCuenta.SelectAll()
                Return False
            End If

        End If


        Return True
    End Function

    Private Sub tabTipoCobro_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabTipoCobro.SelectedIndexChanged
        Select Case tabTipoCobro.SelectedTab.Name
            Case Is = "tbEfectivoVales"
                AcceptButton = btnAceptarEfectivoVales
                txtTotalEfectivoVales.Focus()
            Case Is = "tbChequeFicha"
                AcceptButton = btnAceptarChequeFicha
                txtCodigo.Focus()
            Case Is = "tbTarjetaCredito"
                AcceptButton = btnAceptarTarjetaCredito
                txtClienteTC.Focus()
            Case Is = "tbNotaCredito"
                AcceptButton = btnAceptarNotaCredito
                txtFolio.Select()
        End Select
    End Sub

    Private Sub frmSelTipoCobro_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBanco.CargaDatos(CargaBancoCero:=True, MostrarClaves:=True, SoloActivos:=True)
        'TDC
        comboBancoTDC.CargaDatos(CargaBancoCero:=False, MostrarClaves:=True, SoloActivos:=True)

        If _TipoMovimientoCaja = 35 Then

            tbNotaCredito.Enabled = True
            tbChequeFicha.Enabled = False
            tbEfectivoVales.Enabled = False
            tbSaldoAFavor.Enabled = False
            tbTarjetaCredito.Enabled = False
            tabTipoCobro.SelectedTab = tbNotaCredito
            lblIdClienteDato.Text = _IdCliente
            lblNombreClienteDato.Text = _NombreCliente
            btnAceptarNC.Enabled = False

        End If

        If CapturaEfectivoVales = True Then
            btnAceptarEfectivoVales.Enabled = False
            tabTipoCobro.SelectedTab = tbChequeFicha
        End If
        AddHandler txtImporteTC.KeyDown, AddressOf ManejaFlechas

        'Modificación para captura de transferencias bancarias
        '23-03-2005 Jorge A. Guerrero Domínguez
        If GLOBAL_TransferenciaActiva AndAlso
           _TipoMovimientoCaja = GLOBAL_TipoMovimientoTransferencia Then 'Transferencia bancaria
            rbTransferencia.Enabled = True
            'rbTransferencia.Checked = True
            tabTipoCobro.SelectedTab = tbChequeFicha
        End If

        'Modificacion para captura de abonos por saldo a favor
        If Not GLOBAL_AplicacionSaldoAFavor Then
            Me.tbSaldoAFavor.Enabled = False
        End If

        'Captura de recibos TPV
        Me.chkCapturaTPV.Visible = oSeguridad.TieneAcceso("CAPTURA_TPV")

        'Permitir Solo notas de crédito capturadas
        chkCargarNI.Enabled = Not GLOBAL_SoloNICapturada
    End Sub

    Private Sub txtClienteTC_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AcceptButton = btnBuscarClienteTC
    End Sub

    Private Sub txtClienteTC_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AcceptButton = btnAceptarTarjetaCredito
    End Sub

    Private Sub LimpiaInfoTarjetaCredito()
        lblClienteNombre.Text = ""
        lblTitular.Text = ""
        lblTarjetaCredito.Text = ""
        lblBancoNombre.Text = ""
        lblTipoTarjetaCredito.Text = ""
        lblVigencia.Text = ""
    End Sub

    Private Function ConsultaTarjetaCredito(ByVal Cliente As Integer) As Boolean
        Dim oTC As New SigaMetClasses.cTarjetaCredito()
        Dim dr As SqlDataReader
        Dim existe As Boolean
        dr = oTC.ConsultaActiva(Cliente)
        Do While dr.Read
            lblClienteNombre.Text = CType(dr("ClienteNombre"), String)
            lblTitular.Text = CType(dr("Titular"), String)
            lblTarjetaCredito.Text = CType(dr("TarjetaCredito"), String)
            lblBanco.Text = CType(dr("Banco"), String)
            lblBancoNombre.Text = CType(dr("BancoNombre"), String)
            lblTipoTarjetaCredito.Text = CType(dr("TipoTarjetaCreditoDescripcion"), String)
            lblVigencia.Text = CType(dr("MesVigencia"), String) & " / " & CType(dr("AñoVigencia"), String)
        Loop
        existe = dr.HasRows
        dr.Close()
        Return existe
    End Function

    Private Sub btnBuscarClienteTC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarClienteTC.Click
        If txtClienteTC.Text <> "" And IsNumeric(txtClienteTC.Text) Then
            LimpiaInfoTarjetaCredito()
            If Not chkCapturaTPV.Checked Then
                If ConsultaTarjetaCredito(CType(txtClienteTC.Text, Integer)) Then
                    Dim CargosTarjetas As List(Of SigaMetClasses.CargoTarjeta)
                    Dim objCargoTarjetaDatos As New SigaMetClasses.CargoTarjetaDatos
                    CargosTarjetas = objCargoTarjetaDatos.consultarCargoTarjeta(txtClienteTC.Text)
                    If CargosTarjetas.Count > 0 Then
                        Dim frmConsultaCargo As SigaMetClasses.frmConsultaCargoTarjetaCliente
                        frmConsultaCargo = New SigaMetClasses.frmConsultaCargoTarjetaCliente
                        frmConsultaCargo.Cliente = txtClienteTC.Text
                        If frmConsultaCargo.ShowDialog() = DialogResult.OK Then
                            lblTarjetaCredito.Text = frmConsultaCargo.CargoTarjeta.NumeroTarjeta
                            lblBancoNombre.Text = frmConsultaCargo.CargoTarjeta.NombreBanco
                            lblTipoTarjetaCredito.Text = frmConsultaCargo.CargoTarjeta.TipoCobroDescripcion
                            txtImporteTC.Text = CType(frmConsultaCargo.CargoTarjeta.Importe, String)

                            CargoTarjetaSeleccionado = frmConsultaCargo.CargoTarjeta

                        End If
                    End If
                Else
                    TPVConsultaCliente()
                End If
                'TODO: Validacion de clientes hijos de edificios adminstrados 13/10/2004
                If GLOBAL_AplicaAdmEdificios Then
                    btnAceptarTarjetaCredito.Enabled = True
                    Dim oCliente As New SigaMetClasses.cCliente(CType(txtClienteTC.Text, Integer))
                    If Not (validacionDeClientesHijosEdificio(oCliente, GLOBAL_AplicaValidacionClienteHijo,
                        GLOBAL_ClientePadreEdificio)) Then
                        btnAceptarTarjetaCredito.Enabled = False
                    End If
                End If
                'Fin de la validacion de edificios admistrados
                If lblTarjetaCredito.Text = "" AndAlso Not chkCapturaTPV.Checked Then
                    MessageBox.Show("No existen tarjetas de crédito del cliente especificado.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    txtImporteTC.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub ManejaFlechas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFechaCheque.KeyDown, MyBase.KeyDown
        If e.KeyCode = Keys.F5 Then
            tabTipoCobro.SelectedTab = tbEfectivoVales
            Exit Sub
        End If
        If e.KeyCode = Keys.F6 Then
            tabTipoCobro.SelectedTab = tbChequeFicha
            Exit Sub
        End If
        If e.KeyCode = Keys.F7 Then
            tabTipoCobro.SelectedTab = tbTarjetaCredito
        End If
        If e.KeyCode = Keys.Down Then
            SendKeys.Send("{TAB}")
        End If
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Then
            Select Case tabTipoCobro.SelectedTab.Name
                Case Is = "tbEfectivoVales"
                    If e.KeyCode = Keys.Right Then tabTipoCobro.SelectedTab = tbChequeFicha
                    If e.KeyCode = Keys.Left Then tabTipoCobro.SelectedTab = tbTarjetaCredito
                Case Is = "tbCheque"
                    If e.KeyCode = Keys.Right Then tabTipoCobro.SelectedTab = tbTarjetaCredito
                    If e.KeyCode = Keys.Left Then tabTipoCobro.SelectedTab = tbEfectivoVales
                Case Is = "tbTarjetaCredito"
                    If e.KeyCode = Keys.Right Then tabTipoCobro.SelectedTab = tbEfectivoVales
                    If e.KeyCode = Keys.Left Then tabTipoCobro.SelectedTab = tbChequeFicha
            End Select
        End If
    End Sub

    Private Sub rbCheque_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCheque.CheckedChanged
        _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.Cheque
        txtDocumento.MaxLength = 7
        _CargaNotaIngreso = False
    End Sub

    Private Sub rbFicha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbFicha.CheckedChanged
        _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.FichaDeposito
        txtDocumento.MaxLength = 10
        _CargaNotaIngreso = False

        'Selección del número de cuenta por medio de un combo 'ver si se parametriza

        cboNumeroCuenta.Visible = rbFicha.Checked
        ComboBanco.Enabled = Not rbFicha.Checked
        If rbFicha.Checked Then
            cboNumeroCuenta.DataSource = DTListaBancos
            cboNumeroCuenta.ValueMember = "Cuenta"
            cboNumeroCuenta.DisplayMember = "NombreCompuesto"
            AddHandler cboNumeroCuenta.SelectedValueChanged, AddressOf cboNumeroCuenta_SelectedValueChanged
            cboNumeroCuenta_SelectedValueChanged(sender, e)
            ComboBanco.BackColor = Color.White
        Else
            RemoveHandler cboNumeroCuenta.SelectedValueChanged, AddressOf cboNumeroCuenta_SelectedValueChanged
        End If

    End Sub

    Private Sub rbNotaCredito_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbNotaCredito.CheckedChanged
        _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.NotaCredito
        txtDocumento.MaxLength = 10
        _CargaNotaIngreso = False

        InactivarControlesNC()
    End Sub

    Private Sub rbNotaIngreso_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbNotaIngreso.CheckedChanged
        _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.NotaIngreso
        txtDocumento.MaxLength = 10
        chkCargarNI.Visible = rbNotaIngreso.Checked
        _CargaNotaIngreso = True

        'Inactivar las opciones de captura de datos si se selecciona carga de nota de ingreso
        InactivaControlesNI(rbNotaIngreso.Checked AndAlso chkCargarNI.Checked)
    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        If Trim(txtClienteCheque.Text) <> "" Then
            Dim frmConCliente As New SigaMetClasses.frmConsultaCliente(CType(txtClienteCheque.Text, Integer))
            frmConCliente.ShowDialog()
        End If
    End Sub

    Private Sub txtClienteCheque_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtClienteCheque.Leave
        If Trim(txtClienteCheque.Text) <> String.Empty Then
            Dim oCliente As New SigaMetClasses.cCliente()
            oCliente.Consulta(CType(txtClienteCheque.Text, Integer))
            lblNombre.Text = oCliente.Nombre
            'TODO: Validacion para clientes de adminsitracion de edificios 13/10/2004
            If GLOBAL_AplicaAdmEdificios Then
                btnAceptarChequeFicha.Enabled = True
                If Not (validacionDeClientesHijosEdificio(oCliente, GLOBAL_AplicaValidacionClienteHijo,
                        GLOBAL_ClientePadreEdificio)) Then
                    btnAceptarChequeFicha.Enabled = False
                End If
            End If
            'Fin de la validacion de cobranza de edificios administrados
            oCliente = Nothing
        End If
    End Sub

    Private Sub LeerCodigoCheque(ByVal strCodigo As String)
        Dim NumeroCuenta As String
        Dim NumeroCheque As String
        NumeroCuenta = Mid(strCodigo, 16, 11)
        NumeroCheque = Mid(strCodigo, 28, 7)

        txtNumeroCuenta.Text = NumeroCuenta
        'txtDocumento.Text = NumeroCheque.Substring(4, 4)
        txtDocumento.Text = NumeroCheque
    End Sub


    Private Sub txtCodigo_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigo.Enter
        Me.AcceptButton = btnLeerCodigo
    End Sub


    Private Sub txtCodigo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigo.Leave
        Me.AcceptButton = btnAceptarChequeFicha
    End Sub

    Private Sub btnLeerCodigo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeerCodigo.Click
        On Error Resume Next
        LeerCodigoCheque(txtCodigo.Text)
        txtCodigo.Text = ""
        If Not (txtNumeroCuentaOrigen.Enabled) Then
            txtClienteCheque.SelectAll()
            txtClienteCheque.Focus()
        Else
            txtNumeroCuentaOrigen.SelectAll()
            txtNumeroCuentaOrigen.Focus()
        End If
    End Sub

    Private Sub CargarNI(ByVal strClave As String)
        'Se retira la consulta y se coloca en un procedimiento almacenado
        'Dim strQuery As String = "Select Clave, Total, FMovimiento, Cliente From MovimientoCaja Where Clave = '" & strClave & "'"
        Dim strQuery As String = "spCyCCargaNotaIngreso"
        'Dim da As New SqlDataAdapter(strQuery, SigaMetClasses.LeeInfoConexion(False))
        Dim da As New SqlDataAdapter(strQuery, GLOBAL_connection)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.Add("@Clave", SqlDbType.VarChar, 20)
        da.SelectCommand.Parameters("@Clave").Value = strClave
        Dim dt As New DataTable("MovimientoCaja")

        Try
            da.Fill(dt)
            If dt.Rows.Count = 1 Then
                If Not IsDBNull(dt.Rows(0).Item("Cliente")) Then txtClienteCheque.Text = CType(dt.Rows(0).Item("Cliente"), Integer).ToString
                txtImporteDocumento.Text = CType(dt.Rows(0).Item("Total"), Decimal).ToString("N")
                dtpFechaCheque.Value = CType(dt.Rows(0).Item("FMovimiento"), Date)
                txtNumeroCuenta.Text = "0"
                txtNumeroCuenta.Enabled = False
                txtClienteCheque.Enabled = False
                txtImporteDocumento.Enabled = False
                dtpFechaCheque.Enabled = False
                ComboBanco.SelectedValue = 0
                ComboBanco.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtDocumento_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDocumento.Leave
        If Me.rbNotaIngreso.Checked And chkCargarNI.Checked = True Then
            CargarNI(txtDocumento.Text)
        Else
            txtClienteCheque.Enabled = True
            txtImporteDocumento.Enabled = True
            'txtNumeroCuenta.Text = ""
            dtpFechaCheque.Enabled = True
        End If
        'Si aplica carga los datos de las notas de crédito
        CargaDeNotasCredito()
        '*****
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub chkCargarNI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCargarNI.CheckedChanged
        _CargaNotaIngreso = chkCargarNI.Checked
    End Sub

#Region "Validacion de cliente hijo para edificio "
    'TODO: Validacion de clientes de edificios administrados, cuando se captura una cobranza de edificio administrado
    'verifica que solo se capturen clientes hijos como detalles de la cobranza
    'JAGD 13/10/2004
    Private Function validacionDeClientesHijosEdificio(ByVal oCliente As SigaMetClasses.cCliente,
        ByVal aplicaValidacionClienteHIjo As Boolean,
        ByVal clientePadreEdificio As Integer) As Boolean
        If aplicaValidacionClienteHIjo Then
            If Not (oCliente.ClientePadre = clientePadreEdificio) Then
                MessageBox.Show("Ha sido seleccionado el tipo de cobranza de 'Edificios Administrados' por lo" & Chr(13) &
                            "que se requiere el contrato de un cliente hijo de Administración de Edificios" & Chr(13) &
                            "asignado al contrato padre " & CStr(clientePadreEdificio), "Validacion del no. de contrato",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False 'Devuelve falso si no es un cliente hijo de edificio adminsitado
            Else
                Return True
            End If
        Else
            Return True 'Devuelve verdadero si no está habiltada la validación de clientes hijos
        End If
    End Function

#End Region

#Region "Validación de nota de crédito"
    Private Structure NotaCredito
        Public Factura As Integer
        Public Cliente As Integer
        Public FFactura As Date
        Public Total As Decimal
        Public Status As String
        Public Clave As String
    End Structure

    'Consulta de información a la base de datos para validación de notas de crédito.
    Private Function validaNotaCredito(ByVal Folio As Integer) As NotaCredito
        'Dim connection As New SqlConnection(SigaMetClasses.LeeInfoConexion(False))
        Dim _notaCredito As NotaCredito = Nothing
        Dim connection As SqlConnection = GLOBAL_connection
        Dim cmdSelect As New SqlCommand()
        cmdSelect.CommandText = "spCyCValidaAplicacionNotaCredito"
        cmdSelect.CommandType = CommandType.StoredProcedure
        cmdSelect.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
        cmdSelect.Connection = connection
        Dim reader As SqlDataReader
        Try
            connection.Open()
            reader = cmdSelect.ExecuteReader
            While reader.Read()
                _notaCredito.Factura = CType(reader("Factura"), Integer)
                _notaCredito.Cliente = CType(reader("Cliente"), Integer)
                _notaCredito.FFactura = CType(reader("FFactura"), Date)
                _notaCredito.Total = CType(reader("Total"), Decimal)
                _notaCredito.Status = CType(reader("Status"), String)
                _notaCredito.Clave = CType(reader("Clave"), String)
            End While
            reader.Close()
        Catch ex As SqlException
            MessageBox.Show("Ha ocurrido el siguiente error" & Chr(13) & ex.Number & " " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido el siguiente error" & Chr(13) & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
            cmdSelect.Dispose()
            'connection.Dispose()
        End Try
        Return _notaCredito
    End Function

    'Inactivar los controles para captura de notas de crédito
    Private Sub InactivarControlesNC()
        If Not GLOBAL_AplicaValidaciónNotaCredito Then
            Exit Sub
        End If

        dtpFechaCheque.Enabled = Not rbNotaCredito.Checked
        txtNumeroCuenta.Enabled = Not rbNotaCredito.Checked
        txtClienteCheque.Enabled = Not rbNotaCredito.Checked
        ComboBanco.Enabled = Not rbNotaCredito.Checked
        txtImporteDocumento.Enabled = Not rbNotaCredito.Checked
        btnBusquedaCliente.Enabled = Not rbNotaCredito.Checked

        If Not rbNotaCredito.Checked Then
            ReiniciarControlesNotaCredito()
        End If
    End Sub

    'Reinicializar los controles usados para captura de datos de nota de crédito
    Private Sub ReiniciarControlesNotaCredito()
        txtClienteCheque.Text = String.Empty
        txtImporteDocumento.Text = String.Empty
        txtNumeroCuenta.Text = String.Empty
        lblNombre.Text = String.Empty
    End Sub

    'Consulta y valida los datos de la nota de crédito y muestra en pantalla en los campos correspondientes
    Private Sub CargaDeNotasCredito()
        If rbNotaCredito.Checked Then
            ReiniciarControlesNotaCredito()
            If Not GLOBAL_AplicaValidaciónNotaCredito Then
                Exit Sub
            End If
            InactivarControlesNC()
            Dim _notaCredito As NotaCredito
            _notaCredito = validaNotaCredito(CType(txtDocumento.Text, Integer))
            If _notaCredito.Factura > 0 Then
                Select Case _notaCredito.Status.Trim.ToUpper()
                    Case "IMPRESO"
                        'validación de días de ajuste para la nota de crédito (cierres de mes)
                        Dim mesAnterior As Integer
                        Dim cierreMes As Boolean
                        If FechaOperacion.Day <= GLOBAL_DiasAjuste Then
                            cierreMes = True
                            mesAnterior = DateAdd(DateInterval.Month, -1, FechaOperacion).Month
                        End If

                        txtClienteCheque.Text = _notaCredito.Cliente.ToString()
                        dtpFechaCheque.Value = _notaCredito.FFactura
                        'La nota de crédito debe corresponder al mes de la captura de cobranza
                        'o en caso de cierre de mes, debe corresponder al mes en curso o al mes
                        'anterior
                        If Not (_notaCredito.FFactura.Year = FechaOperacion.Year AndAlso
                            (_notaCredito.FFactura.Month = FechaOperacion.Month OrElse
                            (cierreMes AndAlso _notaCredito.FFactura.Month = mesAnterior))) Then
                            txtDocumento.Focus()
                            MessageBox.Show("Esta nota de crédito no corresponde" & vbCrLf &
                                "al mes en curso." & _notaCredito.Clave & ".", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If
                        txtImporteDocumento.Text = _notaCredito.Total.ToString()
                        ComboBanco.SelectedValue = 0
                        txtNumeroCuenta.Text = "0"
                        txtClienteCheque_Leave(Nothing, Nothing)
                    Case "APLICADO"
                        txtDocumento.Focus()
                        MessageBox.Show("Esta nota de crédito fué aplicada en" & vbCrLf &
                            "el movimiento " & _notaCredito.Clave & ".", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Case Else
                        txtDocumento.Focus()
                        MessageBox.Show("Esta nota de crédito está cancelada" & vbCrLf &
                            "o no ha sido impresa.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End Select
            End If
        End If
    End Sub
#End Region

    Private Sub rbTransferencia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTransferencia.CheckedChanged
        _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.Transferencia
        If Not (rbTransferencia.Checked) Then
            txtNumeroCuentaOrigen.Enabled = False
            ComboBancoOrigen.DataSource = Nothing
            ComboBancoOrigen.Enabled = False
            ComboBancoOrigen.Items.Clear()
            lblBancoOrigen.Text = String.Empty
            lblCtaDestino.Text = String.Empty
        Else
            txtNumeroCuentaOrigen.Enabled = True
            ComboBancoOrigen.Enabled = True
            ComboBancoOrigen.CargaDatos(CargaBancoCero:=True, MostrarClaves:=True, SoloActivos:=True)
            ComboBancoOrigen.SelectedIndex = 0
            lblBancoOrigen.Text = "Banco Origen:"
            lblCtaDestino.Text = "No. Cuenta Origen:"
        End If
    End Sub

    Private Sub btnSFBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSFBuscar.Click
        CleanSaldoAFavor()
        'Dim cnSigamet As New SqlClient.SqlConnection(ConString)
        Dim cnSigamet As SqlClient.SqlConnection = GLOBAL_connection
        Dim consultaSaldoAFavor As New CyCSaldoAFavor.frmSaldosAFavor(cnSigamet, txtSFClave.Text,
            CType(Val(txtSFCliente.Text), Integer), CType(Val(txtSFAñoAtt.Text), Integer),
            CType(Val(txtSFFolioAtt.Text), Integer))
        If consultaSaldoAFavor.ShowDialog() = DialogResult.OK Then
            lblSFAñoCobro.Text = consultaSaldoAFavor.AnioCobro.ToString
            lblSFCobro.Text = consultaSaldoAFavor.Cobro.ToString
            lblSFCliente.Text = consultaSaldoAFavor.Cliente.ToString
            lblSaldoAFavorNombre.Text = consultaSaldoAFavor.Nombre
            lblSFTipo.Text = consultaSaldoAFavor.TipoDocumento
            lblSFImporte.Text = consultaSaldoAFavor.Importe.ToString
            lblSFMovimientoOrigen.Text = consultaSaldoAFavor.MovimientoOrigen.ToString
        End If
    End Sub

    Private Sub CleanSaldoAFavor()
        lblSFAñoCobro.Text = String.Empty
        lblSFCobro.Text = String.Empty
        lblSFCliente.Text = String.Empty
        lblSaldoAFavorNombre.Text = String.Empty
        lblSFTipo.Text = String.Empty
        lblSFImporte.Text = String.Empty
        lblSFMovimientoOrigen.Text = String.Empty
    End Sub

    Private Sub btnAceptarSF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptarSF.Click
        'Validar que el tipo de cobro seleccionado se puede capturar en este tipo de movimiento JAG 23-01-2008
        If GLOBAL_ValidarTipoCobro Then
            If Not ValidarTipoCobro(_TipoMovimientoCaja, SigaMetClasses.Enumeradores.enumTipoCobro.SaldoAFavor) Then
                Exit Sub
            End If
        End If

        Dim frmCaptura As frmCapCobranzaDoc
        If Not _EsRelacionCobranza Then
            frmCaptura = New frmCapCobranzaDoc(_TipoMovimientoCaja, _SoloDocumentosCartera, _ListaCobros)
        Else
            frmCaptura = New frmCapCobranzaDoc(_TipoMovimientoCaja, _SoloDocumentosCartera, _ListaCobros, _RelacionCobranza)
        End If
        frmCaptura.TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.SaldoAFavor
        frmCaptura.ImporteCobro = CType(lblSFImporte.Text, Decimal)

        'Para control de saldos a favor (Le pasamos el cliente del cheque para validar que se pueda capturar) 04/04/2005
        frmCaptura.Cliente = CType(Val(lblSFCliente.Text), Integer)
        'TODO: Hacer la consulta de la tabla de clientes relacionados en esta parte, habilitar una operación para permitir la captura libre de saldos a favor
        Dim ClientesRelacionados As New CyCSaldoAFavor.saldoAFavor()
        frmCaptura.ClientesRelacionados(CType(Val(lblSFCliente.Text), Integer)) =
            ClientesRelacionados.ClientesRelacionados(CType(Val(lblSFCliente.Text), Integer), GLOBAL_connection)

        If frmCaptura.ShowDialog() = DialogResult.OK Then
            With Cobro
                .Consecutivo = _Consecutivo
                .AnoCobro = CType(FechaOperacion.Year, Short)
                .TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.SaldoAFavor
                .AnioCobroOrigen = CType(Val(lblSFAñoCobro.Text), Short)
                .CobroOrigen = CType(Val(lblSFCobro.Text), Integer)
                .Total = frmCaptura.ImporteCobro
                .Saldo = 0
                .Cliente = CType(Val(lblSFCliente.Text), Integer)
                .Observaciones = "ABONO DE SALDO A FAVOR"
                .ListaPedidos = frmCaptura.ListaCobroPedido
                ImporteTotalCobro = .Total
            End With
            DialogResult = DialogResult.OK
        End If
    End Sub

    Private Sub BuscaBanco(ByVal NumeroCuenta As String)
        Dim cuentaCap As String = NumeroCuenta
        If rbFicha.Checked AndAlso (cuentaCap.Length >= 5) Then
            Dim dr As Data.DataRow
            For Each dr In DTListaBancos.Rows
                Dim cuenta As String = CType(dr("Cuenta"), String).Trim
                If cuentaCap.Substring(cuentaCap.Length - 5) = cuenta.Substring(cuenta.Length - 5) Then
                    ComboBanco.SelectedValue = CType(dr("Banco"), Integer)
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub cboNumeroCuenta_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If rbFicha.Checked Then
            txtNumeroCuenta.Text = CType(cboNumeroCuenta.SelectedValue, String).Trim
            BuscaBanco(txtNumeroCuenta.Text.Trim)
        End If
    End Sub

#Region "Pagos con recibo TP TC"

    Private Sub chkCapturaTPV_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCapturaTPV.CheckedChanged
        LimpiaInfoTarjetaCredito()

        Me.lblTarjetaCredito.Visible = Not chkCapturaTPV.Checked
        Me.lblBancoNombre.Visible = Not chkCapturaTPV.Checked
        Me.lblBanco.Visible = Not chkCapturaTPV.Checked

        Me.txtNumeroTarjeta.Visible = chkCapturaTPV.Checked
        Me.comboBancoTDC.Visible = chkCapturaTPV.Checked
        If chkCapturaTPV.Checked Then
            lblTxtTarjeta.Text = "No. Autorización"
            Me.grpTarjetaCredito.Controls.Add(Me.comboBancoTDC)
            Me.grpTarjetaCredito.Controls.Add(Me.txtNumeroTarjeta)
            AddHandler comboBancoTDC.SelectedIndexChanged, AddressOf cboBanco_SelectedIndexChanged
            cboBanco_SelectedIndexChanged(sender, e)
        Else
            lblTxtTarjeta.Text = "No. Tarjeta:"
            Me.grpTarjetaCredito.Controls.Remove(Me.comboBancoTDC)
            Me.grpTarjetaCredito.Controls.Remove(Me.txtNumeroTarjeta)
            RemoveHandler comboBancoTDC.SelectedIndexChanged, AddressOf cboBanco_SelectedIndexChanged
            Me.lblTarjetaCredito.Text = String.Empty
            Me.lblBancoNombre.Text = String.Empty
            Me.lblBanco.Text = String.Empty
        End If
    End Sub

    Private Sub txtTarjetaCredito_Changed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumeroTarjeta.TextChanged
        Me.lblTarjetaCredito.Text = txtNumeroTarjeta.Text
    End Sub

    Private Sub cboBanco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.lblBanco.Text = CType(comboBancoTDC.SelectedValue, String)
    End Sub

    Private Sub TPVConsultaCliente()
        Dim oCliente As New SigaMetClasses.cCliente()
        oCliente.Consulta(CType(txtClienteTC.Text, Integer))
        lblClienteNombre.Text = oCliente.Nombre
    End Sub

#End Region

    Private Sub btnBusquedaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBusquedaCliente.Click
        Dim buscaClientePadre As New SigaMetClasses.BusquedaCliente(True)
        buscaClientePadre.ShowDialog()
        If buscaClientePadre.DialogResult = DialogResult.OK Then
            txtClienteCheque.Text = CStr(buscaClientePadre.Cliente)
            txtClienteCheque_Leave(sender, e)
        End If
    End Sub

    Private Function mensajeNumeroCuenta(ByVal minimo As Byte, ByVal maximo As Byte) As String
        Dim mensaje As String = "El número de cuenta debe ser de "

        If Not minimo = maximo Then
            mensaje &= minimo.ToString() & " dígitos como mínimo y " & maximo.ToString() + " como máximo"
        Else
            mensaje &= minimo.ToString() & " dígitos"
        End If

        Return mensaje
    End Function

    'Consulta de los números de cuenta que han sido usados por un cliente en pagos previos con cheque
    Private Function numeroCuentaClienteValido(ByVal Connection As SqlConnection,
        ByVal Cliente As Integer,
        ByVal Banco As Short,
        ByVal Cuenta As String) As Boolean

        Dim _numeroCuentaCliente As DataTable
        Dim _ctDr As DataRow
        Dim _encontrado As Boolean = False

        Try
            _numeroCuentaCliente = Main.NumeroCuentaCliente(SigaMetClasses.DataLayer.Conexion, CType(txtClienteCheque.Text, Integer),
                                                CType(ComboBanco.SelectedValue, Short))
            For Each _ctDr In _numeroCuentaCliente.Rows
                _encontrado = (CType(_ctDr("NumeroCuenta"), String).Trim() = Cuenta.Trim)
                If _encontrado Then
                    Exit For
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try

        Return _encontrado
    End Function
    '*****

    'Validación de notas de crédito capturadas
    Private Function validarNotadeIngreso(ByVal ClaveNI As String) As Boolean
        Dim _notaExistente As Boolean
        Dim _notaValida As Boolean

        Dim _passValidacion As Boolean = True

        Try
            _notaValida = Main.ValidacionNotaIngresoValidada(SigaMetClasses.DataLayer.Conexion, txtDocumento.Text)
            _notaExistente = Main.ValidacionNotaIngresoExistente(SigaMetClasses.DataLayer.Conexion, txtDocumento.Text)
        Catch ex As Exception
            Throw ex
        End Try

        'Verificar si la nota de ingreso (movimiento NI) ya fué validada.
        If Not _notaValida Then
            MessageBox.Show("Esta nota de ingreso no ha sido validada, no podrá capturarla" & vbCrLf &
                "Verifique.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            _passValidacion = False
            Exit Function
        End If

        'Verificar si la nota de ingreso ya fué capturada en otro movimiento
        If _notaExistente Then
            MessageBox.Show("Esta nota de ingreso ya fué capturada en otro movimiento," & vbCrLf &
                "no podrá capturarla. Verifique.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            _passValidacion = False
            Exit Function
        End If

        Return _passValidacion
    End Function

    'Inhabilitar los controles de captura de nota de crédito
    Private Sub InactivaControlesNI(ByVal Activar As Boolean)
        If Activar Then
            txtDocumento.Select()
        End If

        Activar = Not Activar
        txtNumeroCuenta.Text = "0"
        txtNumeroCuenta.Enabled = Activar
        txtClienteCheque.Enabled = Activar
        txtImporteDocumento.Enabled = Activar
        dtpFechaCheque.Enabled = Activar
        ComboBanco.SelectedValue = 0
        ComboBanco.Enabled = Activar
    End Sub
    '*****

    'Validar el tipo de cobro con el tipo de movimiento
    Private Function ValidarTipoCobro(ByVal TipoMovimientoCaja As Byte, ByVal TipoCobro As SigaMetClasses.Enumeradores.enumTipoCobro) As Boolean
        Dim _passing As Boolean = False
        Dim _tipoCobro As Byte = CType(TipoCobro, Byte)

        Try
            _passing = Main.ValidacionTipoCobroTipoMovimientoCaja(SigaMetClasses.DataLayer.Conexion, TipoMovimientoCaja, _tipoCobro)
            If Not _passing Then
                MessageBox.Show("No puede utilizar esta forma de pago" & vbCrLf & "en el movimiento que está captuando.", Me.Text,
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message, Me.Text,
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        Return _passing
    End Function

    Private Sub txtSerie_Leave(sender As Object, e As EventArgs) Handles txtSerie.Leave

        If txtFolio.Text <> "" Then
            If txtSerie.Text <> "" Then

                Dim oNotaCredito As New SigaMetClasses.cCliente()
                oNotaCredito.ConsultaNotaCredito(CType(txtFolio.Text, Integer),
                                                 CType(lblIdClienteDato.Text, Integer),
                                                 CType(txtSerie.Text, String))


                If oNotaCredito.TotalNC > 0 Then

                    lblImpoteDato.Text = oNotaCredito.TotalNC.ToString("C2")
                    lblFechaDato.Text = oNotaCredito.FechaNC.ToString()
                    _FacturaNC = oNotaCredito.FacturaNC
                    btnAceptarNC.Enabled = True

                    If oNotaCredito.ExisteNC Then

                        MessageBox.Show("La nota de crédito con Folio " + txtFolio.Text + " y Serie " + txtSerie.Text + ", ya existe", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)

                    End If

                Else

                    MessageBox.Show("No existe la nota de crédito, favor de varificar Serie y Folio", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtFolio.Select()

                End If



            Else

                MessageBox.Show("Debe capturar una Serie", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtSerie.Select()

            End If

        Else

            MessageBox.Show("Debe capturar un Folio", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFolio.Select()

        End If

    End Sub

    Private Sub tbDacionPago_Click(sender As Object, e As EventArgs) Handles tbDacionPago.Click

    End Sub
    '*****
End Class