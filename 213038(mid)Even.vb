Using System;
Using System.Windows.Forms;

Namespace EmployeeSalaryCalculator
{
    Partial Public Class MainForm :  Form
    {
        Public MainForm()
        {
            InitializeComponent();
            oreach (string item in checkedListBoxBonuses.CheckedItems)
            {
                switch (item)
                {
                    Case "Project Completion Bonus" : 
                        bonusesTotal += 20000;
                        break;
                    Case "Year End Bonus" : 
                        bonusesTotal += 30000;
                        break;
                    Case "Performance Bonus" : 
                        bonusesTotal += 25000;
                        break;
                    Case "Customer appreciation Bonus" : 
                        bonusesTotal += 15000;
                        break;
                }
            }
        }

        Private void MainForm_Load(Object sender, EventArgs e)
        {
            // Set the default value of the Basic Salary based on the Employee Grade Level
            comboBoxGradeLevel.SelectedIndex = 0;
            SetBasicSalary();

            // Add items to the CheckedListBox for Bonuses
            checkedListBoxBonuses.Items.Add("Project Completion Bonus", false);
            checkedListBoxBonuses.Items.Add("Year End Bonus", false);
            checkedListBoxBonuses.Items.Add("Performance Bonus", false);
            checkedListBoxBonuses.Items.Add("Customer appreciation Bonus", false);
        }

        Private void SetBasicSalary()
        {
            switch (comboBoxGradeLevel.Text)
            {
                Case "Director" : 
                    radioButton30000.Checked = true;
                    break;
                Case "Manager" : 
                    radioButton40000.Checked = true;
                    break;
                Case "Project Manager" : 
                    radioButton50000.Checked = true;
                    break;
                Case "Programmer" : 
                    radioButton100000.Checked = true;
                    break;
                Default: 
                    break;
            }
        }

        Private void buttonCalculate_Click(Object sender, EventArgs e)
        {
            Double basicSalary = 0;
            Double benefitsTotal = 0;
            Double bonusesTotal = 0;
            Double deductions = 0;

            // Calculate Basic Salary
            If (radioButton30000.Checked) basicSalary = 30000;
            If (radioButton40000.Checked) basicSalary = 40000;
            If (radioButton50000.Checked) basicSalary = 50000;
            If (radioButton100000.Checked) basicSalary = 100000;

            // Calculate Benefits
            If (checkBoxHousingAllowance.Checked) benefitsTotal += 20000;
            If (checkBoxConveyanceAllowance.Checked) benefitsTotal += 15000;
            If (checkBoxOtherBenefit1.Checked) benefitsTotal += 10000;
            If (checkBoxOtherBenefit2.Checked) benefitsTotal += 10000;

            // Calculate Bonuses
            foreach (string item in checkedListBoxBonuses.CheckedItems)
            {
                switch (item)
                {
                    Case "Project Completion Bonus" : 
                        bonusesTotal += 20000;
                        break;
                    Case "Year End Bonus" : 
                        bonusesTotal += 30000;
                        break;
                    Case "Performance Bonus" : 
                        bonusesTotal += 25000;
                        break;
                    Case "Customer appreciation Bonus" : 
                        bonusesTotal += 15000;
                        break;
                }
            }

            // Deductions
            If (Double.TryParse(textBoxDeductions.Text, out Double deductionAmount))
            {
                deductions = deductionAmount;
            }

            // Calculate the total salary
            Double totalSalary = basicSalary + benefitsTotal + bonusesTotal - deductions;

            // Display the result
            MessageBox.Show("Total Salary: " + totalSalary.ToString("C"));
        }

        Private void comboBoxGradeLevel_SelectedIndexChanged(Object sender, EventArgs e)
        {
            SetBasicSalary();
        }

        Private void buttonExit_Click(Object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
