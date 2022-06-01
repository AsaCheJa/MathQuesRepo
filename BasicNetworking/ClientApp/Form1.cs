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
using System.Threading.Tasks;

namespace ClientApp
{
    public partial class ClientForm : Form
    {
        public bool exitStatus = false;
        public const int BYTE_SIZE = 1024;
        public const string HOST_NAME = "localhost";
        public const int PORT_NUMBER = 8888;

        // set up a client connection for TCP network service
        private TcpClient clientSocket;
        // set up data stream object
        private NetworkStream netStream;
        // set up thread to run ReceiveStream() method
        private Thread clientThread = null;
        // set up delegate
        delegate void SetTextCallback (string text);


        public ClientForm()
        {
            InitializeComponent();

            // clear all text boxes
            SystemMsg_TextBox.Text = "Error messages appear here ...";
            Send_TextBox.Text = "Enter text here and press send button...";
            Receive_TextBox.Text = "";

            // start client
            StartClient();

        }

        private void StartClient()
        {
            try
            {
                // create TCPClient object (as the socket)
                clientSocket = new TcpClient(HOST_NAME, PORT_NUMBER);
                // create stream
                netStream = clientSocket.GetStream();
                // set up thread to run ReceiveStream() method
                clientThread = new Thread(ReceiveStream);
                // start thread
                clientThread.Start();
                Receive_TextBox.Text = "Client started ..." + Environment.NewLine;
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
            while (! exitStatus)
            {
                try
                {
                    int bytesRead = netStream.Read(bytesReceived, 0, bytesReceived.Length);
                    this.SetText(Encoding.ASCII.GetString(bytesReceived, 0, bytesRead));

                }
                catch (System.IO.IOException)
                {
                    Console.WriteLine("Server has exited!");
                    exitStatus = true;
                }
            }

        }

        private void SetText (string text)
        {
            // InvokeRequired compares the thread ID of the
            // calling thread to the thread ID ofthe creating thread.
            // if these threads are different, it returns true.
            if (this.Receive_TextBox.InvokeRequired)
            {
                // d is a Delegate reference to the SetText() method
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.Receive_TextBox.Text += "Server: " + text + Environment.NewLine;
                Send_TextBox.Text = "";
            }
        }

        private void Send_Button_Click(object sender, EventArgs e)
        {
            // send message in Send_TextBox if any text present
            if (Send_TextBox.MaxLength > 0)
            {
                // construct byte array to stream in write mode
                String strToSend = Send_TextBox.Text;
                byte[] bytesToSend = Encoding.ASCII.GetBytes (strToSend);
                netStream.Write(bytesToSend, 0, bytesToSend.Length);
                Receive_TextBox.Text += "Client: " + strToSend + Environment.NewLine;
                Send_TextBox.Text = "";

            }
        }

        private void ClientApp_FormClosed(object sender, FormClosedEventArgs e)
        {
            // terminate client thread if still running
            if (clientThread.IsAlive)
            {
                Console.WriteLine("Client thread is alive");
                clientThread.Interrupt();
                if (clientThread.IsAlive)
                {
                    Console.WriteLine("Client thread is now terminated");
                }
            }
            else
            {
                Console.WriteLine("Client thread is terminated");
            }

            // close the application for good
            Environment.Exit(0);
        }

    }
}
