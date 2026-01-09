Imports MySql.Data.MySqlClient

Module Koneksi
    Private ReadOnly server As String = "localhost"
    Private ReadOnly database As String = "dbpenjualan"
    Private ReadOnly username As String = "root"
    Private ReadOnly password As String = ""

    Private Function BuildConnString() As String
        Return $"server={server};user id={username};password={password};database={database};SslMode=Disabled;ConnectionTimeout=30;"
    End Function

    ' KONEKSI BARU SETIAP PEMANGGILAN (AMAN)
    Public Function OpenConnection() As MySqlConnection
        Dim conn As New MySqlConnection(BuildConnString())
        conn.Open()
        Return conn
    End Function
End Module
