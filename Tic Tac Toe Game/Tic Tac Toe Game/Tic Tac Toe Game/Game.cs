using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

namespace Tic_Tac_Toe_Game
{
    public partial class Game : Form
    {
        public Game(bool isHost, string ip = null)
        {
            InitializeComponent();
            MessageReceiver.DoWork += MessageReceiver_DoWork;
            CheckForIllegalCrossThreadCalls = false;

            if(isHost)
            {
                PlayerChar = 'X';
                OpponentChar = 'O';
                //socket
                server = new TcpListener(System.Net.IPAddress.Any, 5732);
                server.Start();
                sock = server.AcceptSocket();
            }
            else
            {
                PlayerChar = 'O';
                OpponentChar = 'X';
                try
                {
                    client = new TcpClient(ip, 5732);
                    sock = client.Client;
                    MessageReceiver.RunWorkerAsync();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
        }

        private void MessageReceiver_DoWork(object sender, DoWorkEventArgs e)
        {
            if (CheckState())
                return;
            FreezeBoard();
            label1.Text = "Opponent's Turn!";
            ReceiveMove();
            label1.Text = "Your Trun!";
            if (!CheckState())
                UnfreezeBoard();
        }

        private char PlayerChar;
        private char OpponentChar;
        private Socket sock;
        private BackgroundWorker MessageReceiver = new BackgroundWorker();
        private TcpListener server = null;
        private TcpClient client;

        private bool CheckState()
        {
            //Horizontals
            if(button1.Text == button2.Text && button2.Text == button3.Text && button3.Text == button10.Text &&  button10.Text != "")
            {
                if(button1.Text[0] == PlayerChar)
                {
                    label1.Text = "You Won!";
                    MessageBox.Show("You Won!");
                }
                else
                {
                    label1.Text = "You Lost!";
                    MessageBox.Show("You Lost!");
                }
                return true;
            }

            else if (button4.Text == button5.Text && button5.Text == button6.Text && button6.Text == button11.Text    &&  button11.Text != "")
            {
                if (button4.Text[0] == PlayerChar)
                {
                    label1.Text = "You Won!";
                    MessageBox.Show("You Won!");
                }
                else
                {
                    label1.Text = "You Lost!";
                    MessageBox.Show("You Lost!");
                }
                return true;
            }

            else if (button7.Text == button8.Text && button8.Text == button9.Text && button9.Text == button12.Text   &&  button12.Text != "")
            {
                if (button7.Text[0] == PlayerChar)
                {
                    label1.Text = "You Won!";
                    MessageBox.Show("You Won!");
                }
                else
                {
                    label1.Text = "You Lost!";
                    MessageBox.Show("You Lost!");
                }
                return true;
            }

            //Verticals
            else if (button1.Text == button4.Text && button4.Text == button7.Text && button7.Text == button16.Text && button16.Text != "")
            {
                if (button1.Text[0] == PlayerChar)
                {
                    label1.Text = "You Won!";
                    MessageBox.Show("You Won!");
                }
                else
                {
                    label1.Text = "You Lost!";
                    MessageBox.Show("You Lost!");
                }
                return true;
            }

            else if (button2.Text == button5.Text && button5.Text == button8.Text && button8.Text == button15.Text    &&  button15.Text != "")
            {
                if (button2.Text[0] == PlayerChar)
                {
                    label1.Text = "You Won!";
                    MessageBox.Show("You Won!");
                }
                else
                {
                    label1.Text = "You Lost!";
                    MessageBox.Show("You Lost!");
                }
                return true;
            }

            else if (button3.Text == button6.Text && button6.Text == button9.Text && button9.Text == button14.Text  &&  button14.Text != "")
            {
                if (button3.Text[0] == PlayerChar)
                {
                    label1.Text = "You Won!";
                    MessageBox.Show("You Won!");
                }
                else
                {
                    label1.Text = "You Lost!";
                    MessageBox.Show("You Lost!");
                }
                return true;
            }

            else if (button10.Text == button11.Text && button11.Text == button12.Text && button12.Text == button13.Text && button13.Text != "")
            {
                if (button10.Text[0] == PlayerChar)
                {
                    label1.Text = "You Won!";
                    MessageBox.Show("You Won!");
                }
                else
                {
                    label1.Text = "You Lost!";
                    MessageBox.Show("You Lost!");
                }
                return true;
            }

            else if (button16.Text == button15.Text && button15.Text == button14.Text && button14.Text == button13.Text && button13.Text != "")
            {
                if (button16.Text[0] == PlayerChar)
                {
                    label1.Text = "You Won!";
                    MessageBox.Show("You Won!");
                }
                else
                {
                    label1.Text = "You Lost!";
                    MessageBox.Show("You Lost!");
                }
                return true;
            }










            else if (button1.Text == button5.Text && button5.Text == button9.Text && button9.Text == button13.Text  &&   button13.Text != "")
            {
                if (button1.Text[0] == PlayerChar)
                {
                    label1.Text = "You Won!";
                    MessageBox.Show("You Won!");
                }
                else
                {
                    label1.Text = "You Lost!";
                    MessageBox.Show("You Lost!");
                }
                return true;
            }

            else if (button10.Text == button6.Text && button6.Text == button8.Text && button8.Text == button16.Text  &&  button16.Text != "")
            {
                if (button10.Text[0] == PlayerChar)
                {
                    label1.Text = "You Won!";
                    MessageBox.Show("You Won!");
                }
                else
                {
                    label1.Text = "You Lost!";
                    MessageBox.Show("You Lost!");
                }
                return true;
            }

            //Draw
            else if(button1.Text != "" && button2.Text != "" && button3.Text != "" && button4.Text != "" && button5.Text != "" && button6.Text != "" && button7.Text != "" && button8.Text != "" && button9.Text != "" && button10.Text != "" && button11.Text != "" && button12.Text != "" && button13.Text != "" && button14.Text != "" && button15.Text != "" && button16.Text != "" )
            {
                label1.Text = "It's a draw!";
                MessageBox.Show("It's a draw!");
                return true;
            }
            return false;
        }
        private void FreezeBoard()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button15.Enabled = false;
            button16.Enabled = false;
        }

        private void UnfreezeBoard()
        {
            if (button1.Text == "")
                button1.Enabled = true;
            if (button2.Text == "")
                button2.Enabled = true;
            if (button3.Text == "")
                button3.Enabled = true;
            if (button4.Text == "")
                button4.Enabled = true;
            if (button5.Text == "")
                button5.Enabled = true;
            if (button6.Text == "")
                button6.Enabled = true;
            if (button7.Text == "")
                button7.Enabled = true;
            if (button8.Text == "")
                button8.Enabled = true;
            if (button9.Text == "")
                button9.Enabled = true;
            if (button10.Text == "")
                button10.Enabled = true;
            if (button11.Text == "")
                button11.Enabled = true;
            if (button12.Text == "")
                button12.Enabled = true;
            if (button13.Text == "")
                button13.Enabled = true;
            if (button14.Text == "")
                button14.Enabled = true;
            if (button15.Text == "")
                button15.Enabled = true;
            if (button16.Text == "")
                button16.Enabled = true;
        }

        private void ReceiveMove()
        {
            byte[] buffer = new byte[1];
            sock.Receive(buffer);
            if (buffer[0] == 1)
                button1.Text = OpponentChar.ToString();
            if (buffer[0] == 2)
                button2.Text = OpponentChar.ToString();
            if (buffer[0] == 3)
                button3.Text = OpponentChar.ToString();
            if (buffer[0] == 4)
                button4.Text = OpponentChar.ToString();
            if (buffer[0] == 5)
                button5.Text = OpponentChar.ToString();
            if (buffer[0] == 6)
                button6.Text = OpponentChar.ToString();
            if (buffer[0] == 7)
                button7.Text = OpponentChar.ToString();
            if (buffer[0] == 8)
                button8.Text = OpponentChar.ToString();
            if (buffer[0] == 9)
                button9.Text = OpponentChar.ToString();
            if (buffer[0] == 10)
                button10.Text = OpponentChar.ToString();
            if (buffer[0] == 11)
                button11.Text = OpponentChar.ToString();
            if (buffer[0] == 12)
                button12.Text = OpponentChar.ToString();
            if (buffer[0] == 13)
                button13.Text = OpponentChar.ToString();
            if (buffer[0] == 14)
                button14.Text = OpponentChar.ToString();
            if (buffer[0] == 15)
                button15.Text = OpponentChar.ToString();
            if (buffer[0] == 16)
                button16.Text = OpponentChar.ToString();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] num = { 1 };
            sock.Send(num);
            button1.Text = PlayerChar.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] num = { 2 };
            sock.Send(num);
            button2.Text = PlayerChar.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte[] num = { 3 };
            sock.Send(num);
            button3.Text = PlayerChar.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            byte[] num = { 4 };
            sock.Send(num);
            button4.Text = PlayerChar.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            byte[] num = { 5 };
            sock.Send(num);
            button5.Text = PlayerChar.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            byte[] num = { 6 };
            sock.Send(num);
            button6.Text = PlayerChar.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            byte[] num = { 7 };
            sock.Send(num);
            button7.Text = PlayerChar.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            byte[] num = { 8 };
            sock.Send(num);
            button8.Text = PlayerChar.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            byte[] num = { 9 };
            sock.Send(num);
            button9.Text = PlayerChar.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageReceiver.WorkerSupportsCancellation = true;
            MessageReceiver.CancelAsync();
            if (server != null)
                server.Stop();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            byte[] num = { 10 };
            sock.Send(num);
            button10.Text = PlayerChar.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void Game_Load(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            byte[] num = { 11 };
            sock.Send(num);
            button11.Text = PlayerChar.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            byte[] num = { 12 };
            sock.Send(num);
            button12.Text = PlayerChar.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            byte[] num = { 13 };
            sock.Send(num);
            button13.Text = PlayerChar.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            byte[] num = { 14 };
            sock.Send(num);
            button14.Text = PlayerChar.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            byte[] num = { 15 };
            sock.Send(num);
            button15.Text = PlayerChar.ToString();
            MessageReceiver.RunWorkerAsync();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            byte[] num = { 16 };
            sock.Send(num);
            button16.Text = PlayerChar.ToString();
            MessageReceiver.RunWorkerAsync();
        }
    }
}
