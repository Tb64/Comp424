using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comp424Assign2
{
    public partial class Form1 : Form
    {
        BlockChain chain;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //add hash
            string data = textBox1.Text;
            if (chain == null)
            {
                chain = new BlockChain(data);

            }
            else
            {
                chain.AddBlock(data);
            }
            PrintBlockCreate(data, chain.GetLastBlock());

        }

        private void ClearInput()
        {
            textBox1.Text = "";
        }

        private void AppendLog(string input)
        {
            richTextBox1.Text = input + richTextBox1.Text;
        }

        private void PrintBlockCreate(string data, Block block)
        {
            string output = "data:\t\t" + data + "\n";
            output +=       "hash:\t\t" + block.hash + "\n";
            output +=       "previous hash:\t" + block.previousHash + "\n\n";
            AppendLog(output);
        }
    }
}
