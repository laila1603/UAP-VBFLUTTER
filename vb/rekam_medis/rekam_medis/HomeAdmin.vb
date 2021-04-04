Public Class HomeAdmin
    Private Sub HomeAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        lHello.Text = "Hello, " & My.Settings.nama

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lTanggal.Text = Format(Now, "dd/MM/yyyy")
        lWaktu.Text = Format(Now, "HH:mm:ss")
    End Sub

    Private Sub PendaftaranToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PendaftaranToolStripMenuItem.Click
        FormPendaftaran.Show()
    End Sub

    Private Sub AdminToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdminToolStripMenuItem.Click
        DataAdmin.Show()
    End Sub

    Private Sub DokterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DokterToolStripMenuItem.Click
        DataDokter.Show()
    End Sub

    Private Sub PasienToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasienToolStripMenuItem.Click
        DataPasien.Show()
    End Sub

    Private Sub ObatToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ObatToolStripMenuItem.Click
        DataObat.Show()
    End Sub

    Private Sub PemeriksaanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PemeriksaanToolStripMenuItem.Click
        FormPemeriksaan.Show()
    End Sub

    Private Sub PengambilanObatToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PengambilanObatToolStripMenuItem.Click
        FormResep.Show()
    End Sub

    Private Sub SelesaiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelesaiToolStripMenuItem.Click
        FormSelesai.Show()
    End Sub

    Private Sub HOMEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HOMEToolStripMenuItem.Click

    End Sub
End Class