Imports System
Imports System.ComponentModel
Imports System.Threading
Imports System.Windows.Forms
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Public Class FormUnderlag


    Private paymentDao As PaymentBaseDAO 'Ett objekt som sköter operationer mot databasen
    Private dataTable As DataTable 'Datatabellen som ligger till grund för trädinfon
    Private dataView As DataView
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        'Sort_Namn_Ned.Checked = False : Sort_Namn_Upp.Checked = False
        'Filter_Efternamn_LT_MenuItem.Checked = False
        Filter_Upphovsman_Efternamn_LT.SelectedIndex = 27
        '       Filter_Efternamn_GT_MenuItem.Checked = False : 
        Filter_Upphovsman_Efternamn_GT.SelectedIndex = 0
        Filter_Datum_GT_MenuItem.Checked = True
        Filter_Datum_GT.Text = Date.Today.Subtract(New TimeSpan(14, 0, 0, 0)).ToShortDateString
        Filter_Datum_LT_MenuItem.Checked = True
        Filter_Datum_LT.Text = Date.Today.ToShortDateString
        'Filter_Totalsumma_GT_MenuItem.Checked = True
        'Filter_Förnamn_like_MenuItem.Checked = True : Filter_Förnamn_like.Text = "Per*"
        'Filter_Datum_LT_MenuItem.Text = "Datum < " & If(IsDate(Filter_Datum_LT.ToString), Filter_Datum_LT.ToString, "######") & Space(14 - Filter_Datum_LT.Text.Length)
        'Filter_Datum_GT_MenuItem.Text = "Datum > " & If(IsDate(Filter_Datum_GT.ToString), Filter_Datum_GT.ToString, "######") & Space(14 - Filter_Datum_GT.Text.Length)
        'Filter_Totalsumma_GT_MenuItem.Text = "Totalsumma > " & IIf(IsNumeric(Filter_Totalsumma_GT.Text), Filter_Totalsumma_GT.Text, 0) & Space(6 - Filter_Totalsumma_GT.Text.Length)
        refill_payment_treeview()

        bUtför.ForeColor = Color.White
        Status_Update()


    End Sub



    Public Sub refill_payment_treeview()
        Status_Update()
        Cursor = Cursors.WaitCursor

        Dim whereString As String = Get_where_string()
        Dim paymentDataSet As DataSet = New DataSet
        ' Dim connectionString As String = resources.ResourceManager.'"Data Source=192.168.0.38;Initial Catalog=B2Arbete;user id=Developer;Connection Timeout=120;Password=Developer;"
        Dim sqlConn As SqlConnection = New SqlConnection(My.Settings.DBconnectionString)
        Dim selectCommand As SqlCommand = New SqlCommand()
        selectCommand.CommandType = CommandType.Text
        selectCommand.CommandText = "SELECT * ,case when AntalMottagare=0 then 0 when DödsboEjKlart=1 then 0 else 1 end checkable,  Efternamn+', '+Förnamn+' ('+personnummer+')' Namn_Personnummer_grupp " & _
                    "into #t from v_betalning_underlag_Ej_Godkända  where " & Get_where_string() & _
                    "select (select sum(t2.belopp) from #t t2 where t2.[upphovsman_id]=t.[upphovsman_id]  ) T_Belopp,* from #t t " & _
                    "where (select sum(t2.belopp) from #t t2 where t2.[upphovsman_id]=t.[upphovsman_id]  ) > " & Get_Filter_TotalSumma() & _
                    "order by efternamn,förnamn,[registrerat datum] " & _
                    "drop table #t"

        ' "SELECT [id],[betalning_typ],[upphovsman_id],[belopp],[betalningsdatum],[kommentar],[Personnummer],[förnamn],[efternamn],[Registrerat datum] ,  Efternamn+', '+Förnamn+' ('+personnummer+')' Namn_Personnummer_grupp,* from v_betalning_underlag where " & Status_get_wherestring() & " order by efternamn,förnamn,[registrerat datum]"
        System.Console.WriteLine(selectCommand.CommandText.ToString)
        Dim s As Stopwatch = New Stopwatch
        s.Start()

        pbProgress.Visible = True
        pbProgress.Style = ProgressBarStyle.Marquee
        pbProgress.MarqueeAnimationSpeed = 1000
        selectCommand.Connection = sqlConn
        'Console.WriteLine("1.Innan New DataAdapter: " & s.ElapsedMilliseconds)
        'För att kunna fylla data till DataSetet behövs en SqlDataAdapter
        Dim dataAdapter As SqlDataAdapter = New SqlDataAdapter()
        'Console.WriteLine("2.Efter New DataAdapter: " & s.ElapsedMilliseconds) : s.Reset() : s.Start()

        dataAdapter.SelectCommand = selectCommand

        Try
            'Försök att hämta data från tabellen till DataSetet ds.
            'Console.WriteLine("3.Innan DA fill: " & s.ElapsedMilliseconds) : 
            s.Reset() : s.Start()
            dataAdapter.Fill(paymentDataSet)
            Console.WriteLine("4.Efter DA fill: " & s.ElapsedMilliseconds) : s.Reset() : s.Start()

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
            ' Console.WriteLine("6.Efter datatable: " & s.ElapsedMilliseconds) : s.Reset() : s.Start()
            dataView = New DataView(dataTable)
            'Fyll trädnodernas data med data från den sorterade tabellens
            'Console.WriteLine("7.Efter fill innan set dataview : " & s.ElapsedMilliseconds) : s.Reset() : s.Start()
            PaymentTreeView.SetDataView(dataView)
            'Console.WriteLine("8.Efter dataview: " & s.ElapsedMilliseconds) : s.Reset() : s.Start()
            Dim GroupNames() As String = {"Namn_Personnummer_grupp", "Betalning_typ", "ID"}
            PaymentTreeView.setGroupNames(GroupNames)
            PaymentTreeView.setColSumName("Belopp")
            PaymentTreeView.setColGroupSumName("T_Belopp") 'Gruppsumma att sortera på
            pbProgress.Visible = True
            pbProgress.Style = ProgressBarStyle.Blocks
            pbProgress.Value = 0
            'Console.WriteLine("9.Innan PTV fill: " & s.ElapsedMilliseconds) : s.Reset() : s.Start()
            PaymentTreeView.Fill(pbProgress)
            Console.WriteLine("10.Efter PTV fill: " & s.ElapsedMilliseconds) : s.Reset() : s.Start()
            pbProgress.Style = ProgressBarStyle.Marquee
            pbProgress.MarqueeAnimationSpeed = 1000

            Sort()
            Console.WriteLine("11.Efter SORTERING: " & s.ElapsedMilliseconds) : s.Reset() : s.Start()
            Cursor = Cursors.Default

        End Try
        Status_Update()
        pbProgress.Visible = False
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


        'Visa endast korrekta rader som kan klickas i.
        If Filter_Checkable_Only.Checked = True Then
            lbl_Filter_Checkable_only.Text = ""
        Else
            lbl_Filter_Checkable_only.Text = "Visar även felaktiga mottagare"
        End If
        'Filtertext för efternamn
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
        'Filter text för Belopp
        If Filter_Totalsumma_GT_MenuItem.Checked = True And IsNumeric(Filter_Totalsumma_GT.Text) Then lblFilter_Belopp.Text = " Belopp>= " & Filter_Totalsumma_GT.Text Else lblFilter_Belopp.Text = ""
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
        'Betalning_typ
        lblFilter_Betalningstyp.Text = ""

        If Filter_Utbetalningstyp_Menutem.Checked = True Then
            If Filter_Följerätt.Checked = True Or Filter_IR.Checked = True Or Filter_IR_Foto.Checked = True Or _
               Filter_IV.Checked = True Or Filter_KR.Checked = True Or Filter_Repro.Checked = True Or _
               Filter_ST.Checked = True Or Filter_TV.Checked = True Or Filter_IR_Bildbyrå.Checked = True Or _
               Filter_IRDAGP_Foto.Checked = True Or Filter_IRDAGP_Illust.Checked = True Then
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

        'Totalsummesammansräkningar
        lblAntalRader.Text = PaymentTreeView.GetCheckedRows().ToString("N0") & " av " & PaymentTreeView.GetTotalRows.ToString("N0") & " rader."
        lblAntal_Upphovsmän.Text = PaymentTreeView.Nodes.Count.ToString("N0") & " st. upphovsmän."
        lblTotalAmount.Text = Math.Round(PaymentTreeView.GetCheckedTotalAmount()).ToString("N0") & " kr (av " & Math.Round(PaymentTreeView.GetTotalAmount()).ToString("N0") & " kr.)"
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
            f &= IIf(first, "", " and ") & "AntalMottagare>0 and DödsboEjKlart=0 " : first = False
        End If

        'Namnfilter

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
        If filter_kommentar_like_MenuItem.Checked = True Then
            If filter_kommentar_like.Text.Length = 0 Then filter_kommentar_like.Text = "*"
            f &= IIf(first, "", " and ")
            f &= "kommentar like '"
            f &= filter_kommentar_like.Text.Replace("*", "%")
            f &= "' "
            first = False
        End If
        If Filter_Utbetalningstyp_Menutem.Checked = True Then
            If Filter_Följerätt.Checked = True Or Filter_IR.Checked = True Or Filter_IR_Foto.Checked = True Or _
               Filter_IV.Checked = True Or Filter_KR.Checked = True Or Filter_Repro.Checked = True Or _
               Filter_IR_Bildbyrå.Checked = True Or Filter_IRDAGP_Illust.Checked = True Or Filter_IRDAGP_Foto.Checked = True Or _
                       Filter_ST.Checked = True Or Filter_TV.Checked = True Or Filter_IR_Bildbyrå.Checked = True Then

                Dim FirstIn As Boolean = True
                Dim StringIn As String = " ("
                If Filter_Följerätt.Checked = True Then StringIn &= IIf(FirstIn, "", " OR ") & " Betalning_typ = 'Följerätt'" : FirstIn = False
                If Filter_IR.Checked = True Then StringIn &= IIf(FirstIn, "", " OR ") & " Betalning_typ = 'IR'" : FirstIn = False
                If Filter_IR_Foto.Checked = True Then StringIn &= IIf(FirstIn, "", " OR ") & " Betalning_typ = 'IR-FOTO'" : FirstIn = False
                If Filter_IRDAGP_Foto.Checked = True Then StringIn &= IIf(FirstIn, "", " OR ") & " Betalning_typ = 'IRDAGP-FOTO'" : FirstIn = False
                If Filter_IRDAGP_Illust.Checked = True Then StringIn &= IIf(FirstIn, "", " OR ") & " Betalning_typ = 'IRDAGP-ILLUST.'" : FirstIn = False
                If Filter_IR_Bildbyrå.Checked = True Then StringIn &= IIf(FirstIn, "", " OR ") & " Betalning_typ = 'IR_BILDBYRÅ'" : FirstIn = False
                If Filter_IV.Checked = True Then StringIn &= IIf(FirstIn, "", " OR ") & " Betalning_typ = 'IV'" : FirstIn = False
                If Filter_KR.Checked = True Then StringIn &= IIf(FirstIn, "", " OR ") & " Betalning_typ =  'KR'" : FirstIn = False
                If Filter_Repro.Checked = True Then StringIn &= IIf(FirstIn, "", " OR ") & "  Betalning_typ =  'REPRO'" : FirstIn = False
                If Filter_ST.Checked = True Then StringIn &= IIf(FirstIn, "", " OR ") & "  Betalning_typ =  'ST'" : FirstIn = False
                If Filter_TV.Checked = True Then StringIn &= IIf(FirstIn, "", " OR ") & "  Betalning_typ =  'TV'" : FirstIn = False
                StringIn &= ") "

                f &= IIf(first, "", " and ") & StringIn
                first = False

            End If
        End If
        f &= IIf(first, " 0=0 ", "") 'om inga filter kryssats i


        Return f
    End Function
    Function Get_Filter_TotalSumma() As Decimal
        If Filter_Totalsumma_GT_MenuItem.Checked = True And IsNumeric(Filter_Totalsumma_GT.Text) Then
            Return Filter_Totalsumma_GT.Text
        Else
            Return 0.0
        End If

    End Function







    'Fyller PaymentTreeView från databladet. (3 nivåer Root=Upphovsman,Child=BetalningsTyp,Level2=BetalningsID

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




    Private Sub PaymentTreeView_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles PaymentTreeView.AfterCheck
        'Hantera vilka andra noder som eventuellt ska kryssas i beroende på att denna blev ikryssad
        'För att undvika oändlig rekursion när man ändrar fler checked-värden ska man göra denna koll..
        If Not e.Action = TreeViewAction.Unknown Then

            PaymentTreeView.BeginUpdate()
            If CType(e.Node.Tag, DataRow)("checkable") = 0 Then
                e.Node.Checked = False
            End If

            PaymentTreeView.CheckTreeNode_Children(e.Node)
            PaymentTreeView.EndUpdate()
            Status_Update()

        End If

    End Sub
    REM Filter hantering
    Private Sub Filter_Upphovsman_Efternamn_GT_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Upphovsman_Efternamn_GT.SelectedIndexChanged
        Filter_Upphovsman_Efternamn_GT_MenuItem.Text = "Efternamn >= " & Filter_Upphovsman_Efternamn_GT.Text
        Status_Update()
    End Sub
    Private Sub Filter_Upphovsman_Efternamn_GT_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Upphovsman_Efternamn_GT.LostFocus
        Filter_Upphovsman_Efternamn_GT_MenuItem.Text = "Efternamn >= " & Filter_Upphovsman_Efternamn_GT.Text
        Filter_Upphovsman_Efternamn_GT_MenuItem.Checked = True
        Filter_Upphovsman_MenuItem.Checked = True
        Status_Update() : bUtför.ForeColor = Color.Black



    End Sub
    Private Sub Filter_Upphovsman_Efternamn_GT_MenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Upphovsman_Efternamn_GT_MenuItem.Click
        Filter_Upphovsman_MenuItem.Checked = True
        Status_Update() : bUtför.ForeColor = Color.Black

    End Sub

    Private Sub Filter_Upphovsman_Efternamn_LT_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Upphovsman_Efternamn_LT.SelectedIndexChanged
        Filter_Upphovsman_Efternamn_LT_MenuItem.Text = "Efternamn <= " & Filter_Upphovsman_Efternamn_LT.Text
    End Sub
    Private Sub Filter_Upphovsman_Efternamn_LT_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Upphovsman_Efternamn_LT.LostFocus
        Filter_Upphovsman_Efternamn_LT_MenuItem.Text = "Efternamn <= " & Filter_Upphovsman_Efternamn_LT.Text
        Filter_Upphovsman_Efternamn_LT_MenuItem.Checked = True
        Filter_Upphovsman_MenuItem.Checked = True
        Status_Update() : bUtför.ForeColor = Color.Black
    End Sub
    Private Sub Filter_Upphovsman_Efternamn_LT_MenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Upphovsman_Efternamn_LT_MenuItem.Click
        Filter_Upphovsman_MenuItem.Checked = True
        Status_Update() : bUtför.ForeColor = Color.Black

    End Sub

    Private Sub Filter_Upphovsman_Efternamn_like_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Upphovsman_Efternamn_like.TextChanged
        Filter_Upphovsman_Efternamn_like_MenuItem.Text = "Efternamn = " & Filter_Upphovsman_Efternamn_like.Text

    End Sub
    Private Sub Filter_Upphovsman_Efternamn_like_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Upphovsman_Efternamn_like.LostFocus
        Filter_Upphovsman_Efternamn_like_MenuItem.Text = "Efternamn = " & Filter_Upphovsman_Efternamn_like.Text

        Filter_Upphovsman_Efternamn_like_MenuItem.Checked = True
        Filter_Upphovsman_MenuItem.Checked = True
        Status_Update() : bUtför.ForeColor = Color.Black

    End Sub
    Private Sub Filter_Upphovsman_Efternamn_like_MenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Upphovsman_Efternamn_like_MenuItem.Click
        Filter_Upphovsman_MenuItem.Checked = True
        Status_Update() : bUtför.ForeColor = Color.Black

    End Sub

    Private Sub Filter_Upphovsman_Förnamn_like_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Upphovsman_Förnamn_like_MenuItem.TextChanged
        Filter_Upphovsman_Förnamn_like_MenuItem.Text = "Förnamn = " & Filter_Upphovsman_Förnamn_like.Text
    End Sub
    Private Sub Filter_Upphovsman_Förnamn_like_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Upphovsman_Efternamn_like.LostFocus
        Filter_Upphovsman_Förnamn_like_MenuItem.Text = "Förnamn = " & Filter_Upphovsman_Förnamn_like.Text

        Filter_Upphovsman_Förnamn_like_MenuItem.Checked = True And Filter_Upphovsman_MenuItem.Checked = True
        Status_Update() : bUtför.ForeColor = Color.Black

    End Sub
    Private Sub Filter_Upphovsman_Förnamn_like_MenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Upphovsman_Förnamn_like_MenuItem.Click
        Filter_Upphovsman_MenuItem.Checked = True
        Status_Update() : bUtför.ForeColor = Color.Black


    End Sub

    Private Sub AllaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllaToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        PaymentTreeView.CheckAll(True)
        Status_Update()
        Cursor = Cursors.Default
    End Sub
    Private Sub AvmarkeraAllaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AvmarkeraAllaToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        PaymentTreeView.CheckAll(False)
        Status_Update()
        Cursor = Cursors.Default
    End Sub
    Private Sub AktuellRadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AktuellRadToolStripMenuItem.Click
        If CType(PaymentTreeView.SelectedNode.Tag, DataRow)("checkable") = 1 Then
            PaymentTreeView.SelectedNode.Checked = Not PaymentTreeView.SelectedNode.Checked
        Else
            PaymentTreeView.SelectedNode.Checked = False
        End If
        PaymentTreeView.CheckTreeNode_Children(PaymentTreeView.SelectedNode)
        Status_Update()
        '       PaymentTreeView._Agg_TreeNodeText(PaymentTreeView.SelectedNode)

        '        PaymentTreeView_Checked_TotalAmount_WorkSUM() ' Bakgrundssummering av totalen
    End Sub
    Private Sub AvslutaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AvslutaToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Filter_Totalsumma_GT_MenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Totalsumma_GT_MenuItem.Click
        Status_Update() : bUtför.ForeColor = Color.Black
    End Sub
    Private Sub Filter_Totalsumma_GT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Totalsumma_GT.TextChanged
        Filter_Totalsumma_GT_MenuItem.Text = "Totalsumma > " & IIf(IsNumeric(Filter_Totalsumma_GT.Text), Filter_Totalsumma_GT.Text, 0) & Space(6 - Filter_Totalsumma_GT.Text.Length)

    End Sub
    Private Sub Filter_Totalsumma_GT_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Totalsumma_GT.LostFocus
        Filter_Totalsumma_GT_MenuItem.Text = "Totalsumma > " & IIf(IsNumeric(Filter_Totalsumma_GT.Text), Filter_Totalsumma_GT.Text, 0) & Space(6 - Filter_Totalsumma_GT.Text.Length)
        Filter_Totalsumma_GT_MenuItem.Checked = True
        Status_Update() : bUtför.ForeColor = Color.Black

    End Sub

    Private Sub Filter_Datum_LT_MenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Datum_LT_MenuItem.Click
        Status_Update() : bUtför.ForeColor = Color.Black
    End Sub
    Private Sub Filter_Datum_LT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Datum_LT.TextChanged
        Filter_Datum_LT_MenuItem.Text = "Datum < " & If(IsDate(Filter_Datum_LT.ToString), Filter_Datum_LT.ToString, "######") & Space(14 - Filter_Datum_LT.Text.Length)
    End Sub
    Private Sub Filter_Datum_LT_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Datum_LT.LostFocus
        Filter_Datum_LT_MenuItem.Text = "Datum < " & If(IsDate(Filter_Datum_LT.ToString), Filter_Datum_LT.ToString, "######") & Space(14 - Filter_Datum_LT.Text.Length)
        Filter_Datum_LT_MenuItem.Checked = True
        Status_Update() : bUtför.ForeColor = Color.Black

    End Sub

    Private Sub Filter_Datum_GT_MenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Datum_GT_MenuItem.Click
        Status_Update() : bUtför.ForeColor = Color.Black
    End Sub
    Private Sub Filter_Datum_GT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Datum_GT.TextChanged
        Filter_Datum_GT_MenuItem.Text = "Datum > " & If(IsDate(Filter_Datum_GT.ToString), Filter_Datum_GT.ToString, "######") & Space(14 - Filter_Datum_GT.Text.Length)
    End Sub
    Private Sub Filter_Datum_GT_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Datum_GT.LostFocus
        Filter_Datum_GT_MenuItem.Text = "Datum > " & If(IsDate(Filter_Datum_GT.ToString), Filter_Datum_GT.ToString, "######") & Space(14 - Filter_Datum_GT.Text.Length)
        Filter_Datum_GT_MenuItem.Checked = True
        Status_Update() : bUtför.ForeColor = Color.Black

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


    Private Sub Sort()
        Cursor = Cursors.WaitCursor
        If Sort_Namn_Ned.Checked = True Or Sort_Namn_Upp.Checked = True Then Sort_By_Namn() Else Sort_By_Belopp()
        Cursor = Cursors.Default
    End Sub
    Private Sub Sort_By_Namn()
        Dim s As Stopwatch = New Stopwatch
        s.Start()
        If Sort_Namn_Ned.Checked = True Or Sort_Namn_Upp.Checked = True Then
            PaymentTreeView.BeginUpdate()

            If Sort_Namn_Ned.Checked = True Then
                'PaymentTreeView.TreeViewNodeSorter = New NodeSorterNamnDown
                PaymentTreeView.Sort_RootNodes(B2.GroupTreeView.SortColumn.Name, GroupTreeView.AscDesc.Desc)
            Else
                'PaymentTreeView.TreeViewNodeSorter = New NodeSorterNamnUp
                PaymentTreeView.Sort_RootNodes(B2.GroupTreeView.SortColumn.Name, GroupTreeView.AscDesc.Asc)
            End If
            PaymentTreeView.EndUpdate()

        End If
        'PaymentTreeView.Sort()
        Console.WriteLine(s.ElapsedMilliseconds & " ms sorteringNamn Arraylist")
    End Sub
    Public Class NodeSorterNamnUp
        Implements IComparer

        ' Compare the length of the strings, or the strings
        ' themselves, if they are the same length.
        Public Function Compare(ByVal x As Object, ByVal y As Object) _
            As Integer Implements IComparer.Compare
            Dim tnx As TreeNode = CType(x, TreeNode)
            Dim tny As TreeNode = CType(y, TreeNode)
            Dim tx As String = ""
            Dim ty As String = ""
            If tnx.Tag Is Nothing Then tx = "" Else tx = New String(CType(tnx.Tag, DataRow)("Namn_Personnummer_grupp").ToString.ToUpper)
            If tny.Tag Is Nothing Then ty = "" Else ty = New String(CType(tny.Tag, DataRow)("Namn_Personnummer_grupp").ToString.ToUpper)
            Return String.Compare(tx, ty)

        End Function
    End Class
    Public Class NodeSorterNamnDown
        Implements IComparer

        ' Compare the length of the strings, or the strings
        ' themselves, if they are the same length.
        Public Function Compare(ByVal x As Object, ByVal y As Object) _
            As Integer Implements IComparer.Compare
            Dim tnx As TreeNode = CType(x, TreeNode)
            Dim tny As TreeNode = CType(y, TreeNode)
            Dim tx As String = ""
            Dim ty As String = ""
            If tnx.Tag Is Nothing Then tx = "" Else tx = New String(CType(tnx.Tag, DataRow)("Namn_Personnummer_grupp").ToString.ToUpper)
            If tny.Tag Is Nothing Then ty = "" Else ty = New String(CType(tny.Tag, DataRow)("Namn_Personnummer_grupp").ToString.ToUpper)
            Return -String.Compare(tx, ty)

        End Function
    End Class

    Private Sub Sort_By_Belopp()
        Dim s As Stopwatch = New Stopwatch
        s.Start()
        PaymentTreeView.BeginUpdate()

        If Sort_Totalsumma_Ned.Checked = True Or Sort_Totalsumma_Upp.Checked = True Then
            If Sort_Totalsumma_Ned.Checked = True Then
                PaymentTreeView.Sort_RootNodes(B2.GroupTreeView.SortColumn.Amount, GroupTreeView.AscDesc.Desc)
            Else
                PaymentTreeView.Sort_RootNodes(B2.GroupTreeView.SortColumn.Amount, GroupTreeView.AscDesc.Asc)
            End If
        End If
        PaymentTreeView.EndUpdate()

        Console.WriteLine(s.ElapsedMilliseconds & " ms sorteringBelopp")

    End Sub

    Private Sub MenuTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim sum As Decimal
        Dim row As DataRow
        Dim countRows, countNodes As Int16
        countRows = 0 : countNodes = 0
        Dim timestart As DateTime = Now
        For Each row In dataTable.Rows
            sum += Decimal.Round(row("belopp"), 0)

            countRows += 1
        Next

        lblTotalAmount.Text = sum

        lblTotalAmount.Text &= " Steg 1(Sum) : Rows=" & countRows & "st " & Now.Subtract(timestart).TotalMilliseconds & "ms "

        timestart = Now
        PaymentTreeView.BeginUpdate()
        Dim rootNode, node1, node2 As TreeNode
        For Each rootNode In PaymentTreeView.Nodes
            For Each node1 In rootNode.Nodes
                For Each node2 In node1.Nodes
                    countNodes += 1
                    node2.Text = "BOB "
                Next
            Next
        Next
        PaymentTreeView.EndUpdate()


        lblTotalAmount.Text &= " Steg2 (SetText): Nodes=" & countNodes & "st " & Now.Subtract(timestart).TotalMilliseconds & "ms "

    End Sub


    Private Sub Filter_IV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_IV.Click
        Filter_Utbetalningstyp_Menutem.Checked = True
        Status_Update() : bUtför.ForeColor = Color.Black

    End Sub

    Private Sub Filter_Följerätt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Följerätt.Click
        Filter_Utbetalningstyp_Menutem.Checked = True
        Status_Update() : bUtför.ForeColor = Color.Black

    End Sub

    Private Sub Filter_IR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_IR.Click
        Filter_Utbetalningstyp_Menutem.Checked = True
        Status_Update() : bUtför.ForeColor = Color.Black
    End Sub

    Private Sub Filter_IR_Bildbyrå_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_IR_Bildbyrå.Click
        Filter_Utbetalningstyp_Menutem.Checked = True
        Status_Update() : bUtför.ForeColor = Color.Black
    End Sub

    Private Sub Filter_IR_Foto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_IR_Foto.Click
        Filter_Utbetalningstyp_Menutem.Checked = True
        Status_Update() : bUtför.ForeColor = Color.Black
    End Sub

    Private Sub Filter_IRDAGP_Foto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_IRDAGP_Foto.Click
        Filter_Utbetalningstyp_Menutem.Checked = True
        Status_Update() : bUtför.ForeColor = Color.Black

    End Sub
    Private Sub Filter_IRDAGP_Illust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_IRDAGP_Illust.Click
        Filter_Utbetalningstyp_Menutem.Checked = True
        Status_Update() : bUtför.ForeColor = Color.Black

    End Sub

    Private Sub Filter_KR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_KR.Click
        Filter_Utbetalningstyp_Menutem.Checked = True
        Status_Update() : bUtför.ForeColor = Color.Black
    End Sub

    Private Sub Filter_Repro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Repro.Click
        Filter_Utbetalningstyp_Menutem.Checked = True
        Status_Update() : bUtför.ForeColor = Color.Black
    End Sub

    Private Sub Filter_ST_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_ST.Click
        Filter_Utbetalningstyp_Menutem.Checked = True
        Status_Update() : bUtför.ForeColor = Color.Black
    End Sub

    Private Sub Filter_TV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_TV.Click

        Filter_Utbetalningstyp_Menutem.Checked = True
        Status_Update() : bUtför.ForeColor = Color.Black

    End Sub

    Private Sub filter_Dold_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles filter_Dold.Click
        Status_Update() : bUtför.ForeColor = Color.Black
    End Sub

    Private Sub GodkännFörUtbetalningToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GodkännFörUtbetalningToolStripMenuItem.Click
        Dim sqlConn As SqlConnection = New SqlConnection(My.Settings.DBconnectionString)
        'Try
        Dim AccString As Stringbuilder = New StringBuilder
        AccString.Length = 0
        Status_Update()

        sqlConn.Open()
        Dim maxRows As Integer = PaymentTreeView.GetCheckedRows
        pbProgress.Maximum = 100
        pbProgress.Visible = True
        Dim rowCount As Integer
        Dim i As Integer
        Dim selectCommand As SqlCommand = New SqlCommand()
        Dim reader As SqlDataReader

        AccString.AppendLine("begin transaction")
        For Each node In PaymentTreeView.Nodes
            rowCount += MarkPaid_TreeNode(node, AccString)
            pbProgress.Value = 100 * (rowCount / maxRows)
            pbProgress.Refresh()
            If i + 50 < rowCount Then
                'För att bryta upp transaktionen i smådelar
                AccString.AppendLine("commit transaction")
                selectCommand.CommandType = CommandType.Text
                selectCommand.CommandText = AccString.ToString
                ' System.Console.WriteLine(selectCommand.CommandText.ToString)
                System.Console.WriteLine("RowCount" & rowCount)
                selectCommand.Connection = sqlConn
                reader = selectCommand.ExecuteReader
                reader.Read()
                reader.Close()

                AccString.Length = 0
                AccString.AppendLine("begin transaction")
                i = rowCount
            End If

        Next node
        AccString.AppendLine("commit transaction")

        'Dim parmID As SqlParameter
        selectCommand.CommandType = CommandType.Text
        selectCommand.CommandText = AccString.ToString
        System.Console.WriteLine("rowCount " & rowCount)
        selectCommand.Connection = sqlConn
        reader = selectCommand.ExecuteReader

        reader.Close()

        sqlConn.Close()
        pbProgress.Visible = False
        refill_payment_treeview()
        '        Catch e As SqlException
        '            MsgBox(e.ToString)
        '
        '        Finally
        '            'Stäng SqlConnection-objektet ifall det är öppet eller ifall det blivit något fel
        '            If sqlConn.State = ConnectionState.Open Or sqlConn.State = ConnectionState.Broken Then
        ' sqlConn.Close()
        ' End If

        '        End Try

    End Sub
    Private Function MarkPaid_TreeNode(ByRef tnode As TreeNode, ByRef AccStr As StringBuilder) As Integer

        Dim Counter As Integer = 0
        If tnode.Nodes.Count = 0 Then
            If tnode.Checked = True Then
                AccStr.AppendLine("exec sp_betalning_fördelning " & (CType(tnode.Tag, DataRow)("ID")))
                'TODO sqldo set marked

                'TODO error handling kring misslyckat eller om skall fortsätta
                Return 1

            Else
                Return 0
            End If
        Else


            For Each node In tnode.Nodes
                Counter += MarkPaid_TreeNode(node, AccStr)
            Next node
            Return Counter
        End If
    End Function





    Private Sub Filter_Upphovsman_MenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Upphovsman_MenuItem.Click
        Status_Update() : bUtför.ForeColor = Color.Black
    End Sub

    Private Sub Filter_Utbetalningstyp_Menutem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Utbetalningstyp_Menutem.Click
        Status_Update() : bUtför.ForeColor = Color.Black
    End Sub


    Private Sub Filter_Checkable_Only_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Checkable_Only.Click
        Status_Update()
        bUtför.ForeColor = Color.Black
    End Sub


    Private Sub bUtför_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bUtför.Click
        refill_payment_treeview()
        bUtför.ForeColor = Color.White ' : bUtför.Enabled = False
    End Sub

    Private Sub ÖppnaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ÖppnaToolStripMenuItem.Click
        'Dim fu As FormUtbetalning
        'fu = New FormUtbetalning
        'fu.FilterToolStripMenuItem.Checked = Me.filterToolStripMenuItem.Checked
        'fu.Filter_Checkable_Only.Checked = Me.Filter_Checkable_Only.Checked
        'fu.Filter_Datum_GT.Text = Me.Filter_Datum_GT.Text
        'fu.Filter_Datum_GT_MenuItem.Checked = Me.Filter_Datum_GT_MenuItem.Checked
        'fu.Filter_Datum_LT.Text = Me.Filter_Datum_LT.Text
        'fu.Filter_Datum_LT_MenuItem.Checked = Me.Filter_Datum_LT_MenuItem.Checked
        'fu.filter_kommentar_like.Text = Me.filter_kommentar_like.Text
        'fu.filter_kommentar_like_MenuItem.Checked = Me.filter_kommentar_like_MenuItem.Checked

        'fu.Filter_dold.Checked = Me.filter_Dold.Checked
        'fu.Filter_Följerätt.Checked = Me.Filter_Följerätt.Checked
        'fu.Filter_IR.Checked = Me.Filter_IR.Checked
        'fu.Filter_IR_Bildbyrå.Checked = Me.Filter_IR_Bildbyrå.Checked
        'fu.Filter_IR_Foto.Checked = Me.Filter_IR_Foto.Checked
        'fu.Filter_IRDAGP_Foto.Checked = Me.Filter_IRDAGP_Foto.Checked
        'fu.Filter_IRDAGP_Illust.Checked = Me.Filter_IRDAGP_Illust.Checked
        'fu.Filter_IV.Checked = Me.Filter_IV.Checked
        'fu.Filter_KR.Checked = Me.Filter_KR.Checked
        'fu.Filter_Repro.Checked = Me.Filter_Repro.Checked
        'fu.Filter_ST.Checked = Me.Filter_ST.Checked
        'fu.Filter_TV.Checked = Me.Filter_TV.Checked
        'fu.Filter_Totalsumma_GT.Text = Me.Filter_Totalsumma_GT.Text
        'fu.Filter_Totalsumma_GT_MenuItem.Checked = Me.Filter_Totalsumma_GT_MenuItem.Checked
        'fu.Filter_Upphovsman_Efternamn_GT.SelectedIndex = Me.Filter_Upphovsman_Efternamn_GT.SelectedIndex
        'fu.Filter_Upphovsman_Efternamn_GT_MenuItem.Checked = Me.Filter_Upphovsman_Efternamn_GT_MenuItem.Checked
        'fu.Filter_Upphovsman_Efternamn_like.Text = Me.Filter_Upphovsman_Efternamn_like.Text
        'fu.Filter_Upphovsman_Efternamn_like_MenuItem.Checked = Me.Filter_Upphovsman_Efternamn_like_MenuItem.Checked
        'fu.Filter_Upphovsman_Efternamn_LT.SelectedIndex = Me.Filter_Upphovsman_Efternamn_LT.SelectedIndex
        'fu.Filter_Upphovsman_Efternamn_LT_MenuItem.Checked = Me.Filter_Upphovsman_Efternamn_LT_MenuItem.Checked
        'fu.Filter_Upphovsman_Förnamn_like.Text = Me.Filter_Upphovsman_Förnamn_like.Text
        'fu.Filter_Upphovsman_Förnamn_like_MenuItem.Checked = Me.Filter_Upphovsman_Förnamn_like_MenuItem.Checked
        'fu.Filter_Upphovsman_MenuItem.Checked = Me.Filter_Upphovsman_MenuItem.Checked

        'fu.Filter_Utbetalningstyp_MI.Checked = Me.Filter_Utbetalningstyp_Menutem.Checked
        'fu.Show()
        'fu.refill_utbetalning_treeview()
    End Sub

    Private Sub PaymentTreeView_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles PaymentTreeView.AfterSelect

    End Sub

    
End Class