Public Class FormKontrolluppgiftEnskild

    Private Sub FormKontrolluppgiftEnskild_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'B2DataSet.v_Betalning_kontrolluppgift_Utskick' table. You can move, or remove it, as needed.
        'tbÅr.Text = Date.Now.Year - 1
        cbÅr_fill()
        setSelect(cbÅr.SelectedItem)
 

        '       tbÅr.Text = Date.Now.Year - 1

        setFilter()
       
    End Sub

    Private Sub setSelect(ByVal ÅR As Integer)
        Cursor = Cursors.AppStarting
        
        Me.V_Betalning_kontrolluppgift_UtskickTableAdapter.Connection.ConnectionString = My.Settings.DBconnectionString.ToString
        Me.V_Betalning_kontrolluppgift_UtskickTableAdapter.selectcommand.CommandText = "SELECT år, Efternamn, förnamn, personnummer, OrganisationsNummer, calc_Kontrolluppgift, betalningsmottagare_typ, Ärvd, U_Efternamn, U_Förnamn, U_Personnummer, Ersättningstyp FROM dbo.v_Betalning_kontrolluppgift_Utskick WHERE åR=" & ÅR
        Me.V_Betalning_kontrolluppgift_UtskickTableAdapter.Fill(Me.B2DataSet_Kontrolluppfigt_Enskild.v_Betalning_kontrolluppgift_Utskick)


        'TODO: This line of code loads data into the 'B2DataSet_Kontrolluppgiftsummering.v_betalning_kontrolluppgift_summering' table. You can move, or remove it, as needed.
        Me.V_betalning_kontrolluppgift_summeringTableAdapter.Connection.ConnectionString = My.Settings.DBconnectionString.ToString
        Me.V_betalning_kontrolluppgift_summeringTableAdapter.selectcommand.CommandText = "SELECT År, Personnummer, organisationsnummer, Efternamn, Förnamn, calc_SUM_Kontrolluppgift, calc_SUM_Kontrolluppgift_Royalty, calc_SUM_Kontrolluppgift_Ärvd_Royalty FROM dbo.v_betalning_kontrolluppgift_summering where ÅR= " & ÅR
        Me.V_betalning_kontrolluppgift_summeringTableAdapter.Fill(Me.B2DataSet_Kontrolluppgiftsummering.v_betalning_kontrolluppgift_summering)
        Cursor = Cursors.Default

    End Sub
    Private Sub cbÅr_fill()
        cbÅr.Items.Clear()
        For i As Int16 = CInt(Date.Today.Year) To CInt(Date.Today.Year) - 20 Step -1
            cbÅr.Items.Add(i)

        Next
        cbÅr.SelectedIndex = 1 ' Förra året.
    End Sub
    

    Private Sub tbEfternamn_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbEfternamn.TextChanged
        setFilter()
    End Sub


    Private Sub tbFörnamn_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbFörnamn.TextChanged
        setFilter()
    End Sub

    Private Sub tbPersonnummer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbPersonnummer.TextChanged
        setFilter()
    End Sub

    Sub setFilter()
        VbetalningkontrolluppgiftsummeringBindingSource.Filter = "Efternamn like '%" & tbEfternamn.Text.Trim & "%' and Förnamn like '%" & tbFörnamn.Text.Trim & "%'" & _
            "and (Personnummer like '%" & tbPersonnummer.Text.Replace("-", "").Trim & "%' OR" & _
            " ORganisationsnummer like '%" & tbPersonnummer.Text.Replace("-", "").Trim & "%')"
        setFilterSub()
    End Sub
    Sub setFilterSub()
        If dgvEnskildKontrollUppgiftSumma.SelectedRows.Count > 0 Then
            VBetalningkontrolluppgiftUtskickBindingSource.Filter = "Personnummer='" & dgvEnskildKontrollUppgiftSumma.SelectedRows(0).Cells(1).Value.ToString _
                & "' AND Organisationsnummer='" & dgvEnskildKontrollUppgiftSumma.SelectedRows(0).Cells(2).Value.ToString & "'"
        Else
            VBetalningkontrolluppgiftUtskickBindingSource.Filter = "År=0"
        End If


    End Sub

    Private Sub dgvEnskildKontrollUppgiftSumma_ClickCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEnskildKontrollUppgiftSumma.CellClick
        setFilterSub()
    End Sub
    Private Sub dgvEnskildKontrollUppgiftSumma_KeyDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvEnskildKontrollUppgiftSumma.KeyUp

        setFilterSub()
    End Sub

    Private Sub cbÅr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbÅr.SelectedIndexChanged
        setSelect(cbÅr.SelectedItem)
        'setFilterSub()
    End Sub
End Class