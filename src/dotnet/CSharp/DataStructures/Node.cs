using System;
using System.Runtime.Serialization;

namespace CSharp.DataStructures
{
    public class Node<T>
    {
        private T item;
        public Node() : this(default) { }
        public Node(T item) => Item = item;
        public T Item { get => item; set => item = value; }
    }

    public class LinkedListNode<T>: Node<T>
    {
        private Node<T> next;
        public Node<T> Next { get => next; set => next = value; }
    }

    public class TreeNode<T>: Node<T>
    {
        private TreeNode<T> parent;

        public TreeNode() : this(default(T)) { }
        public TreeNode(T item) : base(item) { }
        public TreeNode(TreeNode<T> parent) => Parent = parent;
        public TreeNode(T item, TreeNode<T> parent) : base(item)
        {
            Parent = parent;
        }

        public TreeNode<T> Parent { get => parent; set => parent = value; }
    }

    public class BinaryTreeNode<T>: TreeNode<T>
    {
        private BinaryTreeNode<T> leftChild, rightChild;

        public BinaryTreeNode() : base() { }
        public BinaryTreeNode(T item) : base(item) { }
        public BinaryTreeNode(T item, BinaryTreeNode<T> parent) : base(item, parent) { }

        public BinaryTreeNode<T> LeftChild { get => leftChild; private set => leftChild = value; }
        public BinaryTreeNode<T> RightChild { get => rightChild; private set => rightChild = value; }

        public virtual void AddLeftChild(T item)
        {
            if(leftChild != null) throw new InvalidOperationException(Messages.ErrorOnAddChildToExistingChild);
            LeftChild = new(item, parent: this);
        }

        public virtual void AddRightChild(T item)
        {
            if(rightChild != null) throw new InvalidOperationException(Messages.ErrorOnAddChildToExistingChild);
            RightChild = new(item, parent: this);
        }
    }

    public interface INonLinearDataStructure<T>
    {
        int Count { get; }
        bool IsEmpty => Count == 0; // C# 9 default interface implementation. Runtime support only for .NET 5+.
    }

    public interface ITree<T>: INonLinearDataStructure<T>
    {
        TreeNode<T> Root { get; }
    }

    public interface IBinaryTree<T>: ITree<T>
    {
        void AddLeftChildTo(BinaryTreeNode<T> parent, T item);
        void AddRightChildTo(BinaryTreeNode<T> parent, T item);
        int GetHeight(BinaryTreeNode<T> root);
        string ToStringLevel(int level, BinaryTreeNode<T> root);
        string ToStringLevelOrder();
    }

    public abstract class Tree<T>
    {
        protected int count;
        private TreeNode<T> root;

        public Tree(TreeNode<T> root)
        {
            Root = root;
            count++;
        }

        public int Count => count;
        public TreeNode<T> Root { get => root; private set => root = value; }
    }

    public class BinaryTree<T>: Tree<T>, IBinaryTree<T>
    {
        public BinaryTree(T rootItem) : this(new BinaryTreeNode<T>(rootItem)) { }
        public BinaryTree(BinaryTreeNode<T> root) : base(root) { }

        public void AddLeftChildTo(BinaryTreeNode<T> parent, T item) => AddChildTo(parent, item, true);
        public void AddRightChildTo(BinaryTreeNode<T> parent, T item) => AddChildTo(parent, item, false);

        private void AddChildTo(BinaryTreeNode<T> parent, T item, bool addLeftChild)
        {
            if(parent is null) throw new ArgumentNullException(nameof(parent), Messages.ErrorOnAddChildToNullParent);
            if(addLeftChild) parent.AddLeftChild(item);
            else parent.AddRightChild(item);
            count++;
        }

        public int GetHeight(BinaryTreeNode<T> root)
        {
            throw new System.NotImplementedException();
        }

        public string ToStringLevel(int level, BinaryTreeNode<T> root)
        {
            throw new System.NotImplementedException();
        }

        public string ToStringLevelOrder()
        {
            throw new System.NotImplementedException();
        }
    }

    static class Messages
    {
        internal const string ErrorOnAddChildToNullParent = "Cannot add a child node to a null parent.";
        internal const string ErrorOnAddChildToExistingChild = "Child already exists.";
    }
}