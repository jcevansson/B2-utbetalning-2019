Imports System.Windows.Forms
Imports System.Data.SqlClient


Public Class FormTransaktion_inställningar

    Private Property tb_PG_ALT1_Beteckning2 As Object

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        'My.Settings.PG_ALT1_Beteckning1 = tb_PG_ALT1_Beteckning1.Text
        'My.Settings.PG_ALT1_Beteckning2 = tb_PG_ALT1_Beteckning2.Text
        'My.Settings.PG_ALT1_Kod = tb_PG_ALT1_Kod.Text
        'My.Settings.PG_ALT1_Konto = tb_PG_ALT1_Konto.Text
        'My.Settings.PG_ALT1_Kundnummer = tb_PG_ALT1_Kundnummer.Text
        'My.Settings.PG_ALT1_Referens = tb_PG_ALT1_Referens.Text
        '
        '       My.Settings.PG_ALT2_Beteckning1 = tb_PG_ALT2_Beteckning1.Text
        '       My.Settings.PG_ALT2_Beteckning2 = tb_PG_ALT2_Beteckning2.Text
        '       My.Settings.PG_ALT2_Kod = tb_PG_ALT2_Kod.Text
        '       My.Settings.PG_ALT2_Konto = tb_PG_ALT2_Konto.Text
        '       My.Settings.PG_ALT2_Kundnummer = tb_PG_ALT2_Kundnummer.Text
        '       My.Settings.PG_ALT2_Referens = tb_PG_ALT2_Referens.Text

        'My.Settings.PG_Meddelande = tb_PG_Meddelande.Text
        'My.Settings.PG_Produktionsdatum = tb_PG_Produktionsdatum.Text
        'My.Settings.PG_Produktionsnummer = tb_PG_Produktionsnummer.Text

        If RB_BG_ALT1.Checked = True Then My.Settings.PG_ALT = 1 Else My.Settings.PG_ALT = 2

        My.Settings.BG_ALT1_BankGiro = tb_BG_ALT1_BankGiro.Text
        My.Settings.BG_ALT2_BankGiro = tb_BG_ALT2_BankGiro.Text
        My.Settings.BG_Meddelande = tb_BG_Meddelande.Text
        My.Settings.BG_Nettorubrik = tb_BG_Nettorubrik.Text
        My.Settings.BG_Produktionsdatum = tb_BG_Produktionsdatum.Text
        My.Settings.BG_Produktionsnummer = Integer.Parse(tb_BG_Produktionsnummer.Text)
        My.Settings.BG_Rubrik = tb_BG_Rubrik.Text
        My.Settings.BG_Specifikation = tb_BG_Specifikation.Text

        '        If My.Settings.BG_ALT = 1 Then rb_PG_Avsändare1.Checked = True Else RB_BG_ALT2.Checked = True

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FormTransaktion_inställningar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '        tb_PG_ALT1_Beteckning1.Text = My.Settings.PG_ALT1_Beteckning1.ToString
        '        tb_PG_ALT1_Beteckning2.Text = My.Settings.PG_ALT1_Beteckning2.ToString
        '        tb_PG_ALT1_Kod.Text = My.Settings.PG_ALT1_Kod.ToString
        '        tb_PG_ALT1_Konto.Text = My.Settings.PG_ALT1_Konto.ToString
        '        tb_PG_ALT1_Kundnummer.Text = My.Settings.PG_ALT1_Kundnummer.ToString
        '        tb_PG_ALT1_Referens.Text = My.Settings.PG_ALT1_Referens.ToString

        'tb_PG_ALT2_Beteckning1.Text = My.Settings.PG_ALT2_Beteckning1.ToString
        'tb_PG_ALT2_Beteckning2.Text = My.Settings.PG_ALT2_Beteckning2.ToString
        'tb_PG_ALT2_Kod.Text = My.Settings.PG_ALT2_Kod.ToString
        'tb_PG_ALT2_Konto.Text = My.Settings.PG_ALT2_Konto.ToString
        'tb_PG_ALT2_Kundnummer.Text = My.Settings.PG_ALT2_Kundnummer.ToString
        'tb_PG_ALT2_Referens.Text = My.Settings.PG_ALT2_Referens.ToUpper

        'tb_PG_Meddelande.Text = My.Settings.PG_Meddelande.ToString
        'tb_PG_Produktionsdatum.Text = (New Date).Today.ToShortDateString 'My.Settings.PG_Produktionsdatum.ToShortDateString
        'tb_PG_Produktionsnummer.Text = Get_Produktionsnummer(tb_PG_Produktionsdatum.Text, "PLUSGIRO") 'My.Settings.PG_Produktionsnummer.ToString

        If My.Settings.PG_ALT = 1 Then RB_BG_ALT1.Checked = True Else RB_BG_ALT2.Checked = True

        tb_BG_ALT1_BankGiro.Text = My.Settings.BG_ALT1_BankGiro.ToString
        tb_BG_ALT2_BankGiro.Text = My.Settings.BG_ALT2_BankGiro.ToString
        tb_BG_Meddelande.Text = My.Settings.BG_Meddelande.ToString
        tb_BG_Nettorubrik.Text = My.Settings.BG_Nettorubrik.ToString
        tb_BG_Produktionsdatum.Text = (New Date).Today.ToShortDateString 'My.Settings.BG_Produktionsdatum.ToShortDateString
        tb_BG_Produktionsnummer.Text = Get_Produktionsnummer(tb_BG_Produktionsdatum.Text, "BANKGIRO")
        tb_BG_Rubrik.Text = My.Settings.BG_Rubrik.ToString
        tb_BG_Specifikation.Text = My.Settings.BG_Specifikation

        'If My.Settings.BG_ALT = 1 Then rb_BG_Avsändare1.Checked = True Else RB_BG_ALT2.Checked = True


    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_BG_ALT2_BankGiro.TextChanged

    End Sub
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

    Private Sub tb_BG_Produktionsdatum_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_BG_Produktionsdatum.LostFocus
        tb_BG_Produktionsnummer.Text = Get_Produktionsnummer(tb_BG_Produktionsdatum.Text, "BANKGIRO") 'My.Settings.PG_Produktionsnummer.ToString
    End Sub

    'Private Sub tb_PG_Produktionsdatum_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    tb_PG_Produktionsnummer.Text = Get_Produktionsnummer(tb_PG_Produktionsdatum.Text, "PLUSGIRO") 'My.Settings.PG_Produktionsnummer.ToString
    'End Sub
End Class
