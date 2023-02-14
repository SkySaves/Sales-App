<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtJimSales = New System.Windows.Forms.TextBox()
        Me.txtDaveSales = New System.Windows.Forms.TextBox()
        Me.txtRobSales = New System.Windows.Forms.TextBox()
        Me.txtJimPerc = New System.Windows.Forms.TextBox()
        Me.txtDavePerc = New System.Windows.Forms.TextBox()
        Me.txtRobPerc = New System.Windows.Forms.TextBox()
        Me.btnCalc = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(40, 121)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Jim"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(40, 198)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 25)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Dave"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(40, 281)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 25)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Rob"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(182, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 25)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Total Sales"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(370, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(122, 25)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Percentages"
        '
        'txtJimSales
        '
        Me.txtJimSales.Location = New System.Drawing.Point(187, 121)
        Me.txtJimSales.Name = "txtJimSales"
        Me.txtJimSales.Size = New System.Drawing.Size(106, 22)
        Me.txtJimSales.TabIndex = 1
        '
        'txtDaveSales
        '
        Me.txtDaveSales.Location = New System.Drawing.Point(187, 198)
        Me.txtDaveSales.Name = "txtDaveSales"
        Me.txtDaveSales.Size = New System.Drawing.Size(106, 22)
        Me.txtDaveSales.TabIndex = 2
        '
        'txtRobSales
        '
        Me.txtRobSales.Location = New System.Drawing.Point(187, 281)
        Me.txtRobSales.Name = "txtRobSales"
        Me.txtRobSales.Size = New System.Drawing.Size(106, 22)
        Me.txtRobSales.TabIndex = 3
        '
        'txtJimPerc
        '
        Me.txtJimPerc.Location = New System.Drawing.Point(375, 125)
        Me.txtJimPerc.Name = "txtJimPerc"
        Me.txtJimPerc.ReadOnly = True
        Me.txtJimPerc.Size = New System.Drawing.Size(117, 22)
        Me.txtJimPerc.TabIndex = 10
        '
        'txtDavePerc
        '
        Me.txtDavePerc.Location = New System.Drawing.Point(375, 202)
        Me.txtDavePerc.Name = "txtDavePerc"
        Me.txtDavePerc.ReadOnly = True
        Me.txtDavePerc.Size = New System.Drawing.Size(117, 22)
        Me.txtDavePerc.TabIndex = 10
        '
        'txtRobPerc
        '
        Me.txtRobPerc.Location = New System.Drawing.Point(375, 281)
        Me.txtRobPerc.Name = "txtRobPerc"
        Me.txtRobPerc.ReadOnly = True
        Me.txtRobPerc.Size = New System.Drawing.Size(117, 22)
        Me.txtRobPerc.TabIndex = 10
        '
        'btnCalc
        '
        Me.btnCalc.Location = New System.Drawing.Point(432, 338)
        Me.btnCalc.Name = "btnCalc"
        Me.btnCalc.Size = New System.Drawing.Size(96, 37)
        Me.btnCalc.TabIndex = 4
        Me.btnCalc.Text = "Calculate"
        Me.btnCalc.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(534, 338)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(96, 37)
        Me.btnExit.TabIndex = 5
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(648, 390)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnCalc)
        Me.Controls.Add(Me.txtRobPerc)
        Me.Controls.Add(Me.txtRobSales)
        Me.Controls.Add(Me.txtDavePerc)
        Me.Controls.Add(Me.txtDaveSales)
        Me.Controls.Add(Me.txtJimPerc)
        Me.Controls.Add(Me.txtJimSales)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Name = "MainForm"
        Me.Text = "Sales Calculator"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtJimSales As TextBox
    Friend WithEvents txtDaveSales As TextBox
    Friend WithEvents txtRobSales As TextBox
    Friend WithEvents txtJimPerc As TextBox
    Friend WithEvents txtDavePerc As TextBox
    Friend WithEvents txtRobPerc As TextBox
    Friend WithEvents btnCalc As Button
    Friend WithEvents btnExit As Button
End Class
