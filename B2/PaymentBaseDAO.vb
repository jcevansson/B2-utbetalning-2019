Imports System.Data
Imports System.Data.SqlClient


Public Class PaymentBaseDAO
    Private connectionString As String = "Data Source=192.168.0.38;Initial Catalog=B2Arbete;user id=Developer;Connection Timeout=120;Password=Developer;"

    Public Sub New()

    End Sub

    Public Function getPaymentBaseInfoForViewing(ByVal viewName As String) As DataSet

        Dim ds As New DataSet()

        Dim sqlConn As SqlConnection = New SqlConnection(connectionString)


        'Skapa ett SQLCommand som kör en stored procedure.
        Dim selectCommand As SqlCommand = New SqlCommand()
        selectCommand.CommandType = CommandType.Text

        selectCommand.CommandText = viewName
        selectCommand.Connection = sqlConn

        'För att kunna fylla data till DataSetet behövs en SqlDataAdapter
        Dim dataAdapter As SqlDataAdapter = New SqlDataAdapter()
        dataAdapter.SelectCommand = selectCommand

        Try

            'Försök att hämta data från tabellen till DataSetet ds.
            dataAdapter.Fill(ds)
            Return ds

        Catch e As SqlException
            MsgBox(e.ToString)

        Finally
            'Stäng SqlConnection-objektet ifall det är öppet eller ifall det blivit något fel
            If sqlConn.State = ConnectionState.Open Or sqlConn.State = ConnectionState.Broken Then

            End If

        End Try

        Return Nothing
    End Function
End Class
