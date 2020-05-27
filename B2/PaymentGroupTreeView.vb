Public Class PaymentGroupTreeView
    Inherits GroupTreeView
    Public Overrides Function LevelText(ByVal l As Integer, ByRef row As System.Data.DataRow) As String
        Dim s As String
        If l = 0 Then
            s = Graph_Pad_Right(row("efternamn").ToString() & ",  " & row("förnamn").ToString(), 60, Me.Font) & row("personnummer").ToString()
        ElseIf l = 2 Then
            s = CType(row("registrerat datum"), Date).ToShortDateString()
        Else
            s = MyBase.LevelText(l, row)
        End If


        Return s
    End Function
    Public Overrides Function LevelToolTipText(ByVal l As Integer, ByRef row As System.Data.DataRow) As String

        If l = 0 Then
            's = "Upphovsman"
            If row("DödsBoEjKlart").ToString = "1" Then
                Return " Dödsbo Ej Klart"
            ElseIf row("antalMottagare").ToString = "0" Then
                Return " Saknas mottagare"
            Else
                Return ("")
            End If
        ElseIf l = 1 Then
            Return "Betalningstyp"
        ElseIf l = 2 Then
            Return row("Kommentar").ToString
        Else
            Try
                Return row(Me.getColGroupSumName()(l)).ToString
            Catch e As Exception
                Return ""
            Finally
            End Try

        End If


    End Function
    
End Class
