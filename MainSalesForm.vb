Imports System.Security.Cryptography

Public Class MainForm
    Private maxSalesPercentage As Double
    Private isTie As Boolean = False
    Private salesData As New Dictionary(Of String, Dictionary(Of String, Integer)) From {
        {"Jim", New Dictionary(Of String, Integer) From {{"Jan", 0}, {"Feb", 0}, {"Mar", 0}, {"Apr", 0}, {"May", 0}, {"Jun", 0}, {"Jul", 0}, {"Aug", 0}, {"Sep", 0}, {"Oct", 0}, {"Nov", 0}, {"Dec", 0}}},
        {"Dave", New Dictionary(Of String, Integer) From {{"Jan", 0}, {"Feb", 0}, {"Mar", 0}, {"Apr", 0}, {"May", 0}, {"Jun", 0}, {"Jul", 0}, {"Aug", 0}, {"Sep", 0}, {"Oct", 0}, {"Nov", 0}, {"Dec", 0}}},
        {"Rob", New Dictionary(Of String, Integer) From {{"Jan", 0}, {"Feb", 0}, {"Mar", 0}, {"Apr", 0}, {"May", 0}, {"Jun", 0}, {"Jul", 0}, {"Aug", 0}, {"Sep", 0}, {"Oct", 0}, {"Nov", 0}, {"Dec", 0}}}
    }
    Private highestSalesperson As String
    Private salesPersonPercentages As New Dictionary(Of String, Double)
    Private target As Integer = 100000
    Private minimumSalesAmount As Integer = 5000
    Private minimumSalesPercentage As Double = 0.1
    Private topPerformers As New List(Of String)
    Private totalSales As Integer
    Private percentage As Double
    Private maxPercentage As Double
    Private salesPerson As String
    Private salesByMonth As Dictionary(Of String, Integer)
    Private grpBox As GroupBox





    Private Sub txtBox_TextChanged(sender As Object, e As EventArgs) Handles txtJimJan.TextChanged, txtJimFeb.TextChanged, txtJimMar.TextChanged, txtJimApr.TextChanged, txtJimMay.TextChanged, txtJimJun.TextChanged, txtJimJul.TextChanged, txtJimAug.TextChanged, txtJimSep.TextChanged, txtJimOct.TextChanged, txtJimNov.TextChanged, txtJimDec.TextChanged,
    txtDaveJan.TextChanged, txtDaveFeb.TextChanged, txtDaveMar.TextChanged, txtDaveApr.TextChanged, txtDaveMay.TextChanged, txtDaveJun.TextChanged, txtDaveJul.TextChanged, txtDaveAug.TextChanged, txtDaveSep.TextChanged, txtDaveOct.TextChanged, txtDaveNov.TextChanged, txtDaveDec.TextChanged,
    txtRobJan.TextChanged, txtRobFeb.TextChanged, txtRobMar.TextChanged, txtRobApr.TextChanged, txtRobMay.TextChanged, txtRobJun.TextChanged, txtRobJul.TextChanged, txtRobAug.TextChanged, txtRobSep.TextChanged, txtRobOct.TextChanged, txtRobNov.TextChanged, txtRobDec.TextChanged


    End Sub




    Private Sub btnCalc_Click(sender As Object, e As EventArgs) Handles btnCalc.Click
        ' Update the labels first
        UpdateLabels()

        ' Calculate the sales data for each salesperson
        CalculateSalesData()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        ' Close the form
        Me.Close()
    End Sub

    Private Sub CalculateSalesData()
        ' Update salesData dictionary with user-entered sales data
        For Each grpBox As GroupBox In Me.Controls.OfType(Of GroupBox)()
            Dim salesPerson As String = grpBox.Name.Substring(3) ' Extract the salesperson's name from the group box name
            Dim monthSales As New Dictionary(Of String, Integer)

            ' Loop through each month and extract the sales data
            For Each txtBox As TextBox In grpBox.Controls.OfType(Of TextBox)()
                Dim month As String = txtBox.Name.Substring(6) ' Extract the month from the text box name
                Dim sales As Integer

                ' Validate the input and convert it to an integer
                If Integer.TryParse(txtBox.Text, sales) AndAlso sales >= 0 Then
                    If monthSales.ContainsKey(month) Then
                        monthSales(month) = sales
                    Else
                        monthSales.Add(month, sales)
                    End If
                Else
                    txtBox.Text = ""
                    MessageBox.Show($"Invalid input for {salesPerson} - {month}. Please enter a positive integer.")
                End If
            Next

            ' Add the sales data for the salesperson to the dictionary
            salesData(salesPerson) = monthSales
        Next

        ' Calculate the sales data for each salesperson

        salesByMonth = New Dictionary(Of String, Integer)()
        For Each salesPersonData In salesData
            For Each monthData In salesPersonData.Value
                If salesByMonth.ContainsKey(monthData.Key) Then
                    salesByMonth(monthData.Key) += monthData.Value
                Else
                    salesByMonth.Add(monthData.Key, monthData.Value)
                End If
            Next
        Next

        ' Calculate the sales data for the salesperson
        Dim salesByMonthWithValues = salesByMonth.Where(Function(x) x.Value > 0)
        Dim maxMonth = salesByMonthWithValues.Aggregate(Function(x, y) If(x.Value > y.Value, x, y)).Key ' Get the month with the highest sales
        Dim minMonth = salesByMonthWithValues.Aggregate(Function(x, y) If(x.Value < y.Value, x, y)).Key ' Get the month with the lowest sales
        Dim maxSales = salesByMonthWithValues.Max(Function(x) x.Value)
        Dim minSales = salesByMonthWithValues.Min(Function(x) x.Value)
        Dim percentage As Double = If(totalSales > 0, Math.Round(salesByMonth.Values.Sum() / totalSales * 100, 1), 0)

        ' Check if this salesperson's percentage is among the top two so far
        Dim maxPercentage = If(topPerformers.Count > 0, salesPersonPercentages(topPerformers(0)), 0)
        Dim secondMaxPercentage = If(topPerformers.Count > 1, salesPersonPercentages(topPerformers(1)), 0)
        isTie = topPerformers.Count > 1 AndAlso maxPercentage = secondMaxPercentage

        If percentage >= maxPercentage Then
            If percentage > maxPercentage Then
                topPerformers.Clear()
            End If

            ' Add this salesperson to the top performers list
            If Not topPerformers.Contains(salesPerson) Then
                topPerformers.Add(salesPerson)
            End If
        End If
        ' Highlight the percentage text box for the current salesperson
        For Each grpBox As GroupBox In Me.Controls.OfType(Of GroupBox)()
            Dim salesPerson As String = grpBox.Name.Substring(3) ' Extract the salesperson's name from the group box name
            Dim txtBoxPercentage = Me.Controls.Find($"txt{salesPerson}Perc", True).FirstOrDefault()
            If txtBoxPercentage IsNot Nothing Then
                txtBoxPercentage.BackColor = If(topPerformers.Any(Function(x) x = salesPerson), Color.Yellow, SystemColors.Window)
            End If

            Dim txtBoxTotalSalesPerc = Me.Controls.Find($"txt{salesPerson}TotalSalesPerc", True).FirstOrDefault()
            If txtBoxTotalSalesPerc IsNot Nothing Then
                txtBoxTotalSalesPerc.BackColor = If(salesData.ContainsKey(salesPerson) AndAlso salesData(salesPerson).Values.Sum() < minimumSalesAmount OrElse percentage < minimumSalesPercentage, Color.Red, SystemColors.Window)
            End If
        Next

        ' Display the total sales and highest salesperson
        If totalSales = 0 Then
            MessageBox.Show("Total sales cannot be zero. Please enter sales data for at least one salesperson.")
            Exit Sub
        End If

        Dim lblTotalSales = Me.Controls.Find("lblTotalSales", True).FirstOrDefault()
        If lblTotalSales IsNot Nothing Then
            lblTotalSales.Text = totalSales.ToString()
        End If

        Dim lblTopSalesperson = Me.Controls.Find("lblTopSalesperson", True).FirstOrDefault()
        If lblTopSalesperson IsNot Nothing Then
            lblTopSalesperson.Text = If(highestSalesperson IsNot Nothing, highestSalesperson, "-")
        End If

        ' Check if there is a tie for the top sales percentage
        isTie = topPerformers.Count > 1 AndAlso topPerformers.Select(Function(sp) salesData(sp).Values.Sum()).Distinct().Count() = 1

        ' If there is a tie for the top sales percentage, highlight both salespeople
        If isTie Then
            For Each performer In topPerformers
                Dim txtBoxPercentageOther = Me.Controls.Find($"txt{performer}Perc", True).FirstOrDefault()
                If txtBoxPercentageOther IsNot Nothing Then
                    txtBoxPercentageOther.BackColor = Color.Yellow
                End If
            Next
        End If

        ' Update the maximum sales percentage value
        maxPercentage = If(isTie, maxPercentage, percentage)
        salesPersonPercentages(salesPerson) = percentage

    End Sub


    Private Sub UpdateLabels()
        ' Calculate the total sales and highest salesperson
        Dim totalSales = salesData.Values.Sum(Function(x) x.Values.Sum())
        Dim highestSalesperson = salesData.OrderByDescending(Function(x) x.Value.Values.Sum()).First().Key

        ' Calculate and display percentages for each salesperson
        Dim maxPercentage = salesData.Values.SelectMany(Function(x) x.Values).Max()
        Dim topPerformers As List(Of String) = salesData _
    .Where(Function(x) x.Value.Values.Sum() > 0) _
    .OrderByDescending(Function(x) x.Value.Values.Sum()) _
    .Take(2) _
    .Select(Function(x) x.Key) _
    .ToList()

        For Each kvp In salesData
            For Each innerKvp In kvp.Value
                If innerKvp.Value = maxPercentage Then
                    topPerformers.Add(kvp.Key)
                    Exit For
                End If
            Next
        Next

        Dim highestPercentage As Double = 0
        Dim salesPersonPercentages As New Dictionary(Of String, Double)()

        For Each salesPerson In salesData.Keys
            Dim totalSalesPerson As Integer = salesData(salesPerson).Values.Sum()
            Dim percentage As Double = If(totalSales > 0, Math.Round(totalSalesPerson / totalSales * 100, 1), 0)

            ' Store the percentage in the dictionary
            salesPersonPercentages(salesPerson) = percentage

            ' Update the percentage label for the salesperson
            Dim lblPercentage = Me.Controls.Find($"txt{salesPerson}Perc", True).FirstOrDefault()
            If lblPercentage IsNot Nothing Then
                lblPercentage.Text = If(Double.TryParse(percentage.ToString(), 0), (CDbl(percentage) * 100).ToString("N1") & "%", "") & "%"
                lblPercentage.BackColor = If(salesPerson = highestSalesperson, Color.Yellow, SystemColors.Control)
            End If
        Next

        ' If there is a tie for the top sales percentage, highlight all salespeople in the tie
        If topPerformers.Count > 1 Then
            For Each salesPerson In salesPersonPercentages.Keys
                Dim percentage = salesPersonPercentages(salesPerson)
                Dim txtBoxPercentage = Me.Controls.Find($"txt{salesPerson}Perc", True).FirstOrDefault()
                If txtBoxPercentage IsNot Nothing AndAlso Math.Abs(percentage - maxPercentage) < 0.001 Then
                    txtBoxPercentage.BackColor = Color.Yellow
                Else
                    txtBoxPercentage.BackColor = SystemColors.Control
                End If
            Next
        End If

        ' Update the maximum sales percentage value
        maxPercentage = If(isTie, maxPercentage, percentage)
        salesPersonPercentages(salesPerson) = percentage

    End Sub

    Private Sub txtBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtJimJan.KeyPress, txtJimFeb.KeyPress, txtJimMar.KeyPress, txtJimApr.KeyPress, txtJimMay.KeyPress, txtJimJun.KeyPress, txtJimJul.KeyPress, txtJimAug.KeyPress, txtJimSep.KeyPress, txtJimOct.KeyPress, txtJimNov.KeyPress, txtJimDec.KeyPress,
    txtDaveJan.KeyPress, txtDaveFeb.KeyPress, txtDaveMar.KeyPress, txtDaveApr.KeyPress, txtDaveMay.KeyPress, txtDaveJun.KeyPress, txtDaveJul.KeyPress, txtDaveAug.KeyPress, txtDaveSep.KeyPress, txtDaveOct.KeyPress, txtDaveNov.KeyPress, txtDaveDec.KeyPress,
    txtRobJan.KeyPress, txtRobFeb.KeyPress, txtRobMar.KeyPress, txtRobApr.KeyPress, txtRobMay.KeyPress, txtRobJun.KeyPress, txtRobJul.KeyPress, txtRobAug.KeyPress, txtRobSep.KeyPress, txtRobOct.KeyPress, txtRobNov.KeyPress, txtRobDec.KeyPress
        ' Only allow digits and the backspace key
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> Chr(Keys.Back) Then
            e.Handled = True
        End If
    End Sub

    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Ask the user to confirm before closing the form
        Dim result = MessageBox.Show("Are you sure you want to exit the application?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.No Then
            e.Cancel = True
        End If
    End Sub

End Class