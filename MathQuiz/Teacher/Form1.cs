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

namespace Teacher
{

    public partial class Form1 : Form
    {

        private List<MathQues> mathList;
        private int currentMathQues;
        
        public Form1()
        {
            InitializeComponent();
            
            mathList = new List<MathQues>();

        }
        
        
        
        /*****************************************************************/
        // Method:  ServerTeacher() constructor
        // Purpose:
        // Input:
        // Outputs:    
        /****************************************************************/
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
        
        public void ServerTeacher()
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
            byte[] bytesReceived = new byte [BYTE_SIZE];
            // loop to read any incoming messages
            while (!exitStatus)
            {
                try
                {
                    int bytesRead = netStream.Read (bytesReceived, 0, bytesReceived.Length);
                    this.SetText(Encoding.ASCII.GetString(bytesReceived, 0, bytesRead));
                }
                catch (System.IO.IOException)
                {
                    Console.WriteLine("");
                    exitStatus = true;
                }
            }
        }
        
        private void SetText(string questionToSend)
        {
            // InvokeRequired compares the thread ID of the 
            // calling thread to the thread ID of the creating thread.
            // if these threads are different, it returns true.
            if (this.binaryTree_TextBox.InvokeRequired)
            {
                // d is a Delegate reference to theSetText() method
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { questionToSend });
            }
            else
            {
                this.binaryTree_TextBox.Text += questionToSend + Environment.NewLine;
            }
        }

        private void send_Button_Click(object sender, EventArgs e)
        {
            // send math question in First number, operator and Second number
            //leftOp_TextBox.Text = this.array_DataGridView.CurrentRow.Cells[0].Value.ToString();
            //mathOp_ComboBox.Text = this.array_DataGridView.CurrentRow.Cells[1].Value.ToString();
            //rightOp_TextBox.Text = this.array_DataGridView.CurrentRow.Cells[2].Value.ToString();

            // Reference :https://stackoverflow.com/questions/7754569/how-to-fill-textboxes-from-datagridview-on-button-click-event
            int leftOp = 0;
            if (String.IsNullOrEmpty(leftOp_TextBox.Text))
            {
                MessageBox.Show("First number is missing", "{0} error(s) detected!");
            }
            else
            {
                try
                {
                    leftOp = Int32.Parse(leftOp_TextBox.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("First number is not numeric", "{0} error(s) detected!");
                }
            }
            int rightOp = 0;
            if (String.IsNullOrEmpty(rightOp_TextBox.Text))
            {
                MessageBox.Show("Second number is missing", "{0} error(s) detected!");
            }
            else
            {
                try
                {
                    rightOp = Int32.Parse(rightOp_TextBox.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Second number is not numeric", "{0} error(s) detected!");
                }
            }
        } // end send_Button_Click method


        
      


    } // end of Form

  
} // end of namespace
