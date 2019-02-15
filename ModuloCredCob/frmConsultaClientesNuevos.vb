Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq

Public Class frmConsultaClientesNuevos
    Inherits System.Windows.Forms.Form
    Private _Cliente As Integer
    Private _URLGateway As String
    Private listaDireccionesEntrega As List(Of RTGMCore.DireccionEntrega)
    Private validarPeticion As Boolean
    Private listaClientesEnviados As List(Of Integer)
    Private dtCliente As DataTable

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

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
    Friend WithEvents btnConsultar As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnRefrescar As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents imgLista16 As System.Windows.Forms.ImageList
    Friend WithEvents grdCliente As System.Windows.Forms.DataGrid
    Friend WithEvents dtpFAlta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Estilo1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colCliente As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colNombre As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colDireccionCompleta As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFAlta As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colRuta As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCelula As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTelCasa As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTipoCreditoDescripcion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colStatus As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents grdTotales As System.Windows.Forms.DataGrid
    Friend WithEvents styResultado As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colREDescripcion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colRETotal As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents colSaldo As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents btnCerrar2 As System.Windows.Forms.Button
    Friend WithEvents colCargo As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents colDGestion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colDCobro As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmConsultaClientesNuevos))
        Me.grdCliente = New System.Windows.Forms.DataGrid()
        Me.Estilo1 = New System.Windows.Forms.DataGridTableStyle()
        Me.colCliente = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colNombre = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colDireccionCompleta = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTelCasa = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFAlta = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colRuta = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCelula = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTipoCreditoDescripcion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colStatus = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCargo = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colSaldo = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colDGestion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colDCobro = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.tbrBarra = New System.Windows.Forms.ToolBar()
        Me.btnConsultar = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton2 = New System.Windows.Forms.ToolBarButton()
        Me.btnRefrescar = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton1 = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.imgLista16 = New System.Windows.Forms.ImageList(Me.components)
        Me.dtpFAlta = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.grdTotales = New System.Windows.Forms.DataGrid()
        Me.styResultado = New System.Windows.Forms.DataGridTableStyle()
        Me.colREDescripcion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colRETotal = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnCerrar2 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        CType(Me.grdCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdTotales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdCliente
        '
        Me.grdCliente.AlternatingBackColor = System.Drawing.Color.Lavender
        Me.grdCliente.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdCliente.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdCliente.BackgroundColor = System.Drawing.Color.LightGray
        Me.grdCliente.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grdCliente.CaptionBackColor = System.Drawing.Color.White
        Me.grdCliente.CaptionFont = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdCliente.CaptionForeColor = System.Drawing.Color.Navy
        Me.grdCliente.DataMember = ""
        Me.grdCliente.FlatMode = True
        Me.grdCliente.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.grdCliente.ForeColor = System.Drawing.Color.MidnightBlue
        Me.grdCliente.GridLineColor = System.Drawing.Color.Gainsboro
        Me.grdCliente.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None
        Me.grdCliente.HeaderBackColor = System.Drawing.Color.MidnightBlue
        Me.grdCliente.HeaderFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.grdCliente.HeaderForeColor = System.Drawing.Color.WhiteSmoke
        Me.grdCliente.LinkColor = System.Drawing.Color.Teal
        Me.grdCliente.Location = New System.Drawing.Point(0, 40)
        Me.grdCliente.Name = "grdCliente"
        Me.grdCliente.ParentRowsBackColor = System.Drawing.Color.Gainsboro
        Me.grdCliente.ParentRowsForeColor = System.Drawing.Color.MidnightBlue
        Me.grdCliente.ReadOnly = True
        Me.grdCliente.SelectionBackColor = System.Drawing.Color.CadetBlue
        Me.grdCliente.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        Me.grdCliente.Size = New System.Drawing.Size(632, 280)
        Me.grdCliente.TabIndex = 0
        Me.grdCliente.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.Estilo1})
        '
        'Estilo1
        '
        Me.Estilo1.DataGrid = Me.grdCliente
        Me.Estilo1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colCliente, Me.colNombre, Me.colDireccionCompleta, Me.colTelCasa, Me.colFAlta, Me.colRuta, Me.colCelula, Me.colTipoCreditoDescripcion, Me.colStatus, Me.colCargo, Me.colSaldo, Me.colDGestion, Me.colDCobro})
        Me.Estilo1.HeaderBackColor = System.Drawing.Color.Gold
        Me.Estilo1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.Estilo1.MappingName = "Cliente"
        Me.Estilo1.RowHeadersVisible = False
        '
        'colCliente
        '
        Me.colCliente.Format = ""
        Me.colCliente.FormatInfo = Nothing
        Me.colCliente.HeaderText = "Cliente"
        Me.colCliente.MappingName = "Cliente"
        Me.colCliente.Width = 75
        '
        'colNombre
        '
        Me.colNombre.Format = ""
        Me.colNombre.FormatInfo = Nothing
        Me.colNombre.HeaderText = "Nombre"
        Me.colNombre.MappingName = "Nombre"
        Me.colNombre.Width = 150
        '
        'colDireccionCompleta
        '
        Me.colDireccionCompleta.Format = ""
        Me.colDireccionCompleta.FormatInfo = Nothing
        Me.colDireccionCompleta.HeaderText = "Dirección"
        Me.colDireccionCompleta.MappingName = "DireccionCompleta"
        Me.colDireccionCompleta.Width = 140
        '
        'colTelCasa
        '
        Me.colTelCasa.Format = ""
        Me.colTelCasa.FormatInfo = Nothing
        Me.colTelCasa.HeaderText = "Teléfono"
        Me.colTelCasa.MappingName = "TelCasa"
        Me.colTelCasa.Width = 70
        '
        'colFAlta
        '
        Me.colFAlta.Format = ""
        Me.colFAlta.FormatInfo = Nothing
        Me.colFAlta.HeaderText = "F.Alta"
        Me.colFAlta.MappingName = "FAlta"
        Me.colFAlta.Width = 120
        '
        'colRuta
        '
        Me.colRuta.Format = ""
        Me.colRuta.FormatInfo = Nothing
        Me.colRuta.HeaderText = "Ruta"
        Me.colRuta.MappingName = "RutaDescripcion"
        Me.colRuta.Width = 60
        '
        'colCelula
        '
        Me.colCelula.Format = ""
        Me.colCelula.FormatInfo = Nothing
        Me.colCelula.HeaderText = "Célula"
        Me.colCelula.MappingName = "CelulaDescripcion"
        Me.colCelula.Width = 60
        '
        'colTipoCreditoDescripcion
        '
        Me.colTipoCreditoDescripcion.Format = ""
        Me.colTipoCreditoDescripcion.FormatInfo = Nothing
        Me.colTipoCreditoDescripcion.HeaderText = "Tipo de crédito"
        Me.colTipoCreditoDescripcion.MappingName = "TipoCreditoDescripcion"
        Me.colTipoCreditoDescripcion.Width = 110
        '
        'colStatus
        '
        Me.colStatus.Format = ""
        Me.colStatus.FormatInfo = Nothing
        Me.colStatus.HeaderText = "Estatus"
        Me.colStatus.MappingName = "Status"
        Me.colStatus.Width = 60
        '
        'colCargo
        '
        Me.colCargo.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colCargo.Format = "#,##.00"
        Me.colCargo.FormatInfo = Nothing
        Me.colCargo.HeaderText = "Cargos"
        Me.colCargo.MappingName = "Cargo"
        Me.colCargo.NullText = "Cargo"
        Me.colCargo.Width = 80
        '
        'colSaldo
        '
        Me.colSaldo.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colSaldo.Format = "#,##.00"
        Me.colSaldo.FormatInfo = Nothing
        Me.colSaldo.HeaderText = "Saldo actual"
        Me.colSaldo.MappingName = "Saldo"
        Me.colSaldo.Width = 80
        '
        'colDGestion
        '
        Me.colDGestion.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.colDGestion.Format = ""
        Me.colDGestion.FormatInfo = Nothing
        Me.colDGestion.HeaderText = "Dificultad Gestion"
        Me.colDGestion.MappingName = "DificultadGestion"
        Me.colDGestion.NullText = ""
        Me.colDGestion.Width = 80
        '
        'colDCobro
        '
        Me.colDCobro.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.colDCobro.Format = ""
        Me.colDCobro.FormatInfo = Nothing
        Me.colDCobro.HeaderText = "Dificultad Cobro"
        Me.colDCobro.MappingName = "DificultadCobro"
        Me.colDCobro.NullText = ""
        Me.colDCobro.Width = 80
        '
        'tbrBarra
        '
        Me.tbrBarra.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbrBarra.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnConsultar, Me.ToolBarButton2, Me.btnRefrescar, Me.ToolBarButton1, Me.btnCerrar})
        Me.tbrBarra.DropDownArrows = True
        Me.tbrBarra.ImageList = Me.imgLista16
        Me.tbrBarra.Name = "tbrBarra"
        Me.tbrBarra.ShowToolTips = True
        Me.tbrBarra.Size = New System.Drawing.Size(632, 39)
        Me.tbrBarra.TabIndex = 1
        '
        'btnConsultar
        '
        Me.btnConsultar.ImageIndex = 0
        Me.btnConsultar.Tag = "Consultar"
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.ToolTipText = "Consultar el cliente seleccionado"
        '
        'ToolBarButton2
        '
        Me.ToolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnRefrescar
        '
        Me.btnRefrescar.ImageIndex = 1
        Me.btnRefrescar.Tag = "Refrescar"
        Me.btnRefrescar.Text = "Refrescar"
        Me.btnRefrescar.ToolTipText = "Refrescar información"
        '
        'ToolBarButton1
        '
        Me.ToolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnCerrar
        '
        Me.btnCerrar.ImageIndex = 2
        Me.btnCerrar.Tag = "Cerrar"
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.ToolTipText = "Cerrar"
        '
        'imgLista16
        '
        Me.imgLista16.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgLista16.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgLista16.ImageStream = CType(resources.GetObject("imgLista16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLista16.TransparentColor = System.Drawing.Color.Transparent
        '
        'dtpFAlta
        '
        Me.dtpFAlta.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.dtpFAlta.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpFAlta.Location = New System.Drawing.Point(272, 8)
        Me.dtpFAlta.Name = "dtpFAlta"
        Me.dtpFAlta.Size = New System.Drawing.Size(88, 21)
        Me.dtpFAlta.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(224, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 14)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Del día:"
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Bitmap)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(560, 8)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(64, 21)
        Me.btnBuscar.TabIndex = 5
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grdTotales
        '
        Me.grdTotales.AlternatingBackColor = System.Drawing.Color.Lavender
        Me.grdTotales.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdTotales.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdTotales.BackgroundColor = System.Drawing.Color.LightGray
        Me.grdTotales.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grdTotales.CaptionBackColor = System.Drawing.Color.LightSteelBlue
        Me.grdTotales.CaptionForeColor = System.Drawing.Color.MidnightBlue
        Me.grdTotales.DataMember = ""
        Me.grdTotales.FlatMode = True
        Me.grdTotales.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.grdTotales.ForeColor = System.Drawing.Color.MidnightBlue
        Me.grdTotales.GridLineColor = System.Drawing.Color.Gainsboro
        Me.grdTotales.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None
        Me.grdTotales.HeaderBackColor = System.Drawing.Color.MidnightBlue
        Me.grdTotales.HeaderFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.grdTotales.HeaderForeColor = System.Drawing.Color.WhiteSmoke
        Me.grdTotales.LinkColor = System.Drawing.Color.Teal
        Me.grdTotales.Location = New System.Drawing.Point(360, 8)
        Me.grdTotales.Name = "grdTotales"
        Me.grdTotales.ParentRowsBackColor = System.Drawing.Color.Gainsboro
        Me.grdTotales.ParentRowsForeColor = System.Drawing.Color.MidnightBlue
        Me.grdTotales.ReadOnly = True
        Me.grdTotales.SelectionBackColor = System.Drawing.Color.CadetBlue
        Me.grdTotales.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        Me.grdTotales.Size = New System.Drawing.Size(264, 128)
        Me.grdTotales.TabIndex = 0
        Me.grdTotales.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.styResultado})
        '
        'styResultado
        '
        Me.styResultado.DataGrid = Me.grdTotales
        Me.styResultado.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colREDescripcion, Me.colRETotal})
        Me.styResultado.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.styResultado.MappingName = "Totales"
        Me.styResultado.ReadOnly = True
        Me.styResultado.RowHeadersVisible = False
        '
        'colREDescripcion
        '
        Me.colREDescripcion.Format = ""
        Me.colREDescripcion.FormatInfo = Nothing
        Me.colREDescripcion.HeaderText = "Célula"
        Me.colREDescripcion.MappingName = "Descripcion"
        Me.colREDescripcion.Width = 75
        '
        'colRETotal
        '
        Me.colRETotal.Format = ""
        Me.colRETotal.FormatInfo = Nothing
        Me.colRETotal.HeaderText = "Total de clientes nuevos"
        Me.colRETotal.MappingName = "Total"
        Me.colRETotal.Width = 130
        '
        'Panel1
        '
        Me.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.grdTotales})
        Me.Panel1.Location = New System.Drawing.Point(0, 320)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(640, 152)
        Me.Panel1.TabIndex = 6
        '
        'btnCerrar2
        '
        Me.btnCerrar2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar2.Location = New System.Drawing.Point(208, 8)
        Me.btnCerrar2.Name = "btnCerrar2"
        Me.btnCerrar2.Size = New System.Drawing.Size(16, 16)
        Me.btnCerrar2.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(376, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 14)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Al día:"
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpFechaFin.Location = New System.Drawing.Point(432, 8)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(88, 21)
        Me.dtpFechaFin.TabIndex = 8
        '
        'frmConsultaClientesNuevos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCerrar2
        Me.ClientSize = New System.Drawing.Size(632, 461)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.dtpFechaFin, Me.Panel1, Me.btnBuscar, Me.Label1, Me.dtpFAlta, Me.tbrBarra, Me.grdCliente, Me.btnCerrar2})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConsultaClientesNuevos"
        Me.Text = "Clientes nuevos a crédito"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.grdCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdTotales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub ConsultaDatos()
        Cursor = Cursors.WaitCursor
        _Cliente = 0
        listaClientesEnviados = New List(Of Integer)
        Dim direccionEntregaTemp As RTGMCore.DireccionEntrega = New RTGMCore.DireccionEntrega
        btnConsultar.Enabled = False

        Dim cmd As SqlCommand
        'Dim cn As New SqlConnection(ConString)
        Dim cn As SqlConnection = GLOBAL_connection
        Dim da As SqlDataAdapter = Nothing
        Dim dt As DataTable = Nothing

        Try

            cmd = New SqlCommand("spReporteClientesNuevos")

            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("@Fecha1", SqlDbType.DateTime).Value = dtpFAlta.Value.Date
                .Parameters.Add("@Fecha2", SqlDbType.DateTime).Value = dtpFechaFin.Value.Date
                .Connection = cn
            End With

            da = New SqlDataAdapter(cmd)
            dt = New DataTable("Cliente")

            da.SelectCommand.CommandTimeout = 180
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                If _URLGateway <> "" Then
                    dtCliente = dt

                    Dim clientesDistintos As DataTable = dt.DefaultView.ToTable(True, "Cliente")
                    Dim listaClientesDistintos As New List(Of Integer)

                    For Each clienteTemp As DataRow In clientesDistintos.Rows
                        direccionEntregaTemp = listaDireccionesEntrega.FirstOrDefault(Function(x) x.IDDireccionEntrega = CType(clienteTemp("Cliente"), Integer))

                        If IsNothing(direccionEntregaTemp) Then
                            listaClientesDistintos.Add(CType(clienteTemp("Cliente"), Integer))
                        End If
                    Next

                    Try
                        If clientesDistintos.Rows.Count > 0 Then
                            If listaClientesDistintos.Count > 0 Then
                                validarPeticion = True
                                generaListaClientes(listaClientesDistintos)
                            Else
                                llenarListaEntrega()
                            End If
                        Else
                            grdCliente.DataSource = dt
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Error consultando clientes: " + ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                Else
                    grdCliente.DataSource = dt
                End If

                grdCliente.CaptionText = "Lista de clientes nuevos a crédito del día: " & dtpFAlta.Value.ToLongDateString & " (" & dt.Rows.Count.ToString & " en total)"

                cmd = New SqlCommand("spCYCClientesNuevosPorDia")
                With cmd

                    .CommandType = CommandType.StoredProcedure
                    .CommandTimeout = 180
                    .Parameters.Add("@Fecha1", SqlDbType.DateTime).Value = dtpFAlta.Value.Date
                    .Parameters.Add("@Fecha2", SqlDbType.DateTime).Value = dtpFechaFin.Value.Date
                    .Connection = cn
                End With

                da = New SqlDataAdapter(cmd)
                Dim dtTotales As New DataTable("Totales")
                da.Fill(dtTotales)
                If dtTotales.Rows.Count > 0 Then
                    grdTotales.DataSource = dtTotales
                    grdTotales.CaptionText = "Resultados"
                Else
                    grdTotales.DataSource = Nothing
                    grdTotales.CaptionText = ""
                End If


            Else
                _Cliente = 0
                btnConsultar.Enabled = False
                grdCliente.DataSource = Nothing
                grdCliente.CaptionText = "No hay clientes nuevos a crédito en el día especificado"
                grdTotales.DataSource = Nothing
                grdTotales.CaptionText = ""
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
                'cn.Dispose()
            End If
            da.Dispose()
            dt.Dispose()
        End Try
    End Sub

    Public Sub completarListaEntregas(lista As List(Of RTGMCore.DireccionEntrega))
        Dim direccionEntrega As RTGMCore.DireccionEntrega
        Dim direccionEntregaTemp As RTGMCore.DireccionEntrega
        Dim errorConsulta As Boolean
        Try
            For Each direccion As RTGMCore.DireccionEntrega In lista
                Try
                    If Not IsNothing(direccion) Then
                        If Not IsNothing(direccion.Message) Then
                            direccionEntrega = New RTGMCore.DireccionEntrega()
                            direccionEntrega.IDDireccionEntrega = direccion.IDDireccionEntrega
                            direccionEntrega.Nombre = direccion.Message
                            listaDireccionesEntrega.Add(direccionEntrega)
                        ElseIf direccion.IDDireccionEntrega = -1 Then
                            errorConsulta = True
                        ElseIf direccion.IDDireccionEntrega >= 0 Then
                            listaDireccionesEntrega.Add(direccion)
                        End If
                    Else
                        direccionEntrega = New RTGMCore.DireccionEntrega()
                        direccionEntrega.IDDireccionEntrega = direccion.IDDireccionEntrega
                        direccionEntrega.Nombre = "No se encontró cliente"
                        listaDireccionesEntrega.Add(direccionEntrega)
                    End If

                Catch ex As Exception
                    direccionEntrega = New RTGMCore.DireccionEntrega()
                    direccionEntrega.IDDireccionEntrega = direccion.IDDireccionEntrega
                    direccionEntrega.Nombre = ex.Message
                    listaDireccionesEntrega.Add(direccionEntrega)
                End Try
            Next

            If validarPeticion And errorConsulta Then
                validarPeticion = False
                Dim listaClientes As List(Of Integer) = New List(Of Integer)
                For Each clienteTemp As Integer In listaClientesEnviados
                    direccionEntregaTemp = listaDireccionesEntrega.FirstOrDefault(Function(x) x.IDDireccionEntrega = clienteTemp)

                    If IsNothing(direccionEntregaTemp) Then
                        listaClientes.Add(clienteTemp)
                    End If
                Next

                Dim result As Integer = MessageBox.Show("No fue posible encontrar información para " & listaClientes.Count & " clientes de la solicitud ¿desea reintentar?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error)

                If result = DialogResult.Yes Then
                    generaListaClientes(listaClientes)
                Else
                    llenarListaEntrega()
                End If
            Else
                llenarListaEntrega()
            End If
        Catch ex As Exception
            MessageBox.Show("Error consultando clientes: " + ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub llenarListaEntrega()
        Dim drow As DataRow
        Dim CLIENTETEMP As Integer
        Dim direccionEntrega As RTGMCore.DireccionEntrega
        Try
            direccionEntrega = New RTGMCore.DireccionEntrega
            For Each drow In dtCliente.Rows
                Try
                    drow("Nombre") = ""
                    CLIENTETEMP = (CType(drow("Cliente"), Integer))

                    direccionEntrega = listaDireccionesEntrega.FirstOrDefault(Function(x) x.IDDireccionEntrega = CLIENTETEMP)

                    If Not IsNothing(direccionEntrega) Then
                        drow("Nombre") = direccionEntrega.Nombre.Trim()
                    Else
                        drow("Nombre") = "No encontrado"
                    End If
                Catch ex As Exception
                    drow("Nombre") = "Error al buscar"
                End Try
            Next

            grdCliente.DataSource = dtCliente
        Catch ex As Exception
            MessageBox.Show("Error" + ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

        End Try
    End Sub

    Private Sub generaListaClientes(ByVal listaClientesDistintos As List(Of Integer))
        Dim oGateway As RTGMGateway.RTGMGateway
        Dim oSolicitud As RTGMGateway.SolicitudGateway
        Try
            oGateway = New RTGMGateway.RTGMGateway(GLOBAL_Modulo, ConString) ', _UrlGateway)
            oGateway.ListaCliente = listaClientesDistintos
            oGateway.URLServicio = _URLGateway
            oSolicitud = New RTGMGateway.SolicitudGateway()
            AddHandler oGateway.eListaEntregas, AddressOf completarListaEntregas
            listaClientesEnviados = listaClientesDistintos
            For Each CLIENTETEMP As Integer In listaClientesDistintos
                oSolicitud.IDCliente = CLIENTETEMP
                oGateway.busquedaDireccionEntregaAsync(oSolicitud)
            Next
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub frmConsultaClientesNuevos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpFAlta.Value = Now.Date
        dtpFAlta.MaxDate = Now.Date
        listaDireccionesEntrega = New List(Of RTGMCore.DireccionEntrega)
        Try
            Dim oConfig As New SigaMetClasses.cConfig(GLOBAL_Modulo, GLOBAL_Corporativo, GLOBAL_Sucursal)
            _URLGateway = CType(oConfig.Parametros("URLGateway"), String)
        Catch ex As Exception

        End Try
        ConsultaDatos()
    End Sub

    Private Sub tbrBarra_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrBarra.ButtonClick
        Select Case e.Button.Tag.ToString()
            Case "Consultar"
                If _Cliente <> 0 Then
                    ConsultaCliente()
                End If
            Case "Refrescar"
                ConsultaDatos()
            Case "Cerrar"
                Me.Close()
        End Select
    End Sub

    Private Sub ConsultaCliente()
        Cursor = Cursors.WaitCursor
        Dim oConsultaCliente As New SigaMetClasses.frmConsultaCliente(_Cliente, Nuevo:=0, Usuario:=GLOBAL_IDUsuario, PermiteModificarDatosCliente:=True)
        oConsultaCliente.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub grdCliente_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCliente.CurrentCellChanged
        Try
            _Cliente = CType(grdCliente.Item(grdCliente.CurrentRowIndex, 0), Integer)
        Catch
            _Cliente = 0
        End Try
        If _Cliente <> 0 Then btnConsultar.Enabled = True
        grdCliente.Select(grdCliente.CurrentRowIndex)
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        ConsultaDatos()
    End Sub

    Private Sub btnCerrar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar2.Click
        Me.Close()
    End Sub
End Class
