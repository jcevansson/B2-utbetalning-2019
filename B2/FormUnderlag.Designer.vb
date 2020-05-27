<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUnderlag
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
        Me.filterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Filter_Utbetalningstyp_Menutem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Filter_Följerätt = New System.Windows.Forms.ToolStripMenuItem()
        Me.Filter_IV = New System.Windows.Forms.ToolStripMenuItem()
        Me.Filter_IR = New System.Windows.Forms.ToolStripMenuItem()
        Me.Filter_IR_Bildbyrå = New System.Windows.Forms.ToolStripMenuItem()
        Me.Filter_IR_Foto = New System.Windows.Forms.ToolStripMenuItem()
        Me.Filter_IRDAGP_Foto = New System.Windows.Forms.ToolStripMenuItem()
        Me.Filter_IRDAGP_Illust = New System.Windows.Forms.ToolStripMenuItem()
        Me.Filter_KR = New System.Windows.Forms.ToolStripMenuItem()
        Me.Filter_Repro = New System.Windows.Forms.ToolStripMenuItem()
        Me.Filter_ST = New System.Windows.Forms.ToolStripMenuItem()
        Me.Filter_TV = New System.Windows.Forms.ToolStripMenuItem()
        Me.Filter_Totalsumma_GT_MenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Filter_Totalsumma_GT = New System.Windows.Forms.ToolStripTextBox()
        Me.Filter_Datum_GT_MenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Filter_Datum_GT = New System.Windows.Forms.ToolStripTextBox()
        Me.Filter_Datum_LT_MenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Filter_Datum_LT = New System.Windows.Forms.ToolStripTextBox()
        Me.Filter_Upphovsman_MenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Filter_Upphovsman_Efternamn_GT_MenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Filter_Upphovsman_Efternamn_GT = New System.Windows.Forms.ToolStripComboBox()
        Me.Filter_Upphovsman_Efternamn_LT_MenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Filter_Upphovsman_Efternamn_LT = New System.Windows.Forms.ToolStripComboBox()
        Me.Filter_Upphovsman_Efternamn_like_MenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Filter_Upphovsman_Efternamn_like = New System.Windows.Forms.ToolStripTextBox()
        Me.Filter_Upphovsman_Förnamn_like_MenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Filter_Upphovsman_Förnamn_like = New System.Windows.Forms.ToolStripTextBox()
        Me.Filter_Checkable_Only = New System.Windows.Forms.ToolStripMenuItem()
        Me.filter_Dold = New System.Windows.Forms.ToolStripMenuItem()
        Me.filter_kommentar_like_MenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.filter_kommentar_like = New System.Windows.Forms.ToolStripTextBox()
        Me.SorteringToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EfternamnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Sort_Namn_Upp = New System.Windows.Forms.ToolStripMenuItem()
        Me.Sort_Namn_Ned = New System.Windows.Forms.ToolStripMenuItem()
        Me.TotalsummaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Sort_Totalsumma_Upp = New System.Windows.Forms.ToolStripMenuItem()
        Me.Sort_Totalsumma_Ned = New System.Windows.Forms.ToolStripMenuItem()
        Me.MarkeraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AktuellRadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AvmarkeraAllaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UtförToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GodkännFörUtbetalningToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SkickaTillbakaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ÖppnaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HjälpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.flpStatus = New System.Windows.Forms.FlowLayoutPanel()
        Me.bUtför = New System.Windows.Forms.Button()
        Me.lblSort = New System.Windows.Forms.Label()
        Me.lblFilter_Date = New System.Windows.Forms.Label()
        Me.lblFilter_Upphovsman_Efternamn = New System.Windows.Forms.Label()
        Me.lblFilter_Upphovsman_Förnamn = New System.Windows.Forms.Label()
        Me.lblFilter_Belopp = New System.Windows.Forms.Label()
        Me.lblFilter_Betalningstyp = New System.Windows.Forms.Label()
        Me.lbl_Filter_Checkable_only = New System.Windows.Forms.Label()
        Me.lblFilter_kommentar = New System.Windows.Forms.Label()
        Me.TLPSum = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTotalAmount = New System.Windows.Forms.Label()
        Me.lblAntalRader = New System.Windows.Forms.Label()
        Me.lblAntal_Upphovsmän = New System.Windows.Forms.Label()
        Me.pbProgress = New System.Windows.Forms.ProgressBar()
        Me.PaymentTreeView = New B2.PaymentGroupTreeView()
        Me.MenuStrip1.SuspendLayout()
        Me.flpStatus.SuspendLayout()
        Me.TLPSum.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArkivToolStripMenuItem, Me.filterToolStripMenuItem, Me.SorteringToolStripMenuItem, Me.MarkeraToolStripMenuItem, Me.UtförToolStripMenuItem, Me.HjälpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(12, 4, 0, 4)
        Me.MenuStrip1.Size = New System.Drawing.Size(1662, 44)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArkivToolStripMenuItem
        '
        Me.ArkivToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SparaSomExcelToolStripMenuItem, Me.RapportToolStripMenuItem, Me.AvslutaToolStripMenuItem})
        Me.ArkivToolStripMenuItem.Name = "ArkivToolStripMenuItem"
        Me.ArkivToolStripMenuItem.Size = New System.Drawing.Size(80, 36)
        Me.ArkivToolStripMenuItem.Text = "&Arkiv"
        '
        'SparaSomExcelToolStripMenuItem
        '
        Me.SparaSomExcelToolStripMenuItem.Enabled = False
        Me.SparaSomExcelToolStripMenuItem.Name = "SparaSomExcelToolStripMenuItem"
        Me.SparaSomExcelToolStripMenuItem.Size = New System.Drawing.Size(261, 36)
        Me.SparaSomExcelToolStripMenuItem.Text = "Spara som E&xcel"
        '
        'RapportToolStripMenuItem
        '
        Me.RapportToolStripMenuItem.Enabled = False
        Me.RapportToolStripMenuItem.Name = "RapportToolStripMenuItem"
        Me.RapportToolStripMenuItem.Size = New System.Drawing.Size(261, 36)
        Me.RapportToolStripMenuItem.Text = "&Rapport"
        '
        'AvslutaToolStripMenuItem
        '
        Me.AvslutaToolStripMenuItem.Name = "AvslutaToolStripMenuItem"
        Me.AvslutaToolStripMenuItem.Size = New System.Drawing.Size(261, 36)
        Me.AvslutaToolStripMenuItem.Text = "&Stäng"
        Me.AvslutaToolStripMenuItem.ToolTipText = "Stänger detta fönster."
        '
        'filterToolStripMenuItem
        '
        Me.filterToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Filter_Utbetalningstyp_Menutem, Me.Filter_Totalsumma_GT_MenuItem, Me.Filter_Datum_GT_MenuItem, Me.Filter_Datum_LT_MenuItem, Me.Filter_Upphovsman_MenuItem, Me.Filter_Checkable_Only, Me.filter_Dold, Me.filter_kommentar_like_MenuItem})
        Me.filterToolStripMenuItem.Name = "filterToolStripMenuItem"
        Me.filterToolStripMenuItem.Size = New System.Drawing.Size(80, 36)
        Me.filterToolStripMenuItem.Text = "&Filter"
        '
        'Filter_Utbetalningstyp_Menutem
        '
        Me.Filter_Utbetalningstyp_Menutem.CheckOnClick = True
        Me.Filter_Utbetalningstyp_Menutem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Filter_Följerätt, Me.Filter_IV, Me.Filter_IR, Me.Filter_IR_Bildbyrå, Me.Filter_IR_Foto, Me.Filter_IRDAGP_Foto, Me.Filter_IRDAGP_Illust, Me.Filter_KR, Me.Filter_Repro, Me.Filter_ST, Me.Filter_TV})
        Me.Filter_Utbetalningstyp_Menutem.Name = "Filter_Utbetalningstyp_Menutem"
        Me.Filter_Utbetalningstyp_Menutem.Size = New System.Drawing.Size(348, 36)
        Me.Filter_Utbetalningstyp_Menutem.Tag = "Från vilken ""modul"" skall raderna komma."
        Me.Filter_Utbetalningstyp_Menutem.Text = "Utbetalningstyp"
        '
        'Filter_Följerätt
        '
        Me.Filter_Följerätt.CheckOnClick = True
        Me.Filter_Följerätt.Name = "Filter_Följerätt"
        Me.Filter_Följerätt.Size = New System.Drawing.Size(626, 36)
        Me.Filter_Följerätt.Text = "Följerätt"
        '
        'Filter_IV
        '
        Me.Filter_IV.CheckOnClick = True
        Me.Filter_IV.Name = "Filter_IV"
        Me.Filter_IV.Size = New System.Drawing.Size(626, 36)
        Me.Filter_IV.Text = "Individuell Visningsersättning."
        '
        'Filter_IR
        '
        Me.Filter_IR.CheckOnClick = True
        Me.Filter_IR.Name = "Filter_IR"
        Me.Filter_IR.Size = New System.Drawing.Size(626, 36)
        Me.Filter_IR.Text = "Individuell Reprografiersättning"
        '
        'Filter_IR_Bildbyrå
        '
        Me.Filter_IR_Bildbyrå.CheckOnClick = True
        Me.Filter_IR_Bildbyrå.Name = "Filter_IR_Bildbyrå"
        Me.Filter_IR_Bildbyrå.Size = New System.Drawing.Size(626, 36)
        Me.Filter_IR_Bildbyrå.Text = "Individuell Reprografiersättning - Bildbyrå"
        Me.Filter_IR_Bildbyrå.Visible = False
        '
        'Filter_IR_Foto
        '
        Me.Filter_IR_Foto.CheckOnClick = True
        Me.Filter_IR_Foto.Name = "Filter_IR_Foto"
        Me.Filter_IR_Foto.Size = New System.Drawing.Size(626, 36)
        Me.Filter_IR_Foto.Text = "Individuell Reprografiersättning - Foto"
        '
        'Filter_IRDAGP_Foto
        '
        Me.Filter_IRDAGP_Foto.CheckOnClick = True
        Me.Filter_IRDAGP_Foto.Name = "Filter_IRDAGP_Foto"
        Me.Filter_IRDAGP_Foto.Size = New System.Drawing.Size(626, 36)
        Me.Filter_IRDAGP_Foto.Text = "Individuell Reprografiersättning - Dagpress - Foto"
        '
        'Filter_IRDAGP_Illust
        '
        Me.Filter_IRDAGP_Illust.CheckOnClick = True
        Me.Filter_IRDAGP_Illust.Name = "Filter_IRDAGP_Illust"
        Me.Filter_IRDAGP_Illust.Size = New System.Drawing.Size(626, 36)
        Me.Filter_IRDAGP_Illust.Text = "Individuell Reprografiersättning - Dagpress - Illust."
        '
        'Filter_KR
        '
        Me.Filter_KR.CheckOnClick = True
        Me.Filter_KR.Name = "Filter_KR"
        Me.Filter_KR.Size = New System.Drawing.Size(626, 36)
        Me.Filter_KR.Text = "Kundredovisning."
        '
        'Filter_Repro
        '
        Me.Filter_Repro.CheckOnClick = True
        Me.Filter_Repro.Name = "Filter_Repro"
        Me.Filter_Repro.Size = New System.Drawing.Size(626, 36)
        Me.Filter_Repro.Text = "Reproduktion."
        '
        'Filter_ST
        '
        Me.Filter_ST.CheckOnClick = True
        Me.Filter_ST.Name = "Filter_ST"
        Me.Filter_ST.Size = New System.Drawing.Size(626, 36)
        Me.Filter_ST.Text = "Sveriges Tidskrifter"
        '
        'Filter_TV
        '
        Me.Filter_TV.CheckOnClick = True
        Me.Filter_TV.Name = "Filter_TV"
        Me.Filter_TV.Size = New System.Drawing.Size(626, 36)
        Me.Filter_TV.Text = "TV"
        '
        'Filter_Totalsumma_GT_MenuItem
        '
        Me.Filter_Totalsumma_GT_MenuItem.Checked = True
        Me.Filter_Totalsumma_GT_MenuItem.CheckOnClick = True
        Me.Filter_Totalsumma_GT_MenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Filter_Totalsumma_GT_MenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Filter_Totalsumma_GT})
        Me.Filter_Totalsumma_GT_MenuItem.Name = "Filter_Totalsumma_GT_MenuItem"
        Me.Filter_Totalsumma_GT_MenuItem.Size = New System.Drawing.Size(348, 36)
        Me.Filter_Totalsumma_GT_MenuItem.Text = "Totalsumma > 100"
        '
        'Filter_Totalsumma_GT
        '
        Me.Filter_Totalsumma_GT.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Filter_Totalsumma_GT.Name = "Filter_Totalsumma_GT"
        Me.Filter_Totalsumma_GT.Size = New System.Drawing.Size(100, 39)
        Me.Filter_Totalsumma_GT.Text = "100"
        '
        'Filter_Datum_GT_MenuItem
        '
        Me.Filter_Datum_GT_MenuItem.Checked = True
        Me.Filter_Datum_GT_MenuItem.CheckOnClick = True
        Me.Filter_Datum_GT_MenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Filter_Datum_GT_MenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Filter_Datum_GT})
        Me.Filter_Datum_GT_MenuItem.Name = "Filter_Datum_GT_MenuItem"
        Me.Filter_Datum_GT_MenuItem.Size = New System.Drawing.Size(348, 36)
        Me.Filter_Datum_GT_MenuItem.Text = "Datum >"
        '
        'Filter_Datum_GT
        '
        Me.Filter_Datum_GT.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Filter_Datum_GT.Name = "Filter_Datum_GT"
        Me.Filter_Datum_GT.Size = New System.Drawing.Size(100, 39)
        '
        'Filter_Datum_LT_MenuItem
        '
        Me.Filter_Datum_LT_MenuItem.Checked = True
        Me.Filter_Datum_LT_MenuItem.CheckOnClick = True
        Me.Filter_Datum_LT_MenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Filter_Datum_LT_MenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Filter_Datum_LT})
        Me.Filter_Datum_LT_MenuItem.Name = "Filter_Datum_LT_MenuItem"
        Me.Filter_Datum_LT_MenuItem.Size = New System.Drawing.Size(348, 36)
        Me.Filter_Datum_LT_MenuItem.Text = "Datum <"
        '
        'Filter_Datum_LT
        '
        Me.Filter_Datum_LT.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Filter_Datum_LT.Name = "Filter_Datum_LT"
        Me.Filter_Datum_LT.Size = New System.Drawing.Size(100, 39)
        '
        'Filter_Upphovsman_MenuItem
        '
        Me.Filter_Upphovsman_MenuItem.CheckOnClick = True
        Me.Filter_Upphovsman_MenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Filter_Upphovsman_Efternamn_GT_MenuItem, Me.Filter_Upphovsman_Efternamn_LT_MenuItem, Me.Filter_Upphovsman_Efternamn_like_MenuItem, Me.Filter_Upphovsman_Förnamn_like_MenuItem})
        Me.Filter_Upphovsman_MenuItem.Name = "Filter_Upphovsman_MenuItem"
        Me.Filter_Upphovsman_MenuItem.Size = New System.Drawing.Size(348, 36)
        Me.Filter_Upphovsman_MenuItem.Tag = "Filter och sökkriterier för upphovsman"
        Me.Filter_Upphovsman_MenuItem.Text = "Upphovsman"
        '
        'Filter_Upphovsman_Efternamn_GT_MenuItem
        '
        Me.Filter_Upphovsman_Efternamn_GT_MenuItem.CheckOnClick = True
        Me.Filter_Upphovsman_Efternamn_GT_MenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Filter_Upphovsman_Efternamn_GT})
        Me.Filter_Upphovsman_Efternamn_GT_MenuItem.Name = "Filter_Upphovsman_Efternamn_GT_MenuItem"
        Me.Filter_Upphovsman_Efternamn_GT_MenuItem.Size = New System.Drawing.Size(239, 36)
        Me.Filter_Upphovsman_Efternamn_GT_MenuItem.Text = "Efternamn >="
        '
        'Filter_Upphovsman_Efternamn_GT
        '
        Me.Filter_Upphovsman_Efternamn_GT.DropDownWidth = 10
        Me.Filter_Upphovsman_Efternamn_GT.Items.AddRange(New Object() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "X", "Y", "Z", "Å", "Ä", "Ö"})
        Me.Filter_Upphovsman_Efternamn_GT.Name = "Filter_Upphovsman_Efternamn_GT"
        Me.Filter_Upphovsman_Efternamn_GT.Size = New System.Drawing.Size(75, 40)
        '
        'Filter_Upphovsman_Efternamn_LT_MenuItem
        '
        Me.Filter_Upphovsman_Efternamn_LT_MenuItem.CheckOnClick = True
        Me.Filter_Upphovsman_Efternamn_LT_MenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Filter_Upphovsman_Efternamn_LT})
        Me.Filter_Upphovsman_Efternamn_LT_MenuItem.Name = "Filter_Upphovsman_Efternamn_LT_MenuItem"
        Me.Filter_Upphovsman_Efternamn_LT_MenuItem.Size = New System.Drawing.Size(239, 36)
        Me.Filter_Upphovsman_Efternamn_LT_MenuItem.Text = "Efternamn <="
        '
        'Filter_Upphovsman_Efternamn_LT
        '
        Me.Filter_Upphovsman_Efternamn_LT.AutoCompleteCustomSource.AddRange(New String() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "X", "Y", "Z", "Å", "Ä", "Ö"})
        Me.Filter_Upphovsman_Efternamn_LT.Items.AddRange(New Object() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "X", "Y", "Z", "Å", "Ä", "Ö"})
        Me.Filter_Upphovsman_Efternamn_LT.Name = "Filter_Upphovsman_Efternamn_LT"
        Me.Filter_Upphovsman_Efternamn_LT.Size = New System.Drawing.Size(121, 40)
        '
        'Filter_Upphovsman_Efternamn_like_MenuItem
        '
        Me.Filter_Upphovsman_Efternamn_like_MenuItem.CheckOnClick = True
        Me.Filter_Upphovsman_Efternamn_like_MenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Filter_Upphovsman_Efternamn_like})
        Me.Filter_Upphovsman_Efternamn_like_MenuItem.Name = "Filter_Upphovsman_Efternamn_like_MenuItem"
        Me.Filter_Upphovsman_Efternamn_like_MenuItem.Size = New System.Drawing.Size(239, 36)
        Me.Filter_Upphovsman_Efternamn_like_MenuItem.Text = "Efternamn ="
        '
        'Filter_Upphovsman_Efternamn_like
        '
        Me.Filter_Upphovsman_Efternamn_like.AcceptsReturn = True
        Me.Filter_Upphovsman_Efternamn_like.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Filter_Upphovsman_Efternamn_like.Name = "Filter_Upphovsman_Efternamn_like"
        Me.Filter_Upphovsman_Efternamn_like.Size = New System.Drawing.Size(100, 39)
        Me.Filter_Upphovsman_Efternamn_like.Text = "*"
        '
        'Filter_Upphovsman_Förnamn_like_MenuItem
        '
        Me.Filter_Upphovsman_Förnamn_like_MenuItem.CheckOnClick = True
        Me.Filter_Upphovsman_Förnamn_like_MenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Filter_Upphovsman_Förnamn_like})
        Me.Filter_Upphovsman_Förnamn_like_MenuItem.Name = "Filter_Upphovsman_Förnamn_like_MenuItem"
        Me.Filter_Upphovsman_Förnamn_like_MenuItem.Size = New System.Drawing.Size(239, 36)
        Me.Filter_Upphovsman_Förnamn_like_MenuItem.Text = "Förnamn   ="
        '
        'Filter_Upphovsman_Förnamn_like
        '
        Me.Filter_Upphovsman_Förnamn_like.AcceptsReturn = True
        Me.Filter_Upphovsman_Förnamn_like.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Filter_Upphovsman_Förnamn_like.Name = "Filter_Upphovsman_Förnamn_like"
        Me.Filter_Upphovsman_Förnamn_like.Size = New System.Drawing.Size(100, 39)
        Me.Filter_Upphovsman_Förnamn_like.Text = "*"
        '
        'Filter_Checkable_Only
        '
        Me.Filter_Checkable_Only.Checked = True
        Me.Filter_Checkable_Only.CheckOnClick = True
        Me.Filter_Checkable_Only.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Filter_Checkable_Only.Name = "Filter_Checkable_Only"
        Me.Filter_Checkable_Only.Size = New System.Drawing.Size(348, 36)
        Me.Filter_Checkable_Only.Tag = "Visar inte rader där det inte finns några betalningsmottagare angivna. (just nu f" & _
    "ördelningssumman=0%)"
        Me.Filter_Checkable_Only.Text = "Dölj felaktiga mottagare"
        Me.Filter_Checkable_Only.ToolTipText = "Ej implementerad änu kommer till Rättighetshavarhanteringen."
        '
        'filter_Dold
        '
        Me.filter_Dold.CheckOnClick = True
        Me.filter_Dold.Enabled = False
        Me.filter_Dold.Name = "filter_Dold"
        Me.filter_Dold.Size = New System.Drawing.Size(348, 36)
        Me.filter_Dold.Tag = "Ej implementerad ännu då rättighetshavarhanteringen måste fungera."
        Me.filter_Dold.Text = "Visa dolda"
        '
        'filter_kommentar_like_MenuItem
        '
        Me.filter_kommentar_like_MenuItem.CheckOnClick = True
        Me.filter_kommentar_like_MenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.filter_kommentar_like})
        Me.filter_kommentar_like_MenuItem.Name = "filter_kommentar_like_MenuItem"
        Me.filter_kommentar_like_MenuItem.Size = New System.Drawing.Size(348, 36)
        Me.filter_kommentar_like_MenuItem.Text = "Kommentar"
        '
        'filter_kommentar_like
        '
        Me.filter_kommentar_like.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.filter_kommentar_like.Name = "filter_kommentar_like"
        Me.filter_kommentar_like.Size = New System.Drawing.Size(100, 39)
        Me.filter_kommentar_like.Text = "*"
        '
        'SorteringToolStripMenuItem
        '
        Me.SorteringToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EfternamnToolStripMenuItem, Me.TotalsummaToolStripMenuItem1})
        Me.SorteringToolStripMenuItem.Name = "SorteringToolStripMenuItem"
        Me.SorteringToolStripMenuItem.Size = New System.Drawing.Size(125, 36)
        Me.SorteringToolStripMenuItem.Text = "&Sortering"
        '
        'EfternamnToolStripMenuItem
        '
        Me.EfternamnToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Sort_Namn_Upp, Me.Sort_Namn_Ned})
        Me.EfternamnToolStripMenuItem.Name = "EfternamnToolStripMenuItem"
        Me.EfternamnToolStripMenuItem.Size = New System.Drawing.Size(219, 36)
        Me.EfternamnToolStripMenuItem.Text = "Efternamn"
        '
        'Sort_Namn_Upp
        '
        Me.Sort_Namn_Upp.Checked = True
        Me.Sort_Namn_Upp.CheckOnClick = True
        Me.Sort_Namn_Upp.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Sort_Namn_Upp.Name = "Sort_Namn_Upp"
        Me.Sort_Namn_Upp.Size = New System.Drawing.Size(183, 36)
        Me.Sort_Namn_Upp.Text = "&Stigande"
        Me.Sort_Namn_Upp.ToolTipText = "Sortera listan på efternamn."
        '
        'Sort_Namn_Ned
        '
        Me.Sort_Namn_Ned.CheckOnClick = True
        Me.Sort_Namn_Ned.Name = "Sort_Namn_Ned"
        Me.Sort_Namn_Ned.Size = New System.Drawing.Size(183, 36)
        Me.Sort_Namn_Ned.Text = "&Fallande"
        '
        'TotalsummaToolStripMenuItem1
        '
        Me.TotalsummaToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Sort_Totalsumma_Upp, Me.Sort_Totalsumma_Ned})
        Me.TotalsummaToolStripMenuItem1.Name = "TotalsummaToolStripMenuItem1"
        Me.TotalsummaToolStripMenuItem1.Size = New System.Drawing.Size(219, 36)
        Me.TotalsummaToolStripMenuItem1.Text = "Totalsumma"
        '
        'Sort_Totalsumma_Upp
        '
        Me.Sort_Totalsumma_Upp.CheckOnClick = True
        Me.Sort_Totalsumma_Upp.Name = "Sort_Totalsumma_Upp"
        Me.Sort_Totalsumma_Upp.Size = New System.Drawing.Size(183, 36)
        Me.Sort_Totalsumma_Upp.Text = "&Stigande"
        '
        'Sort_Totalsumma_Ned
        '
        Me.Sort_Totalsumma_Ned.CheckOnClick = True
        Me.Sort_Totalsumma_Ned.Name = "Sort_Totalsumma_Ned"
        Me.Sort_Totalsumma_Ned.Size = New System.Drawing.Size(183, 36)
        Me.Sort_Totalsumma_Ned.Text = "&Fallande"
        '
        'MarkeraToolStripMenuItem
        '
        Me.MarkeraToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AktuellRadToolStripMenuItem, Me.AllaToolStripMenuItem, Me.AvmarkeraAllaToolStripMenuItem})
        Me.MarkeraToolStripMenuItem.Name = "MarkeraToolStripMenuItem"
        Me.MarkeraToolStripMenuItem.Size = New System.Drawing.Size(114, 36)
        Me.MarkeraToolStripMenuItem.Text = "&Markera"
        '
        'AktuellRadToolStripMenuItem
        '
        Me.AktuellRadToolStripMenuItem.Name = "AktuellRadToolStripMenuItem"
        Me.AktuellRadToolStripMenuItem.Size = New System.Drawing.Size(246, 36)
        Me.AktuellRadToolStripMenuItem.Text = "Aktuell &rad"
        '
        'AllaToolStripMenuItem
        '
        Me.AllaToolStripMenuItem.Name = "AllaToolStripMenuItem"
        Me.AllaToolStripMenuItem.Size = New System.Drawing.Size(246, 36)
        Me.AllaToolStripMenuItem.Text = "&Alla"
        '
        'AvmarkeraAllaToolStripMenuItem
        '
        Me.AvmarkeraAllaToolStripMenuItem.Name = "AvmarkeraAllaToolStripMenuItem"
        Me.AvmarkeraAllaToolStripMenuItem.Size = New System.Drawing.Size(246, 36)
        Me.AvmarkeraAllaToolStripMenuItem.Text = "A&vmarkera alla"
        '
        'UtförToolStripMenuItem
        '
        Me.UtförToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GodkännFörUtbetalningToolStripMenuItem, Me.SkickaTillbakaToolStripMenuItem, Me.ÖppnaToolStripMenuItem})
        Me.UtförToolStripMenuItem.Name = "UtförToolStripMenuItem"
        Me.UtförToolStripMenuItem.Size = New System.Drawing.Size(81, 36)
        Me.UtförToolStripMenuItem.Text = "Utför"
        '
        'GodkännFörUtbetalningToolStripMenuItem
        '
        Me.GodkännFörUtbetalningToolStripMenuItem.Name = "GodkännFörUtbetalningToolStripMenuItem"
        Me.GodkännFörUtbetalningToolStripMenuItem.Size = New System.Drawing.Size(393, 36)
        Me.GodkännFörUtbetalningToolStripMenuItem.Text = "Godkänn för utbetalning"
        '
        'SkickaTillbakaToolStripMenuItem
        '
        Me.SkickaTillbakaToolStripMenuItem.Enabled = False
        Me.SkickaTillbakaToolStripMenuItem.Name = "SkickaTillbakaToolStripMenuItem"
        Me.SkickaTillbakaToolStripMenuItem.Size = New System.Drawing.Size(393, 36)
        Me.SkickaTillbakaToolStripMenuItem.Text = "Skicka tillbaka till Busas"
        '
        'ÖppnaToolStripMenuItem
        '
        Me.ÖppnaToolStripMenuItem.Name = "ÖppnaToolStripMenuItem"
        Me.ÖppnaToolStripMenuItem.Size = New System.Drawing.Size(393, 36)
        Me.ÖppnaToolStripMenuItem.Text = "Öppna godkänn utbetalning"
        Me.ÖppnaToolStripMenuItem.ToolTipText = "Öppnar nästa fönster, godkänn utbetalningar, med samma filterinställningar."
        '
        'HjälpToolStripMenuItem
        '
        Me.HjälpToolStripMenuItem.Name = "HjälpToolStripMenuItem"
        Me.HjälpToolStripMenuItem.Size = New System.Drawing.Size(82, 36)
        Me.HjälpToolStripMenuItem.Text = "&Hjälp"
        '
        'flpStatus
        '
        Me.flpStatus.AutoSize = True
        Me.flpStatus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.flpStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.flpStatus.Controls.Add(Me.bUtför)
        Me.flpStatus.Controls.Add(Me.lblSort)
        Me.flpStatus.Controls.Add(Me.lblFilter_Date)
        Me.flpStatus.Controls.Add(Me.lblFilter_Upphovsman_Efternamn)
        Me.flpStatus.Controls.Add(Me.lblFilter_Upphovsman_Förnamn)
        Me.flpStatus.Controls.Add(Me.lblFilter_Belopp)
        Me.flpStatus.Controls.Add(Me.lblFilter_Betalningstyp)
        Me.flpStatus.Controls.Add(Me.lbl_Filter_Checkable_only)
        Me.flpStatus.Controls.Add(Me.lblFilter_kommentar)
        Me.flpStatus.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.flpStatus.Dock = System.Windows.Forms.DockStyle.Top
        Me.flpStatus.Location = New System.Drawing.Point(0, 44)
        Me.flpStatus.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.flpStatus.MinimumSize = New System.Drawing.Size(18, 17)
        Me.flpStatus.Name = "flpStatus"
        Me.flpStatus.Size = New System.Drawing.Size(1662, 79)
        Me.flpStatus.TabIndex = 1
        '
        'bUtför
        '
        Me.bUtför.Location = New System.Drawing.Point(6, 6)
        Me.bUtför.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.bUtför.Name = "bUtför"
        Me.bUtför.Size = New System.Drawing.Size(86, 40)
        Me.bUtför.TabIndex = 11
        Me.bUtför.Text = "Visa"
        Me.bUtför.UseVisualStyleBackColor = True
        '
        'lblSort
        '
        Me.lblSort.AutoSize = True
        Me.lblSort.Location = New System.Drawing.Point(104, 0)
        Me.lblSort.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblSort.Name = "lblSort"
        Me.lblSort.Size = New System.Drawing.Size(176, 25)
        Me.lblSort.TabIndex = 0
        Me.lblSort.Text = "Sortering : ingen."
        '
        'lblFilter_Date
        '
        Me.lblFilter_Date.AutoSize = True
        Me.lblFilter_Date.Location = New System.Drawing.Point(292, 0)
        Me.lblFilter_Date.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblFilter_Date.Name = "lblFilter_Date"
        Me.lblFilter_Date.Size = New System.Drawing.Size(186, 25)
        Me.lblFilter_Date.TabIndex = 1
        Me.lblFilter_Date.Text = "Datumfilter = idag."
        '
        'lblFilter_Upphovsman_Efternamn
        '
        Me.lblFilter_Upphovsman_Efternamn.AutoSize = True
        Me.lblFilter_Upphovsman_Efternamn.Location = New System.Drawing.Point(490, 0)
        Me.lblFilter_Upphovsman_Efternamn.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblFilter_Upphovsman_Efternamn.Name = "lblFilter_Upphovsman_Efternamn"
        Me.lblFilter_Upphovsman_Efternamn.Size = New System.Drawing.Size(162, 25)
        Me.lblFilter_Upphovsman_Efternamn.TabIndex = 2
        Me.lblFilter_Upphovsman_Efternamn.Text = "Filter efternamn"
        '
        'lblFilter_Upphovsman_Förnamn
        '
        Me.lblFilter_Upphovsman_Förnamn.AutoSize = True
        Me.lblFilter_Upphovsman_Förnamn.Location = New System.Drawing.Point(664, 0)
        Me.lblFilter_Upphovsman_Förnamn.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblFilter_Upphovsman_Förnamn.Name = "lblFilter_Upphovsman_Förnamn"
        Me.lblFilter_Upphovsman_Förnamn.Size = New System.Drawing.Size(144, 25)
        Me.lblFilter_Upphovsman_Förnamn.TabIndex = 6
        Me.lblFilter_Upphovsman_Förnamn.Text = "Förnamn filter"
        '
        'lblFilter_Belopp
        '
        Me.lblFilter_Belopp.AutoSize = True
        Me.lblFilter_Belopp.Location = New System.Drawing.Point(820, 0)
        Me.lblFilter_Belopp.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblFilter_Belopp.Name = "lblFilter_Belopp"
        Me.lblFilter_Belopp.Size = New System.Drawing.Size(155, 25)
        Me.lblFilter_Belopp.TabIndex = 4
        Me.lblFilter_Belopp.Text = "Totalbelopp > ."
        '
        'lblFilter_Betalningstyp
        '
        Me.lblFilter_Betalningstyp.AutoSize = True
        Me.lblFilter_Betalningstyp.Location = New System.Drawing.Point(987, 0)
        Me.lblFilter_Betalningstyp.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblFilter_Betalningstyp.Name = "lblFilter_Betalningstyp"
        Me.lblFilter_Betalningstyp.Size = New System.Drawing.Size(190, 25)
        Me.lblFilter_Betalningstyp.TabIndex = 5
        Me.lblFilter_Betalningstyp.Text = "Betalningstyp=Alla"
        '
        'lbl_Filter_Checkable_only
        '
        Me.lbl_Filter_Checkable_only.AutoSize = True
        Me.lbl_Filter_Checkable_only.Location = New System.Drawing.Point(1189, 0)
        Me.lbl_Filter_Checkable_only.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lbl_Filter_Checkable_only.Name = "lbl_Filter_Checkable_only"
        Me.lbl_Filter_Checkable_only.Size = New System.Drawing.Size(265, 25)
        Me.lbl_Filter_Checkable_only.TabIndex = 7
        Me.lbl_Filter_Checkable_only.Text = "Visa endast korrekta rader"
        '
        'lblFilter_kommentar
        '
        Me.lblFilter_kommentar.AutoSize = True
        Me.lblFilter_kommentar.Location = New System.Drawing.Point(6, 52)
        Me.lblFilter_kommentar.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblFilter_kommentar.Name = "lblFilter_kommentar"
        Me.lblFilter_kommentar.Size = New System.Drawing.Size(193, 25)
        Me.lblFilter_kommentar.TabIndex = 12
        Me.lblFilter_kommentar.Text = "kommentarsökning"
        '
        'TLPSum
        '
        Me.TLPSum.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TLPSum.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TLPSum.ColumnCount = 4
        Me.TLPSum.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TLPSum.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 192.0!))
        Me.TLPSum.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.42857!))
        Me.TLPSum.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.57143!))
        Me.TLPSum.Controls.Add(Me.Label1, 1, 1)
        Me.TLPSum.Controls.Add(Me.lblTotalAmount, 2, 1)
        Me.TLPSum.Controls.Add(Me.lblAntalRader, 3, 2)
        Me.TLPSum.Controls.Add(Me.lblAntal_Upphovsmän, 3, 0)
        Me.TLPSum.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TLPSum.Location = New System.Drawing.Point(0, 1052)
        Me.TLPSum.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.TLPSum.Name = "TLPSum"
        Me.TLPSum.RowCount = 3
        Me.TLPSum.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TLPSum.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.TLPSum.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.TLPSum.Size = New System.Drawing.Size(1662, 121)
        Me.TLPSum.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(46, 40)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Totalsumma"
        '
        'lblTotalAmount
        '
        Me.lblTotalAmount.AutoSize = True
        Me.lblTotalAmount.Location = New System.Drawing.Point(238, 40)
        Me.lblTotalAmount.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Size = New System.Drawing.Size(24, 25)
        Me.lblTotalAmount.TabIndex = 0
        Me.lblTotalAmount.Text = "0"
        '
        'lblAntalRader
        '
        Me.lblAntalRader.AutoSize = True
        Me.lblAntalRader.Location = New System.Drawing.Point(1259, 78)
        Me.lblAntalRader.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblAntalRader.Name = "lblAntalRader"
        Me.lblAntalRader.Size = New System.Drawing.Size(195, 25)
        Me.lblAntalRader.TabIndex = 4
        Me.lblAntalRader.Text = "0 av X fakturarader"
        '
        'lblAntal_Upphovsmän
        '
        Me.lblAntal_Upphovsmän.AutoSize = True
        Me.lblAntal_Upphovsmän.Location = New System.Drawing.Point(1259, 0)
        Me.lblAntal_Upphovsmän.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblAntal_Upphovsmän.Name = "lblAntal_Upphovsmän"
        Me.lblAntal_Upphovsmän.Size = New System.Drawing.Size(208, 25)
        Me.lblAntal_Upphovsmän.TabIndex = 5
        Me.lblAntal_Upphovsmän.Text = "X antal upphovsmän"
        '
        'pbProgress
        '
        Me.pbProgress.Location = New System.Drawing.Point(430, 429)
        Me.pbProgress.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.pbProgress.MarqueeAnimationSpeed = 0
        Me.pbProgress.Name = "pbProgress"
        Me.pbProgress.Size = New System.Drawing.Size(696, 44)
        Me.pbProgress.TabIndex = 4
        '
        'PaymentTreeView
        '
        Me.PaymentTreeView.CheckBoxes = True
        Me.PaymentTreeView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PaymentTreeView.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PaymentTreeView.Location = New System.Drawing.Point(0, 123)
        Me.PaymentTreeView.Margin = New System.Windows.Forms.Padding(6)
        Me.PaymentTreeView.Name = "PaymentTreeView"
        Me.PaymentTreeView.ShowNodeToolTips = True
        Me.PaymentTreeView.Size = New System.Drawing.Size(1662, 929)
        Me.PaymentTreeView.TabIndex = 3
        '
        'FormUnderlag
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1662, 1173)
        Me.Controls.Add(Me.pbProgress)
        Me.Controls.Add(Me.PaymentTreeView)
        Me.Controls.Add(Me.TLPSum)
        Me.Controls.Add(Me.flpStatus)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.MinimumSize = New System.Drawing.Size(774, 704)
        Me.Name = "FormUnderlag"
        Me.Text = "BUSAS betalningsunderlag."
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.flpStatus.ResumeLayout(False)
        Me.flpStatus.PerformLayout()
        Me.TLPSum.ResumeLayout(False)
        Me.TLPSum.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArkivToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents filterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HjälpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SparaSomExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RapportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AvslutaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Filter_Utbetalningstyp_Menutem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Filter_Totalsumma_GT_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Filter_Datum_GT_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SorteringToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EfternamnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MarkeraToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AktuellRadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AllaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AvmarkeraAllaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UtförToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GodkännFörUtbetalningToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SkickaTillbakaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Filter_Datum_LT_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Filter_IR As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Filter_IR_Foto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Filter_IV As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Filter_KR As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Filter_Repro As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Filter_Följerätt As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Filter_ST As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TotalsummaToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents flpStatus As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Sort_Namn_Upp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Sort_Namn_Ned As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Sort_Totalsumma_Upp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Sort_Totalsumma_Ned As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblSort As System.Windows.Forms.Label
    Friend WithEvents lblFilter_Date As System.Windows.Forms.Label
    Friend WithEvents lblFilter_Upphovsman_Efternamn As System.Windows.Forms.Label
    Friend WithEvents Filter_Totalsumma_GT As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents TLPSum As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblTotalAmount As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Filter_Datum_GT As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents Filter_Datum_LT As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents PaymentTreeView As B2.PaymentGroupTreeView
    Friend WithEvents lblFilter_Belopp As System.Windows.Forms.Label
    Friend WithEvents Filter_IR_Bildbyrå As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblFilter_Betalningstyp As System.Windows.Forms.Label
    Friend WithEvents lblFilter_Upphovsman_Förnamn As System.Windows.Forms.Label
    Friend WithEvents lblAntalRader As System.Windows.Forms.Label
    Friend WithEvents pbProgress As System.Windows.Forms.ProgressBar
    Friend WithEvents filter_Dold As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Filter_Upphovsman_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Filter_Upphovsman_Efternamn_GT_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Filter_Upphovsman_Efternamn_GT As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents Filter_Upphovsman_Efternamn_LT_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Filter_Upphovsman_Efternamn_LT As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents Filter_Upphovsman_Efternamn_like_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Filter_Upphovsman_Efternamn_like As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents Filter_Upphovsman_Förnamn_like_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Filter_Upphovsman_Förnamn_like As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents Filter_Checkable_Only As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblAntal_Upphovsmän As System.Windows.Forms.Label
    Friend WithEvents lbl_Filter_Checkable_only As System.Windows.Forms.Label
    Friend WithEvents bUtför As System.Windows.Forms.Button
    Friend WithEvents ÖppnaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents filter_kommentar_like_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents filter_kommentar_like As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents lblFilter_kommentar As System.Windows.Forms.Label
    Friend WithEvents Filter_IRDAGP_Foto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Filter_IRDAGP_Illust As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Filter_TV As System.Windows.Forms.ToolStripMenuItem
End Class
