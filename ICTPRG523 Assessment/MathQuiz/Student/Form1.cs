using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student
{
    public partial class Form1 : Form
    {
        public bool exitStatus = false;
        public const int BYTE_SIZE = 1024;
        public const string HOST_NAME = "localhost";
        public const int PORT_NUMBER = 8888;
        private int actualAnswer;
        // set up a client (Student) connection for TCP network service
        private TcpClient clientSocket;
        // set up data stream object
        private NetworkStream netStream;
        // set up thread to run ReceiveStream() method
        private Thread clientThread = null;
        // set up delegate
        delegate void SetTextCallback(string questionToSend);
        
        public Form1()
        {
            InitializeComponent();

            ques_TextBox.Text = "";
            StartStudent();
        }

        private void StartStudent()
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
                ques_TextBox.Text = "";
            }
            catch (Exception e)
            {
                // display exception message
                // display exception message
                string exceptionStr = "Server Send Error: " + e.StackTrace;
                MessageBox.Show(null, exceptionStr, "SERVER SEND ERROR");
            }
        }

        public void ReceiveStream()
        {
            byte[] bytesReceived = new byte [BYTE_SIZE];
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
                    Console.WriteLine("No one's there");
                    exitStatus = true;
                }
            }
        }

        private void SetText(string questionToSend)
        {
            // InvokeRequired compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // if these threads are different, it returns true.
            if (this.ques_TextBox.InvokeRequired)
            {
                // d is a Delegate reference to the SetText() method
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { questionToSend });
            }
            else
            {
                string[] splitStr = questionToSend.Split(' ');
                actualAnswer = Int32.Parse(splitStr[4]);

                this.ques_TextBox.Text = splitStr[0] + " " + splitStr[1] + " " + splitStr[2] + " =  ?";
            }

        }

        private bool ValidateAnswer()
        {
            bool answerStatus = true;
            string answerText = stuAns_textBox.Text;

            if (String.IsNullOrEmpty(answerText))
            {
                MessageBox.Show("Answer is missing", "Error!");
                answerStatus = false;
            }
            else
            {
                MessageBox.Show("Answer is not numeric", "Error!");
            }
            return answerStatus;
        }

        private void submit_Button_Click(object sender, EventArgs e)
        {
            if (!ValidateAnswer())
            {
                // send question in stuAns_TextBox
                if (stuAns_textBox.Text.Length > 0)
                {
                    // construct byte array to stream in write mode
                    string strToSend = "n";
                    int studentAnswer = Int32.Parse(stuAns_textBox.Text);
                    if (actualAnswer == studentAnswer)
                    {
                        strToSend = "y";
                        MessageBox.Show("Correct", "Correct Answer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Incorrect", "Incorrect Answer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    byte[] bytesToSend = Encoding.ASCII.GetBytes(strToSend);
                    netStream.Write(bytesToSend, 0, bytesToSend.Length);
                    ques_TextBox.Text = "";
                    stuAns_textBox.Text = "";
                }
            }
        }

        private void exit_Button_Click(object sender, EventArgs e)
        {
            // exit the application
            clientThread.Interrupt();

            Environment.Exit(0);
        }
    }
}
