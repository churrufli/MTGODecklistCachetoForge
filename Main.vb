Imports System.Globalization
Imports System.IO
Imports System.IO.Compression
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports ICSharpCode.SharpZipLib.Zip
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq


Public Class Main
    Dim AllCards As String
    ReadOnly cards = Split(AllCards, vbCrLf)

    Function zipdecks()
        If cmbformat.SelectedValue.ToString = Nothing Then
            MsgBox("Select Format")
            Exit Function
        End If

        Dim OriginFolder = Directory.GetCurrentDirectory & "\Forge Tournaments Decks"
        Dim DestinyFolder = Directory.GetCurrentDirectory & "\Forge Tournaments Decks Zipped"
        If Not Directory.Exists(OriginFolder) Then
            MsgBox("Can't find json Tournaments Folder!")
            Exit Function
        End If

        If Not Directory.Exists(DestinyFolder) Then
            Directory.CreateDirectory(DestinyFolder)
        End If

        For Each d In Directory.GetDirectories(OriginFolder & "\" & cmbformat.SelectedValue.ToString)

            Dim DirName = New DirectoryInfo(d).Name
            Dim fn = DestinyFolder & "\" & DirName


            Dim GetMonths() =
                    Directory.GetDirectories(OriginFolder & "\" & cmbformat.SelectedValue.ToString & "\" & DirName)

            For Each mymonth In GetMonths
                Dim DirName2 = New DirectoryInfo(mymonth).Name
                Dim fm = fn & "\" & DirName2

                Dim GetDays() = Directory.GetDirectories(mymonth)
                If Not Directory.Exists("Forge Tournaments Decks Zipped\" & cmbformat.SelectedValue.ToString) Then
                    Directory.CreateDirectory("Forge Tournaments Decks Zipped\" & cmbformat.SelectedValue.ToString)
                End If

                For Each MyDays In GetDays

                    Dim DirName3 = New DirectoryInfo(MyDays).Name
                    Dim MyZipName = DirName3.ToString
                    DirName3 = DirName2 & "\" & DirName3
                    Dim dd = fn & "\" & DirName3
                    MyZipName = MyZipName

                    For i = 2014 To Date.Now.Year
                        If MyZipName.Contains(i) Then
                            MyZipName = i & Split(MyZipName, i)(1) & "-" & Split(MyZipName, i)(0)
                            Exit For
                        End If
                    Next i

                    MyZipName = MyZipName & ".zip"
                    MyZipName = Replace(MyZipName, "-.zip", ".zip")
                    MyZipName = Replace(MyZipName, "-(", "(")

                    If _
                        File.Exists(
                            "Forge Tournaments Decks Zipped\" & cmbformat.SelectedValue.ToString & "\" & MyZipName) =
                        False Then
                        compressDirectory(MyDays,
                                          "Forge Tournaments Decks Zipped\" & cmbformat.SelectedValue.ToString & "\" &
                                          MyZipName, 9)
                        WriteUserLog("Zipping " & MyZipName & vbCrLf)
                    Else
                        WriteUserLog("Skipping " & MyZipName & vbCrLf)
                    End If
                Next
            Next
        Next
        WriteUserLog("Done!")
    End Function


    Function ConvertJsonFilestoDck()

        If cmbformat.SelectedItem.ToString = "" Then
            MsgBox("Select Format")
            Exit Function
        End If

        If cmbyear.SelectedItem.ToString = "" Then
            MsgBox("Select Year")
            Exit Function
        End If

        'Dim listformats As New List(Of String)

        'If cmbformat.SelectedValue.ToString = "all" Then
        '    For i = 0 To cmbformat.Items.Count - 1
        '        If cmbformat.Items(i).value.ToString <> "all" Then
        '            listformats.Add(cmbformat.Items(i).value.ToString)
        '        End If
        '    Next i
        'Else
        '    listformats.Add(cmbformat.SelectedItem.ToString)
        'End If


        '***************************************
        'For myformat = 0 To listformats.Count - 1


            Dim OriginFolder = Directory.GetCurrentDirectory & "\Tournaments\" & cmbcategories.SelectedItem.ToString
            Dim DestinyFolder = Directory.GetCurrentDirectory & "\Forge Tournaments Decks"
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


                'Dim listyears As New List(Of String)

                'If cmbyear.SelectedValue.ToString = "all" Then
                '    For i = 0 To cmbformat.Items.Count - 1
                '        If cmbyear.Items(i).value.ToString <> "all" Then
                '            listyears.Add(cmbyear.Items(i).value.ToString)
                '        End If
                '    Next i
                'Else
                '    listyears.Add(cmbyear.SelectedItem.ToString)
                'End If


                'For myyear = 0 To listyears.Count - 1



                    'If DirName.Contains(cmbyear.SelectedValue.ToString) And continuar = False Then
                    'Dim valor = listyears(myyear).ToString
                    'If DirName.Contains(valor) Then
                    If DirName.Contains(cmbyear.SelectedValue.ToString) Then
                        ''aqui iba todo el for de abajo
                        'continuar = True
                        '******
                        For Each mymonth In GetMonths
                            Dim DirName2 = New DirectoryInfo(mymonth).Name
                            Dim fm = fn & "\" & DirName2

                            Dim GetDays() = Directory.GetDirectories(mymonth)

                            For Each MyDays In GetDays

                                Dim DirName3 = New DirectoryInfo(MyDays).Name
                                DirName3 = DirName2 & "\" & DirName3
                                Dim dd = fn & "\" & DirName3


                                For Each f In Directory.GetFiles(MyDays)
                                    If LCase(f).Contains(LCase(cmbformat.SelectedValue.ToString)) Then

                                    'If LCase(f).Contains(LCase(listformats.Item(myformat).ToString)) Then

                                        Dim tokenJson = JsonConvert.SerializeObject(File.ReadAllText(f))
                                        Dim jsonResult =
                                                    JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(
                                                        File.ReadAllText(f))

                                        Dim TournamentName As String = Path.GetFileNameWithoutExtension(f)
                                        Dim TournamentDate = CDate(jsonResult.Item("Tournament").Item("Date").ToString)
                                        TournamentName = RemoveInvalidFileNameChars(TournamentName)
                                        Dim tournamentfolder = dd & "\" & TournamentName

                                        Dim siguiente = False
                                        Dim mypath = Replace(d, OriginFolder, "")

                                        Dim formato As String = getformat(f)
                                        Dim elaño As String = Replace(d, OriginFolder, "")

                                        Dim elmes As String = Replace(mymonth, OriginFolder & elaño, "")

                                        mypath = DestinyFolder & "\" & formato & elaño & elmes & "\" & TournamentName

                                        If Not Directory.Exists(mypath) Then
                                            Directory.CreateDirectory(mypath)
                                            siguiente = True

                                        Else
                                            If chkoverwrite.Checked = True Then
                                                siguiente = True
                                            Else
                                                siguiente = False
                                            End If
                                        End If

                                        'Dim aver As String = TournamentName.Substring(TournamentName.Length - 2)
                                        'If aver = "-0" Then
                                        '    siguiente = False
                                        '    Try
                                        '        Directory.Delete(mypath, True)
                                        '    Catch
                                        '    End Try
                                        'End If

                                        If siguiente = True Then

                                            Dim json As String = File.ReadAllText(f)
                                            Dim ser As JObject = JObject.Parse(json)
                                            Dim data As List(Of JToken) = ser.Children().ToList
                                            Dim titdeck
                                            Dim contador As Long = 1
                                            Dim totaldecks = jsonResult.Item("Decks").count
                                            Dim newpath = mypath

                                            mypath = newpath
                                            For i = 0 To jsonResult.Item("Decks").count - 1

                                                titdeck = "#" & IIf(contador <= 9, "0", "") & contador & " " &
                                                              jsonResult.Item("Decks").item(i).item("Player") & " " &
                                                              jsonResult.Item("Decks").item(i).item("Result")
                                                Dim FinalName = Trim(titdeck)
                                                FinalName = RemoveInvalidFileNameChars(FinalName)
                                                Dim path As String = mypath & "\" & FinalName & ".dck"

                                                Dim overwrite = False
                                                If chkoverwrite.Checked = True Then
                                                    overwrite = True
                                                End If

                                                overwrite = True
                                                If overwrite Then
                                                    Dim mb = ""
                                                    Dim Mainboard = jsonResult.Item("Decks").item(i).item("Mainboard")

                                                    For x = 0 To Mainboard.count - 1
                                                        Dim carta = RemoveDigits(Mainboard.item(x).item("CardName"))
                                                        carta = Replace(carta, "&apos;", "'")
                                                        carta = Replace(carta, "ä", "a")
                                                        carta = Replace(carta, "ë", "e")
                                                        carta = Replace(carta, "ï", "i")
                                                        carta = Replace(carta, "ö", "o")
                                                        carta = Replace(carta, "ü", "u")

                                                        Dim card = Mainboard.item(x).item("Count") & " " &
                                                                       Mainboard.item(x).item("CardName")
                                                        mb = mb & card & vbCrLf
                                                    Next x

                                                    Dim sb = ""
                                                    Dim Sideboard = jsonResult.Item("Decks").item(i).item("Sideboard")

                                                    For x = 0 To Sideboard.count - 1
                                                        Dim card = Sideboard.item(x).item("Count") & " " &
                                                                       Sideboard.item(x).item("CardName")
                                                        sb = sb & card & vbCrLf
                                                    Next x

                                                    Dim deck As String = "[metadata]" & vbCrLf & "Name=" & titdeck & vbCrLf &
                                                                             "[Main]" & vbCrLf & mb & "[sideboard]" & vbCrLf & sb

                                                    Dim rp = False
                                                    If InStr(tournamentfolder, "commander", CompareMethod.Text) > 0 Then
                                                        rp = True
                                                    End If
                                                    If InStr(tournamentfolder, "brawl", CompareMethod.Text) > 0 Then
                                                        rp = True
                                                    End If

                                                    If rp = True Then
                                                        deck = Replace(deck, "[sideboard]", "[commander]")
                                                    End If

                                                    Dim save = False

                                                    If validatecards(deck, titdeck) = "" Then

                                                        Dim x = 1

                                                        If Not File.Exists(path) Then
                                                            Using fs As FileStream = File.Create(path)
                                                                Dim info As Byte() = New UTF8Encoding(True).GetBytes(deck)
                                                                fs.Write(info, 0, info.Length)
                                                            End Using
                                                        Else
                                                            If overwrite Then
                                                                Using fs As FileStream = File.Create(path)
                                                                    Dim info As Byte() = New UTF8Encoding(True).GetBytes(deck)
                                                                    fs.Write(info, 0, info.Length)
                                                                End Using
                                                            Else
                                                                WriteUserLog("exist " & path & vbCrLf)
                                                            End If

                                                        End If

                                                        WriteUserLog("saved" & path & vbCrLf)
                                                    Else
                                                        log.Text = log.Text & validatecards(deck, titdeck) & vbCrLf

                                                        WriteUserLog(validatecards(deck, titdeck) & vbCrLf)
                                                    End If
                                                Else
                                                    WriteUserLog("exist " & path & vbCrLf)

                                                End If

                                                contador = contador + 1

                                            Next i
                                        End If
                                    End If
                                Next
                                log.Text = ""
                            Next
                            log.Text = ""
                        Next
                        '******
                    End If


                'Next


            Next
            WriteUserLog("Done!")
            '*************************************
        'Next

    End Function

    Sub WriteUserLog(msg)
        log.SelectedText = msg
        log.SelectionStart = log.Text.Length
        log.ScrollToCaret()
    End Sub

    Public Shared Function validatecards(tx, titdeck) As String
        'Return ""
        Try
            Dim readText As String = File.ReadAllText("unsupportedcards.txt")
            Dim tx1 As String = readText
            tx1 = Replace(tx1, vbLf, vbCrLf)
            Dim a As Array = Split(tx1, vbCrLf)

            readText = tx
            Dim t As String = Split(readText, "[Main]" & vbCrLf)(1).ToString
            Dim t2 As String = Split(LCase(readText), "[sideboard]" & vbCrLf)(1).ToString
            t = t & t2
            Dim b As Array = Split(t, vbCrLf)

            Dim contador = 0


            While contador < b.Length

                Dim MyNamecarta = b(contador) & ""

                For x = 0 To 70
                    MyNamecarta = Replace(MyNamecarta, x + 1 & " ", "")
                Next x

                Dim contador2 = 0

                While contador2 < a.Length
                    Dim cartaprohibida As String = LCase(a(contador2))
                    MyNamecarta = LCase(MyNamecarta)
                    If LCase(MyNamecarta) = LCase(cartaprohibida) Then
                        Return _
                            ("Forge unsupported card '" & cartaprohibida & "' in " & titdeck & ". Deck not saved." &
                             vbCrLf)
                        Exit Function
                    End If
                    contador2 = contador2 + 1
                End While

                contador = contador + 1
            End While

            Return ""

        Catch ex As Exception
            Return ""
        End Try
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If _
            MsgBox(
                "Warning! you need an update file supportedcards.txt with all cards supported by Forge. It is because Gauntlets Decks need in each card |EDITION acronym and the file is used to it. An outdate file may causes bad Gauntlets files.",
                MsgBoxStyle.YesNo, "Warning!") = MsgBoxResult.Yes Then
            ConvertDeckstoGauntlets()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If _
            MsgBox(
                "Warning! you need an update file unsupportedcards.txt with all cards unsupported by Forge to avoid unscripted cards in Forge. An outdate file may causes bad deck files.",
                MsgBoxStyle.YesNo, "Warning!") = MsgBoxResult.Yes Then
            ConvertJsonFilestoDck()
        End If
    End Sub

    Private Sub btnzipdecks_Click(sender As Object, e As EventArgs) Handles btnzipdecks.Click
        zipdecks()
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
        GenerateList()
    End Sub

    Sub GenerateList()
        If cmbformat.SelectedItem.value.ToString = "" Then
            MsgBox("Select Format")
            Exit Sub
        End If
        Dim OriginFolder = Directory.GetCurrentDirectory & "\Forge Tournaments Decks Zipped"
        Dim DestinyFolder = Directory.GetCurrentDirectory & "\Forge Tournaments Decks Zipped"
        If Not Directory.Exists(OriginFolder) Then
            MsgBox("Can't find json Tournaments Folder!")
            Exit Sub
        End If

        If Not Directory.Exists(DestinyFolder) Then
            Directory.CreateDirectory(DestinyFolder)
        End If

        Dim filenames As String() = Directory.GetFiles(OriginFolder & "\" & cmbformat.SelectedItem.value.ToString,
                                                       "*.zip")
        Dim tx = ""
        For Each d In filenames

            Dim totaldecks = GetTotalDecks(d.ToString)

            Dim MyName = d
            Dim exclude = False

            'If MyName.Contains("-0-") Then
            '    exclude = True
            'End If

            'If (MyName.Length - 2) = "-0" Then
            '    exclude = True
            'End If

            'If exclude Then
            '    Try
            '        File.Delete(d)
            '    Catch
            '    End Try
            'End If

            MyName = Replace(MyName, OriginFolder & "\" & cmbformat.SelectedItem.value.ToString & "\", "")
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
                'PROBLEMA EN EL FORGE, COMENTO MyName = Replace(MyName, "-", "/")
                Dim ServerUrl As String = d
                ServerUrl = Replace(ServerUrl, OriginFolder & "\" & cmbformat.SelectedItem.value.ToString & "\", "")
                tx = tx & MyName & " | https://downloads.cardforge.org/decks/archive/" &
                     cmbformat.SelectedItem.value.ToString & "/" & ServerUrl & vbCrLf
            Else
                Dim hola = ""
            End If

        Next

        Dim MyNameOfFile = "net-decks-archive-" & cmbformat.SelectedItem.value.ToString & ".txt"
        Try
            File.Delete(MyNameOfFile)
        Catch
        End Try

        File.WriteAllText(MyNameOfFile, tx)
        WriteUserLog("List Done!")
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
End Class