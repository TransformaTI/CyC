Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared


Public Class frmConsultaReporte
    Inherits System.Windows.Forms.Form
    Private rptReporte As New ReportDocument()
    Private _TablaReporte As Table
    Private _LogonInfo As TableLogOnInfo

    Dim crConnectionInfo As New ConnectionInfo()

    Dim crTables As Tables
    Dim crTable As Table
    Dim crParameterValues As ParameterValues
    Dim crParameterDiscreteValue As ParameterDiscreteValue
    Dim crParameterFieldDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Private Titulo As String = "Consulta de Reporte"

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
    Friend WithEvents crvReporte As CrystalDecisions.Windows.Forms.CrystalReportViewer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmConsultaReporte))
        Me.crvReporte = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'crvReporte
        '
        Me.crvReporte.ActiveViewIndex = -1
        'Me.crvReporte.DisplayGroupTree = False
        Me.crvReporte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvReporte.Name = "crvReporte"
        Me.crvReporte.ReportSource = Nothing
        Me.crvReporte.ShowGroupTreeButton = False
        Me.crvReporte.Size = New System.Drawing.Size(440, 301)
        Me.crvReporte.TabIndex = 0
        '
        'frmConsultaReporte
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(440, 301)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.crvReporte})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConsultaReporte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub New(ByVal TipoReporte As enumTipoReporte, _
                   ByVal Celula As Short)
        MyBase.New()
        InitializeComponent()

        Try
            Cursor = Cursors.WaitCursor
            Select Case TipoReporte
                Case enumTipoReporte.ReporteCargos
                    crvReporte.SelectionFormula = "{vwConsultaCargos.Celula} = " & Celula.ToString
                    rptReporte.Load(Main.GLOBAL_RutaReportes & "\ReporteCargos.rpt")
                    AplicaInfoConexion()
                    crvReporte.ReportSource = rptReporte
                    Me.Text = "Reporte de cargos"
                Case enumTipoReporte.CargosPendientes
                    rptReporte.Load(Main.GLOBAL_RutaReportes & "\CargosPendientes.rpt")
                    AplicaInfoConexion()
                    crvReporte.ReportSource = rptReporte
                    Me.Text = "Reporte de cargos pendientes"
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Public Sub New(ByVal TipoReporte As enumTipoReporte, _
                   ByVal PedidoReferencia As String)
        MyBase.New()
        InitializeComponent()

        Try
            Cursor = Cursors.WaitCursor
            Select Case TipoReporte
                Case enumTipoReporte.ComprobanteChequeDevuelto
                    Me.Text = "Comprobante de cheque devuelto"
                    rptReporte.Load(Main.GLOBAL_RutaReportes & "\FormatoChequeDevuelto.rpt")
                    AplicaInfoConexion()
                    'Consecutivo
                    crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFieldDefinitions.Item("@PedidoReferencia")
                    crParameterValues = crParameterFieldDefinition.CurrentValues
                    crParameterDiscreteValue = New ParameterDiscreteValue()
                    crParameterDiscreteValue.Value = PedidoReferencia
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                    crvReporte.ReportSource = rptReporte

            End Select
        Catch exLoadSaveReportException As LoadSaveReportException
            MessageBox.Show("No se pudo cargar el reporte debido al siguiente error: " & Chr(13) & _
                            exLoadSaveReportException.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Public Sub New(ByVal TipoReporte As enumTipoReporte, _
                   ByVal _Caja As Byte, _
                   ByVal _FOperacion As Date, _
                   ByVal _Folio As Integer, _
                   ByVal _Consecutivo As Integer)
        MyBase.New()
        InitializeComponent()

        Try
            Cursor = Cursors.WaitCursor
            Select Case TipoReporte
                Case enumTipoReporte.CombrobanteCaja
                    rptReporte.Load(Main.GLOBAL_RutaReportes & "\MovimientoCajaDetalle.rpt")
                    AplicaInfoConexion()
                    'Consecutivo
                    crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Consecutivo")
                    crParameterValues = crParameterFieldDefinition.CurrentValues
                    crParameterDiscreteValue = New ParameterDiscreteValue()
                    crParameterDiscreteValue.Value = _Consecutivo
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
                    'Folio
                    crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Folio")
                    crParameterValues = crParameterFieldDefinition.CurrentValues
                    crParameterDiscreteValue = New ParameterDiscreteValue()
                    crParameterDiscreteValue.Value = _Folio
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
                    'Caja
                    crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Caja")
                    crParameterValues = crParameterFieldDefinition.CurrentValues
                    crParameterDiscreteValue = New ParameterDiscreteValue()
                    crParameterDiscreteValue.Value = _Caja
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
                    'FOperacion
                    crParameterFieldDefinition = crParameterFieldDefinitions.Item("@FOperacion")
                    crParameterValues = crParameterFieldDefinition.CurrentValues
                    crParameterDiscreteValue = New ParameterDiscreteValue()
                    crParameterDiscreteValue.Value = _FOperacion
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                    crvReporte.ReportSource = rptReporte

                Case enumTipoReporte.RelacionCobranza
                    If _Caja = 0 Then
                        rptReporte.Load(Main.GLOBAL_RutaReportes & "\ReporteRelacionCobranza.rpt")
                    Else
                        rptReporte.Load(Main.GLOBAL_RutaReportes & "\ReporteRelacionCobranzaOrdRuta.rpt")
                    End If
                    AplicaInfoConexion()
                    crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Cobranza")
                    crParameterValues = crParameterFieldDefinition.CurrentValues
                    crParameterDiscreteValue = New ParameterDiscreteValue()
                    crParameterDiscreteValue.Value = _Folio
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                    crvReporte.ReportSource = rptReporte

                Case enumTipoReporte.RelacionCierre
                    rptReporte.Load(Main.GLOBAL_RutaReportes & "\ReporteCierreCobranza.rpt")
                    AplicaInfoConexion()
                    crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Cobranza")
                    crParameterValues = crParameterFieldDefinition.CurrentValues
                    crParameterDiscreteValue = New ParameterDiscreteValue()
                    crParameterDiscreteValue.Value = _Folio
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                    crvReporte.ReportSource = rptReporte

                    'Impresión de las listas de cobranza precapturadas
                Case enumTipoReporte.SolicitudCobranza
                    rptReporte.Load(Main.GLOBAL_RutaReportes & "\ReporteSolicitudCobranza.rpt")
                    AplicaInfoConexion()
                    crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Cobranza")
                    crParameterValues = crParameterFieldDefinition.CurrentValues
                    crParameterDiscreteValue = New ParameterDiscreteValue()
                    crParameterDiscreteValue.Value = _Folio
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                    crvReporte.ReportSource = rptReporte

            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Catch exLoadSaveReportException As LoadSaveReportException
            '    MessageBox.Show("No se pudo cargar el reporte debido al siguiente error: " & Chr(13) & _
            '                    exLoadSaveReportException.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    'Lista de cheques devueltos
    Public Sub New(ByVal TipoReporte As enumTipoReporte, _
               ByVal Usuario As String, _
               ByVal Fecha As DateTime)
        MyBase.New()
        InitializeComponent()

        Try
            Cursor = Cursors.WaitCursor
            Select Case TipoReporte
                Case enumTipoReporte.RelacionChequePosfechado
                    Me.Text = "Listado de cheques posfechados"
                    rptReporte.Load(Main.GLOBAL_RutaReportes & "\rptListadoChequePosfechadoUsuario.rpt")
                    AplicaInfoConexion()
                    'Usuario
                    crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Usuario")
                    crParameterValues = crParameterFieldDefinition.CurrentValues
                    crParameterDiscreteValue = New ParameterDiscreteValue()
                    crParameterDiscreteValue.Value = Usuario
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
                    'Fecha
                    crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFieldDefinitions.Item("@FAlta")
                    crParameterValues = crParameterFieldDefinition.CurrentValues
                    crParameterDiscreteValue = New ParameterDiscreteValue()
                    crParameterDiscreteValue.Value = Fecha
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                    crvReporte.ReportSource = rptReporte

            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Catch exLoadSaveReportException As LoadSaveReportException
            '    MessageBox.Show("No se pudo cargar el reporte debido al siguiente error: " & Chr(13) & _
            '                    exLoadSaveReportException.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub


    Public Sub AplicaInfoConexion()
        Dim _Usuario As String
        Dim _Password As String

        'Determinar si se usa seguridad nt

        'Modificado JAGD 130214 - Se usará la cuenta SIGAREP para las consultas de los reportes de formulario.
        'If SigaMetClasses.DataLayer.Conexion.ConnectionString.IndexOf("Integrated Security = Yes") > 0 Then
        '    Main.GLOBAL_SeguridadNT = True

        Dim oConfig As SigaMetClasses.cConfig = New SigaMetClasses.cConfig(9, GLOBAL_Corporativo, GLOBAL_Sucursal)
        _Usuario = CStr(oConfig.Parametros("UsuarioReportes")).Trim
        Dim oUsuarioReportes As New SigaMetClasses.cUserInfo()
        oUsuarioReportes.ConsultaDatosUsuarioReportes(_Usuario)
        _Password = oUsuarioReportes.Password
        'End If

        'If Not Main.GLOBAL_SeguridadNT = True Then
        '    _Usuario = Main.GLOBAL_IDUsuario
        '    _Password = Main.GLOBAL_Password
        'End If

        For Each _TablaReporte In rptReporte.Database.Tables
            _LogonInfo = _TablaReporte.LogOnInfo
            With _LogonInfo.ConnectionInfo
                .ServerName = Main.GLOBAL_Servidor
                .DatabaseName = Main.GLOBAL_Database
                .UserID = _Usuario
                .Password = _Password
            End With
            _TablaReporte.ApplyLogOnInfo(_LogonInfo)
        Next
    End Sub

    Public Enum enumTipoReporte
        CombrobanteCaja = 1
        ReporteCargos = 2
        CargosPendientes = 3
        RelacionCobranza = 4
        RelacionCierre = 5
        ComprobanteChequeDevuelto = 6
        SolicitudCobranza = 7
        RelacionChequePosfechado = 8
    End Enum

End Class
