Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.Mvvm.POCO

Namespace AppearanceCustomization

    Public Class MainViewModel

        Private random As Random

        Public Sub New()
            random = New Random()
            Items = CreateTestItems()
            SelectedItem = Items(0).Nodes(0)
        End Sub

        Public Property Items As List(Of Node)

        Public Overridable Property SelectedItem As Node

        Public Function CreateTestItems() As List(Of Node)
            Dim result = New List(Of Node)()
            result.Add(Node.Create("Item 1", showInCollapsedMode:=True, nodes:=New List(Of Node)() From {Node.Create("Item 1.1"), Node.Create("Item 1.2")}))
            result.Add(Node.Create("Item 2", isCustomView:=True, nodes:=New List(Of Node)() From {Node.Create("Item 2.1")}))
            result.Add(Node.Create("Item 3", nodes:=New List(Of Node)() From {Node.Create("Item 3.1"), Node.Create("Item 3.2", showInCollapsedMode:=True, isCustomView:=True)}))
            Return result
        End Function

        Public Overridable Sub UpdateCustomItems()
            For Each flattenItem In Flatten(Items)
                flattenItem.IsCustomView = random.Next(0, 100) < 30
            Next
        End Sub

        Private Function Flatten(ByVal e As IEnumerable(Of Node)) As IEnumerable(Of Node)
            Return If(e Is Nothing, Enumerable.Empty(Of Node)(), e.SelectMany(Function(c) Flatten(c.Nodes)).Concat(e))
        End Function
    End Class

    Public Class Node

        Private _Header As String, _ShowInCollapsedMode As Boolean, _Nodes As List(Of AppearanceCustomization.Node), _Index As Integer

        Public Shared Function Create(ByVal header As String, ByVal Optional showInCollapsedMode As Boolean = False, ByVal Optional isCustomView As Boolean = False, ByVal Optional nodes As List(Of Node) = Nothing) As Node
            Dim factory = ViewModelSource.Factory(Of String, Boolean, Boolean, List(Of Node), Node)(Function(s, collapseMode, customView, children) New Node(s, collapseMode, customView, children))
            Return factory(header, showInCollapsedMode, isCustomView, nodes)
        End Function

        Protected Sub New(ByVal header As String, ByVal showInCollapsedMode As Boolean, ByVal isCustomView As Boolean, ByVal nodes As List(Of Node))
            Me.Header = header
            Me.ShowInCollapsedMode = showInCollapsedMode
            Me.IsCustomView = isCustomView
            Me.Nodes = nodes
            Index = counter
            counter += 1
        End Sub

        Private Shared counter As Integer

        Public Property Header As String
            Get
                Return _Header
            End Get

            Private Set(ByVal value As String)
                _Header = value
            End Set
        End Property

        Public Property ShowInCollapsedMode As Boolean
            Get
                Return _ShowInCollapsedMode
            End Get

            Private Set(ByVal value As Boolean)
                _ShowInCollapsedMode = value
            End Set
        End Property

        Public Overridable Property IsCustomView As Boolean

        Public Property Nodes As List(Of Node)
            Get
                Return _Nodes
            End Get

            Private Set(ByVal value As List(Of Node))
                _Nodes = value
            End Set
        End Property

        Public Property Index As Integer
            Get
                Return _Index
            End Get

            Private Set(ByVal value As Integer)
                _Index = value
            End Set
        End Property
    End Class
End Namespace
