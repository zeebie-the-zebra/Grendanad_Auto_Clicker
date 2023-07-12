<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
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
        Me.components = New System.ComponentModel.Container()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.PresetRat = New System.Windows.Forms.Button()
        Me.PresetGoblin = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PresetGreenSlime = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.LoadPresets = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.StatusStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(822, 85)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(172, 61)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Start"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(40, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Mouse Coords"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(130, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "X = 0, Y = 0"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(822, 152)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(172, 61)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Stop"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(57, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Colour 1"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(57, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 15)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Colour 2"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 539)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1006, 22)
        Me.StatusStrip1.TabIndex = 10
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(87, 17)
        Me.ToolStripStatusLabel1.Text = "Active Window"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(115, 56)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(68, 24)
        Me.Button3.TabIndex = 11
        Me.Button3.Text = "Change"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(115, 85)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(68, 24)
        Me.Button4.TabIndex = 12
        Me.Button4.Text = "Change"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(220, 55)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(581, 377)
        Me.Panel1.TabIndex = 14
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(12, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(555, 363)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(232, 444)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 15)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Image Processeing"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(220, 32)
        Me.Label6.MinimumSize = New System.Drawing.Size(0, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(549, 15)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Set Colour 1 to Goblin Colour, then click on start, then go to your chrome browse" &
    "r with Genfanad open"
        '
        'PresetRat
        '
        Me.PresetRat.Location = New System.Drawing.Point(28, 152)
        Me.PresetRat.Name = "PresetRat"
        Me.PresetRat.Size = New System.Drawing.Size(68, 39)
        Me.PresetRat.TabIndex = 17
        Me.PresetRat.Text = "Black Rats"
        Me.PresetRat.UseVisualStyleBackColor = True
        '
        'PresetGoblin
        '
        Me.PresetGoblin.Location = New System.Drawing.Point(102, 152)
        Me.PresetGoblin.Name = "PresetGoblin"
        Me.PresetGoblin.Size = New System.Drawing.Size(68, 39)
        Me.PresetGoblin.TabIndex = 18
        Me.PresetGoblin.Text = "Goblins"
        Me.PresetGoblin.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(28, 60)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(23, 16)
        Me.PictureBox2.TabIndex = 19
        Me.PictureBox2.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(117, 444)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 15)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Target Coords"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(120, 470)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(14, 15)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "X"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(183, 470)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(14, 15)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Y"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(232, 468)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 15)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Click Time"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(822, 56)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(130, 23)
        Me.TextBox1.TabIndex = 24
        Me.TextBox1.Text = "45"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(826, 38)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(111, 15)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "Kill Timer (Seconds)"
        '
        'PictureBox3
        '
        Me.PictureBox3.Location = New System.Drawing.Point(29, 89)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(23, 16)
        Me.PictureBox3.TabIndex = 26
        Me.PictureBox3.TabStop = False
        '
        'PresetGreenSlime
        '
        Me.PresetGreenSlime.Location = New System.Drawing.Point(28, 197)
        Me.PresetGreenSlime.Name = "PresetGreenSlime"
        Me.PresetGreenSlime.Size = New System.Drawing.Size(68, 39)
        Me.PresetGreenSlime.TabIndex = 27
        Me.PresetGreenSlime.Text = "Green Slime"
        Me.PresetGreenSlime.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(40, 131)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(117, 15)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "Quick Colour Presets"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(826, 221)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(69, 15)
        Me.Label13.TabIndex = 29
        Me.Label13.Text = "Version 0.03"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(102, 197)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(68, 39)
        Me.Button5.TabIndex = 30
        Me.Button5.Text = "Blue Frogs"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(822, 366)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(172, 61)
        Me.Button6.TabIndex = 31
        Me.Button6.Text = "GrayScaleScreenshot"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(822, 299)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(172, 61)
        Me.Button7.TabIndex = 32
        Me.Button7.Text = "GrayScaleSearch"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.CheckOnClick = True
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.HorizontalScrollbar = True
        Me.CheckedListBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CheckedListBox1.Location = New System.Drawing.Point(29, 271)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(142, 112)
        Me.CheckedListBox1.TabIndex = 33
        '
        'LoadPresets
        '
        Me.LoadPresets.Location = New System.Drawing.Point(29, 389)
        Me.LoadPresets.Name = "LoadPresets"
        Me.LoadPresets.Size = New System.Drawing.Size(142, 39)
        Me.LoadPresets.TabIndex = 34
        Me.LoadPresets.Text = "Load Presets"
        Me.LoadPresets.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(40, 244)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(89, 15)
        Me.Label14.TabIndex = 35
        Me.Label14.Text = "Custom Presets"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(823, 281)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(171, 15)
        Me.Label15.TabIndex = 36
        Me.Label15.Text = "Do not use feature not working"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1006, 561)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.LoadPresets)
        Me.Controls.Add(Me.CheckedListBox1)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.PresetGreenSlime)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PresetGoblin)
        Me.Controls.Add(Me.PresetRat)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Leona's Mouse Clicker"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Timer2 As Timer
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents PresetRat As Button
    Friend WithEvents PresetGoblin As Button
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PresetGreenSlime As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents CheckedListBox1 As CheckedListBox
    Friend WithEvents LoadPresets As Button
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
End Class
