Imports System.Text
Public Class TestFönster

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Node As TreeNode
        Dim rnd As Random = New Random
        Dim s As String
        Dim WidthOfSpace As Decimal = TextRenderer.MeasureText("".PadLeft(1000, " "), TreeView1.Font).Width / 1000.0
        Dim WidthOfDot As Decimal = TextRenderer.MeasureText("".PadLeft(1000, Strings.Chr(39)), TreeView1.Font).Width / 1000.0
        Dim WidthOfLT As Decimal = TextRenderer.MeasureText("".PadLeft(1000, "LT"), TreeView1.Font).Width / 1000.0
        TextBox1.Text = "WidthOfSpace=" & WidthOfSpace & Environment.NewLine & "WidthOfDot=" & WidthOfDot & Environment.NewLine
        TextBox1.Text &= "WidthOfSingleSpace=" & TextRenderer.MeasureText(" ", TreeView1.Font).Width & _
        Environment.NewLine & "WidthOfSingleDot=" & TextRenderer.MeasureText(Strings.Chr(39), TreeView1.Font).Width & Environment.NewLine
        TextBox1.Text &= "WidthOfCHAR1474=" & TextRenderer.MeasureText(Strings.ChrW(1474), TreeView1.Font).Width & Environment.NewLine
        TextBox1.Text &= "WidthOfCHAR1473-4=" & TextRenderer.MeasureText(Strings.ChrW(1473) & Strings.ChrW(1474), TreeView1.Font).Width & Environment.NewLine

        Dim WidthOfChar As Decimal
        For i = 1 To 3000
            WidthOfChar = TextRenderer.MeasureText("".PadLeft(100, Strings.ChrW(i)), TreeView1.Font).Width / 100.0
            If WidthOfChar < WidthOfSpace - 0.1 And WidthOfChar > 0.1 Then
                TextBox1.Text &= Strings.ChrW(i) & " CHAR" & i & " = " & WidthOfChar & " WithPad=" & TextRenderer.MeasureText(Strings.ChrW(i), TreeView1.Font).Width & Environment.NewLine
            End If

        Next

        Dim t As Stopwatch = New Stopwatch
        t.Reset() : t.Start()
        TextBox1.Text &= "plain start" & Environment.NewLine
        For i = 1 To 10
            For Each Node In TreeView1.Nodes
                s = ">"
                s.PadRight(rnd.Next / rnd.Next.MaxValue * 15, "r")
                s.PadRight(rnd.Next / rnd.Next.MaxValue * 15, "Ö")
                Node.Text = Graph_Pad_Right(s, 50, TreeView1.Font) & "<"

            Next
        Next i
        TextBox1.Text &= "plain " & t.ElapsedMilliseconds & Environment.NewLine

        t.Reset() : t.Start()
        TextBox1.Text &= "sb START " & t.ElapsedMilliseconds & Environment.NewLine

        Dim sb As StringBuilder = New StringBuilder()

        For i = 1 To 10
            For Each Node In TreeView1.Nodes
                sb.Length = 0
                sb.Append(">").Append("r", 10).Append("Ö", 10)
                SB_Graph_Pad_Right(sb, 50, TreeView1.Font)
                sb.Append("<")
                Node.Text = sb.ToString
            Next
        Next i
        TextBox1.Text &= "plain " & t.ElapsedMilliseconds & Environment.NewLine

    End Sub

    Function Graph_Pad_Right(ByRef stringToPad As String, ByVal preferedWidthInChar As Int16, ByVal font As Font) As String
        'Genererar ett antal mellanslag för att nå upp i en specifik bredd (mätt i mellanslag)
        'Använder japanska apostrofer för att fylla ut i början för att justera litet
        '      Dim WidthOfDot As Int16 = TextRenderer.MeasureText(Strings.Chr(39), font).Width - FontPadding
        Dim WidthOfSpace As Int16 = TextRenderer.MeasureText("  ", Me.Font).Width - TextRenderer.MeasureText(" ", Me.Font).Width
        Dim FontPadding As Int16 = TextRenderer.MeasureText(" ", Me.Font).Width - WidthOfSpace
        Dim WidthOfString As Int16 = TextRenderer.MeasureText(stringToPad.ToString, font).Width - FontPadding

        Dim WidthOfPreferedString As Int16 = WidthOfSpace * preferedWidthInChar
        Dim WidthOfPadString As Int16 = WidthOfPreferedString - WidthOfString
        Dim LengthOfPadString As Int16
        Dim DotString As String = ""
        If WidthOfPadString Mod WidthOfSpace = 0 Then
            LengthOfPadString = Math.Floor(WidthOfPadString / WidthOfSpace) - 1
            DotString = ""
        ElseIf WidthOfPadString Mod WidthOfSpace = 1 Then
            LengthOfPadString = Math.Floor(WidthOfPadString / WidthOfSpace) ' - 1
            DotString = Strings.ChrW(1473) & Strings.ChrW(1474)
        ElseIf WidthOfPadString Mod WidthOfSpace = 2 Then
            LengthOfPadString = Math.Floor(WidthOfPadString / WidthOfSpace)
            DotString = Strings.ChrW(1474)

        End If

        If LengthOfPadString < 0 Then

            Return stringToPad
        Else
            '    Dim WidthResultString As Int16 = TextRenderer.MeasureText(stringToPad & DotString & "".PadLeft(LengthOfPadString, " "), font).Width - FontPadding
            Return stringToPad & DotString.PadRight(LengthOfPadString, " ")

        End If
    End Function
    Sub SB_Graph_Pad_Right(ByRef stringToPad As StringBuilder, ByVal preferedWidthInChar As Int16, ByVal font As Font)
        'Genererar ett antal mellanslag för att nå upp i en specifik bredd (mätt i mellanslag)
        'Använder japanska apostrofer för att fylla ut i början för att justera litet
        '      Dim WidthOfDot As Int16 = TextRenderer.MeasureText(Strings.Chr(39), font).Width - FontPadding
        Dim WidthOfSpace As Int16 = TextRenderer.MeasureText("  ", Me.Font).Width - TextRenderer.MeasureText(" ", Me.Font).Width
        Dim FontPadding As Int16 = TextRenderer.MeasureText(" ", Me.Font).Width - WidthOfSpace
        Dim WidthOfString As Int16 = TextRenderer.MeasureText(stringToPad.ToString, font).Width - FontPadding

        Dim WidthOfPreferedString As Int16 = WidthOfSpace * preferedWidthInChar
        Dim WidthOfPadString As Int16 = WidthOfPreferedString - WidthOfString
        Dim LengthOfPadString As Int16
        Dim DotString As String = ""
        If WidthOfPadString Mod WidthOfSpace = 0 Then
            LengthOfPadString = Math.Floor(WidthOfPadString / WidthOfSpace) - 1
            DotString = ""
        ElseIf WidthOfPadString Mod WidthOfSpace = 1 Then
            LengthOfPadString = Math.Floor(WidthOfPadString / WidthOfSpace) ' - 1
            DotString = Strings.ChrW(1473) & Strings.ChrW(1474)
        ElseIf WidthOfPadString Mod WidthOfSpace = 2 Then
            LengthOfPadString = Math.Floor(WidthOfPadString / WidthOfSpace)
            DotString = Strings.ChrW(1474)

        End If

        If LengthOfPadString < 0 Then

            '    Return stringToPad
        Else
            '    Dim WidthResultString As Int16 = TextRenderer.MeasureText(stringToPad & DotString & "".PadLeft(LengthOfPadString, " "), font).Width - FontPadding
            stringToPad.Append(DotString).Append(" ", LengthOfPadString)

        End If
    End Sub
End Class