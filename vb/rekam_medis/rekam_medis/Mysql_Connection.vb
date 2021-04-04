Option Explicit On
Option Strict On

Imports System.Data
Imports MySql.Data.MySqlClient
Module Mysql_Connection

    Public Function getConnString() As String
        Dim server As String = "server = localhost;"
        Dim port As String = "port=3306;"
        Dim db As String = "database=rekam_medis;"
        Dim user As String = "user=root;"
        Dim pass As String = "password="

        Dim connString As String = String.Format("{0}{1}{2}{3}{4}", server, port, db, user, pass)
        'server=localhost;user id=hyda_vb;persistsecurityinfo=True;database=rekam_medis
        'Dim connString As String = "Server=localhost;Database=rekam_medis;allowuservariables=True;"
        Return connString

    End Function

    Public Con As New MySqlConnection(getConnString())
    Public Cmd As MySqlCommand
    Public SQL As String = ""

    Public Function PerformCRUD(com As MySqlCommand) As DataTable
        Dim da As MySqlDataAdapter
        Dim dt As New DataTable()

        Try
            da = New MySqlDataAdapter()
            da.SelectCommand = com
            da.Fill(dt)
            Return dt

        Catch ex As Exception
            MessageBox.Show("error :" & ex.Message)
            dt = Nothing
        End Try
        Return dt
    End Function
End Module

