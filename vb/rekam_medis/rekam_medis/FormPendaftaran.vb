Option Explicit On
Option Strict On
Imports MySql.Data.MySqlClient
Public Class FormPendaftaran
    Private ID As String = ""
    Private intRow As Integer = 0
    Private Sub FormPendaftaran_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        resetMe()
        onLoad()
        loadData()
    End Sub

    Private Sub onLoad()
        Dim SQLpasien As String = "SELECT * FROM tb_pasien "
        Dim SQLdokter As String = "SELECT * FROM tb_dokter "
        Dim Cmdpasien As MySqlCommand
        Dim Cmddoker As MySqlCommand

        Cmdpasien = New MySqlCommand(SQLpasien, Con)
        Dim dataPasien As DataTable = PerformCRUD(Cmdpasien)

        Cmddoker = New MySqlCommand(SQLdokter, Con)
        Dim dataDokter As DataTable = PerformCRUD(Cmddoker)

        If dataPasien.Rows.Count > 0 Then

            With cbPasien
                .Items.Clear()

                For i As Integer = 0 To dataPasien.Rows.Count - 1
                    .Items.Add(dataPasien.Rows(i).Item("no_kartu").ToString() & " - " & dataPasien.Rows(i).Item("nama").ToString() & " - " & dataPasien.Rows(i).Item("id_pasien").ToString())

                Next
                .SelectedIndex = 0
            End With
        End If

        If dataDokter.Rows.Count > 0 Then

            With cbDokter
                .Items.Clear()

                For i As Integer = 0 To dataDokter.Rows.Count - 1
                    .Items.Add(dataDokter.Rows(i).Item("spesialis").ToString() & " - " & dataDokter.Rows(i).Item("nama").ToString() & " - " & dataDokter.Rows(i).Item("id_dokter").ToString())

                Next
                .SelectedIndex = 0
            End With
        End If



    End Sub

    Private Sub resetMe()
        Me.ID = ""

        tKeluhan.Text = ""

        If cbPasien.Items.Count > 0 Then
            cbPasien.SelectedIndex = 0
        End If
        If cbDokter.Items.Count > 0 Then
            cbDokter.SelectedIndex = 0
        End If
        If cbStatus.Items.Count > 0 Then
            cbStatus.SelectedIndex = 0
        End If
    End Sub
    Private Sub Execute(MySQL As String, Optional Parameter As String = "")

        Cmd = New MySqlCommand(MySQL, Con)
        AddParameters(Parameter)
        PerformCRUD(Cmd)

    End Sub

    Private Sub AddParameters(str As String)
        Dim p(), d() As String
        p = Split(cbPasien.SelectedItem.ToString(), "-")
        d = Split(cbDokter.SelectedItem.ToString(), "-")




        Cmd.Parameters.Clear()
        Cmd.Parameters.AddWithValue("@id_pasien", p(2).ToString())
        Cmd.Parameters.AddWithValue("@id_dokter", d(2).ToString())
        Cmd.Parameters.AddWithValue("@status", cbStatus.SelectedItem.ToString())
        Cmd.Parameters.AddWithValue("@keluhan", tKeluhan.Text.Trim())
        Cmd.Parameters.AddWithValue("@id_admin", My.Settings.id)
        Cmd.Parameters.AddWithValue("@tanggal", dtTanggal.Value.ToString("yyyy-M-d"))

        If str = "Update" Or str = "Delete" And Not String.IsNullOrEmpty(Me.ID) Then
            Cmd.Parameters.AddWithValue("@id_rekam", Me.ID)
        End If
    End Sub

    Private Sub loadData(Optional keyword As String = "")
        SQL = "SELECT tb_rekam_medis.id_rekam, tb_pasien.no_kartu,tb_pasien.nama, tb_rekam_medis.keluhan, tb_rekam_medis.tanggal, tb_rekam_medis.status,tb_dokter.spesialis,tb_dokter.nama FROM tb_rekam_medis INNER JOIN tb_pasien ON tb_pasien.id_pasien=tb_rekam_medis.id_pasien INNER JOIN tb_dokter ON tb_dokter.id_dokter=tb_rekam_medis.id_dokter WHERE tb_rekam_medis.status=@status AND  tb_pasien.nama LIKE @keyword1 OR tb_pasien.no_kartu=@keyword2 OR tb_dokter.nama=@keyword3 OR tb_rekam_medis.keluhan=@keyword4 ORDER BY tb_rekam_medis.id_rekam ASC "
        Dim Keyword1 As String = String.Format("%{0}%", keyword)
        Dim sts As String = String.Format("{0}", "pendaftaran")

        Cmd = New MySqlCommand(SQL, Con)
        Cmd.Parameters.Clear()
        Cmd.Parameters.AddWithValue("keyword1", Keyword1)
        Cmd.Parameters.AddWithValue("keyword2", Keyword1)
        Cmd.Parameters.AddWithValue("keyword3", Keyword1)
        Cmd.Parameters.AddWithValue("keyword4", Keyword1)
        Cmd.Parameters.AddWithValue("status", sts)

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
            .Columns(1).HeaderText = "No.Kartu"
            .Columns(2).HeaderText = "Pasien"
            .Columns(3).HeaderText = "Keluhan"
            .Columns(4).HeaderText = "Tanggal"
            .Columns(5).HeaderText = "Status"
            .Columns(6).HeaderText = "Spesialis"
            .Columns(7).HeaderText = "Dokter"

            .Columns(0).Width = 60
            .Columns(1).Width = 100
            .Columns(2).Width = 200
            .Columns(3).Width = 200
            .Columns(4).Width = 85
            .Columns(5).Width = 100
            .Columns(6).Width = 85
            .Columns(6).Width = 200
        End With
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        If String.IsNullOrEmpty(tKeluhan.Text.Trim()) Then
            MsgBox("Tolong isi dulu isianya", MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation,
                   "Peringatan")
        Else
            SQL = "Insert into tb_rekam_medis(id_pasien,id_dokter,keluhan,tanggal,status,id_admin) VALUES(@id_pasien,@id_dokter,@keluhan,@tanggal,@status,@id_admin)"
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
            Dim no_kartu, nm_pasiean, id_pasien, nm_dokter, id_dokter, spesialis As String

            If e.RowIndex <> -1 Then
                Me.ID = Convert.ToString(dgv.CurrentRow.Cells(0).Value).Trim()

                SQL = "SELECT tb_rekam_medis.id_rekam as id_rekam, tb_pasien.id_pasien as id_pasien,tb_pasien.no_kartu as no_kartu,tb_pasien.nama as nm_pasien, tb_rekam_medis.keluhan as keluhan, tb_rekam_medis.tanggal as tanggal, tb_rekam_medis.status as status,tb_dokter.id_dokter as id_dokter,tb_dokter.spesialis as spesialis,tb_dokter.nama as nm_dokter FROM tb_rekam_medis INNER JOIN tb_pasien ON tb_pasien.id_pasien=tb_rekam_medis.id_pasien INNER JOIN tb_dokter ON tb_dokter.id_dokter=tb_rekam_medis.id_dokter  WHERE tb_rekam_medis.id_rekam = @keyword1 ORDER BY tb_rekam_medis.id_rekam ASC "
                Dim Keyword1 As String = String.Format("{0}", Me.ID)

                Cmd = New MySqlCommand(SQL, Con)
                Cmd.Parameters.Clear()
                Cmd.Parameters.AddWithValue("keyword1", Keyword1)
                Dim dt As DataTable = PerformCRUD(Cmd)
                cbPasien.Text = dt.Rows(0).Item("no_kartu").ToString() & " - " & dt.Rows(0).Item("nm_pasien").ToString() & " - " & dt.Rows(0).Item("id_pasien").ToString()
                cbDokter.Text = dt.Rows(0).Item("spesialis").ToString() & " - " & dt.Rows(0).Item("nm_dokter").ToString() & " - " & dt.Rows(0).Item("id_dokter").ToString()
                cbStatus.Text = dt.Rows(0).Item("status").ToString()
                tKeluhan.Text = dt.Rows(0).Item("keluhan").ToString()

                Dim sm(), tgl() As String
                sm = Split(dt.Rows(0).Item("tanggal").ToString(), " ")
                tgl = Split(sm(0).ToString(), "/")
                Console.WriteLine(Convert.ToString(dgv.CurrentRow.Cells(4).Value).Trim())
                dtTanggal.Value = New Date(CInt(tgl(2).ToString()), CInt(tgl(0).ToString()), CInt(tgl(1).ToString()))
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

        If String.IsNullOrEmpty(tKeluhan.Text.Trim()) Then
            MsgBox("Tolong isi dulu isianya", MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation,
                   "PERINGATAN")
        Else
            SQL = "UPDATE tb_rekam_medis SET id_pasien=@id_pasien,id_dokter=@id_dokter,keluhan=@keluhan,tanggal=@tanggal,status=@status,id_admin=@id_admin  WHERE id_rekam= @id_rekam"
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


                SQL = "Delete from tb_rekam_medis WHERE id_rekam= @id_rekam"
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

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub tKeluhan_TextChanged(sender As Object, e As EventArgs) Handles tKeluhan.TextChanged

    End Sub
End Class