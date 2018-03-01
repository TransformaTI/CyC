Imports System.Data.SqlClient
Public Class frmDescuentos
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        cnSigamet = Connection
        Dim cmdDescuentos As New SqlCommand("Select Celula, Descripcion from Celula where Comercial = 1", cnSigamet)
        Dim daDescuentos As New SqlDataAdapter(cmdDescuentos)
        Dim Key(0) As DataColumn
        Dim Row As DataRow
        Dim item As MenuItem
        Try
            daDescuentos.Fill(dtCelula)

            cmdDescuentos.CommandText = "Select TipoDescuento, Descripcion from TipoDescuento"
            daDescuentos.Fill(dtTipo)

            Key(0) = dtCelula.Columns("Descripcion")
            dtCelula.PrimaryKey = Key

            Key(0) = dtTipo.Columns("Descripcion")
            dtTipo.PrimaryKey = Key
        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        item = mnuFiltro.MenuItems.Add("Todas las células", New EventHandler(AddressOf mniFiltroCelula_Click))
        item.DefaultItem = True
        item.Checked = True
        For Each Row In dtCelula.Rows
            mnuFiltro.MenuItems.Add(CStr(Row("Descripcion")), New EventHandler(AddressOf mniFiltroCelula_Click))
        Next
        AuxFiltro = mnuFiltro.MenuItems.Add("-").Index

        item = mnuFiltro.MenuItems.Add("Todos los tipos", New EventHandler(AddressOf mniFiltroTipo_Click))
        item.DefaultItem = True
        item.Checked = True
        For Each Row In dtTipo.Rows
            mnuFiltro.MenuItems.Add(CStr(Row("Descripcion")), New EventHandler(AddressOf mniFiltroTipo_Click))
        Next
        Actualizar()
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
    Friend WithEvents tabDetalles As System.Windows.Forms.TabControl
    Friend WithEvents imgDescuentos As System.Windows.Forms.ImageList
    Friend WithEvents tabCliente As System.Windows.Forms.TabPage
    Friend WithEvents tabEmpresa As System.Windows.Forms.TabPage
    Friend WithEvents tabHistorico As System.Windows.Forms.TabPage
    Friend WithEvents sptDescuentos As System.Windows.Forms.Splitter
    Friend WithEvents tbDescuentos As System.Windows.Forms.ToolBar
    Friend WithEvents btnFiltro As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnActualizar As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents txtMunicipio As System.Windows.Forms.TextBox
    Friend WithEvents lblColonia As System.Windows.Forms.Label
    Friend WithEvents lblCalle As System.Windows.Forms.Label
    Friend WithEvents txtColonia As System.Windows.Forms.TextBox
    Friend WithEvents txtCalle As System.Windows.Forms.TextBox
    Friend WithEvents txtNumExterior As System.Windows.Forms.TextBox
    Friend WithEvents lblTelefono As System.Windows.Forms.Label
    Friend WithEvents txtRamo As System.Windows.Forms.TextBox
    Friend WithEvents lblNumExterior As System.Windows.Forms.Label
    Friend WithEvents lblRamo As System.Windows.Forms.Label
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents txtNumInterior As System.Windows.Forms.TextBox
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents txtConsumo As System.Windows.Forms.TextBox
    Friend WithEvents lblNumInterior As System.Windows.Forms.Label
    Friend WithEvents lblConsumo As System.Windows.Forms.Label
    Friend WithEvents txtRuta As System.Windows.Forms.TextBox
    Friend WithEvents txtFax As System.Windows.Forms.TextBox
    Friend WithEvents txtTelefonoEmp As System.Windows.Forms.TextBox
    Friend WithEvents txtCP As System.Windows.Forms.TextBox
    Friend WithEvents txtCalleEmp As System.Windows.Forms.TextBox
    Friend WithEvents txtColoniaEmp As System.Windows.Forms.TextBox
    Friend WithEvents txtMunicipioEmp As System.Windows.Forms.TextBox
    Friend WithEvents lblCURP As System.Windows.Forms.Label
    Friend WithEvents txtCURP As System.Windows.Forms.TextBox
    Friend WithEvents lblRFC As System.Windows.Forms.Label
    Friend WithEvents txtRFC As System.Windows.Forms.TextBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblMunicipioEmp As System.Windows.Forms.Label
    Friend WithEvents lblCalleEmp As System.Windows.Forms.Label
    Friend WithEvents lblColoniaEmp As System.Windows.Forms.Label
    Friend WithEvents lblFax As System.Windows.Forms.Label
    Friend WithEvents lblTelefonoEmp As System.Windows.Forms.Label
    Friend WithEvents lblCP As System.Windows.Forms.Label
    Friend WithEvents grdHistorico As System.Windows.Forms.DataGrid
    Friend WithEvents grdDescuentos As System.Windows.Forms.DataGrid
    Friend WithEvents tsDescuentos As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents gcContrato As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents gcCliente As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents gcClientePadre As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents gcCelula As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents gcNoDescuento As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents gcDescuento As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents gcTipo As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents gcFInicial As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents gcFFinal As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tsHistorico As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents gcHNoDescuento As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents gcHDescuento As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents gcHTipo As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents gcHFInicial As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents gcHFFinal As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents gcStatus As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents mnuDescuentos As System.Windows.Forms.MainMenu
    Friend WithEvents mniDescuentos As System.Windows.Forms.MenuItem
    Friend WithEvents mniCatDescuentos As System.Windows.Forms.MenuItem
    Friend WithEvents mniBuscar As System.Windows.Forms.MenuItem
    Friend WithEvents mniActualizar As System.Windows.Forms.MenuItem
    Friend WithEvents mniCerrar As System.Windows.Forms.MenuItem
    Friend WithEvents Sepm0 As System.Windows.Forms.MenuItem
    Friend WithEvents Sepm1 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFiltro As System.Windows.Forms.ContextMenu
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDescuentos))
        Me.tabDetalles = New System.Windows.Forms.TabControl()
        Me.tabCliente = New System.Windows.Forms.TabPage()
        Me.txtNumInterior = New System.Windows.Forms.TextBox()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.txtConsumo = New System.Windows.Forms.TextBox()
        Me.lblNumInterior = New System.Windows.Forms.Label()
        Me.lblConsumo = New System.Windows.Forms.Label()
        Me.txtRuta = New System.Windows.Forms.TextBox()
        Me.txtMunicipio = New System.Windows.Forms.TextBox()
        Me.lblMunicipio = New System.Windows.Forms.Label()
        Me.lblColonia = New System.Windows.Forms.Label()
        Me.lblCalle = New System.Windows.Forms.Label()
        Me.txtColonia = New System.Windows.Forms.TextBox()
        Me.txtCalle = New System.Windows.Forms.TextBox()
        Me.txtNumExterior = New System.Windows.Forms.TextBox()
        Me.lblTelefono = New System.Windows.Forms.Label()
        Me.txtRamo = New System.Windows.Forms.TextBox()
        Me.lblNumExterior = New System.Windows.Forms.Label()
        Me.lblRamo = New System.Windows.Forms.Label()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.tabEmpresa = New System.Windows.Forms.TabPage()
        Me.txtFax = New System.Windows.Forms.TextBox()
        Me.txtTelefonoEmp = New System.Windows.Forms.TextBox()
        Me.txtCP = New System.Windows.Forms.TextBox()
        Me.txtCalleEmp = New System.Windows.Forms.TextBox()
        Me.txtColoniaEmp = New System.Windows.Forms.TextBox()
        Me.txtMunicipioEmp = New System.Windows.Forms.TextBox()
        Me.lblCURP = New System.Windows.Forms.Label()
        Me.txtCURP = New System.Windows.Forms.TextBox()
        Me.lblRFC = New System.Windows.Forms.Label()
        Me.txtRFC = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblMunicipioEmp = New System.Windows.Forms.Label()
        Me.lblCalleEmp = New System.Windows.Forms.Label()
        Me.lblColoniaEmp = New System.Windows.Forms.Label()
        Me.lblFax = New System.Windows.Forms.Label()
        Me.lblTelefonoEmp = New System.Windows.Forms.Label()
        Me.lblCP = New System.Windows.Forms.Label()
        Me.tabHistorico = New System.Windows.Forms.TabPage()
        Me.grdHistorico = New System.Windows.Forms.DataGrid()
        Me.tsHistorico = New System.Windows.Forms.DataGridTableStyle()
        Me.gcHNoDescuento = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.gcHDescuento = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.gcHTipo = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.gcHFInicial = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.gcHFFinal = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.gcStatus = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.imgDescuentos = New System.Windows.Forms.ImageList(Me.components)
        Me.sptDescuentos = New System.Windows.Forms.Splitter()
        Me.grdDescuentos = New System.Windows.Forms.DataGrid()
        Me.tsDescuentos = New System.Windows.Forms.DataGridTableStyle()
        Me.gcContrato = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.gcCliente = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.gcClientePadre = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.gcCelula = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.gcNoDescuento = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.gcDescuento = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.gcTipo = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.gcFInicial = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.gcFFinal = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.tbDescuentos = New System.Windows.Forms.ToolBar()
        Me.btnFiltro = New System.Windows.Forms.ToolBarButton()
        Me.btnBuscar = New System.Windows.Forms.ToolBarButton()
        Me.Sep1 = New System.Windows.Forms.ToolBarButton()
        Me.btnActualizar = New System.Windows.Forms.ToolBarButton()
        Me.Sep2 = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.mnuDescuentos = New System.Windows.Forms.MainMenu()
        Me.mniDescuentos = New System.Windows.Forms.MenuItem()
        Me.mniCatDescuentos = New System.Windows.Forms.MenuItem()
        Me.mniBuscar = New System.Windows.Forms.MenuItem()
        Me.Sepm0 = New System.Windows.Forms.MenuItem()
        Me.mniActualizar = New System.Windows.Forms.MenuItem()
        Me.Sepm1 = New System.Windows.Forms.MenuItem()
        Me.mniCerrar = New System.Windows.Forms.MenuItem()
        Me.mnuFiltro = New System.Windows.Forms.ContextMenu()
        Me.tabDetalles.SuspendLayout()
        Me.tabCliente.SuspendLayout()
        Me.tabEmpresa.SuspendLayout()
        Me.tabHistorico.SuspendLayout()
        CType(Me.grdHistorico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDescuentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabDetalles
        '
        Me.tabDetalles.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tabDetalles.Controls.AddRange(New System.Windows.Forms.Control() {Me.tabCliente, Me.tabEmpresa, Me.tabHistorico})
        Me.tabDetalles.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tabDetalles.ImageList = Me.imgDescuentos
        Me.tabDetalles.Location = New System.Drawing.Point(0, 453)
        Me.tabDetalles.Name = "tabDetalles"
        Me.tabDetalles.SelectedIndex = 0
        Me.tabDetalles.ShowToolTips = True
        Me.tabDetalles.Size = New System.Drawing.Size(792, 120)
        Me.tabDetalles.TabIndex = 0
        '
        'tabCliente
        '
        Me.tabCliente.BackColor = System.Drawing.Color.Gainsboro
        Me.tabCliente.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtNumInterior, Me.lblRuta, Me.txtConsumo, Me.lblNumInterior, Me.lblConsumo, Me.txtRuta, Me.txtMunicipio, Me.lblMunicipio, Me.lblColonia, Me.lblCalle, Me.txtColonia, Me.txtCalle, Me.txtNumExterior, Me.lblTelefono, Me.txtRamo, Me.lblNumExterior, Me.lblRamo, Me.txtTelefono})
        Me.tabCliente.ImageIndex = 0
        Me.tabCliente.Location = New System.Drawing.Point(4, 26)
        Me.tabCliente.Name = "tabCliente"
        Me.tabCliente.Size = New System.Drawing.Size(784, 90)
        Me.tabCliente.TabIndex = 0
        Me.tabCliente.Text = "Datos generales"
        Me.tabCliente.ToolTipText = "Datos generales del cliente"
        '
        'txtNumInterior
        '
        Me.txtNumInterior.BackColor = System.Drawing.Color.White
        Me.txtNumInterior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumInterior.ForeColor = System.Drawing.Color.Black
        Me.txtNumInterior.Location = New System.Drawing.Point(641, 10)
        Me.txtNumInterior.Name = "txtNumInterior"
        Me.txtNumInterior.ReadOnly = True
        Me.txtNumInterior.Size = New System.Drawing.Size(97, 21)
        Me.txtNumInterior.TabIndex = 6
        Me.txtNumInterior.TabStop = False
        Me.txtNumInterior.Text = ""
        '
        'lblRuta
        '
        Me.lblRuta.AutoSize = True
        Me.lblRuta.ForeColor = System.Drawing.Color.Black
        Me.lblRuta.Location = New System.Drawing.Point(536, 40)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(31, 14)
        Me.lblRuta.TabIndex = 4
        Me.lblRuta.Text = "Ruta:"
        '
        'txtConsumo
        '
        Me.txtConsumo.BackColor = System.Drawing.Color.White
        Me.txtConsumo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConsumo.ForeColor = System.Drawing.Color.Black
        Me.txtConsumo.Location = New System.Drawing.Point(641, 64)
        Me.txtConsumo.Name = "txtConsumo"
        Me.txtConsumo.ReadOnly = True
        Me.txtConsumo.Size = New System.Drawing.Size(97, 21)
        Me.txtConsumo.TabIndex = 7
        Me.txtConsumo.TabStop = False
        Me.txtConsumo.Text = ""
        '
        'lblNumInterior
        '
        Me.lblNumInterior.AutoSize = True
        Me.lblNumInterior.ForeColor = System.Drawing.Color.Black
        Me.lblNumInterior.Location = New System.Drawing.Point(536, 13)
        Me.lblNumInterior.Name = "lblNumInterior"
        Me.lblNumInterior.Size = New System.Drawing.Size(74, 14)
        Me.lblNumInterior.TabIndex = 3
        Me.lblNumInterior.Text = "Num. interior:"
        '
        'lblConsumo
        '
        Me.lblConsumo.AutoSize = True
        Me.lblConsumo.ForeColor = System.Drawing.Color.Black
        Me.lblConsumo.Location = New System.Drawing.Point(536, 67)
        Me.lblConsumo.Name = "lblConsumo"
        Me.lblConsumo.Size = New System.Drawing.Size(105, 14)
        Me.lblConsumo.TabIndex = 2
        Me.lblConsumo.Text = "Consumo promedio:"
        '
        'txtRuta
        '
        Me.txtRuta.BackColor = System.Drawing.Color.White
        Me.txtRuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRuta.ForeColor = System.Drawing.Color.Black
        Me.txtRuta.Location = New System.Drawing.Point(641, 37)
        Me.txtRuta.Name = "txtRuta"
        Me.txtRuta.ReadOnly = True
        Me.txtRuta.Size = New System.Drawing.Size(97, 21)
        Me.txtRuta.TabIndex = 5
        Me.txtRuta.TabStop = False
        Me.txtRuta.Text = ""
        '
        'txtMunicipio
        '
        Me.txtMunicipio.BackColor = System.Drawing.Color.White
        Me.txtMunicipio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMunicipio.ForeColor = System.Drawing.Color.Black
        Me.txtMunicipio.Location = New System.Drawing.Point(67, 10)
        Me.txtMunicipio.Name = "txtMunicipio"
        Me.txtMunicipio.ReadOnly = True
        Me.txtMunicipio.Size = New System.Drawing.Size(212, 21)
        Me.txtMunicipio.TabIndex = 1
        Me.txtMunicipio.TabStop = False
        Me.txtMunicipio.Text = ""
        '
        'lblMunicipio
        '
        Me.lblMunicipio.AutoSize = True
        Me.lblMunicipio.ForeColor = System.Drawing.Color.Black
        Me.lblMunicipio.Location = New System.Drawing.Point(11, 13)
        Me.lblMunicipio.Name = "lblMunicipio"
        Me.lblMunicipio.Size = New System.Drawing.Size(55, 14)
        Me.lblMunicipio.TabIndex = 0
        Me.lblMunicipio.Text = "Municipio:"
        '
        'lblColonia
        '
        Me.lblColonia.AutoSize = True
        Me.lblColonia.ForeColor = System.Drawing.Color.Black
        Me.lblColonia.Location = New System.Drawing.Point(11, 40)
        Me.lblColonia.Name = "lblColonia"
        Me.lblColonia.Size = New System.Drawing.Size(45, 14)
        Me.lblColonia.TabIndex = 0
        Me.lblColonia.Text = "Colonia:"
        '
        'lblCalle
        '
        Me.lblCalle.AutoSize = True
        Me.lblCalle.ForeColor = System.Drawing.Color.Black
        Me.lblCalle.Location = New System.Drawing.Point(11, 67)
        Me.lblCalle.Name = "lblCalle"
        Me.lblCalle.Size = New System.Drawing.Size(32, 14)
        Me.lblCalle.TabIndex = 0
        Me.lblCalle.Text = "Calle:"
        '
        'txtColonia
        '
        Me.txtColonia.BackColor = System.Drawing.Color.White
        Me.txtColonia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtColonia.ForeColor = System.Drawing.Color.Black
        Me.txtColonia.Location = New System.Drawing.Point(67, 37)
        Me.txtColonia.Name = "txtColonia"
        Me.txtColonia.ReadOnly = True
        Me.txtColonia.Size = New System.Drawing.Size(212, 21)
        Me.txtColonia.TabIndex = 1
        Me.txtColonia.TabStop = False
        Me.txtColonia.Text = ""
        '
        'txtCalle
        '
        Me.txtCalle.BackColor = System.Drawing.Color.White
        Me.txtCalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCalle.ForeColor = System.Drawing.Color.Black
        Me.txtCalle.Location = New System.Drawing.Point(67, 64)
        Me.txtCalle.Name = "txtCalle"
        Me.txtCalle.ReadOnly = True
        Me.txtCalle.Size = New System.Drawing.Size(212, 21)
        Me.txtCalle.TabIndex = 1
        Me.txtCalle.TabStop = False
        Me.txtCalle.Text = ""
        '
        'txtNumExterior
        '
        Me.txtNumExterior.BackColor = System.Drawing.Color.White
        Me.txtNumExterior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumExterior.ForeColor = System.Drawing.Color.Black
        Me.txtNumExterior.Location = New System.Drawing.Point(391, 10)
        Me.txtNumExterior.Name = "txtNumExterior"
        Me.txtNumExterior.ReadOnly = True
        Me.txtNumExterior.Size = New System.Drawing.Size(97, 21)
        Me.txtNumExterior.TabIndex = 1
        Me.txtNumExterior.TabStop = False
        Me.txtNumExterior.Text = ""
        '
        'lblTelefono
        '
        Me.lblTelefono.AutoSize = True
        Me.lblTelefono.ForeColor = System.Drawing.Color.Black
        Me.lblTelefono.Location = New System.Drawing.Point(316, 40)
        Me.lblTelefono.Name = "lblTelefono"
        Me.lblTelefono.Size = New System.Drawing.Size(52, 14)
        Me.lblTelefono.TabIndex = 0
        Me.lblTelefono.Text = "Teléfono:"
        '
        'txtRamo
        '
        Me.txtRamo.BackColor = System.Drawing.Color.White
        Me.txtRamo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRamo.ForeColor = System.Drawing.Color.Black
        Me.txtRamo.Location = New System.Drawing.Point(391, 64)
        Me.txtRamo.Name = "txtRamo"
        Me.txtRamo.ReadOnly = True
        Me.txtRamo.Size = New System.Drawing.Size(97, 21)
        Me.txtRamo.TabIndex = 1
        Me.txtRamo.TabStop = False
        Me.txtRamo.Text = ""
        '
        'lblNumExterior
        '
        Me.lblNumExterior.AutoSize = True
        Me.lblNumExterior.ForeColor = System.Drawing.Color.Black
        Me.lblNumExterior.Location = New System.Drawing.Point(316, 13)
        Me.lblNumExterior.Name = "lblNumExterior"
        Me.lblNumExterior.Size = New System.Drawing.Size(77, 14)
        Me.lblNumExterior.TabIndex = 0
        Me.lblNumExterior.Text = "Num. exterior:"
        '
        'lblRamo
        '
        Me.lblRamo.AutoSize = True
        Me.lblRamo.ForeColor = System.Drawing.Color.Black
        Me.lblRamo.Location = New System.Drawing.Point(316, 67)
        Me.lblRamo.Name = "lblRamo"
        Me.lblRamo.Size = New System.Drawing.Size(37, 14)
        Me.lblRamo.TabIndex = 0
        Me.lblRamo.Text = "Ramo:"
        '
        'txtTelefono
        '
        Me.txtTelefono.BackColor = System.Drawing.Color.White
        Me.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTelefono.ForeColor = System.Drawing.Color.Black
        Me.txtTelefono.Location = New System.Drawing.Point(391, 37)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.ReadOnly = True
        Me.txtTelefono.Size = New System.Drawing.Size(97, 21)
        Me.txtTelefono.TabIndex = 1
        Me.txtTelefono.TabStop = False
        Me.txtTelefono.Text = ""
        '
        'tabEmpresa
        '
        Me.tabEmpresa.BackColor = System.Drawing.Color.Gainsboro
        Me.tabEmpresa.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtFax, Me.txtTelefonoEmp, Me.txtCP, Me.txtCalleEmp, Me.txtColoniaEmp, Me.txtMunicipioEmp, Me.lblCURP, Me.txtCURP, Me.lblRFC, Me.txtRFC, Me.lblNombre, Me.txtNombre, Me.lblMunicipioEmp, Me.lblCalleEmp, Me.lblColoniaEmp, Me.lblFax, Me.lblTelefonoEmp, Me.lblCP})
        Me.tabEmpresa.ImageIndex = 1
        Me.tabEmpresa.Location = New System.Drawing.Point(4, 26)
        Me.tabEmpresa.Name = "tabEmpresa"
        Me.tabEmpresa.Size = New System.Drawing.Size(784, 90)
        Me.tabEmpresa.TabIndex = 1
        Me.tabEmpresa.Text = "Empresa"
        Me.tabEmpresa.ToolTipText = "Datos de la empresa"
        '
        'txtFax
        '
        Me.txtFax.BackColor = System.Drawing.Color.White
        Me.txtFax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFax.ForeColor = System.Drawing.Color.Black
        Me.txtFax.Location = New System.Drawing.Point(656, 60)
        Me.txtFax.Name = "txtFax"
        Me.txtFax.ReadOnly = True
        Me.txtFax.Size = New System.Drawing.Size(120, 21)
        Me.txtFax.TabIndex = 38
        Me.txtFax.Text = ""
        '
        'txtTelefonoEmp
        '
        Me.txtTelefonoEmp.BackColor = System.Drawing.Color.White
        Me.txtTelefonoEmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTelefonoEmp.ForeColor = System.Drawing.Color.Black
        Me.txtTelefonoEmp.Location = New System.Drawing.Point(656, 34)
        Me.txtTelefonoEmp.Name = "txtTelefonoEmp"
        Me.txtTelefonoEmp.ReadOnly = True
        Me.txtTelefonoEmp.Size = New System.Drawing.Size(120, 21)
        Me.txtTelefonoEmp.TabIndex = 36
        Me.txtTelefonoEmp.Text = ""
        '
        'txtCP
        '
        Me.txtCP.BackColor = System.Drawing.Color.White
        Me.txtCP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCP.ForeColor = System.Drawing.Color.Black
        Me.txtCP.Location = New System.Drawing.Point(656, 8)
        Me.txtCP.Name = "txtCP"
        Me.txtCP.ReadOnly = True
        Me.txtCP.Size = New System.Drawing.Size(120, 21)
        Me.txtCP.TabIndex = 34
        Me.txtCP.Text = ""
        '
        'txtCalleEmp
        '
        Me.txtCalleEmp.BackColor = System.Drawing.Color.White
        Me.txtCalleEmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCalleEmp.ForeColor = System.Drawing.Color.Black
        Me.txtCalleEmp.Location = New System.Drawing.Point(352, 60)
        Me.txtCalleEmp.Name = "txtCalleEmp"
        Me.txtCalleEmp.ReadOnly = True
        Me.txtCalleEmp.Size = New System.Drawing.Size(212, 21)
        Me.txtCalleEmp.TabIndex = 32
        Me.txtCalleEmp.Text = ""
        '
        'txtColoniaEmp
        '
        Me.txtColoniaEmp.BackColor = System.Drawing.Color.White
        Me.txtColoniaEmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtColoniaEmp.ForeColor = System.Drawing.Color.Black
        Me.txtColoniaEmp.Location = New System.Drawing.Point(352, 34)
        Me.txtColoniaEmp.Name = "txtColoniaEmp"
        Me.txtColoniaEmp.ReadOnly = True
        Me.txtColoniaEmp.Size = New System.Drawing.Size(212, 21)
        Me.txtColoniaEmp.TabIndex = 30
        Me.txtColoniaEmp.Text = ""
        '
        'txtMunicipioEmp
        '
        Me.txtMunicipioEmp.BackColor = System.Drawing.Color.White
        Me.txtMunicipioEmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMunicipioEmp.ForeColor = System.Drawing.Color.Black
        Me.txtMunicipioEmp.Location = New System.Drawing.Point(352, 8)
        Me.txtMunicipioEmp.Name = "txtMunicipioEmp"
        Me.txtMunicipioEmp.ReadOnly = True
        Me.txtMunicipioEmp.Size = New System.Drawing.Size(212, 21)
        Me.txtMunicipioEmp.TabIndex = 28
        Me.txtMunicipioEmp.Text = ""
        '
        'lblCURP
        '
        Me.lblCURP.AutoSize = True
        Me.lblCURP.ForeColor = System.Drawing.Color.Black
        Me.lblCURP.Location = New System.Drawing.Point(8, 63)
        Me.lblCURP.Name = "lblCURP"
        Me.lblCURP.Size = New System.Drawing.Size(36, 14)
        Me.lblCURP.TabIndex = 25
        Me.lblCURP.Text = "CURP:"
        '
        'txtCURP
        '
        Me.txtCURP.BackColor = System.Drawing.Color.White
        Me.txtCURP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCURP.ForeColor = System.Drawing.Color.Black
        Me.txtCURP.Location = New System.Drawing.Point(56, 60)
        Me.txtCURP.Name = "txtCURP"
        Me.txtCURP.ReadOnly = True
        Me.txtCURP.Size = New System.Drawing.Size(136, 21)
        Me.txtCURP.TabIndex = 26
        Me.txtCURP.Text = ""
        '
        'lblRFC
        '
        Me.lblRFC.AutoSize = True
        Me.lblRFC.ForeColor = System.Drawing.Color.Black
        Me.lblRFC.Location = New System.Drawing.Point(8, 37)
        Me.lblRFC.Name = "lblRFC"
        Me.lblRFC.Size = New System.Drawing.Size(28, 14)
        Me.lblRFC.TabIndex = 23
        Me.lblRFC.Text = "RFC:"
        '
        'txtRFC
        '
        Me.txtRFC.BackColor = System.Drawing.Color.White
        Me.txtRFC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRFC.ForeColor = System.Drawing.Color.Black
        Me.txtRFC.Location = New System.Drawing.Point(56, 34)
        Me.txtRFC.Name = "txtRFC"
        Me.txtRFC.ReadOnly = True
        Me.txtRFC.Size = New System.Drawing.Size(136, 21)
        Me.txtRFC.TabIndex = 24
        Me.txtRFC.Text = ""
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.ForeColor = System.Drawing.Color.Black
        Me.lblNombre.Location = New System.Drawing.Point(8, 11)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(48, 14)
        Me.lblNombre.TabIndex = 21
        Me.lblNombre.Text = "Nombre:"
        '
        'txtNombre
        '
        Me.txtNombre.BackColor = System.Drawing.Color.White
        Me.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNombre.ForeColor = System.Drawing.Color.Black
        Me.txtNombre.Location = New System.Drawing.Point(56, 8)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(208, 21)
        Me.txtNombre.TabIndex = 22
        Me.txtNombre.Text = ""
        '
        'lblMunicipioEmp
        '
        Me.lblMunicipioEmp.AutoSize = True
        Me.lblMunicipioEmp.BackColor = System.Drawing.Color.Transparent
        Me.lblMunicipioEmp.ForeColor = System.Drawing.Color.Black
        Me.lblMunicipioEmp.Location = New System.Drawing.Point(297, 11)
        Me.lblMunicipioEmp.Name = "lblMunicipioEmp"
        Me.lblMunicipioEmp.Size = New System.Drawing.Size(55, 14)
        Me.lblMunicipioEmp.TabIndex = 27
        Me.lblMunicipioEmp.Text = "Municipio:"
        '
        'lblCalleEmp
        '
        Me.lblCalleEmp.AutoSize = True
        Me.lblCalleEmp.ForeColor = System.Drawing.Color.Black
        Me.lblCalleEmp.Location = New System.Drawing.Point(297, 63)
        Me.lblCalleEmp.Name = "lblCalleEmp"
        Me.lblCalleEmp.Size = New System.Drawing.Size(32, 14)
        Me.lblCalleEmp.TabIndex = 31
        Me.lblCalleEmp.Text = "Calle:"
        '
        'lblColoniaEmp
        '
        Me.lblColoniaEmp.AutoSize = True
        Me.lblColoniaEmp.ForeColor = System.Drawing.Color.Black
        Me.lblColoniaEmp.Location = New System.Drawing.Point(297, 37)
        Me.lblColoniaEmp.Name = "lblColoniaEmp"
        Me.lblColoniaEmp.Size = New System.Drawing.Size(45, 14)
        Me.lblColoniaEmp.TabIndex = 29
        Me.lblColoniaEmp.Text = "Colonia:"
        '
        'lblFax
        '
        Me.lblFax.AutoSize = True
        Me.lblFax.ForeColor = System.Drawing.Color.Black
        Me.lblFax.Location = New System.Drawing.Point(600, 63)
        Me.lblFax.Name = "lblFax"
        Me.lblFax.Size = New System.Drawing.Size(26, 14)
        Me.lblFax.TabIndex = 37
        Me.lblFax.Text = "Fax:"
        '
        'lblTelefonoEmp
        '
        Me.lblTelefonoEmp.AutoSize = True
        Me.lblTelefonoEmp.ForeColor = System.Drawing.Color.Black
        Me.lblTelefonoEmp.Location = New System.Drawing.Point(600, 37)
        Me.lblTelefonoEmp.Name = "lblTelefonoEmp"
        Me.lblTelefonoEmp.Size = New System.Drawing.Size(52, 14)
        Me.lblTelefonoEmp.TabIndex = 35
        Me.lblTelefonoEmp.Text = "Teléfono:"
        '
        'lblCP
        '
        Me.lblCP.AutoSize = True
        Me.lblCP.ForeColor = System.Drawing.Color.Black
        Me.lblCP.Location = New System.Drawing.Point(600, 11)
        Me.lblCP.Name = "lblCP"
        Me.lblCP.Size = New System.Drawing.Size(21, 14)
        Me.lblCP.TabIndex = 33
        Me.lblCP.Text = "CP:"
        '
        'tabHistorico
        '
        Me.tabHistorico.BackColor = System.Drawing.Color.Gainsboro
        Me.tabHistorico.Controls.AddRange(New System.Windows.Forms.Control() {Me.grdHistorico})
        Me.tabHistorico.ImageIndex = 2
        Me.tabHistorico.Location = New System.Drawing.Point(4, 26)
        Me.tabHistorico.Name = "tabHistorico"
        Me.tabHistorico.Size = New System.Drawing.Size(784, 90)
        Me.tabHistorico.TabIndex = 2
        Me.tabHistorico.Text = "Histórico"
        Me.tabHistorico.ToolTipText = "Histórico de descuentos"
        '
        'grdHistorico
        '
        Me.grdHistorico.AlternatingBackColor = System.Drawing.Color.Gainsboro
        Me.grdHistorico.BackColor = System.Drawing.Color.Silver
        Me.grdHistorico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.grdHistorico.CaptionBackColor = System.Drawing.Color.DarkSlateBlue
        Me.grdHistorico.CaptionFont = New System.Drawing.Font("Tahoma", 8.0!)
        Me.grdHistorico.CaptionForeColor = System.Drawing.Color.White
        Me.grdHistorico.DataMember = ""
        Me.grdHistorico.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdHistorico.FlatMode = True
        Me.grdHistorico.ForeColor = System.Drawing.Color.Black
        Me.grdHistorico.GridLineColor = System.Drawing.Color.White
        Me.grdHistorico.HeaderBackColor = System.Drawing.Color.DarkGray
        Me.grdHistorico.HeaderForeColor = System.Drawing.Color.Black
        Me.grdHistorico.LinkColor = System.Drawing.Color.DarkSlateBlue
        Me.grdHistorico.Name = "grdHistorico"
        Me.grdHistorico.ParentRowsBackColor = System.Drawing.Color.Black
        Me.grdHistorico.ParentRowsForeColor = System.Drawing.Color.White
        Me.grdHistorico.ReadOnly = True
        Me.grdHistorico.RowHeaderWidth = 5
        Me.grdHistorico.SelectionBackColor = System.Drawing.Color.DarkSlateBlue
        Me.grdHistorico.SelectionForeColor = System.Drawing.Color.White
        Me.grdHistorico.Size = New System.Drawing.Size(784, 90)
        Me.grdHistorico.TabIndex = 0
        Me.grdHistorico.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.tsHistorico})
        '
        'tsHistorico
        '
        Me.tsHistorico.AlternatingBackColor = System.Drawing.Color.Gainsboro
        Me.tsHistorico.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tsHistorico.DataGrid = Me.grdHistorico
        Me.tsHistorico.ForeColor = System.Drawing.Color.Black
        Me.tsHistorico.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.gcHNoDescuento, Me.gcHDescuento, Me.gcHTipo, Me.gcHFInicial, Me.gcHFFinal, Me.gcStatus})
        Me.tsHistorico.GridLineColor = System.Drawing.Color.White
        Me.tsHistorico.HeaderBackColor = System.Drawing.Color.DarkGray
        Me.tsHistorico.HeaderForeColor = System.Drawing.Color.Black
        Me.tsHistorico.MappingName = ""
        Me.tsHistorico.SelectionBackColor = System.Drawing.Color.DarkSlateBlue
        Me.tsHistorico.SelectionForeColor = System.Drawing.Color.White
        '
        'gcHNoDescuento
        '
        Me.gcHNoDescuento.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.gcHNoDescuento.Format = ""
        Me.gcHNoDescuento.FormatInfo = Nothing
        Me.gcHNoDescuento.HeaderText = "No. de descuento"
        Me.gcHNoDescuento.MappingName = "NoDescuento"
        Me.gcHNoDescuento.Width = 75
        '
        'gcHDescuento
        '
        Me.gcHDescuento.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.gcHDescuento.Format = ""
        Me.gcHDescuento.FormatInfo = Nothing
        Me.gcHDescuento.HeaderText = "Descuento"
        Me.gcHDescuento.MappingName = "Descuento"
        Me.gcHDescuento.Width = 75
        '
        'gcHTipo
        '
        Me.gcHTipo.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.gcHTipo.Format = ""
        Me.gcHTipo.FormatInfo = Nothing
        Me.gcHTipo.HeaderText = "Tipo"
        Me.gcHTipo.MappingName = "Tipo"
        Me.gcHTipo.Width = 75
        '
        'gcHFInicial
        '
        Me.gcHFInicial.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.gcHFInicial.Format = ""
        Me.gcHFInicial.FormatInfo = Nothing
        Me.gcHFInicial.HeaderText = "Fecha de incio"
        Me.gcHFInicial.MappingName = "FInicial"
        Me.gcHFInicial.Width = 75
        '
        'gcHFFinal
        '
        Me.gcHFFinal.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.gcHFFinal.Format = ""
        Me.gcHFFinal.FormatInfo = Nothing
        Me.gcHFFinal.HeaderText = "Fecha de fin"
        Me.gcHFFinal.MappingName = "FFinal"
        Me.gcHFFinal.Width = 75
        '
        'gcStatus
        '
        Me.gcStatus.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.gcStatus.Format = ""
        Me.gcStatus.FormatInfo = Nothing
        Me.gcStatus.HeaderText = "Status"
        Me.gcStatus.MappingName = "Status"
        Me.gcStatus.Width = 75
        '
        'imgDescuentos
        '
        Me.imgDescuentos.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgDescuentos.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgDescuentos.ImageStream = CType(resources.GetObject("imgDescuentos.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgDescuentos.TransparentColor = System.Drawing.Color.Transparent
        '
        'sptDescuentos
        '
        Me.sptDescuentos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.sptDescuentos.Location = New System.Drawing.Point(0, 450)
        Me.sptDescuentos.Name = "sptDescuentos"
        Me.sptDescuentos.Size = New System.Drawing.Size(792, 3)
        Me.sptDescuentos.TabIndex = 1
        Me.sptDescuentos.TabStop = False
        '
        'grdDescuentos
        '
        Me.grdDescuentos.AlternatingBackColor = System.Drawing.Color.Gainsboro
        Me.grdDescuentos.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdDescuentos.BackgroundColor = System.Drawing.Color.Silver
        Me.grdDescuentos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grdDescuentos.CaptionBackColor = System.Drawing.Color.SteelBlue
        Me.grdDescuentos.CaptionForeColor = System.Drawing.Color.AliceBlue
        Me.grdDescuentos.DataMember = ""
        Me.grdDescuentos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDescuentos.FlatMode = True
        Me.grdDescuentos.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.grdDescuentos.ForeColor = System.Drawing.Color.Black
        Me.grdDescuentos.GridLineColor = System.Drawing.Color.DimGray
        Me.grdDescuentos.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None
        Me.grdDescuentos.HeaderBackColor = System.Drawing.Color.MidnightBlue
        Me.grdDescuentos.HeaderFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.grdDescuentos.HeaderForeColor = System.Drawing.Color.White
        Me.grdDescuentos.LinkColor = System.Drawing.Color.MidnightBlue
        Me.grdDescuentos.Location = New System.Drawing.Point(0, 39)
        Me.grdDescuentos.Name = "grdDescuentos"
        Me.grdDescuentos.ParentRowsBackColor = System.Drawing.Color.DarkGray
        Me.grdDescuentos.ParentRowsForeColor = System.Drawing.Color.Black
        Me.grdDescuentos.ReadOnly = True
        Me.grdDescuentos.RowHeaderWidth = 5
        Me.grdDescuentos.SelectionBackColor = System.Drawing.Color.CadetBlue
        Me.grdDescuentos.SelectionForeColor = System.Drawing.Color.White
        Me.grdDescuentos.Size = New System.Drawing.Size(792, 411)
        Me.grdDescuentos.TabIndex = 3
        Me.grdDescuentos.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.tsDescuentos})
        '
        'tsDescuentos
        '
        Me.tsDescuentos.AlternatingBackColor = System.Drawing.Color.Gainsboro
        Me.tsDescuentos.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tsDescuentos.DataGrid = Me.grdDescuentos
        Me.tsDescuentos.ForeColor = System.Drawing.Color.Black
        Me.tsDescuentos.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.gcContrato, Me.gcCliente, Me.gcClientePadre, Me.gcCelula, Me.gcNoDescuento, Me.gcDescuento, Me.gcTipo, Me.gcFInicial, Me.gcFFinal})
        Me.tsDescuentos.GridLineColor = System.Drawing.Color.DimGray
        Me.tsDescuentos.HeaderBackColor = System.Drawing.Color.MidnightBlue
        Me.tsDescuentos.HeaderForeColor = System.Drawing.Color.White
        Me.tsDescuentos.MappingName = ""
        Me.tsDescuentos.SelectionBackColor = System.Drawing.Color.CadetBlue
        Me.tsDescuentos.SelectionForeColor = System.Drawing.Color.White
        '
        'gcContrato
        '
        Me.gcContrato.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.gcContrato.Format = ""
        Me.gcContrato.FormatInfo = Nothing
        Me.gcContrato.HeaderText = "Contrato"
        Me.gcContrato.MappingName = "Contrato"
        Me.gcContrato.Width = 75
        '
        'gcCliente
        '
        Me.gcCliente.Format = ""
        Me.gcCliente.FormatInfo = Nothing
        Me.gcCliente.HeaderText = "Cliente"
        Me.gcCliente.MappingName = "Cliente"
        Me.gcCliente.Width = 75
        '
        'gcClientePadre
        '
        Me.gcClientePadre.Format = ""
        Me.gcClientePadre.FormatInfo = Nothing
        Me.gcClientePadre.HeaderText = "Cliente padre"
        Me.gcClientePadre.MappingName = "ClientePadre"
        Me.gcClientePadre.Width = 75
        '
        'gcCelula
        '
        Me.gcCelula.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.gcCelula.Format = ""
        Me.gcCelula.FormatInfo = Nothing
        Me.gcCelula.HeaderText = "Célula"
        Me.gcCelula.MappingName = "Celula"
        Me.gcCelula.Width = 75
        '
        'gcNoDescuento
        '
        Me.gcNoDescuento.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.gcNoDescuento.Format = ""
        Me.gcNoDescuento.FormatInfo = Nothing
        Me.gcNoDescuento.HeaderText = "No. de descuento"
        Me.gcNoDescuento.MappingName = "NoDescuento"
        Me.gcNoDescuento.Width = 75
        '
        'gcDescuento
        '
        Me.gcDescuento.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.gcDescuento.Format = ""
        Me.gcDescuento.FormatInfo = Nothing
        Me.gcDescuento.HeaderText = "Descuento"
        Me.gcDescuento.MappingName = "Descuento"
        Me.gcDescuento.Width = 75
        '
        'gcTipo
        '
        Me.gcTipo.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.gcTipo.Format = ""
        Me.gcTipo.FormatInfo = Nothing
        Me.gcTipo.HeaderText = "Tipo"
        Me.gcTipo.MappingName = "Tipo"
        Me.gcTipo.Width = 75
        '
        'gcFInicial
        '
        Me.gcFInicial.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.gcFInicial.Format = ""
        Me.gcFInicial.FormatInfo = Nothing
        Me.gcFInicial.HeaderText = "Fecha de inicio"
        Me.gcFInicial.MappingName = "FInicial"
        Me.gcFInicial.Width = 75
        '
        'gcFFinal
        '
        Me.gcFFinal.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.gcFFinal.Format = ""
        Me.gcFFinal.FormatInfo = Nothing
        Me.gcFFinal.HeaderText = "Fecha de fin"
        Me.gcFFinal.MappingName = "FFinal"
        Me.gcFFinal.Width = 75
        '
        'tbDescuentos
        '
        Me.tbDescuentos.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbDescuentos.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnFiltro, Me.btnBuscar, Me.Sep1, Me.btnActualizar, Me.Sep2, Me.btnCerrar})
        Me.tbDescuentos.DropDownArrows = True
        Me.tbDescuentos.ImageList = Me.imgDescuentos
        Me.tbDescuentos.Name = "tbDescuentos"
        Me.tbDescuentos.ShowToolTips = True
        Me.tbDescuentos.Size = New System.Drawing.Size(792, 39)
        Me.tbDescuentos.TabIndex = 4
        '
        'btnFiltro
        '
        Me.btnFiltro.DropDownMenu = Me.mnuFiltro
        Me.btnFiltro.ImageIndex = 7
        Me.btnFiltro.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
        Me.btnFiltro.Text = "Filtro"
        Me.btnFiltro.ToolTipText = "Filtrar los descuentos"
        '
        'btnBuscar
        '
        Me.btnBuscar.ImageIndex = 8
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.ToolTipText = "Buscar cliente"
        '
        'Sep1
        '
        Me.Sep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnActualizar
        '
        Me.btnActualizar.ImageIndex = 9
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.ToolTipText = "Cargar la información más reciente"
        '
        'Sep2
        '
        Me.Sep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnCerrar
        '
        Me.btnCerrar.ImageIndex = 10
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.ToolTipText = "Cerrar la pantalla de descuentos"
        '
        'mnuDescuentos
        '
        Me.mnuDescuentos.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniDescuentos})
        '
        'mniDescuentos
        '
        Me.mniDescuentos.Index = 0
        Me.mniDescuentos.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniCatDescuentos})
        Me.mniDescuentos.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniDescuentos.Text = "&Descuentos"
        '
        'mniCatDescuentos
        '
        Me.mniCatDescuentos.Index = 0
        Me.mniCatDescuentos.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniBuscar, Me.Sepm0, Me.mniActualizar, Me.Sepm1, Me.mniCerrar})
        Me.mniCatDescuentos.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniCatDescuentos.Text = "&Descuentos"
        '
        'mniBuscar
        '
        Me.mniBuscar.Index = 0
        Me.mniBuscar.Shortcut = System.Windows.Forms.Shortcut.CtrlB
        Me.mniBuscar.Text = "&Buscar"
        '
        'Sepm0
        '
        Me.Sepm0.Index = 1
        Me.Sepm0.Text = "-"
        '
        'mniActualizar
        '
        Me.mniActualizar.Index = 2
        Me.mniActualizar.Shortcut = System.Windows.Forms.Shortcut.F5
        Me.mniActualizar.Text = "&Actualizar"
        '
        'Sepm1
        '
        Me.Sepm1.Index = 3
        Me.Sepm1.Text = "-"
        '
        'mniCerrar
        '
        Me.mniCerrar.Index = 4
        Me.mniCerrar.Text = "Cerrar"
        '
        'frmDescuentos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(792, 573)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grdDescuentos, Me.tbDescuentos, Me.sptDescuentos, Me.tabDetalles})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.mnuDescuentos
        Me.Name = "frmDescuentos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Descuentos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tabDetalles.ResumeLayout(False)
        Me.tabCliente.ResumeLayout(False)
        Me.tabEmpresa.ResumeLayout(False)
        Me.tabHistorico.ResumeLayout(False)
        CType(Me.grdHistorico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDescuentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables globales"
    Private cnSigamet As SqlConnection
    Private dtDescuentos As New DataTable()
    Private dtHistorico As New DataTable()
    Private dtCelula As New DataTable()
    Private dtTipo As New DataTable()
    Private FiltroTipo, FiltroCelula As String
    Private AuxFiltro As Integer
#End Region
#Region "Rutinas de actualización"
    Private Sub Actualizar()
        Dim cmdDescuentos As New SqlCommand("Select * from vwDESDescuentos where Status = 'ACTIVO'", cnSigamet)
        Dim daDescuentos As New SqlDataAdapter(cmdDescuentos)
        Dim Key(0) As DataColumn
        Me.Cursor = Cursors.WaitCursor
        dtDescuentos.Clear()
        dtHistorico.Clear()
        Try
            daDescuentos.Fill(dtDescuentos)

            cmdDescuentos.CommandText = "Select * from vwDESHistoricoDescuentos"
            daDescuentos.Fill(dtHistorico)

            Key(0) = dtDescuentos.Columns("Contrato")
            dtDescuentos.PrimaryKey = Key
        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        GridData(grdDescuentos, dtDescuentos, 0, 9)
        grdDescuentos.DataSource = dtDescuentos
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub CargaDetalles()
        If grdDescuentos.CurrentRowIndex > -1 Then
            Dim FoundRow As DataRow = dtDescuentos.Rows.Find(grdDescuentos.Item(grdDescuentos.CurrentCell.RowNumber, 0))
            If Not FoundRow Is Nothing Then
                txtMunicipio.Text = CStr(FoundRow("Municipio")).Trim
                txtColonia.Text = CStr(FoundRow("Colonia")).Trim
                txtCalle.Text = CStr(FoundRow("Calle")).Trim
                txtNumExterior.Text = CStr(FoundRow("NumExterior")).Trim
                txtTelefono.Text = CStr(FoundRow("Telefono")).Trim
                txtRamo.Text = CStr(FoundRow("Ramo")).Trim
                txtNumInterior.Text = CStr(FoundRow("NumInterior")).Trim
                txtRuta.Text = CStr(FoundRow("Ruta")).Trim
                txtConsumo.Text = CStr(FoundRow("ConsumoPromedio")).Trim

                txtNombre.Text = CStr(FoundRow("Empresa")).Trim
                txtRFC.Text = CStr(FoundRow("RFC")).Trim
                txtCURP.Text = CStr(FoundRow("CURP")).Trim
                txtMunicipioEmp.Text = CStr(FoundRow("EMunicipio")).Trim
                txtColoniaEmp.Text = CStr(FoundRow("EColonia")).Trim
                txtCalleEmp.Text = CStr(FoundRow("ECalle")).Trim
                txtCP.Text = CStr(FoundRow("ECP")).Trim
                txtTelefonoEmp.Text = CStr(FoundRow("ETelefono")).Trim
                txtFax.Text = CStr(FoundRow("Fax")).Trim

                grdHistorico.CaptionText = "Histórico del cliente " & CStr(FoundRow("Contrato")) & " " & CStr(FoundRow("Cliente"))
            End If
            dtHistorico.DefaultView.RowFilter = "Contrato = " & CStr(grdDescuentos.Item(grdDescuentos.CurrentCell.RowNumber, 0))
            GridData(grdHistorico, ViewToTable(dtHistorico.DefaultView), 0, 6)
        End If
    End Sub
#End Region
#Region "Manejo del grid principal"
    Private Sub grdDescuentos_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDescuentos.CurrentCellChanged
        On Error Resume Next
        grdDescuentos.Select(grdDescuentos.CurrentCell.RowNumber)
        CargaDetalles()
    End Sub
#End Region

#Region "Menus y barras de herramientas"
    Private Sub tbDescuentos_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbDescuentos.ButtonClick
        Select Case e.Button.Text
            Case "Buscar"
                Buscar()
            Case "Actualizar"
                Actualizar()
            Case "Cerrar"
                Me.Close()
                Me.Dispose()
        End Select
    End Sub
    Private Sub mniBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniBuscar.Click
        Buscar()
    End Sub
    Private Sub mniActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniActualizar.Click
        Actualizar()
    End Sub
    Private Sub mniCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub
#End Region
#Region "Rutinas especiales"
    Private Sub Buscar()
        Dim Cliente As String = InputBox("Cliente", Application.ProductName & " v." & Application.ProductVersion)
        EncuentraRegistro(grdDescuentos, Cliente, 0)
    End Sub
    'Asignación de datos a un grid
    Private Sub GridData(ByRef Grid As DataGrid, ByVal Table As DataTable, Optional ByVal TableStyleIndex As Integer = -1, Optional ByVal Columns As Integer = 0)
        If CInt(Grid.Width / Table.Columns.Count) - 10 > 0 Then
            If TableStyleIndex = -1 Then
                Grid.PreferredColumnWidth = CInt(Grid.Width / Table.Columns.Count) - 20 + Table.Columns.Count
            Else
                Grid.TableStyles(TableStyleIndex).MappingName = Table.TableName
                Dim Index As Byte
                If Columns = 0 Then
                    Columns = Table.Columns.Count - 1
                End If
                For Index = 0 To CByte(Columns - 1)
                    Grid.TableStyles(TableStyleIndex).GridColumnStyles(Index).Width = CInt(Grid.Width / Columns) - 20 + Columns
                Next Index
            End If
        End If
        Grid.DataSource = Table
    End Sub
    'Busqueda en grid
    Private Function EncuentraRegistro(ByRef Grid As DataGrid, ByVal Busqueda As String, Optional ByVal Columna As Integer = 0) As Boolean
        Dim Index As Integer
        For Index = 0 To CuentaFilas(Grid)
            If Not Microsoft.VisualBasic.IsDBNull(Grid.Item(Index, Columna)) Then
                If Trim(CStr(Grid.Item(Index, Columna))).ToUpper = Trim(Busqueda).ToUpper Then
                    Grid.UnSelect(Grid.CurrentRowIndex)
                    Grid.Select(Index)
                    Grid.CurrentRowIndex = Index
                    Return True
                End If
            End If
        Next
        Return False
    End Function
    'Propiedades de un grid
    Private Function CuentaFilas(ByVal Grid As DataGrid) As Integer
        Return CType(Grid.DataSource, DataTable).Rows.Count - 1
    End Function
    Private Function CuentaColumnas(ByVal Grid As DataGrid) As Integer
        Return CType(Grid.DataSource, DataTable).Columns.Count - 1
    End Function
    'Converción de DataView a DataTable
    Private Function ViewToTable(ByVal DataViewSource As DataView) As DataTable
        Dim dtSource As New DataTable()
        Dim RowIndex, ColumnIndex As Integer
        Dim IArray(DataViewSource.Table.Columns.Count - 1) As Object
        dtSource = DataViewSource.Table.Clone
        For RowIndex = 0 To DataViewSource.Count - 1
            For ColumnIndex = 0 To DataViewSource.Table.Columns.Count - 1
                IArray(ColumnIndex) = DataViewSource.Item(RowIndex)(ColumnIndex)
            Next
            dtSource.Rows.Add(IArray)
        Next
        Return dtSource
    End Function
#End Region


    Private Sub mniFiltroCelula_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim FoundRow As DataRow = dtCelula.Rows.Find(CType(sender, MenuItem).Text)
        Dim item As MenuItem
        For Each item In mnuFiltro.MenuItems
            If item.Index < AuxFiltro Then
                item.Checked = False
            End If
        Next
        CType(sender, MenuItem).Checked = True
        If Not FoundRow Is Nothing Then
            FiltroCelula = " and Celula = " & CStr(FoundRow("Celula")) & " "
        Else
            FiltroCelula = ""
        End If
        Actualizar()
    End Sub
    Private Sub mniFiltroTipo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim FoundRow As DataRow = dtTipo.Rows.Find(CType(sender, MenuItem).Text)
        Dim item As MenuItem
        For Each item In mnuFiltro.MenuItems
            If item.Index > AuxFiltro Then
                item.Checked = False
            End If
        Next
        CType(sender, MenuItem).Checked = True
        If Not FoundRow Is Nothing Then
            FiltroTipo = " and IDTipo = " & CStr(FoundRow("TipoDescuento")) & " "
        Else
            FiltroTipo = ""
        End If
        Actualizar()
    End Sub
End Class
