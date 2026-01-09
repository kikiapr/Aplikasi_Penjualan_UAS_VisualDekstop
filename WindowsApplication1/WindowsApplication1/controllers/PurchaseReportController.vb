Public Class PurchaseReportController
    Public Function getPurchaseReport() As DataTable
        ' Memanggil fungsi getAll yang baru kita buat di atas
        Return PurchaseReport.getAll()
    End Function
End Class