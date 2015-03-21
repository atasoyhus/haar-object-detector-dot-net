<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.nudMinNRectCount = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.nudMinSize = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.nudMaxSize = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.nudScaleMult = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.nudSizeMultForNesRectCon = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.nudSlidingRatio = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.nudLineWidth = New System.Windows.Forms.NumericUpDown()
        Me.btnDetect = New System.Windows.Forms.Button()
        Me.lblInfo = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMinNRectCount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMinSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMaxSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudScaleMult, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudSizeMultForNesRectCon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudSlidingRatio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudLineWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(399, 216)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse.TabIndex = 0
        Me.btnBrowse.Text = "Browse..."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(320, 240)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'nudMinNRectCount
        '
        Me.nudMinNRectCount.Location = New System.Drawing.Point(507, 12)
        Me.nudMinNRectCount.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudMinNRectCount.Name = "nudMinNRectCount"
        Me.nudMinNRectCount.Size = New System.Drawing.Size(45, 20)
        Me.nudMinNRectCount.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(338, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(163, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Min neighbour rectangle count:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(338, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(163, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Min size of searched object:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nudMinSize
        '
        Me.nudMinSize.Location = New System.Drawing.Point(507, 38)
        Me.nudMinSize.Maximum = New Decimal(New Integer() {640, 0, 0, 0})
        Me.nudMinSize.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudMinSize.Name = "nudMinSize"
        Me.nudMinSize.Size = New System.Drawing.Size(45, 20)
        Me.nudMinSize.TabIndex = 4
        Me.nudMinSize.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(338, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(163, 20)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Max size of searched object:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nudMaxSize
        '
        Me.nudMaxSize.Location = New System.Drawing.Point(507, 64)
        Me.nudMaxSize.Maximum = New Decimal(New Integer() {640, 0, 0, 0})
        Me.nudMaxSize.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudMaxSize.Name = "nudMaxSize"
        Me.nudMaxSize.Size = New System.Drawing.Size(45, 20)
        Me.nudMaxSize.TabIndex = 6
        Me.nudMaxSize.Value = New Decimal(New Integer() {200, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(338, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(163, 20)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Scale multiplier:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nudScaleMult
        '
        Me.nudScaleMult.DecimalPlaces = 2
        Me.nudScaleMult.Increment = New Decimal(New Integer() {5, 0, 0, 131072})
        Me.nudScaleMult.Location = New System.Drawing.Point(507, 90)
        Me.nudScaleMult.Maximum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.nudScaleMult.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudScaleMult.Name = "nudScaleMult"
        Me.nudScaleMult.Size = New System.Drawing.Size(45, 20)
        Me.nudScaleMult.TabIndex = 8
        Me.nudScaleMult.Value = New Decimal(New Integer() {11, 0, 0, 65536})
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(338, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(163, 20)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Nested rectangle size multiplier:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nudSizeMultForNesRectCon
        '
        Me.nudSizeMultForNesRectCon.DecimalPlaces = 2
        Me.nudSizeMultForNesRectCon.Increment = New Decimal(New Integer() {5, 0, 0, 131072})
        Me.nudSizeMultForNesRectCon.Location = New System.Drawing.Point(507, 116)
        Me.nudSizeMultForNesRectCon.Name = "nudSizeMultForNesRectCon"
        Me.nudSizeMultForNesRectCon.Size = New System.Drawing.Size(45, 20)
        Me.nudSizeMultForNesRectCon.TabIndex = 10
        Me.nudSizeMultForNesRectCon.Value = New Decimal(New Integer() {3, 0, 0, 65536})
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(338, 142)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(163, 20)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Sliding Ratio:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nudSlidingRatio
        '
        Me.nudSlidingRatio.DecimalPlaces = 1
        Me.nudSlidingRatio.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.nudSlidingRatio.Location = New System.Drawing.Point(507, 142)
        Me.nudSlidingRatio.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudSlidingRatio.Minimum = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.nudSlidingRatio.Name = "nudSlidingRatio"
        Me.nudSlidingRatio.Size = New System.Drawing.Size(45, 20)
        Me.nudSlidingRatio.TabIndex = 12
        Me.nudSlidingRatio.Value = New Decimal(New Integer() {2, 0, 0, 65536})
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(338, 168)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(163, 20)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Rectangle line width:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nudLineWidth
        '
        Me.nudLineWidth.Location = New System.Drawing.Point(507, 168)
        Me.nudLineWidth.Maximum = New Decimal(New Integer() {8, 0, 0, 0})
        Me.nudLineWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudLineWidth.Name = "nudLineWidth"
        Me.nudLineWidth.Size = New System.Drawing.Size(45, 20)
        Me.nudLineWidth.TabIndex = 14
        Me.nudLineWidth.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'btnDetect
        '
        Me.btnDetect.Enabled = False
        Me.btnDetect.Location = New System.Drawing.Point(480, 216)
        Me.btnDetect.Name = "btnDetect"
        Me.btnDetect.Size = New System.Drawing.Size(75, 23)
        Me.btnDetect.TabIndex = 16
        Me.btnDetect.Text = "Detect"
        Me.btnDetect.UseVisualStyleBackColor = True
        '
        'lblInfo
        '
        Me.lblInfo.ForeColor = System.Drawing.Color.Green
        Me.lblInfo.Location = New System.Drawing.Point(9, 256)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(543, 19)
        Me.lblInfo.TabIndex = 17
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(564, 279)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.btnDetect)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.nudLineWidth)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.nudSlidingRatio)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.nudSizeMultForNesRectCon)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.nudScaleMult)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.nudMaxSize)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.nudMinSize)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.nudMinNRectCount)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnBrowse)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HaarCascadeClassifier.dll Test (Vb.Net)"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMinNRectCount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMinSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMaxSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudScaleMult, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudSizeMultForNesRectCon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudSlidingRatio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudLineWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents nudMinNRectCount As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents nudMinSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents nudMaxSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents nudScaleMult As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents nudSizeMultForNesRectCon As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents nudSlidingRatio As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents nudLineWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnDetect As System.Windows.Forms.Button
    Friend WithEvents lblInfo As System.Windows.Forms.Label

End Class
