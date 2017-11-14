Imports System.Text
Imports System.Text.RegularExpressions

Public Class Validar
    Public Shared Function IsValidEmail(ByVal email As String) As Boolean
        Dim padraoRegex As String = "^[-a-zA-Z0-9][-.a-zA-Z0-9]*@[-.a-zA-Z0-9]+(\.[-.a-zA-Z0-9]+)*\." & _
        "(com|edu|info|gov|int|mil|net|org|biz|name|museum|coop|aero|pro|tv|[a-zA-Z]{2})$"
        Dim verifica As New RegularExpressions.Regex(padraoRegex, RegexOptions.IgnorePatternWhitespace)
        Dim valida As Boolean = False
        'verifica se foi informado um email
        If String.IsNullOrEmpty(email) Then
            valida = False
        Else
            'usar IsMatch para validar o email
            valida = verifica.IsMatch(email)
        End If
        'retorna o valor
        Return valida
    End Function



    Public Shared Function ValidarCpf(ByVal cpf As String) As Boolean
        cpf = cpf.Replace("-", "")
        cpf = cpf.Replace(".", "")

        Dim reg As New Regex("(^(\d{3}.\d{3}.\d{3}-\d{2})|(\d{11})$)")
        If Not reg.IsMatch(cpf) Then
            Return False
        End If

        Dim d1 As Integer, d2 As Integer
        Dim soma As Integer = 0
        Dim digitado As String = ""
        Dim calculado As String = ""

        ' Pesos para calcular o primeiro digito
        Dim peso1 As Integer() = New Integer() {10, 9, 8, 7, 6, 5, 4, 3, 2}

        ' Pesos para calcular o segundo digito
        Dim peso2 As Integer() = New Integer() {11, 10, 9, 8, 7, 6, 5, 4, 3, 2}

        Dim n As Integer() = New Integer(10) {}

        Dim retorno As Boolean = False

        ' Limpa a string
        cpf = cpf.Replace(".", "").Replace("-", "").Replace("/", "").Replace("\", "")

        ' Se o tamanho for < 11 entao retorna como inválido
        If cpf.Length <> 11 Then
            Return False
        End If

        ' Caso coloque todos os numeros iguais
        Select Case cpf

            Case "11111111111"
                Return False
            Case "00000000000"
                Return False
            Case "2222222222"
                Return False
            Case "33333333333"
                Return False
            Case "44444444444"
                Return False
            Case "55555555555"
                Return False
            Case "66666666666"
                Return False
            Case "77777777777"
                Return False
            Case "88888888888"
                Return False
            Case "99999999999"
                Return False
        End Select

        Try
            ' Quebra cada digito do CPF
            n(0) = Convert.ToInt32(cpf.Substring(0, 1))
            n(1) = Convert.ToInt32(cpf.Substring(1, 1))
            n(2) = Convert.ToInt32(cpf.Substring(2, 1))
            n(3) = Convert.ToInt32(cpf.Substring(3, 1))
            n(4) = Convert.ToInt32(cpf.Substring(4, 1))
            n(5) = Convert.ToInt32(cpf.Substring(5, 1))
            n(6) = Convert.ToInt32(cpf.Substring(6, 1))
            n(7) = Convert.ToInt32(cpf.Substring(7, 1))
            n(8) = Convert.ToInt32(cpf.Substring(8, 1))
            n(9) = Convert.ToInt32(cpf.Substring(9, 1))
            n(10) = Convert.ToInt32(cpf.Substring(10, 1))
        Catch
            Return False
        End Try

        ' Calcula cada digito com seu respectivo peso
        For i As Integer = 0 To peso1.GetUpperBound(0)
            soma += (peso1(i) * Convert.ToInt32(n(i)))
        Next

        ' Pega o resto da divisao
        Dim resto As Integer = soma Mod 11

        If resto = 1 OrElse resto = 0 Then
            d1 = 0
        Else
            d1 = 11 - resto
        End If

        soma = 0

        ' Calcula cada digito com seu respectivo peso
        For i As Integer = 0 To peso2.GetUpperBound(0)
            soma += (peso2(i) * Convert.ToInt32(n(i)))
        Next

        ' Pega o resto da divisao
        resto = soma Mod 11

        If resto = 1 OrElse resto = 0 Then
            d2 = 0
        Else
            d2 = 11 - resto
        End If

        calculado = d1.ToString() + d2.ToString()
        digitado = n(9).ToString() + n(10).ToString()

        ' Se os ultimos dois digitos calculados bater com
        ' os dois ultimos digitos do cpf entao é válido
        If calculado = digitado Then
            retorno = True
        Else
            retorno = False
        End If

        Return retorno
    End Function

End Class
