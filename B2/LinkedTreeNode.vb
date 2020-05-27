Public Class LinkedTreeNode
    Private p_treeViewNode As TreeNode
    Private p_prevNode As LinkedTreeNode
    Private p_nextNode As LinkedTreeNode

    Public Sub New(ByRef treeNode As TreeNode)
        p_treeViewNode = treeNode
        p_prevNode = Nothing
        p_nextNode = Nothing
    End Sub

    Public Property TreeViewNode() As TreeNode
        Get
            Return p_treeViewNode
        End Get

        Set(ByVal value As TreeNode)
            p_treeViewNode = value
        End Set
    End Property

    Public Property PrevNode() As LinkedTreeNode
        Get
            Return p_prevNode
        End Get
        Set(ByVal value As LinkedTreeNode)
            p_prevNode = value
        End Set
    End Property

    Public Property NextNode() As LinkedTreeNode
        Get
            Return p_nextNode
        End Get
        Set(ByVal value As LinkedTreeNode)
            p_nextNode = value
        End Set
    End Property
End Class
