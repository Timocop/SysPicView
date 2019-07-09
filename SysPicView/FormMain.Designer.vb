<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If (disposing) Then
                CleanUp()
            End If

            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem_File = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Open = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Exit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Settings = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Quality = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripComboBox_Quality = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripMenuItem_Flash = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_FlashOn = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_FlashOff = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Association = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Previous = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Next = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Center = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Fit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Full = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem_File, Me.ToolStripMenuItem_Settings, Me.ToolStripMenuItem_Previous, Me.ToolStripMenuItem_Next, Me.ToolStripMenuItem_Center, Me.ToolStripMenuItem_Fit, Me.ToolStripMenuItem_Full})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(784, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem_File
        '
        Me.ToolStripMenuItem_File.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem_Open, Me.ToolStripMenuItem_Exit})
        Me.ToolStripMenuItem_File.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem_File.Image = CType(resources.GetObject("ToolStripMenuItem_File.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem_File.Name = "ToolStripMenuItem_File"
        Me.ToolStripMenuItem_File.Size = New System.Drawing.Size(53, 20)
        Me.ToolStripMenuItem_File.Text = "File"
        '
        'ToolStripMenuItem_Open
        '
        Me.ToolStripMenuItem_Open.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripMenuItem_Open.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem_Open.Image = CType(resources.GetObject("ToolStripMenuItem_Open.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem_Open.Name = "ToolStripMenuItem_Open"
        Me.ToolStripMenuItem_Open.Size = New System.Drawing.Size(180, 22)
        Me.ToolStripMenuItem_Open.Text = "Open"
        '
        'ToolStripMenuItem_Exit
        '
        Me.ToolStripMenuItem_Exit.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripMenuItem_Exit.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem_Exit.Image = CType(resources.GetObject("ToolStripMenuItem_Exit.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem_Exit.Name = "ToolStripMenuItem_Exit"
        Me.ToolStripMenuItem_Exit.Size = New System.Drawing.Size(180, 22)
        Me.ToolStripMenuItem_Exit.Text = "Close"
        '
        'ToolStripMenuItem_Settings
        '
        Me.ToolStripMenuItem_Settings.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem_Quality, Me.ToolStripMenuItem_Flash, Me.ToolStripMenuItem_Association})
        Me.ToolStripMenuItem_Settings.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem_Settings.Image = CType(resources.GetObject("ToolStripMenuItem_Settings.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem_Settings.Name = "ToolStripMenuItem_Settings"
        Me.ToolStripMenuItem_Settings.Size = New System.Drawing.Size(77, 20)
        Me.ToolStripMenuItem_Settings.Text = "Settings"
        '
        'ToolStripMenuItem_Quality
        '
        Me.ToolStripMenuItem_Quality.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripMenuItem_Quality.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripComboBox_Quality})
        Me.ToolStripMenuItem_Quality.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem_Quality.Image = CType(resources.GetObject("ToolStripMenuItem_Quality.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem_Quality.Name = "ToolStripMenuItem_Quality"
        Me.ToolStripMenuItem_Quality.Size = New System.Drawing.Size(180, 22)
        Me.ToolStripMenuItem_Quality.Text = "Image quality"
        '
        'ToolStripComboBox_Quality
        '
        Me.ToolStripComboBox_Quality.AutoSize = False
        Me.ToolStripComboBox_Quality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ToolStripComboBox_Quality.DropDownWidth = 180
        Me.ToolStripComboBox_Quality.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ToolStripComboBox_Quality.Name = "ToolStripComboBox_Quality"
        Me.ToolStripComboBox_Quality.Size = New System.Drawing.Size(180, 23)
        '
        'ToolStripMenuItem_Flash
        '
        Me.ToolStripMenuItem_Flash.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripMenuItem_Flash.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem_FlashOn, Me.ToolStripMenuItem_FlashOff})
        Me.ToolStripMenuItem_Flash.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem_Flash.Image = CType(resources.GetObject("ToolStripMenuItem_Flash.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem_Flash.Name = "ToolStripMenuItem_Flash"
        Me.ToolStripMenuItem_Flash.Size = New System.Drawing.Size(180, 22)
        Me.ToolStripMenuItem_Flash.Text = "Display flash (*.swf)"
        '
        'ToolStripMenuItem_FlashOn
        '
        Me.ToolStripMenuItem_FlashOn.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripMenuItem_FlashOn.Checked = True
        Me.ToolStripMenuItem_FlashOn.CheckOnClick = True
        Me.ToolStripMenuItem_FlashOn.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ToolStripMenuItem_FlashOn.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem_FlashOn.Name = "ToolStripMenuItem_FlashOn"
        Me.ToolStripMenuItem_FlashOn.Size = New System.Drawing.Size(180, 22)
        Me.ToolStripMenuItem_FlashOn.Text = "Yes"
        '
        'ToolStripMenuItem_FlashOff
        '
        Me.ToolStripMenuItem_FlashOff.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripMenuItem_FlashOff.CheckOnClick = True
        Me.ToolStripMenuItem_FlashOff.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem_FlashOff.Name = "ToolStripMenuItem_FlashOff"
        Me.ToolStripMenuItem_FlashOff.Size = New System.Drawing.Size(180, 22)
        Me.ToolStripMenuItem_FlashOff.Text = "No"
        '
        'ToolStripMenuItem_Association
        '
        Me.ToolStripMenuItem_Association.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripMenuItem_Association.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem_Association.Image = CType(resources.GetObject("ToolStripMenuItem_Association.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem_Association.Name = "ToolStripMenuItem_Association"
        Me.ToolStripMenuItem_Association.Size = New System.Drawing.Size(180, 22)
        Me.ToolStripMenuItem_Association.Text = "Associate file types"
        '
        'ToolStripMenuItem_Previous
        '
        Me.ToolStripMenuItem_Previous.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem_Previous.Image = CType(resources.GetObject("ToolStripMenuItem_Previous.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem_Previous.Name = "ToolStripMenuItem_Previous"
        Me.ToolStripMenuItem_Previous.Size = New System.Drawing.Size(28, 20)
        '
        'ToolStripMenuItem_Next
        '
        Me.ToolStripMenuItem_Next.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem_Next.Image = CType(resources.GetObject("ToolStripMenuItem_Next.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem_Next.Name = "ToolStripMenuItem_Next"
        Me.ToolStripMenuItem_Next.Size = New System.Drawing.Size(28, 20)
        '
        'ToolStripMenuItem_Center
        '
        Me.ToolStripMenuItem_Center.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripMenuItem_Center.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem_Center.Image = CType(resources.GetObject("ToolStripMenuItem_Center.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem_Center.Name = "ToolStripMenuItem_Center"
        Me.ToolStripMenuItem_Center.Size = New System.Drawing.Size(70, 20)
        Me.ToolStripMenuItem_Center.Text = "Center"
        '
        'ToolStripMenuItem_Fit
        '
        Me.ToolStripMenuItem_Fit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripMenuItem_Fit.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem_Fit.Image = CType(resources.GetObject("ToolStripMenuItem_Fit.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem_Fit.Name = "ToolStripMenuItem_Fit"
        Me.ToolStripMenuItem_Fit.Size = New System.Drawing.Size(48, 20)
        Me.ToolStripMenuItem_Fit.Text = "Fit"
        '
        'ToolStripMenuItem_Full
        '
        Me.ToolStripMenuItem_Full.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripMenuItem_Full.ForeColor = System.Drawing.Color.White
        Me.ToolStripMenuItem_Full.Image = CType(resources.GetObject("ToolStripMenuItem_Full.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem_Full.Name = "ToolStripMenuItem_Full"
        Me.ToolStripMenuItem_Full.Size = New System.Drawing.Size(54, 20)
        Me.ToolStripMenuItem_Full.Text = "Full"
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SysPicView"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ToolStripMenuItem_File As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Settings As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Previous As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Next As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Exit As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Quality As ToolStripMenuItem
    Friend WithEvents ToolStripComboBox_Quality As ToolStripComboBox
    Friend WithEvents ToolStripMenuItem_Flash As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Open As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_FlashOn As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_FlashOff As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Association As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Center As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Fit As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Full As ToolStripMenuItem
End Class
