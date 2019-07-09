Imports Microsoft.Win32

Public Class ClassRegistry
    Enum ENUM_SELECTION_MODEL
        [SINGLE]
        PLAYER
        DOCUMENT
    End Enum

    Public Shared Sub SetAssociation(sProgID As String, sExtension As String, sCommand As String, sIconFile As String, sDefaultIcon As String, iSelectionModel As ENUM_SELECTION_MODEL)
        If (String.IsNullOrEmpty(sProgID)) Then
            Throw New ArgumentException("ProgID invalid")
        End If

        If (String.IsNullOrEmpty(sExtension)) Then
            Throw New ArgumentException("Extension invalid")
        End If

        Using mClassesKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Classes", True)
            If (mClassesKey Is Nothing) Then
                Return
            End If

            Using mExtKey = mClassesKey.CreateSubKey(sProgID)
                Using mShellKey = mExtKey.CreateSubKey("DefaultIcon")
                    mShellKey.SetValue("", """" & sDefaultIcon & """,0")
                End Using

                Using mShellKey = mExtKey.CreateSubKey("Shell")
                    Using mTextKey = mShellKey.CreateSubKey("Open")
                        mTextKey.SetValue("Icon", """" & sIconFile & """")

                        Select Case (iSelectionModel)
                            Case ENUM_SELECTION_MODEL.SINGLE
                                mTextKey.SetValue("MultiSelectModel", "Single")
                            Case ENUM_SELECTION_MODEL.PLAYER
                                mTextKey.SetValue("MultiSelectModel", "Player")
                            Case ENUM_SELECTION_MODEL.DOCUMENT
                                mTextKey.SetValue("MultiSelectModel", "Document")
                            Case Else
                                Throw New ArgumentException("Unknown selection model")
                        End Select

                        Using mCommandKey = mTextKey.CreateSubKey("command")
                            mCommandKey.SetValue("", sCommand)
                        End Using
                    End Using
                End Using
            End Using

            Using mExtKey = mClassesKey.CreateSubKey(sExtension)
                mExtKey.SetValue("", sProgID)
            End Using
        End Using
    End Sub

    Public Shared Sub RemoveAssociation(sProgID As String)
        If (String.IsNullOrEmpty(sProgID)) Then
            Throw New ArgumentException("ProgID invalid")
        End If

        Using mClassesKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Classes", True)
            If (mClassesKey Is Nothing) Then
                Return
            End If

            Using mExtKey = mClassesKey.OpenSubKey(sProgID)
                If (mExtKey Is Nothing) Then
                    Return
                End If
            End Using

            mClassesKey.DeleteSubKeyTree(sProgID)
        End Using

    End Sub


    Public Shared Sub SetExplorerContextMenu(sExtension As String, sContextText As String, sCommand As String, sIconFile As String)
        Using mClassesKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Classes", True)
            If (mClassesKey Is Nothing) Then
                Return
            End If

            Using mExtKey = mClassesKey.CreateSubKey(sExtension)
                Using mShellKey = mExtKey.CreateSubKey("Shell")
                    Using mTextKey = mShellKey.CreateSubKey(sContextText)
                        mTextKey.SetValue("Icon", """" & sIconFile & """")

                        Using mCommandKey = mTextKey.CreateSubKey("command")
                            mCommandKey.SetValue("", sCommand)
                        End Using
                    End Using
                End Using
            End Using
        End Using
    End Sub

    Public Shared Sub RemoveExplorerContextMenu(sExtension As String, sContextText As String)
        Using mClassesKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Classes", True)
            If (mClassesKey Is Nothing) Then
                Return
            End If

            Using mExtKey = mClassesKey.OpenSubKey(sExtension, True)
                If (mExtKey Is Nothing) Then
                    Return
                End If

                Using mShellKey = mExtKey.OpenSubKey("Shell", True)
                    If (mShellKey Is Nothing) Then
                        Return
                    End If

                    Using mContextKey = mShellKey.OpenSubKey(sContextText, True)
                        If (mContextKey Is Nothing) Then
                            Return
                        End If
                    End Using

                    mShellKey.DeleteSubKeyTree(sContextText)
                End Using
            End Using
        End Using
    End Sub
End Class
