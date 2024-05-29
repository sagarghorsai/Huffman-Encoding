using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Huffman_Encoding
{
    public class BinaryTree<E>
    {
        private BinaryTreeNode<E> root;
        private BinaryTreeNode<E> current;
        private int size;
        private StringBuilder encoding;

        public enum Relative : int
        {
            leftChild, rightChild, parent, root
        };

        public BinaryTree()
        {
            root = null;
            current = null;
            size = 0;
            encoding = new StringBuilder();
        }

        public BinaryTree(E data)
        {
            root = new BinaryTreeNode<E>(data);
            current = null;
            size = 0;
            encoding = new StringBuilder();
        }

        // TODO: Verify this method is working properly. 
        public void Destroy(BinaryTreeNode<E> node)
        {
            if (node != null)
            {
                Destroy(node.Left);
                Destroy(node.Right);
                node = null;
                size--;
            }
        }

        public Boolean isEmpty()
        {
            return root == null;
        }

        public int Size
        {
            get
            {
                return size;
            }
        }

        public BinaryTreeNode<E> Current
        {
            get
            {
                return current;
            }
            set
            {
                current = value;
            }
        }

        public BinaryTreeNode<E> Root
        {
            get
            {
                return root;
            }
            set
            {
                root = value;
            }
        }


        /// <summary>
        // TODO:  There are 2 places where the encoding string needs to be 
        // adjusted.  Use the debugger to determine where.  One spot has been 
        // identified for you.  See the TODO comment below. 
        /// </summary>
        /// <param name="p"></param>
        public void BuildEncodingTable(BinaryTreeNode<E> p)
        {
            if (p != null)
            {
                encoding.Append("0");
                BuildEncodingTable(p.Left);

                if (p.isLeaf())
                {
                    Console.WriteLine(p.Data.ToString());
                    Console.WriteLine(encoding);
                }

                encoding.Append("1");
                BuildEncodingTable(p.Right);
            }
            else
            {
                // TODO:  Remove a character from the encoding string
                Console.WriteLine("remove!");
            }
        }

        public void preOrder(BinaryTreeNode<E> p)
        {
            if (p != null)
            {
                Console.WriteLine(p.Data.ToString());
                preOrder(p.Left);
                preOrder(p.Right);
            }
        }

        public void postOrder(BinaryTreeNode<E> p)
        {
            if (p != null)
            {
                postOrder(p.Left);
                postOrder(p.Right);
                Console.WriteLine(p.Data.ToString());
            }
        }

        public void inOrder(BinaryTreeNode<E> p)
        {
            if (p != null)
            {
                inOrder(p.Left);
                Console.WriteLine(p.Data.ToString());
                inOrder(p.Right);
            }
        }

        private BinaryTreeNode<E> findParent(BinaryTreeNode<E> n)
        {
            Stack<BinaryTreeNode<E>> s = new Stack<BinaryTreeNode<E>>();
            n = root;
            while (n.Left != current && n.Right != current)
            {
                if (n.Right != null)
                    s.Push(n.Right);

                if (n.Left != null)
                    n = n.Left;
                else
                    n = s.Pop();
            }
            s.Clear();
            return n;
        }

        public Boolean Insert(BinaryTreeNode<E> node, Relative rel)
        {
            Boolean inserted = true;

            if ((rel == Relative.leftChild && current.Left != null)
                    || (rel == Relative.rightChild && current.Right != null))
            {
                inserted = false;
            }
            else
            {
                switch (rel)
                {
                    case Relative.leftChild:
                        current.Left = node;
                        break;
                    case Relative.rightChild:
                        current.Right = node;
                        break;
                    case Relative.root:
                        if (root == null)
                            root = node;
                        current = root;
                        break;
                }
                size++;
            }

            return inserted;
        }

        public Boolean Insert(E data, Relative rel)
        {
            Boolean inserted = true;

            BinaryTreeNode<E> node = new BinaryTreeNode<E>(data);

            if ((rel == Relative.leftChild && current.Left != null)
                    || (rel == Relative.rightChild && current.Right != null))
            {
                inserted = false;
            }
            else
            {
                switch (rel)
                {
                    case Relative.leftChild:
                        current.Left = node;
                        break;
                    case Relative.rightChild:
                        current.Right = node;
                        break;
                    case Relative.root:
                        if (root == null)
                            root = node;
                        current = root;
                        break;
                }
                size++;
            }

            return inserted;
        }


        public Boolean moveTo(Relative rel)
        {
            Boolean found = false;

            switch (rel)
            {
                case Relative.leftChild:
                    if (current.Left != null)
                    {
                        current = current.Left;
                        found = true;
                    }
                    break;
                case Relative.rightChild:
                    if (current.Right != null)
                    {
                        current = current.Right;
                        found = true;
                    }
                    break;
                case Relative.parent:
                    if (current != root)
                    {
                        current = findParent(current);
                        found = true;
                    }
                    break;
                case Relative.root:
                    if (root != null)
                    {
                        current = root;
                        found = true;
                    }
                    break;
            } // end Switch relative

            return found;
        }


    }
}
