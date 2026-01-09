Public Class PurchaseController
    ' Fungsi untuk mengambil kode transaksi otomatis dari Purchase.vb
    Public Function GetNewTransactionCode() As String
        Return Purchase.GenerateKodeTransaksi()
    End Function

    ' Fungsi untuk memproses penyimpanan data
    Public Function SavePurchase(id As String, tgl As DateTime, total As Double, items As List(Of PurchaseDetail)) As Boolean
        ' 1. Masukkan data ke objek Purchase
        Dim newPurchase As New Purchase()
        newPurchase.idTrans = id
        newPurchase.purchaseDate = tgl
        newPurchase.totalPurchase = total
        newPurchase.details = items

        ' 2. Panggil fungsi Insert yang ada di Purchase.vb
        Return Purchase.Insert(newPurchase)
    End Function
End Class