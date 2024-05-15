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

namespace zad2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label2.Visible = textBox1.Text.IndexOf('/') == -1 ? true : false ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.IndexOf('/') != -1)
            {
                string[] array = textBox1.Text.Split('/');  

                var countNumbers = (from word in textBox1.Text
                                    where char.IsDigit(word) 
                                    select word).Count();

                var charsToSlash = array.TakeWhile(s => s != "/");

                var charsAfterSlash = array.SkipWhile(s => s != "/").Skip(1)
                      .Select(s => s.ToUpper());


                using (StreamWriter wr = File.AppendText("file.txt"))
                {
                    string result = "";
                    result += $"{countNumbers} ";

                    foreach (var chars in charsToSlash)
                    {
                        result += $"{chars} ";
                    }

                    foreach (var chars in charsAfterSlash)
                    {
                        result += $"{chars}";
                    }

                    wr.WriteLine(result);
                }
            }
        }
    }
}
