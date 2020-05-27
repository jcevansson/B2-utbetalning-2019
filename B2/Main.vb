
Imports System.Globalization
Public Class Main

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox.Show()
    End Sub

    Private Sub SynkroniseringAvBetalningarMotToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SynkroniseringAvBetalningaToolStripMenuItem.Click
      
        Dim fu As DSynk
        fu = New DSynk
        fu.Show()

    End Sub

    Private Sub GodkännaUnderlagToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GodkännaUnderlagToolStripMenuItem.Click
        Dim fu As FormUnderlag
        fu = New FormUnderlag
        fu.Show()

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
        REM todo FRÅGA OM DET FINNS ÖPPNA FÖNSTER

    End Sub

    Private Sub UtbetalningarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UtbetalningarToolStripMenuItem.Click
        Dim fu As FormUtbetalning
        fu = New FormUtbetalning
        fu.Show()

    End Sub

    Private Sub GjordaBetalningarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GjordaBetalningarToolStripMenuItem.Click
        Dim fu As FormTransaktion
        fu = New FormTransaktion
        fu.Show()
    End Sub

    Private Sub TestfönsterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestfönsterToolStripMenuItem.Click
        Dim fu As TestFönster
        fu = New TestFönster
        fu.Show()
    End Sub

    Private Sub DecimaltestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DecimaltestToolStripMenuItem.Click
        Dim d As Decimal = 1234567.05
        Dim sv As CultureInfo = New CultureInfo("sv-SE")
        'sv.NumberFormat.NumberGroupSeparator = " "
        'Dim mysizes As Integer() = {3, 3, 3}
        '  sv.NumberFormat.NumberGroupSizes = mysizes
        While MsgBox(d.ToString("N0"), MsgBoxStyle.OkCancel) = MsgBoxResult.Ok

        End While


    End Sub

    Private Sub KontrolluppgifterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KontrolluppgifterToolStripMenuItem.Click
        
    End Sub

    Private Sub GenereraKUfilToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenereraKUfilToolStripMenuItem.Click
        Dim ku As FormKontrolluppgifter
        ku = New FormKontrolluppgifter
        ku.Show()
    End Sub

    Private Sub EnskildKontrolluppgiftToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnskildKontrolluppgiftToolStripMenuItem.Click
        Dim ku As FormKontrolluppgiftEnskild
        ku = New FormKontrolluppgiftEnskild
        ku.Show()
    End Sub

    Private Sub PRVStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PRVStripMenuItem.Click

        Dim Y As Int16 = CType(sender, ToolStripMenuItem).Tag
        Dim f As Main_PRV
        f = New Main_PRV
        f.setYear(Y)
        f.Show()
    End Sub

    Private Sub Main_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim ddi As ToolStripDropDownItem
        For i As Int16 = Date.Now().Year - 1 To 2015 Step -1
            ddi = PRVStripMenuItem.DropDownItems.Add(i.ToString)
            ddi.Tag = i
            ddi.ToolTipText = "Innestående medel " + i.ToString
            AddHandler ddi.Click, AddressOf PRVStripMenuItem_Click
        Next i

    End Sub
End Class
