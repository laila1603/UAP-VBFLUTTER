Option Explicit On
Option Strict On
Imports MySql.Data.MySqlClient
Public Class FormLogin
    Private Sub Execute(MySQL As String, Optional Parameter As String = "")

        Cmd = New MySqlCommand(MySQL, Con)
        'AddParameters(Parameter)
        PerformCRUD(Cmd)

    End Sub

    Private Sub cekLogin(Optional keyword As String = "", Optional strKeyword As String = "")
        SQL = "SELECT * FROM tb_admin WHERE username = @keyword1 AND password = @keyword2 "

        Cmd = New MySqlCommand(SQL, Con)
        Cmd.Parameters.Clear()
        Cmd.Parameters.AddWithValue("keyword1", keyword)
        Cmd.Parameters.AddWithValue("keyword2", strKeyword)

        Dim dataAdmin As DataTable = PerformCRUD(Cmd)

        If dataAdmin.Rows.Count > 0 Then
            Console.WriteLine()
            My.Settings.id = dataAdmin.Rows(0)("id_admin").ToString()
            My.Settings.nama = dataAdmin.Rows(0)("nama").ToString()
            My.Settings.username = dataAdmin.Rows(0)("username").ToString()
            My.Settings.password = dataAdmin.Rows(0)("password").ToString()
            MsgBox("Anda berhasil login level Admin!", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information,
                   "Login Sukses")
            HomeAdmin.Show()
            Me.Hide()
        Else

            SQL = "SELECT * FROM tb_dokter WHERE username = @keyword1 AND password = @keyword2 "

            Cmd = New MySqlCommand(SQL, Con)
            Cmd.Parameters.Clear()
            Cmd.Parameters.AddWithValue("keyword1", keyword)
            Cmd.Parameters.AddWithValue("keyword2", strKeyword)

            Dim dataDokter As DataTable = PerformCRUD(Cmd)

            If dataDokter.Rows.Count > 0 Then
                Console.WriteLine()
                My.Settings.id = dataDokter.Rows(0)("id_dokter").ToString()
                My.Settings.nama = dataDokter.Rows(0)("nama").ToString()
                My.Settings.username = dataDokter.Rows(0)("username").ToString()
                My.Settings.password = dataDokter.Rows(0)("password").ToString()
                MsgBox("Anda berhasil login level Dokter!", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information,
                   "Login Sukses")
            Else
                MsgBox("Username / Password Salah!!", MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation,
                   "Peringatan")
            End If
        End If




    End Sub


    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If String.IsNullOrEmpty(tUsername.Text.Trim()) Or String.IsNullOrEmpty(tPassword.Text.Trim()) Then
            MsgBox("Tolong isi dulu isianya", MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation,
                   "Peringatan")
        Else
            cekLogin(tUsername.Text.Trim(), tPassword.Text.Trim())
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        End
    End Sub
End Class

