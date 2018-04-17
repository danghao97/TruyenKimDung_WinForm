using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTLDotNet.Controller;
using System.Text.RegularExpressions;

namespace BTLDotNet.View
{
    public partial class HomePage : Form
    {
        private const int MAX_LIST_STORY_WIDTH = 200;
        private const int MAX_LIST_CHAP_WIDTH = 200;
        private int idt;
        private int idh;

        public HomePage()
        {
            InitializeComponent();
            this.MinimumSize = new Size(Screen.PrimaryScreen.Bounds.Width / 2, (int)(Screen.PrimaryScreen.Bounds.Height * 0.7));
        }

        private void HomePage_Resize(object sender, EventArgs e)
        {
            resize();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            resize();
            Model.Stories stories = Model.MyDatabase.getStories();
            List<Model.Story> list = stories.getStories();
            liststory.DataSource = list;


            MyRegex regex = new MyRegex();
            regex.InputString = "Phong Điền Khí";
            regex.Content = "tiền bối Phong Thanh ... gã khi Điền Bá .. bên tông phái";
            Match match = regex.GenerateRegexAllMatch();
            if (match != null)
            {
                MessageBox.Show(match.Value);
            } else
            {
                List<Result> results = regex.FuzzyMethod();
            }
        }

        public void resize()
        {
            liststory.Width = (int)(this.Width * 0.2);
            liststory.Height = (int)(this.Height * 0.75);
            liststory.Location = new Point((int)(this.Width * 0.01), (int)(this.Height * 0.15));

            listchap.Width = (int)(this.Width * 0.2);
            listchap.Height = (int)(this.Height * 0.75);
            listchap.Location = new Point((int)(this.Width * 0.775), (int)(this.Height * 0.15));

            contentchap.Width = (int)(this.Width * 0.52);
            contentchap.Height = (int)(this.Height * 0.75);
            contentchap.Location = new Point((int)(this.Width * 0.23), (int)(this.Height * 0.15));

            lbStoryName.Width = this.Width;
            lbStoryName.Location = new Point(0, menuStrip1.Height);

            lbChapName.Width = this.Width;
            lbChapName.Location = new Point(0, menuStrip1.Height + lbStoryName.Height);

            if (this.WindowState == FormWindowState.Maximized)
            {
                liststory.Font = new Font(liststory.Font.FontFamily, 14);
                listchap.Font = new Font(liststory.Font.FontFamily, 14);
            }
            else
            {
                liststory.Font = new Font(liststory.Font.FontFamily, 9);
                listchap.Font = new Font(liststory.Font.FontFamily, 9);
            }
        }

        private void liststory_SelectedValueChanged(object sender, EventArgs e)
        {
            contentchap.Text = "";
            Model.Story story = (Model.Story)liststory.SelectedItem;
            idt = story.idt;
            lbStoryName.Text = story.name;
            List<Model.Chapter> list = story.getChapters();
            listchap.DataSource = list;
        }

        private void listchap_SelectedIndexChanged(object sender, EventArgs e)
        {
            Model.Chapter chap = (Model.Chapter)listchap.SelectedItem;
            idh = chap.idh;
            lbChapName.Text = chap.name;
            contentchap.Text = chap.content.Replace("\r\n", "\n");
            MarkWrongRhythm();

            contentchap.SelectionStart = 0;
            contentchap.SelectionIndent = 100;
            contentchap.SelectionHangingIndent = -70;
            contentchap.SelectionRightIndent = 30;
        }

