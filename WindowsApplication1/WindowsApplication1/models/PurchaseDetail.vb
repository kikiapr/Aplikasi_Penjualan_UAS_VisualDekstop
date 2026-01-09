Public Class PurchaseDetail
    Public Property Id As Integer
    ' Mengikuti struktur tabel purchase kamu (idTrans)
    Public Property PurchaseId As String
    ' Gunakan Integer jika kamu mencari barang pakai angka (ID)
    Public Property ProductId As Integer
    Public Property Qty As Integer
    ' Pakai Double agar bisa menampung angka desimal jika perlu
    Public Property Price As Double
    Public Property Subtotal As Double
End Class