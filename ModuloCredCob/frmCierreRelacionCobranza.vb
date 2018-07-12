Imports System.Data.SqlClient
Public Class frmCierreRelacionCobranza
    Inherits System.Windows.Forms.Form
    Private _dsCobranza As DataSet
    Private _dtCobranza As DataTable
    Private _Cobranza As Integer
    Private Titulo As String = "Cierre de relación de cobranza"
    Private WithEvents objGestionCob As SigaMetClasses.GestionCobranza
    Private _TotalSaldoReal As Decimal
    Private _TablaCobro As DataTable
    Private intCobro As Integer = 0
    Private _Cierre As Boolean
    Private _Empleado As Integer
    Private _EmpleadoNombre As String
    Private _FCobranza As Date
    Private _TipoMovimientoCaja As Byte
    Private _URLGateway As String
    'Control de cheques posfechados
    Private _chequesPosfechados As Boolean = False
    '*****

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Iniciar la captura de efectivo vales
        CapturaEfectivoVales = False
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
    Friend WithEvents pnlGestion As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents lstCobro As System.Windows.Forms.ListBox
    Friend WithEvents lstPedido As System.Windows.Forms.ListBox
    Friend WithEvents btnAgregarCobro As System.Windows.Forms.Button
    Friend WithEvents btnBorrarCobro As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents stbEstatus As System.Windows.Forms.StatusBar
    Friend WithEvents lblTituloCobros As System.Windows.Forms.Label
    Friend WithEvents lblTituloDocumentos As System.Windows.Forms.Label
    Friend WithEvents lblTituloRelacion As System.Windows.Forms.Label
    Friend WithEvents lblAyuda As System.Windows.Forms.Label
    Friend WithEvents lblCobranza As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblFCobranza As System.Windows.Forms.Label
    Friend WithEvents lblEmpleado As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents chbValeCred As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCierreRelacionCobranza))
        Me.pnlGestion = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.lstCobro = New System.Windows.Forms.ListBox()
        Me.btnAgregarCobro = New System.Windows.Forms.Button()
        Me.lstPedido = New System.Windows.Forms.ListBox()
        Me.btnBorrarCobro = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblTituloCobros = New System.Windows.Forms.Label()
        Me.lblTituloDocumentos = New System.Windows.Forms.Label()
        Me.stbEstatus = New System.Windows.Forms.StatusBar()
        Me.lblAyuda = New System.Windows.Forms.Label()
        Me.lblTituloRelacion = New System.Windows.Forms.Label()
        Me.lblCobranza = New System.Windows.Forms.Label()
        Me.lblFCobranza = New System.Windows.Forms.Label()
        Me.lblEmpleado = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.chbValeCred = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlGestion
        '
        Me.pnlGestion.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.pnlGestion.AutoScroll = True
        Me.pnlGestion.BackColor = System.Drawing.Color.Gainsboro
        Me.pnlGestion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlGestion.Location = New System.Drawing.Point(8, 288)
        Me.pnlGestion.Name = "pnlGestion"
        Me.pnlGestion.Size = New System.Drawing.Size(992, 320)
        Me.pnlGestion.TabIndex = 0
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(928, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 19)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "Incluir"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(869, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 19)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "Saldo"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(805, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 19)
        Me.Label9.TabIndex = 32
        Me.Label9.Text = "Total cobro"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(725, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 19)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "Tipo de cobro"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(637, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 19)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "CR/Cobro"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(458, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(118, 19)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Observaciones"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(372, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(136, 19)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "FCompromiso"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(292, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 19)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Gestión real"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(229, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 19)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Saldo"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(213, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 19)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "G.I."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 19)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Documento"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(925, 40)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 36
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(925, 8)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 35
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lstCobro
        '
        Me.lstCobro.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstCobro.ForeColor = System.Drawing.Color.Brown
        Me.lstCobro.ItemHeight = 14
        Me.lstCobro.Location = New System.Drawing.Point(8, 64)
        Me.lstCobro.Name = "lstCobro"
        Me.lstCobro.Size = New System.Drawing.Size(744, 88)
        Me.lstCobro.TabIndex = 40
        '
        'btnAgregarCobro
        '
        Me.btnAgregarCobro.BackColor = System.Drawing.SystemColors.Control
        Me.btnAgregarCobro.Image = CType(resources.GetObject("btnAgregarCobro.Image"), System.Drawing.Bitmap)
        Me.btnAgregarCobro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregarCobro.Location = New System.Drawing.Point(760, 40)
        Me.btnAgregarCobro.Name = "btnAgregarCobro"
        Me.btnAgregarCobro.Size = New System.Drawing.Size(72, 32)
        Me.btnAgregarCobro.TabIndex = 41
        Me.btnAgregarCobro.Text = "Agregar cobro"
        Me.btnAgregarCobro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lstPedido
        '
        Me.lstPedido.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lstPedido.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstPedido.ItemHeight = 14
        Me.lstPedido.Location = New System.Drawing.Point(8, 184)
        Me.lstPedido.Name = "lstPedido"
        Me.lstPedido.Size = New System.Drawing.Size(744, 74)
        Me.lstPedido.TabIndex = 42
        '
        'btnBorrarCobro
        '
        Me.btnBorrarCobro.BackColor = System.Drawing.SystemColors.Control
        Me.btnBorrarCobro.Image = CType(resources.GetObject("btnBorrarCobro.Image"), System.Drawing.Bitmap)
        Me.btnBorrarCobro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBorrarCobro.Location = New System.Drawing.Point(760, 80)
        Me.btnBorrarCobro.Name = "btnBorrarCobro"
        Me.btnBorrarCobro.Size = New System.Drawing.Size(72, 32)
        Me.btnBorrarCobro.TabIndex = 43
        Me.btnBorrarCobro.Text = "Borrar cobro"
        Me.btnBorrarCobro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.Label14, Me.Label8, Me.Label12, Me.Label9, Me.Label2, Me.Label11, Me.Label3, Me.Label4, Me.Label10, Me.Label6, Me.Label7, Me.Label5})
        Me.Panel1.Location = New System.Drawing.Point(8, 288)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(992, 19)
        Me.Panel1.TabIndex = 45
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(85, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(128, 19)
        Me.Label14.TabIndex = 35
        Me.Label14.Text = "Cliente"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTituloCobros
        '
        Me.lblTituloCobros.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.lblTituloCobros.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTituloCobros.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloCobros.Location = New System.Drawing.Point(8, 40)
        Me.lblTituloCobros.Name = "lblTituloCobros"
        Me.lblTituloCobros.Size = New System.Drawing.Size(744, 21)
        Me.lblTituloCobros.TabIndex = 46
        Me.lblTituloCobros.Text = "Lista de cobros capturados"
        Me.lblTituloCobros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTituloDocumentos
        '
        Me.lblTituloDocumentos.BackColor = System.Drawing.Color.MidnightBlue
        Me.lblTituloDocumentos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTituloDocumentos.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloDocumentos.ForeColor = System.Drawing.Color.White
        Me.lblTituloDocumentos.Location = New System.Drawing.Point(8, 160)
        Me.lblTituloDocumentos.Name = "lblTituloDocumentos"
        Me.lblTituloDocumentos.Size = New System.Drawing.Size(744, 21)
        Me.lblTituloDocumentos.TabIndex = 47
        Me.lblTituloDocumentos.Text = "Lista de documentos relacionados al cobro"
        Me.lblTituloDocumentos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'stbEstatus
        '
        Me.stbEstatus.Location = New System.Drawing.Point(0, 615)
        Me.stbEstatus.Name = "stbEstatus"
        Me.stbEstatus.Size = New System.Drawing.Size(1008, 22)
        Me.stbEstatus.TabIndex = 48
        Me.stbEstatus.Text = "Aplique los cobros correspondientes y el cambio de gestión a los documentos y ens" & _
        "eguida dé clic en el botón 'Aceptar'"
        '
        'lblAyuda
        '
        Me.lblAyuda.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblAyuda.Location = New System.Drawing.Point(768, 160)
        Me.lblAyuda.Name = "lblAyuda"
        Me.lblAyuda.Size = New System.Drawing.Size(232, 88)
        Me.lblAyuda.TabIndex = 49
        Me.lblAyuda.Text = "De clic en el botón ""Agregar cobro"" para dar de alta los cobros pendientes a la r" & _
        "elación de cobranza.  También puede cambiar el tipo de gestión que tuvo un docum" & _
        "ento haciendo el cambio en su renglón correspondiente en la lista."
        '
        'lblTituloRelacion
        '
        Me.lblTituloRelacion.BackColor = System.Drawing.Color.RoyalBlue
        Me.lblTituloRelacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTituloRelacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloRelacion.ForeColor = System.Drawing.Color.White
        Me.lblTituloRelacion.Location = New System.Drawing.Point(8, 264)
        Me.lblTituloRelacion.Name = "lblTituloRelacion"
        Me.lblTituloRelacion.Size = New System.Drawing.Size(992, 21)
        Me.lblTituloRelacion.TabIndex = 50
        Me.lblTituloRelacion.Text = "Relación de cobranza"
        Me.lblTituloRelacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCobranza
        '
        Me.lblCobranza.BackColor = System.Drawing.Color.Gainsboro
        Me.lblCobranza.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCobranza.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblCobranza.Location = New System.Drawing.Point(72, 8)
        Me.lblCobranza.Name = "lblCobranza"
        Me.lblCobranza.Size = New System.Drawing.Size(64, 21)
        Me.lblCobranza.TabIndex = 52
        Me.lblCobranza.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFCobranza
        '
        Me.lblFCobranza.BackColor = System.Drawing.Color.Gainsboro
        Me.lblFCobranza.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFCobranza.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblFCobranza.Location = New System.Drawing.Point(216, 8)
        Me.lblFCobranza.Name = "lblFCobranza"
        Me.lblFCobranza.Size = New System.Drawing.Size(216, 21)
        Me.lblFCobranza.TabIndex = 53
        Me.lblFCobranza.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmpleado
        '
        Me.lblEmpleado.BackColor = System.Drawing.Color.Gainsboro
        Me.lblEmpleado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpleado.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblEmpleado.Location = New System.Drawing.Point(512, 8)
        Me.lblEmpleado.Name = "lblEmpleado"
        Me.lblEmpleado.Size = New System.Drawing.Size(240, 21)
        Me.lblEmpleado.TabIndex = 54
        Me.lblEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(8, 11)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 14)
        Me.Label15.TabIndex = 55
        Me.Label15.Text = "Cobranza:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(144, 11)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(64, 14)
        Me.Label16.TabIndex = 56
        Me.Label16.Text = "F.Cobranza:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(448, 11)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(57, 14)
        Me.Label17.TabIndex = 57
        Me.Label17.Text = "Empleado:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(856, 128)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 58
        Me.Button1.Text = "Buscar"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(856, 80)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(112, 21)
        Me.TextBox1.TabIndex = 59
        Me.TextBox1.Text = ""
        '
        'chbValeCred
        '
        Me.chbValeCred.Location = New System.Drawing.Point(856, 104)
        Me.chbValeCred.Name = "chbValeCred"
        Me.chbValeCred.Size = New System.Drawing.Size(120, 24)
        Me.chbValeCred.TabIndex = 60
        Me.chbValeCred.Text = "Por vale de credito"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(570, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 19)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Documento"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmCierreRelacionCobranza
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(1008, 637)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.chbValeCred, Me.TextBox1, Me.Button1, Me.Label17, Me.Label16, Me.Label15, Me.lblEmpleado, Me.lblFCobranza, Me.lblCobranza, Me.lblTituloRelacion, Me.stbEstatus, Me.lblTituloDocumentos, Me.lblTituloCobros, Me.Panel1, Me.btnBorrarCobro, Me.lstPedido, Me.btnAgregarCobro, Me.lstCobro, Me.btnCancelar, Me.btnAceptar, Me.pnlGestion, Me.lblAyuda})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCierreRelacionCobranza"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cierre de la relación de cobranza"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public ReadOnly Property TotalSaldoReal() As Decimal
        Get
            Return _TotalSaldoReal
        End Get
    End Property

    Private Sub CalculaSaldoDocumento()
        Dim oCobro As SigaMetClasses.sCobro
        Dim oCobroPedido As SigaMetClasses.sPedido
        Dim oGestion As SigaMetClasses.GestionCobranza
        Dim _TipoCobro As Byte

        For Each oGestion In Me.pnlGestion.Controls
            oGestion.TotalCobro = 0
            oGestion.TipoCobro = 5
        Next

        For Each oCobro In Me.lstCobro.Items
            _TipoCobro = CType(oCobro.TipoCobro, Byte)
            For Each oCobroPedido In oCobro.ListaPedidos
                Dim PedRef As String, Abono As Decimal
                PedRef = oCobroPedido.PedidoReferencia
                Abono = oCobroPedido.ImporteAbono
                For Each oGestion In Me.pnlGestion.Controls
                    If oGestion.PedidoReferencia = PedRef Then
                        oGestion.TipoGestionCobranza = 1
                        oGestion.TipoCobro = _TipoCobro
                        oGestion.TotalCobro += Abono
                    End If
                Next
            Next
        Next

    End Sub

    Private Sub CalculaSaldoDocumento2()
        Dim oCobro As SigaMetClasses.sCobro
        Dim oCobroPedido As SigaMetClasses.sPedido
        Dim oGestion As SigaMetClasses.GestionCobranza

        For Each oGestion In Me.pnlGestion.Controls
            Dim _PedidoReferencia As String = oGestion.PedidoReferencia
            Dim _TotalAbono As Decimal = 0
            Dim _TipoCobro As Byte = 5
            For Each oCobro In Me.lstCobro.Items
                For Each oCobroPedido In oCobro.ListaPedidos
                    If oCobroPedido.PedidoReferencia = _PedidoReferencia Then
                        _TotalAbono += oCobroPedido.ImporteAbono
                        _TipoCobro = CType(oCobro.TipoCobro, Byte)
                    End If
                Next
            Next
            oGestion.TotalCobro = _TotalAbono
            oGestion.TipoCobro = _TipoCobro
        Next
    End Sub

