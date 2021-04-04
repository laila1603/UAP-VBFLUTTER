<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HomeAdmin
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
        Me.components = New System.ComponentModel.Container()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.HOMEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PendaftaranToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PemeriksaanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PengambilanObatToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelesaiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdminToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DokterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasienToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ObatToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lHello = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lWaktu = New System.Windows.Forms.Label()
        Me.lTanggal = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.HOMEToolStripMenuItem, Me.ToolStripMenuItem2})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Font = New System.Drawing.Font("Garamond", 10.0!)
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(64, 20)
        Me.ToolStripMenuItem1.Text = "HOME"
        '
        'HOMEToolStripMenuItem
        '
        Me.HOMEToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PendaftaranToolStripMenuItem, Me.PemeriksaanToolStripMenuItem, Me.PengambilanObatToolStripMenuItem, Me.SelesaiToolStripMenuItem})
        Me.HOMEToolStripMenuItem.Font = New System.Drawing.Font("Garamond", 10.0!)
        Me.HOMEToolStripMenuItem.Name = "HOMEToolStripMenuItem"
        Me.HOMEToolStripMenuItem.Size = New System.Drawing.Size(96, 20)
        Me.HOMEToolStripMenuItem.Text = "TRANSAKSI"
        '
        'PendaftaranToolStripMenuItem
        '
        Me.PendaftaranToolStripMenuItem.Name = "PendaftaranToolStripMenuItem"
        Me.PendaftaranToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.PendaftaranToolStripMenuItem.Text = "Pendaftaran"
        '
        'PemeriksaanToolStripMenuItem
        '
        Me.PemeriksaanToolStripMenuItem.Name = "PemeriksaanToolStripMenuItem"
        Me.PemeriksaanToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.PemeriksaanToolStripMenuItem.Text = "Pemeriksaan"
        '
        'PengambilanObatToolStripMenuItem
        '
        Me.PengambilanObatToolStripMenuItem.Name = "PengambilanObatToolStripMenuItem"
        Me.PengambilanObatToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.PengambilanObatToolStripMenuItem.Text = "Pengambilan Obat"
        '
        'SelesaiToolStripMenuItem
        '
        Me.SelesaiToolStripMenuItem.Name = "SelesaiToolStripMenuItem"
        Me.SelesaiToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SelesaiToolStripMenuItem.Text = "Selesai"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AdminToolStripMenuItem, Me.DokterToolStripMenuItem, Me.PasienToolStripMenuItem, Me.ObatToolStripMenuItem})
        Me.ToolStripMenuItem2.Font = New System.Drawing.Font("Garamond", 10.0!)
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(58, 20)
        Me.ToolStripMenuItem2.Text = "DATA"
        '
        'AdminToolStripMenuItem
        '
        Me.AdminToolStripMenuItem.Name = "AdminToolStripMenuItem"
        Me.AdminToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.AdminToolStripMenuItem.Text = "Admin"
        '
        'DokterToolStripMenuItem
        '
        Me.DokterToolStripMenuItem.Name = "DokterToolStripMenuItem"
        Me.DokterToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.DokterToolStripMenuItem.Text = "Dokter"
        '
        'PasienToolStripMenuItem
        '
        Me.PasienToolStripMenuItem.Name = "PasienToolStripMenuItem"
        Me.PasienToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.PasienToolStripMenuItem.Text = "Pasien"
        '
        'ObatToolStripMenuItem
        '
        Me.ObatToolStripMenuItem.Name = "ObatToolStripMenuItem"
        Me.ObatToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.ObatToolStripMenuItem.Text = "Obat"
        '
        'lHello
        '
        Me.lHello.AutoSize = True
        Me.lHello.Font = New System.Drawing.Font("Garamond", 50.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lHello.Location = New System.Drawing.Point(179, 109)
        Me.lHello.Name = "lHello"
        Me.lHello.Size = New System.Drawing.Size(344, 76)
        Me.lHello.TabIndex = 1
        Me.lHello.Text = "Hello, User!"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Garamond", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(184, 196)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(391, 45)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Semoga Hari ini Lancar!"
        '
        'lWaktu
        '
        Me.lWaktu.AutoSize = True
        Me.lWaktu.Font = New System.Drawing.Font("Garamond", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lWaktu.Location = New System.Drawing.Point(184, 255)
        Me.lWaktu.Name = "lWaktu"
        Me.lWaktu.Size = New System.Drawing.Size(122, 45)
        Me.lWaktu.TabIndex = 3
        Me.lWaktu.Text = "Waktu"
        '
        'lTanggal
        '
        Me.lTanggal.AutoSize = True
        Me.lTanggal.Font = New System.Drawing.Font("Garamond", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lTanggal.Location = New System.Drawing.Point(433, 255)
        Me.lTanggal.Name = "lTanggal"
        Me.lTanggal.Size = New System.Drawing.Size(142, 45)
        Me.lTanggal.TabIndex = 4
        Me.lTanggal.Text = "Tanggal"
        '
        'Timer1
        '
        '
        'HomeAdmin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lime
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.lTanggal)
        Me.Controls.Add(Me.lWaktu)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lHello)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "HomeAdmin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HomeAdmin"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents HOMEToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PendaftaranToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PemeriksaanToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PengambilanObatToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelesaiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents AdminToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DokterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PasienToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ObatToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lHello As Label

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles lHello.Click

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents lWaktu As Label
    Friend WithEvents lTanggal As Label
    Friend WithEvents Timer1 As Timer
End Class
