Imports System.IO
Imports System.ComponentModel
Imports System.Media
Imports System.Windows.Media
Imports System.Drawing.Color
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Data.OleDb




Public Class Form1
    Public Sub obtemAudio(ByVal diretorioRaiz As String, ByRef arrListaArquivos As ArrayList)
        If My.Computer.FileSystem.GetDirectoryInfo(diretorioRaiz).Name = "System Volume Information" Then
            Return
        End If

        Try
            For Each recursiveDir As String In My.Computer.FileSystem.GetDirectories(diretorioRaiz)
                Call obtemAudio(recursiveDir, arrListaArquivos)

            Next

            Dim arquivos = From file In My.Computer.FileSystem.GetFiles(diretorioRaiz, FileIO.SearchOption.SearchTopLevelOnly) Order By file Select My.Computer.FileSystem.GetFileInfo(file)

            arrListaArquivos.AddRange(arquivos.ToList)


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub formataGridView()
        With DataGridView1
            .AutoGenerateColumns = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
            .RowsDefaultCellStyle.BackColor = System.Drawing.Color.Aqua
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Aquamarine
            .Columns(0).HeaderText = "Nome do arquivo"
            '.Columns(1).HeaderText = "Tamanho"
            .Columns(0).Width = 500
            '.Columns(1).Width = 100
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = True
            .DefaultCellStyle.NullValue = "-"
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            '.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        End With
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Timer1.Interval = 100
            Timer1.Start()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
        Static posicao As Integer = 0
        Dim tempo As Integer

        If posicao < DataGridView1.SelectedRows.Count Then
            Dim tocar As Integer = DataGridView1.SelectedRows.Count - 1 - posicao
            Dim nomeMusica As String = CStr(DataGridView1.SelectedRows(tocar).Cells(0).Value())
            tempo = PlayMedia(nomeMusica)
            posicao += 1
            'Timer1.Interval = tempo
            Timer1.Start()

            'My.Computer.Audio.Play(nomeMusica, AudioPlayMode.Background)


        End If
    End Sub


    


    Private Function PlayMedia(ByVal titulo As String) As Integer
        Try
            Dim media_player As New MediaPlayer
            media_player.Open(New System.Uri(titulo))
            System.Threading.Thread.Sleep(3000) ' dá tempo de carregar a mídia
            Dim duration = media_player.NaturalDuration.TimeSpan
            Dim time As Integer
            time = CInt(duration.TotalMilliseconds)
            media_player.Play()
            Return True
            media_player.Close()
        Catch ex As Exception
            Throw ex

        End Try
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

  
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TeleComuniQDataSet1.audio' table. You can move, or remove it, as needed.
        Me.AudioTableAdapter.Fill(Me.TeleComuniQDataSet1.audio)
        'TODO: This line of code loads data into the 'TeleComuniQDataSet.audio' table. You can move, or remove it, as needed.
        TextBox1.Focus()

        ComboBox1.SelectedIndex = 24

        ComboBox2.SelectedIndex = 0

        formataGridView()

        Dim nomeAlunoMaiusc As String
        Dim nomeAluno As String = Label1.Text
        nomeAlunoMaiusc = UCase(nomeAluno)
        Label1.Text = nomeAlunoMaiusc

        Label13.Text = CDate(Now).ToString("dd/MM/yyyy")

        AudioTableAdapter.Fill(TeleComuniQDataSet1.audio)

        DataGridView1.Refresh()

        If Timer2.Enabled = False Then
            TextBox1.Enabled = False
            TextBox2.Enabled = False
            MaskedTextBox4.Enabled = False
            MaskedTextBox1.Enabled = False
            TextBox4.Enabled = False
            TextBox5.Enabled = False
            ComboBox1.Enabled = False
            MaskedTextBox2.Enabled = False
            MaskedTextBox3.Enabled = False
            TextBox3.Enabled = False
       
        End If

        'Timer2.Enabled = True


    End Sub

    Private Sub FillToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.AudioTableAdapter.Fill(Me.TeleComuniQDataSet1.audio)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub



   

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click


        Button9.Enabled = True


        My.Computer.Audio.Stop()


        



        'If Validar.ValidarCpf(MaskedTextBox2.Text) Then
        'MessageBox.Show("Email valido...", "VÁLIDO", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Else
        'MessageBox.Show("CPF inválido!", "INVÁLIDO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End If


        Dim insere As String
        Dim conexao As New OleDb.OleDbConnection
        Dim conecta As String = "Provider=Microsoft.JET.OLEDB.4.0; Data Source=" & Application.StartupPath & "\TeleComuniQ.mdb"

        conexao.ConnectionString = conecta
        insere = "INSERT INTO dados(aluno, data, bandeira, nome, endereco, cep, telefone, email, cidade, estado, cpf, rg, mensagem) VALUES('" & TextBox6.Text & "','" & Label13.Text & "','" & ComboBox2.Text & "','" & TextBox1.Text & "','" & TextBox2.Text & "','" & MaskedTextBox4.Text & "','" & MaskedTextBox1.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & ComboBox1.Text & "','" & MaskedTextBox2.Text & "','" & MaskedTextBox3.Text & "','" & TextBox3.Text & "')"
        Dim comando As New OleDb.OleDbCommand(insere, conexao)

        comando.Parameters.Add(New OleDb.OleDbParameter("@aluno", Label1.Text))
        comando.Parameters.Add(New OleDb.OleDbParameter("@data", Label13.Text))
        comando.Parameters.Add(New OleDb.OleDbParameter("@bandeira", ComboBox2.Text))
        comando.Parameters.Add(New OleDb.OleDbParameter("@nome", TextBox1.Text))
        comando.Parameters.Add(New OleDb.OleDbParameter("@endereco", TextBox2.Text))
        comando.Parameters.Add(New OleDb.OleDbParameter("@cep", MaskedTextBox4.Text))
        comando.Parameters.Add(New OleDb.OleDbParameter("@telefone", MaskedTextBox1.Text))
        comando.Parameters.Add(New OleDb.OleDbParameter("@email", TextBox4.Text))
        comando.Parameters.Add(New OleDb.OleDbParameter("@cidade", TextBox5.Text))
        comando.Parameters.Add(New OleDb.OleDbParameter("@estado", ComboBox1.Text))
        comando.Parameters.Add(New OleDb.OleDbParameter("@cpf", MaskedTextBox2.Text))
        comando.Parameters.Add(New OleDb.OleDbParameter("@rg", MaskedTextBox3.Text))
        comando.Parameters.Add(New OleDb.OleDbParameter("@mensagem", TextBox3.Text))

        conexao.Open()
        comando.ExecuteNonQuery()
        MsgBox("Dados enviados, veja sua nota clicando no botão Verificar Nota.", MessageBoxIcon.Information)




        TextBox1.Text = ""
        TextBox2.Text = ""
        MaskedTextBox4.Text = ""
        MaskedTextBox1.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        MaskedTextBox2.Text = ""
        MaskedTextBox3.Text = ""
        TextBox3.Text = ""


        

    End Sub

   
    Private Sub FillByToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.AudioTableAdapter.FillBy(Me.TeleComuniQDataSet1.audio)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub FillByToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.AudioTableAdapter.FillBy(Me.TeleComuniQDataSet1.audio)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        'Timer1.Stop()
        My.Computer.Audio.Stop()


        Timer2.Enabled = False

        TextBox1.Enabled = False
        TextBox2.Enabled = False
        MaskedTextBox4.Enabled = False
        MaskedTextBox1.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        ComboBox1.Enabled = False
        MaskedTextBox2.Enabled = False
        MaskedTextBox3.Enabled = False
        TextBox3.Enabled = False

    End Sub



    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        'Dim path As String = "B:\PROJETOS\SISTEMAS\VB.NET\TeleComuniQ\TeleComuniQ\chamadas\Audio_Hypercard.wav"

        'path = Application.StartupPath & path


        'Dim cnt As String = Application.StartupPath & "B:\PROJETOS\SISTEMAS\VB.NET\TeleComuniQ\TeleComuniQ\chamadas\Audio_Hypercard.wav"
        'My.Application.Info.DirectoryPath &

        My.Computer.Audio.Play(Application.StartupPath & "\chamadas\Audio_Hypercard.wav", AudioPlayMode.Background)
        




        DataGridView1.Rows(DataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Visible)).Cells(0).Selected = True
        DataGridView1.Rows(1).Cells(0).Selected = False
        DataGridView1.Rows(2).Cells(0).Selected = False
        DataGridView1.Rows(3).Cells(0).Selected = False

        'HABILITA O TEMPORIZADOR 2 QUE HABILITARÁ O TEMPORIZADOR 3 E DESABILITARÁ AS TEXTBOXES NOVAMENTE EM TORNO DE 3:20MIN

        Timer2.Enabled = True


        'HABILITA AS TEXTBOXES DESABILITADAS NO CARREGAMENTO DA PÁGINA

        TextBox1.Enabled = True
        TextBox2.Enabled = True
        MaskedTextBox4.Enabled = True
        MaskedTextBox1.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        ComboBox1.Enabled = True
        MaskedTextBox2.Enabled = True
        MaskedTextBox3.Enabled = True
        TextBox3.Enabled = True


        


    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        'My.Computer.Audio.Play("C:\Users\Clovis Jr\Documents\Visual Studio 2010\Projects\TeleComuniQ\Audio\a_ha_Never_Never.wav", AudioPlayMode.Background)
        My.Computer.Audio.Play(Application.StartupPath & "\chamadas\Audio_Itau.wav", AudioPlayMode.Background)
        'My.Computer.Audio.Play("..\chamadas\DC_Talk_Jesus_Freak.wav", AudioPlayMode.Background)



        DataGridView1.Rows(1).Cells(0).Selected = True

        DataGridView1.Rows(2).Cells(0).Selected = False
        DataGridView1.Rows(3).Cells(0).Selected = False
        DataGridView1.Rows(DataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Visible)).Cells(0).Selected = False

        Timer2.Enabled = True




        TextBox1.Enabled = True
        TextBox2.Enabled = True
        MaskedTextBox4.Enabled = True
        MaskedTextBox1.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        ComboBox1.Enabled = True
        MaskedTextBox2.Enabled = True
        MaskedTextBox3.Enabled = True
        TextBox3.Enabled = True

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        'My.Computer.Audio.Play("C:\Users\Clovis Jr\Documents\Visual Studio 2010\Projects\TeleComuniQ\Audio\a_ha_Never_Never.wav", AudioPlayMode.Background)
        My.Computer.Audio.Play(Application.StartupPath & "\chamadas\Audio_Americanas.wav", AudioPlayMode.Background)

        DataGridView1.Rows(2).Cells(0).Selected = True

        DataGridView1.Rows(1).Cells(0).Selected = False

        DataGridView1.Rows(3).Cells(0).Selected = False
        DataGridView1.Rows(DataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Visible)).Cells(0).Selected = False


        Timer2.Enabled = True




        TextBox1.Enabled = True
        TextBox2.Enabled = True
        MaskedTextBox4.Enabled = True
        MaskedTextBox1.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        ComboBox1.Enabled = True
        MaskedTextBox2.Enabled = True
        MaskedTextBox3.Enabled = True
        TextBox3.Enabled = True
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        'My.Computer.Audio.Play("C:\Users\Clovis Jr\Documents\Visual Studio 2010\Projects\TeleComuniQ\Audio\a_ha_Never_Never.wav", AudioPlayMode.Background)
        My.Computer.Audio.Play(Application.StartupPath & "\chamadas\Audio_Claro.wav", AudioPlayMode.Background)

        DataGridView1.Rows(3).Cells(0).Selected = True

        DataGridView1.Rows(1).Cells(0).Selected = False
        DataGridView1.Rows(2).Cells(0).Selected = False

        DataGridView1.Rows(DataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Visible)).Cells(0).Selected = False

        Timer2.Enabled = True




        TextBox1.Enabled = True
        TextBox2.Enabled = True
        MaskedTextBox4.Enabled = True
        MaskedTextBox1.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        ComboBox1.Enabled = True
        MaskedTextBox2.Enabled = True
        MaskedTextBox3.Enabled = True
        TextBox3.Enabled = True
    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        nota.Show()
        nota.TextBox12.Text = Me.TextBox6.Text
        Me.Close()



        'nota.Label1.BackColor = Color.DarkBlue
        'nota.Label1.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Regular)
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick

        'ATIVA O TEMPORIZADOR TIMER 3 QUE AO FINAL FECHARA AS TEXTBOXES

        Timer3.Enabled = True



    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        'My.Computer.Audio.Stop()

        'DISPARA O TEMPÓRIZADOR POR 3:20MIN E QUANDO TERMINA EXECUTA A DESABILITAÇÃO DOS TEXTBOXES

        TextBox1.Enabled = False
        TextBox2.Enabled = False
        MaskedTextBox4.Enabled = False
        MaskedTextBox1.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        ComboBox1.Enabled = False
        MaskedTextBox2.Enabled = False
        MaskedTextBox3.Enabled = False
        TextBox3.Enabled = False

        MsgBox("Atendimento finalizado, clique no botão Gravar Registro.", MessageBoxIcon.Information)

    End Sub

    'QUANDO O CAMPO EMAIL PERDE O FOCO DISPARA A MESNAGEM SE O EMAIL NÃO FOR VÁLIDO
    Private Sub TextBox4_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.Leave
        If Validar.IsValidEmail(TextBox4.Text) Then
            'MessageBox.Show("Email valido...", "VÁLIDO", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Email inválido!", "INVÁLIDO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub TextBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.Leave

        TextBox1.Text = StrConv(TextBox1.Text, vbProperCase)
        'MessageBox.Show("Evite colocar letras maiúsculas!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub TextBox2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.Leave
        TextBox2.Text = StrConv(TextBox2.Text, vbProperCase)
    End Sub

    Private Sub TextBox5_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.Leave
        TextBox5.Text = StrConv(TextBox5.Text, vbProperCase)
    End Sub

    Private Sub Form1_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        'Me.Dispose()
        End

    End Sub
End Class
