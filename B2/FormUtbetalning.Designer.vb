<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUtbetalning
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
        Me.SparaSomExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RapportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AvslutaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MarkeraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AktuellRadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AvmarkeraAllaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UtförToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DöljMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.PG_MI = New System.Windows.Forms.ToolStripMenuItem()
        Me.PG_Skapa_ny = New System.Windows.Forms.ToolStripMenuItem()
        Me.PG_Befintlig_MI = New System.Windows.Forms.ToolStripMenuItem()
        Me.BG_MI = New System.Windows.Forms.ToolStripMenuItem()
        Me.BG_Skapa_ny = New System.Windows.Forms.ToolStripMenuItem()
        Me.BG_Befintlig_MI = New System.Windows.Forms.ToolStripMenuItem()
        Me.UTL_MI = New System.Windows.Forms.ToolStripMenuItem()
        Me.UTL_Skapa_ny = New System.Windows.Forms.ToolStripMenuItem()
        Me.UTL_Befintlig_MI = New System.Windows.Forms.ToolStripMenuItem()
        Me.SkickaTillbakaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MI_Öppna_transaktioner = New System.Windows.Forms.ToolStripMenuItem()
        Me.HjälpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.flpStatus = New System.Windows.Forms.FlowLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.tb_Filter_Totalsumma_GT = New System.Windows.Forms.TextBox()
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
        Me.lblFilter_Belopp = New System.Windows.Forms.Label()
        Me.cb_Filter_Betalning_Typ = New System.Windows.Forms.CheckedListBox()
        Me.pUpphovsman = New System.Windows.Forms.Panel()
        Me.p_Uphovsman = New System.Windows.Forms.TableLayoutPanel()
        Me.Label12 = New System.Windows.Forms.Label()
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
        Me.tb_Filter_Kommentar = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.cb_DescAsc = New System.Windows.Forms.ComboBox()
        Me.cb_SortBy = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cb_Filter_VisaDolda = New System.Windows.Forms.CheckBox()
        Me.cb_Filter_VisaFelaktiga = New System.Windows.Forms.CheckBox()
        Me.cb_Filter_Visa_Betalda = New System.Windows.Forms.CheckBox()
        Me.bUtför = New System.Windows.Forms.Button()
        Me.pbProgress = New System.Windows.Forms.ProgressBar()
        Me.TLPSum = New System.Windows.Forms.TableLayoutPanel()
        Me.lblAntalRader = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblTotalAmount = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblAntal_mottagare = New System.Windows.Forms.Label()
        Me.lblTotalUtlandAmount = New System.Windows.Forms.Label()
        Me.lblTotalAVIAmount = New System.Windows.Forms.Label()
        Me.lblTotalBankGiroAmount = New System.Windows.Forms.Label()
        Me.lblTotalBankkontoAmount = New System.Windows.Forms.Label()
        Me.lblTotalPlusgiroAmount = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblBrutto = New System.Windows.Forms.Label()
        Me.UtbetalningTreeView = New B2.UtbetalningGroupTreeView()
        Me.MenuStrip1.SuspendLayout()
        Me.flpStatus.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.p_Rättighetshavare.SuspendLayout()
        Me.pUpphovsman.SuspendLayout()
        Me.p_Uphovsman.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TLPSum.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArkivToolStripMenuItem, Me.MarkeraToolStripMenuItem, Me.UtförToolStripMenuItem, Me.HjälpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1368, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArkivToolStripMenuItem
        '
        Me.ArkivToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SparaSomExcelToolStripMenuItem, Me.RapportToolStripMenuItem, Me.AvslutaToolStripMenuItem})
        Me.ArkivToolStripMenuItem.Name = "ArkivToolStripMenuItem"
        Me.ArkivToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.ArkivToolStripMenuItem.Text = "&Arkiv"
        '
        'SparaSomExcelToolStripMenuItem
        '
        Me.SparaSomExcelToolStripMenuItem.Enabled = False
        Me.SparaSomExcelToolStripMenuItem.Name = "SparaSomExcelToolStripMenuItem"
        Me.SparaSomExcelToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.SparaSomExcelToolStripMenuItem.Text = "Spara som E&xcel"
        '
        'RapportToolStripMenuItem
        '
        Me.RapportToolStripMenuItem.Enabled = False
        Me.RapportToolStripMenuItem.Name = "RapportToolStripMenuItem"
        Me.RapportToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.RapportToolStripMenuItem.Text = "&Rapport"
        '
        'AvslutaToolStripMenuItem
        '
        Me.AvslutaToolStripMenuItem.Name = "AvslutaToolStripMenuItem"
        Me.AvslutaToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.AvslutaToolStripMenuItem.Text = "&Stäng"
        Me.AvslutaToolStripMenuItem.ToolTipText = "Stänger detta fönster."
        '
        'MarkeraToolStripMenuItem
        '
        Me.MarkeraToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AktuellRadToolStripMenuItem, Me.AllaToolStripMenuItem, Me.AvmarkeraAllaToolStripMenuItem})
        Me.MarkeraToolStripMenuItem.Name = "MarkeraToolStripMenuItem"
        Me.MarkeraToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.MarkeraToolStripMenuItem.Text = "&Markera"
        '
        'AktuellRadToolStripMenuItem
        '
        Me.AktuellRadToolStripMenuItem.Name = "AktuellRadToolStripMenuItem"
        Me.AktuellRadToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AktuellRadToolStripMenuItem.Text = "Aktuell &rad"
        '
        'AllaToolStripMenuItem
        '
        Me.AllaToolStripMenuItem.Name = "AllaToolStripMenuItem"
        Me.AllaToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AllaToolStripMenuItem.Text = "&Alla"
        '
        'AvmarkeraAllaToolStripMenuItem
        '
        Me.AvmarkeraAllaToolStripMenuItem.Name = "AvmarkeraAllaToolStripMenuItem"
        Me.AvmarkeraAllaToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AvmarkeraAllaToolStripMenuItem.Text = "A&vmarkera alla"
        '
        'UtförToolStripMenuItem
        '
        Me.UtförToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DöljMI, Me.PG_MI, Me.BG_MI, Me.UTL_MI, Me.SkickaTillbakaToolStripMenuItem, Me.MI_Öppna_transaktioner})
        Me.UtförToolStripMenuItem.Name = "UtförToolStripMenuItem"
        Me.UtförToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.UtförToolStripMenuItem.Text = "Utför"
        '
        'DöljMI
        '
        Me.DöljMI.Name = "DöljMI"
        Me.DöljMI.Size = New System.Drawing.Size(236, 22)
        Me.DöljMI.Text = "Dölj markerade."
        '
        'PG_MI
        '
        Me.PG_MI.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PG_Skapa_ny, Me.PG_Befintlig_MI})
        Me.PG_MI.Enabled = False
        Me.PG_MI.Name = "PG_MI"
        Me.PG_MI.Size = New System.Drawing.Size(236, 22)
        Me.PG_MI.Text = "Lägg markerade till Plusgiro"
        Me.PG_MI.Visible = False
        '
        'PG_Skapa_ny
        '
        Me.PG_Skapa_ny.Name = "PG_Skapa_ny"
        Me.PG_Skapa_ny.Size = New System.Drawing.Size(145, 22)
        Me.PG_Skapa_ny.Text = "Lägg till ny fil"
        '
        'PG_Befintlig_MI
        '
        Me.PG_Befintlig_MI.Name = "PG_Befintlig_MI"
        Me.PG_Befintlig_MI.Size = New System.Drawing.Size(145, 22)
        Me.PG_Befintlig_MI.Text = "Befintlig fil"
        '
        'BG_MI
        '
        Me.BG_MI.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BG_Skapa_ny, Me.BG_Befintlig_MI})
        Me.BG_MI.Name = "BG_MI"
        Me.BG_MI.Size = New System.Drawing.Size(236, 22)
        Me.BG_MI.Text = "Lägg markerade till Bankgiro"
        '
        'BG_Skapa_ny
        '
        Me.BG_Skapa_ny.Name = "BG_Skapa_ny"
        Me.BG_Skapa_ny.Size = New System.Drawing.Size(145, 22)
        Me.BG_Skapa_ny.Text = "Lägg till ny fil"
        '
        'BG_Befintlig_MI
        '
        Me.BG_Befintlig_MI.Name = "BG_Befintlig_MI"
        Me.BG_Befintlig_MI.Size = New System.Drawing.Size(145, 22)
        Me.BG_Befintlig_MI.Text = "Befintlig fil"
        '
        'UTL_MI
        '
        Me.UTL_MI.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UTL_Skapa_ny, Me.UTL_Befintlig_MI})
        Me.UTL_MI.Name = "UTL_MI"
        Me.UTL_MI.Size = New System.Drawing.Size(236, 22)
        Me.UTL_MI.Text = "Lägg markerade till Utlandsb."
        '
        'UTL_Skapa_ny
        '
        Me.UTL_Skapa_ny.Name = "UTL_Skapa_ny"
        Me.UTL_Skapa_ny.Size = New System.Drawing.Size(145, 22)
        Me.UTL_Skapa_ny.Text = "Lägg till ny fil"
        '
        'UTL_Befintlig_MI
        '
        Me.UTL_Befintlig_MI.Name = "UTL_Befintlig_MI"
        Me.UTL_Befintlig_MI.Size = New System.Drawing.Size(145, 22)
        Me.UTL_Befintlig_MI.Text = "Befintlig fil"
        '
        'SkickaTillbakaToolStripMenuItem
        '
        Me.SkickaTillbakaToolStripMenuItem.Enabled = False
        Me.SkickaTillbakaToolStripMenuItem.Name = "SkickaTillbakaToolStripMenuItem"
        Me.SkickaTillbakaToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
        Me.SkickaTillbakaToolStripMenuItem.Text = "Skicka tillbaka till Busas"
        '
        'MI_Öppna_transaktioner
        '
        Me.MI_Öppna_transaktioner.Name = "MI_Öppna_transaktioner"
        Me.MI_Öppna_transaktioner.Size = New System.Drawing.Size(236, 22)
        Me.MI_Öppna_transaktioner.Text = "Öppna &Gjorda betalningar/filer"
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
        Me.flpStatus.Controls.Add(Me.pUpphovsman)
        Me.flpStatus.Controls.Add(Me.TableLayoutPanel1)
        Me.flpStatus.Controls.Add(Me.bUtför)
        Me.flpStatus.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.flpStatus.Dock = System.Windows.Forms.DockStyle.Top
        Me.flpStatus.Location = New System.Drawing.Point(0, 24)
        Me.flpStatus.MinimumSize = New System.Drawing.Size(10, 10)
        Me.flpStatus.Name = "flpStatus"
        Me.flpStatus.Size = New System.Drawing.Size(1368, 161)
        Me.flpStatus.TabIndex = 1
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.tb_Filter_Totalsumma_GT, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Filter_Konto_Typ, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Filter_Mottagartyp, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.p_Rättighetshavare, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblFilter_Belopp, 1, 1)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(2, 2)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(2)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.62963!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.37037!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(440, 132)
        Me.TableLayoutPanel2.TabIndex = 35
        '
        'tb_Filter_Totalsumma_GT
        '
        Me.tb_Filter_Totalsumma_GT.Location = New System.Drawing.Point(325, 107)
        Me.tb_Filter_Totalsumma_GT.Margin = New System.Windows.Forms.Padding(2)
        Me.tb_Filter_Totalsumma_GT.MaxLength = 6
        Me.tb_Filter_Totalsumma_GT.MinimumSize = New System.Drawing.Size(30, 4)
        Me.tb_Filter_Totalsumma_GT.Name = "tb_Filter_Totalsumma_GT"
        Me.tb_Filter_Totalsumma_GT.Size = New System.Drawing.Size(54, 20)
        Me.tb_Filter_Totalsumma_GT.TabIndex = 8
        '
        'Filter_Konto_Typ
        '
        Me.Filter_Konto_Typ.FormattingEnabled = True
        Me.Filter_Konto_Typ.Items.AddRange(New Object() {"AVI", "Bankgiro", "Bankkonto", "Plusgiro"})
        Me.Filter_Konto_Typ.Location = New System.Drawing.Point(325, 2)
        Me.Filter_Konto_Typ.Margin = New System.Windows.Forms.Padding(2)
        Me.Filter_Konto_Typ.Name = "Filter_Konto_Typ"
        Me.Filter_Konto_Typ.Size = New System.Drawing.Size(91, 64)
        Me.Filter_Konto_Typ.TabIndex = 7
        '
        'Filter_Mottagartyp
        '
        Me.Filter_Mottagartyp.FormattingEnabled = True
        Me.Filter_Mottagartyp.Items.AddRange(New Object() {"Ombud", "Rättighetsh.", "Systerorg.", "Upphovsmän"})
        Me.Filter_Mottagartyp.Location = New System.Drawing.Point(230, 2)
        Me.Filter_Mottagartyp.Margin = New System.Windows.Forms.Padding(2)
        Me.Filter_Mottagartyp.Name = "Filter_Mottagartyp"
        Me.Filter_Mottagartyp.Size = New System.Drawing.Size(91, 64)
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
        Me.p_Rättighetshavare.Location = New System.Drawing.Point(2, 2)
        Me.p_Rättighetshavare.Margin = New System.Windows.Forms.Padding(2)
        Me.p_Rättighetshavare.Name = "p_Rättighetshavare"
        Me.p_Rättighetshavare.RowCount = 4
        Me.p_Rättighetshavare.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.p_Rättighetshavare.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.p_Rättighetshavare.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.p_Rättighetshavare.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.p_Rättighetshavare.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16.0!))
        Me.p_Rättighetshavare.Size = New System.Drawing.Size(224, 100)
        Me.p_Rättighetshavare.TabIndex = 19
        '
        'lbl_Filter_Förnamn_Rättighetshavare
        '
        Me.lbl_Filter_Förnamn_Rättighetshavare.AutoSize = True
        Me.lbl_Filter_Förnamn_Rättighetshavare.Location = New System.Drawing.Point(3, 24)
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
        Me.cb_Filter_Efternamn_GT_Rättighetshavare.Size = New System.Drawing.Size(38, 21)
        Me.cb_Filter_Efternamn_GT_Rättighetshavare.TabIndex = 3
        '
        'cb_Filter_Efternamn_LT_Rättighetshavare
        '
        Me.cb_Filter_Efternamn_LT_Rättighetshavare.FormattingEnabled = True
        Me.cb_Filter_Efternamn_LT_Rättighetshavare.Items.AddRange(New Object() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "X", "Y", "Z", "Å", "Ä", "Ö"})
        Me.cb_Filter_Efternamn_LT_Rättighetshavare.Location = New System.Drawing.Point(140, 50)
        Me.cb_Filter_Efternamn_LT_Rättighetshavare.Margin = New System.Windows.Forms.Padding(2)
        Me.cb_Filter_Efternamn_LT_Rättighetshavare.Name = "cb_Filter_Efternamn_LT_Rättighetshavare"
        Me.cb_Filter_Efternamn_LT_Rättighetshavare.Size = New System.Drawing.Size(38, 21)
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
        Me.lbl_Filter_Efternamn_Rättighetshavare.Location = New System.Drawing.Point(3, 0)
        Me.lbl_Filter_Efternamn_Rättighetshavare.Name = "lbl_Filter_Efternamn_Rättighetshavare"
        Me.lbl_Filter_Efternamn_Rättighetshavare.Size = New System.Drawing.Size(55, 13)
        Me.lbl_Filter_Efternamn_Rättighetshavare.TabIndex = 2
        Me.lbl_Filter_Efternamn_Rättighetshavare.Text = "Efternamn"
        '
        'lbl_Filter_PNR_Rättighetshavare
        '
        Me.lbl_Filter_PNR_Rättighetshavare.AutoSize = True
        Me.lbl_Filter_PNR_Rättighetshavare.Location = New System.Drawing.Point(3, 73)
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
        Me.tb_Filter_PNR_Rättighetshavare.Size = New System.Drawing.Size(151, 20)
        Me.tb_Filter_PNR_Rättighetshavare.TabIndex = 5
        Me.tb_Filter_PNR_Rättighetshavare.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblFilter_Belopp
        '
        Me.lblFilter_Belopp.AutoSize = True
        Me.lblFilter_Belopp.Location = New System.Drawing.Point(231, 105)
        Me.lblFilter_Belopp.Name = "lblFilter_Belopp"
        Me.lblFilter_Belopp.Size = New System.Drawing.Size(52, 13)
        Me.lblFilter_Belopp.TabIndex = 4
        Me.lblFilter_Belopp.Text = "Belopp > "
        '
        'cb_Filter_Betalning_Typ
        '
        Me.cb_Filter_Betalning_Typ.FormattingEnabled = True
        Me.cb_Filter_Betalning_Typ.Items.AddRange(New Object() {"Följerätt", "IV", "IR", "IR-Bildbyrå", "IR-Foto", "IR-Dagpress-foto", "IR-Dagpress-illustration", "KR", "Repro", "Sveriges tidskrifter", "TV", "TV-Foto", "TV4", "TV4-Foto", "TVCopy", "TVCopy-Foto", "TV4-Copy", "TV4-Copy-Foto"})
        Me.cb_Filter_Betalning_Typ.Location = New System.Drawing.Point(446, 2)
        Me.cb_Filter_Betalning_Typ.Margin = New System.Windows.Forms.Padding(2)
        Me.cb_Filter_Betalning_Typ.MultiColumn = True
        Me.cb_Filter_Betalning_Typ.Name = "cb_Filter_Betalning_Typ"
        Me.cb_Filter_Betalning_Typ.Size = New System.Drawing.Size(259, 154)
        Me.cb_Filter_Betalning_Typ.TabIndex = 9
        '
        'pUpphovsman
        '
        Me.pUpphovsman.Controls.Add(Me.p_Uphovsman)
        Me.pUpphovsman.Location = New System.Drawing.Point(709, 2)
        Me.pUpphovsman.Margin = New System.Windows.Forms.Padding(2)
        Me.pUpphovsman.Name = "pUpphovsman"
        Me.pUpphovsman.Size = New System.Drawing.Size(266, 155)
        Me.pUpphovsman.TabIndex = 33
        '
        'p_Uphovsman
        '
        Me.p_Uphovsman.ColumnCount = 4
        Me.p_Uphovsman.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93.0!))
        Me.p_Uphovsman.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.p_Uphovsman.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.p_Uphovsman.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86.0!))
        Me.p_Uphovsman.Controls.Add(Me.Label12, 0, 6)
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
        Me.p_Uphovsman.Controls.Add(Me.tb_Filter_Kommentar, 1, 6)
        Me.p_Uphovsman.Location = New System.Drawing.Point(10, 2)
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
        Me.p_Uphovsman.Size = New System.Drawing.Size(254, 153)
        Me.p_Uphovsman.TabIndex = 18
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(2, 121)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Kommentar:"
        '
        'lbl_PNR
        '
        Me.lbl_PNR.AutoSize = True
        Me.lbl_PNR.Location = New System.Drawing.Point(3, 73)
        Me.lbl_PNR.Name = "lbl_PNR"
        Me.lbl_PNR.Size = New System.Drawing.Size(54, 13)
        Me.lbl_PNR.TabIndex = 14
        Me.lbl_PNR.Text = "Upph.pnr."
        '
        'dt_Filter_To
        '
        Me.dt_Filter_To.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_Filter_To.Location = New System.Drawing.Point(170, 99)
        Me.dt_Filter_To.Margin = New System.Windows.Forms.Padding(2)
        Me.dt_Filter_To.Name = "dt_Filter_To"
        Me.dt_Filter_To.Size = New System.Drawing.Size(82, 20)
        Me.dt_Filter_To.TabIndex = 17
        '
        'dt_Filter_From
        '
        Me.p_Uphovsman.SetColumnSpan(Me.dt_Filter_From, 2)
        Me.dt_Filter_From.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_Filter_From.Location = New System.Drawing.Point(95, 99)
        Me.dt_Filter_From.Margin = New System.Windows.Forms.Padding(2)
        Me.dt_Filter_From.Name = "dt_Filter_From"
        Me.dt_Filter_From.Size = New System.Drawing.Size(67, 20)
        Me.dt_Filter_From.TabIndex = 16
        '
        'lblFilter_Förnamn
        '
        Me.lblFilter_Förnamn.AutoSize = True
        Me.lblFilter_Förnamn.Location = New System.Drawing.Point(3, 24)
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
        Me.tb_Filter_Efternamn.Location = New System.Drawing.Point(95, 2)
        Me.tb_Filter_Efternamn.Margin = New System.Windows.Forms.Padding(2)
        Me.tb_Filter_Efternamn.Name = "tb_Filter_Efternamn"
        Me.tb_Filter_Efternamn.Size = New System.Drawing.Size(146, 20)
        Me.tb_Filter_Efternamn.TabIndex = 10
        '
        'tb_Filter_Förnamn
        '
        Me.p_Uphovsman.SetColumnSpan(Me.tb_Filter_Förnamn, 3)
        Me.tb_Filter_Förnamn.Location = New System.Drawing.Point(95, 26)
        Me.tb_Filter_Förnamn.Margin = New System.Windows.Forms.Padding(2)
        Me.tb_Filter_Förnamn.Name = "tb_Filter_Förnamn"
        Me.tb_Filter_Förnamn.Size = New System.Drawing.Size(146, 20)
        Me.tb_Filter_Förnamn.TabIndex = 11
        '
        'cb_Filter_Efternamn_LT
        '
        Me.cb_Filter_Efternamn_LT.FormattingEnabled = True
        Me.cb_Filter_Efternamn_LT.Items.AddRange(New Object() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "X", "Y", "Z", "Å", "Ä", "Ö"})
        Me.cb_Filter_Efternamn_LT.Location = New System.Drawing.Point(170, 50)
        Me.cb_Filter_Efternamn_LT.Margin = New System.Windows.Forms.Padding(2)
        Me.cb_Filter_Efternamn_LT.Name = "cb_Filter_Efternamn_LT"
        Me.cb_Filter_Efternamn_LT.Size = New System.Drawing.Size(38, 21)
        Me.cb_Filter_Efternamn_LT.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(150, 48)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(10, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "-"
        '
        'lblFilter_Efternamn
        '
        Me.lblFilter_Efternamn.AutoSize = True
        Me.lblFilter_Efternamn.Location = New System.Drawing.Point(3, 0)
        Me.lblFilter_Efternamn.Name = "lblFilter_Efternamn"
        Me.lblFilter_Efternamn.Size = New System.Drawing.Size(86, 13)
        Me.lblFilter_Efternamn.TabIndex = 2
        Me.lblFilter_Efternamn.Text = "Upph. efternamn"
        '
        'cb_Filter_Efternamn_GT
        '
        Me.cb_Filter_Efternamn_GT.FormattingEnabled = True
        Me.cb_Filter_Efternamn_GT.Items.AddRange(New Object() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "X", "Y", "Z", "Å", "Ä", "Ö"})
        Me.cb_Filter_Efternamn_GT.Location = New System.Drawing.Point(95, 50)
        Me.cb_Filter_Efternamn_GT.Margin = New System.Windows.Forms.Padding(2)
        Me.cb_Filter_Efternamn_GT.Name = "cb_Filter_Efternamn_GT"
        Me.cb_Filter_Efternamn_GT.Size = New System.Drawing.Size(38, 21)
        Me.cb_Filter_Efternamn_GT.TabIndex = 12
        '
        'tb_Filter_PNR
        '
        Me.p_Uphovsman.SetColumnSpan(Me.tb_Filter_PNR, 3)
        Me.tb_Filter_PNR.Location = New System.Drawing.Point(95, 75)
        Me.tb_Filter_PNR.Margin = New System.Windows.Forms.Padding(2)
        Me.tb_Filter_PNR.Name = "tb_Filter_PNR"
        Me.tb_Filter_PNR.Size = New System.Drawing.Size(146, 20)
        Me.tb_Filter_PNR.TabIndex = 15
        '
        'tb_Filter_Kommentar
        '
        Me.p_Uphovsman.SetColumnSpan(Me.tb_Filter_Kommentar, 3)
        Me.tb_Filter_Kommentar.Location = New System.Drawing.Point(95, 123)
        Me.tb_Filter_Kommentar.Margin = New System.Windows.Forms.Padding(2)
        Me.tb_Filter_Kommentar.Name = "tb_Filter_Kommentar"
        Me.tb_Filter_Kommentar.Size = New System.Drawing.Size(146, 20)
        Me.tb_Filter_Kommentar.TabIndex = 18
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.cb_DescAsc, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cb_SortBy, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label11, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cb_Filter_VisaDolda, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cb_Filter_VisaFelaktiga, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cb_Filter_Visa_Betalda, 1, 3)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(979, 2)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(278, 95)
        Me.TableLayoutPanel1.TabIndex = 34
        '
        'cb_DescAsc
        '
        Me.cb_DescAsc.FormattingEnabled = True
        Me.cb_DescAsc.Items.AddRange(New Object() {"Stigande", "Fallande"})
        Me.cb_DescAsc.Location = New System.Drawing.Point(128, 2)
        Me.cb_DescAsc.Margin = New System.Windows.Forms.Padding(2)
        Me.cb_DescAsc.Name = "cb_DescAsc"
        Me.cb_DescAsc.Size = New System.Drawing.Size(64, 21)
        Me.cb_DescAsc.TabIndex = 20
        '
        'cb_SortBy
        '
        Me.cb_SortBy.FormattingEnabled = True
        Me.cb_SortBy.Items.AddRange(New Object() {"Namn", "Belopp"})
        Me.cb_SortBy.Location = New System.Drawing.Point(58, 2)
        Me.cb_SortBy.Margin = New System.Windows.Forms.Padding(2)
        Me.cb_SortBy.Name = "cb_SortBy"
        Me.cb_SortBy.Size = New System.Drawing.Size(66, 21)
        Me.cb_SortBy.TabIndex = 19
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
        'cb_Filter_VisaDolda
        '
        Me.cb_Filter_VisaDolda.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.cb_Filter_VisaDolda, 2)
        Me.cb_Filter_VisaDolda.Location = New System.Drawing.Point(58, 27)
        Me.cb_Filter_VisaDolda.Margin = New System.Windows.Forms.Padding(2)
        Me.cb_Filter_VisaDolda.Name = "cb_Filter_VisaDolda"
        Me.cb_Filter_VisaDolda.Size = New System.Drawing.Size(102, 17)
        Me.cb_Filter_VisaDolda.TabIndex = 21
        Me.cb_Filter_VisaDolda.Text = "Visa dolda rader"
        Me.cb_Filter_VisaDolda.UseVisualStyleBackColor = True
        Me.cb_Filter_VisaDolda.Visible = False
        '
        'cb_Filter_VisaFelaktiga
        '
        Me.cb_Filter_VisaFelaktiga.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.cb_Filter_VisaFelaktiga, 2)
        Me.cb_Filter_VisaFelaktiga.Location = New System.Drawing.Point(58, 48)
        Me.cb_Filter_VisaFelaktiga.Margin = New System.Windows.Forms.Padding(2)
        Me.cb_Filter_VisaFelaktiga.Name = "cb_Filter_VisaFelaktiga"
        Me.cb_Filter_VisaFelaktiga.Size = New System.Drawing.Size(138, 17)
        Me.cb_Filter_VisaFelaktiga.TabIndex = 22
        Me.cb_Filter_VisaFelaktiga.Text = "Visa ej utbetalningsbara"
        Me.cb_Filter_VisaFelaktiga.UseVisualStyleBackColor = True
        '
        'cb_Filter_Visa_Betalda
        '
        Me.cb_Filter_Visa_Betalda.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.cb_Filter_Visa_Betalda, 2)
        Me.cb_Filter_Visa_Betalda.Location = New System.Drawing.Point(58, 69)
        Me.cb_Filter_Visa_Betalda.Margin = New System.Windows.Forms.Padding(2)
        Me.cb_Filter_Visa_Betalda.Name = "cb_Filter_Visa_Betalda"
        Me.cb_Filter_Visa_Betalda.Size = New System.Drawing.Size(111, 17)
        Me.cb_Filter_Visa_Betalda.TabIndex = 23
        Me.cb_Filter_Visa_Betalda.Text = "Visa betalda rader"
        Me.cb_Filter_Visa_Betalda.UseVisualStyleBackColor = True
        '
        'bUtför
        '
        Me.bUtför.Location = New System.Drawing.Point(1262, 3)
        Me.bUtför.Name = "bUtför"
        Me.bUtför.Size = New System.Drawing.Size(43, 21)
        Me.bUtför.TabIndex = 24
        Me.bUtför.Text = "Visa"
        Me.bUtför.UseVisualStyleBackColor = True
        '
        'pbProgress
        '
        Me.pbProgress.Location = New System.Drawing.Point(170, 254)
        Me.pbProgress.Name = "pbProgress"
        Me.pbProgress.Size = New System.Drawing.Size(348, 23)
        Me.pbProgress.TabIndex = 4
        '
        'TLPSum
        '
        Me.TLPSum.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TLPSum.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TLPSum.ColumnCount = 5
        Me.TLPSum.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TLPSum.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96.0!))
        Me.TLPSum.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TLPSum.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TLPSum.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TLPSum.Controls.Add(Me.lblAntalRader, 3, 5)
        Me.TLPSum.Controls.Add(Me.Label2, 1, 3)
        Me.TLPSum.Controls.Add(Me.Label3, 1, 2)
        Me.TLPSum.Controls.Add(Me.Label4, 1, 1)
        Me.TLPSum.Controls.Add(Me.Label5, 1, 0)
        Me.TLPSum.Controls.Add(Me.lblTotalAmount, 2, 5)
        Me.TLPSum.Controls.Add(Me.Label6, 1, 4)
        Me.TLPSum.Controls.Add(Me.lblAntal_mottagare, 3, 3)
        Me.TLPSum.Controls.Add(Me.lblTotalUtlandAmount, 2, 4)
        Me.TLPSum.Controls.Add(Me.lblTotalAVIAmount, 2, 3)
        Me.TLPSum.Controls.Add(Me.lblTotalBankGiroAmount, 2, 2)
        Me.TLPSum.Controls.Add(Me.lblTotalBankkontoAmount, 2, 1)
        Me.TLPSum.Controls.Add(Me.lblTotalPlusgiroAmount, 2, 0)
        Me.TLPSum.Controls.Add(Me.Label9, 1, 5)
        Me.TLPSum.Controls.Add(Me.Label1, 1, 6)
        Me.TLPSum.Controls.Add(Me.lblBrutto, 2, 6)
        Me.TLPSum.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TLPSum.Location = New System.Drawing.Point(0, 531)
        Me.TLPSum.Name = "TLPSum"
        Me.TLPSum.RowCount = 7
        Me.TLPSum.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TLPSum.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TLPSum.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TLPSum.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TLPSum.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TLPSum.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TLPSum.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TLPSum.Size = New System.Drawing.Size(1368, 141)
        Me.TLPSum.TabIndex = 2
        '
        'lblAntalRader
        '
        Me.lblAntalRader.AutoSize = True
        Me.lblAntalRader.Location = New System.Drawing.Point(1207, 100)
        Me.lblAntalRader.Name = "lblAntalRader"
        Me.lblAntalRader.Size = New System.Drawing.Size(98, 13)
        Me.lblAntalRader.TabIndex = 6
        Me.lblAntalRader.Text = "0 av X fakturarader"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "AVI"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "BankGiro"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Bankkonto"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "PlusGiro"
        '
        'lblTotalAmount
        '
        Me.lblTotalAmount.AutoSize = True
        Me.lblTotalAmount.Location = New System.Drawing.Point(119, 100)
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Size = New System.Drawing.Size(13, 13)
        Me.lblTotalAmount.TabIndex = 0
        Me.lblTotalAmount.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(23, 80)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Utland."
        '
        'lblAntal_mottagare
        '
        Me.lblAntal_mottagare.AutoSize = True
        Me.lblAntal_mottagare.Location = New System.Drawing.Point(1207, 60)
        Me.lblAntal_mottagare.Name = "lblAntal_mottagare"
        Me.lblAntal_mottagare.Size = New System.Drawing.Size(81, 13)
        Me.lblAntal_mottagare.TabIndex = 10
        Me.lblAntal_mottagare.Text = "X st. mottagare."
        '
        'lblTotalUtlandAmount
        '
        Me.lblTotalUtlandAmount.AutoSize = True
        Me.lblTotalUtlandAmount.Location = New System.Drawing.Point(119, 80)
        Me.lblTotalUtlandAmount.Name = "lblTotalUtlandAmount"
        Me.lblTotalUtlandAmount.Size = New System.Drawing.Size(13, 13)
        Me.lblTotalUtlandAmount.TabIndex = 11
        Me.lblTotalUtlandAmount.Text = "0"
        '
        'lblTotalAVIAmount
        '
        Me.lblTotalAVIAmount.AutoSize = True
        Me.lblTotalAVIAmount.Location = New System.Drawing.Point(119, 60)
        Me.lblTotalAVIAmount.Name = "lblTotalAVIAmount"
        Me.lblTotalAVIAmount.Size = New System.Drawing.Size(13, 13)
        Me.lblTotalAVIAmount.TabIndex = 12
        Me.lblTotalAVIAmount.Text = "0"
        '
        'lblTotalBankGiroAmount
        '
        Me.lblTotalBankGiroAmount.AutoSize = True
        Me.lblTotalBankGiroAmount.Location = New System.Drawing.Point(119, 40)
        Me.lblTotalBankGiroAmount.Name = "lblTotalBankGiroAmount"
        Me.lblTotalBankGiroAmount.Size = New System.Drawing.Size(13, 13)
        Me.lblTotalBankGiroAmount.TabIndex = 13
        Me.lblTotalBankGiroAmount.Text = "0"
        '
        'lblTotalBankkontoAmount
        '
        Me.lblTotalBankkontoAmount.AutoSize = True
        Me.lblTotalBankkontoAmount.Location = New System.Drawing.Point(119, 20)
        Me.lblTotalBankkontoAmount.Name = "lblTotalBankkontoAmount"
        Me.lblTotalBankkontoAmount.Size = New System.Drawing.Size(13, 13)
        Me.lblTotalBankkontoAmount.TabIndex = 14
        Me.lblTotalBankkontoAmount.Text = "0"
        '
        'lblTotalPlusgiroAmount
        '
        Me.lblTotalPlusgiroAmount.AutoSize = True
        Me.lblTotalPlusgiroAmount.Location = New System.Drawing.Point(119, 0)
        Me.lblTotalPlusgiroAmount.Name = "lblTotalPlusgiroAmount"
        Me.lblTotalPlusgiroAmount.Size = New System.Drawing.Size(13, 13)
        Me.lblTotalPlusgiroAmount.TabIndex = 15
        Me.lblTotalPlusgiroAmount.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(23, 100)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Totalsumma"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Brutto"
        '
        'lblBrutto
        '
        Me.lblBrutto.AutoSize = True
        Me.lblBrutto.Location = New System.Drawing.Point(119, 120)
        Me.lblBrutto.Name = "lblBrutto"
        Me.lblBrutto.Size = New System.Drawing.Size(13, 13)
        Me.lblBrutto.TabIndex = 19
        Me.lblBrutto.Text = "0"
        '
        'UtbetalningTreeView
        '
        Me.UtbetalningTreeView.CheckBoxes = True
        Me.UtbetalningTreeView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UtbetalningTreeView.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!)
        Me.UtbetalningTreeView.Location = New System.Drawing.Point(0, 185)
        Me.UtbetalningTreeView.Name = "UtbetalningTreeView"
        Me.UtbetalningTreeView.ShowNodeToolTips = True
        Me.UtbetalningTreeView.Size = New System.Drawing.Size(1368, 346)
        Me.UtbetalningTreeView.TabIndex = 25
        '
        'FormUtbetalning
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1368, 672)
        Me.Controls.Add(Me.pbProgress)
        Me.Controls.Add(Me.UtbetalningTreeView)
        Me.Controls.Add(Me.flpStatus)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.TLPSum)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(388, 367)
        Me.Name = "FormUtbetalning"
        Me.Text = "Godkänn utbetalningar."
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.flpStatus.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.p_Rättighetshavare.ResumeLayout(False)
        Me.p_Rättighetshavare.PerformLayout()
        Me.pUpphovsman.ResumeLayout(False)
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
    Friend WithEvents RapportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AvslutaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MarkeraToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AktuellRadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AllaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AvmarkeraAllaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UtförToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DöljMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SkickaTillbakaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents flpStatus As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblFilter_Efternamn As System.Windows.Forms.Label
    Friend WithEvents TLPSum As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblTotalAmount As System.Windows.Forms.Label
    Friend WithEvents lblFilter_Belopp As System.Windows.Forms.Label
    Friend WithEvents lblFilter_Förnamn As System.Windows.Forms.Label
    Friend WithEvents pbProgress As System.Windows.Forms.ProgressBar
    Friend WithEvents UtbetalningTreeView As B2.UtbetalningGroupTreeView
    Friend WithEvents PG_MI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PG_Skapa_ny As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblAntalRader As System.Windows.Forms.Label
    Friend WithEvents lblAntal_mottagare As System.Windows.Forms.Label
    Friend WithEvents BG_MI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BG_Skapa_ny As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UTL_MI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UTL_Skapa_ny As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PG_Befintlig_MI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BG_Befintlig_MI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UTL_Befintlig_MI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MI_Öppna_transaktioner As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblTotalBankGiroAmount As System.Windows.Forms.Label
    Friend WithEvents lblTotalUtlandAmount As System.Windows.Forms.Label
    Friend WithEvents lblTotalAVIAmount As System.Windows.Forms.Label
    Friend WithEvents lblTotalBankkontoAmount As System.Windows.Forms.Label
    Friend WithEvents lblTotalPlusgiroAmount As System.Windows.Forms.Label
    Friend WithEvents tb_Filter_Totalsumma_GT As System.Windows.Forms.TextBox
    Friend WithEvents Filter_Konto_Typ As System.Windows.Forms.CheckedListBox
    Friend WithEvents Filter_Mottagartyp As System.Windows.Forms.CheckedListBox
    Friend WithEvents p_Uphovsman As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tb_Filter_Förnamn As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Efternamn_GTLT As System.Windows.Forms.Label
    Friend WithEvents tb_Filter_Efternamn As System.Windows.Forms.TextBox
    Friend WithEvents cb_Filter_Efternamn_GT As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Filter_Efternamn_LT As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents p_Rättighetshavare As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbl_Filter_Förnamn_Rättighetshavare As System.Windows.Forms.Label
    Friend WithEvents lbl_Filter_Efternamn_LTGT As System.Windows.Forms.Label
    Friend WithEvents tb_Filter_Efternamn_Rättighetshavare As System.Windows.Forms.TextBox
    Friend WithEvents tb_Filter_Förnamn_Rättighetshavare As System.Windows.Forms.TextBox
    Friend WithEvents cb_Filter_Efternamn_GT_Rättighetshavare As System.Windows.Forms.ComboBox
    Friend WithEvents cb_Filter_Efternamn_LT_Rättighetshavare As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lbl_Filter_Efternamn_Rättighetshavare As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dt_Filter_From As System.Windows.Forms.DateTimePicker
    Friend WithEvents dt_Filter_To As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cb_SortBy As System.Windows.Forms.ComboBox
    Friend WithEvents cb_DescAsc As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents tb_Filter_Kommentar As System.Windows.Forms.TextBox
    Friend WithEvents cb_Filter_Betalning_Typ As System.Windows.Forms.CheckedListBox
    Friend WithEvents cb_Filter_VisaFelaktiga As System.Windows.Forms.CheckBox
    Friend WithEvents cb_Filter_VisaDolda As System.Windows.Forms.CheckBox
    Friend WithEvents cb_Filter_Visa_Betalda As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_Filter_PNR_Rättighetshavare As System.Windows.Forms.Label
    Friend WithEvents lbl_PNR As System.Windows.Forms.Label
    Friend WithEvents tb_Filter_PNR As System.Windows.Forms.TextBox
    Friend WithEvents tb_Filter_PNR_Rättighetshavare As System.Windows.Forms.TextBox
    Friend WithEvents pUpphovsman As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents bUtför As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblBrutto As System.Windows.Forms.Label
End Class
