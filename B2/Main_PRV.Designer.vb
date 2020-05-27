<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main_PRV
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.crvPRV = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.PRVUnderlag1 = New B2.PRVUnderlag()
        Me.SuspendLayout()
        '
        'crvPRV
        '
        Me.crvPRV.ActiveViewIndex = 0
        Me.crvPRV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvPRV.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvPRV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvPRV.Location = New System.Drawing.Point(0, 0)
        Me.crvPRV.Name = "crvPRV"
        Me.crvPRV.ReportSource = Me.PRVUnderlag1
        Me.crvPRV.Size = New System.Drawing.Size(2829, 1773)
        Me.crvPRV.TabIndex = 0
        '
        'PRVUnderlag1
        '
        '
        'Main_PRV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2829, 1773)
        Me.Controls.Add(Me.crvPRV)
        Me.Name = "Main_PRV"
        Me.Text = "Main_PRV"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents crvPRV As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents PRVUnderlag1 As B2.PRVUnderlag
End Class
