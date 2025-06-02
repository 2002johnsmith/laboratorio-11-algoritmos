using System;
using System.Collections.Generic;

public class Tree<T>
{
    public TreeNode<T> Root { get; private set; }

    public Tree(T rootValue)
    {
        Root = new TreeNode<T>(rootValue);
    }

    public TreeNode<T> Find(TreeNode<T> node, T value)
    {
        if (EqualityComparer<T>.Default.Equals(node.Value, value))
            return node;

        foreach (var child in node.Children)
        {
            var result = Find(child, value);
            if (result != null) return result;
        }

        return null;
    }

    public int GetHeight(TreeNode<T> node)
    {
        if (node.Children.Count == 0)
            return 0;

        int maxHeight = 0;
        foreach (var child in node.Children)
        {
            maxHeight = Math.Max(maxHeight, GetHeight(child));
        }

        return 1 + maxHeight;
    }

    public void TraversePreOrder(TreeNode<T> node, Action<T> action)
    {
        if (node == null || action == null) return;
        action(node.Value);
        foreach (var child in node.Children)
        {
            TraversePreOrder(child, action);
        }
    }
}
