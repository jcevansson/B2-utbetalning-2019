Imports System.Text
Imports System.Data.SqlClient
Public Class UtbetalningGroupTreeView
    Inherits GroupTreeView
    Public Overrides Function LevelText(ByVal l As Integer, ByRef row As System.Data.DataRow) As String
        Dim s As StringBuilder

        If l = 0 Then
            s = New StringBuilder(Graph_Pad_Right(New StringBuilder(row("mottagare_efternamn").ToString()).Append(", ").Append(row("mottagare_förnamn").ToString()).ToString, 80, Me.Font))
            s.Append(Graph_Pad_Right(row("mottagare_personnummer").ToString, 30, Me.Font))
            Return s.ToString
        ElseIf l = 1 Then
            s = New StringBuilder(Graph_Pad_Right(row("betalning_typ").ToString(), 110, Me.Font))
            Return s.ToString

        ElseIf l = 2 Then
            s = New StringBuilder(Graph_Pad_Right(New StringBuilder(row("efternamn").ToString()).Append(",  ").Append(row("förnamn").ToString()).ToString, 65, Me.Font))
            s.Append(Graph_Pad_Right(row("personnummer").ToString, 30, Me.Font))
            Return s.ToString
        ElseIf l = 3 Then
            s = New StringBuilder(Graph_Pad_Right(CType(row("registrerat datum"), Date).ToShortDateString(), 15, Me.Font)).Append("  ")
            s.Append(Graph_Pad_Right(New StringBuilder(row("efternamn").ToString()).Append(",  ").Append(row("förnamn").ToString()).ToString, 65, Me.Font))
            s.Append(Graph_Pad_Right(row("personnummer").ToString, 30, Me.Font))
            Return s.ToString
        Else
            Return MyBase.LevelText(l, row)
        End If



    End Function
    Public Overrides Function LevelToolTipText(ByVal l As Integer, ByRef row As System.Data.DataRow) As String
        Dim s As StringBuilder
        If l = 0 Then
            s = New StringBuilder("Brutto=" & Convert.ToDecimal(row("T_belopp_brutto")).ToString("N0")).AppendLine(" kr.")


            If row("konto_typ_kortnamn").ToString.ToUpper.Trim = "AVI" Then
                s.AppendLine(row("Adress_Kommentar").ToString)
            Else
                s.AppendLine(row("Konto_Kommentar").ToString)
            End If
            If row("dödsboejklart").ToString = "1" Then
                s.AppendLine(" Dödsbo ej klart")
            End If
            If row("KontoOK").ToString = "0" Then
                s.AppendLine(" felaktig kontoinfomation")
            End If



        ElseIf l = 1 Then
            s = New StringBuilder("Betalningstyp")
        ElseIf l = 2 Then
            s = New StringBuilder(row("betalnings_underlag_Kommentar").ToString).Append(Environment.NewLine)
            s.Append(Convert.ToDecimal(row("Fördelning")).ToString("N1")).Append("% av ")
            s.Append(Convert.ToDecimal(row("betalning_underlag_belopp")).ToString("N0")).Append(" kr" & Environment.NewLine)
            s.Append("Moms=" & Convert.ToDecimal(row("calc_moms")).ToString("N0")).Append(" kr. (")
            s.Append(Convert.ToDecimal(row("moms")).ToString("N0")).Append("%) ").Append(Environment.NewLine)
            s.Append("Avdrag=").Append(Convert.ToDecimal(row("calc_avdrag")).ToString("N0")).Append(" kr.  (").Append(Convert.ToDecimal(row("avdrag")).ToString("N0")).Append("%)")
            
        ElseIf l = 3 Then
            s = New StringBuilder(row("betalnings_underlag_Kommentar").ToString).Append(Environment.NewLine)
            s.Append(Convert.ToDecimal(row("Fördelning")).ToString("N1")).Append("% av ")
            s.Append(Convert.ToDecimal(row("betalning_underlag_belopp")).ToString("N0")).Append(" kr" & Environment.NewLine)
            s.Append("Moms=" & Convert.ToDecimal(row("calc_moms")).ToString("N0")).Append(" kr. (")
            s.Append(Convert.ToDecimal(row("moms")).ToString("N0")).Append("%) ").Append(Environment.NewLine)
            s.Append("Avdrag=").Append(Convert.ToDecimal(row("calc_avdrag")).ToString("N0")).Append(" kr.  (").Append(Convert.ToDecimal(row("avdrag")).ToString("N0")).Append("%)")
            If row("STATUS").ToString = "BETALD" Then
                s.AppendLine("Betald")
            End If

        Else
            s = New StringBuilder(row(Me.getColGroupSumName()(l)).ToString)
        End If


        Return s.ToString
    End Function
    Overrides Function LevelForeGroundColor(ByVal l As Integer, ByVal row As DataRow) As Color
        If l.ToString = "0" Then
            If row("checkable").ToString = "1" Then
                If row("mottagare_typ").ToString.ToUpper.Trim = "S" Then
                    Return Color.Green
                Else
                    Return Color.Black
                End If
            Else
                If row("dödsboejklart").ToString = "1" Or row("KontoOK").ToString = "0" Then
                    Return Color.Red
                Else
                    Return Color.Brown
                End If
            End If
        ElseIf l.ToString = "1" Then
            Return Color.Black
        ElseIf l.ToString = "3" Then
            If row("status").ToString.ToUpper = "BETALD" Then
                Return Color.Blue

            ElseIf row("Status").ToString.ToUpper = "SAKNAS" Then
                Return Color.Red

            End If
        Else
            Return Color.Black
        End If
    End Function
    

    Private Sub UtbetalningGroupTreeView_Click(sender As Object, e As System.EventArgs) Handles Me.AfterSelect
        Dim Sn As TreeNode = DirectCast(sender, UtbetalningGroupTreeView).SelectedNode
        If Sn IsNot Nothing Then
            If Sn.Level = 2 And Sn.Nodes.Count = 0 Then
                '  MsgBox("EXPAND level" & Sn.Level & " med " & CType(Sn.Tag, DataRow)("Antal_underlag"))
                Cursor = Cursors.WaitCursor
                Dim dt As DataTable
                Dim dv As DataView
                'TODO
                Dim whereString As String = DirectCast(Me.FindForm(), FormUtbetalning).Get_where_string()
                Dim paymentDataSet As DataSet = New DataSet
                Dim sqlConn As SqlConnection = New SqlConnection(My.Settings.DBconnectionString)
                Dim selectCommand As SqlCommand = New SqlCommand()
                selectCommand.CommandType = CommandType.Text
                selectCommand.CommandText = "SELECT *, 1 antal_underlag from v_betalning_summering "
                selectCommand.CommandText &= " where(" & whereString & _
                                             " and Namn_Personnummer_grupp = '" & CType(Sn.Tag, DataRow)("Namn_Personnummer_grupp") & "'" & _
                                               "   and betalning_typ = '" & CType(Sn.Tag, DataRow)("betalning_typ").ToString.TrimEnd & "'" & _
                                            "   and upphovsman_ID = '" & CType(Sn.Tag, DataRow)("upphovsman_ID").ToString.TrimEnd & "')   "
                selectCommand.CommandText &= "order by efternamn,förnamn,[registrerat datum]; "

                ' "SELECT [id],[betalning_typ],[upphovsman_id],[belopp],[betalningsdatum],[kommentar],[Personnummer],[förnamn],[efternamn],[Registrerat datum] ,  Efternamn+', '+Förnamn+' ('+personnummer+')' Namn_Personnummer_grupp,* from v_betalning_underlag where " & Status_get_wherestring() & " order by efternamn,förnamn,[registrerat datum]"
                System.Console.WriteLine(selectCommand.CommandText.ToString)

                selectCommand.Connection = sqlConn
                Dim dataAdapter As SqlDataAdapter = New SqlDataAdapter()
                dataAdapter.SelectCommand = selectCommand
                Try
                    dataAdapter.Fill(paymentDataSet)
                Catch ex As SqlException
                    MsgBox(ex.ToString)

                Finally
                    If sqlConn.State = ConnectionState.Open Or sqlConn.State = ConnectionState.Broken Then
                        sqlConn.Close()
                    End If
                End Try
                Try
                    'Console.WriteLine("5.Innan datatable: " & s.ElapsedMilliseconds) : s.Reset() : s.Start()
                    dt = paymentDataSet.Tables(0)
                Catch
                    dt = New DataTable
                Finally
                    'Console.WriteLine("6.Efter datatable: " & s.ElapsedMilliseconds) : s.Reset() : s.Start()
                    dv = New DataView(dt)
                    'Fyll trädnodernas data med data från den sorterade tabellens
                    'Console.WriteLine("7.Efter fill innan set dataview : " & s.ElapsedMilliseconds) : s.Reset() : s.Start()
                    SetDataView(dv)
                    'Console.WriteLine("8.Efter dataview: " & s.ElapsedMilliseconds) : s.Reset() : s.Start()
                    Dim cn As TreeNode
                    For Each rowView As DataRowView In dv
                        Dim row As DataRow = rowView.Row
                        Dim regularFont As Font = New Font(TreeView.DefaultFont, FontStyle.Regular)
                        'Fyll alla levels med insformation från denna rad
                        'If cn Is Nothing Then 
                        cn = Sn.Nodes.Add("")
                        cn.Tag = row
                        cn.NodeFont = regularFont
                        cn.ForeColor = LevelForeGroundColor(Sn.Level, row)
                        cn.Text = LevelText(Sn.Level, row)
                        cn.ToolTipText = LevelToolTipText(Sn.Level, row)
                        cn.Checked = Sn.Checked


                    Next

                    Cursor = Cursors.Default
                    Agg_All_LevelText_Sum()
                End Try

                Cursor = Cursors.Default
            End If
        End If
    End Sub
End Class
