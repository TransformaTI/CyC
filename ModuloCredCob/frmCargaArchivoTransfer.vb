Public Class frmCargaArchivoTransfer
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
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblBanco As ControlesBase.LabelBase
    Friend WithEvents btnAceptar As ControlesBase.BotonBase
    Friend WithEvents btnCancelar As ControlesBase.BotonBase
    Friend WithEvents lblNombreArchivo As ControlesBase.LabelBase
    Friend WithEvents btnArchivo As ControlesBase.BotonBase
    Friend WithEvents cboBanco As System.Windows.Forms.ComboBox
    Friend WithEvents txtNombreArchivo As ControlesBase.TextBoxBase
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCargaArchivoTransfer))
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.cboBanco = New System.Windows.Forms.ComboBox()
        Me.lblBanco = New ControlesBase.LabelBase()
        Me.txtNombreArchivo = New ControlesBase.TextBoxBase()
        Me.btnAceptar = New ControlesBase.BotonBase()
        Me.btnCancelar = New ControlesBase.BotonBase()
        Me.lblNombreArchivo = New ControlesBase.LabelBase()
        Me.btnArchivo = New ControlesBase.BotonBase()
        Me.SuspendLayout()
        '
        'cboBanco
        '
        Me.cboBanco.Location = New System.Drawing.Point(72, 40)
        Me.cboBanco.Name = "cboBanco"
        Me.cboBanco.Size = New System.Drawing.Size(112, 21)
        Me.cboBanco.TabIndex = 2
        '
        'lblBanco
        '
        Me.lblBanco.AutoSize = True
        Me.lblBanco.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBanco.Location = New System.Drawing.Point(16, 43)
        Me.lblBanco.Name = "lblBanco"
        Me.lblBanco.Size = New System.Drawing.Size(43, 14)
        Me.lblBanco.TabIndex = 1
        Me.lblBanco.Text = "Banco:"
        '
        'txtNombreArchivo
        '
        Me.txtNombreArchivo.Location = New System.Drawing.Point(72, 16)
        Me.txtNombreArchivo.Name = "txtNombreArchivo"
        Me.txtNombreArchivo.Size = New System.Drawing.Size(296, 21)
        Me.txtNombreArchivo.TabIndex = 0
        Me.txtNombreArchivo.Text = ""
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(424, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(424, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNombreArchivo
        '
        Me.lblNombreArchivo.AutoSize = True
        Me.lblNombreArchivo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreArchivo.Location = New System.Drawing.Point(16, 19)
        Me.lblNombreArchivo.Name = "lblNombreArchivo"
        Me.lblNombreArchivo.Size = New System.Drawing.Size(51, 14)
        Me.lblNombreArchivo.TabIndex = 5
        Me.lblNombreArchivo.Text = "Archivo:"
        '
        'btnArchivo
        '
        Me.btnArchivo.Location = New System.Drawing.Point(376, 16)
        Me.btnArchivo.Name = "btnArchivo"
        Me.btnArchivo.Size = New System.Drawing.Size(24, 21)
        Me.btnArchivo.TabIndex = 1
        Me.btnArchivo.Text = "..."
        '
        'frmCargaArchivoTransfer
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(512, 109)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnArchivo, Me.btnCancelar, Me.btnAceptar, Me.txtNombreArchivo, Me.lblBanco, Me.cboBanco, Me.lblNombreArchivo})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmCargaArchivoTransfer"
        Me.Text = "Carga de archivo de transferencia"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnArchivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArchivo.Click
        OpenFileDialog.ShowDialog()
        txtNombreArchivo.Text = OpenFileDialog.FileName
    End Sub

    Private Sub frmCargaArchivoTransfer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Dispose()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

    End Sub
End Class