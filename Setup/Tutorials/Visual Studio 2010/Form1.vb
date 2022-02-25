Imports System.Data.OleDb
Public Class Form1
    Dim FF As New DynamicComponents.FormFlipper()
    Dim connetionString As String
    Dim connection As OleDbConnection
    Dim oledbAdapter As OleDbDataAdapter
    Dim sql As String
    Dim ds As New DataSet
    Dim i As Integer
    Dim Right2Left As Boolean = True

    Private Sub TestForm_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'establish DSN
        'establish DSN
        connetionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\nWind.accdb"
        sql = "select * from Customers"
        connection = New OleDbConnection(connetionString)

        Try

            connection.Open()
            oledbAdapter = New OleDbDataAdapter(sql, connection)
            oledbAdapter.Fill(ds)
            oledbAdapter.Dispose()
            connection.Close()
        Catch ex As Exception
            MsgBox("Can not open connection ! ")
            Exit Sub
        End Try

        PopulateData()
        FF.setRegistrationKey("0000-000-000-000-0000") ' replace with your purchased serial number once you get one
        FF.FlipForm(Me, True) ' Flip form ,so it is right 2 left 
    End Sub


    Private Sub ExitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitButton.Click
        Me.Close()

    End Sub

    Private Sub PopulateData()
        Dim Row As DataRow

        Row = ds.Tables(0).Rows(i)
        Me.CustomerID.Text = Row.Item(0).ToString
        Me.CustomerName.Text = Row.Item(1).ToString
        Me.Address.Text = Row.Item(2).ToString
        Me.Phone.Text = Row.Item(3).ToString

    End Sub

    Private Sub FirstButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FirstButton.Click
        i = 0
        PopulateData()
    End Sub

    Private Sub PreviousButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreviousButton.Click
        If i > 0 Then
            i = i - 1
        End If
        PopulateData()
    End Sub

    Private Sub NextButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NextButton.Click
        If i < (ds.Tables(0).Rows.Count - 1) Then
            i = i + 1
        End If
        PopulateData()
    End Sub

    Private Sub LastButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LastButton.Click
        i = ds.Tables(0).Rows.Count - 1
        PopulateData()
    End Sub

    Private Sub FlipForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlipForm.Click

        Dim y As Boolean

        If Right2Left = True Then
            Right2Left = False
        Else
            Right2Left = True
        End If

        FF.FlipForm(Me, Right2Left) ' Flip form 
    End Sub
End Class


