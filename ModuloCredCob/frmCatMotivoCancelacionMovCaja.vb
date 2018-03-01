Imports System.Data.SqlClient

Public Class frmCatMotivoCancelacionMovCaja
    Inherits Catalogo.frmCatalogo
    Private _MotivoCancelacion As Byte

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
    Friend WithEvents colMotivoCancelacion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colDescripcion As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCatMotivoCancelacionMovCaja))
        Me.Estilo1 = New System.Windows.Forms.DataGridTableStyle()
        Me.colMotivoCancelacion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colDescripcion = New System.Windows.Forms.DataGridTextBoxColumn()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdDatos
        '
        Me.grdDatos.AccessibleName = "DataGrid"
        Me.grdDatos.AccessibleRole = System.Windows.Forms.AccessibleRole.Table
        Me.grdDatos.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.Estilo1})
        Me.grdDatos.Visible = True
        '
        'BarraBotones
        '
        Me.BarraBotones.Size = New System.Drawing.Size(608, 38)
        Me.BarraBotones.Visible = True
        '
        'Estilo1
        '
        Me.Estilo1.DataGrid = Me.grdDatos
        Me.Estilo1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colMotivoCancelacion, Me.colDescripcion})
        Me.Estilo1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.Estilo1.MappingName = "MotivoCancelacionMovimientoCaja"
        Me.Estilo1.ReadOnly = True
        '
        'colMotivoCancelacion
        '
        Me.colMotivoCancelacion.Format = ""
        Me.colMotivoCancelacion.FormatInfo = Nothing
        Me.colMotivoCancelacion.HeaderText = "Clave"
        Me.colMotivoCancelacion.MappingName = "MotivoCancelacionMovimientoCaja"
        Me.colMotivoCancelacion.Width = 75
        '
        'colDescripcion
        '
        Me.colDescripcion.Format = ""
        Me.colDescripcion.FormatInfo = Nothing
        Me.colDescripcion.HeaderText = "Descripción"
        Me.colDescripcion.MappingName = "Descripcion"
        Me.colDescripcion.Width = 250
        '
        'frmCatMotivoCancelacionMovCaja
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(608, 413)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grdDatos, Me.BarraBotones})
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCatMotivoCancelacionMovCaja"
        Me.Text = "Motivos de cancelación de movimientos de caja"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub CargaDatos()
        Cursor = Cursors.WaitCursor
        Dim strQuery As String = "SELECT MotivoCancelacionMovimientoCaja, Descripcion From MotivoCancelacionMovimientoCaja"
        Dim da As New SqlDataAdapter(strQuery, GLOBAL_connection)
        Dim dt As New DataTable("MotivoCancelacionMovimientoCaja")

        Try
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                grdDatos.DataSource = dt
                grdDatos.CaptionText = "Lista de motivos de cancelación de movimientos de caja (" & dt.Rows.Count.ToString & " en total)"
            End If
        Finally
            da.Dispose()
            Cursor = Cursors.Default
            _MotivoCancelacion = 0
        End Try
    End Sub

    Private Sub frmCatMotivoCancelacionMovCaja_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.PermiteImprimir = False
        Me.PermiteConsultar = False
        Me.PermiteEliminar = False
        CargaDatos()
    End Sub

    Public Overrides Sub grdDatos_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        grdDatos.Select(grdDatos.CurrentRowIndex)
        _MotivoCancelacion = CType(grdDatos.Item(grdDatos.CurrentRowIndex, 0), Byte)
    End Sub

    Public Overrides Sub BarraBotones_ButtonClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs)
        Select Case e.Button.Tag.ToString()
            Case Is = "Agregar"
                Dim oCapMotivoCancelacion As New frmCapMotivoCancelacionMovCaja()
                If oCapMotivoCancelacion.ShowDialog = DialogResult.OK Then
                    CargaDatos()
                End If

            Case Is = "Modificar"
                If _MotivoCancelacion <> 0 Then
                    Dim oCapMotivoCancelacion As New frmCapMotivoCancelacionMovCaja(_MotivoCancelacion)
                    If oCapMotivoCancelacion.ShowDialog = DialogResult.OK Then
                        CargaDatos()
                    End If
                End If

            Case Is = "Refrescar"
                CargaDatos()

            Case Is = "Cerrar"
                Me.Close()
        End Select
    End Sub

End Class
