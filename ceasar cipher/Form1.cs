using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ceasar_cipher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            string plaintext = textBox2.Text.ToUpper();

            int key = int.Parse(textBox1.Text);

            
            char[] p = plaintext.ToCharArray();
            char[] index = encrypt(p, key);

            //output
            for (int i = 0; i < index.Length; i++)
            {
                textBox3.Text = textBox3.Text + index[i].ToString();
            }
        }
        char[] encrypt(char[] p, int key)
        {
            //string ciphertext = string.Empty;
            char[] index = new char[p.Length];

            for (int i = 0; i < p.Length; i++)
            {
                if (p[i] >= 65 && p[i] <= 90)
                {
                    int a = (int)(p[i] - 65);

                    index[i] = (char)(((a + key) % 26) + 65);

                }
                else
                {
                    index[i] = p[i];
                }

            }
            return index;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            string ciphertext = textBox3.Text.ToUpper();

            int key = int.Parse(textBox1.Text);


            char[] c = ciphertext.ToCharArray();
            char[] index = decrypt(c, key);
            
            for (int i = 0; i < index.Length; i++)
            {
                textBox2.Text = textBox2.Text + index[i].ToString();
            }
        }
        char[] decrypt(char[] c, int key)
        {
            char[] index = new char[c.Length];

            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] >= 65 && c[i] <= 90)
                {
                    int a = (int)(c[i] - 65);
                    if ((a - key) < 0)
                    {
                        a += 26;
                    }

                    index[i] = (char)(((a - key) % 26) + 65);

                }
                else
                {
                    index[i] = c[i];
                }

            }
            return index;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Form2 Form2 = new Form2();
            //Form2.ShowDialog();

            string ciphertext = textBox3.Text.ToUpper();
            char[] c = ciphertext.ToCharArray();

            for (int i = 1; i < 26; i++)
            {
                char[] index = decrypt(c, i);
                textBox2.Text = textBox2.Text + i + ". ";
                for (int j = 0; j < index.Length; j++)
                {
                    textBox2.Text = textBox2.Text + index[j].ToString();
                }
                textBox2.Text = textBox2.Text + "\r\n";
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
