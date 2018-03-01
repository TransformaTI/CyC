Public Class frmCatOperador
    Inherits Catalogo.frmCatalogo
    Private _TipoOperacion As SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Agregar
    Private _Cliente As Integer
    Private _Operador As Short
    Private _TipoOperador As String
    Private _Nombre As String
    Private _MaxImporteCredito As Decimal
    Private _MaxLitrosCredito As Integer
    Private _MaxDiasCredito As Short
    Private dtOperador As DataTable

    Public Sub New(ByVal TipoOperacion As SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo)
        MyBase.New()
        InitializeComponent()
        _TipoOperacion = TipoOperacion
    End Sub

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
    Friend WithEvents Estilo1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colNombre As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colDescripcion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colStatus As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colMaxImporteCredito As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colMaxLitrosCredito As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colMaxDiasCredito As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCelula As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colOperador As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCategoriaOperador As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTipoOperador As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents ComboCelula As SigaMetClasses.Combos.ComboCelula
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents colCliente As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents btnOperadorPedido As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCatOperador))
        Me.Estilo1 = New System.Windows.Forms.DataGridTableStyle()
        Me.colCliente = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCategoriaOperador = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colOperador = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colNombre = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCelula = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colDescripcion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colStatus = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colMaxImporteCredito = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colMaxLitrosCredito = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colMaxDiasCredito = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTipoOperador = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.ComboCelula = New SigaMetClasses.Combos.ComboCelula()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnOperadorPedido = New System.Windows.Forms.ToolBarButton()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarraBotones
        '
        Me.BarraBotones.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnOperadorPedido})
        Me.BarraBotones.Visible = True
        '
        'tbbModificar
        '
        'Me.tbbModificar.Rectangle = New System.Drawing.Rectangle(66, 0, 66, 36)
        ''
        ''tbbRefrescar
        ''
        'Me.tbbRefrescar.Rectangle = New System.Drawing.Rectangle(346, 0, 66, 36)
        ''
        'tbbSep1
        '
        'Me.tbbSep1.Rectangle = New System.Drawing.Rectangle(264, 0, 8, 36)
        ''
        ''tbbConsultar
        ''
        'Me.tbbConsultar.Rectangle = New System.Drawing.Rectangle(198, 0, 66, 36)
        ''
        ''tbbEliminar
        ''
        'Me.tbbEliminar.Rectangle = New System.Drawing.Rectangle(132, 0, 66, 36)
        ''
        ''tbbCerrar
        ''
        'Me.tbbCerrar.Rectangle = New System.Drawing.Rectangle(420, 0, 66, 36)
        ''
        ''tbbAgregar
        ''
        'Me.tbbAgregar.Rectangle = New System.Drawing.Rectangle(0, 0, 66, 36)
        ''
        ''Toolbar
        ''
        'Me.Toolbar.ImageStream = CType(resources.GetObject("Toolbar.ImageStream"), System.Windows.Forms.ImageListStreamer)
        ''
        ''tbbSep2
        ''
        'Me.tbbSep2.Rectangle = New System.Drawing.Rectangle(338, 0, 8, 36)
        ''
        ''tbbImprimir
        ''
        'Me.tbbImprimir.Rectangle = New System.Drawing.Rectangle(272, 0, 66, 36)
        ''
        ''tbbSep3
        ''
        'Me.tbbSep3.Rectangle = New System.Drawing.Rectangle(412, 0, 8, 36)
        '
        'grdDatos
        '
        Me.grdDatos.AccessibleName = "DataGrid"
        Me.grdDatos.AccessibleRole = System.Windows.Forms.AccessibleRole.Table
        Me.grdDatos.CaptionBackColor = System.Drawing.Color.White
        Me.grdDatos.CaptionFont = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDatos.CaptionForeColor = System.Drawing.Color.Navy
        Me.grdDatos.CaptionText = "Operadores"
        Me.grdDatos.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.Estilo1})
        Me.grdDatos.Visible = True
        '
        'Estilo1
        '
        Me.Estilo1.DataGrid = Me.grdDatos
        Me.Estilo1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colCliente, Me.colCategoriaOperador, Me.colOperador, Me.colNombre, Me.colCelula, Me.colDescripcion, Me.colStatus, Me.colMaxImporteCredito, Me.colMaxLitrosCredito, Me.colMaxDiasCredito, Me.colTipoOperador})
        Me.Estilo1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.Estilo1.MappingName = "Operador"
        '
        'colCliente
        '
        Me.colCliente.Format = ""
        Me.colCliente.FormatInfo = Nothing
        Me.colCliente.HeaderText = "Cliente"
        Me.colCliente.MappingName = "Cliente"
        Me.colCliente.Width = 75
        '
        'colCategoriaOperador
        '
        Me.colCategoriaOperador.Format = ""
        Me.colCategoriaOperador.FormatInfo = Nothing
        Me.colCategoriaOperador.HeaderText = "Categoría"
        Me.colCategoriaOperador.MappingName = "CategoriaOperadorDescripcion"
        Me.colCategoriaOperador.Width = 75
        '
        'colOperador
        '
        Me.colOperador.Format = ""
        Me.colOperador.FormatInfo = Nothing
        Me.colOperador.HeaderText = "Operador"
        Me.colOperador.MappingName = "Operador"
        Me.colOperador.Width = 75
        '
        'colNombre
        '
        Me.colNombre.Format = ""
        Me.colNombre.FormatInfo = Nothing
        Me.colNombre.HeaderText = "Nombre"
        Me.colNombre.MappingName = "Nombre"
        Me.colNombre.Width = 200
        '
        'colCelula
        '
        Me.colCelula.Format = ""
        Me.colCelula.FormatInfo = Nothing
        Me.colCelula.HeaderText = "Célula"
        Me.colCelula.MappingName = "Celula"
        Me.colCelula.Width = 75
        '
        'colDescripcion
        '
        Me.colDescripcion.Format = ""
        Me.colDescripcion.FormatInfo = Nothing
        Me.colDescripcion.HeaderText = "Tipo"
        Me.colDescripcion.MappingName = "Descripcion"
        Me.colDescripcion.Width = 75
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
        Me.colMaxImporteCredito.HeaderText = "MIC"
        Me.colMaxImporteCredito.MappingName = "MaxImporteCredito"
        Me.colMaxImporteCredito.Width = 75
        '
        'colMaxLitrosCredito
        '
        Me.colMaxLitrosCredito.Format = ""
        Me.colMaxLitrosCredito.FormatInfo = Nothing
        Me.colMaxLitrosCredito.HeaderText = "MLC"
        Me.colMaxLitrosCredito.MappingName = "MaxLitrosCredito"
        Me.colMaxLitrosCredito.Width = 75
        '
        'colMaxDiasCredito
        '
        Me.colMaxDiasCredito.Format = ""
        Me.colMaxDiasCredito.FormatInfo = Nothing
        Me.colMaxDiasCredito.HeaderText = "MDC"
        Me.colMaxDiasCredito.MappingName = "MaxDiasCredito"
        Me.colMaxDiasCredito.Width = 75
        '
        'colTipoOperador
        '
        Me.colTipoOperador.Format = ""
        Me.colTipoOperador.FormatInfo = Nothing
        Me.colTipoOperador.MappingName = "TipoOperador"
        Me.colTipoOperador.Width = 0
        '
        'ComboCelula
        '
        Me.ComboCelula.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.ComboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboCelula.ForeColor = System.Drawing.Color.MediumBlue
        Me.ComboCelula.Location = New System.Drawing.Point(488, 8)
        Me.ComboCelula.Name = "ComboCelula"
        Me.ComboCelula.Size = New System.Drawing.Size(112, 21)
        Me.ComboCelula.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(448, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Célula:"
        '
        'btnOperadorPedido
        '
        Me.btnOperadorPedido.ImageIndex = 6
        Me.btnOperadorPedido.Tag = "OperadorPedido"
        Me.btnOperadorPedido.Text = "Documentos"
        Me.btnOperadorPedido.ToolTipText = "Consulta los documentos cargados al operador"
        '
        'frmCatOperador
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(608, 413)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.ComboCelula, Me.BarraBotones, Me.grdDatos})
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCatOperador"
        Me.Text = "Catálogo de operadores"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub CargaGrid()
        Cursor = Cursors.WaitCursor
        Dim oOperador As New SigaMetClasses.cOperador()
        dtOperador = New DataTable()
        dtOperador = oOperador.Consulta()
        If dtOperador.Rows.Count > 0 Then
            grdDatos.DataSource = dtOperador
            grdDatos.CaptionText = "Operadores (" & dtOperador.Rows.Count.ToString & ")"
        End If
        grdDatos.CaptionText = "Lista de operadores (" & dtOperador.Rows.Count.ToString & " en total)"
        Cursor = Cursors.Default
    End Sub

    Public Overrides Sub grdDatos_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If IsDBNull(grdDatos.Item(grdDatos.CurrentRowIndex, 0)) Then
            _Cliente = 0
        Else
            _Cliente = CType(grdDatos.Item(grdDatos.CurrentRowIndex, 0), Integer)
        End If
        _TipoOperador = CType(grdDatos.Item(grdDatos.CurrentRowIndex, 1), String) & " / " & _
                        CType(grdDatos.Item(grdDatos.CurrentRowIndex, 5), String)
        _Operador = CType(grdDatos.Item(grdDatos.CurrentRowIndex, 2), Short)
        _Nombre = CType(grdDatos.Item(grdDatos.CurrentRowIndex, 3), String)
        _MaxImporteCredito = CType(grdDatos.Item(grdDatos.CurrentRowIndex, 7), Decimal)
        _MaxLitrosCredito = CType(grdDatos.Item(grdDatos.CurrentRowIndex, 8), Integer)
        _MaxDiasCredito = CType(grdDatos.Item(grdDatos.CurrentRowIndex, 9), Short)
        grdDatos.Select(grdDatos.CurrentRowIndex)
    End Sub

    Private Sub frmCatOperador_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargaGrid()
        ComboCelula.CargaDatos()
        If _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Modificar Then
            Me.PermiteModificar = False
            Me.PermiteConsultar = False
        End If

        PermiteImprimir = False
        PermiteAgregar = False
        PermiteEliminar = False
    End Sub

    Private Sub ComboCelula_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCelula.SelectedIndexChanged
        If ComboCelula.Celula > 0 Then
            dtOperador.DefaultView.RowFilter = "Celula = " & ComboCelula.Celula
            grdDatos.CaptionText = "Operadores (" & dtOperador.DefaultView.Count & ")"
        Else
            dtOperador.DefaultView.RowFilter = ""
            grdDatos.CaptionText = "Operadores (" & dtOperador.Rows.Count.ToString & ")"
        End If
    End Sub


    Public Overrides Sub BarraBotones_ButtonClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs)
        Select Case e.Button.Tag.ToString()
            Case Is = "Modificar"
                If _Operador > 0 Then
                    Dim frmCaptura As New frmCapOperador(_Operador, _TipoOperador, _Nombre, _MaxImporteCredito, _MaxLitrosCredito, _MaxDiasCredito)
                    If frmCaptura.ShowDialog() = DialogResult.OK Then
                        CargaGrid()
                        ComboCelula.SelectedIndex = 0
                    End If
                End If
            Case Is = "Consultar"
                If _Cliente > 0 And Not IsDBNull(_Cliente) Then
                    Cursor = Cursors.WaitCursor
                    Dim frmConDatos As New SigaMetClasses.frmConsultaCliente(_Cliente)
                    frmConDatos.ShowDialog()
                    Cursor = Cursors.Default
                End If
            Case "OperadorPedido"
                If _Operador > 0 Then
                    Cursor = Cursors.WaitCursor
                    Dim oOperadorPedido As New SigaMetClasses.ConsultaOperadorPedido(_Operador)
                    oOperadorPedido.ShowDialog()
                    Cursor = Cursors.Default
                End If
            Case Is = "Refrescar"
                CargaGrid()
                ComboCelula.SelectedIndex = 0
            Case Is = "Cerrar"
                Me.Close()
        End Select
    End Sub

End Class