        public void MarkWrongRhythm()
        {
            contentchap.SelectionStart = 0;
            contentchap.SelectionColor = Color.Black;

            string content = contentchap.Text.Replace("\r\n", "\n");
            string[] rhythms = Controller.Rhythm.splitRhythm(content);
            int ind = 0;
            long tryparse;
            foreach (var rhythm in rhythms)
            {
                if (!Int64.TryParse(rhythm, out tryparse))
                {
                    if (!rhythm.Equals(string.Empty) && !Controller.MyRule.IsValid(rhythm))
                    {
                        do
                        {
                            ind = content.IndexOf(rhythm, ind) + rhythm.Length;
                            contentchap.Select(ind - rhythm.Length, rhythm.Length);
                            char cBehind = content[ind];
                            if (Controller.Rhythm.isSeparator(cBehind))
                            {
                                if (ind > (rhythm.Length + 1))
                                {
                                    char cFront = content[ind - rhythm.Length - 1];
                                    if (Controller.Rhythm.isSeparator(cFront))
                                    {
                                        contentchap.SelectionColor = Color.Red;
                                        break;
                                    }
                                }
                            }
                        } while (true);
                    }
                    else
                    {
                        ind += (rhythm.Length);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form input = new View.InputData();
            input.Show();
        }

        private void contentchap_MouseMove(object sender, MouseEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(contentchap.Text))
            {
                //get index of nearest character
                var index = contentchap.GetCharIndexFromPosition(e.Location);
                //check if mouse is above a word (non-whitespace character)
                if (!Controller.Rhythm.isSeparator(contentchap.Text[index]))
                {
                    var start = index;
                    while (start > 0 && !Controller.Rhythm.isSeparator(contentchap.Text[start - 1]))
                        start--;
                    var end = index;
                    while (end < contentchap.Text.Length - 1 && !Controller.Rhythm.isSeparator(contentchap.Text[end + 1]))
                        end++;
                    string strHover = contentchap.Text.Substring(start, end - start + 1);
                    long tryparse;
                    if (!Int64.TryParse(strHover, out tryparse))
                    {
                        if (!strHover.Equals(string.Empty) && !Controller.MyRule.IsValid(strHover))
                        {
                            // hien tooltip
                            toolTip1.Show(Controller.MyRule.Explain(strHover), contentchap, e.Location.X + 10, e.Location.Y + 5);
                        }
                        else
                        {
                            toolTip1.Hide(contentchap);
                            // an tooltip
                        }
                    }
                    else
                    {
                        toolTip1.Hide(contentchap);
                        // An tooltip
                    }
                }
            }
        }

        private void contentchap_MouseDown(object sender, MouseEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(contentchap.Text))
            {
                //get index of nearest character
                var index = contentchap.GetCharIndexFromPosition(e.Location);
                //check if mouse is above a word (non-whitespace character)
                if (!Controller.Rhythm.isSeparator(contentchap.Text[index]))
                {
                    var start = index;
                    while (start > 0 && !Controller.Rhythm.isSeparator(contentchap.Text[start - 1]))
                        start--;
                    var end = index;
                    while (end < contentchap.Text.Length - 1 && !Controller.Rhythm.isSeparator(contentchap.Text[end + 1]))
                        end++;
                    string strHover = contentchap.Text.Substring(start, end - start + 1);
                    long tryparse;
                    if (!Int64.TryParse(strHover, out tryparse))
                    {
                        if (!strHover.Equals(string.Empty) && !Controller.MyRule.IsValid(strHover))
                        {
                            DialogResult dialogResult;
                            switch (e.Button)
                            {
                                case MouseButtons.Right:

                                    dialogResult = MessageBox.Show("Bạn có muốn xóa từ này không?", "", MessageBoxButtons.YesNo);
                                    if (dialogResult == DialogResult.Yes)
                                    {
                                        MessageBox.Show("Đã xóa từ");
                                    }
                                    break;
                                case MouseButtons.Left:
                                    dialogResult = MessageBox.Show("Bạn có muốn sửa từ này không?", "", MessageBoxButtons.YesNo);
                                    if (dialogResult == DialogResult.Yes)
                                    {
                                        Form form = new EditErrorWord(idt, idh, start, end, contentchap.Text, strHover);
                                        DialogResult result = form.ShowDialog(this);
                                        if (result == DialogResult.OK)
                                        {
                                            Model.Chapter chap = (Model.Chapter)listchap.SelectedItem;
                                            chap.content = Model.MyDatabase.getContentChap(idh);

                                            contentchap.Text = chap.content.Replace("\r\n", "\n");
                                            MarkWrongRhythm();
                                            contentchap.Select(start, end - start + 1);
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            InputSearch testDialog = new InputSearch();

            if (testDialog.ShowDialog(this) == DialogResult.OK)
            {
                ResultSearch result = new ResultSearch();
                result.Show();
            }
            else
            {
                MessageBox.Show("Huy", "Huy");
            }
            testDialog.Dispose();
        }
    }
}
