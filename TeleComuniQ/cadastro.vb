Imports System.Data.OleDb

Public Class cadastro

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
        login.Show()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        Dim conecta As String = "Provider=Microsoft.JET.OLEDB.4.0; Data Source=" & Application.StartupPath & "\TeleComuniQ.mdb"
        'Vai inserir registro na pasta bin\debug com o atributo application.startup
        Dim conexao As New OleDbConnection(conecta)
        Dim comando As OleDbCommand = Nothing
        Dim queryResult As Integer
        conexao.Open()
        comando = New OleDbCommand("SELECT COUNT(*) FROM login WHERE usuario ='" & Me.TextBox1.Text & "'", conexao)
        queryResult = comando.ExecuteScalar()
        conexao.Close()

        If queryResult = 0 Then
            conexao.Open()
            comando = New OleDbCommand("INSERT INTO login (usuario, senha) VALUES (@usuario, @senha)", conexao)
            comando.Parameters.AddWithValue("@usuario", OleDbType.VarChar).Value = Me.TextBox1.Text
            comando.Parameters.AddWithValue("@senha", OleDbType.VarChar).Value = Me.TextBox2.Text

            If Me.TextBox1.Text = "" Or TextBox2.Text = "" Then
                MsgBox("Preencha com seu nome e senha")
            Else
                comando.ExecuteNonQuery()
                conexao.Close()
                MsgBox("Registro adicionado")

                Form1.Show()
                Form1.TextBox6.Text = TextBox1.Text
                Me.Close()
            End If
        Else
            MsgBox("Já existe um registro com este nome")
            Me.TextBox1.Text = ""
            Me.TextBox2.Text = ""
        End If

















        'Dim inclui As String
        'Dim selecao As String
        'Dim conexao As New OleDb.OleDbConnection
        'Dim usuario As String
        'Try

        'conexao.ConnectionString = "Provider=Microsoft.JET.OLEDB.4.0; Data Source=C:\Users\Clovis Jr\Documents\Visual Studio 2010\Projects\TeleComuniQ\TeleComuniQ.mdb"
        'inclui = "INSERT INTO login (usuario,senha) VALUES('" & TextBox1.Text & "','" & TextBox2.Text & "')"
        'selecao = "SELECT usuario FROM login WHERE usuario = '" & TextBox1.Text & "'"
        'Dim comando As New OleDb.OleDbCommand(inclui, conexao)

        'conexao.Open()


       
        'comando.ExecuteNonQuery()





        'If selecao = TextBox1.Text Then

        'MsgBox("Já existe um usuário com esse nome!")


        'Else


        'Form1.Show()
        'Me.Hide()
        'Form1.Label1.Text = Me.TextBox1.Text

        'End If

        'conexao.Close()


    End Sub

    Private Sub TextBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.Leave




        'INSERE UMA FUNÇÃO ASSIM QUE O CAMPO TEXTBOX1 PERDE O FOCO










        'Dim conexao As OleDbConnection
        ' Dim texto As String = TextBox1.Text
        'Dim selecao As String


        'conexao = New OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0; Data Source=C:\Users\Clovis Jr\Documents\Visual Studio 2010\Projects\TeleComuniQ\TeleComuniQ.mdb")

        'selecao = "SELECT usuario FROM login "

        'Dim comando As New OleDb.OleDbCommand(selecao, conexao)
        'Dim reader As OleDbDataReader
        'conexao.Open()

        'comando.ExecuteNonQuery()

        'reader = comando.ExecuteReader(CommandBehavior.CloseConnection)







        'If ((reader.HasRows)) Then
        'If (TextBox1.Text = reader("usuario").ToString()) Then
        'MessageBox.Show("Nome já Cadastrado !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ' TextBox1.Focus()
        ' TextBox1.ForeColor = Color.Red
        'End If
        'End If
        'conexao.Close()
        'If selecao.ToString = texto Then

        'MsgBox("Já existe um usuário com esse nome!")





        'End If
        'Catch ex As Exception
        'MessageBox.Show("Erro ao conectar com a base de dados" + ex.Message)

        'End Try




    End Sub
End Class