Imports System.Data.SqlClient
Imports System.Text
Imports System.IO

Public Class FormKontrolluppgifter



    Private Sub bGenereraKU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGenereraKU.Click

        Dim MAXNAMN As Integer
        Dim MAXADRESS As Integer
        MAXNAMN = 35 : MAXADRESS = 25

    
       
        REM ***********

        If (SFD_Kontrolluppgift.ShowDialog = Windows.Forms.DialogResult.OK And SFD_Kontrolluppgift.FileName.Length > 0) Then
            Dim outString As StringBuilder = New StringBuilder
            Dim str As StringBuilder = New StringBuilder

            Dim sqlConn As SqlConnection = New SqlConnection(My.Settings.DBconnectionString)
            sqlConn.Open()
            Dim selectCommand As SqlCommand = New SqlCommand()
            selectCommand.CommandType = CommandType.Text
            selectCommand.CommandText = "SELECT *" & _
                        "from v_betalning_kontrolluppgift_summering  where År=" & nudÅr.Value & " order by År,efternamn,förnamn,personnummer,OrganisationsNummer"
            selectCommand.Connection = sqlConn
            System.Console.WriteLine(selectCommand.CommandText.ToString)
            Dim reader As SqlDataReader = selectCommand.ExecuteReader
            Dim index As Integer = 0

            '-----------------------       
            outString.AppendLine("<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>")
            outString.AppendLine("<Skatteverket xmlns=""http://xmls.skatteverket.se/se/skatteverket/ai/instans/infoForBeskattning/4.0"" xmlns:gm=""http://xmls.skatteverket.se/se/skatteverket/ai/gemensamt/infoForBeskattning/4.0"" xmlns:ku=""http://xmls.skatteverket.se/se/skatteverket/ai/komponent/infoForBeskattning/4.0"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" omrade=""Kontrolluppgifter"" xsi:schemaLocation=""http://xmls.skatteverket.se/se/skatteverket/ai/instans/infoForBeskattning/4.0 http://xmls.skatteverket.se/se/skatteverket/ai/kontrolluppgift/instans/Kontrolluppgifter_4.0.xsd ""> ")
            outString.AppendLine("<ku:Avsandare>")
            outString.AppendLine("<ku:Programnamn>KUfilsprogrammet</ku:Programnamn>  ")
            outString.AppendLine("<ku:Organisationsnummer>" & My.Settings.KU_UG.Trim & "</ku:Organisationsnummer>")
            outString.AppendLine("<ku:TekniskKontaktperson>")
            outString.AppendLine("<ku:Namn>" & My.Settings.KU_Kontakt.Trim & "</ku:Namn>")
            outString.AppendLine("<ku:Telefon>" & My.Settings.KU_Telefon.Trim & "</ku:Telefon>")
            outString.AppendLine("   <ku:Epostadress>" & My.Settings.KU_Email.Trim & "</ku:Epostadress> ")
            outString.AppendLine("  <ku:Utdelningsadress1>" & My.Settings.KU_Adress.Trim & "</ku:Utdelningsadress1>")
            outString.AppendLine("<ku:Utdelningsadress2></ku:Utdelningsadress2>   ")
            outString.AppendLine("<ku:Postnummer>" & My.Settings.KU_PostNR.trim & "</ku:Postnummer>   <ku:Postort>" & My.Settings.KU_PostOrt & "</ku:Postort> ")
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



                If ((CInt(reader("calc_SUM_Kontrolluppgift"))) >= 100) And (PNROK(reader("Personnummer")) Or PNROK(reader("Organisationsnummer"))) Then

                    index += 1
                


                
                    outString.AppendLine("<ku:Blankett nummer=""2300"">")
                    outString.AppendLine("<ku:Arendeinformation>")
                    outString.AppendLine("<ku:Arendeagare>" & My.Settings.KU_UG.Trim & "</ku:Arendeagare>")
                    outString.AppendLine("<ku:Period>" & CInt(nudÅr.Value).ToString & "</ku:Period>")
                    outString.AppendLine("</ku:Arendeinformation>")
                    outString.AppendLine("<ku:Blankettinnehall>")
                    outString.AppendLine("<ku:KU10>")
                    outString.AppendLine("<ku:Specifikationsnummer faltkod=""570""> " & Int(index) & " </ku:Specifikationsnummer>")
                    outString.AppendLine("<ku:Inkomstar faltkod=""203"">" & CInt(nudÅr.Value).ToString & "</ku:Inkomstar>")


                    REM ORU=U (pphovsman)
                    'TODO Borttagningsmarkering
                    'outString.AppendLine("<ku:Borttag faltkod=""205"">1</ku:Borttag>")

                    If CInt(reader("calc_SUM_Kontrolluppgift_Royalty")) > 0 Then
                        If PNROK(reader("Organisationsnummer")) Then
                            outString.AppendLine("<ku:ErsEjSocAvg faltkod=""031""> " & CInt(reader("calc_SUM_Kontrolluppgift_Royalty")) & "</ku:ErsEjSocAvg>")
                        Else
                            outString.AppendLine("<ku:ErsMEgenavgifter faltkod=""025""> " & CInt(reader("calc_SUM_Kontrolluppgift_Royalty")) & "</ku:ErsMEgenavgifter>")
                        End If

                        '    REM outString.AppendLine("#UP 67 Royalty")

                    End If
                    'REM ORU=R (epresentant)
                    If CInt(reader("calc_SUM_Kontrolluppgift_Ärvd_Royalty")) > 0 Then

                        outString.AppendLine("<ku:ErsEjSocAvgEjJobbavd faltkod=""032""> " & CInt(reader("calc_SUM_Kontrolluppgift_Ärvd_Royalty")) & "</ku:ErsEjSocAvgEjJobbavd>")
                        '    REM outString.AppendLine("#UP 69 Ärvd Royalty")

                    End If



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
    'Public Class FormKontrolluppgifter



    'Private Sub bGenereraKU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGenereraKU.Click

    '    Dim MAXNAMN As Integer
    '    Dim MAXADRESS As Integer
    '    MAXNAMN = 35 : MAXADRESS = 25



    '    REM ***********

    '    If (SFD_Kontrolluppgift.ShowDialog = Windows.Forms.DialogResult.OK And SFD_Kontrolluppgift.FileName.Length > 0) Then
    '        Dim outString As StringBuilder = New StringBuilder
    '        Dim str As StringBuilder = New StringBuilder

    '        Dim sqlConn As SqlConnection = New SqlConnection(My.Settings.DBconnectionString)
    '        sqlConn.Open()
    '        Dim selectCommand As SqlCommand = New SqlCommand()
    '        selectCommand.CommandType = CommandType.Text
    '        selectCommand.CommandText = "SELECT *" & _
    '                    "from v_betalning_kontrolluppgift_summering  where År=" & nudÅr.Value & " order by År,efternamn,förnamn,personnummer,OrganisationsNummer"
    '        selectCommand.Connection = sqlConn
    '        System.Console.WriteLine(selectCommand.CommandText.ToString)
    '        Dim reader As SqlDataReader = selectCommand.ExecuteReader
    '        Dim index As Integer = 0

    '        '-----------------------       
    '        outString.AppendLine("#DATA_START")
    '        outString.AppendLine("#POST_START UGNR")
    '        outString.AppendLine("#UG " & My.Settings.KU_UG.Trim)


    '        While reader.Read

    '            If (CInt(reader("calc_SUM_Kontrolluppgift"))) >= 100 Then
    '                index += 1
    '                outString.AppendLine("#POST_START KU10")
    '                If CStr(reader("Organisationsnummer")).Length = 12 Then
    '                    outString.AppendLine("#PERSONNR " & CStr(reader("Organisationsnummer")))

    '                Else
    '                    outString.AppendLine("#PERSONNR " & CStr(reader("Personnummer")))

    '                End If
    '                outString.AppendLine("#UP 570 " & Int(index))
    '                REM ORU=U (pphovsman)
    '                If CInt(reader("calc_SUM_Kontrolluppgift_Royalty")) > 0 Then
    '                    outString.AppendLine("#UP 25 " & CInt(reader("calc_SUM_Kontrolluppgift_Royalty")))
    '                    REM outString.AppendLine("#UP 67 Royalty")

    '                End If
    '                REM ORU=R (epresentant)
    '                If CInt(reader("calc_SUM_Kontrolluppgift_Ärvd_Royalty")) > 0 Then

    '                    outString.AppendLine("#UP 32 " & CInt(reader("calc_SUM_Kontrolluppgift_Ärvd_Royalty")))
    '                    REM outString.AppendLine("#UP 69 Ärvd Royalty")

    '                End If
    '                outString.AppendLine("#POST_SLUT KU10")

    '            End If

    '        End While

    '        outString.AppendLine("#POST_SLUT UGNR")
    '        outString.AppendLine("#DATA_SLUT")
    '        outString.AppendLine("#FIL_SLUT")


    '        MsgBox(index & " poster skrivna till kufil")

    '        reader.Close()
    '        File.WriteAllText(SFD_Kontrolluppgift.FileName, outString.ToString(), Encoding.GetEncoding("iso-8859-1"))

    '        sqlConn.Close()
    '        REM skapa info.ku fil
    '        outString.Length = 0
    '        outString.AppendLine("#EFX 1.0")
    '        outString.AppendLine("#DATABESKRIVNING_START")
    '        outString.AppendLine("#TECKENPROV ÅÄÖÜåäöüÉé#_@")
    '        outString.AppendLine("#PRODUKT KU" & nudÅr.Value + 1)
    '        outString.AppendLine("#PERIOD " & CInt(nudÅr.Value))
    '        outString.AppendLine("#MEDIAID " & nudMediaID.Value)
    '        outString.AppendLine("#PROGRAM EGET")
    '        Dim d As DateTime = New DateTime
    '        outString.AppendLine("#SKAPAD " & d.Today.Year.ToString & d.Today.Month.ToString.PadLeft(2, "0") & d.Today.Day.ToString.PadLeft(2, "0") & " " & d.Now.Hour.ToString.PadLeft(2, "0") & d.Now.Minute.ToString.PadLeft(2, "0") & "00") REM  20110127 121128
    '        outString.AppendLine("#TEST N")
    '        outString.AppendLine("#FILNAMN KURED")
    '        outString.AppendLine("#DATABESKRIVNING_SLUT")
    '        outString.AppendLine("#MEDIELEV_START")
    '        outString.AppendLine("#ORGNR " & My.Settings.KU_UG.Trim)
    '        outString.AppendLine("#NAMN " & My.Settings.KU_Namn.Substring(0, Math.Min(50, My.Settings.KU_Namn.Length))) REM Bildkonst upphovsrätt i Sverige
    '        outString.AppendLine("#AVDELNING DATAENHETEN")
    '        outString.AppendLine("#KONTAKT " & My.Settings.KU_Kontakt.Substring(0, Math.Min(50, My.Settings.KU_Kontakt.Length))) REM Lotta Björklin
    '        outString.AppendLine("#ADRESS " & My.Settings.KU_Adress.Substring(0, Math.Min(50, My.Settings.KU_Adress.Length))) REM Årstaängsvägen 5B
    '        outString.AppendLine("#POSTNR " & My.Settings.KU_PostNR.Substring(0, Math.Min(15, My.Settings.KU_PostNR.Length))) REM  11242
    '        outString.AppendLine("#POSTORT " & My.Settings.KU_PostOrt.Substring(0, Math.Min(50, My.Settings.KU_PostOrt.Length))) REM  STOCKHOLM
    '        outString.AppendLine("#TELEFON " & My.Settings.KU_Telefon.Substring(0, Math.Min(15, My.Settings.KU_Telefon.Length))) REM 08-545523389
    '        outString.AppendLine("#FAX " & My.Settings.KU_Fax.Substring(0, Math.Min(15, My.Settings.KU_Fax.Length))) REM 08-54553398
    '        outString.AppendLine("#EMAIL " & My.Settings.KU_Email.Substring(0, Math.Min(50, My.Settings.KU_Email.Length))) REM lotta@bus.se
    '        outString.AppendLine("#MEDIELEV_SLUT")
    '        Dim kuredFileName As String = SFD_Kontrolluppgift.FileName.Substring(0, SFD_Kontrolluppgift.FileName.LastIndexOf("\")) & "\info.ku"
    '        File.WriteAllText(kuredFileName, outString.ToString(), Encoding.GetEncoding("iso-8859-1"))



    '    End If

    'End Sub

    Private Sub Uppgiftslämnare_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblUG.Click

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        nudÅr.Value = Now().Year - 1
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

    Private Sub bGenererarAG_Click(sender As System.Object, e As System.EventArgs) Handles bGenererarAG.Click
        Dim MAXNAMN As Integer
        Dim MAXADRESS As Integer
        MAXNAMN = 35 : MAXADRESS = 25
        Dim strPeriod As String = nudÅr.Value.ToString("0000") + nupPeriod.Value.ToString("0#")


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
                        "from v_betalning_kontrolluppgift_period_summering  where calc_SUM_Kontrolluppgift_Ärvd_Royalty>0 and År=" & nudÅr.Value & " and Månad=" & nupPeriod.Value & "  order by År,efternamn,förnamn,personnummer,OrganisationsNummer"
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



                If ((CInt(reader("calc_SUM_Kontrolluppgift"))) >= 100) And (PNROK(reader("Personnummer")) Or PNROK(reader("Organisationsnummer"))) Then

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
                    If CInt(reader("calc_SUM_Kontrolluppgift_Ärvd_Royalty")) > 0 Then

                        outString.AppendLine("<agd:ErsEjSocAvgEjJobbavd faltkod=""032""> " & CInt(reader("calc_SUM_Kontrolluppgift_Ärvd_Royalty")) & "</agd:ErsEjSocAvgEjJobbavd>")
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

    Private Sub bKU_Click(sender As System.Object, e As System.EventArgs) Handles bKU.Click
        Dim ku As FormKontrolluppgift
        ku = New FormKontrolluppgift

        ku.Show()
    End Sub
End Class