<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTransaktion_inställningar
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.TC_Konto = New System.Windows.Forms.TabControl()
        Me.tpBG = New System.Windows.Forms.TabPage()
        Me.RB_BG_ALT2 = New System.Windows.Forms.RadioButton()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.tb_BG_ALT2_BankGiro = New System.Windows.Forms.TextBox()
        Me.RB_BG_ALT1 = New System.Windows.Forms.RadioButton()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tb_BG_Meddelande = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tb_BG_Rubrik = New System.Windows.Forms.TextBox()
        Me.tb_BG_Nettorubrik = New System.Windows.Forms.TextBox()
        Me.tb_BG_Specifikation = New System.Windows.Forms.TextBox()
        Me.tb_BG_ALT1_BankGiro = New System.Windows.Forms.TextBox()
        Me.tb_BG_Produktionsnummer = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tb_BG_Produktionsdatum = New System.Windows.Forms.TextBox()
        Me.tpUTL = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TC_Konto.SuspendLayout()
        Me.tpBG.SuspendLayout()
        Me.tpUTL.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(611, 556)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 16
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 17
        Me.Cancel_Button.Text = "Cancel"
        '
        'TC_Konto
        '
        Me.TC_Konto.Controls.Add(Me.tpBG)
        Me.TC_Konto.Controls.Add(Me.tpUTL)
        Me.TC_Konto.Location = New System.Drawing.Point(13, 28)
        Me.TC_Konto.Name = "TC_Konto"
        Me.TC_Konto.SelectedIndex = 0
        Me.TC_Konto.Size = New System.Drawing.Size(733, 522)
        Me.TC_Konto.TabIndex = 1
        '
        'tpBG
        '
        Me.tpBG.Controls.Add(Me.RB_BG_ALT2)
        Me.tpBG.Controls.Add(Me.Label11)
        Me.tpBG.Controls.Add(Me.Label30)
        Me.tpBG.Controls.Add(Me.tb_BG_ALT2_BankGiro)
        Me.tpBG.Controls.Add(Me.RB_BG_ALT1)
        Me.tpBG.Controls.Add(Me.Label29)
        Me.tpBG.Controls.Add(Me.Label10)
        Me.tpBG.Controls.Add(Me.tb_BG_Meddelande)
        Me.tpBG.Controls.Add(Me.Label9)
        Me.tpBG.Controls.Add(Me.Label8)
        Me.tpBG.Controls.Add(Me.Label6)
        Me.tpBG.Controls.Add(Me.Label5)
        Me.tpBG.Controls.Add(Me.tb_BG_Rubrik)
        Me.tpBG.Controls.Add(Me.tb_BG_Nettorubrik)
        Me.tpBG.Controls.Add(Me.tb_BG_Specifikation)
        Me.tpBG.Controls.Add(Me.tb_BG_ALT1_BankGiro)
        Me.tpBG.Controls.Add(Me.tb_BG_Produktionsnummer)
        Me.tpBG.Controls.Add(Me.Label3)
        Me.tpBG.Controls.Add(Me.Label2)
        Me.tpBG.Controls.Add(Me.tb_BG_Produktionsdatum)
        Me.tpBG.Location = New System.Drawing.Point(4, 22)
        Me.tpBG.Name = "tpBG"
        Me.tpBG.Padding = New System.Windows.Forms.Padding(3)
        Me.tpBG.Size = New System.Drawing.Size(725, 496)
        Me.tpBG.TabIndex = 0
        Me.tpBG.Text = "BankGiro"
        Me.tpBG.UseVisualStyleBackColor = True
        '
        'RB_BG_ALT2
        '
        Me.RB_BG_ALT2.AutoSize = True
        Me.RB_BG_ALT2.Location = New System.Drawing.Point(122, 164)
        Me.RB_BG_ALT2.Name = "RB_BG_ALT2"
        Me.RB_BG_ALT2.Size = New System.Drawing.Size(14, 13)
        Me.RB_BG_ALT2.TabIndex = 2
        Me.RB_BG_ALT2.TabStop = True
        Me.RB_BG_ALT2.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(13, 163)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(90, 13)
        Me.Label11.TabIndex = 67
        Me.Label11.Text = "Avsändare  alt 2 :"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(27, 186)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(51, 13)
        Me.Label30.TabIndex = 66
        Me.Label30.Text = "BankGiro"
        '
        'tb_BG_ALT2_BankGiro
        '
        Me.tb_BG_ALT2_BankGiro.Location = New System.Drawing.Point(145, 183)
        Me.tb_BG_ALT2_BankGiro.Name = "tb_BG_ALT2_BankGiro"
        Me.tb_BG_ALT2_BankGiro.Size = New System.Drawing.Size(100, 20)
        Me.tb_BG_ALT2_BankGiro.TabIndex = 65
        '
        'RB_BG_ALT1
        '
        Me.RB_BG_ALT1.AutoSize = True
        Me.RB_BG_ALT1.Location = New System.Drawing.Point(123, 117)
        Me.RB_BG_ALT1.Name = "RB_BG_ALT1"
        Me.RB_BG_ALT1.Size = New System.Drawing.Size(14, 13)
        Me.RB_BG_ALT1.TabIndex = 1
        Me.RB_BG_ALT1.TabStop = True
        Me.RB_BG_ALT1.UseVisualStyleBackColor = True
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(10, 116)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(90, 13)
        Me.Label29.TabIndex = 63
        Me.Label29.Text = "Avsändare  alt 1 :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(360, 30)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(139, 13)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Meddelande på utbetalning."
        '
        'tb_BG_Meddelande
        '
        Me.tb_BG_Meddelande.Location = New System.Drawing.Point(363, 54)
        Me.tb_BG_Meddelande.Multiline = True
        Me.tb_BG_Meddelande.Name = "tb_BG_Meddelande"
        Me.tb_BG_Meddelande.Size = New System.Drawing.Size(270, 176)
        Me.tb_BG_Meddelande.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(24, 139)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 13)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "BankGiro"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 246)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Rubrik"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 272)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Nettorubrik"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 298)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Specifikation"
        '
        'tb_BG_Rubrik
        '
        Me.tb_BG_Rubrik.Location = New System.Drawing.Point(127, 243)
        Me.tb_BG_Rubrik.MaxLength = 25
        Me.tb_BG_Rubrik.Name = "tb_BG_Rubrik"
        Me.tb_BG_Rubrik.Size = New System.Drawing.Size(218, 20)
        Me.tb_BG_Rubrik.TabIndex = 5
        '
        'tb_BG_Nettorubrik
        '
        Me.tb_BG_Nettorubrik.Location = New System.Drawing.Point(127, 269)
        Me.tb_BG_Nettorubrik.MaxLength = 12
        Me.tb_BG_Nettorubrik.Name = "tb_BG_Nettorubrik"
        Me.tb_BG_Nettorubrik.Size = New System.Drawing.Size(218, 20)
        Me.tb_BG_Nettorubrik.TabIndex = 7
        '
        'tb_BG_Specifikation
        '
        Me.tb_BG_Specifikation.Location = New System.Drawing.Point(127, 295)
        Me.tb_BG_Specifikation.MaxLength = 25
        Me.tb_BG_Specifikation.Name = "tb_BG_Specifikation"
        Me.tb_BG_Specifikation.Size = New System.Drawing.Size(218, 20)
        Me.tb_BG_Specifikation.TabIndex = 8
        '
        'tb_BG_ALT1_BankGiro
        '
        Me.tb_BG_ALT1_BankGiro.Location = New System.Drawing.Point(144, 136)
        Me.tb_BG_ALT1_BankGiro.Name = "tb_BG_ALT1_BankGiro"
        Me.tb_BG_ALT1_BankGiro.Size = New System.Drawing.Size(100, 20)
        Me.tb_BG_ALT1_BankGiro.TabIndex = 4
        '
        'tb_BG_Produktionsnummer
        '
        Me.tb_BG_Produktionsnummer.Enabled = False
        Me.tb_BG_Produktionsnummer.Location = New System.Drawing.Point(126, 54)
        Me.tb_BG_Produktionsnummer.Name = "tb_BG_Produktionsnummer"
        Me.tb_BG_Produktionsnummer.Size = New System.Drawing.Size(100, 20)
        Me.tb_BG_Produktionsnummer.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Produktionsnummer"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Produktionsdatum"
        '
        'tb_BG_Produktionsdatum
        '
        Me.tb_BG_Produktionsdatum.Enabled = False
        Me.tb_BG_Produktionsdatum.Location = New System.Drawing.Point(126, 27)
        Me.tb_BG_Produktionsdatum.Name = "tb_BG_Produktionsdatum"
        Me.tb_BG_Produktionsdatum.Size = New System.Drawing.Size(100, 20)
        Me.tb_BG_Produktionsdatum.TabIndex = 0
        '
        'tpUTL
        '
        Me.tpUTL.Controls.Add(Me.Label1)
        Me.tpUTL.Location = New System.Drawing.Point(4, 22)
        Me.tpUTL.Name = "tpUTL"
        Me.tpUTL.Size = New System.Drawing.Size(725, 496)
        Me.tpUTL.TabIndex = 2
        Me.tpUTL.Text = "Utlandsbetalning"
        Me.tpUTL.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(153, 147)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Inga inställningar."
        '
        'FormTransaktion_inställningar
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(769, 597)
        Me.Controls.Add(Me.TC_Konto)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormTransaktion_inställningar"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Inställningar för bank och plusgiro filer."
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TC_Konto.ResumeLayout(False)
        Me.tpBG.ResumeLayout(False)
        Me.tpBG.PerformLayout()
        Me.tpUTL.ResumeLayout(False)
        Me.tpUTL.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents TC_Konto As System.Windows.Forms.TabControl
    Friend WithEvents tpBG As System.Windows.Forms.TabPage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tb_BG_Produktionsdatum As System.Windows.Forms.TextBox
    Friend WithEvents tpUTL As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tb_BG_Meddelande As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tb_BG_Rubrik As System.Windows.Forms.TextBox
    Friend WithEvents tb_BG_Nettorubrik As System.Windows.Forms.TextBox
    Friend WithEvents tb_BG_Specifikation As System.Windows.Forms.TextBox
    Friend WithEvents tb_BG_ALT1_BankGiro As System.Windows.Forms.TextBox
    Friend WithEvents tb_BG_Produktionsnummer As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents RB_BG_ALT1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents RB_BG_ALT2 As System.Windows.Forms.RadioButton
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents tb_BG_ALT2_BankGiro As System.Windows.Forms.TextBox

End Class
