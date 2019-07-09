Public Class ClassSettings
    Shared ReadOnly g_sSettingsPath As String = IO.Path.Combine(Application.StartupPath, "SysPicViewSettings.ini")

    Enum ENUM_IMAGE_QUALITY
        FAST
        HIGH_QUALITY
    End Enum

    Shared Property m_ImageQuality As ENUM_IMAGE_QUALITY = ENUM_IMAGE_QUALITY.FAST
    Shared Property m_DisplayFlash As Boolean = True

    Shared Sub LoadSettings()
        Using mIni As New ClassIni(g_sSettingsPath, IO.FileMode.OpenOrCreate)
            Dim iImageQuality As Integer
            If (Integer.TryParse(mIni.ReadKeyValue("Settings", "ImageQuality", CStr(ENUM_IMAGE_QUALITY.FAST)), iImageQuality)) Then
                Select Case (iImageQuality)
                    Case ENUM_IMAGE_QUALITY.FAST, ENUM_IMAGE_QUALITY.HIGH_QUALITY
                        m_ImageQuality = CType(iImageQuality, ENUM_IMAGE_QUALITY)
                    Case Else
                        m_ImageQuality = ENUM_IMAGE_QUALITY.FAST
                End Select
            Else
                m_ImageQuality = ENUM_IMAGE_QUALITY.FAST
            End If

            m_DisplayFlash = (mIni.ReadKeyValue("Settings", "DisplayFlash", "1") <> "0")
        End Using
    End Sub
    Shared Sub SaveSettings()
        Using mIni As New ClassIni(g_sSettingsPath, IO.FileMode.OpenOrCreate)
            mIni.WriteKeyValue("Settings", "ImageQuality", CStr(m_ImageQuality))
            mIni.WriteKeyValue("Settings", "DisplayFlash", If(m_DisplayFlash, "1", "0"))
        End Using
    End Sub
End Class
