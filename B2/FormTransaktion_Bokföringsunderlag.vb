Imports CrystalDecisions.Shared
Public Class FormTransaktion_Bokföringsunderlag
    Public Sub setBT_ID(ByVal bt_id As Int32)
        Dim paramFields As ParameterFields = New ParameterFields '(crvBokföringsunderlag.ParameterFieldInfo)
        Dim pfItemId As ParameterField = New ParameterField
        pfItemId.ParameterFieldName = "BT_ID"
        Dim dcItemId As ParameterDiscreteValue = New ParameterDiscreteValue
        dcItemId.Value = bt_id
        pfItemId.CurrentValues.Add(dcItemId)
        paramFields.Add(pfItemId)
        crvBokföringsunderlag.ParameterFieldInfo = paramFields
        Dim CRconn As ConnectionInfo = New ConnectionInfo
        CRconn.DatabaseName = My.Settings.Initial_catalog
        CRconn.ServerName = My.Settings.Data_source
        CRconn.UserID = My.Settings.USER_ID
        CRconn.AllowCustomConnection = True

        CRconn.Password = My.Settings.PASSWORD


        Dim myTableLogOnInfos As TableLogOnInfos = crvBokföringsunderlag.LogOnInfo
        For Each myTableLogOnInfo As TableLogOnInfo In myTableLogOnInfos
            myTableLogOnInfo.ConnectionInfo = CRconn
        Next
        'MsgBox("DBNAME" & crvBokföringsunderlag.LogOnInfo(0).ConnectionInfo.DatabaseName.ToString & "<ServerName" & crvBokföringsunderlag.LogOnInfo(0).ConnectionInfo.ServerName.ToString & "<UserID" & crvBokföringsunderlag.LogOnInfo(0).ConnectionInfo.UserID.ToString & "<PW" & crvBokföringsunderlag.LogOnInfo(0).ConnectionInfo.Password.ToString & "<")
        crvBokföringsunderlag.RefreshReport()
    End Sub

    Private Sub crvBokföringsunderlag_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles crvBokföringsunderlag.Load

    End Sub

    Private Sub TransaktionBokföringsunderlag1_InitReport(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransaktionBokföringsunderlag1.InitReport

    End Sub
End Class