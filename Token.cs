using System;

namespace LexicalAnalyzerOdev
{
    /// <summary>
    /// Leksik analiz sonucu elde edilen birimi (token) temsil eder.
    /// </summary>
    public class Token
    {
        // Değerler atandıktan sonra değiştirilemesin diye sadece 'get'
        public string Lexeme { get; }
        public  string TokenType { get; }
        public int Line { get; }
        public int Column { get; }

        /// <summary>
        /// Yeni bir Token nesnesi oluşturur.
        /// </summary>
        public Token(string lexeme, string tokenType, int line, int column)
        {
          
            this.Lexeme = lexeme;
            this.TokenType = tokenType;
            this.Line = line;
            this.Column = column;
        }

        public override string ToString()
        {
            return $"Lexeme: \"{Lexeme}\", Type: {TokenType}, Konum: {Line}:{Column}";
        }
    }
}