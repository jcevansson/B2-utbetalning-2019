Imports System
Imports System.ComponentModel
Imports System.Threading
Imports System.Windows.Forms
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Public Class FormUtbetalning


    Private UtbetalningDao As PaymentBaseDAO 'Ett objekt som sköter operationer mot databasen
    Private dataTable As DataTable 'Datatabellen som ligger till grund för trädinfon
    Private dataView As DataView
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        'Sort_Namn_Ned.Checked = False : Sort_Namn_Upp.Checked = False
        Filter_Efternamn_LT.SelectedIndex = Filter_Efternamn_LT.Items.Count - 1
        Filter_Efternamn_GT.SelectedIndex = 0
        Filter_Upphovsman_Efternamn_LT.SelectedIndex = Filter_Upphovsman_Efternamn_LT.Items.Count - 1
        Filter_Upphovsman_Efternamn_GT.SelectedIndex = 0
        Filter_Datum_GT_MenuItem.Checked = True : Filter_Datum_GT.Text = Date.Today.Subtract(New TimeSpan(14, 0, 0, 0)).ToShortDateString
        Filter_Datum_LT_MenuItem.Checked = True : Filter_Datum_LT.Text = Date.Today.ToShortDateString
        'Filter_Förnamn_like.Text = "*"
        ' Filter_Datum_LT_MenuItem.Text = "Datum < " & If(IsDate(Filter_Datum_LT.ToString), Filter_Datum_LT.ToString, "######") & Space(14 - Filter_Datum_LT.Text.Length)
        'Filter_Datum_GT_MenuItem.Text = "Datum > " & If(IsDate(Filter_Datum_GT.ToString), Filter_Datum_GT.ToString, "######") & Space(14 - Filter_Datum_GT.Text.Length)
        'Filter_Totalsumma_GT_MenuItem.Text = "Totalsumma > " & IIf(IsNumeric(Filter_Totalsumma_GT.Text), Filter_Totalsumma_GT.Text, 0) & Space(6 - Filter_Totalsumma_GT.Text.Length)
        refill_Utbetalning_treeview()
        Lägg_till_befintlig_fil_fyll()
        Status_Update()


    End Sub
    Sub Lägg_till_befintlig_fil_fyll()
        'Fyller dropdown rutorn för befintliga filer BG_Lägg_till_befintlig,PG_Lägg_till_befintlig,UTL_lägg_tillBefintlig
        Cursor = Cursors.WaitCursor
        Dim selectCommand As SqlCommand = New SqlCommand()
        Dim sqlConn As SqlConnection = New SqlConnection(My.Settings.DBconnectionString)
        selectCommand.CommandType = CommandType.Text
        selectCommand.CommandText = "select * from v_transaktion_assigned_list order by skapad"
        PG_Befintlig_MI.DropDownItems.Clear()
        BG_Befintlig_MI.DropDownItems.Clear()
        UTL_Befintlig_MI.DropDownItems.Clear()

        sqlConn.Open()
        System.Console.WriteLine(selectCommand.CommandText.ToString)
        selectCommand.Connection = SQLConn
        Dim reader As SqlDataReader = selectCommand.ExecuteReader
        Dim typ, s As String
        Dim ddi As ToolStripDropDownItem
        While reader.Read
            typ = reader("Transaktion_typ").ToString.Trim.ToUpper
            s = CDate(reader("Skapad")).ToShortDateString & " " & CDate(reader("Skapad")).ToShortTimeString & " " & reader("antal_poster_calc") & " st."
            If typ = "PLUSGIRO" Then
                ddi = PG_Befintlig_MI.DropDownItems.Add(s)
                ddi.Tag = reader("ID")
                AddHandler ddi.Click, AddressOf PG_Lägg_till_befintlig_Click
            End If

            If typ = "BANKGIRO" Then
                ddi = BG_Befintlig_MI.DropDownItems.Add(s)
                ddi.Tag = reader("ID")
                AddHandler ddi.Click, AddressOf BG_Lägg_till_befintlig_Click

            End If

            If typ = "UTLAND" Then
                ddi = UTL_Befintlig_MI.DropDownItems.Add(s)
                ddi.Tag = reader("ID")
                AddHandler ddi.Click, AddressOf UTL_Lägg_till_befintlig_Click

            End If


        End While
        reader.Close()

        Cursor = Cursors.Default
    End Sub


    Public Sub refill_utbetalning_treeview()
        Cursor = Cursors.WaitCursor

        Dim whereString As String = Get_where_string()
        Dim paymentDataSet As DataSet = New DataSet
        ' Dim connectionString As String = resources.ResourceManager.'"Data Source=192.168.0.38;Initial Catalog=B2Arbete;user id=Developer;Connection Timeout=120;Password=Developer;"
        Dim sqlConn As SqlConnection = New SqlConnection(My.Settings.DBconnectionString)
        Dim selectCommand As SqlCommand = New SqlCommand()
        selectCommand.CommandType = CommandType.Text
        '        selectCommand.CommandText = "SELECT * ,KontoOK checkable,  Mottagare_Efternamn+', '+Mottagare_Förnamn+' ('+Mottagare_personnummer+')' Namn_Personnummer_grupp " & _
        '                    "into #t from v_Betalning_godkänd_ej_transaktion  where " & Get_where_string() & _
        '                    "select (select sum(t2.CALC_Belopp_NETTO) from #t t2 where t2.[upphovsman_id]=t.[upphovsman_id] and t2.mottagare_id=t.mottagare_id and  t2.mottagare_typ=t.mottagare_typ  ) T_Belopp,* from #t t " & _
        '                   "where (select sum(t2.CALC_Belopp_NETTO) from #t t2 where t2.[upphovsman_id]=t.[upphovsman_id] and t2.mottagare_id=t.mottagare_id and  t2.mottagare_typ=t.mottagare_typ  ) > " & Get_Filter_TotalSumma() & _
        '                    "order by efternamn,förnamn,[registrerat datum] " & _
        '                    "drop table #t"    
        selectCommand.CommandText = "SELECT * " & _
                    "into #t from v_betalning_summering  where " & Get_where_string() & _
                   "; select (select sum(t2.CALC_Belopp_NETTO) from #t t2 where t2.[Namn_Personnummer_grupp]=t.[Namn_Personnummer_grupp] ) T_Belopp," & _
                    " (select sum(t2.Belopp) from #t t2 where t2.[Namn_Personnummer_grupp]=t.[Namn_Personnummer_grupp]  ) T_Belopp_Brutto,* from #t t " & _
                   "where (select sum(t2.Belopp) from #t t2 where t2.[Namn_Personnummer_grupp]=t.[Namn_Personnummer_grupp] )> " & Get_Filter_TotalSumma() & _
                   " order by efternamn,förnamn,[registrerat datum]; " & _
                   "drop table #t;"

            ' "SELECT [id],[betalning_typ],[upphovsman_id],[belopp],[betalningsdatum],[kommentar],[Personnummer],[förnamn],[efternamn],[Registrerat datum] ,  Efternamn+', '+Förnamn+' ('+personnummer+')' Namn_Personnummer_grupp,* from v_betalning_underlag where " & Status_get_wherestring() & " order by efternamn,förnamn,[registrerat datum]"
        System.Console.WriteLine(selectCommand.CommandText.ToString)
        Dim s As Stopwatch = New Stopwatch
            's.Start()
        pbProgress.Value = 0
        pbProgress.Visible = True
        selectCommand.Connection = sqlConn
            'Console.WriteLine("1.Innan New DataAdapter: " & s.ElapsedMilliseconds)
            'För att kunna fylla data till DataSetet behövs en SqlDataAdapter
        Dim dataAdapter As SqlDataAdapter = New SqlDataAdapter()
            'Console.WriteLine("2.Efter New DataAdapter: " & s.ElapsedMilliseconds) : s.Reset() : s.Start()

        dataAdapter.SelectCommand = selectCommand

        Try
                'Försök att hämta data från tabellen till DataSetet ds.
                'Console.WriteLine("3.Innan DA fill: " & s.ElapsedMilliseconds) : s.Reset() : s.Start()
            dataAdapter.Fill(paymentDataSet)
                'Console.WriteLine("4.Efter DA fill: " & s.ElapsedMilliseconds) : s.Reset() : s.Start()

        Catch e As SqlException
            MsgBox(e.ToString)

        Finally
                'Stäng SqlConnection-objektet ifall det är öppet eller ifall det blivit något fel
            If sqlConn.State = ConnectionState.Open Or sqlConn.State = ConnectionState.Broken Then
                sqlConn.Close()
                End If
            pbProgress.Visible = False
            End Try
        Try
                'Console.WriteLine("5.Innan datatable: " & s.ElapsedMilliseconds) : s.Reset() : s.Start()
            dataTable = paymentDataSet.Tables(0)
        Catch
            dataTable = New DataTable
        Finally
                'Console.WriteLine("6.Efter datatable: " & s.ElapsedMilliseconds) : s.Reset() : s.Start()
            dataView = New DataView(dataTable)
                'Fyll trädnodernas data med data från den sorterade tabellens
                'Console.WriteLine("7.Efter fill innan set dataview : " & s.ElapsedMilliseconds) : s.Reset() : s.Start()
            UtbetalningTreeView.SetDataView(dataView)
                'Console.WriteLine("8.Efter dataview: " & s.ElapsedMilliseconds) : s.Reset() : s.Start()
            Dim GroupNames() As String = {"Namn_Personnummer_grupp", "Betalning_typ", "betalning_underlag_ID"}
            UtbetalningTreeView.setGroupNames(GroupNames)
            UtbetalningTreeView.setColSumName("CALC_Belopp_NETTO")
            UtbetalningTreeView.setColGroupSumName("T_Belopp") 'Gruppsumma att sortera på
            pbProgress.Visible = True
            pbProgress.Value = 0
                'Console.WriteLine("9.Innan PTV fill: " & s.ElapsedMilliseconds) : s.Reset() : s.Start()
            UtbetalningTreeView.Fill(pbProgress)
                'Console.WriteLine("10.Efter PTV fill: " & s.ElapsedMilliseconds) : s.Reset() : s.Start()
            pbProgress.Visible = False
            s.Start()
            Sort()
            Console.WriteLine("11.Efter SORTERING: " & s.ElapsedMilliseconds) : s.Reset() : s.Start()
            Cursor = Cursors.Default

            End Try
        Status_Update()
        Cursor = Cursors.Default
    End Sub

    REM Uppdaterar statusrad baserat på filter och sorteringsinställningar
    Private Sub Status_Update()
        'Sortering
        If Sort_Namn_Ned.Checked = True Then
            lblSort.Text = "Sortering namn fallande."
        ElseIf Sort_Namn_Upp.Checked = True Then
            lblSort.Text = "Sortering namn stigande."
        ElseIf Sort_Totalsumma_Ned.Checked = True Then
            lblSort.Text = "Sortering totalsumma fallande."
        ElseIf Sort_Totalsumma_Upp.Checked = True Then
            lblSort.Text = "Sortering totalsumma stigande."
        Else
            lblSort.Text = "Osorterat."
        End If

        If Filter_Checkable_Only.Checked = True Then
            lbl_Filter_Checkable_only.Text = ""
        Else
            lbl_Filter_Checkable_only.Text = "Visar även felaktiga kontorader"
        End If


        'Filter för upphovsman
        lblFilter_Upphovsman_Efternamn.Text = "" : lblFilter_Upphovsman_Förnamn.Text = ""
        If Filter_Upphovsman_MenuItem.Checked = True Then

            If (Filter_Upphovsman_Efternamn_GT_MenuItem.Checked = True And Filter_Upphovsman_Efternamn_GT.SelectedIndex >= 0) And _
                (Filter_Upphovsman_Efternamn_LT_MenuItem.Checked = True And Filter_Upphovsman_Efternamn_LT.SelectedIndex >= 0) Then
                lblFilter_Upphovsman_Efternamn.Text = "Efternamn = " & Filter_Upphovsman_Efternamn_GT.Text & "-" & Filter_Upphovsman_Efternamn_LT.Text
            ElseIf Filter_Upphovsman_Efternamn_LT_MenuItem.Checked = True And Filter_Upphovsman_Efternamn_LT.SelectedIndex >= 0 Then
                lblFilter_Upphovsman_Efternamn.Text = "Efternamn = -" & Filter_Upphovsman_Efternamn_LT.Text
            ElseIf Filter_Upphovsman_Efternamn_GT_MenuItem.Checked = True And Filter_Upphovsman_Efternamn_GT.SelectedIndex >= 0 Then
                lblFilter_Upphovsman_Efternamn.Text = "Efternamn = " & Filter_Upphovsman_Efternamn_GT.Text & "-"
            End If


            If Filter_Upphovsman_Efternamn_like_MenuItem.Checked = True Then
                lblFilter_Upphovsman_Efternamn.Text &= " Efternamn = " & Filter_Upphovsman_Efternamn_like.Text

            End If


            'Filtertext för Förnamn
            If Filter_Upphovsman_Förnamn_like_MenuItem.Checked = True Then
                lblFilter_Upphovsman_Förnamn.Text = " Förnamn = " & Filter_Upphovsman_Förnamn_like.Text

            End If
        End If

        'Filtertext för Namn (mottagare)
        lblFilter_Förnamn.Text = ""
        lblFilter_Efternamn.Text = ""
        lblFilter_mottagartyp.Text = ""

        If Filter_Mottagare_MI.Checked = True Then
            If (Filter_Efternamn_GT_MenuItem.Checked = True And Filter_Efternamn_GT.SelectedIndex >= 0) And _
                (Filter_Efternamn_LT_MenuItem.Checked = True And Filter_Efternamn_LT.SelectedIndex >= 0) Then
                lblFilter_Efternamn.Text = "M_Efternamn = " & Filter_Efternamn_GT.Text & "-" & Filter_Efternamn_LT.Text
            ElseIf Filter_Efternamn_LT_MenuItem.Checked = True And Filter_Efternamn_LT.SelectedIndex >= 0 Then
                lblFilter_Efternamn.Text = "M_Efternamn = -" & Filter_Efternamn_LT.Text
            ElseIf Filter_Efternamn_GT_MenuItem.Checked = True And Filter_Efternamn_GT.SelectedIndex >= 0 Then
                lblFilter_Efternamn.Text = "M_Efternamn = " & Filter_Efternamn_GT.Text & "-"
            End If

            If Filter_Efternamn_like_MenuItem.Checked = True Then
                lblFilter_Efternamn.Text &= " M_Efternamn = " & Filter_Efternamn_like.Text
            End If
            'Filtertext för Förnamn
            If Filter_Förnamn_like_MenuItem.Checked = True Then
                lblFilter_Förnamn.Text = " M_Förnamn = " & Filter_Förnamn_like.Text
            End If

            'Mottagartyp
            If Filter_mottagaretyp_MI.Checked = True Then
                If Filter_mottagare_typ_Ombud.Checked = True Or _
                        Filter_mottagare_typ_Rättighetshavare.Checked = True Or _
                       Filter_mottagare_typ_Systerorganisation.Checked = True Or _
                       Filter_mottagare_typ_Upphovsman.Checked = True Then
                    Dim FirstIn As Boolean = True
                    Dim StringIn As String = "Mottagartyp=("


                    If Filter_mottagare_typ_Ombud.Checked = True Then StringIn &= IIf(FirstIn, "", ",") & "Ombud" : FirstIn = False
                    If Filter_mottagare_typ_Rättighetshavare.Checked = True Then StringIn &= IIf(FirstIn, "", ",") & "Rättighetsh." : FirstIn = False
                    If Filter_mottagare_typ_Systerorganisation.Checked = True Then StringIn &= IIf(FirstIn, "", ",") & "Systerorg." : FirstIn = False
                    If Filter_mottagare_typ_Upphovsman.Checked = True Then StringIn &= IIf(FirstIn, "", ",") & "Upphovsm." : FirstIn = False
                    StringIn &= ") "
                    lblFilter_mottagartyp.Text = StringIn
                End If
            End If

        End If
        'Kommentar fritextsökning filter
        lblFilter_kommentar.Text = ""
        If filter_kommentar_like_MenuItem.Checked = True Then
            lblFilter_kommentar.Text = " Kommentar = " & filter_kommentar_like.Text
        Else
            lblFilter_kommentar.Text = ""
        End If

        'Datumfilter
        If Filter_Datum_GT_MenuItem.Checked = False And Filter_Datum_LT_MenuItem.Checked = False Then
            lblFilter_Date.Text = "Inget datumfilter."
        Else
            lblFilter_Date.Text = ""
            If Filter_Datum_GT_MenuItem.Checked = True Then
                lblFilter_Date.Text = "Datum > " & Filter_Datum_GT.Text & "."
            End If
            If Filter_Datum_LT_MenuItem.Checked = True Then
                lblFilter_Date.Text &= " Datum < " & Filter_Datum_LT.Text & "."
            End If

        End If
        'DoldVisad
        If Filter_dold.Checked = False Then lblFilter_dold.Text = "" Else lblFilter_dold.Text = "Visar dolda rader"


        'Betalning_typ
        lblFilter_Betalningstyp.Text = ""

        If Filter_Utbetalningstyp_MI.Checked = True Then
            If Filter_Följerätt.Checked = True Or Filter_IR.Checked = True Or Filter_IR_Foto.Checked = True Or _
               Filter_IV.Checked = True Or Filter_KR.Checked = True Or Filter_Repro.Checked = True Or _
               Filter_IRDAGP_Foto.Checked = True Or Filter_IRDAGP_Illust.Checked = True Or _
                              Filter_ST.Checked = True Or Filter_TV.Checked = True Or Filter_IR_Bildbyrå.Checked = True Then
                'IR-BILDBYRÅ    
                Dim FirstIn As Boolean = True
                Dim StringIn As String = "Betaltyp= ("
                If Filter_Följerätt.Checked = True Then StringIn &= IIf(FirstIn, "", ",") & "Följerätt" : FirstIn = False
                If Filter_IR.Checked = True Then StringIn &= IIf(FirstIn, "", ",") & "IR" : FirstIn = False
                If Filter_IR_Foto.Checked = True Then StringIn &= IIf(FirstIn, "", ",") & "IR_Foto" : FirstIn = False
                If Filter_IRDAGP_Foto.Checked = True Then StringIn &= IIf(FirstIn, "", ",") & "IRDAGP_Foto" : FirstIn = False
                If Filter_IRDAGP_Illust.Checked = True Then StringIn &= IIf(FirstIn, "", ",") & "IRDAGP_Illust." : FirstIn = False


                If Filter_IR_Bildbyrå.Checked = True Then StringIn &= IIf(FirstIn, "", ",") & "IR_Bildbyrå" : FirstIn = False
                If Filter_IV.Checked = True Then StringIn &= IIf(FirstIn, "", ",") & "IV" : FirstIn = False
                If Filter_KR.Checked = True Then StringIn &= IIf(FirstIn, "", ",") & "KR" : FirstIn = False
                If Filter_Repro.Checked = True Then StringIn &= IIf(FirstIn, "", ",") & "Repro" : FirstIn = False
                If Filter_ST.Checked = True Then StringIn &= IIf(FirstIn, "", ",") & "ST" : FirstIn = False
                If Filter_TV.Checked = True Then StringIn &= IIf(FirstIn, "", ",") & "TV" : FirstIn = False
                StringIn &= ") "
                lblFilter_Betalningstyp.Text = StringIn

            End If
        End If
        'Kontotyp                
        lblfilter_konto_typ.Text = ""
        If Filter_kontotyp_MI.Checked = True Then
            If Filter_konto_typ_AVI.Checked = True Or _
            Filter_konto_typ_Bankgiro.Checked = True Or _
            Filter_konto_typ_Bankkonto.Checked = True Or _
            Filter_konto_typ_Plusgiro.Checked = True Then
                Dim FirstIn As Boolean = True
                Dim StringIn As String = "Kontotyp= ("

                If Filter_konto_typ_AVI.Checked = True Then StringIn &= IIf(FirstIn, "", ",") & "AVI" : FirstIn = False
                If Filter_konto_typ_Bankgiro.Checked = True Then StringIn &= IIf(FirstIn, "", ",") & "Bankgiro" : FirstIn = False
                If Filter_konto_typ_Bankkonto.Checked = True Then StringIn &= IIf(FirstIn, "", ",") & "Bankkonto" : FirstIn = False
                If Filter_konto_typ_Plusgiro.Checked = True Then StringIn &= IIf(FirstIn, "", ",") & "Plusgiro" : FirstIn = False
                StringIn &= ") "
                lblfilter_konto_typ.Text = StringIn

            End If

        End If

        'Filter text för Belopp
        If Filter_Totalsumma_GT_MenuItem.Checked = True And IsNumeric(Filter_Totalsumma_GT.Text) Then lblFilter_Belopp.Text = " Belopp>= " & Filter_Totalsumma_GT.Text Else lblFilter_Belopp.Text = ""

        'Totalsummesammansräkningar
        Dim s As Stopwatch = New Stopwatch
        s.Reset() : s.Start()
        Console.WriteLine("innan summeringar :" & s.ElapsedMilliseconds.ToString)
        lblAntalRader.Text = UtbetalningTreeView.GetCheckedRows().ToString("N0") & " av " & UtbetalningTreeView.GetTotalRows.ToString("N0") & " fakturarader."
        lblAntal_mottagare.Text = UtbetalningTreeView.Nodes.Count.ToString("N0") & " st. mottagare."
        lblTotalAmount.Text = UtbetalningTreeView.Graph_Pad_Left(Math.Round(UtbetalningTreeView.GetCheckedTotalAmount()).ToString("N0") & " kr.", 20, Me.Font) & " (av " & Math.Round(UtbetalningTreeView.GetTotalAmount()).ToString("N0") & " kr.)"
        Console.WriteLine("Efter första summeringarna :" & s.ElapsedMilliseconds.ToString)
        lblTotalAVIAmount.Text = UtbetalningTreeView.Agg_conditional_text("konto_typ_kortnamn", "AVI")
        Console.WriteLine("Efter AVI summeringarna :" & s.ElapsedMilliseconds.ToString)

        lblTotalPlusgiroAmount.Text = UtbetalningTreeView.Agg_conditional_text("konto_typ_kortnamn", "PlusGiro")
        Console.WriteLine("Efter PlusGiro summeringarna :" & s.ElapsedMilliseconds.ToString)

        lblTotalBankGiroAmount.Text = UtbetalningTreeView.Agg_conditional_text("konto_typ_kortnamn", "BankGiro")
        Console.WriteLine("Efter BankGiro summeringarna :" & s.ElapsedMilliseconds.ToString)

        lblTotalUtlandAmount.Text = UtbetalningTreeView.Agg_conditional_text("konto_typ_kortnamn", "UTLAND")
        Console.WriteLine("Efter Utland summeringarna :" & s.ElapsedMilliseconds.ToString)
        lblTotalBankkontoAmount.Text = UtbetalningTreeView.Agg_conditional_text("konto_typ_kortnamn", "BANKKONTO")
        Console.WriteLine("Efter BANKKonto summeringarna :" & s.ElapsedMilliseconds.ToString)
    End Sub
    Function Get_where_string() As String
        Dim first As Boolean = True
        'filter
        Dim f As String = ""
        Dim GTdate As Date
        If Filter_Datum_GT_MenuItem.Checked = True And Date.TryParse(Filter_Datum_GT.Text, GTdate) Then
            f &= IIf(first, "", " and ") & "datediff(hh,[Registrerat datum] , '" & GTdate.ToShortDateString & " 00:01')<0" : first = False
        End If
        Dim LTDate As Date
        If Filter_Datum_LT_MenuItem.Checked = True And Date.TryParse(Filter_Datum_LT.Text, LTDate) Then
            f &= IIf(first, "", " and ") & "datediff(hh,[Registrerat datum] , '" & LTDate.ToShortDateString & " 23:59')>0" : first = False
        End If


        If Filter_Checkable_Only.Checked = True Then
            f &= IIf(first, "", " and ") & "kontoOK=1 and DödsBoEjKlart=0 " : first = False
        End If

        'Upphovsman filter
        If Filter_Upphovsman_MenuItem.Checked = True Then
            If Filter_Upphovsman_Efternamn_GT_MenuItem.Checked = True And Filter_Upphovsman_Efternamn_GT.SelectedIndex >= 0 Then
                f &= IIf(first, "", " and ") & " (Efternamn > '" & Filter_Upphovsman_Efternamn_GT.Text & "' or Efternamn like '" & Filter_Upphovsman_Efternamn_GT.Text & "%')" : first = False
            End If

            If Filter_Upphovsman_Efternamn_LT_MenuItem.Checked = True And Filter_Upphovsman_Efternamn_LT.SelectedIndex >= 0 Then
                f &= IIf(first, "", " and ") & " (Efternamn < '" & Filter_Upphovsman_Efternamn_LT.Text & "' or Efternamn like '" & Filter_Upphovsman_Efternamn_LT.Text & "%')" : first = False
            End If

            If Filter_Upphovsman_Efternamn_like_MenuItem.Checked = True Then
                If Filter_Upphovsman_Efternamn_like.Text.Length = 0 Then Filter_Upphovsman_Efternamn_like.Text = "*"
                f &= IIf(first, "", " and ")
                f &= "Efternamn like '"
                f &= Filter_Upphovsman_Efternamn_like.Text.Replace("*", "%")
                f &= "' "
                first = False
            End If

            If Filter_Upphovsman_Förnamn_like_MenuItem.Checked = True Then
                If Filter_Upphovsman_Förnamn_like.Text.Length = 0 Then Filter_Upphovsman_Förnamn_like.Text = "*"
                f &= IIf(first, "", " and ")
                f &= "Förnamn like '"
                f &= Filter_Upphovsman_Förnamn_like.Text.Replace("*", "%")
                f &= "' "
                first = False
            End If
        End If

        'Mottagare filter
        If Filter_Mottagare_MI.Checked = True Then


            'Namnfilter


            If Filter_Efternamn_GT_MenuItem.Checked = True And Filter_Efternamn_GT.SelectedIndex >= 0 Then
                f &= IIf(first, "", " and ") & " (MOttagare_Efternamn > '" & Filter_Efternamn_GT.Text & "' or mottagare_Efternamn = '" & Filter_Efternamn_GT.Text & "')" : first = False
            End If

            If Filter_Efternamn_LT_MenuItem.Checked = True And Filter_Efternamn_LT.SelectedIndex >= 0 Then
                f &= IIf(first, "", " and ") & " (Mottagare_Efternamn < '" & Filter_Efternamn_LT.Text & "' or Mottagare_Efternamn like '" & Filter_Efternamn_LT.Text & "%')" : first = False
            End If

            If Filter_Efternamn_like_MenuItem.Checked = True Then
                If Filter_Efternamn_like.Text.Length = 0 Then Filter_Efternamn_like.Text = "*"
                f &= IIf(first, "", " and ")
                f &= "Mottagare_Efternamn like '"
                f &= Filter_Efternamn_like.Text.Replace("*", "%")
                f &= "' "
                first = False
            End If

            If Filter_Förnamn_like_MenuItem.Checked = True Then
                If Filter_Förnamn_like.Text.Length = 0 Then Filter_Förnamn_like.Text = "*"
                f &= IIf(first, "", " and ")
                f &= "Mottagare_Förnamn like '"
                f &= Filter_Förnamn_like.Text.Replace("*", "%")
                f &= "' "
                first = False
            End If
            If Filter_mottagaretyp_MI.Checked = True Then
                If Filter_mottagare_typ_Ombud.Checked = True Or _
                    Filter_mottagare_typ_Rättighetshavare.Checked = True Or _
                   Filter_mottagare_typ_Systerorganisation.Checked = True Or _
                   Filter_mottagare_typ_Upphovsman.Checked = True Then
                    Dim FirstIn As Boolean = True
                    Dim StringIn As String = "("


                    If Filter_mottagare_typ_Ombud.Checked = True Then StringIn &= IIf(FirstIn, "", " OR ") & "rtrim(mottagare_typ) like 'O%'" : FirstIn = False
                    If Filter_mottagare_typ_Rättighetshavare.Checked = True Then StringIn &= IIf(FirstIn, "", " or ") & "rtrim(mottagare_typ) like 'R%'" : FirstIn = False
                    If Filter_mottagare_typ_Systerorganisation.Checked = True Then StringIn &= IIf(FirstIn, "", " or ") & "rtrim(mottagare_typ) like 'S%'" : FirstIn = False
                    If Filter_mottagare_typ_Upphovsman.Checked = True Then StringIn &= IIf(FirstIn, "", " or ") & "rtrim(mottagare_typ) like 'U%'" : FirstIn = False
                    StringIn &= ") "

                    f &= IIf(first, "", " and ") & StringIn
                    first = False
                End If
            End If


        End If
        'KOmmentar sökningsfilter
        If filter_kommentar_like_MenuItem.Checked = True Then
            If filter_kommentar_like.Text.Length = 0 Then filter_kommentar_like.Text = "*"
            f &= IIf(first, "", " and ")
            f &= "betalnings_underlag_kommentar like '"
            f &= filter_kommentar_like.Text.Replace("*", "%")
            f &= "' "
            first = False
        End If

        'Utbetalningstyp fileter
        If Filter_Utbetalningstyp_MI.Checked = True Then
            If Filter_Följerätt.Checked = True Or Filter_IR.Checked = True Or Filter_IR_Foto.Checked = True Or _
               Filter_IV.Checked = True Or Filter_KR.Checked = True Or Filter_Repro.Checked = True Or _
               Filter_IRDAGP_Foto.Checked = True Or Filter_IRDAGP_Illust.Checked = True Or _
               Filter_ST.Checked = True Or Filter_TV.Checked = True Or Filter_IR_Bildbyrå.Checked = True Then
                'IR-BILDBYRÅ    
                Dim FirstIn As Boolean = True
                Dim StringIn As String = " ("
                If Filter_Följerätt.Checked = True Then StringIn &= IIf(FirstIn, "", " OR ") & " rtrim(Betalning_typ) like 'Följerätt%'" : FirstIn = False
                If Filter_IR.Checked = True Then StringIn &= IIf(FirstIn, "", " OR ") & " rtrim(Betalning_typ) like 'IR'" : FirstIn = False
                If Filter_IR_Foto.Checked = True Then StringIn &= IIf(FirstIn, "", " OR ") & " rtrim(Betalning_typ) like 'IR-F%'" : FirstIn = False

                If Filter_IRDAGP_Foto.Checked = True Then StringIn &= IIf(FirstIn, "", " OR ") & " rtrim(Betalning_typ) = 'IRDAGP-FOTO'" : FirstIn = False
                If Filter_IRDAGP_Illust.Checked = True Then StringIn &= IIf(FirstIn, "", " OR ") & " rtrim(Betalning_typ) = 'IRDAGP-ILLUST.'" : FirstIn = False

                If Filter_IR_Bildbyrå.Checked = True Then StringIn &= IIf(FirstIn, "", " OR ") & " rtrim(Betalning_typ) like 'IR_B%'" : FirstIn = False
                If Filter_IV.Checked = True Then StringIn &= IIf(FirstIn, "", " OR ") & " rtrim(Betalning_typ) like 'IV%'" : FirstIn = False
                If Filter_KR.Checked = True Then StringIn &= IIf(FirstIn, "", " OR ") & " rtrim(Betalning_typ) like 'KR%'" : FirstIn = False
                If Filter_Repro.Checked = True Then StringIn &= IIf(FirstIn, "", " OR ") & " rtrim(Betalning_typ) like 'Repro%'" : FirstIn = False
                If Filter_ST.Checked = True Then StringIn &= IIf(FirstIn, "", " OR ") & " rtrim(Betalning_typ) like 'ST%'" : FirstIn = False
                If Filter_TV.Checked = True Then StringIn &= IIf(FirstIn, "", " OR ") & " rtrim(Betalning_typ) like 'TV%'" : FirstIn = False
                StringIn &= ") "

                f &= IIf(first, "", " and ") & StringIn
                first = False

            End If

        End If


        If Filter_kontotyp_MI.Checked = True Then


            If Filter_konto_typ_AVI.Checked = True Or _
            Filter_konto_typ_Bankgiro.Checked = True Or _
            Filter_konto_typ_Bankkonto.Checked = True Or _
            Filter_konto_typ_Plusgiro.Checked = True Then
                Dim FirstIn As Boolean = True
                Dim StringIn As String = " ("


                If Filter_konto_typ_AVI.Checked = True Then
                    StringIn &= IIf(FirstIn, "", " OR ") & "RTrim(Konto_typ_kortnamn) like 'A%'"
                    FirstIn = False
                End If

                If Filter_konto_typ_Bankgiro.Checked = True Then
                    StringIn &= IIf(FirstIn, "", " OR ") & "RTrim(Konto_typ_kortnamn) like 'Bankg%'"
                    FirstIn = False
                End If

                If Filter_konto_typ_Bankkonto.Checked = True Then
                    StringIn &= IIf(FirstIn, "", " OR ") & "RTrim(Konto_typ_kortnamn) like 'Bankk%'"
                    FirstIn = False
                End If

                If Filter_konto_typ_Plusgiro.Checked = True Then
                    StringIn &= IIf(FirstIn, "", " OR ") & "RTrim(Konto_typ_kortnamn) like 'P%'"
                    FirstIn = False
                End If

                StringIn &= ") "

                f &= IIf(first, "", " and ") & StringIn
                first = False
            End If

        End If


        'If Filter_dold.Checked = True Then
        'f &= IIf(first, "", " and ") & "isnull(Dold,0)<>0" : first = False
        'Else
        'f &= IIf(first, "", " and ") & "isnull(Dold,0)=0" : first = False
        'End If


        Return f
    End Function
    Function Get_Filter_TotalSumma() As Decimal
        If Filter_Totalsumma_GT_MenuItem.Checked = True And IsNumeric(Filter_Totalsumma_GT.Text) Then
            Return Filter_Totalsumma_GT.Text
        Else
            Return 0.0
        End If

    End Function







    'Fyller UtbetalningTreeView från databladet. (3 nivåer Root=Upphovsman,Child=BetalningsTyp,Level2=BetalningsID

    Private Sub Sort_Efternamn_Upp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Sort_Namn_Upp.Click
        Sort_Namn_Ned.Checked = False
        Sort_Totalsumma_Ned.Checked = False
        Sort_Totalsumma_Upp.Checked = False
        Status_Update()
        Sort_By_Namn()
    End Sub
    Private Sub Sort_Efternamn_Ned_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Sort_Namn_Ned.Click
        Sort_Namn_Upp.Checked = False
        Sort_Totalsumma_Ned.Checked = False
        Sort_Totalsumma_Upp.Checked = False
        Status_Update()
        Sort_By_Namn()
    End Sub
    Private Sub Sort_Totalsumma_Upp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Sort_Totalsumma_Upp.Click
        Sort_Namn_Ned.Checked = False
        Sort_Namn_Upp.Checked = False
        Sort_Totalsumma_Ned.Checked = False
        Status_Update()
        Sort_By_Belopp()
    End Sub
    Private Sub Sort_Totalsumma_Ned_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Sort_Totalsumma_Ned.Click
        Sort_Namn_Ned.Checked = False
        Sort_Namn_Upp.Checked = False
        Sort_Totalsumma_Upp.Checked = False
        Status_Update()
        Sort_By_Belopp()
    End Sub




    Private Sub UtbetalningTreeView_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles UtbetalningTreeView.AfterCheck
        'Hantera vilka andra noder som eventuellt ska kryssas i beroende på att denna blev ikryssad
        'För att undvika oändlig rekursion när man ändrar fler checked-värden ska man göra denna koll..
        If Not e.Action = TreeViewAction.Unknown Then
            UtbetalningTreeView.BeginUpdate()
            If CType(e.Node.Tag, DataRow)("checkable") = 0 Then
                e.Node.Checked = False
            End If


            UtbetalningTreeView.CheckTreeNode_Children(e.Node)
            UtbetalningTreeView.EndUpdate()
            Status_Update()

        End If

    End Sub
    REM Filter hantering

    Private Sub Filter_Upphovsman_MenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Upphovsman_MenuItem.Click
        bUtför.ForeColor = Color.Black
        Status_Update()
    End Sub
    Private Sub Filter_Upphovsman_Efternamn_GT_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Upphovsman_Efternamn_GT.SelectedIndexChanged
        Filter_Upphovsman_Efternamn_GT_MenuItem.Text = "Efternamn >= " & Filter_Upphovsman_Efternamn_GT.Text
        Status_Update()
    End Sub
    Private Sub Filter_Upphovsman_Efternamn_GT_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Upphovsman_Efternamn_GT.LostFocus
        Filter_Upphovsman_Efternamn_GT_MenuItem.Text = "Efternamn >= " & Filter_Upphovsman_Efternamn_GT.Text
        Filter_Upphovsman_Efternamn_GT_MenuItem.Checked = True
        Filter_Upphovsman_MenuItem.Checked = True
        bUtför.ForeColor = Color.Black
        Status_Update()
    End Sub
    Private Sub Filter_Upphovsman_Efternamn_GT_MenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Upphovsman_Efternamn_GT_MenuItem.Click
        Filter_Upphovsman_MenuItem.Checked = True

        bUtför.ForeColor = Color.Black
        Status_Update()

    End Sub

    Private Sub Filter_Upphovsman_Efternamn_LT_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Upphovsman_Efternamn_LT.SelectedIndexChanged
        Filter_Upphovsman_Efternamn_LT_MenuItem.Text = "Efternamn <= " & Filter_Upphovsman_Efternamn_LT.Text
    End Sub
    Private Sub Filter_Upphovsman_Efternamn_LT_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Upphovsman_Efternamn_LT.LostFocus
        Filter_Upphovsman_Efternamn_LT_MenuItem.Text = "Efternamn <= " & Filter_Upphovsman_Efternamn_LT.Text
        Filter_Upphovsman_Efternamn_LT_MenuItem.Checked = True
        Filter_Upphovsman_MenuItem.Checked = True
        bUtför.ForeColor = Color.Black
        Status_Update()


    End Sub
    Private Sub Filter_Upphovsman_Efternamn_LT_MenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Upphovsman_Efternamn_LT_MenuItem.Click
        Filter_Upphovsman_MenuItem.Checked = True
        bUtför.ForeColor = Color.Black 'bUtför.Enabled = True
        Status_Update()


    End Sub

    Private Sub Filter_Upphovsman_Efternamn_like_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Upphovsman_Efternamn_like.TextChanged
        Filter_Upphovsman_Efternamn_like_MenuItem.Text = "Efternamn = " & Filter_Upphovsman_Efternamn_like.Text

    End Sub
    Private Sub Filter_Upphovsman_Efternamn_like_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Upphovsman_Efternamn_like.LostFocus
        Filter_Upphovsman_Efternamn_like_MenuItem.Text = "Efternamn = " & Filter_Upphovsman_Efternamn_like.Text

        Filter_Upphovsman_Efternamn_like_MenuItem.Checked = True
        Filter_Upphovsman_MenuItem.Checked = True
        bUtför.ForeColor = Color.Black 'bUtför.Enabled = True
        Status_Update()
        
    End Sub
    Private Sub Filter_Upphovsman_Efternamn_like_MenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Upphovsman_Efternamn_like_MenuItem.Click
        Status_Update()
        Filter_Upphovsman_MenuItem.Checked = True
        bUtför.ForeColor = Color.Black 'bUtför.Enabled = True
        Status_Update()


    End Sub

    Private Sub Filter_Upphovsman_Förnamn_like_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Upphovsman_Förnamn_like_MenuItem.TextChanged
        Filter_Upphovsman_Förnamn_like_MenuItem.Text = "Förnamn     = " & Filter_Upphovsman_Förnamn_like.Text
    End Sub
    Private Sub Filter_Upphovsman_Förnamn_like_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Upphovsman_Efternamn_like.LostFocus
        Filter_Upphovsman_Förnamn_like_MenuItem.Text = "Förnamn     = " & Filter_Upphovsman_Förnamn_like.Text

        Filter_Upphovsman_Förnamn_like_MenuItem.Checked = True
        Filter_Upphovsman_MenuItem.Checked = True
        bUtför.ForeColor = Color.Black 'bUtför.Enabled = True
        Status_Update()


    End Sub
    Private Sub Filter_Upphovsman_Förnamn_like_MenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Upphovsman_Förnamn_like_MenuItem.Click
        Filter_Upphovsman_MenuItem.Checked = True

        bUtför.ForeColor = Color.Black 'bUtför.Enabled = True
        Status_Update()


    End Sub

    Private Sub Filter_Efternamn_GT_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Efternamn_GT.SelectedIndexChanged
        Filter_Efternamn_GT_MenuItem.Text = "Efternamn >= " & Filter_Efternamn_GT.Text
        Filter_Mottagare_MI.Checked = True
        Status_Update()

    End Sub
    Private Sub Filter_Efternamn_GT_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Efternamn_GT.LostFocus
        Filter_Efternamn_GT_MenuItem.Text = "Efternamn >= " & Filter_Efternamn_GT.Text
        Filter_Mottagare_MI.Checked = True
        Filter_Efternamn_GT_MenuItem.Checked = True
        bUtför.ForeColor = Color.Black 'bUtför.Enabled = True 
        Status_Update() 'refill_utbetalning_treeview()
        
    End Sub
    Private Sub Filter_Efternamn_GT_MenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Efternamn_GT_MenuItem.Click
        Filter_Mottagare_MI.Checked = True
        bUtför.ForeColor = Color.Black 'bUtför.Enabled = True
        Status_Update() 'refill_utbetalning_treeview()

    End Sub

    Private Sub Filter_Efternamn_LT_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Efternamn_LT.SelectedIndexChanged
        Filter_Efternamn_LT_MenuItem.Text = "Efternamn <= " & Filter_Efternamn_LT.Text
    End Sub
    Private Sub Filter_Efternamn_LT_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Efternamn_LT.LostFocus
        Filter_Efternamn_LT_MenuItem.Text = "Efternamn <= " & Filter_Efternamn_LT.Text
        Filter_Mottagare_MI.Checked = True
        Filter_Efternamn_LT_MenuItem.Checked = True
        bUtför.ForeColor = Color.Black 'bUtför.Enabled = True 
        Status_Update() 'refill_utbetalning_treeview()
        
    End Sub
    Private Sub Filter_Mottagare_MI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Mottagare_MI.Click
        bUtför.ForeColor = Color.Black 'bUtför.Enabled = True
        Status_Update()
    End Sub

    Private Sub Filter_Efternamn_LT_MenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Efternamn_LT_MenuItem.Click
        Filter_Mottagare_MI.Checked = True
        bUtför.ForeColor = Color.Black 'bUtför.Enabled = True
        Status_Update() 'refill_utbetalning_treeview()

    End Sub

    Private Sub Filter_Efternamn_like_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Efternamn_like.TextChanged
        Filter_Efternamn_like_MenuItem.Text = "Efternamn = " & Filter_Efternamn_like.Text

    End Sub
    Private Sub Filter_Efternamn_like_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Efternamn_like.LostFocus
        Filter_Efternamn_like_MenuItem.Text = "Efternamn = " & Filter_Efternamn_like.Text
        Filter_Mottagare_MI.Checked = True
        Filter_Efternamn_like_MenuItem.Checked = True
            bUtför.ForeColor = Color.Black 'bUtför.Enabled = True
            Status_Update() 'refill_utbetalning_treeview()
        
    End Sub
    Private Sub Filter_Efternamn_like_MenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Efternamn_like_MenuItem.Click
        Filter_Mottagare_MI.Checked = True

        bUtför.ForeColor = Color.Black 'bUtför.Enabled = True
        Status_Update() 'refill_utbetalning_treeview()

    End Sub

    Private Sub Filter_Förnamn_like_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Förnamn_like.TextChanged
        Filter_Förnamn_like_MenuItem.Text = "Förnamn     = " & Filter_Förnamn_like.Text
    End Sub
    Private Sub Filter_Förnamn_like_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Efternamn_like.LostFocus
        Filter_Förnamn_like_MenuItem.Text = "Förnamn     = " & Filter_Förnamn_like.Text
        Filter_Mottagare_MI.Checked = True

        Filter_Förnamn_like_MenuItem.Checked = True
        bUtför.ForeColor = Color.Black : Status_Update() 'bUtför.Enabled = True 'refill_utbetalning_treeview()


    End Sub
    Private Sub Filter_Förnamn_like_MenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Förnamn_like_MenuItem.Click
        Filter_Mottagare_MI.Checked = True
        bUtför.ForeColor = Color.Black : Status_Update() 'bUtför.Enabled = True 'refill_utbetalning_treeview()

    End Sub
    Private Sub Filter_kommentar_like_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles filter_kommentar_like.TextChanged
        filter_kommentar_like_MenuItem.Text = "Kommentar     = " & filter_kommentar_like.Text()
    End Sub
    Private Sub Filter_kommentar_like_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles filter_kommentar_like.LostFocus
        filter_kommentar_like_MenuItem.Text = "Kommentar     = " & filter_kommentar_like.Text()

        filter_kommentar_like_MenuItem.Checked = True
        bUtför.ForeColor = Color.Black : Status_Update() 'bUtför.Enabled = True 'refill_utbetalning_treeview()


    End Sub
    Private Sub Filter_kommentar_like_MenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles filter_kommentar_like_MenuItem.Click
        bUtför.ForeColor = Color.Black : Status_Update() 'bUtför.Enabled = True 'refill_utbetalning_treeview()

    End Sub
    Private Sub Filter_Checkable_Only_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Checkable_Only.Click
        bUtför.ForeColor = Color.Black
        Status_Update()
    End Sub
    Private Sub AllaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllaToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        UtbetalningTreeView.CheckAll(True)
        Status_Update()
        Cursor = Cursors.Default
    End Sub
    Private Sub AvmarkeraAllaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AvmarkeraAllaToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        UtbetalningTreeView.CheckAll(False)
        Status_Update()
        Cursor = Cursors.Default
    End Sub
    Private Sub AktuellRadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AktuellRadToolStripMenuItem.Click
        If CType(UtbetalningTreeView.SelectedNode.Tag, DataRow)("checkable") = 1 Then
            UtbetalningTreeView.SelectedNode.Checked = Not UtbetalningTreeView.SelectedNode.Checked
        Else
            UtbetalningTreeView.SelectedNode.Checked = False
        End If

        UtbetalningTreeView.CheckTreeNode_Children(UtbetalningTreeView.SelectedNode)
        Status_Update()
        '       UtbetalningTreeView._Agg_TreeNodeText(UtbetalningTreeView.SelectedNode)

        '        UtbetalningTreeView_Checked_TotalAmount_WorkSUM() ' Bakgrundssummering av totalen
    End Sub
    Private Sub AvslutaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AvslutaToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Filter_Totalsumma_GT_MenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Totalsumma_GT_MenuItem.Click
        bUtför.ForeColor = Color.Black : Status_Update() 'bUtför.Enabled = True 'refill_utbetalning_treeview()
    End Sub
    Private Sub Filter_Totalsumma_GT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Filter_Totalsumma_GT_MenuItem.Text = "Totalsumma > " & IIf(IsNumeric(Filter_Totalsumma_GT.Text), Filter_Totalsumma_GT.Text, 0) & Space(6 - Filter_Totalsumma_GT.Text.Length)

    End Sub
    Private Sub Filter_Totalsumma_GT_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Filter_Totalsumma_GT_MenuItem.Text = "Totalsumma > " & IIf(IsNumeric(Filter_Totalsumma_GT.Text), Filter_Totalsumma_GT.Text, 0) & Space(6 - Filter_Totalsumma_GT.Text.Length)
        Filter_Totalsumma_GT_MenuItem.Checked = True
        bUtför.ForeColor = Color.Black : Status_Update() 'bUtför.Enabled = True 'refill_utbetalning_treeview()

    End Sub

    Private Sub Filter_Datum_LT_MenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Datum_LT_MenuItem.Click
        bUtför.ForeColor = Color.Black : Status_Update() 'bUtför.Enabled = True 'refill_utbetalning_treeview()
    End Sub
    Private Sub Filter_Datum_LT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Datum_LT.TextChanged
        Filter_Datum_LT_MenuItem.Text = "Datum < " & If(IsDate(Filter_Datum_LT.ToString), Filter_Datum_LT.ToString, "######") & Space(14 - Filter_Datum_LT.Text.Length)
    End Sub
    Private Sub Filter_Datum_LT_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Datum_LT.LostFocus
        Filter_Datum_LT_MenuItem.Text = "Datum < " & If(IsDate(Filter_Datum_LT.ToString), Filter_Datum_LT.ToString, "######") & Space(14 - Filter_Datum_LT.Text.Length)
        Filter_Datum_LT_MenuItem.Checked = True
        bUtför.ForeColor = Color.Black : Status_Update() 'bUtför.Enabled = True 'refill_utbetalning_treeview()

    End Sub

    Private Sub Filter_Datum_GT_MenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Datum_GT_MenuItem.Click
        bUtför.ForeColor = Color.Black : Status_Update() 'bUtför.Enabled = True 'refill_utbetalning_treeview()
    End Sub
    Private Sub Filter_Datum_GT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Datum_GT.TextChanged
        Filter_Datum_GT_MenuItem.Text = "Datum > " & If(IsDate(Filter_Datum_GT.ToString), Filter_Datum_GT.ToString, "######") & Space(14 - Filter_Datum_GT.Text.Length)
    End Sub
    Private Sub Filter_Datum_GT_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Datum_GT.LostFocus
        Filter_Datum_GT_MenuItem.Text = "Datum > " & If(IsDate(Filter_Datum_GT.ToString), Filter_Datum_GT.ToString, "######") & Space(14 - Filter_Datum_GT.Text.Length)
        Filter_Datum_GT_MenuItem.Checked = True
        bUtför.ForeColor = Color.Black : Status_Update() 'bUtför.Enabled = True 'refill_utbetalning_treeview()

    End Sub

    Private Sub Sort()
        Cursor = Cursors.WaitCursor
        If Sort_Namn_Ned.Checked = True Or Sort_Namn_Upp.Checked = True Then Sort_By_Namn() Else Sort_By_Belopp()
        Cursor = Cursors.Default
    End Sub
    Private Sub Sort_By_Namn()
        If Sort_Namn_Ned.Checked = True Or Sort_Namn_Upp.Checked = True Then
            If Sort_Namn_Ned.Checked = True Then
                UtbetalningTreeView.Sort_RootNodes(B2.GroupTreeView.SortColumn.Name, GroupTreeView.AscDesc.Desc)
            Else
                UtbetalningTreeView.Sort_RootNodes(B2.GroupTreeView.SortColumn.Name, GroupTreeView.AscDesc.Asc)


            End If
        End If

    End Sub
    Private Sub Sort_By_Belopp()
        If Sort_Totalsumma_Ned.Checked = True Or Sort_Totalsumma_Upp.Checked = True Then
            If Sort_Totalsumma_Ned.Checked = True Then
                UtbetalningTreeView.Sort_RootNodes(B2.GroupTreeView.SortColumn.Amount, GroupTreeView.AscDesc.Desc)
            Else
                UtbetalningTreeView.Sort_RootNodes(B2.GroupTreeView.SortColumn.Amount, GroupTreeView.AscDesc.Asc)
            End If
        End If
    End Sub



    Private Sub Filter_IV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_IV.Click
        Filter_Utbetalningstyp_MI.Checked = True
        bUtför.ForeColor = Color.Black : Status_Update() 'bUtför.Enabled = True 'refill_utbetalning_treeview()


    End Sub
    Private Sub Filter_Följerätt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Följerätt.Click
        Filter_Utbetalningstyp_MI.Checked = True
        bUtför.ForeColor = Color.Black : Status_Update() 'bUtför.Enabled = True 'refill_utbetalning_treeview()

    End Sub
    Private Sub Filter_IR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_IR.Click
        Filter_Utbetalningstyp_MI.Checked = True
        bUtför.ForeColor = Color.Black : Status_Update() 'bUtför.Enabled = True 'refill_utbetalning_treeview()

    End Sub
    Private Sub Filter_IR_Bildbyrå_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_IR_Bildbyrå.Click
        Filter_Utbetalningstyp_MI.Checked = True
        bUtför.ForeColor = Color.Black : Status_Update() 'bUtför.Enabled = True 'refill_utbetalning_treeview()

    End Sub
    Private Sub Filter_IR_Foto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_IR_Foto.Click
        Filter_Utbetalningstyp_MI.Checked = True
        bUtför.ForeColor = Color.Black : Status_Update() 'bUtför.Enabled = True 'refill_utbetalning_treeview()

    End Sub

    Private Sub Filter_IRDAGP_Foto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_IRDAGP_Foto.Click
        Filter_Utbetalningstyp_MI.Checked = True
        bUtför.ForeColor = Color.Black : Status_Update() 'bUtför.Enabled = True 'refill_utbetalning_treeview()

    End Sub

    Private Sub Filter_IRDAGP_Illust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_IRDAGP_Illust.Click
        Filter_Utbetalningstyp_MI.Checked = True
        bUtför.ForeColor = Color.Black : Status_Update() 'bUtför.Enabled = True 'refill_utbetalning_treeview()

    End Sub
    Private Sub Filter_KR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_KR.Click
        Filter_Utbetalningstyp_MI.Checked = True
        bUtför.ForeColor = Color.Black : Status_Update() 'bUtför.Enabled = True 'refill_utbetalning_treeview()

    End Sub
    Private Sub Filter_Repro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Repro.Click
        Filter_Utbetalningstyp_MI.Checked = True
        bUtför.ForeColor = Color.Black : Status_Update() 'bUtför.Enabled = True 'refill_utbetalning_treeview()

    End Sub
    Private Sub Filter_ST_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_ST.Click
        Filter_Utbetalningstyp_MI.Checked = True
        bUtför.ForeColor = Color.Black : Status_Update() 'bUtför.Enabled = True 'refill_utbetalning_treeview()


    End Sub
    Private Sub Filter_TV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_TV.Click
        Filter_Utbetalningstyp_MI.Checked = True
        bUtför.ForeColor = Color.Black : Status_Update() 'bUtför.Enabled = True 'refill_utbetalning_treeview()


    End Sub
    Private Sub Filter_kontotyp_MI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_kontotyp_MI.Click
        bUtför.ForeColor = Color.Black
        Status_Update()
    End Sub
    Private Sub Filter_konto_typ_AVI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_konto_typ_AVI.Click
        Filter_kontotyp_MI.Checked = True
        bUtför.ForeColor = Color.Black : Status_Update() 'bUtför.Enabled = True 'refill_utbetalning_treeview()


    End Sub
    Private Sub Filter_konto_typ_Bankkonto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_konto_typ_Bankkonto.Click
        Filter_kontotyp_MI.Checked = True
        bUtför.ForeColor = Color.Black : Status_Update() 'bUtför.Enabled = True 'refill_utbetalning_treeview()

    End Sub
    Private Sub Filter_konto_typ_Bankgiro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_konto_typ_Bankgiro.Click
        Filter_kontotyp_MI.Checked = True
        bUtför.ForeColor = Color.Black : Status_Update() 'bUtför.Enabled = True 'refill_utbetalning_treeview()

    End Sub
    Private Sub Filter_konto_typ_Plusgiro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_konto_typ_Plusgiro.Click
        Filter_kontotyp_MI.Checked = True
        bUtför.ForeColor = Color.Black : Status_Update() 'bUtför.Enabled = True 'refill_utbetalning_treeview()

    End Sub
    Private Sub Filter_mottagaretyp_MI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_mottagaretyp_MI.Click
        Filter_Mottagare_MI.Checked = True
        bUtför.ForeColor = Color.Black : Status_Update()

    End Sub

    Private Sub Filter_mottagare_typ_Ombud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Filter_Mottagare_MI.Checked = True
        bUtför.ForeColor = Color.Black : Status_Update()

    End Sub
    Private Sub Filter_mottagare_typ_Rättighetshavare_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Filter_Mottagare_MI.Checked = True
        bUtför.ForeColor = Color.Black : Status_Update()

    End Sub
    Private Sub Filter_mottagare_typ_Systerorganisation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Filter_Mottagare_MI.Checked = True
        bUtför.ForeColor = Color.Black : Status_Update()

    End Sub
    Private Sub Filter_mottagare_typ_Upphovsman_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Filter_Mottagare_MI.Checked = True
        Filter_mottagaretyp_MI.Checked = True
        bUtför.ForeColor = Color.Black : Status_Update() 'bUtför.Enabled = True 'refill_utbetalning_treeview()


    End Sub

    Private Sub Filter_Utbetalningstyp_MI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Utbetalningstyp_MI.Click
        bUtför.ForeColor = Color.Black : Status_Update() 
    End Sub

    Private Sub Filter_dold_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_dold.Click
        If Filter_dold.Checked = True Then
            DöljMI.Text = "Visa"
        Else
            DöljMI.Text = "Dölj"
        End If
        bUtför.ForeColor = Color.Black : Status_Update() 'bUtför.Enabled = True 'refill_utbetalning_treeview()

    End Sub
    Private Sub DöljMI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DöljMI.Click
        Dim sqlConn As SqlConnection = New SqlConnection(My.Settings.DBconnectionString)
        'Try
        Status_Update()

        sqlConn.Open()
        pbProgress.Maximum = UtbetalningTreeView.GetCheckedRows
        pbProgress.Visible = True
        Dim rowCount As Integer
        For Each node In UtbetalningTreeView.Nodes
            rowCount += DöljVisa_TreeNode(node, sqlConn)
            pbProgress.Value = rowCount
        Next node
        sqlConn.Close()
        pbProgress.Visible = False
        refill_utbetalning_treeview()
        Status_Update()
    End Sub
    Private Function DöljVisa_TreeNode(ByRef tnode As TreeNode, ByRef SQLConn As SqlConnection) As Integer

        Dim Counter As Integer = 0
        If tnode.Nodes.Count = 0 Then
            If tnode.Checked = True Then
                'TODO sqldo set marked
                Dim selectCommand As SqlCommand = New SqlCommand()
                Dim parmID As SqlParameter
                selectCommand.CommandType = CommandType.StoredProcedure
                If Filter_dold.Checked = True Then
                    selectCommand.CommandText = "[sp_betalning_godkänd_visa]"
                Else
                    selectCommand.CommandText = "[sp_betalning_godkänd_dölj]"
                End If

                parmID = selectCommand.Parameters.Add("betalning_godkänd_id", SqlDbType.Int)
                parmID.Value = (CType(tnode.Tag, DataRow)("ID"))
                System.Console.WriteLine(selectCommand.CommandText.ToString & " " & parmID.Value)
                selectCommand.Connection = SQLConn
                Dim reader As SqlDataReader = selectCommand.ExecuteReader

                reader.Close()

                'TODO error handling kring misslyckat eller om skall fortsätta
                Return 1

            Else
                Return 0
            End If
        Else


            For Each node In tnode.Nodes
                Counter += DöljVisa_TreeNode(node, SQLConn)
            Next node
            Return Counter
        End If
    End Function



    Private Sub Skapa_ny_betalning_transaktion(ByVal Transaktion_typ As String)
        If Transaktion_typ = "PLUSGIRO" Or Transaktion_typ = "BANKGIRO" Or Transaktion_typ = "UTLAND" Then


            Dim sqlConn As SqlConnection = New SqlConnection(My.Settings.DBconnectionString)
            'Try
            sqlConn.Open()
           
            Dim selectCommand As SqlCommand = New SqlCommand()
            Dim parmID As SqlParameter
            selectCommand.CommandType = CommandType.StoredProcedure
            selectCommand.CommandText = "[sp_betalning_transaktion_skapa]"

            parmID = selectCommand.Parameters.Add("transaktions_typ", SqlDbType.Char)
            parmID.Value = Transaktion_typ '"plusgiro"

            System.Console.WriteLine(selectCommand.CommandText.ToString & " " & parmID.Value)
            selectCommand.Connection = sqlConn
            Dim reader As SqlDataReader = selectCommand.ExecuteReader

            If reader.Read() Then
                If reader.Item("identity") > 0 Then
                    Dim session_id As Int16 = reader.Item("identity")
                    reader.Close()

                    Betalning_transaktion_TreeView_Add(session_id, Transaktion_typ)
                    bUtför.ForeColor = Color.Black : Status_Update() 'bUtför.Enabled = True 'refill_utbetalning_treeview()

                End If
            End If
        End If
    End Sub
    Private Sub Betalning_transaktion_TreeView_Add(ByVal betalning_transaktion_id, ByVal Transaktion_typ)
        Dim sqlConn As SqlConnection = New SqlConnection(My.Settings.DBconnectionString)
        sqlConn.Open()
        Dim AccString As StringBuilder = New StringBuilder
        AccString.Length = 0

        pbProgress.Maximum = UtbetalningTreeView.GetCheckedRows
        pbProgress.Visible = True
        Dim rowCount As Integer
        Dim row As DataRow
        Dim i As Int32 = 0
        Dim selectCommand As SqlCommand = New SqlCommand()
        Dim reader As SqlDataReader


        For Each node In UtbetalningTreeView.Nodes
            row = CType(node.Tag, DataRow)
            pbProgress.Value = rowCount
            rowCount += Betalning_transaktion_TreeNode_Add(betalning_transaktion_id, Transaktion_typ, node, AccString)
        Next node
        Dim rowString As String
        Dim AccStringOut As StringBuilder = New StringBuilder
        AccStringOut.Length = 0
        AccStringOut.AppendLine("begin transaction")
        AccStringOut.AppendLine("exec sp_betalning_transaktion_summera " & betalning_transaktion_id)
        For Each rowString In AccString.ToString.Split(vbNewLine)
            AccStringOut.AppendLine(rowString)
            i = i + 1
            'System.Console.WriteLine(rowString)
            If i Mod 20 = 0 Then
                'För att bryta upp transaktionen i smådelar

                AccStringOut.AppendLine("commit transaction")
                selectCommand.CommandType = CommandType.Text
                selectCommand.CommandText = AccStringOut.ToString
                'System.Console.WriteLine(selectCommand.CommandText.ToString)
                System.Console.WriteLine("i=" & i)

                selectCommand.Connection = sqlConn
                reader = selectCommand.ExecuteReader
                reader.Read()
                reader.Close()
                pbProgress.Value = rowCount
                pbProgress.Refresh()
                AccStringOut.Length = 0
                AccStringOut.AppendLine("begin transaction")

            End If

        Next rowString

        AccStringOut.AppendLine("exec sp_betalning_transaktion_summera " & betalning_transaktion_id)
        AccStringOut.AppendLine("commit transaction")
        'Spara transaktionen
        selectCommand.CommandType = CommandType.Text
        selectCommand.CommandText = AccStringOut.ToString

        'System.Console.WriteLine(selectCommand.CommandText.ToString)
        System.Console.WriteLine("Final i " & i)
        selectCommand.Connection = sqlConn
        reader = selectCommand.ExecuteReader
        reader.Read()
        reader.Close()
        sqlConn.Close()
        pbProgress.Visible = False

    End Sub
    Private Function is_Transaktion_OK(ByRef Mottagar_typ As String, ByRef Transaktion_typ As String, ByRef Konto_typ As String) As Boolean
        If Mottagar_typ.Trim.ToUpper = "S" Then 'SYSTERORGANISATION
            If Transaktion_typ.ToUpper.Trim = "UTLAND" Then
                Return True
            Else
                Return False
            End If
        ElseIf Transaktion_typ.ToUpper.Trim = "PLUSGIRO" Then
            If Konto_typ.Trim.ToUpper = "PLUSGIRO" Or Konto_typ.ToUpper.Trim = "AVI" Then
                Return True
            Else
                Return False
            End If
        ElseIf Transaktion_typ.ToUpper.Trim = "BANKGIRO" Then

            If Konto_typ.Trim.ToUpper = "BANKGIRO" Or Konto_typ.ToUpper.Trim = "BANKKONTO" Or Konto_typ.ToUpper.Trim = "AVI" Then
                Return True
            Else
                Return False
            End If
        End If




    End Function
    Private Function Betalning_transaktion_TreeNode_Add(ByRef betalning_transaktion_id As Int16, ByRef Transaktion_typ As String, ByRef tnode As TreeNode, ByRef AccStr As StringBuilder) As Integer

        Dim Counter As Integer = 0
        If tnode.Nodes.Count = 0 Then
            If tnode.Checked = True And is_Transaktion_OK(CType(tnode.Tag, DataRow)("bg_mottagar_typ").ToString, Transaktion_typ, CType(tnode.Tag, DataRow)("Konto_typ_kortnamn").ToString) = True Then
                'TODO sqldo set marked
                AccStr.Append("exec sp_betalning_transaktion_add")
                AccStr.Append(" @betalning_godkänd_id=" & (CType(tnode.Tag, DataRow)("ID")) & ", ")
                AccStr.AppendLine("@betalning_transaktion_id=" & betalning_transaktion_id)

                
                Return 1

            Else
                Return 0
            End If
        Else


            For Each node In tnode.Nodes
                Counter += Betalning_transaktion_TreeNode_Add(betalning_transaktion_id, Transaktion_typ, node, AccStr)
            Next node
            Return Counter
        End If
    End Function

    
    Private Sub bUtför_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bUtför.Click
        refill_utbetalning_treeview()
        bUtför.ForeColor = Color.White ' : bUtför.Enabled = False
    End Sub

    
    
    
    Private Sub FormUtbetalning_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    
    Private Sub PG_Skapa_ny_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PG_Skapa_ny.Click
        If MsgBox("Vill du skapa en ny utfil för Plusgiro ?", MsgBoxStyle.YesNo, "PlusGiro skapa nytt filunderlag") = MsgBoxResult.Yes Then
            Skapa_ny_betalning_transaktion("PLUSGIRO")
            refill_utbetalning_treeview()
            Lägg_till_befintlig_fil_fyll()

            bUtför.ForeColor = Color.White ' : bUtför.Enabled = False
        End If

    End Sub
    Private Sub PG_Lägg_till_befintlig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim sid As Int32 = CType(sender, ToolStripMenuItem).Tag
        If MsgBox("Vill du lägga dessa poster på Plusgiro-filen ?", MsgBoxStyle.YesNo, "PlusGiro fyll befintligt filunderlag") = MsgBoxResult.Yes Then
            Betalning_transaktion_TreeView_Add(CInt(sid), "PLUSGIRO")
            refill_utbetalning_treeview()
            Lägg_till_befintlig_fil_fyll()
            bUtför.ForeColor = Color.Gray ' : bUtför.Enabled = False
        End If
    End Sub
    Private Sub BG_Skapa_ny_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BG_Skapa_ny.Click
        If MsgBox("Vill du skapa en ny utfil för BankGiro ?", MsgBoxStyle.YesNo, "BankGiro skapa nytt filunderlag.") = MsgBoxResult.Yes Then
            Skapa_ny_betalning_transaktion("BANKGIRO")
            refill_utbetalning_treeview()
            Lägg_till_befintlig_fil_fyll()
            bUtför.ForeColor = Color.White ' : bUtför.Enabled = False
        End If

    End Sub
    Private Sub BG_Lägg_till_befintlig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim sid As Int32 = CType(sender, ToolStripMenuItem).Tag
        If MsgBox("Vill du lägga dessa poster på Bankgiro-filen ?", MsgBoxStyle.YesNo, "BankGiro fyll befintligt filunderlag") = MsgBoxResult.Yes Then
            Betalning_transaktion_TreeView_Add(CInt(sid), "BANKGIRO")
            refill_utbetalning_treeview()
            Lägg_till_befintlig_fil_fyll()
            bUtför.ForeColor = Color.White ' : bUtför.Enabled = False
        End If
    End Sub

    Private Sub UTL_Skapa_ny_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UTL_Skapa_ny.Click
        If MsgBox("Vill du skapa en ny utfil för Utlandsbetalning ?", MsgBoxStyle.YesNo, "Utlandsbetalning skapa nytt filunderlag.") = MsgBoxResult.Yes Then
            Skapa_ny_betalning_transaktion("UTLAND")
            refill_utbetalning_treeview()
            Lägg_till_befintlig_fil_fyll()
            bUtför.ForeColor = Color.White ' : bUtför.Enabled = False
        End If
    End Sub

    Private Sub UTL_Lägg_till_befintlig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim sid As Int32 = CType(sender, ToolStripMenuItem).Tag
        If MsgBox("Vill du lägga dessa poster på Utlandsbetalning ?", MsgBoxStyle.YesNo, "Utlandsbetalning fyll befintligt filunderlag") = MsgBoxResult.Yes Then
            Betalning_transaktion_TreeView_Add(CInt(sid), "UTLAND")
            refill_utbetalning_treeview()
            Lägg_till_befintlig_fil_fyll()
            bUtför.ForeColor = Color.White ' : bUtför.Enabled = False
        End If
    End Sub


    Private Sub MI_Öppna_transaktioner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MI_Öppna_transaktioner.Click
        Dim fu As FormTransaktion
        fu = New FormTransaktion
        fu.Show()
    End Sub

 

    Private Sub FilterKontoTyp_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Filter_Konto_Typ.SelectedIndexChanged

    End Sub
End Class