Public Class MainForm


    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnCalc_Click_1(sender As Object, e As EventArgs) Handles btnCalc.Click
        ' Clear the previous percentages
        txtJimSales.BackColor = SystemColors.Window
        txtJimPerc.BackColor = SystemColors.Window
        txtDaveSales.BackColor = SystemColors.Window
        txtDavePerc.BackColor = SystemColors.Window
        txtRobPerc.BackColor = SystemColors.Window

        ' Declare variables to store sales for each salesperson
        Dim jimSales As Double = 0
        Dim daveSales As Double = 0
        Dim robSales As Double = 0
        Dim totalSales As Double = 0
        Dim highestPercentage As Double = 0
        Dim highestSalesperson As String = String.Empty
        Dim tiedPercentage As Boolean = False
        ' Initialize max sales and the highest salesperson
        Dim maxSales As Decimal = 0


        ' Get sales input from text boxes
        Double.TryParse(txtJimSales.Text, jimSales)
        Double.TryParse(txtDaveSales.Text, daveSales)
        Double.TryParse(txtRobSales.Text, robSales)

        ' Calculate total sales
        totalSales = jimSales + daveSales + robSales

        ' Check for division by zero
        If totalSales <> 0 Then
            ' Calculate and display percentages for each salesperson
            If jimSales > 0 Then
                txtJimPerc.Text = (jimSales / totalSales * 100).ToString("P1")
            Else
                txtJimPerc.Text = "0.0%"
            End If
            If daveSales > 0 Then
                txtDavePerc.Text = (daveSales / totalSales * 100).ToString("P1")
            Else
                txtDavePerc.Text = "0.0%"
            End If
            If robSales > 0 Then
                txtRobPerc.Text = (robSales / totalSales * 100).ToString("P1")
            Else
                txtRobPerc.Text = "0.0%"
            End If
        Else
            txtJimPerc.Text = "0.0%"
            txtDavePerc.Text = "0.0%"
            txtRobPerc.Text = "0.0%"
        End If

        ' Check if there is a tie in sales
        If jimSales / totalSales * 100 = daveSales / totalSales * 100 AndAlso jimSales > 0 AndAlso daveSales > 0 Then
            tiedPercentage = True
            txtJimSales.BackColor = Color.Yellow
            txtJimPerc.BackColor = Color.Yellow
            txtDaveSales.BackColor = Color.Yellow
            txtDavePerc.BackColor = Color.Yellow
        ElseIf daveSales / totalSales * 100 = robSales / totalSales * 100 AndAlso daveSales > 0 AndAlso robSales > 0 Then
            tiedPercentage = True
            txtDaveSales.BackColor = Color.Yellow
            txtDavePerc.BackColor = Color.Yellow
            txtRobSales.BackColor = Color.Yellow
            txtRobPerc.BackColor = Color.Yellow
        ElseIf jimSales / totalSales * 100 = robSales / totalSales * 100 AndAlso jimSales > 0 AndAlso robSales > 0 Then
            tiedPercentage = True
            txtJimSales.BackColor = Color.Yellow
            txtJimPerc.BackColor = Color.Yellow
            txtRobSales.BackColor = Color.Yellow
            txtRobPerc.BackColor = Color.Yellow

            'If no sales figures are equal, Then the code sets the color Of the text boxes And percentage labels To their Default color

        Else
            tiedPercentage = False
            txtJimSales.BackColor = SystemColors.Control
            txtJimPerc.BackColor = SystemColors.Control
            txtDaveSales.BackColor = SystemColors.Control
            txtDavePerc.BackColor = SystemColors.Control
            txtRobSales.BackColor = SystemColors.Control
            txtRobPerc.BackColor = SystemColors.Control
        End If

        ' Calculate and display percentages for each salesperson
        If jimSales > 0 Then
            txtJimPerc.Text = (jimSales / totalSales * 100).ToString("P1")
        Else
            txtJimPerc.Text = "0.0%"
        End If
        If daveSales > 0 Then
            txtDavePerc.Text = (daveSales / totalSales * 100).ToString("P1")
        Else
            txtDavePerc.Text = "0.0%"
        End If
        If robSales > 0 Then
            txtRobPerc.Text = (robSales / totalSales * 100).ToString("P1")
        Else
            txtRobPerc.Text = "0.0%"
        End If

        ' Find the highest salesperson
        If jimSales > daveSales AndAlso jimSales > robSales Then
            highestPercentage = jimSales / totalSales * 100
            highestSalesperson = "Jim"
        ElseIf daveSales > jimSales AndAlso daveSales > robSales Then
            highestPercentage = daveSales / totalSales * 100
            highestSalesperson = "Dave"
        ElseIf robSales > jimSales AndAlso robSales > daveSales Then
            highestPercentage = robSales / totalSales * 100
            highestSalesperson = "Rob"
        End If

        ' Highlight the highest salesperson
        If highestSalesperson = "Jim" Then
            txtJimSales.BackColor = Color.Yellow
            txtJimPerc.BackColor = Color.Yellow
            txtDaveSales.BackColor = SystemColors.Control
            txtDavePerc.BackColor = SystemColors.Control
            txtRobSales.BackColor = SystemColors.Control
            txtRobPerc.BackColor = SystemColors.Control
        ElseIf highestSalesperson = "Dave" Then
            txtDaveSales.BackColor = Color.Yellow
            txtDavePerc.BackColor = Color.Yellow
            txtJimSales.BackColor = SystemColors.Control
            txtJimPerc.BackColor = SystemColors.Control
            txtRobSales.BackColor = SystemColors.Control
            txtRobPerc.BackColor = SystemColors.Control
        ElseIf highestSalesperson = "Rob" Then
            txtRobSales.BackColor = Color.Yellow
            txtRobPerc.BackColor = Color.Yellow
            txtJimSales.BackColor = SystemColors.Control
            txtJimPerc.BackColor = SystemColors.Control
            txtDaveSales.BackColor = SystemColors.Control
            txtDavePerc.BackColor = SystemColors.Control
        End If

    End Sub

End Class


