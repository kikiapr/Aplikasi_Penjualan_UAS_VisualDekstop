Imports MySql.Data.MySqlClient

Public Class Purchase
    Public Property idTrans As String
    Public Property purchaseDate As DateTime
    Public Property totalPurchase As Double
    Public Property details As List(Of PurchaseDetail)

    Public Shared Function Insert(purchase As Purchase) As Boolean
        Using conn = Koneksi.OpenConnection()
            Dim transaction As MySqlTransaction = conn.BeginTransaction()

            Try
                ' 1. Insert ke tabel Master: purchase
                ' Pastikan kolom di DB adalah: idTrans, purchaseDate, totalPurchase
                Dim cmd As New MySqlCommand("INSERT INTO purchase (idTrans, purchaseDate, totalPurchase) " &
                                            "VALUES (@kode, @tanggal, @total)", conn, transaction)

                cmd.Parameters.AddWithValue("@kode", purchase.idTrans)
                cmd.Parameters.AddWithValue("@tanggal", purchase.purchaseDate)
                cmd.Parameters.AddWithValue("@total", purchase.totalPurchase)
                cmd.ExecuteNonQuery()

                ' 2. Insert ke tabel Detail: purchasedetail
                For Each d In purchase.details
                    ' PERBAIKAN DI SINI: Sesuaikan nama kolom dengan tabel purchasedetail di phpMyAdmin kamu
                    ' Aku ubah 'idPurchase' jadi 'idTrans' dan 'qtyPurchase' jadi 'qty' agar umum
                    Dim cmdDet As New MySqlCommand("INSERT INTO purchasedetail " &
                        "(idTrans, itemID, qty, price, subtotal) " &
                        "VALUES (@purchase_id, @item_id, @qty, @price, @subtotal)", conn, transaction)

                    cmdDet.Parameters.AddWithValue("@purchase_id", purchase.idTrans)
                    cmdDet.Parameters.AddWithValue("@item_id", d.ProductId)
                    cmdDet.Parameters.AddWithValue("@qty", d.Qty)
                    cmdDet.Parameters.AddWithValue("@price", d.Price)
                    cmdDet.Parameters.AddWithValue("@subtotal", d.Subtotal)
                    cmdDet.ExecuteNonQuery()
                Next

                transaction.Commit()
                Return True

            Catch ex As Exception
                transaction.Rollback()
                MessageBox.Show("Gagal menyimpan data pembelian: " & ex.Message)
                Return False
            End Try
        End Using
    End Function

    Public Shared Function GenerateKodeTransaksi() As String
        Dim kodeBaru As String = "PUR0001"
        Try
            Using conn = Koneksi.OpenConnection()
                Dim cmd As New MySqlCommand("SELECT idTrans FROM purchase ORDER BY idTrans DESC LIMIT 1", conn)
                Dim rd = cmd.ExecuteReader()

                If rd.Read() Then
                    Dim kodeLama As String = rd("idTrans").ToString()
                    ' Mengambil angka setelah "PUR" (index ke-3)
                    Dim nomor As Integer = CInt(kodeLama.Substring(3)) + 1
                    kodeBaru = "PUR" & nomor.ToString("0000")
                End If
            End Using
        Catch ex As Exception
            ' Error generate kode biasanya karena tabel masih kosong, jadi PUR0001 tetap dipakai
        End Try
        Return kodeBaru
    End Function
End Class