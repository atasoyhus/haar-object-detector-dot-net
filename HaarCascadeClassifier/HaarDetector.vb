
Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports System.Threading

Public Class HaarDetector

    '--------------------------------------------------------------------------
    ' HaarCascadeClassifier > HaarDetector.vb
    '--------------------------------------------------------------------------
    ' VB.Net implementation of Viola-Jones Object Detection algorithm
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

    Public Structure DResults
        Public Sub New(ByVal SearchedSubRegionCount As Integer, ByVal NOfObjects As Integer, ByVal DetectedOLocs() As Rectangle)
            Me.SearchedSubRegionCount = SearchedSubRegionCount  ' Total number of searched subregions
            Me.NOfObjects = NOfObjects                          ' Number of objects
            Me.DetectedOLocs = DetectedOLocs                    ' Detected objects' locations
        End Sub
        Public SearchedSubRegionCount As Integer
        Public NOfObjects As Integer
        Public DetectedOLocs() As Rectangle
    End Structure

    Public Structure DetectionParams
        Public MaxDetCount As Integer               ' Detector stops searching when number of detected objects reachs this value.
        Public MinNRectCount As Integer             ' Minimum neighbour areas must be passed the detector to verify existence of searched object.
        Public FirstScale As Single                 ' First scaler of searching window.
        Public MaxScale As Single                   ' Maximum scaler of searching window.
        Public ScaleMult As Single                  ' ScaleMult (Scale Multiplier) and current scaler are multiplied to make an increment on current scaler.
        Public SizeMultForNesRectCon As Single      ' SizeMultForNesRectCon (Size Multiplier For Nested Object Control) and size of every rectangle are multiplied separately to obtain maximum acceptable horizontal and vertical distances between current rectangle and others. Maximum distances are used to check if rectangles are nested or not.
        Public SlidingRatio As Single               ' The ratio of step size to scaled searching window width. (CurrentStepSize = ScaledWindowWidth * SlidingRatio)
        Public Pen As Pen                           ' A "Pen" object to draw rectangles on given bitmap. If it is given as null, nothing will be drawn.
        Public Sub New(ByVal MaxDetCount As Integer, ByVal MinNRectCount As Integer, ByVal FirstScale As Single, ByVal MaxScale As Single, ByVal ScaleMult As Single, ByVal SizeMultForNesRectCon As Single, ByVal SlidingRatio As Single, ByVal Pen As Pen)
            Me.MaxDetCount = MaxDetCount
            Me.MinNRectCount = MinNRectCount
            Me.FirstScale = FirstScale
            Me.MaxScale = MaxScale
            Me.ScaleMult = ScaleMult
            Me.SizeMultForNesRectCon = SizeMultForNesRectCon
            Me.SlidingRatio = SlidingRatio
            Me.Pen = Pen
        End Sub
    End Structure

    Private HCascade As HaarCascade

    ' Creates a HaarDetector object, parsing opencv xml storage file of which full path is given.
    Public Sub New(ByVal OpenCVXmlStorage As String)
        HCascade = New HaarCascade(OpenCVXmlStorage)
    End Sub

    ' Creates a HaarDetector object, parsing given xml document. This constructor can be used for loading embedded cascades.
    Public Sub New(ByVal XmlDoc As XmlDocument)
        HCascade = New HaarCascade(XmlDoc)
    End Sub

    ' Calculate ratio of given size to unscaled searching window size. It can be used to calculate first and max scales of searching window.
    Public Function Size2Scale(ByVal Size As Integer) As Single
        Return Convert.ToSingle(Math.Min(Size / HCascade.WindowSize.Width, Size / HCascade.WindowSize.Height))
    End Function

    ' For 8 bits per pixel images
    Private Sub CalculateCumSums8bpp(ByRef CumSum(,) As Integer, ByRef CumSum2(,) As Long, ByRef BitmapData As BitmapData, ByRef Width As Integer, ByRef Height As Integer)
        Dim AbsOfStride As Integer = FastAbs(BitmapData.Stride)
        Dim ExtraBPerLine As Integer = AbsOfStride - Width
        Dim ScanWidthWP As Integer = AbsOfStride - ExtraBPerLine ' Scan width without padding
        Dim BmpDataPtr As IntPtr = BitmapData.Scan0

        Dim ByteCount As Integer = AbsOfStride * Height
        Dim Colors(ByteCount - 1) As Byte
        Marshal.Copy(BmpDataPtr, Colors, 0, ByteCount)

        Dim CurRowSum As Integer
        Dim CurRowSum2 As Long
        Dim k As Integer = Width  ' image2D(0,1) = image1D(width)   (Skip first row)
        Dim i As Integer = Width + ExtraBPerLine
        Dim PosControl As Integer = 0 ' We will start right after first extra bytes
        While i < ByteCount
            Dim GrayVal As Integer = Colors(i)
            i = i + 1

            PosControl = PosControl + 1
            If PosControl = ScanWidthWP Then ' If current position is equal to ScanWidthWP now, skip bytes inserted for padding the scan line and zero PosControl for future controls.
                PosControl = 0
                i = i + ExtraBPerLine
            End If

            Dim CurRow As Integer = Convert.ToInt32(Math.Floor(k / Width))
            Dim CurCol As Integer = k Mod Width
            If CurCol = 0 Then
                CurRowSum = 0
                CurRowSum2 = 0
            End If
            CurRowSum = CurRowSum + GrayVal
            CurRowSum2 = CurRowSum2 + GrayVal * GrayVal
            CumSum(CurCol, CurRow) = CumSum(CurCol, CurRow - 1) + CurRowSum
            CumSum2(CurCol, CurRow) = CumSum2(CurCol, CurRow - 1) + CurRowSum2

            k = k + 1
        End While
    End Sub

    ' For 24 bits per pixel images
    Private Sub CalculateCumSums24bpp(ByRef CumSum(,) As Integer, ByRef CumSum2(,) As Long, ByRef BitmapData As BitmapData, ByRef Width As Integer, ByRef Height As Integer)
        Dim AbsOfStride As Integer = FastAbs(BitmapData.Stride)
        Dim ExtraBPerLine As Integer = AbsOfStride - Width * 3
        Dim ScanWidthWP As Integer = AbsOfStride - ExtraBPerLine ' Scan width without padding
        Dim BmpDataPtr As IntPtr = BitmapData.Scan0

        Dim ByteCount As Integer = AbsOfStride * Height
        Dim Colors(ByteCount - 1) As Byte
        Marshal.Copy(BmpDataPtr, Colors, 0, ByteCount)

        Dim CurRowSum As Integer
        Dim CurRowSum2 As Long
        Dim k As Integer = Width  ' image2D(0,1) = image1D(width)   (Skip first row)
        Dim i As Integer = 3 * Width + ExtraBPerLine '8bppimage2D(0,1) = 8bppimage1D(3 * Width)
        Dim PosControl As Integer = 0 ' We will start right after first extra bytes
        While i < ByteCount
            ' For conversation from rgb to gray.
            Dim GrayVal As Single = Colors(i) ' Blue
            GrayVal = 0.114F * GrayVal
            i = i + 1

            GrayVal = GrayVal + 0.587F * Colors(i) ' Green
            i = i + 1

            GrayVal = GrayVal + 0.299F * Colors(i) ' Red
            i = i + 1

            PosControl = PosControl + 3
            If PosControl = ScanWidthWP Then ' If current position is equal to ScanWidthWP now, skip bytes inserted for padding the scan line and zero PosControl for future controls.
                PosControl = 0
                i = i + ExtraBPerLine
            End If

            Dim CurRow As Integer = Convert.ToInt32(Math.Floor(k / Width))
            Dim CurCol As Integer = k Mod Width
            If CurCol = 0 Then
                CurRowSum = 0
                CurRowSum2 = 0
            End If
            CurRowSum = Convert.ToInt32(CurRowSum + GrayVal)
            CurRowSum2 = Convert.ToInt32(CurRowSum2 + GrayVal * GrayVal)
            CumSum(CurCol, CurRow) = CumSum(CurCol, CurRow - 1) + CurRowSum
            CumSum2(CurCol, CurRow) = CumSum2(CurCol, CurRow - 1) + CurRowSum2

            k = k + 1
        End While
    End Sub

    ' For 32 bits per pixel images (for both premultiplied and not premultiplied by alpha values.) Alpha channel is ignored.
    Private Sub CalculateCumSums32bpp(ByRef CumSum(,) As Integer, ByRef CumSum2(,) As Long, ByRef BitmapData As BitmapData, ByRef Width As Integer, ByRef Height As Integer)
        Dim ScanWidthWP As Integer = Width * 4 ' 32bpp formatted bitmaps never contains padding bytes.
        Dim BmpDataPtr As IntPtr = BitmapData.Scan0

        Dim ByteCount As Integer = ScanWidthWP * Height
        Dim Colors(ByteCount - 1) As Byte
        Marshal.Copy(BmpDataPtr, Colors, 0, ByteCount)

        Dim CurRowSum As Integer
        Dim CurRowSum2 As Long
        Dim k As Integer = Width  ' image2D(0,1) = image1D(width)   (Skip first row)
        Dim i As Integer = ScanWidthWP '8bppimage2D(0,1) = 8bppimage1D(3 * Width)
        While i < ByteCount
            ' For conversation from rgb to gray.
            Dim GrayVal As Single = Colors(i) ' Blue
            GrayVal = 0.114F * GrayVal
            i = i + 1

            GrayVal = GrayVal + 0.587F * Colors(i) ' Green
            i = i + 1

            GrayVal = GrayVal + 0.299F * Colors(i) ' Red
            i = i + 2 ' Skip alpha channel

            Dim CurRow As Integer = Convert.ToInt32(Math.Floor(k / Width))
            Dim CurCol As Integer = k Mod Width
            If CurCol = 0 Then
                CurRowSum = 0
                CurRowSum2 = 0
            End If
            CurRowSum = Convert.ToInt32(CurRowSum + GrayVal)
            CurRowSum2 = Convert.ToInt32(CurRowSum2 + GrayVal * GrayVal)
            CumSum(CurCol, CurRow) = CumSum(CurCol, CurRow - 1) + CurRowSum
            CumSum2(CurCol, CurRow) = CumSum2(CurCol, CurRow - 1) + CurRowSum2

            k = k + 1
        End While
    End Sub

    ' Detects objects on given Bitmap. Only 32bppPArgb, 32bppArgb, 24bppRgb and 8bppIndexed formats are supported for now.
    Public Function Detect(ByRef Bitmap As Bitmap, ByVal Parameters As DetectionParams) As DResults
        Dim Width As Integer = Bitmap.Width
        Dim Height As Integer = Bitmap.Height

        Dim CumSum(Width - 1, Height - 1) As Integer ' Cumulative sums of every pixel.
        Dim CumSum2(Width - 1, Height - 1) As Long   ' Squares of sums of every pixel. These will be used for standart deviation calculations.

        Dim BitmapData As BitmapData = Bitmap.LockBits(New Rectangle(0, 0, Width, Height), ImageLockMode.ReadOnly, Bitmap.PixelFormat)
        If Bitmap.PixelFormat = PixelFormat.Format24bppRgb Then
            CalculateCumSums24bpp(CumSum, CumSum2, BitmapData, Width, Height)
        ElseIf Bitmap.PixelFormat = PixelFormat.Format8bppIndexed Then
            CalculateCumSums8bpp(CumSum, CumSum2, BitmapData, Width, Height)
            Parameters.Pen = Nothing ' Can't draw anything on an 8 bit indexed image.
        ElseIf Bitmap.PixelFormat = PixelFormat.Format32bppPArgb OrElse Bitmap.PixelFormat = PixelFormat.Format32bppArgb Then
            CalculateCumSums32bpp(CumSum, CumSum2, BitmapData, Width, Height)
        Else
            Throw New Exception(Bitmap.PixelFormat.ToString() & " is not supported.")
            Bitmap.UnlockBits(BitmapData)
            Return Nothing
        End If
        Bitmap.UnlockBits(BitmapData)

        Dim DetectedOLocs As New List(Of Rectangle) ' Passed regions will be stored here.
        Dim NOfObjects As Integer = 0               ' Number of detected objects
        Dim SearchedSubRegionCount As Integer = 0   ' Searched subregion count

        Dim Scaler As Single = Parameters.FirstScale
        While Scaler < Parameters.MaxScale ' For all scales between first scale and max scale.
            Dim WinWidth As Integer = Convert.ToInt32(HCascade.WindowSize.Width * Scaler) ' Scaled searching window width
            Dim WinHeight As Integer = Convert.ToInt32(HCascade.WindowSize.Height * Scaler) ' Scaled searching window height
            Dim InvArea As Single = Convert.ToSingle(1 / (WinWidth * WinHeight)) ' Inverse of the area

            Dim StepSize As Integer = Convert.ToInt32(WinWidth * Parameters.SlidingRatio) ' Current step size
            For i = 0 To Width - WinWidth - 1 Step StepSize
                For j = 0 To Height - WinHeight - 1 Step StepSize
                    SearchedSubRegionCount = SearchedSubRegionCount + 1

                    ' Integral image of current region:
                    Dim IImg As Integer = CumSum(i + WinWidth, j + WinHeight) - CumSum(i, j + WinHeight) - CumSum(i + WinWidth, j) + CumSum(i, j)
                    Dim IImg2 As Long = CumSum2(i + WinWidth, j + WinHeight) - CumSum2(i, j + WinHeight) - CumSum2(i + WinWidth, j) + CumSum2(i, j)
                    Dim Mean As Single = IImg * InvArea
                    Dim Variance As Single = IImg2 * InvArea - Mean * Mean
                    Dim Normalizer As Single ' Will normalize thresholds.
                    If Variance > 1 Then
                        Normalizer = Convert.ToSingle(Math.Sqrt(Variance)) ' Standart deviation
                    Else
                        Normalizer = 1
                    End If

                    Dim Passed As Boolean = True
                    For Each Stage As HaarCascade.Stage In HCascade.Stages
                        Dim StageVal As Single = 0
                        For Each Tree As HaarCascade.Tree In Stage.Trees
                            Dim CurNode As HaarCascade.Node = Tree.Nodes(0)
                            While True
                                Dim RectSum As Integer = 0
                                For Each FeatureRect As HaarCascade.FeatureRect In CurNode.FeatureRects
                                    ' Resize current feature rectangle to fit it in scaled searching window:
                                    Dim Rx1 As Integer = Convert.ToInt32(i + Math.Floor(FeatureRect.Rectangle.X * Scaler))
                                    Dim Ry1 As Integer = Convert.ToInt32(j + Math.Floor(FeatureRect.Rectangle.Y * Scaler))
                                    Dim Rx2 As Integer = Convert.ToInt32(Rx1 + Math.Floor(FeatureRect.Rectangle.Width * Scaler))
                                    Dim Ry2 As Integer = Convert.ToInt32(Ry1 + Math.Floor(FeatureRect.Rectangle.Height * Scaler))
                                    ' Integral image of the region bordered by the current feature ractangle (sum of all pixels in it):
                                    RectSum = Convert.ToInt32(RectSum + (CumSum(Rx2, Ry2) - CumSum(Rx1, Ry2) - CumSum(Rx2, Ry1) + CumSum(Rx1, Ry1)) * FeatureRect.Weight)
                                Next

                                Dim AvgRectSum As Single = RectSum * InvArea
                                If AvgRectSum < CurNode.Threshold * Normalizer Then
                                    If CurNode.HasLNode Then
                                        CurNode = Tree.Nodes(CurNode.LeftNode) ' Go to the left node
                                        Continue While
                                    Else
                                        StageVal = StageVal + CurNode.LeftVal
                                        Exit While ' It is a leaf, exit.
                                    End If
                                Else
                                    If CurNode.HasRNode Then
                                        CurNode = Tree.Nodes(CurNode.RightNode) ' Go to the right node
                                        Continue While
                                    Else
                                        StageVal = StageVal + CurNode.RightVal
                                        Exit While ' It is a leaf, exit.
                                    End If
                                End If
                            End While
                        Next
                        If StageVal < Stage.Threshold Then
                            Passed = False
                            Exit For ' Don't waste time with trying to pass it from other stages.
                        End If
                    Next
                    If Passed Then ' If current region was passed from all stages
                        DetectedOLocs.Add(New Rectangle(i, j, WinWidth, WinHeight))
                        NOfObjects += 1
                        If NOfObjects = Parameters.MaxDetCount Then ' Are they enough? (note that, nested rectangles are not eliminated yet)
                            Exit While
                        End If
                    End If
                Next
            Next
            Scaler *= Parameters.ScaleMult
        End While

        Dim Results As DResults
        If DetectedOLocs.Count > 0 Then
            Results = EliminateNestedRects(DetectedOLocs.ToArray, NOfObjects, Parameters.MinNRectCount + 1, Parameters.SizeMultForNesRectCon)
            If Parameters.Pen IsNot Nothing Then ' If a pen was given, mark objects using given pen
                Dim G As Graphics = Graphics.FromImage(Bitmap)
                G.DrawRectangles(Parameters.Pen, Results.DetectedOLocs)
                G.Dispose()
            End If
        Else
            Results = New DResults(0, 0, Nothing)
        End If

        Results.SearchedSubRegionCount = SearchedSubRegionCount
        Return Results
    End Function

    ' Every detected object must be marked only with one rectangle. Others must be eliminated:
    Private Function EliminateNestedRects(ByVal DetectedOLocs() As Rectangle, ByVal NOfObjects As Integer, ByVal MinNRectCount As Integer, ByRef SizeMultForNesRectCon As Single) As DResults
        Dim NestedRectsCount(NOfObjects - 1) As Integer
        Dim AvgRects(NOfObjects - 1) As Rectangle
        For i As Integer = 0 To NOfObjects - 1
            Dim Current As Rectangle = DetectedOLocs(i)
            AvgRects(i) = Current
            For j As Integer = 0 To NOfObjects - 1
                ' Check if these 2 rectangles are nested
                If i <> j AndAlso DetectedOLocs(j).Width > 0 AndAlso AreTheyNested(Current, DetectedOLocs(j), SizeMultForNesRectCon) Then
                    NestedRectsCount(i) += 1
                    AvgRects(i).X += DetectedOLocs(j).X
                    AvgRects(i).Y += DetectedOLocs(j).Y
                    AvgRects(i).Width += DetectedOLocs(j).Width
                    AvgRects(i).Height += DetectedOLocs(j).Height
                    DetectedOLocs(j).Width = 0 ' Zero it to eliminate.
                End If
            Next
        Next

        Dim k As Integer = 0
        Dim NewRects(NOfObjects - 1) As Rectangle
        For i As Integer = 0 To NOfObjects - 1
            If DetectedOLocs(i).Width > 0 Then ' Rectangles that are not eliminated
                Dim NOfNRects As Integer = NestedRectsCount(i) + 1 '+1 is itself. It is required, becuse we will calculate average of them.
                If NOfNRects >= MinNRectCount Then
                    ' Average rectangle:
                    NewRects(k) = New Rectangle(Convert.ToInt32(AvgRects(i).X / NOfNRects), Convert.ToInt32(AvgRects(i).Y / NOfNRects), Convert.ToInt32(AvgRects(i).Width / NOfNRects), Convert.ToInt32(AvgRects(i).Height / NOfNRects))
                End If
                k = k + 1
            End If
        Next

        Dim Results As New DResults
        ReDim Results.DetectedOLocs(k - 1)
        Array.Copy(NewRects, Results.DetectedOLocs, k)
        Results.NOfObjects = k

        Return Results
    End Function

    Private Function AreTheyNested(ByRef Rectangle1 As Rectangle, ByRef Rectangle2 As Rectangle, ByRef SizeMultForNesRectCon As Single) As Boolean
        ' Maybe they are not fully nested, we must be tolerant:
        Dim MaxHorDist As Integer = Convert.ToInt32(SizeMultForNesRectCon * Rectangle1.Width)
        Dim MaxVertDist As Integer = Convert.ToInt32(SizeMultForNesRectCon * Rectangle1.Height)
        If (FastAbs(Rectangle2.X - Rectangle1.X) < MaxHorDist AndAlso FastAbs(Rectangle2.Right - Rectangle1.Right) < MaxHorDist) AndAlso (FastAbs(Rectangle2.Y - Rectangle1.Y) < MaxVertDist AndAlso FastAbs(Rectangle2.Bottom - Rectangle1.Bottom) < MaxVertDist) Then
            Return True
        Else
            Return False
        End If
    End Function

    ' Math.Abs() makes type conversations before and after the operation. It is waste of time...
    Private Function FastAbs(ByVal Int As Integer) As Integer
        If Int < 0 Then
            Return -Int
        Else
            Return Int
        End If
    End Function
End Class