#Region "Eventos"

    Private Sub ReasignacionCobro(ByVal Cobro As Short, ByVal objControlGestion As SigaMetClasses.GestionCobranza)

        If _TablaCobro.Rows.Count = 0 Then
            MessageBox.Show("No se han dado de alta documentos de cobro.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            objControlGestion.txtDocumento.Text = String.Empty
            objControlGestion.TipoCobro = 5
            Exit Sub
        End If

        Dim dr As DataRow, SeEncontro As Boolean = False
        For Each dr In _TablaCobro.Rows
            If CType(dr("Cobro"), Short) = Cobro Then
                SeEncontro = True
                If CType(dr("Saldo"), Decimal) > 0 Then
                    If CType(dr("Saldo"), Decimal) <= objControlGestion.TotalCobro Then
                        objControlGestion.TotalCobro = CType(dr("Saldo"), Decimal)
                    Else
                        objControlGestion.TotalCobro = objControlGestion.SaldoReal
                    End If
                Else
                    MessageBox.Show("El cobro ya fue usado en su totalidad.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    objControlGestion.txtDocumento.Text = String.Empty
                    objControlGestion.TipoCobro = 5
                End If

            End If
        Next
        If Not SeEncontro Then
            MessageBox.Show("El cobro no existe en la lista de cobros.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            objControlGestion.txtDocumento.Focus()
            objControlGestion.txtDocumento.SelectAll()
        End If
    End Sub

    Private Sub RepetirObservacionesCliente(ByVal Cliente As Integer, ByVal Observaciones As String)
        Cursor = Cursors.WaitCursor
        Dim objGC As SigaMetClasses.GestionCobranza
        For Each objGC In Me.pnlGestion.Controls
            If objGC.Cliente = Cliente Then
                objGC.Observaciones = Observaciones
            End If
        Next
        Cursor = Cursors.Default
    End Sub

    Private Sub RepetirObservacionesEmpresa(ByVal Empresa As Integer, ByVal Observaciones As String)
        Cursor = Cursors.WaitCursor
        Dim objGC As SigaMetClasses.GestionCobranza
        For Each objGC In Me.pnlGestion.Controls
            If objGC.Empresa = Empresa Then
                objGC.Observaciones = Observaciones
            End If
        Next
        Cursor = Cursors.Default
    End Sub


    Private Sub RepetirFCompromisoCliente(ByVal Cliente As Integer, ByVal FCompromiso As Date)
        Cursor = Cursors.WaitCursor
        Dim objGC As SigaMetClasses.GestionCobranza
        For Each objGC In Me.pnlGestion.Controls
            If objGC.Cliente = Cliente Then
                objGC.FCompromisoGestion = FCompromiso
            End If
        Next
        Cursor = Cursors.Default
    End Sub

    Private Sub RepetirFCompromisoEmpresa(ByVal Empresa As Integer, ByVal FCompromiso As Date)
        Cursor = Cursors.WaitCursor
        Dim objGC As SigaMetClasses.GestionCobranza
        For Each objGC In Me.pnlGestion.Controls
            If objGC.Empresa = Empresa Then
                objGC.FCompromisoGestion = FCompromiso
            End If
        Next
        Cursor = Cursors.Default
    End Sub

    Private Sub RepetirDocumentoGestionCliente(ByVal Cliente As Integer, ByVal DocumentoGestion As String)
        Cursor = Cursors.WaitCursor
        Dim objGC As SigaMetClasses.GestionCobranza
        For Each objGC In Me.pnlGestion.Controls
            If objGC.Cliente = Cliente Then
                objGC.DocumentoGestion = DocumentoGestion
            End If
        Next
        Cursor = Cursors.Default
    End Sub

    Private Sub RepetirDocumentoGestionEmpresa(ByVal Empresa As Integer, ByVal DocumentoGestion As String)
        Cursor = Cursors.WaitCursor
        Dim objGC As SigaMetClasses.GestionCobranza
        For Each objGC In Me.pnlGestion.Controls
            If objGC.Empresa = Empresa Then
                objGC.DocumentoGestion = DocumentoGestion
            End If
        Next
        Cursor = Cursors.Default
    End Sub


#End Region
#Region "Funciones"

    Private Function VerificaRelacionCobranza() As Boolean
        Dim oGestion As SigaMetClasses.GestionCobranza
        For Each oGestion In Me.pnlGestion.Controls
            If oGestion.TipoGestionCobranza = 1 Then
                If oGestion.TotalCobro <= 0 Then
                    If oGestion.IncluirEnEfectivo = False Then
                        If oGestion.SaldoReal > 0 Then
                            MessageBox.Show("Falta por relacionar cobros.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Return False
                        End If
                    End If
                End If
            End If
        Next
        Return True
    End Function

    Private Function CalculaTotalEfectivo() As Decimal
        Dim oGestion As SigaMetClasses.GestionCobranza
        Dim _TotalEfectivo As Decimal
        For Each oGestion In pnlGestion.Controls
            If oGestion.TipoGestionCobranza = 1 _
                And (oGestion.TipoCobro = 5 And oGestion.IncluirEnEfectivo = True) _
                Or (oGestion.TipoCobro <> 5 And oGestion.IncluirEnEfectivo = True And oGestion.TotalCobro > 0) Then
                _TotalEfectivo += oGestion.Saldo
            End If
        Next
        Return _TotalEfectivo
    End Function

    Private Function CalculaTotalMovimiento() As Decimal
        Dim oGestion As SigaMetClasses.GestionCobranza
        Dim oCobro As SigaMetClasses.sCobro
        Dim _Total As Decimal
        For Each oCobro In lstCobro.Items
            _Total += oCobro.Total
        Next

        For Each oGestion In pnlGestion.Controls
            If oGestion.TipoGestionCobranza = 1 Then
                If oGestion.TipoCobro = 5 Then
                    If oGestion.IncluirEnEfectivo = True Then
                        _Total += oGestion.Saldo
                    End If
                End If
                If oGestion.TipoCobro <> 5 Then
                    _Total += oGestion.TotalCobro
                End If
            End If
        Next
        Return _Total
    End Function

    Private Sub AvandonaControl(ByVal sender As Object, ByVal e As System.EventArgs) Handles objGestionCob.Leave
        Dim objGC As SigaMetClasses.GestionCobranza
        For Each objGC In Me.pnlGestion.Controls
            objGC.BackColor = Color.Gainsboro
        Next
    End Sub


    Private Sub CargaGestionCobranza()
        Dim dr As DataRow
        Dim oGateway As RTGMGateway.RTGMGateway
        Dim oSolicitud As RTGMGateway.SolicitudGateway
        Dim oDireccionEntrega As RTGMCore.DireccionEntrega
        Dim lClienteNombre As String
        Dim lCliente As Integer
        If Not _URLGateway Is Nothing And _URLGateway.Trim() <> "" Then
            oGateway = New RTGMGateway.RTGMGateway()
            oSolicitud = New RTGMGateway.SolicitudGateway()
            oGateway.URLServicio = _URLGateway
            oSolicitud.Fuente = RTGMCore.Fuente.CRM
        End If

        Dim i As Integer = 0
        For Each dr In _dsCobranza.Tables("PedidoCobranza").Rows
            If CType(dr("Cobranza"), Integer) = _Cobranza Then
                i += 1
                _TotalSaldoReal += CType(dr("Saldo"), Decimal)
                objGestionCob = New SigaMetClasses.GestionCobranza()

                lCliente = CType(dr("Cliente"), Integer)
                If Not String.IsNullOrEmpty(_URLGateway) Then
                    oSolicitud.IDCliente = lCliente
                    oDireccionEntrega = oGateway.buscarDireccionEntrega(oSolicitud)
                    lClienteNombre = oDireccionEntrega.Nombre
                Else
                    lClienteNombre = Trim(CType(dr("Nombre"), String))
                End If

                With objGestionCob
                    .Top = i * objGestionCob.Height
                    .AñoPed = CType(dr("AñoPed"), Short)
                    .Celula = CType(dr("Celula"), Byte)
                    .Pedido = CType(dr("Pedido"), Integer)
                    .PedidoReferencia = Trim(CType(dr("PedidoReferencia"), String))
                    .GestionInicial = CType(dr("GestionInicial"), Byte)               
                    .GestionInicialDescripcion = Trim(CType(dr("GestionInicialDescripcion"), String))
                    .Cliente = CType(dr("Cliente"), Integer)
                    If Not IsDBNull(dr("Empresa")) Then
                        .Empresa = CType(dr("Empresa"), Integer)
                    End If

                    .Nombre = lClienteNombre
                    .DiasCredito = CType(dr("DiasCredito"), Short)
                    .SaldoReal = CType(dr("Saldo"), Decimal)
                    If Not IsDBNull(dr("ValeCredito")) Then
                        .ValeCredito = CType(dr("ValeCredito"), String)
                    End If
                    '.TipoGestionCobranza = CType(dr("GestionInicial"), Byte)
                    .TipoGestionCobranza = 1
                End With

                If _TipoMovimientoCaja = 0 Then
                    If CType(dr("TipoCargo"), Byte) = 1 Then
                        _TipoMovimientoCaja = GLOBAL_TipoMovCajaVentaGas
                    End If
                    If CType(dr("TipoCargo"), Byte) = 3 Then
                        _TipoMovimientoCaja = GLOBAL_TipoMovCajaCheqDev
                    End If
                End If


                AddHandler Me.objGestionCob.ReasignacionCobro, AddressOf Me.ReasignacionCobro
                AddHandler Me.objGestionCob.RepetirObservacionesCliente, AddressOf Me.RepetirObservacionesCliente
                AddHandler Me.objGestionCob.RepetirObservacionesEmpresa, AddressOf Me.RepetirObservacionesEmpresa
                AddHandler Me.objGestionCob.RepetirFCompromisoCliente, AddressOf Me.RepetirFCompromisoCliente
                AddHandler Me.objGestionCob.RepetirFCompromisoEmpresa, AddressOf Me.RepetirFCompromisoEmpresa
                AddHandler Me.objGestionCob.RepetirDocumentoCobroCliente, AddressOf Me.RepetirDocumentoGestionCliente
                AddHandler Me.objGestionCob.RepetirDocumentoCobroEmpresa, AddressOf Me.RepetirDocumentoGestionEmpresa
                AddHandler Me.objGestionCob.Leave, AddressOf Me.AvandonaControl

                pnlGestion.Controls.Add(objGestionCob)
            End If
        Next

        lblTituloRelacion.Text = "Lista de documentos incluidos en la relación de cobranza (" & i.ToString & " en total)"
    End Sub

    Private Function CierraRelacion() As String
        'Creación del MovimientoCaja
        Cursor = Cursors.WaitCursor
        Dim _NuevoCobro As Integer = Nothing
        Dim oGestion As SigaMetClasses.GestionCobranza
        Dim ListaCobros As New ArrayList()
        Dim oCobro As SigaMetClasses.sCobro
        Dim oCobroPedido As SigaMetClasses.sPedido
        Dim oMovimientoCaja As New SigaMetClasses.TransaccionMovimientoCaja()
        Dim TotalMovimiento As Decimal
        Dim _EfectivoEnLista As Boolean

        'Control de cheques posfechados
        _chequesPosfechados = False

        '********
        'Efectivo
        '********
        Try

            'Si capturaron cobros
            If lstCobro.Items.Count > 0 Then
                'Reviso cada cobro en la lista
                For Each oCobro In Me.lstCobro.Items
                    If oCobro.TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.EfectivoVales Then
                        _EfectivoEnLista = True
                        If Me.CalculaTotalEfectivo > 0 Then
                            oCobro.Total += CalculaTotalEfectivo()

                            'Agregar los documentos relacionados con el cobro
                            For Each oGestion In Me.pnlGestion.Controls
                                If oGestion.TipoGestionCobranza = 1 _
                                And (oGestion.TipoCobro = 5 And oGestion.IncluirEnEfectivo = True) _
                                Or (oGestion.TipoCobro <> 5 And oGestion.IncluirEnEfectivo = True And oGestion.TotalCobro > 0) Then
                                    Dim objCobroPedido As SigaMetClasses.sPedido
                                    objCobroPedido.AnoPed = oGestion.AñoPed
                                    objCobroPedido.Celula = oGestion.Celula
                                    objCobroPedido.Pedido = oGestion.Pedido
                                    objCobroPedido.PedidoReferencia = oGestion.PedidoReferencia
                                    objCobroPedido.ImporteAbono = oGestion.Saldo

                                    oCobro.ListaPedidos.Add(objCobroPedido)
                                End If
                            Next
                        End If
                    End If

                    'Control de cobros posfechados, no sumar el total de cobros posfechados
                    If Not oCobro.Posfechado Then
                        TotalMovimiento += oCobro.Total
                    Else
                        'Marcar el movimiento como contenedor de cobros posfechados
                        _chequesPosfechados = True
                    End If
                    '*****

                    'Los cobros posfechados se controlan dentro de la transacción de movimientocaja
                    ListaCobros.Add(oCobro)
                Next

                'Aqui me quede
                If Me.CalculaTotalEfectivo > 0 And _EfectivoEnLista = False Then
                    oCobro = New SigaMetClasses.sCobro()
                    oCobro.ListaPedidos = New ArrayList()
                    oCobro.Total += CalculaTotalEfectivo()
                    oCobro.TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.EfectivoVales
                    oCobro.AnoCobro = CType(Year(FechaOperacion), Short)

                    'Agregar los documentos relacionados con el cobro
                    For Each oGestion In Me.pnlGestion.Controls
                        If oGestion.TipoGestionCobranza = 1 _
                        And (oGestion.TipoCobro = 5 And oGestion.IncluirEnEfectivo = True) _
                        Or (oGestion.TipoCobro <> 5 And oGestion.IncluirEnEfectivo = True And oGestion.TotalCobro > 0) Then
                            Dim objCobroPedido As SigaMetClasses.sPedido
                            objCobroPedido.AnoPed = oGestion.AñoPed
                            objCobroPedido.Celula = oGestion.Celula
                            objCobroPedido.Pedido = oGestion.Pedido
                            objCobroPedido.PedidoReferencia = oGestion.PedidoReferencia
                            objCobroPedido.ImporteAbono = oGestion.Saldo

                            oCobro.ListaPedidos.Add(objCobroPedido)
                        End If
                    Next
                    TotalMovimiento += oCobro.Total
                    ListaCobros.Add(oCobro)
                End If
                'Aqui me quede

            Else
                'No le capturaron cobros. Reviso si hay efectivos.
                If CalculaTotalEfectivo() > 0 Then
                    oCobro.AnoCobro = CType(FechaOperacion.Year, Short)
                    oCobro.TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.EfectivoVales
                    oCobro.Total = CalculaTotalEfectivo()
                    oCobro.Saldo = 0
                    oCobro.ListaPedidos = New ArrayList()

                    'Agregar los documentos relacionados con el cobro
                    For Each oGestion In Me.pnlGestion.Controls
                        If oGestion.TipoGestionCobranza = 1 _
                        And (oGestion.TipoCobro = 5 And oGestion.IncluirEnEfectivo = True) _
                        Or (oGestion.TipoCobro <> 5 And oGestion.IncluirEnEfectivo = True And oGestion.TotalCobro > 0) Then
                            Dim objCobroPedido As SigaMetClasses.sPedido
                            objCobroPedido.AnoPed = oGestion.AñoPed
                            objCobroPedido.Celula = oGestion.Celula
                            objCobroPedido.Pedido = oGestion.Pedido
                            objCobroPedido.PedidoReferencia = oGestion.PedidoReferencia
                            objCobroPedido.ImporteAbono = oGestion.Saldo

                            oCobro.ListaPedidos.Add(objCobroPedido)
                        End If
                    Next
                    TotalMovimiento += oCobro.Total
                    ListaCobros.Add(oCobro)
                End If
            End If

            If Main.SesionIniciada = False Then
                IniciarSesion(FechaInicioSesion)
            End If

            Dim strClave As String = Nothing
            oMovimientoCaja.Alta(GLOBAL_CajaUsuario, _
                                Main.FechaOperacion, _
                                Main.ConsecutivoInicioDeSesion, _
                                Main.FechaOperacion, _
                                TotalMovimiento, _
                                Main.GLOBAL_IDUsuario, _
                                _Empleado, _
                                _TipoMovimientoCaja, _
                                0, _
                                0, _
                                ListaCobros, _
                                Main.GLOBAL_IDUsuario, _
                                "FUENTE: RELACION_COBRANZA", _
                                strClave)
            Return strClave
        Catch ex As Exception
            Throw ex
        Finally
            Cursor = Cursors.Default
            oCobro = Nothing
            oCobroPedido = Nothing
        End Try

    End Function

#End Region

#Region "Devolución de documentos no gestionados"
    'Lista de documentos en la nueva cobranza
    Dim listaNvaCobranza As ArrayList
    Dim listaDocumentos As System.Text.StringBuilder

    'Lista de documentos en la nueva cobranza documentos devueltos a resguardo
    Dim listaNvaCobranzaResguardo As ArrayList
    Dim listaDocumentosResguardo As System.Text.StringBuilder

    'Verificar que si se requiere 
    'Validar que se devuelvan todos los documentos no gestionados
    Public Function ValidaDevolucionDocumentos() As Boolean
        Dim oGestion As SigaMetClasses.GestionCobranza
        For Each oGestion In Me.pnlGestion.Controls
            If oGestion.DevolucionRequerida AndAlso Not oGestion.DocumentoDevuelto Then
                oGestion.Select()
                Return False
            End If
        Next
        Return True
    End Function

    'Calcular el total de la lista de cobranza de resguardo documentos devueltos
    Public Function TotalNuevaCobranzaResguardo() As Decimal
        listaNvaCobranzaResguardo = New ArrayList()
        listaDocumentosResguardo = New System.Text.StringBuilder()

        Dim total As Decimal
        Dim oGestion As SigaMetClasses.GestionCobranza
        For Each oGestion In Me.pnlGestion.Controls
            If oGestion.DevolucionRequerida AndAlso oGestion.DocumentoDevuelto Then
                Dim oPedido As SigaMetClasses.sPedido
                oPedido.AnoPed = oGestion.AñoPed
                oPedido.Celula = oGestion.Celula
                oPedido.Pedido = oGestion.Pedido
                oPedido.Saldo = oGestion.SaldoReal
                oPedido.TipoCargo = oGestion.GestionInicial
                listaNvaCobranzaResguardo.Add(oPedido)
                listaDocumentosResguardo.Append(oGestion.PedidoReferencia)
                listaDocumentosResguardo.Append(vbCrLf)
                total += oGestion.SaldoReal
            End If
        Next
        Return total
    End Function

    'Calcular el total de la nueva cobranza de cobrador documentos no devueltos
    Public Function TotalNuevaCobranza() As Decimal
        listaNvaCobranza = New ArrayList()
        listaDocumentos = New System.Text.StringBuilder()

        Dim total As Decimal
        Dim oGestion As SigaMetClasses.GestionCobranza
        For Each oGestion In Me.pnlGestion.Controls
            If oGestion.DevolucionRequerida AndAlso Not oGestion.DocumentoDevuelto Then
                Dim oPedido As SigaMetClasses.sPedido
                oPedido.AnoPed = oGestion.AñoPed
                oPedido.Celula = oGestion.Celula
                oPedido.Pedido = oGestion.Pedido
                oPedido.Saldo = oGestion.SaldoReal
                oPedido.TipoCargo = oGestion.GestionInicial
                listaNvaCobranza.Add(oPedido)
                listaDocumentos.Append(oGestion.PedidoReferencia)
                listaDocumentos.Append(vbCrLf)
                total += oGestion.SaldoReal
            End If
        Next
        Return total
    End Function

    'Imprimir el comprobante de la cobranza generada automáticamente
    Private Sub imprimirComprobanteCobranza(ByVal NuevaCobranza As Integer)
        'Solo se despliega la pantalla cuando se genera la lista
        If NuevaCobranza > 0 Then
            Cursor = Cursors.WaitCursor
            Dim frmReporte As New frmConsultaReporte(frmConsultaReporte.enumTipoReporte.RelacionCobranza, 0, DateTime.Now.Date, NuevaCobranza, 0)
            frmReporte.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub
#End Region

    Public Sub New(ByVal dsCobranza As DataSet,
                   ByVal Cobranza As Integer, Optional URLGateway As String = "")
        MyBase.New()
        InitializeComponent()
        _UrlGateway = URLGateway
        _dsCobranza = dsCobranza
        _Cobranza = Cobranza
        CargaGestionCobranza()

        _dtCobranza = dsCobranza.Tables("Cobranza")
        _dtCobranza.DefaultView.RowFilter = "Cobranza = " & Cobranza.ToString

        _Empleado = CType(_dtCobranza.DefaultView.Item(0).Item("Empleado"), Integer)
        _EmpleadoNombre = CType(_dtCobranza.DefaultView.Item(0).Item("EmpleadoNombre"), String)
        _FCobranza = CType(_dtCobranza.DefaultView.Item(0).Item("FCobranza"), Date)

        lblCobranza.Text = _Cobranza.ToString
        lblFCobranza.Text = _FCobranza.ToLongDateString
        lblEmpleado.Text = _Empleado.ToString & " " & _EmpleadoNombre

        'Reiniciar para la captura de efectivo y vales
        CapturaEfectivoVales = False
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        'TODO: Validar que se entreguen todos los documentos con saldo, parametrizar esta función
        Dim generaNuevaLista As Boolean = False
        '*****
        If Not VerificaRelacionCobranza() Then
            Exit Sub
        End If
        If MessageBox.Show(SigaMetClasses.M_ESTAN_CORRECTOS, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            'TODO: Validar que se entreguen todos los documentos con saldo, parametrizar esta función
            If GLOBAL_DevDocumentosReq AndAlso Not ValidaDevolucionDocumentos() Then
                If MessageBox.Show("Hay documentos no cobrados que no fueron devueltos" & vbCrLf & _
                    "Haga click en 'SÍ' para continuar y generar una nueva lista con" & vbCrLf & _
                    "los documentos no devueltos" & vbCrLf & _
                    "Haga click en 'NO' para volver a la pantalla de captura y verificar", Me.Text, MessageBoxButtons.YesNo, _
                    MessageBoxIcon.Question) = DialogResult.No Then
                    Exit Sub
                Else
                    generaNuevaLista = True
                End If
            End If
            '*****

            Dim oGestion As SigaMetClasses.GestionCobranza
            Dim oCobPed As SigaMetClasses.cCobranza.cPedidoCobranza
            Dim ListaPedidos As New ArrayList()

            Try
                Dim strMovimientoCajaClave As String = Nothing

                If CalculaTotalMovimiento() > 0 Then
                    strMovimientoCajaClave = CierraRelacion()
                End If

                Cursor = Cursors.WaitCursor

                For Each oGestion In Me.pnlGestion.Controls
                    oCobPed = New SigaMetClasses.cCobranza.cPedidoCobranza()
                    With oCobPed
                        .AñoPed = oGestion.AñoPed
                        .Celula = oGestion.Celula
                        .Pedido = oGestion.Pedido
                        .Cobranza = _Cobranza
                        .DocumentoGestion = oGestion.DocumentoGestion
                        .GestionFinal = oGestion.TipoGestionCobranza
                        If oGestion.FCompromisoCapturada Then
                            .FCompromisoGestion = oGestion.FCompromisoGestion
                        End If
                        .Observaciones = oGestion.Observaciones
                    End With
                    ListaPedidos.Add(oCobPed)

                Next
                Dim oCobranza As New SigaMetClasses.cCobranza()
                oCobranza.Cierra(_Cobranza, ListaPedidos, strMovimientoCajaClave)
                Dim strMensaje As String = "La relación fue cerrada exitosamente."

                Dim msgBoxButton As MessageBoxButtons = MessageBoxButtons.OK
                Dim msgBoxIcon As MessageBoxIcon = MessageBoxIcon.Information

                If strMovimientoCajaClave <> "" Then
                    strMensaje &= Chr(13) & "La información de los abonos fue guardada en el movimiento " & strMovimientoCajaClave & _
                        Chr(13) & "¿Desea imprimir el comprobante?"
                    msgBoxButton = MessageBoxButtons.YesNo
                    msgBoxIcon = MessageBoxIcon.Question
                End If

                If MessageBox.Show(strMensaje, Titulo, msgBoxButton, msgBoxIcon) = DialogResult.Yes Then
                    imprimirComprobanteCaja(strMovimientoCajaClave)
                End If

                'Control de cheques posfechados, impresión del listado acumulado de cheques posfechados del día y del usuario
                If _chequesPosfechados Then
                    If MessageBox.Show("Este movimiento generó cobros posfechados" & vbCrLf & _
                        "¿Desea imprimir el listado? (acumulado del día de hoy)", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        Dim rptListadoPosfechados As frmConsultaReporte = New frmConsultaReporte(frmConsultaReporte.enumTipoReporte.RelacionChequePosfechado, _
                            GLOBAL_IDUsuario, FechaOperacion)
                        rptListadoPosfechados.ShowDialog()
                    End If
                End If
                '*****

                'Procesar la nueva lista de cobranza para el cobrador / documentos no devueltos y la nueva lista de documentos devueltos
                If GLOBAL_DevDocumentosReq Then
                    Dim nuevaCobranzaResguardo As Integer 'Cobranza para devolución de documentos a resguardo
                    Dim nuevaCobranza As Integer 'Cobranza de documentos no entregados por el cobrador

                    Dim nCobranza As New SigaMetClasses.cCobranza()
                    Try
                        'Lista de cobranza para resguardo
                        Dim _totalNvaCobranzaResguardo As Decimal = TotalNuevaCobranzaResguardo()
                        If listaNvaCobranzaResguardo.Count > 0 Then
                            nuevaCobranzaResguardo = nCobranza.Alta(DateTime.Now.Date, 9, GLOBAL_IDUsuario, GLOBAL_IDEmpleado, _
                                                        _totalNvaCobranzaResguardo, "Documentos devueltos a resguardo", listaNvaCobranzaResguardo)
                        End If

                        'Lista de cobranza para cobrador
                        Dim _totalNvaCobranzaGestor As Decimal = TotalNuevaCobranza()
                        If generaNuevaLista And listaNvaCobranza.Count > 0 Then
                            nuevaCobranza = nCobranza.Alta(DateTime.Now.Date, GLOBAL_ListaDevCobrador, GLOBAL_IDUsuario, _Empleado, _
                                _totalNvaCobranzaGestor, "Documentos no entregados", listaNvaCobranza)
                        End If
                        '*****
                    Catch ex As Exception
                        Dim mensaje As String

                        If nuevaCobranzaResguardo = 0 Then
                            mensaje = "Error al generar la lista de cobranza de documentos devueltos"
                        Else
                            mensaje = "Error al generar la lista de cobranza para el cobrador (documentos no entregados)"
                        End If

                        MessageBox.Show(mensaje & vbCrLf & _
                            "Capture manualmente la lista de cobranza para los siguientes documentos:" & vbCrLf & _
                            listaDocumentos.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        _Cierre = True
                        DialogResult = DialogResult.OK
                    Finally
                        Dim mensaje As String = ""
                        If nuevaCobranzaResguardo > 0 Then
                            mensaje &= "Los documentos devueltos (Resguardo) fueron capturados en la lista " & nuevaCobranzaResguardo.ToString() & vbCrLf
                        End If

                        If nuevaCobranza > 0 Then
                            mensaje &= "Los documentos no devueltos (Cobrador) fueron capturados en la lista " & nuevaCobranza.ToString()
                        End If


                        If (MessageBox.Show(mensaje & vbCrLf & _
                            "¿Desea imprimir los comprobantes?", Me.Text, MessageBoxButtons.YesNo, _
                            MessageBoxIcon.Question) = DialogResult.Yes) Then
                            imprimirComprobanteCobranza(nuevaCobranzaResguardo)
                            imprimirComprobanteCobranza(nuevaCobranza)
                        End If
                    End Try
                End If
                '*****

                _Cierre = True

                DialogResult = DialogResult.OK

            Catch ex As Exception
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Cursor = Cursors.Default
            End Try
        End If

    End Sub


    Private Sub frmCierreRelacionCobranza_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lstCobro.DisplayMember = "InformacionCompleta"
        lstPedido.DisplayMember = "InformacionCompleta"
    End Sub

    Private Sub lstCobro_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstCobro.SelectedIndexChanged
        Dim s As SigaMetClasses.sPedido
        lstPedido.Items.Clear()
        If Not lstCobro.SelectedIndex < 0 AndAlso Not IsNothing(CType(lstCobro.Items(lstCobro.SelectedIndex), SigaMetClasses.sCobro).ListaPedidos()) Then
            For Each s In CType(lstCobro.Items(lstCobro.SelectedIndex), SigaMetClasses.sCobro).ListaPedidos()
                lstPedido.Items.Add(s)
            Next
        End If
    End Sub

    Private Function GeneraListaDocumentos() As ArrayList
        Dim arrDocumentos As New ArrayList()
        Dim oGestion As SigaMetClasses.GestionCobranza
        Dim oPedido As SigaMetClasses.sPedido
        For Each oGestion In Me.pnlGestion.Controls
            If oGestion.Saldo > 0 And oGestion.TipoGestionCobranza = 1 Then
                oPedido.PedidoReferencia = oGestion.PedidoReferencia
                arrDocumentos.Add(oPedido)
            End If
        Next
        Return arrDocumentos

    End Function

    Private Sub btnAgregarCobro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarCobro.Click
        intCobro += 1

        Dim oCapCobro As New frmSelTipoCobro(intCobro, lstCobro, GeneraListaDocumentos, _TipoMovimientoCaja)

        If oSeguridad.TieneAcceso("AreaDacionEnPago") Then
            oCapCobro.HabilitarDacionEnPago = True
        End If

        If oCapCobro.ShowDialog() = DialogResult.OK Then
            lstCobro.Items.Add(oCapCobro.Cobro)
            CalculaSaldoDocumento2()
        End If
    End Sub

    Private Sub frmCierreRelacionCobranza_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not _Cierre Then
            If MessageBox.Show("¿Desea salir del cierre de la cobranza?", Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'TextBox1.Text = Me.CalculaTotalEfectivo.ToString("N")
        Dim Encontrado As Boolean
        Dim Err As Boolean
        Encontrado = False
        Err = True
        Dim oGestion As SigaMetClasses.GestionCobranza
        For Each oGestion In Me.pnlGestion.Controls
            If oGestion.Saldo > 0 And oGestion.TipoGestionCobranza = 1 Then
                If chbValeCred.Checked = False Then
                    If oGestion.PedidoReferencia = TextBox1.Text Then
                        oGestion.Select()
                        oGestion.Focus()
                        oGestion.BackColor = Color.Blue
                        Encontrado = True
                        Exit For
                    End If
                Else
                    Try
                        If Convert.ToInt32(oGestion.ValeCredito) = Convert.ToInt32(TextBox1.Text) Then
                            oGestion.Select()
                            oGestion.Focus()
                            oGestion.BackColor = Color.Blue
                            Encontrado = True
                            Exit For
                        End If
                    Catch Ex As OverflowException
                        MessageBox.Show("Por favor indique un vale de crédito", "CyC", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        TextBox1.Focus()
                        Err = False
                        Exit For
                    End Try

                End If
            End If
        Next
        If Encontrado = False And Err Then
            MessageBox.Show("Documento no encontrado", "CyC", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub

    Private Sub imprimirComprobanteCaja(ByVal Clave As String)
        Dim _Caja As Byte
        Dim _FOperacion As DateTime
        Dim _Consecutivo As Byte
        Dim _Folio As Integer
        Dim dtMovimiento As DataTable

        Try
            dtMovimiento = Main.consultaMovimientoCobranza(SigaMetClasses.DataLayer.Conexion, Clave)
            _Caja = CType(dtMovimiento.Rows(0).Item("Caja"), Byte)
            _FOperacion = CType(dtMovimiento.Rows(0).Item("FOperacion"), DateTime)
            _Consecutivo = CType(dtMovimiento.Rows(0).Item("Consecutivo"), Byte)
            _Folio = CType(dtMovimiento.Rows(0).Item("Folio"), Integer)
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error:" & vbCrLf & _
                ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

        If _Caja <> 0 And _Folio <> 0 And _Consecutivo <> 0 Then
            Cursor = Cursors.WaitCursor
            Dim frmRep As New frmConsultaReporte(frmConsultaReporte.enumTipoReporte.CombrobanteCaja, _Caja, _FOperacion, _Folio, _Consecutivo)
            frmRep.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub btnBorrarCobro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrarCobro.Click
        BorrarCobro()
    End Sub

    Private Sub BorrarCobro()
        If CType(lstCobro.SelectedItem, SigaMetClasses.sCobro).TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.EfectivoVales Then
            CapturaEfectivoVales = False
        End If
        'lstCobro.Items.Remove(lstCobro.SelectedItem)
        lstCobro.Items.RemoveAt(lstCobro.SelectedIndex)
        'lstPedido.Items.Clear()
        CalculaSaldoDocumento2()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            Button1_Click(sender, e)
        End If
    End Sub
End Class