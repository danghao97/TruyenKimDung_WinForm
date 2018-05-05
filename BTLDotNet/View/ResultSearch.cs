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
    public partial class ResultSearch : Form
    {
        private string input = "";
        private HomePage home;

        public ResultSearch(HomePage home, string input)
        {
            this.home = home;
            this.input = input;
            InitializeComponent();
            Search();
        }

        public void Search()
        {
            List<string> results = new List<string>();
            Model.Stories stories = Model.MyDatabase.getStories();

            foreach (Model.Story story in stories.getStories())
            {
                foreach (Model.Chapter chap in story.getChapters())
                {
                    MyRegex regex = new MyRegex();
                    regex.InputString = input;
                    regex.Content = chap.content;
                    Match match = regex.GenerateRegexAllMatch();
                    if (match != null)
                    {
                        MessageBox.Show("Tìm thấy tại " + story.name + " - " + chap.name);
                        this.Dispose();
                        return;
                    }
                    else
                    {
                        List<Result> result = regex.FuzzyMethod();
                        foreach (Result rs in result)
                        {
                            int start = rs.begin;
                            int len = rs.end - rs.begin;
                            results.Add(story.name + " - " + chap.name + ": (" + rs.numberRhythmsMatch + ")" + chap.content.Substring(start, len));
                        }
                    }
                }
            }

            listBox1.DataSource = results;
            this.Show();
        }
    }
}
