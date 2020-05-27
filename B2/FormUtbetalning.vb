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
        tb_Filter_Totalsumma_GT.Text = 100
        cb_SortBy.SelectedIndex = 0
        cb_DescAsc.SelectedIndex = 0
        cb_Filter_Efternamn_LT.SelectedIndex = cb_Filter_Efternamn_LT.Items.Count - 1
        cb_Filter_Efternamn_GT.SelectedIndex = 0
        cb_Filter_Efternamn_LT_Rättighetshavare.SelectedIndex = cb_Filter_Efternamn_LT_Rättighetshavare.Items.Count - 1
        cb_Filter_Efternamn_GT_Rättighetshavare.SelectedIndex = 0
        dt_Filter_From.Value = Date.Today.Subtract(New TimeSpan(14, 0, 0, 0)).ToShortDateString
        dt_Filter_To.Value = Date.Today.ToShortDateString

        For i As Integer = 0 To Filter_Mottagartyp.Items.Count - 1
            If Filter_Mottagartyp.Items(i).ToString = "Systerorg." Then Filter_Mottagartyp.SetItemChecked(i, False) Else Filter_Mottagartyp.SetItemChecked(i, True)
        Next i

        'Filter_Förnamn_like.Text = "*"
        ' Filter_Datum_LT_MenuItem.Text = "Datum < " & If(IsDate(Filter_Datum_LT.ToString), Filter_Datum_LT.ToString, "######") & Space(14 - Filter_Datum_LT.Text.Length)
        'Filter_Datum_GT_MenuItem.Text = "Datum > " & If(IsDate(Filter_Datum_GT.ToString), Filter_Datum_GT.ToString, "######") & Space(14 - Filter_Datum_GT.Text.Length)
        refill_utbetalning_treeview()
        Lägg_till_befintlig_fil_fyll()
        Status_Update()


    End Sub
    Sub Lägg_till_befintlig_fil_fyll()
        'Fyller dropdown rutorn för befintliga filer BG_Lägg_till_befintlig,PG_Lägg_till_befintlig,UTL_lägg_tillBefintlig
        Cursor = Cursors.WaitCursor
        Dim selectCommand As SqlCommand = New SqlCommand()
        Dim sqlConn As SqlConnection = New SqlConnection(My.Settings.DBconnectionString)
        selectCommand.CommandType = CommandType.Text
        selectCommand.CommandText = "select * from v_transaktion_assigned_list where antal_poster_calc>0 order by skapad"
        PG_Befintlig_MI.DropDownItems.Clear()
        BG_Befintlig_MI.DropDownItems.Clear()
        BG_Befintlig_MI.Enabled = False


        UTL_Befintlig_MI.DropDownItems.Clear()
        UTL_Befintlig_MI.Enabled = False

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
                BG_Befintlig_MI.Enabled = True


            End If

            If typ = "UTLAND" Then
                ddi = UTL_Befintlig_MI.DropDownItems.Add(s)
                ddi.Tag = reader("ID")
                AddHandler ddi.Click, AddressOf UTL_Lägg_till_befintlig_Click
                UTL_Befintlig_MI.Enabled = True

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
        selectCommand.CommandText = "select * from (select SUM(isnull(sum(CALC_Belopp_NETTO),0.0)) OVER (PARTITION BY mottagare_id,case when mottagare_typ in ('R','U') then 'P' else mottagare_typ end) AS T_Belopp," & _
                                    " SUM(isnull(sum(Belopp),0.0)) OVER (PARTITION BY mottagare_id,case when mottagare_typ in ('R','U') then 'P' else mottagare_typ end) AS T_Belopp_Brutto," & _
                                    "[Namn_Personnummer_grupp], mottagare_id, mottagare_typ, mottagare_personnummer, mottagare_efternamn, mottagare_förnamn, " & _
                                    "upphovsman_ID,personnummer,efternamn,förnamn,betalning_typ,konto_typ_kortnamn,Adress_Kommentar,Konto_Kommentar," & _
                                    " convert(varchar,count(*)) + ' st. underlag '  betalnings_underlag_Kommentar,KontoOK," & _
                                    "min([Registrerat datum]) [Registrerat datum] ,sum(Belopp)/sum(betalning_underlag_belopp)*100.0 Fördelning,sum(betalning_underlag_belopp) betalning_underlag_belopp,sum(CALC_Belopp_NETTO) CALC_Belopp_NETTO,sum(calc_moms) calc_moms,sum(calc_moms)/SUM(belopp) moms,sum(calc_avdrag) calc_avdrag,sum(calc_avdrag)/SUM(belopp) avdrag,sum(Belopp) Belopp,max(checkable) checkable," & _
                                    "min(dödsboejklart) dödsboejklart,max(status) status, COUNT(*) antal_underlag ,min(betalning_Underlag_id) betalning_Underlag_id,0 bg_procent_av_orginal "
        If cb_Filter_Visa_Betalda.Checked Or cb_Filter_VisaFelaktiga.Checked Then
            selectCommand.CommandText &= "from v_betalning_summering "
        Else
            selectCommand.CommandText &= "from v_betalning_summering_OBETALD "
        End If
        selectCommand.CommandText &= " where(" & Get_where_string() & ") group by [Namn_Personnummer_grupp],mottagare_id,mottagare_typ,mottagare_personnummer,mottagare_efternamn,mottagare_förnamn,upphovsman_ID,personnummer,efternamn,förnamn,betalning_typ,konto_typ_kortnamn,Adress_Kommentar,Konto_Kommentar,KontoOK ) t  "
        
        selectCommand.CommandText &= " where t.T_Belopp > " & Get_Filter_TotalSumma() & " " & _
                                   " order by  mottagare_efternamn,mottagare_förnamn,efternamn,förnamn,[registrerat datum];  "

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
        dataAdapter.SelectCommand.CommandTimeout = 0
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
    Public Sub Status_Update()

        'Totalsummesammansräkningar
        Dim s As Stopwatch = New Stopwatch
        s.Reset() : s.Start()
        Console.WriteLine("innan summeringar :" & s.ElapsedMilliseconds.ToString)
        lblAntalRader.Text = UtbetalningTreeView.GetCheckedRows().ToString("N0") & " av " & UtbetalningTreeView.GetTotalRows.ToString("N0") & " fakturarader."
        lblAntal_mottagare.Text = UtbetalningTreeView.Nodes.Count.ToString("N0") & " st. mottagare."
        lblTotalAmount.Text = UtbetalningTreeView.Graph_Pad_Left(Math.Round(UtbetalningTreeView.GetCheckedTotalAmount()).ToString("N0") & " kr.", 20, Me.Font) & " (av " & Math.Round(UtbetalningTreeView.GetTotalAmount()).ToString("N0") & " kr.)"
        'Console.WriteLine("Efter första summeringarna :" & s.ElapsedMilliseconds.ToString)
        lblBrutto.Text = UtbetalningTreeView.Agg_CheckedTotal_text("belopp")
        lblTotalAVIAmount.Text = UtbetalningTreeView.Agg_conditional_text("konto_typ_kortnamn", "AVI")
        'Console.WriteLine("Efter AVI summeringarna :" & s.ElapsedMilliseconds.ToString)

        lblTotalPlusgiroAmount.Text = UtbetalningTreeView.Agg_conditional_text("konto_typ_kortnamn", "PlusGiro")
        'Console.WriteLine("Efter PlusGiro summeringarna :" & s.ElapsedMilliseconds.ToString)

        lblTotalBankGiroAmount.Text = UtbetalningTreeView.Agg_conditional_text("konto_typ_kortnamn", "BankGiro")
        'Console.WriteLine("Efter BankGiro summeringarna :" & s.ElapsedMilliseconds.ToString)

        lblTotalUtlandAmount.Text = UtbetalningTreeView.Agg_conditional_text("konto_typ_kortnamn", "UTLAND")
        'Console.WriteLine("Efter Utland summeringarna :" & s.ElapsedMilliseconds.ToString)
        lblTotalBankkontoAmount.Text = UtbetalningTreeView.Agg_conditional_text("konto_typ_kortnamn", "BANKKONTO")
        ' Console.WriteLine("Efter BANKKonto summeringarna :" & s.ElapsedMilliseconds.ToString)
    End Sub
    Function Get_where_string() As String
        'Dim first As Boolean = True
        'filter
        Dim f As String = ""
        
        f &= " datediff(hh,[Registrerat datum] , '" & dt_Filter_From.Value.ToShortDateString & " 00:01')<0"
        f &= " and datediff(hh,[Registrerat datum] , '" & dt_Filter_To.Value.ToShortDateString & " 23:59')>0"
        

        If cb_Filter_VisaFelaktiga.Checked = False Then
            f &= " and kontoOK=1 and DödsBoEjKlart=0 "
        End If


        If cb_Filter_Visa_Betalda.Checked = False Then
            f &= " and STATUS !='BETALD' "
        End If

        'Upphovsman filter
        If cb_Filter_Efternamn_GT.SelectedIndex > 0 Then
            f &= " and  (Efternamn > '" & cb_Filter_Efternamn_GT.Text & "' or Efternamn like '" & cb_Filter_Efternamn_GT.Text & "%')"
        End If

        If cb_Filter_Efternamn_LT.SelectedIndex < cb_Filter_Efternamn_LT.Items.Count - 1 Then
            f &= " and  (Efternamn < '" & cb_Filter_Efternamn_LT.Text & "' or Efternamn like '" & cb_Filter_Efternamn_LT.Text & "%')"
        End If

        If tb_Filter_Efternamn.Text.Length > 1 Then f &= " and Efternamn like '" & tb_Filter_Efternamn.Text.Replace("*", "%") & "' "


        If tb_Filter_Förnamn.Text.Length > 1 Then f &= " and Förnamn like '" & tb_Filter_Förnamn.Text.Replace("*", "%") & "' "
        If tb_Filter_PNR.Text.Length > 1 Then f &= " and Personnummer like '" & tb_Filter_PNR.Text.Replace("*", "%") & "' "
        'Mottagare filter

        If cb_Filter_Efternamn_GT_Rättighetshavare.SelectedIndex > 0 Then
            f &= " and  (MOttagare_Efternamn > '" & cb_Filter_Efternamn_GT_Rättighetshavare.Text & "' or mottagare_Efternamn = '" & cb_Filter_Efternamn_GT_Rättighetshavare.Text & "')"
        End If

        If cb_Filter_Efternamn_LT_Rättighetshavare.SelectedIndex < cb_Filter_Efternamn_LT_Rättighetshavare.Items.Count - 1 Then
            f &= " and (Mottagare_Efternamn < '" & cb_Filter_Efternamn_LT_Rättighetshavare.Text & "' or Mottagare_Efternamn like '" & cb_Filter_Efternamn_LT_Rättighetshavare.Text & "%')"
        End If

        If tb_Filter_Efternamn_Rättighetshavare.Text.Length > 1 Then f &= " and Mottagare_Efternamn like '" & tb_Filter_Efternamn_Rättighetshavare.Text.Replace("*", "%") & "' "

        If tb_Filter_Förnamn_Rättighetshavare.Text.Length > 1 Then f &= " and Mottagare_Förnamn like '" & tb_Filter_Förnamn_Rättighetshavare.Text.Replace("*", "%") & "' "
        If tb_Filter_PNR_Rättighetshavare.Text.Length > 1 Then f &= " and MOttagare_Personnummer like '" & tb_Filter_PNR_Rättighetshavare.Text.Replace("*", "%") & "' "

        Dim FirstIn As Boolean = True
        Dim StringIn As String = ""

        If Filter_Mottagartyp.CheckedItems.Count < Filter_Mottagartyp.Items.Count Then
            If Filter_Mottagartyp.CheckedItems.Contains("Upphovsmän") = True Then StringIn &= IIf(FirstIn, "", " or ") & "rtrim(mottagare_typ) like 'U%'" : FirstIn = False
            If Filter_Mottagartyp.CheckedItems.Contains("Rättighetsh.") = True Then StringIn &= IIf(FirstIn, "", " or ") & "rtrim(mottagare_typ) like 'R%'" : FirstIn = False
            If Filter_Mottagartyp.CheckedItems.Contains("Systerorg.") = True Then StringIn &= IIf(FirstIn, "", " or ") & "rtrim(mottagare_typ) like 'S%'" : FirstIn = False
            If Filter_Mottagartyp.CheckedItems.Contains("Ombud") = True Then StringIn &= IIf(FirstIn, "", " or ") & "rtrim(mottagare_typ) like 'O%'" : FirstIn = False

            If StringIn.Length > 0 Then f &= " and (" & StringIn & ") "
        End If



        'KOmmentar sökningsfilter

        If tb_Filter_Kommentar.Text.Length > 1 Then f &= " and betalnings_underlag_kommentar like '" & tb_Filter_Kommentar.Text.Replace("*", "%") & "' "


        'Utbetalningstyp fileter
        If cb_Filter_Betalning_Typ.CheckedItems.Count < cb_Filter_Betalning_Typ.Items.Count Then
            'IR-BILDBYRÅ    
            FirstIn = True
            StringIn = ""
            If cb_Filter_Betalning_Typ.CheckedItems.Contains("Följerätt") = True Then StringIn &= IIf(FirstIn, "", " OR ") & " Betalning_typ = 'Följerätt'" : FirstIn = False
            If cb_Filter_Betalning_Typ.CheckedItems.Contains("IR") = True Then StringIn &= IIf(FirstIn, "", " OR ") & " rtrim(Betalning_typ) = 'IR'" : FirstIn = False
            If cb_Filter_Betalning_Typ.CheckedItems.Contains("IR-Foto") = True Then StringIn &= IIf(FirstIn, "", " OR ") & " Betalning_typ = 'IR-Foto'" : FirstIn = False
            If cb_Filter_Betalning_Typ.CheckedItems.Contains("IR-Dagpress-foto") = True Then StringIn &= IIf(FirstIn, "", " OR ") & " Betalning_typ = 'IRDAGP-FOTO'" : FirstIn = False
            If cb_Filter_Betalning_Typ.CheckedItems.Contains("IR-Dagpress-illustration") = True Then StringIn &= IIf(FirstIn, "", " OR ") & " Betalning_typ = 'IRDAGP-ILLUST.'" : FirstIn = False

            If cb_Filter_Betalning_Typ.CheckedItems.Contains("IR-Bildbyrå") = True Then StringIn &= IIf(FirstIn, "", " OR ") & " Betalning_typ = 'IR_Bildbyrå'" : FirstIn = False
            If cb_Filter_Betalning_Typ.CheckedItems.Contains("IV") = True Then StringIn &= IIf(FirstIn, "", " OR ") & " Betalning_typ = 'IV'" : FirstIn = False
            If cb_Filter_Betalning_Typ.CheckedItems.Contains("KR") = True Then StringIn &= IIf(FirstIn, "", " OR ") & " Betalning_typ like 'KR%'" : FirstIn = False
            If cb_Filter_Betalning_Typ.CheckedItems.Contains("Repro") = True Then StringIn &= IIf(FirstIn, "", " OR ") & " Betalning_typ = 'Repro'" : FirstIn = False
            If cb_Filter_Betalning_Typ.CheckedItems.Contains("Sveriges tidskrifter") = True Then StringIn &= IIf(FirstIn, "", " OR ") & " Betalning_typ = 'ST'" : FirstIn = False
            If cb_Filter_Betalning_Typ.CheckedItems.Contains("TV") = True Then StringIn &= IIf(FirstIn, "", " OR ") & " rtrim(Betalning_typ) = 'TV'" : FirstIn = False
            If cb_Filter_Betalning_Typ.CheckedItems.Contains("TV-Foto") = True Then StringIn &= IIf(FirstIn, "", " OR ") & " Betalning_typ  = 'TV-FOTO'" : FirstIn = False
            If cb_Filter_Betalning_Typ.CheckedItems.Contains("TV4") = True Then StringIn &= IIf(FirstIn, "", " OR ") & " rtrim(Betalning_typ) = 'TV4'" : FirstIn = False
            If cb_Filter_Betalning_Typ.CheckedItems.Contains("TV4-Foto") = True Then StringIn &= IIf(FirstIn, "", " OR ") & " Betalning_typ = 'TV4-Foto'" : FirstIn = False
            If cb_Filter_Betalning_Typ.CheckedItems.Contains("TVCopy") = True Then StringIn &= IIf(FirstIn, "", " OR ") & " rtrim(Betalning_typ) = 'TVCopy'" : FirstIn = False
            If cb_Filter_Betalning_Typ.CheckedItems.Contains("TVCopy-Foto") = True Then StringIn &= IIf(FirstIn, "", " OR ") & " Betalning_typ = 'TVCOPY-FOTO'" : FirstIn = False
            If cb_Filter_Betalning_Typ.CheckedItems.Contains("TV4-Copy") = True Then StringIn &= IIf(FirstIn, "", " OR ") & " rtrim(Betalning_typ) = 'TV4-Copy'" : FirstIn = False
            If cb_Filter_Betalning_Typ.CheckedItems.Contains("TV4-Copy-Foto") = True Then StringIn &= IIf(FirstIn, "", " OR ") & " Betalning_typ like 'TV4-Copy-Foto'" : FirstIn = False

            If StringIn.Length > 0 Then f &= "  and (" & StringIn & ") "

        End If



        'AVI,        Bankgiro,        Bankkonto,        Plusgiro
        FirstIn = True
        StringIn = ""

        If Filter_Konto_Typ.CheckedItems.Count < Filter_Konto_Typ.Items.Count Then
            If Filter_Konto_Typ.CheckedItems.Contains("AVI") = True Then
                StringIn &= IIf(FirstIn, "", " OR ") & "Konto_typ_kortnamn = 'AVI'"
                FirstIn = False
            End If

            If Filter_Konto_Typ.CheckedItems.Contains("Bankgiro") = True Then
                StringIn &= IIf(FirstIn, "", " OR ") & "Konto_typ_kortnamn = 'Bankgiro'"
                FirstIn = False
            End If

            If Filter_Konto_Typ.CheckedItems.Contains("Bankkonto") = True Then
                StringIn &= IIf(FirstIn, "", " OR ") & "Konto_typ_kortnamn ='Bankkonto'"
                FirstIn = False
            End If

            If Filter_Konto_Typ.CheckedItems.Contains("Plusgiro") Then
                StringIn &= IIf(FirstIn, "", " OR ") & "Konto_typ_kortnamn = 'Plusgiro'"
                FirstIn = False
            End If


            If StringIn.Length > 0 Then f &= " and  (" & StringIn & ")"
        End If



        Return f
    End Function
    Function Get_Filter_TotalSumma() As Decimal
        If IsNumeric(tb_Filter_Totalsumma_GT.Text) Then
            Return tb_Filter_Totalsumma_GT.Text
        Else
            Return 0.0
        End If

    End Function







    'Fyller UtbetalningTreeView från databladet. (3 nivåer Root=Upphovsman,Child=BetalningsTyp,Level2=BetalningsID




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
    Private Sub tb_Filter_Totalsumma_GT_TextChanged(sender As System.Object, e As System.EventArgs) Handles tb_Filter_Totalsumma_GT.TextChanged
        bUtför.ForeColor = Color.Black

    End Sub

    Private Sub dt_Filter_From_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dt_Filter_From.ValueChanged
        bUtför.ForeColor = Color.Black

    End Sub

    Private Sub dt_Filter_To_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dt_Filter_To.ValueChanged
        bUtför.ForeColor = Color.Black

    End Sub

    Private Sub cb_Betalda_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cb_Filter_Visa_Betalda.CheckedChanged
        bUtför.ForeColor = Color.Black

    End Sub
    Private Sub tb_Filter_Efternamn_Rättighetshavare_TextChanged(sender As System.Object, e As System.EventArgs) Handles tb_Filter_Efternamn_Rättighetshavare.TextChanged
        bUtför.ForeColor = Color.Black

    End Sub
    Private Sub tb_Filter_PNR_Rättighetshavare_TextChanged(sender As System.Object, e As System.EventArgs) Handles tb_Filter_PNR_Rättighetshavare.TextChanged
        bUtför.ForeColor = Color.Black 'bUtför.Enabled = True

    End Sub

    Private Sub tb_Filter_Förnamn_Rättighetshavare_TextChanged(sender As System.Object, e As System.EventArgs) Handles tb_Filter_Förnamn_Rättighetshavare.TextChanged
        bUtför.ForeColor = Color.Black

    End Sub

    Private Sub cb_Filter_Efternamn_GT_Rättighetshavare_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cb_Filter_Efternamn_GT_Rättighetshavare.SelectedIndexChanged

        bUtför.ForeColor = Color.Black
    End Sub

    Private Sub cb_Filter_Efternamn_LT_Rättighetshavare_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cb_Filter_Efternamn_LT_Rättighetshavare.SelectedIndexChanged
        bUtför.ForeColor = Color.Black

    End Sub

    Private Sub Filter_Upphovsman_MenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        bUtför.ForeColor = Color.Black

    End Sub

    Private Sub tb_Filter_Efternamn_TextChanged(sender As System.Object, e As System.EventArgs) Handles tb_Filter_Efternamn.TextChanged
        bUtför.ForeColor = Color.Black 'bUtför.Enabled = True
        
    End Sub
    
    Private Sub tb_Filter_Förnamn_TextChanged(sender As System.Object, e As System.EventArgs) Handles tb_Filter_Förnamn.TextChanged
        bUtför.ForeColor = Color.Black 'bUtför.Enabled = True


    End Sub


    Private Sub tb_Filter_PNR_TextChanged(sender As System.Object, e As System.EventArgs) Handles tb_Filter_PNR.TextChanged
        bUtför.ForeColor = Color.Black 'bUtför.Enabled = True

    End Sub
    Private Sub cb_Filter_Efternamn_GT_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cb_Filter_Efternamn_GT.SelectedIndexChanged
        bUtför.ForeColor = Color.Black 'bUtför.Enabled = True

    End Sub
    Private Sub cb_Filter_Efternamn_LT_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cb_Filter_Efternamn_LT.SelectedIndexChanged
        bUtför.ForeColor = Color.Black 'bUtför.Enabled = True

    End Sub

    Private Sub tb_Filter_Kommentar_TextChanged(sender As System.Object, e As System.EventArgs) Handles tb_Filter_Kommentar.TextChanged
        bUtför.ForeColor = Color.Black
    End Sub
    Private Sub Filter_Checkable_Only_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        bUtför.ForeColor = Color.Black
        Status_Update()
    End Sub


    Private Sub cb_SortBy_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cb_SortBy.SelectedIndexChanged
        Sort()
    End Sub

    Private Sub cb_DescAsc_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cb_DescAsc.SelectedIndexChanged
        Sort()
    End Sub
    Private Sub cb_Filter_Betalning_Typ_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cb_Filter_Betalning_Typ.SelectedIndexChanged
        bUtför.ForeColor = Color.Black
    End Sub


    Private Sub FilterKontoTyp_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Filter_Konto_Typ.SelectedIndexChanged
        bUtför.ForeColor = Color.Black

    End Sub

    Private Sub Filter_Mottagartyp_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Filter_Mottagartyp.SelectedIndexChanged
        bUtför.ForeColor = Color.Black : Status_Update()
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

    Private Sub Sort()
        Cursor = Cursors.WaitCursor
        If cb_SortBy.Text = "Namn" Then Sort_By_Namn() Else Sort_By_Belopp()
        Cursor = Cursors.Default
    End Sub
    Private Sub Sort_By_Namn()
        If cb_DescAsc.Text = "Fallande" Then
            UtbetalningTreeView.Sort_RootNodes(B2.GroupTreeView.SortColumn.Name, GroupTreeView.AscDesc.Desc)
        Else
            UtbetalningTreeView.Sort_RootNodes(B2.GroupTreeView.SortColumn.Name, GroupTreeView.AscDesc.Asc)


        End If


    End Sub
    Private Sub Sort_By_Belopp()
        If cb_DescAsc.Text = "Fallande" Then
            UtbetalningTreeView.Sort_RootNodes(B2.GroupTreeView.SortColumn.Amount, GroupTreeView.AscDesc.Desc)
        Else
            UtbetalningTreeView.Sort_RootNodes(B2.GroupTreeView.SortColumn.Amount, GroupTreeView.AscDesc.Asc)
        End If

    End Sub





  
    Private Sub cb_VisaDolda_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cb_Filter_VisaDolda.CheckedChanged
        bUtför.ForeColor = Color.Black
    End Sub

    Private Sub cb_VisaFelaktiga_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cb_Filter_VisaFelaktiga.CheckedChanged
        bUtför.ForeColor = Color.Black
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
                If cb_Filter_VisaDolda.Checked = True Then
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
        selectCommand.CommandTimeout = 0

        'Skapa temporär taell med samliga where
        Dim s As StringBuilder = New StringBuilder
        s.Length = 0
        s.AppendLine("if OBJECT_ID('tempdb..#kryss') is not null drop table  #kryss;")
        s.AppendLine("create table  #kryss (id int  identity,  k_mottagare_id int not null,k_mottagare_typ varchar(1) not null, k_betalning_typ varchar(15)  not null,k_Upphovsman_ID int not null,k_BEtalning_underlag_ID int  );")
        System.Console.WriteLine(s.ToString)
        selectCommand.CommandType = CommandType.Text
        selectCommand.CommandText = s.ToString

        selectCommand.Connection = sqlConn
        reader = selectCommand.ExecuteReader
        reader.Read()
        reader.Close()


        For Each node In UtbetalningTreeView.Nodes 'Fyll #kryss från  DataGrid
            row = CType(node.Tag, DataRow)
            pbProgress.Value = rowCount
            rowCount += Betalning_transaktion_TreeNode_Add(betalning_transaktion_id, Transaktion_typ, node, AccString, sqlConn)
        Next node
        Dim rowString As String
        Dim AccStringOut As StringBuilder = New StringBuilder
        AccStringOut.Length = 0
        AccStringOut.AppendLine("begin transaction")
        ' AccStringOut.AppendLine("exec sp_betalning_transaktion_summera " & betalning_transaktion_id)
        For Each rowString In AccString.ToString.Split(vbNewLine)
            AccStringOut.AppendLine(rowString)
            i = i + 1
            'System.Console.WriteLine(rowString)
            If i Mod 200 = 0 Then
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
        AccStringOut.AppendLine("if OBJECT_ID('tempdb..#bu') is not null drop table #bu;")
        AccStringOut.AppendLine("SELECT bs.mottagare_id,bs.mottagare_typ,mottagare_personnummer,mottagare_efternamn,mottagare_förnamn,bs.upphovsman_ID,")
        AccStringOut.AppendLine("bs.betalning_typ,bs.konto_typ_kortnamn,KontoOK,[Registrerat datum] , ")
        AccStringOut.AppendLine("Fördelning,betalning_underlag_belopp, CALC_Belopp_NETTO,calc_moms, moms, calc_avdrag, avdrag, Belopp,checkable checkable,dödsboejklart,")
        AccStringOut.AppendLine("status,bs.betalning_Underlag_id betalning_Underlag_id,bg_procent_av_orginal ,Adress_ID,Betalningssätt_ID")
        AccStringOut.AppendLine("into #bu from v_betalning_summering_obetald  bs join #kryss k on k.k_mottagare_id=bs.mottagare_id and")
        AccStringOut.AppendLine("k.k_mottagare_typ=bs.mottagare_typ collate Finnish_Swedish_CI_AS and ")
        AccStringOut.AppendLine("k.k_betalning_typ=bs.betalning_typ  collate Finnish_Swedish_CI_AS and k.k_upphovsman_id=bs.upphovsman_id ")
        AccStringOut.AppendLine("and (bs.betalning_underlag_id=k.k_betalning_underlag_id or k.k_betalning_underlag_id is null)")
        AccStringOut.AppendLine(" where(" & Get_where_string() & ") ")
        AccStringOut.AppendLine("order by Namn_Personnummer_grupp")


        AccStringOut.AppendLine("exec sp_betalning_transaktion_kryss " & betalning_transaktion_id & ",'" & Environ("USERNAME") & "'")
        AccStringOut.AppendLine("commit transaction")
        'Spara transaktionen
        selectCommand.CommandType = CommandType.Text
        selectCommand.CommandText = AccStringOut.ToString

        System.Console.WriteLine(selectCommand.CommandText.ToString)
        System.Console.WriteLine("Final i " & i)
        selectCommand.Connection = sqlConn
        reader = selectCommand.ExecuteReader
        reader.Read()
        reader.Close()
        sqlConn.Close()
        pbProgress.Visible = False

    End Sub
    Private Function Betalning_transaktion_TreeNode_Add(ByRef betalning_transaktion_id As Int16, ByRef Transaktion_typ As String, ByRef tnode As TreeNode, ByRef AccStr As StringBuilder, ByRef sqlConn As SqlConnection) As Integer

        Dim Counter As Integer = 0
        If tnode.Nodes.Count = 0 Then
            If tnode.Checked = True And is_Transaktion_OK(CType(tnode.Tag, DataRow)("mottagare_typ").ToString, Transaktion_typ, CType(tnode.Tag, DataRow)("Konto_typ_kortnamn").ToString) = True Then

                If tnode.Level = 3 Then
                    AccStr.Append("insert #kryss (k_mottagare_id,k_mottagare_typ,k_betalning_typ,k_Upphovsman_ID,k_BEtalning_underlag_ID)")
                    AccStr.Append("values	(" & (CType(tnode.Tag, DataRow)("mottagare_id")) & ",'" & (CType(tnode.Tag, DataRow)("mottagare_typ")) & "'")
                    AccStr.Append(",'" & (CType(tnode.Tag, DataRow)("betalning_typ")) & "'," & (CType(tnode.Tag, DataRow)("upphovsman_id")) & "," & (CType(tnode.Tag, DataRow)("betalning_Underlag_id")) & "); ")
                    Return 1
                ElseIf tnode.Level = 2 Then 'Gruppering av multipla level 3
                    AccStr.Append("insert #kryss (k_mottagare_id,k_mottagare_typ,k_betalning_typ,k_Upphovsman_ID,k_BEtalning_underlag_ID)")
                    AccStr.Append("values	(" & (CType(tnode.Tag, DataRow)("mottagare_id")) & ",'" & (CType(tnode.Tag, DataRow)("mottagare_typ")) & "'")
                    AccStr.Append(",'" & (CType(tnode.Tag, DataRow)("betalning_typ")) & "'," & (CType(tnode.Tag, DataRow)("upphovsman_id")) & ",NULL); ")

                End If

                Return (CType(tnode.Tag, DataRow)("antal_underlag")) 'Counter
            Else
                Return 0
            End If
        Else


            For Each node In tnode.Nodes
                Counter += Betalning_transaktion_TreeNode_Add(betalning_transaktion_id, Transaktion_typ, node, AccStr, sqlConn)
            Next node
            Return Counter
        End If
    End Function

    Private Function is_Transaktion_OK(ByRef Mottagar_typ As String, ByRef Transaktion_typ As String, ByRef Konto_typ As String) As Boolean
        If Mottagar_typ.Trim.ToUpper = "S" Then 'SYSTERORGANISATION
            If Transaktion_typ.ToUpper.Trim = "UTLAND" Then
                Return True
            Else
                Return False
            End If
        ElseIf Transaktion_typ.ToUpper.Trim = "PLUSGIRO" Then
            If Konto_typ.Trim.ToUpper = "PLUSGIRO" Or Konto_typ.ToUpper.Trim = "AVI" Then
                '        Return True
                Return False
            Else
                Return False
            End If
        ElseIf Transaktion_typ.ToUpper.Trim = "BANKGIRO" Then

            If Konto_typ.Trim.ToUpper = "PLUSGIRO" Or Konto_typ.Trim.ToUpper = "BANKGIRO" Or Konto_typ.ToUpper.Trim = "BANKKONTO" Or Konto_typ.ToUpper.Trim = "AVI" Then
                Return True
            Else
                Return False
            End If
        End If




    End Function
    
    
    Private Sub bUtför_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bUtför.Click
        refill_utbetalning_treeview()
        bUtför.ForeColor = Color.White ' : bUtför.Enabled = False
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

    Private Sub UTL_Lägg_till_befintlig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UTL_Befintlig_MI.Click
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

 
    Private Sub SparaSomExcelToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SparaSomExcelToolStripMenuItem.Click

    End Sub

    Private Sub RapportToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RapportToolStripMenuItem.Click

    End Sub

  
End Class