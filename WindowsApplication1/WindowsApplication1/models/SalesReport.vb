Imports MySql.Data.MySqlClient
Public Class SalesReport
    Public Shared Function getAll() As DataTable
        Dim dt As New DataTable
        Dim query As String = "SELECT S.idTrans as NOTA, S.saleDate as TGL_NOTA, SD.itemID as KODE_BRG, " & _
            " I.itemDesc as NAMA_BRG, SD.qtySale AS QTY, SD.price AS HARGA, I.unit," & _
            " SD.qtySale*SD.price AS SUBTOTAL from Sale S inner join saledetail SD " & _
            " ON S.idTrans=SD.idSale left join items I on SD.itemID=I.id;"

        Using conn = Koneksi.OpenConnection()
            Using cmd As New MySqlCommand(query, conn)
                dt.Load(cmd.ExecuteReader())
            End Using
        End Using
        MsgBox(dt.Rows.Count)
        Return dt

    End Function
End Class
