Public Class ClientSelectionPage
    Public Property SelectedClientID As Integer

    Public Sub New(clients As List(Of Tuple(Of Integer, String)))
        InitializeComponent()

        ' client options
        For Each client In clients
            Dim displayText As String = $"ID: {client.Item1} - Name: {client.Item2}"
            ListBoxClients.Items.Add(New With {.ClientID = client.Item1, .DisplayText = displayText})
        Next
        ListBoxClients.DisplayMember = "DisplayText"
    End Sub

    Private Sub BtnSelect_Click(sender As Object, e As EventArgs) Handles BtnSelect.Click
        If ListBoxClients.SelectedItem IsNot Nothing Then
            Dim selectedClient = CType(ListBoxClients.SelectedItem, Object)
            SelectedClientID = selectedClient.ClientID
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("Please select a client.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub BtnBack_Click(sender As Object, e As EventArgs) Handles BtnBack.Click
        Dim ClientPage As New ClientPage()
        ClientPage.Show()
        Me.Hide()
    End Sub

    Private Sub ListBoxClients_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxClients.SelectedIndexChanged

    End Sub
End Class