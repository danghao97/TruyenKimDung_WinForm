using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTLDotNet.View
{
    public partial class EditErrorWord : Form
    {
        int idt;
        int idh;
        int start;
        int end;
        string content;
        string word;

        public EditErrorWord(int idt, int idh, int start, int end, string content, string word)
        {
            this.idt = idt;
            this.idh = idh;
            this.start = start;
            this.end = end;
            this.content = content;
            this.word = word;
            InitializeComponent();
            label3.Text = word;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newword = textBox1.Text;
            long tryparse;
            if (!Int64.TryParse(newword, out tryparse))
            {
                if (!newword.Equals(string.Empty) && !Controller.MyRule.IsValid(newword))
                {
                    MessageBox.Show("Từ mới sai chính tả", Controller.MyRule.Explain(newword));
                    return;
                }
            }
            string query = "UPDATE tbl_chap SET contentchap = N'" + content.Replace(word, textBox1.Text) + "' WHERE idh = " + idh;
            Model.MyDatabase.Update(query);
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
    }
}
