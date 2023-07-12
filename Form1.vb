Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Threading
Imports AForge.Imaging

Public Class Form1

    ' Windows API declarations
    Private Declare Function FindWindowEx Lib "user32" Alias "FindWindowExA" (ByVal hWnd1 As IntPtr, ByVal hWnd2 As IntPtr, ByVal lpsz1 As String, ByVal lpsz2 As String) As IntPtr
    Private Declare Function GetClientRect Lib "user32" (ByVal hWnd As IntPtr, ByRef lpRect As RECT) As Boolean
    Private Declare Function PrintWindow Lib "user32" (ByVal hWnd As IntPtr, ByVal hdcBlt As IntPtr, ByVal nFlags As UInteger) As Boolean

    Private Structure RECT
        Public Left As Integer
        Public Top As Integer
        Public Right As Integer
        Public Bottom As Integer
    End Structure

    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function GetWindowRect(hWnd As IntPtr, ByRef lpRect As RECT) As Boolean
    End Function
    <DllImport("user32")>
    Public Shared Sub mouse_event(ByVal dwFlags As UInteger,
                                 ByVal dx As UInteger,
                                 ByVal dy As UInteger,
                                 ByVal dwData As UInteger,
                                 ByVal dwExtraInfo As Integer)
    End Sub

    Private Const INPUT_MOUSE As Integer = 0
    Const MOUSEEVENTF_LEFTDOWN As UInteger = &H2
    Const MOUSEEVENTF_LEFTUP As UInteger = &H4
    Const MOUSEEVENTF_RIGHTDOWN As UInteger = &H8
    Const MOUSEEVENTF_RIGHTUP As UInteger = &H10
    Private Const WM_LBUTTONDOWN As Integer = &H201
    Private Const WM_LBUTTONUP As Integer = &H202
    Private Const WM_MBUTTONDOWN As Integer = &H207
    Private Const WM_MBUTTONUP As Integer = &H208
    Private Const MK_MBUTTON As Integer = &H10
    Private Const MOUSEEVENTF_MOVE As UInteger = &H1
    Private Const KEYEVENTF_EXTENDEDKEY As Integer = &H1
    Private Const KEYEVENTF_KEYUP As Integer = &H2

    <DllImport("user32.dll")>
    Private Shared Sub keybd_event(bVk As Byte, bScan As Byte, dwFlags As Integer, dwExtraInfo As Integer)
    End Sub

    <DllImport("user32")>
    Public Shared Function FindWindow(ByVal lpClassName As String,
                                      ByVal lpWindowName As String) As IntPtr
    End Function

    <DllImport("user32")>
    Public Shared Function GetDC(ByVal hWnd As IntPtr) As IntPtr
    End Function

    <DllImport("user32")>
    Public Shared Function ReleaseDC(ByVal hwnd As IntPtr,
                                     ByVal hdc As IntPtr) As IntPtr
    End Function

    <DllImport("gdi32")>
    Private Shared Function GetPixel(ByVal hdc As IntPtr,
                                     ByVal X As Int32,
                                     ByVal Y As Int32) As Int32
    End Function

    ' Import required WinAPI functions
    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function SetForegroundWindow(ByVal hWnd As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function ReleaseCapture() As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim KillTimer As Integer = CInt(TextBox1.Text)
        Timer1.Interval = 1000 * KillTimer ' Set tick interval to 1 second
        Label2.Text = MousePosition.ToString
        Dim activeWindowTitle As String
        activeWindowTitle = Robot.GetActiveWindowTitle()

        If Not activeWindowTitle = Me.Text Then
            ToolStripStatusLabel1.Text = activeWindowTitle
        End If
        Dim Target1 As Color = Label3.ForeColor
        Dim Target2 As Color = Label4.ForeColor
        ImageCapture()
        Dim screenshot As Bitmap = CType(PictureBox1.Image, Bitmap)
        ProcessImage(Target1, Target2)

        Dim x As Integer, y As Integer
        x = Label8.Text
        y = Label9.Text

        While x = 0 AndAlso y = 0
            RotateCamera()
            ImageCapture()
            ProcessImage(Target1, Target2)
            x = Label8.Text
            y = Label9.Text
            ' Sleep for 2 seconds (2000 milliseconds)
            Thread.Sleep(2000)
        End While

        MouseMoveAndClick()
        'MouseMoveAndClick()
    End Sub

    Private Sub ImageRecogniziton()
        ' Assuming you have a captured screenshot stored in a variable called 'gameScreenshot' of type Bitmap
        Dim gameScreenshot As Bitmap = CType(PictureBox1.Image, Bitmap)
        ' Resize the image if needed
        Dim newWidth As Integer, newHeight As Integer
        newWidth = 1440
        newHeight = 810

        Dim resizedImage As Bitmap = ResizeImage(gameScreenshot, New Size(newWidth, newHeight))

        ' Convert the image to grayscale
        Dim grayscaleImage As Bitmap = ConvertToGrayscale(resizedImage)

        ' Save the captured screenshot as a template image
        SaveTemplateImage(grayscaleImage)
    End Sub

    Private Sub SaveTemplateImage(ByVal image As Bitmap)
        Dim templateFileName As String = "template.png"
        Dim currentDirectory As String = Directory.GetCurrentDirectory()
        Dim templateFilePath As String = Path.Combine(currentDirectory, templateFileName)

        ' Check if the template file already exists
        If File.Exists(templateFilePath) Then
            Dim templateNumber As Integer = 1
            Dim newTemplateFilePath As String

            ' Increment the template number until a unique filename is found
            Do
                Dim newFileName As String = $"template{templateNumber}.png"
                newTemplateFilePath = Path.Combine(currentDirectory, newFileName)
                templateNumber += 1
            Loop While File.Exists(newTemplateFilePath)

            ' Save the new template with the incremented number
            image.Save(newTemplateFilePath, ImageFormat.Png)
        Else
            ' Save the grayscale image as the initial template
            image.Save(templateFilePath, ImageFormat.Png)
        End If

    End Sub

    ' Function to resize the image while maintaining aspect ratio
    Private Function ResizeImage(ByVal image As Bitmap, ByVal newSize As Size) As Bitmap
        Dim ratioX As Double = CDbl(newSize.Width) / image.Width
        Dim ratioY As Double = CDbl(newSize.Height) / image.Height
        Dim ratio As Double = Math.Min(ratioX, ratioY)

        Dim newWidth As Integer = CInt(image.Width * ratio)
        Dim newHeight As Integer = CInt(image.Height * ratio)

        Dim newImage As New Bitmap(newWidth, newHeight)
        Using graphics As Graphics = Graphics.FromImage(newImage)
            graphics.DrawImage(image, 0, 0, newWidth, newHeight)
        End Using

        Return newImage
    End Function

    ' Function to convert the image to grayscale
    Private Function ConvertToGrayscale(ByVal image As Bitmap) As Bitmap
        Dim grayscaleImage As New Bitmap(image.Width, image.Height)

        For y As Integer = 0 To image.Height - 1
            For x As Integer = 0 To image.Width - 1
                Dim pixel As Color = image.GetPixel(x, y)
                Dim grayScale As Integer = CInt(pixel.R * 0.299 + pixel.G * 0.587 + pixel.B * 0.114)
                grayscaleImage.SetPixel(x, y, Color.FromArgb(grayScale, grayScale, grayScale))
            Next
        Next

        Return grayscaleImage
    End Function

    Private Sub StartLoop()
        stopLoop = False
        Timer1.Start()

        While Not stopLoop
            Application.DoEvents() ' Allow the UI to remain responsive
        End While

        Timer1.Stop()
    End Sub

    Public Sub RotateCamera()
        ' Get the handle of the Chrome window
        Dim chromeWindowHandle As IntPtr = FindChromeWindow()

        ' Check if Chrome window handle is found
        If chromeWindowHandle <> IntPtr.Zero Then
            ' Set Chrome window as the active window
            SetForegroundWindow(chromeWindowHandle)

            ' Randomly choose between A and D keys
            Dim random As New Random()
            Dim key As Integer = If(random.Next(2) = 0, Keys.A, Keys.D)

            ' Press and hold the randomly chosen key
            keybd_event(CByte(key), 0, KEYEVENTF_EXTENDEDKEY Or 0, 0)

            ' Sleep for 2 seconds (2000 milliseconds)
            Thread.Sleep(2000)

            ' Release the key
            keybd_event(CByte(key), 0, KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)
        End If
    End Sub

    Private stopLoop As Boolean = False

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        stopLoop = False
        StartLoop()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        stopLoop = True
        PictureBox1.Image.Dispose()
        PictureBox1.Image = Nothing
        MsgBox("clicker stopped")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ColorDialog1.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            Label3.ForeColor = ColorDialog1.Color
            PictureBox2.BackColor = ColorDialog1.Color
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            Label4.ForeColor = ColorDialog1.Color
            PictureBox3.BackColor = ColorDialog1.Color
        End If
    End Sub

    Public Sub LeftClick()
        Dim input As INPUT = New INPUT()
        input.type = INPUT_MOUSE
        input.mi.dwFlags = MOUSEEVENTF_LEFTDOWN
        SendInput(1, input, Marshal.SizeOf(input))

        Thread.Sleep(200) ' Wait required

        input.mi.dwFlags = MOUSEEVENTF_LEFTUP
        SendInput(1, input, Marshal.SizeOf(input))
    End Sub

    Private Structure INPUT
        Public type As Integer
        Public mi As MOUSEINPUT
    End Structure

    Private Structure MOUSEINPUT
        Public dx As Integer
        Public dy As Integer
        Public mouseData As Integer
        Public dwFlags As Integer
        Public time As Integer
        Public dwExtraInfo As IntPtr
    End Structure



    Private Declare Function SendInput Lib "user32" (ByVal nInputs As Integer, ByRef pInputs As INPUT, ByVal cbSize As Integer) As Integer

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles PresetRat.Click
        Label3.ForeColor = Color.FromArgb(236, 139, 123)
        PictureBox2.BackColor = Color.FromArgb(236, 139, 123)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles PresetGoblin.Click
        Label3.ForeColor = Color.FromArgb(239, 208, 54)
        PictureBox2.BackColor = Color.FromArgb(239, 208, 54)
        Label4.ForeColor = Color.FromArgb(102, 145, 10)
        PictureBox3.BackColor = Color.FromArgb(102, 145, 10)
    End Sub


    Public Function ProcessImage(Target1 As Color, Target2 As Color) As Point
        Dim screenshot As Bitmap = Nothing
        Dim width As Integer = 0
        Dim height As Integer = 0
        Dim result As Point = Point.Empty
        Dim StartTime As DateTime = DateTime.Now()
        ' Synchronize access to the bitmap
        SyncLock PictureBox1.Image
            ' Create a local copy of the bitmap
            screenshot = New Bitmap(CType(PictureBox1.Image, Bitmap))
            width = screenshot.Width
            height = screenshot.Height
        End SyncLock

        ' Search for Target1 in parallel
        Parallel.For(0, width, Sub(x)
                                   If Not result.IsEmpty Then
                                       ' Target1 already found, exit the loop
                                       Return
                                   End If

                                   For y As Integer = 0 To height - 1
                                       ' Synchronize access to the bitmap
                                       SyncLock screenshot
                                           If screenshot.GetPixel(x, y) = Target1 Then
                                               result = New Point(x + 1, y + 1)
                                               Return
                                           End If
                                       End SyncLock
                                   Next
                               End Sub)

        ' If Target1 not found, search for Target2 in parallel
        If result.IsEmpty Then
            Parallel.For(0, width, Sub(x)
                                       If Not result.IsEmpty Then
                                           ' Target2 already found, exit the loop
                                           Return
                                       End If

                                       For y As Integer = 0 To height - 1
                                           ' Synchronize access to the bitmap
                                           SyncLock screenshot
                                               If screenshot.GetPixel(x, y) = Target2 Then
                                                   result = New Point(x + 1, y + 1)
                                                   Return
                                               End If
                                           End SyncLock
                                       Next
                                   End Sub)
        End If
        ' Get the elapsed time and set labels
        Dim color As Color = If(result <> Point.Empty, Target1, Target2)
        GetElapsedTimeAndSetLabels(StartTime, result.X, result.Y)
        Return result
    End Function


    Private Function GetElapsedTimeAndSetLabels(startTime As DateTime, mouseX As Integer, mouseY As Integer) As Color
        Dim endTime As DateTime = DateTime.Now()
        Dim elapsedSeconds As Double = endTime.Subtract(startTime).TotalSeconds
        Label5.Text = "Image processed in " & elapsedSeconds.ToString("0.##") & " seconds"
        Label8.Text = mouseX.ToString()
        Label9.Text = mouseY.ToString()
        Return If(mouseX <> -1 AndAlso mouseY <> -1, Label3.ForeColor, Color.Empty)
    End Function

    Public Sub MouseMoveAndClick()
        Dim StartTime As DateTime = DateTime.Now()
        Dim mouseX As Integer
        Dim mouseY As Integer
        mouseX = Label8.Text
        mouseY = Label9.Text

        ' Get the handle of the Chrome window
        Dim chromeWindowHandle As IntPtr = FindChromeWindow()

        ' Check if Chrome window handle is found
        If chromeWindowHandle <> IntPtr.Zero Then
            ' Get the bounding rectangle of the Chrome window
            Dim windowRect As RECT
            GetWindowRect(chromeWindowHandle, windowRect)

            '' Calculate the relative click position within the Chrome window
            Dim relativeX As Integer = mouseX
            Dim relativeY As Integer = mouseY

            ' Calculate the absolute click position on the entire screen
            Dim absoluteX As Integer = windowRect.Left + relativeX
            Dim absoluteY As Integer = windowRect.Top + relativeY

            ' Move the mouse cursor to the absolute position on the screen
            Windows.Forms.Cursor.Position = New Point(absoluteX, absoluteY)

            ' Perform the mouse click
            LeftClick()
        End If

        Dim EndTime As DateTime = DateTime.Now()
        Dim ElapsedSeconds As Double = EndTime.Subtract(StartTime).TotalSeconds

        Label10.Text = "On " & ElapsedSeconds.ToString("F2") & " seconds, left click occurred at " & mouseX.ToString() & "," & mouseY.ToString()
    End Sub

    Public Function CountLoop(Count As Integer) As Integer
        Count += 1
        Return Count
    End Function


    Private Sub ImageCapture()
        Dim chromeWindow As IntPtr = FindChromeWindow()
        If chromeWindow <> IntPtr.Zero Then
            Dim bounds As Rectangle = GetWindowRectangle(chromeWindow)
            Dim screenshot As New Bitmap(bounds.Width, bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
            Using g As Graphics = Graphics.FromImage(screenshot)
                g.CopyFromScreen(bounds.Left, bounds.Top, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy)
            End Using
            PictureBox1.Image = screenshot
        Else
            MessageBox.Show("Chrome window not found.")
        End If
    End Sub

    Private Function FindChromeWindow() As IntPtr
        Dim processName As String = "chrome"

        Dim chromeProcesses As Process() = Process.GetProcessesByName(processName)
        For Each chromeProcess As Process In chromeProcesses
            If chromeProcess.MainWindowHandle <> IntPtr.Zero Then
                Dim windowClass As StringBuilder = New StringBuilder(256)
                NativeMethods.GetClassName(chromeProcess.MainWindowHandle, windowClass, windowClass.Capacity)
                If windowClass.ToString() = "Chrome_WidgetWin_1" Then
                    Return chromeProcess.MainWindowHandle
                End If
            End If
        Next

        Return IntPtr.Zero
    End Function



    Private Function GetWindowRectangle(windowHandle As IntPtr) As Rectangle
        Dim rect As NativeMethods.RECT
        NativeMethods.GetWindowRect(windowHandle, rect)
        Return Rectangle.FromLTRB(rect.Left, rect.Top, rect.Right, rect.Bottom)
    End Function

    Private Class NativeMethods
        <System.Runtime.InteropServices.DllImport("user32.dll")>
        Public Shared Function GetClassName(hWnd As IntPtr, lpClassName As StringBuilder, nMaxCount As Integer) As Integer
        End Function

        <System.Runtime.InteropServices.DllImport("user32.dll")>
        Public Shared Function GetWindowRect(hWnd As IntPtr, ByRef lpRect As RECT) As Boolean
        End Function

        Public Structure RECT
            Public Left As Integer
            Public Top As Integer
            Public Right As Integer
            Public Bottom As Integer
        End Structure
    End Class

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles PresetGreenSlime.Click
        Label3.ForeColor = Color.FromArgb(138, 230, 0)
        PictureBox2.BackColor = Color.FromArgb(138, 230, 0)
        Label4.ForeColor = Color.FromArgb(152, 251, 0)
        PictureBox3.BackColor = Color.FromArgb(152, 251, 0)
    End Sub

    Private Sub Button5_Click_2(sender As Object, e As EventArgs) Handles Button5.Click
        Label3.ForeColor = Color.FromArgb(0, 80, 200)
        PictureBox2.BackColor = Color.FromArgb(0, 80, 200)
        Label4.ForeColor = Color.FromArgb(0, 0, 0)
        PictureBox3.BackColor = Color.FromArgb(0, 0, 0)
    End Sub

    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click
        ImageRecogniziton()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim currentDirectory As String = Directory.GetCurrentDirectory()

        ' Specify the directory name where the grayscale template images are stored
        Dim templateDirectory As String = currentDirectory

        ' Get all PNG files in the template directory
        Dim templateFiles As String() = Directory.GetFiles(templateDirectory, "*.png")

        Dim goblinTemplates As New List(Of Bitmap)()

        ' Load grayscale template images into the list
        For Each templateFile As String In templateFiles
            Dim templateImage As Bitmap = New Bitmap(templateFile)
            goblinTemplates.Add(templateImage)
        Next

        ' Convert the image to grayscale
        Dim gameScreenshot As Bitmap = CType(PictureBox1.Image, Bitmap)
        Dim capturedGrayImage As Bitmap = ConvertToGrayscale(gameScreenshot)

        Dim matchedTemplate As Bitmap = FindBestMatch(capturedGrayImage, goblinTemplates)

        If matchedTemplate IsNot Nothing Then
            ' A matching template was found
            ' Perform further actions or interactions with the identified goblin
            MsgBox("Goblin Found")

        Else
            ' No matching template was found
            ' Handle the case when no goblin is detected
            MsgBox("Goblin Found")
        End If

    End Sub

    ' Function to perform template matching and find the best match
    Private Function FindBestMatch(ByVal capturedImage As Bitmap, ByVal templates As List(Of Bitmap)) As Bitmap
        Dim matchScoreThreshold As Double = 0.2 ' Adjust this threshold as needed

        Dim maxMatchScore As Double = 0
        Dim bestMatchIndex As Integer = -1

        For i As Integer = 0 To templates.Count - 1
            Dim template As Bitmap = templates(i)

            ' Convert the captured image and template to a supported pixel format
            capturedImage = capturedImage.Clone(New Rectangle(0, 0, capturedImage.Width, capturedImage.Height), PixelFormat.Format24bppRgb)
            template = template.Clone(New Rectangle(0, 0, template.Width, template.Height), PixelFormat.Format24bppRgb)
            MsgBox("test1")
            ' Create a new ExhaustiveTemplateMatching instance
            Dim tm As New ExhaustiveTemplateMatching(matchScoreThreshold)
            MsgBox("test2")
            ' Find the best match between the captured image and the template
            Dim match As TemplateMatch() = tm.ProcessImage(capturedImage, template)

            ' Check if the match score exceeds the threshold and is the highest so far
            If match.Length > 0 AndAlso match(0).Similarity > maxMatchScore Then
                maxMatchScore = match(0).Similarity
                bestMatchIndex = i
            End If
        Next
        MsgBox("test3")

        ' Check if a match above the threshold was found
        If bestMatchIndex >= 0 Then
            ' Return the best matching template image
            Return templates(bestMatchIndex)
        Else
            ' No match above the threshold was found
            Return Nothing
        End If
    End Function

    Dim SRclb As IO.StreamReader

    Private Sub LoadPresets_Click(sender As Object, e As EventArgs) Handles LoadPresets.Click
        Dim currentDirectory As String = Directory.GetCurrentDirectory()
        Dim presetsFilePath As String = currentDirectory & "\Presets.txt"

        If File.Exists(presetsFilePath) Then
            CheckedListBox1.Items.AddRange(File.ReadAllLines(presetsFilePath))
        Else
            Dim openFileDialog As New OpenFileDialog()
            openFileDialog.Title = "Select Presets File"
            openFileDialog.Filter = "Text Files (*.txt)|*.txt"

            If openFileDialog.ShowDialog() = DialogResult.OK Then
                presetsFilePath = openFileDialog.FileName
                CheckedListBox1.Items.AddRange(File.ReadAllLines(presetsFilePath))
            Else
                ' User cancelled file selection, handle accordingly
                Return
            End If
        End If


    End Sub

    Private Sub CheckedListBox1_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles CheckedListBox1.ItemCheck
        Dim selectedItem As String = CheckedListBox1.Items(e.Index).ToString()
        Dim itemParts As String() = selectedItem.Split(";"c)

        If e.NewValue = CheckState.Checked Then ' Only process when the item is being checked, not unchecked
            ' Uncheck all other items
            For i As Integer = 0 To CheckedListBox1.Items.Count - 1
                If i <> e.Index Then
                    CheckedListBox1.SetItemChecked(i, False)
                End If
            Next

            ' Extract Colour Id's from the list box
            If itemParts.Length = 3 Then
                Dim name As String = itemParts(0).Trim()
                Dim color1 As String = itemParts(1).Trim()
                Dim color2 As String = itemParts(2).Trim()

                ' Convert Color1 and Color2 to ARGB colors
                Dim argbColor1 As Color = ConvertToArgbColor(color1)
                Dim argbColor2 As Color = ConvertToArgbColor(color2)

                ' Use the extracted variables as needed
                Label3.ForeColor = argbColor1
                PictureBox2.BackColor = argbColor1
                Label4.ForeColor = argbColor2
                PictureBox3.BackColor = argbColor2

                MsgBox("Preset has been set to target: " & name)
            End If
        End If
    End Sub
    Function ConvertToArgbColor(colorString As String) As Color
        Dim components As String() = colorString.Split(","c)
        Dim alpha As Integer = 255
        Dim red As Integer = Integer.Parse(components(0).Trim())
        Dim green As Integer = Integer.Parse(components(1).Trim())
        Dim blue As Integer = Integer.Parse(components(2).Trim())
        Return Color.FromArgb(alpha, red, green, blue)
    End Function

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class
