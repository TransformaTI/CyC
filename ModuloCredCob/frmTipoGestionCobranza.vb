Imports System.Data.SqlClient
Public Class frmTipoGestionCobranza
    Inherits System.Windows.Forms.Form
    Private _TipoGestionCobranza As Byte
    Private _Descripcion As String
    Private DatosCargados As Boolean

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
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents cboTipoGestionCobranza As SigaMetClasses.Combos.ComboTipoGestionCobranza
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTipoGestionCobranza))
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.cboTipoGestionCobranza = New SigaMetClasses.Combos.ComboTipoGestionCobranza()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(160, 40)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(160, 8)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 6
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboTipoGestionCobranza
        '
        Me.cboTipoGestionCobranza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoGestionCobranza.Location = New System.Drawing.Point(8, 8)
        Me.cboTipoGestionCobranza.Name = "cboTipoGestionCobranza"
        Me.cboTipoGestionCobranza.Size = New System.Drawing.Size(144, 21)
        Me.cboTipoGestionCobranza.TabIndex = 8
        '
        'frmTipoGestionCobranza
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(242, 71)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboTipoGestionCobranza, Me.btnCancelar, Me.btnAceptar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTipoGestionCobranza"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambiar tipo de gestión de cobranza"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public ReadOnly Property TipoGestionCobranza() As Byte
        Get
            Return _TipoGestionCobranza
        End Get
    End Property

    Public ReadOnly Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
    End Property

    Public Sub New(ByVal TipoGestionCobranza As Byte)
        MyBase.New()
        InitializeComponent()
        _TipoGestionCobranza = TipoGestionCobranza
        cboTipoGestionCobranza.CargaDatos(False, True)
        DatosCargados = True
        cboTipoGestionCobranza.SelectedValue = _TipoGestionCobranza
    End Sub

    Private Sub frmTipoGestionCobranza_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not DatosCargados Then
            cboTipoGestionCobranza.CargaDatos(False, True)
            DatosCargados = True
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub cboTipoGestionCobranza_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipoGestionCobranza.SelectedValueChanged
        If DatosCargados Then
            _TipoGestionCobranza = CType(cboTipoGestionCobranza.SelectedValue, Byte)
            _Descripcion = Trim(CType(cboTipoGestionCobranza.Text, String))
        End If
    End Sub
End Class
