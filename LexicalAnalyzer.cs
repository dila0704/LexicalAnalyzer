using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace LexicalAnalyzerOdev
{
    public class LexicalAnalyzer
    {
        private readonly HashSet<string> keywords = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        private readonly Dictionary<string, string> defines = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public IReadOnlyDictionary<string, string> DefinedValues => defines;

        public bool LoadKeywords(string path)
        {
            keywords.Clear();
            try
            {
                if (!File.Exists(path)) return false;

                foreach (var line in File.ReadAllLines(path))
                {
                    var trimmedLine = line.Trim();
                    var parts = trimmedLine.Split(new[] { ',', ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var part in parts)
                    {
                        if (!string.IsNullOrEmpty(part))
                            keywords.Add(part);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private string ProcessPreprocessor(string source)
        {
            defines.Clear();
            var lines = new List<string>();

            using (var sr = new StringReader(source))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var trimmed = line.Trim();

                    if (trimmed.StartsWith("#define", StringComparison.OrdinalIgnoreCase))
                    {
                        var parts = Regex.Split(trimmed, @"\s+");
                        if (parts.Length >= 3)
                        {
                            var name = parts[1];
                            var val = string.Join(" ", parts, 2, parts.Length - 2);
                            defines[name] = val;
                        }
                        continue;
                    }
                    if (trimmed.StartsWith("#")) continue;

                    lines.Add(line);
                }
            }

            var processedSource = string.Join(Environment.NewLine, lines);

            foreach (var kv in defines)
            {
                processedSource = Regex.Replace(processedSource, $@"\b{Regex.Escape(kv.Key)}\b", kv.Value);
            }
            return processedSource;
        }

        private string RemoveComments(string source)
        {
            source = Regex.Replace(source, @"//[^\r\n]*", "", RegexOptions.Multiline);
            source = Regex.Replace(source, @"/\*.*?\*/", "", RegexOptions.Singleline);
            return source;
        }

        public List<Token> Analyze(string source)
        {
            var tokens = new List<Token>();
            if (string.IsNullOrEmpty(source)) return tokens;

            source = ProcessPreprocessor(source);
            source = RemoveComments(source);

            int line = 1, col = 1, i = 0;

            while (i < source.Length)
            {
                char c = source[i];
                int startCol = col;
                int startIndex = i;

                // 1. Konum Güncelleme ve Boşlukları Atla
                if (c == '\r') { i++; continue; }
                if (c == '\n') { line++; col = 1; i++; continue; }
                if (char.IsWhiteSpace(c)) { i++; col++; continue; }

                // 2. Identifier veya Keyword
                if (char.IsLetter(c) || c == '_')
                {
                    while (i < source.Length && (char.IsLetterOrDigit(source[i]) || source[i] == '_'))
                    {
                        i++; col++;
                    }
                    string lexeme = source.Substring(startIndex, i - startIndex);
                    string tokenType = keywords.Contains(lexeme) ? "Keyword" : "Identifier";
                    tokens.Add(new Token(lexeme, tokenType, line, startCol));
                    continue;
                }

                // 3. Number Literal
                if (char.IsDigit(c))
                {
                    bool hasDot = false;
                    string type = "IntegerLiteral";

                    while (i < source.Length)
                    {
                        char current = source[i];
                        if (char.IsDigit(current))
                        {
                            // Devam
                        }
                        else if (current == '.' && !hasDot)
                        {
                            hasDot = true;
                            type = "FloatLiteral";
                        }
                        else
                        {
                            break;
                        }
                        i++; col++;
                    }
                    string lexeme = source.Substring(startIndex, i - startIndex);
                    tokens.Add(new Token(lexeme, type, line, startCol));
                    continue;
                }

                // 4. String Literal
                if (c == '\"')
                {
                    i++; col++;
                    bool isClosed = false;

                    while (i < source.Length)
                    {
                        char current = source[i];

                        if (current == '\"')
                        {
                            i++; col++;
                            isClosed = true;
                            break;
                        }
                        else if (current == '\\' && i + 1 < source.Length)
                        {
                            i += 2; col += 2;
                            continue;
                        }

                        if (current == '\n') { line++; col = 1; } else col++;
                        i++;
                    }

                    int length = i - startIndex;
                    string lexeme = source.Substring(startIndex, length);

                    tokens.Add(new Token(lexeme, isClosed ? "StringLiteral" : "UnclosedStringError", line, startCol));
                    continue;
                }

                // 5. Operatör ve Semboller

                // İki karakterli operatörler
                string twoChar = i + 1 < source.Length ? source.Substring(i, 2) : null;
                string opType = GetTwoCharOperatorType(twoChar);

                if (opType != "Unknown" && opType != null)
                {
                    tokens.Add(new Token(twoChar, opType, line, startCol));
                    i += 2; col += 2;
                    continue;
                }

                // Tek karakterli operatörler/semboller
                string singleType = GetSingleCharTokenType(c);
                if (singleType != "Unknown")
                {
                    tokens.Add(new Token(c.ToString(), singleType, line, startCol));
                    i++; col++;
                    continue;
                }

                // 6. Bilinmeyen Karakter
                tokens.Add(new Token(c.ToString(), "Unknown", line, startCol));
                i++; col++;
            }

            return tokens;
        }

        // ==========================================================
        // YARDIMCI METOTLAR
        // ==========================================================

        private string GetTwoCharOperatorType(string two)
        {
            if (two == null) return null;

            if (two == "==" || two == "!=" || two == "<=" || two == ">=")
            {
                return "RelationalOp";
            }
            else if (two == "++" || two == "--")
            {
                return "UnaryOp";
            }
            else if (two == "&&" || two == "||")
            {
                return "LogicalOp";
            }
            else if (two == "+=" || two == "-=" || two == "*=" || two == "/=" || two == "%=")
            {
                return "AssignmentOp";
            }
            else
            {
                return "Unknown";
            }
        }

        private string GetSingleCharTokenType(char c)
        {
            switch (c)
            {
                case '+':
                case '-':
                case '*':
                case '/':
                case '%':
                    return "ArithmeticOp";

                case '=':
                    return "Assignment";

                case ';':
                case ',':
                    return "Punctuation";

                case '(':
                case ')':
                case '{':
                case '}':
                case '[':
                case ']':
                    return "Delimiter";

                case '<':
                case '>':
                    return "RelationalOp";

                case '!':
                case '&':
                case '|':
                    return "LogicalOp";

                case '.':
                    return "Dot";

                default:
                    return "Unknown";
            }
        }
    }
}