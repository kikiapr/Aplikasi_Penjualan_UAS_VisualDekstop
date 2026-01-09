Imports Microsoft.Reporting.WinForms
Imports System.IO

Public Class FormPurchaseReport
    Dim WithEvents ReportViewer1 As New ReportViewer
    Private _controller As New PurchaseReportController()

    Private Sub FormPurchaseReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReportViewer1.Dock = DockStyle.Fill
        Me.Controls.Add(ReportViewer1)
        TampilkanLaporan()
    End Sub

    Sub TampilkanLaporan()
        Try
            ' 1. Ambil data dari database melalui Controller
            Dim dt As DataTable = _controller.getPurchaseReport()
            Dim rds As New ReportDataSource("DataSet1", dt)

            ' 2. Masukkan data ke ReportViewer
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(rds)

            ' 3. JALUR BARU: Mengarah ke folder 'Reports'
            ' Pastikan nama folder di project kamu adalah "Reports" (pakai S)
            Dim pathReport As String = Path.Combine(Application.StartupPath, "Reports", "ReportPurchase.rdlc")

            ' 4. Cek apakah filenya benar-benar ada di folder bin\Debug\Reports
            If File.Exists(pathReport) Then
                ReportViewer1.LocalReport.ReportPath = pathReport
            Else
                ' Jika muncul pesan ini, artinya file belum di-set 'Copy Always'
                MsgBox("File RDLC TIDAK DITEMUKAN di: " & vbCrLf & pathReport)
                Return
            End If

            ' 5. Tampilkan!
            ReportViewer1.RefreshReport()

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub
End Class