Public Class frmUtama

    ' =========================
    ' FORM LOAD
    ' =========================
    Private Sub frmUtama_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Cek setting database
        If Not IO.File.Exists("setting.ini") Then
            MessageBox.Show("Database belum disetting", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dim f As New frmSetting
            f.ShowDialog()
        End If
    End Sub

    ' =========================
    ' MENU FILE
    ' =========================
    Private Sub KeluarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KeluarToolStripMenuItem.Click
        Application.Exit()
    End Sub

    ' =========================
    ' MENU MASTER
    ' =========================
    Private Sub ItemsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ItemsToolStripMenuItem.Click
        Dim frm As New frmListItem
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub SupplierToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupplierToolStripMenuItem.Click
        ' Jika ada form supplier, panggil di sini
    End Sub

    ' =========================
    ' MENU TRANSAKSI
    ' =========================
    Private Sub PenjualanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PenjualanToolStripMenuItem.Click
        Dim frm As New frmSale
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub PembelianToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PembelianToolStripMenuItem.Click
        ' Memanggil Form Transaksi Purchase
        frmPurchase.MdiParent = Me
        frmPurchase.Show()
    End Sub

    ' =========================
    ' MENU LAPORAN (Bagian Krusial!)
    ' =========================
    Private Sub PenjualanToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PenjualanToolStripMenuItem1.Click
        ' Membuka Laporan Penjualan
        FormSalesReport.MdiParent = Me
        FormSalesReport.Size = New Size(900, 600)
        FormSalesReport.StartPosition = FormStartPosition.CenterScreen
        FormSalesReport.Show()
    End Sub

    Private Sub PembelianToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PembelianToolStripMenuItem1.Click
        ' 1. Set MdiParent agar berada di dalam form utama
        FormPurchaseReport.MdiParent = Me

        ' 2. Atur ukuran manual (Misal: Lebar 900, Tinggi 600) biar sama kayak Penjualan
        FormPurchaseReport.Size = New Size(900, 600)

        ' 3. Pastikan StartPosition-nya di tengah biar rapi
        FormPurchaseReport.StartPosition = FormStartPosition.CenterScreen

        ' 4. Tampilkan
        FormPurchaseReport.Show()
    End Sub

    ' =========================
    ' MENU SETTING DATABASE
    ' =========================
    Private Sub DatabaseSettingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DatabaseSettingToolStripMenuItem.Click
        Dim frm As New frmSetting
        frm.ShowDialog()
    End Sub

    Private Sub KasirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KasirToolStripMenuItem.Click

    End Sub

    Private Sub UserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserToolStripMenuItem.Click

    End Sub
End Class