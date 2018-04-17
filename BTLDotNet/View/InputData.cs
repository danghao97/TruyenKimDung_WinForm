using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace BTLDotNet.View
{
    public partial class InputData : Form
    {
        public InputData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Model.MyDatabase.addStory(textBox1.Text) <= 0)
            {
                MessageBox.Show("Chưa thêm được truyện", "Lỗi");
            }
            else
            {
                MessageBox.Show("Thêm truyện thành công", "Success");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Model.Stories stories = Model.MyDatabase.getStories();
            List<Model.Story> list = stories.getStories();
            comboBox1.DataSource = list;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int idt = ((Model.Story)comboBox1.SelectedItem).idt;
            string name = textBox2.Text;
            string content = textBox3.Text;
            if (Model.MyDatabase.addChap(idt, name, content) <= 0)
            {
                MessageBox.Show("Chưa thêm được truyện", "Lỗi");
            }
            else
            {
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }
    }
}
