using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree_078
{
    class Node
    {
        public string info;
        public Node leftchild;
        public Node rightchild;

        // Constructor for the Node Class

        public Node(string i, Node l, Node r)
        {
            info = i;
            leftchild = l;
            rightchild = r;
        }
    }
    /* A node class consists of the three things, the information,
     * references to the right child, references to the right child, and references to the left child*/

    class Program
    {
        public Node ROOT;
        public Program()
        {
            ROOT = null; /*Initializing ROOT to null */
        }
        public void search(string element, ref Node parent, ref Node currentNode)
        {
            /* This function search the currentNode of the specified Node as well as the current Node of its parents */
            currentNode = ROOT;
            parent = null;
            while((currentNode != null) && (currentNode.info != element))
            {
                parent = currentNode;
                if (string.Compare(element, currentNode.info) < 0)
                    currentNode = currentNode.leftchild;
                else
                    currentNode = currentNode.rightchild;
            }
        }
        public void insert(string element)/* Insert a node in the binary search tree */
        {
            Node tmp, parent = null, currentNode = null;
            search(element, ref parent, ref currentNode);
            if (currentNode != null)/* Check if the node to be inserted already
                                     * inserted or not*/
            {
                Console.WriteLine("Duplicate words not allowed");
                return;
            }
            else /* If the specified node is not parent*/
            {
                tmp = new Node(element, null, null); /* creates a Node */
                if (parent == null) /* If the trees is empty */
                {
                    ROOT = tmp;
                }
                else if (string.Compare(element, parent.info) < 0)
                {
                    parent.leftchild = tmp;
                }
                else
                {
                    parent.rightchild = tmp;
                }
            }
        }
        public void inorder(Node ptr)
        {
            if(ROOT == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }
            if (ptr != null)
            {
                inorder(ptr.leftchild);
                Console.WriteLine(ptr.info + "");
                inorder(ptr.rightchild);
            }
        }
        public void preorder (Node ptr)
        {
            if (ROOT == null)
            {
                Console.WriteLine("Tree is EMpty");
                return;
            }
            if (ptr != null)
            {
                Console.WriteLine(ptr.info + "");
                preorder(ptr.leftchild);
                preorder(ptr.rightchild);
            }
        }
        public void postorder(Node ptr)/* Perfores the postorder traversal
                                        * of the three*/
        {
            if (ROOT == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }
            if (ptr != null)
            {
                postorder(ptr.leftchild);
                postorder(ptr.rightchild);
                Console.WriteLine(ptr.info + "");
            }
        }
        static void Main(string[] args)
        {
            Program x = new Program();
            while (true)
            {
                Console.WriteLine("\nMenu");
                Console.WriteLine("1. Implement insert option");
                Console.WriteLine("2. Perform inorder traversal");
                Console.WriteLine("3. Perform preorder traversal");
                Console.WriteLine("4. Perform postorder traversal");
                Console.WriteLine("5. Exit");
                Console.WriteLine("\n Enter your choice (1-5) :");
                char ch = Convert.ToChar(Console.ReadLine());
                Console.WriteLine();
                switch (ch)
                {
                    case '1':
                        {
                            Console.Write("Enter a word: ");
                            string word = Console.ReadLine();
                            x.insert(word);
                        }
                        break;
                    case '2':
                        {
                            x.inorder(x.ROOT);
                        }
                        break;
                    case '3':
                        {
                            x.preorder(x.ROOT);
                        }
                        break;
                    case '4':
                        {
                            x.postorder(x.ROOT);
                        }
                        break;
                    case '5':
                        return;
                    default:
                        {
                            Console.WriteLine("Invalid option");
                            break;
                        }
                }
            }
        }
    }
}
