<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormKontrolluppgiftEnskild
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvEnskildKontrollUppgiftSumma = New System.Windows.Forms.DataGridView()
        Me.ÅrDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PersonnummerDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrganisationsnummerDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EfternamnDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FörnamnDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CalcSUMKontrolluppgiftDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CalcSUMKontrolluppgiftRoyaltyDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CalcSUMKontrolluppgiftÄrvdRoyaltyDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VbetalningkontrolluppgiftsummeringBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.B2DataSet_Kontrolluppgiftsummering = New B2.B2DataSet_Kontrolluppgiftsummering()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbEfternamn = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbFörnamn = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbPersonnummer = New System.Windows.Forms.TextBox()
        Me.dgvEnskildKU = New System.Windows.Forms.DataGridView()
        Me.Ärvd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.U_Efternamn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.U_Förnamn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.U_Personnummer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ersättningstyp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.calc_Kontrolluppgift = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VBetalningkontrolluppgiftUtskickBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.B2DataSet_Kontrolluppfigt_Enskild = New B2.B2DataSet()
        Me.cbÅr = New System.Windows.Forms.ComboBox()
        Me.V_Betalning_kontrolluppgift_UtskickTableAdapter = New B2.B2DataSetTableAdapters.v_Betalning_kontrolluppgift_UtskickTableAdapter()
        Me.V_betalning_kontrolluppgift_summeringTableAdapter = New B2.B2DataSet_KontrolluppgiftsummeringTableAdapters.v_betalning_kontrolluppgift_summeringTableAdapter()
        CType(Me.dgvEnskildKontrollUppgiftSumma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VbetalningkontrolluppgiftsummeringBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.B2DataSet_Kontrolluppgiftsummering, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvEnskildKU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VBetalningkontrolluppgiftUtskickBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.B2DataSet_Kontrolluppfigt_Enskild, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvEnskildKontrollUppgiftSumma
        '
        Me.dgvEnskildKontrollUppgiftSumma.AllowUserToAddRows = False
        Me.dgvEnskildKontrollUppgiftSumma.AllowUserToDeleteRows = False
        Me.dgvEnskildKontrollUppgiftSumma.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvEnskildKontrollUppgiftSumma.AutoGenerateColumns = False
        Me.dgvEnskildKontrollUppgiftSumma.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEnskildKontrollUppgiftSumma.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ÅrDataGridViewTextBoxColumn, Me.PersonnummerDataGridViewTextBoxColumn, Me.OrganisationsnummerDataGridViewTextBoxColumn, Me.EfternamnDataGridViewTextBoxColumn, Me.FörnamnDataGridViewTextBoxColumn, Me.CalcSUMKontrolluppgiftDataGridViewTextBoxColumn, Me.CalcSUMKontrolluppgiftRoyaltyDataGridViewTextBoxColumn, Me.CalcSUMKontrolluppgiftÄrvdRoyaltyDataGridViewTextBoxColumn})
        Me.dgvEnskildKontrollUppgiftSumma.DataSource = Me.VbetalningkontrolluppgiftsummeringBindingSource
        Me.dgvEnskildKontrollUppgiftSumma.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvEnskildKontrollUppgiftSumma.EnableHeadersVisualStyles = False
        Me.dgvEnskildKontrollUppgiftSumma.Location = New System.Drawing.Point(2, 200)
        Me.dgvEnskildKontrollUppgiftSumma.MultiSelect = False
        Me.dgvEnskildKontrollUppgiftSumma.Name = "dgvEnskildKontrollUppgiftSumma"
        Me.dgvEnskildKontrollUppgiftSumma.ReadOnly = True
        Me.dgvEnskildKontrollUppgiftSumma.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEnskildKontrollUppgiftSumma.ShowEditingIcon = False
        Me.dgvEnskildKontrollUppgiftSumma.Size = New System.Drawing.Size(990, 172)
        Me.dgvEnskildKontrollUppgiftSumma.TabIndex = 5
        '
        'ÅrDataGridViewTextBoxColumn
        '
        Me.ÅrDataGridViewTextBoxColumn.DataPropertyName = "År"
        Me.ÅrDataGridViewTextBoxColumn.HeaderText = "År"
        Me.ÅrDataGridViewTextBoxColumn.Name = "ÅrDataGridViewTextBoxColumn"
        Me.ÅrDataGridViewTextBoxColumn.ReadOnly = True
        Me.ÅrDataGridViewTextBoxColumn.Width = 50
        '
        'PersonnummerDataGridViewTextBoxColumn
        '
        Me.PersonnummerDataGridViewTextBoxColumn.DataPropertyName = "Personnummer"
        Me.PersonnummerDataGridViewTextBoxColumn.HeaderText = "Personnummer"
        Me.PersonnummerDataGridViewTextBoxColumn.Name = "PersonnummerDataGridViewTextBoxColumn"
        Me.PersonnummerDataGridViewTextBoxColumn.ReadOnly = True
        Me.PersonnummerDataGridViewTextBoxColumn.Width = 120
        '
        'OrganisationsnummerDataGridViewTextBoxColumn
        '
        Me.OrganisationsnummerDataGridViewTextBoxColumn.DataPropertyName = "organisationsnummer"
        Me.OrganisationsnummerDataGridViewTextBoxColumn.HeaderText = "Org-nr."
        Me.OrganisationsnummerDataGridViewTextBoxColumn.Name = "OrganisationsnummerDataGridViewTextBoxColumn"
        Me.OrganisationsnummerDataGridViewTextBoxColumn.ReadOnly = True
        Me.OrganisationsnummerDataGridViewTextBoxColumn.Width = 120
        '
        'EfternamnDataGridViewTextBoxColumn
        '
        Me.EfternamnDataGridViewTextBoxColumn.DataPropertyName = "Efternamn"
        Me.EfternamnDataGridViewTextBoxColumn.HeaderText = "Efternamn"
        Me.EfternamnDataGridViewTextBoxColumn.Name = "EfternamnDataGridViewTextBoxColumn"
        Me.EfternamnDataGridViewTextBoxColumn.ReadOnly = True
        Me.EfternamnDataGridViewTextBoxColumn.Width = 200
        '
        'FörnamnDataGridViewTextBoxColumn
        '
        Me.FörnamnDataGridViewTextBoxColumn.DataPropertyName = "Förnamn"
        Me.FörnamnDataGridViewTextBoxColumn.HeaderText = "Förnamn"
        Me.FörnamnDataGridViewTextBoxColumn.Name = "FörnamnDataGridViewTextBoxColumn"
        Me.FörnamnDataGridViewTextBoxColumn.ReadOnly = True
        Me.FörnamnDataGridViewTextBoxColumn.Width = 200
        '
        'CalcSUMKontrolluppgiftDataGridViewTextBoxColumn
        '
        Me.CalcSUMKontrolluppgiftDataGridViewTextBoxColumn.DataPropertyName = "calc_SUM_Kontrolluppgift"
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.CalcSUMKontrolluppgiftDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.CalcSUMKontrolluppgiftDataGridViewTextBoxColumn.HeaderText = "Kontrolluppgift"
        Me.CalcSUMKontrolluppgiftDataGridViewTextBoxColumn.Name = "CalcSUMKontrolluppgiftDataGridViewTextBoxColumn"
        Me.CalcSUMKontrolluppgiftDataGridViewTextBoxColumn.ReadOnly = True
        Me.CalcSUMKontrolluppgiftDataGridViewTextBoxColumn.Width = 80
        '
        'CalcSUMKontrolluppgiftRoyaltyDataGridViewTextBoxColumn
        '
        Me.CalcSUMKontrolluppgiftRoyaltyDataGridViewTextBoxColumn.DataPropertyName = "calc_SUM_Kontrolluppgift_Royalty"
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.CalcSUMKontrolluppgiftRoyaltyDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.CalcSUMKontrolluppgiftRoyaltyDataGridViewTextBoxColumn.HeaderText = "Royalty"
        Me.CalcSUMKontrolluppgiftRoyaltyDataGridViewTextBoxColumn.Name = "CalcSUMKontrolluppgiftRoyaltyDataGridViewTextBoxColumn"
        Me.CalcSUMKontrolluppgiftRoyaltyDataGridViewTextBoxColumn.ReadOnly = True
        Me.CalcSUMKontrolluppgiftRoyaltyDataGridViewTextBoxColumn.Width = 80
        '
        'CalcSUMKontrolluppgiftÄrvdRoyaltyDataGridViewTextBoxColumn
        '
        Me.CalcSUMKontrolluppgiftÄrvdRoyaltyDataGridViewTextBoxColumn.DataPropertyName = "calc_SUM_Kontrolluppgift_Ärvd_Royalty"
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = "0"
        Me.CalcSUMKontrolluppgiftÄrvdRoyaltyDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.CalcSUMKontrolluppgiftÄrvdRoyaltyDataGridViewTextBoxColumn.HeaderText = "Ärvd Royalty"
        Me.CalcSUMKontrolluppgiftÄrvdRoyaltyDataGridViewTextBoxColumn.Name = "CalcSUMKontrolluppgiftÄrvdRoyaltyDataGridViewTextBoxColumn"
        Me.CalcSUMKontrolluppgiftÄrvdRoyaltyDataGridViewTextBoxColumn.ReadOnly = True
        Me.CalcSUMKontrolluppgiftÄrvdRoyaltyDataGridViewTextBoxColumn.Width = 80
        '
        'VbetalningkontrolluppgiftsummeringBindingSource
        '
        Me.VbetalningkontrolluppgiftsummeringBindingSource.DataMember = "v_betalning_kontrolluppgift_summering"
        Me.VbetalningkontrolluppgiftsummeringBindingSource.DataSource = Me.B2DataSet_Kontrolluppgiftsummering
        Me.VbetalningkontrolluppgiftsummeringBindingSource.Filter = ""
        '
        'B2DataSet_Kontrolluppgiftsummering
        '
        Me.B2DataSet_Kontrolluppgiftsummering.DataSetName = "B2DataSet_Kontrolluppgiftsummering"
        Me.B2DataSet_Kontrolluppgiftsummering.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(17, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "År"
        '
        'tbEfternamn
        '
        Me.tbEfternamn.Location = New System.Drawing.Point(97, 94)
        Me.tbEfternamn.Name = "tbEfternamn"
        Me.tbEfternamn.Size = New System.Drawing.Size(185, 20)
        Me.tbEfternamn.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Efternamn"
        '
        'tbFörnamn
        '
        Me.tbFörnamn.Location = New System.Drawing.Point(97, 126)
        Me.tbFörnamn.Name = "tbFörnamn"
        Me.tbFörnamn.Size = New System.Drawing.Size(184, 20)
        Me.tbFörnamn.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 129)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Förnamn"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(26, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Person-/Orgnr"
        '
        'tbPersonnummer
        '
        Me.tbPersonnummer.Location = New System.Drawing.Point(97, 59)
        Me.tbPersonnummer.Name = "tbPersonnummer"
        Me.tbPersonnummer.Size = New System.Drawing.Size(181, 20)
        Me.tbPersonnummer.TabIndex = 2
        '
        'dgvEnskildKU
        '
        Me.dgvEnskildKU.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvEnskildKU.AutoGenerateColumns = False
        Me.dgvEnskildKU.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEnskildKU.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Ärvd, Me.U_Efternamn, Me.U_Förnamn, Me.U_Personnummer, Me.Ersättningstyp, Me.calc_Kontrolluppgift})
        Me.dgvEnskildKU.DataSource = Me.VBetalningkontrolluppgiftUtskickBindingSource
        Me.dgvEnskildKU.Location = New System.Drawing.Point(2, 378)
        Me.dgvEnskildKU.Name = "dgvEnskildKU"
        Me.dgvEnskildKU.Size = New System.Drawing.Size(971, 383)
        Me.dgvEnskildKU.TabIndex = 6
        '
        'Ärvd
        '
        Me.Ärvd.DataPropertyName = "Ärvd"
        Me.Ärvd.HeaderText = ""
        Me.Ärvd.Name = "Ärvd"
        Me.Ärvd.ReadOnly = True
        '
        'U_Efternamn
        '
        Me.U_Efternamn.DataPropertyName = "U_Efternamn"
        Me.U_Efternamn.HeaderText = "U_Efternamn"
        Me.U_Efternamn.Name = "U_Efternamn"
        '
        'U_Förnamn
        '
        Me.U_Förnamn.DataPropertyName = "U_Förnamn"
        Me.U_Förnamn.HeaderText = "U_Förnamn"
        Me.U_Förnamn.Name = "U_Förnamn"
        '
        'U_Personnummer
        '
        Me.U_Personnummer.DataPropertyName = "U_Personnummer"
        Me.U_Personnummer.HeaderText = "U_Personnummer"
        Me.U_Personnummer.Name = "U_Personnummer"
        '
        'Ersättningstyp
        '
        Me.Ersättningstyp.DataPropertyName = "Ersättningstyp"
        Me.Ersättningstyp.HeaderText = "Ersättningstyp"
        Me.Ersättningstyp.Name = "Ersättningstyp"
        Me.Ersättningstyp.Width = 200
        '
        'calc_Kontrolluppgift
        '
        Me.calc_Kontrolluppgift.DataPropertyName = "calc_Kontrolluppgift"
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.calc_Kontrolluppgift.DefaultCellStyle = DataGridViewCellStyle4
        Me.calc_Kontrolluppgift.HeaderText = "KU"
        Me.calc_Kontrolluppgift.Name = "calc_Kontrolluppgift"
        Me.calc_Kontrolluppgift.ReadOnly = True
        '
        'VBetalningkontrolluppgiftUtskickBindingSource
        '
        Me.VBetalningkontrolluppgiftUtskickBindingSource.DataMember = "v_Betalning_kontrolluppgift_Utskick"
        Me.VBetalningkontrolluppgiftUtskickBindingSource.DataSource = Me.B2DataSet_Kontrolluppfigt_Enskild
        '
        'B2DataSet_Kontrolluppfigt_Enskild
        '
        Me.B2DataSet_Kontrolluppfigt_Enskild.DataSetName = "B2DataSet"
        Me.B2DataSet_Kontrolluppfigt_Enskild.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cbÅr
        '
        Me.cbÅr.AllowDrop = True
        Me.cbÅr.FormattingEnabled = True
        Me.cbÅr.Location = New System.Drawing.Point(97, 26)
        Me.cbÅr.Name = "cbÅr"
        Me.cbÅr.Size = New System.Drawing.Size(86, 21)
        Me.cbÅr.TabIndex = 1
        '
        'V_Betalning_kontrolluppgift_UtskickTableAdapter
        '
        Me.V_Betalning_kontrolluppgift_UtskickTableAdapter.ClearBeforeFill = True
        '
        'V_betalning_kontrolluppgift_summeringTableAdapter
        '
        Me.V_betalning_kontrolluppgift_summeringTableAdapter.ClearBeforeFill = True
        '
        'FormKontrolluppgiftEnskild
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(985, 761)
        Me.Controls.Add(Me.cbÅr)
        Me.Controls.Add(Me.dgvEnskildKU)
        Me.Controls.Add(Me.tbPersonnummer)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tbFörnamn)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbEfternamn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvEnskildKontrollUppgiftSumma)
        Me.Name = "FormKontrolluppgiftEnskild"
        Me.Text = "Enskild kontrolluppgift"
        CType(Me.dgvEnskildKontrollUppgiftSumma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VbetalningkontrolluppgiftsummeringBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.B2DataSet_Kontrolluppgiftsummering, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvEnskildKU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VBetalningkontrolluppgiftUtskickBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.B2DataSet_Kontrolluppfigt_Enskild, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvEnskildKontrollUppgiftSumma As System.Windows.Forms.DataGridView
    Friend WithEvents B2DataSet_Kontrolluppgiftsummering As B2.B2DataSet_Kontrolluppgiftsummering
    Friend WithEvents VbetalningkontrolluppgiftsummeringBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents V_betalning_kontrolluppgift_summeringTableAdapter As B2.B2DataSet_KontrolluppgiftsummeringTableAdapters.v_betalning_kontrolluppgift_summeringTableAdapter
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbEfternamn As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbFörnamn As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbPersonnummer As System.Windows.Forms.TextBox
    Friend WithEvents dgvEnskildKU As System.Windows.Forms.DataGridView
    Friend WithEvents B2DataSet_Kontrolluppfigt_Enskild As B2.B2DataSet
    Friend WithEvents VBetalningkontrolluppgiftUtskickBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents V_Betalning_kontrolluppgift_UtskickTableAdapter As B2.B2DataSetTableAdapters.v_Betalning_kontrolluppgift_UtskickTableAdapter
    Friend WithEvents cbÅr As System.Windows.Forms.ComboBox
    Friend WithEvents ÅrDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PersonnummerDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrganisationsnummerDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EfternamnDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FörnamnDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CalcSUMKontrolluppgiftDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CalcSUMKontrolluppgiftRoyaltyDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CalcSUMKontrolluppgiftÄrvdRoyaltyDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ärvd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents U_Efternamn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents U_Förnamn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents U_Personnummer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ersättningstyp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents calc_Kontrolluppgift As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
