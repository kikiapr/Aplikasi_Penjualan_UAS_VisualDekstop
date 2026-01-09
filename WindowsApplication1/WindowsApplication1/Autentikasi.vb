Imports MySql.Data.MySqlClient
Imports System.IO

Public Class Autentikasi
    Public username As String
    Public password As String
    Public isLogin As Boolean = False

    Private Function GetConnectionString() As String
        ' Baca file setting.ini untuk dapat koneksi database
        Dim path As String = Application.StartupPath & "\setting.ini"
        If Not File.Exists(path) Then
            Throw New FileNotFoundException("File setting.ini tidak ditemukan.")
        End If

        Dim server As String = ""
        Dim user As String = ""
        Dim pass As String = ""
        Dim db As String = ""

        For Each line As String In File.ReadAllLines(path)
            If line.StartsWith("Server=") Then server = line.Replace("Server=", "").Trim()
            If line.StartsWith("User=") Then user = line.Replace("User=", "").Trim()
            If line.StartsWith("Password=") Then pass = line.Replace("Password=", "").Trim()
            If line.StartsWith("Database=") Then db = line.Replace("Database=", "").Trim()
        Next

        Return $"server={server};uid={user};pwd={pass};database={db};"
    End Function

    Public Sub Login()
        Try
            Using conn As New MySqlConnection(GetConnectionString())
                conn.Open()

                Dim query As String = "SELECT * FROM users WHERE username=@username AND password=@password"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@username", username)
                    cmd.Parameters.AddWithValue("@password", password)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.HasRows Then
                            isLogin = True
                        Else
                            isLogin = False
                        End If
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan koneksi: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            isLogin = False
        End Try
    End Sub
End Class
