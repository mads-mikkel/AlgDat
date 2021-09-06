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

    public interface IDataStructure<T>
    {
        int Count { get; }
        bool IsEmpty => Count == 0; // C# 9 default interface implementation. Runtime support only for .NET 5+.
    }

    public interface ITree<T>: IDataStructure<T>
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

    public abstract class Tree<T>: DataStructure<T>
    {
        private TreeNode<T> root;

        public Tree(TreeNode<T> root)
        {
            Root = root;
            count++;
        }

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

    public abstract class DataStructure<T>: IDataStructure<T>
    {
        private protected int count;

        public int Count => count;
    }

    public class LinkedList<T>
    {
        public LinkedListNode<T> Head { get; private set; }

        public void Add(T item)
        {
            if(Head is null)
            {
                Head = new LinkedListNode
                    <T>()
                { Item = item };
                //count++;
            }
            else
            {
                // iterere indtil Next er null, og derefter lave en ny node og assigne den sidste node's Next property.
            }
        }
    }

    public class HashTable<TKey, TValue>: LinearDataStructure<TValue>
    {
        private const double LoadFactor = 0.8, IncreaseSizeFactor = 1.5;
        private double actualLoadFactor;
        private bool loadFactorThresholdReached;

        public HashTable() : base(1000)
        {
        }

        public virtual void Add((TKey key, TValue value) kvPair)
        {
            // Calculate hascode of key;
            uint index = Hash(kvPair.key);
            if(index >= TotalCapacity)
                ResizeTo((int)index);
            this[(int)index] = kvPair.value;
        }

        public virtual int IndexOf(TKey key) => (int)Hash(key);

        public TValue this[uint index]
        {
            get => base[(int)index];
            set => base[(int)index] = value;
        }

        public virtual bool ValueExistsFor(TKey key) =>
            this[Hash(key)] is not null;


        public virtual bool Contains(TValue value)
        {
            if(IsEmpty || value is null)
                return false;
            else
            {
                for(int i = 0; i < TotalCapacity - 1; i++)
                    if(value.Equals(this[i]))
                        return true;
                return false;
            }
        }

        protected virtual uint Hash(TKey key)
        {
            int objectHashCode = key.GetHashCode();
            int mask = objectHashCode >> 31;
            objectHashCode ^= mask;
            objectHashCode -= mask;
            objectHashCode %= TotalCapacity;
            uint hashCode = (uint)objectHashCode;
            return hashCode;
        }

        protected void CalculateLoadFactor()
        {

        }

        public override string ToString()
        {
            string output = "";
            for(int i = 0; i < TotalCapacity; i++)
            {
                if(this[i] is not null)
                {
                    output += $"i: {i} |Value: {this[i]}";
                }
            }
            return output;
        }
    }

    static class Messages
    {
        internal const string ErrorOnAddChildToNullParent = "Cannot add a child node to a null parent.";
        internal const string ErrorOnAddChildToExistingChild = "Child already exists.";
    }
}