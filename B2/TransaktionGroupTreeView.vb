Imports System.Text
Public Class TransaktionGroupTreeView
    Inherits GroupTreeView
    Public Overrides Function LevelText(ByVal l As Integer, ByRef row As System.Data.DataRow) As String
        Dim s As String
        If l = 0 Then
            s = Graph_Pad_Right(row("transaktion_typ").ToString().ToUpper, 25, Me.Font) & ",  " & CType(row("transaktion_dag"), Date).ToShortDateString() & "  " & Graph_Pad_Right(row("fil_namn").ToString(), 120, Me.Font)
        ElseIf l = 1 Then
            s = Graph_Pad_Right(row("bp_konto_typ").ToString(), 30, Me.Font)
        ElseIf l = 2 Then
            s = row("mottagare_efternamn").ToString() & ",  " & row("mottagare_förnamn").ToString() & "  " & row("mottagare_personnummer").ToString()

        ElseIf l = 3 Then
            s = Graph_Pad_Right(row("betalning_typ").ToString(), 10, Me.Font) & ": " & row("BU_upphovsman_efternamn").ToString() & ",  " & row("BU_upphovsman_förnamn").ToString() & "  " & row("BU_upphovsman_personnummer").ToString()

        Else
            s = MyBase.LevelText(l, row)
        End If


        Return s
    End Function
    Public Overrides Function LevelToolTipText(ByVal l As Integer, ByRef row As System.Data.DataRow) As String
        Dim s As String

        If l = 0 Then
            s = "Löpnr. =" & row("bt_fil_löpnummer")
            If row("status").ToString.ToUpper.Trim = "CLOSED" Then s &= " AVSLUTAD"
        ElseIf l = 2 Then
            If row("bp_konto_typ").ToString.ToUpper.Trim = "AVI" Then
                s = row("Adress_Kommentar").ToString
            Else
                s = row("Konto_Kommentar").ToString
            End If
        ElseIf l = 3 Then
            s = row("betalning_underlag_kommentar")

        Else
            s = ""
        End If


        Return s
    End Function
    Overrides Function LevelForeGroundColor(ByVal l As Integer, ByVal row As DataRow) As Color
        If l = 0 Then
            If row("status").ToString.ToUpper.Trim = "NEW" Then
                Return Color.Green
            ElseIf row("status").ToString.ToUpper.Trim = "CLOSED" Then
                Return Color.Brown
            Else
                Return Color.Black
            End If
        ElseIf l = 3 Then
            If row("mottagare_typ").ToString.ToUpper.Trim = "S" Then
                Return Color.Green
            ElseIf row("mottagare_typ").ToString.ToUpper.Trim = "R" Then
                Return Color.Blue
            Else
                Return Color.Black
            End If
        Else
            Return Color.Black
        End If

    End Function

    Overrides Sub Agg_All_Amount()
        Dim sum As Decimal = 0.0 'Dim sumList As ArrayList
        REM Me.BeginUpdate()
        REM For Each childNode As TreeNode In Me.Nodes
        REM sum = sum + CType(childNode.Tag, DataRow)(")
        REM Next
        REM Me.EndUpdate()
        TotalAmount = 0


    End Sub
    Overrides Function Agg_LevelText_Sum(ByRef node As TreeNode) As ArrayList
        'första värden måste vara checkedSum,totalsum,checkedRows
        Dim checkedSum As Decimal = 0.0
        Dim totalNetto As Decimal = 0.0
        Dim checkedRows As Integer = 0
        Dim totalMoms As Decimal = 0.0
        Dim totalAvdrag As Decimal = 0.0
        Dim totalBrutto As Decimal = 0.0
        Dim totalMottagare As Integer = 0

        Dim row As DataRow = CType(node.Tag, DataRow)
        Dim sumList As ArrayList
        'Sätt värden på barnnoder och rekursivt summera dem.

        For Each childNode As TreeNode In node.Nodes
            sumList = Agg_LevelText_Sum(childNode)
            'checkedSum += sumList(0)
            totalNetto += sumList(1)
            'checkedRows += sumList(2)
            totalMoms += sumList(3)
            totalAvdrag += sumList(4)
            totalBrutto += sumList(5)
            totalMottagare += sumList(6)
        Next childNode

        If node.Level = 0 Then
            totalNetto = row("BT_Netto_Calc")
            totalAvdrag = row("BT_Avdrag_calc")
            totalMoms = row("Bt_Moms_calc")
            totalBrutto = row("Bt_Brutto_calc")
        ElseIf node.Level = 2 Then
            totalMottagare = 1
        ElseIf node.Level = 3 Then
            totalNetto = row("BG_netto_calc")
            totalAvdrag = row("bg_Avdrag_calc")
            totalMoms = row("bg_Moms_calc")
            totalBrutto = row("bg_Belopp")
            totalMottagare = 0
        ElseIf node.Level > 3 Then
            totalNetto = row("BU_Belopp")
            totalAvdrag = 0.0
            totalMoms = 0.0
            totalBrutto = row("BU_Belopp")
            totalMottagare = 0
        End If
        Dim s As StringBuilder

        'Sätter text och tooltip text
        If node.Level <= 2 Then
            'node.Level & " " & 
            
            node.Text = Graph_Pad_Right(LevelText(node.Level, row), 100, Me.Font) & Graph_Pad_Left((Decimal.Round(totalNetto, 0).ToString("N0") & " kr"), 50, Me.Font)

            s = New StringBuilder(LevelToolTipText(node.Level, row)).Append(Environment.NewLine)
            If node.Level = 0 Then
                s.Append("Summa på filen : ").Append(Convert.ToDecimal(row("bt_netto_calc")).ToString("N0")).Append(Environment.NewLine)
                s.Append("Transaktions ID : ").Append(Convert.ToInt32(row("bt_ID")).ToString("N0")).Append(Environment.NewLine)
            End If
            s.Append("Antal mottagare   : ").Append(totalMottagare.ToString("N0")).Append(" st.").Append(Environment.NewLine)

            's.Append("Brutto   : ").Append(Convert.TODECIMAL(row("bt_brutto_calc")).ToString("N0")).Append(" kr.").Append(Environment.NewLine)
            s.Append("Brutto   : ").Append(totalBrutto.ToString("N0")).Append(" kr.").Append(Environment.NewLine)
            's.Append("Avdrag : ").Append(Convert.ToDecimal(row("bt_avdrag_calc")).ToString("N0")).Append(" kr.").Append(Environment.NewLine)
            s.Append("Avdrag : ").Append(totalAvdrag.ToString("N0")).Append(" kr.").Append(Environment.NewLine)
            's.Append("Moms   : ").Append(Convert.ToDecimal(row("bt_moms_calc")).ToString("N0")).Append(" kr.").Append(Environment.NewLine)
            s.Append("Moms   : ").Append(totalMoms.ToString("N0")).Append(" kr.").Append(Environment.NewLine)

            If node.Level = 0 Then s.Append("Öresutjämn.: ").Append(Convert.ToDecimal(row("bt_Öresavrundning_calc")).ToString("N2")).Append(" kr.").Append(Environment.NewLine)

            node.ToolTipText = s.ToString

        Else
            s = New StringBuilder(Graph_Pad_Right(LevelText(node.Level, row), 100, Me.Font)).Append(Graph_Pad_Left(Decimal.Round(totalBrutto, 0).ToString("N0") & " kr ", 50, Me.Font))
            s.Append(" brutto. (").Append(Convert.ToDecimal(row("bg_fördelning"))).Append("% av ").Append(Decimal.Round(row("BU_Belopp"), 0)).Append(" kr.)")
            node.Text = s.ToString
            node.ToolTipText = LevelToolTipText(node.Level, row)


        End If

        node.ForeColor = LevelForeGroundColor(node.Level, row)



        sumList = New ArrayList(6)
        sumList.Add(checkedSum)
        sumList.Add(totalNetto)
        sumList.Add(checkedRows)
        sumList.Add(totalMoms)
        sumList.Add(totalAvdrag)
        sumList.Add(totalBrutto)
        sumList.Add(totalMottagare)

        Return sumList
    End Function
    Function Level_Sum_TreeNode(ByRef node As TreeNode, ByVal level As Integer, ByVal ColName As String) As Decimal
        Dim totalSum As Decimal = 0.0
        Dim row As DataRow = CType(node.Tag, DataRow)
        'Sätt värden på barnnoder och rekursivt summera dem.
        If node.Level < level Then
            For Each childNode As TreeNode In node.Nodes
                totalSum += Level_Sum_TreeNode(childNode, level, ColName)
            Next
        ElseIf node.Level = level Then
            totalSum = row(ColName)
        ElseIf node.Level > level Then
            totalSum = 0
        End If

        Return totalSum
    End Function

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        Me.ResumeLayout(False)

    End Sub
End Class
