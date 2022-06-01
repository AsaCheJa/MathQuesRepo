/*
 * Filename: Form1.cs
 * Purpose:  Set up Teacher(Server) GUI
 * Author:   Asami Paddison
 * Date:     20/05/2022 
 * Version:  1.0
 * Licence:  GNU
 * Note:     Sort, LinkedList, Search(HashTable)
 * 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.Collections;
using TreesExample;
using System.IO;

namespace Teacher
{

    public partial class Form1 : Form
    {

        private List<MathQues> mathList;
        private LinkedList<MathQues> mathLinkedList;
        private BinaryTree<MathQues> mathBinaryTree;
        private MathQues currentMathQues;
        private Hashtable mathHashtable;

        public bool exitStatus = false;
        public const int BYTE_SIZE = 1024;
        public const int PORT_NUMBER = 8888;

        // listens for and accept incoming connection request
        private TcpListener serverListener;
        // TcpClient is used to connect with the TcpListener object
        private TcpClient serverSocket;
        // set up data stream object
        private NetworkStream netStream;
        // set up thread to run ReceiveStream() method
        private Thread serverThread = null;
        // set up delegate
        // a delegate is a reference variable to a method
        // and used for a call back by the delegate object
        // delegate ref variable is declared in SetText() method below
        delegate void SetTextCallback(string questionToSend);
        public Form1()
        {
            InitializeComponent();
            
            // instantiate mathList
            mathList = new List<MathQues>();
            mathLinkedList = new LinkedList<MathQues>();
            mathBinaryTree = new BinaryTree<MathQues>();
            mathHashtable = new Hashtable();
            // set current record
            currentMathQues = null;
            // add questions to the tabele
            displayDataGridView();
            // sort mathList
            mathList.Sort();
            // run server
            StartTeacher();
        }



        /*****************************************************************/
        // Method:  ServerTeacher() 
        // Purpose:
        // Input:
        // Outputs:    
        /****************************************************************/

        public void StartTeacher()
        {
            try
            {
                // create listener and start
                serverListener = new TcpListener(IPAddress.Loopback, PORT_NUMBER);
                serverListener.Start();
                // create acceptance socket
                // this creates a socket connection for the server
                serverSocket = serverListener.AcceptTcpClient();
                // create stream
                netStream = serverSocket.GetStream();
                // set up thread to run ReceiveStream() method
                serverThread = new Thread(ReceiveStream);
                // start thread
                serverThread.Start();
                //array_DataGridView.Column = Environment.NewLine;
            }
            catch (Exception e)
            {
                // display exception message
                string exceptionStr = "Server Send Error: " + e.StackTrace;
                MessageBox.Show(null, exceptionStr, "SERVER SEND ERROR");
            }
        }

        public void ReceiveStream()
        {
            byte[] bytesReceived = new byte[BYTE_SIZE];
            // loop to read any incoming messages
            while (!exitStatus)
            {
                try
                {
                    int bytesRead = netStream.Read(bytesReceived, 0, bytesReceived.Length);
                    this.SetText(Encoding.ASCII.GetString(bytesReceived, 0, bytesRead));
                }
                catch (System.IO.IOException)
                {
                    Console.WriteLine("");
                    exitStatus = true;
                }
            }
        }

        private void SetText(string input)
        {
            // InvokeRequired compares the thread ID of the 
            // calling thread to the thread ID of the creating thread.
            // if these threads are different, it returns true.
            if (this.binaryTree_TextBox.InvokeRequired)
            {
                // d is a Delegate reference to theSetText() method
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { input });
            }
            else
            {
                if (input.Equals("y"))
                {
                    linkedList_TextBox.Text = "Correct";
                    
                }
                else
                {
                    linkedList_TextBox.Text = "Incorrect";
                    mathLinkedList.AddLast(currentMathQues);

                }
                send_Button.Enabled = true;
                leftOp_TextBox.Text = "";
                rightOp_TextBox.Text = "";
                answer_TextBox.Text = "";
            }
        }

      

        /*****************************************************************/
        // Method:  IsMathQuesValid() method
        // Purpose:
        // Input:
        // Outputs:    
        /****************************************************************/
        public bool IsMathQuesValid()
        {
            bool mathquesStatus = true;
            string leftOpstr = leftOp_TextBox.Text;
            string rightOpstr = rightOp_TextBox.Text;
            int leftOp;
            int rightOp;
            string errorMessage = "";

            // 1. check Left Op 
            if (String.IsNullOrEmpty(leftOpstr))
            {
                errorMessage += "First number is missing\n";
                mathquesStatus = false;
            }
            else
            {
                try
                {
                    leftOp = Int32.Parse(leftOpstr);
                }
                catch (Exception e)
                {
                    errorMessage += "First number is not numeric\n";
                    MessageBox.Show(errorMessage, "error(s) detected!");
                    return false;
                }
            }
            // 2. check Right Op
            if (String.IsNullOrEmpty(rightOpstr))
            {
                errorMessage += "Second number is missing\n";
                mathquesStatus = false;
            }
            else
            {
                try
                {
                    rightOp = Int32.Parse(rightOpstr);
                }
                catch (Exception e)
                {
                    errorMessage += "Second number is not numeric\n";
                    MessageBox.Show(errorMessage, "error(s) detected!");
                    return false;
                }
            }
            if (mathquesStatus == false)
            {
                MessageBox.Show(errorMessage, "Errors!");

            }

            return mathquesStatus;

          


        }  // end of IsMathQuesValid() method

        /*****************************************************************/
        // Method:  IsAnswerValid() method
        // Purpose:
        // Input:
        // Outputs:    
        /****************************************************************/


        private void send_Button_Click(object sender, EventArgs e)
        {
            if (IsMathQuesValid() == false)
            {
                return;
            }
            else
            {
                // create mathList Object
                string leftOpstr = leftOp_TextBox.Text;
                string rightOpstr = rightOp_TextBox.Text;
                string mathOp = mathOp_ComboBox.Text;
                int leftOp = Int32.Parse(leftOpstr);
                int rightOp = Int32.Parse(rightOpstr);
                int answer = 0;
                switch (mathOp)
                {
                    case "+":
                        answer = leftOp + rightOp;
                        break;

                    case "-":
                        answer = leftOp - rightOp;
                        break;

                    case "*":
                        answer = leftOp * rightOp;
                        break;

                    case "/":
                        answer = leftOp / rightOp;
                        break;

                }



                currentMathQues = new MathQues(leftOp, mathOp, rightOp, answer);
                string strToSend = currentMathQues.questionToSend();

                mathList.Add(currentMathQues);
                mathBinaryTree.Add(currentMathQues);
                mathHashtable.Add(strToSend, currentMathQues.ToString());


                byte[] bytesToSend = Encoding.ASCII.GetBytes(strToSend);
                netStream.Write(bytesToSend, 0, bytesToSend.Length);
                answer_TextBox.Text = answer.ToString();
                send_Button.Enabled = false;

                displayDataGridView();
            }
            
            


        } // end of send_Button_Click method

        // Add Math Questions to DataGridView
        private void displayDataGridView()
        {
            if (mathList.Count == 0)
            {
                return;
            }
            else
            {
                array_DataGridView.Rows.Clear();
                for (int i = 0; i < mathList.Count; i++)
                {
                    array_DataGridView.Rows.Add(mathList[i].GetStrArray());
                }
            }
            array_DataGridView.Refresh();
           



           
        } // end of DisplayDataGridView

        private void bubble_Button_Click(object sender, EventArgs e)
        {

            MathQues[] mathQuesArray = mathList.ToArray();
            // Bubble Sort (asc)
            if (mathList.Count == 0)
            {
               return;
            }
            
            //int swapCounter = 0;
            
            
            for (int i = 0; i < mathQuesArray.Length; i++)
            {
                for (int j = 0; j < mathQuesArray.Length - 1; j++)
                {
                    
                        if (mathQuesArray[i].Answer < mathQuesArray[j].Answer)
                        {
                            MathQues temp = mathQuesArray[i];
                            mathQuesArray[i] = mathQuesArray[j];
                            mathQuesArray[j] = temp;
                           // swapCounter++;
                        }
                    
                } // end inner for loop
            } // end outer for loop

            //reassign mathList
            mathList = new List<MathQues>(mathQuesArray);
            displayDataGridView();


        }

        private void selection_Button_Click(object sender, EventArgs e)
        {
            // Selection Sort (desc)
            if (mathList.Count == 0)
            {
                return;
            }

            MathQues[] mathQuesArray = mathList.ToArray();

            for (int i = 0; i < mathQuesArray.Length - 1; i++)
            {
                for (int j = i + 1; j < mathQuesArray.Length; j++)
                {

                    if (mathQuesArray[j].Answer > mathQuesArray[i].Answer)
                    {
                        MathQues temp = mathQuesArray[j];
                        mathQuesArray[j] = mathQuesArray[i];
                        mathQuesArray[i] = temp;
                    }

                } // end inner for loop
            } // end outer for loop

            
            //reassign mathList
            mathList = new List<MathQues>(mathQuesArray);
            displayDataGridView();
          
        }

        private void insertion_Button_Click(object sender, EventArgs e)
        {
            // insertion sort (asc)
            if (mathList.Count == 0)
            {
                return;
            }

            MathQues[] mathQuesArray = mathList.ToArray();

            for (int i = 1; i < mathQuesArray.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {

                    if (mathQuesArray[j].Answer < mathQuesArray[j - 1].Answer)
                    {
                        MathQues temp = mathQuesArray[j];
                        mathQuesArray[j] = mathQuesArray[j - 1];
                        mathQuesArray[j - 1] = temp;
                        
                    }

                } // end inner for loop
            } // end outer for loop

            //reassign mathList
            mathList = new List<MathQues>(mathQuesArray);
            displayDataGridView();
        }

        private void linkedList_Button_Click(object sender, EventArgs e)
        {
           
            
            if (mathLinkedList.Count > 0)
            {
                String displayIncorrect = "HEAD <->";
                for (int i = 0; i < mathLinkedList.Count; i++)
                {
                    displayIncorrect += mathLinkedList.ElementAt(i).ToString() + " <-> ";
                }

                 displayIncorrect += "TAIL";
                linkedList_TextBox.Text = displayIncorrect;


            }
            else
            {
                linkedList_TextBox.Text = "There are no incorrect answers";
            }


        }

        private void search_Button_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(search_TextBox.Text))
            {
                binaryTree_TextBox.Text = "No math questions have been set up";
                return;
            }
            else
            {
                                
                string quesToFind = search_TextBox.Text;
                bool foundStatus = mathHashtable.ContainsKey(quesToFind);
                if (foundStatus)
                {
                   
                    binaryTree_TextBox.Text = quesToFind.ToString() + "  found!";
                   
                }
                else
                {
                    binaryTree_TextBox.Text = quesToFind.ToString() + "  NOT found!";
                }
            }
            

           
        }

        private void preOrderDisp_Click(object sender, EventArgs e)
        {

            if (mathList.Count() > 0)
            {
                mathBinaryTree.NodeValues = "";
                mathBinaryTree.Preorder(mathBinaryTree.GetRoot());
                String preOrderDispStr = mathBinaryTree.NodeValues;
                binaryTree_TextBox.Text = "PRE-ORDER: " + preOrderDispStr;
            }
            else
            {
                binaryTree_TextBox.Text = "No math questions have been set up";

            }

            // reassign to mathBinaryTree
            //mathBinaryTree = new BinaryTree<MathQues>();

        }

        private void preOrderSave_Click(object sender, EventArgs e)
        {
           
            if (mathBinaryTree.NodeValues.Count() == 0) 
            {
                MessageBox.Show("There is no question to save...", "No questions");
                return;
            }
            try
            {
                 if (mathBinaryTree.NodeValues.Count() > 0)
                 {
                      mathBinaryTree.NodeValues = "";
                      mathBinaryTree.Preorder(mathBinaryTree.GetRoot());
                      String preOrderDispStr = mathBinaryTree.NodeValues;
                      
                 }
                File.WriteAllText("Pre-Order.text", binaryTree_TextBox.Text);
                MessageBox.Show("Pre-Order Saved", "Saved");

            }
            
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: Problem in writing to external file!");
            }

        }

       
        private void inOrderDisp_Click(object sender, EventArgs e)
        {

            
            if (mathBinaryTree.NodeValues.Count() > 0)
            {
                mathBinaryTree.NodeValues = "";
                mathBinaryTree.Inorder(mathBinaryTree.GetRoot());
                String inOrderDispStr = mathBinaryTree.NodeValues;
                binaryTree_TextBox.Text = "IN-ORDER: " + inOrderDispStr;

            }
            else
            {
                binaryTree_TextBox.Text = "No math questions have been set up";
                
            }
            // reassign to mathBinaryTree
            //mathBinaryTree = new BinaryTree<MathQues>();
           
        } 

        private void inOrderSave_Click(object sender, EventArgs e)
        {
            if (mathBinaryTree.NodeValues.Count() == 0)
            {
                MessageBox.Show("There is no question to save...", "No questions");
                return;
            }
            try
            {
                if (mathBinaryTree.NodeValues.Count() > 0)
                {
                    mathBinaryTree.NodeValues = "";
                    mathBinaryTree.Inorder(mathBinaryTree.GetRoot());
                    String inOrderDispStr = mathBinaryTree.NodeValues;

                }
                File.WriteAllText("In-Order.text", binaryTree_TextBox.Text);
                MessageBox.Show("In-Order Saved", "Saved");

            }

            catch (Exception ex)
            {
                MessageBox.Show("ERROR: Problem in writing to external file!");
            }
        }

        private void postOrderDisp_Click(object sender, EventArgs e)
        {
            if (mathBinaryTree.NodeValues.Count() > 0)
            {
                mathBinaryTree.NodeValues = "";
                mathBinaryTree.Postorder(mathBinaryTree.GetRoot());
                String postOrderDispStr = mathBinaryTree.NodeValues;
                binaryTree_TextBox.Text = "POST-ORDER: " + postOrderDispStr;
            }
            else
            {
                binaryTree_TextBox.Text = "No math questions have been set up";
               
            }
            // reassign to mathBinaryTree
           // mathBinaryTree = new BinaryTree<MathQues>();
        }

        private void postOrderSave_Click(object sender, EventArgs e)
        {
            if (mathBinaryTree.NodeValues.Count() == 0)
            {
                MessageBox.Show("There is no question to save...", "No questions");
                return;
            }
            try
            {
                if (mathBinaryTree.NodeValues.Count() > 0)
                {
                    mathBinaryTree.NodeValues = "";
                    mathBinaryTree.Postorder(mathBinaryTree.GetRoot());
                    String postOrderDispStr = mathBinaryTree.NodeValues;

                }
                File.WriteAllText("Post-Order.text", binaryTree_TextBox.Text);
                MessageBox.Show("Post-Order Saved", "Saved");

            }

            catch (Exception ex)
            {
                MessageBox.Show("ERROR: Problem in writing to external file!");
            }
        }

        private void exit_Button_Click(object sender, EventArgs e)
        {
            // exit the application
            serverThread.Interrupt();

            Environment.Exit(0);

        }
    } // end of Form

  
} // end of namespace
