Imports System.Data.SqlClient

Public Class frmCatTarjetaCredito
    Inherits Catalogo.frmCatalogo
    Private _Cliente As Integer
    Private Titulo As String = "Catálogo de tarjetas de crédito"

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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCatTarjetaCredito))
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdDatos
        '
        Me.grdDatos.AccessibleName = "DataGrid"
        Me.grdDatos.AccessibleRole = System.Windows.Forms.AccessibleRole.Table
        Me.grdDatos.CaptionBackColor = System.Drawing.Color.Brown
        Me.grdDatos.CaptionText = "Catálogo de tarjetas de crédito"
        '
        'BarraBotones
        '
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
        'frmCatTarjetaCredito
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(608, 413)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCatTarjetaCredito"
        Me.Text = "Catálogo de tarjetas de crédito"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabDatos.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public Sub CargaDatos()
        Cursor = Cursors.WaitCursor
        'Dim da As New SqlDataAdapter("SELECT * FROM vwTarjetaCredito ORDER BY Cliente", SigaMetClasses.LeeInfoConexion(False))
        Dim da As New SqlDataAdapter("EXEC spCyCCatalogoTarjetaCredito", SigaMetClasses.DataLayer.Conexion)
        Dim ds As New DataSet()
        Try
            da.Fill(ds, "TarjetaCredito")
            grdDatos.DataSource = ds.Tables("TarjetaCredito")
        Catch ex As Exception
            MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub frmCatTarjetaCredito_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PermiteAgregar = False
        PermiteEliminar = False
        PermiteModificar = False
        PermiteImprimir = False
        CargaDatos()
    End Sub

    Public Overrides Sub grdDatos_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not IsDBNull(grdDatos.Item(grdDatos.CurrentRowIndex, 0)) Then
            _Cliente = CType(grdDatos.Item(grdDatos.CurrentRowIndex, 0), Integer)
        Else
            _Cliente = 0
        End If
        grdDatos.Select(grdDatos.CurrentRowIndex)
    End Sub

    Private Sub BarraBotones_ButtonClick_1(sender As Object, e As ToolBarButtonClickEventArgs) Handles BarraBotones.ButtonClick
        Select Case e.Button.Tag.ToString()
            Case Is = "Consultar"
                If _Cliente > 0 And Not IsDBNull(_Cliente) Then
                    Cursor = Cursors.WaitCursor
                    Dim frmConCliente As New SigaMetClasses.frmConsultaCliente(_Cliente, Nuevo:=0, Usuario:=GLOBAL_IDUsuario)
                    frmConCliente.ShowDialog()
                    Cursor = Cursors.Default
                End If
            Case Is = "Refrescar"
                CargaDatos()
            Case Is = "Cerrar"
                Me.Close()
        End Select
    End Sub


    'Public Overrides Sub BarraBotones_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles BarraBotones.ButtonClick
    '    Select Case e.Button.Tag.ToString()
    '        Case Is = "Consultar"
    '            If _Cliente > 0 And Not IsDBNull(_Cliente) Then
    '                Cursor = Cursors.WaitCursor
    '                Dim frmConCliente As New SigaMetClasses.frmConsultaCliente(_Cliente, Nuevo:=0, Usuario:=GLOBAL_IDUsuario)
    '                frmConCliente.ShowDialog()
    '                Cursor = Cursors.Default
    '            End If
    '        Case Is = "Refrescar"
    '            CargaDatos()
    '        Case Is = "Cerrar"
    '            Me.Close()
    '    End Select
    'End Sub

End Class
