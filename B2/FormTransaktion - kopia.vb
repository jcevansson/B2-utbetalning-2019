Imports System
Imports System.ComponentModel
Imports System.Threading
Imports System.Windows.Forms
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.IO



Public Class FormTransaktion


    Private UtbetalningDao As PaymentBaseDAO 'Ett objekt som sköter operationer mot databasen
    Private dataTable As DataTable 'Datatabellen som ligger till grund för trädinfon
    Private dataView As DataView
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        'Sort_Namn_Ned.Checked = False : Sort_Namn_Upp.Checked = False

        cb_DescAsc.SelectedIndex = 0
        cb_Filter_Efternamn_LT.SelectedIndex = cb_Filter_Efternamn_LT.Items.Count - 1
        cb_Filter_Efternamn_GT.SelectedIndex = 0
        cb_Filter_Efternamn_LT_Rättighetshavare.SelectedIndex = cb_Filter_Efternamn_LT_Rättighetshavare.Items.Count - 1
        cb_Filter_Efternamn_GT_Rättighetshavare.SelectedIndex = 0
        dt_Filter_From.Value = Date.Today.Subtract(New TimeSpan(14, 0, 0, 0)).ToShortDateString
        dt_Filter_To.Value = Date.Today.ToShortDateString
        cb_Filter_Status.SelectedIndex = 1

        
        '        Filter_Förnamn_like_MenuItem.Checked = True : Filter_Förnamn_like.Text = "P*"
        ' Filter_Datum_LT_MenuItem.Text = "Datum < " & If(IsDate(Filter_Datum_LT.ToString), Filter_Datum_LT.ToString, "######") & Space(14 - Filter_Datum_LT.Text.Length)
        'Filter_Datum_GT_MenuItem.Text = "Datum > " & If(IsDate(Filter_Datum_GT.ToString), Filter_Datum_GT.ToString, "######") & Space(14 - Filter_Datum_GT.Text.Length)
        'Filter_Totalsumma_GT_MenuItem.Text = "Totalsumma > " & IIf(IsNumeric(Filter_Totalsumma_GT.Text), Filter_Totalsumma_GT.Text, 0) & Space(6 - Filter_Totalsumma_GT.Text.Length)
        refill_utbetalning_treeview()

        Status_Update()


    End Sub



    Public Sub refill_utbetalning_treeview()
        Cursor = Cursors.WaitCursor

        Dim whereString As String = Get_where_string()
        Dim paymentDataSet As DataSet = New DataSet
        ' Dim connectionString As String = resources.ResourceManager.'"Data Source=192.168.0.38;Initial Catalog=B2Arbete;user id=Developer;Connection Timeout=120;Password=Developer;"
        Dim sqlConn As SqlConnection = New SqlConnection(My.Settings.DBconnectionString)
        Dim selectCommand As SqlCommand = New SqlCommand()
        selectCommand.CommandType = CommandType.Text
        selectCommand.CommandText = "SELECT * ,  Mottagare_Efternamn+', '+Mottagare_Förnamn+' ('+Mottagare_personnummer+')' Mottagar_grupp " & _
                    "from v_betalning_transaktion_post  where " & Get_where_string() & _
                    "order by mottagare_efternamn,mottagare_förnamn,bu_upphovsman_efternamn,bu_upphovsman_förnamn,utbetalning_transaktion_skapad "

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
            TransTreeView.SetDataView(dataView)
            'Console.WriteLine("8.Efter dataview: " & s.ElapsedMilliseconds) : s.Reset() : s.Start()
            Dim GroupNames() As String = {"bt_ID", "bp_konto_typ", "mottagar_grupp", "bu_ID"}
            TransTreeView.setGroupNames(GroupNames)
            TransTreeView.setColSumName("BU_Belopp")
            TransTreeView.setColGroupSumName("BP_netto") 'Gruppsumma att sortera på
            pbProgress.Visible = True
            pbProgress.Value = 0
            'Console.WriteLine("9.Innan PTV fill: " & s.ElapsedMilliseconds) : s.Reset() : s.Start()
            TransTreeView.Fill(pbProgress)
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
        SkapaBG.Enabled = False
        skapaPG.Enabled = False
        skapaUTL.Enabled = False
        If TransTreeView.SelectedNode Is Nothing Then
            RapporterMI.Enabled = False
        Else
            Dim row As DataRow = CType(TransTreeView.SelectedNode.Tag, DataRow)

            If row("STATUS").ToString.ToUpper.Trim = "ASSIGNED" Or row("STATUS").ToString.ToUpper.Trim = "NEW" Then
                RapporterMI.Enabled = True
                Rapport_Acconto.Enabled = True
                Rapport_Bokföring.Enabled = False
                Rapport_Prognos.Enabled = True
                If row("Transaktion_typ").ToString.ToUpper.Trim = "UTLAND" Then
                    skapaUTL.Enabled = True
                ElseIf row("Transaktion_typ").ToString.ToUpper.Trim = "PLUSGIRO" Then
                    skapaPG.Enabled = True
                ElseIf row("Transaktion_typ").ToString.ToUpper.Trim = "BANKGIRO" Then
                    SkapaBG.Enabled = True
                End If

            ElseIf row("STATUS").ToString.ToUpper.Trim = "CLOSED" Then
                RapporterMI.Enabled = True
                Rapport_Acconto.Enabled = True
                Rapport_Bokföring.Enabled = True

                Rapport_Prognos.Enabled = False
            Else
                RapporterMI.Enabled = False
                Rapport_Acconto.Enabled = True
                Rapport_Bokföring.Enabled = True
                Rapport_Prognos.Enabled = True
            End If



        End If



        'Transaktionstyp

        'Datumfilter
        'DoldVisad
        'Betalning_typ
        'Kontotyp
        'Kontotyp                
        'Totalsummesammansräkningar
        lblAntalRader.Text = TransTreeView.GetCheckedRows().ToString("N0") & " av " & TransTreeView.GetTotalRows
        lblTotalAmount.Text = Math.Round(TransTreeView.GetCheckedTotalAmount()).ToString("N0") & " (" & Math.Round(TransTreeView.GetTotalAmount()).ToString("N0") & ")"
    End Sub
    Function Get_where_string() As String
        Dim first As Boolean = True
        'filter
        Dim f As String = ""
        
        f &= " datediff(hh,[utbetalning_transaktion_skapad] , '" & dt_Filter_From.Value.ToShortDateString & " 00:01')<0"
        f &= " and datediff(hh,[utbetalning_transaktion_skapad] , '" & dt_Filter_To.Value.ToShortDateString & " 23:59')>0"

        'Upphovsman filter

        If cb_Filter_Efternamn_GT.SelectedIndex > 0 Then
            f &= " and  (BU_Upphovsman_Efternamn > '" & cb_Filter_Efternamn_GT.Text & "' or BU_Upphovsman_Efternamn like '" & cb_Filter_Efternamn_GT.Text & "%')"
        End If

        If cb_Filter_Efternamn_LT.SelectedIndex < cb_Filter_Efternamn_LT.Items.Count - 1 Then
            f &= " and  (BU_Upphovsman_Efternamn < '" & cb_Filter_Efternamn_LT.Text & "' or BU_Upphovsman_Efternamn like '" & cb_Filter_Efternamn_LT.Text & "%')"
        End If

        If tb_Filter_Efternamn.Text.Trim.Length > 1 Then f &= " and BU_Upphovsman_Efternamn like '" & tb_Filter_Efternamn.Text.Trim.Replace("*", "%") & "' "


        If tb_Filter_Förnamn.Text.Trim.Length > 1 Then f &= " and BU_Upphovsman_Förnamn like '" & tb_Filter_Förnamn.Text.Trim.Replace("*", "%") & "' "
        If tb_Filter_PNR.Text.Trim.Length > 1 Then f &= " and BU_Upphovsman_personnummer like '" & tb_Filter_PNR.Text.Trim.Replace("*", "%") & "' "

        'Mottagare filter
        

            'Namnfilter


            
            
            If cb_Filter_Efternamn_GT_Rättighetshavare.SelectedIndex > 0 Then
                f &= " and  (MOttagare_Efternamn > '" & cb_Filter_Efternamn_GT_Rättighetshavare.Text & "' or mottagare_Efternamn = '" & cb_Filter_Efternamn_GT_Rättighetshavare.Text & "')"
            End If

            If cb_Filter_Efternamn_LT_Rättighetshavare.SelectedIndex < cb_Filter_Efternamn_LT_Rättighetshavare.Items.Count - 1 Then
                f &= " and (Mottagare_Efternamn < '" & cb_Filter_Efternamn_LT_Rättighetshavare.Text & "' or Mottagare_Efternamn like '" & cb_Filter_Efternamn_LT_Rättighetshavare.Text & "%')"
            End If

        If tb_Filter_Efternamn_Rättighetshavare.Text.Trim.Length > 1 Then f &= " and Mottagare_Efternamn like '" & tb_Filter_Efternamn_Rättighetshavare.Text.Trim.Replace("*", "%") & "' "

        If tb_Filter_Förnamn_Rättighetshavare.Text.Trim.Length > 1 Then f &= " and Mottagare_Förnamn like '" & tb_Filter_Förnamn_Rättighetshavare.Text.Trim.Replace("*", "%") & "' "
        If tb_Filter_PNR_Rättighetshavare.Text.Trim.Length > 1 Then f &= " and MOttagare_Personnummer like '" & tb_Filter_PNR_Rättighetshavare.Text.Trim.Replace("*", "%") & "' "


            
        Dim FirstIn As Boolean = True
        Dim StringIn As String = ""

        If Filter_Mottagartyp.CheckedItems.Count < Filter_Mottagartyp.Items.Count Then
            If Filter_Mottagartyp.CheckedItems.Contains("Upphovsmän") = True Then StringIn &= IIf(FirstIn, "", " or ") & "rtrim(betalningsmottagare_typ) like 'U%'" : FirstIn = False
            If Filter_Mottagartyp.CheckedItems.Contains("Rättighetsh.") = True Then StringIn &= IIf(FirstIn, "", " or ") & "rtrim(betalningsmottagare_typ) like 'R%'" : FirstIn = False
            If Filter_Mottagartyp.CheckedItems.Contains("Systerorg.") = True Then StringIn &= IIf(FirstIn, "", " or ") & "rtrim(betalningsmottagare_typ) like 'S%'" : FirstIn = False
            If Filter_Mottagartyp.CheckedItems.Contains("Ombud") = True Then StringIn &= IIf(FirstIn, "", " or ") & "rtrim(betalningsmottagare_typ) like 'O%'" : FirstIn = False

            If StringIn.Length > 0 Then f &= " and (" & StringIn & ") "
        End If



        'Utbetalningstyp fileter

        If cb_Filter_Betalning_Typ.CheckedItems.Count < cb_Filter_Betalning_Typ.Items.Count Then
            'IR-BILDBYRÅ    
            FirstIn = True
            StringIn = ""
            If cb_Filter_Betalning_Typ.CheckedItems.Contains("Följerätt") = True Then StringIn &= IIf(FirstIn, "", " OR ") & " rtrim(Betalning_typ) like 'Följerätt%'" : FirstIn = False
            If cb_Filter_Betalning_Typ.CheckedItems.Contains("IR") = True Then StringIn &= IIf(FirstIn, "", " OR ") & " rtrim(Betalning_typ) like 'IR'" : FirstIn = False
            If cb_Filter_Betalning_Typ.CheckedItems.Contains("IR-Foto") = True Then StringIn &= IIf(FirstIn, "", " OR ") & " rtrim(Betalning_typ) like 'IR-F%'" : FirstIn = False
            If cb_Filter_Betalning_Typ.CheckedItems.Contains("IR-Dagpress-foto") = True Then StringIn &= IIf(FirstIn, "", " OR ") & " rtrim(Betalning_typ) = 'IRDAGP-FOTO'" : FirstIn = False
            If cb_Filter_Betalning_Typ.CheckedItems.Contains("IR-Dagpress-illustration") = True Then StringIn &= IIf(FirstIn, "", " OR ") & " rtrim(Betalning_typ) = 'IRDAGP-ILLUST.'" : FirstIn = False

            If cb_Filter_Betalning_Typ.CheckedItems.Contains("IR-Bildbyrå") = True Then StringIn &= IIf(FirstIn, "", " OR ") & " rtrim(Betalning_typ) like 'IR_B%'" : FirstIn = False
            If cb_Filter_Betalning_Typ.CheckedItems.Contains("IV") = True Then StringIn &= IIf(FirstIn, "", " OR ") & " rtrim(Betalning_typ) like 'IV%'" : FirstIn = False
            If cb_Filter_Betalning_Typ.CheckedItems.Contains("KR") = True Then StringIn &= IIf(FirstIn, "", " OR ") & " rtrim(Betalning_typ) like 'KR%'" : FirstIn = False
            If cb_Filter_Betalning_Typ.CheckedItems.Contains("Repro") = True Then StringIn &= IIf(FirstIn, "", " OR ") & " rtrim(Betalning_typ) like 'Repro%'" : FirstIn = False
            If cb_Filter_Betalning_Typ.CheckedItems.Contains("Sveriges tidskrifter") = True Then StringIn &= IIf(FirstIn, "", " OR ") & " rtrim(Betalning_typ) like 'ST%'" : FirstIn = False
            If cb_Filter_Betalning_Typ.CheckedItems.Contains("TV") = True Then StringIn &= IIf(FirstIn, "", " OR ") & " rtrim(Betalning_typ) like 'TV'" : FirstIn = False
            If cb_Filter_Betalning_Typ.CheckedItems.Contains("TV-Foto") = True Then StringIn &= IIf(FirstIn, "", " OR ") & " rtrim(Betalning_typ) like 'TV-Foto'" : FirstIn = False
            If cb_Filter_Betalning_Typ.CheckedItems.Contains("TV4") = True Then StringIn &= IIf(FirstIn, "", " OR ") & " rtrim(Betalning_typ) like 'TV4'" : FirstIn = False
            If cb_Filter_Betalning_Typ.CheckedItems.Contains("TV4-Foto") = True Then StringIn &= IIf(FirstIn, "", " OR ") & " rtrim(Betalning_typ) like 'TV4-Foto'" : FirstIn = False
            If cb_Filter_Betalning_Typ.CheckedItems.Contains("TVCopy") = True Then StringIn &= IIf(FirstIn, "", " OR ") & " rtrim(Betalning_typ) like 'TVCopy'" : FirstIn = False
            If cb_Filter_Betalning_Typ.CheckedItems.Contains("TVCopy-Foto") = True Then StringIn &= IIf(FirstIn, "", " OR ") & " rtrim(Betalning_typ) like 'TVCopy-Foto'" : FirstIn = False

            If StringIn.Length > 0 Then f &= "  and (" & StringIn & ") "

        End If



        
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


        'Status Utbetald eller ej
        If cb_Filter_Status.Text = "Ej betalda" Then
            f &= " and Status='ASSIGNED'"
        ElseIf cb_Filter_Status.Text = "Betalda" Then
            f &= " and Status='Closed'"

        Else
            f &= " and Status<>'' "

        End If

        'Transaktionstyp
            
        FirstIn = True
        StringIn = ""

        If cb_Filter_Transaktionstyp.CheckedItems.Count < cb_Filter_Transaktionstyp.Items.Count Then
            If cb_Filter_Transaktionstyp.CheckedItems.Contains("PlusGiro") = True Then
                StringIn &= IIf(FirstIn, "", " OR ") & "transaktion_typ like 'pl%'"
                FirstIn = False
            End If

            If cb_Filter_Transaktionstyp.CheckedItems.Contains("BankGiro") = True Then
                StringIn &= IIf(FirstIn, "", " OR ") & "transaktion_typ like 'ba%'"
                FirstIn = False
            End If

            If cb_Filter_Transaktionstyp.CheckedItems.Contains("Utlandsbetalningar") = True Then
                StringIn &= IIf(FirstIn, "", " OR ") & "transaktion_typ like 'utl%'"
                FirstIn = False
            End If



            If StringIn.Length > 0 Then f &= " and  (" & StringIn & ")"
        End If

        'Konto_nummer och clearing_nummer
        If tb_filter_kontonr.Text.Trim.Trim.Length > 1 Then f &= " and konto_nummer like '" & tb_filter_kontonr.Text.Trim.Trim.Replace("*", "%") & "' "
        If tb_filter_clearing.Text.Trim.Trim.Length > 1 Then f &= " and clearing_nummer like '" & tb_filter_clearing.Text.Trim.Trim.Replace("*", "%") & "' "


        Return f
    End Function







    'Fyller UtbetalningTreeView från databladet. (3 nivåer Root=Upphovsman,Child=BetalningsTyp,Level2=BetalningsID





    Private Sub UtbetalningTreeView_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs)
        'Hantera vilka andra noder som eventuellt ska kryssas i beroende på att denna blev ikryssad
        'För att undvika oändlig rekursion när man ändrar fler checked-värden ska man göra denna koll..
        If Not e.Action = TreeViewAction.Unknown Then
            TransTreeView.BeginUpdate()
            TransTreeView.CheckTreeNode_Children(e.Node)
            TransTreeView.EndUpdate()
            Status_Update()

        End If

    End Sub
    REM Filter hantering

    Private Sub dt_Filter_From_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dt_Filter_From.ValueChanged
        bUtför.ForeColor = Color.Black

    End Sub

    Private Sub dt_Filter_To_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dt_Filter_To.ValueChanged
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

    Private Sub cb_Filter_Transaktionstyp_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cb_Filter_Transaktionstyp.SelectedIndexChanged
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

    Private Sub tb_filter_clearing_TextChanged(sender As System.Object, e As System.EventArgs) Handles tb_filter_clearing.TextChanged
        bUtför.ForeColor = Color.Black 'bUtför.Enabled = True

    End Sub

    Private Sub tb_filter_kontonr_TextChanged(sender As System.Object, e As System.EventArgs) Handles tb_filter_kontonr.TextChanged
        bUtför.ForeColor = Color.Black 'bUtför.Enabled = True

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


    Private Sub cb_Filter_Status_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cb_Filter_Status.SelectedIndexChanged
        bUtför.ForeColor = Color.Black
    End Sub
    Private Sub AllaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Cursor = Cursors.WaitCursor
        TransTreeView.CheckAll(True)
        Status_Update()
        Cursor = Cursors.Default
    End Sub
    Private Sub AvmarkeraAllaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Cursor = Cursors.WaitCursor
        TransTreeView.CheckAll(False)
        Status_Update()
        Cursor = Cursors.Default
    End Sub
    Private Sub AktuellRadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TransTreeView.SelectedNode.Checked = Not TransTreeView.SelectedNode.Checked
        TransTreeView.CheckTreeNode_Children(TransTreeView.SelectedNode)
        Status_Update()
        '       UtbetalningTreeView._Agg_TreeNodeText(UtbetalningTreeView.SelectedNode)

        '        UtbetalningTreeView_Checked_TotalAmount_WorkSUM() ' Bakgrundssummering av totalen
    End Sub
    Private Sub AvslutaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AvslutaToolStripMenuItem.Click
        Me.Close()
    End Sub
    
    
    Private Sub Sort()
        Sort_By_Namn()
        
    End Sub
    Private Sub Sort_By_Namn()
        Cursor = Cursors.WaitCursor

        If cb_DescAsc.Text = "Fallande" Then
                TransTreeView.Sort_RootNodes(B2.GroupTreeView.SortColumn.Name, GroupTreeView.AscDesc.Desc)
            Else
                TransTreeView.Sort_RootNodes(B2.GroupTreeView.SortColumn.Name, GroupTreeView.AscDesc.Asc)


            End If
        Cursor = Cursors.Default

    End Sub
    



    Private Sub bUtför_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bUtför.Click
        refill_utbetalning_treeview()
        bUtför.ForeColor = Color.Gray
        ' bUtför.Enabled = False
    End Sub

    
    
    Private Sub InställningarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InställningarToolStripMenuItem.Click
        Dim fu As FormTransaktion_inställningar
        fu = New FormTransaktion_inställningar

        fu.Show()
        fu.TC_Konto.TabPages(1).Focus()
        fu.TC_Konto.SelectedTab = fu.TC_Konto.TabPages(1)
    End Sub

    Private Sub InställningarToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InställningarToolStripMenuItem1.Click
        Dim fu As FormTransaktion_inställningar
        fu = New FormTransaktion_inställningar

        fu.Show()
        fu.TC_Konto.TabPages(0).Focus()
        fu.TC_Konto.SelectedTab = fu.TC_Konto.TabPages(0)

    End Sub

    Private Sub skapaPG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles skapaPG.Click
        Dim row As DataRow = CType(TransTreeView.SelectedNode.Tag, DataRow)
        If row("Transaktion_typ").ToString.ToUpper.Trim = "PLUSGIRO" Then
            If (SFD_PG.ShowDialog = Windows.Forms.DialogResult.OK And SFD_PG.FileName.Length > 0) Then
                Dim outString As StringBuilder = New StringBuilder
                Dim sqlConn As SqlConnection = New SqlConnection(My.Settings.DBconnectionString)
                sqlConn.Open()

                'Markera som betald med filnamnet inkluderat
                Dim selectCommand As SqlCommand = New SqlCommand()
                selectCommand.CommandType = CommandType.Text
                selectCommand.CommandText = "SELECT * ,  Mottagare_Efternamn+', '+Mottagare_Förnamn+' ('+Mottagare_personnummer+')' Mottagar_grupp " & _
                            "from v_betalning_transaktion_post_filpost  where bt_id=" & row("bt_id") & _
                            "order by mottagare_efternamn,mottagare_förnamn,utbetalning_transaktion_skapad "
                selectCommand.Connection = sqlConn
                Dim reader As SqlDataReader = selectCommand.ExecuteReader
                Dim index As Integer = 0
                Dim netto_summa As String = ""
                Dim str As StringBuilder = New StringBuilder

                'Öppningspost
                'strDatum = RightB(Year(v_datum), 2 * 2) & IIf(Len(Month(v_datum)) = 1, "0" & Month(v_datum), Month(v_datum)) & IIf(Len(Day(v_datum)) = 1, "0" & Day(v_datum), Day(v_datum))
                'File.WriteLine(objPostGiro.IPostGiro_InledningsPost(txtKundNr.Text, strDatum, txtProduktionsNr.Text))
                'str = objStr.AddR(CStr(0), 1) & objStr.AddR(strKundNr, 5) & objStr.AddR(strDatum, 6) & _
                'objStr.AddR(intProdNummer, 1) & objStr.AddR("", 87)
                str.Length = 0
                str.Append("0")
                If My.Settings.PG_ALT = 2 Then
                    str.Append(My.Settings.PG_ALT2_Kundnummer.Trim.PadLeft(5, "0").Substring(0, 5))
                Else
                    str.Append(My.Settings.PG_ALT1_Kundnummer.Trim.PadLeft(5, "0").Substring(0, 5))
                End If
                str.Append(Today.ToShortDateString().Replace("-", "").Substring(2, 6))
                str.Append(Get_Produktionsnummer(Today, "PLUSGIRO"))
                str.Append("".PadLeft(87))
                'str.Append("-" & str.ToString.Length & "-")
                outString.AppendLine(str.ToString.ToUpper)

                ' Skriver Avsändarpost
                '-------------------------------------------------------------------------
                'File.WriteLine(objPostGiro.IPostGiro_Avsandarpost(txtKundNr.Text, RensaTkn(txtAvsandarkonto.Text), txtAvsandarKod.Text, _
                '            txtAvsandarbetack1.Text, txtAvsandarbetack2.Text, ""))
                'str = objStr.AddR(CStr(2), 1) & objStr.AddR(strKundNr, 5) & objStr.AddR(strAvsandarkonto, 10) & _
                'bjStr.AddR(strAvsandarkod, 2) & objStr.AddL(strAvsandabetackning1, 27) & objStr.AddL(strAvsandarbetackning2, 27) & _
                'objStr.AddR("", 19) & objStr.AddR(strAterforingskonto, 9)
                str.Length = 0
                str.Append("2")
                If My.Settings.PG_ALT = 2 Then
                    str.Append(My.Settings.PG_ALT2_Kundnummer.Trim.PadLeft(5, "0").Substring(0, 5))
                    str.Append(RensaTkn(My.Settings.PG_ALT2_Konto).Trim.PadLeft(10).Substring(0, 10))
                    str.Append(My.Settings.PG_ALT2_Kod.Trim.PadLeft(2).Substring(0, 2))
                    str.Append(My.Settings.PG_ALT2_Beteckning1.Trim.PadRight(27).Substring(0, 27))
                    str.Append(My.Settings.PG_ALT2_Beteckning2.Trim.PadRight(27).Substring(0, 27))

                Else
                    str.Append(My.Settings.PG_ALT1_Kundnummer.Trim.PadLeft(5, "0").Substring(0, 5))
                    str.Append(RensaTkn(My.Settings.PG_ALT1_Konto).Trim.PadLeft(10).Substring(0, 10))
                    str.Append(My.Settings.PG_ALT1_Kod.Trim.PadLeft(2).Substring(0, 2))
                    str.Append(My.Settings.PG_ALT1_Beteckning1.Trim.PadRight(27).Substring(0, 27))
                    str.Append(My.Settings.PG_ALT1_Beteckning2.Trim.PadRight(27).Substring(0, 27))

                End If

                str.Append("".PadLeft(19))
                str.Append(" ".PadLeft(9)) ' Återförningskonto
                'str.Append("-" & str.ToString.Length & "-")
                outString.AppendLine(str.ToString.ToUpper)


                'Lista
                
                While reader.Read
                    index += 1
                    If index = 1 Then
                        netto_summa = CInt(reader("BT_Netto_calc")).ToString
                    End If
                    If reader("BP_KONTO_TYP").ToString.ToUpper.Trim = "AVI" Then
                        str.Length = 0
                        str.Append("35").Append("".PadRight(5))
                        'Skapar ett för utbetalningspost som inte krockar om en Upphovsman har samma id som en rättighetshavare
                        If reader("mottagare_typ") = "R" Then : str.Append("1")
                        ElseIf reader("mottagare_typ") = "O" Then : str.Append("2")
                        Else : str.Append("0") : End If
                        str.Append(CInt(reader("betalningsmottagare_id")).ToString.PadLeft(9, "0")) ' 10 siffrig mottagarID
                        str.Append(reader("postnr").ToString.Trim.Replace(" ", "").PadRight(5).Substring(0, 5))
                        str.Append(New String(reader("mottagare_efternamn").ToString.Trim & ", " & reader("mottagare_förnamn").ToString.Trim & " " & IIf(reader("CareOf").ToString.Trim <> "", "C/O " & reader("CareOf").ToString.Trim, "")).PadRight(33).Substring(0, 33))
                        str.Append(New String(reader("adressrad1").ToString.Trim & " " & reader("adressrad2").ToString.Trim).PadRight(27).Substring(0, 27))
                        str.Append(reader("postadress").ToString.Trim.PadRight(13).Substring(0, 13))
                        str.Append("".PadLeft(5))
                        'str.Append("-" & str.ToString.Length & "-")
                        outString.AppendLine(str.ToString.ToUpper)

 

                    ElseIf reader("BP_KONTO_TYP").ToString.ToUpper.Trim = "PLUSGIRO" Then
                        '   File.WriteLine objPostGiro.IPostGiro_MottagarKontoinsattningPost(RensaTkn(rsUpph!kontonr), rsOmbud!enamn & ", " & rsOmbud!fnamn, RensaTkn(rsOmbud!kontonr))
                        'str = objStr.AddL("4", 1) & objStr.AddL("3", 1) & objStr.AddL("", 5) & objStr.AddR(strMottagarId, 10) & _
                        'objStr.AddL("", 0) & objStr.AddL(strMottagarNamn, 39) & objStr.AddL("", 44) '  &
                        ' Replace(objStr.AddR(strBankkontoNr, 16), " ", "0") & objStr.AddL("", 29)
                        str.Length = 0
                        str.Append("43").Append("".PadRight(5))
                        str.Append(RensaTkn(reader("konto_nummer")).ToString.PadLeft(10).Substring(0, 10)) ' 10 siffrig mottagarID
                        str.Append(New String(reader("mottagare_efternamn").ToString.Trim & ", " & reader("mottagare_förnamn").ToString.Trim).PadRight(39).Substring(0, 39))
                        str.Append("".PadRight(44))
                        'str.Append("-" & str.ToString.Length & "-")
                        outString.AppendLine(str.ToString.ToUpper)
                    Else
                        '                        outString.AppendLine("OKÄND KONTOTYP*********************DEBUG***************")
                    End If

                    'MEDDELANDEPOST
                    For i As Integer = 0 To Int((My.Settings.PG_Meddelande.Trim.Length - 1) / 80)
                        str.Length = 0
                        If reader("BP_KONTO_TYP").ToString.ToUpper.Trim = "AVI" Then
                            str.Append("45").Append("".PadRight(5))
                            If reader("mottagare_typ") = "R" Then : str.Append("1")
                            ElseIf reader("mottagare_typ") = "O" Then : str.Append("2")
                            Else : str.Append("0") : End If
                            str.Append(CInt(reader("betalningsmottagare_id")).ToString.PadLeft(9, "0")) ' 10 siffrig mottagarID
                        Else
                            str.Append("43").Append("".PadRight(5))
                            str.Append(RensaTkn(reader("konto_nummer")).ToString.PadLeft(10).Substring(0, 10)) ' 10 siffrig mottagarID
                        End If

                        str.Append(My.Settings.PG_Meddelande.ToUpper.Trim.Substring(i * 80, Math.Min(80, My.Settings.PG_Meddelande.Trim.Length - i * 80)).PadRight(80))
                        str.Append(" ".PadLeft(3))
                        'str.Append("-" & str.ToString.Length & "-")
                        outString.AppendLine(str.ToString.ToUpper)

                    Next

                    ' Beloppspost - debet
                    str.Length = 0
                    If reader("BP_KONTO_TYP").ToString.ToUpper.Trim = "AVI" Then
                        str.Append("55").Append("".PadRight(5))
                        If reader("mottagare_typ") = "R" Then : str.Append("1")
                        ElseIf reader("mottagare_typ") = "O" Then : str.Append("2")
                        Else : str.Append("0") : End If
                        str.Append(CInt(reader("betalningsmottagare_id")).ToString.PadLeft(9, "0")) ' 10 siffrig mottagarID
                    Else
                        str.Append("53").Append("".PadRight(5))
                        str.Append(RensaTkn(reader("konto_nummer")).ToString.PadLeft(10).Substring(0, 10)) ' 10 siffrig mottagarID
                    End If
                    str.Append(My.Settings.PG_Meddelande.Trim.ToUpper.PadRight(27).Substring(0, 27))
                    str.Append(CInt(reader("BP_NETTO")).ToString.Trim.PadLeft(9, "0")).Append("00")
                    str.Append(Today.ToShortDateString().Replace("-", "").Substring(2, 6))
                    str.Append("".PadRight(39))
                    'str.Append("-" & str.ToString.Length & "-")
                    outString.AppendLine(str.ToString.ToUpper)

                End While


                'Avslutningspost
                'IPostGiro_Summapost(txtKundNr.Text, RensaTkn(txtAvsandarkonto.Text), txtAvsandarKod.Text, dblTotBelopp)
                'str = objStr.AddL(7, 1) & objStr.AddL(strKundNr, 5) & objStr.AddR(strAvsandarkonto, 10) & _
                'objStr.AddL(strAvsandarkod, 2) & _
                'Replace(objStr.AddR(strTotalBelopp, 13), " ", "0") & objStr.AddL("", 69)
                str.Length = 0
                str.Append("7")
                If My.Settings.PG_ALT = 2 Then
                    str.Append(My.Settings.PG_ALT2_Kundnummer.Trim.PadLeft(5, "0").Substring(0, 5))
                    str.Append(RensaTkn(My.Settings.PG_ALT2_Konto).Trim.PadLeft(10).Substring(0, 10))
                    str.Append(My.Settings.PG_ALT2_Kod.Trim.PadLeft(2).Substring(0, 2))
                    
                Else
                    str.Append(My.Settings.PG_ALT1_Kundnummer.Trim.PadLeft(5, "0").Substring(0, 5))
                    str.Append(RensaTkn(My.Settings.PG_ALT1_Konto).Trim.PadLeft(10).Substring(0, 10))
                    str.Append(My.Settings.PG_ALT1_Kod.Trim.PadLeft(2).Substring(0, 2))

                End If
                str.Append(netto_summa.ToString.PadLeft(11, "0").Substring(0, 11))
                str.Append("00").Append("".PadRight(69, " "))
                'str.Append("-" & str.ToString.Length & "-")
                outString.AppendLine(str.ToString.ToUpper)




                'Välj fil
                reader.Close()

                File.WriteAllText(SFD_PG.FileName, outString.ToString(), Encoding.GetEncoding("iso-8859-1"))
                selectCommand = New SqlCommand()
                Dim parmID As SqlParameter

                selectCommand.CommandType = CommandType.StoredProcedure
                selectCommand.CommandText = "[sp_betalning_transaktion_Close]"
                selectCommand.Parameters.Clear()
                parmID = selectCommand.Parameters.Add("betalning_transaktion_id", SqlDbType.Int)
                parmID.Value = row("bt_id")
                '@fil_namn as varchar(100)='X.XX',
                parmID = selectCommand.Parameters.Add("fil_namn", SqlDbType.VarChar, 100)
                parmID.Value = SFD_PG.FileName


                '@Avsändare as varchar(30)='BUS'
                parmID = selectCommand.Parameters.Add("Avsändare", SqlDbType.VarChar, 30)
                If My.Settings.PG_ALT = 2 Then parmID.Value = My.Settings.PG_ALT2_Kundnummer.Trim Else parmID.Value = My.Settings.PG_ALT2_Kundnummer.Trim

                System.Console.WriteLine(selectCommand.CommandText.ToString & " " & parmID.Value)
                selectCommand.Connection = sqlConn
                reader = selectCommand.ExecuteReader
                reader.Read()
                reader.Close()
                sqlConn.Close()
                refill_utbetalning_treeview()
                bUtför.ForeColor = Color.White : Status_Update()
                sync_busas_markera_betald(row("bt_id"))


            End If


        Else
            MsgBox("Ej Plusgiro fil")
        End If

    End Sub
    Private Sub sync_busas_markera_betald(ByVal betalningstransaktion_ID As Integer)

        Dim outString As StringBuilder = New StringBuilder
        Dim sqlConn As SqlConnection = New SqlConnection(My.Settings.DBconnectionString)
        sqlConn.Open()
        Dim selectCommand As SqlCommand = New SqlCommand()

        Dim parmID As SqlParameter

        selectCommand.CommandType = CommandType.StoredProcedure
        selectCommand.CommandText = "[sp_synk_markera_betalning]"
        selectCommand.Parameters.Clear()
        parmID = selectCommand.Parameters.Add("betalning_transaktion_id", SqlDbType.Int)
        parmID.Value = betalningstransaktion_ID
  
        System.Console.WriteLine(selectCommand.CommandText.ToString & " " & parmID.Value)
        selectCommand.Connection = sqlConn
        Dim reader As SqlDataReader = selectCommand.ExecuteReader
        reader.Read()
        reader.Close()
        sqlConn.Close()

    End Sub
    Private Sub skapaBG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SkapaBG.Click
        Dim row As DataRow = CType(TransTreeView.SelectedNode.Tag, DataRow)
        If row("Transaktion_typ").ToString.ToUpper.Trim = "BANKGIRO" Then
            If (SFD_BG.ShowDialog = Windows.Forms.DialogResult.OK And SFD_BG.FileName.Length > 0) Then
                Dim outString As StringBuilder = New StringBuilder
                'outString.Append("Början").AppendLine(My.Settings.BG_Meddelande)
                'Anropa rätt lista med summeringarna i listan (samma som huvudanropet
                'generera rätt löpnummer(skall ske i inställningar

                Dim sqlConn As SqlConnection = New SqlConnection(My.Settings.DBconnectionString)
                sqlConn.Open()
                'Markera som betald med filnamnet inkluderat
                Dim selectCommand As SqlCommand = New SqlCommand()
                selectCommand.CommandType = CommandType.Text
                selectCommand.CommandText = "SELECT * ,  Mottagare_Efternamn+', '+Mottagare_Förnamn+' ('+Mottagare_personnummer+')' Mottagar_grupp " & _
                            "from v_betalning_transaktion_post_filpost  where bt_id=" & row("bt_id") & _
                            "order by mottagare_efternamn,mottagare_förnamn,utbetalning_transaktion_skapad "
                selectCommand.Connection = sqlConn
                Dim reader As SqlDataReader = selectCommand.ExecuteReader
                Dim index As Integer = 0
                Dim produktionsnummer = Get_Produktionsnummer(Today, "BANKGIRO")
                Dim netto_summa As String = ""

                '-----------------------------------------------------------------
                ' Skriver Öppningspost (TK11)
                '-----------------------------------------------------------------
                'file.WriteLine(objBankGiro.IBankGiro_Oppningspost(RensaTkn(txtBankGiroNr.text), strDatum, strBetalDatum, "SEK"))
                '                Str = objStr.AddR(CStr(11), 2) & Replace(objStr.AddR(strBankGiroNr, 10), " ", "0") &
                ' objStr.AddR(strdATUM, 6) & _
                '"LEVERANTÖRSBETALNINGAR" & objStr.AddR(strBetalDag, 6) & _
                'objStr.AddR(" ", 13) & objStr.AddR("SEK", 3) & objStr.AddR(" ", 18)
                Dim str As StringBuilder = New StringBuilder

                str.Append("11").Append(My.Settings.BG_ALT1_BankGiro.Trim.PadLeft(10, "0").Substring(0, 10))
                str.Append(Today.ToShortDateString().Replace("-", "").Substring(2, 6))
                str.Append("LEVERANTÖRSBETALNINGAR")
                str.Append(Today.ToShortDateString().Replace("-", "").Substring(2, 6).PadRight(6 + 13)) '6 tkn
                str.Append("SEK".PadRight(3 + 18))
                'str.Append("-" & str.ToString.Length & "-")
                outString.AppendLine(str.ToString.ToUpper)

                '-----------------------------------------------------------------
                ' Skriver Rubrik (TK13)
                '-----------------------------------------------------------------
                str.Length = 0
                'File.WriteLine(objBankGiro.IBankGiro_Rubrik(txtRubrik.text, txtRubrikNetto.text))
                '                str = objStr.AddR(CStr(13), 2) &
                ' objStr.AddL(strRubrik, 25) & objStr.AddR(strAviRubrik, 12) & _
                'objStr.AddR(" ", 41)
                str.Append("13").Append(My.Settings.BG_Rubrik.Trim.PadRight(25).Substring(0, 25)).Append(My.Settings.BG_Nettorubrik.Trim.PadLeft(12).Substring(0, 12).PadRight(12 + 41))
                'str.Append("-" & str.ToString.Length & "-")
                outString.AppendLine(str.ToString.ToUpper)



                While reader.Read
                    index += 1
                    If index = 1 Then
                        netto_summa = CInt(reader("BT_Netto_calc")).ToString
                    End If
                    If reader("BP_KONTO_TYP").ToString.ToUpper.Trim = "AVI" Then
                        '-------------------------------------------------------------
                        ' Skriver namn (TK 26)
                        '-------------------------------------------------------------
                        'File.WriteLine(objBankGiro.IBankGiro_Namn(intUtbetalningsNr, rsUpph!enamn & ", " & rsUpph!fnamn, IIf(rs!CareOf <> "", "C/O " & rs!CareOf, "")))
                        'str = objStr.AddL("26", 2) & 
                        'objStr.AddL("0000", 4) & Replace(objStr.AddR(strUtbetalningsNr, 5), " ", "0") & _
                        '  " " & objStr.AddL(strNamn, 35) & objStr.AddL(strXNamn, 33)
                        str.Length = 0
                        '       str.AppendLine("AVI")
                        str.Append("26").Append(produktionsnummer.ToString.PadLeft(5, "0").Substring(0, 5) & index.ToString.PadLeft(4, "0"))
                        str.Append(" ")
                        str.Append((New String(reader("mottagare_efternamn").ToString.Trim & ", " & reader("mottagare_förnamn").ToString.Trim)).PadRight(35).Substring(0, 35))

                        'INgen " " & C/Onamn
                        str.Append(" ".PadRight(33))
                        '  str.Append("-" & str.ToString.Length & "-")
                        outString.AppendLine(str.ToString.ToUpper)
                        '-------------------------------------------------------------
                        ' Skriver adress (TK 27)
                        '-------------------------------------------------------------
                        'File.WriteLine(objBankGiro.IBankGiro_Adress(intUtbetalningsNr, Trim(rs!Adressrad1 & " " & rs!Adressrad2), rs!PostNr, rs!PostAdress))
                        'str = objStr.AddL("27", 2) & objStr.AddL("0000", 4) & Replace(objStr.AddR(strUtbetalningNr, 5), " ", "0") & _
                        '          " " & objStr.AddL(strGatuAdress, 35) & objStr.AddL(Replace(strPostNr, " ", ""), 5) & _
                        '         objStr.AddL(strPostAdress, 20) & objStr.AddL("", 8)
                        str.Length = 0
                        str.Append("27").Append(produktionsnummer.ToString.PadLeft(5, "0").Substring(0, 5) & index.ToString.PadLeft(4, "0"))
                        str.Append(" ")
                        str.Append(New String(reader("adressrad1").trim & " " & reader("adressrad2").trim).Trim.PadRight(35).Substring(0, 35))
                        str.Append(RensaTkn(reader("postnr").ToString).Trim.PadRight(5).Substring(0, 5))
                        str.Append(reader("Postadress").ToString.Trim.PadRight(20).Substring(0, 20))
                        str.Append(" ".PadRight(8))

                        '  str.Append("-" & str.ToString.Length & "-")
                        outString.AppendLine(str.ToString.ToUpper)

                        '-------------------------------------------------------------
                        ' Skriver kontantbetalningsuppdrag (TK 14)
                        '-------------------------------------------------------------
                        'File.WriteLine(objBankGiro.IBankGiro_BetalningsUppdrag(txtSpec.text, belopp, strBetalDatum, "", RensaTkn(rsUpph!kontonr), CStr(intUtbetalningsNr)))
                        'str = objStr.AddR(CStr(14), 2)
                        '  If strBankGiroNr <> "" Then
                        ' str = str & Replace(objStr.AddR(strBankGiroNr, 10), " ", 0)
                        'Else
                        '   str = str & objStr.AddL("000", 3) & Replace(objStr.AddR(strUtbetalningsNr, 6), " ", "0") & " "
                        '& objStr.AddL(objStr.Check(strUtbetalningsNr), 1)
                        'End If

                        'str = str & objStr.AddL(strBetalningsSpec, 25) & Replace(objStr.AddR(strBelopp, 12), " ", "0") 
                        '& objStr.AddR(strBetalDatum, 6) & _
                        '               objStr.AddR(" ", 5) & objStr.AddR(strAvsandarInfo, 20)
                        str.Length = 0
                        str.Append("14")
                        If reader("konto_nummer").ToString.Length > 0 Then
                            str.Append(reader("kontonummer").ToString.Trim.PadLeft(10, "0").Substring(0, 10))
                        Else
                            str.Append(produktionsnummer.ToString.PadLeft(5, "0").Substring(0, 5) & index.ToString.PadLeft(4, "0")).Append(" ")
                        End If
                        str.Append(My.Settings.BG_Specifikation.PadRight(25).Substring(0, 25))
                        str.Append((CInt(reader("BP_Netto")).ToString() & "00").PadLeft(12, "0"))
                        str.Append(Today.ToShortDateString().Replace("-", "").Substring(2, 6))

                        str.Append(" ".PadRight(5))
                        str.Append(My.Settings.BG_Rubrik.PadRight(20).Substring(0, 20))

                        '  str.Append("-" & str.ToString.Length & "-")
                        outString.AppendLine(str.ToString.ToUpper)

                        '-------------------------------------------------------------
                        ' Skriver information (TK 25)
                        '-------------------------------------------------------------
                        'intRows = IIf(Len(txtBankGiroMeddelande.text) / 50 > Int(Len(txtBankGiroMeddelande.text) / 50), Int(Len(txtBankGiroMeddelande.text) / 50) + 1, Int(Len(txtBankGiroMeddelande.text) / 50))
                        'For index = 0 To intRows - 1
                        'File.WriteLine(objBankGiro.IBankGiro_InformationsPost(Mid(txtBankGiroMeddelande, index * 50 + 1, 50), "", CStr(intUtbetalningsNr)))
                        'str = str & objStr.AddL("000", 3) & Replace(objStr.AddR(strUtbetalningsNr, 6), " ", "0") & _
                        'objStr.AddL(objStr.Check(strUtbetalningsNr), 1) & objStr.AddL(strBetalningsSpec, 50) & objStr.AddR(" ", 18)
                        '                        Next index
                        For i As Integer = 0 To Int((My.Settings.BG_Meddelande.Trim.Length - 1) / 50)
                            str.Length = 0
                            str.Append("25").Append(produktionsnummer.ToString.PadLeft(5, "0").Substring(0, 5) & index.ToString.PadLeft(4, "0")).Append(" ") 'ingen checksiffra
                            str.Append(My.Settings.BG_Meddelande.Trim.Substring(i * 50, Math.Min(50, My.Settings.BG_Meddelande.Trim.Length - i * 50)).PadRight(50))
                            str.Append(" ".PadLeft(18))
                            '                       str.Append("-" & str.ToString.Length & "-")
                            outString.AppendLine(str.ToString.ToUpper)

                        Next

                    ElseIf reader("BP_KONTO_TYP").ToString.ToUpper.Trim = "BANKGIRO" Then
                        '-------------------------------------------------------------
                        ' Skriver kontantbetalningsuppdrag (TK 14)
                        '-------------------------------------------------------------
                        str.Length = 0
                        str.Append("14")
                        If reader("konto_nummer").ToString.Length > 0 Then
                            str.Append(RensaTkn(reader("konto_nummer").ToString).Trim.PadLeft(10, "0"))
                        Else
                            str.Append(produktionsnummer.ToString.PadLeft(5, "0").Substring(0, 5) & index.ToString.PadLeft(4, "0")).Append(" ")
                        End If
                        str.Append(My.Settings.BG_Specifikation.PadRight(25).Substring(0, 25))
                        str.Append((CInt(reader("BP_Netto")).ToString() & "00").PadLeft(12, "0"))
                        str.Append(Today.ToShortDateString().Replace("-", "").Substring(2, 6))

                        str.Append(" ".PadRight(5))
                        str.Append(My.Settings.BG_Rubrik.PadRight(20).Substring(0, 20))

                        '                    str.Append("-" & str.ToString.Length & "-")
                        outString.AppendLine(str.ToString.ToUpper)

                        '-------------------------------------------------------------
                        ' Skriver Informationspost (TK 25) med kontonummer
                        '-------------------------------------------------------------
                        ' str = str & Replace(objStr.AddR(strBankGiroNr, 10), " ", "0") & _
                        'objStr.AddL(strBetalningsSpec, 50) & objStr.AddR(" ", 18)
                        For i As Integer = 0 To Int((My.Settings.BG_Meddelande.Trim.Length - 1) / 50)
                            str.Length = 0
                            str.Append("25").Append(RensaTkn(reader("konto_nummer").ToString).Trim.PadLeft(10, "0").Substring(0, 10)) 'ingen checksiffra
                            str.Append(My.Settings.BG_Meddelande.Trim.Substring(i * 50, Math.Min(50, My.Settings.BG_Meddelande.Trim.Length - i * 50)).PadRight(50))
                            str.Append(" ".PadLeft(18))
                            '                         str.Append("-" & str.ToString.Length & "-")
                            outString.AppendLine(str.ToString.ToUpper)

                        Next
                    ElseIf reader("BP_KONTO_TYP").ToString.ToUpper.Trim = "BANKKONTO" Then
                        '        outString.AppendLine("BANKKONTO")
                        '-------------------------------------------------------------
                        ' Skriver Kontonummer (TK 40)
                        '-------------------------------------------------------------
                        'File.WriteLine(objBankGiro.IBankGiro_KontoNr(intUtbetalningsNr, rsUpph!ClearingsNr, RensaTkn(rsUpph!kontonr)))
                        '   str = objStr.AddL("40", 2) & objStr.AddL("0000", 4) & Replace(objStr.AddR(strUtbetalningsNr, 5), " ", "0") & _
                        '  " " & objStr.AddL(strClearingNr, 4) & Replace(objStr.AddR(strBankkontoNr, 12), " ", 0) & _
                        '  objStr.AddL("", 12) & objStr.AddL(" ", 1) & objStr.AddL("", 39)
                        str.Length = 0
                        str.Append("40")
                        str.Append(produktionsnummer.ToString.PadLeft(5, "0").Substring(0, 5) & index.ToString.PadLeft(4, "0")).Append(" ")
                        str.Append(reader("clearing_nummer").ToString.Trim.PadRight(4, " ").Substring(0, 4))
                        str.Append(RensaTkn(reader("konto_nummer").ToString).Trim.Replace(" ", "0").PadLeft(12, "0").Substring(0, 12))
                        str.Append(" ".PadRight(52, " "))
                        '                      str.Append("-" & str.ToString.Length & "-").Append("#" & reader("clearing_nummer").ToString & "#" & RensaTkn(reader("konto_nummer").ToString).Trim & "#")
                        outString.AppendLine(str.ToString.ToUpper)


                        '-------------------------------------------------------------
                        ' Kontobetalning (TK 14)
                        '-------------------------------------------------------------
                        'File.WriteLine(objBankGiro.IBankGiro_BetalningsUppdrag(txtSpec.Text, belopp, strBetalDatum, "", "", CStr(intUtbetalningsNr)))
                        str.Length = 0
                        str.Append("14")
                        str.Append(produktionsnummer.ToString.PadLeft(5, "0").Substring(0, 5) & index.ToString.PadLeft(4, "0")).Append(" ")
                        str.Append(My.Settings.BG_Specifikation.PadRight(25).Substring(0, 25))
                        str.Append((CInt(reader("BP_Netto")).ToString() & "00").PadLeft(12, "0"))
                        str.Append(Today.ToShortDateString().Replace("-", "").Substring(2, 6))

                        str.Append(" ".PadRight(5))
                        str.Append(My.Settings.BG_Rubrik.PadRight(20).Substring(0, 20))

                        '                       str.Append("-" & str.ToString.Length & "-")
                        outString.AppendLine(str.ToString.ToUpper)


                    Else
                        '                        outString.AppendLine("OKÄND KONTOTYP*********************DEBUG***************")
                    End If






                End While

                '   File.WriteLine objBankGiro.IBankGiro_Slutsumma(RensaTkn(txtBankGiroNr.Text), intUtbetalningsNr, dblTotBelopp)
                'str = objStr.AddR(CStr(29), 2) & Replace(objStr.AddR(strBankGiroNr, 10), " ", "0") & _
                'Replace(objStr.AddR(strAntalPoster, 8), " ", "0") & _
                'Replace(objStr.AddR(strTotBelopp, 12), " ", "0") & 
                'objStr.AddR(" ", 1) & objStr.AddR(" ", 47)
                outString.Append("29")
                If My.Settings.BG_ALT = 2 Then

                    outString.Append(My.Settings.BG_ALT2_BankGiro.ToString.Trim.PadLeft(10, "0").Substring(0, 10))
                Else
                    outString.Append(My.Settings.BG_ALT1_BankGiro.ToString.Trim.PadLeft(10, "0").Substring(0, 10))
                End If

                outString.Append(index.ToString.PadLeft(8, "0"))
                outString.Append(netto_summa.ToString.PadLeft(10, "0").Substring(0, 10)).Append("00").AppendLine(" ".PadLeft(48, " "))
                reader.Close()
                File.WriteAllText(SFD_BG.FileName, outString.ToString(), Encoding.GetEncoding("iso-8859-1"))

                '                Dim selectCommand As SqlCommand = New SqlCommand()
                selectCommand = New SqlCommand()
                Dim parmID As SqlParameter

                selectCommand.CommandType = CommandType.StoredProcedure
                selectCommand.CommandText = "[sp_betalning_transaktion_Close]"
                selectCommand.Parameters.Clear()
                parmID = selectCommand.Parameters.Add("betalning_transaktion_id", SqlDbType.Int)
                parmID.Value = row("bt_id")
                '@fil_namn as varchar(100)='X.XX',
                parmID = selectCommand.Parameters.Add("fil_namn", SqlDbType.VarChar, 100)
                parmID.Value = SFD_BG.FileName


                '@Avsändare as varchar(30)='BUS'
                parmID = selectCommand.Parameters.Add("Avsändare", SqlDbType.VarChar, 30)
                If My.Settings.BG_ALT = 2 Then parmID.Value = My.Settings.BG_ALT2_BankGiro.Trim Else parmID.Value = My.Settings.BG_ALT1_BankGiro.Trim

                System.Console.WriteLine(selectCommand.CommandText.ToString & " " & parmID.Value)
                selectCommand.Connection = sqlConn
                reader = selectCommand.ExecuteReader
                reader.Read()
                reader.Close()
                sqlConn.Close()
                sync_busas_markera_betald(row("bt_id"))
                refill_utbetalning_treeview()
                bUtför.ForeColor = Color.White : Status_Update()



            End If
        Else
            MsgBox("Ej Bankgiro fil")

        End If
    End Sub

    Private Sub skapaUTL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles skapaUTL.Click
        Dim row As DataRow = CType(TransTreeView.SelectedNode.Tag, DataRow)
        Dim sqlConn As SqlConnection = New SqlConnection(My.Settings.DBconnectionString)
        sqlConn.Open()
        If row("Transaktion_typ").ToString.ToUpper.Trim = "UTLAND" Then
            Dim selectCommand As SqlCommand = New SqlCommand()
            Dim parmID As SqlParameter

            selectCommand.CommandType = CommandType.StoredProcedure
            selectCommand.CommandText = "[sp_betalning_transaktion_Close]"
            selectCommand.Parameters.Clear()
            parmID = selectCommand.Parameters.Add("betalning_transaktion_id", SqlDbType.Int)
            parmID.Value = row("bt_id")
            '@fil_namn as varchar(100)='X.XX',
            Dim filnamn As String = InputBox("Namn på utlandsfilen", "Utlandsfil", "XX.UTL")
            parmID = selectCommand.Parameters.Add("fil_namn", SqlDbType.VarChar, 100)
            parmID.Value = filnamn
            System.Console.WriteLine(selectCommand.CommandText.ToString & " " & parmID.Value)
            selectCommand.Connection = sqlConn
            Dim reader As SqlDataReader = selectCommand.ExecuteReader
            reader.Read()
            reader.Close()
            sqlConn.Close()
            sync_busas_markera_betald(row("bt_id"))
            refill_utbetalning_treeview()
            bUtför.ForeColor = Color.White : Status_Update()
        Else
            MsgBox("Ej Utlandsfil")

        End If

    End Sub
    Private Function RensaTkn(ByVal strString As String) As String
        '*********************************************************************************
        '*
        '* Tar bort alla tecken från en sträng som inte är 0 - 9
        '*
        '*********************************************************************************
        '*
        Dim I As Integer
        Dim Outstr As StringBuilder = New StringBuilder("", 100)

        For I = 0 To Len(strString) - 1
            If IsNumeric(strString.Substring(I, 1)) Then Outstr.Append(strString.Substring(I, 1))
        Next I
        Return Outstr.ToString
    End Function
    Function Get_Produktionsnummer(ByVal d As Date, ByVal typ As String) As Int16
        Dim sqlConn As SqlConnection = New SqlConnection(My.Settings.DBconnectionString)
        sqlConn.Open()
        Dim selectCommand As SqlCommand = New SqlCommand()
        Dim parmID As SqlParameter

        selectCommand.CommandType = CommandType.StoredProcedure
        'exec sp_transaktion_get_max_Refnumber '2010-03-09','PlusGIRO',@nr output
        selectCommand.CommandText = "[sp_transaktion_get_max_Refnumber]"
        selectCommand.Parameters.Clear()
        parmID = selectCommand.Parameters.Add("datum", SqlDbType.DateTime)
        parmID.Value = d.ToShortDateString
        parmID = selectCommand.Parameters.Add("typ", SqlDbType.Char)
        parmID.Value = typ
        parmID = selectCommand.Parameters.Add("retval", SqlDbType.Int)
        parmID.Direction = ParameterDirection.Output
        'parmID.Value = "PLUSGIRO"

        System.Console.WriteLine(selectCommand.CommandText.ToString & " " & parmID.Value)
        selectCommand.Connection = sqlConn
        Dim reader As SqlDataReader = selectCommand.ExecuteReader
        Return CInt(parmID.Value) + 1

        reader.Close()
        sqlConn.Close()


        Return 1
    End Function

    Private Sub Rapport_Bokföring_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rapport_Bokföring.Click
        Dim row As DataRow = CType(TransTreeView.SelectedNode.Tag, DataRow)
        Dim f As FormTransaktion_Bokföringsunderlag
        f = New FormTransaktion_Bokföringsunderlag
        f.setBT_ID(row("bt_id"))
        f.Show()

    End Sub


    Private Sub Rapport_Prognos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rapport_Prognos.Click
        Dim row As DataRow = CType(TransTreeView.SelectedNode.Tag, DataRow)
        Dim f As FormTransaktion_Bokföringsunderlag
        f = New FormTransaktion_Bokföringsunderlag
        f.setBT_ID(row("bt_id"))
        f.Show()

    End Sub

   
    
    
    Private Sub TransTreeView_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TransTreeView.AfterSelect
        Status_Update()
    End Sub


End Class
