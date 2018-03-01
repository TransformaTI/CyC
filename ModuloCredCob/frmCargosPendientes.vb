Imports System.Data.SqlClient

Public Class frmCargosPendientes
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
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents tbBarra As System.Windows.Forms.ToolBar
    Friend WithEvents tbbImprimir As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbSep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents imgLista As System.Windows.Forms.ImageList
    Friend WithEvents grdLista As System.Windows.Forms.DataGrid
    Friend WithEvents Estilo1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colTipoPedido As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colDocumento As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCelula As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colRuta As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colAutotanque As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFolioAtt As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colStatus As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFSuministro As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colLitros As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTotal As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colAnoAtt As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents lblMensaje As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCargosPendientes))
        Me.StatusBar1 = New System.Windows.Forms.StatusBar()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.tbBarra = New System.Windows.Forms.ToolBar()
        Me.tbbImprimir = New System.Windows.Forms.ToolBarButton()
        Me.tbbSep1 = New System.Windows.Forms.ToolBarButton()
        Me.tbbCerrar = New System.Windows.Forms.ToolBarButton()
        Me.imgLista = New System.Windows.Forms.ImageList(Me.components)
        Me.grdLista = New System.Windows.Forms.DataGrid()
        Me.Estilo1 = New System.Windows.Forms.DataGridTableStyle()
        Me.colTipoPedido = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colDocumento = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCelula = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colRuta = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colAutotanque = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFolioAtt = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colStatus = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFSuministro = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colLitros = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTotal = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colAnoAtt = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.lblMensaje = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.grdLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 311)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(928, 22)
        Me.StatusBar1.TabIndex = 1
        Me.StatusBar1.Text = "Lista de documentos de crédito que no pertenecen a la cartera."
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Bitmap)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(720, 184)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.TabIndex = 2
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbBarra
        '
        Me.tbBarra.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbBarra.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.tbbImprimir, Me.tbbSep1, Me.tbbCerrar})
        Me.tbBarra.DropDownArrows = True
        Me.tbBarra.ImageList = Me.imgLista
        Me.tbBarra.Name = "tbBarra"
        Me.tbBarra.ShowToolTips = True
        Me.tbBarra.Size = New System.Drawing.Size(928, 39)
        Me.tbBarra.TabIndex = 4
        '
        'tbbImprimir
        '
        Me.tbbImprimir.ImageIndex = 0
        Me.tbbImprimir.Tag = "Imprimir"
        Me.tbbImprimir.Text = "Imprimir"
        Me.tbbImprimir.ToolTipText = "Imprimir reporte"
        '
        'tbbSep1
        '
        Me.tbbSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        Me.tbbSep1.Tag = "tbbSep1"
        '
        'tbbCerrar
        '
        Me.tbbCerrar.ImageIndex = 1
        Me.tbbCerrar.Tag = "Cerrar"
        Me.tbbCerrar.Text = "Cerrar"
        Me.tbbCerrar.ToolTipText = "Cerrar"
        '
        'imgLista
        '
        Me.imgLista.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgLista.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgLista.ImageStream = CType(resources.GetObject("imgLista.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLista.TransparentColor = System.Drawing.Color.Transparent
        '
        'grdLista
        '
        Me.grdLista.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdLista.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdLista.CaptionBackColor = System.Drawing.Color.OrangeRed
        Me.grdLista.CaptionText = "Lista de cargos pendientes"
        Me.grdLista.DataMember = ""
        Me.grdLista.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdLista.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdLista.Location = New System.Drawing.Point(8, 80)
        Me.grdLista.Name = "grdLista"
        Me.grdLista.ReadOnly = True
        Me.grdLista.Size = New System.Drawing.Size(912, 224)
        Me.grdLista.TabIndex = 0
        Me.grdLista.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.Estilo1})
        '
        'Estilo1
        '
        Me.Estilo1.DataGrid = Me.grdLista
        Me.Estilo1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.Estilo1.MappingName = "CargosPendientes"
        Me.Estilo1.ReadOnly = True
        '
        'colTipoPedido
        '
        Me.colTipoPedido.Format = ""
        Me.colTipoPedido.FormatInfo = Nothing
        Me.colTipoPedido.HeaderText = "Tipo de cargo / pedido"
        Me.colTipoPedido.MappingName = "TipoCargoTipoPedido"
        Me.colTipoPedido.Width = 180
        '
        'colDocumento
        '
        Me.colDocumento.Format = ""
        Me.colDocumento.FormatInfo = Nothing
        Me.colDocumento.HeaderText = "Documento"
        Me.colDocumento.MappingName = "PedidoReferencia"
        Me.colDocumento.Width = 90
        '
        'colCelula
        '
        Me.colCelula.Format = ""
        Me.colCelula.FormatInfo = Nothing
        Me.colCelula.HeaderText = "Célula"
        Me.colCelula.MappingName = "Celula"
        Me.colCelula.Width = 75
        '
        'colRuta
        '
        Me.colRuta.Format = ""
        Me.colRuta.FormatInfo = Nothing
        Me.colRuta.HeaderText = "Ruta"
        Me.colRuta.MappingName = "RutaSuministro"
        Me.colRuta.Width = 75
        '
        'colAutotanque
        '
        Me.colAutotanque.Format = ""
        Me.colAutotanque.FormatInfo = Nothing
        Me.colAutotanque.HeaderText = "A.T."
        Me.colAutotanque.MappingName = "Autotanque"
        Me.colAutotanque.Width = 75
        '
        'colFolioAtt
        '
        Me.colFolioAtt.Format = ""
        Me.colFolioAtt.FormatInfo = Nothing
        Me.colFolioAtt.HeaderText = "Folio"
        Me.colFolioAtt.MappingName = "FolioAtt"
        Me.colFolioAtt.NullText = ""
        Me.colFolioAtt.Width = 65
        '
        'colStatus
        '
        Me.colStatus.Format = ""
        Me.colStatus.FormatInfo = Nothing
        Me.colStatus.HeaderText = "Estatus"
        Me.colStatus.MappingName = "StatusPedido"
        Me.colStatus.Width = 75
        '
        'colFSuministro
        '
        Me.colFSuministro.Format = ""
        Me.colFSuministro.FormatInfo = Nothing
        Me.colFSuministro.HeaderText = "F.Suministro"
        Me.colFSuministro.MappingName = "FSuministro"
        Me.colFSuministro.Width = 70
        '
        'colLitros
        '
        Me.colLitros.Format = ""
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
        'colAnoAtt
        '
        Me.colAnoAtt.Format = ""
        Me.colAnoAtt.FormatInfo = Nothing
        Me.colAnoAtt.MappingName = "AñoAtt"
        Me.colAnoAtt.Width = 0
        '
        'lblMensaje
        '
        Me.lblMensaje.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblMensaje.BackColor = System.Drawing.Color.LemonChiffon
        Me.lblMensaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMensaje.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensaje.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblMensaje.Location = New System.Drawing.Point(8, 48)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(912, 21)
        Me.lblMensaje.TabIndex = 0
        Me.lblMensaje.Text = "Los documentos listados no pertenecen a la cartera de crédito debido a que no se " & _
        "han conciliado.  Favor de acudir al departamento correspondiente para su concili" & _
        "ación."
        Me.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.LemonChiffon
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Bitmap)
        Me.PictureBox1.Location = New System.Drawing.Point(16, 50)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'frmCargosPendientes
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(928, 333)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.PictureBox1, Me.tbBarra, Me.StatusBar1, Me.grdLista, Me.btnCerrar, Me.lblMensaje})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmCargosPendientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cargos pendientes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.grdLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub CargaLista()
        Cursor = Cursors.WaitCursor
        Dim strQuery As String = "Select * from vwCargosPendientes"
        Dim da As New SqlDataAdapter(strQuery, GLOBAL_connection)
        Dim dt As New DataTable("CargosPendientes")

        Try
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                grdLista.DataSource = dt
                grdLista.CaptionText &= " (" & dt.Rows.Count.ToString & ")"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub frmCargosPendientes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargaLista()
        btnCerrar.Focus()
    End Sub

    Private Sub grdLista_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdLista.CurrentCellChanged
        grdLista.Select(grdLista.CurrentRowIndex)
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub tbBarra_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbBarra.ButtonClick
        Select Case e.Button.Tag.ToString()
            Case Is = "Imprimir"
                Imprimir()

            Case Is = "Cerrar"
                Me.Close()
        End Select
    End Sub

    Private Sub Imprimir()
        Cursor = Cursors.WaitCursor
        Dim frmRep As New frmConsultaReporte(frmConsultaReporte.enumTipoReporte.CargosPendientes, 0)
        frmRep.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class
