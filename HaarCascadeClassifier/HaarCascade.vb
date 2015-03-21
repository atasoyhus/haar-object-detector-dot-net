
Imports System.Xml
Imports System.Drawing

Friend Class HaarCascade

    '--------------------------------------------------------------------------
    ' HaarCascadeClassifier > HaarCascade.vb
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


    ' Feature rectangle
    Public Structure FeatureRect
        Public Rectangle As Rectangle
        Public Weight As Single
    End Structure

    ' Binary tree nodes
    Public Structure Node
        Public FeatureRects As List(Of FeatureRect) ' Feature rectangles
        Public Threshold As Single                  ' Threshold for determining what to select (left value/right value) or where to go on binary tree (left or right)
        Public LeftVal As Single                    ' Left value
        Public RightVal As Single                   ' Right value
        Public HasLNode As Boolean                  ' Does this node have a left node? (Checking a boolean takes less time then to control if left node is null or not.)
        Public LeftNode As Integer                  ' Left node. If current node doesn't have a left node, this will be null.
        Public HasRNode As Boolean                  ' Does this node have a right node?
        Public RightNode As Integer                 ' Right node. If current node doesn't have a right node, this will be null.
    End Structure

    ' Will be used as a binary tree
    Public Structure Tree
        Public Nodes As List(Of Node)               ' Each tree can have max 3 nodes. First one is the current and others are nodes of the current.
    End Structure

    ' Stages
    Public Structure Stage
        Public Trees As List(Of Tree)               ' Trees in the stage.
        Public Threshold As Single                  ' Threshold of the stage.
    End Structure

    Public Stages As List(Of Stage)                 ' Stages of the cascade
    Public WindowSize As Size                       ' Original (unscaled) size of searching window

    ' Loads cascade from xml file at given path and creates a HaarCascade object using its content
    Public Sub New(ByVal OpenCVXmlStorageFile As String)
        Dim XMLDoc As New XmlDocument()
        XMLDoc.Load(OpenCVXmlStorageFile)
        Load(XMLDoc)
    End Sub

    ' If you embed the xml file, you can create an XmlDocument using embedded file and then use this constructor to create new HaarCascade.
    Public Sub New(ByVal XmlDoc As XmlDocument)
        Load(XmlDoc)
    End Sub

    ' Parses given xml document and loads parsed data
    Private Sub Load(ByVal XmlDoc As XmlDocument)
        For Each RootNode As XmlNode In XmlDoc.ChildNodes
            If RootNode.NodeType = XmlNodeType.Comment Then Continue For

            For Each CascadeNode As XmlNode In RootNode
                ' All haar cascades start with this expression: <haarcascade_frontalface_alt type_id="opencv-haar-classifier">
                If CascadeNode.NodeType = XmlNodeType.Comment OrElse CascadeNode.Attributes("type_id") Is Nothing OrElse Not CascadeNode.Attributes("type_id").Value.Equals("opencv-haar-classifier") Then Continue For

                Stages = New List(Of Stage)

                For Each CascadeChild As XmlNode In CascadeNode
                    If CascadeChild.NodeType = XmlNodeType.Comment Then Continue For

                    If CascadeChild.Name.Equals("size") Then
                        WindowSize = Parser.ParseSize(CascadeChild.InnerText)
                    ElseIf CascadeChild.Name.Equals("stages") Then
                        For Each StageNode As XmlNode In CascadeChild
                            If StageNode.NodeType = XmlNodeType.Comment Then Continue For

                            Dim NewStage As New Stage
                            NewStage.Trees = New List(Of Tree)
                            For Each StageChild As XmlNode In StageNode
                                If StageChild.NodeType = XmlNodeType.Comment Then Continue For

                                If StageChild.Name.Equals("stage_threshold") Then
                                    NewStage.Threshold = Parser.ParseSingle(StageChild.InnerText)
                                ElseIf StageChild.Name.Equals("trees") Then
                                    For Each Tree As XmlNode In StageChild
                                        If Tree.NodeType = XmlNodeType.Comment Then Continue For

                                        Dim NewTree As New Tree
                                        NewTree.Nodes = New List(Of Node)

                                        For Each TreeNode As XmlNode In Tree
                                            If TreeNode.NodeType = XmlNodeType.Comment Then Continue For

                                            Dim NewNode As New Node
                                            NewNode.FeatureRects = New List(Of FeatureRect)

                                            For Each TreeNodeChild As XmlNode In TreeNode
                                                If TreeNodeChild.NodeType = XmlNodeType.Comment Then Continue For

                                                If TreeNodeChild.Name.Equals("feature") Then
                                                    For Each TNCChild As XmlNode In TreeNodeChild
                                                        If TNCChild.NodeType = XmlNodeType.Comment Then Continue For

                                                        If TNCChild.Name.Equals("rects") Then
                                                            For Each Rect As XmlNode In TNCChild
                                                                If Rect.NodeType = XmlNodeType.Comment Then Continue For

                                                                NewNode.FeatureRects.Add(Parser.ParseFeatureRect(Rect.InnerText))
                                                            Next
                                                        ElseIf TNCChild.Name.Equals("tilted") Then
                                                            If Parser.ParseInt(TNCChild.InnerText) = 1 Then
                                                                ' Not supported for now. Will be implemented in future releases.
                                                                Throw New Exception("Tilted features are not supported yet!")
                                                                Return
                                                            End If
                                                        End If
                                                    Next
                                                ElseIf TreeNodeChild.Name.Equals("threshold") Then
                                                    NewNode.Threshold = Parser.ParseSingle(TreeNodeChild.InnerText)
                                                ElseIf TreeNodeChild.Name.Equals("left_val") Then
                                                    NewNode.LeftVal = Parser.ParseSingle(TreeNodeChild.InnerText)
                                                    NewNode.HasLNode = False
                                                ElseIf TreeNodeChild.Name.Equals("right_val") Then
                                                    NewNode.RightVal = Parser.ParseSingle(TreeNodeChild.InnerText)
                                                    NewNode.HasRNode = False
                                                ElseIf TreeNodeChild.Name.Equals("left_node") Then
                                                    NewNode.LeftNode = Parser.ParseInt(TreeNodeChild.InnerText)
                                                    NewNode.HasLNode = True
                                                ElseIf TreeNodeChild.Name.Equals("right_node") Then
                                                    NewNode.RightNode = Parser.ParseInt(TreeNodeChild.InnerText)
                                                    NewNode.HasRNode = True
                                                End If
                                            Next
                                            NewTree.Nodes.Add(NewNode)
                                        Next

                                        NewStage.Trees.Add(NewTree)
                                    Next
                                End If
                            Next
                            Stages.Add(NewStage)
                        Next
                    End If
                Next

                Return
            Next
        Next

        Throw New Exception("Given XML document does not contain a haar cascade in supported format.")
    End Sub

End Class
