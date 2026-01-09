Imports Microsoft.Reporting.WinForms
Public Class FormSalesReport

    Private _controller As SalesReportController

    Private Sub SalesReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _controller = New SalesReportController()
        LoadReport()

        Me.ReportViewer1.RefreshReport()
    End Sub

    Sub LoadReport()
        Dim dt As DataTable = _controller.getSalesReport()
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.ReportPath = System.IO.Path.Combine(Application.StartupPath, "Reports\SalesReport.rdlc")
        Dim rds As New ReportDataSource("DataSet1", dt)
        ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewer1.RefreshReport()
    End Sub
End Class