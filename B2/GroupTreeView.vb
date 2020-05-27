Imports System
Imports System.ComponentModel
Imports System.Threading
Imports System.Windows.Forms

Public Class GroupTreeView
    Inherits TreeView
    Enum SortColumn
        Name
        Amount
        None
    End Enum
    Enum AscDesc
        Asc
        Desc
        None
    End Enum
    Public Enum CondCols
        checkedRows = 0
        checkedSum = 1
        totalRows = 2
        totalSum = 3
    End Enum
    Private dataView As DataView
    Friend SortedBy As SortColumn = SortColumn.None  'GroupTreeView kan sorteras på  kolumnerna Name och amount
    Friend SortOrder As AscDesc = AscDesc.None 'Sorteringsordning
    Friend TotalAmount As Decimal = 0.0 : Dim TotalIsCounted As Boolean = False
    Friend Checked_TotalAmount As Decimal = 0.0 : Dim CheckedIsCounted As Boolean = False
    Private TotalRows As Integer = 0, TotalCheckedRows As Integer = 0
    Private colAmountName As String = "Belopp"
    Private colGroupAmountName As String = "T_Belopp"
    Private colGroupNames() As String
    Private AmountFilter As Decimal = 0.0
    Dim WidthOfSpace As Int16 = TextRenderer.MeasureText("  ", Me.Font).Width - TextRenderer.MeasureText(" ", Me.Font).Width
    Dim FontPadding As Int16 = TextRenderer.MeasureText(" ", Me.Font).Width - WidthOfSpace
    Dim regularFont As Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Regular)
    Dim italicFont As Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Italic)


    Public Sub SetDataView(ByRef dv As DataView)
        dataView = dv
    End Sub
    Function Graph_Pad_Right(ByRef stringToPad As String, ByVal preferedWidthInChar As Int16, ByVal font As Font) As String
        'Genererar ett antal mellanslag för att nå upp i en specifik bredd (mätt i mellanslag)
        'Använder japanska apostrofer för att fylla ut i början för att justera litet
        '      Dim WidthOfDot As Int16 = TextRenderer.MeasureText(Strings.Chr(39), font).Width - FontPadding
        Dim WidthOfString As Int16 = TextRenderer.MeasureText(stringToPad, font).Width - FontPadding

        Dim WidthOfPreferedString As Int16 = WidthOfSpace * preferedWidthInChar
        Dim WidthOfPadString As Int16 = WidthOfPreferedString - WidthOfString
        Dim LengthOfPadString As Int16
        Dim DotString As String = ""
        If WidthOfPadString Mod WidthOfSpace = 0 Then
            LengthOfPadString = Math.Floor(WidthOfPadString / WidthOfSpace) - 1
            DotString = ""
        ElseIf WidthOfPadString Mod WidthOfSpace = 1 Then
            LengthOfPadString = Math.Floor(WidthOfPadString / WidthOfSpace)
            DotString = Strings.ChrW(1371) '& Strings.ChrW(1474)
        ElseIf WidthOfPadString Mod WidthOfSpace = 2 Then
            LengthOfPadString = Math.Floor(WidthOfPadString / WidthOfSpace)
            DotString = Strings.ChrW(1372)

        End If

        If LengthOfPadString < 0 Then

            Return stringToPad
        Else
            '    Dim WidthResultString As Int16 = TextRenderer.MeasureText(stringToPad & DotString & "".PadLeft(LengthOfPadString, " "), font).Width - FontPadding
            Return stringToPad & DotString.PadRight(LengthOfPadString, " ")

        End If
    End Function
    Function Graph_Pad_Left(ByRef stringToPad As String, ByVal preferedWidthInChar As Int16, ByVal font As Font) As String
        'Genererar ett antal mellanslag för att nå upp i en specifik bredd (mätt i mellanslag)
        'Använder japanska apostrofer för att fylla ut i början för att justera litet
        Dim WidthOfString As Int16 = TextRenderer.MeasureText(stringToPad, font).Width - FontPadding

        Dim WidthOfPreferedString As Int16 = WidthOfSpace * preferedWidthInChar
        Dim WidthOfPadString As Int16 = WidthOfPreferedString - WidthOfString
        Dim LengthOfPadString As Int16
        Dim DotString As String = ""
        If WidthOfPadString Mod WidthOfSpace = 0 Then
            LengthOfPadString = Math.Floor(WidthOfPadString / WidthOfSpace) - 1
            DotString = ""
        ElseIf WidthOfPadString Mod WidthOfSpace = 1 Then
            LengthOfPadString = Math.Floor(WidthOfPadString / WidthOfSpace)
            DotString = Strings.ChrW(1371)
        ElseIf WidthOfPadString Mod WidthOfSpace = 2 Then
            LengthOfPadString = Math.Floor(WidthOfPadString / WidthOfSpace)
            DotString = Strings.ChrW(1372)

        End If

        If LengthOfPadString < 0 Then

            Return stringToPad
        Else
            'Dim WidthResultString As Int16 = TextRenderer.MeasureText(stringToPad & DotString & "".PadLeft(LengthOfPadString, " "), font).Width - FontPadding
            Return DotString.PadLeft(LengthOfPadString, " ") & stringToPad

        End If
    End Function

    Public Function getDataView() As DataView
        Return dataView
    End Function
    Public Sub setColSumName(ByVal ColumnName As String)
        colAmountName = ColumnName
    End Sub
    Public Function getColSumName() As String
        Return colAmountName
    End Function
    Public Sub setColGroupSumName(ByVal ColumnName As String)
        colGroupAmountName = ColumnName
    End Sub
    Public Function getColGroupSumName() As String
        Return colGroupAmountName
    End Function
    ' Public Sub setAmountFilter(ByVal newAmountFilter As Decimal)
    'Om filtret är mindre begränsande så måste alla läsas in igen
    ' Dim node As TreeNode
    ' Dim index As Integer = 0
    '     If newAmountFilter < AmountFilter Then Me.Fill()
    '
    '        Me.SuspendLayout()
    '        For index = 0 To Me.Nodes.Count - 1
    '            System.Console.Write(index.ToString & ":" & Me.Nodes(index).Text)
    '
    '            If newAmountFilter > Agg_Amount(Me.Nodes(index)) Then
    '                Me.Nodes.Remove(Me.Nodes.Item(index))
    '                System.Console.Write(" DEL ")
    '    'Me.Nodes.Item(Me.Nodes.IndexOf(node)).Text = "BORT"
    '                index -= 1
    '
    '
    '            End If
    '            System.Console.WriteLine(" Antal= " & Me.Nodes.Count & " index=" & index.ToString)
    '
    '            If index >= Me.Nodes.Count - 1 Then Exit For
    '        Next index
    '
    '    'Agg_All_LevelText_Sum()
    '            AmountFilter = newAmountFilter
    '        Me.ResumeLayout()
    '    End Sub
    Public Sub setGroupNames(ByRef groupNames As Array)
        'System.Array.Copy(sa, colGroupNames, sa.Length)

        If dataView Is Nothing Then Throw New ArgumentException("Ingen dataView i setColSumName")
        Dim o As Object
        Dim Name As String
        If dataView.Count > 0 Then
            For Each Name In groupNames
                o = dataView(0).Item(Name)
            Next
        End If
        'Throw New ArgumentException("Kolumnen saknas", "GroupNames")
        colGroupNames = groupNames

    End Sub
    Private Function FindChild(ByRef nodes As TreeNodeCollection, ByRef colName As String, ByVal colValue As String) As TreeNode
        'Throw New ApplicationException("Ej implementerat FindChild")
        For Each node As TreeNode In nodes
            'Hämta ut dataraden från noden
            Dim dr As DataRow = CType(node.Tag, DataRow)
            If colValue.Equals(dr(colName).ToString()) Then Return node
        Next
        Return Nothing

        Return Nothing
    End Function

    Public Sub Fill(ByRef pb As ProgressBar)
        SortedBy = SortColumn.None
        SortOrder = AscDesc.None
        TotalAmount = 0.0 : TotalIsCounted = False
        TotalRows = 0 : CheckedIsCounted = False
        '  Dim countRow As Integer = 0
        Dim inLevel As Integer
        Dim ProgressRows = 0
        Dim currentNode, parentNode As TreeNode
        Dim s As Stopwatch = New Stopwatch : s.Reset() : s.Start()

        Me.SuspendLayout()
        Me.Nodes.Clear()
        pb.Maximum = dataView.Count
        Dim regularFont As Font = New Font(TreeView.DefaultFont, FontStyle.Regular)
        ' MsgBox(regularFont.FontFamily.ToString + " " + regularFont.Name.ToString)
        For Each rowView As DataRowView In dataView
            '     countRow += 1
            Dim row As DataRow = rowView.Row
            'Dim regularFont As Font = New Font("Microsoft Sans Serif (TrueType)", 8)
            'Används för totalsumma
            'TotalAmount = TotalAmount + row(colAmountName)

            If row.Table.Columns.Contains("Antal_underlag") Then TotalRows += row("Antal_underlag") Else TotalRows += 1
            ProgressRows += 1
            pb.Value = ProgressRows
            'Översta nivån 

            'Fyll alla levels med insformation från denna rad
            currentNode = FindChild(Me.Nodes, colGroupNames(0), row(colGroupNames(0)).ToString())
            If currentNode Is Nothing Then currentNode = Me.Nodes.Add("") 'Me.Nodes.Add(LevelText(inLevel, row))
            currentNode.Tag = row
            currentNode.NodeFont = regularFont
            currentNode.ForeColor = LevelForeGroundColor(inLevel, row)


            parentNode = currentNode
            'Sublevels
            For inLevel = 1 To colGroupNames.Length - 1

                currentNode = FindChild(parentNode.Nodes, colGroupNames(inLevel), row(colGroupNames(inLevel)).ToString())
                If currentNode Is Nothing Then currentNode = parentNode.Nodes.Add("") 'parentNode.Nodes.Add(LevelText(inLevel, row))
                currentNode.Tag = row
                currentNode.NodeFont = regularFont
                currentNode.ForeColor = LevelForeGroundColor(inLevel, row)

                parentNode = currentNode

            Next inLevel
        Next
        Console.WriteLine("Efter Tree_fill: " & s.ElapsedMilliseconds) : s.Reset() : s.Start()
        'Agg_All_Amount()
        
        'Sätt alla amount-värden (och andra synliga värden) för alla barn i trädet
        Agg_All_LevelText_Sum()
        Console.WriteLine("Efter All_Level_text: " & s.ElapsedMilliseconds) : s.Reset() : s.Start()
        Me.ResumeLayout()


    End Sub
    

    Overridable Function LevelText(ByVal l As Integer, ByRef row As DataRow) As String

        Return row(colGroupNames(Math.Min(l, colGroupNames.Length - 1))).ToString
    End Function
    Overridable Function LevelToolTipText(ByVal l As Integer, ByRef row As DataRow) As String
        Try
            If row("checkable").ToString = "1" Then
                Return row(colGroupNames(l)).ToString
            Else
                Return row(colGroupNames(l)).ToString & " Saknas information"
            End If
        Catch e As Exception
            Return row(colGroupNames(l)).ToString
        Finally
        End Try


    End Function
    Overridable Function LevelForeGroundColor(ByVal l As Integer, ByVal row As DataRow) As Color
        Try
            If row("checkable").ToString = "1" Then
                Return Color.Black
            Else
                Return Color.Brown
            End If
        Catch e As Exception
            Return Color.Black
        Finally
        End Try
    End Function
    'return sum of nodes amount
    Overridable Function Agg_Amount_TreeNode(ByRef node As TreeNode) As Decimal
        Dim totalSum As Decimal = 0.0

        Dim row As DataRow = CType(node.Tag, DataRow)
        'Sätt värden på barnnoder och rekursivt summera dem.
        If node.Nodes.Count > 0 Then
            For Each childNode As TreeNode In node.Nodes
                totalSum = totalSum + Agg_Amount_TreeNode(childNode)
            Next
        Else
            totalSum = row(colAmountName)

        End If

        'Sätter text
        Return totalSum
    End Function
    Overridable Sub Agg_All_Amount()
        Dim sum As Decimal = 0.0 'Dim sumList As ArrayList
        Me.BeginUpdate()
        TotalIsCounted = False
        For Each childNode As TreeNode In Me.Nodes
            sum = sum + CType(childNode.Tag, DataRow)(colGroupAmountName)
        Next
        Me.EndUpdate()
        TotalAmount = sum : TotalIsCounted = True


    End Sub
    'Summerar antalet ikryssade rader och summan på beloppen av ikryssade rader
    Private Sub Agg_CheckedTotal()
        Dim checkedSum As Double = 0.0
        Dim checkedRows As Integer = 0
        CheckedIsCounted = False
        For Each node In Me.Nodes
            Dim sl As ArrayList
            sl = Agg_Checked(node)
            checkedSum += sl(0)
            checkedRows += sl(1)
        Next
        Checked_TotalAmount = checkedSum
        TotalCheckedRows = checkedRows
        CheckedIsCounted = True
    End Sub
    'Denna funktion summerar amount-värden för barnnoderna där noden är ikryssad (rekursivt) använder den kolumn(decimal) som anges
    Private Function Agg_Checked(ByRef node As TreeNode) As ArrayList
        'Kolla ifall denna nod är ett löv
        Dim sumList As ArrayList
        Dim checkedRows As Integer = 0
        Dim checkedSum As Decimal = 0.0
        If node.Nodes.Count = 0 Then
            'Returnera denna rads amount Om noden är ikryssad. 
            If node.Checked = True Then
                'Hämta dataraden som sparats i Tag
                Dim dataRow As DataRow = CType(node.Tag, DataRow)
                checkedSum = CType(dataRow(colAmountName), Decimal)
                If CType(node.Tag, DataRow).Table.Columns.Contains("Antal_underlag") Then checkedRows = CType(node.Tag, DataRow)("Antal_underlag") Else checkedRows = 1


            End If
        Else 'Har Children
            For Each childNode As TreeNode In node.Nodes
                Dim sl As ArrayList = Agg_Checked(childNode)
                checkedSum += sl(0)
                checkedRows += sl(1)

            Next

        End If
        sumList = New ArrayList
        sumList.Add(checkedSum)
        sumList.Add(checkedRows)

        Return sumList  'returnerar (summering av ikryssade rader,AntalikryssadeRader)
    End Function
    'Summerar antalet ikryssade rader och summan på beloppen av ikryssade rader  för en specifik kolumn

    Public Function Agg_CheckedTotal_text(ColName As String) As String
        Dim checkedSum As Decimal = 0.0
        Dim checkedRows As Integer = 0
        Dim totalSum As Decimal = 0.0 'Dim sumList As ArrayList

        Dim sumList As ArrayList = New ArrayList(2)
      
        For Each childNode As TreeNode In Me.Nodes
            sumList = Agg_Checked(ColName, childNode) '' Agg_LevelText_Sum(childNode) ' Array is 3 values Checked,Totalsum,number of checke "drows)
            checkedSum += sumList(0)
            totalSum += sumList(1)
            checkedRows += sumList(2)
        Next
      
        Dim amountString As String = Graph_Pad_Left(Decimal.Round(checkedSum, 0).ToString("N0") & " kr.", 20, Me.Font) & " (av " & _
                                   Decimal.Round(totalSum, 0).ToString("N0") & " kr.)"



        Return amountString

    End Function
    Public Function Agg_Total_Amount(ColName As String) As Decimal
        Dim totalSum As Decimal = 0.0 'Dim sumList As ArrayList
        Dim sumList As ArrayList = New ArrayList(2)

        For Each childNode As TreeNode In Me.Nodes
            sumList = Agg_Checked(ColName, childNode) '' Agg_LevelText_Sum(childNode) ' Array is 3 values Checked,Totalsum,number of checke "drows)
            totalSum += sumList(1)

        Next

        Return totalSum

    End Function
    'Denna funktion summerar amount-värden för barnnoderna där noden är ikryssad (rekursivt) använder den kolumn(ColName) som anges    
    Private Function Agg_Checked(ByVal ColName As String, ByRef node As TreeNode) As ArrayList
        'Kolla ifall denna nod är ett löv
        Dim sumList As ArrayList
        Dim checkedRows As Integer = 0
        Dim checkedSum As Decimal = 0.0
        Dim totalSum As Decimal = 0.0
        If node.Nodes.Count = 0 Then
            'Returnera denna rads amount Om noden är ikryssad. 

            'Hämta dataraden som sparats i Tag
            Dim dataRow As DataRow = CType(node.Tag, DataRow)
            totalSum = CType(dataRow(ColName), Decimal)
            If node.Checked = True Then
                checkedSum = CType(dataRow(ColName), Decimal)
                If CType(node.Tag, DataRow).Table.Columns.Contains("Antal_underlag") Then checkedRows = CType(node.Tag, DataRow)("Antal_underlag") Else checkedRows = 1
            End If
        Else 'Har Children
            For Each childNode As TreeNode In node.Nodes
                Dim sl As ArrayList = Agg_Checked(ColName, childNode)
                checkedSum += sl(0)
                totalSum += sl(1)
                checkedRows += sl(2)

            Next

        End If
        sumList = New ArrayList
        sumList.Add(checkedSum)
        sumList.Add(totalSum)
        sumList.Add(checkedRows)

        Return sumList  'returnerar (summering av ikryssade rader,AntalikryssadeRader)
    End Function
    Public Overridable Function Agg_conditional_text(ByVal columnName As String, ByVal columnValue As String) As String
        Dim sumList As ArrayList = New ArrayList(4)

        sumList = Agg_Conditional_CheckedTotal(columnName, columnValue)
        '" & sumList(CondCols.checkedRows) & " st
        Return Graph_Pad_Left(Convert.ToDecimal(sumList(CondCols.checkedSum)).ToString("N0") & " kr.", 20, Me.Font) & "(" & Convert.ToDecimal(sumList(CondCols.totalSum)).ToString("N0") & " kr. " & Convert.ToInt32(sumList(CondCols.totalRows)).ToString("N0") & " st.)"
    End Function
    'Summerar antalet ikryssade rader och summan på beloppen av ikryssade rader samt totala antalet rader och summor
    Private Function Agg_Conditional_CheckedTotal(ByVal columnName As String, ByVal columnValue As String) As ArrayList
        Dim sumList As ArrayList
        Dim totalSum As Double = 0.0
        Dim totalRows As Integer = 0
        Dim checkedSum As Double = 0.0
        Dim checkedRows As Integer = 0

        For Each node In Me.Nodes
            Dim sl As ArrayList
            sl = Agg_Conditional_Checked(node, columnName, columnValue)
            checkedSum += sl(CondCols.checkedSum)
            checkedRows += sl(CondCols.checkedRows)
            totalSum += sl(CondCols.totalSum)
            totalRows += sl(CondCols.totalRows)
        Next
        sumList = New ArrayList
        sumList.Add(checkedRows)
        sumList.Add(checkedSum)
        sumList.Add(totalRows)
        sumList.Add(totalSum)
        Return sumList
    End Function
    'Denna funktion summerar amount-värden för barnnoderna (rekursivt) använder den kolumn(decimal) som anges
    Private Function Agg_Conditional_Checked(ByRef node As TreeNode, ByVal columnName As String, ByVal columnValue As String) As ArrayList
        'Kolla ifall denna nod är ett löv
        Dim sumList As ArrayList = New ArrayList(4)
        Dim totalSum As Double = 0.0
        Dim totalRows As Integer = 0
        Dim checkedRows As Integer = 0
        Dim checkedSum As Decimal = 0.0
        If node.Nodes.Count = 0 Then
            'Kontrollera om raden är av rätt typ
            'Hämta dataraden som sparats i Tag
            Dim dataRow As DataRow = CType(node.Tag, DataRow)

            If dataRow(columnName).ToString.ToUpper.TrimEnd = columnValue.ToUpper Then
                If CType(node.Tag, DataRow).Table.Columns.Contains("Antal_underlag") Then totalRows = CType(node.Tag, DataRow)("Antal_underlag") Else totalRows = 1

                totalSum = CType(dataRow(colAmountName), Decimal)
                'Returnera denna rads amount Om noden är ikryssad. 
                If node.Checked = True Then
                    checkedSum = CType(dataRow(colAmountName), Decimal)
                    If CType(node.Tag, DataRow).Table.Columns.Contains("Antal_underlag") Then checkedRows = CType(node.Tag, DataRow)("Antal_underlag") Else checkedRows = 1


                End If
            End If
        Else 'Har Children
            For Each childNode As TreeNode In node.Nodes
                Dim sl As ArrayList = Agg_Conditional_Checked(childNode, columnName, columnValue)
                checkedSum += sl(CondCols.checkedSum)
                checkedRows += sl(CondCols.checkedRows)
                totalSum += sl(CondCols.totalSum)
                totalRows += sl(CondCols.totalRows)

            Next

        End If
        sumList = New ArrayList
        sumList.Add(checkedRows)
        sumList.Add(checkedSum)
        sumList.Add(totalRows)
        sumList.Add(totalSum)
        Return sumList  'returnerar (summering av ikryssade rader,AntalikryssadeRader)
    End Function

    'Genererar TagText med summering av noderna baserat på DataView skall returnera ArrayList(CheckedSum,totalSum,checkedRows)
    Overridable Function Agg_LevelText_Sum(ByRef node As TreeNode) As ArrayList
        Dim checkedSum As Decimal = 0.0
        Dim totalSum As Decimal = 0.0
        Dim checkedRows As Integer = 0
        Dim row As DataRow = CType(node.Tag, DataRow)
        Dim sumList As ArrayList
        'Sätt värden på barnnoder och rekursivt summera dem.
        If node.Nodes.Count > 0 Then
            For Each childNode As TreeNode In node.Nodes
                sumList = Agg_LevelText_Sum(childNode)
                checkedSum += sumList(0)
                totalSum += sumList(1)
                checkedRows += sumList(2)

            Next
        Else
            If node.Checked = True Then
                checkedSum = row(colAmountName)
                If CType(node.Tag, DataRow).Table.Columns.Contains("Antal_underlag") Then checkedRows = CType(node.Tag, DataRow)("Antal_underlag") Else checkedRows = 1


            Else
                checkedSum = 0.0
                checkedRows = 0
            End If
            totalSum = row(colAmountName)

        End If

        'Sätter text
        'Sätter text
        Dim amountString As String = Decimal.Round(checkedSum, 0).ToString("N0") & " kr (" & _
                                     Decimal.Round(totalSum, 0).ToString("N0") & ")"

        If node.Level = Me.getColGroupSumName().Length - 1 Then


            node.Text = Graph_Pad_Right(LevelText(node.Level, row), 120, Me.Font) & Graph_Pad_Left((Decimal.Round(totalSum, 0).ToString("N0") & " kr"), 50, Me.Font)
        Else
            node.Text = Graph_Pad_Right(LevelText(node.Level, row), 120, Me.Font) & Graph_Pad_Left((Decimal.Round(checkedSum, 0).ToString("N0") & " kr"), 50, Me.Font) & _
            " (" & Decimal.Round(totalSum, 0).ToString("N0") & ")"

        End If

        node.ToolTipText = LevelToolTipText(node.Level, row)
        node.ForeColor = LevelForeGroundColor(node.Level, row)



        sumList = New ArrayList(3)
        sumList.Add(checkedSum)
        sumList.Add(totalSum)
        sumList.Add(checkedRows)
        Return sumList
    End Function
    Protected Sub Agg_All_LevelText_Sum()
        Dim checkedSum As Decimal = 0.0
        Dim checkedRows As Integer = 0
        Dim totalSum As Decimal = 0.0 'Dim sumList As ArrayList

        Dim sumList As ArrayList = New ArrayList(2)
        Me.BeginUpdate()
        CheckedIsCounted = False : TotalIsCounted = False

        For Each childNode As TreeNode In Me.Nodes
            sumList = Agg_LevelText_Sum(childNode) ' Array is 3 values Checked,Totalsum,number of checkedrows)
            checkedSum += sumList(0)
            totalSum += sumList(1)
            checkedRows += sumList(2)
        Next
        Me.EndUpdate()
        Checked_TotalAmount = checkedSum
        TotalCheckedRows = checkedRows
        TotalAmount = totalSum
        CheckedIsCounted = True : TotalIsCounted = True



    End Sub


    'Returnerar sorterbart namn
    Overridable Function TreeNode_getSortName(ByRef node As TreeNode) As String
        'Kolla ifall denna nod är ett löv
        Dim row As DataRow = CType(node.Tag, DataRow)
        Return row(colGroupNames(0))
        'Här kan vi istället köra ex. row("Efternamn") & ", " & "Förnamn")

    End Function
    'Returnerar sorterbar summa
    Overridable Function TreeNode_getSortAmount(ByRef node As TreeNode) As String

        Dim row As DataRow = CType(node.Tag, DataRow)
        Return row(colGroupAmountName)
        'Return Agg_Amount(node)

    End Function
    'Denna metod är rekursiv och kan ev. ändra en nods checkbox-värde beroende på hur många barn som är ikryssade.
    Private Function GenerateCheckedFromChildNodes(ByRef node As TreeNode) As Double
        'All, Some ,None
        'Det är viktigt att kolla att noden har ett värde för när den = Nothing stoppas rekursionen.

        If node Is Nothing Then

            Return 0.0
        Else
            If node.Nodes.Count = 0 Then
                'Inga barn/child räkna ikryssning
                If node.Checked = True Then Return 1.0 Else Return 0.0
            Else
                'Beräkna hur många procent av lövnoderna som är ikryssade
                Dim PercentChecked As Double = 0.0
                For Each childNode As TreeNode In node.Nodes
                    PercentChecked = PercentChecked + GenerateCheckedFromChildNodes(childNode)
                Next
                If PercentChecked / node.Nodes.Count = 1.0 Then
                    If node.Checked = False Then node.Checked = True
                Else
                    If node.Checked = True Then node.Checked = False
                End If


                If PercentChecked / node.Nodes.Count < 1.0 Then node.NodeFont = italicFont Else node.NodeFont = Me.Font
                If PercentChecked / node.Nodes.Count = 0.0 Then node.NodeFont = Me.Font

                Return PercentChecked / node.Nodes.Count
            End If

        End If
    End Function

    'Denna anropas när en kryssruta för en nod har blivit ibockad eller urbockad
    Public Sub CheckTreeNode_Children(ByRef node As TreeNode)
        'Hantera vilka andra noder som eventuellt ska kryssas i beroende på att denna blev ikryssad
        'För att undvika oändlig rekursion när man ändrar fler checked-värden ska man göra denna koll..
        CheckChildren(node)
        'TotalIsCounted = False
        'Finn Rootnoden för denna
        CheckedIsCounted = False
        Dim currentRootNode As TreeNode = node
        While currentRootNode.Level > 0
            currentRootNode = currentRootNode.Parent
        End While

        Me.BeginUpdate()
        GenerateCheckedFromChildNodes(currentRootNode)
        Agg_LevelText_Sum(currentRootNode)
        Me.EndUpdate()
        '          Checked_TotalAmount_WorkSUM() ' Bakgrundssummering av totalen
        'End If

    End Sub
    Public Sub CheckAll(ByVal checked As Boolean)
        CheckedIsCounted = False
        Me.SuspendLayout()

        For Each rootNode In Me.Nodes
            '   If rootNode.checked <> checked Then
            If CType(rootNode.Tag, DataRow)("checkable") = 1 Then
                rootNode.checked = checked
            Else
                rootNode.checked = False
            End If

            CheckChildren(rootNode)

            'End If


        Next
        Me.Agg_All_LevelText_Sum()

        Me.ResumeLayout()
        'Checked_TotalAmount_Sum() ' Bakgrundssummering av totalen

    End Sub
    Private Sub PaymentTreeView_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles Me.AfterCheck
        'Hantera vilka andra noder som eventuellt ska kryssas i beroende på att denna blev ikryssad
        'För att undvika oändlig rekursion när man ändrar fler checked-värden ska man göra denna koll..
        If Not e.Action = TreeViewAction.Unknown Then

            CheckedIsCounted = False
        End If
        'Status_Update()
    End Sub


    Public Function GetTotalAmount() As Decimal
        If TotalIsCounted = False Then Agg_All_Amount()
        Return TotalAmount

    End Function
    Public Function GetTotalRows() As Integer
        Return TotalRows
    End Function
    Public Function GetCheckedTotalAmount() As Decimal
        If CheckedIsCounted = False Then Agg_CheckedTotal()
        Return Checked_TotalAmount

    End Function
    Public Function GetCheckedRows() As Decimal
        If CheckedIsCounted = False Then Agg_CheckedTotal()
        Return TotalCheckedRows

    End Function
    'Om en föräldernod har blivit ikryssad ska alla barnnoderna också bli ikryssade.
    Private Sub CheckChildren(ByRef node As TreeNode)
        CheckedIsCounted = False
        For Each childNode As TreeNode In node.Nodes
            If node.Checked = True Then
                If CType(childNode.Tag, DataRow)("checkable") = 1 Then childNode.Checked = node.Checked Else childNode.Checked = False
            Else
                childNode.Checked = False
            End If
            'Gör ett rekursivt anrop till barnets barn om de finns
            CheckChildren(childNode)
        Next
    End Sub
    'Den här metoden sorterar på Efternamn och Förnamn eller på Belopp
    Public Sub Sort_RootNodes(ByVal Sort_By As SortColumn, ByVal newSortOrder As AscDesc)

        'Nu behöver jag sköta sorteringen manuellt.

        'Kolla om den senaste sorteringen av trädet var på detta värde.
        If SortedBy = Sort_By And newSortOrder = SortOrder Then
            'Här behöv inget göras
        ElseIf SortedBy = Sort_By And newSortOrder <> SortOrder Then
            'I det här fallet ska vi bara byta ordning på rotnoderna.
            'Gå igenom trädet bakifrån och skapa ett nytt träd med noder i den ordningen.
            Dim newTree As TreeView = New TreeView()



            Dim i As Integer = Me.Nodes.Count - 1
            While i >= 0
                newTree.Nodes.Add(CType(Me.Nodes(i).Clone(), TreeNode))
                i = i - 1
            End While

            'Töm nuvarande nodlista
            Me.Nodes.Clear()

            'Lägg in kopior på noderna i newTree.
            For Each node As TreeNode In newTree.Nodes
                Me.Nodes.Add(CType(node.Clone(), TreeNode))
            Next

            'Tala om vilket håll den sorterade åt så man vet till nästa gång

            SortOrder = newSortOrder
        Else
            'Trädet är sorterat på något annat värde så vi måste göra sorteringen på det mer avancerade sättet.
            'För att underlätta sorteringen använder jag min klass LinkedTreeNode.
            Dim rootNode As LinkedTreeNode = Nothing
            SortOrder = newSortOrder

            'Gå igenom alla noder i PaymentTreeView.
            For i As Integer = 0 To Me.Nodes.Count - 1
                'Hämta ut den totala summan för denna nod
                Dim node As TreeNode = Me.Nodes(i)
                Dim newLastName As String = ""
                Dim newLastAmount As Integer = 0
                If Sort_By = SortColumn.Name Then newLastName = TreeNode_getSortName(node).ToUpper
                If Sort_By = SortColumn.Amount Then newLastAmount = TreeNode_getSortAmount(node)


                'Om det här är den första noden kan den bara läggas in i linkedNodes.
                If rootNode Is Nothing Then
                    rootNode = New LinkedTreeNode(node)
                Else
                    'Gå igenom alla noder utifrån rootNode och sortera in noden på rätt ställe.
                    Dim stepNode As LinkedTreeNode = rootNode
                    Dim newNode As LinkedTreeNode = Nothing
                    Dim lastNode As LinkedTreeNode = Nothing

                    While Not stepNode Is Nothing
                        Dim thisLastName As String = ""
                        Dim thisLastAmount As Integer = 0

                        If Sort_By = SortColumn.Amount Then thisLastAmount = TreeNode_getSortAmount(stepNode.TreeViewNode)
                        If Sort_By = SortColumn.Name Then thisLastName = TreeNode_getSortName(stepNode.TreeViewNode).ToUpper


                        If (Sort_By = SortColumn.Name And newSortOrder = AscDesc.Asc And newLastName < thisLastName) _
                        Or (Sort_By = SortColumn.Name And newSortOrder = AscDesc.Desc And newLastName > thisLastName) _
                        Or (Sort_By = SortColumn.Amount And newSortOrder = AscDesc.Asc And newLastAmount < thisLastAmount) _
                        Or (Sort_By = SortColumn.Amount And newSortOrder = AscDesc.Desc And newLastAmount > thisLastAmount) _
                        Then
                            Dim nodeBefore As LinkedTreeNode = stepNode.PrevNode
                            newNode = New LinkedTreeNode(node)
                            newNode.NextNode = stepNode
                            stepNode.PrevNode = newNode

                            'Kolla om newNode ska bli ny rotnod
                            If nodeBefore Is Nothing Then
                                rootNode = newNode
                            Else
                                nodeBefore.NextNode = newNode
                                newNode.PrevNode = nodeBefore
                            End If

                            Exit While
                        End If

                        'Om stepNode pekar på den sista noden så ska den sparas
                        If stepNode.NextNode Is Nothing Then
                            lastNode = stepNode
                        End If

                        stepNode = stepNode.NextNode
                    End While

                    'Om newNode fortfarande är Nothing så betyder det att den nya noden ska läggas sist.
                    If newNode Is Nothing Then
                        newNode = New LinkedTreeNode(node)
                        lastNode.NextNode = newNode
                        newNode.PrevNode = lastNode
                    End If
                End If
            Next

            'Töm nodlistan i PaymentTreeView
            Me.Nodes.Clear()

            'Lägg in nya noder från den sorterade länkade listan
            Dim jumpNode As LinkedTreeNode = rootNode

            While Not jumpNode Is Nothing
                Me.Nodes.Add(jumpNode.TreeViewNode)
                jumpNode = jumpNode.NextNode
            End While

        End If

        SortedBy = Sort_By
        SortOrder = newSortOrder



    End Sub
    Public Sub Sort_RootNodes_test(ByVal Sort_By As SortColumn, ByVal newSortOrder As AscDesc, ByRef comp As Comparer)

        'Nu behöver jag sköta sorteringen manuellt.

        'Kolla om den senaste sorteringen av trädet var på detta värde.
        If SortedBy = Sort_By And newSortOrder = SortOrder Then
            'Här behöv inget göras
        ElseIf SortedBy = Sort_By And newSortOrder <> SortOrder Then
            'I det här fallet ska vi bara byta ordning på rotnoderna.
            'Gå igenom trädet bakifrån och skapa ett nytt träd med noder i den ordningen.
            Dim newTree As TreeView = New TreeView()



            Dim i As Integer = Me.Nodes.Count - 1
            While i >= 0
                newTree.Nodes.Add(CType(Me.Nodes(i).Clone(), TreeNode))
                i = i - 1
            End While

            'Töm nuvarande nodlista
            Me.Nodes.Clear()

            'Lägg in kopior på noderna i newTree.
            For Each node As TreeNode In newTree.Nodes
                Me.Nodes.Add(CType(node.Clone(), TreeNode))
            Next

            'Tala om vilket håll den sorterade åt så man vet till nästa gång

            SortOrder = newSortOrder
        Else
            SortOrder = newSortOrder

            'Gå igenom alla noder i PaymentTreeView.
            Dim l As ArrayList = New ArrayList(Me.Nodes.Count)
            'Dim childNode As TreeNode
            For Each childNode In Me.Nodes
                l.Add(childNode)
            Next
            l.Sort(comp)

            '            Me.BeginUpdate()
            Me.Nodes.Clear()
            For Each childNode In l
                Me.Nodes.Add(childNode)
                'Me.EndUpdate()
            Next
            SortedBy = Sort_By
            SortOrder = newSortOrder
        End If


    End Sub
End Class
