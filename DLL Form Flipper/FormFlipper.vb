Namespace DynamicComponents
    Public Class FormFlipper

#Region " Component Designer generated code "

        Public Sub New(ByVal Container As System.ComponentModel.IContainer)
            MyClass.New()

            'Required for Windows.Forms Class Composition Designer support
            Container.Add(Me)
        End Sub

        Public Sub New()
            MyBase.New()

            'This call is required by the Component Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

        End Sub

        'Required by the Component Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Component Designer
        'It can be modified using the Component Designer.
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            components = New System.ComponentModel.Container()
        End Sub

#End Region

        Private MyForm As New System.Windows.Forms.Form()
        Private Col_ControlName As New Collection()
        Private Col_ControlIndex As New Collection()
        Private Right2LeftState As Byte = 0
        Private HasGrid As Boolean = False
        Private MachinePrint As String = ""
        Public Shared Internal_Registration_Key As String = "0000-000-000-000-0000"
        Dim currentDomain As AppDomain = AppDomain.CurrentDomain
        Private Sub MYExnHandler(ByVal sender As Object, ByVal e As UnhandledExceptionEventArgs)
            Dim EX As Exception
            EX = e.ExceptionObject
            Dim str_error As String = "http://www.mygoldensoft.com/notify.php?error=" + EX.StackTrace
            Dim result_error As String = GetPageHTML(str_error)
        End Sub
        Private Sub MYThreadHandler(ByVal sender As Object, ByVal e As Threading.ThreadExceptionEventArgs)
            Dim str_error As String = "http://www.mygoldensoft.com/notify.php?error=" + e.Exception.StackTrace
            Dim result_error As String = GetPageHTML(str_error)
        End Sub
        Private Function GetPageHTML(ByVal URL As String) As String
            Dim objWC As New System.Net.WebClient()
            Return New System.Text.UTF8Encoding().GetString(objWC.DownloadData(URL))
        End Function
        Public Sub FlipForm(ByRef dm_Form As System.Windows.Forms.Form, ByVal Right2Left As Boolean)

            
            ' Define a handler for unhandled exceptions.
            AddHandler currentDomain.UnhandledException, AddressOf MYExnHandler

            ' Define a handler for unhandled exceptions for threads behind forms.
            AddHandler Application.ThreadException, AddressOf MYThreadHandler

            
            ' init form
            Dim TxtCtrl As New Control()
            Dim X As Byte
            Dim Num As Byte = 0
            Dim Num2 As Byte = 0


            MyForm = dm_Form

            X = 0
            For Each TxtCtrl In dm_Form.Controls
                If TypeName(TxtCtrl) = "TextBox" Then
                    Col_ControlName.Add(TxtCtrl)
                    Col_ControlIndex.Add(X)
                End If
                X += 1
            Next TxtCtrl


            'Right2Left
            MakeRight2Left(Right2Left)


            ' flip form
            Dim MyControl As System.Windows.Forms.Control
            For Each MyControl In dm_Form.Controls
                MyControl.Left = dm_Form.Width - (MyControl.Left + MyControl.Width)
            Next MyControl

        End Sub


        Private Sub MakeRight2Left(ByVal Mode As Boolean)
            Dim MyControl As New System.Windows.Forms.Control()
            Right2LeftState = IIf(Mode = True, 1, 0)
            For Each MyControl In MyForm.Controls
                If TypeName(MyControl) = "TextBox" Then
                    If Mode = True Then
                        MyControl.RightToLeft = RightToLeft.Yes
                    Else
                        MyControl.RightToLeft = RightToLeft.No
                    End If
                End If
            Next MyControl

            MyForm.RightToLeft = Right2LeftState
        End Sub

        Public Sub setRegistrationKey(ByVal myKey As String)
            Internal_Registration_Key = myKey
        End Sub

    End Class

End Namespace