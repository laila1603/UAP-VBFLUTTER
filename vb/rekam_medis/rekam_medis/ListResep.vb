Option Explicit On
Option Strict On
Imports MySql.Data.MySqlClient
Public Class ListResep
    Public Property ID As String
    Private Sub FormPemeriksaanDokter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadData()
    End Sub

    Private Sub loadData(Optional keyword As String = "")
        SQL = "SELECT * FROM tb_resep WHERE id_rekam=" & Me.ID & " ORDER BY nama ASC "


        Cmd = New MySqlCommand(SQL, Con)
        Cmd.Parameters.Clear()

        Dim dt As DataTable = PerformCRUD(Cmd)

        ListBox1.DataSource = dt

        ListBox1.DisplayMember = "nama"



    End Sub

    Private Sub tDiagnosa_TextChanged(sender As Object, e As EventArgs) Handles tDiagnosa.TextChanged

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub tKeluhan_TextChanged(sender As Object, e As EventArgs) Handles tKeluhan.TextChanged

    End Sub
End Class