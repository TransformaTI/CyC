Imports System.Data.SqlClient
Public Class frmConsultaMovimientosCancelados
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents grdDatos As System.Windows.Forms.DataGrid
    Friend WithEvents stbEstatus As System.Windows.Forms.StatusBar
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents imgLista As System.Windows.Forms.ImageList
    Friend WithEvents dtpFMovimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Estilo1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colClave As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colMovimientoCajaStatus As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTotal As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCobroPedidoTotal As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTipoMovimientoCaja As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colMotivoCancelacion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFCancelacion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents btnRefrescar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents colNombreUsuarioCancelacion As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmConsultaMovimientosCancelados))
        Me.tbBarra = New System.Windows.Forms.ToolBar()
        Me.btnRefrescar = New System.Windows.Forms.ToolBarButton()
        Me.btnSep1 = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.imgLista = New System.Windows.Forms.ImageList(Me.components)
        Me.grdDatos = New System.Windows.Forms.DataGrid()
        Me.Estilo1 = New System.Windows.Forms.DataGridTableStyle()
        Me.colClave = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTipoMovimientoCaja = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colMovimientoCajaStatus = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colMotivoCancelacion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTotal = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCobroPedidoTotal = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFCancelacion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colNombreUsuarioCancelacion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.stbEstatus = New System.Windows.Forms.StatusBar()
        Me.dtpFMovimiento = New System.Windows.Forms.DateTimePicker()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbBarra
        '
        Me.tbBarra.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbBarra.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnRefrescar, Me.btnSep1, Me.btnCerrar})
        Me.tbBarra.DropDownArrows = True
        Me.tbBarra.ImageList = Me.imgLista
        Me.tbBarra.Name = "tbBarra"
        Me.tbBarra.ShowToolTips = True
        Me.tbBarra.Size = New System.Drawing.Size(624, 39)
        Me.tbBarra.TabIndex = 0
        '
        'btnRefrescar
        '
        Me.btnRefrescar.ImageIndex = 1
        Me.btnRefrescar.Tag = "Refrescar"
        Me.btnRefrescar.Text = "Refrescar"
        Me.btnRefrescar.ToolTipText = "Refrescar información"
        '
        'btnSep1
        '
        Me.btnSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnCerrar
        '
        Me.btnCerrar.ImageIndex = 0
        Me.btnCerrar.Tag = "Cerrar"
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.ToolTipText = "Cerrar"
        '
        'imgLista
        '
        Me.imgLista.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgLista.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgLista.ImageStream = CType(resources.GetObject("imgLista.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLista.TransparentColor = System.Drawing.Color.Transparent
        '
        'grdDatos
        '
        Me.grdDatos.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdDatos.CaptionBackColor = System.Drawing.Color.OrangeRed
        Me.grdDatos.CaptionText = "Lista de movimientos cancelados"
        Me.grdDatos.DataMember = ""
        Me.grdDatos.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdDatos.Location = New System.Drawing.Point(0, 48)
        Me.grdDatos.Name = "grdDatos"
        Me.grdDatos.ReadOnly = True
        Me.grdDatos.Size = New System.Drawing.Size(624, 304)
        Me.grdDatos.TabIndex = 1
        Me.grdDatos.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.Estilo1})
        '
        'Estilo1
        '
        Me.Estilo1.DataGrid = Me.grdDatos
        Me.Estilo1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colClave, Me.colTipoMovimientoCaja, Me.colMovimientoCajaStatus, Me.colMotivoCancelacion, Me.colTotal, Me.colCobroPedidoTotal, Me.colFCancelacion, Me.colNombreUsuarioCancelacion})
        Me.Estilo1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.Estilo1.MappingName = "MovCancel"
        '
        'colClave
        '
        Me.colClave.Format = ""
        Me.colClave.FormatInfo = Nothing
        Me.colClave.HeaderText = "Clave"
        Me.colClave.MappingName = "Clave"
        Me.colClave.Width = 140
        '
        'colTipoMovimientoCaja
        '
        Me.colTipoMovimientoCaja.Format = ""
        Me.colTipoMovimientoCaja.FormatInfo = Nothing
        Me.colTipoMovimientoCaja.HeaderText = "Tipo de movimiento"
        Me.colTipoMovimientoCaja.MappingName = "TipoMovimientoCajaDescripcion"
        Me.colTipoMovimientoCaja.Width = 160
        '
        'colMovimientoCajaStatus
        '
        Me.colMovimientoCajaStatus.Format = ""
        Me.colMovimientoCajaStatus.FormatInfo = Nothing
        Me.colMovimientoCajaStatus.HeaderText = "Estatus"
        Me.colMovimientoCajaStatus.MappingName = "MovimientoCajaStatus"
        Me.colMovimientoCajaStatus.Width = 75
        '
        'colMotivoCancelacion
        '
        Me.colMotivoCancelacion.Format = ""
        Me.colMotivoCancelacion.FormatInfo = Nothing
        Me.colMotivoCancelacion.HeaderText = "Motivo de cancelación"
        Me.colMotivoCancelacion.MappingName = "MotivoCancelacion"
        Me.colMotivoCancelacion.Width = 180
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
        'colCobroPedidoTotal
        '
        Me.colCobroPedidoTotal.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colCobroPedidoTotal.Format = "#,##.00"
        Me.colCobroPedidoTotal.FormatInfo = Nothing
        Me.colCobroPedidoTotal.HeaderText = "Cobranza"
        Me.colCobroPedidoTotal.MappingName = "CobroPedidoTotal"
        Me.colCobroPedidoTotal.NullText = ""
        Me.colCobroPedidoTotal.Width = 75
        '
        'colFCancelacion
        '
        Me.colFCancelacion.Format = ""
        Me.colFCancelacion.FormatInfo = Nothing
        Me.colFCancelacion.HeaderText = "F. Cancelación"
        Me.colFCancelacion.MappingName = "FCancelacion"
        Me.colFCancelacion.Width = 120
        '
        'colNombreUsuarioCancelacion
        '
        Me.colNombreUsuarioCancelacion.Format = ""
        Me.colNombreUsuarioCancelacion.FormatInfo = Nothing
        Me.colNombreUsuarioCancelacion.HeaderText = "Usuario que canceló"
        Me.colNombreUsuarioCancelacion.MappingName = "NombreUsuarioCancelacion"
        Me.colNombreUsuarioCancelacion.Width = 130
        '
        'stbEstatus
        '
        Me.stbEstatus.Location = New System.Drawing.Point(0, 359)
        Me.stbEstatus.Name = "stbEstatus"
        Me.stbEstatus.Size = New System.Drawing.Size(624, 22)
        Me.stbEstatus.TabIndex = 2
        Me.stbEstatus.Text = "Seleccione la fecha correspondiente a los movimientos cancelados que desee consul" & _
        "tar y haga clic en el botón Buscar."
        '
        'dtpFMovimiento
        '
        Me.dtpFMovimiento.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.dtpFMovimiento.Location = New System.Drawing.Point(344, 8)
        Me.dtpFMovimiento.Name = "dtpFMovimiento"
        Me.dtpFMovimiento.TabIndex = 3
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Bitmap)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(552, 8)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(64, 21)
        Me.btnBuscar.TabIndex = 4
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(264, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 14)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "F. Movimiento:"
        '
        'frmConsultaMovimientosCancelados
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(624, 381)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.btnBuscar, Me.dtpFMovimiento, Me.stbEstatus, Me.grdDatos, Me.tbBarra})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConsultaMovimientosCancelados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de movimientos cancelados"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub CargaDatos(ByVal FMovimiento As Date)
        Cursor = Cursors.WaitCursor
        Dim cmd As New SqlCommand("spReporteMovimientosCancelados")
        With cmd
            .CommandTimeout = 180
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add("@FMovimiento1", SqlDbType.DateTime).Value = FMovimiento
            .Parameters.Add("@FMovimiento2", SqlDbType.DateTime).Value = FMovimiento
        End With

        Dim cn As SqlConnection = Nothing

        Try
            'cn = New SqlConnection(SigaMetClasses.LeeInfoConexion(False))
            cn = GLOBAL_connection
            cmd.Connection = cn
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable("MovCancel")
            da.Fill(dt)


            grdDatos.DataSource = dt
            grdDatos.CaptionText = "Lista de movimientos cancelados (" & dt.Rows.Count.ToString & " en total)"

        Catch ex As Exception
            
            MessageBox.Show(Me.Name, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            'cn.Dispose()
            cmd.Dispose()
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        CargaDatos(dtpFMovimiento.Value.Date)
    End Sub

    Private Sub frmConsultaMovimientosCancelados_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpFMovimiento.Value = FechaOperacion.Date
        CargaDatos(dtpFMovimiento.Value.Date)
    End Sub

    Private Sub tbBarra_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbBarra.ButtonClick
        Select Case e.Button.Tag.ToString()
            Case Is = "Refrescar"
                CargaDatos(dtpFMovimiento.Value.Date)
            Case Is = "Cerrar"
                Me.Close()
        End Select
    End Sub

    Private Sub grdDatos_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDatos.CurrentCellChanged
        grdDatos.Select(grdDatos.CurrentRowIndex)
    End Sub
End Class
