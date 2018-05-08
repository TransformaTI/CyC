<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCatCuentaBancariaCliente
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCatCuentaBancariaCliente))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.TSBNuevo = New System.Windows.Forms.ToolStripButton()
        Me.TSBModificar = New System.Windows.Forms.ToolStripButton()
        Me.TSBConsultar = New System.Windows.Forms.ToolStripButton()
        Me.TSBRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.TSBCerrar = New System.Windows.Forms.ToolStripButton()
        Me.Label_Cliente = New System.Windows.Forms.Label()
        Me.grd_Cliente = New System.Windows.Forms.DataGridView()
        Me.TB_DATOS = New System.Windows.Forms.TabControl()
        Me.page_Datos = New System.Windows.Forms.TabPage()
        Me.TB_Estatus = New System.Windows.Forms.TextBox()
        Me.Tb_UsuarioAlta = New System.Windows.Forms.TextBox()
        Me.Lb_Estatus = New System.Windows.Forms.Label()
        Me.Lbfecha = New System.Windows.Forms.Label()
        Me.lb_usuario = New System.Windows.Forms.Label()
        Me.Txtb_FechaAlta = New System.Windows.Forms.TextBox()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.grd_Cliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TB_DATOS.SuspendLayout()
        Me.page_Datos.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBNuevo, Me.TSBModificar, Me.TSBConsultar, Me.TSBRefrescar, Me.TSBCerrar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(787, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TSBNuevo
        '
        Me.TSBNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TSBNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBNuevo.Name = "TSBNuevo"
        Me.TSBNuevo.Size = New System.Drawing.Size(46, 22)
        Me.TSBNuevo.Text = "Nuevo"
        '
        'TSBModificar
        '
        Me.TSBModificar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TSBModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBModificar.Name = "TSBModificar"
        Me.TSBModificar.Size = New System.Drawing.Size(62, 22)
        Me.TSBModificar.Text = "Modificar"
        '
        'TSBConsultar
        '
        Me.TSBConsultar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TSBConsultar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBConsultar.Name = "TSBConsultar"
        Me.TSBConsultar.Size = New System.Drawing.Size(62, 22)
        Me.TSBConsultar.Text = "Consultar"
        '
        'TSBRefrescar
        '
        Me.TSBRefrescar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TSBRefrescar.Image = CType(resources.GetObject("TSBRefrescar.Image"), System.Drawing.Image)
        Me.TSBRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBRefrescar.Name = "TSBRefrescar"
        Me.TSBRefrescar.Size = New System.Drawing.Size(59, 22)
        Me.TSBRefrescar.Text = "Refrescar"
        '
        'TSBCerrar
        '
        Me.TSBCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TSBCerrar.Image = CType(resources.GetObject("TSBCerrar.Image"), System.Drawing.Image)
        Me.TSBCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBCerrar.Name = "TSBCerrar"
        Me.TSBCerrar.Size = New System.Drawing.Size(43, 22)
        Me.TSBCerrar.Text = "Cerrar"
        '
        'Label_Cliente
        '
        Me.Label_Cliente.AutoSize = True
        Me.Label_Cliente.Location = New System.Drawing.Point(-3, 25)
        Me.Label_Cliente.Name = "Label_Cliente"
        Me.Label_Cliente.Size = New System.Drawing.Size(795, 13)
        Me.Label_Cliente.TabIndex = 1
        Me.Label_Cliente.Text = "__ Cliente ______________________________________________________________________" &
    "_____________________________________________________"
        '
        'grd_Cliente
        '
        Me.grd_Cliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_Cliente.Location = New System.Drawing.Point(0, 50)
        Me.grd_Cliente.Name = "grd_Cliente"
        Me.grd_Cliente.Size = New System.Drawing.Size(787, 235)
        Me.grd_Cliente.TabIndex = 2
        '
        'TB_DATOS
        '
        Me.TB_DATOS.Controls.Add(Me.page_Datos)
        Me.TB_DATOS.Location = New System.Drawing.Point(0, 296)
        Me.TB_DATOS.Name = "TB_DATOS"
        Me.TB_DATOS.SelectedIndex = 0
        Me.TB_DATOS.Size = New System.Drawing.Size(787, 100)
        Me.TB_DATOS.TabIndex = 3
        '
        'page_Datos
        '
        Me.page_Datos.Controls.Add(Me.Txtb_FechaAlta)
        Me.page_Datos.Controls.Add(Me.TB_Estatus)
        Me.page_Datos.Controls.Add(Me.Tb_UsuarioAlta)
        Me.page_Datos.Controls.Add(Me.Lb_Estatus)
        Me.page_Datos.Controls.Add(Me.Lbfecha)
        Me.page_Datos.Controls.Add(Me.lb_usuario)
        Me.page_Datos.Location = New System.Drawing.Point(4, 22)
        Me.page_Datos.Name = "page_Datos"
        Me.page_Datos.Padding = New System.Windows.Forms.Padding(3)
        Me.page_Datos.Size = New System.Drawing.Size(779, 74)
        Me.page_Datos.TabIndex = 0
        Me.page_Datos.Text = "Datos"
        Me.page_Datos.UseVisualStyleBackColor = True
        '
        'TB_Estatus
        '
        Me.TB_Estatus.Location = New System.Drawing.Point(519, 21)
        Me.TB_Estatus.Name = "TB_Estatus"
        Me.TB_Estatus.Size = New System.Drawing.Size(100, 20)
        Me.TB_Estatus.TabIndex = 4
        '
        'Tb_UsuarioAlta
        '
        Me.Tb_UsuarioAlta.Location = New System.Drawing.Point(109, 23)
        Me.Tb_UsuarioAlta.Name = "Tb_UsuarioAlta"
        Me.Tb_UsuarioAlta.Size = New System.Drawing.Size(100, 20)
        Me.Tb_UsuarioAlta.TabIndex = 3
        '
        'Lb_Estatus
        '
        Me.Lb_Estatus.AutoSize = True
        Me.Lb_Estatus.Location = New System.Drawing.Point(471, 28)
        Me.Lb_Estatus.Name = "Lb_Estatus"
        Me.Lb_Estatus.Size = New System.Drawing.Size(42, 13)
        Me.Lb_Estatus.TabIndex = 2
        Me.Lb_Estatus.Text = "Estatus"
        '
        'Lbfecha
        '
        Me.Lbfecha.AutoSize = True
        Me.Lbfecha.Location = New System.Drawing.Point(247, 28)
        Me.Lbfecha.Name = "Lbfecha"
        Me.Lbfecha.Size = New System.Drawing.Size(57, 13)
        Me.Lbfecha.TabIndex = 1
        Me.Lbfecha.Text = "Fecha alta"
        '
        'lb_usuario
        '
        Me.lb_usuario.AutoSize = True
        Me.lb_usuario.Location = New System.Drawing.Point(40, 28)
        Me.lb_usuario.Name = "lb_usuario"
        Me.lb_usuario.Size = New System.Drawing.Size(63, 13)
        Me.lb_usuario.TabIndex = 0
        Me.lb_usuario.Text = "Usuario alta"
        '
        'Txtb_FechaAlta
        '
        Me.Txtb_FechaAlta.Location = New System.Drawing.Point(310, 23)
        Me.Txtb_FechaAlta.Name = "Txtb_FechaAlta"
        Me.Txtb_FechaAlta.Size = New System.Drawing.Size(100, 20)
        Me.Txtb_FechaAlta.TabIndex = 5
        '
        'frmCatCuentaBancariaCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(787, 408)
        Me.Controls.Add(Me.TB_DATOS)
        Me.Controls.Add(Me.grd_Cliente)
        Me.Controls.Add(Me.Label_Cliente)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "frmCatCuentaBancariaCliente"
        Me.Text = "Catálogo de cuentas bancarias del cliente"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.grd_Cliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TB_DATOS.ResumeLayout(False)
        Me.page_Datos.ResumeLayout(False)
        Me.page_Datos.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents TSBNuevo As ToolStripButton
    Friend WithEvents TSBModificar As ToolStripButton
    Friend WithEvents TSBConsultar As ToolStripButton
    Friend WithEvents TSBRefrescar As ToolStripButton
    Friend WithEvents TSBCerrar As ToolStripButton
    Friend WithEvents Label_Cliente As Label
    Friend WithEvents grd_Cliente As DataGridView
    Friend WithEvents TB_DATOS As TabControl
    Friend WithEvents page_Datos As TabPage
    Friend WithEvents TB_Estatus As TextBox
    Friend WithEvents Tb_UsuarioAlta As TextBox
    Friend WithEvents Lb_Estatus As Label
    Friend WithEvents Lbfecha As Label
    Friend WithEvents lb_usuario As Label
    Friend WithEvents Txtb_FechaAlta As TextBox
End Class
