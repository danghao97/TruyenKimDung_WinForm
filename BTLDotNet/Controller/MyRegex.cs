using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BTLDotNet.Controller
{
    class MyRegex
    {

        private String[] rhythms;
        private String inputString;
        private String content;
        private int n;
        List<Match> listMatch = new List<Match>();
        private String storyname;
        private String chapname;

        public String InputString
        {
            set
            {
                this.inputString = value;
                this.rhythms = Rhythm.splitRhythm(this.inputString);
                this.n = rhythms.Length;
            }
        }
        public String Content
        {
            set
            {
                this.content = value;
            }
        }

        public Match GenerateRegexAllMatch()
        {

            String pattern = @"";
            for (int i = 0; i < n - 1; i++)
            {
                pattern += rhythms[i] + ".{0,100}";
            }
            pattern += rhythms.LastOrDefault();
            Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
            if (!r.IsMatch(content))
                return null;
            return r.Match(content);
        }
        //trả về một mảng index có vị trí của các từ 
        public void ListIndexPattern()
        {
            for (int i = 0; i < n; i++)
            {
                Regex r = new Regex(@"" + rhythms[i], RegexOptions.IgnoreCase);
                MatchCollection mc = r.Matches(content);
                foreach (Match e in mc)
                {
                    listMatch.Add(e);
                }
            }
            listMatch.Sort(delegate (Match x, Match y)
            {
                return (x.Index > y.Index ? 1 : (x.Index == y.Index) ? 0 : -1);
            });
        }
        public List<Result> FuzzyMethod()
        {
            ListIndexPattern();
            List<Result> listResult = new List<Result>();
            for (int l = n; l > 3 * n / 5; l--)
            {
                for (int i = 0; i <= listMatch.Count - l; i++)
                {
                    int c = CountDifferentRhythm(i, i + l);
                    if (c == l || (l == n && c > 3 * l / 5))
                    {
                        int distance = 0;
                        for (int k = i; k < i + l - 1; k++)
                        {
                            distance += listMatch[k + 1].Index - listMatch[k].Index;
                        }
                        if (distance < 1000)
                            listResult.Add(new Result(listMatch[i].Index, listMatch[i + l - 1].Index + listMatch[i+l-1].Value.Length, (byte)l, distance));
                    }
                }
            }
            listResult.Sort(delegate (Result x, Result y)
            {
                if (x.numberRhythmsMatch > y.numberRhythmsMatch) return -1;
                if (x.numberRhythmsMatch < y.numberRhythmsMatch) return 1;
                return (x.distance > y.distance ? 1 : (x.distance == y.distance) ? 0 : -1);
            });
            return listResult;
        }
        private int CountDifferentRhythm(int i, int j)
        {
            List<String> dict = new List<String>();
            for (int k = i; k < j; k++)
            {
                String s = listMatch[k].Value;
                if (!dict.Contains(s))
                {
                    dict.Add(s);
                }
            }
            return dict.Count;
        }
    }
    class Result
    {
        public int begin;
        public int end;
        public byte numberRhythmsMatch;//số âm tiết tìm thấy trong chương có trong chuỗi nhập vào
        public int distance;//tổng khoảng cách giữa các từ trong chương
        public Result(int begin, int end, byte numberRhythmsMatch, int distance)
        {
            this.begin = begin;
            this.end = end;
            this.numberRhythmsMatch = numberRhythmsMatch;
            this.distance = distance;
        }

        public override string ToString()
        {
            return begin + " - " + end;
        }
    }
}
