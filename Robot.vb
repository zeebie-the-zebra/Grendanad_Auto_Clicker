Imports System.Threading
Imports System.Text.RegularExpressions
Module Robot

    Private Declare Function GetForegroundWindow Lib "user32" () As IntPtr

    Private Declare Auto Function GetWindowText Lib "user32" (ByVal hWnd As System.IntPtr,
                                                              ByVal lpString As System.Text.StringBuilder,
                                                              ByVal cch As Integer) As Integer

    Public Declare Sub mouse_event Lib "user32" (ByVal dwFlags As UInteger,
                                                 ByVal dx As UInteger,
                                                 ByVal dy As UInteger,
                                                 ByVal dwData As UInteger,
                                                 ByVal dwExtraInfo As Integer)

    Const MOUSEEVENTF_LEFTDOWN As UInteger = &H2
    Const MOUSEEVENTF_LEFTUP As UInteger = &H4
    Const MOUSEEVENTF_RIGHTDOWN As UInteger = &H8
    Const MOUSEEVENTF_RIGHTUP As UInteger = &H10

    Public Function GetActiveWindowTitle() As String
        Dim title As New System.Text.StringBuilder(256)
        Dim hWnd As IntPtr = GetForegroundWindow()
        GetWindowText(hWnd, title, title.Capacity)
        Return title.ToString
    End Function
    Public Function WaitForWindow(title As String, seconds As Integer)
        Dim start As DateTime
        Dim activeTitle As String = ""

        start = Now

        While Not activeTitle.ToLower.Contains(title.ToLower)
            activeTitle = GetActiveWindowTitle()
            If TimedOut(start, seconds) Then
                Return 1

            End If
        End While
    End Function

    Public Function TimedOut(start As DateTime, seconds As Integer)
        Return DateDiff(DateInterval.Second, start, Now) > seconds
    End Function

    Public Sub Wait(seconds As Double)
        Thread.Sleep(1000 * seconds)



    End Sub

    Public Sub Type(str As String, count As Integer)
        str = Regex.Replace(str, "[+^%~(){}]", "{$0}")

        For i = 1 To count
            SendKeys.SendWait(str)
        Next
    End Sub

    Public Sub PressEnterKey(count As Integer)
        For i = 1 To count
            SendKeys.Send("{Enter}")
        Next
    End Sub

    Public Sub PressTabKey(count As Integer)
        For i = 1 To count
            SendKeys.Send("{Tab}")
            Wait(0.1)
        Next
    End Sub
    Public Sub PressDeleteKey(count As Integer)
        For i = 1 To count
            SendKeys.Send("{Del}")
        Next
    End Sub
    Public Sub PressLeftKey(count As Integer)
        For i = 1 To count
            SendKeys.Send("{Left}")
            Wait(0.1)
        Next
    End Sub
    Public Sub PressRightKey(count As Integer)
        For i = 1 To count
            SendKeys.Send("{Right}")
            Wait(0.1)
        Next
    End Sub
    Public Sub PressDownKey(count As Integer)
        For i = 1 To count
            SendKeys.Send("{Down}")
            Wait(0.1)
        Next
    End Sub
    Public Sub PressUpKey(count As Integer)
        For i = 1 To count
            SendKeys.Send("{Up}")
            Wait(0.1)
        Next
    End Sub

    Public Sub LeftClick(x As Integer, y As Integer, count As Integer)
        Cursor.Position = New Point(x, y)

        For i = 1 To count
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
            Thread.Sleep(100)
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)
            Wait(0.1)

        Next
    End Sub

    Public Sub RightClick(x As Integer, y As Integer, count As Integer)
        Cursor.Position = New Point(x, y)

        For i = 1 To count
            mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0)
            Thread.Sleep(100)
            mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0)
            Wait(0.1)

        Next
    End Sub


End Module
