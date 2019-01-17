Imports System.Collections.Generic
Imports System.Linq
Imports RTGMGateway

Public Class frmClientesCartera
    Inherits System.Windows.Forms.Form

    Private LoadCompleted As Boolean = False
    Private _Cliente As Integer
    Private NoExiste As Boolean = False
    Private _URLGateway As String
    Private listaDireccionesEntrega As List(Of RTGMCore.DireccionEntrega)

    Private _Modulo As Short
    Private _CadenaConexion As String

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        cboCelula.CargaDatos()
    End Sub
    Public Property Modulo As Short
        Get
            Return _Modulo
        End Get
        Set(value As Short)
            _Modulo = value
        End Set
    End Property

    Public Property CadenaConexion As String
        Get
            Return _CadenaConexion
        End Get
        Set(value As String)
            _CadenaConexion = value
        End Set
    End Property

    Public Sub New(URLGateway As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        cboCelula.CargaDatos()
        _URLGateway = URLGateway
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
    Friend WithEvents imgTools As System.Windows.Forms.ImageList
    Friend WithEvents tbCartera As System.Windows.Forms.ToolBar
    Friend WithEvents grdCartera As System.Windows.Forms.DataGrid
    Friend WithEvents lblCelula As System.Windows.Forms.Label
    Friend WithEvents cboCelula As SigaMetClasses.Combos.ComboCelula
    Friend WithEvents btnCargarDatos As System.Windows.Forms.Button
    Friend WithEvents tbbRefrescar As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbModificar As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbSep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents Estilo1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colCliente As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colNombre As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCelula As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colRuta As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colStatus As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colSaldo As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colDiaRevision As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colDiasCredito As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colMaxImporteCredito As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTipoCobro As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colEmpleadoNombre As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnConsultar As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClientesCartera))
        Me.imgTools = New System.Windows.Forms.ImageList(Me.components)
        Me.tbCartera = New System.Windows.Forms.ToolBar()
        Me.tbbModificar = New System.Windows.Forms.ToolBarButton()
        Me.btnConsultar = New System.Windows.Forms.ToolBarButton()
        Me.tbbSep1 = New System.Windows.Forms.ToolBarButton()
        Me.tbbRefrescar = New System.Windows.Forms.ToolBarButton()
        Me.tbbCerrar = New System.Windows.Forms.ToolBarButton()
        Me.grdCartera = New System.Windows.Forms.DataGrid()
        Me.Estilo1 = New System.Windows.Forms.DataGridTableStyle()
        Me.colCliente = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colNombre = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCelula = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colRuta = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colStatus = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colSaldo = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colDiaRevision = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colDiasCredito = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colMaxImporteCredito = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTipoCobro = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colEmpleadoNombre = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.lblCelula = New System.Windows.Forms.Label()
        Me.cboCelula = New SigaMetClasses.Combos.ComboCelula()
        Me.btnCargarDatos = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        CType(Me.grdCartera, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'imgTools
        '
        Me.imgTools.ImageStream = CType(resources.GetObject("imgTools.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgTools.TransparentColor = System.Drawing.Color.Transparent
        Me.imgTools.Images.SetKeyName(0, "")
        Me.imgTools.Images.SetKeyName(1, "")
        Me.imgTools.Images.SetKeyName(2, "")
        Me.imgTools.Images.SetKeyName(3, "")
        '
        'tbCartera
        '
        Me.tbCartera.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbCartera.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.tbbModificar, Me.btnConsultar, Me.tbbSep1, Me.tbbRefrescar, Me.tbbCerrar})
        Me.tbCartera.DropDownArrows = True
        Me.tbCartera.ImageList = Me.imgTools
        Me.tbCartera.Location = New System.Drawing.Point(0, 0)
        Me.tbCartera.Name = "tbCartera"
        Me.tbCartera.ShowToolTips = True
        Me.tbCartera.Size = New System.Drawing.Size(944, 42)
        Me.tbCartera.TabIndex = 0
        '
        'tbbModificar
        '
        Me.tbbModificar.ImageIndex = 2
        Me.tbbModificar.Name = "tbbModificar"
        Me.tbbModificar.Tag = "Modificar"
        Me.tbbModificar.Text = "Modificar"
        Me.tbbModificar.ToolTipText = "Modificar los datos de crédito del cliente"
        '
        'btnConsultar
        '
        Me.btnConsultar.ImageIndex = 3
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Tag = "Consultar"
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.ToolTipText = "Consultar el cliente seleccionado"
        '
        'tbbSep1
        '
        Me.tbbSep1.Name = "tbbSep1"
        Me.tbbSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbbRefrescar
        '
        Me.tbbRefrescar.ImageIndex = 1
        Me.tbbRefrescar.Name = "tbbRefrescar"
        Me.tbbRefrescar.Tag = "Refrescar"
        Me.tbbRefrescar.Text = "Refrescar"
        Me.tbbRefrescar.ToolTipText = "Refrescar la información"
        '
        'tbbCerrar
        '
        Me.tbbCerrar.ImageIndex = 0
        Me.tbbCerrar.Name = "tbbCerrar"
        Me.tbbCerrar.Tag = "Cerrar"
        Me.tbbCerrar.Text = "Cerrar"
        Me.tbbCerrar.ToolTipText = "Cerrar"
        '
        'grdCartera
        '
        Me.grdCartera.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdCartera.BackgroundColor = System.Drawing.Color.LightGray
        Me.grdCartera.CaptionBackColor = System.Drawing.Color.White
        Me.grdCartera.CaptionFont = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdCartera.CaptionForeColor = System.Drawing.Color.Navy
        Me.grdCartera.DataMember = ""
        Me.grdCartera.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdCartera.Location = New System.Drawing.Point(4, 40)
        Me.grdCartera.Name = "grdCartera"
        Me.grdCartera.ReadOnly = True
        Me.grdCartera.Size = New System.Drawing.Size(936, 384)
        Me.grdCartera.TabIndex = 3
        Me.grdCartera.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.Estilo1})
        '
        'Estilo1
        '
        Me.Estilo1.DataGrid = Me.grdCartera
        Me.Estilo1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colCliente, Me.colNombre, Me.colCelula, Me.colRuta, Me.colStatus, Me.colSaldo, Me.colDiaRevision, Me.colDiasCredito, Me.colMaxImporteCredito, Me.colTipoCobro, Me.colEmpleadoNombre})
        Me.Estilo1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.Estilo1.MappingName = "Cartera"
        Me.Estilo1.ReadOnly = True
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
        Me.colNombre.Width = 180
        '
        'colCelula
        '
        Me.colCelula.Format = ""
        Me.colCelula.FormatInfo = Nothing
        Me.colCelula.HeaderText = "Célula"
        Me.colCelula.MappingName = "Celula"
        Me.colCelula.Width = 60
        '
        'colRuta
        '
        Me.colRuta.Format = ""
        Me.colRuta.FormatInfo = Nothing
        Me.colRuta.HeaderText = "Ruta"
        Me.colRuta.MappingName = "Ruta"
        Me.colRuta.Width = 60
        '
        'colStatus
        '
        Me.colStatus.Format = ""
        Me.colStatus.FormatInfo = Nothing
        Me.colStatus.HeaderText = "Estatus"
        Me.colStatus.MappingName = "Status"
        Me.colStatus.Width = 75
        '
        'colSaldo
        '
        Me.colSaldo.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colSaldo.Format = "#,##.00"
        Me.colSaldo.FormatInfo = Nothing
        Me.colSaldo.HeaderText = "Saldo"
        Me.colSaldo.MappingName = "Saldo"
        Me.colSaldo.Width = 75
        '
        'colDiaRevision
        '
        Me.colDiaRevision.Format = ""
        Me.colDiaRevision.FormatInfo = Nothing
        Me.colDiaRevision.HeaderText = "Día de revisión"
        Me.colDiaRevision.MappingName = "DiaRevisionNombre"
        Me.colDiaRevision.Width = 75
        '
        'colDiasCredito
        '
        Me.colDiasCredito.Format = ""
        Me.colDiasCredito.FormatInfo = Nothing
        Me.colDiasCredito.HeaderText = "Días de crédito"
        Me.colDiasCredito.MappingName = "DiasCredito"
        Me.colDiasCredito.Width = 75
        '
        'colMaxImporteCredito
        '
        Me.colMaxImporteCredito.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colMaxImporteCredito.Format = "#,##.00"
        Me.colMaxImporteCredito.FormatInfo = Nothing
        Me.colMaxImporteCredito.HeaderText = "Max. Importe crédito"
        Me.colMaxImporteCredito.MappingName = "MaxImporteCredito"
        Me.colMaxImporteCredito.Width = 75
        '
        'colTipoCobro
        '
        Me.colTipoCobro.Format = ""
        Me.colTipoCobro.FormatInfo = Nothing
        Me.colTipoCobro.HeaderText = "Tipo de cobro"
        Me.colTipoCobro.MappingName = "TipoCobroDescripcion"
        Me.colTipoCobro.Width = 75
        '
        'colEmpleadoNombre
        '
        Me.colEmpleadoNombre.Format = ""
        Me.colEmpleadoNombre.FormatInfo = Nothing
        Me.colEmpleadoNombre.HeaderText = "Empleado"
        Me.colEmpleadoNombre.MappingName = "EmpleadoNombre"
        Me.colEmpleadoNombre.Width = 150
        '
        'lblCelula
        '
        Me.lblCelula.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCelula.AutoSize = True
        Me.lblCelula.Location = New System.Drawing.Point(600, 11)
        Me.lblCelula.Name = "lblCelula"
        Me.lblCelula.Size = New System.Drawing.Size(40, 13)
        Me.lblCelula.TabIndex = 14
        Me.lblCelula.Text = "Célula:"
        '
        'cboCelula
        '
        Me.cboCelula.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelula.ForeColor = System.Drawing.Color.MediumBlue
        Me.cboCelula.Location = New System.Drawing.Point(640, 8)
        Me.cboCelula.Name = "cboCelula"
        Me.cboCelula.Size = New System.Drawing.Size(216, 21)
        Me.cboCelula.TabIndex = 16
        '
        'btnCargarDatos
        '
        Me.btnCargarDatos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCargarDatos.Image = CType(resources.GetObject("btnCargarDatos.Image"), System.Drawing.Image)
        Me.btnCargarDatos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCargarDatos.Location = New System.Drawing.Point(864, 7)
        Me.btnCargarDatos.Name = "btnCargarDatos"
        Me.btnCargarDatos.Size = New System.Drawing.Size(75, 23)
        Me.btnCargarDatos.TabIndex = 17
        Me.btnCargarDatos.Text = "Consultar"
        Me.btnCargarDatos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCerrar
        '
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Location = New System.Drawing.Point(528, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(8, 16)
        Me.btnCerrar.TabIndex = 18
        '
        'frmClientesCartera
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(944, 429)
        Me.Controls.Add(Me.btnCargarDatos)
        Me.Controls.Add(Me.cboCelula)
        Me.Controls.Add(Me.lblCelula)
        Me.Controls.Add(Me.grdCartera)
        Me.Controls.Add(Me.tbCartera)
        Me.Controls.Add(Me.btnCerrar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmClientesCartera"
        Me.Text = "Clientes de la cartera"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.grdCartera, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


    Private Sub grdCartera_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCartera.CurrentCellChanged
        grdCartera.Select(grdCartera.CurrentRowIndex)
        _Cliente = CType(grdCartera.Item(grdCartera.CurrentRowIndex, 0), Integer)
    End Sub

    Private Sub tbCartera_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbCartera.ButtonClick
        Select Case e.Button.Tag.ToString()
            Case "Modificar"
                Modificar()
            Case "Consultar"
                Consultar()
            Case "Refrescar"
                If _URLGateway = "" Then
                    CargaDatos()
                Else
                    CargaDatos(_URLGateway)
                End If

            Case "Cerrar"
                Me.Close()
        End Select
    End Sub

    Private Sub Consultar()
        Cursor = Cursors.WaitCursor
        Dim oConsultaCliente As New SigaMetClasses.frmConsultaCliente(_Cliente, Nuevo:=0, Usuario:=GLOBAL_IDUsuario, _ClienteRow:=listaDireccionesEntrega.FirstOrDefault(Function(x) x.IDDireccionEntrega = _Cliente))
        oConsultaCliente.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub CargaDatos()
        Cursor = Cursors.WaitCursor
        _Cliente = 0
        If Not LoadCompleted Then
            Exit Sub
        End If
        Dim ColumnKey(0) As DataColumn
        Dim strQuery As String =
        "SELECT Cliente, Nombre, Celula, Ruta, Saldo, Status, DiaRevisionNombre, DiasCredito, MaxImporteCredito, TipoCobroDescripcion, EmpleadoNombre " &
        "FROM vwDatosCliente " &
        "WHERE Saldo > 0 " &
        "AND Celula = @Celula ORDER BY Celula, Ruta, Cliente"

        'Dim cnSIGAMET As New SqlClient.SqlConnection(Main.ConString)
        Dim cnSIGAMET As SqlClient.SqlConnection = GLOBAL_connection
        Dim cmdCartera As New SqlClient.SqlCommand(strQuery, cnSIGAMET)
        Dim daCartera As New SqlClient.SqlDataAdapter(cmdCartera)
        Dim dt As New DataTable("Cartera")
        cmdCartera.Parameters.Add("@Celula", SqlDbType.SmallInt).Value = cboCelula.Celula
        Try

            daCartera.Fill(dt)
            If dt.Rows.Count > 0 Then
                grdCartera.DataSource = dt
            End If
            grdCartera.CaptionText = "Clientes de la cartera de crédito de la célula " & cboCelula.Celula.ToString & " (" & dt.Rows.Count.ToString & " en total)"
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido el siguiente error:" & Chr(13) & ex.Message, Application.ProductName & " versión " & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub CargaDatos(URLGateway As String)
        Cursor = Cursors.WaitCursor
        _Cliente = 0
        If Not LoadCompleted Then
            Exit Sub
        End If
        Dim ColumnKey(0) As DataColumn
        Dim strQuery As String =
        "SELECT Cliente, Nombre, Celula, Ruta, Saldo, Status, DiaRevisionNombre, DiasCredito, MaxImporteCredito, TipoCobroDescripcion, EmpleadoNombre " &
        "FROM vwDatosCliente " &
        "WHERE Saldo > 0 " &
        "AND Celula = @Celula ORDER BY Celula, Ruta, Cliente"

        'Dim cnSIGAMET As New SqlClient.SqlConnection(Main.ConString)
        Dim cnSIGAMET As SqlClient.SqlConnection = GLOBAL_connection
        Dim cmdCartera As New SqlClient.SqlCommand(strQuery, cnSIGAMET)
        Dim daCartera As New SqlClient.SqlDataAdapter(cmdCartera)
        Dim dt As New DataTable("Cartera")
        Dim CLIENTETEMP As Integer
        Dim direccionEntrega As RTGMCore.DireccionEntrega
        cmdCartera.Parameters.Add("@Celula", SqlDbType.SmallInt).Value = cboCelula.Celula
        Try
            daCartera.Fill(dt)
            If dt.Rows.Count > 0 Then
                Dim dvConsultar As DataView = New DataView(dt)
                Dim dtConsultar As DataTable = dvConsultar.ToTable(True, "Cliente")
                If dtConsultar.Rows.Count() > 0 Then
                    Dim listaClientesDistintos As New List(Of Integer)

                    For Each fila As DataRow In dtConsultar.Rows
                        listaClientesDistintos.Add(CType(fila("Cliente"), Integer))
                    Next

                    Try
                        generaListaClientes(listaClientesDistintos)
                    Catch ex As Exception

                    End Try

                    For Each drow As DataRow In dt.Rows
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

                End If
                'Dim objGateway As RTGMGateway.RTGMGateway = New RTGMGateway.RTGMGateway(GLOBAL_Modulo, ConString)
                'objGateway.URLServicio = URLGateway
                '  Dim objSolicitudGateway As SolicitudGateway = New SolicitudGateway()
                'Dim objRtgCore As RTGMCore.DireccionEntrega = New RTGMCore.DireccionEntrega()

                '                Dim row As DataRow

                '                For Each row In dt.Rows
                '                    If row("Cliente") Is DBNull.Value OrElse row("Cliente") Is Nothing Then
                '                        GoTo SiguienteFila
                '                    End If

                '                    Dim Cliente As Integer = CInt(row("Cliente"))
                '                    Dim objSolicitudGateway As SolicitudGateway = New SolicitudGateway()
                '                    objSolicitudGateway.IDCliente = Cliente
                '                    ' Dim objGateway As RTGMGateway.RTGMGateway = New RTGMGateway.RTGMGateway(GLOBAL_Modulo, ConString)
                '                    objGateway.URLServicio = URLGateway
                '                    Dim objRtgCore As RTGMCore.DireccionEntrega = objGateway.buscarDireccionEntrega(objSolicitudGateway)
                '                    row("Nombre") = IIf(Not IsNothing(objRtgCore.Nombre), objRtgCore.Nombre, String.Empty)
                'SiguienteFila:
                '                Next

                'daCartera.Fill(dt)
                'If dt.Rows.Count > 0 Then
                grdCartera.DataSource = dt
            End If
            grdCartera.CaptionText = "Clientes de la cartera de crédito de la célula " & cboCelula.Celula.ToString & " (" & dt.Rows.Count.ToString & " en total)"
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido el siguiente error:" & Chr(13) & ex.Message, Application.ProductName & " versión " & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub generaListaClientes(ByVal listaClientesDistintos As List(Of Integer))
        Try
            Dim listaClientes As New List(Of Integer?)
            Dim direccionEntregaTemp As RTGMCore.DireccionEntrega

            For Each clienteTemp As Integer In listaClientesDistintos
                direccionEntregaTemp = listaDireccionesEntrega.FirstOrDefault(Function(x) x.IDDireccionEntrega = clienteTemp)

                If IsNothing(direccionEntregaTemp) Then
                    listaClientes.Add(clienteTemp)
                End If
            Next

            Dim oSolicitud As RTGMGateway.SolicitudGateway
            oSolicitud.ListaCliente = listaClientes
            consultarDireccionesLista(oSolicitud)
        Catch ex As Exception
            Throw
        End Try

    End Sub

    Private Sub consultarDireccionesLista(oSolicitud As RTGMGateway.SolicitudGateway)
        Dim oGateway As RTGMGateway.RTGMGateway
        Dim oDireccionEntrega As New RTGMCore.DireccionEntrega()
        Dim oDireccionEntregaLista As List(Of RTGMCore.DireccionEntrega)
        Try

            oGateway = New RTGMGateway.RTGMGateway(CType(_Modulo, Byte), _CadenaConexion)
            oGateway.URLServicio = _URLGateway

            oDireccionEntregaLista = oGateway.busquedaDireccionEntregaLista(oSolicitud)

            If Not IsNothing(oDireccionEntregaLista) Then
                For Each direccion As RTGMCore.DireccionEntrega In oDireccionEntregaLista
                    If Not listaDireccionesEntrega.Exists(Function(x) x.IDDireccionEntrega = direccion.IDDireccionEntrega) Then
                        If Not IsNothing(direccion.Message) Then
                            oDireccionEntrega = New RTGMCore.DireccionEntrega()
                            oDireccionEntrega.IDDireccionEntrega = direccion.IDDireccionEntrega
                            oDireccionEntrega.Nombre = direccion.Message
                            listaDireccionesEntrega.Add(oDireccionEntrega)
                        Else
                            oDireccionEntrega = New RTGMCore.DireccionEntrega()
                            oDireccionEntrega.IDDireccionEntrega = direccion.IDDireccionEntrega
                            oDireccionEntrega.Nombre = direccion.Nombre
                            listaDireccionesEntrega.Add(oDireccionEntrega)
                        End If
                    End If
                Next
            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub frmCartera_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCompleted = True
        If IsNothing(listaDireccionesEntrega) Then
            listaDireccionesEntrega = New List(Of RTGMCore.DireccionEntrega)
        End If
    End Sub

    Private Sub Modificar()
        If _Cliente <> 0 Then
            Cursor = Cursors.WaitCursor
            Dim oDatosCredito As New SigaMetClasses.CapturaDatosCreditoCliente(_Cliente, GLOBAL_Corporativo, GLOBAL_Sucursal,
            ModificaTipoCredito:=False, ModificaTipoCobro:=False, dtEjecutivoCyC:=DSCatalogos.Tables("EjecutivosCyC"))
            If oDatosCredito.ShowDialog() = DialogResult.OK Then
                If _URLGateway = "" Then
                    CargaDatos()
                Else
                    CargaDatos(_URLGateway)
                End If
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub btnCargarDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargarDatos.Click
        If _URLGateway = "" Then
            CargaDatos()
        Else
            CargaDatos(_URLGateway)
        End If
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub grdCartera_Navigate(sender As Object, ne As NavigateEventArgs) Handles grdCartera.Navigate

    End Sub
End Class
