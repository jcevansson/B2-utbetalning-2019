Imports CrystalDecisions.Shared
Public Class Main_PRV

    Private Sub Main_PRV_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load


    End Sub

    Private Sub ReportViewer1_Load(sender As System.Object, e As System.EventArgs)

    End Sub
    Public Sub setYear(ByVal bt_id As Int32)
        Dim paramFields As ParameterFields = New ParameterFields '(crvBokföringsunderlag.ParameterFieldInfo)
        Dim pfItemId As ParameterField = New ParameterField
        pfItemId.ParameterFieldName = "Per"
        Dim dcItemId As ParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue


        dcItemId.Value = IIf(bt_id <> 0, bt_id, Date.Now().Year - 1)
        pfItemId.CurrentValues.Add(dcItemId)
        paramFields.Add(pfItemId)
        crvPRV.ParameterFieldInfo = paramFields

        Dim CRconn As ConnectionInfo = New ConnectionInfo
        CRconn.DatabaseName = My.Settings.Initial_catalog
        CRconn.ServerName = My.Settings.Data_source
        CRconn.UserID = My.Settings.USER_ID
        CRconn.AllowCustomConnection = True

        CRconn.Password = My.Settings.PASSWORD


        Dim myTableLogOnInfos As TableLogOnInfos = crvPRV.LogOnInfo
        For Each myTableLogOnInfo As TableLogOnInfo In myTableLogOnInfos
            myTableLogOnInfo.ConnectionInfo = CRconn
        Next
        'MsgBox("DBNAME" & crvBokföringsunderlag.LogOnInfo(0).ConnectionInfo.DatabaseName.ToString & "<ServerName" & crvBokföringsunderlag.LogOnInfo(0).ConnectionInfo.ServerName.ToString & "<UserID" & crvBokföringsunderlag.LogOnInfo(0).ConnectionInfo.UserID.ToString & "<PW" & crvBokföringsunderlag.LogOnInfo(0).ConnectionInfo.Password.ToString & "<")
        crvPRV.RefreshReport()
    End Sub


    Private Sub PRVUnderlag1_InitReport(sender As System.Object, e As System.EventArgs) Handles PRVUnderlag1.InitReport

    End Sub
End Class