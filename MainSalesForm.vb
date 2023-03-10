
'Todo:

'Bugs:
'   1. FIgure out why top sales person Is Not being highlighted after entered values are changed And the calculate button Is clicked again.




Public Class MainForm
    Dim maxSalesPercentage As Double
    Dim isTie As Boolean = False
    Dim salesData As New Dictionary(Of String, Dictionary(Of String, Integer)) From {
        {"Jim", New Dictionary(Of String, Integer)},
        {"Sky", New Dictionary(Of String, Integer)},
        {"Rob", New Dictionary(Of String, Integer)}}

    Dim highestSalesperson As String
    Dim salesPersonPercentages As New Dictionary(Of String, Double)
    Dim target As Integer = 100000
    Dim minimumSalesAmount As Integer = 5000
    Dim minimumSalesPercentage As Double = 0.1
    Dim topPerformers As New List(Of String)
    Dim totalSales As Integer
    Dim percentage As Double
    Dim maxPercentage As Double
    Dim salesPerson As String
    Dim salesByMonth As Dictionary(Of String, Integer)
    Dim grpBox As GroupBox
    Dim sales As Integer
    Dim month As String
    Dim monthSales As Dictionary(Of String, Integer)
    Dim salesByMonthWithValues As IEnumerable(Of KeyValuePair(Of String, Integer))
    Dim maxMonth As String
    Dim minMonth As String
    Dim maxSales As Integer
    Dim minSales As Integer
    Dim secondMaxPercentage As Double
    Dim txtBoxPercentage As TextBox
    Dim txtBoxTotalSalesPerc As TextBox
    Dim txtBoxTotalSales As TextBox
    Dim txtBoxSales As TextBox
    Dim txtBoxPercentageOther As TextBox
    Dim highestPercentage As Double = 0
    Dim totalSalesPerson As Integer
    Dim txtPercentage As TextBox
    Dim maxSalesPersonPercentages = New List(Of KeyValuePair(Of String, Double))()
    Dim jimData As New Dictionary(Of String, Integer)
    Dim skyData As New Dictionary(Of String, Integer)
    Dim robData As New Dictionary(Of String, Integer)
    Dim salesPersonData As KeyValuePair(Of String, Dictionary(Of String, Integer))
    Dim monthData As KeyValuePair(Of String, Integer)
    Dim salesPersonName As String
    Dim monthName As String
    Dim salesAmount As Integer
    Dim salesPersonTotalSales As Integer
    Dim previousHighestSalesperson As String









    Private Sub btnCalc_Click(sender As Object, e As EventArgs) Handles btnCalc.Click



        updateSalesData()

        ' Calculate the sales data for each salesperson
        CalculateSalesData()

        updateData()

        ' Update the labels first
        UpdateLabels()

        displayTotalSales()

        HighlightHigestSales()

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        ' Close the form
        Me.Close()
    End Sub


    Private Function updateSalesData()
        ' Update salesData dictionary with user-entered sales data
        For Each grpBox As GroupBox In Me.Controls.OfType(Of GroupBox)()
            salesPerson = grpBox.Name.Substring(3) ' Extract the salesperson's name from the group box name
            Dim monthSales As New Dictionary(Of String, Integer)

            ' Loop through each month and extract the sales data
            For Each txtBox As TextBox In grpBox.Controls.OfType(Of TextBox)()
                month = txtBox.Name.Substring(6) ' Extract the month from the text box name


                ' Validate the input and convert it to an integer
                If Integer.TryParse(txtBox.Text.Trim(), sales) Then
                    If sales < 0 Then
                        txtBox.Text = ""
                        MessageBox.Show($"Invalid input for {salesPerson} - {month}. Please enter a positive integer, blank boxes will be interpreted as a 0")
                    Else
                        If monthSales.ContainsKey(month) Then
                            monthSales(month) = sales
                        Else
                            monthSales.Add(month, sales)
                        End If
                    End If
                Else
                    txtBox.Text = "0"
                    If Not String.IsNullOrWhiteSpace(txtBox.Text) Then
                        MessageBox.Show($"Invalid input for {salesPerson} - {month}. Please enter a positive integer, blank boxes will be interpreted as a 0")
                    End If
                End If


                ' Add the sales data for the salesperson to the dictionary
                salesData(salesPerson) = monthSales
            Next

        Next
    End Function




    Private Function displayTotalSales()

        ' Display the total sales and highest salesperson
        If totalSales = 0 Then
            MessageBox.Show("Total sales cannot be zero. Please enter sales data for at least one salesperson.")
        End If

        txtTotalSales = Me.Controls.Find("txtTotalSales", True).FirstOrDefault()


        If txtTotalSales IsNot Nothing Then
            txtTotalSales.Text = totalSales.ToString()
        End If

        lblTopSalesperson = Me.Controls.Find("lblTopSalesperson", True).FirstOrDefault()
        If lblTopSalesperson IsNot Nothing Then
            lblTopSalesperson.Text = If(highestSalesperson IsNot Nothing, highestSalesperson, "-")
        End If
    End Function


    Private Sub updateData()
        ' Update Jim's sales data
        If salesData.ContainsKey("Jim") AndAlso salesData("Jim").Count > 0 Then
            jimData = salesData("Jim")
            txtJimSales.Text = jimData.Values.Sum().ToString()
            txtJimHighestSales.Text = jimData.Aggregate(Function(x, y) If(x.Value > y.Value, x, y)).Key
            txtJimLowestSales.Text = jimData.Aggregate(Function(x, y) If(x.Value < y.Value, x, y)).Key
        Else
            ' If Jim's data is missing, clear the text boxes
            txtJimSales.Text = ""
            txtJimHighestSales.Text = ""
            txtJimLowestSales.Text = ""
        End If

        ' Update Sky's sales data
        If salesData.ContainsKey("Sky") AndAlso salesData("Sky").Count > 0 Then
            skyData = salesData("Sky")
            txtSkySales.Text = skyData.Values.Sum().ToString()
            txtSkyHighestSales.Text = skyData.Aggregate(Function(x, y) If(x.Value > y.Value, x, y)).Key
            txtSkyLowestSales.Text = skyData.Aggregate(Function(x, y) If(x.Value < y.Value, x, y)).Key
        Else
            ' If Sky's data is missing, clear the text boxes
            txtSkySales.Text = ""
            txtSkyHighestSales.Text = ""
            txtSkyLowestSales.Text = ""
        End If

        ' Update Rob's sales data
        If salesData.ContainsKey("Rob") AndAlso salesData("Rob").Count > 0 Then
            robData = salesData("Rob")
            txtRobSales.Text = robData.Values.Sum().ToString()
            txtRobHighestSales.Text = robData.Aggregate(Function(x, y) If(x.Value > y.Value, x, y)).Key
            txtRobLowestSales.Text = robData.Aggregate(Function(x, y) If(x.Value < y.Value, x, y)).Key
        Else
            ' If Rob's data is missing, clear the text boxes
            txtRobSales.Text = ""
            txtRobHighestSales.Text = ""
            txtRobLowestSales.Text = ""
        End If
    End Sub






    Private Sub CalculateSalesData()
        topPerformers.Clear()

        ' Calculate the sales data for each salesperson

        ' Aggregates the sales data for each month across all salespeople
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
        salesByMonthWithValues = salesByMonth.Where(Function(x) x.Value > 0)
        maxMonth = salesByMonthWithValues.Aggregate(Function(x, y) If(x.Value > y.Value, x, y)).Key ' Get the month with the highest sales
        minMonth = salesByMonthWithValues.Aggregate(Function(x, y) If(x.Value < y.Value, x, y)).Key ' Get the month with the lowest sales
        maxSales = salesByMonthWithValues.Max(Function(x) x.Value)
        minSales = salesByMonthWithValues.Min(Function(x) x.Value)
        percentage = If(totalSales >= 0, Math.Round(salesByMonth.Values.Sum() / totalSales * 100, 1), 0)

        ' Check if this salesperson's percentage is among the top two so far
        maxPercentage = If(topPerformers.Count > 0, salesPersonPercentages(topPerformers(0)), 0)
        secondMaxPercentage = If(topPerformers.Count > 1, salesPersonPercentages(topPerformers(1)), 0)
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





        ' Update the maximum sales percentage value
        maxPercentage = If(isTie, maxPercentage, percentage)
        salesPersonPercentages(salesPerson) = percentage

    End Sub


    Private Sub HighlightHigestSales()
        Dim topEarners As List(Of String) = New List(Of String)
        Dim maxSales As Double = 0

        ' Determine who the top earners are
        For Each grpBox As GroupBox In Me.Controls.OfType(Of GroupBox)()
            Dim name = grpBox.Name.Substring(3) ' Extract the salesperson's name from the group box name
            Dim tb = Me.Controls.Find($"txt{name}Perc", True).FirstOrDefault()
            If tb IsNot Nothing Then
                tb.BackColor = SystemColors.Window

                Dim sales = Double.Parse(tb.Text.TrimEnd("%"))
                If sales > maxSales Then
                    maxSales = sales

                    topEarners.Clear()
                    topEarners.Add(name)
                Else
                    If sales = maxSales Then
                        topEarners.Add(name)
                    End If
                End If
            End If
        Next

        For Each earner As String In topEarners
            Dim tb = Me.Controls.Find($"txt{earner}Perc", True).FirstOrDefault()
            If tb IsNot Nothing Then
                tb.BackColor = Color.Yellow
            End If
        Next


    End Sub


    Private Sub UpdateLabels()
        ' Calculate the total sales and highest salesperson
        totalSales = salesData.Sum(Function(kvp) kvp.Value.Values.Sum())
        highestSalesperson = salesData.OrderByDescending(Function(x) x.Value.Values.Sum()).First().Key




        ' Calculate and display percentages for each salesperson
        maxPercentage = salesData.Values.SelectMany(Function(x) x.Values).Max()
        maxSalesPersonPercentages = salesPersonPercentages _
    .Where(Function(x) salesData(x.Key).Values.Sum() > 0) _
    .OrderByDescending(Function(x) x.Value) _
    .Take(2) _
    .ToList()

        ' Clear the top performers list
        topPerformers.Clear()

        For Each kvp In maxSalesPersonPercentages
            topPerformers.Add(kvp.Key)
        Next

        For Each salesPerson In salesData.Keys
            totalSalesPerson = salesData(salesPerson).Values.Sum()
            percentage = If(totalSales > 0, Math.Round((totalSalesPerson / totalSales) * 100, 1), 0)

            ' Store the percentage in the dictionary
            salesPersonPercentages(salesPerson) = percentage

            ' Update the percentage label for the salesperson
            txtPercentage = Me.Controls.Find($"txt{salesPerson}Perc", True).FirstOrDefault()
            If txtPercentage IsNot Nothing Then
                'Dim value As Double
                txtPercentage.Text = (percentage / 100).ToString("P2") 'If(Double.TryParse(txtPercentage.Text, value), value.ToString("P1"), "")
                'txtPercentage.BackColor = If(salesPerson = highestSalesperson, Color.Yellow, SystemColors.Control)
            End If
        Next

        '' If there is a tie for the top sales percentage, highlight all salespeople in the tie
        'If topPerformers.Count > 1 Then
        '    For Each salesPerson In salesPersonPercentages.Keys
        '        percentage = salesPersonPercentages(salesPerson)
        '        txtBoxPercentage = Me.Controls.Find($"txt{salesPerson}Perc", True).FirstOrDefault()
        '        If txtBoxPercentage IsNot Nothing AndAlso Math.Abs(percentage - maxPercentage) < 0.001 Then
        '            txtBoxPercentage.BackColor = If(topPerformers.Any(Function(x) x = salesPerson), Color.Yellow, SystemColors.Control)
        '        Else
        '            txtBoxPercentage.BackColor = SystemColors.Control
        '        End If
        '    Next
        'Else
        '    ' Highlight the percentage text box for the current salesperson
        '    For Each grpBox As GroupBox In Me.Controls.OfType(Of GroupBox)()
        '        salesPerson = grpBox.Name.Substring(3) ' Extract the salesperson's name from the group box name
        '        txtBoxPercentage = Me.Controls.Find($"txt{salesPerson}Perc", True).FirstOrDefault()
        '        If txtBoxPercentage IsNot Nothing Then
        '            txtBoxPercentage.BackColor = If(salesPerson = highestSalesperson, Color.Yellow, SystemColors.Control)
        '        End If
        '    Next
        'End If
    End Sub



    Private Sub txtBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtJimJan.KeyPress, txtJimFeb.KeyPress, txtJimMar.KeyPress, txtJimApr.KeyPress, txtJimMay.KeyPress, txtJimJun.KeyPress, txtJimJul.KeyPress, txtJimAug.KeyPress, txtJimSep.KeyPress, txtJimOct.KeyPress, txtJimNov.KeyPress, txtJimDec.KeyPress,
    txtSkyJan.KeyPress, txtSkyFeb.KeyPress, txtSkyMar.KeyPress, txtSkyApr.KeyPress, txtSkyMay.KeyPress, txtSkyJun.KeyPress, txtSkyJul.KeyPress, txtSkyAug.KeyPress, txtSkySep.KeyPress, txtSkyOct.KeyPress, txtSkyNov.KeyPress, txtSkyDec.KeyPress,
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