﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.btnzipdecks = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckForANewVersionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'log
        '
        Me.log.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.log.Location = New System.Drawing.Point(16, 62)
        Me.log.Multiline = True
        Me.log.Name = "log"
        Me.log.ReadOnly = True
        Me.log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.log.Size = New System.Drawing.Size(865, 333)
        Me.log.TabIndex = 25
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(458, 473)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(192, 30)
        Me.Button1.TabIndex = 31
        Me.Button1.Text = "Create Gauntlets with Decks"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(16, 473)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(184, 30)
        Me.Button3.TabIndex = 32
        Me.Button3.Text = "Extract Decks"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"standard", "modern", "vintage", "legacy", "pauper", "pioneer"})
        Me.ComboBox1.Location = New System.Drawing.Point(12, 32)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 24)
        Me.ComboBox1.TabIndex = 33
        '
        'btnzipdecks
        '
        Me.btnzipdecks.Location = New System.Drawing.Point(697, 473)
        Me.btnzipdecks.Name = "btnzipdecks"
        Me.btnzipdecks.Size = New System.Drawing.Size(184, 30)
        Me.btnzipdecks.TabIndex = 34
        Me.btnzipdecks.Text = "Zip Decks by Format"
        Me.btnzipdecks.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(906, 28)
        Me.MenuStrip1.TabIndex = 35
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CheckForANewVersionToolStripMenuItem})
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(75, 24)
        Me.OptionsToolStripMenuItem.Text = "Options"
        '
        'CheckForANewVersionToolStripMenuItem
        '
        Me.CheckForANewVersionToolStripMenuItem.Name = "CheckForANewVersionToolStripMenuItem"
        Me.CheckForANewVersionToolStripMenuItem.Size = New System.Drawing.Size(551, 26)
        Me.CheckForANewVersionToolStripMenuItem.Text = "Download Zip of MTGODecklistCachetoForge last version from server"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.Label1.Location = New System.Drawing.Point(13, 398)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(314, 45)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "1. Put Tournaments folder (json files) in the same folder. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "2. Extract Decks." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "3" &
    ". Then, you can do ""Zips Decks by Format"""
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(225, 473)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(184, 30)
        Me.Button2.TabIndex = 37
        Me.Button2.Text = "Generate list.txt"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(906, 533)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.btnzipdecks)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.log)
        Me.Name = "Form1"
        Me.Text = "MTGODecklistCachetoForge"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents log As TextBox
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents Button1 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents btnzipdecks As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents OptionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CheckForANewVersionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents Button2 As Button
End Class