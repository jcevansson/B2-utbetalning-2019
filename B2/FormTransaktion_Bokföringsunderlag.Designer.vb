<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTransaktion_Bokföringsunderlag
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
        Me.crvBokföringsunderlag = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.TransaktionBokföringsunderlag1 = New B2.TransaktionBokföringsunderlag()
        Me.SuspendLayout()
        '
        'crvBokföringsunderlag
        '
        Me.crvBokföringsunderlag.ActiveViewIndex = 0
        Me.crvBokföringsunderlag.AutoSize = True
        Me.crvBokföringsunderlag.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.crvBokföringsunderlag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvBokföringsunderlag.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvBokföringsunderlag.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvBokföringsunderlag.Location = New System.Drawing.Point(0, 0)
        Me.crvBokföringsunderlag.Margin = New System.Windows.Forms.Padding(6)
        Me.crvBokföringsunderlag.Name = "crvBokföringsunderlag"
        Me.crvBokföringsunderlag.ReportSource = Me.TransaktionBokföringsunderlag1
        Me.crvBokföringsunderlag.ReuseParameterValuesOnRefresh = True
        Me.crvBokföringsunderlag.Size = New System.Drawing.Size(1382, 1100)
        Me.crvBokföringsunderlag.TabIndex = 0
        Me.crvBokföringsunderlag.ToolPanelWidth = 400
        '
        'TransaktionBokföringsunderlag1
        '
        '
        'FormTransaktion_Bokföringsunderlag
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1382, 1100)
        Me.Controls.Add(Me.crvBokföringsunderlag)
        Me.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.Name = "FormTransaktion_Bokföringsunderlag"
        Me.Text = "Bokföringsunderlag"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TransaktionBokföringsunderlag1 As B2.TransaktionBokföringsunderlag
    Public WithEvents crvBokföringsunderlag As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
