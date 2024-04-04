Imports System.Globalization
Imports System.IO
Imports System.IO.Compression
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports ICSharpCode.SharpZipLib.Zip
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Imports ICSharpCode.SharpZipLib.BZip2
Imports ICSharpCode.SharpZipLib.Tar


Public Class Main
    Dim AllCards As String
    ReadOnly cards = Split(AllCards, vbCrLf)

    Sub zipdecks(formato)

        Dim OriginFolder = Directory.GetCurrentDirectory & "\Forge Tournaments Decks"
        Dim DestinyFolder = Directory.GetCurrentDirectory & "\Forge Tournaments Decks Zipped"
        If Not Directory.Exists(OriginFolder) Then
            MsgBox("Can't find json Tournaments Folder!")
            Exit Sub
        End If

        If Not Directory.Exists(DestinyFolder) Then
            Directory.CreateDirectory(DestinyFolder)
        End If

        For Each d In Directory.GetDirectories(OriginFolder & "\" & formato)

            Dim DirName = New DirectoryInfo(d).Name
            Dim fn = DestinyFolder & "\" & DirName

            Dim GetMonths() =
                    Directory.GetDirectories(OriginFolder & "\" & formato & "\" & DirName)

            For Each mymonth In GetMonths
                Dim DirName2 = New DirectoryInfo(mymonth).Name
                Dim fm = fn & "\" & DirName2

                Dim GetDays() = Directory.GetDirectories(mymonth)
                If Not Directory.Exists("Forge Tournaments Decks Zipped\" & formato) Then
                    Directory.CreateDirectory("Forge Tournaments Decks Zipped\" & formato)
                End If

                For Each MyDays In GetDays

                    Dim MyZipName
                    Dim GetFolders() = Directory.GetDirectories(MyDays)
                    For Each myFolder In GetFolders
                        MyZipName = New DirectoryInfo(myFolder).Name
                        MyZipName = MyZipName & ".zip"



                        Dim DirName3 = New DirectoryInfo(MyDays).Name

                        DirName3 = DirName2 & "\" & DirName3
                        Dim dd = fn & "\" & DirName3
                        MyZipName = ReorganizarCadena(MyZipName)
                        MyZipName = Replace(MyZipName, "-.zip", ".zip")
                        If _
                            File.Exists(
                                "Forge Tournaments Decks Zipped\" & formato & "\" & MyZipName) =
                            False Then
                            compressDirectory(myFolder,
                                          Directory.GetCurrentDirectory() & "\Forge Tournaments Decks Zipped\" & formato & "\" &
                                          MyZipName, 9)
                            WriteUserLog("Zipping " & MyZipName & vbCrLf)
                        Else
                            WriteUserLog("Skipping " & MyZipName & vbCrLf)
                        End If
                    Next
                Next
            Next
        Next
        WriteUserLog("Done!")
    End Sub

    Function ReorganizarCadena(ByVal inputTexto As String) As String
        ' Verificar si el texto contiene "2023" o "2024"
        Dim año As String = ""
        If inputTexto.Contains("2023") Then
            año = "2023"
        ElseIf inputTexto.Contains("2024") Then
            año = "2024"
        Else
            ' Si no se encuentra ningún año en el texto, devolver el texto original
            Return inputTexto
        End If

        ' Eliminar la extensión ".zip"
        inputTexto = inputTexto.Replace(".zip", "")

        ' Dividir la cadena en dos partes basadas en el año identificado
        Dim partes As String() = inputTexto.Split(New String() {año}, StringSplitOptions.None)

        ' Verificar si la cadena se pudo dividir en dos partes
        If partes.Length >= 2 Then
            Dim x As String = partes(0)
            Dim y As String = partes(1)

            ' Reorganizar las partes en un nuevo formato
            Dim r As String = año & y & "-" & x

            ' Eliminar posibles duplicaciones de guiones
            r = r.Replace("--", "-")

            ' Volver a agregar la extensión ".zip"
            r &= ".zip"

            ' Eliminar un guion adicional seguido de ".zip"
            r = r.Replace("-.zip", ".zip")

            ' Devolver el resultado final
            Return r
        Else
            ' Si no se pudo dividir en dos partes, devolver la cadena original
            Return inputTexto & ".zip"
        End If
    End Function

    Function RenameFolder(formato)
        Dim DestinyFolder = Directory.GetCurrentDirectory & "\Tournaments\" & cmbcategories.SelectedItem.ToString
        Dim OriginFolder = Directory.GetCurrentDirectory & "\Forge Tournaments Decks"
        If Not Directory.Exists(OriginFolder) Then
            MsgBox("Can't find json Tournaments Folder!")
            Exit Function
        End If

        If Not Directory.Exists(DestinyFolder) Then
            Directory.CreateDirectory(DestinyFolder)
        End If

        For Each d In Directory.GetDirectories(OriginFolder)

            Dim DirName = New DirectoryInfo(d).Name
            Dim fn = DestinyFolder & "\" & DirName

            Dim GetMonths() = Directory.GetDirectories(OriginFolder & "\" & DirName)
            If DirName <> "Block" And DirName <> "Draft" Then
                'If DirName.Contains(cmbyear.SelectedValue.ToString) Then
                ''aqui iba todo el for de abajo
                'continuar = True
                '******
                For Each mymonth In GetMonths
                    Dim DirName2 = New DirectoryInfo(mymonth).Name
                    Dim fm = fn & "\" & DirName2

                    Dim GetDays() = Directory.GetDirectories(mymonth)

                    If DirName2.Contains(cmbyear.SelectedValue.ToString) Then

                        For Each MyDays In GetDays
                            Dim DirName3 = New DirectoryInfo(MyDays).Name
                            'MsgBox(MyDays)
                            Dim GetTournaments() = Directory.GetDirectories(MyDays)
                            For Each ournament In GetTournaments
                                'MsgBox(ournament)

                                'prueba de renombrar
                                Dim partido = ournament
                                If partido.Contains("-") Then
                                    partido = Split(ournament, "-" & cmbyear.SelectedValue.ToString & "-")(1)
                                End If

                                partido = partido
                                If Len(partido) > 8 And partido.Contains("-") Then
                                    Dim partes = Split(partido, "-")(1)
                                    Dim newname
                                    If partes.Contains("-") = False Then
                                        newname = Replace(partido, "-" & partes.Substring(0, 2), "-" & partes.Substring(0, 2) & "-")
                                        partes = partes.Substring(0, 2)
                                        Dim total = ournament
                                        newname = newname
                                        Dim nuevodir = Replace(ournament, partido, newname)
                                        Dim oldDirectoryPathandName = ournament

                                        nuevodir = Replace(nuevodir, "---", "-")
                                        nuevodir = Replace(nuevodir, "--", "-")
                                        nuevodir = Replace(nuevodir, "---------", "-")
                                        nuevodir = Replace(nuevodir, "--------", "-")
                                        nuevodir = Replace(nuevodir, "---", "-")
                                        nuevodir = Replace(nuevodir, "--", "-")
                                        nuevodir = Replace(nuevodir, "--", "-")
                                        nuevodir = Replace(nuevodir, "--", "-")
                                        nuevodir = Replace(nuevodir, "--", "-")
                                        nuevodir = Replace(nuevodir, "-------", "-")
                                        nuevodir = Replace(nuevodir, "---", "-")
                                        nuevodir = Replace(nuevodir, "--", "-")
                                        Dim newDirectoryName = nuevodir
                                        'try
                                        'FileIO.FileSystem.RenameDirectory(oldDirectoryPathandName, newDirectoryName)
                                        If oldDirectoryPathandName <> newDirectoryName Then
                                            If System.IO.Directory.Exists(newDirectoryName) Then
                                                System.IO.Directory.Delete(newDirectoryName, True)
                                            End If
                                            Try
                                                FileSystem.Rename(oldDirectoryPathandName, newDirectoryName)
                                            Catch
                                            End Try

                                        End If

                                        '            catch
                                        'End try
                                    End If

                                End If

                            Next

                        Next
                    End If
                    log.Text = ""
                Next
                log.Text = ""

                'End If
            End If

        Next
        WriteUserLog("Done rewrite!")
        '*************************************
        'Next

    End Function

    Function ConvertJsonFilestoDck(formato)
        Dim OriginFolder As String
        Try
            OriginFolder = Path.Combine(Directory.GetCurrentDirectory(), "Tournaments", cmbcategories.SelectedItem.ToString())
        Catch
            MsgBox("Select category")
            Exit Function
        End Try

        Dim DestinyFolder As String = Path.Combine(Directory.GetCurrentDirectory(), "Forge Tournaments Decks")
        If Not Directory.Exists(OriginFolder) Then
            MsgBox("Can't find json Tournaments Folder!")
            Exit Function
        End If

        If Not Directory.Exists(DestinyFolder) Then
            Directory.CreateDirectory(DestinyFolder)
        End If

        For Each yearFolder In Directory.GetDirectories(OriginFolder)
            Dim year = New DirectoryInfo(yearFolder).Name

            If year.Contains(cmbyear.SelectedValue.ToString) Then
                For Each monthFolder In Directory.GetDirectories(yearFolder)
                    Dim month = New DirectoryInfo(monthFolder).Name
                    ''FUERZO AL MES
                    'If month.Contains(cmbmonth.SelectedItem.ToString) Then
                    For Each dayFolder In Directory.GetDirectories(monthFolder)
                        Dim day = New DirectoryInfo(dayFolder).Name
                        Dim tournamentDate = New DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day))

                        For Each jsonFilePath In Directory.GetFiles(dayFolder, "*" & formato & "*.json")
                            Dim jsonContent = File.ReadAllText(jsonFilePath)
                            Dim jsonResult As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(jsonContent)
                            Dim tournamentName As String = Path.GetFileNameWithoutExtension(jsonFilePath)
                            tournamentName = RemoveInvalidFileNameChars(tournamentName)

                            Dim tournamentFolderPath = Path.Combine(DestinyFolder, $"{formato}\{year}\{month}\{day}\{tournamentName}")
                            tournamentFolderPath = ModificarNombreCarpeta(tournamentFolderPath)
                            If Not Directory.Exists(tournamentFolderPath) Then
                                Directory.CreateDirectory(tournamentFolderPath)
                            ElseIf Not chkoverwrite.Checked Then
                                Continue For
                            End If

                            Dim deckCount As Integer = 1

                            For Each deckInfo As JObject In jsonResult("Decks")
                                Dim player = deckInfo("Player").ToString()
                                Dim result = deckInfo("Result").ToString()
                                Dim deckName = $"{deckCount:00} {player} {result}"
                                deckName = RemoveInvalidFileNameChars(deckName)

                                Dim deckFilePath = Path.Combine(tournamentFolderPath, $"{deckName}.dck")

                                If Not File.Exists(deckFilePath) OrElse chkoverwrite.Checked Then
                                    Dim mainboard = GetCardList(deckInfo("Mainboard"))
                                    Dim sideboard = GetCardList(deckInfo("Sideboard"))

                                    Dim deckContent As String = $"[metadata]{Environment.NewLine}Name={deckName}{Environment.NewLine}[Main]{Environment.NewLine}{mainboard}{Environment.NewLine}[sideboard]{Environment.NewLine}{sideboard}"

                                    If validatecards(deckContent, deckName) = "" Then

                                        File.WriteAllText(deckFilePath, deckContent)
                                        WriteUserLog($"Saved: {deckFilePath}{Environment.NewLine}")

                                    Else

                                        Exit Function
                                    End If

                                Else
                                        WriteUserLog($"Exists: {deckFilePath}{Environment.NewLine}")
                                End If

                                deckCount += 1
                            Next

                            deckCount = 1
                        Next
                    Next
                    'End If

                Next
            End If
        Next

        WriteUserLog("Done!")
    End Function



    Function ModificarNombreCarpeta(ByVal rutaCarpeta As String) As String
        ' Utilizamos una expresión regular para buscar el último guión seguido de más de dos dígitos
        Dim regexPattern As String = "^(.*-)(\d{2,})$"
        Dim regex As New Regex(regexPattern)

        ' Comprobamos si la cadena coincide con el patrón
        Dim match As Match = regex.Match(rutaCarpeta)

        If match.Success Then
            ' Obtenemos la parte del nombre antes del guión y la parte de los últimos dos dígitos
            Dim parteNombre As String = match.Groups(1).Value
            Dim ultimosDigitos As String = match.Groups(2).Value

            ' Verificamos que haya más de dos dígitos después del último guión
            If ultimosDigitos.Length > 2 Then
                ' Renombramos la cadena con los dos últimos dígitos y un guión
                Dim nuevoNombre As String = $"{parteNombre}{ultimosDigitos.Substring(0, 2)}-{ultimosDigitos.Substring(2)}"

                ' Construimos la nueva ruta con el nombre modificado
                Dim nuevaRutaCarpeta As String = rutaCarpeta.Replace(match.Value, nuevoNombre)

                Return nuevaRutaCarpeta
            End If
        End If

        ' Devolvemos la ruta original si no se cumple el patrón o la condición de dígitos
        Return rutaCarpeta
    End Function

    Function EsNumerico(s As String) As Boolean
        ' Función para verificar si una cadena es numérica
        Dim result As Integer
        Return Integer.TryParse(s, result)
    End Function


    Function GetCardList(cards As JToken) As String
        Dim cardList As New StringBuilder()

        For Each cardInfo As JObject In cards
            Dim count = cardInfo("Count").ToString()
            Dim cardName = cardInfo("CardName").ToString()
            cardList.AppendLine($"{count} {cardName}")
        Next

        Return cardList.ToString()
    End Function


    Public Shared Function RemoveDiacritics(ByVal text As String) As String
        Dim normalizedString = text.Normalize(NormalizationForm.FormD)
        Dim stringBuilder = New StringBuilder()

        For Each c In normalizedString
            Dim unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c)

            If unicodeCategory <> UnicodeCategory.NonSpacingMark Then
                stringBuilder.Append(c)
            Else
                Dim exist = "exist"
            End If
        Next

        Return stringBuilder.ToString().Normalize(NormalizationForm.FormC)
    End Function

    Sub WriteUserLog(msg)
        log.SelectedText = msg
        log.SelectionStart = log.Text.Length
        log.ScrollToCaret()
    End Sub

    Public Shared Function ValidateCards(deckText As String, deckTitle As String) As String
        Try
            ' Read unsupported cards from file
            Dim unsupportedCards As New List(Of String)
            Using reader As New StreamReader("unsupportedcards.txt")
                Do While Not reader.EndOfStream
                    unsupportedCards.Add(reader.ReadLine())
                Loop
            End Using

            ' Extract cards from the deck
            Dim deckLines As String() = deckText.Split({"[Main]", "[sideboard]"}, StringSplitOptions.RemoveEmptyEntries)
            Dim deckCards As New List(Of String)(deckLines(1).Split({vbCrLf}, StringSplitOptions.RemoveEmptyEntries))

            ' Check for unsupported cards
            For Each deckCard In deckCards
                Dim cardName As String = deckCard.Split("|"c)(0).Trim()

                ' Remove card numbers
                For x = 1 To 20
                    cardName = cardName.Replace(x & " ", "")
                Next

                If unsupportedCards.Any(Function(unsupportedCard) String.Equals(cardName, unsupportedCard, StringComparison.OrdinalIgnoreCase)) Then
                    MsgBox("Forge unsupported card " & cardName & " in " & deckTitle & ". Deck not saved.{vbCrLf}")
                    Return "Forge unsupported card " & cardName & " in " & deckTitle & ". Deck not saved.{vbCrLf}"
                End If
            Next
        Catch ex As Exception
            ' Handle the exception appropriately (e.g., log or rethrow)
        End Try

        Return ""
    End Function


    Private Function RemoveInvalidFileNameChars(UserInput As String) As String
        For Each invalidChar In Path.GetInvalidFileNameChars
            UserInput = UserInput.Replace(invalidChar, "")
        Next
        Return UserInput
    End Function

    Sub creategauntlet(directorio, destinyfolder)

        Dim filePath As String = directorio
        Dim asplit As String() = filePath.Split("\")
        Dim parentFolder As String = asplit(asplit.Length - 1)

        Dim MyNamefinal = (parentFolder)
        MyNamefinal = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(MyNamefinal.ToLower)
        MyNamefinal = "LOCKED_" & (MyNamefinal)

        If File.Exists(destinyfolder & MyNamefinal & ".dat") Then
            Exit Sub
        End If
        MyNamefinal = ""
        parentFolder = ""
        filePath = ""

        WriteUserLog("reading " & directorio & vbCrLf)
        Dim x As String
        Dim megacounter = 0

        Dim list As New List(Of String)
        Dim valido = True
        For Each d In Directory.GetFiles(directorio, "*.dck")
            Dim MyName = Path.GetFileName(d).ToString
            Dim titie As String = My.Computer.FileSystem.ReadAllText(d)
            If validatecards(titie, MyName) = "" Then
                list.Add(MyName)
                titie = Nothing
            Else
                WriteUserLog(validatecards(titie, MyName))
            End If
        Next

        list.Reverse()

        x = "<forge.gauntlet.GauntletData>" & vbCrLf
        x = x & "<completed>0</completed>" & vbCrLf
        x = x & "<timestamp></timestamp>" & vbCrLf
        x = x & "<eventRecords>" & vbCrLf

        For mazo = 0 To list.Count - 1
            x = x & "<string></string>" & vbCrLf
        Next

        x = x & "</eventRecords>" & vbCrLf
        x = x & "<eventNames>" & vbCrLf

        For mazo = 0 To list.Count - 1
            x = x & " <string>" & list(mazo) & "</string>" & vbCrLf
        Next

        x = x & " </eventNames>" & vbCrLf
        x = x & " <decks>" & vbCrLf

        Dim titdeck = ""

        Dim contador = 0
        For mazo = 0 To list.Count - 1

            Dim fifu As String
            Dim seguir = False
            fifu = My.Computer.FileSystem.ReadAllText(directorio & "\" & list(mazo))

            x = x & "<forge.deck.Deck>" & vbCrLf
            titdeck = Path.GetFileNameWithoutExtension(list(mazo)).ToString

            x = x & "<name>" & titdeck & "</name>" & vbCrLf
            x = x & "<parts class=""enum-map"" enum-type=""forge.deck.DeckSection"">" & vbCrLf
            x = x & "<entry>" & vbCrLf
            x = x & "<forge.deck.DeckSection>Main</forge.deck.DeckSection>" & vbCrLf
            x = x & "<forge.deck.CardPool>" & vbCrLf
            Dim pack As String = fifu
            fifu = Split(fifu, "[Main]")(1).ToString
            fifu = Split(fifu, "[Sideboard]")(0).ToString
            fifu = Split(fifu, "[sideboard]")(0).ToString
            Try
                pack = Split(pack, "[Sideboard]")(1).ToString
            Catch
            End Try
            Try
                pack = Split(pack, "[sideboard]")(1).ToString
            Catch
            End Try

            pack = pack
            fifu = Replace(fifu, vbCr & vbCrLf, Nothing)
            fifu = Replace(fifu, vbCr, Nothing)
            fifu = Replace(fifu, vbLf, vbCrLf)

            pack = Replace(pack, vbCr & vbCrLf, Nothing)
            pack = Replace(pack, vbCr, Nothing)
            pack = Replace(pack, vbLf, vbCrLf)

            Dim fifi = Split(fifu, vbCrLf)

            For b = 0 To fifi.Length - 1
                If fifi(b).ToString <> "" Then
                    x = x & anadircarta(fifi(b).ToString, list(mazo).ToString)
                End If
            Next b

            x = x & "</forge.deck.CardPool>" & vbCrLf
            x = x & "</entry>" & vbCrLf

            fifi = Split(pack, vbCrLf)

            If fifi.Length > 1 Then

                x = x & "<entry>" & vbCrLf
                x = x & "<forge.deck.DeckSection>Sideboard</forge.deck.DeckSection>" & vbCrLf
                x = x & "<forge.deck.CardPool>" & vbCrLf

                For b = 0 To fifi.Length - 1
                    If fifi(b).ToString <> "" Then
                        x = x & anadircarta(fifi(b).ToString, list(mazo).ToString)
                    End If
                Next b

                x = x & "</forge.deck.CardPool>" & vbCrLf
                x = x & "</entry>" & vbCrLf

            End If
            x = x & "</parts>" & vbCrLf
            x = x & "<tags Class=""sorted-set"">" & vbCrLf
            x = x & "<comparator class=""java.lang.String$CaseInsensitiveComparator""/>" & vbCrLf
            x = x & "</tags>" & vbCrLf
            x = x & "</forge.deck.Deck>" & vbCrLf

            fifu = Nothing
            WriteUserLog("Adding " & list(megacounter) & vbCrLf)
            megacounter = megacounter + 1

        Next
        x = x & "</decks>" & vbCrLf
        x = x & "</forge.gauntlet.GauntletData>"
        Dim result = x

        filePath = directorio
        asplit = filePath.Split("\")
        parentFolder = asplit(asplit.Length - 1)

        MyNamefinal = (parentFolder)

        MyNamefinal = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(MyNamefinal.ToLower)
        MyNamefinal = "LOCKED_" & (MyNamefinal)

        If File.Exists(destinyfolder & MyNamefinal) Then File.Delete(destinyfolder & MyNamefinal)

        Using fs As FileStream = File.Create(destinyfolder & MyNamefinal)
            Dim info As Byte() = New UTF8Encoding(True).GetBytes(result)
            fs.Write(info, 0, info.Length)
        End Using

        CompressFile(destinyfolder & MyNamefinal, destinyfolder & MyNamefinal & ".gz")
        Dim MyNameini, MyNamefin As String
        MyNameini = destinyfolder & MyNamefinal & ".gz"
        MyNamefin = MyNamefinal & ".dat"
        Try
            My.Computer.FileSystem.RenameFile(MyNameini, MyNamefin)
        Catch e As Exception
            WriteUserLog(e.ToString)
        End Try
        My.Computer.FileSystem.DeleteFile(destinyfolder & MyNamefinal)
        log.Text = ""

        WriteUserLog("Saved " & destinyfolder & MyNamefinal & ".dat" & vbCrLf)
    End Sub

    Function anadircarta(carta, lista) 'esto solo se usa para los gauntlets
        Dim x = ""
        If carta <> "" Then
            carta = Replace(carta, "'", "&apos;")
            Dim numero = ""
            For wa = 1 To 100
                If InStr(carta, wa & " ") > 0 Then
                    numero = wa
                    carta = Replace(carta, wa & " ", "")
                    Exit For
                End If
            Next wa
            If Not IsNothing(carta) Then
                carta = RemoveDigits(carta)
                Dim edicion As String = searchforedition(carta, lista)
                If carta <> "" And edicion <> "" Then
                    x = x & "<card c=""" & carta & """ i="" 1"" s=""" & edicion & """ n=""" & Trim(numero) & """/>" &
                        vbCrLf
                Else
                    carta = carta
                    edicion = edicion
                End If
            End If
        End If
        Return x
    End Function

    Function RemoveDigits(S As String) As String
        Return Regex.Replace(S, "\d", "")
    End Function

    Function searchforedition2(carta, d)
        carta = RemoveDigits(carta)
        carta = Replace(carta, "&apos;", "'")

        If carta = "Forest" Or carta = "Island" Or carta = "Plains" Or carta = "Swamp" Or carta = "Mountain" Then
            Return "ZEN"
            Exit Function
        End If

        Dim SearchWithinThis As String = AllCards

        For d = 0 To cards.Length - 1

            If Split(cards(d), "|")(0).ToString = carta Then
                'la encuentra y toma su edición
                Dim rrr = Split(cards(d), "|")(1).ToString
                Return rrr
                Exit For
            End If
        Next d
    End Function

    Function searchforedition(carta, d)

        If InStr(carta, "tun Grunt") > 0 Then
            carta = ""
        End If

        carta = RemoveDigits(carta)
        carta = Replace(carta, "&apos;", "'")
        carta = Replace(carta, "ä", "a")
        carta = Replace(carta, "ë", "e")
        carta = Replace(carta, "ï", "i")
        carta = Replace(carta, "ö", "o")
        carta = Replace(carta, "ü", "u")

        If carta = "Forest" Or carta = "Island" Or carta = "Plains" Or carta = "Swamp" Or carta = "Mountain" Then
            Return "ZEN"
            Exit Function
        End If

        If carta = "Wastes" Then
            Return "OGW"
        End If
        Dim a
        Try
            a = Split(AllCards, vbCrLf & carta & "|")(1)
        Catch
            Return ""
        End Try

        a = Split(a, vbCrLf)(0)
        If InStr(a, "|") > 0 Then
            a = Split(a, "|")(0)
        End If

        If InStr(a, "|") > 0 Then
            a = Split(a, "|")(0)
        End If

        a = a
        Return a
        Exit Function

        Dim SearchWithinThis As String = AllCards

        For d = 0 To cards.Length - 1

            If Split(cards(d), "|")(0).ToString = carta Then
                'la encuentra y toma su edición
                Dim rrr = Split(cards(d), "|")(1).ToString
                Return rrr
                Exit For
            End If
        Next d
    End Function

    Public Shared Function FindIt(total As String, first As String, last As String) As String
        If last.Length < 1 Then
            FindIt = total.Substring(total.IndexOf(first))
        End If
        If first.Length < 1 Then
            FindIt = total.Substring(0, (total.IndexOf(last)))
        End If
        Try
            FindIt =
                ((total.Substring(total.IndexOf(first), (total.IndexOf(last) - total.IndexOf(first)))).Replace(first, "")) _
                    .Replace(last, "")
        Catch ArgumentOutOfRangeException As Exception
        End Try
    End Function

    Function getformat(f)
        Dim dir = ""
        If InStr(f, "standard") > 0 Then
            dir = "Standard"
        End If
        If InStr(f, "modern") > 0 Then
            dir = "Modern"
        End If

        If InStr(f, "commander") > 0 Then
            dir = "Commander"
        End If

        If InStr(f, "legacy") > 0 Then
            dir = "Legacy"
        End If

        If InStr(f, "vintage") > 0 Then
            dir = "Vintage"
        End If

        If InStr(f, "pauper") > 0 Then
            dir = "pauper"
        End If

        If InStr(f, "brawl") > 0 Then
            dir = "Brawl"
        End If

        If InStr(f, "sealed") > 0 Then
            dir = "Sealed"
        End If

        If InStr(f, "block") > 0 Then
            dir = "Block"
        End If

        If InStr(f, "pioneer") > 0 Then
            dir = "Pioneer"
        End If

        If InStr(f, "draft") > 0 Then
            dir = "Draft"
        End If
        Return dir
    End Function

    Public Shared Sub CompressFile(sourceFile As String, destFile As String,
                                   Optional ByVal tipo As String = "gz")

        Dim destStream As New FileStream(destFile, FileMode.Create, FileAccess.Write, FileShare.Read)
        Dim srcStream As New FileStream(sourceFile, FileMode.Open, FileAccess.Read, FileShare.Read)
        Dim gz As New GZipStream(destStream, CompressionMode.Compress)

        Dim bytesRead As Integer
        Dim buffer = New Byte(10000) {}

        bytesRead = srcStream.Read(buffer, 0, buffer.Length)

        While bytesRead <> 0
            gz.Write(buffer, 0, bytesRead)

            bytesRead = srcStream.Read(buffer, 0, buffer.Length)
        End While

        gz.Close()
        destStream.Close()
        srcStream.Close()
    End Sub

    Public Shared Sub DecompressFile(sourceFile As String, destFile As String)

        Dim destStream As New FileStream(destFile, FileMode.Create, FileAccess.Write, FileShare.Read)
        Dim srcStream As New FileStream(sourceFile, FileMode.Open, FileAccess.Read, FileShare.Read)
        Dim gz As New GZipStream(srcStream, CompressionMode.Decompress)

        Dim bytesRead As Integer
        Dim buffer = New Byte(10000) {}

        bytesRead = gz.Read(buffer, 0, buffer.Length)

        While bytesRead <> 0
            destStream.Write(buffer, 0, bytesRead)

            bytesRead = gz.Read(buffer, 0, buffer.Length)
        End While

        gz.Close()
        destStream.Close()
        srcStream.Close()
    End Sub

    Function ConvertDeckstoGauntlets()
        If cmbformat.SelectedValue = Nothing Then
            MsgBox("Select Format")
            Exit Function
        End If
        If cmbyear.SelectedValue = "all" Then
            MsgBox("You need to select year for this option")
            Exit Function
        End If

        Dim OriginFolder = Directory.GetCurrentDirectory & "\Forge Tournaments Decks\" &
                           cmbformat.SelectedValue.ToString & "\" & cmbyear.SelectedValue.ToString
        Dim DestinyFolder = Directory.GetCurrentDirectory & "\Forge Gauntlets\" & cmbformat.SelectedValue.ToString & "\" & cmbyear.SelectedValue.ToString

        If Not Directory.Exists(OriginFolder) Then
            MsgBox(OriginFolder & " Not found")
            Exit Function
        End If

        If Not Directory.Exists(DestinyFolder) Then
            Directory.CreateDirectory(DestinyFolder)
        End If

        For Each d In Directory.GetDirectories(OriginFolder)

            Dim DirName = New DirectoryInfo(d).Name
            Dim fn = DestinyFolder & "\" & DirName

            Dim GetDays() = Directory.GetDirectories(OriginFolder & "\" & DirName)

            For Each MyDays In GetDays
                Dim ADirName = New DirectoryInfo(MyDays).Name
                Dim posible = DestinyFolder & "LOCKED_" & ADirName & ".dat"
                If Not File.Exists(posible) Then
                    creategauntlet(MyDays, DestinyFolder & "\")
                End If

            Next
        Next
    End Function

    Function ConvertDeckstoGauntlets2(OriginFolder2)
        Dim DestinyFolder = Directory.GetCurrentDirectory & "\Forge Gauntlets"
        creategauntlet(OriginFolder2, DestinyFolder & "\")

    End Function

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        renombarcarpetas()
    End Sub

    Sub renombarcarpetas()
        'If cmbyear.SelectedValue.ToString = "all" Then
        '    MsgBox("Select Year")
        '    Exit Sub
        'End If

        'If _
        '    MsgBox(
        '        "Renaming folders! Warning! you need an update file unsupportedcards.txt with all cards unsupported by Forge to avoid unscripted cards in Forge. An outdate file may causes bad deck files.",
        '        MsgBoxStyle.YesNo, "Warning!") = MsgBoxResult.Yes Then
        '    If cmbformat.SelectedValue.ToString = "all" Then
        '        For a = 0 To cmbformat.Items.Count - 1
        '            If cmbformat.Items(a).value.ToString <> "all" Then
        '                RenameFolder(cmbformat.Items(a).value.ToString)
        '            End If
        '        Next
        '    Else
        '        'ConvertJsonFilestoDck(cmbformat.SelectedItem.value.ToString)
        '        RenameFolder(cmbformat.SelectedItem.value.ToString)
        '    End If

        'End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btExtract.Click
        If cmbyear.SelectedValue.ToString = "all" Then
            MsgBox("Select Year")
            Exit Sub
        End If

        If _
            MsgBox(
                "Warning! you need an update file unsupportedcards.txt with all cards unsupported by Forge to avoid unscripted cards in Forge. An outdate file may causes bad deck files.",
                MsgBoxStyle.YesNo, "Warning!") = MsgBoxResult.Yes Then
            If cmbformat.SelectedValue.ToString = "all" Then
                For a = 0 To cmbformat.Items.Count - 1
                    If cmbformat.Items(a).value.ToString <> "all" Then
                        ConvertJsonFilestoDck(cmbformat.Items(a).value.ToString)
                    End If
                Next
            Else
                ConvertJsonFilestoDck(cmbformat.SelectedItem.value.ToString)

            End If

            renombarcarpetas()

        End If
    End Sub

    Private Sub btnzipdecks_Click(sender As Object, e As EventArgs) Handles btnzipdecks.Click
        If cmbformat.SelectedValue.ToString = Nothing Then
            MsgBox("Select Format")
            Exit Sub
        End If

        Dim formato As String
        Dim myyear As String

        If cmbformat.SelectedValue.ToString = "all" Then

            For a = 0 To cmbformat.Items.Count - 1
                If cmbformat.Items(a).value.ToString <> "all" Then
                    zipdecks(cmbformat.Items(a).value.ToString)
                End If
            Next
        Else
            zipdecks(cmbformat.SelectedItem.value.ToString)
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'lee las carpetas y las pone en cmbcategories
        Dim ruta = Directory.GetCurrentDirectory() & "/Tournaments/"
        For Each Dir As String In Directory.GetDirectories(ruta)
            cmbcategories.Items.Add(Split(Dir, "Tournaments/")(1).ToString)
        Next

        cmbcategories.SelectedIndex = cmbcategories.Items.IndexOf("magic.wizards.com")

        Try
            AllCards = My.Computer.FileSystem.ReadAllText("supportedcards.txt")
        Catch
        End Try

        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add("all", "all")
        comboSource.Add("standard", "standard")
        comboSource.Add("modern", "modern")
        comboSource.Add("vintage", "vintage")
        comboSource.Add("legacy", "legacy")
        comboSource.Add("pauper", "pauper")
        comboSource.Add("pioneer", "pioneer")
        comboSource.Add("block", "block")

        cmbformat.DataSource = New BindingSource(comboSource, Nothing)
        cmbformat.DisplayMember = "Value"
        cmbformat.ValueMember = "Key"

        cmbformat.SelectedIndex = 1

        comboSource = Nothing
        comboSource = New Dictionary(Of String, String)()
        comboSource.Add("all", "all")
        For i = 2014 To DateTime.Now.Year
            comboSource.Add(i, i)
        Next

        cmbyear.DataSource = New BindingSource(comboSource, Nothing)
        cmbyear.DisplayMember = "Value"
        cmbyear.ValueMember = "Key"
        cmbformat.SelectedIndex = 0

    End Sub

    Public Shared Sub compressDirectory(DirectoryPath As String, OutputFilePath As String,
                                        ByVal Optional CompressionLevel As Integer = 9)
        Try
            Dim filenames As String() = Directory.GetFiles(DirectoryPath)

            Using OutputStream = New ZipOutputStream(File.Create(OutputFilePath))
                OutputStream.SetLevel(CompressionLevel)
                Dim buffer = New Byte(4095) {}

                For Each file As String In filenames
                    Dim entry = New ZipEntry(Path.GetFileName(file))
                    entry.DateTime = DateTime.Now
                    OutputStream.PutNextEntry(entry)

                    Using fs As FileStream = IO.File.OpenRead(file)
                        Dim sourceBytes As Integer

                        Do
                            sourceBytes = fs.Read(buffer, 0, buffer.Length)
                            OutputStream.Write(buffer, 0, sourceBytes)
                        Loop While sourceBytes > 0
                    End Using
                Next

                OutputStream.Finish()
                OutputStream.Close()
                Console.WriteLine("Files successfully compressed")
            End Using
        Catch ex As Exception
            Console.WriteLine("Exception during processing {0}", ex)
        End Try
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem.Click
    End Sub

    Private Sub CheckForANewVersionToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles CheckForANewVersionToolStripMenuItem.Click
        Process.Start("https://forgedecks.000webhostapp.com/MTGODecklistCachetoForge.zip")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If cmbformat.SelectedValue.ToString = Nothing Then
            MsgBox("Select Format")
            Exit Sub
        End If

        If cmbformat.SelectedValue.ToString = "all" Then
            For a = 0 To cmbformat.Items.Count - 1
                If cmbformat.Items(a).value.ToString <> "all" Then
                    GenerateList(cmbformat.Items(a).value.ToString)
                End If
            Next
        Else
            GenerateList(cmbformat.SelectedItem.value.ToString)

        End If
    End Sub

    Sub GenerateList(formato)


        Dim OriginFolder = Directory.GetCurrentDirectory & "\Forge Tournaments Decks Zipped"
        Dim DestinyFolder = Directory.GetCurrentDirectory & "\Forge Tournaments Decks Zipped"
        If Not Directory.Exists(OriginFolder) Then
            MsgBox("Can't find json Tournaments Folder!")
            Exit Sub
        End If

        If Not Directory.Exists(DestinyFolder) Then
            Directory.CreateDirectory(DestinyFolder)
        End If

        Dim filenames As String() = Directory.GetFiles(OriginFolder & "\" & formato,
                                                       "*.zip")

        Dim MyNameOfFile = "net-decks-archive-" & formato & ".txt"
        Dim tx = ""

        Dim listaactual As New List(Of String)
        Dim listaleida As New List(Of String)

        'tengo que crear dos listas, las que hay y las que existen en el fichero
        If IO.File.Exists(MyNameOfFile) Then
            'Dim fileReader As String
            'fileReader = My.Computer.FileSystem.ReadAllText(MyNameOfFile)
            'For Each line In fileReader
            '    listaactual.Add(line)
            '    tx = tx & line
            'Next

            Dim reader As StreamReader = My.Computer.FileSystem.OpenTextFileReader(MyNameOfFile)
            Dim a As String

            Do
                a = reader.ReadLine
                listaactual.Add(a & vbCrLf)

                tx = tx & a & vbCrLf

                ' Code here
                '
            Loop Until a Is Nothing

            reader.Close()

        End If

        For Each d In filenames

            Dim totaldecks = GetTotalDecks(d.ToString)

            Dim MyName = d
            Dim exclude = False


            MyName = Replace(MyName, OriginFolder & "\" & formato & "\", "")
            MyName = Replace(MyName, ".zip", "")
            MyName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(MyName)
            MyName = MyName & " (" & totaldecks & " decks)"

            If totaldecks <> 0 Then
                Dim comp = Split(MyName, "-")
                Dim MyDate = ""
                Try
                    MyDate = comp(0) & "-" & comp(1) & "-" & comp(2)
                Catch
                End Try
                Dim eltexto = MyName
                eltexto = Replace(eltexto, MyDate & "-", " ")
                eltexto = Replace(eltexto, "-", " ")
                MyName = MyDate & eltexto
                Dim ServerUrl As String = d
                ServerUrl = Replace(ServerUrl, OriginFolder & "\" & formato & "\", "")
                Dim a = MyName & " | https://downloads.cardforge.org/decks/archive/" & formato & "/" & ServerUrl & vbCrLf

                If listaactual.Contains(a) = False Then
                    tx = tx & a
                    listaleida.Add(a)
                Else
                    Dim hola = ""

                End If
            Else
                Dim hola = ""

            End If

        Next

        If IO.File.Exists(MyNameOfFile) Then
            Dim fileReader As String
            fileReader = My.Computer.FileSystem.ReadAllText(MyNameOfFile)
        End If

        Try
            File.Delete(MyNameOfFile)
        Catch
        End Try

        File.WriteAllText(MyNameOfFile, tx)
        WriteUserLog(MyNameOfFile & " done!" & vbCrLf)
    End Sub



    Public Shared Function GetTotalDecks(archivozip As String)
        Dim MyCount = 0
        Using zFile = New ZipFile(archivozip)
            For Each e As ZipEntry In zFile
                If e.IsFile Then
                    MyCount = MyCount + 1
                End If
            Next
        End Using
        Return MyCount
    End Function

    Sub searchforacard()
        'recorro todos los mazos de la categoria y año seleccionado y busco esa carta en el mazo
        If cmbyear.SelectedValue.ToString = "all" Then
            MsgBox("Select Year")
            Exit Sub
        End If

        If cmbformat.SelectedValue.ToString = "all" Then
            MsgBox("Select Format")
            Exit Sub
        End If

        Dim ruta = Directory.GetCurrentDirectory() & "/Forge Tournaments Decks/" & cmbformat.Text & "/" & cmbyear.Text & "/"
        If Directory.Exists(ruta) = False Then
            WriteUserLog("Can't find " & ruta)
            Exit Sub
        End If

        For Each Dir As String In Directory.GetDirectories(ruta)

            For Each SubDir As String In Directory.GetDirectories(Dir)
                SubDir = SubDir

                Dim di As New DirectoryInfo(SubDir)
                ' Get a reference to each file in that directory.
                Dim fiArr As FileInfo() = di.GetFiles()
                ' Display the names of the files.
                Dim fri As FileInfo
                For Each fri In fiArr
                    Console.WriteLine(fri.Name)
                    Dim fileReader As String
                    fileReader = My.Computer.FileSystem.ReadAllText(SubDir & "/" & fri.Name)
                    fileReader = fileReader
                    If InStr(fileReader, txfind.Text, CompareMethod.Text) > 0 Then
                        fileReader = Replace(fileReader, txfind.Text, txreplace.Text)
                        My.Computer.FileSystem.DeleteFile(SubDir & "/" & fri.Name)
                        File.Create(SubDir & "/" & fri.Name).Dispose()
                        File.WriteAllText(SubDir & "/" & fri.Name, fileReader)
                        WriteUserLog("Replaced " & txfind.Text & " in " & SubDir & "/" & fri.Name & vbCrLf)

                    End If

                Next fri

            Next
        Next

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        searchforacard()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If _
      MsgBox(
          "Warning! you need an update file supportedcards.txt with all cards supported by Forge. It is because Gauntlets Decks need in each card |EDITION acronym and the file is used to it. An outdate file may causes bad Gauntlets files.",
          MsgBoxStyle.YesNo, "Warning!") = MsgBoxResult.Yes Then
            ConvertDeckstoGauntlets()
        End If
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        Dim MyFolder = txfolder.Text
        ConvertDeckstoGauntlets2(MyFolder)
    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)
        For i = 1 To 10
            MsgBox("hola!" & i)
        Next

    End Sub

End Class