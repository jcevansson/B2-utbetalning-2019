Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Public Class FormKontrolluppgift

    Private Sub FormKontrolluppgift_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'B2dsKontrolluppgift.betalning_kontrolluppgift' table. You can move, or remove it, as needed.
        Me.Betalning_kontrolluppgiftTableAdapter.Connection = New SqlConnection(My.Settings.DBconnectionString)
        Me.Betalning_kontrolluppgiftTableAdapter.Fill(Me.B2dsKontrolluppgift.betalning_kontrolluppgift)

        cbÄrvdRoyalty.Checked = True
        NumericUpDown1.Value = Today.AddMonths(-1).Year
        nupMånad.Enabled = True
        nupMånad.Value = Today.AddMonths(-1).Month

        Dim toolTip1 As ToolTip = New ToolTip
        toolTip1.SetToolTip(bGenereraKU, "Generera XML-fil att skicka till Skattemyndigheten")
        toolTip1 = New ToolTip
        toolTip1.SetToolTip(bUnderlag, "Skapa alla kontrolluppgifter för perioden, sedan kan du ändra dem innan du genererar fil åt skattemyndigheten ")
        toolTip1 = New ToolTip
        toolTip1.SetToolTip(tbPNRORG, "Fritextfilter ")


        setDatumStr()
    End Sub

    Private Sub cbÄrvdRoyalty_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbÄrvdRoyalty.CheckedChanged
        If cbÄrvdRoyalty.Checked = True Then
            If Today.Month = 1 Then
                NumericUpDown1.Value = Today.Year - 1
                nupMånad.Value = 12
            Else
                NumericUpDown1.Value = Today.Year
                nupMånad.Value = Today.Month - 1
            End If

            nupMånad.Enabled = True

        Else
            NumericUpDown1.Value = Today.Year - 1
            nupMånad.Enabled = False
            nupMånad.Value = Today.Month
        End If

        setDatumStr()
    End Sub
    Sub setDatumStr()
        If cbÄrvdRoyalty.Checked = True Then
            lDatumStr.Text = Format(NumericUpDown1.Value, "0000") + Format(nupMånad.Value, "00")
        Else
            lDatumStr.Text = Format(NumericUpDown1.Value, "0000")
        End If

        Try
            Me.Betalning_kontrolluppgiftTableAdapter.FillBy(Me.B2dsKontrolluppgift.betalning_kontrolluppgift, lDatumStr.Text)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NumericUpDown1.ValueChanged
  
        setDatumStr()

    End Sub

    Private Sub nupMånad_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nupMånad.ValueChanged
    
        setDatumStr()
    End Sub



    

    Private Sub dgKontrolluppgift_DefaultValuesNeeded(sender As Object, e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgKontrolluppgift.DefaultValuesNeeded
        If cbÄrvdRoyalty.Checked = True Then e.Row.Cells(1).Value = "R" Else e.Row.Cells(1).Value = "U"
        e.Row.Cells(2).Value = lDatumStr.Text
        e.Row.Cells(3).Selected = True
        e.Row.Cells(3).Value = ""
        e.Row.Cells(4).Value = ""
        e.Row.Cells(5).Value = ""
        e.Row.Cells(6).Value = ""
        e.Row.Cells(7).Value = 0

    End Sub

  

    Private Sub bUnderlag_Click(sender As System.Object, e As System.EventArgs) Handles bUnderlag.Click
        If MsgBox("Du kommer skriva över eventuella tidigare kontrolluppgifter för perioden " + lDatumStr.Text, MsgBoxStyle.OkCancel, "hämta underlag för perioden") = MsgBoxResult.Ok Then
            Dim sqlConn As SqlConnection = New SqlConnection(My.Settings.DBconnectionString)
            'Try
            sqlConn.Open()

            Dim selectCommand As SqlCommand = New SqlCommand()
            Dim parmID As SqlParameter
            selectCommand.CommandType = CommandType.StoredProcedure
            selectCommand.CommandText = "[sp_betalning_kontrolluppgift_skapa_period]"

            parmID = selectCommand.Parameters.Add("PeriodStr", SqlDbType.Char)
            parmID.Value = lDatumStr.Text

            System.Console.WriteLine(selectCommand.CommandText.ToString & " " & parmID.Value)
            selectCommand.Connection = sqlConn
            Dim reader As SqlDataReader = selectCommand.ExecuteReader

            setDatumStr()
        End If

    End Sub

    Private Sub tbPNRORG_TextChanged(sender As System.Object, e As System.EventArgs) Handles tbPNRORG.TextChanged
        BetalningkontrolluppgiftBindingSource.Filter = " PErsonnummer like '%" + tbPNRORG.Text.Trim + "%' OR Organisationsnummer like '%" + tbPNRORG.Text.Trim + "%' OR Förnamn like '%" + tbPNRORG.Text.Trim + "%' OR Efternamn like '%" + tbPNRORG.Text.Trim + "%'"
    End Sub


    Private Sub GenereraKU()

        Dim MAXNAMN As Integer
        Dim MAXADRESS As Integer
        MAXNAMN = 35 : MAXADRESS = 25



        REM ***********
        SFD_Kontrolluppgift.FileName = "Skatteverket_KU_" + lDatumStr.Text
        If (SFD_Kontrolluppgift.ShowDialog = Windows.Forms.DialogResult.OK And SFD_Kontrolluppgift.FileName.Length > 0) Then
            Dim outString As StringBuilder = New StringBuilder
            Dim str As StringBuilder = New StringBuilder

            Dim sqlConn As SqlConnection = New SqlConnection(My.Settings.DBconnectionString)
            sqlConn.Open()
            Dim selectCommand As SqlCommand = New SqlCommand()
            selectCommand.CommandType = CommandType.Text
            selectCommand.CommandText = "SELECT *" & _
                        "from betalning_kontrolluppgift  where PeriodStr=" & lDatumStr.Text & " and typ in ('U') order by Typ,PeriodStr,efternamn,förnamn,personnummer,OrganisationsNummer"
            selectCommand.Connection = sqlConn
            System.Console.WriteLine(selectCommand.CommandText.ToString)
            Dim reader As SqlDataReader = selectCommand.ExecuteReader
            Dim index As Integer = 0

            '-----------------------       
            outString.AppendLine("<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>")
            outString.AppendLine("<Skatteverket xmlns=""http://xmls.skatteverket.se/se/skatteverket/ai/instans/infoForBeskattning/5.0"" xmlns:gm=""http://xmls.skatteverket.se/se/skatteverket/ai/gemensamt/infoForBeskattning/5.0"" xmlns:ku=""http://xmls.skatteverket.se/se/skatteverket/ai/komponent/infoForBeskattning/5.0"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" omrade=""Kontrolluppgifter"" xsi:schemaLocation=""http://xmls.skatteverket.se/se/skatteverket/ai/instans/infoForBeskattning/5.0 http://xmls.skatteverket.se/se/skatteverket/ai/kontrolluppgift/instans/Kontrolluppgifter_5.0.xsd ""> ")
            outString.AppendLine("<ku:Avsandare>")
            outString.AppendLine("<ku:Programnamn>KUfilsprogrammet</ku:Programnamn>  ")
            outString.AppendLine("<ku:Organisationsnummer>" & My.Settings.KU_UG.Trim & "</ku:Organisationsnummer>")
            outString.AppendLine("<ku:TekniskKontaktperson>")
            outString.AppendLine("<ku:Namn>" & My.Settings.KU_Kontakt.Trim & "</ku:Namn>")
            outString.AppendLine("<ku:Telefon>" & My.Settings.KU_Telefon.Trim & "</ku:Telefon>")
            outString.AppendLine("   <ku:Epostadress>" & My.Settings.KU_Email.Trim & "</ku:Epostadress> ")
            outString.AppendLine("  <ku:Utdelningsadress1>" & My.Settings.KU_Adress.Trim & "</ku:Utdelningsadress1>")
            outString.AppendLine("<ku:Utdelningsadress2></ku:Utdelningsadress2>   ")
            outString.AppendLine("<ku:Postnummer>" & My.Settings.KU_PostNR.Trim & "</ku:Postnummer>   <ku:Postort>" & My.Settings.KU_PostOrt & "</ku:Postort> ")
            outString.AppendLine(" </ku:TekniskKontaktperson>")
            outString.AppendLine("     <ku:Skapad>" & Date.Today.ToString("yyyy-MM-ddThh:ss:mm") & "</ku:Skapad> ")  '2014-06-07T21:32:52
            outString.AppendLine("</ku:Avsandare> ")

            outString.AppendLine("  <ku:Blankettgemensamt>     <ku:Uppgiftslamnare>     ")
            outString.AppendLine("  <ku:UppgiftslamnarePersOrgnr>" & My.Settings.KU_UG.Trim & "</ku:UppgiftslamnarePersOrgnr>     ")
            outString.AppendLine("  <ku:Kontaktperson>    ")
            outString.AppendLine("<ku:Namn>" & My.Settings.KU_Kontakt.Trim & "</ku:Namn> ")
            outString.AppendLine(" <ku:Telefon>" & My.Settings.KU_Telefon.Trim & "</ku:Telefon> ")
            outString.AppendLine(" <ku:Epostadress>" & My.Settings.KU_Email.Trim & "</ku:Epostadress> ")
            outString.AppendLine(" <ku:Sakomrade>Skatteverket</ku:Sakomrade> ")
            outString.AppendLine(" </ku:Kontaktperson> ")
            outString.AppendLine(" </ku:Uppgiftslamnare>   </ku:Blankettgemensamt>   ")



            Dim felPNR As Int16 = 0
            'Dim felString As String = ""



            While reader.Read
                If PNROK(reader("Organisationsnummer")) = False And PNROK(reader("Personnummer")) = False Then
                    'felString = felString & "<O:" & reader("Organisationsnummer") & ",P" & reader("Personnummer") & ">"
                    felPNR += 1
                End If



                If ((CInt(reader("Kontrolluppgift"))) >= 100) And (PNROK(reader("Personnummer")) Or PNROK(reader("Organisationsnummer"))) Then

                    index += 1




                    outString.AppendLine("<ku:Blankett nummer=""2300"">")
                    outString.AppendLine("<ku:Arendeinformation>")
                    outString.AppendLine("<ku:Arendeagare>" & My.Settings.KU_UG.Trim & "</ku:Arendeagare>")
                    outString.AppendLine("<ku:Period>" & lDatumStr.Text.Trim & "</ku:Period>")
                    outString.AppendLine("</ku:Arendeinformation>")
                    outString.AppendLine("<ku:Blankettinnehall>")
                    outString.AppendLine("<ku:KU10>")
                    outString.AppendLine("<ku:Specifikationsnummer faltkod=""570""> " & Int(index) & " </ku:Specifikationsnummer>")
                    outString.AppendLine("<ku:Inkomstar faltkod=""203"">" & lDatumStr.Text.Trim & "</ku:Inkomstar>")


                    REM ORU=U (pphovsman)
                    'TODO Borttagningsmarkering
                    'outString.AppendLine("<ku:Borttag faltkod=""205"">1</ku:Borttag>")

                    If CInt(reader("Kontrolluppgift")) > 0 Then
                        If PNROK(reader("Organisationsnummer")) Then
                            outString.AppendLine("<ku:ErsEjSocAvg faltkod=""031""> " & CInt(reader("Kontrolluppgift")) & "</ku:ErsEjSocAvg>")
                        Else
                            outString.AppendLine("<ku:ErsMEgenavgifter faltkod=""025""> " & CInt(reader("Kontrolluppgift")) & "</ku:ErsMEgenavgifter>")
                        End If

                        '    REM outString.AppendLine("#UP 67 Royalty")

                    End If
                    'REM ORU=R (epresentant)



                    outString.AppendLine("<ku:InkomsttagareKU10>")
                    outString.Append("<ku:Inkomsttagare faltkod=""215"">")

                    If PNROK(reader("Organisationsnummer")) Then
                        outString.Append(CStr(reader("Organisationsnummer")).Substring(0, 12)) ' & "-" & CStr(reader("Organisationsnummer")).Substring(8, 4))
                        '& IIf(PNROK(CStr(reader("Organisationsnummer")).Substring(0, 12)), "OK", "Fel")

                    Else
                        outString.Append(CStr(reader("Personnummer")).Substring(0, 12))
                        '& CStr(reader("Personnummer")).Substring(8, 4))

                    End If
                    outString.AppendLine("</ku:Inkomsttagare>")

                    outString.AppendLine("</ku:InkomsttagareKU10>")


                    outString.AppendLine("<ku:UppgiftslamnareKU10> ")
                    outString.AppendLine("<ku:UppgiftslamnarId faltkod=""201"">" & My.Settings.KU_UG.Trim & "</ku:UppgiftslamnarId> ")
                    outString.AppendLine(" </ku:UppgiftslamnareKU10>")
                    outString.AppendLine("</ku:KU10>")
                    outString.AppendLine("</ku:Blankettinnehall>")
                    outString.AppendLine(" </ku:Blankett> ")

                End If
                'End If
                'End If

            End While

            outString.AppendLine("</Skatteverket> ")

            sqlConn.Close()

            reader.Close()
            File.WriteAllText(SFD_Kontrolluppgift.FileName, outString.ToString(), Encoding.GetEncoding("utf-8"))

            MsgBox(index & " poster skrivna till kufil" & IIf(felPNR > 0, ". " & felPNR.ToString() & " Felaktiga personnummer/orgnummer ej med i fil.", ""))




        End If

    End Sub
    Public Function PNROK(Pnr As String) As Boolean
        If Pnr.Length <> 12 Then Return False
        If IsNumeric(Pnr) = 0 Then Return False
        '165561670919
        'If CInt(Mid(Pnr, 5, 1)) >= 2 Then Return False ' Samordningsnummer månad>20
        'If (CInt(Mid(Pnr, 1, 2)) = 19 Or CInt(Mid(Pnr, 1, 2)) = 20) And CInt(Mid(Pnr, 7, 1)) >= 6 Then Return False ' Samordningsnummer dag>60
        'If CInt(Mid(Pnr, 7, 1)) >= 6 Then Return False ' Samordningsnummer dag>60
        If (CInt(Mid(Pnr, 1, 2)) = 19 Or CInt(Mid(Pnr, 1, 2)) = 20) And CInt(Mid(Pnr, 5, 2)) > 12 Then Return False ' felaktig månad
        If (CInt(Mid(Pnr, 1, 2)) = 19 Or CInt(Mid(Pnr, 1, 2)) = 20) And CInt(Mid(Pnr, 7, 2)) > 32 Then Return False ' felaktig dag
        '197107230000
        If (CInt(Mid(Pnr, 1, 2)) = 19 Or CInt(Mid(Pnr, 1, 2)) = 20) And CInt(Mid(Pnr, 9, 4)) = 0 Then Return False ' felaktig kontrolluppgioft 0000




        Dim sum As Int16 = 0
        For i As Int16 = 3 To 12
            sum += Int(((i Mod 2 + 1) * (CInt(Mid(Pnr, i, 1)))) / 10) + ((i Mod 2 + 1) * (CInt(Mid(Pnr, i, 1)))) Mod 10

        Next i
        If (sum Mod 10) <> 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub GenererarAG()
        Dim MAXNAMN As Integer
        Dim MAXADRESS As Integer
        MAXNAMN = 35 : MAXADRESS = 25
        Dim strPeriod As String = lDatumStr.Text.Trim()

        REM ***********
        SFD_Kontrolluppgift.FileName = "Skattemyndighet_ArbetsgivareIndividuell_" + strPeriod + ".xml"
        If (SFD_Kontrolluppgift.ShowDialog = Windows.Forms.DialogResult.OK And SFD_Kontrolluppgift.FileName.Length > 0) Then
            Dim outString As StringBuilder = New StringBuilder
            Dim str As StringBuilder = New StringBuilder

            Dim sqlConn As SqlConnection = New SqlConnection(My.Settings.DBconnectionString)
            sqlConn.Open()
            Dim selectCommand As SqlCommand = New SqlCommand()
            selectCommand.CommandType = CommandType.Text
            selectCommand.CommandText = "SELECT *" & _
                        "from betalning_kontrolluppgift  where Kontrolluppgift>0 and PeriodStr=" & strPeriod & " and typ='R' order by Typ,PeriodStr,efternamn,förnamn,personnummer,OrganisationsNummer"
            selectCommand.Connection = sqlConn
            System.Console.WriteLine(selectCommand.CommandText.ToString)
            Dim reader As SqlDataReader = selectCommand.ExecuteReader
            Dim index As Integer = 0

            '-----------------------       
            outString.AppendLine("<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>")
            outString.AppendLine("<Skatteverket omrade=""Arbetsgivardeklaration""")
            outString.AppendLine("xmlns = ""http://xmls.skatteverket.se/se/skatteverket/da/instans/schema/1.1""")
            outString.AppendLine("xmlns:agd=""http://xmls.skatteverket.se/se/skatteverket/da/komponent/schema/1.1"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""")
            outString.AppendLine("xsi:schemaLocation=""http://xmls.skatteverket.se/se/skatteverket/da/instans/schema/1.1 http://xmls.skatteverket.se/se/skatteverket/da/arbetsgivardeklaration/arbetsgivardeklaration_1.1.xsd"">")

            outString.AppendLine("<agd:Avsandare>")
            outString.AppendLine("<agd:Programnamn>KUfilsprogrammet</agd:Programnamn>  ")
            outString.AppendLine("<agd:Organisationsnummer>" & My.Settings.KU_UG.Trim & "</agd:Organisationsnummer>")
            outString.AppendLine("<agd:TekniskKontaktperson>")
            outString.AppendLine("<agd:Namn>" & My.Settings.KU_Kontakt.Trim & "</agd:Namn>")
            outString.AppendLine("<agd:Telefon>" & My.Settings.KU_Telefon.Trim & "</agd:Telefon>")
            outString.AppendLine("   <agd:Epostadress>" & My.Settings.KU_Email.Trim & "</agd:Epostadress> ")
            outString.AppendLine("  <agd:Utdelningsadress1>" & My.Settings.KU_Adress.Trim & "</agd:Utdelningsadress1>")
            ' outString.AppendLine("<agd:Utdelningsadress2></agd:Utdelningsadress2>   ")
            outString.AppendLine("<agd:Postnummer>" & My.Settings.KU_PostNR.Trim & "</agd:Postnummer>   <agd:Postort>" & My.Settings.KU_PostOrt & "</agd:Postort> ")
            outString.AppendLine(" </agd:TekniskKontaktperson>")
            outString.AppendLine("     <agd:Skapad>" & Date.Today.ToString("yyyy-MM-ddThh:ss:mm") & "</agd:Skapad> ")  '2014-06-07T21:32:52
            outString.AppendLine("</agd:Avsandare> ")

            outString.AppendLine("  <agd:Blankettgemensamt>     <agd:Arbetsgivare>     ")
            outString.AppendLine("  <agd:AgRegistreradId>" & My.Settings.KU_UG.Trim & "</agd:AgRegistreradId>     ")
            outString.AppendLine("  <agd:Kontaktperson>    ")
            outString.AppendLine("<agd:Namn>" & My.Settings.KU_Kontakt.Trim & "</agd:Namn> ")
            outString.AppendLine(" <agd:Telefon>" & My.Settings.KU_Telefon.Trim & "</agd:Telefon> ")
            outString.AppendLine(" <agd:Epostadress>" & My.Settings.KU_Email.Trim & "</agd:Epostadress> ")
            outString.AppendLine(" <agd:Sakomrade>Skatteverket</agd:Sakomrade> ")
            outString.AppendLine(" </agd:Kontaktperson> ")
            outString.AppendLine(" </agd:Arbetsgivare>   </agd:Blankettgemensamt>   ")



            Dim felPNR As Int16 = 0
            'Dim felString As String = ""

            outString.AppendLine("<agd:Blankett><agd:Arendeinformation><agd:Arendeagare>" & My.Settings.KU_UG.Trim & "</agd:Arendeagare>")
            outString.AppendLine("<agd:Period>" & strPeriod & "</agd:Period>")
            outString.AppendLine("</agd:Arendeinformation>")


            outString.AppendLine("<agd:Blankettinnehall><agd:HU>")

            outString.AppendLine("<agd:ArbetsgivareHUGROUP><agd:AgRegistreradId faltkod=""201"">" & My.Settings.KU_UG.Trim & "</agd:AgRegistreradId></agd:ArbetsgivareHUGROUP>")
            outString.AppendLine("<agd:RedovisningsPeriod faltkod=""006"">" & strPeriod & "</agd:RedovisningsPeriod>")
            '  outString.AppendLine("<agd:SummaArbAvgSlf faltkod=""487"">0</agd:SummaArbAvgSlf>")
            ' outString.AppendLine("<agd:SummaSkatteavdr faltkod=""497"">0</agd:SummaSkatteavdr>")
            outString.AppendLine("</agd:HU></agd:Blankettinnehall></agd:Blankett>")

            While reader.Read
                If PNROK(reader("Organisationsnummer")) = False And PNROK(reader("Personnummer")) = False Then
                    'felString = felString & "<O:" & reader("Organisationsnummer") & ",P" & reader("Personnummer") & ">"
                    felPNR += 1
                End If



                If ((CInt(reader("kontrolluppgift"))) >= 100) And (PNROK(reader("Personnummer")) Or PNROK(reader("Organisationsnummer"))) Then

                    index += 1




                    outString.AppendLine("<agd:Blankett>")
                    outString.AppendLine("<agd:Arendeinformation>")
                    outString.AppendLine("<agd:Arendeagare>" & My.Settings.KU_UG.Trim & "</agd:Arendeagare>")
                    outString.AppendLine("<agd:Period>" & strPeriod & "</agd:Period>")
                    outString.AppendLine("</agd:Arendeinformation>")
                    outString.AppendLine("<agd:Blankettinnehall>")

                    outString.AppendLine("<agd:IU>")
                    outString.AppendLine("<agd:ArbetsgivareIUGROUP>")
                    outString.AppendLine("<agd:AgRegistreradId faltkod=""201"">" & My.Settings.KU_UG.Trim & "</agd:AgRegistreradId>")
                    '
                    outString.AppendLine("</agd:ArbetsgivareIUGROUP>")
                    'personummer TODO
                    outString.AppendLine("<agd:BetalningsmottagareIUGROUP>")
                    outString.AppendLine("<agd:BetalningsmottagareIDChoice>")
                    outString.Append("<agd:BetalningsmottagarId faltkod=""215"">")
                    '198202252386
                    If PNROK(reader("Organisationsnummer")) Then
                        outString.Append(CStr(reader("Organisationsnummer")).Substring(0, 12)) ' & "-" & CStr(reader("Organisationsnummer")).Substring(8, 4))
                        '& IIf(PNROK(CStr(reader("Organisationsnummer")).Substring(0, 12)), "OK", "Fel")

                    Else
                        outString.Append(CStr(reader("Personnummer")).Substring(0, 12))
                        '& CStr(reader("Personnummer")).Substring(8, 4))

                    End If

                    outString.AppendLine("</agd:BetalningsmottagarId>")
                    outString.AppendLine("</agd:BetalningsmottagareIDChoice>")
                    outString.AppendLine("</agd:BetalningsmottagareIUGROUP>")

                    outString.AppendLine("<agd:RedovisningsPeriod faltkod=""006"">" & strPeriod & "</agd:RedovisningsPeriod>")
                    outString.AppendLine("<agd:Specifikationsnummer faltkod=""570""> " & Int(index) + 1000 & " </agd:Specifikationsnummer>")

                    REM ORU=U (pphovsman)
                    'TODO Borttagningsmarkering
                    'outString.AppendLine("<ku:Borttag faltkod=""205"">1</ku:Borttag>")

                    'If CInt(reader("calc_SUM_Kontrolluppgift_Royalty")) > 0 Then
                    '    If PNROK(reader("Organisationsnummer")) Then
                    '        outString.AppendLine("<ku:ErsEjSocAvg faltkod=""031""> " & CInt(reader("calc_SUM_Kontrolluppgift_Royalty")) & "</ku:ErsEjSocAvg>")
                    '    Else
                    '        outString.AppendLine("<ku:ErsMEgenavgifter faltkod=""025""> " & CInt(reader("calc_SUM_Kontrolluppgift_Royalty")) & "</ku:ErsMEgenavgifter>")
                    '    End If

                    '    '    REM outString.AppendLine("#UP 67 Royalty")

                    'End If
                    'REM ORU=R (epresentant)
                    If CInt(reader("Kontrolluppgift")) > 0 Then

                        outString.AppendLine("<agd:ErsEjSocAvgEjJobbavd faltkod=""032""> " & CInt(reader("Kontrolluppgift")) & "</agd:ErsEjSocAvgEjJobbavd>")
                        '    REM outString.AppendLine("#UP 69 Ärvd Royalty")
                        outString.AppendLine("<agd:AvdrPrelSkatt faltkod=""001"">0</agd:AvdrPrelSkatt>")
                    End If






                    outString.AppendLine("</agd:IU>")
                    outString.AppendLine("</agd:Blankettinnehall>")
                    outString.AppendLine(" </agd:Blankett> ")

                End If
                'End If
                'End If

            End While

            outString.AppendLine("</Skatteverket> ")

            sqlConn.Close()

            reader.Close()
            File.WriteAllText(SFD_Kontrolluppgift.FileName, outString.ToString(), Encoding.GetEncoding("utf-8"))

            MsgBox(index & " poster skrivna till AG fil" & IIf(felPNR > 0, ". " & felPNR.ToString() & " Felaktiga personnummer/orgnummer ej med i fil.", ""))




        End If

    End Sub

    Private Sub bGenereraKU_Click(sender As System.Object, e As System.EventArgs) Handles bGenereraKU.Click
        If cbÄrvdRoyalty.Checked = False Then GenereraKU() Else GenererarAG()
    End Sub

   

    Private Sub dgKontrolluppgift_Leave(sender As Object, e As System.EventArgs) Handles dgKontrolluppgift.Leave
        Betalning_kontrolluppgiftTableAdapter.Update(B2dsKontrolluppgift)



    End Sub
End Class