using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace levenstein
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string s1;

            textBox3.Text = "";
            s1 = textBox1.Text;
            foreach (var s2 in textBox2.Lines)
            {
                int[,] m;

                textBox3.AppendText(s1 + " <=> " + s2 + " = " + 
                    levensteinDist.calcLevenstein(s1, s2, out m, checkBox2.Checked) + "\n");

                if (checkBox1.Checked)
                {
                    for (int x = 1; x <= s1.Length; x++)
                    {
                        string s = "";
                        for (int y = 1; y <= s2.Length; y++)
                            s = s + m[x, y] + "  ";
                        textBox3.AppendText("  " + s + "\n");
                    }
                }
            }
        }
    }
}
