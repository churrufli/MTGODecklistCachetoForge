<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.log = New System.Windows.Forms.TextBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.cmbformat = New System.Windows.Forms.ComboBox()
        Me.btnzipdecks = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckForANewVersionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbyear = New System.Windows.Forms.ComboBox()
        Me.chkoverwrite = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbcategories = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.txfolder = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.txfind = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txreplace = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'log
        '
        Me.log.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.log.Location = New System.Drawing.Point(16, 233)
        Me.log.Multiline = True
        Me.log.Name = "log"
        Me.log.ReadOnly = True
        Me.log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.log.Size = New System.Drawing.Size(861, 456)
        Me.log.TabIndex = 25
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(227, 34)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(423, 30)
        Me.Button3.TabIndex = 32
        Me.Button3.Text = "Extract Decks"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'cmbformat
        '
        Me.cmbformat.FormattingEnabled = True
        Me.cmbformat.Location = New System.Drawing.Point(336, 22)
        Me.cmbformat.Name = "cmbformat"
        Me.cmbformat.Size = New System.Drawing.Size(121, 24)
        Me.cmbformat.TabIndex = 33
        '
        'btnzipdecks
        '
        Me.btnzipdecks.Location = New System.Drawing.Point(185, 35)
        Me.btnzipdecks.Name = "btnzipdecks"
        Me.btnzipdecks.Size = New System.Drawing.Size(184, 30)
        Me.btnzipdecks.TabIndex = 34
        Me.btnzipdecks.Text = "Zip Decks"
        Me.btnzipdecks.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(892, 28)
        Me.MenuStrip1.TabIndex = 35
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CheckForANewVersionToolStripMenuItem})
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(73, 24)
        Me.OptionsToolStripMenuItem.Text = "Options"
        '
        'CheckForANewVersionToolStripMenuItem
        '
        Me.CheckForANewVersionToolStripMenuItem.Name = "CheckForANewVersionToolStripMenuItem"
        Me.CheckForANewVersionToolStripMenuItem.Size = New System.Drawing.Size(543, 26)
        Me.CheckForANewVersionToolStripMenuItem.Text = "Download Zip of MTGODecklistCachetoForge last version from server"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(434, 35)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(197, 30)
        Me.Button2.TabIndex = 37
        Me.Button2.Text = "Generate list.txt"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(278, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 17)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Format"
        '
        'cmbyear
        '
        Me.cmbyear.FormattingEnabled = True
        Me.cmbyear.Items.AddRange(New Object() {"standard", "modern", "vintage", "legacy", "pauper", "pioneer"})
        Me.cmbyear.Location = New System.Drawing.Point(533, 22)
        Me.cmbyear.Name = "cmbyear"
        Me.cmbyear.Size = New System.Drawing.Size(121, 24)
        Me.cmbyear.TabIndex = 39
        '
        'chkoverwrite
        '
        Me.chkoverwrite.AutoSize = True
        Me.chkoverwrite.Location = New System.Drawing.Point(679, 25)
        Me.chkoverwrite.Name = "chkoverwrite"
        Me.chkoverwrite.Size = New System.Drawing.Size(169, 21)
        Me.chkoverwrite.TabIndex = 41
        Me.chkoverwrite.Text = "Overwrite files if exists"
        Me.chkoverwrite.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(489, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 17)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "Year"
        '
        'cmbcategories
        '
        Me.cmbcategories.FormattingEnabled = True
        Me.cmbcategories.Location = New System.Drawing.Point(64, 21)
        Me.cmbcategories.Name = "cmbcategories"
        Me.cmbcategories.Size = New System.Drawing.Size(193, 24)
        Me.cmbcategories.TabIndex = 42
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.chkoverwrite)
        Me.GroupBox1.Controls.Add(Me.cmbyear)
        Me.GroupBox1.Controls.Add(Me.cmbformat)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmbcategories)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 31)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(865, 62)
        Me.GroupBox1.TabIndex = 51
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filter"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 17)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "Folder"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 99)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(869, 128)
        Me.TabControl1.TabIndex = 54
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage1.Controls.Add(Me.Button3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(861, 99)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Decks Extractor"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage3.Controls.Add(Me.btnzipdecks)
        Me.TabPage3.Controls.Add(Me.Button2)
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(861, 99)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Tools"
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage4.Controls.Add(Me.Label6)
        Me.TabPage4.Controls.Add(Me.Button1)
        Me.TabPage4.Controls.Add(Me.Button4)
        Me.TabPage4.Controls.Add(Me.txfolder)
        Me.TabPage4.Location = New System.Drawing.Point(4, 25)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(861, 99)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Gauntlets"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(274, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 17)
        Me.Label6.TabIndex = 54
        Me.Label6.Text = "Folder"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(19, 33)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(217, 30)
        Me.Button1.TabIndex = 51
        Me.Button1.Text = "Create Gauntlets with Decks"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(627, 33)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(217, 30)
        Me.Button4.TabIndex = 52
        Me.Button4.Text = "Create Gauntlets with a folder"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'txfolder
        '
        Me.txfolder.Location = New System.Drawing.Point(332, 37)
        Me.txfolder.Name = "txfolder"
        Me.txfolder.Size = New System.Drawing.Size(267, 22)
        Me.txfolder.TabIndex = 53
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage2.Controls.Add(Me.Button5)
        Me.TabPage2.Controls.Add(Me.txfind)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.txreplace)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(861, 99)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Find and Replace"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(624, 37)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(217, 30)
        Me.Button5.TabIndex = 59
        Me.Button5.Text = "Find and Replace"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'txfind
        '
        Me.txfind.Location = New System.Drawing.Point(22, 41)
        Me.txfind.Name = "txfind"
        Me.txfind.Size = New System.Drawing.Size(256, 22)
        Me.txfind.TabIndex = 55
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(298, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(131, 17)
        Me.Label5.TabIndex = 58
        Me.Label5.Text = "Replace card name"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txreplace
        '
        Me.txreplace.Location = New System.Drawing.Point(295, 41)
        Me.txreplace.Name = "txreplace"
        Me.txreplace.Size = New System.Drawing.Size(317, 22)
        Me.txreplace.TabIndex = 56
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 17)
        Me.Label4.TabIndex = 57
        Me.Label4.Text = "Find card name"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(892, 701)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.log)
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MTGODecklistCachetoForge"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub
    Friend WithEvents log As TextBox
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents Button3 As Button
    Friend WithEvents cmbformat As ComboBox
    Friend WithEvents btnzipdecks As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents OptionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CheckForANewVersionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button2 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbyear As ComboBox
    Friend WithEvents chkoverwrite As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbcategories As ComboBox
    Friend WithEvents txfind As TextBox
    Friend WithEvents txreplace As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Button5 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents Label6 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents txfolder As TextBox
End Class
