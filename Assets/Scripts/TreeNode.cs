using System;
using System.Collections.Generic;

public class TreeNode<T>
{
    public T Value { get; private set; }
    public TreeNode<T> Parent { get; private set; }
    public List<TreeNode<T>> Children { get; private set; }

    public TreeNode(T value)
    {
        Value = value;
        Children = new List<TreeNode<T>>();
    }

    public void AddChild(TreeNode<T> child)
    {
        if (child == null) return;
        child.Parent = this;
        Children.Add(child);
    }

    public bool RemoveChild(TreeNode<T> child)
    {
        if (Children.Remove(child))
        {
            child.Parent = null;
            return true;
        }
        return false;
    }
}
