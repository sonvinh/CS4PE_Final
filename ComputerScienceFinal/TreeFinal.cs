using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerScienceFinal
{
    public static class TreeFinal
    {
        class Tree 
        { 
            public TreeNODE root;
            public int height; 

            public Tree() 
            {
                 root = null;
            }
            public Tree (Tree tr)
            {
                this.root = tr.root;
            } 
        // kiểm tra độ dài của tree
            public int getHeight()
            {
                if (root == null)
                    return 0;
                else
                    return getHeight(root);
            }
        // lấy độ dài của tree
            public int getHeight(TreeNODE current)
            {
                int countLeft = 0;
                int countRight = 0;

                if (current.left != null)
                {
                    countLeft = getHeight(current.left);
                }
                if (current.right != null)
                {
                    countRight = getHeight(current.right);
                }
                if (countLeft > countRight)
                    return countLeft + 1;
                else
                    return countRight + 1;
            }   
        // kiểm tra phần tử trong cây
            public int getChild()
            {
                if (root == null)
                    return 0;
                else
                    return getChild(root);
            }
        // đếm phần tử trong cây
            public int getChild(TreeNODE current)
            {
                int count = 0;
                if (current != null)
                {
                    count++;
                    count += getChild(current.left);
                    count += getChild(current.right);
                }
                return count;
        }
        // kiểm tra lá của cây
            public int getLeaves()
            {
                return getLeaves(root);
            }
        // đếm lá của cây
            public int getLeaves(TreeNODE current)
            {
                if (current == null)
                    return 0;
                if (current.left == null && current.right == null)
                {
                    return 1;
                }
                else
                {
                    return getLeaves(current.left) + getLeaves(current.right);
                }
            }
        // trả về Root
            public TreeNODE getRoot()
            {
                return root;
            }
        // kiểm tra có phải là cha hay không
            public TreeNODE getParent(TreeNODE T)
            {
                return getParent(root, T);
            }
        // tìm node cha
            public TreeNODE getParent(TreeNODE currentRoot, TreeNODE T)
            {
                if (currentRoot == null || T == null)
                    return null;
                else
            {
                if (currentRoot.left.data == T.data || currentRoot.right.data == T.data)
                    return currentRoot;
                else
                {
                    if (currentRoot.data > T.data)
                        return getParent(currentRoot.left, T);
                    else
                        return getParent(currentRoot.right, T);
                }
                
            }
        }
        // tìm bên trái 
            public TreeNODE getLeftSibling(TreeNODE T)
            {
                if (T == null || getRoot() == T)
                    return null;
                TreeNODE parent = getParent(T);
                if (parent.left != T && parent.left != null && parent.left.data != T.data)
                {
                    return parent.left;
                }
                else
                {
                    return null;
                }
            }
        // tìm bên phải
            public TreeNODE getRightSibling(TreeNODE T)
            {
                if (T == null || getRoot() == T)
                    return null;

                TreeNODE parent = getParent(T);

                if (parent.right != T && parent.right != null && parent.right.data != T.data)
                {
                    return parent.right;
                }
                else
                {
                    return null;
                }
            }   
        // thêm phần tử vào cây
            public void InsertNode(int Data)
            {
                if (root == null)
                    root = new TreeNODE(Data);
                else
                    root.Insert(Data);
            }
        // sắp xếp theo thứ tự Node -> Left -> Right
            public void PreOrderTraverse(TreeNODE node)
            {
                if (node == null)
                    return;
                Console.Write(node.data + " ");
                PreOrderTraverse(node.left);
                PreOrderTraverse(node.right);
            }
        // sắp xếp theo thứ tự Left -> Node -> Right
            public void InOrderTraverse(TreeNODE node)
            {
                if (node == null)
                    return;
                InOrderTraverse(node.left);
                Console.Write(node.data + " ");
                InOrderTraverse(node.right);
            }
        // sắp xếp theo thứ tự Left -> Right -> Node
            public void PostOrderTraverse(TreeNODE node)
            {
                if (node == null)
                    return;
                PostOrderTraverse(node.left);
                PostOrderTraverse(node.right);
                Console.Write(node.data + " ");
            }
        // tham chiếu tới 3 hàm trên
            public void PreOrderTraverse()
            {
                PreOrderTraverse(root);
            }

            public void InOrderTraverse()
            {
                InOrderTraverse(root);
            }

            public void PostOrderTraverse()
            {
                PostOrderTraverse(root);
            }
        // kiểm tra có search
            public TreeNODE Search(int Data)
            {
                return Search(root, Data);
            }
        // tìm kiếm trong cây
            public TreeNODE Search(TreeNODE node, int Data)
            {
                if (node == null)
                    return null;
                if (node.data == Data)
                    return node;
                if (node.data > Data)
                    return Search(node.left, Data);
                else if (node.data < Data)
                    return Search(node.right, Data);
                else
                    return null;
            }
            
        }
        public static void RunTree()
        {
            Tree tr = new Tree();
            for (int i = 0; i <= 8; i++)
            {
                Console.Write("Nhap vao phan tu thu {0}: ", i + 1);
                int num = int.Parse(Console.ReadLine());
                tr.InsertNode(num);
            }

            Console.Write("Kiem Tra Do Dai Cua Cay:");
            Console.Write(tr.getHeight());

            Console.Write("Kiem Tra Phan Tu Cua Cay:");
            Console.Write(tr.getChild());

            Console.Write("\nPre-Order Traverse: ");
            tr.PreOrderTraverse();

            Console.Write("\nIn-Order Traverse: ");
            tr.InOrderTraverse();

            Console.Write("\nPost-Order Traverse: ");
            tr.PostOrderTraverse();

            Console.Write("\nInput Search Tree: ");
            int n = int.Parse(Console.ReadLine());

            if (tr.Search(n) != null)
            {
                Console.WriteLine("Ton Tai Phan tu" + n + "Trong Tree");
            }
            else
            {
                Console.WriteLine("Khong Ton Tai Phan tu" + n + "Trong Tree");
            }

        }
    }
}
