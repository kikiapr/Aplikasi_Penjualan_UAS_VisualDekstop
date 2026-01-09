Imports MySql.Data.MySqlClient

Public Class PurchaseReport
    Public Shared Function getAll() As DataTable
        Dim dt As New DataTable
        ' Query sudah diarahkan ke purchase & purchasedetail
        ' Alias sudah menggunakan huruf kecil agar 'jodoh' dengan RDLC kamu
        Dim query As String = "SELECT P.idTrans as nota, P.purchaseDate as tgl_nota, PD.itemID as kode_brg, " &
                              " I.itemDesc as nama_brg, PD.qty AS qty, PD.price AS harga, I.unit," &
                              " PD.qty*PD.price AS subtotal from purchase P inner join purchasedetail PD " &
                              " ON P.idTrans=PD.idTrans left join items I on PD.itemID=I.id;"

        Using conn = Koneksi.OpenConnection()
            Using cmd As New MySqlCommand(query, conn)
                dt.Load(cmd.ExecuteReader())
            End Using
        End Using
        ' MsgBox(dt.Rows.Count) ' Aktifkan ini kalau mau cek jumlah data yang ditarik
        Return dt
    End Function
End Class