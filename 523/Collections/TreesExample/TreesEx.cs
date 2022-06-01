/*
    ----------------------------------------------------------------------------------
    Collections in C# --- (5) Binary Tree

    NOTE: C# .NET does not specify the BinaryTree<T> class in its built-in library
    This example is using a user-defined BinaryTree<T> class

    Developed by Hans Telford
    ----------------------------------------------------------------------------------
    A tree is a data structure designed to represent data as a hierarchical tree-like structure containing nodes.
    A node itself contains data and a memory address (reference) to its parent node.
    The root node is the first node set up in memory - it contains data, but a null memory address to its parent,
    because the root node has no parent.

    Subsequent nodes are then set up as subtrees or children of the parent node. 
    These children can act as parent nodes in their own right. A parent node can have any number of child nodes.
    In computer science, a tree is considered an abstract data type.

    A binary tree is a more usable tree structure in which all data nodes must have at most two children 
    (i.e. can have 0, 1 or 2 child nodes).
    These nodes are known as left child and right child.
    The one node located above the left and right child nodes is the parent.
    
    When nodes are created, the value of the new node is first compared with the root node value.
    If the new node value is less than the root node value, the new node is then moved to the left child node position
    of the root node. If there isn't any, then a new left child node is created under the root node.
    If there is an existing left child for the root, then the new node value is compared with the left child node value.
    If the new node value is less than the left child node value, then a new node is created in this position.
    If the new node value is greater than the node value, then a new node is created in the right child position.
    So, in all, the node values on the left side are less than the root node value and the node values on the right side
    are greater than the root node value --- refer example below.

    This type of Binary Tree is known as the Binary Search Tree in C# because it is very useful and fast for searching data.
    It has an O(n*logn) algorithm performance efficiency.
    Refer: Big O notation link - https://mytechnetknowhows.wordpress.com/2014/12/20/o-notation-with-c-csharp-my-take/
    
    There can only be one root node (the original parent).
    All nodes except the root, have only one parent

                                               Root Node
                                              -----------
                                                   |
                                    ---------------------------------
                                    |                               |
                                Left Child                     Right Child
                                ----------                     -----------
                                    |                               |         
                       --------------------------            ---------------
                       |                        |            |              |
                   Left Child              Right Child   Left Child    Right Child
    

    Binary Tree example: 
    Order of insertion: 16, 24, 15, 13, 18, 56, 13, 19, 17 (NOTE: The second value of 13 is rejected as it is a duplicate)

                                               [16]
                                                 |
                                         -----------------
                                     [15]                  [24]
                                       |                    |
                                 --------------        -------------
                             [13]                    [18]          [56]
                                                       |
                                                ---------------
                                               [17]           [19]
 
    
    To search through a Binary Tree structure, some traversal methods are used:

    1. Breadth-first traversal method is a technique which visits all the nodes at the same depth or level
    before visiting the nodes at the next level (left to right). This is a level order search.
    e.g.    first:  16 for Level 0; 
            second: 15 and 24 for Level 1; 
            third:  13, 18 and 56 for Level 2 
            and finally:
                    17 and 19 for Level 3.

    2. Depth-first search method is a technique which generally visits length-ways along a specified pathway 
    which is prioritised according to what nodes are visited (e.g. Left-Right-Root)
    For example: visiting the left sub-tree first, then the right sub-tree and then finally, the root node 
    (This is known as the Postorder traversal - refer example below).
    
    There are generally 3 traversal strategies utilised in the depth-first method:

   2.1 Inorder traversal
       Always produces an ascending sorted output
       - must visit the left subtree node, then the root node and then the right subtree node (L-Root-R)
       - when visiting the subtrees, you take the same steps
       e.g. 13, 15, 16, 17, 18, 19, 24, 56

   2.2 Preorder traversal (order that might be used by a functional calculator)
       - must visit the root node first, then the left subtree and then the right subtree (Root-L-R)
       e.g. 16, 15, 13, 24, 18, 17, 19, 56

   2.3 Postorder traversal (used in "reverse Polish" notation calculators that use a stack for their calculations)
       - must visit the left subtree, then the right subtree and finally the root node (L-R-Root)
       - the root value is always last
       e.g. 13, 15, 17, 19, 18, 56, 24, 16
   
   Refer: https://www.journaldev.com/35001/binary-tree-traversal-preorder-inorder-postorder

   The implementation for these 3 depth-first traversal types uses recursion in this example.

   MSDN documentation on Binary Trees:
   Creating Binary Trees
   https://msdn.microsoft.com/en-us/library/aa227489(v=vs.60).aspx
   An Extensive Examination of Data Structures using C# 2.0
   Part 3 Binary Trees and BSTs
   https://msdn.microsoft.com/en-us/library/ms379572(v=vs.80).aspx

    The example uses 3 files - "TreesEx.cs", "Node.cs" and "BinaryTree.cs".
    The Node class contains a data component and two memory addresses to each of its child nodes and is the
    basis of a single node in a binary tree data structure.

    The Binary Tree class contains null, one or several nodes. They are added into the binary tree according
    to the rule that all data values less than its parent node will be placed to the left of the parent node,
    and all data values greater than its parent node will be placed to the right of the parent node.

    Source code is error-free and was tested in MS Visual Studio 2022 (Community Edition) as at 20th April, 2022
    Hans Telford

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesExample
{
    /********************************************************************************/
    // Binary Tree examples set up in Main() method
    /********************************************************************************/
    class TreesEx
    {
        static void Main(string[] args)
        {
            /********************************************************************************/
            // Binary Tree of integers
            /********************************************************************************/
            // 1. Declare data variables needed for this program
            // Create a binary tree and insert 10 elements (one is a duplicate and will be ignored)
            BinaryTree<int> btIntegers = new BinaryTree<int>();

            // display header
            Console.WriteLine("*************************************************");
            Console.WriteLine("*******      Binary Tree<int> Example     *******");
            Console.WriteLine("*************************************************");
            Console.WriteLine();

            // 2. Add integer values to the binary tree btIntegers
            // Order of insertion: 16, 24, 15, 13, 18, 56, 13, 19, 17
            btIntegers.Add (16);
            btIntegers.Add (24);
            btIntegers.Add (15);
            btIntegers.Add (13);
            btIntegers.Add (18);
            btIntegers.Add (56);
            btIntegers.Add (13);
            btIntegers.Add (19);
            btIntegers.Add (17);

            Console.WriteLine();
            // 3. Display binary tree details
            Console.WriteLine("Binary tree node insertion complete!");
            Console.WriteLine("There are " + btIntegers.GetCount() + " inserted nodes in total");
            Console.WriteLine("Height of binary tree is: " + btIntegers.GetHeight(btIntegers.GetRoot()));
            Console.WriteLine("**************************************************");

            // display elements using a breadth-first traversal method
            // code utilises a queue (FIFO data structure) to implement this method
            // displaying data in each node moving left to right via level
            // level 0 is where the root node lies (containing the value of 16)
            // level 1 is where the root's left child and root's right child exists
            Console.WriteLine("Breadth-First traversal of elements using queue ...");
            btIntegers.DisplayBreadthFirst();
            Console.WriteLine();
            Console.WriteLine("**************************************************");
            
            // display elements using the standard depth-first traversal method
            // code utilises a stack (FILO data structure) to implement this method
            // displaying data in each node moving down the node's right side
            // using the priority of Root-R-L
            Console.WriteLine("Depth-First traversal using stack (Root-R-L) ...");
            btIntegers.DisplayDepthFirst();
            Console.WriteLine();
            Console.WriteLine("**************************************************");

            // display elements in the numerical order
            Console.WriteLine("Inorder (depth-first) traversal of elements (L-Root-R) ...");
            btIntegers.NodeValues = "";
            btIntegers.Inorder(btIntegers.GetRoot());
            Console.WriteLine(btIntegers.NodeValues);
            Console.WriteLine();
            Console.WriteLine("**************************************************");

            // display elements preorder which means traversing the list from
            // root along the left side first (left side holds all values < root)
            // then traversing the right side last (which holds all values > root)
            // e.g. 16 (root) - 15 - 13 (left)- 24 - 18 - 17 - 19 - 56 - (right)
            Console.WriteLine("Preorder (depth-first) traversal of elements (Root-L-R) ...");
            btIntegers.NodeValues = "";
            btIntegers.Preorder(btIntegers.GetRoot());
            Console.WriteLine(btIntegers.NodeValues);
            Console.WriteLine();
            Console.WriteLine("**************************************************");

            // display elements starting with left side first (not root) in reverse
            // then following on the right side; finally ending on the root
            // e.g. 13 - 15 (left reverse) - 17 - 19 - 18 - 56 - 24 (right reverse) - 16 - (root)
            Console.WriteLine("Postorder (depth-first) traversal of elements (L-R-Root) ...");
            btIntegers.NodeValues = "";
            btIntegers.Postorder(btIntegers.GetRoot());
            Console.WriteLine(btIntegers.NodeValues);
            Console.WriteLine();
            Console.WriteLine("**************************************************");

            Console.Write("Enter a value to search ==> ");
            int valueToSearch = Int32.Parse(Console.ReadLine());
            Console.WriteLine();

            if (btIntegers.Contains(valueToSearch))
            {
                Console.WriteLine(valueToSearch + " found!");
            }
            else
            {
                Console.WriteLine(valueToSearch + " not found");
            }

            Console.WriteLine();

            /********************************************************************************/
            // Binary Tree of strings
            /********************************************************************************/

            Console.WriteLine("*************************************************");
            Console.WriteLine("*******    Binary Tree<string> Example    *******");
            Console.WriteLine("*************************************************");
            Console.WriteLine();
            BinaryTree<string> btFilms = new BinaryTree<string>();
            btFilms.Add("Howl's Moving Castle");
            btFilms.Add("Spirited Away");
            btFilms.Add("Princess Mononoke");
            btFilms.Add("My Neighbour Totoro");
            btFilms.Add("Nausicaa of the Valley of the Wind");
            Console.WriteLine();
            // Display list in alphabetic order
            Console.WriteLine("Inorder traversal of strings ...");
            btFilms.Inorder(btFilms.GetRoot());
            Console.WriteLine(btFilms.NodeValues);
            Console.WriteLine();

            /********************************************************************************/
            // Binary Tree of DateTime objects
            /********************************************************************************/

            Console.WriteLine("*************************************************");
            Console.WriteLine("*******   Binary Tree<DateTime> Example   *******");
            Console.WriteLine("*************************************************");
            Console.WriteLine();
            BinaryTree<DateTime> btDates = new BinaryTree<DateTime>();
            btDates.Add(new DateTime(2000, 1, 1));
            btDates.Add(new DateTime(2030, 12, 25)); // future date-time
            btDates.Add(DateTime.Today); // current date-time
            btDates.Add(DateTime.Today.AddDays(-1));  // yesterday
            btDates.Add(DateTime.Today.AddDays(1)); // tomorrow
            Console.WriteLine();
            // Display list in alphabetic order
            Console.WriteLine("In-order traversal of dates ...");
            btDates.Inorder(btDates.GetRoot());
            Console.WriteLine(btDates.NodeValues);
            Console.WriteLine();

            /********************************************************************************/
            // Binary Tree of mathematical string values (for use in a calculator process)
            /********************************************************************************/

            Console.WriteLine("*************************************************");
            Console.WriteLine("*******   Binary Tree<string> Example     *******");
            Console.WriteLine("*************************************************");
            Console.WriteLine();
            BinaryTree<string> btCalculation = new BinaryTree<string>();
            btCalculation.Add("12");
            btCalculation.Add("+");
            btCalculation.Add("14");
            btCalculation.Add("=");
            btCalculation.Add("26");
            Console.WriteLine();
            // Display calculation list in in-order
            Console.WriteLine("**************************************************");
            Console.WriteLine("In-order traversal of calculator elements ...");
            btCalculation.NodeValues = "";
            btCalculation.Inorder(btCalculation.GetRoot());
            Console.WriteLine(btCalculation.NodeValues);

            // Display calculation list in pre-order
            Console.WriteLine("**************************************************");
            Console.WriteLine("Pre-order traversal of calculator elements ...");
            btCalculation.NodeValues = "";
            btCalculation.Preorder(btCalculation.GetRoot());
            Console.WriteLine(btCalculation.NodeValues);

            // Display calculation list in post-order
            Console.WriteLine();
            Console.WriteLine("**************************************************");
            Console.WriteLine("Post-order traversal of calculator elements ...");
            btCalculation.NodeValues = "";
            btCalculation.Postorder(btCalculation.GetRoot());
            Console.WriteLine();
            Console.WriteLine(btCalculation.NodeValues);


            /********************************************************************************/
            // Binary Tree of MathQues objects (from MathQues class)
            /********************************************************************************/
            Console.WriteLine("*************************************************");
            Console.WriteLine("*******   Binary Tree<MathQues> Example   *******");
            Console.WriteLine("*************************************************");
            Console.WriteLine();
			// Exercise
			// Create a Binary Tree data structure named "btQuiz" using your MathQues class you have created
			// Create new MathQues instances for the following and add them to your btQuiz binary tree
			// 11 - 6 =  5
			// 15 - 6 =  9
			// 20 / 2 = 10
			// 10 + 2 = 12
			//  7 + 6 = 13
			//  7 * 2 = 14
			// 11 + 4 = 15
			//  4 * 4 = 16
			
			// TO DO
            BinaryTree<MathQues> btQuiz = new BinaryTree<MathQues>();
            MathQues q1 = new MathQues(11, 6, "-", 5);
            MathQues q2 = new MathQues(15, 6, "-", 9);
            MathQues q3 = new MathQues(20, 2, "/", 10);
            MathQues q4 = new MathQues(10, 2, "+", 12);
            MathQues q5 = new MathQues(7, 6, "+", 13);
            MathQues q6 = new MathQues(7, 2, "*", 14);
            MathQues q7 = new MathQues(11, 4, "+", 15);
            MathQues q8 = new MathQues(4, 4, "*", 16);

            btQuiz.Add(q6);
            btQuiz.Add(q1);
            btQuiz.Add(q2);
            btQuiz.Add(q3);
            btQuiz.Add(q5);
            btQuiz.Add(q7);
            btQuiz.Add(q8);
            btQuiz.Add(q4);

            // Display Math Quiz list in in-order traversal
            Console.WriteLine("In-order traversal ...");
            // TO DO
            btQuiz.NodeValues = "";
            btQuiz.Inorder(btQuiz.GetRoot());
            Console.WriteLine(btQuiz.NodeValues);
            Console.WriteLine();



            // Display Math Quiz list in pre-order traversal
            Console.WriteLine();
            Console.WriteLine("**************************************************");
            Console.WriteLine("Pre-order traversal ...");
            // TO DO
            btQuiz.NodeValues = "";
            btQuiz.Preorder(btQuiz.GetRoot());
            Console.WriteLine(btQuiz.NodeValues);
            Console.WriteLine();


            // Display Math Quiz list in post-order
            Console.WriteLine();
            Console.WriteLine("**************************************************");
            Console.WriteLine("Post-order traversal ...");
            // TO DO
            btQuiz.NodeValues = "";
            btQuiz.Postorder(btQuiz.GetRoot());
            Console.WriteLine(btQuiz.NodeValues);
            Console.WriteLine();


            /********************************************************************************/
            // Binary Tree of Friend objects (from Friend class)
            /********************************************************************************/
            Console.WriteLine("*************************************************");
            Console.WriteLine("*******    Binary Tree<Friend> Example    *******");
            Console.WriteLine("*************************************************");
            Console.WriteLine();
			// Exercise
			// Create a Binary Tree data structure named "btFriends" using the provided Friend class
			// Add the cast of the television series "Friends"
			// Jennifer Aniston - born 02-Nov-1969
			// Courtney Cox - born 15-Jun-1964
			// Lisa Kudrow - born 30-Jul-1963
			// Matt LeBlanc - born 25-Jul-1967
			// Matthew Perry - born 19-Aug-1969
			// David Schwimmer - born 02-Nov-1966
			
			// TO DO
            BinaryTree<Friend> btFriends = new BinaryTree<Friend>();
            btFriends.Add(new Friend("Jennifer", "Aniston", new DateTime(1969, 11, 2)));
            btFriends.Add(new Friend("Courtney", "Cox", new DateTime(1964, 6, 15)));
            btFriends.Add(new Friend("Lisa", "Kudrow", new DateTime(1963, 7, 30)));
            btFriends.Add(new Friend("Matt", "LeBlanc", new DateTime(1967, 7, 25)));
            btFriends.Add(new Friend("Matthew", "Perry", new DateTime(1969, 8, 19)));
            btFriends.Add(new Friend("David", "Schwimmer", new DateTime(1966, 11, 2)));
            
            // Display Binary Tree Friend object in in-order traversal
            Console.WriteLine();
            Console.WriteLine("In-order traversal for Friends elements ...");
            // TO DO
            btFriends.NodeValues = "";
            btFriends.Inorder(btFriends.GetRoot());
            Console.WriteLine(btFriends.NodeValues);
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

        }
    }
}
