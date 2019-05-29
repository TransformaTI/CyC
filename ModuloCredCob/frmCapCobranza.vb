Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class frmCapCobranza
    Inherits System.Windows.Forms.Form
    Private Titulo As String = "Captura de cobranza"
    Private ListaCobros As New ArrayList()
    Private Consecutivo As Integer
    Private decImporteTotalCobros As Decimal
    Private _FMovimiento As Date
    Private InicioListo As Boolean = False
    Private _Clave As String
    Private _FOperacion As Date
    Private _Folio As Integer
    Private _Consecutivo As Byte
    Private _Caja As Byte
    Private _URLGateway As String = ""
    Private _Modulo As Short
    Private _FuenteGateway As String

#Region " Windows Form Designer generated code "
    Public Property Modulo() As Short
        Get
            Return _Modulo
        End Get
        Set(value As Short)
            _Modulo = value
        End Set
    End Property
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        dtpFMovimiento.Value = FechaOperacion
        lblFMovimiento.Text = FechaOperacion.ToLongDateString
        cboEmpleado.CargaDatosCredito(True)

        lstCobro.DisplayMember = "InformacionCompleta"
        lstPedido.DisplayMember = "InformacionCompleta"

        cboEmpleado.SelectedValue = GLOBAL_IDEmpleado

        cboRuta.CargaDatos()

        CargaURLGateway()


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
    Friend WithEvents lstPedido As System.Windows.Forms.ListBox
    Friend WithEvents btnCancelar As ControlesBase.BotonBase
    Friend WithEvents btnAceptar As ControlesBase.BotonBase
    Friend WithEvents btnAgregar As ControlesBase.BotonBase
    Friend WithEvents ttDatosPedido As System.Windows.Forms.ToolTip
    Friend WithEvents stbEstatus As System.Windows.Forms.StatusBar
    Friend WithEvents Documentos As System.Windows.Forms.StatusBarPanel
    Friend WithEvents ImporteTotal As System.Windows.Forms.StatusBarPanel
    Friend WithEvents lblNombreEmpleado As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents lstCobro As System.Windows.Forms.ListBox
    Friend WithEvents dtpFMovimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFMovimiento As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents btnBorrarCobro As System.Windows.Forms.Button
    Friend WithEvents txtCliente As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblNombreCliente As System.Windows.Forms.Label
    Friend WithEvents cboTipoMovCaja As SigaMetClasses.Combos.ComboTipoMovimientoCaja
    Friend WithEvents cboEmpleado As SigaMetClasses.Combos.ComboEmpleado
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboRuta As SigaMetClasses.Combos.ComboRuta2
    Friend WithEvents lblWarning As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCapCobranza))
        Me.lstCobro = New System.Windows.Forms.ListBox()
        Me.lstPedido = New System.Windows.Forms.ListBox()
        Me.btnCancelar = New ControlesBase.BotonBase()
        Me.btnAceptar = New ControlesBase.BotonBase()
        Me.btnAgregar = New ControlesBase.BotonBase()
        Me.ttDatosPedido = New System.Windows.Forms.ToolTip(Me.components)
        Me.dtpFMovimiento = New System.Windows.Forms.DateTimePicker()
        Me.btnBorrarCobro = New System.Windows.Forms.Button()
        Me.stbEstatus = New System.Windows.Forms.StatusBar()
        Me.Documentos = New System.Windows.Forms.StatusBarPanel()
        Me.ImporteTotal = New System.Windows.Forms.StatusBarPanel()
        Me.lblNombreEmpleado = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboTipoMovCaja = New SigaMetClasses.Combos.ComboTipoMovimientoCaja()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblFMovimiento = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCliente = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblNombreCliente = New System.Windows.Forms.Label()
        Me.cboEmpleado = New SigaMetClasses.Combos.ComboEmpleado()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboRuta = New SigaMetClasses.Combos.ComboRuta2()
        Me.lblWarning = New System.Windows.Forms.Label()
        CType(Me.Documentos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImporteTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lstCobro
        '
        Me.lstCobro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstCobro.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lstCobro.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstCobro.ForeColor = System.Drawing.Color.MediumBlue
        Me.lstCobro.ItemHeight = 14
        Me.lstCobro.Location = New System.Drawing.Point(144, 224)
        Me.lstCobro.Name = "lstCobro"
        Me.lstCobro.Size = New System.Drawing.Size(728, 88)
        Me.lstCobro.TabIndex = 0
        '
        'lstPedido
        '
        Me.lstPedido.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstPedido.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstPedido.ItemHeight = 14
        Me.lstPedido.Location = New System.Drawing.Point(8, 336)
        Me.lstPedido.Name = "lstPedido"
        Me.lstPedido.Size = New System.Drawing.Size(864, 200)
        Me.lstPedido.TabIndex = 1
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(792, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btnCancelar.TabIndex = 6
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
        Me.btnAceptar.Location = New System.Drawing.Point(792, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(8, 224)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(120, 32)
        Me.btnAgregar.TabIndex = 3
        Me.btnAgregar.Text = "Agregar cobro"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ttDatosPedido.SetToolTip(Me.btnAgregar, "Agrega un cobro al movimiento")
        Me.btnAgregar.UseVisualStyleBackColor = False
        '
        'dtpFMovimiento
        '
        Me.dtpFMovimiento.Enabled = False
        Me.dtpFMovimiento.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFMovimiento.Location = New System.Drawing.Point(144, 88)
        Me.dtpFMovimiento.MaxDate = New Date(2500, 12, 31, 0, 0, 0, 0)
        Me.dtpFMovimiento.MinDate = New Date(2002, 1, 1, 0, 0, 0, 0)
        Me.dtpFMovimiento.Name = "dtpFMovimiento"
        Me.dtpFMovimiento.Size = New System.Drawing.Size(440, 21)
        Me.dtpFMovimiento.TabIndex = 14
        Me.ttDatosPedido.SetToolTip(Me.dtpFMovimiento, "Es la fecha que se va a afectar")
        Me.dtpFMovimiento.Value = New Date(2002, 12, 31, 0, 0, 0, 0)
        '
        'btnBorrarCobro
        '
        Me.btnBorrarCobro.BackColor = System.Drawing.SystemColors.Control
        Me.btnBorrarCobro.Enabled = False
        Me.btnBorrarCobro.Image = CType(resources.GetObject("btnBorrarCobro.Image"), System.Drawing.Image)
        Me.btnBorrarCobro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBorrarCobro.Location = New System.Drawing.Point(8, 264)
        Me.btnBorrarCobro.Name = "btnBorrarCobro"
        Me.btnBorrarCobro.Size = New System.Drawing.Size(120, 32)
        Me.btnBorrarCobro.TabIndex = 4
        Me.btnBorrarCobro.Text = "&Borrar cobro"
        Me.btnBorrarCobro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ttDatosPedido.SetToolTip(Me.btnBorrarCobro, "Borra el cobro seleccionado")
        Me.btnBorrarCobro.UseVisualStyleBackColor = False
        '
        'stbEstatus
        '
        Me.stbEstatus.Location = New System.Drawing.Point(0, 538)
        Me.stbEstatus.Name = "stbEstatus"
        Me.stbEstatus.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.Documentos, Me.ImporteTotal})
        Me.stbEstatus.ShowPanels = True
        Me.stbEstatus.Size = New System.Drawing.Size(870, 22)
        Me.stbEstatus.TabIndex = 9
        '
        'Documentos
        '
        Me.Documentos.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.Documentos.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.Documentos.Name = "Documentos"
        Me.Documentos.Text = "0 cobro(s)"
        Me.Documentos.Width = 426
        '
        'ImporteTotal
        '
        Me.ImporteTotal.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.ImporteTotal.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.ImporteTotal.Name = "ImporteTotal"
        Me.ImporteTotal.Text = "$0.00"
        Me.ImporteTotal.Width = 426
        '
        'lblNombreEmpleado
        '
        Me.lblNombreEmpleado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNombreEmpleado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreEmpleado.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblNombreEmpleado.Location = New System.Drawing.Point(144, 16)
        Me.lblNombreEmpleado.Name = "lblNombreEmpleado"
        Me.lblNombreEmpleado.Size = New System.Drawing.Size(440, 21)
        Me.lblNombreEmpleado.TabIndex = 0
        Me.lblNombreEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Responsable:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Ruta:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Fecha de movimiento:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 320)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(229, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Lista de documentos relacionados con el cobro"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(144, 208)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Lista de cobros"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboTipoMovCaja
        '
        Me.cboTipoMovCaja.BackColor = System.Drawing.SystemColors.Info
        Me.cboTipoMovCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoMovCaja.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoMovCaja.ForeColor = System.Drawing.Color.Crimson
        Me.cboTipoMovCaja.Location = New System.Drawing.Point(144, 112)
        Me.cboTipoMovCaja.Name = "cboTipoMovCaja"
        Me.cboTipoMovCaja.Size = New System.Drawing.Size(440, 21)
        Me.cboTipoMovCaja.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 115)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Tipo de movimiento:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFMovimiento
        '
        Me.lblFMovimiento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFMovimiento.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFMovimiento.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblFMovimiento.Location = New System.Drawing.Point(144, 88)
        Me.lblFMovimiento.Name = "lblFMovimiento"
        Me.lblFMovimiento.Size = New System.Drawing.Size(440, 21)
        Me.lblFMovimiento.TabIndex = 2
        Me.lblFMovimiento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(144, 160)
        Me.txtObservaciones.MaxLength = 400
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(440, 40)
        Me.txtObservaciones.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 160)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 13)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Observaciones:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(144, 136)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(112, 21)
        Me.txtCliente.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(8, 139)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 13)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "Cliente:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNombreCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreCliente.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblNombreCliente.Location = New System.Drawing.Point(256, 136)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(328, 21)
        Me.lblNombreCliente.TabIndex = 27
        Me.lblNombreCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboEmpleado
        '
        Me.cboEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmpleado.ForeColor = System.Drawing.Color.MediumBlue
        Me.cboEmpleado.Location = New System.Drawing.Point(144, 40)
        Me.cboEmpleado.Name = "cboEmpleado"
        Me.cboEmpleado.Size = New System.Drawing.Size(440, 21)
        Me.cboEmpleado.TabIndex = 28
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(8, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(50, 13)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "Captura:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboRuta
        '
        Me.cboRuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRuta.Location = New System.Drawing.Point(144, 64)
        Me.cboRuta.Name = "cboRuta"
        Me.cboRuta.Size = New System.Drawing.Size(121, 21)
        Me.cboRuta.TabIndex = 30
        '
        'lblWarning
        '
        Me.lblWarning.ForeColor = System.Drawing.Color.Firebrick
        Me.lblWarning.Location = New System.Drawing.Point(608, 136)
        Me.lblWarning.Name = "lblWarning"
        Me.lblWarning.Size = New System.Drawing.Size(256, 72)
        Me.lblWarning.TabIndex = 31
        Me.lblWarning.Text = "La modificación de este movimiento implica la cancelación de este y la creación d" &
    "e un nuevo movimiento con otra clave."
        Me.lblWarning.Visible = False
        '
        'frmCapCobranza
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(870, 560)
        Me.Controls.Add(Me.lblWarning)
        Me.Controls.Add(Me.lblFMovimiento)
        Me.Controls.Add(Me.cboRuta)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboEmpleado)
        Me.Controls.Add(Me.lblNombreCliente)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.btnBorrarCobro)
        Me.Controls.Add(Me.txtObservaciones)
        Me.Controls.Add(Me.cboTipoMovCaja)
        Me.Controls.Add(Me.dtpFMovimiento)
        Me.Controls.Add(Me.lblNombreEmpleado)
        Me.Controls.Add(Me.stbEstatus)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.lstPedido)
        Me.Controls.Add(Me.lstCobro)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(886, 598)
        Me.MinimumSize = New System.Drawing.Size(640, 512)
        Me.Name = "frmCapCobranza"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Captura de cobranza"
        CType(Me.Documentos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImporteTotal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public Sub New(ByVal Clave As String)
        MyBase.New()
        InitializeComponent()

        _Clave = Clave

        lblWarning.Visible = True

        cboRuta.CargaDatos()
        cboEmpleado.CargaDatosCredito(True)

        lstCobro.DisplayMember = "InformacionCompleta"
        lstPedido.DisplayMember = "InformacionCompleta"

        Dim cn As New SqlConnection(Main.ConString)
        Dim cn2 As New SqlConnection(Main.ConString)

        Dim cmdMovimientoCaja As New SqlCommand("SELECT * FROM MovimientoCaja WHERE Clave = @Clave", cn)
        Dim cmd As New SqlCommand("SELECT co.* FROM Cobro co JOIN vwCYCMovimientoCajaCobro mcc ON co.AñoCobro = mcc.AñoCobro and co.Cobro = mcc.Cobro AND mcc.Clave = @Clave", cn)
        Dim cmdCobroPedido As New SqlCommand("SELECT cp.*, pe.PedidoReferencia, pe.Cliente, pe.Total as PedidoTotal, cl.Nombre FROM CobroPedido cp JOIN Pedido pe ON cp.AñoPed = pe.AñoPed and cp.Celula = pe.Celula and cp.Pedido = pe.Pedido JOIN Cliente cl on pe.Cliente = cl.Cliente WHERE cp.AñoCobro = @AñoCobro AND cp.Cobro = @Cobro", cn2)

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        cmdMovimientoCaja.Parameters.Add("@Clave", SqlDbType.VarChar, 20).Value = _Clave

        Dim drMovimientoCaja As SqlDataReader
        Try
            drMovimientoCaja = cmdMovimientoCaja.ExecuteReader(CommandBehavior.CloseConnection)
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End Try


        drMovimientoCaja.Read()

        _FOperacion = CType(drMovimientoCaja("FOperacion"), Date)
        _Consecutivo = CType(drMovimientoCaja("Consecutivo"), Byte)
        _Folio = CType(drMovimientoCaja("Folio"), Integer)
        _Caja = CType(drMovimientoCaja("Caja"), Byte)

        If Not IsDBNull(drMovimientoCaja("Cliente")) Then
            txtCliente.Text = CType(drMovimientoCaja("Cliente"), Integer).ToString
            Dim oCliente As New SigaMetClasses.cCliente(Integer.Parse(txtCliente.Text))
            lblNombreCliente.Text = oCliente.Nombre
            oCliente.Dispose()

        End If

        dtpFMovimiento.Value = CType(drMovimientoCaja("FMovimiento"), Date)
        dtpFMovimiento.MaxDate = FechaOperacion
        dtpFMovimiento.MinDate = FechaOperacion.AddMonths(-1)
        dtpFMovimiento.Enabled = True
        lblFMovimiento.Text = dtpFMovimiento.Value.ToLongDateString
        lblFMovimiento.Visible = False

        cboRuta.SelectedValue = CType(drMovimientoCaja("Ruta"), Short)
        cboEmpleado.SelectedValue = CType(drMovimientoCaja("Empleado"), Integer)

        If Not IsDBNull(drMovimientoCaja("Observaciones")) Then
            txtObservaciones.Text = CType(drMovimientoCaja("Observaciones"), String).Trim
        End If

        If cn.State = ConnectionState.Open Then cn.Close()

        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim dr As SqlDataReader
        With cmd
            .Parameters.Clear()
            .Parameters.Add("@Clave", SqlDbType.VarChar, 20).Value = _Clave
        End With


        dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

        Dim i As Integer, _AñoCobro As Short, _Cobro As Integer

        While dr.Read
            i += 1
            Dim oCobro As SigaMetClasses.sCobro
            _AñoCobro = CType(dr("AñoCobro"), Short)
            _Cobro = CType(dr("Cobro"), Integer)

            oCobro.Consecutivo = i
            oCobro.AnoCobro = _AñoCobro
            oCobro.TipoCobro = CType(dr("TipoCobro"), SigaMetClasses.Enumeradores.enumTipoCobro)
            oCobro.Saldo = CType(dr("Saldo"), Decimal)
            oCobro.Total = CType(dr("Total"), Decimal)

            oCobro.Referencia = If(Not IsDBNull(dr("referencia")), CType(dr("referencia"), String), "")
            oCobro.NoCuentaDestino = If(Not IsDBNull(dr("NumeroCuentaDestino")), CType(dr("NumeroCuentaDestino"), String), "")
            oCobro.BancoOrigen = If(Not IsDBNull(dr("BancoOrigen")), CType(dr("BancoOrigen"), Short), CType(0, Short))

            'Control de saldos a favor en modificación de cobranza
            If oSeguridad.TieneAcceso("CAPTURA_SALDOAFAVOR") Then
                oCobro.SaldoAFavor = CType(dr("Saldo"), Boolean)
            End If

            If Not IsDBNull(dr("Banco")) Then oCobro.Banco = CType(dr("Banco"), Short)
            If Not IsDBNull(dr("Cliente")) Then oCobro.Cliente = CType(dr("Cliente"), Integer)
            If Not IsDBNull(dr("FCheque")) Then oCobro.FechaCheque = CType(dr("FCheque"), Date)
            If Not IsDBNull(dr("NumeroCheque")) Then oCobro.NoCheque = CType(dr("NumeroCheque"), String).Trim
            If Not IsDBNull(dr("NumeroCuenta")) Then oCobro.NoCuenta = CType(dr("NumeroCuenta"), String).Trim
            If Not IsDBNull(dr("FCOBRO")) Then oCobro.Fcobro = CType(dr("FCOBRO"), Date)

            oCobro.ListaPedidos = New ArrayList()


            Dim drCobroPedido As SqlDataReader
            With cmdCobroPedido
                .Parameters.Clear()
                .Parameters.Add("@AñoCobro", SqlDbType.SmallInt).Value = _AñoCobro
                .Parameters.Add("@Cobro", SqlDbType.Int).Value = _Cobro
            End With

            If cn2.State = ConnectionState.Closed Then
                cn2.Open()
            End If

            drCobroPedido = cmdCobroPedido.ExecuteReader(CommandBehavior.CloseConnection)

            While drCobroPedido.Read
                Dim oPedido As SigaMetClasses.sPedido
                oPedido.AnoPed = CType(drCobroPedido("AñoPed"), Short)
                oPedido.Celula = CType(drCobroPedido("Celula"), Byte)
                oPedido.Pedido = CType(drCobroPedido("Pedido"), Integer)
                oPedido.ImporteAbono = CType(drCobroPedido("Total"), Decimal)
                oPedido.Importe = CType(drCobroPedido("PedidoTotal"), Decimal)
                oPedido.PedidoReferencia = CType(drCobroPedido("PedidoReferencia"), String).Trim
                oPedido.Cliente = CType(drCobroPedido("Cliente"), Integer)
                oPedido.Nombre = CType(drCobroPedido("Nombre"), String).Trim

                oCobro.ListaPedidos.Add(oPedido)

            End While

            If cn2.State = ConnectionState.Open Then cn2.Close()

            decImporteTotalCobros += oCobro.Total
            stbEstatus.Panels(1).Text = decImporteTotalCobros.ToString("C")

            ListaCobros.Add(oCobro)

        End While

        Me.CargaLista()

        CargaURLGateway()

    End Sub

    Private Sub CargaURLGateway()
        Dim oConfig As New SigaMetClasses.cConfig(GLOBAL_Modulo, CShort(GLOBAL_Empresa), GLOBAL_Sucursal)
        Try
            _URLGateway = CType(oConfig.Parametros("URLGateway"), String).Trim()
            Dim re As Regex = New Regex(
                            "^(https?|ftp|file)://[-A-Z0-9+&@#/%?=~_|!:,.;]*[-A-Z0-9+&@#/%=~_|]",
                            RegexOptions.IgnoreCase)
            'Dim m As Match = re.Match(_URLGateway)
            'If m.Captures.Count = 0 Then
            '    MessageBox.Show("El valor configurado al parámetro URLGateway no es correcto.")
            'End If
        Catch ex As Exception
            _URLGateway = ""
        End Try
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If cboTipoMovCaja.TipoMovimientoCaja = 0 Then
            MessageBox.Show("Debe seleccionar el tipo de movimiento.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Try
            Consecutivo += 1
            Dim frmSelTipoCobro As frmSelTipoCobro
            If Me.cboTipoMovCaja.NotaIngreso = False Then
                If cboTipoMovCaja.TipoMovimientoCaja <> 28 Then
                    frmSelTipoCobro = New frmSelTipoCobro(Consecutivo, cboTipoMovCaja.TipoMovimientoCaja, lstCobro, txtCliente.Text, lblNombreCliente.Text)
                Else
                    frmSelTipoCobro = New frmSelTipoCobro(Consecutivo, cboTipoMovCaja.TipoMovimientoCaja, lstCobro, txtCliente.Text, lblNombreCliente.Text, False, True)
                End If
            Else
                frmSelTipoCobro = New frmSelTipoCobro(Consecutivo, cboTipoMovCaja.TipoMovimientoCaja, lstCobro, txtCliente.Text, lblNombreCliente.Text, True, False)
            End If

            If oSeguridad.TieneAcceso("AreaDacionEnPago") Then
                frmSelTipoCobro.HabilitarDacionEnPago = True
            End If

            If frmSelTipoCobro.ShowDialog() = DialogResult.OK Then
                ListaCobros.Add(frmSelTipoCobro.Cobro)
                'lstCobro.Items.Add(frmSelTipoCobro.Cobro)
                CargaLista()

                'No incluir cobros posfechados
                If Not frmSelTipoCobro.Posfechado Then
                    decImporteTotalCobros += frmSelTipoCobro.ImporteTotalCobro
                End If

                'stbEstatus.Panels(0).Text = lstCobro.Items.Count.ToString & " cobro(s)"
                stbEstatus.Panels(1).Text = decImporteTotalCobros.ToString("C")
                lstPedido.Items.Clear()
                btnBorrarCobro.Enabled = False
            Else
                Consecutivo -= 1
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub frmCapCobranza_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor


        If FechaOperacion.Day <= Main.GLOBAL_DiasAjuste Then
            'Se detecta la fecha mínima
            Dim strFechaMinima As String, dtmFechaMinima As Date
            strFechaMinima = "01/" & (FechaOperacion.AddMonths(-1)).Month & "/" & (FechaOperacion.AddMonths(-1)).Year
            dtmFechaMinima = CType(strFechaMinima, Date)
            dtpFMovimiento.MinDate = dtmFechaMinima
            dtpFMovimiento.MaxDate = FechaOperacion
            dtpFMovimiento.Visible = True
            lblFMovimiento.Visible = False
            'If Main.GLOBAL_UsuarioAjuste = Main.GLOBAL_IDUsuario Then
            '    dtpFMovimiento.Enabled = True
            'End If
        End If

        CargarVariablesGateway()

        Try

            If Main.GLOBAL_UsuarioCobranza = True Then
                cboTipoMovCaja.CargaDatosCapturaCobranza(True)
            Else
                cboTipoMovCaja.CargaDatos(True, True, False)
            End If

            InicioListo = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try

        lblNombreEmpleado.Text = GLOBAL_IDEmpleado.ToString & " " & GLOBAL_EmpleadoNombre
        If Modulo = 4 Then
            Try
                If cboTipoMovCaja.SelectedItem IsNot Nothing Then
                    cboTipoMovCaja.Items.RemoveAt(30)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
            ' cboTipoMovCaja.Refresh()
        End If
    End Sub

    Private Sub lstCobro_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstCobro.SelectedIndexChanged
        Dim s As SigaMetClasses.sPedido
        lstPedido.Items.Clear()
        If Not IsNothing(CType(lstCobro.Items(lstCobro.SelectedIndex), SigaMetClasses.sCobro).ListaPedidos()) Then
            For Each s In CType(lstCobro.Items(lstCobro.SelectedIndex), SigaMetClasses.sCobro).ListaPedidos()
                lstPedido.Items.Add(s)
            Next
        End If
        btnBorrarCobro.Enabled = True
    End Sub

    Private Sub lstPedido_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstPedido.SelectedIndexChanged
        If lstPedido.SelectedIndex <> -1 Then
            Dim strTip As String
            strTip = "Documento: " & CType(lstPedido.Items(lstPedido.SelectedIndex), SigaMetClasses.sPedido).PedidoReferencia & Chr(13) &
                     "Cliente: " & CType(lstPedido.Items(lstPedido.SelectedIndex), SigaMetClasses.sPedido).Cliente.ToString & Chr(13) &
                     "Nombre: " & CType(lstPedido.Items(lstPedido.SelectedIndex), SigaMetClasses.sPedido).Nombre & Chr(13) &
                     "Importe del documento: " & CType(lstPedido.Items(lstPedido.SelectedIndex), SigaMetClasses.sPedido).Importe.ToString("N") & Chr(13) &
                     "Importe del abono: " & CType(lstPedido.Items(lstPedido.SelectedIndex), SigaMetClasses.sPedido).ImporteAbono.ToString("N")
            ttDatosPedido.SetToolTip(lstPedido, strTip)
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click


        If CType(cboEmpleado.SelectedValue, Integer) = 0 Then
            MessageBox.Show("Debe seleccionar el empleado responsable del movimiento.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If



        If cboTipoMovCaja.TipoMovimientoCaja <= 0 Then
            MessageBox.Show("Debe seleccionar el tipo de movimiento de esta captura.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If cboTipoMovCaja.NotaIngreso = True Then
            If Trim(txtCliente.Text) = "" Then
                MessageBox.Show("Debe teclear el número de contrato del cliente.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If

        If Me.lstCobro.Items.Count <= 0 Then
            MessageBox.Show("No se han capturado cobros.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If MessageBox.Show(M_ESTAN_CORRECTOS, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            _FMovimiento = CType(dtpFMovimiento.Value.ToShortDateString, Date)
            'Dim oMov As New SigaMetClasses.TransaccionMovimientoCaja()

            Dim oMov As SigaMetClasses.TransaccionMovimientoCaja
            If Not String.IsNullOrEmpty(_URLGateway) Then
                oMov = New SigaMetClasses.TransaccionMovimientoCaja(_URLGateway, ConString, GLOBAL_Modulo, _FuenteGateway)
            Else
                oMov = New SigaMetClasses.TransaccionMovimientoCaja()
            End If

            Try
                If Main.SesionIniciada = False Then
                    IniciarSesion(FechaInicioSesion)
                End If

                Dim _Cliente As Integer
                If Trim(txtCliente.Text) = "" Then
                    _Cliente = 0
                Else
                    _Cliente = CType(txtCliente.Text, Integer)
                End If

                If _Clave <> "" Then
                    Try
                        oMov.Cancela(_Caja, _FOperacion, _Consecutivo, _Folio, 1, Main.GLOBAL_IDUsuario)
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End Try
                End If

                'Control de cheques posfechados
                'Mensaje de advertencia de documentos posfechados
                Dim _cobro As SigaMetClasses.sCobro
                Dim _posfechado As Boolean = False
                Dim _normal As Boolean = False
                Dim _mensajePosfechado As String = Nothing

                For Each _cobro In ListaCobros
                    If Not _cobro.Posfechado Then
                        _normal = True
                    Else
                        _posfechado = True
                    End If
                Next

                If _posfechado And _normal Then
                    _mensajePosfechado = "Este movimiento contiene documentos posfechados" & vbCrLf &
                        "los cuáles no serán incluidos y serán almacenados para" & vbCrLf &
                        "su posterior aplicación." & vbCrLf &
                        "¿Desea continuar?"
                End If

                If _posfechado And Not _normal Then
                    _mensajePosfechado = "No se generará el movimiento de esta cobranza porque" & vbCrLf &
                        "solo contiene documentos posfechados que serán almacenados para" & vbCrLf &
                        "su posterior aplicación." & vbCrLf &
                        "¿Desea continuar?"
                End If

                If _posfechado Then
                    If MessageBox.Show(_mensajePosfechado, "Posfechados", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                        Exit Sub
                    End If
                End If
                '*****

                Dim iFolio As Integer = oMov.Alta(Main.GLOBAL_CajaUsuario,
                            FechaOperacion,
                            ConsecutivoInicioDeSesion,
                            _FMovimiento,
                            decImporteTotalCobros,
                            GLOBAL_IDUsuario,
                            CType(cboEmpleado.SelectedValue, Integer),
                            cboTipoMovCaja.TipoMovimientoCaja,
                            CType(cboRuta.SelectedValue, Short),
                            _Cliente,
                            ListaCobros,
                            GLOBAL_IDUsuario, Trim(txtObservaciones.Text))
                CapturaEfectivoVales = False
                CapturaMixtaEfectivoVales = False

                'Solo desplegar la pantalla del comprobante cuando el movimiento contiene cobros normales
                If _normal Then
                    If cboTipoMovCaja.NotaIngreso = False Then
                        If MessageBox.Show(M_DATOS_OK & Chr(13) & Chr(13) & "¿Desea imprimir el comprobante?", Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            Cursor = Cursors.WaitCursor
                            Dim frmRep As New frmConsultaReporte(frmConsultaReporte.enumTipoReporte.CombrobanteCaja, Main.GLOBAL_CajaUsuario, FechaOperacion, iFolio, ConsecutivoInicioDeSesion)
                            frmRep.ShowDialog()
                            Cursor = Cursors.Default
                        End If
                    End If
                End If

                'Imprimir el listado de cheques posfechados por el usuario para entregar a resguardo
                If _posfechado Then
                    If MessageBox.Show("¿Desea imprimir el listado de cheques posfechados del día?", Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        Cursor = Cursors.WaitCursor
                        Dim frmRep As New frmConsultaReporte(frmConsultaReporte.enumTipoReporte.RelacionChequePosfechado, Main.GLOBAL_IDUsuario, FechaOperacion)
                        frmRep.ShowDialog()
                        Cursor = Cursors.Default
                    End If
                End If

                DialogResult = DialogResult.OK

                Me.Close()
            Catch ex As Exception
                'EventLog.WriteEntry("CyC " & ex.Source, ex.Message, EventLogEntryType.Error)
                MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)

                'Si falla la modificación, revivir el movimiento cancelado
                'JAGD 04/04/2005

                If _Clave <> "" Then
                    Try
                        oMov.Revive(_Clave)
                    Catch ex1 As Exception
                        MessageBox.Show(ex1.Message, ex1.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End Try
                End If

            Finally
                oMov = Nothing
            End Try
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub frmCapCobranza_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        CapturaEfectivoVales = False
        CapturaMixtaEfectivoVales = False
    End Sub

    Private Sub CargaLista()
        lstCobro.Items.Clear()
        Dim oCobro As SigaMetClasses.sCobro
        For Each oCobro In ListaCobros
            lstCobro.Items.Add(oCobro)
        Next
        stbEstatus.Panels(0).Text = lstCobro.Items.Count.ToString & " cobro(s)"
    End Sub

    Private Sub CargarVariablesGateway()
        Dim oConfig As New SigaMetClasses.cConfig(GLOBAL_Modulo, GLOBAL_Corporativo, GLOBAL_Sucursal)
        _FuenteGateway = CType(oConfig.Parametros("FuenteCRM"), String)
    End Sub

    Private Sub BorrarCobro()
        If CType(lstCobro.SelectedItem, SigaMetClasses.sCobro).TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.EfectivoVales Then
            CapturaEfectivoVales = False
        End If
        decImporteTotalCobros -= CType(lstCobro.SelectedItem, SigaMetClasses.sCobro).Total
        ListaCobros.Remove(lstCobro.SelectedItem)
        lstPedido.Items.Clear()
        stbEstatus.Panels(1).Text = decImporteTotalCobros.ToString("C")
    End Sub

    Private Sub btnBorrarCobro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrarCobro.Click
        BorrarCobro()
        CargaLista()
        btnBorrarCobro.Enabled = False
    End Sub

    Private Function consultaClienteCRM(ByVal cliente As Integer) As String
        Dim Gateway As RTGMGateway.RTGMGateway
        Dim Solicitud As RTGMGateway.SolicitudGateway
        Dim DireccionEntrega As New RTGMCore.DireccionEntrega
        Dim Nombre As String = ""

        Try
            If (Not String.IsNullOrEmpty(_URLGateway)) Then
                Gateway = New RTGMGateway.RTGMGateway(GLOBAL_Modulo, ConString)
                Gateway.URLServicio = _URLGateway
                Solicitud = New RTGMGateway.SolicitudGateway() With {
                    .IDCliente = cliente}



                DireccionEntrega = Gateway.buscarDireccionEntrega(Solicitud)
                If DireccionEntrega.Nombre IsNot Nothing Then
                    Nombre = DireccionEntrega.Nombre.Trim
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return Nombre
    End Function

    Private Sub txtCliente_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCliente.Leave

        Dim oConfig As New SigaMetClasses.cConfig(GLOBAL_Modulo, CShort(GLOBAL_Empresa), GLOBAL_Sucursal)
        If txtCliente.Text <> "" Then
            If _URLGateway <> "" Then
                lblNombreCliente.Text = consultaClienteCRM(CInt(txtCliente.Text))
            Else
                Dim oCliente As New SigaMetClasses.cCliente()
                oCliente.Consulta(CType(txtCliente.Text, Integer))
                lblNombreCliente.Text = oCliente.Nombre
                'TODO: Validacion de clientes de edificio administrado agregada el 13/10/2004
                btnAgregar.Enabled = True
                GLOBAL_ClientePadreEdificio = Nothing
                GLOBAL_AplicaValidacionClienteHijo = False 'Indica cuando se debe aplicar la validación de clientes hijos en la captura de cobros
                If GLOBAL_AplicaAdmEdificios Then
                    Dim movCaja As Byte = cboTipoMovCaja.TipoMovimientoCaja
                    If movCaja = GLOBAL_TipoMovimientoAdmEdificios Then
                        If Not (validacionDeClientesEdificio(oCliente)) Then
                            MessageBox.Show("Ha sido seleccionado el tipo de cobranza de 'Edificios Administrados' por lo que" & Chr(13) &
                            "se requiere el contrato de un cliente padre de Administración de Edificios", "Validacion del no. de contrato",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            'Se apaga el botón para que no se agregen cobros hasta que se corrija el contrato o se cambie el tipo de cobranza
                            btnAgregar.Enabled = False
                        End If
                    End If
                End If
                'Fin de la validacion de cobranza de edificios
            End If
        End If


        Try
            _URLGateway = CType(oConfig.Parametros("URLGateway"), String).Trim()
        Catch ex As Exception
            _URLGateway = ""
        End Try


        If (Not String.IsNullOrEmpty(_URLGateway) And Not String.IsNullOrEmpty(txtCliente.Text.ToString().Trim())) Then

            If ValidaClienteHijo(Integer.Parse(txtCliente.Text.ToString())) = True Then
                MessageBox.Show("Ha sido seleccionado el tipo de cobranza de 'Edificios Administrados' por lo que se requiere el contrato de un cliente padre de Administración de Edificios", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If




    End Sub

    'TODO: Funcion para validar que el cliente sea un cliente padre de edificio administrado 13/10/2004
    Private Function validacionDeClientesEdificio(ByVal oCliente As SigaMetClasses.cCliente) As Boolean
        If Not (oCliente.RamoClienteDescripcion = GLOBAL_RamoAdmEdificios) Then
            Return False
            Exit Function
        End If
        If Not (oCliente.ClientePadre = 0) Then
            Return False
            Exit Function
        End If
        If Not (oCliente.Hijos > 0) Then
            Return False
            Exit Function
        End If
        GLOBAL_ClientePadreEdificio = CType(txtCliente.Text, Integer)
        GLOBAL_AplicaValidacionClienteHijo = True
        Return True
    End Function

    Private Function validacionDeClientesEdificioCRM(ByVal IDDireccioneEntrega As Integer) As Boolean
        Dim ClientePadre As Boolean



        Dim Gateway As RTGMGateway.RTGMGateway
        Dim Solicitud As RTGMGateway.SolicitudGateway
        Dim DireccionEntrega As New RTGMCore.DireccionEntrega



        Gateway = New RTGMGateway.RTGMGateway(GLOBAL_Modulo, ConString)
        Gateway.URLServicio = _URLGateway



        Solicitud.IDCliente = IDDireccioneEntrega
        Solicitud.Portatil = False
        Solicitud.IDAutotanque = Nothing
        Solicitud.FechaConsulta = Nothing


        Try

            DireccionEntrega = Gateway.buscarDireccionEntrega(Solicitud)


            If (Not DireccionEntrega.Ramo Is Nothing) Then

                If (DireccionEntrega.Ramo.IDRamoCliente = 53 And Not IsNothing(DireccionEntrega.IDDireccionEntregaPadreEdificio)) Then
                    ClientePadre = False

                ElseIf (DireccionEntrega.Ramo.IDRamoCliente = 53 And IsNothing(DireccionEntrega.IDDireccionEntregaPadreEdificio)) Then
                    ClientePadre = True
                End If
            End If

        Catch ex As Exception
            EventLog.WriteEntry(My.Application.Info.AssemblyName.ToString() & ex.Source, ex.Message, EventLogEntryType.Error)
        Finally
            Gateway = Nothing
            Solicitud = Nothing
            DireccionEntrega = Nothing
        End Try


        Return ClientePadre
    End Function

    Function ValidaClienteHijo(ByVal IDDireccioneEntrega As Integer) As Boolean
        Dim ClienteHijo As Boolean



        Dim Gateway As RTGMGateway.RTGMGateway
        Dim Solicitud As RTGMGateway.SolicitudGateway
        Dim DireccionEntrega As New RTGMCore.DireccionEntrega



        Gateway = New RTGMGateway.RTGMGateway(GLOBAL_Modulo, ConString)
        Gateway.URLServicio = _URLGateway



        Solicitud.IDCliente = IDDireccioneEntrega
        Solicitud.Portatil = False
        Solicitud.IDAutotanque = Nothing
        Solicitud.FechaConsulta = Nothing


        Try

            DireccionEntrega = Gateway.buscarDireccionEntrega(Solicitud)


            If (Not DireccionEntrega.Ramo Is Nothing) Then

                If (DireccionEntrega.Ramo.IDRamoCliente = 53 And IsNothing(DireccionEntrega.IDDireccionEntregaPadreEdificio)) Then
                    ClienteHijo = True

                End If
            End If




        Catch ex As Exception
            EventLog.WriteEntry(My.Application.Info.AssemblyName.ToString() & ex.Source, ex.Message, EventLogEntryType.Error)
        Finally
            Gateway = Nothing
            Solicitud = Nothing
            DireccionEntrega = Nothing
        End Try


        Return ClienteHijo
    End Function

    Private Sub cboTipoMovCaja_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoMovCaja.SelectedIndexChanged
        Dim TransBan As String = ""

        Dim oConfig As New SigaMetClasses.cConfig(GLOBAL_Modulo, CShort(GLOBAL_Empresa), GLOBAL_Sucursal)

        Try
            TransBan = CType(oConfig.Parametros("TransBan"), String).Trim()
        Catch ex As Exception
            TransBan = ""
        End Try

        If Me.cboTipoMovCaja.Text.ToUpper.Contains("TRANSFERENCIA") And TransBan = "0" Then
            btnAgregar.Enabled = False
            btnAceptar.Enabled = False
        Else
            btnAgregar.Enabled = True
            btnAceptar.Enabled = True
        End If


    End Sub

    Private Sub txtCliente_TextChanged(sender As Object, e As EventArgs) Handles txtCliente.TextChanged

    End Sub

    Private Sub cboTipoMovCaja_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTipoMovCaja.SelectedValueChanged

    End Sub
End Class

#Region "Estructuras"
'Estructura de Pedidos para el llenado del listbox

'Public Structure sCobro
'    Private _Consecutivo As Integer
'    Private _AnoCobro As Short
'    Private _TipoCobro As enumTipoCobro
'    Private _Total As Decimal
'    Private _NoCheque As String
'    Private _FechaCheque As Date
'    Private _NoCuenta As String
'    Private _Cliente As Integer
'    Private _Banco As Short
'    Private _Observaciones As String
'    Private _ListaPedidos As ArrayList

'    Public Property Consecutivo() As Integer
'        Get
'            Return _Consecutivo
'        End Get
'        Set(ByVal Value As Integer)
'            _Consecutivo = Value
'        End Set
'    End Property

'    Public Property AnoCobro() As Short
'        Get
'            Return _AnoCobro
'        End Get
'        Set(ByVal Value As Short)
'            _AnoCobro = Value
'        End Set
'    End Property

'    Public Property TipoCobro() As enumTipoCobro
'        Get
'            Return _TipoCobro
'        End Get
'        Set(ByVal Value As enumTipoCobro)
'            _TipoCobro = Value
'        End Set
'    End Property

'    Public Property Total() As Decimal
'        Get
'            Return _Total
'        End Get
'        Set(ByVal Value As Decimal)
'            _Total = Value
'        End Set
'    End Property

'    Public Property NoCheque() As String
'        Get
'            Return _NoCheque
'        End Get
'        Set(ByVal Value As String)
'            _NoCheque = Value
'        End Set
'    End Property

'    Public Property FechaCheque() As Date
'        Get
'            Return _FechaCheque
'        End Get
'        Set(ByVal Value As Date)
'            _FechaCheque = Value
'        End Set
'    End Property

'    Public Property NoCuenta() As String
'        Get
'            Return _NoCuenta
'        End Get
'        Set(ByVal Value As String)
'            _NoCuenta = Value
'        End Set
'    End Property

'    Public Property Cliente() As Integer
'        Get
'            Return _Cliente
'        End Get
'        Set(ByVal Value As Integer)
'            _Cliente = Value
'        End Set
'    End Property

'    Public Property Banco() As Short
'        Get
'            Return _Banco
'        End Get
'        Set(ByVal Value As Short)
'            _Banco = Value
'        End Set
'    End Property

'    Public Property Observaciones() As String
'        Get
'            Return _Observaciones
'        End Get
'        Set(ByVal Value As String)
'            _Observaciones = Value
'        End Set
'    End Property

'    Public Property ListaPedidos() As ArrayList
'        Get
'            Return _ListaPedidos
'        End Get
'        Set(ByVal Value As ArrayList)
'            _ListaPedidos = Value
'        End Set
'    End Property

'    Public ReadOnly Property InformacionCompleta() As String
'        Get
'            Return "Cobro: " & LSet(Trim(_Consecutivo.ToString), 3) & " " & LSet(Trim(_TipoCobro.ToString), 20) & " Importe:" & RSet(Trim(_Total.ToString("C")), 20) & " " & RSet(Trim(_ListaPedidos.Count.ToString), 5) & " documento(s)"
'        End Get
'    End Property

'End Structure


'Public Structure sPedido
'    Private _Cobro As Integer
'    Private _Celula As Byte
'    Private _AnoPed As Short
'    Private _Pedido As Integer
'    Private _Importe As Decimal
'    Private _ImporteAbono As Decimal
'    Private _PedidoReferencia As String
'    Private _Cliente As Integer
'    Private _Nombre As String

'    Public Property Cobro() As Integer
'        Get
'            Return _Cobro
'        End Get
'        Set(ByVal Value As Integer)
'            _Cobro = Value
'        End Set
'    End Property

'    Public Property Celula() As Byte
'        Get
'            Return _Celula
'        End Get
'        Set(ByVal Value As Byte)
'            _Celula = Value
'        End Set
'    End Property

'    Public Property AnoPed() As Short
'        Get
'            Return _AnoPed
'        End Get
'        Set(ByVal Value As Short)
'            _AnoPed = Value
'        End Set
'    End Property

'    Public Property Pedido() As Integer
'        Get
'            Return _Pedido
'        End Get
'        Set(ByVal Value As Integer)
'            _Pedido = Value
'        End Set
'    End Property

'    Public Property Importe() As Decimal
'        Get
'            Return _Importe
'        End Get
'        Set(ByVal Value As Decimal)
'            _Importe = Value
'        End Set
'    End Property

'    Public Property ImporteAbono() As Decimal
'        Get
'            Return _ImporteAbono
'        End Get
'        Set(ByVal Value As Decimal)
'            _ImporteAbono = Value
'        End Set
'    End Property

'    Public Property PedidoReferencia() As String
'        Get
'            Return _PedidoReferencia
'        End Get
'        Set(ByVal Value As String)
'            _PedidoReferencia = Value
'        End Set
'    End Property

'    Public ReadOnly Property InformacionCompleta() As String
'        Get
'            Return LSet(_PedidoReferencia, 20) & " " & RSet(Trim(_ImporteAbono.ToString("N")), 15)
'        End Get
'    End Property

'    Public Property Cliente() As Integer
'        Get
'            Return _Cliente
'        End Get
'        Set(ByVal Value As Integer)
'            _Cliente = Value
'        End Set
'    End Property

'    Public Property Nombre() As String
'        Get
'            Return _Nombre
'        End Get
'        Set(ByVal Value As String)
'            _Nombre = Value
'        End Set
'    End Property
'End Structure
#End Region