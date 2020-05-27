
Imports System.Windows.Forms
Imports System.Data.SqlClient


Public Class DSynk

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Function RunSP(ByVal s As String) As Int16
        'Kör synk sp och returnera positiva tal om det gått bra negativa om det inte gått bra
        Dim selectCommand As SqlCommand = New SqlCommand()
        Dim sqlConn As SqlConnection = New SqlConnection(My.Settings.DBconnectionString)

        'Dim retVal As SqlParameter
        selectCommand.CommandType = CommandType.StoredProcedure
        selectCommand.CommandText = s

        ' retVal = selectCommand.Parameters.Add("count", SqlDbType.Int)
        'retVal.Direction = ParameterDirection.ReturnValue
        sqlConn.Open()
        selectCommand.Connection = SQLConn
 
        'TODO error handling kring misslyckat eller om skall fortsätta

        Try
            Console.WriteLine("RunSP: " & s)
            Dim reader As SqlDataReader = selectCommand.ExecuteReader
            reader.Read()
            reader.Close()
            Return 1
        Catch e As SqlException
            Return -1

        Finally
            'Stäng SqlConnection-objektet ifall det är öppet eller ifall det blivit något fel
            If sqlConn.State = ConnectionState.Open Or sqlConn.State = ConnectionState.Broken Then
                sqlConn.Close()
            End If

        End Try

        Return 1



    End Function

    Private Sub DSynk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OK_Button.Enabled = False
        

        tStatus.Text = "Synronisering av alla poster påbörjas..." & vbNewLine
        
        tStatus.Text &= vbNewLine & "Följerätt synkning : "
        If RunSP("sp_synk_följerätt") > 0 Then tStatus.Text &= "OK" Else tStatus.Text &= "Fel"

        tStatus.Text &= vbNewLine & "IR-Foto synkning :  "
        If RunSP("sp_synk_irfoto") > 0 Then tStatus.Text &= "OK" Else tStatus.Text &= "Fel"
        tStatus.Text &= vbNewLine & "IR synkning :  "
        If RunSP("sp_synk_ir") > 0 Then tStatus.Text &= "OK" Else tStatus.Text &= "Fel"

        tStatus.Text &= vbNewLine & "IRDagspress foto synkning :  "
        If RunSP("sp_synk_irdagp_foto") > 0 Then tStatus.Text &= "OK" Else tStatus.Text &= "Fel"

        tStatus.Text &= vbNewLine & "IRDagspress illustratör synkning :  "
        If RunSP("sp_synk_irdagp_illust") > 0 Then tStatus.Text &= "OK" Else tStatus.Text &= "Fel"

        tStatus.Text &= vbNewLine & "IV synkning :  "
        If RunSP("sp_synk_iv") > 0 Then tStatus.Text &= "OK" Else tStatus.Text &= "Fel"

        tStatus.Text &= vbNewLine & "Reproduktion synkning :  "
        If RunSP("sp_synk_reproduktion") > 0 Then tStatus.Text &= "OK" Else tStatus.Text &= "Fel"

        tStatus.Text &= vbNewLine & "Sveriges Tidskrifter synkning :  "
        If RunSP("sp_synk_sveriges_tidskrifter") > 0 Then tStatus.Text &= "OK" Else tStatus.Text &= "Fel"

        tStatus.Text &= vbNewLine & "Television synkning :  "
        If RunSP("sp_synk_tv") > 0 Then tStatus.Text &= "OK" Else tStatus.Text &= "Fel"


        tStatus.Text &= vbNewLine & "Kundredovisning synkning :  "
        If RunSP("sp_synk_kr") > 0 Then tStatus.Text &= "OK" Else tStatus.Text &= "Fel"

        tStatus.Text &= vbNewLine & "Skapa historik i Busas : "
        If RunSP("sp_synk_historik") > 0 Then tStatus.Text &= "OK" Else tStatus.Text &= "Fel"
        OK_Button.Enabled = True

    End Sub
End Class
