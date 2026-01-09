<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPurchase
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dgvItems = New System.Windows.Forms.DataGridView()
        Me.ItemID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.itemDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qtySale = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.unit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.priceSale = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SubTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTglTrans = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtKode = New System.Windows.Forms.TextBox()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.dgvItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvItems
        '
        Me.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ItemID, Me.itemDesc, Me.qtySale, Me.unit, Me.priceSale, Me.SubTotal})
        Me.dgvItems.Location = New System.Drawing.Point(12, 71)
        Me.dgvItems.Name = "dgvItems"
        Me.dgvItems.ReadOnly = True
        Me.dgvItems.Size = New System.Drawing.Size(755, 263)
        Me.dgvItems.TabIndex = 1
        '
        'ItemID
        '
        Me.ItemID.HeaderText = "Kode"
        Me.ItemID.Name = "ItemID"
        Me.ItemID.ReadOnly = True
        '
        'itemDesc
        '
        Me.itemDesc.HeaderText = "Nama Barang"
        Me.itemDesc.Name = "itemDesc"
        Me.itemDesc.ReadOnly = True
        '
        'qtySale
        '
        Me.qtySale.HeaderText = "Jumlah"
        Me.qtySale.Name = "qtySale"
        Me.qtySale.ReadOnly = True
        '
        'unit
        '
        Me.unit.HeaderText = "Satuan"
        Me.unit.Name = "unit"
        Me.unit.ReadOnly = True
        '
        'priceSale
        '
        Me.priceSale.HeaderText = "Harga"
        Me.priceSale.Name = "priceSale"
        Me.priceSale.ReadOnly = True
        '
        'SubTotal
        '
        Me.SubTotal.HeaderText = "Sub.Total"
        Me.SubTotal.Name = "SubTotal"
        Me.SubTotal.ReadOnly = True
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(653, 17)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(101, 38)
        Me.btnSave.TabIndex = 11
        Me.btnSave.Text = "Simpan Transaksi "
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(546, 16)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(101, 38)
        Me.btnNew.TabIndex = 10
        Me.btnNew.Text = "Transaksi Baru [F1]"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtTglTrans)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtKode)
        Me.Panel1.Location = New System.Drawing.Point(13, 23)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(445, 27)
        Me.Panel1.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(216, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Tanggal"
        '
        'txtTglTrans
        '
        Me.txtTglTrans.Enabled = False
        Me.txtTglTrans.Location = New System.Drawing.Point(268, 4)
        Me.txtTglTrans.Name = "txtTglTrans"
        Me.txtTglTrans.Size = New System.Drawing.Size(146, 20)
        Me.txtTglTrans.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Kode Trans."
        '
        'txtKode
        '
        Me.txtKode.Enabled = False
        Me.txtKode.Location = New System.Drawing.Point(72, 3)
        Me.txtKode.Name = "txtKode"
        Me.txtKode.Size = New System.Drawing.Size(102, 20)
        Me.txtKode.TabIndex = 5
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(621, 343)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(146, 20)
        Me.txtTotal.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(568, 346)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "TOTAL"
        '
        'frmPurchase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(779, 375)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgvItems)
        Me.Name = "frmPurchase"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transaksi Pembelian"
        CType(Me.dgvItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvItems As DataGridView
    Friend WithEvents ItemID As DataGridViewTextBoxColumn
    Friend WithEvents itemDesc As DataGridViewTextBoxColumn
    Friend WithEvents qtySale As DataGridViewTextBoxColumn
    Friend WithEvents unit As DataGridViewTextBoxColumn
    Friend WithEvents priceSale As DataGridViewTextBoxColumn
    Friend WithEvents SubTotal As DataGridViewTextBoxColumn
    Friend WithEvents btnSave As Button
    Friend WithEvents btnNew As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents txtTglTrans As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtKode As TextBox
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents Label3 As Label
End Class
