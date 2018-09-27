Imports System.Data.SqlClient

Public Class frmCargosPendientesEmpleado
    Inherits System.Windows.Forms.Form
    Private _PedidoReferencia As String
    Private _Cliente As Integer

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
    Friend WithEvents btnConsultaDocumento As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnConsultaCliente As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton3 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnRefrescar As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton5 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents imgLista16 As System.Windows.Forms.ImageList
    Friend WithEvents grdCargoEmpleado As System.Windows.Forms.DataGrid
    Friend WithEvents stbEstatus As System.Windows.Forms.StatusBar
    Friend WithEvents styCargoEmpleado As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colEmpleadoNomina As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colEmpleadoNombre As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colPedidoReferencia As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCliente As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colClienteNombre As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFCargo As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colStatus As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colLitros As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTotal As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colSaldo As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents btnCerrar2 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCargosPendientesEmpleado))
        Me.tbrBarra = New System.Windows.Forms.ToolBar()
        Me.btnConsultaDocumento = New System.Windows.Forms.ToolBarButton()
        Me.btnConsultaCliente = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton3 = New System.Windows.Forms.ToolBarButton()
        Me.btnRefrescar = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton5 = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.imgLista16 = New System.Windows.Forms.ImageList(Me.components)
        Me.grdCargoEmpleado = New System.Windows.Forms.DataGrid()
        Me.styCargoEmpleado = New System.Windows.Forms.DataGridTableStyle()
        Me.colEmpleadoNomina = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colEmpleadoNombre = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colPedidoReferencia = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCliente = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colClienteNombre = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFCargo = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colStatus = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colLitros = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTotal = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colSaldo = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.stbEstatus = New System.Windows.Forms.StatusBar()
        Me.btnCerrar2 = New System.Windows.Forms.Button()
        CType(Me.grdCargoEmpleado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbrBarra
        '
        Me.tbrBarra.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbrBarra.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnConsultaDocumento, Me.btnConsultaCliente, Me.ToolBarButton3, Me.btnRefrescar, Me.ToolBarButton5, Me.btnCerrar})
        Me.tbrBarra.DropDownArrows = True
        Me.tbrBarra.ImageList = Me.imgLista16
        Me.tbrBarra.Name = "tbrBarra"
        Me.tbrBarra.ShowToolTips = True
        Me.tbrBarra.Size = New System.Drawing.Size(592, 25)
        Me.tbrBarra.TabIndex = 1
        '
        'btnConsultaDocumento
        '
        Me.btnConsultaDocumento.Enabled = False
        Me.btnConsultaDocumento.ImageIndex = 0
        Me.btnConsultaDocumento.Tag = "ConsultaDocumento"
        Me.btnConsultaDocumento.ToolTipText = "Consulta el documento seleccionado"
        '
        'btnConsultaCliente
        '
        Me.btnConsultaCliente.Enabled = False
        Me.btnConsultaCliente.ImageIndex = 1
        Me.btnConsultaCliente.Tag = "ConsultaCliente"
        Me.btnConsultaCliente.ToolTipText = "Consulta el cliente seleccionado"
        '
        'ToolBarButton3
        '
        Me.ToolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnRefrescar
        '
        Me.btnRefrescar.ImageIndex = 2
        Me.btnRefrescar.Tag = "Refrescar"
        Me.btnRefrescar.ToolTipText = "Refrescar la información"
        '
        'ToolBarButton5
        '
        Me.ToolBarButton5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnCerrar
        '
        Me.btnCerrar.ImageIndex = 3
        Me.btnCerrar.Tag = "Cerrar"
        Me.btnCerrar.ToolTipText = "Cerrar"
        '
        'imgLista16
        '
        Me.imgLista16.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgLista16.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgLista16.ImageStream = CType(resources.GetObject("imgLista16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLista16.TransparentColor = System.Drawing.Color.Transparent
        '
        'grdCargoEmpleado
        '
        Me.grdCargoEmpleado.AlternatingBackColor = System.Drawing.Color.Lavender
        Me.grdCargoEmpleado.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdCargoEmpleado.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdCargoEmpleado.BackgroundColor = System.Drawing.Color.LightGray
        Me.grdCargoEmpleado.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grdCargoEmpleado.CaptionBackColor = System.Drawing.Color.LightSteelBlue
        Me.grdCargoEmpleado.CaptionFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdCargoEmpleado.CaptionForeColor = System.Drawing.Color.MidnightBlue
        Me.grdCargoEmpleado.DataMember = ""
        Me.grdCargoEmpleado.FlatMode = True
        Me.grdCargoEmpleado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.grdCargoEmpleado.ForeColor = System.Drawing.Color.MidnightBlue
        Me.grdCargoEmpleado.GridLineColor = System.Drawing.Color.Gainsboro
        Me.grdCargoEmpleado.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None
        Me.grdCargoEmpleado.HeaderBackColor = System.Drawing.Color.MidnightBlue
        Me.grdCargoEmpleado.HeaderFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.grdCargoEmpleado.HeaderForeColor = System.Drawing.Color.WhiteSmoke
        Me.grdCargoEmpleado.LinkColor = System.Drawing.Color.Teal
        Me.grdCargoEmpleado.Location = New System.Drawing.Point(0, 32)
        Me.grdCargoEmpleado.Name = "grdCargoEmpleado"
        Me.grdCargoEmpleado.ParentRowsBackColor = System.Drawing.Color.Gainsboro
        Me.grdCargoEmpleado.ParentRowsForeColor = System.Drawing.Color.MidnightBlue
        Me.grdCargoEmpleado.ReadOnly = True
        Me.grdCargoEmpleado.SelectionBackColor = System.Drawing.Color.CadetBlue
        Me.grdCargoEmpleado.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        Me.grdCargoEmpleado.Size = New System.Drawing.Size(592, 328)
        Me.grdCargoEmpleado.TabIndex = 2
        Me.grdCargoEmpleado.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.styCargoEmpleado})
        '
        'styCargoEmpleado
        '
        Me.styCargoEmpleado.BackColor = System.Drawing.Color.Lavender
        Me.styCargoEmpleado.DataGrid = Me.grdCargoEmpleado
        Me.styCargoEmpleado.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colEmpleadoNomina, Me.colEmpleadoNombre, Me.colPedidoReferencia, Me.colCliente, Me.colClienteNombre, Me.colFCargo, Me.colStatus, Me.colLitros, Me.colTotal, Me.colSaldo})
        Me.styCargoEmpleado.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.styCargoEmpleado.MappingName = "CargoEmpleado"
        Me.styCargoEmpleado.RowHeadersVisible = False
        '
        'colEmpleadoNomina
        '
        Me.colEmpleadoNomina.Format = ""
        Me.colEmpleadoNomina.FormatInfo = Nothing
        Me.colEmpleadoNomina.HeaderText = "Empleado"
        Me.colEmpleadoNomina.MappingName = "EmpleadoNomina"
        Me.colEmpleadoNomina.Width = 75
        '
        'colEmpleadoNombre
        '
        Me.colEmpleadoNombre.Format = ""
        Me.colEmpleadoNombre.FormatInfo = Nothing
        Me.colEmpleadoNombre.HeaderText = "Nombre del empleado"
        Me.colEmpleadoNombre.MappingName = "EmpleadoNombre"
        Me.colEmpleadoNombre.Width = 170
        '
        'colPedidoReferencia
        '
        Me.colPedidoReferencia.Format = ""
        Me.colPedidoReferencia.FormatInfo = Nothing
        Me.colPedidoReferencia.HeaderText = "Documento"
        Me.colPedidoReferencia.MappingName = "PedidoReferencia"
        Me.colPedidoReferencia.Width = 90
        '
        'colCliente
        '
        Me.colCliente.Format = ""
        Me.colCliente.FormatInfo = Nothing
        Me.colCliente.HeaderText = "Cliente"
        Me.colCliente.MappingName = "Cliente"
        Me.colCliente.Width = 75
        '
        'colClienteNombre
        '
        Me.colClienteNombre.Format = ""
        Me.colClienteNombre.FormatInfo = Nothing
        Me.colClienteNombre.HeaderText = "Nombre"
        Me.colClienteNombre.MappingName = "Nombre"
        Me.colClienteNombre.Width = 180
        '
        'colFCargo
        '
        Me.colFCargo.Format = ""
        Me.colFCargo.FormatInfo = Nothing
        Me.colFCargo.HeaderText = "F.Cargo"
        Me.colFCargo.MappingName = "FCargo"
        Me.colFCargo.Width = 75
        '
        'colStatus
        '
        Me.colStatus.Format = ""
        Me.colStatus.FormatInfo = Nothing
        Me.colStatus.HeaderText = "Estatus"
        Me.colStatus.MappingName = "Status"
        Me.colStatus.Width = 75
        '
        'colLitros
        '
        Me.colLitros.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colLitros.Format = "#,##.00"
        Me.colLitros.FormatInfo = Nothing
        Me.colLitros.HeaderText = "Litros"
        Me.colLitros.MappingName = "Litros"
        Me.colLitros.Width = 75
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
        'colSaldo
        '
        Me.colSaldo.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colSaldo.Format = "#,##.00"
        Me.colSaldo.FormatInfo = Nothing
        Me.colSaldo.HeaderText = "Saldo"
        Me.colSaldo.MappingName = "Saldo"
        Me.colSaldo.Width = 75
        '
        'stbEstatus
        '
        Me.stbEstatus.Location = New System.Drawing.Point(0, 359)
        Me.stbEstatus.Name = "stbEstatus"
        Me.stbEstatus.Size = New System.Drawing.Size(592, 22)
        Me.stbEstatus.TabIndex = 3
        Me.stbEstatus.Text = "Cargos pendientes de empleado"
        '
        'btnCerrar2
        '
        Me.btnCerrar2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar2.Location = New System.Drawing.Point(160, 8)
        Me.btnCerrar2.Name = "btnCerrar2"
        Me.btnCerrar2.Size = New System.Drawing.Size(8, 8)
        Me.btnCerrar2.TabIndex = 4
        '
        'frmCargosPendientesEmpleado
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCerrar2
        Me.ClientSize = New System.Drawing.Size(592, 381)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.stbEstatus, Me.grdCargoEmpleado, Me.tbrBarra, Me.btnCerrar2})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCargosPendientesEmpleado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cargos pendientes de empleado"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.grdCargoEmpleado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub CargaDatos()
        Cursor = Cursors.WaitCursor
        btnConsultaDocumento.Enabled = False
        btnConsultaCliente.Enabled = False

        Dim strQuery As String = "SELECT * FROM vwCYCCargosPendientesEmpleadoNomina"
        Dim da As SqlDataAdapter = Nothing
        Dim dt As DataTable = Nothing

        Try
            da = New SqlDataAdapter(strQuery, GLOBAL_connection)
            dt = New DataTable("CargoEmpleado")
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                grdCargoEmpleado.DataSource = dt
                grdCargoEmpleado.CaptionText = "Lista de cargos pendientes de empleados (" & dt.Rows.Count.ToString & " en total)"
            Else
                grdCargoEmpleado.DataSource = Nothing
                grdCargoEmpleado.CaptionText = "No existen cargos pendientes de empleados"
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            Cursor = Cursors.Default
            da.Dispose()
            dt.Dispose()

        End Try
    End Sub

    Private Sub ConsultaDocumento()
        Cursor = Cursors.WaitCursor
        Dim oConsultaDocumento As New SigaMetClasses.ConsultaCargo(_PedidoReferencia)
        oConsultaDocumento.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub ConsultaCliente()
        Cursor = Cursors.WaitCursor
        Dim oConsultaCliente As New SigaMetClasses.frmConsultaCliente(_Cliente, Nuevo:=0)
        oConsultaCliente.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub tbrBarra_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrBarra.ButtonClick
        Select Case e.Button.Tag.ToString()
            Case "ConsultaDocumento"
                ConsultaDocumento()
            Case "ConsultaCliente"
                ConsultaCliente()
            Case "Refrescar"
                CargaDatos()
            Case "Cerrar"
                Me.Close()
        End Select
    End Sub

    Private Sub frmCargosPendientesEmpleado_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargaDatos()
    End Sub

    Private Sub grdCargoEmpleado_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCargoEmpleado.CurrentCellChanged
        grdCargoEmpleado.Select(grdCargoEmpleado.CurrentRowIndex)

        Try
            _PedidoReferencia = CType(grdCargoEmpleado.Item(grdCargoEmpleado.CurrentRowIndex, 2), String).Trim
        Catch
            _PedidoReferencia = ""
        End Try

        Try
            _Cliente = CType(grdCargoEmpleado.Item(grdCargoEmpleado.CurrentRowIndex, 3), Integer)
        Catch
            _Cliente = 0
        End Try

        If _PedidoReferencia <> "" Then
            btnConsultaDocumento.Enabled = True
        Else
            btnConsultaDocumento.Enabled = False
        End If
        If _Cliente <> 0 Then
            btnConsultaCliente.Enabled = True
        Else
            btnConsultaCliente.Enabled = False
        End If

    End Sub

    Private Sub btnCerrar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar2.Click
        Me.Close()
    End Sub
End Class