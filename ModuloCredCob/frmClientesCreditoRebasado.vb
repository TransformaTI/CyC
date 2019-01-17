Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq

Public Class frmClientesCreditoRebasado
    Inherits System.Windows.Forms.Form
    Private _Cliente As Integer
    Private _Modulo As Short
    Private _CadenaConexion As String
    Private _URLGateway As String
    Private listaDireccionesEntrega As List(Of RTGMCore.DireccionEntrega)

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
    Friend WithEvents tbBarra As System.Windows.Forms.ToolBar
    Friend WithEvents btnConsultar As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnRefrescar As System.Windows.Forms.ToolBarButton
    Friend WithEvents imgLista16 As System.Windows.Forms.ImageList
    Friend WithEvents ToolBarButton1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents grdCliente As System.Windows.Forms.DataGrid
    Friend WithEvents stbEstatus As System.Windows.Forms.StatusBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboCelula As SigaMetClasses.Combos.ComboCelula
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Estilo1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colCliente As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colNombre As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colDireccionCompleta As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colRuta As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colMaxImporteCredito As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colSaldo As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colStatus As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTelCasa As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colEmpleadoNombre As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents btnCerrar2 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmClientesCreditoRebasado))
        Me.tbBarra = New System.Windows.Forms.ToolBar()
        Me.btnConsultar = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton2 = New System.Windows.Forms.ToolBarButton()
        Me.btnRefrescar = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton1 = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.imgLista16 = New System.Windows.Forms.ImageList(Me.components)
        Me.grdCliente = New System.Windows.Forms.DataGrid()
        Me.Estilo1 = New System.Windows.Forms.DataGridTableStyle()
        Me.colCliente = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colNombre = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colDireccionCompleta = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTelCasa = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colRuta = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colStatus = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colMaxImporteCredito = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colSaldo = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colEmpleadoNombre = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.stbEstatus = New System.Windows.Forms.StatusBar()
        Me.cboCelula = New SigaMetClasses.Combos.ComboCelula()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnCerrar2 = New System.Windows.Forms.Button()
        CType(Me.grdCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbBarra
        '
        Me.tbBarra.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbBarra.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnConsultar, Me.ToolBarButton2, Me.btnRefrescar, Me.ToolBarButton1, Me.btnCerrar})
        Me.tbBarra.DropDownArrows = True
        Me.tbBarra.ImageList = Me.imgLista16
        Me.tbBarra.Name = "tbBarra"
        Me.tbBarra.ShowToolTips = True
        Me.tbBarra.Size = New System.Drawing.Size(648, 39)
        Me.tbBarra.TabIndex = 0
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
        Me.btnRefrescar.ToolTipText = "Refrescar la información"
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
        'grdCliente
        '
        Me.grdCliente.AlternatingBackColor = System.Drawing.Color.Gainsboro
        Me.grdCliente.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdCliente.BackColor = System.Drawing.Color.Silver
        Me.grdCliente.BackgroundColor = System.Drawing.Color.Lavender
        Me.grdCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.grdCliente.CaptionBackColor = System.Drawing.Color.White
        Me.grdCliente.CaptionFont = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdCliente.CaptionForeColor = System.Drawing.Color.Navy
        Me.grdCliente.DataMember = ""
        Me.grdCliente.FlatMode = True
        Me.grdCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdCliente.ForeColor = System.Drawing.Color.Black
        Me.grdCliente.GridLineColor = System.Drawing.Color.White
        Me.grdCliente.HeaderBackColor = System.Drawing.Color.DarkGray
        Me.grdCliente.HeaderForeColor = System.Drawing.Color.Black
        Me.grdCliente.LinkColor = System.Drawing.Color.DarkSlateBlue
        Me.grdCliente.Location = New System.Drawing.Point(0, 40)
        Me.grdCliente.Name = "grdCliente"
        Me.grdCliente.ParentRowsBackColor = System.Drawing.Color.Black
        Me.grdCliente.ParentRowsForeColor = System.Drawing.Color.White
        Me.grdCliente.ReadOnly = True
        Me.grdCliente.SelectionBackColor = System.Drawing.Color.DarkSlateBlue
        Me.grdCliente.SelectionForeColor = System.Drawing.Color.White
        Me.grdCliente.Size = New System.Drawing.Size(648, 344)
        Me.grdCliente.TabIndex = 1
        Me.grdCliente.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.Estilo1})
        '
        'Estilo1
        '
        Me.Estilo1.DataGrid = Me.grdCliente
        Me.Estilo1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colCliente, Me.colNombre, Me.colDireccionCompleta, Me.colTelCasa, Me.colRuta, Me.colStatus, Me.colMaxImporteCredito, Me.colSaldo, Me.colEmpleadoNombre})
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
        Me.colCliente.Width = 80
        '
        'colNombre
        '
        Me.colNombre.Format = ""
        Me.colNombre.FormatInfo = Nothing
        Me.colNombre.HeaderText = "Nombre"
        Me.colNombre.MappingName = "Nombre"
        Me.colNombre.Width = 180
        '
        'colDireccionCompleta
        '
        Me.colDireccionCompleta.Format = ""
        Me.colDireccionCompleta.FormatInfo = Nothing
        Me.colDireccionCompleta.HeaderText = "Dirección"
        Me.colDireccionCompleta.MappingName = "DireccionCompleta"
        Me.colDireccionCompleta.Width = 200
        '
        'colTelCasa
        '
        Me.colTelCasa.Format = ""
        Me.colTelCasa.FormatInfo = Nothing
        Me.colTelCasa.HeaderText = "Teléfono"
        Me.colTelCasa.MappingName = "TelCasa"
        Me.colTelCasa.Width = 75
        '
        'colRuta
        '
        Me.colRuta.Format = ""
        Me.colRuta.FormatInfo = Nothing
        Me.colRuta.HeaderText = "Ruta"
        Me.colRuta.MappingName = "Ruta"
        Me.colRuta.Width = 75
        '
        'colStatus
        '
        Me.colStatus.Format = ""
        Me.colStatus.FormatInfo = Nothing
        Me.colStatus.HeaderText = "Estatus"
        Me.colStatus.MappingName = "Status"
        Me.colStatus.Width = 75
        '
        'colMaxImporteCredito
        '
        Me.colMaxImporteCredito.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colMaxImporteCredito.Format = "#,##.00"
        Me.colMaxImporteCredito.FormatInfo = Nothing
        Me.colMaxImporteCredito.HeaderText = "Máx. Crédito"
        Me.colMaxImporteCredito.MappingName = "MaxImporteCredito"
        Me.colMaxImporteCredito.Width = 75
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
        'colEmpleadoNombre
        '
        Me.colEmpleadoNombre.Format = ""
        Me.colEmpleadoNombre.FormatInfo = Nothing
        Me.colEmpleadoNombre.HeaderText = "Responsable"
        Me.colEmpleadoNombre.MappingName = "EmpleadoNombre"
        Me.colEmpleadoNombre.Width = 140
        '
        'stbEstatus
        '
        Me.stbEstatus.Location = New System.Drawing.Point(0, 391)
        Me.stbEstatus.Name = "stbEstatus"
        Me.stbEstatus.Size = New System.Drawing.Size(648, 22)
        Me.stbEstatus.TabIndex = 2
        Me.stbEstatus.Text = "Clientes que ya rebasaron su límite de crédito"
        '
        'cboCelula
        '
        Me.cboCelula.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.cboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelula.ForeColor = System.Drawing.Color.MediumBlue
        Me.cboCelula.Location = New System.Drawing.Point(448, 8)
        Me.cboCelula.Name = "cboCelula"
        Me.cboCelula.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label1.Location = New System.Drawing.Point(400, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 14)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Célula:"
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnBuscar.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Bitmap)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(576, 8)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(64, 21)
        Me.btnBuscar.TabIndex = 5
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCerrar2
        '
        Me.btnCerrar2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar2.Location = New System.Drawing.Point(280, 8)
        Me.btnCerrar2.Name = "btnCerrar2"
        Me.btnCerrar2.Size = New System.Drawing.Size(16, 8)
        Me.btnCerrar2.TabIndex = 6
        '
        'frmClientesCreditoRebasado
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCerrar2
        Me.ClientSize = New System.Drawing.Size(648, 413)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnBuscar, Me.Label1, Me.cboCelula, Me.stbEstatus, Me.grdCliente, Me.tbBarra, Me.btnCerrar2})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmClientesCreditoRebasado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clientes que ya rebasaron su límite de crédito"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.grdCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

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

    Public Property URLGateway As String
        Get
            Return _URLGateway
        End Get
        Set(value As String)
            _URLGateway = value
        End Set
    End Property

    Private Sub frmClientesCreditoRebasado_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboCelula.CargaDatos()
        If IsNothing(listaDireccionesEntrega) Then
            listaDireccionesEntrega = New List(Of RTGMCore.DireccionEntrega)
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        CargaDatos()
    End Sub

    Private Sub CargaDatos()
        Cursor = Cursors.WaitCursor
        Dim cmd As New SqlCommand("spReporteClientesCreditoRebasado")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 180
            .Parameters.Add("@Celula", SqlDbType.TinyInt).Value = CType(cboCelula.Celula, Byte)
        End With

        Dim cn As SqlConnection = GLOBAL_connection
        Dim da As SqlDataAdapter = Nothing
        Dim dt As DataTable = Nothing

        Try
            Try
                cn.Open()
            Catch ex As Exception
                MessageBox.Show(SigaMetClasses.M_NO_CONEXION, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End Try

            cmd.Connection = cn
            da = New SqlDataAdapter(cmd)
            dt = New DataTable("Cliente")

            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                grdCliente.DataSource = dt
                grdCliente.CaptionText = "Clientes que ya rebasaron su límite de crédito en la célula: " & cboCelula.Celula.ToString & " (" & dt.Rows.Count.ToString & " en total)"
            Else
                grdCliente.DataSource = Nothing
                grdCliente.CaptionText = "No se encontraron registros"
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
                'cn.Dispose()
            End If
            da.Dispose()
            cmd.Dispose()
            dt.Dispose()

            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub CargaDatos(URLGateway As String)
        Cursor = Cursors.WaitCursor
        Dim cmd As New SqlCommand("spReporteClientesCreditoRebasado")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 180
            .Parameters.Add("@Celula", SqlDbType.TinyInt).Value = CType(cboCelula.Celula, Byte)
        End With

        Dim cn As SqlConnection = GLOBAL_connection
        Dim da As SqlDataAdapter = Nothing
        Dim dt As DataTable = Nothing
        Dim CLIENTETEMP As Integer
        Dim direccionEntrega As RTGMCore.DireccionEntrega

        Try
            Try
                cn.Open()
            Catch ex As Exception
                MessageBox.Show(SigaMetClasses.M_NO_CONEXION, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End Try

            cmd.Connection = cn
            da = New SqlDataAdapter(cmd)
            dt = New DataTable("Cliente")

            da.Fill(dt)
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


                grdCliente.DataSource = dt
                grdCliente.CaptionText = "Clientes que ya rebasaron su límite de crédito en la célula: " & cboCelula.Celula.ToString & " (" & dt.Rows.Count.ToString & " en total)"
            Else
                grdCliente.DataSource = Nothing
                grdCliente.CaptionText = "No se encontraron registros"
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
                'cn.Dispose()
            End If
            da.Dispose()
            cmd.Dispose()
            dt.Dispose()

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

    Private Sub ConsultaCliente()
        Cursor = Cursors.WaitCursor
        Dim oConsultaCliente As New SigaMetClasses.frmConsultaCliente(_Cliente, Nuevo:=0, Usuario:=GLOBAL_IDUsuario)
        oConsultaCliente.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub tbBarra_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbBarra.ButtonClick
        Select Case e.Button.Tag.ToString()
            Case "Consultar"
                If _Cliente <> 0 Then
                    ConsultaCliente()
                End If
            Case "Refrescar"
                CargaDatos()
            Case "Cerrar"
                Me.Close()
        End Select
    End Sub


    Private Sub grdCliente_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCliente.CurrentCellChanged
        Try
            grdCliente.Select(grdCliente.CurrentRowIndex)
            _Cliente = CType(grdCliente.Item(grdCliente.CurrentRowIndex, 0), Integer)
        Catch
            _Cliente = 0
        End Try

    End Sub

    Private Sub btnCerrar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar2.Click
        Me.Close()
    End Sub
End Class
