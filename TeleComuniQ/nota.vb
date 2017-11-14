Imports System.Data.OleDb


Public Class nota

    Dim conexao As OleDbConnection
    Dim ds As DataSet
    Dim da As OleDbDataAdapter
    Dim i As Integer = 0





    Private Sub nota_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim conecta As String = "Provider=Microsoft.JET.OLEDB.4.0; Data Source=" & Application.StartupPath & "\TeleComuniQ.mdb"

        conexao = New OleDbConnection(conecta)
        conexao.Open()
        da = New OleDbDataAdapter("SELECT * FROM dados WHERE aluno LIKE '%" & TextBox12.Text & "%' ORDER BY id DESC", conexao)
        ds = New DataSet()
        da.Fill(ds, "dados")
        Call ExibeDados()

        Dim nota As Integer = 10


        'Form1.TextBox6.Text = TextBox12.Text


        'If TextBox13.Text = "HYPERCARD" And TextBox2.Text <> "carlos augusto de oliveira" Then
        'nota = nota - 5
        'Label17.Visible = True
        'Label17.Text = "Erro"
        'Label17.ForeColor = Color.Red

        'End If

        If TextBox2.Text = "Carlos Augusto De Oliveira" And TextBox13.Text <> "HYPERCARD" Then
            nota = nota - 5
            Label17.Visible = True
            Label17.Text = "Erro"
            Label17.ForeColor = Color.Red

        End If

        If TextBox2.Text = "Juscelino Neves Correia Da Costa" And TextBox13.Text <> "ITAÚ" Then
            nota = nota - 5
            Label17.Visible = True
            Label17.Text = "Erro"
            Label17.ForeColor = Color.Red

        End If

        'If TextBox13.Text = "ITAÚ" And TextBox2.Text <> "denise costa" Then
        'nota = nota - 5
        'Label17.Visible = True
        'Label17.Text = "Erro"
        'Label17.ForeColor = Color.Red
        'End If


        If TextBox2.Text = "Joseilton Maia" And TextBox13.Text <> "LOJAS AMERICANAS" Then
            nota = nota - 5
            Label17.Visible = True
            Label17.Text = "Erro"
            Label17.ForeColor = Color.Red

        End If

        'If TextBox13.Text = "LOJAS AMERICANAS" And TextBox2.Text <> "renan isac" Then
        'nota = nota - 5
        'Label17.Visible = True
        'Label17.Text = "Erro"
        'Label17.ForeColor = Color.Red
        'End If

        If TextBox2.Text = "Luan Keller Maia" And TextBox13.Text <> "CLARO" Then
            nota = nota - 5
            Label17.Visible = True
            Label17.Text = "Erro"
            Label17.ForeColor = Color.Red

        End If

        'If TextBox13.Text = "CLARO" And TextBox2.Text <> "marcia cavalcante" Then
        'nota = nota - 5
        'Label17.Visible = True
        'Label17.Text = "Erro"
        'Label17.ForeColor = Color.Red
        'End If



        If TextBox2.Text <> "Carlos Augusto De Oliveira" And TextBox2.Text <> "Juscelino Neves Correia Da Costa" And TextBox2.Text <> "Joseilton Maia" And TextBox2.Text <> "Luan Keller Matos" Then
            Label18.Visible = True
            Label18.Text = "Erro"
            Label18.ForeColor = Color.Red
            nota = nota - 3
        End If

        'USUARIO CARLOS AUGUSTO DE OLIVEIRA
        'If TextBox2.Text = "carlos augusto de oliveira" And TextBox2.Text = "Carlos Augusto de Oliveira" And TextBox2.Text = "CARLOS AUGUSTO DE OLIVEIRA" Then
        If TextBox3.Text <> "Rua Holanda 360 Parque Das Nações" And TextBox3.Text <> "Rua Saviniano Maia 20" And TextBox3.Text <> "Rua Bingen 1096 Bingen" And TextBox3.Text <> "Qe 20 Bloco J Guará I" Then
            Label19.Visible = True
            Label19.Text = "Erro"
            Label19.ForeColor = Color.Red
            nota = nota - 2
        End If

        If TextBox5.Text <> "(11)9982-21741" And TextBox5.Text <> "(83)9793-74718" And TextBox5.Text <> "(24)9995-43130" And TextBox5.Text <> "(61)9886-11177" Then
            Label24.Visible = True
            Label24.Text = "Erro"
            Label24.ForeColor = Color.Red
            nota = nota - 1
        End If

        If TextBox6.Text <> "carlos@zipmail.com" And TextBox6.Text <> "joseiltonpb@mail.net" And TextBox6.Text <> "kellerluan@net.com" And TextBox6.Text <> "jkneves@zip.net" Then
            Label20.Visible = True
            Label20.Text = "Erro"
            Label20.ForeColor = Color.Red
            nota = nota - 1
        End If

        If TextBox7.Text <> "Santo André" And TextBox7.Text <> "Guarabira" And TextBox7.Text <> "Petrópolis" And TextBox7.Text <> "Guará" And TextBox7.Text <> "Guara" And TextBox7.Text <> "Brasília" Then
            Label21.Visible = True
            Label21.Text = "Erro"
            Label21.ForeColor = Color.Red
            nota = nota - 2
        End If

        If TextBox8.Text <> "São Paulo" And TextBox8.Text <> "Paraíba" And TextBox8.Text <> "Rio de Janeiro" And TextBox8.Text <> "Distrito Federal" Then
            Label22.Visible = True
            Label22.Text = "Erro"
            Label22.ForeColor = Color.Red
            nota = nota - 2
        End If
        ' End If

        'MENSAGEM
        If TextBox11.Text.Length < 8 Then
            Label27.Visible = True
            Label27.Text = "Erro"
            Label27.ForeColor = Color.Red
            nota = nota - 1
        End If
        'CEP
        If TextBox4.Text <> "09,210-050" And TextBox4.Text <> "25,660-004" And TextBox4.Text <> "58,200-000" And TextBox4.Text <> "71,015-107" Then
            Label23.Visible = True
            Label23.Text = "Erro"
            Label23.ForeColor = Color.Red
            nota = nota - 1
        End If

        'CPF
        If TextBox9.Text <> "999,603317-30" And TextBox9.Text <> "075,259127-10" And TextBox9.Text <> "098,885818-40" And TextBox9.Text <> "009,187916-20" Then
            Label25.Visible = True
            Label25.Text = "Erro"
            Label25.ForeColor = Color.Red
            nota = nota - 1
        End If

        'RG
        If TextBox10.Text <> "10258220-" And TextBox10.Text <> "14576218-0" And TextBox10.Text <> "20216216-0" And TextBox10.Text <> "09982249-8" Then
            Label26.Visible = True
            Label26.Text = "Erro"
            Label26.ForeColor = Color.Red
            nota = nota - 1
        End If












        If nota < 0 Then
            nota = 0

        End If


        Label13.Text = CType(nota, String)

        Label1.ForeColor = Color.DarkBlue
        Label1.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Regular)







        'Me.Label1.Text = nota.Label1.Text=

    End Sub

    Private Sub ExibeDados()

        Try
            TextBox1.Text = ds.Tables(0).Rows(i)("data").ToString()
            TextBox13.Text = ds.Tables(0).Rows(i)("bandeira").ToString()
            TextBox2.Text = ds.Tables(0).Rows(i)("nome").ToString()
            TextBox3.Text = ds.Tables(0).Rows(i)("endereco").ToString()
            TextBox4.Text = ds.Tables(0).Rows(i)("cep").ToString()
            TextBox5.Text = ds.Tables(0).Rows(i)("telefone").ToString()
            TextBox6.Text = ds.Tables(0).Rows(i)("email").ToString()
            TextBox7.Text = ds.Tables(0).Rows(i)("cidade").ToString()
            TextBox8.Text = ds.Tables(0).Rows(i)("estado").ToString()
            TextBox9.Text = ds.Tables(0).Rows(i)("cpf").ToString()
            TextBox10.Text = ds.Tables(0).Rows(i)("rg").ToString()
            TextBox11.Text = ds.Tables(0).Rows(i)("mensagem").ToString()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If ds.Tables(0).Rows.Count > 0 Then
                i = 0
                Call ExibeDados()

            End If
        Catch ex As Exception
            MessageBox.Show("Não há mais registros!" + ex.Message)
        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            If i = ds.Tables(0).Rows.Count - 1 OrElse 1 <> 0 Then
                i -= 1
                Call ExibeDados()

            End If
        Catch ex As Exception
            MessageBox.Show("Não há mais registros!" + ex.Message)
        End Try

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Try
            If i < ds.Tables(0).Rows.Count - 1 Then
                i += 1
                Call ExibeDados()

            End If
        Catch ex As Exception
            MessageBox.Show("Não há mais registros!" + ex.Message)
        End Try

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            If ds.Tables(0).Rows.Count > 0 Then
                i = ds.Tables(0).Rows.Count - 1
            End If
        Catch ex As Exception
            MessageBox.Show("Não há mais registros!" + ex.Message)
        End Try

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim exclui As String

        Dim conexao As New OleDb.OleDbConnection
        'Dim usuario As String
        Try
            Dim conecta As String = "Provider=Microsoft.JET.OLEDB.4.0; Data Source=" & Application.StartupPath & "\TeleComuniQ.mdb"

            conexao.ConnectionString = conecta
            exclui = "DELETE FROM dados WHERE aluno LIKE '%" & TextBox12.Text & "%' "
            Dim comando As New OleDb.OleDbCommand(exclui, conexao)

            conexao.Open()
            'usuario = comando.ExecuteScalar()
            comando.ExecuteNonQuery()

            conexao.Close()

            'If usuario > "" Then
            MsgBox("Registros excluídos com sucesso!")

            TextBox1.Text = ""
            TextBox13.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            TextBox7.Text = ""
            TextBox8.Text = ""
            TextBox9.Text = ""
            TextBox10.Text = ""
            TextBox11.Text = ""

            'Else

            'se estiver errado envio um messagem de erro ao usuario

            'MessageBox.Show("Usuario ou senha invalidos")

            'End If
        Catch ex As Exception
            MessageBox.Show("Não há registros para serem excluídos!" + ex.Message)

        End Try
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Me.Close()
        Form1.Show()
        Form1.Label1.Text = TextBox12.Text

    End Sub


End Class