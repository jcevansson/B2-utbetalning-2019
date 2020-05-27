<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormKontrolluppgifter
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
        Me.nudÅr = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bGenereraKU = New System.Windows.Forms.Button()
        Me.SFD_Kontrolluppgift = New System.Windows.Forms.SaveFileDialog()
        Me.nudMediaID = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblUG = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.tb_KU_Fax = New System.Windows.Forms.TextBox()
        Me.tb_KU_Telefon = New System.Windows.Forms.TextBox()
        Me.tb_KU_PostOrt = New System.Windows.Forms.TextBox()
        Me.tb_KU_PostNR = New System.Windows.Forms.TextBox()
        Me.tb_KU_Adress = New System.Windows.Forms.TextBox()
        Me.tb_KU_Kontakt = New System.Windows.Forms.TextBox()
        Me.tb_KU_NAMN = New System.Windows.Forms.TextBox()
        Me.p = New System.Windows.Forms.TextBox()
        Me.bGenererarAG = New System.Windows.Forms.Button()
        Me.lMånad = New System.Windows.Forms.Label()
        Me.nupPeriod = New System.Windows.Forms.NumericUpDown()
        Me.bKU = New System.Windows.Forms.Button()
        CType(Me.nudÅr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMediaID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nupPeriod, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'nudÅr
        '
        Me.nudÅr.Location = New System.Drawing.Point(240, 56)
        Me.nudÅr.Margin = New System.Windows.Forms.Padding(6)
        Me.nudÅr.Maximum = New Decimal(New Integer() {2100, 0, 0, 0})
        Me.nudÅr.Minimum = New Decimal(New Integer() {2010, 0, 0, 0})
        Me.nudÅr.Name = "nudÅr"
        Me.nudÅr.Size = New System.Drawing.Size(110, 31)
        Me.nudÅr.TabIndex = 1
        Me.nudÅr.Value = New Decimal(New Integer() {2010, 0, 0, 0})
        Me.nudÅr.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(60, 69)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "År"
        Me.Label1.Visible = False
        '
        'bGenereraKU
        '
        Me.bGenereraKU.Location = New System.Drawing.Point(446, 38)
        Me.bGenereraKU.Margin = New System.Windows.Forms.Padding(6)
        Me.bGenereraKU.Name = "bGenereraKU"
        Me.bGenereraKU.Size = New System.Drawing.Size(150, 54)
        Me.bGenereraKU.TabIndex = 2
        Me.bGenereraKU.Text = "Skapa KU-fil..."
        Me.bGenereraKU.UseVisualStyleBackColor = True
        Me.bGenereraKU.Visible = False
        '
        'SFD_Kontrolluppgift
        '
        Me.SFD_Kontrolluppgift.CreatePrompt = True
        Me.SFD_Kontrolluppgift.DefaultExt = "xml"
        Me.SFD_Kontrolluppgift.FileName = "Skatteverket.xml"
        Me.SFD_Kontrolluppgift.InitialDirectory = "C:\kutest\"
        '
        'nudMediaID
        '
        Me.nudMediaID.Location = New System.Drawing.Point(240, 227)
        Me.nudMediaID.Margin = New System.Windows.Forms.Padding(6)
        Me.nudMediaID.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudMediaID.Name = "nudMediaID"
        Me.nudMediaID.Size = New System.Drawing.Size(74, 31)
        Me.nudMediaID.TabIndex = 3
        Me.nudMediaID.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(60, 240)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 25)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "MediaID"
        '
        'lblUG
        '
        Me.lblUG.AutoSize = True
        Me.lblUG.Location = New System.Drawing.Point(60, 292)
        Me.lblUG.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblUG.Name = "lblUG"
        Me.lblUG.Size = New System.Drawing.Size(168, 25)
        Me.lblUG.TabIndex = 0
        Me.lblUG.Text = "Uppgiftslämnare"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(60, 344)
        Me.Label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 25)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Namn"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(60, 396)
        Me.Label4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(151, 25)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Kontaktperson"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(60, 448)
        Me.Label5.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 25)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Adress"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(60, 500)
        Me.Label6.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 25)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Postnr"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(60, 552)
        Me.Label7.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 25)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Postort"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(60, 602)
        Me.Label8.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 25)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Telefon"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(60, 654)
        Me.Label9.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 25)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Fax"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(60, 706)
        Me.Label10.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 25)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Epost"
        '
        'TextBox1
        '
        Me.TextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.B2.My.MySettings.Default, "KU_Email", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.TextBox1.Location = New System.Drawing.Point(240, 692)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(6)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(428, 31)
        Me.TextBox1.TabIndex = 14
        Me.TextBox1.Text = Global.B2.My.MySettings.Default.KU_Email
        '
        'tb_KU_Fax
        '
        Me.tb_KU_Fax.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.B2.My.MySettings.Default, "KU_Fax", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tb_KU_Fax.Location = New System.Drawing.Point(240, 640)
        Me.tb_KU_Fax.Margin = New System.Windows.Forms.Padding(6)
        Me.tb_KU_Fax.Name = "tb_KU_Fax"
        Me.tb_KU_Fax.Size = New System.Drawing.Size(196, 31)
        Me.tb_KU_Fax.TabIndex = 13
        Me.tb_KU_Fax.Text = Global.B2.My.MySettings.Default.KU_Fax
        '
        'tb_KU_Telefon
        '
        Me.tb_KU_Telefon.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.B2.My.MySettings.Default, "KU_Telefon", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tb_KU_Telefon.Location = New System.Drawing.Point(240, 588)
        Me.tb_KU_Telefon.Margin = New System.Windows.Forms.Padding(6)
        Me.tb_KU_Telefon.Name = "tb_KU_Telefon"
        Me.tb_KU_Telefon.Size = New System.Drawing.Size(196, 31)
        Me.tb_KU_Telefon.TabIndex = 12
        Me.tb_KU_Telefon.Text = Global.B2.My.MySettings.Default.KU_Telefon
        '
        'tb_KU_PostOrt
        '
        Me.tb_KU_PostOrt.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.B2.My.MySettings.Default, "KU_PostOrt", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tb_KU_PostOrt.Location = New System.Drawing.Point(240, 538)
        Me.tb_KU_PostOrt.Margin = New System.Windows.Forms.Padding(6)
        Me.tb_KU_PostOrt.Name = "tb_KU_PostOrt"
        Me.tb_KU_PostOrt.Size = New System.Drawing.Size(428, 31)
        Me.tb_KU_PostOrt.TabIndex = 11
        Me.tb_KU_PostOrt.Text = Global.B2.My.MySettings.Default.KU_PostOrt
        '
        'tb_KU_PostNR
        '
        Me.tb_KU_PostNR.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.B2.My.MySettings.Default, "KU_PostNR", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tb_KU_PostNR.Location = New System.Drawing.Point(240, 487)
        Me.tb_KU_PostNR.Margin = New System.Windows.Forms.Padding(6)
        Me.tb_KU_PostNR.Name = "tb_KU_PostNR"
        Me.tb_KU_PostNR.Size = New System.Drawing.Size(106, 31)
        Me.tb_KU_PostNR.TabIndex = 10
        Me.tb_KU_PostNR.Text = Global.B2.My.MySettings.Default.KU_PostNR
        '
        'tb_KU_Adress
        '
        Me.tb_KU_Adress.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.B2.My.MySettings.Default, "KU_Adress", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tb_KU_Adress.Location = New System.Drawing.Point(240, 435)
        Me.tb_KU_Adress.Margin = New System.Windows.Forms.Padding(6)
        Me.tb_KU_Adress.Name = "tb_KU_Adress"
        Me.tb_KU_Adress.Size = New System.Drawing.Size(428, 31)
        Me.tb_KU_Adress.TabIndex = 9
        Me.tb_KU_Adress.Text = Global.B2.My.MySettings.Default.KU_Adress
        '
        'tb_KU_Kontakt
        '
        Me.tb_KU_Kontakt.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.B2.My.MySettings.Default, "KU_Kontakt", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tb_KU_Kontakt.Location = New System.Drawing.Point(240, 383)
        Me.tb_KU_Kontakt.Margin = New System.Windows.Forms.Padding(6)
        Me.tb_KU_Kontakt.Name = "tb_KU_Kontakt"
        Me.tb_KU_Kontakt.Size = New System.Drawing.Size(428, 31)
        Me.tb_KU_Kontakt.TabIndex = 8
        Me.tb_KU_Kontakt.Text = Global.B2.My.MySettings.Default.KU_Kontakt
        '
        'tb_KU_NAMN
        '
        Me.tb_KU_NAMN.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.B2.My.MySettings.Default, "KU_Namn", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tb_KU_NAMN.Location = New System.Drawing.Point(240, 331)
        Me.tb_KU_NAMN.Margin = New System.Windows.Forms.Padding(6)
        Me.tb_KU_NAMN.Name = "tb_KU_NAMN"
        Me.tb_KU_NAMN.Size = New System.Drawing.Size(428, 31)
        Me.tb_KU_NAMN.TabIndex = 7
        Me.tb_KU_NAMN.Text = Global.B2.My.MySettings.Default.KU_Namn
        '
        'p
        '
        Me.p.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.B2.My.MySettings.Default, "KU_UG", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.p.Location = New System.Drawing.Point(240, 279)
        Me.p.Margin = New System.Windows.Forms.Padding(6)
        Me.p.Name = "p"
        Me.p.Size = New System.Drawing.Size(196, 31)
        Me.p.TabIndex = 5
        Me.p.Text = Global.B2.My.MySettings.Default.KU_UG
        '
        'bGenererarAG
        '
        Me.bGenererarAG.Location = New System.Drawing.Point(446, 116)
        Me.bGenererarAG.Margin = New System.Windows.Forms.Padding(6)
        Me.bGenererarAG.Name = "bGenererarAG"
        Me.bGenererarAG.Size = New System.Drawing.Size(150, 67)
        Me.bGenererarAG.TabIndex = 15
        Me.bGenererarAG.Text = "Skapa AG-fil..."
        Me.bGenererarAG.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.bGenererarAG.UseVisualStyleBackColor = True
        Me.bGenererarAG.Visible = False
        '
        'lMånad
        '
        Me.lMånad.AutoSize = True
        Me.lMånad.Location = New System.Drawing.Point(66, 120)
        Me.lMånad.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lMånad.Name = "lMånad"
        Me.lMånad.Size = New System.Drawing.Size(74, 25)
        Me.lMånad.TabIndex = 16
        Me.lMånad.Text = "Period"
        Me.lMånad.Visible = False
        '
        'nupPeriod
        '
        Me.nupPeriod.ForeColor = System.Drawing.Color.Black
        Me.nupPeriod.Location = New System.Drawing.Point(226, 120)
        Me.nupPeriod.Name = "nupPeriod"
        Me.nupPeriod.Size = New System.Drawing.Size(120, 31)
        Me.nupPeriod.TabIndex = 17
        Me.nupPeriod.Value = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nupPeriod.Visible = False
        '
        'bKU
        '
        Me.bKU.Location = New System.Drawing.Point(621, 93)
        Me.bKU.Name = "bKU"
        Me.bKU.Size = New System.Drawing.Size(129, 81)
        Me.bKU.TabIndex = 18
        Me.bKU.Text = "Editera KU"
        Me.bKU.UseVisualStyleBackColor = True
        '
        'FormKontrolluppgifter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(762, 852)
        Me.Controls.Add(Me.bKU)
        Me.Controls.Add(Me.nupPeriod)
        Me.Controls.Add(Me.lMånad)
        Me.Controls.Add(Me.bGenererarAG)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.tb_KU_Fax)
        Me.Controls.Add(Me.tb_KU_Telefon)
        Me.Controls.Add(Me.tb_KU_PostOrt)
        Me.Controls.Add(Me.tb_KU_PostNR)
        Me.Controls.Add(Me.tb_KU_Adress)
        Me.Controls.Add(Me.tb_KU_Kontakt)
        Me.Controls.Add(Me.tb_KU_NAMN)
        Me.Controls.Add(Me.lblUG)
        Me.Controls.Add(Me.p)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.nudMediaID)
        Me.Controls.Add(Me.bGenereraKU)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.nudÅr)
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "FormKontrolluppgifter"
        Me.Text = "Kontrolluppgifter - generera KU"
        CType(Me.nudÅr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMediaID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nupPeriod, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents nudÅr As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents bGenereraKU As System.Windows.Forms.Button
    Friend WithEvents SFD_Kontrolluppgift As System.Windows.Forms.SaveFileDialog
    Friend WithEvents nudMediaID As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents p As System.Windows.Forms.TextBox
    Friend WithEvents lblUG As System.Windows.Forms.Label
    Friend WithEvents tb_KU_NAMN As System.Windows.Forms.TextBox
    Friend WithEvents tb_KU_Kontakt As System.Windows.Forms.TextBox
    Friend WithEvents tb_KU_Adress As System.Windows.Forms.TextBox
    Friend WithEvents tb_KU_PostNR As System.Windows.Forms.TextBox
    Friend WithEvents tb_KU_PostOrt As System.Windows.Forms.TextBox
    Friend WithEvents tb_KU_Telefon As System.Windows.Forms.TextBox
    Friend WithEvents tb_KU_Fax As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents bGenererarAG As System.Windows.Forms.Button
    Friend WithEvents lMånad As System.Windows.Forms.Label
    Friend WithEvents nupPeriod As System.Windows.Forms.NumericUpDown
    Friend WithEvents bKU As System.Windows.Forms.Button
End Class
