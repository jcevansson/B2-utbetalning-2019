<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTransaktion
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArkivToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RapporterMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.Rapport_Bokföring = New System.Windows.Forms.ToolStripMenuItem()
        Me.Rapport_Prognos = New System.Windows.Forms.ToolStripMenuItem()
        Me.Rapport_Acconto = New System.Windows.Forms.ToolStripMenuItem()
        Me.SparaSomExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AvslutaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SorteringToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EfternamnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Sort_Namn_Upp = New System.Windows.Forms.ToolStripMenuItem()
        Me.Sort_Namn_Ned = New System.Windows.Forms.ToolStripMenuItem()
        Me.UtförToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SkickaTillbakaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BankGirofilToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InställningarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SkapaBG = New System.Windows.Forms.ToolStripMenuItem()
        Me.PostGiroFilToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InställningarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.skapaPG = New System.Windows.Forms.ToolStripMenuItem()
        Me.UtlandsbetalningToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.skapaUTL = New System.Windows.Forms.ToolStripMenuItem()
        Me.HjälpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.flpStatus = New System.Windows.Forms.FlowLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Filter_Konto_Typ = New System.Windows.Forms.CheckedListBox()
        Me.Filter_Mottagartyp = New System.Windows.Forms.CheckedListBox()
        Me.p_Rättighetshavare = New System.Windows.Forms.TableLayoutPanel()
        Me.lbl_Filter_Förnamn_Rättighetshavare = New System.Windows.Forms.Label()
        Me.lbl_Filter_Efternamn_LTGT = New System.Windows.Forms.Label()
        Me.tb_Filter_Efternamn_Rättighetshavare = New System.Windows.Forms.TextBox()
        Me.tb_Filter_Förnamn_Rättighetshavare = New System.Windows.Forms.TextBox()
        Me.cb_Filter_Efternamn_GT_Rättighetshavare = New System.Windows.Forms.ComboBox()
        Me.cb_Filter_Efternamn_LT_Rättighetshavare = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lbl_Filter_Efternamn_Rättighetshavare = New System.Windows.Forms.Label()
        Me.lbl_Filter_PNR_Rättighetshavare = New System.Windows.Forms.Label()
        Me.tb_Filter_PNR_Rättighetshavare = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tb_filter_clearing = New System.Windows.Forms.TextBox()
        Me.tb_filter_kontonr = New System.Windows.Forms.TextBox()
        Me.cb_Filter_Betalning_Typ = New System.Windows.Forms.CheckedListBox()
        Me.p_Uphovsman = New System.Windows.Forms.TableLayoutPanel()
        Me.lbl_PNR = New System.Windows.Forms.Label()
        Me.dt_Filter_To = New System.Windows.Forms.DateTimePicker()
        Me.dt_Filter_From = New System.Windows.Forms.DateTimePicker()
        Me.lblFilter_Förnamn = New System.Windows.Forms.Label()
        Me.lbl_Efternamn_GTLT = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tb_Filter_Efternamn = New System.Windows.Forms.TextBox()
        Me.tb_Filter_Förnamn = New System.Windows.Forms.TextBox()
        Me.cb_Filter_Efternamn_LT = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblFilter_Efternamn = New System.Windows.Forms.Label()
        Me.cb_Filter_Efternamn_GT = New System.Windows.Forms.ComboBox()
        Me.tb_Filter_PNR = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cb_Filter_Status = New System.Windows.Forms.ComboBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.cb_Filter_Transaktionstyp = New System.Windows.Forms.CheckedListBox()
        Me.lblTransaktionstyp = New System.Windows.Forms.Label()
        Me.cb_DescAsc = New System.Windows.Forms.ComboBox()
        Me.bUtför = New System.Windows.Forms.Button()
        Me.TLPSum = New System.Windows.Forms.TableLayoutPanel()
        Me.lblAntalRader = New System.Windows.Forms.Label()
        Me.lblTotalAmount = New System.Windows.Forms.Label()
        Me.lblTot = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblBrutto = New System.Windows.Forms.Label()
        Me.pbProgress = New System.Windows.Forms.ProgressBar()
        Me.SFD_BG = New System.Windows.Forms.SaveFileDialog()
        Me.SFD_PG = New System.Windows.Forms.SaveFileDialog()
        Me.SFD_Excelark = New System.Windows.Forms.SaveFileDialog()
        Me.FBD_Excelark = New System.Windows.Forms.FolderBrowserDialog()
        Me.TransTreeView = New B2.TransaktionGroupTreeView()
        Me.MenuStrip1.SuspendLayout()
        Me.flpStatus.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.p_Rättighetshavare.SuspendLayout()
        Me.p_Uphovsman.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TLPSum.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AutoSize = False
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArkivToolStripMenuItem, Me.SorteringToolStripMenuItem, Me.UtförToolStripMenuItem, Me.HjälpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.ShowItemToolTips = True
        Me.MenuStrip1.Size = New System.Drawing.Size(1354, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArkivToolStripMenuItem
        '
        Me.ArkivToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RapporterMI, Me.SparaSomExcelToolStripMenuItem, Me.AvslutaToolStripMenuItem})
        Me.ArkivToolStripMenuItem.Name = "ArkivToolStripMenuItem"
        Me.ArkivToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.ArkivToolStripMenuItem.Text = "&Arkiv"
        '
        'RapporterMI
        '
        Me.RapporterMI.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Rapport_Bokföring, Me.Rapport_Prognos, Me.Rapport_Acconto})
        Me.RapporterMI.Name = "RapporterMI"
        Me.RapporterMI.Size = New System.Drawing.Size(159, 22)
        Me.RapporterMI.Text = "Rapporter"
        '
        'Rapport_Bokföring
        '
        Me.Rapport_Bokföring.Name = "Rapport_Bokföring"
        Me.Rapport_Bokföring.Size = New System.Drawing.Size(178, 22)
        Me.Rapport_Bokföring.Text = "Bokföringsunderlag"
        '
        'Rapport_Prognos
        '
        Me.Rapport_Prognos.Name = "Rapport_Prognos"
        Me.Rapport_Prognos.Size = New System.Drawing.Size(178, 22)
        Me.Rapport_Prognos.Text = "Prognos"
        Me.Rapport_Prognos.ToolTipText = "Utbetalningsprognos "
        '
        'Rapport_Acconto
        '
        Me.Rapport_Acconto.Enabled = False
        Me.Rapport_Acconto.Name = "Rapport_Acconto"
        Me.Rapport_Acconto.Size = New System.Drawing.Size(178, 22)
        Me.Rapport_Acconto.Text = "Kontosummeringar"
        Me.Rapport_Acconto.ToolTipText = "Acconto sammanställningar"
        '
        'SparaSomExcelToolStripMenuItem
        '
        Me.SparaSomExcelToolStripMenuItem.Name = "SparaSomExcelToolStripMenuItem"
        Me.SparaSomExcelToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.SparaSomExcelToolStripMenuItem.Text = "Spara som E&xcel"
        Me.SparaSomExcelToolStripMenuItem.ToolTipText = "Excelrapport till systerorganisation"
        '
        'AvslutaToolStripMenuItem
        '
        Me.AvslutaToolStripMenuItem.Name = "AvslutaToolStripMenuItem"
        Me.AvslutaToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.AvslutaToolStripMenuItem.Text = "&Stäng"
        Me.AvslutaToolStripMenuItem.ToolTipText = "Stänger detta fönster."
        '
        'SorteringToolStripMenuItem
        '
        Me.SorteringToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EfternamnToolStripMenuItem})
        Me.SorteringToolStripMenuItem.Name = "SorteringToolStripMenuItem"
        Me.SorteringToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.SorteringToolStripMenuItem.Text = "&Sortering"
        '
        'EfternamnToolStripMenuItem
        '
        Me.EfternamnToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
        Me.EfternamnToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Sort_Namn_Upp, Me.Sort_Namn_Ned})
        Me.EfternamnToolStripMenuItem.Name = "EfternamnToolStripMenuItem"
        Me.EfternamnToolStripMenuItem.Size = New System.Drawing.Size(108, 22)
        Me.EfternamnToolStripMenuItem.Text = "Rubrik"
        '
        'Sort_Namn_Upp
        '
        Me.Sort_Namn_Upp.Checked = True
        Me.Sort_Namn_Upp.CheckOnClick = True
        Me.Sort_Namn_Upp.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Sort_Namn_Upp.Name = "Sort_Namn_Upp"
        Me.Sort_Namn_Upp.Size = New System.Drawing.Size(120, 22)
        Me.Sort_Namn_Upp.Text = "&Stigande"
        Me.Sort_Namn_Upp.ToolTipText = "Sortera listan på efternamn."
        '
        'Sort_Namn_Ned
        '
        Me.Sort_Namn_Ned.CheckOnClick = True
        Me.Sort_Namn_Ned.Name = "Sort_Namn_Ned"
        Me.Sort_Namn_Ned.Size = New System.Drawing.Size(120, 22)
        Me.Sort_Namn_Ned.Text = "&Fallande"
        '
        'UtförToolStripMenuItem
        '
        Me.UtförToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SkickaTillbakaToolStripMenuItem, Me.BankGirofilToolStripMenuItem, Me.PostGiroFilToolStripMenuItem, Me.UtlandsbetalningToolStripMenuItem})
        Me.UtförToolStripMenuItem.Name = "UtförToolStripMenuItem"
        Me.UtförToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.UtförToolStripMenuItem.Text = "Utför"
        '
        'SkickaTillbakaToolStripMenuItem
        '
        Me.SkickaTillbakaToolStripMenuItem.Enabled = False
        Me.SkickaTillbakaToolStripMenuItem.Name = "SkickaTillbakaToolStripMenuItem"
        Me.SkickaTillbakaToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.SkickaTillbakaToolStripMenuItem.Text = "Skicka tillbaka till godkänd"
        '
        'BankGirofilToolStripMenuItem
        '
        Me.BankGirofilToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InställningarToolStripMenuItem1, Me.SkapaBG})
        Me.BankGirofilToolStripMenuItem.Name = "BankGirofilToolStripMenuItem"
        Me.BankGirofilToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.BankGirofilToolStripMenuItem.Text = "BankGirofil"
        '
        'InställningarToolStripMenuItem1
        '
        Me.InställningarToolStripMenuItem1.Name = "InställningarToolStripMenuItem1"
        Me.InställningarToolStripMenuItem1.Size = New System.Drawing.Size(139, 22)
        Me.InställningarToolStripMenuItem1.Text = "Inställningar"
        '
        'SkapaBG
        '
        Me.SkapaBG.Name = "SkapaBG"
        Me.SkapaBG.Size = New System.Drawing.Size(139, 22)
        Me.SkapaBG.Text = "Skapa fil"
        '
        'PostGiroFilToolStripMenuItem
        '
        Me.PostGiroFilToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InställningarToolStripMenuItem, Me.skapaPG})
        Me.PostGiroFilToolStripMenuItem.Name = "PostGiroFilToolStripMenuItem"
        Me.PostGiroFilToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.PostGiroFilToolStripMenuItem.Text = "PlusGirofil"
        Me.PostGiroFilToolStripMenuItem.Visible = False
        '
        'InställningarToolStripMenuItem
        '
        Me.InställningarToolStripMenuItem.Name = "InställningarToolStripMenuItem"
        Me.InställningarToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.InställningarToolStripMenuItem.Text = "Inställningar"
        '
        'skapaPG
        '
        Me.skapaPG.Name = "skapaPG"
        Me.skapaPG.Size = New System.Drawing.Size(139, 22)
        Me.skapaPG.Text = "Skapa fil"
        '
        'UtlandsbetalningToolStripMenuItem
        '
        Me.UtlandsbetalningToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.skapaUTL})
        Me.UtlandsbetalningToolStripMenuItem.Name = "UtlandsbetalningToolStripMenuItem"
        Me.UtlandsbetalningToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.UtlandsbetalningToolStripMenuItem.Text = "Utlandsbetalning"
        '
        'skapaUTL
        '
        Me.skapaUTL.Name = "skapaUTL"
        Me.skapaUTL.Size = New System.Drawing.Size(121, 22)
        Me.skapaUTL.Text = "Skapa fil."
        '
        'HjälpToolStripMenuItem
        '
        Me.HjälpToolStripMenuItem.Name = "HjälpToolStripMenuItem"
        Me.HjälpToolStripMenuItem.Size = New System.Drawing.Size(47, 20)
        Me.HjälpToolStripMenuItem.Text = "&Hjälp"
        '
        'flpStatus
        '
        Me.flpStatus.AutoSize = True
        Me.flpStatus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.flpStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.flpStatus.Controls.Add(Me.TableLayoutPanel2)
        Me.flpStatus.Controls.Add(Me.cb_Filter_Betalning_Typ)
        Me.flpStatus.Controls.Add(Me.p_Uphovsman)
        Me.flpStatus.Controls.Add(Me.TableLayoutPanel1)
        Me.flpStatus.Controls.Add(Me.bUtför)
        Me.flpStatus.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.flpStatus.Dock = System.Windows.Forms.DockStyle.Top
        Me.flpStatus.Location = New System.Drawing.Point(0, 24)
        Me.flpStatus.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.flpStatus.MinimumSize = New System.Drawing.Size(10, 10)
        Me.flpStatus.Name = "flpStatus"
        Me.flpStatus.Size = New System.Drawing.Size(1354, 164)
        Me.flpStatus.TabIndex = 1
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.Filter_Konto_Typ, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Filter_Mottagartyp, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.p_Rättighetshavare, 0, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(2, 2)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(2)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(440, 158)
        Me.TableLayoutPanel2.TabIndex = 36
        '
        'Filter_Konto_Typ
        '
        Me.Filter_Konto_Typ.FormattingEnabled = True
        Me.Filter_Konto_Typ.Items.AddRange(New Object() {"AVI", "Bankgiro", "Bankkonto", "Plusgiro"})
        Me.Filter_Konto_Typ.Location = New System.Drawing.Point(330, 2)
        Me.Filter_Konto_Typ.Margin = New System.Windows.Forms.Padding(2)
        Me.Filter_Konto_Typ.Name = "Filter_Konto_Typ"
        Me.Filter_Konto_Typ.Size = New System.Drawing.Size(90, 34)
        Me.Filter_Konto_Typ.TabIndex = 7
        '
        'Filter_Mottagartyp
        '
        Me.Filter_Mottagartyp.FormattingEnabled = True
        Me.Filter_Mottagartyp.Items.AddRange(New Object() {"Ombud", "Rättighetsh.", "Systerorg.", "Upphovsmän"})
        Me.Filter_Mottagartyp.Location = New System.Drawing.Point(230, 2)
        Me.Filter_Mottagartyp.Margin = New System.Windows.Forms.Padding(2)
        Me.Filter_Mottagartyp.Name = "Filter_Mottagartyp"
        Me.Filter_Mottagartyp.Size = New System.Drawing.Size(96, 34)
        Me.Filter_Mottagartyp.TabIndex = 6
        '
        'p_Rättighetshavare
        '
        Me.p_Rättighetshavare.ColumnCount = 4
        Me.p_Rättighetshavare.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 68.0!))
        Me.p_Rättighetshavare.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.p_Rättighetshavare.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.p_Rättighetshavare.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86.0!))
        Me.p_Rättighetshavare.Controls.Add(Me.lbl_Filter_Förnamn_Rättighetshavare, 0, 1)
        Me.p_Rättighetshavare.Controls.Add(Me.lbl_Filter_Efternamn_LTGT, 0, 2)
        Me.p_Rättighetshavare.Controls.Add(Me.tb_Filter_Efternamn_Rättighetshavare, 1, 0)
        Me.p_Rättighetshavare.Controls.Add(Me.tb_Filter_Förnamn_Rättighetshavare, 1, 1)
        Me.p_Rättighetshavare.Controls.Add(Me.cb_Filter_Efternamn_GT_Rättighetshavare, 1, 2)
        Me.p_Rättighetshavare.Controls.Add(Me.cb_Filter_Efternamn_LT_Rättighetshavare, 3, 2)
        Me.p_Rättighetshavare.Controls.Add(Me.Label10, 2, 2)
        Me.p_Rättighetshavare.Controls.Add(Me.lbl_Filter_Efternamn_Rättighetshavare, 0, 0)
        Me.p_Rättighetshavare.Controls.Add(Me.lbl_Filter_PNR_Rättighetshavare, 0, 3)
        Me.p_Rättighetshavare.Controls.Add(Me.tb_Filter_PNR_Rättighetshavare, 1, 3)
        Me.p_Rättighetshavare.Controls.Add(Me.Label1, 0, 5)
        Me.p_Rättighetshavare.Controls.Add(Me.tb_filter_clearing, 1, 5)
        Me.p_Rättighetshavare.Controls.Add(Me.tb_filter_kontonr, 3, 5)
        Me.p_Rättighetshavare.Location = New System.Drawing.Point(2, 2)
        Me.p_Rättighetshavare.Margin = New System.Windows.Forms.Padding(2)
        Me.p_Rättighetshavare.Name = "p_Rättighetshavare"
        Me.p_Rättighetshavare.RowCount = 7
        Me.p_Rättighetshavare.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.p_Rättighetshavare.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.p_Rättighetshavare.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.p_Rättighetshavare.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.p_Rättighetshavare.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16.0!))
        Me.p_Rättighetshavare.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16.0!))
        Me.p_Rättighetshavare.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16.0!))
        Me.p_Rättighetshavare.Size = New System.Drawing.Size(224, 133)
        Me.p_Rättighetshavare.TabIndex = 19
        '
        'lbl_Filter_Förnamn_Rättighetshavare
        '
        Me.lbl_Filter_Förnamn_Rättighetshavare.AutoSize = True
        Me.lbl_Filter_Förnamn_Rättighetshavare.Location = New System.Drawing.Point(2, 24)
        Me.lbl_Filter_Förnamn_Rättighetshavare.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_Filter_Förnamn_Rättighetshavare.Name = "lbl_Filter_Förnamn_Rättighetshavare"
        Me.lbl_Filter_Förnamn_Rättighetshavare.Size = New System.Drawing.Size(48, 13)
        Me.lbl_Filter_Förnamn_Rättighetshavare.TabIndex = 6
        Me.lbl_Filter_Förnamn_Rättighetshavare.Text = "Förnamn"
        '
        'lbl_Filter_Efternamn_LTGT
        '
        Me.lbl_Filter_Efternamn_LTGT.AutoSize = True
        Me.lbl_Filter_Efternamn_LTGT.Location = New System.Drawing.Point(2, 48)
        Me.lbl_Filter_Efternamn_LTGT.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_Filter_Efternamn_LTGT.Name = "lbl_Filter_Efternamn_LTGT"
        Me.lbl_Filter_Efternamn_LTGT.Size = New System.Drawing.Size(55, 13)
        Me.lbl_Filter_Efternamn_LTGT.TabIndex = 7
        Me.lbl_Filter_Efternamn_LTGT.Text = "Efternamn"
        '
        'tb_Filter_Efternamn_Rättighetshavare
        '
        Me.p_Rättighetshavare.SetColumnSpan(Me.tb_Filter_Efternamn_Rättighetshavare, 3)
        Me.tb_Filter_Efternamn_Rättighetshavare.Location = New System.Drawing.Point(70, 2)
        Me.tb_Filter_Efternamn_Rättighetshavare.Margin = New System.Windows.Forms.Padding(2)
        Me.tb_Filter_Efternamn_Rättighetshavare.Name = "tb_Filter_Efternamn_Rättighetshavare"
        Me.tb_Filter_Efternamn_Rättighetshavare.Size = New System.Drawing.Size(152, 20)
        Me.tb_Filter_Efternamn_Rättighetshavare.TabIndex = 1
        '
        'tb_Filter_Förnamn_Rättighetshavare
        '
        Me.p_Rättighetshavare.SetColumnSpan(Me.tb_Filter_Förnamn_Rättighetshavare, 3)
        Me.tb_Filter_Förnamn_Rättighetshavare.Location = New System.Drawing.Point(70, 26)
        Me.tb_Filter_Förnamn_Rättighetshavare.Margin = New System.Windows.Forms.Padding(2)
        Me.tb_Filter_Förnamn_Rättighetshavare.Name = "tb_Filter_Förnamn_Rättighetshavare"
        Me.tb_Filter_Förnamn_Rättighetshavare.Size = New System.Drawing.Size(152, 20)
        Me.tb_Filter_Förnamn_Rättighetshavare.TabIndex = 2
        '
        'cb_Filter_Efternamn_GT_Rättighetshavare
        '
        Me.cb_Filter_Efternamn_GT_Rättighetshavare.FormattingEnabled = True
        Me.cb_Filter_Efternamn_GT_Rättighetshavare.Items.AddRange(New Object() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "X", "Y", "Z", "Å", "Ä", "Ö"})
        Me.cb_Filter_Efternamn_GT_Rättighetshavare.Location = New System.Drawing.Point(70, 50)
        Me.cb_Filter_Efternamn_GT_Rättighetshavare.Margin = New System.Windows.Forms.Padding(2)
        Me.cb_Filter_Efternamn_GT_Rättighetshavare.Name = "cb_Filter_Efternamn_GT_Rättighetshavare"
        Me.cb_Filter_Efternamn_GT_Rättighetshavare.Size = New System.Drawing.Size(46, 21)
        Me.cb_Filter_Efternamn_GT_Rättighetshavare.TabIndex = 3
        '
        'cb_Filter_Efternamn_LT_Rättighetshavare
        '
        Me.cb_Filter_Efternamn_LT_Rättighetshavare.FormattingEnabled = True
        Me.cb_Filter_Efternamn_LT_Rättighetshavare.Items.AddRange(New Object() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "X", "Y", "Z", "Å", "Ä", "Ö"})
        Me.cb_Filter_Efternamn_LT_Rättighetshavare.Location = New System.Drawing.Point(140, 50)
        Me.cb_Filter_Efternamn_LT_Rättighetshavare.Margin = New System.Windows.Forms.Padding(2)
        Me.cb_Filter_Efternamn_LT_Rättighetshavare.Name = "cb_Filter_Efternamn_LT_Rättighetshavare"
        Me.cb_Filter_Efternamn_LT_Rättighetshavare.Size = New System.Drawing.Size(44, 21)
        Me.cb_Filter_Efternamn_LT_Rättighetshavare.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(120, 48)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(10, 13)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "-"
        '
        'lbl_Filter_Efternamn_Rättighetshavare
        '
        Me.lbl_Filter_Efternamn_Rättighetshavare.AutoSize = True
        Me.lbl_Filter_Efternamn_Rättighetshavare.Location = New System.Drawing.Point(2, 0)
        Me.lbl_Filter_Efternamn_Rättighetshavare.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_Filter_Efternamn_Rättighetshavare.Name = "lbl_Filter_Efternamn_Rättighetshavare"
        Me.lbl_Filter_Efternamn_Rättighetshavare.Size = New System.Drawing.Size(55, 13)
        Me.lbl_Filter_Efternamn_Rättighetshavare.TabIndex = 2
        Me.lbl_Filter_Efternamn_Rättighetshavare.Text = "Efternamn"
        '
        'lbl_Filter_PNR_Rättighetshavare
        '
        Me.lbl_Filter_PNR_Rättighetshavare.AutoSize = True
        Me.lbl_Filter_PNR_Rättighetshavare.Location = New System.Drawing.Point(2, 73)
        Me.lbl_Filter_PNR_Rättighetshavare.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_Filter_PNR_Rättighetshavare.Name = "lbl_Filter_PNR_Rättighetshavare"
        Me.lbl_Filter_PNR_Rättighetshavare.Size = New System.Drawing.Size(52, 13)
        Me.lbl_Filter_PNR_Rättighetshavare.TabIndex = 13
        Me.lbl_Filter_PNR_Rättighetshavare.Text = "Personnr."
        '
        'tb_Filter_PNR_Rättighetshavare
        '
        Me.p_Rättighetshavare.SetColumnSpan(Me.tb_Filter_PNR_Rättighetshavare, 3)
        Me.tb_Filter_PNR_Rättighetshavare.Location = New System.Drawing.Point(70, 75)
        Me.tb_Filter_PNR_Rättighetshavare.Margin = New System.Windows.Forms.Padding(2)
        Me.tb_Filter_PNR_Rättighetshavare.Name = "tb_Filter_PNR_Rättighetshavare"
        Me.tb_Filter_PNR_Rättighetshavare.Size = New System.Drawing.Size(150, 20)
        Me.tb_Filter_PNR_Rättighetshavare.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 113)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Konto"
        '
        'tb_filter_clearing
        '
        Me.tb_filter_clearing.Location = New System.Drawing.Point(70, 115)
        Me.tb_filter_clearing.Margin = New System.Windows.Forms.Padding(2)
        Me.tb_filter_clearing.Name = "tb_filter_clearing"
        Me.tb_filter_clearing.Size = New System.Drawing.Size(46, 20)
        Me.tb_filter_clearing.TabIndex = 15
        '
        'tb_filter_kontonr
        '
        Me.tb_filter_kontonr.Location = New System.Drawing.Point(140, 115)
        Me.tb_filter_kontonr.Margin = New System.Windows.Forms.Padding(2)
        Me.tb_filter_kontonr.Name = "tb_filter_kontonr"
        Me.tb_filter_kontonr.Size = New System.Drawing.Size(76, 20)
        Me.tb_filter_kontonr.TabIndex = 16
        '
        'cb_Filter_Betalning_Typ
        '
        Me.cb_Filter_Betalning_Typ.FormattingEnabled = True
        Me.cb_Filter_Betalning_Typ.Items.AddRange(New Object() {"Följerätt", "IV", "IR", "IR-Bildbyrå", "IR-Foto", "IR-Dagpress-foto", "IR-Dagpress-illustration", "KR", "Repro", "Sveriges tidskrifter", "TV", "TV-foto", "TV4", "TV4-foto", "TVCopy", "TVCopy-foto", "TV4-Copy", "TV4-Copy-Foto"})
        Me.cb_Filter_Betalning_Typ.Location = New System.Drawing.Point(446, 2)
        Me.cb_Filter_Betalning_Typ.Margin = New System.Windows.Forms.Padding(2)
        Me.cb_Filter_Betalning_Typ.MultiColumn = True
        Me.cb_Filter_Betalning_Typ.Name = "cb_Filter_Betalning_Typ"
        Me.cb_Filter_Betalning_Typ.Size = New System.Drawing.Size(246, 139)
        Me.cb_Filter_Betalning_Typ.TabIndex = 8
        '
        'p_Uphovsman
        '
        Me.p_Uphovsman.ColumnCount = 4
        Me.p_Uphovsman.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94.0!))
        Me.p_Uphovsman.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.p_Uphovsman.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.p_Uphovsman.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74.0!))
        Me.p_Uphovsman.Controls.Add(Me.lbl_PNR, 0, 4)
        Me.p_Uphovsman.Controls.Add(Me.dt_Filter_To, 3, 5)
        Me.p_Uphovsman.Controls.Add(Me.dt_Filter_From, 1, 5)
        Me.p_Uphovsman.Controls.Add(Me.lblFilter_Förnamn, 0, 2)
        Me.p_Uphovsman.Controls.Add(Me.lbl_Efternamn_GTLT, 0, 3)
        Me.p_Uphovsman.Controls.Add(Me.Label8, 0, 5)
        Me.p_Uphovsman.Controls.Add(Me.tb_Filter_Efternamn, 1, 0)
        Me.p_Uphovsman.Controls.Add(Me.tb_Filter_Förnamn, 1, 2)
        Me.p_Uphovsman.Controls.Add(Me.cb_Filter_Efternamn_LT, 3, 3)
        Me.p_Uphovsman.Controls.Add(Me.Label7, 2, 3)
        Me.p_Uphovsman.Controls.Add(Me.lblFilter_Efternamn, 0, 0)
        Me.p_Uphovsman.Controls.Add(Me.cb_Filter_Efternamn_GT, 1, 3)
        Me.p_Uphovsman.Controls.Add(Me.tb_Filter_PNR, 1, 4)
        Me.p_Uphovsman.Location = New System.Drawing.Point(696, 2)
        Me.p_Uphovsman.Margin = New System.Windows.Forms.Padding(2)
        Me.p_Uphovsman.Name = "p_Uphovsman"
        Me.p_Uphovsman.RowCount = 7
        Me.p_Uphovsman.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.p_Uphovsman.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.p_Uphovsman.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.p_Uphovsman.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.p_Uphovsman.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.p_Uphovsman.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.p_Uphovsman.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.p_Uphovsman.Size = New System.Drawing.Size(250, 138)
        Me.p_Uphovsman.TabIndex = 24
        '
        'lbl_PNR
        '
        Me.lbl_PNR.AutoSize = True
        Me.lbl_PNR.Location = New System.Drawing.Point(2, 73)
        Me.lbl_PNR.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_PNR.Name = "lbl_PNR"
        Me.lbl_PNR.Size = New System.Drawing.Size(57, 13)
        Me.lbl_PNR.TabIndex = 14
        Me.lbl_PNR.Text = "Upph. pnr."
        '
        'dt_Filter_To
        '
        Me.dt_Filter_To.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_Filter_To.Location = New System.Drawing.Point(178, 99)
        Me.dt_Filter_To.Margin = New System.Windows.Forms.Padding(2)
        Me.dt_Filter_To.Name = "dt_Filter_To"
        Me.dt_Filter_To.Size = New System.Drawing.Size(70, 20)
        Me.dt_Filter_To.TabIndex = 17
        '
        'dt_Filter_From
        '
        Me.p_Uphovsman.SetColumnSpan(Me.dt_Filter_From, 2)
        Me.dt_Filter_From.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_Filter_From.Location = New System.Drawing.Point(96, 99)
        Me.dt_Filter_From.Margin = New System.Windows.Forms.Padding(2)
        Me.dt_Filter_From.Name = "dt_Filter_From"
        Me.dt_Filter_From.Size = New System.Drawing.Size(74, 20)
        Me.dt_Filter_From.TabIndex = 16
        '
        'lblFilter_Förnamn
        '
        Me.lblFilter_Förnamn.AutoSize = True
        Me.lblFilter_Förnamn.Location = New System.Drawing.Point(2, 24)
        Me.lblFilter_Förnamn.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblFilter_Förnamn.Name = "lblFilter_Förnamn"
        Me.lblFilter_Förnamn.Size = New System.Drawing.Size(80, 13)
        Me.lblFilter_Förnamn.TabIndex = 6
        Me.lblFilter_Förnamn.Text = "Upph. Förnamn"
        '
        'lbl_Efternamn_GTLT
        '
        Me.lbl_Efternamn_GTLT.AutoSize = True
        Me.lbl_Efternamn_GTLT.Location = New System.Drawing.Point(2, 48)
        Me.lbl_Efternamn_GTLT.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_Efternamn_GTLT.Name = "lbl_Efternamn_GTLT"
        Me.lbl_Efternamn_GTLT.Size = New System.Drawing.Size(87, 13)
        Me.lbl_Efternamn_GTLT.TabIndex = 7
        Me.lbl_Efternamn_GTLT.Text = "Upph. Efternamn"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(2, 97)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Datum:"
        '
        'tb_Filter_Efternamn
        '
        Me.p_Uphovsman.SetColumnSpan(Me.tb_Filter_Efternamn, 3)
        Me.tb_Filter_Efternamn.Location = New System.Drawing.Point(96, 2)
        Me.tb_Filter_Efternamn.Margin = New System.Windows.Forms.Padding(2)
        Me.tb_Filter_Efternamn.Name = "tb_Filter_Efternamn"
        Me.tb_Filter_Efternamn.Size = New System.Drawing.Size(150, 20)
        Me.tb_Filter_Efternamn.TabIndex = 10
        '
        'tb_Filter_Förnamn
        '
        Me.p_Uphovsman.SetColumnSpan(Me.tb_Filter_Förnamn, 3)
        Me.tb_Filter_Förnamn.Location = New System.Drawing.Point(96, 26)
        Me.tb_Filter_Förnamn.Margin = New System.Windows.Forms.Padding(2)
        Me.tb_Filter_Förnamn.Name = "tb_Filter_Förnamn"
        Me.tb_Filter_Förnamn.Size = New System.Drawing.Size(150, 20)
        Me.tb_Filter_Förnamn.TabIndex = 11
        '
        'cb_Filter_Efternamn_LT
        '
        Me.cb_Filter_Efternamn_LT.FormattingEnabled = True
        Me.cb_Filter_Efternamn_LT.Items.AddRange(New Object() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "X", "Y", "Z", "Å", "Ä", "Ö"})
        Me.cb_Filter_Efternamn_LT.Location = New System.Drawing.Point(178, 50)
        Me.cb_Filter_Efternamn_LT.Margin = New System.Windows.Forms.Padding(2)
        Me.cb_Filter_Efternamn_LT.Name = "cb_Filter_Efternamn_LT"
        Me.cb_Filter_Efternamn_LT.Size = New System.Drawing.Size(44, 21)
        Me.cb_Filter_Efternamn_LT.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(168, 48)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(6, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "-"
        '
        'lblFilter_Efternamn
        '
        Me.lblFilter_Efternamn.AutoSize = True
        Me.lblFilter_Efternamn.Location = New System.Drawing.Point(2, 0)
        Me.lblFilter_Efternamn.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblFilter_Efternamn.Name = "lblFilter_Efternamn"
        Me.lblFilter_Efternamn.Size = New System.Drawing.Size(87, 13)
        Me.lblFilter_Efternamn.TabIndex = 2
        Me.lblFilter_Efternamn.Text = "Upph. Efternamn"
        '
        'cb_Filter_Efternamn_GT
        '
        Me.cb_Filter_Efternamn_GT.FormattingEnabled = True
        Me.cb_Filter_Efternamn_GT.Items.AddRange(New Object() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "X", "Y", "Z", "Å", "Ä", "Ö"})
        Me.cb_Filter_Efternamn_GT.Location = New System.Drawing.Point(96, 50)
        Me.cb_Filter_Efternamn_GT.Margin = New System.Windows.Forms.Padding(2)
        Me.cb_Filter_Efternamn_GT.Name = "cb_Filter_Efternamn_GT"
        Me.cb_Filter_Efternamn_GT.Size = New System.Drawing.Size(46, 21)
        Me.cb_Filter_Efternamn_GT.TabIndex = 12
        '
        'tb_Filter_PNR
        '
        Me.p_Uphovsman.SetColumnSpan(Me.tb_Filter_PNR, 3)
        Me.tb_Filter_PNR.Location = New System.Drawing.Point(96, 75)
        Me.tb_Filter_PNR.Margin = New System.Windows.Forms.Padding(2)
        Me.tb_Filter_PNR.Name = "tb_Filter_PNR"
        Me.tb_Filter_PNR.Size = New System.Drawing.Size(150, 20)
        Me.tb_Filter_PNR.TabIndex = 15
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.Label11, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cb_Filter_Status, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblStatus, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.cb_Filter_Transaktionstyp, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTransaktionstyp, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.cb_DescAsc, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(950, 2)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(238, 138)
        Me.TableLayoutPanel1.TabIndex = 35
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(2, 0)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(52, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Sortering:"
        '
        'cb_Filter_Status
        '
        Me.cb_Filter_Status.FormattingEnabled = True
        Me.cb_Filter_Status.Items.AddRange(New Object() {"Betalda", "Ej betalda", "Alla"})
        Me.cb_Filter_Status.Location = New System.Drawing.Point(58, 27)
        Me.cb_Filter_Status.Margin = New System.Windows.Forms.Padding(2)
        Me.cb_Filter_Status.Name = "cb_Filter_Status"
        Me.cb_Filter_Status.Size = New System.Drawing.Size(74, 21)
        Me.cb_Filter_Status.TabIndex = 21
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(2, 25)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(37, 13)
        Me.lblStatus.TabIndex = 22
        Me.lblStatus.Text = "Status"
        '
        'cb_Filter_Transaktionstyp
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.cb_Filter_Transaktionstyp, 2)
        Me.cb_Filter_Transaktionstyp.FormattingEnabled = True
        Me.cb_Filter_Transaktionstyp.Items.AddRange(New Object() {"PlusGiro", "BankGiro", "Utlandsbetalningar"})
        Me.cb_Filter_Transaktionstyp.Location = New System.Drawing.Point(58, 52)
        Me.cb_Filter_Transaktionstyp.Margin = New System.Windows.Forms.Padding(2)
        Me.cb_Filter_Transaktionstyp.Name = "cb_Filter_Transaktionstyp"
        Me.cb_Filter_Transaktionstyp.Size = New System.Drawing.Size(178, 4)
        Me.cb_Filter_Transaktionstyp.TabIndex = 23
        '
        'lblTransaktionstyp
        '
        Me.lblTransaktionstyp.AutoSize = True
        Me.lblTransaktionstyp.Location = New System.Drawing.Point(2, 50)
        Me.lblTransaktionstyp.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblTransaktionstyp.Name = "lblTransaktionstyp"
        Me.lblTransaktionstyp.Size = New System.Drawing.Size(40, 13)
        Me.lblTransaktionstyp.TabIndex = 24
        Me.lblTransaktionstyp.Text = "Girotyp"
        '
        'cb_DescAsc
        '
        Me.cb_DescAsc.FormattingEnabled = True
        Me.cb_DescAsc.Items.AddRange(New Object() {"Stigande", "Fallande"})
        Me.cb_DescAsc.Location = New System.Drawing.Point(58, 2)
        Me.cb_DescAsc.Margin = New System.Windows.Forms.Padding(2)
        Me.cb_DescAsc.Name = "cb_DescAsc"
        Me.cb_DescAsc.Size = New System.Drawing.Size(74, 21)
        Me.cb_DescAsc.TabIndex = 20
        '
        'bUtför
        '
        Me.bUtför.Location = New System.Drawing.Point(1192, 3)
        Me.bUtför.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.bUtför.Name = "bUtför"
        Me.bUtför.Size = New System.Drawing.Size(42, 21)
        Me.bUtför.TabIndex = 24
        Me.bUtför.Text = "Visa"
        Me.bUtför.UseVisualStyleBackColor = True
        '
        'TLPSum
        '
        Me.TLPSum.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TLPSum.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TLPSum.ColumnCount = 4
        Me.TLPSum.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TLPSum.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109.0!))
        Me.TLPSum.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.42857!))
        Me.TLPSum.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.57143!))
        Me.TLPSum.Controls.Add(Me.lblAntalRader, 3, 1)
        Me.TLPSum.Controls.Add(Me.lblTotalAmount, 2, 1)
        Me.TLPSum.Controls.Add(Me.lblTot, 1, 1)
        Me.TLPSum.Controls.Add(Me.Label2, 1, 2)
        Me.TLPSum.Controls.Add(Me.lblBrutto, 2, 2)
        Me.TLPSum.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TLPSum.Location = New System.Drawing.Point(0, 541)
        Me.TLPSum.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TLPSum.Name = "TLPSum"
        Me.TLPSum.RowCount = 3
        Me.TLPSum.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.TLPSum.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19.0!))
        Me.TLPSum.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19.0!))
        Me.TLPSum.Size = New System.Drawing.Size(1354, 57)
        Me.TLPSum.TabIndex = 2
        '
        'lblAntalRader
        '
        Me.lblAntalRader.AutoSize = True
        Me.lblAntalRader.Location = New System.Drawing.Point(1006, 21)
        Me.lblAntalRader.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblAntalRader.Name = "lblAntalRader"
        Me.lblAntalRader.Size = New System.Drawing.Size(38, 13)
        Me.lblAntalRader.TabIndex = 4
        Me.lblAntalRader.Text = "0 av X"
        '
        'lblTotalAmount
        '
        Me.lblTotalAmount.AutoSize = True
        Me.lblTotalAmount.Location = New System.Drawing.Point(131, 21)
        Me.lblTotalAmount.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Size = New System.Drawing.Size(13, 13)
        Me.lblTotalAmount.TabIndex = 5
        Me.lblTotalAmount.Text = "0"
        '
        'lblTot
        '
        Me.lblTot.AutoSize = True
        Me.lblTot.Location = New System.Drawing.Point(22, 21)
        Me.lblTot.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblTot.Name = "lblTot"
        Me.lblTot.Size = New System.Drawing.Size(64, 13)
        Me.lblTot.TabIndex = 6
        Me.lblTot.Text = "Totalsumma"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 40)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Brutto"
        '
        'lblBrutto
        '
        Me.lblBrutto.AutoSize = True
        Me.lblBrutto.Location = New System.Drawing.Point(131, 40)
        Me.lblBrutto.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblBrutto.Name = "lblBrutto"
        Me.lblBrutto.Size = New System.Drawing.Size(13, 13)
        Me.lblBrutto.TabIndex = 8
        Me.lblBrutto.Text = "0"
        '
        'pbProgress
        '
        Me.pbProgress.Location = New System.Drawing.Point(34, 387)
        Me.pbProgress.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.pbProgress.Name = "pbProgress"
        Me.pbProgress.Size = New System.Drawing.Size(348, 23)
        Me.pbProgress.TabIndex = 4
        '
        'SFD_BG
        '
        Me.SFD_BG.CreatePrompt = True
        Me.SFD_BG.DefaultExt = "in"
        Me.SFD_BG.FileName = "bankgiro.in"
        Me.SFD_BG.Filter = """Bankgirofiler (*.in)|*.in|Alla filer (*.*)|*.*"""
        Me.SFD_BG.FilterIndex = 2
        Me.SFD_BG.InitialDirectory = "c:\"
        '
        'SFD_PG
        '
        Me.SFD_PG.CreatePrompt = True
        Me.SFD_PG.DefaultExt = "pg"
        Me.SFD_PG.FileName = "plusgiro.pg"
        Me.SFD_PG.Filter = """Plusgirofiler (*.pg)|*.pg|Alla filer (*.*)|*.*"""
        Me.SFD_PG.FilterIndex = 2
        Me.SFD_PG.InitialDirectory = "c:\"
        '
        'SFD_Excelark
        '
        Me.SFD_Excelark.CreatePrompt = True
        Me.SFD_Excelark.DefaultExt = "xlsx"
        Me.SFD_Excelark.FileName = "Repro.xlsx"
        Me.SFD_Excelark.Filter = """Excelarbetsbok (*.xlsx)|*.xls*|Alla filer (*.*)|*.*"""
        Me.SFD_Excelark.FilterIndex = 2
        Me.SFD_Excelark.InitialDirectory = "c:\"
        Me.SFD_Excelark.Title = "Excelexport - välj fil"
        '
        'TransTreeView
        '
        Me.TransTreeView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TransTreeView.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TransTreeView.Location = New System.Drawing.Point(0, 188)
        Me.TransTreeView.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TransTreeView.Name = "TransTreeView"
        Me.TransTreeView.ShowNodeToolTips = True
        Me.TransTreeView.Size = New System.Drawing.Size(1354, 353)
        Me.TransTreeView.TabIndex = 5
        '
        'FormTransaktion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1354, 598)
        Me.Controls.Add(Me.pbProgress)
        Me.Controls.Add(Me.TransTreeView)
        Me.Controls.Add(Me.TLPSum)
        Me.Controls.Add(Me.flpStatus)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.MinimumSize = New System.Drawing.Size(377, 334)
        Me.Name = "FormTransaktion"
        Me.Text = "Utbetalningar - filer till Bank och Plus-giro"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.flpStatus.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.p_Rättighetshavare.ResumeLayout(False)
        Me.p_Rättighetshavare.PerformLayout()
        Me.p_Uphovsman.ResumeLayout(False)
        Me.p_Uphovsman.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TLPSum.ResumeLayout(False)
        Me.TLPSum.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArkivToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HjälpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SparaSomExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AvslutaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SorteringToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EfternamnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UtförToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SkickaTillbakaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents flpStatus As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Sort_Namn_Upp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Sort_Namn_Ned As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TLPSum As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblAntalRader As System.Windows.Forms.Label
    Friend WithEvents pbProgress As System.Windows.Forms.ProgressBar
    Friend WithEvents Filter_Status_MI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Filter_Status_Closed As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Filter_Status_Assigned As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransTreeView As B2.TransaktionGroupTreeView
    Friend WithEvents bUtför As System.Windows.Forms.Button
    Friend WithEvents RapporterMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Rapport_Prognos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Rapport_Acconto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Rapport_Bokföring As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PostGiroFilToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InställningarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents skapaPG As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BankGirofilToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InställningarToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SkapaBG As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UtlandsbetalningToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents skapaUTL As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SFD_BG As System.Windows.Forms.SaveFileDialog
    Friend WithEvents SFD_PG As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Filter_Mottagartyp As System.Windows.Forms.CheckedListBox
    Friend WithEvents Filter_Konto_Typ As System.Windows.Forms.CheckedListBox
    Friend WithEvents p_Rättighetshavare As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbl_Filter_Förnamn_Rättighetshavare As System.Windows.Forms.Label
    Friend WithEvents lbl_Filter_Efternamn_LTGT As System.Windows.Forms.Label
    Friend WithEvents tb_Filter_Efternamn_Rättighetshavare As System.Windows.Forms.TextBox
    Friend WithEvents tb_Filter_Förnamn_Rättighetshavare As System.Windows.Forms.TextBox
    Friend WithEvents cb_Filter_Efternamn_GT_Rättighetshavare As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Filter_Efternamn_LT_Rättighetshavare As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lbl_Filter_Efternamn_Rättighetshavare As System.Windows.Forms.Label
    Friend WithEvents lbl_Filter_PNR_Rättighetshavare As System.Windows.Forms.Label
    Friend WithEvents tb_Filter_PNR_Rättighetshavare As System.Windows.Forms.TextBox
    Friend WithEvents cb_Filter_Betalning_Typ As System.Windows.Forms.CheckedListBox
    Friend WithEvents p_Uphovsman As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lbl_PNR As System.Windows.Forms.Label
    Friend WithEvents dt_Filter_To As System.Windows.Forms.DateTimePicker
    Friend WithEvents dt_Filter_From As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFilter_Förnamn As System.Windows.Forms.Label
    Friend WithEvents lbl_Efternamn_GTLT As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tb_Filter_Efternamn As System.Windows.Forms.TextBox
    Friend WithEvents tb_Filter_Förnamn As System.Windows.Forms.TextBox
    Friend WithEvents cb_Filter_Efternamn_LT As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblFilter_Efternamn As System.Windows.Forms.Label
    Friend WithEvents cb_Filter_Efternamn_GT As System.Windows.Forms.ComboBox
    Friend WithEvents tb_Filter_PNR As System.Windows.Forms.TextBox
    Friend WithEvents tb_Filter_Kommentar As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cb_DescAsc As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cb_Filter_Status As System.Windows.Forms.ComboBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents cb_Filter_Transaktionstyp As System.Windows.Forms.CheckedListBox
    Friend WithEvents lblTransaktionstyp As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tb_filter_clearing As System.Windows.Forms.TextBox
    Friend WithEvents tb_filter_kontonr As System.Windows.Forms.TextBox
    Friend WithEvents SFD_Excelark As System.Windows.Forms.SaveFileDialog
    Friend WithEvents FBD_Excelark As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents lblTotalAmount As System.Windows.Forms.Label
    Friend WithEvents lblTot As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblBrutto As System.Windows.Forms.Label
End Class
