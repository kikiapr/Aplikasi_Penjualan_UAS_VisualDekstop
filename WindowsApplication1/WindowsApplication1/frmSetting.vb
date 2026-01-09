Imports System.IO

Public Class frmSetting
    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        ' Path file setting
        Dim path As String = Application.StartupPath & "\setting.ini"

        Try
            ' Simpan konfigurasi ke file setting.ini
            Using writer As StreamWriter = New StreamWriter(path, False)
                writer.WriteLine("[Database]")
                writer.WriteLine("Server=" & txtServer.Text)
                writer.WriteLine("User=" & txtUser.Text)
                writer.WriteLine("Password=" & txtPassword.Text)
                writer.WriteLine("Database=" & txtDatabase.Text)
            End Using

            MessageBox.Show("Konfigurasi berhasil disimpan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Gagal menyimpan konfigurasi: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Jika file sudah ada, tampilkan isi sebelumnya
        Dim path As String = Application.StartupPath & "\setting.ini"
        If File.Exists(path) Then
            Dim lines() As String = File.ReadAllLines(path)
            For Each line As String In lines
                If line.StartsWith("Server=") Then txtServer.Text = line.Replace("Server=", "")
                If line.StartsWith("User=") Then txtUser.Text = line.Replace("User=", "")
                If line.StartsWith("Password=") Then txtPassword.Text = line.Replace("Password=", "")
                If line.StartsWith("Database=") Then txtDatabase.Text = line.Replace("Database=", "")
            Next
        End If
    End Sub
End Class
