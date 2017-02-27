Imports System.Threading

Public Class Alarm

    Public u_date As String = Nothing
    Public time As String = Nothing

End Class

Class MainWindow

    Private thread As Thread
    Public alarm_set = False

    Private Sub setAlarm(ByVal param As Object)

        Dim alarm As Alarm = CType(param, Alarm)

        Do
            If DateTime.Now.ToShortTimeString = alarm.time Then
                playAudioClip("sound/audio.wav")
                MessageBox.Show("MONSTER KROD ALARM!!!!")
                stopAudioClip()
                thread.Suspend()
                Exit Do
            End If

            Thread.Sleep(100)
        Loop


    End Sub

    Private Sub playAudioClip(path As String)
        My.Computer.Audio.Play(path, AudioPlayMode.BackgroundLoop)
    End Sub

    Private Sub stopAudioClip()
        My.Computer.Audio.Stop()
    End Sub

    Private Sub btn_etAlarm_Click(sender As Object, e As RoutedEventArgs) Handles btn_etAlarm.Click

        thread = New Thread(AddressOf setAlarm)
        Dim alarm As Alarm = New Alarm
        Dim clockSetup = clk_generalClock

        alarm.time = clockSetup.Time.ToShortTimeString
        alarm.u_date = DateTime.Now.Date.ToShortDateString

        thread.Start(alarm)
        thread.IsBackground = True
    End Sub

End Class
