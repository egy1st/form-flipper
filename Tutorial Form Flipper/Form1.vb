Public Class Form1
    Dim FF As New DynamicComponents.FormFlipper()
    Dim CN As New ADODB.Connection()
    Dim oCust As New ADODB.Recordset()
    Dim oAccess As New Microsoft.Office.Interop.Access.Application()
    Dim DAO_DBEngine As New DAO.DBEngine()
    Dim Right2Left As Boolean = True

    Private Sub TestForm_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'establish DSN
        oAccess.DBEngine.RegisterDatabase("DCDM_Nwind", "Microsoft Access Driver (*.mdb)", True, "DBQ=" & Application.StartupPath & "\Nwind.mdb")
        CN.Open("DSN=DCDM_NWind")
        oCust.Open("Customers", CN, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        PopulateData()
        FF.FlipForm(Me, True) ' Flip form ,so it is right 2 left 
    End Sub


    Private Sub ExitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitButton.Click
        oAccess.Quit()
        Me.Close()

    End Sub

    Private Sub PopulateData()
        Me.CustomerID.Text = oCust.Fields("CustomerID").Value
        Me.CustomerName.Text = oCust.Fields("CustomerName").Value
        Me.Address.Text = oCust.Fields("Address").Value
        Me.Phone.Text = oCust.Fields("Phone").Value
        Me.MaxDebit.Text = oCust.Fields("MaxDebit").Value
        Me.LastDeal.Text = oCust.Fields("LastDeal").Value

    End Sub

    Private Sub FirstButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FirstButton.Click
        oCust.MoveFirst()
        PopulateData()
    End Sub

    Private Sub PreviousButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreviousButton.Click
        On Error Resume Next

        oCust.MovePrevious()
        PopulateData()
    End Sub

    Private Sub NextButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NextButton.Click
        On Error Resume Next

        oCust.MoveNext()
        PopulateData()
    End Sub

    Private Sub LastButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LastButton.Click
        oCust.MoveLast()
        PopulateData()
    End Sub

    Private Sub FlipForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlipForm.Click
        If Right2Left = True Then
            Right2Left = False
        Else
            Right2Left = True
        End If

        FF.FlipForm(Me, Right2Left) ' Flip form 
    End Sub
End Class


