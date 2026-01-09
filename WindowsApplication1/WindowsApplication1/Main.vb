Imports MySql.Data.MySqlClient
Imports System.IO

Module Main

    '🔹 Fungsi untuk membuka koneksi dari file setting.ini
    Public Function BukaKoneksi() As Boolean
        Try
            Dim path As String = Application.StartupPath & "\setting.ini"
            If Not File.Exists(path) Then Return False

            Dim lines() As String = File.ReadAllLines(path)
            Dim s, u, p, d As String
            For Each line In lines
                Dim parts() As String = line.Split("=")
                If parts.Length = 2 Then
                    Select Case parts(0).Trim().ToLower()
                        Case "server" : s = parts(1).Trim()
                        Case "user" : u = parts(1).Trim()
                        Case "password" : p = parts(1).Trim()
                        Case "database" : d = parts(1).Trim()
                    End Select
                End If
            Next

            Dim connStr As String = $"server={s};port=3306;database={d};uid={u};pwd={p};SslMode=Disabled;"
            Using conn As New MySqlConnection(connStr)
                conn.Open()
                MessageBox.Show("Koneksi ke database berhasil!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using

            Return True
        Catch ex As Exception
            MessageBox.Show("Gagal koneksi: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    '🔹 Main awal aplikasi
    Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)

        Dim path As String = Application.StartupPath & "\setting.ini"

        ' Jika file setting belum ada, buka form setting dulu
        If Not File.Exists(path) Then
            MessageBox.Show("File konfigurasi belum ditemukan. Silakan isi koneksi database terlebih dahulu.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            frmSetting.ShowDialog()
        End If

        ' Coba buka koneksi dari setting.ini
        If BukaKoneksi() Then
            Dim oFrmLogin As New frmLogin()
            If oFrmLogin.ShowDialog() = DialogResult.OK Then
                Application.Run(New frmUtama())
            End If
        Else
            frmSetting.ShowDialog() ' Kalau gagal konek, buka lagi form setting
        End If
    End Sub

End Module
