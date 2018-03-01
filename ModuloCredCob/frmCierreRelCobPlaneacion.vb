Imports System.Data.SqlClient
Public Class frmCierreRelCobPlaneacion
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
    Private _dtPedidoCobranza As DataTable

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
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblTituloRelacion As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblEmpleado As System.Windows.Forms.Label
    Friend WithEvents lblFCobranza As System.Windows.Forms.Label
    Friend WithEvents lblCobranza As System.Windows.Forms.Label
    Friend WithEvents chbValeCred As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Estilo1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents grdPedidoCobranza As System.Windows.Forms.DataGrid
    Friend WithEvents colDocumento As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCliente As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colNombre As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colGestionInicial As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colSaldo As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colGestionFinalDescripcion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFechaCompromiso As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFCargo As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colLitros As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTotal As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colEscaneado As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents txtDocumento As System.Windows.Forms.TextBox
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button

    Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCierreRelCobPlaneacion))
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblTituloRelacion = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblEmpleado = New System.Windows.Forms.Label()
        Me.lblFCobranza = New System.Windows.Forms.Label()
        Me.lblCobranza = New System.Windows.Forms.Label()
        Me.chbValeCred = New System.Windows.Forms.CheckBox()
        Me.txtDocumento = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.grdPedidoCobranza = New System.Windows.Forms.DataGrid()
        Me.Estilo1 = New System.Windows.Forms.DataGridTableStyle()
        Me.colDocumento = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCliente = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colNombre = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colGestionInicial = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colSaldo = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colGestionFinalDescripcion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFechaCompromiso = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFCargo = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colLitros = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTotal = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colEscaneado = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.grdPedidoCobranza, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(-120, 148)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 14)
        Me.Label15.TabIndex = 61
        Me.Label15.Text = "Cobranza:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTituloRelacion
        '
        Me.lblTituloRelacion.BackColor = System.Drawing.Color.RoyalBlue
        Me.lblTituloRelacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTituloRelacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloRelacion.ForeColor = System.Drawing.Color.White
        Me.lblTituloRelacion.Location = New System.Drawing.Point(8, 120)
        Me.lblTituloRelacion.Name = "lblTituloRelacion"
        Me.lblTituloRelacion.Size = New System.Drawing.Size(960, 21)
        Me.lblTituloRelacion.TabIndex = 65
        Me.lblTituloRelacion.Text = "Relación de cobranza"
        Me.lblTituloRelacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(8, 46)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(60, 13)
        Me.Label17.TabIndex = 71
        Me.Label17.Text = "Empleado:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(212, 20)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(72, 14)
        Me.Label16.TabIndex = 70
        Me.Label16.Text = "F.Cobranza:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "Cobranza:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmpleado
        '
        Me.lblEmpleado.BackColor = System.Drawing.Color.Gainsboro
        Me.lblEmpleado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpleado.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblEmpleado.Location = New System.Drawing.Point(84, 44)
        Me.lblEmpleado.Name = "lblEmpleado"
        Me.lblEmpleado.Size = New System.Drawing.Size(400, 16)
        Me.lblEmpleado.TabIndex = 68
        Me.lblEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFCobranza
        '
        Me.lblFCobranza.BackColor = System.Drawing.Color.Gainsboro
        Me.lblFCobranza.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFCobranza.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblFCobranza.Location = New System.Drawing.Point(296, 18)
        Me.lblFCobranza.Name = "lblFCobranza"
        Me.lblFCobranza.Size = New System.Drawing.Size(188, 16)
        Me.lblFCobranza.TabIndex = 67
        Me.lblFCobranza.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCobranza
        '
        Me.lblCobranza.BackColor = System.Drawing.Color.Gainsboro
        Me.lblCobranza.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCobranza.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblCobranza.Location = New System.Drawing.Point(84, 20)
        Me.lblCobranza.Name = "lblCobranza"
        Me.lblCobranza.Size = New System.Drawing.Size(108, 16)
        Me.lblCobranza.TabIndex = 66
        Me.lblCobranza.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chbValeCred
        '
        Me.chbValeCred.Location = New System.Drawing.Point(84, 88)
        Me.chbValeCred.Name = "chbValeCred"
        Me.chbValeCred.Size = New System.Drawing.Size(120, 20)
        Me.chbValeCred.TabIndex = 74
        Me.chbValeCred.Text = "Por vale de credito"
        '
        'txtDocumento
        '
        Me.txtDocumento.Location = New System.Drawing.Point(84, 68)
        Me.txtDocumento.Name = "txtDocumento"
        Me.txtDocumento.Size = New System.Drawing.Size(152, 21)
        Me.txtDocumento.TabIndex = 73
        Me.txtDocumento.Text = ""
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Bitmap)
        Me.Button1.Location = New System.Drawing.Point(240, 68)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(24, 20)
        Me.Button1.TabIndex = 72
        '
        'grdPedidoCobranza
        '
        Me.grdPedidoCobranza.CaptionVisible = False
        Me.grdPedidoCobranza.DataMember = ""
        Me.grdPedidoCobranza.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdPedidoCobranza.Location = New System.Drawing.Point(8, 144)
        Me.grdPedidoCobranza.Name = "grdPedidoCobranza"
        Me.grdPedidoCobranza.ReadOnly = True
        Me.grdPedidoCobranza.Size = New System.Drawing.Size(960, 416)
        Me.grdPedidoCobranza.TabIndex = 75
        Me.grdPedidoCobranza.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.Estilo1})
        '
        'Estilo1
        '
        Me.Estilo1.DataGrid = Me.grdPedidoCobranza
        Me.Estilo1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colDocumento, Me.colCliente, Me.colNombre, Me.colGestionInicial, Me.colSaldo, Me.colGestionFinalDescripcion, Me.colFechaCompromiso, Me.colFCargo, Me.colLitros, Me.colTotal, Me.colEscaneado})
        Me.Estilo1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.Estilo1.MappingName = "PedidoCobranza"
        Me.Estilo1.RowHeadersVisible = False
        '
        'colDocumento
        '
        Me.colDocumento.Format = ""
        Me.colDocumento.FormatInfo = Nothing
        Me.colDocumento.HeaderText = "Documento"
        Me.colDocumento.MappingName = "PedidoReferencia"
        Me.colDocumento.Width = 75
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
        Me.colNombre.Width = 200
        '
        'colGestionInicial
        '
        Me.colGestionInicial.Format = ""
        Me.colGestionInicial.FormatInfo = Nothing
        Me.colGestionInicial.HeaderText = "G. Inicial"
        Me.colGestionInicial.MappingName = "GestionInicialDescripcion"
        Me.colGestionInicial.Width = 75
        '
        'colSaldo
        '
        Me.colSaldo.Format = ""
        Me.colSaldo.FormatInfo = Nothing
        Me.colSaldo.HeaderText = "Saldo"
        Me.colSaldo.MappingName = "Saldo"
        Me.colSaldo.Width = 75
        '
        'colGestionFinalDescripcion
        '
        Me.colGestionFinalDescripcion.Format = ""
        Me.colGestionFinalDescripcion.FormatInfo = Nothing
        Me.colGestionFinalDescripcion.HeaderText = "Gestion Final"
        Me.colGestionFinalDescripcion.MappingName = "GestionFinalDescripcion"
        Me.colGestionFinalDescripcion.Width = 75
        '
        'colFechaCompromiso
        '
        Me.colFechaCompromiso.Format = ""
        Me.colFechaCompromiso.FormatInfo = Nothing
        Me.colFechaCompromiso.HeaderText = "F. Compromiso"
        Me.colFechaCompromiso.MappingName = "FCompromisoGestion"
        Me.colFechaCompromiso.Width = 75
        '
        'colFCargo
        '
        Me.colFCargo.Format = ""
        Me.colFCargo.FormatInfo = Nothing
        Me.colFCargo.HeaderText = "F. Cargo"
        Me.colFCargo.MappingName = "FCargo"
        Me.colFCargo.Width = 75
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
        Me.colTotal.Format = ""
        Me.colTotal.FormatInfo = Nothing
        Me.colTotal.HeaderText = "Total"
        Me.colTotal.MappingName = "Total"
        Me.colTotal.Width = 75
        '
        'colEscaneado
        '
        Me.colEscaneado.Format = ""
        Me.colEscaneado.FormatInfo = Nothing
        Me.colEscaneado.HeaderText = "Escaneado"
        Me.colEscaneado.MappingName = "Escaneado"
        Me.colEscaneado.Width = 75
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Bitmap)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(864, 18)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(88, 23)
        Me.btnCerrar.TabIndex = 76
        Me.btnCerrar.Text = "  &Aceptar"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancelar, Me.Label2, Me.Label1, Me.Label16, Me.Label17, Me.lblFCobranza, Me.lblCobranza, Me.lblEmpleado, Me.txtDocumento, Me.chbValeCred, Me.btnCerrar, Me.Button1})
        Me.GroupBox1.Location = New System.Drawing.Point(8, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(960, 112)
        Me.GroupBox1.TabIndex = 77
        Me.GroupBox1.TabStop = False
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(864, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(88, 23)
        Me.btnCancelar.TabIndex = 78
        Me.btnCancelar.Text = "  &Cancelar"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 14)
        Me.Label2.TabIndex = 77
        Me.Label2.Text = "Documento:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmCierreRelCobPlaneacion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(976, 566)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox1, Me.grdPedidoCobranza, Me.lblTituloRelacion, Me.Label15})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmCierreRelCobPlaneacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cierre de relación de cobranza  para planeacion"
        CType(Me.grdPedidoCobranza, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub New(ByVal dsCobranza As DataSet, _
                   ByVal Cobranza As Integer)
        MyBase.New()
        InitializeComponent()
        _dsCobranza = dsCobranza
        _Cobranza = Cobranza

        _dtCobranza = dsCobranza.Tables("Cobranza")
        _dtCobranza.DefaultView.RowFilter = "Cobranza = " & Cobranza.ToString

        _Empleado = CType(_dtCobranza.DefaultView.Item(0).Item("Empleado"), Integer)
        _EmpleadoNombre = CType(_dtCobranza.DefaultView.Item(0).Item("EmpleadoNombre"), String)
        _FCobranza = CType(_dtCobranza.DefaultView.Item(0).Item("FCobranza"), Date)

        lblCobranza.Text = _Cobranza.ToString
        lblFCobranza.Text = _FCobranza.ToLongDateString
        lblEmpleado.Text = _Empleado.ToString & " " & _EmpleadoNombre
        grdPedidoCobranza.DataSource = _dsCobranza.Tables("PedidoCobranza")
        AgregaEscaneado()
    End Sub


    Private Sub AgregaEscaneado()
        Dim colEscaneado As New DataColumn("Escaneado", System.Type.GetType("System.Boolean"))
        colEscaneado.DefaultValue = False
        Try
            _dsCobranza.Tables("PedidoCobranza").Columns.Add(colEscaneado)
        Catch ex As Exception
            MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Function BuscaDocumento(ByVal Documento As String) As Boolean
        Dim dr As DataRow
        Dim i As Integer = Nothing

        Dim foundRows As DataRow() = _dsCobranza.Tables("PedidoCobranza").Select("Cobranza = " + System.Convert.ToString(_Cobranza))
        Dim dvDocumentos As New DataView(_dsCobranza.Tables("PedidoCobranza"))
        Dim dvDocsEscaneados As New DataView(_dsCobranza.Tables("PedidoCobranza"))
        If chbValeCred.Checked Then
            dvDocumentos.RowFilter = "ValeCredito =" + Documento.Trim
            dvDocsEscaneados.RowFilter = "ValeCredito =" + Documento.Trim + " and escaneado = true and Cobranza = " + System.Convert.ToString(_Cobranza)
        Else
            dvDocumentos.RowFilter = "PedidoReferencia = '" + Documento.Trim + "'"
            dvDocsEscaneados.RowFilter = "PedidoReferencia = '" + Documento.Trim + "' and escaneado = true and Cobranza = " + System.Convert.ToString(_Cobranza)
        End If


        If dvDocsEscaneados.Count() > 0 Then 'El documento ya se había escaneado
            MessageBox.Show("El documento ya había sido capturado", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return True
        End If

        If dvDocumentos.Count() > 0 Then ' El documento no se ha escaneado
            For Each dr In foundRows
                If chbValeCred.Checked Then
                    If System.Convert.ToString(dr("ValeCredito")).Trim = Documento.Trim Then
                        SetEscaneado(Documento, _Cobranza)
                        Return True
                    End If
                Else
                    If System.Convert.ToString(dr("PedidoReferencia")).Trim = Documento.Trim Then
                        SetEscaneado(Documento, _Cobranza)
                        Return True
                    End If
                End If
            Next
        Else
            Return False
        End If
    End Function

    Private Sub SetEscaneado(ByVal Documento As String, ByVal cobranza As Integer)
        Dim dr As DataRow
        Dim i As Integer
        For Each dr In _dsCobranza.Tables("PedidoCobranza").Rows
            If chbValeCred.Checked Then
                If System.Convert.ToString(dr("ValeCredito", DataRowVersion.Original)).Trim = Documento And System.Convert.ToInt32(dr("Cobranza", DataRowVersion.Original)) = cobranza Then
                    _dsCobranza.Tables("PedidoCobranza").Rows(i).Item("Escaneado") = True
                End If
            Else
                If System.Convert.ToString(dr("PedidoReferencia", DataRowVersion.Original)).Trim = Documento And System.Convert.ToInt32(dr("Cobranza", DataRowVersion.Original)) = cobranza Then
                    _dsCobranza.Tables("PedidoCobranza").Rows(i).Item("Escaneado") = True
                End If
            End If

            i = i + 1
        Next
    End Sub

    Private Function ValidaCierreCobranza() As Boolean
        Dim dvDocumentos As New DataView(_dsCobranza.Tables("PedidoCobranza"))
        dvDocumentos.RowFilter = "Escaneado = False and Cobranza = " + System.Convert.ToString(_Cobranza)
        If dvDocumentos.Count() > 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub CierraCobranzaPlaneacion(ByVal Cobranza As Integer)
        Dim cnn As New SqlConnection()
        cnn = GLOBAL_connection

        Dim cmd As New SqlCommand("spCYCCobranzaCierra", cnn)
        Dim parCobranza As New SqlParameter("@Cobranza", SqlDbType.Int)
        parCobranza.Value = Cobranza
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add(parCobranza)

        Try
            cnn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            cnn.Close()
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtDocumento.Text <> "" Then
            If BuscaDocumento(txtDocumento.Text.Trim) = False Then
                MessageBox.Show("El documento no fue encontrado", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If
        Else
            MessageBox.Show("Por favor especifique un documento", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        txtDocumento.Text = String.Empty
        txtDocumento.Focus()
    End Sub


    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        'Procesar la nueva lista de cobranza para el cobrador / documentos no devueltos y la nueva lista de documentos devueltos
        If GLOBAL_DevDocumentosReq Then
            'Generar lista de cobranza de los documentos que fueron devueltos (Lista de cobranza para resguardo)
            Dim cobranzaDevolucion As Integer
            Dim cobranzaNoDevolucion As Integer
            Dim nCobranza As New SigaMetClasses.cCobranza()
            Try
                'Lista de cobranza para el cobrador
                cobranzaDevolucion = nCobranza.Alta(DateTime.Now.Date, 9, GLOBAL_IDUsuario, GLOBAL_IDEmpleado, _
                                        TotalDocumentosDevueltos(), "Documentos devueltos a resguardo", listaCobranzaDevolucion)
                'Lista de cobranza para ejecutivo de crédito, documentos no entregados
                If Not ValidaCierreCobranza() Then
                    cobranzaNoDevolucion = nCobranza.Alta(DateTime.Now.Date, GLOBAL_ListaDevEjecutivo, GLOBAL_IDUsuario, _Empleado, _
                                            TotalDocumentosNoDevueltos(), "Documentos no entregados", listaCobranzaNoDevueltos)
                End If
                '*****
                'Cierre de la cobranza actual
                CierraCobranzaPlaneacion(_Cobranza)
                Me.Close()
            Catch
                Dim mensaje As String
                If cobranzaDevolucion = 0 Then
                    mensaje = "Error al generar la lista de cobranza de documentos devueltos"
                Else
                    mensaje = "Error al generar la lista de cobranza para el cobrador (documentos no entregados)"
                End If
                MessageBox.Show(mensaje & vbCrLf & _
                    "Capture manualmente las listas de cobranza de documentos" & vbCrLf & _
                    "devueltos y no devueltos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                _Cierre = True
                DialogResult = DialogResult.OK
            Finally
                Dim mensaje As String = ""
                If cobranzaDevolucion > 0 Then
                    mensaje &= "Los documentos devueltos (Resguardo) fueron capturados en la lista " & cobranzaDevolucion.ToString() & vbCrLf
                End If
                If cobranzaNoDevolucion > 0 Then
                    mensaje &= "Los documentos no devueltos (Cobrador) fueron capturados en la lista " & cobranzaNoDevolucion.ToString()
                End If
                If (MessageBox.Show(mensaje & vbCrLf & _
                    "¿Desea imprimir los comprobantes?", Me.Text, MessageBoxButtons.YesNo, _
                    MessageBoxIcon.Question) = DialogResult.Yes) Then
                    imprimirComprobanteCobranza(cobranzaDevolucion)
                    imprimirComprobanteCobranza(cobranzaNoDevolucion)
                End If
            End Try
        Else
            'Generar lista de cobranza de los documentos que no fueron devueltos (Lista de cobranza para ejecutivo)
            If ValidaCierreCobranza() = False Then
                MessageBox.Show("No se han entregado todos los documentos de la relación de cobranza, por lo mismo no puede cerrarse", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                CierraCobranzaPlaneacion(_Cobranza)
                Me.Close()
            End If
        End If
    End Sub

    Private Sub txtDocumento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDocumento.TextChanged

    End Sub

    Private Sub txtDocumento_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDocumento.Enter
        txtDocumento.BackColor = Color.LightGoldenrodYellow
        txtDocumento.SelectAll()
        Me.AcceptButton = Button1
    End Sub

    Private Sub frmCierreRelCobPlaneacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDocumento.Text = String.Empty
        txtDocumento.Focus()
        Me.ActiveControl = txtDocumento

    End Sub

#Region "Control de entrada y salida de documentos"
    Dim listaCobranzaDevolucion As New ArrayList()


    Dim listaCobranzaNoDevueltos As New ArrayList()


    Private Function TotalDocumentosDevueltos() As Decimal
        Dim totalCobranzaDevolucion As Decimal
        Dim drDocumentoDevuelto As DataRow() = _dsCobranza.Tables("PedidoCobranza").Select("Escaneado = True and Cobranza = " + System.Convert.ToString(_Cobranza))
        If Convert.ToInt32(drDocumentoDevuelto.Length) > 0 Then
            Dim dr As DataRow
            For Each dr In drDocumentoDevuelto
                Dim oPedido As SigaMetClasses.sPedido
                oPedido.AnoPed = CType(dr("AñoPed"), Short)
                oPedido.Celula = CType(dr("Celula"), Byte)
                oPedido.Pedido = CType(dr("Pedido"), Integer)
                oPedido.Saldo = CType(dr("Saldo"), Decimal)
                oPedido.TipoCargo = CType(dr("TipoCargo"), Byte)
                listaCobranzaDevolucion.Add(oPedido)
                totalCobranzaDevolucion += oPedido.Saldo
            Next
        End If
        Return totalCobranzaDevolucion
    End Function

    Private Function TotalDocumentosNoDevueltos() As Decimal
        Dim totalCobranzaNoDevueltos As Decimal
        Dim drDocumentoNoDevuelto As DataRow() = _dsCobranza.Tables("PedidoCobranza").Select("Escaneado = False and Cobranza = " + System.Convert.ToString(_Cobranza))
        If Convert.ToInt32(drDocumentoNoDevuelto.Length) > 0 Then
            Dim dr As DataRow
            For Each dr In drDocumentoNoDevuelto
                Dim oPedido As SigaMetClasses.sPedido
                oPedido.AnoPed = CType(dr("AñoPed"), Short)
                oPedido.Celula = CType(dr("Celula"), Byte)
                oPedido.Pedido = CType(dr("Pedido"), Integer)
                oPedido.Saldo = CType(dr("Saldo"), Decimal)
                oPedido.TipoCargo = CType(dr("TipoCargo"), Byte)
                listaCobranzaNoDevueltos.Add(oPedido)
                totalCobranzaNoDevueltos += oPedido.Saldo
            Next
        End If
        Return totalCobranzaNoDevueltos
    End Function

#End Region

    'Imprimir el comprobante de la cobranza generada automáticamente
    Private Sub imprimirComprobanteCobranza(ByVal NuevaCobranza As Integer)
        Cursor = Cursors.WaitCursor
        Dim frmReporte As New frmConsultaReporte(frmConsultaReporte.enumTipoReporte.RelacionCobranza, 0, DateTime.Now.Date, NuevaCobranza, 0)
        frmReporte.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If MessageBox.Show("¿Desea cancelar el cierre de cobranza?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Me.DialogResult = DialogResult.No
            Me.Close()
        End If
    End Sub
End Class
