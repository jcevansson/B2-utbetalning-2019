<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormKontrolluppgift
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tlpTop = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbÄrvdRoyalty = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.nupMånad = New System.Windows.Forms.NumericUpDown()
        Me.lDatumStr = New System.Windows.Forms.Label()
        Me.dgKontrolluppgift = New System.Windows.Forms.DataGridView()
        Me.IDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TypDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PeriodStrDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EfternamnDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FörnamnDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PersonnummerDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrganisationsnummerDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KontrolluppgiftDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BetalningkontrolluppgiftBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.B2dsKontrolluppgift = New B2.B2dsKontrolluppgift()
        Me.bUnderlag = New System.Windows.Forms.Button()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.tbPNRORG = New System.Windows.Forms.TextBox()
        Me.bGenereraKU = New System.Windows.Forms.Button()
        Me.SFD_Kontrolluppgift = New System.Windows.Forms.SaveFileDialog()
        Me.Betalning_kontrolluppgiftTableAdapter = New B2.B2dsKontrolluppgiftTableAdapters.betalning_kontrolluppgiftTableAdapter()
        Me.tlpTop.SuspendLayout()
        CType(Me.nupMånad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgKontrolluppgift, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BetalningkontrolluppgiftBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.B2dsKontrolluppgift, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpTop
        '
        Me.tlpTop.AutoSize = True
        Me.tlpTop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpTop.ColumnCount = 7
        Me.tlpTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 204.0!))
        Me.tlpTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
        Me.tlpTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 169.0!))
        Me.tlpTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 184.0!))
        Me.tlpTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167.0!))
        Me.tlpTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 124.0!))
        Me.tlpTop.Controls.Add(Me.Label1, 0, 1)
        Me.tlpTop.Controls.Add(Me.Label2, 0, 0)
        Me.tlpTop.Controls.Add(Me.cbÄrvdRoyalty, 1, 0)
        Me.tlpTop.Controls.Add(Me.Label3, 0, 2)
        Me.tlpTop.Controls.Add(Me.nupMånad, 1, 2)
        Me.tlpTop.Controls.Add(Me.lDatumStr, 2, 2)
        Me.tlpTop.Controls.Add(Me.dgKontrolluppgift, 1, 3)
        Me.tlpTop.Controls.Add(Me.bUnderlag, 0, 3)
        Me.tlpTop.Controls.Add(Me.NumericUpDown1, 1, 1)
        Me.tlpTop.Controls.Add(Me.tbPNRORG, 3, 2)
        Me.tlpTop.Controls.Add(Me.bGenereraKU, 4, 0)
        Me.tlpTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpTop.Location = New System.Drawing.Point(0, 0)
        Me.tlpTop.Name = "tlpTop"
        Me.tlpTop.RowCount = 4
        Me.tlpTop.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63.0!))
        Me.tlpTop.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64.0!))
        Me.tlpTop.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.tlpTop.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpTop.Size = New System.Drawing.Size(2049, 1246)
        Me.tlpTop.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "År"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 25)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Ärvd royalty"
        '
        'cbÄrvdRoyalty
        '
        Me.cbÄrvdRoyalty.AutoSize = True
        Me.cbÄrvdRoyalty.Location = New System.Drawing.Point(207, 3)
        Me.cbÄrvdRoyalty.Name = "cbÄrvdRoyalty"
        Me.cbÄrvdRoyalty.Size = New System.Drawing.Size(28, 27)
        Me.cbÄrvdRoyalty.TabIndex = 3
        Me.cbÄrvdRoyalty.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 127)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 25)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Månad"
        '
        'nupMånad
        '
        Me.nupMånad.Enabled = False
        Me.nupMånad.Location = New System.Drawing.Point(207, 130)
        Me.nupMånad.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.nupMånad.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nupMånad.Name = "nupMånad"
        Me.nupMånad.Size = New System.Drawing.Size(144, 31)
        Me.nupMånad.TabIndex = 5
        Me.nupMånad.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lDatumStr
        '
        Me.lDatumStr.AutoSize = True
        Me.lDatumStr.Location = New System.Drawing.Point(407, 127)
        Me.lDatumStr.Name = "lDatumStr"
        Me.lDatumStr.Size = New System.Drawing.Size(0, 25)
        Me.lDatumStr.TabIndex = 6
        '
        'dgKontrolluppgift
        '
        Me.dgKontrolluppgift.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.dgKontrolluppgift.AutoGenerateColumns = False
        Me.dgKontrolluppgift.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.875!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgKontrolluppgift.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgKontrolluppgift.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgKontrolluppgift.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDDataGridViewTextBoxColumn, Me.TypDataGridViewTextBoxColumn, Me.PeriodStrDataGridViewTextBoxColumn, Me.EfternamnDataGridViewTextBoxColumn, Me.FörnamnDataGridViewTextBoxColumn, Me.PersonnummerDataGridViewTextBoxColumn, Me.OrganisationsnummerDataGridViewTextBoxColumn, Me.KontrolluppgiftDataGridViewTextBoxColumn})
        Me.tlpTop.SetColumnSpan(Me.dgKontrolluppgift, 4)
        Me.dgKontrolluppgift.DataSource = Me.BetalningkontrolluppgiftBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.875!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgKontrolluppgift.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgKontrolluppgift.Location = New System.Drawing.Point(207, 180)
        Me.dgKontrolluppgift.Name = "dgKontrolluppgift"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.875!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgKontrolluppgift.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgKontrolluppgift.RowTemplate.Height = 33
        Me.dgKontrolluppgift.Size = New System.Drawing.Size(1552, 1063)
        Me.dgKontrolluppgift.TabIndex = 7
        '
        'IDDataGridViewTextBoxColumn
        '
        Me.IDDataGridViewTextBoxColumn.DataPropertyName = "ID"
        Me.IDDataGridViewTextBoxColumn.HeaderText = "ID"
        Me.IDDataGridViewTextBoxColumn.Name = "IDDataGridViewTextBoxColumn"
        Me.IDDataGridViewTextBoxColumn.ReadOnly = True
        Me.IDDataGridViewTextBoxColumn.Visible = False
        '
        'TypDataGridViewTextBoxColumn
        '
        Me.TypDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.TypDataGridViewTextBoxColumn.DataPropertyName = "Typ"
        Me.TypDataGridViewTextBoxColumn.HeaderText = "Typ"
        Me.TypDataGridViewTextBoxColumn.Name = "TypDataGridViewTextBoxColumn"
        Me.TypDataGridViewTextBoxColumn.ReadOnly = True
        Me.TypDataGridViewTextBoxColumn.Width = 73
        '
        'PeriodStrDataGridViewTextBoxColumn
        '
        Me.PeriodStrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.PeriodStrDataGridViewTextBoxColumn.DataPropertyName = "PeriodStr"
        Me.PeriodStrDataGridViewTextBoxColumn.HeaderText = "PeriodStr"
        Me.PeriodStrDataGridViewTextBoxColumn.Name = "PeriodStrDataGridViewTextBoxColumn"
        Me.PeriodStrDataGridViewTextBoxColumn.ReadOnly = True
        Me.PeriodStrDataGridViewTextBoxColumn.Width = 126
        '
        'EfternamnDataGridViewTextBoxColumn
        '
        Me.EfternamnDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.EfternamnDataGridViewTextBoxColumn.DataPropertyName = "Efternamn"
        Me.EfternamnDataGridViewTextBoxColumn.HeaderText = "Efternamn"
        Me.EfternamnDataGridViewTextBoxColumn.Name = "EfternamnDataGridViewTextBoxColumn"
        Me.EfternamnDataGridViewTextBoxColumn.Width = 135
        '
        'FörnamnDataGridViewTextBoxColumn
        '
        Me.FörnamnDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.FörnamnDataGridViewTextBoxColumn.DataPropertyName = "Förnamn"
        Me.FörnamnDataGridViewTextBoxColumn.HeaderText = "Förnamn"
        Me.FörnamnDataGridViewTextBoxColumn.Name = "FörnamnDataGridViewTextBoxColumn"
        Me.FörnamnDataGridViewTextBoxColumn.Width = 122
        '
        'PersonnummerDataGridViewTextBoxColumn
        '
        Me.PersonnummerDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.PersonnummerDataGridViewTextBoxColumn.DataPropertyName = "personnummer"
        Me.PersonnummerDataGridViewTextBoxColumn.HeaderText = "personnummer"
        Me.PersonnummerDataGridViewTextBoxColumn.Name = "PersonnummerDataGridViewTextBoxColumn"
        Me.PersonnummerDataGridViewTextBoxColumn.Width = 180
        '
        'OrganisationsnummerDataGridViewTextBoxColumn
        '
        Me.OrganisationsnummerDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.OrganisationsnummerDataGridViewTextBoxColumn.DataPropertyName = "organisationsnummer"
        Me.OrganisationsnummerDataGridViewTextBoxColumn.HeaderText = "organisationsnummer"
        Me.OrganisationsnummerDataGridViewTextBoxColumn.Name = "OrganisationsnummerDataGridViewTextBoxColumn"
        Me.OrganisationsnummerDataGridViewTextBoxColumn.Width = 243
        '
        'KontrolluppgiftDataGridViewTextBoxColumn
        '
        Me.KontrolluppgiftDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.KontrolluppgiftDataGridViewTextBoxColumn.DataPropertyName = "kontrolluppgift"
        Me.KontrolluppgiftDataGridViewTextBoxColumn.HeaderText = "kontrolluppgift"
        Me.KontrolluppgiftDataGridViewTextBoxColumn.Name = "KontrolluppgiftDataGridViewTextBoxColumn"
        Me.KontrolluppgiftDataGridViewTextBoxColumn.Width = 172
        '
        'BetalningkontrolluppgiftBindingSource
        '
        Me.BetalningkontrolluppgiftBindingSource.DataMember = "betalning_kontrolluppgift"
        Me.BetalningkontrolluppgiftBindingSource.DataSource = Me.B2dsKontrolluppgift
        Me.BetalningkontrolluppgiftBindingSource.Filter = ""
        Me.BetalningkontrolluppgiftBindingSource.Sort = "Efternamn,Förnamn"
        '
        'B2dsKontrolluppgift
        '
        Me.B2dsKontrolluppgift.DataSetName = "B2dsKontrolluppgift"
        Me.B2dsKontrolluppgift.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'bUnderlag
        '
        Me.bUnderlag.Location = New System.Drawing.Point(3, 180)
        Me.bUnderlag.Name = "bUnderlag"
        Me.bUnderlag.Size = New System.Drawing.Size(198, 67)
        Me.bUnderlag.TabIndex = 9
        Me.bUnderlag.Text = "Underlag"
        Me.bUnderlag.UseVisualStyleBackColor = True
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(207, 66)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {2050, 0, 0, 0})
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {2010, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(144, 31)
        Me.NumericUpDown1.TabIndex = 1
        Me.NumericUpDown1.Value = New Decimal(New Integer() {2050, 0, 0, 0})
        '
        'tbPNRORG
        '
        Me.tbPNRORG.Location = New System.Drawing.Point(576, 130)
        Me.tbPNRORG.Name = "tbPNRORG"
        Me.tbPNRORG.Size = New System.Drawing.Size(288, 31)
        Me.tbPNRORG.TabIndex = 10
        '
        'bGenereraKU
        '
        Me.bGenereraKU.Location = New System.Drawing.Point(1581, 3)
        Me.bGenereraKU.Name = "bGenereraKU"
        Me.bGenereraKU.Size = New System.Drawing.Size(178, 57)
        Me.bGenereraKU.TabIndex = 8
        Me.bGenereraKU.Text = "Generera fil"
        Me.bGenereraKU.UseVisualStyleBackColor = True
        '
        'SFD_Kontrolluppgift
        '
        Me.SFD_Kontrolluppgift.CreatePrompt = True
        Me.SFD_Kontrolluppgift.DefaultExt = "xml"
        Me.SFD_Kontrolluppgift.FileName = "Skatteverket.xml"
        Me.SFD_Kontrolluppgift.InitialDirectory = "C:\kutest\"
        '
        'Betalning_kontrolluppgiftTableAdapter
        '
        Me.Betalning_kontrolluppgiftTableAdapter.ClearBeforeFill = True
        '
        'FormKontrolluppgift
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(2049, 1553)
        Me.Controls.Add(Me.tlpTop)
        Me.Name = "FormKontrolluppgift"
        Me.Text = "Kontrolluppgifter"
        Me.tlpTop.ResumeLayout(False)
        Me.tlpTop.PerformLayout()
        CType(Me.nupMånad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgKontrolluppgift, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BetalningkontrolluppgiftBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.B2dsKontrolluppgift, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tlpTop As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbÄrvdRoyalty As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents nupMånad As System.Windows.Forms.NumericUpDown
    Friend WithEvents B2dsKontrolluppgift As B2.B2dsKontrolluppgift
    Friend WithEvents BetalningkontrolluppgiftBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Betalning_kontrolluppgiftTableAdapter As B2.B2dsKontrolluppgiftTableAdapters.betalning_kontrolluppgiftTableAdapter
    Friend WithEvents lDatumStr As System.Windows.Forms.Label
    Friend WithEvents dgKontrolluppgift As System.Windows.Forms.DataGridView
    Friend WithEvents IDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TypDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PeriodStrDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EfternamnDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FörnamnDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PersonnummerDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrganisationsnummerDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KontrolluppgiftDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bGenereraKU As System.Windows.Forms.Button
    Friend WithEvents bUnderlag As System.Windows.Forms.Button
    Friend WithEvents tbPNRORG As System.Windows.Forms.TextBox
    Friend WithEvents SFD_Kontrolluppgift As System.Windows.Forms.SaveFileDialog
End Class
