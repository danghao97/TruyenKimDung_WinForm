using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BTLDotNet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Model.Stories stories = Model.MyDatabase.getStories();
            string list = "";
            foreach (var story in stories.getStories())
            {
                list += story.idt + ": " + story.name + "\n";
                foreach (var chap in story.getChapters())
                {
                    list += "    " + chap.idh + ": " + chap.name + " - " + chap.content + "\n";
                }
            }
            label1.Text = list;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new View.InputData().Show();
        }
    }
}
