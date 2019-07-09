Public Class FormMain
    Private g_bComboBoxIgnoreEvent As Boolean = False
    Private g_sImageFileExtensions As String() = {"png", "bmp", "jpg", "jpeg", "gif", "swf", "ico"}
    Private g_sImageFile As String = ""

    Private g_mClassFileFinder As ClassFileFinder
    Private g_mClassImageControl As ClassImageControl

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ClassSettings.LoadSettings()

        g_mClassImageControl = New ClassImageControl(Me) With {
            .m_ImageQuality = ClassSettings.m_ImageQuality
        }

        g_bComboBoxIgnoreEvent = True
        ToolStripComboBox_Quality.Items.Clear()
        ToolStripComboBox_Quality.Items.Add("Fast")
        ToolStripComboBox_Quality.Items.Add("High Quality")
        ToolStripComboBox_Quality.SelectedIndex = ClassSettings.m_ImageQuality
        g_bComboBoxIgnoreEvent = False

        If (ClassSettings.m_DisplayFlash) Then
            ToolStripMenuItem_FlashOn.Checked = True
            ToolStripMenuItem_FlashOff.Checked = False
        Else
            ToolStripMenuItem_FlashOn.Checked = False
            ToolStripMenuItem_FlashOff.Checked = True
        End If

        For i = 1 To Environment.GetCommandLineArgs.Count - 1
            If (IO.File.Exists(Environment.GetCommandLineArgs(i))) Then
                OpenFile(Environment.GetCommandLineArgs(i))
                Exit For
            End If
        Next
    End Sub

    Private Sub ToolStripMenuItem_Open_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem_Open.Click
        Using i As New OpenFileDialog
            i.Filter = "All files|*.*|Supported files|*.png;*.bmp;*.jpg;*.jpeg;*.gif;*.swf;*.ico"

            If (i.ShowDialog = DialogResult.OK) Then
                OpenFile(i.FileName)
            End If
        End Using
    End Sub

    Private Sub ToolStripComboBox_Quality_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ToolStripComboBox_Quality.SelectedIndexChanged
        If (g_bComboBoxIgnoreEvent) Then
            Return
        End If

        ClassSettings.m_ImageQuality = CType(ToolStripComboBox_Quality.SelectedIndex, ClassSettings.ENUM_IMAGE_QUALITY)
        ClassSettings.SaveSettings()

        g_mClassImageControl.m_ImageQuality = ClassSettings.m_ImageQuality
    End Sub

    Private Sub ToolStripComboBox_Quality_DropDown(sender As Object, e As EventArgs) Handles ToolStripComboBox_Quality.DropDown
        g_bComboBoxIgnoreEvent = True
        ToolStripComboBox_Quality.SelectedIndex = ClassSettings.m_ImageQuality
        g_bComboBoxIgnoreEvent = False
    End Sub

    Private Sub ToolStripMenuItem_Association_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem_Association.Click
        For i = 0 To g_sImageFileExtensions.Length - 1
            ClassRegistry.SetAssociation(String.Format("SysPicView.{0}", g_sImageFileExtensions(i).ToUpper), String.Format(".{0}", g_sImageFileExtensions(i)), String.Format("""{0}"" ""%1""", Application.ExecutablePath), Application.ExecutablePath, Application.ExecutablePath, ClassRegistry.ENUM_SELECTION_MODEL.PLAYER)
        Next
    End Sub

    Private Sub ToolStripMenuItem_FlashOn_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem_FlashOn.Click
        ClassSettings.m_DisplayFlash = True

        ToolStripMenuItem_FlashOn.Checked = True
        ToolStripMenuItem_FlashOff.Checked = False

        ClassSettings.SaveSettings()
    End Sub

    Private Sub ToolStripMenuItem_FlashOff_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem_FlashOff.Click
        ClassSettings.m_DisplayFlash = False

        ToolStripMenuItem_FlashOn.Checked = False
        ToolStripMenuItem_FlashOff.Checked = True

        ClassSettings.SaveSettings()
    End Sub

    Private Sub ToolStripMenuItem_Flash_DropDownOpening(sender As Object, e As EventArgs) Handles ToolStripMenuItem_Flash.DropDownOpening
        If (ClassSettings.m_DisplayFlash) Then
            ToolStripMenuItem_FlashOn.Checked = True
            ToolStripMenuItem_FlashOff.Checked = False
        Else
            ToolStripMenuItem_FlashOn.Checked = False
            ToolStripMenuItem_FlashOff.Checked = True
        End If
    End Sub

    Private Sub ToolStripMenuItem_Exit_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem_Exit.Click
        Me.Close()
    End Sub


    Private Sub OpenFile(sPath As String)
        Dim sFile As String = IO.Path.GetFullPath(sPath)
        Dim sDirectory As String = IO.Path.GetDirectoryName(sPath)

        g_mClassFileFinder = New ClassFileFinder(Me, sDirectory, sFile)
        g_mClassImageControl.ReloadImage()
        g_mClassImageControl.CenterImage()
    End Sub

    Private Sub ToolStripMenuItem_Next_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem_Next.Click
        If (g_mClassFileFinder Is Nothing) Then
            Return
        End If

        g_mClassFileFinder.FindNext()
        g_mClassImageControl.ReloadImage()
        g_mClassImageControl.CenterImage()
    End Sub

    Private Sub ToolStripMenuItem_Previous_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem_Previous.Click
        If (g_mClassFileFinder Is Nothing) Then
            Return
        End If

        g_mClassFileFinder.FindPrevious()
        g_mClassImageControl.ReloadImage()
        g_mClassImageControl.CenterImage()
    End Sub

    Private Sub ToolStripMenuItem_Full_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem_Full.Click
        g_mClassImageControl.AutosizeZoom()
        g_mClassImageControl.CenterImage()
    End Sub

    Private Sub ToolStripMenuItem_Fit_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem_Fit.Click
        g_mClassImageControl.FitZoom()
        g_mClassImageControl.CenterImage()
    End Sub

    Private Sub ToolStripMenuItem_Center_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem_Center.Click
        g_mClassImageControl.CenterImage()
    End Sub

    Private Sub FormMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CleanUp()
    End Sub

    Private Sub CleanUp()
        If (g_mClassImageControl IsNot Nothing) Then
            g_mClassImageControl.Dispose()
            g_mClassImageControl = Nothing
        End If
    End Sub

    Class ClassFileFinder
        Private g_mFormMain As FormMain

        Private g_lFiles As New List(Of String)
        Private g_iFileIndex As Integer = 0
        Private g_sCurrentFile As String = ""

        Public Sub New(mFormMain As FormMain, sDirectory As String, Optional sSelectedFile As String = Nothing)
            g_mFormMain = mFormMain

            sSelectedFile = sSelectedFile.ToLower

            'Gather all files from the directory
            g_lFiles.Clear()
            For Each sFile In IO.Directory.GetFiles(sDirectory)
                If (Array.IndexOf(g_mFormMain.g_sImageFileExtensions, IO.Path.GetExtension(sFile).TrimStart("."c)) = -1) Then
                    Continue For
                End If

                g_lFiles.Add(sFile.ToLower)
            Next

            'Find index of current file
            If (Not String.IsNullOrEmpty(sSelectedFile)) Then
                For i = 0 To g_lFiles.Count - 1
                    If (g_lFiles(i) <> sSelectedFile) Then
                        Continue For
                    End If

                    g_iFileIndex = i
                    g_sCurrentFile = sSelectedFile
                    Exit For
                Next
            End If
        End Sub

        Public Sub FindNext()
            If (g_lFiles.Count < 1) Then
                Return
            End If

            For i = g_iFileIndex + 1 To g_lFiles.Count - 1
                If (Not IO.File.Exists(g_lFiles(i))) Then
                    Continue For
                End If

                If (Not ClassSettings.m_DisplayFlash) Then
                    If (IO.Path.GetExtension(g_lFiles(i)).ToLower = ".swf") Then
                        Continue For
                    End If
                End If

                g_iFileIndex = i
                g_sCurrentFile = g_lFiles(i)
                Exit For
            Next
        End Sub

        Public Sub FindPrevious()
            If (g_lFiles.Count < 1) Then
                Return
            End If

            For i = g_iFileIndex - 1 To 0 Step -1
                If (Not IO.File.Exists(g_lFiles(i))) Then
                    Continue For
                End If

                If (Not ClassSettings.m_DisplayFlash) Then
                    If (IO.Path.GetExtension(g_lFiles(i)).ToLower = ".swf") Then
                        Continue For
                    End If
                End If

                g_iFileIndex = i
                g_sCurrentFile = g_lFiles(i)
                Exit For
            Next
        End Sub

        ReadOnly Property m_CurrentFile As String
            Get
                Return g_sCurrentFile
            End Get
        End Property
    End Class

    Class ClassImageControl
        Implements IDisposable

        Private g_mFormMain As FormMain

        Private g_mImageControl As ClassPictureBoxQuality
        Private g_mFlashControl As WebBrowser

        Private g_mImage As Image

        Public Sub New(mFormMain As FormMain)
            g_mFormMain = mFormMain

            Try
                g_mImageControl = New ClassPictureBoxQuality With {
                    .m_HighQuality = (ClassSettings.m_ImageQuality = ClassSettings.ENUM_IMAGE_QUALITY.HIGH_QUALITY),
                    .Parent = g_mFormMain,
                    .Anchor = AnchorStyles.None,
                    .BorderStyle = BorderStyle.FixedSingle,
                    .Visible = False
                }

                If (g_mImageControl IsNot Nothing) Then
                    RemoveHandler g_mImageControl.MouseMove, AddressOf OnMoveImage
                    RemoveHandler g_mImageControl.MouseDown, AddressOf OnMoveImageBegin
                    RemoveHandler g_mImageControl.MouseUp, AddressOf OnMoveImageEnd
                    RemoveHandler g_mFormMain.MouseWheel, AddressOf OnZoomImage
                    AddHandler g_mImageControl.MouseMove, AddressOf OnMoveImage
                    AddHandler g_mImageControl.MouseDown, AddressOf OnMoveImageBegin
                    AddHandler g_mImageControl.MouseUp, AddressOf OnMoveImageEnd
                    AddHandler g_mFormMain.MouseWheel, AddressOf OnZoomImage
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Unable to create image viewer", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            Try
                g_mFlashControl = New WebBrowser With {
                    .ScriptErrorsSuppressed = True,
                    .Parent = g_mFormMain,
                    .Dock = DockStyle.Fill,
                    .Visible = False
                }
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Unable to create flash viewer", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Property m_ImageQuality As ClassSettings.ENUM_IMAGE_QUALITY
            Get
                If (g_mImageControl Is Nothing OrElse g_mImageControl.IsDisposed) Then
                    Return ClassSettings.ENUM_IMAGE_QUALITY.FAST
                End If

                If (g_mImageControl.m_HighQuality) Then
                    Return ClassSettings.ENUM_IMAGE_QUALITY.HIGH_QUALITY
                Else
                    Return ClassSettings.ENUM_IMAGE_QUALITY.FAST
                End If
            End Get
            Set(value As ClassSettings.ENUM_IMAGE_QUALITY)
                If (g_mImageControl Is Nothing OrElse g_mImageControl.IsDisposed) Then
                    Return
                End If

                g_mImageControl.m_HighQuality = (ClassSettings.m_ImageQuality = ClassSettings.ENUM_IMAGE_QUALITY.HIGH_QUALITY)
                g_mImageControl.Refresh()
            End Set
        End Property

        Public Sub ReloadImage()
            g_mFormMain.SuspendLayout()

            Dim sFile As String = g_mFormMain.g_mClassFileFinder.m_CurrentFile
            If (Not IO.File.Exists(sFile)) Then
                ResetImageControl()
                ResetFlashControl()

                Return
            End If

            Select Case (IO.Path.GetExtension(sFile))
                Case ".swf"
                    'Disable Image Control
                    ResetImageControl()

                    'Enable Flash Control
                    If (g_mFlashControl IsNot Nothing) Then
                        g_mFlashControl.Visible = True
                        g_mFlashControl.Navigate(sFile)
                    End If

                Case Else
                    'Disable Flash Control
                    ResetFlashControl()

                    'Enable Image Control
                    g_mImage = New Bitmap(sFile)

                    If (g_mImageControl IsNot Nothing AndAlso Not g_mImageControl.IsDisposed) Then
                        g_mImageControl.Visible = True
                        g_mImageControl.Image = g_mImage

                        g_mImageControl.SizeMode = PictureBoxSizeMode.AutoSize
                        FitZoom()
                    End If
            End Select

            g_mFormMain.ResumeLayout()
        End Sub

        Public Sub CenterImage()
            If (g_mImageControl Is Nothing OrElse g_mImageControl.IsDisposed) Then
                Return
            End If

            g_mImageControl.Location = New Point(CInt((g_mImageControl.Parent.ClientSize.Width / 2) - (g_mImageControl.Width / 2)),
                                                    CInt((g_mImageControl.Parent.ClientSize.Height / 2) - (g_mImageControl.Height / 2)))
        End Sub

        Public Sub AutosizeZoom()
            If (g_mImageControl Is Nothing OrElse g_mImageControl.IsDisposed) Then
                Return
            End If

            If (g_mImageControl.Image Is Nothing) Then
                Return
            End If

            g_mImageControl.SuspendLayout()
            g_mImageControl.SizeMode = PictureBoxSizeMode.Zoom
            g_mImageControl.Size = Squere(g_mImageControl.Image.Size)
            g_mImageControl.ResumeLayout()
        End Sub

        Public Sub FitZoom()
            If (g_mImageControl Is Nothing OrElse g_mImageControl.IsDisposed) Then
                Return
            End If

            If (g_mImageControl.Image Is Nothing) Then
                Return
            End If

            g_mImageControl.SuspendLayout()
            g_mImageControl.SizeMode = PictureBoxSizeMode.Zoom
            g_mImageControl.Size = Squere(g_mImageControl.Image.Size)

            Dim iAspectRatio As Double = 1.0
            If (g_mImageControl.Size.Width > g_mImageControl.Size.Height) Then
                iAspectRatio = (g_mFormMain.ClientSize.Width / g_mImageControl.Image.Size.Width)
            Else
                iAspectRatio = (g_mFormMain.ClientSize.Height / g_mImageControl.Image.Size.Height)
            End If

            g_mImageControl.Size = Squere(New Size(CInt(g_mImageControl.Size.Width * iAspectRatio), CInt(g_mImageControl.Size.Height * iAspectRatio)))
            g_mImageControl.ResumeLayout()
        End Sub

        Public Sub ResetImageControl()
            If (g_mImage IsNot Nothing) Then
                g_mImage.Dispose()
                g_mImage = Nothing
            End If

            If (g_mImageControl IsNot Nothing AndAlso Not g_mImageControl.IsDisposed) Then
                g_mImageControl.Visible = False
                g_mImageControl.Image = g_mImage
            End If
        End Sub

        Public Sub ResetFlashControl()
            If (g_mFlashControl Is Nothing) Then
                Return
            End If

            g_mFlashControl.Visible = False

            If (g_mFlashControl.Url Is Nothing OrElse g_mFlashControl.Url.AbsoluteUri.ToLower <> "about:blank") Then
                g_mFlashControl.Navigate("about:blank")
            End If
        End Sub

        'TODO: Fix zoom and remove this
        Private Function Squere(i As Size) As Size
            If (i.Width > i.Height) Then
                i.Height = i.Width
            End If

            If (i.Height > i.Width) Then
                i.Width = i.Height
            End If

            Return i
        End Function

        Private g_bDragging As Boolean = False
        Private g_iDragPoint As Point
        Private Sub OnMoveImageBegin(sender As Object, e As MouseEventArgs)
            If (g_mImageControl Is Nothing OrElse g_mImageControl.IsDisposed) Then
                Return
            End If

            If (e.Button <> MouseButtons.Left) Then
                Return
            End If

            g_bDragging = True
            g_iDragPoint = New Point(e.X, e.Y)
            g_mImageControl.Cursor = Cursors.SizeAll
        End Sub

        Private Sub OnMoveImageEnd(sender As Object, e As MouseEventArgs)
            If (g_mImageControl Is Nothing OrElse g_mImageControl.IsDisposed) Then
                Return
            End If

            If (e.Button <> MouseButtons.Left) Then
                Return
            End If

            g_bDragging = False
            g_mImageControl.Cursor = Cursors.Default
        End Sub

        Private Sub OnMoveImage(sender As Object, e As MouseEventArgs)
            If (g_mImageControl Is Nothing OrElse g_mImageControl.IsDisposed) Then
                Return
            End If

            If (Not g_bDragging) Then
                Return
            End If

            g_mImageControl.Top = g_mImageControl.Top + e.Y - g_iDragPoint.Y
            g_mImageControl.Left = g_mImageControl.Left + e.X - g_iDragPoint.X
        End Sub

        Private Sub OnZoomImage(sender As Object, e As MouseEventArgs)
            If (g_mImageControl Is Nothing OrElse g_mImageControl.IsDisposed) Then
                Return
            End If

            If (e.Delta = 0) Then
                Return
            End If

            Dim iImageSize = g_mImageControl.Size
            Dim iFactor = CInt(e.Delta / 2) * Math.Max(CInt(iImageSize.Width / 360), 1)
            Dim iNewImageSize = iImageSize + New Size(iFactor, iFactor)
            Dim iDiffImageSize = iNewImageSize - iImageSize

            'Min/Max size
            If (iNewImageSize.Width > (1 << 14) OrElse iNewImageSize.Height > (1 << 14)) Then
                Return
            End If

            If (iNewImageSize.Width < 16 OrElse iNewImageSize.Height < 16) Then
                Return
            End If

            g_mImageControl.SuspendLayout()
            g_mImageControl.Size = iNewImageSize
            g_mImageControl.Location -= New Size(CInt(iDiffImageSize.Width / 2), CInt(iDiffImageSize.Height / 2))
            g_mImageControl.ResumeLayout()
        End Sub

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    ' TODO: dispose managed state (managed objects).
                    If (g_mImageControl IsNot Nothing) Then
                        RemoveHandler g_mImageControl.MouseMove, AddressOf OnMoveImage
                        RemoveHandler g_mImageControl.MouseDown, AddressOf OnMoveImageBegin
                        RemoveHandler g_mImageControl.MouseUp, AddressOf OnMoveImageEnd
                        RemoveHandler g_mFormMain.MouseWheel, AddressOf OnZoomImage
                    End If

                    If (g_mImageControl IsNot Nothing AndAlso Not g_mImageControl.IsDisposed) Then
                        g_mImageControl.Dispose()
                        g_mImageControl = Nothing
                    End If

                    If (g_mFlashControl IsNot Nothing AndAlso Not g_mFlashControl.IsDisposed) Then
                        g_mFlashControl.Dispose()
                        g_mFlashControl = Nothing
                    End If
                End If

                ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
                ' TODO: set large fields to null.
            End If
            disposedValue = True
        End Sub

        ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
        'Protected Overrides Sub Finalize()
        '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        '    Dispose(False)
        '    MyBase.Finalize()
        'End Sub

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
            Dispose(True)
            ' TODO: uncomment the following line if Finalize() is overridden above.
            ' GC.SuppressFinalize(Me)
        End Sub
#End Region
    End Class
End Class
