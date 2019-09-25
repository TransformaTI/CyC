Imports System.Collections.Generic
Imports System.Linq

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
    Private _URLGateway As String
    Private listaDireccionesEntrega As List(Of RTGMCore.DireccionEntrega)
    Private _ChequeRow As DataRow
    Dim _EntregaCheque As RTGMCore.DireccionEntrega
    Private validarPeticion As Boolean
    Private listaClientesEnviados As List(Of Integer)

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

    Public Sub New(URLGateway As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCatOperador))
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
        Me.tabDatos.SuspendLayout()
        Me.SuspendLayout()
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
        '
        'BarraBotones
        '
        Me.BarraBotones.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnOperadorPedido})
        Me.BarraBotones.Size = New System.Drawing.Size(608, 42)
        '
        'Toolbar
        '
        Me.Toolbar.ImageStream = CType(resources.GetObject("Toolbar.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Toolbar.Images.SetKeyName(0, "")
        Me.Toolbar.Images.SetKeyName(1, "")
        Me.Toolbar.Images.SetKeyName(2, "")
        Me.Toolbar.Images.SetKeyName(3, "")
        Me.Toolbar.Images.SetKeyName(4, "")
        Me.Toolbar.Images.SetKeyName(5, "")
        Me.Toolbar.Images.SetKeyName(6, "")
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
        Me.ComboCelula.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboCelula.ForeColor = System.Drawing.Color.MediumBlue
        Me.ComboCelula.Location = New System.Drawing.Point(488, 8)
        Me.ComboCelula.Name = "ComboCelula"
        Me.ComboCelula.Size = New System.Drawing.Size(112, 21)
        Me.ComboCelula.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(448, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Célula:"
        '
        'btnOperadorPedido
        '
        Me.btnOperadorPedido.ImageIndex = 6
        Me.btnOperadorPedido.Name = "btnOperadorPedido"
        Me.btnOperadorPedido.Tag = "OperadorPedido"
        Me.btnOperadorPedido.Text = "Documentos"
        Me.btnOperadorPedido.ToolTipText = "Consulta los documentos cargados al operador"
        '
        'frmCatOperador
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(608, 413)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboCelula)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCatOperador"
        Me.Text = "Catálogo de operadores"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.grdDatos, 0)
        Me.Controls.SetChildIndex(Me.BarraBotones, 0)
        Me.Controls.SetChildIndex(Me.ComboCelula, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.tabDatos, 0)
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabDatos.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Public Function recargarOperadoresCRM(ByVal dtOperadores As DataTable) As DataTable
        Dim _dtOperadores As New DataTable()
        _dtOperadores = dtOperadores
        Dim direccionEntregaTemp As New RTGMCore.DireccionEntrega
        listaClientesEnviados = New List(Of Integer)
        'Dim objRTGMGateway As RTGMGateway.RTGMGateway = New RTGMGateway.RTGMGateway(GLOBAL_Modulo, ConString)
        'objRTGMGateway.URLServicio = _URLGateway
        'Dim objSolicitud As RTGMGateway.SolicitudGateway
        'Dim iteraciones As Integer = 0
        'Dim CLIENTETEMP As Integer
        'Dim direccionEntrega As RTGMCore.DireccionEntrega
        Dim dtOperModificados As New DataTable()

        Try
            Dim dwOperVista As DataView = New DataView(_dtOperadores)
            dtOperModificados = dwOperVista.ToTable(True, "Cliente")

            'If dtOperModificados.Rows.Count() > 0 Then
            Dim listaClientesDistintos As New List(Of Integer)

                For Each clienteTemp As DataRow In dtOperModificados.Rows
				direccionEntregaTemp = Nothing
				Try
					direccionEntregaTemp = listaDireccionesEntrega.FirstOrDefault(Function(x) x.IDDireccionEntrega = CType(clienteTemp("Cliente"), Integer))
				Catch ex As Exception

				End Try


				If IsNothing(direccionEntregaTemp) Then
                    If Not IsDBNull(clienteTemp("Cliente")) Then
                        listaClientesDistintos.Add(CType(clienteTemp("Cliente"), Integer))
                    End If
                End If
            Next
                Try
                    If dtOperModificados.Rows.Count > 0 Then
                        If listaClientesDistintos.Count > 0 Then
                            validarPeticion = True
                            generaListaClientes(listaClientesDistintos)
                        Else
                            llenarListaEntrega()
                        End If
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error consultando clientes: " + ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                'Dim listaClientesDistintos As New List(Of Integer)

            'For Each fila As DataRow In dtOperModificados.Rows

            '    If fila("Cliente") Is DBNull.Value OrElse fila("Cliente") Is Nothing Then
            '        'GoTo Linea1
            '        fila("Cliente") = 1
            '    End If

            '    listaClientesDistintos.Add(CType(fila("Cliente"), Integer))
            'Next

            'While listaClientesDistintos.Count <> listaDireccionesEntrega.Count And iteraciones < 20
            '    generaListaCLientes(listaClientesDistintos)
            '    iteraciones = iteraciones + 1
            'End While

            'For Each drow As DataRow In _dtOperadores.Rows
            '    Try
            '        drow("Nombre") = ""
            '        CLIENTETEMP = (CType(drow("Cliente"), Integer))

            '        DireccionEntrega = listaDireccionesEntrega.FirstOrDefault(Function(x) x.IDDireccionEntrega = CLIENTETEMP)

            '        If Not IsNothing(DireccionEntrega.Nombre) Then
            '            drow("Nombre") = DireccionEntrega.Nombre.Trim()
            '        Else
            '            drow("Nombre") = "No encontrado"
            '        End If
            '    Catch ex As Exception
            '        drow("Nombre") = "Error al buscar"
            '    End Try
            'Next
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            dtOperModificados.Clear()
        Finally
            Cursor = Cursors.Default
        End Try


        '        For Each row As DataRow In _dtOperadores.Rows

        '            If row("Cliente") Is DBNull.Value OrElse row("Cliente") Is Nothing Then
        '                GoTo Linea1
        '            End If

        '            Try
        '                If (Not String.IsNullOrEmpty(_URLGateway)) Then
        '                    objRTGMGateway = New RTGMGateway.RTGMGateway(GLOBAL_Modulo, ConString)
        '                    objRTGMGateway.URLServicio = _URLGateway
        '                    objSolicitud = New RTGMGateway.SolicitudGateway() With {
        '                        .IDCliente = CInt(row("Cliente"))}


        '                    DireccionEntrega = objRTGMGateway.buscarDireccionEntrega(objSolicitud)
        '                    If Not IsNothing(objSolicitud.Nombre) Then
        '                        row("Nombre") = objSolicitud.Nombre
        '                    Else
        '                        row("Nombre") = ""
        '                    End If
        '                End If
        '            Catch ex As Exception
        '                Throw ex
        '            End Try
Linea1:
        '        Next
        Return _dtOperadores
    End Function

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
        Dim direccionEntrega As RTGMCore.DireccionEntrega
        Dim CLIENTETEMP As Integer
        Try
            direccionEntrega = New RTGMCore.DireccionEntrega
            For Each drow In dtOperador.Rows
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

            grdDatos.DataSource = dtOperador
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

    Private Sub consultarDirecciones(ByVal idCliente As Integer)
        Dim oGateway As RTGMGateway.RTGMGateway
        Dim oSolicitud As RTGMGateway.SolicitudGateway
        Dim oDireccionEntrega As RTGMCore.DireccionEntrega
        Try

            oGateway = New RTGMGateway.RTGMGateway(CType(GLOBAL_Modulo, Byte), ConString)
            oSolicitud = New RTGMGateway.SolicitudGateway()
            oGateway.URLServicio = _URLGateway

            oSolicitud.IDCliente = idCliente
            oDireccionEntrega = oGateway.buscarDireccionEntrega(oSolicitud)

            If Not IsNothing(oDireccionEntrega) Then
                If Not IsNothing(oDireccionEntrega.Message) Then
                    oDireccionEntrega = New RTGMCore.DireccionEntrega()
                    oDireccionEntrega.IDDireccionEntrega = idCliente
                    oDireccionEntrega.Nombre = oDireccionEntrega.Message
                    listaDireccionesEntrega.Add(oDireccionEntrega)
                Else
                    listaDireccionesEntrega.Add(oDireccionEntrega)
                End If

            Else
                oDireccionEntrega = New RTGMCore.DireccionEntrega()
                oDireccionEntrega.IDDireccionEntrega = idCliente
                oDireccionEntrega.Nombre = "No se encontró cliente"
                listaDireccionesEntrega.Add(oDireccionEntrega)
            End If

        Catch ex As Exception
            oDireccionEntrega = New RTGMCore.DireccionEntrega()
            oDireccionEntrega.IDDireccionEntrega = idCliente
            oDireccionEntrega.Nombre = ex.Message
            listaDireccionesEntrega.Add(oDireccionEntrega)

        End Try
    End Sub

    Private Sub CargaGrid()
        Cursor = Cursors.WaitCursor
        Dim oOperador As New SigaMetClasses.cOperador()
        dtOperador = New DataTable()
        dtOperador = oOperador.Consulta()
        If dtOperador.Rows.Count > 0 Then
            If Not String.IsNullOrEmpty(_URLGateway) Then
                dtOperador = recargarOperadoresCRM(dtOperador)
            End If
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
        _TipoOperador = CType(grdDatos.Item(grdDatos.CurrentRowIndex, 1), String) & " / " &
                        CType(grdDatos.Item(grdDatos.CurrentRowIndex, 5), String)
        _Operador = CType(grdDatos.Item(grdDatos.CurrentRowIndex, 2), Short)
        _Nombre = CType(grdDatos.Item(grdDatos.CurrentRowIndex, 3), String)
        _MaxImporteCredito = CType(grdDatos.Item(grdDatos.CurrentRowIndex, 7), Decimal)
        _MaxLitrosCredito = CType(grdDatos.Item(grdDatos.CurrentRowIndex, 8), Integer)
        _MaxDiasCredito = CType(grdDatos.Item(grdDatos.CurrentRowIndex, 9), Short)
        grdDatos.Select(grdDatos.CurrentRowIndex)
    End Sub

    Private Sub frmCatOperador_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        listaDireccionesEntrega = New List(Of RTGMCore.DireccionEntrega)
        CargaGrid()
        ComboCelula.CargaDatos()
        If _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Modificar Then
            Me.PermiteModificar = False
            Me.PermiteConsultar = False
        End If

        Dim dtTemp As DataTable
        dtTemp = CType(grdDatos.DataSource, DataTable)
        _ChequeRow = dtTemp.Rows(grdDatos.CurrentRowIndex)

        _EntregaCheque = New RTGMCore.DireccionEntrega
        _EntregaCheque.Ruta = New RTGMCore.Ruta()
        _EntregaCheque.Nombre = _ChequeRow("Nombre").ToString()
        _EntregaCheque.IDDireccionEntrega = CType(_ChequeRow("Cliente"), Integer)
        '_EntregaCheque.Ruta.IDRuta = CType(_ChequeRow("Ruta"), Integer)
        '_EntregaCheque.Ruta.Descripcion = CType(_ChequeRow("RutaDescripcion"), String)
        _EntregaCheque.Status = CType(_ChequeRow("Status"), String)
        '_EntregaCheque.FAlta = CType(_ChequeRow("FAlta"), DateTime)
        '_EntregaCheque.Observaciones = CType(_ChequeRow("Observaciones"), String)

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
                    Dim frmConDatos As New SigaMetClasses.frmConsultaCliente(_Cliente, Nuevo:=0, Usuario:=GLOBAL_IDUsuario, _ClienteRow:=_EntregaCheque)
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

    Private Sub BarraBotones_ButtonClick_1(sender As Object, e As ToolBarButtonClickEventArgs) Handles BarraBotones.ButtonClick

    End Sub
End Class