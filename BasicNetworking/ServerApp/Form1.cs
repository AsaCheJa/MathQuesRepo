using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;


namespace ServerApp
{
    public partial class ServerForm : Form
    {
        public bool exitStatus = false;
        public const int BYTE_SIZE = 1024;
        public const int PORT_NUMBER = 8888;

        // listens for and accept incoming connection requests
        private TcpListener serverListener;

        // TcpClient is used to connect with the TcpListener object
        private TcpClient serverSocket;

        // set up data strea object
        private NetworkStream netStream;

        // set up thread to run ReceiveStream() method
        private Thread serverThread = null;

        // set up delegate
        // a delegate is a reference variable to a method
        // and used for a call back by the delegate object
        // delegate ref variable is declared in SetText() method below
        delegate void SetTextCallback (string text);

        public ServerForm()
        {
            InitializeComponent();
             // clear all text boxes
            SystemMsg_TextBox.Text = "Error messages appear here ...";
            Send_TextBox.Text = "Enter text here and press send button ...";
            Receive_TextBox.Text = "";
            // run server
            StartServer();

        }

        private void StartServer()
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
                Receive_TextBox.Text = "Server started ..." + Environment.NewLine;

            }
            catch (Exception e)
            {
                // display exception message
                SystemMsg_TextBox.Text = e.StackTrace;
            }
        }

        // this method runs as a thread (called by serverThread)
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
                    Console.WriteLine("Client has exited!");
                    exitStatus = true;
                }
            }
        }

        private void SetText (string text)
        {
            // InvokeRequired compares the thread ID of the 
            // calling thread to the thread ID of the creating thread.
            // if these threads are different, it returns true.
            if (this.Receive_TextBox.InvokeRequired)
            {
                // d is a Delegate reference to the SetText() method
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.Receive_TextBox.Text += "Client: " + text + Environment.NewLine;
            }
        }

        private void Send_Button_Click(object sender, EventArgs e)
        {
            // send message in Send_TextBox if any text present
            if (Send_TextBox.Text.Length > 0)
            {
                // construct byte array to stream in write mode
                String strToSend = Send_TextBox.Text;
                byte[] bytesToSend = Encoding.ASCII.GetBytes (strToSend);
                netStream.Write(bytesToSend, 0, bytesToSend.Length);
                Receive_TextBox.Text += "Server: " + strToSend + Environment.NewLine;
                Send_TextBox.Text = "";

            }
        }

        private void ServerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // terminate thread if still running
            if (serverThread.IsAlive)
            {
                Console.WriteLine("Server thread is alive");
                serverThread.Interrupt();
                if (serverThread.IsAlive)
                {
                    Console.WriteLine("Server thread is now terminated");
                }
                else
                {
                    Console.WriteLine("Server thread is terminated");
                }
                // close the application for good
                Environment.Exit(0);
            }
        }
    }
}
