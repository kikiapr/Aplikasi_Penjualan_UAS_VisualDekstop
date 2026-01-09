Public Class frmPurchase
    Dim ctrl As New PurchaseController()

    Private Sub frmPurchase_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cancelNew()
    End Sub

    Private Sub createNew()
        ' Memanggil GetNewTransactionCode dari PurchaseController kamu
        txtKode.Text = ctrl.GetNewTransactionCode()
        txtTglTrans.Text = DateTime.Now.ToString("dd/MM/yyyy")
        dgvItems.ReadOnly = False
        dgvItems.Rows.Clear()
        btnSave.Enabled = True
    End Sub

    Private Sub cancelNew()
        txtKode.Text = ""
        txtTglTrans.Text = ""
        If txtTotal IsNot Nothing Then txtTotal.Text = "0"
        dgvItems.ReadOnly = True
        dgvItems.Rows.Clear()
        btnSave.Enabled = False
        btnNew.Text = "Transaksi Baru [F1]"
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        If btnNew.Text.Contains("Baru") Then
            createNew()
            btnNew.Text = "Batal [F2]"
        Else
            cancelNew()
        End If
    End Sub

    ' Fungsi Hitung Otomatis per baris dan Grand Total
    Private Sub HitungSemua(rowIndex As Integer)
        ' Pastikan nama cell sesuai dengan (Name) di Edit Columns DataGridView
        Dim qty = CDec(If(dgvItems.Rows(rowIndex).Cells("qtySale").Value, 0))
        Dim harga = CDec(If(dgvItems.Rows(rowIndex).Cells("priceSale").Value, 0))
        dgvItems.Rows(rowIndex).Cells("SubTotal").Value = qty * harga

        ' Hitung Grand Total ke TextBox
        Dim total As Decimal = 0
        For Each row As DataGridViewRow In dgvItems.Rows
            If Not row.IsNewRow AndAlso row.Cells("SubTotal").Value IsNot Nothing Then
                total += CDec(row.Cells("SubTotal").Value)
            End If
        Next
        If txtTotal IsNot Nothing Then txtTotal.Text = total.ToString("N0")
    End Sub

    Private Sub dgvItems_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItems.CellEndEdit
        If e.RowIndex < 0 Then Return

        ' A. Cari Barang berdasarkan ID (Input angka di kolom itemID)
        If e.ColumnIndex = dgvItems.Columns("itemID").Index Then
            Dim inputId As String = If(dgvItems.Rows(e.RowIndex).Cells("itemID").Value, "").ToString()

            If inputId <> "" AndAlso IsNumeric(inputId) Then
                ' Memanggil ItemModel.GetItemById (parameter Integer)
                Dim rowBarang = ItemModel.GetItemById(CInt(inputId))

                If rowBarang IsNot Nothing Then
                    dgvItems.Rows(e.RowIndex).Cells("itemDesc").Value = rowBarang.itemDesc
                    dgvItems.Rows(e.RowIndex).Cells("unit").Value = rowBarang.unit
                    ' Mengambil purchasePrice dari ItemModel
                    dgvItems.Rows(e.RowIndex).Cells("priceSale").Value = rowBarang.purchasePrice
                    dgvItems.Rows(e.RowIndex).Cells("qtySale").Value = 1
                    HitungSemua(e.RowIndex)
                Else
                    MsgBox("ID Barang " & inputId & " tidak ditemukan!", MsgBoxStyle.Critical)
                    dgvItems.Rows(e.RowIndex).Cells("itemID").Value = ""
                End If
            End If

            ' B. Hitung ulang jika Qty atau Harga diubah manual oleh user
        ElseIf e.ColumnIndex = dgvItems.Columns("qtySale").Index Or e.ColumnIndex = dgvItems.Columns("priceSale").Index Then
            HitungSemua(e.RowIndex)
        End If
    End Sub

    ' --- TOMBOL SIMPAN ---
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Validasi jika grid kosong (hanya baris baru)
        If dgvItems.Rows.Count <= 1 AndAlso dgvItems.Rows(0).IsNewRow Then
            MsgBox("Tabel masih kosong!", MsgBoxStyle.Exclamation)
            Return
        End If

        Try
            Dim listDetails As New List(Of PurchaseDetail)

            ' Ambil data dari Grid masuk ke List Detail
            For Each row As DataGridViewRow In dgvItems.Rows
                If Not row.IsNewRow AndAlso row.Cells("itemID").Value IsNot Nothing Then
                    Dim d As New PurchaseDetail()

                    ' DISESUAIKAN: Menggunakan ProductId sesuai file PurchaseDetail.vb kamu
                    d.ProductId = row.Cells("itemID").Value.ToString()
                    d.Qty = CInt(row.Cells("qtySale").Value)
                    d.Price = CDbl(row.Cells("priceSale").Value)
                    d.Subtotal = CDbl(row.Cells("SubTotal").Value)

                    listDetails.Add(d)
                End If
            Next

            ' Bersihkan format titik/koma agar bisa dikonversi ke Double
            Dim totalClean As String = txtTotal.Text.Replace(".", "").Replace(",", "")
            Dim totalAmount As Double = CDbl(totalClean)

            ' Panggil fungsi SavePurchase di PurchaseController
            If ctrl.SavePurchase(txtKode.Text, DateTime.Now, totalAmount, listDetails) Then
                MsgBox("Transaksi Berhasil Disimpan!", MsgBoxStyle.Information)
                cancelNew()
            Else
                MsgBox("Gagal menyimpan transaksi.", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("Error Simpan: " & ex.Message)
        End Try
    End Sub

    Private Sub dgvItems_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItems.CellContentClick

    End Sub
End Class