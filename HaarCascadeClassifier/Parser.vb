
Imports System.Drawing
Imports HaarCascadeClassifer.HaarCascade
Imports System.Globalization

Friend Class Parser

    '--------------------------------------------------------------------------
    ' HaarCascadeClassifier > Parser.vb
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


    ' Sample: "20 20"
    Public Shared Function ParseSize(ByVal StringVal As String) As Size
        Dim Slices() As String = StringVal.Trim.Split(" "c)
        Return New Size(Convert.ToInt32(Slices(0).Trim), Convert.ToInt32(Slices(1).Trim))
    End Function

    ' Sample: "0.0337941907346249"
    Public Shared Function ParseSingle(ByVal StringVal As String) As Single
        Return (Single.Parse(ReplaceDecimalSeperator(StringVal.Trim)))
    End Function

    ' Sample: "1"
    Public Shared Function ParseInt(ByVal StringVal As String) As Integer
        Return Integer.Parse(StringVal.Trim)
    End Function

    ' Sample: "3 7 14 4 -1."
    Public Shared Function ParseFeatureRect(ByVal StringVal As String) As FeatureRect
        Dim Slices() As String = StringVal.Trim.Split(" "c)
        Dim FR As New FeatureRect
        FR.Rectangle = New Rectangle(Convert.ToInt32(Slices(0).Trim), Convert.ToInt32(Slices(1).Trim), Convert.ToInt32(Slices(2).Trim), Convert.ToInt32(Slices(3).Trim))

        Dim Weight As String = Slices(4)
        If Weight.EndsWith(".") Then
            Weight = Weight.Replace(".", "")
        Else
            Weight = ReplaceDecimalSeperator(Weight)
        End If
        FR.Weight = Convert.ToInt32(Weight.Trim)
        Return FR
    End Function

    Public Shared NumberDecimalSeparator As String = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
    Public Shared Function ReplaceDecimalSeperator(ByVal Val As String) As String
        Return Val.Replace(".", NumberDecimalSeparator)
    End Function
End Class
