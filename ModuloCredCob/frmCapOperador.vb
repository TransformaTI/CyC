Public Class frmCapOperador
    Inherits System.Windows.Forms.Form
    Private _Operador As Short
    Private _MaxImporteCredito As Decimal
    Private _MaxLitrosCredito As Integer
    Private _MaxDiasCredito As Short
    Private Titulo As String = "Datos de crédito del operador"

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Operador As Short, _
                   ByVal TipoOperador As String, _
                   ByVal Nombre As String, _
                   ByVal MaxImporteCredito As Decimal, _
                   ByVal MaxLitrosCredito As Integer, _
                   ByVal MaxDiasCredito As Short)

        MyBase.New()
        InitializeComponent()

        _Operador = Operador
        _MaxImporteCredito = MaxImporteCredito
        _MaxLitrosCredito = MaxLitrosCredito
        _MaxDiasCredito = MaxDiasCredito

        lblOperador.Text = Operador.ToString & " " & Nombre
        lblTipoOperador.Text = TipoOperador
        lblMaxImporteCredito.Text = MaxImporteCredito.ToString("N")
        txtMaxLitrosCredito.Text = MaxLitrosCredito.ToString
        txtMaxDiasCredito.Text = MaxDiasCredito.ToString

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
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblOperador As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtMaxLitrosCredito As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtMaxDiasCredito As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblTipoOperador As System.Windows.Forms.Label
    Friend WithEvents lblMaxImporteCredito As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCapOperador))
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblOperador = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtMaxLitrosCredito = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.txtMaxDiasCredito = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblTipoOperador = New System.Windows.Forms.Label()
        Me.lblMaxImporteCredito = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(136, 176)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 4
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(224, 176)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 139)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(138, 14)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Importe máximo a crédito:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(137, 14)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Máximo de litros a crédito:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(133, 14)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Máximo de días a crédito:"
        '
        'lblOperador
        '
        Me.lblOperador.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOperador.Location = New System.Drawing.Point(112, 16)
        Me.lblOperador.Name = "lblOperador"
        Me.lblOperador.Size = New System.Drawing.Size(312, 21)
        Me.lblOperador.TabIndex = 10
        Me.lblOperador.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 14)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Operador:"
        '
        'txtMaxLitrosCredito
        '
        Me.txtMaxLitrosCredito.Location = New System.Drawing.Point(160, 88)
        Me.txtMaxLitrosCredito.Name = "txtMaxLitrosCredito"
        Me.txtMaxLitrosCredito.Size = New System.Drawing.Size(128, 21)
        Me.txtMaxLitrosCredito.TabIndex = 2
        Me.txtMaxLitrosCredito.Text = ""
        '
        'txtMaxDiasCredito
        '
        Me.txtMaxDiasCredito.Location = New System.Drawing.Point(160, 112)
        Me.txtMaxDiasCredito.Name = "txtMaxDiasCredito"
        Me.txtMaxDiasCredito.Size = New System.Drawing.Size(128, 21)
        Me.txtMaxDiasCredito.TabIndex = 3
        Me.txtMaxDiasCredito.Text = ""
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 14)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Tipo de operador:"
        '
        'lblTipoOperador
        '
        Me.lblTipoOperador.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoOperador.Location = New System.Drawing.Point(112, 40)
        Me.lblTipoOperador.Name = "lblTipoOperador"
        Me.lblTipoOperador.Size = New System.Drawing.Size(312, 21)
        Me.lblTipoOperador.TabIndex = 12
        Me.lblTipoOperador.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMaxImporteCredito
        '
        Me.lblMaxImporteCredito.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMaxImporteCredito.Location = New System.Drawing.Point(160, 136)
        Me.lblMaxImporteCredito.Name = "lblMaxImporteCredito"
        Me.lblMaxImporteCredito.Size = New System.Drawing.Size(128, 21)
        Me.lblMaxImporteCredito.TabIndex = 14
        Me.lblMaxImporteCredito.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(16, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(408, 1)
        Me.Label1.TabIndex = 15
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmCapOperador
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(434, 223)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.lblMaxImporteCredito, Me.Label6, Me.lblTipoOperador, Me.txtMaxDiasCredito, Me.txtMaxLitrosCredito, Me.Label5, Me.lblOperador, Me.Label4, Me.Label3, Me.Label2, Me.btnCancelar, Me.btnAceptar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCapOperador"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Datos de crédito del operador"
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If ValidaCaptura() = True Then
            Dim objOp As New SigaMetClasses.cOperador()
            Try
                objOp.Modifica(_Operador, _MaxImporteCredito, _MaxLitrosCredito, _MaxDiasCredito)
                DialogResult = DialogResult.OK
            Catch ex As Exception
                MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                objOp = Nothing
            End Try
        End If
    End Sub

    Private Function ValidaCaptura() As Boolean
        If Trim(txtMaxLitrosCredito.Text) <> "" And IsNumeric(txtMaxLitrosCredito.Text) Then
            If Trim(txtMaxDiasCredito.Text) <> "" And IsNumeric(txtMaxDiasCredito.Text) Then
                _MaxImporteCredito = CType(lblMaxImporteCredito.Text, Decimal)
                _MaxLitrosCredito = CType(txtMaxLitrosCredito.Text, Integer)
                _MaxDiasCredito = CType(txtMaxDiasCredito.Text, Short)
                ValidaCaptura = True
            Else
                ValidaCaptura = False
                MessageBox.Show("Debe especificar el máximo de días a crédito.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else : ValidaCaptura = False
            MessageBox.Show("Debe especificar el máximo de litros a crédito.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Function

End Class
