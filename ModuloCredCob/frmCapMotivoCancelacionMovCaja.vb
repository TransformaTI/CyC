Imports System.Data.SqlClient
Public Class frmCapMotivoCancelacionMovCaja
    Inherits System.Windows.Forms.Form
    Private _MotivoCancelacion As Byte
    Private _TipoOperacion As SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Agregar

    Public Sub New(ByVal MotivoCancelacion As Byte)
        MyBase.New()
        InitializeComponent()
        _MotivoCancelacion = MotivoCancelacion
        _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Modificar
        CargaDatos(_MotivoCancelacion)
        Me.Text = "Modificación de motivo de cancelación"
    End Sub


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        Me.Text = "Alta de motivo de cancelación"

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
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCapMotivoCancelacionMovCaja))
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(80, 28)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(232, 21)
        Me.txtDescripcion.TabIndex = 0
        Me.txtDescripcion.Text = ""
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(328, 40)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(328, 8)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 6
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 14)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Descripción:"
        '
        'frmCapMotivoCancelacionMovCaja
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(408, 77)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.btnCancelar, Me.btnAceptar, Me.txtDescripcion})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCapMotivoCancelacionMovCaja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Motivos de cancelación"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub CargaDatos(ByVal MotivoCancelacion As Byte)
        Cursor = Cursors.WaitCursor
        Dim strQuery As String = "SELECT MotivoCancelacionMovimientoCaja, Descripcion FROM MotivoCancelacionMovimientoCaja WHERE MotivoCancelacionMovimientoCaja = " & MotivoCancelacion
        Dim da As New SqlDataAdapter(strQuery, ConString)
        Dim dt As New DataTable("MotivoCancelacion")
        Try
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                txtDescripcion.Text = CType(dt.Rows(0).Item("Descripcion"), String)
            End If
        Catch ex As Exception
            da.Dispose()
            dt.Dispose()
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub GuardaDatos()
        Dim cmd As New SqlCommand("spCYCMotivoCancelacionMCAltaModifica")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add("@Descripcion", SqlDbType.VarChar, 50).Value = Trim(txtDescripcion.Text)
            If Me._TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Modificar Then
                .Parameters.Add("@MotivoCancelacionMovimientoCaja", SqlDbType.TinyInt).Value = Me._MotivoCancelacion
                .Parameters.Add("@Alta", SqlDbType.Bit).Value = 0
            End If
        End With

        Dim cn As New SqlConnection(ConString)

        Try
            cmd.Connection = cn
            cn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Dispose()
            cmd.Dispose()
        End Try

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If MessageBox.Show(SigaMetClasses.M_ESTAN_CORRECTOS, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            GuardaDatos()
            Me.DialogResult = DialogResult.OK
        End If
    End Sub
End Class
