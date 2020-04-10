' Name:         Utilities Project
' Purpose:      Display utility bills.
' Programmer:   Ian on 04/09/2020

Option Explicit On
Option Strict On
Option Infer Off

Public Class frmMain
    Private Sub BillsBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles BillsBindingNavigatorSaveItem.Click
        Try
            Me.Validate()
            Me.BillsBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.UtilitiesDataSet)
            MessageBox.Show("Changes saved.", "Monthly Bills",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Monthly Bills",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'UtilitiesDataSet.Bills' table. You can move, or remove it, as needed.
        Me.BillsTableAdapter.Fill(Me.UtilitiesDataSet.Bills)
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        me.Close()
    End Sub

    Private Sub btnCalc_Click(sender As Object, e As EventArgs) Handles btnCalc.Click
        Dim decElectricityTotal As Decimal
        Dim decWaterTotal As Decimal
        Dim decGasTotal As Decimal
        Dim decBillsTotal As Decimal
        For Each row As UtilitiesDataSet.BillsRow In UtilitiesDataSet.Bills
            decElectricityTotal += row.Electricity
            decWaterTotal += row.Water
            decGasTotal += row.Gas
        Next
        decBillsTotal = decElectricityTotal + decWaterTotal + decGasTotal
        lblElectricity.Text = decElectricityTotal.ToString("C2")
        lblWater.Text = decWaterTotal.ToString("C2")
        lblGas.Text = decGasTotal.ToString("C2")
        lblTotal.Text = decBillsTotal.ToString("C2")
    End Sub
End Class
