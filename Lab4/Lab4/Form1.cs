using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Lab4
{
    public partial class Form1 : Form
    {
        private List<string> strings;
        private Stopwatch stopWatch;
        public Form1()
        {
            InitializeComponent();
            openFileWindow.Filter = "Text files(*.txt)|*.txt";
            openFileWindow.InitialDirectory = Directory.GetCurrentDirectory();
            stopWatch = new Stopwatch();
            strings = new List<string>();
        }

        private void открытьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileWindow.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                int maxDist = Convert.ToInt32(textBox1.Text);

                stopWatch.Start();
                // получаем выбранный файл
                string filename = openFileWindow.FileName;
                // читаем файл в строку
                string fileText = System.IO.File.ReadAllText(filename, Encoding.UTF8);
                char[] separator = { ',', ' ', '?', '!' };
                string[] words = fileText.Split(separator);
                foreach(string word in words)
                {
                    // if(!strings.Contains(word))
                    bool fl = false;

                    foreach ( var s in strings )
                        if (levensteinDist.calcLevenstein( word, s, checkBox1.Checked) <= maxDist)
                        {
                            fl = true;
                            break;

                        }

                    if (fl)
                        strings.Add(word);
                }
                stopWatch.Stop();
                textFile.Text = stopWatch.ElapsedMilliseconds + " миллисекунд.";
                MessageBox.Show("Файл успешно считан.");
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            listWords.Items.Clear();
            string search = textWord.Text;
            stopWatch.Start();
            foreach(string word in strings)
            {
                if(word.Contains(search))
                {
                    listWords.BeginUpdate();
                    listWords.Items.Add(word);
                    listWords.EndUpdate();
                }
            }
            stopWatch.Stop();
            textSearch.Text = stopWatch.ElapsedMilliseconds + " миллисекунд.";
        }

    }
}
