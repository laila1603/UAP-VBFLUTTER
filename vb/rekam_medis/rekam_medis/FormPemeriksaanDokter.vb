Option Explicit On
Option Strict On
Imports MySql.Data.MySqlClient
Public Class FormPemeriksaanDokter
    Public Property ID As String
    Private namaResep As String = ""

    Private intRow As Integer = 0
    Private Sub FormPemeriksaanDokter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadData()
    End Sub

    Private Sub loadData(Optional keyword As String = "")
        SQL = "SELECT * FROM tb_obat ORDER BY nama ASC "


        Cmd = New MySqlCommand(SQL, Con)
        Cmd.Parameters.Clear()

        Dim dt As DataTable = PerformCRUD(Cmd)

        ListBox1.DataSource = dt

        ListBox1.DisplayMember = "nama"
        ListBox1.ValueMember = "id_obat"



    End Sub


    Private Sub Execute(MySQL As String, Optional Parameter As String = "")

        Cmd = New MySqlCommand(MySQL, Con)
        AddParameters(Parameter)
        PerformCRUD(Cmd)

    End Sub

    Private Sub AddParameters(str As String)

        Cmd.Parameters.Clear()
        Cmd.Parameters.AddWithValue("@diagnosa", tDiagnosa.Text)
        Cmd.Parameters.AddWithValue("@keluhan", tKeluhan.Text)
        Cmd.Parameters.AddWithValue("@id_admin", My.Settings.id)

        If str = "Update" Or str = "Delete" And Not String.IsNullOrEmpty(Me.ID) Then
            Cmd.Parameters.AddWithValue("@id_rekam", Me.ID)
        End If
    End Sub



    Private Sub Execute1(MySQL As String, Optional Parameter As String = "")

        Cmd = New MySqlCommand(MySQL, Con)
        AddParameters1(Parameter)
        PerformCRUD(Cmd)

    End Sub

    Private Sub AddParameters1(str As String)

        Cmd.Parameters.Clear()
        Cmd.Parameters.AddWithValue("@nama", namaResep.ToString())
        Cmd.Parameters.AddWithValue("@id_rekam", Me.ID.ToString())

        If str = "Update" Or str = "Delete" And Not String.IsNullOrEmpty(Me.ID) Then
            Cmd.Parameters.AddWithValue("@id_resep", Me.ID)
        End If
    End Sub


    Private Sub btnTambahObat_Click(sender As Object, e As EventArgs) Handles btnTambahObat.Click
        Dim MyDataRowView As DataRowView
        For Each MyDataRowView In ListBox1.SelectedItems
            Me.ListBox2.Items.Add(MyDataRowView.Row.Item(1).ToString)
        Next

    End Sub

    Private Sub btnSelesai_Click(sender As Object, e As EventArgs) Handles btnSelesai.Click
        SQL = "UPDATE tb_rekam_medis SET status='tebus_obat',keluhan=@keluhan,diagnosa=@diagnosa,id_admin=@id_admin  WHERE id_rekam= @id_rekam"
        Execute(SQL, "Update")

        For Each name As String In ListBox2.Items
            namaResep = name
            Console.WriteLine(Me.ID.ToString())
            SQL = "Insert into tb_resep(id_rekam,nama) VALUES(@id_rekam,@nama)"
            Execute1(SQL, "Insert")
        Next
        Dim OBJ As New FormPemeriksaan
        OBJ.loadData()
        OBJ.resetMe()


        MsgBox("Data Berhasil di Disimpan.", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information,
                       "SUKSES")
        Me.Hide()


    End Sub

    Private Sub tDiagnosa_TextChanged(sender As Object, e As EventArgs) Handles tDiagnosa.TextChanged

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged

    End Sub
End Class