using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace BTLDotNet.Controller
{
    class MyRule
    {
        public static string[] VOWEL = {
            "a", "ă", "â", "e", "ê", "i", "y", "o", "ô", "ơ", "u", "ư"
        };

        public static string[] HEAD_CONSONANT = {
            "b",  "ch","c", "d", "đ", "gh","gi", "g", "h", "kh","k",  "l", "m","ngh","ng",
            "nh","n", "ph", "p", "qu", "q", "r", "s",  "th", "tr", "t", "v", "x", ""
        };

        public static string[] SPELLING = {
            "a", "ac", "ach", "ai", "am","an", "ang", "anh", "ao", "ap", "at", "au", "ay",
            "ăc", "ăm", "ăn", "ăng", "ăp", "ăt",
            "âc", "âm", "ân", "âng", "âp", "ât", "âu", "ây",
            "e", "ec", "em", "en", "eng", "eo", "ep", "et",
            "ê", "êc", "êch", "êm", "ên", "ênh", "êp", "êt", "êu",
            "i", "ia", "ich", "iêc", "iêm", "iên", "iêng", "iêp", "iêt", "iêu", "im", "in", "inh", "ip", "it", "iu",
            "o", "oa", "oac", "oach", "oai", "oam", "oan", "oang", "oanh", "oao", "oap", "oat", "oay", "oăc", "oăm",
            "oăn", "oăng", "oăp", "oăt", "oc", "oe", "oec", "oem", "oen", "oeng", "oeo", "oep", "oet",
            "oi", "om", "on", "ong", "ooc", "oong", "op", "ot",
            "ô", "ôc", "ôi", "ôm", "ôn", "ông", "ôp", "ôt",
            "ơ", "ơc", "ơi", "ơm", "ơn", "ơng", "ơp", "ơt",
            "u", "ua", "uân", "uâng", "uât", "uây", "uc", "uê", "uêch", "uênh", "ui", "um", "un", "ung", "uôc", "uôi",
            "uôm", "uôn", "uông", "uôt", "uơ", "up", "ut", "uy", "uya", "uych", "uyên", "uyêt", "uyn", "uynh", "uyp", "uyt", "uyu",
            "ư", "ưa", "ưc", "ưi", "ưm", "ưn", "ưng", "ươc", "ươi", "ươm", "ươn", "ương", "ươp", "ươt", "ươu", "ưt", "ưu",
            "y", "ych", "yêm", "yên", "yêt", "yêu", "ynh"
        };

        public static string[] WRONG_SPELLING_AND_TONE = {
            "ac", "àc", "ảc", "ãc",
            "ach", "àch", "ảch", "ãch",
            "ap", "àp", "ảp", "ãp",
            "at", "àt", "ảt", "ãt",
            "ăc", "ằc", "ẳc", "ẵc",
            "ăp", "ằp", "ẳp", "ẵp",
            "ăt", "ằt", "ẳt", "ẵt",
            "âc", "ầc", "ẩc", "ẫc",
            "âp", "ầp", "ẩp", "ẫp",
            "ât", "ầt", "ẩt", "ẫt",
            "ec", "èc", "ẻc", "ẽc",
            "ep", "èp", "ẻp", "ẽp",
            "et", "èt", "ẻt", "ẽt",
            "êc", "ềc", "ểc", "ễc",
            "êch", "ềch", "ểch", "ễch",
            "êp", "ềp", "ểp", "ễp",
            "êt", "ềt", "ểt", "ễt",
            "ich", "ìch", "ỉch", "ĩch",
            "iêc", "iềc", "iểc", "iễc", "ìêc", "ỉêc", "ĩêc",
            "iêp", "iềp", "iểp", "iễp", "ìêp", "ỉêp", "ĩêp",
            "iêt", "iềt", "iểt", "iễt", "ìêt", "ỉêt", "ĩêt",
            "ip", "ìp", "ỉp", "ĩp",
            "it", "ìt", "ỉt", "ĩt",
            "oac", "oàc", "oảc", "oãc", "òac", "ỏac", "õac",
            "oach", "oàch", "oảch", "oãch", "òach", "ỏach", "õach",
            "oap", "oàp", "oảp", "oãp", "òap", "ỏap", "õap",
            "oat", "oàt", "oảt", "oãt", "òat", "ỏat", " õat",
            "oăc", "oằc", "oẳc", "oẵc", "òăc", "ỏăc", "õăc",
            "oăp", "oằp", "oẳp", "oẵp", "òăp", "ỏăp", "õăp",
            "oăt", "oằt", "oẳt", "oẵt", "òăt", "ỏăt", "õăt",
            "oc", "òc", "ỏc", "õc",
            "oec", "òec", "ỏec", "õec","oèc", "oẻc", "oẽc", "óec", "ọec",
            "oep", "òep", "ỏep", "õep","oèp", "oẻp", "oẽp", "óep", "ọep",
            "oet", "oèt", "oẻt", "oẽt", "òet", "ỏet", "õet", "óet", "ọet",
            "ooc", "òoc", "oòc", "ỏoc", "oỏc", "õoc", "oõc", "óoc", "ọoc",
            "op", "òp", "ỏp", "õp",
            "ot", "òt", "ỏt", "õt",
            "ôc", "ồc", "ổc", "ỗc",
            "ôp", "ồp", "ổp", "ỗp",
            "ôt", "ồt", "ổt", "ỗt",
            "ơc", "ờc", "ởc", "ỡc",
            "ơp", "ờp", "ởp", "ỡp",
            "ơt", "ờt", "ởt", "ỡt",
            "uât", "uầt", "ùât", "uẩt", "ủât", "uẫt", "ũât",
            "uc", "ùc", "ủc", "ũc",
            "uêch", "uềch", "ùêch", "uểch", "ủêch", "uễch", "ũêch",
            "uôc", "uồc", "ùôc", "uổc", "ủôc", "uỗc", "ũôc",
            "uôt", "uồt", "ùôt", "uổt", "ủôt", "uỗt", "ũôt",
            "up", "ùp", "ủp", "ũp",
            "ut", "ùt", "ủt", "ũt",
            "uych", "uỳch", "ùych", "uỷch", "ủych", "uỹch", "ũych",
            "uyêt", "uyềt", "uyểt", "uyễt", "ùyêt", "ủyêt", "ũyêt", "uỳêt", "uỷêt", "uỹêt",
            "uyp", "uỳp", "uỷp", "uỹp", "ùyp", "ủyp", "ũyp",
            "uyt", "uỳt", "uỷt", "uỹt", "ùyt", "ủyt", "ũyt",
            "ưc", "ừc", "ửc", "ữc",
            "ươc", "ườc", "ưởc", "ưỡc", "ừơc", "ửơc", "ữơc",
            "ươp", "ườp", "ưởp", "ưỡp", "ừơp", "ửơp", "ữơp",
            "ươt", "ườt", "ưởt", "ưỡt", "ừơt", "ửơt", "ữơt",
            "ưt", "ừt", "ửt", "ữt",
            "yêt", "yềt", "yểt", "yễt", "ỳêt", "ỷêt", "ỹêt"
        };

        public static string[] WRONG_POSITION_OF_TONE = {//các vần sai vị trí âm là các vần có hai nguyên âm
            "aì", "aí", "aỉ", "aĩ", "aị",
            "aò", "aó", "aỏ", "aõ", "aọ",
            "aù", "aú", "aủ", "aũ", "aụ",
            "aỳ", "aý", "aỷ", "aỹ", "aỵ",
            "âù", "âú", "âủ", "âũ", "âụ",
            "âỳ", "âý", "âỷ", "âỹ", "âỵ",
            "eò", "eó", "eỏ", "eõ", "eọ",
            "êù", "êú", "êủ", "êũ", "êụ",
            "ià", "iá", "iả", "iã", "iạ",
            "íêc", "ịêc", "ìêm", "íêm", "ỉêm", "ĩêm", "ịêm",
            "ìên", "íên", "ỉên", "ĩên", "ịên", "ìêng", "íêng", "ỉêng", "ĩêng", "ịêng",
            "íêp", "ịêp", "íêt", "ịêt",
            "ìêu", "íêu", "ỉêu", "ĩêu", "ịêu", "iêù", "iêú", "iêủ", "iêũ", "iêụ",
            "iù", "iú", "iủ", "iũ", "iụ",
            "óac", "ọac", "óach", "ọach",
            "òai", "óai", "ỏai", "õai", "ọai", "òam", "óam", "ỏam", "õam", "ọam",
            "òan", "óan", "ỏan", "õan", "ọan", "òang", "óang", "ỏang", "õang", "ọang", "òanh", "óanh", "ỏanh", "õanh", "ọanh",
            "òao", "óao", "ỏao", "õao", "ọao", "oaò", "oaó", "oaỏ", "oaõ", "oaọ",
            "óap", "ọap", "óat", "ọat",
            "òay", "óay", "ỏay", "õay", "ọay", "óăc", "ọăc", "óăp", "ọăp", "óăt", "ọăt",
            "òăm", "óăm", "ỏăm", "õăm", "ọăm", "òăn", "óăn", "ỏăn", "õăn", "ọăn", "òăng", "óăng", "ỏăng", "õăng", "ọăng",
            "óec", "ọec", "óep", "ọep", "óet", "ọet", "" ,
            "òem", "óem", "ỏem", "õem", "ọem", "òen", "óen", "ỏen", "õen", "ọen", "òeng", "óeng", "ỏeng", "õeng", "ọeng",
            "ôì", "ôí", "ôỉ", "ôĩ", "ôị", "ơì", "ơí", "ơỉ", "ơĩ", "ơị", "uà", "uá", "uả", "uã", "uạ",
            "ùân", "úân", "ủân", "ũân", "ụân", "ùâng", "úâng", "ủâng", "ũâng", "ụâng", "úât", "ụât",
            "ùây", "úây", "ủây", "ũây", "ụây", "úêch", "ụêch", "ùơ", "úơ", "ủơ", "ũơ", "ụơ",
            "ùê", "úê", "ủê", "ũê", "ụê", "ùênh", "úênh", "ủênh", "ũênh", "ụênh", "uì", "uí", "uỉ", "uĩ", "uị",
            "úôc", "ụôc", "ùôi", "úôi", "ủôi", "ũôi", "ụôi", "uôì", "uôí", "uôỉ", "uôĩ", "uôị","úôt", "ụôt",
            "ùôm", "úôm", "ủôm", "ũôm", "ụôm", "ùôn", "úôn", "ủôn", "ũôn", "ụôn", "ùông", "úông", "ủông", "ũông", "ụông",
            "ùya", "úya", "ủya", "ũya", "ụya", "uyà", "uyá", "uyả", "uyã", "uyạ", "úych", "ụych",
        };

        public static Rule[] allRules = new Rule[] {
            new Rule1(),
            new Rule2(),
            new Rule3(),
            new Rule4(),
            new Rule5(),
            new Rule6()
        };

        public static bool IsValid(string rhythm)
        {
            for (byte i = 0; i < allRules.Length; i++)
            {
                if (!allRules[i].IsValid(rhythm))
                {
                    return false;
                }
                if (i == 4) return true;
            }
            return true;
        }

        public static string Explain(string rhythm)
        {
            for (byte i = 0; i < allRules.Length; i++)
            {
                if (!allRules[i].IsValid(rhythm))
                {
                    return allRules[i].Explain();
                }
            }
            return "Unknow";
        }
    }

    class Rule
    {
        public virtual bool IsValid(string rhythm)
        {
            return true;
        }

        public static bool CheckFirstLetterOfSentence(string sentence)
        {
            return true;
        }

        public virtual string Explain()
        {
            return "Unknow";
        }
    }

    //kiểm tra số lượng kí tự trong một âm tiết
    class Rule1 : Rule
    {
        public override bool IsValid(string word)
        {
            return word.Length <= 7;
        }

        public override string Explain()
        {
            return "ERROR: Max Lenght = 7";
        }
    }

    // Kiểm tra sự ghép không hợp hệ giữa phụ âm đầu và vần, ví dụ: ka, ko, kon ciến, ...
    class Rule2 : Rule
    {
        public override bool IsValid(string word)
        {
            string[] arr1 = { "e", "ê", "i", "y" };
            string[] arr2 = { "a", "ă", "â", "o", "ô", "ơ", "u", "ư" };
            string[] arr3 = { "k", "gh", "ngh" };
            string[] arr4 = { "c", "g", "ng" };
            word = Rhythm.RemoveTone(word);
            Rhythm rhythm = Rhythm.EscapeRhythm(word.ToLower());// tach
            if (!(rhythm.HeadConsonant == ""))
            {
                if (arr3.Contains(rhythm.HeadConsonant))
                {
                    for (byte i = 0; i < arr2.Length; i++)
                    {
                        if (rhythm.Spelling.StartsWith(arr2[i]))
                        {
                            return false;
                        }
                    }
                }
                else if (arr4.Contains(rhythm.HeadConsonant))
                {
                    for (byte i = 0; i < arr1.Length; i++)
                    {
                        if (rhythm.Spelling.StartsWith(arr1[i]))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public override string Explain()
        {
            return "ERROR: Phụ âm đầu và vần không hợp lý";
        }
    }

    class Rule3 : Rule// Kiểm tra vị trí dấu
    {

        public override bool IsValid(string spelling)
        {
            return !MyRule.WRONG_POSITION_OF_TONE.Contains(spelling);
        }

        public override string Explain()
        {
            return "ERROR: Sai vị trí thanh điệu";
        }
    }

    class Rule4 : Rule// Kiểm tra số lượng thanh điệu
    {
        public override bool IsValid(string rhythm)
        {
            int myCount = 0;
            int k = 0;

            while (k < rhythm.Length)
            {
                for (int i = 0; i < Rhythm.VietnamLetters.Length; i++)
                {
                    if (rhythm[k] == Rhythm.VietnamLetters[i][0])
                    {
                        continue;
                    }
                    for (int j = 1; j < Rhythm.VietnamLetters[i].Length; j++)
                    {
                        if (rhythm[k] == Rhythm.VietnamLetters[i][j])
                        {
                            myCount++;
                            if (myCount > 1)
                                return false;
                            break;
                        }
                    }
                }
                k++;
            }

            return true;
        }

        public override string Explain()
        {
            return "ERROR: Số lượng thanh điệu quá lớn";
        }
    }
    // Kiểm tra các trường hợp phụ âm đầu đặc biệt với giê
    class Rule5 : Rule
    {
        public override bool IsValid(string rhythm)
        {
            int len = rhythm.Length;
            string s = Rhythm.RemoveTone(rhythm.ToLower());
            string xxx = "";
            if (len > 3)
            {
                xxx = s.Substring(0, 3);
                if (!xxx.Equals("giê"))
                    return true;
                string spelling = rhythm.Substring(1, len - 1);
                if (!MyRule.SPELLING.Contains(Rhythm.RemoveTone(spelling)))
                {
                    return false;
                }
                if (MyRule.WRONG_SPELLING_AND_TONE.Contains(spelling))
                {
                    return false;
                }
            }
            return true;
        }
        public override string Explain()
        {
            return "Error: Sai vần.";
        }
    }

    //kiểm tra sự ghép của phụ âm đầu và vần
    class Rule6 : Rule
    {
        public override bool IsValid(string word)
        {
            string checkSpecify = word.Clone().ToString();
            if (Rhythm.RemoveTone(checkSpecify).Equals("gin"))
            {
                return true;
            }
            Rhythm rhythm = Rhythm.EscapeRhythm(word.ToLower());
            if (rhythm.Spelling.Length > 4)
            {
                return false;
            }
            if (MyRule.WRONG_SPELLING_AND_TONE.Contains(rhythm.Spelling))
            {
                return false;
            }
            string spelling = Rhythm.RemoveTone(rhythm.Spelling);
            if (!MyRule.SPELLING.Contains(spelling))
            {
                return false;
            }
            return true;
        }

        public override string Explain()
        {
            return "ERROR: Sai vần hoặc phụ âm đầu";
        }
    }

    //lớp Rhythm để lưu cấu trúc một từ sau khi tách ra thành âm đầu, vần
    class Rhythm
    {
        public static readonly string[] VietnamLetters = new string[]
        {
            "aàáảãạ",
            "ăằắẳẵặ",
            "âầấẩẫậ",
            "eèéẻẽẹ",
            "êềếểễệ",
            "iìíỉĩị",
            "oòóỏõọ",
            "ôồốổỗộ",
            "ơờớởỡợ",
            "uùúủũụ",
            "ưừứửữự",
            "yỳýỷỹỵ"
        };
        private string _headConsonant;//phụ âm đầu
        private string _spelling;//vần
        public string HeadConsonant
        {
            get
            {
                return this._headConsonant;
            }
            set
            {
                this._headConsonant = value;
            }
        }

        public string Spelling
        {
            get
            {
                return this._spelling;
            }
            set
            {
                this._spelling = value;
            }
        }
        public Rhythm()
        {
            _headConsonant = null;
            _spelling = null;
        }

        public Rhythm(string _headConsonant, string _spelling)
        {
            this._headConsonant = _headConsonant;
            this._spelling = _spelling;
        }

        public static Rhythm EscapeRhythm(string rhythm)
        {
            for (byte i = 0; i < MyRule.HEAD_CONSONANT.Length; i++)
            {
                if (rhythm.StartsWith(MyRule.HEAD_CONSONANT[i]))
                {
                    Rhythm r = new Rhythm();
                    r.HeadConsonant = MyRule.HEAD_CONSONANT[i];
                    r.Spelling = rhythm.Substring(MyRule.HEAD_CONSONANT[i].Length);
                    return r;
                }
            }
            return new Rhythm("", rhythm);
        }

        public static string RemoveTone(string rhythm)
        {
            for (byte i = 0; i < VietnamLetters.Length; i++)
            {
                for (byte j = 1; j < VietnamLetters[i].Length; j++)
                {
                    rhythm = rhythm.Replace(VietnamLetters[i][j], VietnamLetters[i][0]);
                }
            }
            return rhythm;
        }

        public static string[] splitRhythm(string content)
        {
            //string pattern = "(\\W*\\W+\\W*)";
            //return Regex.Split(content, pattern);
            char[] separator = new char[] { '“', '”', ' ', ',', '.', ';', '(', ')', '[', ']', '{', '}', '/', '\\', '\'', '"', '-', '~', '!', '?', '*', '\n', '\t', ':' };
            return content.Split(separator);
        }

        public static bool isSeparator(char c)
        {
            char[] separator = new char[] { '“', '”', ' ', ',', '.', ';', '(', ')', '[', ']', '{', '}', '/', '\\', '\'', '"', '-', '~', '!', '?', '*', '\n', '\t', ':' };
            return separator.Contains(c);
        }

        public static bool IsValidTonePos(string spelling)
        {
            return !MyRule.WRONG_POSITION_OF_TONE.Contains(spelling);
        }
    }
}
