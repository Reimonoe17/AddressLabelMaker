'Jamison Burton
'RCET0265
'Spring 2022
'Address label program
'https://github.com/Reimonoe17/AddressLabelMaker

Public Class AddressLabelMakerForm

    'Text Box inputs are checked for content.
    Function ValidateInput() As Boolean
        Dim valid As Boolean = False

        If ZipCodeTextBox.Text = "" Then
            AccumulateMessage("Zip Code is Required")
            ZipCodeTextBox.Focus()
        End If

        If StateTextBox.Text = "" Then
            AccumulateMessage("State is Required")
            StateTextBox.Focus()
        End If

        If CityTextBox.Text = "" Then
            AccumulateMessage("City is Required")
            CityTextBox.Focus()
        End If

        If StreetAddressTextBox.Text = "" Then
            AccumulateMessage("Street Address is Required")
            StreetAddressTextBox.Focus()
        End If

        If LastNameTextBox.Text = "" Then
            AccumulateMessage("Last Name is Required")
            LastNameTextBox.Focus()
        End If

        If FirstNameTextBox.Text = "" Then
            AccumulateMessage("First Name is Required")
            FirstNameTextBox.Focus()
        End If

        If AccumulateMessage() <> "" Then
            MsgBox(AccumulateMessage())
            AccumulateMessage(, True)
            valid = True
        End If

        Return valid
    End Function

    'creates a message based on what text boxes are empty
    Private Function AccumulateMessage(Optional newMessage As String = "", Optional clear As Boolean = False) As String
        Static _message As String

        Select Case clear
            Case False
                If newMessage <> "" Then
                    _message &= newMessage & vbCrLf
                End If
            Case Else
                _message = ""
        End Select
        Return _message
    End Function

    Sub Reset()
        'resets all forms to default
        FirstNameTextBox.Text = ""
        LastNameTextBox.Text = ""
        StreetAddressTextBox.Text = ""
        CityTextBox.Text = ""
        ZipCodeTextBox.Text = ""
        DisplayLabel.Text = ""

    End Sub

    'compiles the text boxes into the Address Format
    Private Function FormatAddress()
        Dim _message As String

        _message &= FirstNameTextBox.Text & " "
        _message &= LastNameTextBox.Text & vbNewLine
        _message &= StreetAddressTextBox.Text & vbNewLine
        _message &= CityTextBox.Text & ", "
        _message &= StateTextBox.Text & " "
        _message &= ZipCodeTextBox.Text

        Return _message
    End Function

    Private Sub DisplayLabelButton_Click(sender As Object, e As EventArgs) Handles DisplayLabelButton.Click
        'Checks if text is present or not
        If ValidateInput() = False Then
            'clears any previous displayed information and adds in the FormatAddress information
            DisplayLabel.Text = ""
            DisplayLabel.Text = FormatAddress()
        End If

    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click

        DisplayLabel.Text = ""

    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub TestButton_Click(sender As Object, e As EventArgs) Handles TestButton.Click
        'inputs information rapidly for testing purposes
        FirstNameTextBox.Text = "Jamison"
        LastNameTextBox.Text = "Burton"
        StreetAddressTextBox.Text = "4 Privet Drive"
        CityTextBox.Text = "Surry"
        StateTextBox.Text = "Wales"
        ZipCodeTextBox.Text = "12345"

    End Sub
End Class
