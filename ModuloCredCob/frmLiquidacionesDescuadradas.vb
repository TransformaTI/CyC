Imports System.Data.SqlClient
Public Class frmLiquidacionesDescuadradas
    Inherits System.Windows.Forms.Form
    Private _AnoAtt As Short
    Private _Folio As Integer

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
    Friend WithEvents grdLiquidacion As System.Windows.Forms.DataGrid
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents imgLista16 As System.Windows.Forms.ImageList
    Friend WithEvents btnRefrescar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents tbBarra As System.Windows.Forms.ToolBar
    Friend WithEvents btnConsultarFolio As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSep2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents Estilo1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colAnoAtt As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFolio As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFInicioRuta As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFTerminoRuta As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colStatusLogistica As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colImporteContado As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents btnCerrar2 As System.Windows.Forms.Button
    Friend WithEvents colPedidoContado As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colImporteCredito As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colPedidoCredito As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmLiquidacionesDescuadradas))
        Me.grdLiquidacion = New System.Windows.Forms.DataGrid()
        Me.tbBarra = New System.Windows.Forms.ToolBar()
        Me.btnConsultarFolio = New System.Windows.Forms.ToolBarButton()
        Me.btnSep1 = New System.Windows.Forms.ToolBarButton()
        Me.btnRefrescar = New System.Windows.Forms.ToolBarButton()
        Me.btnSep2 = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.imgLista16 = New System.Windows.Forms.ImageList(Me.components)
        Me.StatusBar1 = New System.Windows.Forms.StatusBar()
        Me.Estilo1 = New System.Windows.Forms.DataGridTableStyle()
        Me.colAnoAtt = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFolio = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFInicioRuta = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFTerminoRuta = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colStatusLogistica = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colImporteContado = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.btnCerrar2 = New System.Windows.Forms.Button()
        Me.colPedidoContado = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colImporteCredito = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colPedidoCredito = New System.Windows.Forms.DataGridTextBoxColumn()
        CType(Me.grdLiquidacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdLiquidacion
        '
        Me.grdLiquidacion.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdLiquidacion.CaptionBackColor = System.Drawing.Color.OrangeRed
        Me.grdLiquidacion.CaptionText = "Liquidaciones descuadradas"
        Me.grdLiquidacion.DataMember = ""
        Me.grdLiquidacion.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdLiquidacion.Location = New System.Drawing.Point(0, 40)
        Me.grdLiquidacion.Name = "grdLiquidacion"
        Me.grdLiquidacion.ReadOnly = True
        Me.grdLiquidacion.Size = New System.Drawing.Size(600, 344)
        Me.grdLiquidacion.TabIndex = 0
        Me.grdLiquidacion.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.Estilo1})
        '
        'tbBarra
        '
        Me.tbBarra.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbBarra.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnConsultarFolio, Me.btnSep1, Me.btnRefrescar, Me.btnSep2, Me.btnCerrar})
        Me.tbBarra.DropDownArrows = True
        Me.tbBarra.ImageList = Me.imgLista16
        Me.tbBarra.Name = "tbBarra"
        Me.tbBarra.ShowToolTips = True
        Me.tbBarra.Size = New System.Drawing.Size(600, 39)
        Me.tbBarra.TabIndex = 1
        '
        'btnConsultarFolio
        '
        Me.btnConsultarFolio.ImageIndex = 2
        Me.btnConsultarFolio.Tag = "ConsultarFolio"
        Me.btnConsultarFolio.Text = "Consultar"
        Me.btnConsultarFolio.ToolTipText = "Consulta el folio seleccionado"
        '
        'btnSep1
        '
        Me.btnSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnRefrescar
        '
        Me.btnRefrescar.ImageIndex = 0
        Me.btnRefrescar.Tag = "Refrescar"
        Me.btnRefrescar.Text = "Refrescar"
        Me.btnRefrescar.ToolTipText = "Refrescar información"
        '
        'btnSep2
        '
        Me.btnSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnCerrar
        '
        Me.btnCerrar.ImageIndex = 1
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
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 391)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(600, 22)
        Me.StatusBar1.TabIndex = 2
        Me.StatusBar1.Text = "Liquidaciones descuadradas"
        '
        'Estilo1
        '
        Me.Estilo1.DataGrid = Me.grdLiquidacion
        Me.Estilo1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colAnoAtt, Me.colFolio, Me.colFInicioRuta, Me.colFTerminoRuta, Me.colStatusLogistica, Me.colImporteContado, Me.colPedidoContado, Me.colImporteCredito, Me.colPedidoCredito})
        Me.Estilo1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.Estilo1.MappingName = "Liquidacion"
        Me.Estilo1.ReadOnly = True
        '
        'colAnoAtt
        '
        Me.colAnoAtt.Format = ""
        Me.colAnoAtt.FormatInfo = Nothing
        Me.colAnoAtt.HeaderText = "Año"
        Me.colAnoAtt.MappingName = "AñoAtt"
        Me.colAnoAtt.Width = 75
        '
        'colFolio
        '
        Me.colFolio.Format = ""
        Me.colFolio.FormatInfo = Nothing
        Me.colFolio.HeaderText = "Folio"
        Me.colFolio.MappingName = "Folio"
        Me.colFolio.Width = 75
        '
        'colFInicioRuta
        '
        Me.colFInicioRuta.Format = ""
        Me.colFInicioRuta.FormatInfo = Nothing
        Me.colFInicioRuta.HeaderText = "F. Inicio ruta"
        Me.colFInicioRuta.MappingName = "FInicioRuta"
        Me.colFInicioRuta.Width = 140
        '
        'colFTerminoRuta
        '
        Me.colFTerminoRuta.Format = ""
        Me.colFTerminoRuta.FormatInfo = Nothing
        Me.colFTerminoRuta.HeaderText = "F. Término ruta"
        Me.colFTerminoRuta.MappingName = "FTerminoRuta"
        Me.colFTerminoRuta.Width = 140
        '
        'colStatusLogistica
        '
        Me.colStatusLogistica.Format = ""
        Me.colStatusLogistica.FormatInfo = Nothing
        Me.colStatusLogistica.HeaderText = "Estatus"
        Me.colStatusLogistica.MappingName = "StatusLogistica"
        Me.colStatusLogistica.Width = 75
        '
        'colImporteContado
        '
        Me.colImporteContado.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colImporteContado.Format = "#,##.00"
        Me.colImporteContado.FormatInfo = Nothing
        Me.colImporteContado.HeaderText = "Importe contado"
        Me.colImporteContado.MappingName = "ImporteContado"
        Me.colImporteContado.Width = 110
        '
        'btnCerrar2
        '
        Me.btnCerrar2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar2.Location = New System.Drawing.Point(456, 16)
        Me.btnCerrar2.Name = "btnCerrar2"
        Me.btnCerrar2.Size = New System.Drawing.Size(16, 16)
        Me.btnCerrar2.TabIndex = 3
        Me.btnCerrar2.Text = "Button1"
        '
        'colPedidoContado
        '
        Me.colPedidoContado.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colPedidoContado.Format = "#,##.00"
        Me.colPedidoContado.FormatInfo = Nothing
        Me.colPedidoContado.HeaderText = "Pedidos a contado"
        Me.colPedidoContado.MappingName = "PedidoContado"
        Me.colPedidoContado.Width = 110
        '
        'colImporteCredito
        '
        Me.colImporteCredito.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colImporteCredito.Format = "#,##.00"
        Me.colImporteCredito.FormatInfo = Nothing
        Me.colImporteCredito.HeaderText = "Importe crédito"
        Me.colImporteCredito.MappingName = "ImporteCredito"
        Me.colImporteCredito.Width = 110
        '
        'colPedidoCredito
        '
        Me.colPedidoCredito.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colPedidoCredito.Format = "#,##.00"
        Me.colPedidoCredito.FormatInfo = Nothing
        Me.colPedidoCredito.HeaderText = "Pedidos a crédito"
        Me.colPedidoCredito.MappingName = "PedidoCredito"
        Me.colPedidoCredito.Width = 110
        '
        'frmLiquidacionesDescuadradas
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCerrar2
        Me.ClientSize = New System.Drawing.Size(600, 413)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.StatusBar1, Me.tbBarra, Me.grdLiquidacion, Me.btnCerrar2})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmLiquidacionesDescuadradas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Liquidaciones descuadradas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.grdLiquidacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub tbBarra_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbBarra.ButtonClick
        Select Case e.Button.Tag.ToString()
            Case Is = "ConsultarFolio"
                If _AnoAtt <> 0 And _Folio <> 0 Then
                    Cursor = Cursors.WaitCursor
                    Dim frmConsultaAtt As New SigaMetClasses.ConsultaATT(_AnoAtt, _Folio)
                    frmConsultaAtt.ShowDialog()
                    Cursor = Cursors.Default
                End If
            Case Is = "Refrescar"
                CargaDatos()
            Case Is = "Cerrar"
                Me.Close()
        End Select
    End Sub

    Private Sub CargaDatos()
        Cursor = Cursors.WaitCursor
        Dim strQuery As String = "set transaction isolation level read uncommitted Select * from vwDifLiqPed"
        'Dim da As New SqlDataAdapter(strQuery, SigaMetClasses.LeeInfoConexion(False))
        Dim da As New SqlDataAdapter(strQuery, GLOBAL_connection)
        Try
            Dim dt As New DataTable("Liquidacion")
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                grdLiquidacion.DataSource = dt
            End If
            grdLiquidacion.CaptionText = "Liquidaciones descuadradas (" & dt.Rows.Count.ToString & " en total)"
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            da.Dispose()
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub frmLiquidacionesDescuadradas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargaDatos()
    End Sub

    Private Sub btnCerrar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar2.Click
        Me.Close()
    End Sub

    
    Private Sub grdLiquidacion_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdLiquidacion.CurrentCellChanged
        grdLiquidacion.Select(grdLiquidacion.CurrentRowIndex)
        _AnoAtt = CType(grdLiquidacion.Item(grdLiquidacion.CurrentRowIndex, 0), Short)
        _Folio = CType(grdLiquidacion.Item(grdLiquidacion.CurrentRowIndex, 1), Integer)
    End Sub
End Class
