using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BTLDotNet.Model
{
    class Chapter
    {
        private int _idh;
        private string _name;
        private string _content;
        private string _excerpt;
        public int idh
        {
            get
            {
                return _idh;
            }
            set
            {
                _idh = value;
            }
        }
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public string content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
            }
        }
        public string excerpt
        {
            get
            {
                return _excerpt;
            }
            set
            {
                _excerpt = value;
            }
        }

        public override string ToString()
        {
            return name;
        }
    }
    class Story
    {
        private int _idt;
        private string _name;
        private string _excerpt;
        private List<Chapter> chaps = new List<Chapter>();

        public int idt
        {
            get
            {
                return _idt;
            }
            set
            {
                _idt = value;
            }
        }

        public String name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public string excerpt
        {
            get
            {
                return _excerpt;
            }
            set
            {
                _excerpt = value;
            }
        }

        public List<Chapter> getChapters()
        {
            return chaps;
        }

        public void addChapter(Chapter chap)
        {
            chaps.Add(chap);
        }

        public override string ToString()
        {
            return idt + ": " + name;
        }
    }

    // All 
    class Stories
    {
        private List<Story> stories = new List<Story>();
        public List<Story> getStories()
        {
            return stories;
        }

        public void addStory(Story story)
        {
            stories.Add(story);
        }
    }

    class MyDatabase
    {
        private const string STR_CONNECT = "Server=localhost\\sqlexpress;Database=BTLDotNet;Integrated Security=True;MultipleActiveResultSets=True";
        public static Stories getStories()
        {
            Stories stories = null;

            using (SqlConnection con = new SqlConnection(STR_CONNECT))
            {
                string queryStory = "SELECT * FROM tbl_story";
                SqlCommand cmdStory = new SqlCommand(queryStory, con);
                con.Open();
                using (SqlDataReader reader = cmdStory.ExecuteReader())
                {
                    stories = new Stories();
                    Story story;
                    while (reader.Read())
                    {
                        story = new Story();
                        story.idt = Int32.Parse(reader["id_story"].ToString());
                        story.name = reader["name"].ToString();
                        string queryChap = "SELECT * FROM tbl_chap WHERE id_story = " + story.idt;
                        SqlCommand cmdChap = new SqlCommand(queryChap, con);
                        using (SqlDataReader readchap = cmdChap.ExecuteReader())
                        {
                            Chapter chap;
                            while (readchap.Read())
                            {
                                chap = new Chapter();
                                chap.idh = Int32.Parse(readchap["id_chap"].ToString());
                                chap.name = readchap["name"].ToString();
                                chap.content = readchap["contentchap"].ToString();
                                story.addChapter(chap);
                            }
                        }
                        stories.addStory(story);
                    }
                }
            }

            return stories;
        }

        public static int addStory(string name)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(STR_CONNECT))
            {
                string queryStory = "INSERT INTO tbl_story (name) VALUES (N'" + name + "')";
                SqlCommand cmdStory = new SqlCommand(queryStory, con);
                con.Open();
                result = cmdStory.ExecuteNonQuery();
            }
            return result;
        }

        public static int addChap(int idt, string name, string content)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(STR_CONNECT))
            {
                string queryStory = "INSERT INTO tbl_chap (id_story, name, contentchap) VALUES (" + idt + ", N'" + name + "', N'" + content + "')";
                SqlCommand cmdStory = new SqlCommand(queryStory, con);
                con.Open();
                result = cmdStory.ExecuteNonQuery();
            }
            return result;
        }

        public static int addParagraph(int id_chap, int begin, int end, string content)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(STR_CONNECT))
            {
                string queryStory = "INSERT INTO tbl_paragraph (id_chap, begin_index, end_index, content_paragraph) VALUES (" + id_chap + ", " + begin + ", " + end + ", N'" + content + "')";
                SqlCommand cmdStory = new SqlCommand(queryStory, con);
                con.Open();
                result = cmdStory.ExecuteNonQuery();
            }
            return result;
        }

        public static int Update(string query)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(STR_CONNECT))
            {
                SqlCommand cmdStory = new SqlCommand(query, con);
                con.Open();
                result = cmdStory.ExecuteNonQuery();
            }
            return result;
        }

        public static string getContentChap(int idh)
        {
            string content = "";

            using (SqlConnection con = new SqlConnection(STR_CONNECT))
            {
                string queryStory = "SELECT contentchap FROM tbl_chap WHERE id_chap = " + idh;
                SqlCommand cmdStory = new SqlCommand(queryStory, con);
                con.Open();
                using (SqlDataReader reader = cmdStory.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        content = reader["contentchap"].ToString();
                    }
                }
            }

            string pattern = "";
            string input = "";
            System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex(pattern);
            r.IsMatch(input);

            return content;
        }
    }
}
