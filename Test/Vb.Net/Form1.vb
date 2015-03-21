Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports HaarCascadeClassifer
Imports HaarCascadeClassifer.HaarDetector

Public Class Form1

    '--------------------------------------------------------------------------
    ' HaarCascadeClassifierTEST > Form1.vb
    '--------------------------------------------------------------------------
    ' Huseyin Atasoy
    ' huseyin@atasoyweb.net
    ' www.atasoyweb.net
    ' July 2012
    '--------------------------------------------------------------------------
    ' Copyright 2012 Huseyin Atasoy
    '
    ' Licensed under the Apache License, Version 2.0 (the "License");
    ' you may not use this file except in compliance with the License.
    ' You may obtain a copy of the License at
    '
    '     http://www.apache.org/licenses/LICENSE-2.0
    '
    ' Unless required by applicable law or agreed to in writing, software
    ' distributed under the License is distributed on an "AS IS" BASIS,
    ' WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    ' See the License for the specific language governing permissions and
    ' limitations under the License.
    '--------------------------------------------------------------------------

    Private SelectedBitmap As Bitmap
    Private Detector As HaarDetector

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Start As DateTime = Now
        Dim XMLDoc As New Xml.XmlDocument
        XMLDoc.LoadXml(HaarCascadeClassifer.My.Resources.haarcascade_frontalface_alt)
        Detector = New HaarDetector(XMLDoc)
        lblInfo.Text = "XML cascade parsed in " & Math.Round((Now - Start).TotalMilliseconds, 3).ToString & " milliseconds."
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Dim OFDialog As New OpenFileDialog()
        Try
            OFDialog.Filter = "Images|*.tiff;*.jpg;*.jpeg;*.png;*.gif;*.bmp"
            OFDialog.FilterIndex = 0
            OFDialog.FileName = ""
            If Not OFDialog.ShowDialog() = DialogResult.OK Then
                Return
            End If
        Catch
            Return
        End Try

        SelectedBitmap = New Bitmap(OFDialog.FileName)
        PictureBox1.Image = SelectedBitmap.Clone

        btnDetect.Enabled = True
    End Sub

    Private Sub btnDetect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetect.Click
        Dim MaxDetCount As Integer = Integer.MaxValue
        Dim MinNRectCount As Integer = nudMinNRectCount.Value
        Dim FirstScale As Single = Detector.Size2Scale(nudMinSize.Value)
        Dim MaxScale As Single = Detector.Size2Scale(nudMaxSize.Value)
        Dim ScaleMult As Single = nudScaleMult.Value
        Dim SizeMultForNesRectCon As Single = nudSizeMultForNesRectCon.Value
        Dim SlidingRatio As Single = nudSlidingRatio.Value
        Dim Pen As New Pen(Brushes.Red, nudLineWidth.Value)
        Dim DetectorParameters As New DetectionParams(MaxDetCount, MinNRectCount, FirstScale, MaxScale, ScaleMult, SizeMultForNesRectCon, SlidingRatio, Pen)

        Dim Bmp As Bitmap = SelectedBitmap.Clone

        Dim Start As DateTime = Now
        Dim Results As DResults = Detector.Detect(Bmp, DetectorParameters)
        Dim Elapsed As TimeSpan = Now - Start

        PictureBox1.Image = Bmp
        lblInfo.Text = Results.SearchedSubRegionCount & " subregions were searched and " & Results.NOfObjects & " object(s) were detected in " & Math.Round(Elapsed.TotalMilliseconds, 3).ToString & " milliseconds."
    End Sub
End Class
