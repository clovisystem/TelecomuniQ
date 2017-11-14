Imports System.Data.OleDb
Public Class login
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim verifica As String

        Dim conexao As New OleDb.OleDbConnection
        Dim usuario As String
        Try
            Dim conecta As String = "Provider=Microsoft.JET.OLEDB.4.0; Data Source=" & Application.StartupPath & "\TeleComuniQ.mdb"
            conexao.ConnectionString = conecta
            verifica = "SELECT usuario FROM login WHERE usuario = '" & TextBox1.Text & "' And senha= '" & TextBox2.Text & "' "
            Dim comando As New OleDb.OleDbCommand(verifica, conexao)

            conexao.Open()
            usuario = comando.ExecuteScalar()
            comando.ExecuteNonQuery()

            conexao.Close()

            If usuario > "" Then
                'MsgBox("sucesso")
                Form1.Show()
                Form1.TextBox6.Text = TextBox1.Text
                Me.Hide()

            Else

                'se estiver errado envio um messagem de erro ao usuario

                MessageBox.Show("Usuario ou senha inválidos")

            End If
        Catch ex As Exception
            MessageBox.Show("Erro ao conectar com a base de dados" + ex.Message)

        End Try



    End Sub

 

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        cadastro.Show()
        Me.Hide()
    End Sub


    Private Sub login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Focus()

    End Sub

 
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()

    End Sub
End Class