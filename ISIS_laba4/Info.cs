using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISIS_laba4
{
    public partial class Info : Form
    {
        public Info()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public string getText
        { get { return textBox1.Text; } }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
