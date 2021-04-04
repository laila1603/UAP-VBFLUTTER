Option Explicit On
Option Strict On
Imports MySql.Data.MySqlClient
Public Class DataAdmin
    Private ID As String = ""
    Private intRow As Integer = 0
    Private Sub DataAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        resetMe()
        loadData()
    End Sub

    Private Sub resetMe()
        Me.ID = ""

        tNama.Text = ""
        tUsername.Text = ""
        tPassword.Text = ""

    End Sub

    Private Sub Execute(MySQL As String, Optional Parameter As String = "")

        Cmd = New MySqlCommand(MySQL, Con)
        AddParameters(Parameter)
        PerformCRUD(Cmd)

    End Sub

    Private Sub AddParameters(str As String)
        Cmd.Parameters.Clear()
        Cmd.Parameters.AddWithValue("@nama", tNama.Text.Trim())
        Cmd.Parameters.AddWithValue("@username", tUsername.Text.Trim())
        Cmd.Parameters.AddWithValue("@password", tPassword.Text.Trim())

        If str = "Update" Or str = "Delete" And Not String.IsNullOrEmpty(Me.ID) Then
            Cmd.Parameters.AddWithValue("@id_admin", Me.ID)
            Console.WriteLine(Me.ID)
        End If
    End Sub


    Private Sub loadData(Optional keyword As String = "")
        SQL = "SELECT * FROM tb_admin WHERE nama LIKE @keyword1 OR username = @keyword2 ORDER BY id_admin ASC "
        Dim strKeyword As String = String.Format("%{0}%", keyword)

        Cmd = New MySqlCommand(SQL, Con)
        Cmd.Parameters.Clear()
        Cmd.Parameters.AddWithValue("keyword1", strKeyword)
        Cmd.Parameters.AddWithValue("keyword2", keyword)

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
            .Columns(1).HeaderText = "Nama"
            .Columns(2).HeaderText = "Username"
            .Columns(3).HeaderText = "Password"

            .Columns(0).Width = 60
            .Columns(1).Width = 200
            .Columns(2).Width = 100
            .Columns(3).Width = 85


        End With

    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        If String.IsNullOrEmpty(tNama.Text.Trim()) Or String.IsNullOrEmpty(tUsername.Text.Trim()) Or String.IsNullOrEmpty(tPassword.Text.Trim()) Then
            MsgBox("Tolong isi dulu isianya", MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation,
                   "Peringatan")
        Else
            SQL = "Insert into tb_admin(nama,username,password) VALUES(@nama, @username, @password)"
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

                tNama.Text = Convert.ToString(dgv.CurrentRow.Cells(1).Value).Trim()
                tUsername.Text = Convert.ToString(dgv.CurrentRow.Cells(2).Value).Trim()
                tPassword.Text = Convert.ToString(dgv.CurrentRow.Cells(3).Value).Trim()
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

        If String.IsNullOrEmpty(tNama.Text.Trim()) Or String.IsNullOrEmpty(tUsername.Text.Trim()) Or String.IsNullOrEmpty(tPassword.Text.Trim()) Then
            MsgBox("Tolong isi dulu isianya", MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation,
                   "PERINGATAN")
        Else
            SQL = "UPDATE tb_admin SET nama = @nama, username = @username , password = @password WHERE id_admin= @id_admin"
            Execute(SQL, "Update")
            MsgBox("Data Berhasil di Perbaharui.", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information,
                       "SUKSES")
            loadData()
            resetMe()
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


                SQL = "Delete from tb_admin WHERE id_admin= @id_admin"
                Execute(SQL, "Delete")
                MsgBox("Data berhasil di hapus", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information,
                       "PERINGATAN")
                loadData()
                resetMe()

            End If

        End If

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        HomeAdmin.Show()
        Me.Hide()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class