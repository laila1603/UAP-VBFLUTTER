Option Explicit On
Option Strict On
Imports MySql.Data.MySqlClient
Public Class DataPasien
    Private ID As String = ""
    Private intRow As Integer = 0
    Private Sub DataPasien_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        resetMe()
        loadData()
    End Sub

    Private Sub resetMe()
        Me.ID = ""

        tNama.Text = ""
        tNoKartu.Text = ""
        tUmur.Text = ""

        If cbGender.Items.Count > 0 Then
            cbGender.SelectedIndex = 0
        End If

    End Sub

    Private Sub Execute(MySQL As String, Optional Parameter As String = "")

        Cmd = New MySqlCommand(MySQL, Con)
        AddParameters(Parameter)
        PerformCRUD(Cmd)

    End Sub

    Private Sub AddParameters(str As String)
        Cmd.Parameters.Clear()
        Cmd.Parameters.AddWithValue("@nama", tNama.Text.Trim())
        Cmd.Parameters.AddWithValue("@no_kartu", tNoKartu.Text.Trim())
        Cmd.Parameters.AddWithValue("@jk", cbGender.SelectedItem.ToString())
        Cmd.Parameters.AddWithValue("@umur", tUmur.Text.Trim())

        If str = "Update" Or str = "Delete" And Not String.IsNullOrEmpty(Me.ID) Then
            Cmd.Parameters.AddWithValue("@id_pasien", Me.ID)
        End If
    End Sub

    Private Sub loadData(Optional keyword As String = "")
        SQL = "SELECT * FROM tb_pasien WHERE nama LIKE @keyword1 OR no_kartu = @keyword2 OR umur = @keyword3 ORDER BY id_pasien ASC "
        Dim strKeyword As String = String.Format("%{0}%", keyword)
        Dim spesialisKeyword As String = String.Format("%{0}%", keyword)

        Cmd = New MySqlCommand(SQL, Con)
        Cmd.Parameters.Clear()
        Cmd.Parameters.AddWithValue("keyword1", strKeyword)
        Cmd.Parameters.AddWithValue("keyword2", keyword)
        Cmd.Parameters.AddWithValue("keyword3", spesialisKeyword)

        Dim dt As DataTable = PerformCRUD(Cmd)

        If dt.Rows.Count > 0 Then
            intRow = Convert.ToInt32(dt.Rows.Count.ToString())
        Else
            intRow = 0
        End If

        ToolStrip1.Text = "Total row data : " & intRow.ToString()

        With DataGridView1
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoGenerateColumns = True

            .DataSource = dt

            .Columns(0).HeaderText = "ID"
            .Columns(1).HeaderText = "Nomor Kartu"
            .Columns(2).HeaderText = "Nama"
            .Columns(3).HeaderText = "Jenis Kelamin"
            .Columns(4).HeaderText = "Umur"

            .Columns(0).Width = 60
            .Columns(1).Width = 150
            .Columns(2).Width = 150
            .Columns(3).Width = 85
            .Columns(4).Width = 85


        End With

    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        If String.IsNullOrEmpty(tNama.Text.Trim()) Or String.IsNullOrEmpty(tNoKartu.Text.Trim()) Or String.IsNullOrEmpty(tUmur.Text.Trim()) Then
            MsgBox("Tolong isi dulu isianya", MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation,
                   "Peringatan")
        Else
            SQL = "Insert into tb_pasien(nama,no_kartu,jk,umur) VALUES(@nama, @no_kartu, @jk, @umur)"
            Execute(SQL, "Insert")
            MsgBox("Berhasil Menyimpan DATA.", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information,
                       "SUKSES")
            loadData()
            resetMe()
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            Dim dgv As DataGridView = DataGridView1
            If e.RowIndex <> -1 Then
                Me.ID = Convert.ToString(dgv.CurrentRow.Cells(0).Value).Trim()

                tNoKartu.Text = Convert.ToString(dgv.CurrentRow.Cells(1).Value).Trim()
                tNama.Text = Convert.ToString(dgv.CurrentRow.Cells(2).Value).Trim()
                cbGender.Text = Convert.ToString(dgv.CurrentRow.Cells(3).Value).Trim()
                tUmur.Text = Convert.ToString(dgv.CurrentRow.Cells(4).Value).Trim()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnPerbarui_Click(sender As Object, e As EventArgs) Handles btnPerbarui.Click
        If DataGridView1.Rows.Count = 0 Then
            Exit Sub
        End If
        If String.IsNullOrEmpty(Me.ID) Then
            MsgBox("Pilih salah satu item dari list.", MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation,
                   "PERINGATAN")
            Exit Sub
        End If

        If String.IsNullOrEmpty(tNama.Text.Trim()) Or String.IsNullOrEmpty(tNoKartu.Text.Trim()) Or String.IsNullOrEmpty(tUmur.Text.Trim()) Then
            MsgBox("Tolong isi dulu isianya", MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation,
                   "PERINGATAN")
        Else
            SQL = "UPDATE tb_pasien SET nama = @nama, no_kartu = @no_kartu, jk = @jk, umur = @umur WHERE id_pasien= @id_pasien"
            Execute(SQL, "Update")
            MsgBox("Data Berhasil di Perbaharui.", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information,
                       "SUKSES")
            loadData()
            resetMe()
        End If
    End Sub


    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        If DataGridView1.Rows.Count = 0 Then
            Exit Sub
        End If
        If String.IsNullOrEmpty(Me.ID) Then
            MsgBox("Pilih salah satu item dari list.", MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation,
                   "PERINGATAN")
        Else
            If MessageBox.Show("Apa kamu akan menghapus data ini? ", "PERINGATAN",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then


                SQL = "Delete from tb_pasien WHERE id_pasien= @id_pasien"
                Execute(SQL, "Delete")
                MsgBox("Data berhasil di hapus", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information,
                       "PERINGATAN")
                loadData()
                resetMe()

            End If

        End If
    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        If Not String.IsNullOrEmpty(tCari.Text.Trim()) Then
            loadData(tCari.Text.Trim())
        Else
            loadData()
        End If

        resetMe()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        HomeAdmin.Show()
        Me.Hide()
    End Sub
End Class